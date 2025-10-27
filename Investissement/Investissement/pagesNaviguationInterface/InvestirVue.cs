using System.Collections.Generic;
using MetroFramework.Controls;
using System.Windows.Forms;
using System.Data;
using System;

/*
A FAIRE
- regarder dans toutes les fonctions si on peut pas cree des fonctions plus parlantes (moins de if imbriquer et division en sous fonctions))
*/

namespace Investissement
{
    public partial class InvestirVue : UserControl
    {
        /*ATTRIBUTS*/
        private readonly ActifController actifController;
        private readonly ModeleInvestController modeleInvestController;
        private readonly TransactionController transactionController;

        private enum EtatBoutonValidation
        {
            ajouterActif,
            ajouterModele,
            editerModele,
        }

        private enum EtatBoutonSuppression
        {
            supprActif,
            supprTransactionModele
        }

        private EtatBoutonValidation etatBoutonValidation;
        private EtatBoutonSuppression etatBoutonSuppression = EtatBoutonSuppression.supprActif;


        public InvestirVue(ActifController actifController, ModeleInvestController modeleInvestController, TransactionController transactionController)
        {
            this.actifController = actifController;
            this.modeleInvestController = modeleInvestController;
            this.transactionController = transactionController;

            InitializeComponent();
        }

        private void InvestirVue_Load(object sender, EventArgs e)
        {
            this.configurerGridAffichageActifs();
            this.afficherActifsDansGrid();
            this.chargerModeles();

            btnInterfaceAjoutActif.Click += afficherInterfaceAjoutActif;
            btnInterfaceCreationModel.Click += afficherInterfaceCreationModele;
            btnInterfaceEditerModeleInvest.Click += afficherInterfaceEditerModeleInvest;
            btnQuittInterface.Click += quitterInterface;
            btnValidation.Click += choixActionValidation;
            btnSupression.Click += choixActionSuppression;
            btnSupprModele.Click += supprModele;
            btnInvest.Click += validerInvest;
            comboBoxModelesInvest.SelectedIndexChanged += changerModele;
        }

        /*ENCAPSULATION*/
        private string getNomModeleSelectionne()
        {
            return ((DataRowView)this.comboBoxModelesInvest.SelectedItem)["nom"].ToString();
        }
        private long getIdModeleSelectionne()
        {
            return Convert.ToInt64(comboBoxModelesInvest.SelectedValue);
        }


        /*METHODES*/
        private void afficherActifsDansGrid()
        {
            this.gridActifs.Rows.Clear();
            foreach (string nom in actifController.getListeActifs())
            {
                this.gridActifs.Rows.Add(nom);
            }
        }
        private void changerModele(object sender, EventArgs e)
        {
            long idModeleChoisi = this.getIdModeleSelectionne();
            this.labelDescrModele.Text = modeleInvestController.getDescriptionModeleInvest(idModeleChoisi);

            if (idModeleChoisi == 0) //0 = liste des actifs
            {
                this.afficherActifsDansGrid();

                this.btnSupression.Visible = true;
                this.btnInterfaceAjoutActif.Visible = true;
                this.btnInterfaceCreationModel.Enabled = true;
                this.btnInterfaceEditerModeleInvest.Enabled = false;
                this.btnSupprModele.Enabled = false;
            }
            else
            {
                this.afficherTransactionsModele(idModeleChoisi);

                this.btnSupprModele.Enabled = true;
                this.btnInterfaceEditerModeleInvest.Enabled = true;
                this.btnInterfaceCreationModel.Enabled = false;
                this.btnInterfaceAjoutActif.Visible = false;
                this.btnSupression.Visible = false;
            }
        }
        private void afficherTransactionsModele(long idModele)
        {
            this.gridActifs.Rows.Clear();
            List<(string actif, long quantite)> transactions = modeleInvestController.getTransactionsModele(idModele);
            if (transactions.Count != 0)
            {
                foreach (var (actif, quantite) in transactions)
                {
                    gridActifs.Rows.Add(actif, quantite);
                }
            }
        }
        private void chargerModeles()
        {
            MetroComboBox modeles = this.comboBoxModelesInvest;
            DataTable modeleInvest = modeleInvestController.getModelesDataTable();
            modeles.DataSource = modeleInvest;
            modeles.ValueMember = "id";
            modeles.DisplayMember = "nom";
        }


        /*Differentes formes du gridActifs*/
        private void configurerGridAffichageActifs()
        {
            this.gridActifs.Columns.Clear();
            this.gridActifs.Columns.Add("Nom", "actif");
            this.gridActifs.Columns.Add("nombre", "nombre d'actifs");
            this.gridActifs.Columns.Add("prix", "prix EUR");
            this.gridActifs.Columns[0].ReadOnly = true;
            this.gridActifs.AllowUserToAddRows = false;
        }
        private void configurerGridCreationModele()
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
            this.gridActifs.Columns.Add("quantite","quantite");
        }
        private void configurerGridEditerModele()
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
            this.gridActifs.Columns.Add("quantite", "quantite");

