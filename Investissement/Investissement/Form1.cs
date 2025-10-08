using DocumentFormat.OpenXml.Wordprocessing;
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

        public Form1BDD form1bdd;
        public ActifBDD actifbdd;
        public ModeleInvestBDD modeleInvestbdd;
        public TransactionModeleBDD transactionModelebdd;
        public TransactionBDD transactionbdd;

        /*CONSTRUCTEUR*/
        public Form1()
        {
            styleManager = new MetroStyleManager();
            styleManager.Owner = this;

            /*GESTION DE LA CONNECTION A LA BASE DE DONNEE*/
            this.maBDD = new BDD("Data Source=C:\\Users\\mathi\\Documents\\prog perso\\c#\\Investissement\\bd\\historique_transactions.db");
            this.ouvrirBDD(this.maBDD);

            /*CLASSES QUI GERENT LA PARTIE SQL DE CHAQUE CONCEPT*/
            form1bdd = new Form1BDD(this.maBDD);
            modeleInvestbdd = new ModeleInvestBDD(this.maBDD);
            actifbdd = new ActifBDD(this.maBDD);
            transactionModelebdd = new TransactionModeleBDD(this.maBDD);
            transactionbdd = new TransactionBDD(this.maBDD);

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

            majGridActifs();
            majComboBoxModeles();
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


        public void majGridActifs()
        {
            this.gridActifs.Rows.Clear();

            try
            {
                foreach (var (nom, type) in actifbdd.getActifsGrid())
                {
                    this.gridActifs.Rows.Add(nom, type);
                }
            }
            catch(SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur sélection actifs BDD");
            }
        }
            

        public void majComboBoxModeles()
        {
            try
            {
                DataTable modeleInvest = modeleInvestbdd.getModeles();
                this.boxModeles.DataSource = modeleInvest;
                this.boxModeles.DisplayMember = "nom";
            }
            catch(SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur selection modeles BDD");
            }
        }

        public void insertionTransactionsModeleDepuisGrid(ModeleInvest modele)
        {
            foreach (DataGridViewRow transaction in this.gridActifs.Rows)
            {
                if (transaction.IsNewRow) continue; //ne prend pas en compte la ligne vide en bas

                string actif = transaction.Cells[0].Value.ToString();
                string type = transaction.Cells[1].Value.ToString();
                var quantiteVar = transaction.Cells[2].Value;
                long quantiteLong = 0;
                if (quantiteVar != DBNull.Value) quantiteLong = Convert.ToInt64(quantiteVar);

                if (quantiteLong !=0)
                {
                    TransactionModele transactionModele = new TransactionModele(actif, type, quantiteLong, modele);
                    modele.ajouterTransaction(transactionModele);
                }
            }
            modele.ajouterTransactions(this.transactionModelebdd);
        }


        /* EVENEMENTS CHOIX DANS UN COMBOBOX */
        public void changerModele(object sender, EventArgs e)
        {
            
            string nomModele = ((DataRowView)boxModeles.SelectedItem)["nom"].ToString();
            if (nomModele == "liste actifs")
            {
                majGridActifs();
            }
            else if (!string.IsNullOrEmpty(nomModele))
            {
                try
                {
                    (long id, string description) modeleChoisi = modeleInvestbdd.getModele(nomModele);
                    long id_modele = modeleChoisi.id;
                    this.labelDescrModele.Text = modeleChoisi.description;

                    try
                    {
                        this.gridActifs.Rows.Clear();

                        foreach (var (actif, type, quantite) in transactionModelebdd.getTransactionModele(id_modele))
                        {
                            this.gridActifs.Rows.Add(actif, type, quantite);
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur selection transaction modele par id_modele BDD");
                    }

                }
                catch(SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "Erreur selection modeles par nom BDD");
                }
            }
        }


        /* BOUTONS */
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

        private void BtnValiderInvest(object sender, EventArgs e)
        {
            foreach (DataGridViewRow transaction in this.gridActifs.Rows)
            {
                DateTime date = this.dateInvest.Value;    
                string actif = transaction.Cells[0].Value.ToString();
                string type = transaction.Cells[1].Value.ToString();
                var quantiteVar = transaction.Cells[2].Value;
                var prixVar = transaction.Cells[3].Value;

                long quantiteLong = 0;
                long prixLong = 0;

                if (quantiteVar != DBNull.Value) quantiteLong = Convert.ToInt64(quantiteVar);
                if (prixVar != DBNull.Value) prixLong = Convert.ToInt64(prixVar);

                if (quantiteLong != 0 && prixLong != 0)
                {
                    Transaction nvltransaction = new Transaction(date, actif, type, quantiteLong, prixLong);

                    try
                    {
                        transactionbdd.ajouterTransaction(nvltransaction);
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message,"erreur insertion transaction bdd");
                    }
                }

            }
        }

        private void BtnQuitter(object sender, EventArgs e)
        {
            this.Close();
        }


        /* EVENEMENTS FERMUTURE DE LA FENETRE */
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.fermerBDD(this.maBDD);
        }
    }
}
