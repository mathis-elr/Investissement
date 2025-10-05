using ClosedXML.Excel;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;


namespace Investissement
{
    public partial class AjoutActif : MetroForm
    {
        public Form1 form;
        public AjoutActif(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

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

            if (nom != "" && type != "")
            {

                /*-------------------------------
                   Ajout dans la base de données
                *-------------------------------*/

                try
                {
                    string query = "INSERT INTO Actif VALUES(@nom,@type,@ISIN,@risque);";
                    var command = new SQLiteCommand(query, form.bdd);
                    command.Parameters.AddWithValue("@nom", nom);
                    command.Parameters.AddWithValue("@type", type);
                    command.Parameters.AddWithValue("@ISIN", isin);
                    command.Parameters.AddWithValue("@risque", risque);

                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "erreur insertion actif bdd");
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur ajout actif : nom ou type vide / actif déjà existant");
            }

            //on met a jour le tableau en consequence de l'ajout
            this.form.MajGridActifs();
        }
    }
}
