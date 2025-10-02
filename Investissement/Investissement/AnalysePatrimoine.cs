using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Investissement
{
    public partial class AnalysePatrimoine : MetroForm
    {
        public Form1 form;
        private MetroFramework.Components.MetroStyleManager styleManager;

        public AnalysePatrimoine(Form1 form)
        {
            
            this.form = form;
            InitializeComponent();
            this.StyleManager = styleManager;
        }

        private void AnalysePatrimoine_Load(object sender, EventArgs e)
        {
            /*ENTETE*/
            this.Text = "Analyse du Patromoine";
            styleManager = new MetroFramework.Components.MetroStyleManager();
            styleManager.Owner = this;

            this.StyleManager = styleManager;
            styleManager.Style = MetroColorStyle.Yellow; 
            styleManager.Theme = MetroThemeStyle.Light;

            /*LAYOUT*/
            //TableLayoutPanel layoutPrincipal = new TableLayoutPanel()
            //{
            //    Dock = DockStyle.Fill,
            //    RowCount = 2,
            //    ColumnCount = 2,
            //    AutoSize = true
            //};

            //FlowLayoutPanel layoutTitre = new FlowLayoutPanel();
            //layoutTitre.FlowDirection = FlowDirection.LeftToRight;
            //layoutTitre.AutoSize = true;
            //layoutTitre.Padding = new Padding(10);


            /*NAVIGATION*/
            var tabControl = new MetroFramework.Controls.MetroTabControl
            {
                Location = new Point(0, 60),
                Size = new Size(600, 400),
                Style = MetroFramework.MetroColorStyle.Yellow,
                Theme = MetroFramework.MetroThemeStyle.Dark
            };

            var pageAccueil = new MetroFramework.Controls.MetroTabPage
            {
                Text = "Accueil",
                BackColor = Color.White
            };
            tabControl.TabPages.Add(pageAccueil);

            var pageDonnees = new MetroFramework.Controls.MetroTabPage
            {
                Text = "Donnees",
                BackColor = Color.White
            };
            tabControl.TabPages.Add(pageDonnees);

            var pageGraphique = new MetroFramework.Controls.MetroTabPage
            {
                Text = "Graphiques",
                BackColor = Color.White
            };
            tabControl.TabPages.Add(pageGraphique);


            /*AFFICHAGE DANS L'APPLICATION*/
            this.Controls.Add(tabControl);
        }
    }
}
