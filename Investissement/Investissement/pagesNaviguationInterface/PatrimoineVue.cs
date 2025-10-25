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
        private Series serieLineQuantiteInvestit;
        private Series seriePieChartTypeActif;
        private Series seriePieChartActifs;

        public PatrimoineVue(ActifController actifController, TransactionController transactionController)
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

            Legend legendTypes = new Legend();
            legendTypes.BackColor = Color.Black;
            legendTypes.ForeColor = Color.White;
            legendTypes.Docking = Docking.Right;
            legendTypes.Alignment = StringAlignment.Center;
            pieChartTypes.Legends.Add(legendTypes);

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

            Legend legendActifs = new Legend();
            legendActifs.BackColor = Color.Black;
            legendActifs.ForeColor = Color.White;
            legendActifs.Docking = Docking.Right;
            legendActifs.Alignment = StringAlignment.Center;
            pieChartActifs.Legends.Add(legendActifs);

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

            Legend legendLineChartPatrimoine = new Legend();
            legendLineChartPatrimoine.BackColor = Color.Black;
            legendLineChartPatrimoine.ForeColor = Color.White;
            legendLineChartPatrimoine.Docking = Docking.Bottom;
            legendLineChartPatrimoine.Alignment = StringAlignment.Center;
            lineChartPatrimoine.Legends.Add(legendLineChartPatrimoine);

            /*1ere ligne du graphique montant total investit par rapport au temps*/
            this.serieLineQuantiteInvestit = new Series()
            {
                ChartType = SeriesChartType.Line,
                Color = Color.DeepSkyBlue,
                BorderWidth = 3,
                Name = "Total Investit"
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

            this.pageGraphique.Controls.Add(lineChartPatrimoine);
            lineChartPatrimoine.Dock = DockStyle.Fill;
        }


        /*METHODES*/
        public async void majGraphiquesInterface(object sender, EventArgs e)
        {
            await transactionController.recupererPrixActifsActuel();
            //↓ mise a jour en consequence ↓
            this.afficherLineGraphiqueValeurTotaleInvestitParDate();
            this.afficherPieChartProportionParActifs();
            this.afficherPieChartProportionParTypeActifs();
            this.afficherValeurPatrimoineActuel();
        }

        private void afficherValeurPatrimoineActuel()
        {
            double valeur = transactionController.getValeurTotalePatrimoineActuel();
            this.labelValeurPatrimoineTotal.Text = $"{valeur} €";
        }

        private void afficherLineGraphiqueValeurTotaleInvestitParDate()
        {
            this.serieLineQuantiteInvestit.Points.Clear();
            foreach ((DateTime date, double quantiteEUR) in transactionController.getPaireQuantiteTotaleInvestitEURParDate())
            {
                if (quantiteEUR == 0)
                {
                    this.serieLineQuantiteInvestit.Points.AddXY("j-1", quantiteEUR);
                    continue;
                }
                this.serieLineQuantiteInvestit.Points.AddXY(date.Day + "/" + date.Month, quantiteEUR);
            }
        }

        private void afficherLineGraphiqueValeurTotaleEnFonctionDuPrixParDate()
        {
            //this.serieLineQuantiteValeurTotaleEnFonctionDuPrix.Points.Clear();
            //foreach ((DateTime date, double quantiteEUR) in transactionController.getListeQuantiteTotaleInvestitEURParDate())
            //{
            //    if (quantiteEUR == 0)
            //    {
            //        this.serieLineQuantiteInvestit.Points.AddXY("j-1", quantiteEUR);
            //        continue;
            //    }
            //    this.serieLineQuantiteInvestit.Points.AddXY(date.Day + "/" + date.Month, quantiteEUR);
            //}
        }

        private void afficherPieChartProportionParActifs()
        {
            this.seriePieChartActifs.Points.Clear();
            double valeurTotalePatrimoineActuel = transactionController.getValeurTotalePatrimoineActuel();
            if (valeurTotalePatrimoineActuel == 0) { return; }
            foreach ((string actif, double quantiteTotaleEnEUR) in transactionController.getPaireQuantiteEnEURTotaleInvestitParActif())
            {
                double proportion = transactionController.getProportion(quantiteTotaleEnEUR, valeurTotalePatrimoineActuel);
                this.seriePieChartActifs.Points.AddXY(actif + $"\n{proportion}%", proportion);
            }
        }

        private void afficherPieChartProportionParTypeActifs()
        {
            this.seriePieChartTypeActif.Points.Clear();
            double valeurTotalePatrimoineActuel = transactionController.getValeurTotalePatrimoineActuel();
            foreach (KeyValuePair<string,double> type in transactionController.getDictionnaireQuantiteEnEURTotaleInvestitParTypeActif())
            {
                double proportion = transactionController.getProportion(type.Value, valeurTotalePatrimoineActuel);
                this.seriePieChartTypeActif.Points.AddXY(type.Key + $"\n{proportion}%", proportion);
            }
        }
    }
}
