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
            this.pageInvestir = new MetroFramework.Controls.MetroTabPage();
            this.panelLigne1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnInvest = new MetroFramework.Controls.MetroButton();
            this.dateInvest = new MetroFramework.Controls.MetroDateTime();
            this.layoutActifs = new System.Windows.Forms.TableLayoutPanel();
            this.btnSupprActifOuTransactionInvest = new MetroFramework.Controls.MetroButton();
            this.gridActifs = new System.Windows.Forms.DataGridView();
            this.btnAjoutActifs = new MetroFramework.Controls.MetroButton();
            this.layoutModeles = new System.Windows.Forms.TableLayoutPanel();
            this.btnSupprModele = new MetroFramework.Controls.MetroButton();
            this.labelDescrModele = new MetroFramework.Controls.MetroLabel();
            this.labelTitreDescrModele = new MetroFramework.Controls.MetroLabel();
            this.btnAjoutModele = new MetroFramework.Controls.MetroButton();
            this.labelModelesInvest = new MetroFramework.Controls.MetroLabel();
            this.boxModeles = new MetroFramework.Controls.MetroComboBox();
            this.pagePatrimoine = new MetroFramework.Controls.MetroTabPage();
            this.pageGraphiques = new MetroFramework.Controls.MetroTabPage();
            this.pageBourse = new MetroFramework.Controls.MetroTabPage();
            this.panelTitre.SuspendLayout();
            this.navigation.SuspendLayout();
            this.pageInvestir.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.layoutActifs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridActifs)).BeginInit();
            this.layoutModeles.SuspendLayout();
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
            this.navigation.Controls.Add(this.pageGraphiques);
            this.navigation.Controls.Add(this.pageBourse);
            this.navigation.FontWeight = MetroFramework.MetroTabControlWeight.Bold;
            this.navigation.ItemSize = new System.Drawing.Size(54, 35);
            this.navigation.Location = new System.Drawing.Point(-6, 80);
            this.navigation.Name = "navigation";
            this.navigation.SelectedIndex = 0;
            this.navigation.Size = new System.Drawing.Size(1157, 460);
            this.navigation.TabIndex = 2;
            this.navigation.UseCustomBackColor = true;
            this.navigation.UseCustomForeColor = true;
            this.navigation.UseSelectable = true;
            this.navigation.UseStyleColors = true;
            // 
            // pageInvestir
            // 
            this.pageInvestir.BackColor = System.Drawing.Color.Black;
            this.pageInvestir.Controls.Add(this.panelLigne1);
            this.pageInvestir.Controls.Add(this.tableLayoutPanel3);
            this.pageInvestir.Controls.Add(this.layoutActifs);
            this.pageInvestir.Controls.Add(this.layoutModeles);
            this.pageInvestir.HorizontalScrollbarBarColor = true;
            this.pageInvestir.HorizontalScrollbarHighlightOnWheel = false;
            this.pageInvestir.HorizontalScrollbarSize = 10;
            this.pageInvestir.Location = new System.Drawing.Point(4, 39);
            this.pageInvestir.Name = "pageInvestir";
            this.pageInvestir.Size = new System.Drawing.Size(1149, 417);
            this.pageInvestir.TabIndex = 0;
            this.pageInvestir.Text = "Investir";
            this.pageInvestir.UseCustomBackColor = true;
            this.pageInvestir.UseCustomForeColor = true;
            this.pageInvestir.UseStyleColors = true;
            this.pageInvestir.VerticalScrollbar = true;
            this.pageInvestir.VerticalScrollbarBarColor = true;
            this.pageInvestir.VerticalScrollbarHighlightOnWheel = false;
            this.pageInvestir.VerticalScrollbarSize = 10;
            // 
            // panelLigne1
            // 
            this.panelLigne1.BackColor = System.Drawing.Color.White;
            this.panelLigne1.Location = new System.Drawing.Point(649, 11);
            this.panelLigne1.Name = "panelLigne1";
            this.panelLigne1.Size = new System.Drawing.Size(1, 350);
            this.panelLigne1.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.56717F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.43283F));
            this.tableLayoutPanel3.Controls.Add(this.btnInvest, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.dateInvest, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(307, 307);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(318, 72);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // btnInvest
            // 
            this.btnInvest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnInvest.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnInvest.Location = new System.Drawing.Point(3, 43);
            this.btnInvest.Name = "btnInvest";
            this.btnInvest.Size = new System.Drawing.Size(312, 26);
            this.btnInvest.TabIndex = 6;
            this.btnInvest.Text = "Confirmer l\'investissement";
            this.btnInvest.UseCustomBackColor = true;
            this.btnInvest.UseCustomForeColor = true;
            this.btnInvest.UseSelectable = true;
            this.btnInvest.UseStyleColors = true;
            // 
            // dateInvest
            // 
            this.dateInvest.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dateInvest.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.dateInvest.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateInvest.FontWeight = MetroFramework.MetroDateTimeWeight.Bold;
            this.dateInvest.Location = new System.Drawing.Point(3, 3);
            this.dateInvest.MinimumSize = new System.Drawing.Size(0, 30);
            this.dateInvest.Name = "dateInvest";
            this.dateInvest.Size = new System.Drawing.Size(312, 30);
            this.dateInvest.TabIndex = 7;
            this.dateInvest.UseCustomBackColor = true;
            this.dateInvest.UseCustomForeColor = true;
            this.dateInvest.UseStyleColors = true;
            // 
            // layoutActifs
            // 
            this.layoutActifs.ColumnCount = 2;
            this.layoutActifs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.744108F));
            this.layoutActifs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.25589F));
            this.layoutActifs.Controls.Add(this.btnSupprActifOuTransactionInvest, 0, 1);
            this.layoutActifs.Controls.Add(this.gridActifs, 1, 0);
            this.layoutActifs.Controls.Add(this.btnAjoutActifs, 0, 0);
            this.layoutActifs.Location = new System.Drawing.Point(23, 28);
            this.layoutActifs.Name = "layoutActifs";
            this.layoutActifs.RowCount = 2;
            this.layoutActifs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.29825F));
            this.layoutActifs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.70175F));
            this.layoutActifs.Size = new System.Drawing.Size(590, 251);
            this.layoutActifs.TabIndex = 5;
            // 
            // btnSupprActifOuTransactionInvest
            // 
            this.btnSupprActifOuTransactionInvest.BackColor = System.Drawing.Color.Red;
            this.btnSupprActifOuTransactionInvest.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSupprActifOuTransactionInvest.Location = new System.Drawing.Point(3, 51);
            this.btnSupprActifOuTransactionInvest.Name = "btnSupprActifOuTransactionInvest";
            this.btnSupprActifOuTransactionInvest.Size = new System.Drawing.Size(35, 35);
            this.btnSupprActifOuTransactionInvest.TabIndex = 9;
            this.btnSupprActifOuTransactionInvest.Text = "-";
            this.btnSupprActifOuTransactionInvest.UseCustomBackColor = true;
            this.btnSupprActifOuTransactionInvest.UseCustomForeColor = true;
            this.btnSupprActifOuTransactionInvest.UseSelectable = true;
            this.btnSupprActifOuTransactionInvest.UseStyleColors = true;
            // 
            // gridActifs
            // 
            this.gridActifs.AllowUserToAddRows = false;
            this.gridActifs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridActifs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridActifs.BackgroundColor = System.Drawing.Color.White;
            this.gridActifs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridActifs.GridColor = System.Drawing.Color.Black;
            this.gridActifs.Location = new System.Drawing.Point(48, 3);
            this.gridActifs.Name = "gridActifs";
            this.gridActifs.RowHeadersWidth = 51;
            this.layoutActifs.SetRowSpan(this.gridActifs, 2);
            this.gridActifs.RowTemplate.Height = 24;
            this.gridActifs.Size = new System.Drawing.Size(539, 245);
            this.gridActifs.TabIndex = 2;
            // 
            // btnAjoutActifs
            // 
            this.btnAjoutActifs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAjoutActifs.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnAjoutActifs.Location = new System.Drawing.Point(3, 3);
            this.btnAjoutActifs.Name = "btnAjoutActifs";
            this.btnAjoutActifs.Size = new System.Drawing.Size(35, 35);
            this.btnAjoutActifs.TabIndex = 4;
            this.btnAjoutActifs.Text = "+";
            this.btnAjoutActifs.UseCustomBackColor = true;
            this.btnAjoutActifs.UseCustomForeColor = true;
            this.btnAjoutActifs.UseSelectable = true;
            this.btnAjoutActifs.UseStyleColors = true;
            // 
            // layoutModeles
            // 
            this.layoutModeles.ColumnCount = 3;
            this.layoutModeles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.88889F));
            this.layoutModeles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layoutModeles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.layoutModeles.Controls.Add(this.btnSupprModele, 2, 1);
            this.layoutModeles.Controls.Add(this.labelDescrModele, 0, 3);
            this.layoutModeles.Controls.Add(this.labelTitreDescrModele, 0, 2);
            this.layoutModeles.Controls.Add(this.btnAjoutModele, 1, 1);
            this.layoutModeles.Controls.Add(this.labelModelesInvest, 0, 0);
            this.layoutModeles.Controls.Add(this.boxModeles, 0, 1);
            this.layoutModeles.Location = new System.Drawing.Point(675, 31);
            this.layoutModeles.Name = "layoutModeles";
            this.layoutModeles.RowCount = 4;
            this.layoutModeles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.37705F));
            this.layoutModeles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.62295F));
            this.layoutModeles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.layoutModeles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.layoutModeles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.layoutModeles.Size = new System.Drawing.Size(403, 312);
            this.layoutModeles.TabIndex = 3;
            // 
            // btnSupprModele
            // 
            this.btnSupprModele.BackColor = System.Drawing.Color.Red;
            this.btnSupprModele.Enabled = false;
            this.btnSupprModele.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSupprModele.Location = new System.Drawing.Point(368, 71);
            this.btnSupprModele.Name = "btnSupprModele";
            this.btnSupprModele.Size = new System.Drawing.Size(30, 30);
            this.btnSupprModele.TabIndex = 9;
            this.btnSupprModele.Text = "-";
            this.btnSupprModele.UseCustomBackColor = true;
            this.btnSupprModele.UseCustomForeColor = true;
            this.btnSupprModele.UseSelectable = true;
            this.btnSupprModele.UseStyleColors = true;
            // 
            // labelDescrModele
            // 
            this.labelDescrModele.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescrModele.AutoSize = true;
            this.labelDescrModele.BackColor = System.Drawing.Color.Black;
            this.labelDescrModele.FontSize = MetroFramework.MetroLabelSize.Small;
            this.labelDescrModele.ForeColor = System.Drawing.Color.White;
            this.labelDescrModele.Location = new System.Drawing.Point(3, 165);
            this.labelDescrModele.Name = "labelDescrModele";
            this.labelDescrModele.Size = new System.Drawing.Size(319, 147);
            this.labelDescrModele.TabIndex = 6;
            this.labelDescrModele.Text = "aucun modèle sélectionné";
            this.labelDescrModele.UseCustomBackColor = true;
            this.labelDescrModele.UseCustomForeColor = true;
            this.labelDescrModele.UseStyleColors = true;
            // 
            // labelTitreDescrModele
            // 
            this.labelTitreDescrModele.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitreDescrModele.AutoSize = true;
            this.labelTitreDescrModele.BackColor = System.Drawing.Color.Black;
            this.labelTitreDescrModele.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.labelTitreDescrModele.ForeColor = System.Drawing.Color.White;
            this.labelTitreDescrModele.Location = new System.Drawing.Point(3, 118);
            this.labelTitreDescrModele.Name = "labelTitreDescrModele";
            this.labelTitreDescrModele.Size = new System.Drawing.Size(319, 47);
            this.labelTitreDescrModele.TabIndex = 5;
            this.labelTitreDescrModele.Text = "description modele";
            this.labelTitreDescrModele.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitreDescrModele.UseCustomBackColor = true;
            this.labelTitreDescrModele.UseCustomForeColor = true;
            this.labelTitreDescrModele.UseStyleColors = true;
            // 
            // btnAjoutModele
            // 
            this.btnAjoutModele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAjoutModele.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnAjoutModele.Location = new System.Drawing.Point(328, 71);
            this.btnAjoutModele.Name = "btnAjoutModele";
            this.btnAjoutModele.Size = new System.Drawing.Size(30, 30);
            this.btnAjoutModele.TabIndex = 5;
            this.btnAjoutModele.Text = "+";
            this.btnAjoutModele.UseCustomBackColor = true;
            this.btnAjoutModele.UseCustomForeColor = true;
            this.btnAjoutModele.UseSelectable = true;
            this.btnAjoutModele.UseStyleColors = true;
            // 
            // labelModelesInvest
            // 
            this.labelModelesInvest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelModelesInvest.AutoSize = true;
            this.labelModelesInvest.BackColor = System.Drawing.Color.Black;
            this.labelModelesInvest.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.labelModelesInvest.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelModelesInvest.ForeColor = System.Drawing.Color.White;
            this.labelModelesInvest.Location = new System.Drawing.Point(3, 0);
            this.labelModelesInvest.Name = "labelModelesInvest";
            this.labelModelesInvest.Size = new System.Drawing.Size(319, 68);
            this.labelModelesInvest.TabIndex = 4;
            this.labelModelesInvest.Text = "Modeles Investissement";
            this.labelModelesInvest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelModelesInvest.UseCustomBackColor = true;
            this.labelModelesInvest.UseCustomForeColor = true;
            this.labelModelesInvest.UseStyleColors = true;
            // 
            // boxModeles
            // 
            this.boxModeles.FormattingEnabled = true;
            this.boxModeles.ItemHeight = 24;
            this.boxModeles.Location = new System.Drawing.Point(3, 71);
            this.boxModeles.Name = "boxModeles";
            this.boxModeles.Size = new System.Drawing.Size(319, 30);
            this.boxModeles.TabIndex = 3;
            this.boxModeles.UseSelectable = true;
            // 
            // pagePatrimoine
            // 
            this.pagePatrimoine.BackColor = System.Drawing.Color.Black;
            this.pagePatrimoine.HorizontalScrollbarBarColor = true;
            this.pagePatrimoine.HorizontalScrollbarHighlightOnWheel = false;
            this.pagePatrimoine.HorizontalScrollbarSize = 10;
            this.pagePatrimoine.Location = new System.Drawing.Point(4, 39);
            this.pagePatrimoine.Name = "pagePatrimoine";
            this.pagePatrimoine.Size = new System.Drawing.Size(1149, 417);
            this.pagePatrimoine.TabIndex = 1;
            this.pagePatrimoine.Text = "Patrimoine";
            this.pagePatrimoine.UseCustomBackColor = true;
            this.pagePatrimoine.UseCustomForeColor = true;
            this.pagePatrimoine.UseStyleColors = true;
            this.pagePatrimoine.VerticalScrollbar = true;
            this.pagePatrimoine.VerticalScrollbarBarColor = true;
            this.pagePatrimoine.VerticalScrollbarHighlightOnWheel = false;
            this.pagePatrimoine.VerticalScrollbarSize = 10;
            // 
            // pageGraphiques
            // 
            this.pageGraphiques.BackColor = System.Drawing.Color.Black;
            this.pageGraphiques.HorizontalScrollbarBarColor = true;
            this.pageGraphiques.HorizontalScrollbarHighlightOnWheel = false;
            this.pageGraphiques.HorizontalScrollbarSize = 10;
            this.pageGraphiques.Location = new System.Drawing.Point(4, 39);
            this.pageGraphiques.Name = "pageGraphiques";
            this.pageGraphiques.Size = new System.Drawing.Size(1149, 417);
            this.pageGraphiques.Style = MetroFramework.MetroColorStyle.Black;
            this.pageGraphiques.TabIndex = 2;
            this.pageGraphiques.Text = "Graphiques";
            this.pageGraphiques.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.pageGraphiques.UseCustomBackColor = true;
            this.pageGraphiques.UseCustomForeColor = true;
            this.pageGraphiques.UseStyleColors = true;
            this.pageGraphiques.VerticalScrollbar = true;
            this.pageGraphiques.VerticalScrollbarBarColor = true;
            this.pageGraphiques.VerticalScrollbarHighlightOnWheel = false;
            this.pageGraphiques.VerticalScrollbarSize = 10;
            // 
            // pageBourse
            // 
            this.pageBourse.BackColor = System.Drawing.Color.Black;
            this.pageBourse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pageBourse.HorizontalScrollbarBarColor = true;
            this.pageBourse.HorizontalScrollbarHighlightOnWheel = false;
            this.pageBourse.HorizontalScrollbarSize = 10;
            this.pageBourse.Location = new System.Drawing.Point(4, 39);
            this.pageBourse.Name = "pageBourse";
            this.pageBourse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pageBourse.Size = new System.Drawing.Size(1149, 417);
            this.pageBourse.TabIndex = 3;
            this.pageBourse.Text = "Bourse ";
            this.pageBourse.UseCustomBackColor = true;
            this.pageBourse.UseCustomForeColor = true;
            this.pageBourse.UseStyleColors = true;
            this.pageBourse.VerticalScrollbar = true;
            this.pageBourse.VerticalScrollbarBarColor = true;
            this.pageBourse.VerticalScrollbarHighlightOnWheel = false;
            this.pageBourse.VerticalScrollbarSize = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 531);
            this.Controls.Add(this.navigation);
            this.Controls.Add(this.panelTitre);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTitre.ResumeLayout(false);
            this.panelTitre.PerformLayout();
            this.navigation.ResumeLayout(false);
            this.pageInvestir.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.layoutActifs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridActifs)).EndInit();
            this.layoutModeles.ResumeLayout(false);
            this.layoutModeles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panelTitre;
        private MetroFramework.Controls.MetroTabControl navigation;
        private MetroFramework.Controls.MetroTabPage pageInvestir;
        private MetroFramework.Controls.MetroTabPage pagePatrimoine;
        private MetroFramework.Controls.MetroTabPage pageGraphiques;
        private MetroFramework.Controls.MetroTabPage pageBourse;
        private System.Windows.Forms.DataGridView gridActifs;
        private MetroFramework.Controls.MetroButton btnAjoutActifs;
        private MetroFramework.Controls.MetroComboBox boxModeles;
        private MetroFramework.Controls.MetroButton btnAjoutModele;
        private MetroFramework.Controls.MetroLabel labelModelesInvest;
        private System.Windows.Forms.TableLayoutPanel layoutModeles;
        private MetroFramework.Controls.MetroLabel labelTitreDescrModele;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MetroFramework.Controls.MetroButton btnInvest;
        private System.Windows.Forms.TableLayoutPanel layoutActifs;
        private MetroFramework.Controls.MetroLabel labelDescrModele;
        private MetroFramework.Controls.MetroDateTime dateInvest;
        private System.Windows.Forms.Label labelTitre;
        private MetroFramework.Controls.MetroButton btnQuitter;
        private System.Windows.Forms.Panel panelLigne1;
        private MetroFramework.Controls.MetroButton btnSupprModele;
        private MetroFramework.Controls.MetroButton btnSupprActifOuTransactionInvest;
    }
}

