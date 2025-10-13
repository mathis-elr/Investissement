using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Investissement
{

    public enum ModeEdition
    {
        /*publique dans le projet car utilisé dans plusieurs classes*/
        ajouter,
        supprimer,
        modifier
    }

    public partial class Form1 : MetroForm
    {
        /*ATTRIBUTS*/
        private MetroStyleManager styleManager;
        public BDD maBDD;
       

        public ActifController actifController;
        public ModeleInvestController modeleInvestController;
        public TransactionController transactionController;




        /*CONSTRUCTEUR*/
        public Form1()
        {
            styleManager = new MetroStyleManager();
            styleManager.Owner = this;

            /*GESTION DE LA CONNECTION A LA BASE DE DONNEE*/
            this.maBDD = new BDD("Data Source=C:\\Users\\mathi\\Documents\\prog perso\\c#\\Investissement\\bd\\historique_transactions.db");
            maBDD.ouvrirBDD();

            /*CLASSES QUI GERENT LA LOGIQUE DE CHAQUE CONCEPT*/
            actifController = new ActifController(this, this.maBDD);
            modeleInvestController = new ModeleInvestController(this, this.maBDD);
            transactionController = new TransactionController(this, this.maBDD);

            InitializeComponent();
            
            this.FormClosing += MyForm_FormClosing;
        }

        /*INITIALISATION*/
        private void Form1_Load(object sender, EventArgs e)
        {

            navigation.Style = MetroFramework.MetroColorStyle.Yellow;
            navigation.Theme = MetroFramework.MetroThemeStyle.Dark;

            /******************************************************
             *  Remplissage du tableau avec les actifs existants  *
             ******************************************************/
            this.gridActifListeActifs();    
            actifController.chargerActifs();

            /*********************************************************************
             *  replissage du comboBox avec les Modeles d'investissement existant*
             *********************************************************************/
            boxModeles.Text = "liste actifs";
            modeleInvestController.chargerModeles();

            /*******************************
             *  interception d'evenements  *
             *******************************/
            //boutons
            btnAjoutActifs.Click += BtnAjoutActifs;
            btnSupprActifOuTransactionInvest.Click += BtnSupprActif;

            btnInterfaceCreationModel.Click += BtnInterfaceCreationModele;
            btnInterfaceEditerModeleInvest.Click += BtnInterfaceEditerModeleInvest;
            btnSupprModele.Click += BtnSupprModele;
            btnQuitterInterfaceCreationModele.Click += BtnQuitterInterfaceEditionOuCreationModele;

            btnInvest.Click += BtnValiderInvest;

            btnQuitter.Click += BtnQuitter;

            //comboBox
            boxModeles.SelectedIndexChanged += (s, _) => changerModele();
        }


        /*ENCAPSULATION*/
        public DataGridView getGridViewActifs()
        {
            return this.gridActifs;
        }

        public MetroComboBox getComboBoxModeles()
        {
            return this.boxModeles;
        }

        public Label getLabelDescriptionModele()
        {
            return this.labelDescrModele;
        }

        public MetroDateTime getDateInvest()
        {
            return this.dateInvest;
        }



        /**************
         ***METHODES***
         **************/

        /* EVENEMENTS COMBOBOX */
        public void changerModele()
        {
            string nomModele = ((DataRowView)boxModeles.SelectedItem)["nom"].ToString();
            modeleInvestController.choixModele(nomModele);

            if (nomModele  == "liste actifs")
            {
                this.btnAjoutActifs.Visible = true;
                this.btnInterfaceCreationModel.Enabled = true;
                this.btnSupprActifOuTransactionInvest.Visible = true;
                this.btnInterfaceEditerModeleInvest.Enabled = false;
                this.btnSupprModele.Enabled = false;

                this.btnSupprActifOuTransactionInvest.Click -= BtnSupprTransactionModele;
                this.btnSupprActifOuTransactionInvest.Click += BtnSupprActif;
            }
            else
            {
                this.btnSupprModele.Enabled = true;
                this.btnInterfaceEditerModeleInvest.Enabled = true;
                this.btnSupprActifOuTransactionInvest.Visible = false;
                this.btnInterfaceCreationModel.Enabled = false;
                this.btnAjoutActifs.Visible = false;

                this.btnSupprActifOuTransactionInvest.Click -= BtnSupprActif;
                this.btnSupprActifOuTransactionInvest.Click += BtnSupprTransactionModele;
            }
        }

        /*Differentes formes du gridActifs*/
        private void gridActifListeActifs()
        {
            this.gridActifs.Rows.Clear();
            this.gridActifs.Columns.Clear();
            this.gridActifs.Columns.Add("Nom", "Nom actif");
            this.gridActifs.Columns.Add("quantite", "quantite (€)");
            this.gridActifs.Columns.Add("prix", "prix (€)");
            this.gridActifs.Columns[0].ReadOnly = true;
            this.gridActifs.AllowUserToAddRows = false;
        }

        private void gridActifCreationModele()
        {
            this.gridActifs.Rows.Clear();
            this.gridActifs.Columns.Clear();
            this.gridActifs.AllowUserToAddRows = true;

            DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
            comboCol.HeaderText = "actif";
            comboCol.Name = "Nom";              
            DataGridViewComboBoxColumn listeActifs = comboCol;
            DataTable actifs = actifController.getActifs();
            comboCol.DataSource = actifs;
            comboCol.DisplayMember = "Nom";

            gridActifs.Columns.Add(comboCol);
            this.gridActifs.Columns.Add("quantite", "quantite (€)");
        }


        /* EVENEMENTS BOUTONS */
        private void BtnAjoutActifs(object sender, EventArgs e)
        {
            ActifInterface ajoutActif = new ActifInterface(this.actifController, ModeEdition.ajouter);
            ajoutActif.Show();
        }

        private void BtnSupprActif(object sender, EventArgs e)
        {
            if (actifController.supprActif())
            {
                MessageBox.Show("Actif supprimé avec succès", "Actif");
            }
        }

        private void BtnInterfaceCreationModele(object sender, EventArgs e)
        {
            this.gridActifCreationModele();
            this.labelTitreCreationOuEdition.Text = "Creation d'un modele";

            this.panelAjoutModele.Visible = true;
            this.btnSupprActifOuTransactionInvest.Visible = true;
            this.btnAjoutActifs.Visible = false;
            this.panelConfirmationInvest.Visible = false;
            this.pannelChoixModeles.Visible = false;
            this.btnSupprActifOuTransactionInvest.Visible = false;

            this.btnAjoutModeleInvest.Click -= BtnEnregistreEditModeleInvest;
            this.btnAjoutModeleInvest.Click += BtnAjouterModeleInvest;
        }

        private void BtnInterfaceEditerModeleInvest(object sender, EventArgs e)
        {
            this.labelTitreCreationOuEdition.Text = "Edition d'un modele";
            this.btnAjoutModeleInvest.Text = "Enregistrer les modifs";

            this.panelAjoutModele.Visible = true;
            this.btnSupprActifOuTransactionInvest.Visible = true;
            this.panelConfirmationInvest.Visible = false;
            this.pannelChoixModeles.Visible = false;
            this.btnAjoutActifs.Visible = false;

            this.btnSupprActifOuTransactionInvest.Click -= BtnSupprActif;
            this.btnSupprActifOuTransactionInvest.Click += BtnSupprTransactionModele;
        }

        private void BtnSupprTransactionModele(object sender, EventArgs e)
        {
            if (modeleInvestController.supprTransactionModele())
            {
                MessageBox.Show("transaction de modele supprimé avec succès", "Transaction Modele");
            }
        }

        private void BtnQuitterInterfaceEditionOuCreationModele(object sender, EventArgs e)
        {
            this.gridActifListeActifs();
            this.actifController.chargerActifs();

            this.panelConfirmationInvest.Visible = true;
            this.pannelChoixModeles.Visible = true;
            this.panelAjoutModele.Visible = false;
            this.btnAjoutActifs.Visible = true;

            this.btnSupprActifOuTransactionInvest.Click -= BtnSupprTransactionModele;
            this.btnSupprActifOuTransactionInvest.Click += BtnSupprActif;
        }

        private void BtnEnregistreEditModeleInvest(object sender, EventArgs e)
        {
            if (modeleInvestController.editTransactionModele())
            {
                this.gridActifListeActifs();
                MessageBox.Show("transaction de modele supprimé avec succès", "Transaction Modele");
            }
        }

        private void BtnAjouterModeleInvest(object sender, EventArgs e)
        {
            if (this.inputNomModele.Text == "")
            {
                MessageBox.Show("choisissez un nom", "Erreur nom vide");
                return;
            }

            if (this.inputDescriptionModele.Text == "")
            {
                MessageBox.Show("decrivez votre modèle", "Erreur description vide");
                return;
            }

            if (modeleInvestController.ajouterModele(this.inputNomModele.Text, this.inputDescriptionModele.Text))
            {
                this.gridActifListeActifs();
                this.actifController.chargerActifs();
                MessageBox.Show("Modele ajouté avec succès", "Modele");
            }
        }

        private void BtnSupprModele(object sender, EventArgs e)
        {
            string nomModele = ((DataRowView)boxModeles.SelectedItem)["nom"].ToString();
            if (modeleInvestController.supprModele(nomModele))
            {
                MessageBox.Show("Modele supprimé avec succès", "Modele");
            }
        }

        private void BtnValiderInvest(object sender, EventArgs e)
        {
            if(transactionController.ajouterInvestissement())
            {
                MessageBox.Show("Investissement effectué avec succès", "Investissement");
            }
            else
            {
                MessageBox.Show("Erreur Investissement non effectue", "Investissement");
            }
        }

        private void BtnQuitter(object sender, EventArgs e)
        {
            this.Close();
        }


        /* EVENEMENTS FERMUTURE DE LA FENETRE */
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            maBDD.fermerBDD();
        }
    }
}
