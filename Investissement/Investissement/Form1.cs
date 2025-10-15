using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Investissement
{
    public partial class Form1 : MetroForm
    {
        /*ATTRIBUTS*/
        private MetroStyleManager styleManager;
        public BDD maBDD;
        public enum EtatBoutonValidation
        {
            ajouterActif,
            ajouterModele,
            editerModele,
        }

        public enum EtatBoutonSuppression
        {
            supprActif,
            supprTransactionModele
        }

        public EtatBoutonValidation etatBoutonValidation;
        public EtatBoutonSuppression etatBoutonSuppression = EtatBoutonSuppression.supprActif;

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

            /*Remplissage du tableau avec les actifs existants*/
            this.gridListeActifs();
            this.afficherActifs();

            /*Remplissage du comboBox avec les Modeles d'investissement existan*/
            boxModeles.Text = "liste actifs";
            modeleInvestController.chargerModeles();

            /*Interception d'evenements*/
            //boutons affichage d'interface
            btnInterfaceAjoutActif.Click += BtnInterfaceAjoutActif;
            btnInterfaceCreationModel.Click += BtnInterfaceCreationModele;
            btnInterfaceEditerModeleInvest.Click += BtnInterfaceEditerModeleInvest;
            btnQuittInterface.Click += BtnQuitterInterface;

            //evenement du bouton variable voir les methodes appellées
            btnValidation.Click += BtnChoixValidation;
            btnSupression.Click += BtnChoixSuppression;

            //boutons
            btnSupprModele.Click += BtnSupprModele;
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
            string modeleChoisi = ((DataRowView)boxModeles.SelectedItem)["nom"].ToString();
            this.labelDescrModele.Text = modeleInvestController.getDescriptionModeleInvest(modeleChoisi);

            if (modeleChoisi == "liste actifs")
            {
                this.afficherActifs();
                
                this.btnSupression.Visible = true;
                this.btnInterfaceAjoutActif.Visible = true;
                this.btnInterfaceCreationModel.Enabled = true;
                this.btnInterfaceEditerModeleInvest.Enabled = false;
                this.btnSupprModele.Enabled = false;
            }
            else
            {
                this.afficherTransactionsModele(modeleChoisi);

                this.btnSupprModele.Enabled = true;
                this.btnInterfaceEditerModeleInvest.Enabled = true;
                this.btnInterfaceCreationModel.Enabled = false;
                this.btnInterfaceAjoutActif.Visible = false;
                this.btnSupression.Visible = false;
            }
        }

        public void afficherActifs()
        {
            this.gridActifs.Rows.Clear();
            foreach (string nom in actifController.getListeActifs())
            {
                this.gridActifs.Rows.Add(nom);
            }
        }

        private void afficherTransactionsModele(string modele)
        {
            this.gridActifs.Rows.Clear();
            List<(string actif, long quantite)> transactions = modeleInvestController.getTransactionsModele(modele);
            if (transactions.Count != 0)
            {
                foreach (var (actif, quantite) in transactions)
                {
                    gridActifs.Rows.Add(actif, quantite);
                }
            }
        }

        /*Differentes formes du gridActifs*/
        private void gridListeActifs()
        {
            this.gridActifs.Rows.Clear();
            this.gridActifs.Columns.Clear();
            this.gridActifs.Columns.Add("Nom", "Nom actif");
            this.gridActifs.Columns.Add("quantite", "quantite (€)");
            this.gridActifs.Columns.Add("prix", "prix (€)");
            this.gridActifs.Columns[0].ReadOnly = true;
            this.gridActifs.AllowUserToAddRows = false;
        }

        private void gridCreationModele()
        {
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

        private void gridEditionModele()
        {
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

            string modeleChoisi = ((DataRowView)boxModeles.SelectedItem)["nom"].ToString();
            this.afficherTransactionsModele(modeleChoisi);
        }


        /*BOUTONS CHANGEMENTS D'INTERFACE*/
        private void BtnInterfaceAjoutActif(object sender, EventArgs e)
        {       
            this.labelTitreInterface.Text = "Ajouter un actif";
            this.btnValidation.Text = "Ajouter l'actif";

            this.panelAjoutActif.Visible = true;
            this.panelTitreQuitter.Visible = true;
            this.panelConfirmationInvest.Visible = false;
            this.btnInterfaceAjoutActif.Visible = false;
            this.pannelChoixModeles.Visible = false;
            this.labelChoixModele.Visible = false;

            this.etatBoutonValidation = EtatBoutonValidation.ajouterActif;

        }

        private void BtnInterfaceCreationModele(object sender, EventArgs e)
        {
            this.gridCreationModele();
            this.labelTitreInterface.Text = "Cree un modele";
            this.btnValidation.Text = "Ajouter le modele";

            this.btnValidation.Visible = true;
            this.panelAjoutModele.Visible = true;
            this.panelTitreQuitter.Visible = true;
            this.panelConfirmationInvest.Visible = false;
            this.btnInterfaceAjoutActif.Visible = false;
            this.pannelChoixModeles.Visible = false;
            this.labelChoixModele.Visible = false;
            this.btnSupression.Visible = false;

            this.etatBoutonValidation = EtatBoutonValidation.ajouterModele;
        }

        private void BtnInterfaceEditerModeleInvest(object sender, EventArgs e)
        {
            this.gridEditionModele();
            this.labelTitreInterface.Text = "Edition d'un modele";
            this.btnValidation.Text = "Enregistrer les modifs";
            
            
            this.btnValidation.Visible = true;
            this.panelAjoutModele.Visible = true;
            this.panelTitreQuitter.Visible = true;
            this.btnSupression.Visible = true;
            this.panelConfirmationInvest.Visible = false;
            this.btnInterfaceAjoutActif.Visible = false;
            this.pannelChoixModeles.Visible = false;
            this.labelChoixModele.Visible = false;

            string nomModele = ((DataRowView)this.boxModeles.SelectedItem)["nom"].ToString();
            string description = modeleInvestController.getDescriptionModeleInvest(nomModele);
            this.inputNomModeleInvest.Text = nomModele;
            this.inputDescriptionModeleInvest.Text = description;

            this.etatBoutonSuppression = EtatBoutonSuppression.supprTransactionModele;
            this.etatBoutonValidation = EtatBoutonValidation.editerModele;
        }

        private void BtnQuitterInterface(object sender, EventArgs e)
        {
            this.gridListeActifs();
            this.afficherActifs();

            this.labelChoixModele.Visible = true;
            this.pannelChoixModeles.Visible = true;
            this.btnInterfaceAjoutActif.Visible = true;
            this.panelConfirmationInvest.Visible = true;
            this.panelTitreQuitter.Visible = false;
            this.panelAjoutModele.Visible = false;
            this.panelAjoutActif.Visible = false;
            this.btnValidation.Visible = false;

            this.etatBoutonSuppression = EtatBoutonSuppression.supprActif;
        }

        /*ROLE BOUTONS EN FONCTION DE L'INTERFACE*/
        private void BtnChoixValidation(object sender, EventArgs e)
        {
            switch(this.etatBoutonValidation)
            {
                case EtatBoutonValidation.ajouterActif:
                    ajoutActif();
                    return;
                case EtatBoutonValidation.ajouterModele:
                    ajouterModeleInvest();
                    return;
                case EtatBoutonValidation.editerModele:
                    enregistreEditModeleInvest();
                    return;
            }
        }

        private void BtnChoixSuppression(object sender, EventArgs e)
        {
            switch (this.etatBoutonSuppression)
            {
                case EtatBoutonSuppression.supprActif:
                    supprActif();
                    return;
                case EtatBoutonSuppression.supprTransactionModele:
                    supprTransactionModele();
                    return;
            }
        }

        /*BOUTONS ACTION*/
        private void ajoutActif()
        {
            if(this.inputNomActif.Text == "")
            {
                MessageBox.Show("entrez un nom pour votre actif", "Actif");
                return;
            }
            if (this.inputTypeActif.Text == "")
            {
                MessageBox.Show("entrez le type de votre actif", "Actif");
                return;
            }
            if (this.inputRisqueActif.Text == "")
            {
                MessageBox.Show("entrez un niveau de rique d'investissement pour votre actif (faible, moyen,fort)", "Actif");
                return;
            }
            if (actifController.ajoutActif(this.inputNomActif.Text, this.inputTypeActif.Text, this.inputISINActif.Text, this.inputRisqueActif.Text))
            {
                this.afficherActifs();
                this.labelChoixModele.Visible = true;
                this.pannelChoixModeles.Visible = true;
                this.btnInterfaceAjoutActif.Visible = true;
                this.panelConfirmationInvest.Visible = true;
                this.btnSupression.Visible = true;
                this.panelTitreQuitter.Visible = false;
                this.panelAjoutActif.Visible = false;
                MessageBox.Show("Actif ajouté avec succès", "Actif");
            }
        }

        private void ajouterModeleInvest()
        {
            if (this.inputNomModeleInvest.Text == "")
            {
                MessageBox.Show("choisissez un nom", "Erreur nom vide");
                return;
            }

            if (this.inputDescriptionModeleInvest.Text == "")
            {
                MessageBox.Show("decrivez votre modèle", "Erreur description vide");
                return;
            }

            if (modeleInvestController.ajouterModele(this.inputNomModeleInvest.Text,this.inputDescriptionModeleInvest.Text))
            {
                this.gridListeActifs();
                this.afficherActifs();
                this.labelTitreInterface.Text = "Choix du modele";
                this.pannelChoixModeles.Visible = true;
                this.panelConfirmationInvest.Visible = true;
                this.panelTitreQuitter.Visible = false;
                this.panelAjoutModele.Visible = false;
                MessageBox.Show("Modele ajouté avec succès", "Modele");
            }
        }

        private void enregistreEditModeleInvest()
        {
            if (this.inputNomModeleInvest.Text == "")
            {
                MessageBox.Show("choisissez un nom", "Erreur nom vide");
                return;
            }

            if (this.inputDescriptionModeleInvest.Text == "")
            {
                MessageBox.Show("decrivez votre modèle", "Erreur description vide");
                return;
            }

            string nomModele = ((DataRowView)this.boxModeles.SelectedItem)["nom"].ToString();
            if (modeleInvestController.editTransactionModele(nomModele))
            {
                if (modeleInvestController.majNomDescription(nomModele, this.inputNomModeleInvest.Text, this.inputDescriptionModeleInvest.Text))
                {
                    this.gridListeActifs();
                    modeleInvestController.chargerModeles();
                    this.labelTitreInterface.Text = "Choix du modele";
                    this.pannelChoixModeles.Visible = true;
                    this.panelConfirmationInvest.Visible = true;
                    this.panelTitreQuitter.Visible = false;
                    this.panelAjoutModele.Visible = false;
                    this.inputNomModeleInvest.Clear();
                    this.inputDescriptionModeleInvest.Clear();
                    MessageBox.Show("enregistrement effectué avec succès", "Modele Invest");
                }
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

        private void supprTransactionModele()
        {
            if (modeleInvestController.supprTransactionModele())
            {
                MessageBox.Show("transaction de modele supprimé avec succès", "Transaction Modele");
            }
        }

        private void supprActif()
        {
            if (actifController.supprActif())
            {
                MessageBox.Show("Actif supprimé avec succès", "Actif");
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
