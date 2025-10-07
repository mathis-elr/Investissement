using MetroFramework.Components;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;


namespace Investissement
{

    public enum Mode
    {
        ajouter,
        supprimer,
        modifier
    }


    public partial class Form1 : MetroForm
    {
        /*ATTRIBUTS*/
        private MetroStyleManager styleManager;
        public BDD maBDD;

        public ActifBDD actifbdd;
        public ModeleInvestBDD modeleInvestbdd;

        /*CONSTRUCTEUR*/
        public Form1()
        {
            styleManager = new MetroStyleManager();
            styleManager.Owner = this;

            this.maBDD = new BDD("Data Source=C:\\Users\\mathi\\Documents\\prog perso\\c#\\Investissement\\bd\\historique_transactions.db");
            this.ouvrirBDD(maBDD);

            modeleInvestbdd = new ModeleInvestBDD(maBDD);
            actifbdd = new ActifBDD(maBDD);

            InitializeComponent();
            
            this.FormClosing += MyForm_FormClosing;
        }

        /*INITIALISATION*/
        private void Form1_Load(object sender, EventArgs e)
        {

            navigation.Style = MetroFramework.MetroColorStyle.Yellow;
            navigation.Theme = MetroFramework.MetroThemeStyle.Dark;

            /**********************************
             *  noms colonnes tableau actifs  *
             **********************************/
            this.gridActifs.Columns.Add("Nom", "Nom actif");
            this.gridActifs.Columns.Add("Type", "Type");
            this.gridActifs.Columns.Add("quantite", "quantite (€)");
            this.gridActifs.Columns.Add("prix", "prix (€)");

            MajGridActifs();
            majModeles();
            boxModeles.Text = "liste actifs";

            /****************************
             *  evenements des boutons  *
             ****************************/
            btnAjoutActifs.Click += BtnAjoutActifs;
            btnAjoutModele.Click += BtnAjoutModele;
            //this.btnDernierInvest.Click += BtnDernierInvest;
            btnInvest.Click += BtnValiderInvest;
            btnQuitter.Click += BtnQuitter;

            boxModeles.SelectedIndexChanged += changerModele;
        }



