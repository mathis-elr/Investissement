using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Investissement.Form1;

namespace Investissement
{
    public partial class InvestirVue : UserControl
    {
        public ActifController actifController;
        public ModeleInvestController modeleInvestController;
        public TransactionController transactionController;


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


        public InvestirVue(ActifController actifController, ModeleInvestController modeleInvestController, TransactionController transactionController)
        {
            this.actifController = actifController;
            this.modeleInvestController = modeleInvestController;
            this.transactionController = transactionController;

            InitializeComponent();
            this.Load += InvestirVue_Load;
        }

        private void InvestirVue_Load(object sender, EventArgs e)
        {
            /*Remplissage du tableau avec les actifs existants*/
            this.gridListeActifs();
            this.afficherActifs();

            /*Remplissage du comboBox avec les Modeles d'investissement existant*/
            this.chargerModeles();
            //boxModeles.SelectedIndex = 0; //la liste d'actif

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

            //comboBox
            boxModeles.SelectedIndexChanged += (s, _) => changerModele();
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

        public void chargerModeles()
        {
            MetroComboBox modeles = this.boxModeles;
            DataTable modeleInvest = modeleInvestController.getModelesDataTable();
            modeles.DataSource = modeleInvest;
            modeles.ValueMember = "id";
            modeles.DisplayMember = "nom";
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

            this.btnValidation.Visible = true;
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

            this.btnSupression.Visible = true;
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
            switch (this.etatBoutonValidation)
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


        /*ACTIONS BOUTONS*/
        private void ajoutActif()
        {
            Actif nvActif = new Actif(this.inputNomActif.Text, this.inputTypeActif.Text, this.inputISINActif.Text, this.inputRisqueActif.Text);
            if (actifController.ajoutActif(nvActif))
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
        private void supprActif()
        {
            if (this.gridActifs.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.gridActifs.SelectedRows[0];
                string nom = row.Cells["Nom"].Value.ToString();
                DialogResult result = MessageBox.Show(
                    "Voulez-vous vraiment supprimer cet actif ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    if (actifController.supprActif(nom))
                    {
                        this.afficherActifs();
                        MessageBox.Show("Actif supprimé avec succès", "Actif");
                    }
                }
            }
        }

        private void ajouterModeleInvest()
        {
            try
            {
                ModeleInvest modeleInvest = new ModeleInvest(this.inputNomModeleInvest.Text, this.inputDescriptionModeleInvest.Text);
                if (modeleInvestController.ajouterModele(modeleInvest))
                {
                    this.ajouterTransactionsModele(modeleInvest);
                    this.chargerModeles();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur insertion Modele");
            }
        }

        private void ajouterTransactionsModele(ModeleInvest modeleInvest)
        {
            foreach (DataGridViewRow transaction in this.gridActifs.Rows)
            {
                if (transaction.IsNewRow){ continue; } //ne prend pas en compte la ligne vide en bas

                string actif = transaction.Cells[0].Value.ToString();
                var quantiteVar = transaction.Cells[1].Value;
                long quantiteLong = 0;
                if (quantiteVar != DBNull.Value){ quantiteLong = Convert.ToInt64(quantiteVar); }

                TransactionModele transactionModele = new TransactionModele(actif, quantiteLong, modeleInvest.id);
                modeleInvestController.ajouterTransactionsModele(transactionModele);
            }
        }

        private void enregistreEditModeleInvest()
        {
            //pour la modification d'un modele on supprime toutes les transaction associées et on rajoute les nouvelles/modifiées
            //pour le nom et la description on fait une mise a jour directement

            string nomModele = ((DataRowView)this.boxModeles.SelectedItem)["nom"].ToString();
            ModeleInvest ModeleInvestModifie = new ModeleInvest(this.inputNomModeleInvest.Text, this.inputDescriptionModeleInvest.Text);
            ModeleInvestModifie.id = Convert.ToInt64(boxModeles.SelectedValue);

            if (modeleInvestController.editTransactionModele(nomModele))
            {
                this.ajouterTransactionsModele(ModeleInvestModifie);
                if (modeleInvestController.majNomDescription(nomModele, ModeleInvestModifie))
                {
                    this.gridListeActifs();
                    this.chargerModeles();
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
            DialogResult result = MessageBox.Show(
                "Voulez-vous vraiment supprimer ce modele ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                string nomModele = ((DataRowView)boxModeles.SelectedItem)["nom"].ToString();
                if (modeleInvestController.supprModele(nomModele))
                {
                    this.chargerModeles();
                    MessageBox.Show("Modele supprimé avec succès", "Modele");
                }
            }
        }

        private void supprTransactionModele()
        {
            if (this.gridActifs.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.gridActifs.SelectedRows[0];
                string nomActif = row.Cells["Nom"].Value.ToString();
                DialogResult result = MessageBox.Show(
                    "Voulez-vous vraiment supprimer cette transaction ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    if (modeleInvestController.supprTransactionModele(nomActif))
                    {
                        this.changerModele(); //pour que la grille se mette a jour en consequence de la suppression d'une transaction
                        MessageBox.Show("transaction de modele supprimé avec succès", "Transaction Modele");
                    }
                }
            }
        }

        private void BtnValiderInvest(object sender, EventArgs e)
        {
            foreach (DataGridViewRow transaction in this.gridActifs.Rows)
            {
                DateTime date = this.dateInvest.Value;
                var actif = transaction.Cells[0].Value.ToString();
                var quantiteVar = transaction.Cells[1].Value;
                var prixVar = transaction.Cells[2].Value;

                long quantiteLong = 0;
                long prixLong = 0;

                if (quantiteVar != DBNull.Value) quantiteLong = Convert.ToInt64(quantiteVar);
                if (prixVar != DBNull.Value) prixLong = Convert.ToInt64(prixVar);

                if (quantiteLong != 0 && prixLong != 0)
                {
                    Transaction nvltransaction = new Transaction(date, actif, quantiteLong, prixLong);
                    if (transactionController.ajouterInvestissement(nvltransaction))
                    {
                        MessageBox.Show("Investissement effectué avec succès", "Investissement");
                    }
                }
            }
        }
    }
}
