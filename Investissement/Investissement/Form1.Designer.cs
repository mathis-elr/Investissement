namespace Investissement
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTitre = new MetroFramework.Controls.MetroPanel();
            this.btnQuitter = new MetroFramework.Controls.MetroButton();
            this.labelTitre = new System.Windows.Forms.Label();
            this.navigation = new MetroFramework.Controls.MetroTabControl();
            this.pagePatrimoine = new MetroFramework.Controls.MetroTabPage();
            this.pageBourse = new MetroFramework.Controls.MetroTabPage();
            this.pageInvestir = new MetroFramework.Controls.MetroTabPage();
            this.panelTitre.SuspendLayout();
            this.navigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitre
            // 
            this.panelTitre.BackColor = System.Drawing.Color.Black;
            this.panelTitre.Controls.Add(this.btnQuitter);
            this.panelTitre.Controls.Add(this.labelTitre);
            this.panelTitre.HorizontalScrollbarBarColor = true;
            this.panelTitre.HorizontalScrollbarHighlightOnWheel = false;
            this.panelTitre.HorizontalScrollbarSize = 10;
            this.panelTitre.Location = new System.Drawing.Point(-1, 4);
            this.panelTitre.Name = "panelTitre";
            this.panelTitre.Size = new System.Drawing.Size(1155, 88);
            this.panelTitre.TabIndex = 0;
            this.panelTitre.UseCustomBackColor = true;
            this.panelTitre.UseCustomForeColor = true;
            this.panelTitre.VerticalScrollbarBarColor = true;
            this.panelTitre.VerticalScrollbarHighlightOnWheel = false;
            this.panelTitre.VerticalScrollbarSize = 10;
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Red;
            this.btnQuitter.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnQuitter.Location = new System.Drawing.Point(1079, 9);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(56, 56);
            this.btnQuitter.TabIndex = 8;
            this.btnQuitter.Text = "x";
            this.btnQuitter.UseCustomBackColor = true;
            this.btnQuitter.UseCustomForeColor = true;
            this.btnQuitter.UseSelectable = true;
            this.btnQuitter.UseStyleColors = true;
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Font = new System.Drawing.Font("Modern No. 20", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitre.ForeColor = System.Drawing.Color.White;
            this.labelTitre.Location = new System.Drawing.Point(15, 22);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(224, 34);
            this.labelTitre.TabIndex = 1;
            this.labelTitre.Text = "Investissement";
            // 
            // navigation
            // 
            this.navigation.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.navigation.Controls.Add(this.pageInvestir);
            this.navigation.Controls.Add(this.pagePatrimoine);
            this.navigation.Controls.Add(this.pageBourse);
            this.navigation.FontWeight = MetroFramework.MetroTabControlWeight.Bold;
            this.navigation.ItemSize = new System.Drawing.Size(54, 35);
            this.navigation.Location = new System.Drawing.Point(-6, 80);
            this.navigation.Name = "navigation";
            this.navigation.SelectedIndex = 0;
            this.navigation.Size = new System.Drawing.Size(1160, 463);
            this.navigation.TabIndex = 2;
            this.navigation.UseCustomBackColor = true;
            this.navigation.UseCustomForeColor = true;
            this.navigation.UseSelectable = true;
            this.navigation.UseStyleColors = true;
            // 
            // pagePatrimoine
            // 
            this.pagePatrimoine.BackColor = System.Drawing.Color.Black;
            this.pagePatrimoine.HorizontalScrollbarBarColor = true;
            this.pagePatrimoine.HorizontalScrollbarHighlightOnWheel = false;
            this.pagePatrimoine.HorizontalScrollbarSize = 0;
            this.pagePatrimoine.Location = new System.Drawing.Point(4, 39);
            this.pagePatrimoine.Name = "pagePatrimoine";
            this.pagePatrimoine.Size = new System.Drawing.Size(1152, 420);
            this.pagePatrimoine.TabIndex = 1;
            this.pagePatrimoine.Text = "Patrimoine";
            this.pagePatrimoine.UseCustomBackColor = true;
            this.pagePatrimoine.UseCustomForeColor = true;
            this.pagePatrimoine.UseStyleColors = true;
            this.pagePatrimoine.VerticalScrollbar = true;
            this.pagePatrimoine.VerticalScrollbarBarColor = true;
            this.pagePatrimoine.VerticalScrollbarHighlightOnWheel = false;
            this.pagePatrimoine.VerticalScrollbarSize = 0;
            // 
            // pageBourse
            // 
            this.pageBourse.BackColor = System.Drawing.Color.Black;
            this.pageBourse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pageBourse.HorizontalScrollbarBarColor = true;
            this.pageBourse.HorizontalScrollbarHighlightOnWheel = false;
            this.pageBourse.HorizontalScrollbarSize = 0;
            this.pageBourse.Location = new System.Drawing.Point(4, 39);
            this.pageBourse.Name = "pageBourse";
            this.pageBourse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pageBourse.Size = new System.Drawing.Size(1152, 420);
            this.pageBourse.TabIndex = 3;
            this.pageBourse.Text = "Bourse ";
            this.pageBourse.UseCustomBackColor = true;
            this.pageBourse.UseCustomForeColor = true;
            this.pageBourse.UseStyleColors = true;
            this.pageBourse.VerticalScrollbar = true;
            this.pageBourse.VerticalScrollbarBarColor = true;
            this.pageBourse.VerticalScrollbarHighlightOnWheel = false;
            this.pageBourse.VerticalScrollbarSize = 0;
            // 
            // pageInvestir
            // 
            this.pageInvestir.BackColor = System.Drawing.Color.Black;
            this.pageInvestir.HorizontalScrollbarBarColor = false;
            this.pageInvestir.HorizontalScrollbarHighlightOnWheel = false;
            this.pageInvestir.HorizontalScrollbarSize = 0;
            this.pageInvestir.Location = new System.Drawing.Point(4, 39);
            this.pageInvestir.Name = "pageInvestir";
            this.pageInvestir.Size = new System.Drawing.Size(1152, 420);
            this.pageInvestir.TabIndex = 0;
            this.pageInvestir.Text = "Investir";
            this.pageInvestir.UseCustomBackColor = true;
            this.pageInvestir.UseCustomForeColor = true;
            this.pageInvestir.UseStyleColors = true;
            this.pageInvestir.VerticalScrollbarBarColor = false;
            this.pageInvestir.VerticalScrollbarHighlightOnWheel = false;
            this.pageInvestir.VerticalScrollbarSize = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 536);
            this.Controls.Add(this.navigation);
            this.Controls.Add(this.panelTitre);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTitre.ResumeLayout(false);
            this.panelTitre.PerformLayout();
            this.navigation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panelTitre;
        private MetroFramework.Controls.MetroTabControl navigation;
        private MetroFramework.Controls.MetroTabPage pagePatrimoine;
        private MetroFramework.Controls.MetroTabPage pageBourse;
        private MetroFramework.Controls.MetroButton btnQuitter;
        private System.Windows.Forms.Label labelTitre;
        private MetroFramework.Controls.MetroTabPage pageInvestir;
    }
}

