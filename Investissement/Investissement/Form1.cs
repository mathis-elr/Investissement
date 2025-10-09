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
        public TransactionModelesController transactionModelesController;
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
            transactionModelesController = new TransactionModelesController(this, this.maBDD);
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
            this.gridActifs.Columns.Add("Nom", "Nom actif");
            this.gridActifs.Columns.Add("Type", "Type");
            this.gridActifs.Columns.Add("quantite", "quantite (€)");
            this.gridActifs.Columns.Add("prix", "prix (€)");
            this.gridActifs.Columns[0].ReadOnly = true;
            this.gridActifs.Columns[1].ReadOnly = true;
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
            btnAjoutModele.Click += BtnAjoutModele;
            btnInvest.Click += BtnValiderInvest;
            btnQuitter.Click += BtnQuitter;

            //comboBox
            boxModeles.SelectedIndexChanged += changerModele;
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
        public void changerModele(object sender, EventArgs e)
        {
            string nomModele = ((DataRowView)boxModeles.SelectedItem)["nom"].ToString();
            modeleInvestController.choixModele(nomModele);
        }


        /* EVENEMENTS BOUTONS */
        private void BtnAjoutActifs(object sender, EventArgs e)
        {
            ActifInterface ajoutActif = new ActifInterface(this.actifController, ModeEdition.ajouter);
            ajoutActif.Show();
        }

        private void BtnAjoutModele(object sender, EventArgs e)
        {
            ModeleInvestInterface ajoutModeleInvest = new ModeleInvestInterface(this.modeleInvestController, ModeEdition.ajouter);
            ajoutModeleInvest.Show();
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
