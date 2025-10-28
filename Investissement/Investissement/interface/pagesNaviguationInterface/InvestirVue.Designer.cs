namespace Investissement
{
    partial class InvestirVue
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
            this.labelChoixModele = new MetroFramework.Controls.MetroLabel();
            this.panelAjoutActif = new System.Windows.Forms.TableLayoutPanel();
            this.inputSymboleActif = new MetroFramework.Controls.MetroTextBox();
            this.labelSymbole = new MetroFramework.Controls.MetroLabel();
            this.inputNomActif = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.inputRisqueActif = new MetroFramework.Controls.MetroTextBox();
            this.inputISINActif = new MetroFramework.Controls.MetroTextBox();
            this.inputTypeActif = new MetroFramework.Controls.MetroTextBox();
            this.panelTitreQuitter = new System.Windows.Forms.TableLayoutPanel();
            this.btnQuittInterface = new MetroFramework.Controls.MetroButton();
            this.labelTitreInterface = new MetroFramework.Controls.MetroLabel();
            this.btnValidation = new MetroFramework.Controls.MetroButton();
            this.panelAjoutModele = new System.Windows.Forms.TableLayoutPanel();
            this.inputDescriptionModeleInvest = new MetroFramework.Controls.MetroTextBox();
            this.inputNomModeleInvest = new MetroFramework.Controls.MetroTextBox();
            this.panelLigne1 = new System.Windows.Forms.Panel();
            this.panelConfirmationInvest = new System.Windows.Forms.TableLayoutPanel();
            this.btnInvest = new MetroFramework.Controls.MetroButton();
            this.dateInvest = new MetroFramework.Controls.MetroDateTime();
            this.layoutActifs = new System.Windows.Forms.TableLayoutPanel();
            this.btnSupression = new MetroFramework.Controls.MetroButton();
            this.gridActifs = new System.Windows.Forms.DataGridView();
            this.btnInterfaceAjoutActif = new MetroFramework.Controls.MetroButton();
            this.pannelChoixModeles = new System.Windows.Forms.TableLayoutPanel();
            this.btnInterfaceEditerModeleInvest = new MetroFramework.Controls.MetroButton();
            this.btnSupprModele = new MetroFramework.Controls.MetroButton();
            this.labelDescrModele = new MetroFramework.Controls.MetroLabel();
            this.labelTitreDescrModele = new MetroFramework.Controls.MetroLabel();
            this.btnInterfaceCreationModel = new MetroFramework.Controls.MetroButton();
            this.comboBoxModelesInvest = new MetroFramework.Controls.MetroComboBox();
            this.panelAjoutActif.SuspendLayout();
            this.panelTitreQuitter.SuspendLayout();
            this.panelAjoutModele.SuspendLayout();
            this.panelConfirmationInvest.SuspendLayout();
            this.layoutActifs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridActifs)).BeginInit();
            this.pannelChoixModeles.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelChoixModele
            // 
            this.labelChoixModele.AutoSize = true;
            this.labelChoixModele.BackColor = System.Drawing.Color.Black;
            this.labelChoixModele.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.labelChoixModele.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelChoixModele.ForeColor = System.Drawing.Color.White;
            this.labelChoixModele.Location = new System.Drawing.Point(814, 31);
            this.labelChoixModele.Name = "labelChoixModele";
            this.labelChoixModele.Size = new System.Drawing.Size(155, 25);
            this.labelChoixModele.TabIndex = 15;
            this.labelChoixModele.Text = "Choix du modele";
            this.labelChoixModele.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelChoixModele.UseCustomBackColor = true;
            this.labelChoixModele.UseCustomForeColor = true;
            this.labelChoixModele.UseStyleColors = true;
            // 
            // panelAjoutActif
            // 
            this.panelAjoutActif.ColumnCount = 2;
            this.panelAjoutActif.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelAjoutActif.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 301F));
            this.panelAjoutActif.Controls.Add(this.inputSymboleActif, 1, 1);
            this.panelAjoutActif.Controls.Add(this.labelSymbole, 0, 1);
            this.panelAjoutActif.Controls.Add(this.inputNomActif, 1, 0);
            this.panelAjoutActif.Controls.Add(this.metroLabel4, 0, 4);
            this.panelAjoutActif.Controls.Add(this.metroLabel3, 0, 3);
            this.panelAjoutActif.Controls.Add(this.metroLabel2, 0, 2);
            this.panelAjoutActif.Controls.Add(this.metroLabel1, 0, 0);
            this.panelAjoutActif.Controls.Add(this.inputRisqueActif, 1, 4);
            this.panelAjoutActif.Controls.Add(this.inputISINActif, 1, 3);
            this.panelAjoutActif.Controls.Add(this.inputTypeActif, 1, 2);
            this.panelAjoutActif.Location = new System.Drawing.Point(705, 103);
            this.panelAjoutActif.Name = "panelAjoutActif";
            this.panelAjoutActif.RowCount = 5;
            this.panelAjoutActif.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelAjoutActif.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelAjoutActif.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelAjoutActif.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelAjoutActif.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.panelAjoutActif.Size = new System.Drawing.Size(387, 160);
            this.panelAjoutActif.TabIndex = 14;
            this.panelAjoutActif.Visible = false;
            // 
            // inputSymboleActif
            // 
            // 
            // 
            // 
            this.inputSymboleActif.CustomButton.Image = null;
            this.inputSymboleActif.CustomButton.Location = new System.Drawing.Point(271, 1);
            this.inputSymboleActif.CustomButton.Name = "";
            this.inputSymboleActif.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.inputSymboleActif.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputSymboleActif.CustomButton.TabIndex = 1;
            this.inputSymboleActif.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputSymboleActif.CustomButton.UseSelectable = true;
            this.inputSymboleActif.CustomButton.Visible = false;
            this.inputSymboleActif.Lines = new string[0];
            this.inputSymboleActif.Location = new System.Drawing.Point(89, 36);
            this.inputSymboleActif.MaxLength = 32767;
            this.inputSymboleActif.Name = "inputSymboleActif";
            this.inputSymboleActif.PasswordChar = '\0';
            this.inputSymboleActif.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputSymboleActif.SelectedText = "";
            this.inputSymboleActif.SelectionLength = 0;
            this.inputSymboleActif.SelectionStart = 0;
            this.inputSymboleActif.ShortcutsEnabled = true;
            this.inputSymboleActif.Size = new System.Drawing.Size(295, 25);
            this.inputSymboleActif.TabIndex = 17;
            this.inputSymboleActif.UseSelectable = true;
            this.inputSymboleActif.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputSymboleActif.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // labelSymbole
            // 
            this.labelSymbole.AutoSize = true;
            this.labelSymbole.ForeColor = System.Drawing.Color.White;
            this.labelSymbole.Location = new System.Drawing.Point(3, 33);
            this.labelSymbole.Name = "labelSymbole";
            this.labelSymbole.Size = new System.Drawing.Size(62, 20);
            this.labelSymbole.TabIndex = 23;
            this.labelSymbole.Text = "Symbole";
            this.labelSymbole.UseCustomBackColor = true;
            this.labelSymbole.UseCustomForeColor = true;
            // 
            // inputNomActif
            // 
            // 
            // 
            // 
            this.inputNomActif.CustomButton.Image = null;
            this.inputNomActif.CustomButton.Location = new System.Drawing.Point(271, 1);
            this.inputNomActif.CustomButton.Name = "";
            this.inputNomActif.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.inputNomActif.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputNomActif.CustomButton.TabIndex = 1;
            this.inputNomActif.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputNomActif.CustomButton.UseSelectable = true;
            this.inputNomActif.CustomButton.Visible = false;
            this.inputNomActif.Lines = new string[0];
            this.inputNomActif.Location = new System.Drawing.Point(89, 3);
            this.inputNomActif.MaxLength = 32767;
            this.inputNomActif.Name = "inputNomActif";
            this.inputNomActif.PasswordChar = '\0';
            this.inputNomActif.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputNomActif.SelectedText = "";
            this.inputNomActif.SelectionLength = 0;
            this.inputNomActif.SelectionStart = 0;
            this.inputNomActif.ShortcutsEnabled = true;
            this.inputNomActif.Size = new System.Drawing.Size(295, 25);
            this.inputNomActif.TabIndex = 17;
            this.inputNomActif.UseSelectable = true;
            this.inputNomActif.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputNomActif.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.ForeColor = System.Drawing.Color.White;
            this.metroLabel4.Location = new System.Drawing.Point(3, 129);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(50, 20);
            this.metroLabel4.TabIndex = 22;
            this.metroLabel4.Text = "Risque";
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseCustomForeColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.ForeColor = System.Drawing.Color.White;
            this.metroLabel3.Location = new System.Drawing.Point(3, 97);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(33, 20);
            this.metroLabel3.TabIndex = 21;
            this.metroLabel3.Text = "ISIN";
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseCustomForeColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.ForeColor = System.Drawing.Color.White;
            this.metroLabel2.Location = new System.Drawing.Point(3, 65);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(39, 20);
            this.metroLabel2.TabIndex = 20;
            this.metroLabel2.Text = "Type";
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.ForeColor = System.Drawing.Color.White;
            this.metroLabel1.Location = new System.Drawing.Point(3, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(40, 20);
            this.metroLabel1.TabIndex = 15;
            this.metroLabel1.Text = "Nom";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            // 
            // inputRisqueActif
            // 
            // 
            // 
            // 
            this.inputRisqueActif.CustomButton.Image = null;
            this.inputRisqueActif.CustomButton.Location = new System.Drawing.Point(271, 1);
            this.inputRisqueActif.CustomButton.Name = "";
            this.inputRisqueActif.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.inputRisqueActif.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputRisqueActif.CustomButton.TabIndex = 1;
            this.inputRisqueActif.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputRisqueActif.CustomButton.UseSelectable = true;
            this.inputRisqueActif.CustomButton.Visible = false;
            this.inputRisqueActif.Lines = new string[0];
            this.inputRisqueActif.Location = new System.Drawing.Point(89, 132);
            this.inputRisqueActif.MaxLength = 32767;
            this.inputRisqueActif.Name = "inputRisqueActif";
            this.inputRisqueActif.PasswordChar = '\0';
            this.inputRisqueActif.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputRisqueActif.SelectedText = "";
            this.inputRisqueActif.SelectionLength = 0;
            this.inputRisqueActif.SelectionStart = 0;
            this.inputRisqueActif.ShortcutsEnabled = true;
            this.inputRisqueActif.Size = new System.Drawing.Size(295, 25);
            this.inputRisqueActif.TabIndex = 19;
            this.inputRisqueActif.UseSelectable = true;
            this.inputRisqueActif.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputRisqueActif.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // inputISINActif
            // 
            // 
            // 
            // 
            this.inputISINActif.CustomButton.Image = null;
            this.inputISINActif.CustomButton.Location = new System.Drawing.Point(271, 1);
            this.inputISINActif.CustomButton.Name = "";
            this.inputISINActif.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.inputISINActif.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputISINActif.CustomButton.TabIndex = 1;
            this.inputISINActif.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputISINActif.CustomButton.UseSelectable = true;
            this.inputISINActif.CustomButton.Visible = false;
            this.inputISINActif.Lines = new string[0];
            this.inputISINActif.Location = new System.Drawing.Point(89, 100);
            this.inputISINActif.MaxLength = 32767;
            this.inputISINActif.Name = "inputISINActif";
            this.inputISINActif.PasswordChar = '\0';
            this.inputISINActif.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputISINActif.SelectedText = "";
            this.inputISINActif.SelectionLength = 0;
            this.inputISINActif.SelectionStart = 0;
            this.inputISINActif.ShortcutsEnabled = true;
            this.inputISINActif.Size = new System.Drawing.Size(295, 25);
            this.inputISINActif.TabIndex = 17;
            this.inputISINActif.UseSelectable = true;
            this.inputISINActif.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputISINActif.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // inputTypeActif
            // 
            // 
            // 
            // 
            this.inputTypeActif.CustomButton.Image = null;
            this.inputTypeActif.CustomButton.Location = new System.Drawing.Point(271, 1);
            this.inputTypeActif.CustomButton.Name = "";
            this.inputTypeActif.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.inputTypeActif.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputTypeActif.CustomButton.TabIndex = 1;
            this.inputTypeActif.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputTypeActif.CustomButton.UseSelectable = true;
            this.inputTypeActif.CustomButton.Visible = false;
            this.inputTypeActif.Lines = new string[0];
            this.inputTypeActif.Location = new System.Drawing.Point(89, 68);
            this.inputTypeActif.MaxLength = 32767;
            this.inputTypeActif.Name = "inputTypeActif";
            this.inputTypeActif.PasswordChar = '\0';
            this.inputTypeActif.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputTypeActif.SelectedText = "";
            this.inputTypeActif.SelectionLength = 0;
            this.inputTypeActif.SelectionStart = 0;
            this.inputTypeActif.ShortcutsEnabled = true;
            this.inputTypeActif.Size = new System.Drawing.Size(295, 25);
            this.inputTypeActif.TabIndex = 16;
            this.inputTypeActif.UseSelectable = true;
            this.inputTypeActif.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputTypeActif.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panelTitreQuitter
            // 
            this.panelTitreQuitter.ColumnCount = 2;
            this.panelTitreQuitter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.8297F));
            this.panelTitreQuitter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.170305F));
            this.panelTitreQuitter.Controls.Add(this.btnQuittInterface, 1, 0);
            this.panelTitreQuitter.Controls.Add(this.labelTitreInterface, 0, 0);
            this.panelTitreQuitter.Location = new System.Drawing.Point(678, 28);
            this.panelTitreQuitter.Name = "panelTitreQuitter";
            this.panelTitreQuitter.RowCount = 1;
            this.panelTitreQuitter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelTitreQuitter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.panelTitreQuitter.Size = new System.Drawing.Size(458, 51);
            this.panelTitreQuitter.TabIndex = 13;
            this.panelTitreQuitter.Visible = false;
            // 
            // btnQuittInterface
            // 
            this.btnQuittInterface.BackColor = System.Drawing.Color.Red;
            this.btnQuittInterface.Location = new System.Drawing.Point(419, 3);
            this.btnQuittInterface.Name = "btnQuittInterface";
            this.btnQuittInterface.Size = new System.Drawing.Size(28, 26);
            this.btnQuittInterface.TabIndex = 12;
            this.btnQuittInterface.Text = "x";
            this.btnQuittInterface.UseCustomBackColor = true;
            this.btnQuittInterface.UseCustomForeColor = true;
            this.btnQuittInterface.UseSelectable = true;
            // 
            // labelTitreInterface
            // 
            this.labelTitreInterface.AutoSize = true;
            this.labelTitreInterface.BackColor = System.Drawing.Color.Black;
            this.labelTitreInterface.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitreInterface.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.labelTitreInterface.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelTitreInterface.ForeColor = System.Drawing.Color.White;
            this.labelTitreInterface.Location = new System.Drawing.Point(3, 0);
            this.labelTitreInterface.Name = "labelTitreInterface";
            this.labelTitreInterface.Size = new System.Drawing.Size(410, 25);
            this.labelTitreInterface.TabIndex = 4;
            this.labelTitreInterface.Text = "Titre interface";
            this.labelTitreInterface.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitreInterface.UseCustomBackColor = true;
            this.labelTitreInterface.UseCustomForeColor = true;
            this.labelTitreInterface.UseStyleColors = true;
            // 
            // btnValidation
            // 
            this.btnValidation.BackColor = System.Drawing.Color.Lime;
            this.btnValidation.Location = new System.Drawing.Point(895, 350);
            this.btnValidation.Name = "btnValidation";
            this.btnValidation.Size = new System.Drawing.Size(184, 43);
            this.btnValidation.TabIndex = 11;
            this.btnValidation.UseCustomBackColor = true;
            this.btnValidation.UseCustomForeColor = true;
            this.btnValidation.UseSelectable = true;
            this.btnValidation.UseStyleColors = true;
            this.btnValidation.Visible = false;
            // 
            // panelAjoutModele
            // 
            this.panelAjoutModele.ColumnCount = 2;
            this.panelAjoutModele.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.88889F));
            this.panelAjoutModele.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.panelAjoutModele.Controls.Add(this.inputDescriptionModeleInvest, 0, 1);
            this.panelAjoutModele.Controls.Add(this.inputNomModeleInvest, 0, 0);
            this.panelAjoutModele.Location = new System.Drawing.Point(681, 106);
            this.panelAjoutModele.Name = "panelAjoutModele";
            this.panelAjoutModele.RowCount = 2;
            this.panelAjoutModele.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.05155F));
            this.panelAjoutModele.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.94846F));
            this.panelAjoutModele.Size = new System.Drawing.Size(430, 157);
            this.panelAjoutModele.TabIndex = 11;
            this.panelAjoutModele.Visible = false;
            // 
            // inputDescriptionModeleInvest
            // 
            this.panelAjoutModele.SetColumnSpan(this.inputDescriptionModeleInvest, 2);
            // 
            // 
            // 
            this.inputDescriptionModeleInvest.CustomButton.Image = null;
            this.inputDescriptionModeleInvest.CustomButton.Location = new System.Drawing.Point(344, 1);
            this.inputDescriptionModeleInvest.CustomButton.Name = "";
            this.inputDescriptionModeleInvest.CustomButton.Size = new System.Drawing.Size(55, 55);
            this.inputDescriptionModeleInvest.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputDescriptionModeleInvest.CustomButton.TabIndex = 1;
            this.inputDescriptionModeleInvest.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputDescriptionModeleInvest.CustomButton.UseSelectable = true;
            this.inputDescriptionModeleInvest.CustomButton.Visible = false;
            this.inputDescriptionModeleInvest.Lines = new string[] {
        "description"};
            this.inputDescriptionModeleInvest.Location = new System.Drawing.Point(3, 58);
            this.inputDescriptionModeleInvest.MaxLength = 32767;
            this.inputDescriptionModeleInvest.Name = "inputDescriptionModeleInvest";
            this.inputDescriptionModeleInvest.PasswordChar = '\0';
            this.inputDescriptionModeleInvest.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputDescriptionModeleInvest.SelectedText = "";
            this.inputDescriptionModeleInvest.SelectionLength = 0;
            this.inputDescriptionModeleInvest.SelectionStart = 0;
            this.inputDescriptionModeleInvest.ShortcutsEnabled = true;
            this.inputDescriptionModeleInvest.Size = new System.Drawing.Size(400, 57);
            this.inputDescriptionModeleInvest.TabIndex = 10;
            this.inputDescriptionModeleInvest.Text = "description";
            this.inputDescriptionModeleInvest.UseSelectable = true;
            this.inputDescriptionModeleInvest.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputDescriptionModeleInvest.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // inputNomModeleInvest
            // 
            this.panelAjoutModele.SetColumnSpan(this.inputNomModeleInvest, 2);
            // 
            // 
            // 
            this.inputNomModeleInvest.CustomButton.Image = null;
            this.inputNomModeleInvest.CustomButton.Location = new System.Drawing.Point(374, 2);
            this.inputNomModeleInvest.CustomButton.Name = "";
            this.inputNomModeleInvest.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.inputNomModeleInvest.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputNomModeleInvest.CustomButton.TabIndex = 1;
            this.inputNomModeleInvest.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputNomModeleInvest.CustomButton.UseSelectable = true;
            this.inputNomModeleInvest.CustomButton.Visible = false;
            this.inputNomModeleInvest.Lines = new string[] {
        "nom modele"};
            this.inputNomModeleInvest.Location = new System.Drawing.Point(3, 3);
            this.inputNomModeleInvest.MaxLength = 32767;
            this.inputNomModeleInvest.Name = "inputNomModeleInvest";
            this.inputNomModeleInvest.PasswordChar = '\0';
            this.inputNomModeleInvest.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputNomModeleInvest.SelectedText = "";
            this.inputNomModeleInvest.SelectionLength = 0;
            this.inputNomModeleInvest.SelectionStart = 0;
            this.inputNomModeleInvest.ShortcutsEnabled = true;
            this.inputNomModeleInvest.Size = new System.Drawing.Size(400, 28);
            this.inputNomModeleInvest.TabIndex = 6;
            this.inputNomModeleInvest.Text = "nom modele";
            this.inputNomModeleInvest.UseSelectable = true;
            this.inputNomModeleInvest.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputNomModeleInvest.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panelLigne1
            // 
            this.panelLigne1.BackColor = System.Drawing.Color.White;
            this.panelLigne1.Location = new System.Drawing.Point(658, 11);
            this.panelLigne1.Name = "panelLigne1";
            this.panelLigne1.Size = new System.Drawing.Size(1, 350);
            this.panelLigne1.TabIndex = 8;
            // 
            // panelConfirmationInvest
            // 
            this.panelConfirmationInvest.ColumnCount = 1;
            this.panelConfirmationInvest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.56717F));
            this.panelConfirmationInvest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.43283F));
            this.panelConfirmationInvest.Controls.Add(this.btnInvest, 0, 1);
            this.panelConfirmationInvest.Controls.Add(this.dateInvest, 0, 0);
            this.panelConfirmationInvest.Location = new System.Drawing.Point(307, 307);
            this.panelConfirmationInvest.Name = "panelConfirmationInvest";
            this.panelConfirmationInvest.RowCount = 2;
            this.panelConfirmationInvest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.panelConfirmationInvest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.panelConfirmationInvest.Size = new System.Drawing.Size(318, 86);
            this.panelConfirmationInvest.TabIndex = 7;
            // 
            // btnInvest
            // 
            this.btnInvest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnInvest.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnInvest.Location = new System.Drawing.Point(3, 50);
            this.btnInvest.Name = "btnInvest";
            this.btnInvest.Size = new System.Drawing.Size(312, 33);
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
            this.layoutActifs.Controls.Add(this.btnSupression, 0, 1);
            this.layoutActifs.Controls.Add(this.gridActifs, 1, 0);
            this.layoutActifs.Controls.Add(this.btnInterfaceAjoutActif, 0, 0);
            this.layoutActifs.Location = new System.Drawing.Point(20, 28);
            this.layoutActifs.Name = "layoutActifs";
            this.layoutActifs.RowCount = 2;
            this.layoutActifs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.29825F));
            this.layoutActifs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.70175F));
            this.layoutActifs.Size = new System.Drawing.Size(610, 251);
            this.layoutActifs.TabIndex = 5;
            // 
            // btnSupression
            // 
            this.btnSupression.BackColor = System.Drawing.Color.Red;
            this.btnSupression.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSupression.Location = new System.Drawing.Point(3, 51);
            this.btnSupression.Name = "btnSupression";
            this.btnSupression.Size = new System.Drawing.Size(35, 35);
            this.btnSupression.TabIndex = 9;
            this.btnSupression.Text = "-";
            this.btnSupression.UseCustomBackColor = true;
            this.btnSupression.UseCustomForeColor = true;
            this.btnSupression.UseSelectable = true;
            this.btnSupression.UseStyleColors = true;
            // 
            // gridActifs
            // 
            this.gridActifs.AllowUserToAddRows = false;
            this.gridActifs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridActifs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridActifs.BackgroundColor = System.Drawing.Color.White;
            this.gridActifs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridActifs.GridColor = System.Drawing.Color.Black;
            this.gridActifs.Location = new System.Drawing.Point(50, 3);
            this.gridActifs.Name = "gridActifs";
            this.gridActifs.RowHeadersWidth = 51;
            this.layoutActifs.SetRowSpan(this.gridActifs, 2);
            this.gridActifs.RowTemplate.Height = 24;
            this.gridActifs.Size = new System.Drawing.Size(557, 245);
            this.gridActifs.TabIndex = 2;
            // 
            // btnInterfaceAjoutActif
            // 
            this.btnInterfaceAjoutActif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnInterfaceAjoutActif.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnInterfaceAjoutActif.Location = new System.Drawing.Point(3, 3);
            this.btnInterfaceAjoutActif.Name = "btnInterfaceAjoutActif";
            this.btnInterfaceAjoutActif.Size = new System.Drawing.Size(35, 35);
            this.btnInterfaceAjoutActif.TabIndex = 4;
            this.btnInterfaceAjoutActif.Text = "+";
            this.btnInterfaceAjoutActif.UseCustomBackColor = true;
            this.btnInterfaceAjoutActif.UseCustomForeColor = true;
            this.btnInterfaceAjoutActif.UseSelectable = true;
            this.btnInterfaceAjoutActif.UseStyleColors = true;
            // 
            // pannelChoixModeles
            // 
            this.pannelChoixModeles.ColumnCount = 4;
            this.pannelChoixModeles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.84849F));
            this.pannelChoixModeles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.15152F));
            this.pannelChoixModeles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.pannelChoixModeles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.pannelChoixModeles.Controls.Add(this.btnInterfaceEditerModeleInvest, 3, 0);
            this.pannelChoixModeles.Controls.Add(this.btnSupprModele, 2, 0);
            this.pannelChoixModeles.Controls.Add(this.labelDescrModele, 0, 2);
            this.pannelChoixModeles.Controls.Add(this.labelTitreDescrModele, 0, 1);
            this.pannelChoixModeles.Controls.Add(this.btnInterfaceCreationModel, 1, 0);
            this.pannelChoixModeles.Controls.Add(this.comboBoxModelesInvest, 0, 0);
            this.pannelChoixModeles.Location = new System.Drawing.Point(678, 103);
            this.pannelChoixModeles.Name = "pannelChoixModeles";
            this.pannelChoixModeles.RowCount = 3;
            this.pannelChoixModeles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.37705F));
            this.pannelChoixModeles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.62295F));
            this.pannelChoixModeles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.pannelChoixModeles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.pannelChoixModeles.Size = new System.Drawing.Size(433, 160);
            this.pannelChoixModeles.TabIndex = 3;
            // 
            // btnInterfaceEditerModeleInvest
            // 
            this.btnInterfaceEditerModeleInvest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnInterfaceEditerModeleInvest.Enabled = false;
            this.btnInterfaceEditerModeleInvest.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnInterfaceEditerModeleInvest.Location = new System.Drawing.Point(349, 3);
            this.btnInterfaceEditerModeleInvest.Name = "btnInterfaceEditerModeleInvest";
            this.btnInterfaceEditerModeleInvest.Size = new System.Drawing.Size(50, 35);
            this.btnInterfaceEditerModeleInvest.TabIndex = 12;
            this.btnInterfaceEditerModeleInvest.Text = "✏️";
            this.btnInterfaceEditerModeleInvest.UseCustomBackColor = true;
            this.btnInterfaceEditerModeleInvest.UseCustomForeColor = true;
            this.btnInterfaceEditerModeleInvest.UseSelectable = true;
            this.btnInterfaceEditerModeleInvest.UseStyleColors = true;
            // 
            // btnSupprModele
            // 
            this.btnSupprModele.BackColor = System.Drawing.Color.Red;
            this.btnSupprModele.Enabled = false;
            this.btnSupprModele.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSupprModele.Location = new System.Drawing.Point(297, 3);
            this.btnSupprModele.Name = "btnSupprModele";
            this.btnSupprModele.Size = new System.Drawing.Size(35, 35);
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
            this.labelDescrModele.Location = new System.Drawing.Point(3, 75);
            this.labelDescrModele.Name = "labelDescrModele";
            this.labelDescrModele.Size = new System.Drawing.Size(244, 85);
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
            this.labelTitreDescrModele.Location = new System.Drawing.Point(3, 43);
            this.labelTitreDescrModele.Name = "labelTitreDescrModele";
            this.labelTitreDescrModele.Size = new System.Drawing.Size(244, 32);
            this.labelTitreDescrModele.TabIndex = 5;
            this.labelTitreDescrModele.Text = "description modele";
            this.labelTitreDescrModele.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitreDescrModele.UseCustomBackColor = true;
            this.labelTitreDescrModele.UseCustomForeColor = true;
            this.labelTitreDescrModele.UseStyleColors = true;
            // 
            // btnInterfaceCreationModel
            // 
            this.btnInterfaceCreationModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnInterfaceCreationModel.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnInterfaceCreationModel.Location = new System.Drawing.Point(253, 3);
            this.btnInterfaceCreationModel.Name = "btnInterfaceCreationModel";
            this.btnInterfaceCreationModel.Size = new System.Drawing.Size(35, 35);
            this.btnInterfaceCreationModel.TabIndex = 5;
            this.btnInterfaceCreationModel.Text = "+";
            this.btnInterfaceCreationModel.UseCustomBackColor = true;
            this.btnInterfaceCreationModel.UseCustomForeColor = true;
            this.btnInterfaceCreationModel.UseSelectable = true;
            this.btnInterfaceCreationModel.UseStyleColors = true;
            // 
            // comboBoxModelesInvest
            // 
            this.comboBoxModelesInvest.FormattingEnabled = true;
            this.comboBoxModelesInvest.ItemHeight = 24;
            this.comboBoxModelesInvest.Location = new System.Drawing.Point(3, 3);
            this.comboBoxModelesInvest.Name = "comboBoxModelesInvest";
            this.comboBoxModelesInvest.Size = new System.Drawing.Size(244, 30);
            this.comboBoxModelesInvest.TabIndex = 3;
            this.comboBoxModelesInvest.UseSelectable = true;
            // 
            // InvestirVue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.layoutActifs);
            this.Controls.Add(this.panelConfirmationInvest);
            this.Controls.Add(this.panelLigne1);
            this.Controls.Add(this.panelAjoutModele);
            this.Controls.Add(this.btnValidation);
            this.Controls.Add(this.panelTitreQuitter);
            this.Controls.Add(this.panelAjoutActif);
            this.Controls.Add(this.labelChoixModele);
            this.Controls.Add(this.pannelChoixModeles);
            this.Name = "InvestirVue";
            this.Size = new System.Drawing.Size(1147, 668);
            this.Load += new System.EventHandler(this.InvestirVue_Load);
            this.panelAjoutActif.ResumeLayout(false);
            this.panelAjoutActif.PerformLayout();
            this.panelTitreQuitter.ResumeLayout(false);
            this.panelTitreQuitter.PerformLayout();
            this.panelAjoutModele.ResumeLayout(false);
            this.panelConfirmationInvest.ResumeLayout(false);
            this.layoutActifs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridActifs)).EndInit();
            this.pannelChoixModeles.ResumeLayout(false);
            this.pannelChoixModeles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridActifs;
        private MetroFramework.Controls.MetroButton btnInterfaceAjoutActif;
        private MetroFramework.Controls.MetroComboBox comboBoxModelesInvest;
        private MetroFramework.Controls.MetroButton btnInterfaceCreationModel;
        private System.Windows.Forms.TableLayoutPanel pannelChoixModeles;
        private MetroFramework.Controls.MetroLabel labelTitreDescrModele;
        private System.Windows.Forms.TableLayoutPanel panelConfirmationInvest;
        private MetroFramework.Controls.MetroButton btnInvest;
        private System.Windows.Forms.TableLayoutPanel layoutActifs;
        private MetroFramework.Controls.MetroLabel labelDescrModele;
        private MetroFramework.Controls.MetroDateTime dateInvest;
        private System.Windows.Forms.Panel panelLigne1;
        private MetroFramework.Controls.MetroButton btnSupprModele;
        private MetroFramework.Controls.MetroButton btnSupression;
        private System.Windows.Forms.TableLayoutPanel panelAjoutModele;
        private MetroFramework.Controls.MetroTextBox inputDescriptionModeleInvest;
        private MetroFramework.Controls.MetroLabel labelTitreInterface;
        private MetroFramework.Controls.MetroTextBox inputNomModeleInvest;
        private MetroFramework.Controls.MetroButton btnValidation;
        private MetroFramework.Controls.MetroButton btnQuittInterface;
        private MetroFramework.Controls.MetroButton btnInterfaceEditerModeleInvest;
        private System.Windows.Forms.TableLayoutPanel panelTitreQuitter;
        private System.Windows.Forms.TableLayoutPanel panelAjoutActif;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox inputRisqueActif;
        private MetroFramework.Controls.MetroTextBox inputISINActif;
        private MetroFramework.Controls.MetroTextBox inputTypeActif;
        private MetroFramework.Controls.MetroTextBox inputNomActif;
        private MetroFramework.Controls.MetroLabel labelChoixModele;
        private MetroFramework.Controls.MetroTextBox inputSymboleActif;
        private MetroFramework.Controls.MetroLabel labelSymbole;
    }
}