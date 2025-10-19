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
            this.label1 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelValeurPatrimoineTotal = new System.Windows.Forms.Label();
            this.panelPatrimoine.SuspendLayout();
            this.naviguationDiagrammesPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPatrimoine
            // 
            this.panelPatrimoine.ColumnCount = 3;
            this.panelPatrimoine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.10018F));
            this.panelPatrimoine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.89982F));
            this.panelPatrimoine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.panelPatrimoine.Controls.Add(this.labelValeurPatrimoineTotal, 0, 1);
            this.panelPatrimoine.Controls.Add(this.labelTotal, 0, 0);
            this.panelPatrimoine.Controls.Add(this.naviguationDiagrammesPie, 2, 1);
            this.panelPatrimoine.Location = new System.Drawing.Point(-1, 8);
            this.panelPatrimoine.Name = "panelPatrimoine";
            this.panelPatrimoine.RowCount = 4;
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.40351F));
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.59649F));
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 241F));
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelPatrimoine.Size = new System.Drawing.Size(858, 313);
            this.panelPatrimoine.TabIndex = 2;
            // 
            // naviguationDiagrammesPie
            // 
            this.naviguationDiagrammesPie.Controls.Add(this.pageActifs);
            this.naviguationDiagrammesPie.Controls.Add(this.pageTypes);
            this.naviguationDiagrammesPie.Location = new System.Drawing.Point(560, 38);
            this.naviguationDiagrammesPie.Name = "naviguationDiagrammesPie";
            this.panelPatrimoine.SetRowSpan(this.naviguationDiagrammesPie, 3);
            this.naviguationDiagrammesPie.SelectedIndex = 0;
            this.naviguationDiagrammesPie.Size = new System.Drawing.Size(291, 272);
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
            this.pageActifs.Name = "pageActifs";
            this.pageActifs.Size = new System.Drawing.Size(283, 230);
            this.pageActifs.TabIndex = 0;
            this.pageActifs.Text = "Actifs";
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
            this.pageTypes.Name = "pageTypes";
            this.pageTypes.Size = new System.Drawing.Size(260, 233);
            this.pageTypes.TabIndex = 1;
            this.pageTypes.Text = "Type";
            this.pageTypes.UseCustomBackColor = true;
            this.pageTypes.UseCustomForeColor = true;
            this.pageTypes.VerticalScrollbarBarColor = true;
            this.pageTypes.VerticalScrollbarHighlightOnWheel = false;
            this.pageTypes.VerticalScrollbarSize = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(558, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Proportion par rapport au patrimoine total";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.White;
            this.labelTotal.Location = new System.Drawing.Point(3, 0);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(80, 31);
            this.labelTotal.TabIndex = 4;
            this.labelTotal.Text = "Total";
            // 
            // labelValeurPatrimoineTotal
            // 
            this.labelValeurPatrimoineTotal.AutoSize = true;
            this.labelValeurPatrimoineTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelValeurPatrimoineTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValeurPatrimoineTotal.ForeColor = System.Drawing.Color.White;
            this.labelValeurPatrimoineTotal.Location = new System.Drawing.Point(11, 35);
            this.labelValeurPatrimoineTotal.Name = "labelValeurPatrimoineTotal";
            this.labelValeurPatrimoineTotal.Size = new System.Drawing.Size(75, 22);
            this.labelValeurPatrimoineTotal.TabIndex = 5;
            this.labelValeurPatrimoineTotal.Text = "----,-- €";
            // 
            // PatrimoineVue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelPatrimoine);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PatrimoineVue";
            this.Size = new System.Drawing.Size(870, 376);
            this.Load += new System.EventHandler(this.PatrimoineVue_Load);
            this.panelPatrimoine.ResumeLayout(false);
            this.panelPatrimoine.PerformLayout();
            this.naviguationDiagrammesPie.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel panelPatrimoine;
        private MetroFramework.Controls.MetroTabControl naviguationDiagrammesPie;
        private MetroFramework.Controls.MetroTabPage pageActifs;
        private MetroFramework.Controls.MetroTabPage pageTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelValeurPatrimoineTotal;
    }
}