        /**************
         ***METHODES***
         **************/
        public void ouvrirBDD(BDD bdd)
        {
            try
            {
                bdd.ouvrirBDD();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void fermerBDD(BDD bdd)
        {
            try
            {
                bdd.fermerBDD();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public void MajGridActifs()
        {
            this.gridActifs.Rows.Clear();

            try
            {
                string query = "SELECT nom,type FROM Actif ORDER BY type;";
                var command = new SQLiteCommand(query, this.maBDD.connexion);

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

        public void majModeles()
        {
            var query = "SELECT nom FROM ModeleInvest;";
            var command = new SQLiteCommand(query, this.maBDD.connexion);
            var noms = command.ExecuteReader();

            var ModeleInvest = new DataTable();
            ModeleInvest.Load(noms);

            this.boxModeles.DataSource = ModeleInvest;
            this.boxModeles.DisplayMember = "nom";
            this.boxModeles.DisplayMember = "id";
        }

        public void insertionTransactionsNvModele(string nom)
        {
            string selectionIdModele = "SELECT id FROM ModeleInvest WHERE nom=@nom";
            var commandSelectionIdModele = new SQLiteCommand(selectionIdModele, this.maBDD.connexion);
            commandSelectionIdModele.Parameters.AddWithValue("@nom", nom);
            var idModele = commandSelectionIdModele.ExecuteScalar();

            foreach (DataGridViewRow transaction in this.gridActifs.Rows)
            {
                var actif = transaction.Cells[0].Value;
                var type = transaction.Cells[1].Value;
                var quantite = transaction.Cells[2].Value;

                if (actif!=null && type!=null && quantite!=null)
                {
                    //on ajoute pas le prix qui est variable
                    string insertionTransactions = "INSERT INTO TransactionsModele(actif,type,quantite,idModele) VALUES(@actif,@type,@quantite,@idModele);";
                    var commandInsertionTransactions = new SQLiteCommand(insertionTransactions, this.maBDD.connexion);
                    commandInsertionTransactions.Parameters.AddWithValue("@actif", actif);
                    commandInsertionTransactions.Parameters.AddWithValue("@type", type);
                    commandInsertionTransactions.Parameters.AddWithValue("@quantite", quantite);
                    commandInsertionTransactions.Parameters.AddWithValue("@idModele", idModele);
                    commandInsertionTransactions.ExecuteNonQuery();

                    commandInsertionTransactions.Dispose();
                }
            }

            commandSelectionIdModele.Dispose();
        }


        /* EVENEMENTS CHOIX DANS UN COMBOBOX */
        public void changerModele(object sender, EventArgs e)
        {
            
            string nomModele = ((DataRowView)boxModeles.SelectedItem)["nom"].ToString();
            if (nomModele == "liste actifs")
            {
                MajGridActifs();
            }
            else if (!string.IsNullOrEmpty(nomModele))
            {
                var query = "SELECT id,description FROM ModeleInvest WHERE nom=@nom;";
                var command = new SQLiteCommand(query, this.maBDD.connexion);
                command.Parameters.AddWithValue("@nom", nomModele);
                var modeleChoisi = command.ExecuteReader();

                modeleChoisi.Read();
                long idModele = modeleChoisi.GetInt64(0);
                this.labelDescrModele.Text = modeleChoisi.GetString(1);

                /*affecter les transactions du modele chosis au tableau*/
                this.gridActifs.Rows.Clear();
                var queryTransactions = "SELECT actif,type,quantite,prix FROM TransactionsModele WHERE idModele=@idModele;";
                var commandTransactions = new SQLiteCommand(queryTransactions, this.maBDD.connexion);
                commandTransactions.Parameters.AddWithValue("@idModele", idModele);
                modeleChoisi.Dispose();
                var transactions = commandTransactions.ExecuteReader();

                while (transactions.Read())
                {
                    this.gridActifs.Rows.Add(transactions.GetString(0), transactions.GetString(1), transactions.GetInt64(2), transactions.GetInt64(3));
                }

                transactions.Dispose();
            }
        }


        /* BOUTONS */
        private void BtnValiderInvest(object sender, EventArgs e)
        {
            foreach (DataGridViewRow transaction in this.gridActifs.Rows)
            {
                var date = this.dateInvest.Value;    
                var actif = transaction.Cells[0].Value;
                var type = transaction.Cells[1].Value;
                var quantite = transaction.Cells[2].Value;
                var prix = transaction.Cells[3].Value;
                if (quantite != null)
                {
                    try
                    {
                        string query = "INSERT INTO [Transaction] (date,actif,type,quantite,prix) VALUES (@date,@actif,@type,@quantite,@prix);"; //entre crochets car Transaction est un mot réservé en sql
                        var command = new SQLiteCommand(query, this.maBDD.connexion);

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

        private void BtnAjoutActifs(object sender, EventArgs e)
        {
            ActifInterface ajoutActif = new ActifInterface(this, this.actifbdd, Mode.ajouter);
            ajoutActif.Show();
        }

        private void BtnAjoutModele(object sender, EventArgs e)
        {
            ModeleInvestInterface ajoutModeleInvest = new ModeleInvestInterface(this, this.modeleInvestbdd, Mode.ajouter);
            ajoutModeleInvest.Show();
        }

        private void BtnQuitter(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void BtnDernierInvest(object sender, EventArgs e)
        //{
        //    /*On récupère la date du dernier investissement*/
        //    string queryDate = "SELECT date FROM [Transaction] ORDER BY date DESC LIMIT 1;"; 
        //    var command = new SQLiteCommand(queryDate, bdd);
        //    var date = command.ExecuteScalar(); //commande d'execution pour SELECT qui retourne qu'une seule valeur

        //    //on varifie qu'il y a au moins une transaction
        //    if (date != null) 
        //    {
        //        /*grace a cette date on recupère toutes les transactions effectuées ce jour là*/
        //        string queryDernierInvest = "SELECT actif,type,quantite,prix FROM [Transaction] WHERE date=@date;";
        //        var command2 = new SQLiteCommand(queryDernierInvest, bdd);
        //        command2.Parameters.AddWithValue("@date", date);
        //        var Investissements = command2.ExecuteReader();

        //        //on parcours les transactions
        //        while (Investissements.Read())
        //        {
        //            this.gridActifs.Rows.Add(Investissements.GetString(0), Investissements.GetString(1), Investissements.GetDouble(2), Investissements.GetDouble(3));
        //        }

        //        command.Dispose();
        //        command2.Dispose();

        //    }
        //    else
        //    {
        //        MessageBox.Show("aucune transactions dans la base de données");
        //    }
        //}

        /* EVENEMENTS LORS DE LA FERMUTURE DE LA FENETRE */
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.fermerBDD(this.maBDD);
        }
    }
}
