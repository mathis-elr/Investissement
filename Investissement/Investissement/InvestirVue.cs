using System.Collections.Generic;
using MetroFramework.Controls;
using System.Windows.Forms;
using System.Data;
using System;


namespace Investissement
{
    public partial class InvestirVue : UserControl
    {
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
            this.afficherActifs();
            this.comboBoxChargerModeles();

            btnInterfaceAjoutActif.Click += btnAfficherInterfaceAjoutActif;
            btnInterfaceCreationModel.Click += btnAfficherInterfaceCreationModele;
            btnInterfaceEditerModeleInvest.Click += btnAfficherInterfaceEditerModeleInvest;
            btnQuittInterface.Click += btnActionQuitterInterface;

            btnValidation.Click += btnChoixActionValidation;
            btnSupression.Click += btnChoixActionSuppression;

            btnSupprModele.Click += btnActionSupprModele;
            btnInvest.Click += btnActionValiderInvest;

            comboBoxModelesInvest.SelectedIndexChanged += (s, _) => comboBoxActionChangerModele();
        }


        /*METHODES*/
        private void afficherActifs()
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

        private void comboBoxActionChangerModele()
        {
            string modeleChoisi = ((DataRowView)comboBoxModelesInvest.SelectedItem)["nom"].ToString();
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

        private void comboBoxChargerModeles()
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
            this.gridActifs.Columns.Add("Nom", "Nom actif");
            this.gridActifs.Columns.Add("quantite", "quantite (€)");
            this.gridActifs.Columns.Add("prix", "prix (€)");
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
            this.gridActifs.Columns.Add("quantite", "quantite (€)");
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
            this.gridActifs.Columns.Add("quantite", "quantite (€)");

            string modeleChoisi = ((DataRowView)comboBoxModelesInvest.SelectedItem)["nom"].ToString();
            this.afficherTransactionsModele(modeleChoisi);
        }


        /*BOUTONS CHANGEMENTS D'INTERFACE*/
        private void btnAfficherInterfaceAjoutActif(object sender, EventArgs e)
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

        private void btnAfficherInterfaceCreationModele(object sender, EventArgs e)
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

        private void btnAfficherInterfaceEditerModeleInvest(object sender, EventArgs e)
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

            string nomModele = ((DataRowView)this.comboBoxModelesInvest.SelectedItem)["nom"].ToString();
            string description = modeleInvestController.getDescriptionModeleInvest(nomModele);
            this.inputNomModeleInvest.Text = nomModele;
            this.inputDescriptionModeleInvest.Text = description;

