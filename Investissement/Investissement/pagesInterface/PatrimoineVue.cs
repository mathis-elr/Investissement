using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Investissement
{
    public partial class PatrimoineVue : UserControl
    {
        private ActifController actifController;
        private TransactionController transactionController;

        public Series seriePieChartActifs;
        public Series seriePieChartTypeActif;
        public Series serieLineQuantiteInvestit;
        public PatrimoineVue(ActifController actifController, TransactionController transactionController)
        {
            this.transactionController = transactionController;
            this.actifController = actifController;

            InitializeComponent();
        }

        private void PatrimoineVue_Load(object sender, EventArgs e)
        {
            /*1er diagramme pie (Type/Patrimoine)*/
            Chart pieChartTypes = new Chart();
            pieChartTypes.BackColor = Color.Black;

            ChartArea chartAreaTypes = new ChartArea();
            chartAreaTypes.BackColor = Color.Black;
            pieChartTypes.ChartAreas.Add(chartAreaTypes);

            this.seriePieChartTypeActif = new Series();
            this.seriePieChartTypeActif.ChartType = SeriesChartType.Pie;

            pieChartTypes.Series.Add(seriePieChartTypeActif);

            this.pageTypes.Controls.Add(pieChartTypes);
            pieChartTypes.Dock = DockStyle.Fill;


            /*2eme diagramme pie (Actif/Patrimoine)*/
            Chart pieChartActifs = new Chart();
            pieChartActifs.BackColor = Color.Black;

            ChartArea chartAreaActifs = new ChartArea();
            chartAreaActifs.BackColor = Color.Black;
            pieChartActifs.ChartAreas.Add(chartAreaActifs);

            this.seriePieChartActifs = new Series();
            this.seriePieChartActifs.ChartType = SeriesChartType.Pie;
            pieChartActifs.Series.Add(seriePieChartActifs);

            this.pageActifs.Controls.Add(pieChartActifs);
            pieChartActifs.Dock = DockStyle.Fill;

            /*graphique*/
            var lineChartPatrimoine = new Chart()
            {
                BackColor = Color.Black,
            };

            var chartAreaPatrimoine = new ChartArea()
            {
                BackColor = Color.FromArgb(17, 17, 17),
            };
            chartAreaPatrimoine.AxisX.LabelStyle.ForeColor = Color.White;
            chartAreaPatrimoine.AxisY.LabelStyle.ForeColor = Color.White;
            lineChartPatrimoine.ChartAreas.Add(chartAreaPatrimoine);

            /*1ere ligne du graphique montant total investit par rapport au temps*/
            this.serieLineQuantiteInvestit = new Series()
            {
                ChartType = SeriesChartType.Line,
                Color = Color.DeepSkyBlue,
                BorderWidth = 3,
            };

            lineChartPatrimoine.Series.Add(this.serieLineQuantiteInvestit);

            //Series series2 = new Series()
            //{
            //    ChartType = SeriesChartType.Line,
            //    Color = Color.IndianRed,
            //    BorderWidth = 3,
            //};
            //series2.Points.AddXY("Jan", 0);
            //series2.Points.AddXY("Fév", 100);
            //series2.Points.AddXY("Mars", 230);
            //lineChartPatrimoine.Series.Add(series2);

            this.panelPatrimoine.Controls.Add(lineChartPatrimoine, 0, 3);
            this.panelPatrimoine.SetColumnSpan(lineChartPatrimoine, 2);
            lineChartPatrimoine.Dock = DockStyle.Fill;

            this.afficherLineGraphiqueValeurTotaleInvestitParDate();
            this.afficherPieChartActifs();
            this.afficherPieChartTypeActifs();
        }


        /*METHODES*/
        public async void majDonnees(object sender, EventArgs e)
        {
            this.afficherLineGraphiqueValeurTotaleInvestitParDate();
            this.afficherPieChartActifs();
            this.afficherPieChartTypeActifs();

            await this.afficherValeurPatrimoineActuel();
        }

        private async Task afficherValeurPatrimoineActuel()
        {
            double valeur = await transactionController.getValeurTotalePatrimoineActuel();
            this.labelValeurPatrimoineTotal.Text = $"{Math.Round(valeur,1)} €";
        }

        private void afficherLineGraphiqueValeurTotaleInvestitParDate()
        {
            this.serieLineQuantiteInvestit.Points.Clear();
            foreach ((DateTime date, double quantite) in transactionController.getListeQuantiteTotaleInvestitParDate())
            {
                this.serieLineQuantiteInvestit.Points.AddXY(date.Day + "/" + date.Month, quantite);
            }
        }

        private void afficherPieChartActifs()
        {
            this.seriePieChartActifs.Points.Clear();
            long valeurTotalePatrimoine = transactionController.getValeurTotaleInvestit();
            if (valeurTotalePatrimoine == 0) { Console.WriteLine("division 0");  return; }
            foreach ((string actif, double quantiteTotale) in transactionController.getListePaireQuantiteTotaleInvestitParActif())
            {
                double proportion = Math.Round(quantiteTotale / valeurTotalePatrimoine * 100, 2);
                this.seriePieChartActifs.Points.AddXY(actif + $"\n{proportion}%", proportion);
            }
        }

        private void afficherPieChartTypeActifs()
        {
            this.seriePieChartTypeActif.Points.Clear();
            long nbTransaction = transactionController.getNombreTransaction();
            if (nbTransaction == 0) { Console.WriteLine("division 0"); return; }
            foreach ((string typeActif, long nombre) in transactionController.getListePaireNombreTransactionParTypeActif())
            {
                double proportion = Math.Round(((double)nombre/ nbTransaction) * 100, 2);
                this.seriePieChartTypeActif.Points.AddXY(typeActif + $"\n{proportion}%", proportion);
            }
        }
    }
}
