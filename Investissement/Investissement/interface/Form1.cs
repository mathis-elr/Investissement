using MetroFramework.Components;
using MetroFramework.Forms;
using System.Windows.Forms;
using System;


namespace Investissement
{
    public partial class Form1 : MetroForm
    {
        /*ATTRIBUTS*/
        private readonly MetroStyleManager styleManager;
        private readonly BDD maBDD;

        private readonly ActifController actifController;
        private readonly ModeleInvestController modeleInvestController;
        private readonly TransactionController transactionController;
        private readonly InvestissementTotalController investissementTotalController;
        private readonly ValeurPatrimoineController valeurPatrimoineController;

        public InvestirVue investirVue;
        public PatrimoineVue patrimoineVue;
        public BourseVue bourseVue;


        /*CONSTRUCTEUR*/
        public Form1()
        {
            InitializeComponent();

            styleManager = new MetroStyleManager();
            styleManager.Owner = this;
            string cheminAbsolueFichierBDD = "Data Source=C:\\Users\\mathi\\Documents\\prog perso\\c#\\Investissement\\bd\\historique_transactions_tests.db";
            //string cheminAbsolueFichierBDD = "Data Source=C:\\Users\\mathi\\Documents\\prog perso\\c#\\Investissement\\bd\\historique_transactions_tests.db";

            /*GESTION DE LA CONNECTION A LA BASE DE DONNEE*/
            this.maBDD = new BDD(cheminAbsolueFichierBDD);
            maBDD.ouvrirBDD();

            /*LA VUE CONNAIT LES CONTROLLERS*/
            actifController = new ActifController(this.maBDD);
            modeleInvestController = new ModeleInvestController(this.maBDD);
            valeurPatrimoineController = new ValeurPatrimoineController(this.maBDD);
            transactionController = new TransactionController(this.maBDD, valeurPatrimoineController);
            investissementTotalController = new InvestissementTotalController(this.maBDD);


            /*GESTION DES DIFFERENTES PAGES*/
            investirVue = new InvestirVue(actifController, modeleInvestController, transactionController, investissementTotalController);
            patrimoineVue = new PatrimoineVue(valeurPatrimoineController, transactionController, investissementTotalController);
            bourseVue = new BourseVue();

            /*CHAQUE PAGE DE NAVIGUATION A SON PROPRE FICHIER*/
            this.pageInvestir.Controls.Add(investirVue);
            investirVue.Dock = DockStyle.Fill;
            this.pagePatrimoine.Controls.Add(patrimoineVue);
            patrimoineVue.Dock = DockStyle.Fill;
            this.pageBourse.Controls.Add(bourseVue);
            bourseVue.Dock = DockStyle.Fill;

            this.FormClosing += fermerBDD;
        }

        /*INITIALISATION*/
        private void Form1_Load(object sender, EventArgs e)
        {
            navigation.Style = MetroFramework.MetroColorStyle.Yellow;
            navigation.Theme = MetroFramework.MetroThemeStyle.Dark;

            btnQuitter.Click += quitterInterface;
            navigation.SelectedIndexChanged += patrimoineVue.majGraphiquesInterface;
        }

        /*METHODES*/
        private void quitterInterface(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fermerBDD(object sender, FormClosingEventArgs e)
        {
            maBDD.fermerBDD();
        }
    }
}
