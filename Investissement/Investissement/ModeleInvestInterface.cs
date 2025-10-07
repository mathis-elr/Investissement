using MetroFramework.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Investissement
{
    public partial class ModeleInvestInterface : Form
    {
        /*ATTRIBUTS*/
        public Mode mode;
        public ModeleInvestBDD modeleInvestBDD;
        public Form1 form;

        /*pour le mode ajouter*/
        public MetroTextBox inputDescription;
        public MetroTextBox inputNom;

        public ModeleInvestInterface(Form1 form, ModeleInvestBDD modeleInvestBDD, Mode mode)
        {
            this.form = form;
            this.modeleInvestBDD = modeleInvestBDD;
            this.mode = mode;
            InitializeComponent();
        }

        private void ModeleInvestInterface_Load(object sender, EventArgs e)
        {
            switch (this.mode)
            {
                case Mode.ajouter:
                    ajoutModeleInvest();
                    break;
                case Mode.modifier:
                    modifModeleInvest();
                    break;
                case Mode.supprimer:
                    supprModeleInvest();
                    break;
            }
        }

        private void ajoutModeleInvest()
        {
            this.inputDescription = new MetroTextBox();
            this.inputNom = new MetroTextBox();
            MetroLabel labelImportant = new MetroLabel();
            MetroButton btnAjouterModele = new MetroButton();
            Label label1 = new Label();
            SuspendLayout();

            // inputDescription
            this.inputDescription.CustomButton.Image = null;
            this.inputDescription.CustomButton.Location = new Point(156, 2);
            this.inputDescription.CustomButton.Name = "";
            this.inputDescription.CustomButton.Size = new Size(129, 129);
            this.inputDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputDescription.CustomButton.TabIndex = 1;
            this.inputDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputDescription.CustomButton.UseSelectable = true;
            this.inputDescription.CustomButton.Visible = false;
            this.inputDescription.Lines = new string[] { "description" };
            this.inputDescription.Location = new Point(12, 95);
            this.inputDescription.MaxLength = 32767;
            this.inputDescription.Multiline = true;
            this.inputDescription.Name = "inputDescription";
            this.inputDescription.PasswordChar = '\0';
            this.inputDescription.ScrollBars = ScrollBars.None;
            this.inputDescription.SelectedText = "";
            this.inputDescription.SelectionLength = 0;
            this.inputDescription.SelectionStart = 0;
            this.inputDescription.ShortcutsEnabled = true;
            this.inputDescription.Size = new Size(320, 134);
            this.inputDescription.TabIndex = 0;
            this.inputDescription.Text = "description";
            this.inputDescription.UseSelectable = true;

            // inputNom
            this.inputNom.CustomButton.Image = null;
            this.inputNom.CustomButton.Location = new Point(169, 1);
            this.inputNom.CustomButton.Name = "";
            this.inputNom.CustomButton.Size = new Size(21, 21);
            this.inputNom.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputNom.CustomButton.TabIndex = 1;
            this.inputNom.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputNom.CustomButton.UseSelectable = true;
            this.inputNom.CustomButton.Visible = false;
            this.inputNom.Lines = new string[] { "nom du modèle" };
            this.inputNom.Location = new Point(12, 66);
            this.inputNom.MaxLength = 32767;
            this.inputNom.Name = "inputNom";
            this.inputNom.PasswordChar = '\0';
            this.inputNom.ScrollBars = ScrollBars.None;
            this.inputNom.SelectedText = "";
            this.inputNom.SelectionLength = 0;
            this.inputNom.SelectionStart = 0;
            this.inputNom.ShortcutsEnabled = true;
            this.inputNom.Size = new Size(234, 23);
            this.inputNom.TabIndex = 1;
            this.inputNom.Text = "nom du modèle";
            this.inputNom.UseSelectable = true;

            // labelImportant
            labelImportant.AutoSize = true;
            labelImportant.BackColor = Color.Black;
            labelImportant.ForeColor = Color.Red;
            labelImportant.Location = new Point(12, 234);
            labelImportant.Name = "labelImportant";
            labelImportant.Size = new Size(76, 20);
            labelImportant.TabIndex = 3;
            labelImportant.Text = "important : les actifs de ce modèle \nseront le contenu actuel du tableau \nde la page 'Investir";
            labelImportant.UseCustomBackColor = true;
            labelImportant.UseCustomForeColor = true;
            labelImportant.WrapToLine = true;

            // btnAjouterModele
            btnAjouterModele.BackColor = Color.Lime;
            btnAjouterModele.Location = new Point(244, 328);
            btnAjouterModele.Name = "btnAjouterModele";
            btnAjouterModele.Size = new Size(109, 29);
            btnAjouterModele.TabIndex = 4;
            btnAjouterModele.Text = "ajouter";
            btnAjouterModele.UseCustomBackColor = true;
            btnAjouterModele.UseSelectable = true;
            btnAjouterModele.Click += btnAjouterModeleInvest;

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Mongolian Baiti", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(222, 30);
            label1.TabIndex = 5;
            label1.Text = "Ajouter un modèle";

            // Form
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(365, 369);
            Controls.Add(label1);
            Controls.Add(btnAjouterModele);
            Controls.Add(labelImportant);
            Controls.Add(this.inputNom);
            Controls.Add(this.inputDescription);
            Load += ModeleInvestInterface_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void modifModeleInvest()
        {
            //a faire
        }

        private void supprModeleInvest()
        {
            //a faire
        }

        private void btnAjouterModeleInvest(object sender, EventArgs e)
        {
            //cree un modeleInvest
            ModeleInvest nvModeleInvest = new ModeleInvest(this.inputNom.Text, this.inputDescription.Text);
            //ajouter le modele a la BDD grace a ModeleInvestBDD
            //si la fontion renvoi true alors on met a jour le combo box des modeles et on ferme l'application courante
            if (modeleInvestBDD.ajouterModele(nvModeleInvest))
            {
                this.form.majModeles(); //mise a jour du combo box pour pouvoir utiliser le modele crée, methode dans form1 car le combobox appartient à l'interface de form1
                this.Close();
            }
        }
    }
}
