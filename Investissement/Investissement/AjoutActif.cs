using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Investissement
{
    public partial class AjoutActif : MetroForm
    {

        /*ATTRIBUTS*/
        public Form1 form;

        /*CONSTRUCTEUR*/
        public AjoutActif(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        /*INITIALISATION*/
        private void AjoutActif_Load(object sender, EventArgs e)
        {
            //fenetre
            this.Text = "Ajouter un actif";
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Size = new Size(250, 220);

            //layout
            FlowLayoutPanel layoutPrincipal = new FlowLayoutPanel();
            layoutPrincipal.FlowDirection = FlowDirection.TopDown;
            layoutPrincipal.Dock = DockStyle.Fill;
            Padding padding = new Padding(10);

            //input
            MetroTextBox inputNom = new MetroTextBox();
            inputNom.WaterMark = "Nom";
            inputNom.Width = 100;
            layoutPrincipal.Controls.Add(inputNom);

            MetroTextBox inputType = new MetroTextBox();
            inputType.WaterMark = "Type";
            inputType.Width = 100;
            layoutPrincipal.Controls.Add(inputType);

            MetroTextBox inputISIN = new MetroTextBox();
            inputISIN.WaterMark = "ISIN";
            inputISIN.Width = 100;
            layoutPrincipal.Controls.Add(inputISIN);

            MetroTextBox inputRisque = new MetroTextBox();
            inputRisque.WaterMark = "Risque (securitaire ou risque)";
            inputRisque.Width = 100;
            layoutPrincipal.Controls.Add(inputRisque);

            //boutons
            MetroButton btnAjout = new MetroButton();
            btnAjout.Text = "Ajouter l'actif";
            btnAjout.AutoSize = true;
            btnAjout.UseCustomBackColor = true;
            btnAjout.BackColor = System.Drawing.Color.LightGreen;
            btnAjout.Click += (s, _) => AjouterActif(inputNom.Text, inputType.Text, inputISIN.Text, inputRisque.Text);
            layoutPrincipal.Controls.Add(btnAjout);

            //afficher les layouts
            this.Controls.Add(layoutPrincipal);
        }



        /**************
         ***METHODES***
         **************/
        private void AjouterActif(string nom, string type, string isin, string risque)
        {
            /*informer l'utilisateur de son erreur précise*/
            var selectionNoms = "SELECT nom FROM Actif;";
            var commandSelectionNoms = new SQLiteCommand(selectionNoms, form.bdd);
            var noms = commandSelectionNoms.ExecuteReader();

            while (noms.Read())
            {
                if (noms.GetString(0) == nom)
                {
                    MessageBox.Show("un actif du même nom existe déjà", "Erreur actif");
                    return;
                }
            }

            if (nom == "")
            {
                MessageBox.Show("choisissez un nom", "Erreur nom");
                return;
            }

            if (type == "")
            {
                MessageBox.Show("choisissez un type (ETF, crypto, action ...)", "Erreur type");
                return;
            }

            else
            {

                /*-------------------------------
                   Ajout dans la base de données
                *-------------------------------*/
                try
                {
                    string insertionActif = "INSERT INTO Actif VALUES(@nom,@type,@ISIN,@risque);";
                    var commandInsertionActif = new SQLiteCommand(insertionActif, form.bdd);
                    commandInsertionActif.Parameters.AddWithValue("@nom", nom);
                    commandInsertionActif.Parameters.AddWithValue("@type", type);
                    commandInsertionActif.Parameters.AddWithValue("@ISIN", isin);
                    commandInsertionActif.Parameters.AddWithValue("@risque", risque);

                    commandInsertionActif.ExecuteNonQuery();
                    commandInsertionActif.Dispose();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "Erreur insertion actif bdd");
                }

                this.form.MajGridActifs(); //mise a jour du tableau des actifs pour pouvoir investir dans l'actif ajouté, methode dans form1 car le tableau appartient à l'interface de form1
                this.Close();
            }
        }
    }
}
