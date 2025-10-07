using MetroFramework.Controls;
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
    public partial class ActifInterface : Form
    {
        /*ATTRIBUTS*/
        public Mode mode;
        public ActifBDD actifBDD;
        public Form1 form;

        /*pour le mode ajouter*/
        public MetroTextBox inputNom;
        public MetroTextBox inputType;
        public MetroTextBox inputISIN;
        public MetroTextBox inputRisque;

        public ActifInterface(Form1 form, ActifBDD actifBDD, Mode mode)
        {
            this.form = form;
            this.actifBDD = actifBDD;
            this.mode = mode;
            InitializeComponent();
        }

        private void ActifInterface_Load(object sender, EventArgs e)
        {
            switch (this.mode)
            {
                case Mode.ajouter:
                    ajoutActif();
                    break;
                case Mode.modifier:
                    modifActif();
                    break;
                case Mode.supprimer:
                    supprActif();
                    break;
            }
        }

        //faire trois fonctions qui construise une interface differente en fonction du mode

        private void ajoutActif()
        {
            //fenetre
            this.Text = "Ajouter un actif";
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Size = new Size(250, 220);

            //layout
            FlowLayoutPanel layoutPrincipal = new FlowLayoutPanel();
            layoutPrincipal.FlowDirection = FlowDirection.TopDown;
            layoutPrincipal.Dock = DockStyle.Fill;
            Padding padding = new Padding(10);

            //input
            this.inputNom = new MetroTextBox();
            inputNom.WaterMark = "Nom";
            inputNom.Width = 100;
            layoutPrincipal.Controls.Add(inputNom);

            this.inputType = new MetroTextBox();
            inputType.WaterMark = "Type";
            inputType.Width = 100;
            layoutPrincipal.Controls.Add(inputType);

            this.inputISIN = new MetroTextBox();
            inputISIN.WaterMark = "ISIN";
            inputISIN.Width = 100;
            layoutPrincipal.Controls.Add(inputISIN);

            this.inputRisque = new MetroTextBox();
            inputRisque.WaterMark = "Risque (securitaire ou risque)";
            inputRisque.Width = 100;
            layoutPrincipal.Controls.Add(inputRisque);

            //boutons
            MetroButton btnAjout = new MetroButton();
            btnAjout.Text = "Ajouter l'actif";
            btnAjout.AutoSize = true;
            btnAjout.UseCustomBackColor = true;
            btnAjout.BackColor = System.Drawing.Color.LightGreen;
            btnAjout.Click += btnAjoutActif;
            layoutPrincipal.Controls.Add(btnAjout);

            //afficher les layouts
            this.Controls.Add(layoutPrincipal);
        }

        private void modifActif()
        {
            //a faire
        }

        private void supprActif()
        {
            //a faire
        }

        private void btnAjoutActif(object sender, EventArgs e)
        {
            Actif nvActif = new Actif(this.inputNom.Text, this.inputType.Text, this.inputISIN.Text, this.inputRisque.Text);
            if (actifBDD.ajouterActif(nvActif))
            {
                this.form.MajGridActifs(); //mise a jour du tableau des actifs pour pouvoir investir dans l'actif ajouté, methode dans form1 car le tableau appartient à l'interface de form1
                this.Close();
            }
        }
    }
}
