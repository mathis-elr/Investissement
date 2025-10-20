using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Investissement
{
    public partial class Form1 : MetroForm
    {
        /*ATTRIBUTS*/
        private MetroStyleManager styleManager;
        public BDD maBDD;

        public ActifController actifController;
        public ModeleInvestController modeleInvestController;
        public TransactionController transactionController;

        public InvestirVue investirVue;
        public PatrimoineVue patrimoineVue;
        public BourseVue bourseVue;


        /*CONSTRUCTEUR*/
        public Form1()
        {
            InitializeComponent();

            styleManager = new MetroStyleManager();
            styleManager.Owner = this;


            /*GESTION DE LA CONNECTION A LA BASE DE DONNEE*/
            this.maBDD = new BDD("Data Source=C:\\Users\\mathi\\Documents\\prog perso\\c#\\Investissement\\bd\\historique_transactions.db");
            maBDD.ouvrirBDD();

            /*LIAISON AVEC LES PRESENTATIONS*/
            actifController = new ActifController(this.maBDD);
            modeleInvestController = new ModeleInvestController(this.maBDD);
            transactionController = new TransactionController(this.maBDD);

            this.FormClosing += MyForm_FormClosing;

            /*GESTION DES DIFFERENTES PAGES*/
            investirVue = new InvestirVue(actifController, modeleInvestController, transactionController);
            patrimoineVue = new PatrimoineVue(actifController,transactionController);
            bourseVue = new BourseVue();

            /*LIAISON DES CHAQUE VUE A SA PAGE*/
            this.pageInvestir.Controls.Add(investirVue);
            this.pagePatrimoine.Controls.Add(patrimoineVue);
            this.pageBourse.Controls.Add(bourseVue);

            investirVue.Dock = DockStyle.Fill;
            patrimoineVue.Dock = DockStyle.Fill;
            bourseVue.Dock = DockStyle.Fill;
        }

        /*INITIALISATION*/
        private void Form1_Load(object sender, EventArgs e)
        {
            this.pageInvestir.VerticalScrollbarBarColor = false;
            this.pageInvestir.VerticalScrollbarSize = 0;

            navigation.Style = MetroFramework.MetroColorStyle.Yellow;
            navigation.Theme = MetroFramework.MetroThemeStyle.Dark;

            btnQuitter.Click += BtnQuitter;

            navigation.SelectedIndexChanged += patrimoineVue.majDonnees;
        }


        /* EVENEMENTS FERMUTURE DE LA FENETRE */
        private void BtnQuitter(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            maBDD.fermerBDD();
        }
    }
}
