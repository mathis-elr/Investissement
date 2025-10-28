using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Investissement
{
    partial class PatrimoineVue
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
            this.panelPatrimoine = new System.Windows.Forms.TableLayoutPanel();
            this.naviguationDiagrammesPie = new MetroFramework.Controls.MetroTabControl();
            this.pageActifs = new MetroFramework.Controls.MetroTabPage();
            this.pageTypes = new MetroFramework.Controls.MetroTabPage();
            this.pageGraphique = new MetroFramework.Controls.MetroTabPage();
            this.labelValeurPatrimoineTotal = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.panelPatrimoine.SuspendLayout();
            this.naviguationDiagrammesPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPatrimoine
            // 
            this.panelPatrimoine.ColumnCount = 2;
            this.panelPatrimoine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.32877F));
            this.panelPatrimoine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.67123F));
            this.panelPatrimoine.Controls.Add(this.naviguationDiagrammesPie, 0, 2);
            this.panelPatrimoine.Controls.Add(this.labelValeurPatrimoineTotal, 0, 1);
            this.panelPatrimoine.Controls.Add(this.labelTotal, 0, 0);
            this.panelPatrimoine.Location = new System.Drawing.Point(21, 17);
            this.panelPatrimoine.Margin = new System.Windows.Forms.Padding(4);
            this.panelPatrimoine.Name = "panelPatrimoine";
            this.panelPatrimoine.RowCount = 3;
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 587F));
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.panelPatrimoine.Size = new System.Drawing.Size(1105, 674);
            this.panelPatrimoine.TabIndex = 2;
            // 
            // naviguationDiagrammesPie
            // 
            this.panelPatrimoine.SetColumnSpan(this.naviguationDiagrammesPie, 2);
            this.naviguationDiagrammesPie.Controls.Add(this.pageActifs);
            this.naviguationDiagrammesPie.Controls.Add(this.pageTypes);
            this.naviguationDiagrammesPie.Controls.Add(this.pageGraphique);
            this.naviguationDiagrammesPie.FontWeight = MetroFramework.MetroTabControlWeight.Bold;
            this.naviguationDiagrammesPie.Location = new System.Drawing.Point(4, 90);
            this.naviguationDiagrammesPie.Margin = new System.Windows.Forms.Padding(4);
            this.naviguationDiagrammesPie.Name = "naviguationDiagrammesPie";
            this.naviguationDiagrammesPie.SelectedIndex = 0;
            this.naviguationDiagrammesPie.Size = new System.Drawing.Size(1097, 485);
            this.naviguationDiagrammesPie.Style = MetroFramework.MetroColorStyle.Silver;
            this.naviguationDiagrammesPie.TabIndex = 2;
            this.naviguationDiagrammesPie.Theme = MetroFramework.MetroThemeStyle.Light;
            this.naviguationDiagrammesPie.UseSelectable = true;
            // 
            // pageActifs
            // 
            this.pageActifs.BackColor = System.Drawing.Color.Black;
            this.pageActifs.HorizontalScrollbarBarColor = true;
            this.pageActifs.HorizontalScrollbarHighlightOnWheel = false;
            this.pageActifs.HorizontalScrollbarSize = 0;
            this.pageActifs.Location = new System.Drawing.Point(4, 38);
            this.pageActifs.Margin = new System.Windows.Forms.Padding(4);
            this.pageActifs.Name = "pageActifs";
            this.pageActifs.Size = new System.Drawing.Size(1089, 443);
            this.pageActifs.TabIndex = 1;
            this.pageActifs.Text = "actifs";
            this.pageActifs.UseCustomBackColor = true;
            this.pageActifs.UseCustomForeColor = true;
            this.pageActifs.VerticalScrollbarBarColor = true;
            this.pageActifs.VerticalScrollbarHighlightOnWheel = false;
            this.pageActifs.VerticalScrollbarSize = 0;
            // 
            // pageTypes
            // 
            this.pageTypes.BackColor = System.Drawing.Color.Black;
            this.pageTypes.HorizontalScrollbarBarColor = true;
            this.pageTypes.HorizontalScrollbarHighlightOnWheel = false;
            this.pageTypes.HorizontalScrollbarSize = 0;
            this.pageTypes.Location = new System.Drawing.Point(4, 38);
            this.pageTypes.Margin = new System.Windows.Forms.Padding(4);
            this.pageTypes.Name = "pageTypes";
            this.pageTypes.Size = new System.Drawing.Size(1089, 443);
            this.pageTypes.TabIndex = 2;
            this.pageTypes.Text = "types";
            this.pageTypes.UseCustomBackColor = true;
            this.pageTypes.UseCustomForeColor = true;
            this.pageTypes.VerticalScrollbarBarColor = true;
            this.pageTypes.VerticalScrollbarHighlightOnWheel = false;
            this.pageTypes.VerticalScrollbarSize = 0;
            // 
            // pageGraphique
            // 
            this.pageGraphique.BackColor = System.Drawing.Color.Black;
            this.pageGraphique.HorizontalScrollbarBarColor = true;
            this.pageGraphique.HorizontalScrollbarHighlightOnWheel = false;
            this.pageGraphique.HorizontalScrollbarSize = 0;
            this.pageGraphique.Location = new System.Drawing.Point(4, 38);
            this.pageGraphique.Name = "pageGraphique";
            this.pageGraphique.Size = new System.Drawing.Size(1089, 443);
            this.pageGraphique.TabIndex = 0;
            this.pageGraphique.Text = "courbes";
            this.pageGraphique.UseCustomBackColor = true;
            this.pageGraphique.UseCustomForeColor = true;
            this.pageGraphique.VerticalScrollbarBarColor = true;
            this.pageGraphique.VerticalScrollbarHighlightOnWheel = false;
            this.pageGraphique.VerticalScrollbarSize = 0;
            // 
            // labelValeurPatrimoineTotal
            // 
            this.labelValeurPatrimoineTotal.AutoSize = true;
            this.labelValeurPatrimoineTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelValeurPatrimoineTotal.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValeurPatrimoineTotal.ForeColor = System.Drawing.Color.White;
            this.labelValeurPatrimoineTotal.Location = new System.Drawing.Point(12, 43);
            this.labelValeurPatrimoineTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelValeurPatrimoineTotal.Name = "labelValeurPatrimoineTotal";
            this.labelValeurPatrimoineTotal.Size = new System.Drawing.Size(120, 43);
            this.labelValeurPatrimoineTotal.TabIndex = 5;
            this.labelValeurPatrimoineTotal.Text = "-------,-- €";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.White;
            this.labelTotal.Location = new System.Drawing.Point(4, 0);
            this.labelTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(98, 39);
            this.labelTotal.TabIndex = 4;
            this.labelTotal.Text = "Total";
            // 
            // PatrimoineVue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panelPatrimoine);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PatrimoineVue";
            this.Size = new System.Drawing.Size(1147, 644);
            this.Load += new System.EventHandler(this.PatrimoineVue_Load);
            this.panelPatrimoine.ResumeLayout(false);
            this.panelPatrimoine.PerformLayout();
            this.naviguationDiagrammesPie.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel panelPatrimoine;
        private MetroFramework.Controls.MetroTabControl naviguationDiagrammesPie;
        private MetroFramework.Controls.MetroTabPage pageActifs;
        private MetroFramework.Controls.MetroTabPage pageTypes;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelValeurPatrimoineTotal;
        private MetroFramework.Controls.MetroTabPage pageGraphique;
    }
}