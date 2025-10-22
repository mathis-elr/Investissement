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
            this.labelValeurPatrimoineTotal = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.naviguationDiagrammesPie = new MetroFramework.Controls.MetroTabControl();
            this.pageActifs = new MetroFramework.Controls.MetroTabPage();
            this.pageTypes = new MetroFramework.Controls.MetroTabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPatrimoine.SuspendLayout();
            this.naviguationDiagrammesPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPatrimoine
            // 
            this.panelPatrimoine.ColumnCount = 3;
            this.panelPatrimoine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.61995F));
            this.panelPatrimoine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.38005F));
            this.panelPatrimoine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 402F));
            this.panelPatrimoine.Controls.Add(this.label1, 2, 0);
            this.panelPatrimoine.Controls.Add(this.labelValeurPatrimoineTotal, 0, 1);
            this.panelPatrimoine.Controls.Add(this.labelTotal, 0, 0);
            this.panelPatrimoine.Controls.Add(this.naviguationDiagrammesPie, 2, 1);
            this.panelPatrimoine.Location = new System.Drawing.Point(-1, 10);
            this.panelPatrimoine.Margin = new System.Windows.Forms.Padding(4);
            this.panelPatrimoine.Name = "panelPatrimoine";
            this.panelPatrimoine.RowCount = 4;
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.40351F));
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.59649F));
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 297F));
            this.panelPatrimoine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.panelPatrimoine.Size = new System.Drawing.Size(1144, 385);
            this.panelPatrimoine.TabIndex = 2;
            // 
            // labelValeurPatrimoineTotal
            // 
            this.labelValeurPatrimoineTotal.AutoSize = true;
            this.labelValeurPatrimoineTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelValeurPatrimoineTotal.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValeurPatrimoineTotal.ForeColor = System.Drawing.Color.White;
            this.labelValeurPatrimoineTotal.Location = new System.Drawing.Point(29, 42);
            this.labelValeurPatrimoineTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelValeurPatrimoineTotal.Name = "labelValeurPatrimoineTotal";
            this.labelValeurPatrimoineTotal.Size = new System.Drawing.Size(120, 27);
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
            // naviguationDiagrammesPie
            // 
            this.naviguationDiagrammesPie.Controls.Add(this.pageActifs);
            this.naviguationDiagrammesPie.Controls.Add(this.pageTypes);
            this.naviguationDiagrammesPie.Location = new System.Drawing.Point(745, 46);
            this.naviguationDiagrammesPie.Margin = new System.Windows.Forms.Padding(4);
            this.naviguationDiagrammesPie.Name = "naviguationDiagrammesPie";
            this.panelPatrimoine.SetRowSpan(this.naviguationDiagrammesPie, 3);
            this.naviguationDiagrammesPie.SelectedIndex = 0;
            this.naviguationDiagrammesPie.Size = new System.Drawing.Size(395, 335);
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
            this.pageActifs.Size = new System.Drawing.Size(387, 293);
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
            this.pageTypes.Margin = new System.Windows.Forms.Padding(4);
            this.pageTypes.Name = "pageTypes";
            this.pageTypes.Size = new System.Drawing.Size(380, 293);
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
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(931, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 53);
            this.label1.TabIndex = 3;
            this.label1.Text = "Proportion par rapport \r\nau patrimoine total";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PatrimoineVue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panelPatrimoine);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PatrimoineVue";
            this.Size = new System.Drawing.Size(1160, 463);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelValeurPatrimoineTotal;
    }
}