            this.afficherTransactionsModele(this.getIdModeleSelectionne());
        }


        /*CHANGEMENTS D'INTERFACE*/
        private void afficherInterfaceAjoutActif(object sender, EventArgs e)
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
        private void afficherInterfaceCreationModele(object sender, EventArgs e)
        {
            this.configurerGridCreationModele();
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
        private void afficherInterfaceEditerModeleInvest(object sender, EventArgs e)
        {
            this.configurerGridEditerModele();
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

            long idModeleSelectionne = this.getIdModeleSelectionne();
            this.inputNomModeleInvest.Text = this.getNomModeleSelectionne();
            this.inputDescriptionModeleInvest.Text = modeleInvestController.getDescriptionModeleInvest(idModeleSelectionne);

            this.etatBoutonSuppression = EtatBoutonSuppression.supprTransactionModele;
            this.etatBoutonValidation = EtatBoutonValidation.editerModele;
        }
        private void quitterInterface(object sender, EventArgs e)
        {
            this.configurerGridAffichageActifs();
            this.afficherActifsDansGrid();

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


        /*ROLE EN FONCTION DE L'INTERFACE*/
        private void choixActionValidation(object sender, EventArgs e)
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
                    enregistrerEditModeleInvest();
                    return;
            }
        }
        private void choixActionSuppression(object sender, EventArgs e)
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


        /*METHODES ACTION BTN*/
        private void ajoutActif()
        {
            Actif nvActif = new Actif(this.inputNomActif.Text, this.inputSymboleActif.Text, this.inputTypeActif.Text, this.inputISINActif.Text, this.inputRisqueActif.Text);
            try
            {
                actifController.ajoutActif(nvActif);

                this.inputNomActif.Clear();
                this.inputSymboleActif.Clear();
                this.inputTypeActif.Clear();
                this.inputISINActif.Clear();
                this.inputRisqueActif.Clear();
                afficherInterfaceApresAjoutActif();
                MessageBox.Show("Actif ajouté avec succès", "Actif");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
    
        }
        private void supprActif()
        {
            if(this.aucuneSelectionDansGrid())
            {
                MessageBox.Show("aucune actif selectionné", "Erreur suppression actif");
                return;
            }

            if (this.reponsePositiveUtilisateur("Voulez-vous vraiment supprimer cet actif ?"))
            {
                this.supprActifSelectionne();
            }
        }
        private void supprActifSelectionne()
        {
            DataGridViewRow row = this.gridActifs.SelectedRows[0];
            string nom = row.Cells["Nom"].Value.ToString();

            try
            {
                actifController.supprActif(nom);
                this.afficherActifsDansGrid();
                MessageBox.Show("Actif supprimé avec succès", "Actif");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }
        private void ajouterModeleInvest()
        {
            ModeleInvest modeleInvest = new ModeleInvest(this.inputNomModeleInvest.Text, this.inputDescriptionModeleInvest.Text);
            try
            { 
                modeleInvestController.ajouterModele(modeleInvest);
                this.ajouterTransactionsModele(modeleInvest);
                this.afficherInterfaceApresAjoutModele();
                MessageBox.Show("Modele ajouté avec succès", "Modele");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
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
        private void enregistrerEditModeleInvest()
        {
            //pour la modification d'un modele on supprime toutes les transaction associées et on rajoute les nouvelles/modifiées
            //pour le nom et la description on fait une mise a jour directement

            long idModele = this.getIdModeleSelectionne();
            ModeleInvest ModeleInvestModifie = new ModeleInvest(this.inputNomModeleInvest.Text, this.inputDescriptionModeleInvest.Text);
            ModeleInvestModifie.id = this.getIdModeleSelectionne();

            try
            {
                modeleInvestController.supprToutesTransactionsModele(idModele);
                this.ajouterTransactionsModele(ModeleInvestModifie);
                modeleInvestController.majNomDescription(idModele, ModeleInvestModifie);

                this.inputNomModeleInvest.Clear();
                this.inputDescriptionModeleInvest.Clear();
                this.afficherInterfaceApresEditModele();
                MessageBox.Show("modifications effectuées avec succès", "Modele Invest");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }
        private void supprModele(object sender, EventArgs e)
        {
            if (this.reponsePositiveUtilisateur("Voulez-vous vraiment supprimer ce modele ?"))
            {
                try
                {
                    modeleInvestController.supprModele(this.getIdModeleSelectionne());
                    this.chargerModeles();
                    MessageBox.Show("modele supprimé avec succès", "Modele");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur");
                }
            }
        }
        private void supprTransactionModele()
        {
            if (this.aucuneSelectionDansGrid()) 
            {
                MessageBox.Show("aucune transaction selectionné", "Erreur suppression transaction modele");
                return;
            }

            if(this.transactionVide())
            {
                MessageBox.Show("transaction vide", "Erreur suppression transaction modele");
                return;
            }

            if (this.reponsePositiveUtilisateur("Voulez-vous vraiment supprimer cette transaction ?"))
            {
                this.supprTransactionModeleSelectionne();
            }
        }
        private void supprTransactionModeleSelectionne()
        {
            long idModeleAssocie = this.getIdModeleSelectionne();;
            DataGridViewRow row = this.gridActifs.SelectedRows[0];
            string nomActif = row.Cells["Nom"].Value.ToString();

            try
            {
                modeleInvestController.supprUneTransactionModele(idModeleAssocie, nomActif);
                this.afficherTransactionsModele(idModeleAssocie);
                MessageBox.Show("transaction de modele supprimé avec succès", "Transaction Modele");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }
        private void validerInvest(object sender, EventArgs e)
        {
            if (!validerSaisieTransactions())
                return;

            DateTime dateInvestSaisie = this.dateInvest.Value;
            double quantiteTotaleEnEUR = 0;

            foreach (DataGridViewRow transaction in this.gridActifs.Rows)
            {
                string quantiteString = transaction.Cells[1].Value?.ToString();
                string prixString = transaction.Cells[2].Value?.ToString();
                if (this.infoTransactionCouranteInexistante(quantiteString, prixString)) { continue; }

                Transaction nouvelleTransaction = creerTransaction(dateInvestSaisie, transaction);
                this.ajouterTransaction(nouvelleTransaction);
                quantiteTotaleEnEUR += nouvelleTransaction.quantite * nouvelleTransaction.prix;
            }

            transactionController.ajouterInvestissementTotalParDate(dateInvestSaisie, quantiteTotaleEnEUR);
            MessageBox.Show("Investissement effectué avec succès", "Investissement");
            this.afficherActifsDansGrid();
        }
        private bool validerSaisieTransactions()
        {
            if (this.mauvaisTypeSaisie())
            {
                MessageBox.Show("double attendu pour le prix et la quantite des actifs choisis", "Erreur Transaction Invest");
                return false;
            }
            return true;
        }
        private Transaction creerTransaction(DateTime date, DataGridViewRow row)
        {
            string nomActif = row.Cells[0].Value.ToString();
            double quantite = double.Parse(row.Cells[1].Value?.ToString());
            double prix = double.Parse(row.Cells[2].Value?.ToString());
            return new Transaction(date, nomActif, quantite, prix);
        }
        private void ajouterTransaction(Transaction transaction)
        {
            try
            {
                transactionController.ajouterTransaction(transaction);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }
        private bool reponsePositiveUtilisateur(string message)
        {
            DialogResult reponse = MessageBox.Show(
            message,
            "Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (reponse == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        private bool mauvaisTypeSaisie()
        {
            /*On est obliger de verifier avant toutes les lignes sinon ca peut ajouter certaines transactions et pas d'autre, donc on insere que si il n'y a pas d'erreur*/
            foreach (DataGridViewRow transaction in this.gridActifs.Rows)
            {
                string quantiteString = transaction.Cells[1].Value?.ToString();
                string prixString = transaction.Cells[2].Value?.ToString();

                if (string.IsNullOrEmpty(quantiteString) && string.IsNullOrEmpty(prixString)) { continue; }

                bool quantiteOk = double.TryParse(quantiteString, out double quantiteLong);
                bool prixOk = double.TryParse(prixString, out double prixLong);
                if (!quantiteOk || !prixOk)
                {
                    return false;
                }
            }
            return true;
        }
        private bool infoTransactionCouranteInexistante(string quantite, string prix)
        {
            return string.IsNullOrEmpty(quantite) || string.IsNullOrEmpty(prix);
        }
        private bool aucuneSelectionDansGrid()
        {
            return this.gridActifs.SelectedRows.Count == 0;
        }
        private bool transactionVide()
        {
            return this.gridActifs.SelectedRows[0].IsNewRow;
        }


        /*changements d'interface*/
        private void afficherInterfaceApresAjoutActif()
        {
            this.afficherActifsDansGrid();
            this.labelChoixModele.Visible = true;
            this.pannelChoixModeles.Visible = true;
            this.btnInterfaceAjoutActif.Visible = true;
            this.panelConfirmationInvest.Visible = true;
            this.btnSupression.Visible = true;
            this.panelTitreQuitter.Visible = false;
            this.panelAjoutActif.Visible = false;
        }
        private void afficherInterfaceApresAjoutModele()
        {
            this.chargerModeles();
            this.configurerGridAffichageActifs();
            this.afficherActifsDansGrid();
            this.labelTitreInterface.Text = "Choix du modele";
            this.pannelChoixModeles.Visible = true;
            this.panelConfirmationInvest.Visible = true;
            this.panelTitreQuitter.Visible = false;
            this.panelAjoutModele.Visible = false;
        }
        private void afficherInterfaceApresEditModele()
        {
            this.configurerGridAffichageActifs();
            this.chargerModeles();
            this.labelTitreInterface.Text = "Choix du modele";
            this.pannelChoixModeles.Visible = true;
            this.panelConfirmationInvest.Visible = true;
            this.panelTitreQuitter.Visible = false;
            this.panelAjoutModele.Visible = false;
        }
    }
}
