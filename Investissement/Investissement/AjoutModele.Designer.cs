namespace Investissement
{
    partial class AjoutModele
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputDescription = new MetroFramework.Controls.MetroTextBox();
            this.inputNom = new MetroFramework.Controls.MetroTextBox();
            this.labelImportant = new MetroFramework.Controls.MetroLabel();
            this.btnAjouterModele = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputDescription
            // 
            // 
            // 
            // 
            this.inputDescription.CustomButton.Image = null;
            this.inputDescription.CustomButton.Location = new System.Drawing.Point(156, 2);
            this.inputDescription.CustomButton.Name = "";
            this.inputDescription.CustomButton.Size = new System.Drawing.Size(129, 129);
            this.inputDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputDescription.CustomButton.TabIndex = 1;
            this.inputDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputDescription.CustomButton.UseSelectable = true;
            this.inputDescription.CustomButton.Visible = false;
            this.inputDescription.Lines = new string[] {
        "description"};
            this.inputDescription.Location = new System.Drawing.Point(12, 95);
            this.inputDescription.MaxLength = 32767;
            this.inputDescription.Multiline = true;
            this.inputDescription.Name = "inputDescription";
            this.inputDescription.PasswordChar = '\0';
            this.inputDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputDescription.SelectedText = "";
            this.inputDescription.SelectionLength = 0;
            this.inputDescription.SelectionStart = 0;
            this.inputDescription.ShortcutsEnabled = true;
            this.inputDescription.Size = new System.Drawing.Size(320, 134);
            this.inputDescription.TabIndex = 0;
            this.inputDescription.Text = "description";
            this.inputDescription.UseSelectable = true;
            this.inputDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // inputNom
            // 
            // 
            // 
            // 
            this.inputNom.CustomButton.Image = null;
            this.inputNom.CustomButton.Location = new System.Drawing.Point(169, 1);
            this.inputNom.CustomButton.Name = "";
            this.inputNom.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.inputNom.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputNom.CustomButton.TabIndex = 1;
            this.inputNom.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputNom.CustomButton.UseSelectable = true;
            this.inputNom.CustomButton.Visible = false;
            this.inputNom.Lines = new string[] {
        "nom du modèle"};
            this.inputNom.Location = new System.Drawing.Point(12, 66);
            this.inputNom.MaxLength = 32767;
            this.inputNom.Name = "inputNom";
            this.inputNom.PasswordChar = '\0';
            this.inputNom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputNom.SelectedText = "";
            this.inputNom.SelectionLength = 0;
            this.inputNom.SelectionStart = 0;
            this.inputNom.ShortcutsEnabled = true;
            this.inputNom.Size = new System.Drawing.Size(234, 23);
            this.inputNom.TabIndex = 1;
            this.inputNom.Text = "nom du modèle";
            this.inputNom.UseSelectable = true;
            this.inputNom.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputNom.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // labelImportant
            // 
            this.labelImportant.AutoSize = true;
            this.labelImportant.BackColor = System.Drawing.Color.Black;
            this.labelImportant.ForeColor = System.Drawing.Color.Red;
            this.labelImportant.Location = new System.Drawing.Point(12, 234);
            this.labelImportant.Name = "labelImportant";
            this.labelImportant.Size = new System.Drawing.Size(76, 20);
            this.labelImportant.TabIndex = 3;
            this.labelImportant.Text = "important :";
            this.labelImportant.UseCustomBackColor = true;
            this.labelImportant.UseCustomForeColor = true;
            this.labelImportant.WrapToLine = true;
            // 
            // btnAjouterModele
            // 
            this.btnAjouterModele.BackColor = System.Drawing.Color.Lime;
            this.btnAjouterModele.Location = new System.Drawing.Point(244, 328);
            this.btnAjouterModele.Name = "btnAjouterModele";
            this.btnAjouterModele.Size = new System.Drawing.Size(109, 29);
            this.btnAjouterModele.TabIndex = 4;
            this.btnAjouterModele.Text = "ajouter";
            this.btnAjouterModele.UseCustomBackColor = true;
            this.btnAjouterModele.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ajouter un modèle";
            // 
            // AjoutModele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(365, 369);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAjouterModele);
            this.Controls.Add(this.labelImportant);
            this.Controls.Add(this.inputNom);
            this.Controls.Add(this.inputDescription);
            this.Name = "AjoutModele";
            this.Text = "AjoutModele";
            this.Load += new System.EventHandler(this.AjoutModele_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox inputDescription;
        private MetroFramework.Controls.MetroTextBox inputNom;
        private MetroFramework.Controls.MetroLabel labelImportant;
        private MetroFramework.Controls.MetroButton btnAjouterModele;
        private System.Windows.Forms.Label label1;
    }
}