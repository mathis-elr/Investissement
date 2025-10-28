using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;

/*A FAIRE
*/

namespace Investissement
{
    public partial class PatrimoineVue : UserControl
    {
        private TransactionController transactionController;
        private Series serieLineQuantiteInvestit;
        private Series seriePieChartTypeActif;
        private Series seriePieChartActifs;
        private Series serieLineValeurPatrimoineMoyen;
        private double valeurPatrimoineActuelle;

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

            chartAreaPatrimoine.CursorX.IsUserEnabled = true;
            chartAreaPatrimoine.CursorX.IsUserSelectionEnabled = true;
            chartAreaPatrimoine.AxisX.ScaleView.Zoomable = true;
            chartAreaPatrimoine.CursorY.IsUserEnabled = true;
            chartAreaPatrimoine.CursorY.IsUserSelectionEnabled = true;
            chartAreaPatrimoine.AxisY.ScaleView.Zoomable = true;
            lineChartPatrimoine.ChartAreas.Add(chartAreaPatrimoine);

            /*1ere ligne du graphique montant total investit par rapport au temps*/
            this.serieLineQuantiteInvestit = new Series()
            {
                ChartType = SeriesChartType.Line,
                Color = Color.DeepSkyBlue,
                BorderWidth = 3,
                Name = "Total Investit",
                XValueType = ChartValueType.DateTime
            };
            lineChartPatrimoine.Series.Add(this.serieLineQuantiteInvestit);

            /*2e ligne du graphique valeur du patrimoine moyen par rapport au temps*/
            this.serieLineValeurPatrimoineMoyen = new Series()
            {
                ChartType = SeriesChartType.Line,
                Color = Color.IndianRed,
                BorderWidth = 3,
                Name = "Valeur patrimoine moyen",
                XValueType = ChartValueType.DateTime
            };
            lineChartPatrimoine.Series.Add(serieLineValeurPatrimoineMoyen);

            Legend legendLineChart = new Legend();
            legendLineChart.BackColor = Color.Black;
            legendLineChart.ForeColor = Color.White;
            legendLineChart.Docking = Docking.Bottom;
            legendLineChart.Alignment = StringAlignment.Center;
            lineChartPatrimoine.Legends.Add(legendLineChart);

            this.pageGraphique.Controls.Add(lineChartPatrimoine);
            lineChartPatrimoine.Dock = DockStyle.Fill;
        }


        /*METHODES*/
        public async void majGraphiquesInterface(object sender, EventArgs e)
        {
            try
            {
                await transactionController.recupererPrixActifsActuel();
                //↓ mise a jour des graphiques en consequence ↓
                this.valeurPatrimoineActuelle = transactionController.calculerEnregistrerValeurPatrimoineActuel(this.valeurPatrimoineActuelle);
                this.afficherValeurPatrimoineActuel();
                this.remplirPieChartProportionParActifs();
                this.remplirPieChartProportionParTypeActifs();
                transactionController.ajouterInvestissementTotalDuJour();
                this.remplirGraphiqueValeurTotaleInvestitParDate();
                this.remplirGraphiqueValeurMoyenneParDate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }
        private void afficherValeurPatrimoineActuel()
        {
            this.labelValeurPatrimoineTotal.Text = $"{this.valeurPatrimoineActuelle} €";
        }
        private void remplirPieChartProportionParActifs()
        {
            this.seriePieChartActifs.Points.Clear();
            foreach (KeyValuePair<string, double> quantiteParActif in transactionController.getValeurActuelleParActif())
            {
                double proportion = transactionController.calculerProportion(quantiteParActif.Value, this.valeurPatrimoineActuelle);
                this.seriePieChartActifs.Points.AddXY(quantiteParActif.Key + $"\n{proportion}%", proportion);
            }
        }
        private void remplirPieChartProportionParTypeActifs()
        {
            this.seriePieChartTypeActif.Points.Clear();
            foreach (KeyValuePair<string, double> type in transactionController.getQuantiteInvestitParTypeActif())
            {
                double proportion = transactionController.calculerProportion(type.Value, this.valeurPatrimoineActuelle);
                this.seriePieChartTypeActif.Points.AddXY(type.Key + $"\n{proportion}%", proportion);
            }
        }
        private void remplirGraphiqueValeurTotaleInvestitParDate()
        {
            this.serieLineQuantiteInvestit.Points.Clear();
            foreach (KeyValuePair<DateTime, double> quantiteInvestitParDate in transactionController.getQuantiteInvestitParDate())
            {
                this.serieLineQuantiteInvestit.Points.AddXY(quantiteInvestitParDate.Key, quantiteInvestitParDate.Value);
            }
        }
        private void remplirGraphiqueValeurMoyenneParDate()
        {
            this.serieLineValeurPatrimoineMoyen.Points.Clear();
            foreach (KeyValuePair<DateTime, double> valeurMoyenneParDate in transactionController.getMoyenneValeurPatrimoineParJour())
            {
                this.serieLineValeurPatrimoineMoyen.Points.AddXY(valeurMoyenneParDate.Key, valeurMoyenneParDate.Value);
            }
        }
    }
}
