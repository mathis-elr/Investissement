using ClosedXML.Excel;
using CuoreUI;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Investissement
{
    public partial class Form1 : MetroForm
    {
        /*ATTRIBUTS*/
        public MetroGrid gridActifs;
        public MetroDateTime date;
        public SQLiteConnection bdd;
        public MetroButton btnDernierInvest;

        /*CONSTRUCTEUR*/
        public Form1()
        {
            InitializeComponent();  
            OuvrirBdd();
            this.FormClosing += MyForm_FormClosing;
        }

        /*INITIALISATION*/
        private void Form1_Load(object sender, EventArgs e)
        {

            //fenetre
            this.Text = "Ajouter un investissement";
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;


            //layout
            TableLayoutPanel layoutPrincipal = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 2,
                AutoSize = true
            };

            FlowLayoutPanel layout = new FlowLayoutPanel();
            layout.FlowDirection = FlowDirection.LeftToRight;
            layout.AutoSize = true;
            layout.Padding = new Padding(10);

            FlowLayoutPanel layoutActifs = new FlowLayoutPanel();
            layoutActifs.FlowDirection = FlowDirection.LeftToRight;
            layoutActifs.AutoSize = true;
            layoutActifs.Padding = new Padding(10);

            FlowLayoutPanel layoutBoutons = new FlowLayoutPanel();
            layoutActifs.FlowDirection = FlowDirection.TopDown;
            layoutActifs.AutoSize = true;
            layoutActifs.Padding = new Padding(10);


            //grille des actifs
            this.gridActifs = new MetroGrid();
            this.gridActifs.Columns.Add("Nom", "Nom actif");
            this.gridActifs.Columns.Add("Type", "Type");
            this.gridActifs.Columns.Add("quantite", "quantite (€)"); 
            this.gridActifs.Columns.Add("prix", "prix (€)");
            this.gridActifs.Width = 310;
            this.gridActifs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridActifs.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MajGridActifs();


            //entry date
            this.date = new MetroDateTime();
            this.date.Format = DateTimePickerFormat.Custom;
            this.date.CustomFormat = "dd-MM-yyyy";
            this.date.Width = 150;



            //boutons
            this.btnDernierInvest = new MetroButton();
            this.btnDernierInvest.Text = "Afficher dernier investissement";
            this.btnDernierInvest.AutoSize = true;
            this.btnDernierInvest.UseCustomBackColor = true; //obligé sinon on peut pas modifier la couleur
            this.btnDernierInvest.BackColor = System.Drawing.Color.LightBlue;
            this.btnDernierInvest.Click += (s, _) => BtnDernierInvest();

            MetroButton btnAjoutActif = new MetroButton();
            btnAjoutActif.Text = "+";
            btnAjoutActif.AutoSize = true;
            btnAjoutActif.UseCustomBackColor = true;
            btnAjoutActif.BackColor = System.Drawing.Color.Green;
            btnAjoutActif.Click += BtnAjoutActif;

            MetroButton btnAnalyse = new MetroButton();
            btnAnalyse.Text = "Analyse Patrimoine";
            btnAnalyse.AutoSize = true;
            btnAnalyse.UseCustomBackColor = true;
            btnAnalyse.BackColor = System.Drawing.Color.Gold;
            btnAnalyse.Click += BtnAnalyse;

            MetroButton btnInvest = new MetroButton();
            btnInvest.Text = "Valider l'investissement";
            btnInvest.AutoSize = true;
            btnInvest.UseCustomBackColor = true; //obligé sinon on peut pas modifier la couleur
            btnInvest.BackColor = System.Drawing.Color.LightGreen;
            btnInvest.Click += (s, _) => BtnValiderInvest();


            //mettre les elmts dans les layouts

            layoutBoutons.Controls.Add(btnAjoutActif);
            layoutBoutons.Controls.Add(btnDernierInvest);
            layoutBoutons.Controls.Add(btnAnalyse);

            layoutActifs.Controls.Add(this.gridActifs);

            layout.Controls.Add(date);
            layout.Controls.Add(btnInvest);

            //mettre les layouts dans le layout principal
            layoutPrincipal.Controls.Add(layoutActifs, 0, 0);
            layoutPrincipal.Controls.Add(layoutBoutons, 1, 0);
            layoutPrincipal.Controls.Add(layout, 0, 1);



            //afficher les elmts
            this.Controls.Add(layoutPrincipal);

        }



        /**************
         ***METHODES***
         **************/
        public void OuvrirBdd()
        {
            try
            {
                string connectionString = @"Data Source=C:\Users\mathi\Documents\prog perso\c#\Investissement\bd\historique_transactions.db";
                this.bdd = new SQLiteConnection(connectionString);

                this.bdd.Open();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message,"erreur ouverture bdd");
            }
        }


        public void MajGridActifs()
        {
            this.gridActifs.Rows.Clear();

            try
            {
                string query = "SELECT nom,type FROM Actif ORDER BY type;";
                var command = new SQLiteCommand(query, bdd);

                var actif = command.ExecuteReader(); //commande d'execution pour SELECT
                

                while (actif.Read())
                {
                    this.gridActifs.Rows.Add(actif.GetString(0), actif.GetString(1));
                    //pour chaque actif ajouter son type dans une colonne a coté
                }

                actif.Dispose();

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message,"erreur selection bdd");
            }
        }


        private void BtnValiderInvest()
        {
            foreach (DataGridViewRow transaction in this.gridActifs.Rows)
            {
                var date = this.date.Value;    
                var actif = transaction.Cells[0].Value;
                var type = transaction.Cells[1].Value;
                var quantite = transaction.Cells[2].Value;
                var prix = transaction.Cells[3].Value;
                if (quantite != null)
                {
                    try
                    {
                        string query = "INSERT INTO [Transaction] (date,actif,type,quantite,prix) VALUES (@date,@actif,@type,@quantite,@prix);"; //entre crochets car Transaction est un mot réservé en sql
                        var command = new SQLiteCommand(query, bdd);

                        command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@actif", actif.ToString());
                        command.Parameters.AddWithValue("@type", type.ToString());
                        command.Parameters.AddWithValue("@quantite", Convert.ToDouble(quantite));
                        command.Parameters.AddWithValue("@prix", Convert.ToDouble(prix));

                        command.ExecuteNonQuery(); //commande d'executuion poour INSERT, UPDATE, DELETE
                        command.Dispose();
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message,"erreur insertion transaction bdd");
                    }
                }

            }
        }

        private void BtnAjoutActif(object sender, EventArgs e)
        {
            AjoutActif ajoutActif = new AjoutActif(this);
            ajoutActif.Show();
        }

        private void BtnAnalyse(object sender, EventArgs e)
        {
            AnalysePatrimoine analyse= new AnalysePatrimoine(this);
            analyse.Show();
        }

        private void BtnDernierInvest()
        {
            /*On récupère la date du dernier investissement*/
            string queryDate = "SELECT date FROM [Transaction] ORDER BY date DESC LIMIT 1;"; 
            var command = new SQLiteCommand(queryDate, bdd);
            var date = command.ExecuteScalar(); //commande d'execution pour SELECT qui retourne qu'une seule valeur

            //on varifie qu'il y a au moins une transaction
            if (date != null) 
            {
                /*grace a cette date on recupère toutes les transactions effectuées ce jour là*/
                string queryDernierInvest = "SELECT actif,type,quantite,prix FROM [Transaction] WHERE date=@date;";
                var command2 = new SQLiteCommand(queryDernierInvest, bdd);
                command2.Parameters.AddWithValue("@date", date);
                var Investissements = command2.ExecuteReader();

                //on parcours les transactions
                while (Investissements.Read())
                {
                    this.gridActifs.Rows.Add(Investissements.GetString(0), Investissements.GetString(1), Investissements.GetDouble(2), Investissements.GetDouble(3));
                }

                command.Dispose();
                command2.Dispose();

                //on change le texte et l'action du bouton
                this.btnDernierInvest.Text = "Afficher les actifs";
                this.btnDernierInvest.Click += (s, _) => BtnInvestGeneral();
            }
            else
            {
                this.btnDernierInvest.BackColor = System.Drawing.Color.Red;
            }
        }

        public void BtnInvestGeneral() 
        { 
            this.gridActifs.Rows.Clear(); //on vide le tableau

            //on remet la grille des actifs
            MajGridActifs();

            //on change le texte et l'action du bouton
            this.btnDernierInvest.Text = "Afficher dernier investissement";
            this.btnDernierInvest.Click += (s, _) => BtnDernierInvest();
        } 


        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.bdd != null && this.bdd.State == System.Data.ConnectionState.Open)
                {
                    this.bdd.Close();
                    this.bdd.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur fermeture BDD");
            }
        }

    }
}
