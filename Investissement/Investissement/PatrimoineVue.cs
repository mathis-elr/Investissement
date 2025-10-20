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

        public Series serieValeurInvestit;
        public Series serieActifs;
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

            Series serieTypes = new Series();
            serieTypes.ChartType = SeriesChartType.Pie;
            serieTypes.Points.AddXY("Type A", 50);
            serieTypes.Points.AddXY("Type B", 10);
            serieTypes.Points.AddXY("Type C", 40);
            pieChartTypes.Series.Add(serieTypes);

            this.pageTypes.Controls.Add(pieChartTypes);
            pieChartTypes.Dock = DockStyle.Fill;


            /*2eme diagramme pie (Actif/Patrimoine)*/
            Chart pieChartActifs = new Chart();
            pieChartActifs.BackColor = Color.Black;

            ChartArea chartAreaActifs = new ChartArea();
            chartAreaActifs.BackColor = Color.Black;
            pieChartActifs.ChartAreas.Add(chartAreaActifs);

            serieActifs = new Series();
            serieActifs.ChartType = SeriesChartType.Pie;
            pieChartActifs.Series.Add(serieActifs);

            this.pageActifs.Controls.Add(pieChartActifs);
            pieChartActifs.Dock = DockStyle.Fill;


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

            serieValeurInvestit = new Series()
            {
                ChartType = SeriesChartType.Line,
                Color = Color.DeepSkyBlue,
                BorderWidth = 3,
            };

            lineChartPatrimoine.Series.Add(serieValeurInvestit);

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

            this.afficherLineGraphiqueValeurTotaleInvestit();
            this.afficherValeurPatrimoineActuel();
            this.afficherPieChartActifs();
        }


        /*METHODES*/
        public void majDonnees(object sender, EventArgs e)
        {
            this.afficherLineGraphiqueValeurTotaleInvestit();
            this.afficherValeurPatrimoineActuel();
            this.afficherPieChartActifs();
        }

        private void afficherValeurPatrimoineActuel()
        {
            this.labelValeurPatrimoineTotal.Text = $"{transactionController.getValeurTotalePatrimoine()} €";
        }

        private void afficherLineGraphiqueValeurTotaleInvestit()
        {
            //this.labelValeurPatrimoineTotal.Text = $"{transactionController.calculerValeurTotaleInvestit()} €";
            this.serieValeurInvestit.Points.Clear();
            foreach ((DateTime date, long quantite) in transactionController.getsommeQuantiteParDateInvest())
            {
                serieValeurInvestit.Points.AddXY(date.Day + "/" + date.Month, quantite);
            }
        }

        private void afficherPieChartActifs()
        {
            this.serieActifs.Points.Clear();
            long valeurTotalePatrimoine = transactionController.getValeurTotaleInvestit();
            foreach ((string actif, long quantiteTotale) in transactionController.getListeActifQuantiteTotaleInvestit())
            {
                double proportion = Math.Round(((double)quantiteTotale / valeurTotalePatrimoine) * 100, 2);
                serieActifs.Points.AddXY(actif + $"\n{proportion}%", proportion);
            }
        }
    }
}