            this.etatBoutonSuppression = EtatBoutonSuppression.supprTransactionModele;
            this.etatBoutonValidation = EtatBoutonValidation.editerModele;
        }

        private void btnActionQuitterInterface(object sender, EventArgs e)
        {
            this.configurerGridAffichageActifs();
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
        private void btnChoixActionValidation(object sender, EventArgs e)
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

        private void btnChoixActionSuppression(object sender, EventArgs e)
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
            try
            {
                actifController.ajoutActif(nvActif);

                this.inputNomActif.Clear();
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
                    try
                    {
                        actifController.supprActif(nom);
                        this.afficherActifs();
                        MessageBox.Show("Actif supprimé avec succès", "Actif");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur");
                    }
                }
            }
        }

        private void ajouterModeleInvest()
        {
            ModeleInvest modeleInvest = new ModeleInvest(this.inputNomModeleInvest.Text, this.inputDescriptionModeleInvest.Text);
            try
            { 
                modeleInvestController.ajouterModele(modeleInvest);
                this.ajouterTransactionsModele(modeleInvest);
                afficherInterfaceApresAjoutModele();
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

            string nomModele = ((DataRowView)this.comboBoxModelesInvest.SelectedItem)["nom"].ToString();
            ModeleInvest ModeleInvestModifie = new ModeleInvest(this.inputNomModeleInvest.Text, this.inputDescriptionModeleInvest.Text);
            ModeleInvestModifie.id = Convert.ToInt64(comboBoxModelesInvest.SelectedValue);

            try
            {
                modeleInvestController.supprTransactionsModele(nomModele);
                this.ajouterTransactionsModele(ModeleInvestModifie);
                modeleInvestController.majNomDescription(nomModele, ModeleInvestModifie);

                this.inputNomModeleInvest.Clear();
                this.inputDescriptionModeleInvest.Clear();
                afficherInterfaceApresEditModele();
                MessageBox.Show("modifications effectuées avec succès", "Modele Invest");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void btnActionSupprModele(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Voulez-vous vraiment supprimer ce modele ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                string nomModele = ((DataRowView)comboBoxModelesInvest.SelectedItem)["nom"].ToString();
                try
                {
                    modeleInvestController.supprModele(nomModele);

                    this.comboBoxChargerModeles();
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
            if (!this.gridActifs.SelectedRows[0].IsNewRow && this.gridActifs.SelectedRows.Count > 0)
            {
                long idModeleAssocie = Convert.ToInt64(comboBoxModelesInvest.SelectedValue);
                string nomModeleAssocie = ((DataRowView)comboBoxModelesInvest.SelectedItem)["nom"].ToString();
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
                    try
                    {
                        modeleInvestController.supprTransactionModele(idModeleAssocie, nomActif);
                        this.afficherTransactionsModele(nomModeleAssocie);
                        MessageBox.Show("transaction de modele supprimé avec succès", "Transaction Modele");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur");
                    }
                }
            }
            else
            {
                MessageBox.Show("aucune transaction", "Erreur suppression transaction modele");
            }
        }

        private void btnActionValiderInvest(object sender, EventArgs e)
        {
            /*On est obliger de verifier avant toutes les lignes sinon ca peut ajouter certaines transactions et pas d'autre, donc on insere que si il n'y a pas d'erreur*/
            foreach (DataGridViewRow transaction in this.gridActifs.Rows)
            {
                string quantiteString = transaction.Cells[1].Value?.ToString();
                string prixString = transaction.Cells[2].Value?.ToString();

                if (string.IsNullOrEmpty(quantiteString) && string.IsNullOrEmpty(prixString)) { continue; }

                bool quantiteOk = long.TryParse(quantiteString, out long quantiteLong);
                bool prixOk = long.TryParse(prixString, out long prixLong);
                if (!quantiteOk || !prixOk)
                {
                    if (((DataRowView)comboBoxModelesInvest.SelectedItem)["nom"].ToString() != "liste actifs")
                    {
                        MessageBox.Show("vous devez remplir toutes les transactions du modele courant", "Erreur Transaction Invest");
                    }
                    else
                    {
                        MessageBox.Show("entier attendu pour le prix et la quantite des actifs choisis", "Erreur Transaction Invest");
                    }
                    return;
                }
            }

            DateTime date = this.dateInvest.Value;
            long sommeQuantite = 0;
            foreach (DataGridViewRow transaction in this.gridActifs.Rows)
            {
                string quantiteString = transaction.Cells[1].Value?.ToString();
                string prixString = transaction.Cells[2].Value?.ToString();

                if (string.IsNullOrEmpty(quantiteString) || string.IsNullOrEmpty(prixString)) { continue; }
                
                string actif = transaction.Cells[0].Value.ToString();
                long quantite = long.Parse(quantiteString);
                long prix = long.Parse(prixString);
                sommeQuantite += quantite;

                Transaction nvltransaction = new Transaction(date, actif, quantite, prix);
                try
                {
                    transactionController.ajouterTransaction(nvltransaction);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur");
                }
            }

            transactionController.ajouterInvestissementTotalParDate(date, sommeQuantite);

            this.afficherActifs();
            MessageBox.Show("Investissement effectué avec succès", "Investissement");
        }


        /*changements d'interface*/
        private void afficherInterfaceApresAjoutActif()
        {
            this.afficherActifs();
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
            this.comboBoxChargerModeles();
            this.configurerGridAffichageActifs();
            this.afficherActifs();
            this.labelTitreInterface.Text = "Choix du modele";
            this.pannelChoixModeles.Visible = true;
            this.panelConfirmationInvest.Visible = true;
            this.panelTitreQuitter.Visible = false;
            this.panelAjoutModele.Visible = false;
        }

        private void afficherInterfaceApresEditModele()
        {
            this.configurerGridAffichageActifs();
            this.comboBoxChargerModeles();
            this.labelTitreInterface.Text = "Choix du modele";
            this.pannelChoixModeles.Visible = true;
            this.panelConfirmationInvest.Visible = true;
            this.panelTitreQuitter.Visible = false;
            this.panelAjoutModele.Visible = false;
        }

    }
}
