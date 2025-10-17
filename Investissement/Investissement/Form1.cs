using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
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
            var vueInvestir = new InvestirVue(actifController, modeleInvestController, transactionController);
            var vuePatrimoine = new PatrimoineVue(transactionController);
            var vueBourse = new BourseVue();

            /*LIAISON DES CHAQUE VUE A SA PAGE*/
            this.pageInvestir.Controls.Add(vueInvestir);
            this.pagePatrimoine.Controls.Add(vuePatrimoine);
            this.pageBourse.Controls.Add(vueBourse);

            vueInvestir.Dock = DockStyle.Fill;
            vuePatrimoine.Dock = DockStyle.Fill;
            vueBourse.Dock = DockStyle.Fill;
        }

        /*INITIALISATION*/
        private void Form1_Load(object sender, EventArgs e)
        {
            this.pageInvestir.VerticalScrollbarBarColor = false;
            this.pageInvestir.VerticalScrollbarSize = 0;

            navigation.Style = MetroFramework.MetroColorStyle.Yellow;
            navigation.Theme = MetroFramework.MetroThemeStyle.Dark;

            btnQuitter.Click += BtnQuitter;
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
