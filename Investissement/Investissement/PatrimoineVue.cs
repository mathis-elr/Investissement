using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using MetroFramework.Controls;
using System.Windows.Forms;
using System.Drawing;
using System;


namespace Investissement
{
    public partial class PatrimoineVue : UserControl
    {
        private TransactionController transactionController;

        public Series serieValeurInvestit;
        public PatrimoineVue(TransactionController transactionController)
        {
            this.transactionController = transactionController;

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

            Series serieActifs = new Series();
            serieActifs.ChartType = SeriesChartType.Pie;
            serieActifs.Points.AddXY("Action A", 10);
            serieActifs.Points.AddXY("Action B", 20);
            serieActifs.Points.AddXY("Action C", 10);
            serieActifs.Points.AddXY("Action D", 30);
            serieActifs.Points.AddXY("Action E", 10);
            serieActifs.Points.AddXY("Action F", 5);
            serieActifs.Points.AddXY("Action G", 5);
            serieActifs.Points.AddXY("Action H", 10);

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

            this.afficherValeurTotaleInvestit();
        }


        /*METHODES*/
        public void majDonnees(object sender, EventArgs e)
        {
            this.afficherValeurTotaleInvestit();
        }

        private void afficherValeurTotaleInvestit()
        {
            //this.labelValeurPatrimoineTotal.Text = $"{transactionController.calculerValeurTotaleInvestit()} €";
            serieValeurInvestit.Points.Clear();
            foreach ((DateTime date,long quantite) in transactionController.getsommeQuantiteParDateInvest())
            {
                serieValeurInvestit.Points.AddXY(date.Day + "/" + date.Month, quantite);
            }
        }

    }
}
