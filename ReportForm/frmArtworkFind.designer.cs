namespace cf01.ReportForm
{
    partial class frmArtworkFind
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArtworkFind));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.deDevelop_Date2 = new DevExpress.XtraEditors.DateEdit();
            this.deDevelop_Date1 = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDevelop_Date = new System.Windows.Forms.Label();
            this.lblMark_Content = new System.Windows.Forms.Label();
            this.txtMark_Content = new DevExpress.XtraEditors.TextEdit();
            this.lblArtwork_Name = new System.Windows.Forms.Label();
            this.lblArtwork_Name_en = new System.Windows.Forms.Label();
            this.txtArtwork_Name_prc = new DevExpress.XtraEditors.TextEdit();
            this.txtArtwork_Name_en = new DevExpress.XtraEditors.TextEdit();
            this.lblArtwork_id = new System.Windows.Forms.Label();
            this.txtArtwork_id1 = new DevExpress.XtraEditors.TextEdit();
            this.txtRange_Size = new DevExpress.XtraEditors.LookUpEdit();
            this.chkMulticolor = new DevExpress.XtraEditors.CheckEdit();
            this.lblMuticolor = new System.Windows.Forms.Label();
            this.lblActual_Size = new System.Windows.Forms.Label();
            this.txtActualSize = new DevExpress.XtraEditors.TextEdit();
            this.lblRange_Size = new System.Windows.Forms.Label();
            this.txtProdution_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lblProduct_type = new System.Windows.Forms.Label();
            this.txtMateriel_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMateriel_id = new System.Windows.Forms.Label();
            this.lblBrand_id = new System.Windows.Forms.Label();
            this.lblCust_id = new System.Windows.Forms.Label();
            this.txtCustomer1 = new DevExpress.XtraEditors.TextEdit();
            this.btnFindCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.btnFindBrand = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBrand_id = new DevExpress.XtraEditors.TextEdit();
            this.lblOrder_Date = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLarge = new DevExpress.XtraEditors.SimpleButton();
            this.lblSelectAll = new System.Windows.Forms.Label();
            this.chkSelectAll = new DevExpress.XtraEditors.CheckEdit();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddReport = new DevExpress.XtraEditors.SimpleButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDevelop_Date2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDevelop_Date2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDevelop_Date1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDevelop_Date1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMark_Content.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArtwork_Name_prc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArtwork_Name_en.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArtwork_id1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRange_Size.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMulticolor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdution_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMateriel_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrand_id.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnFind});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(982, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = false;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 25);
            this.btnExit.Text = "Exit(&E)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(70, 25);
            this.btnFind.Text = "Find(&F)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // deDevelop_Date2
            // 
            this.deDevelop_Date2.EditValue = null;
            this.deDevelop_Date2.EnterMoveNextControl = true;
            this.deDevelop_Date2.Location = new System.Drawing.Point(573, 13);
            this.deDevelop_Date2.Name = "deDevelop_Date2";
            this.deDevelop_Date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDevelop_Date2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.deDevelop_Date2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDevelop_Date2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.deDevelop_Date2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDevelop_Date2.Size = new System.Drawing.Size(96, 20);
            this.deDevelop_Date2.TabIndex = 9;
            this.deDevelop_Date2.Leave += new System.EventHandler(this.deDevelop_Date2_Leave);
            // 
            // deDevelop_Date1
            // 
            this.deDevelop_Date1.EditValue = null;
            this.deDevelop_Date1.EnterMoveNextControl = true;
            this.deDevelop_Date1.Location = new System.Drawing.Point(461, 13);
            this.deDevelop_Date1.Name = "deDevelop_Date1";
            this.deDevelop_Date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDevelop_Date1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.deDevelop_Date1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDevelop_Date1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.deDevelop_Date1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDevelop_Date1.Size = new System.Drawing.Size(96, 20);
            this.deDevelop_Date1.TabIndex = 8;
            this.deDevelop_Date1.Leave += new System.EventHandler(this.deDevelop_Date1_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(560, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "~";
            // 
            // lblDevelop_Date
            // 
            this.lblDevelop_Date.Location = new System.Drawing.Point(365, 17);
            this.lblDevelop_Date.Name = "lblDevelop_Date";
            this.lblDevelop_Date.Size = new System.Drawing.Size(93, 12);
            this.lblDevelop_Date.TabIndex = 28;
            this.lblDevelop_Date.Text = "Develop Date";
            this.lblDevelop_Date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMark_Content
            // 
            this.lblMark_Content.Location = new System.Drawing.Point(698, 17);
            this.lblMark_Content.Name = "lblMark_Content";
            this.lblMark_Content.Size = new System.Drawing.Size(76, 12);
            this.lblMark_Content.TabIndex = 27;
            this.lblMark_Content.Text = "Mark Content";
            this.lblMark_Content.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMark_Content
            // 
            this.txtMark_Content.EditValue = "";
            this.txtMark_Content.EnterMoveNextControl = true;
            this.txtMark_Content.Location = new System.Drawing.Point(774, 13);
            this.txtMark_Content.Name = "txtMark_Content";
            this.txtMark_Content.Size = new System.Drawing.Size(176, 20);
            this.txtMark_Content.TabIndex = 15;
            // 
            // lblArtwork_Name
            // 
            this.lblArtwork_Name.Location = new System.Drawing.Point(23, 78);
            this.lblArtwork_Name.Name = "lblArtwork_Name";
            this.lblArtwork_Name.Size = new System.Drawing.Size(105, 12);
            this.lblArtwork_Name.TabIndex = 25;
            this.lblArtwork_Name.Text = "Artwork Name";
            this.lblArtwork_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblArtwork_Name_en
            // 
            this.lblArtwork_Name_en.Location = new System.Drawing.Point(25, 47);
            this.lblArtwork_Name_en.Name = "lblArtwork_Name_en";
            this.lblArtwork_Name_en.Size = new System.Drawing.Size(103, 12);
            this.lblArtwork_Name_en.TabIndex = 24;
            this.lblArtwork_Name_en.Text = "Artwork Name(EN)";
            this.lblArtwork_Name_en.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtArtwork_Name_prc
            // 
            this.txtArtwork_Name_prc.EnterMoveNextControl = true;
            this.txtArtwork_Name_prc.Location = new System.Drawing.Point(131, 73);
            this.txtArtwork_Name_prc.Name = "txtArtwork_Name_prc";
            this.txtArtwork_Name_prc.Size = new System.Drawing.Size(212, 20);
            this.txtArtwork_Name_prc.TabIndex = 3;
            // 
            // txtArtwork_Name_en
            // 
            this.txtArtwork_Name_en.EnterMoveNextControl = true;
            this.txtArtwork_Name_en.Location = new System.Drawing.Point(131, 43);
            this.txtArtwork_Name_en.Name = "txtArtwork_Name_en";
            this.txtArtwork_Name_en.Size = new System.Drawing.Size(212, 20);
            this.txtArtwork_Name_en.TabIndex = 2;
            // 
            // lblArtwork_id
            // 
            this.lblArtwork_id.ForeColor = System.Drawing.Color.Blue;
            this.lblArtwork_id.Location = new System.Drawing.Point(23, 17);
            this.lblArtwork_id.Name = "lblArtwork_id";
            this.lblArtwork_id.Size = new System.Drawing.Size(105, 12);
            this.lblArtwork_id.TabIndex = 19;
            this.lblArtwork_id.Text = "Artwork No.";
            this.lblArtwork_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtArtwork_id1
            // 
            this.txtArtwork_id1.EnterMoveNextControl = true;
            this.txtArtwork_id1.Location = new System.Drawing.Point(131, 13);
            this.txtArtwork_id1.Name = "txtArtwork_id1";
            this.txtArtwork_id1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArtwork_id1.Properties.MaxLength = 7;
            this.txtArtwork_id1.Size = new System.Drawing.Size(212, 20);
            this.txtArtwork_id1.TabIndex = 0;
            // 
            // txtRange_Size
            // 
            this.txtRange_Size.EditValue = "";
            this.txtRange_Size.EnterMoveNextControl = true;
            this.txtRange_Size.Location = new System.Drawing.Point(774, 43);
            this.txtRange_Size.Name = "txtRange_Size";
            this.txtRange_Size.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtRange_Size.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange_Size.Properties.DropDownRows = 10;
            this.txtRange_Size.Properties.ImmediatePopup = true;
            this.txtRange_Size.Properties.MaxLength = 2;
            this.txtRange_Size.Properties.NullText = "";
            this.txtRange_Size.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.txtRange_Size.Properties.ShowHeader = false;
            this.txtRange_Size.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtRange_Size.Size = new System.Drawing.Size(176, 20);
            this.txtRange_Size.TabIndex = 16;
            // 
            // chkMulticolor
            // 
            this.chkMulticolor.Location = new System.Drawing.Point(772, 104);
            this.chkMulticolor.Name = "chkMulticolor";
            this.chkMulticolor.Properties.Caption = "";
            this.chkMulticolor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkMulticolor.Size = new System.Drawing.Size(34, 19);
            this.chkMulticolor.TabIndex = 60;
            this.chkMulticolor.CheckedChanged += new System.EventHandler(this.chkMulticolor_CheckedChanged);
            // 
            // lblMuticolor
            // 
            this.lblMuticolor.Location = new System.Drawing.Point(688, 105);
            this.lblMuticolor.Name = "lblMuticolor";
            this.lblMuticolor.Size = new System.Drawing.Size(83, 16);
            this.lblMuticolor.TabIndex = 59;
            this.lblMuticolor.Text = "Multicolor";
            this.lblMuticolor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblActual_Size
            // 
            this.lblActual_Size.Location = new System.Drawing.Point(707, 78);
            this.lblActual_Size.Name = "lblActual_Size";
            this.lblActual_Size.Size = new System.Drawing.Size(66, 12);
            this.lblActual_Size.TabIndex = 54;
            this.lblActual_Size.Text = "Actual Size";
            this.lblActual_Size.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtActualSize
            // 
            this.txtActualSize.EditValue = "";
            this.txtActualSize.EnterMoveNextControl = true;
            this.txtActualSize.Location = new System.Drawing.Point(774, 73);
            this.txtActualSize.Name = "txtActualSize";
            this.txtActualSize.Size = new System.Drawing.Size(176, 20);
            this.txtActualSize.TabIndex = 17;
            // 
            // lblRange_Size
            // 
            this.lblRange_Size.Location = new System.Drawing.Point(707, 47);
            this.lblRange_Size.Name = "lblRange_Size";
            this.lblRange_Size.Size = new System.Drawing.Size(66, 12);
            this.lblRange_Size.TabIndex = 52;
            this.lblRange_Size.Text = "Range Size";
            this.lblRange_Size.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProdution_id
            // 
            this.txtProdution_id.EditValue = "";
            this.txtProdution_id.EnterMoveNextControl = true;
            this.txtProdution_id.Location = new System.Drawing.Point(461, 104);
            this.txtProdution_id.Name = "txtProdution_id";
            this.txtProdution_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtProdution_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProdution_id.Properties.DropDownRows = 15;
            this.txtProdution_id.Properties.MaxLength = 3;
            this.txtProdution_id.Properties.NullText = "";
            this.txtProdution_id.Properties.ShowHeader = false;
            this.txtProdution_id.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtProdution_id.Size = new System.Drawing.Size(208, 20);
            this.txtProdution_id.TabIndex = 13;
            // 
            // lblProduct_type
            // 
            this.lblProduct_type.Location = new System.Drawing.Point(371, 106);
            this.lblProduct_type.Name = "lblProduct_type";
            this.lblProduct_type.Size = new System.Drawing.Size(87, 14);
            this.lblProduct_type.TabIndex = 50;
            this.lblProduct_type.Text = "Product Type";
            this.lblProduct_type.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMateriel_id
            // 
            this.txtMateriel_id.EditValue = "";
            this.txtMateriel_id.EnterMoveNextControl = true;
            this.txtMateriel_id.Location = new System.Drawing.Point(461, 73);
            this.txtMateriel_id.Name = "txtMateriel_id";
            this.txtMateriel_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMateriel_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMateriel_id.Properties.DropDownRows = 15;
            this.txtMateriel_id.Properties.MaxLength = 2;
            this.txtMateriel_id.Properties.NullText = "";
            this.txtMateriel_id.Properties.ShowHeader = false;
            this.txtMateriel_id.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtMateriel_id.Size = new System.Drawing.Size(208, 20);
            this.txtMateriel_id.TabIndex = 12;
            // 
            // lblMateriel_id
            // 
            this.lblMateriel_id.Location = new System.Drawing.Point(375, 78);
            this.lblMateriel_id.Name = "lblMateriel_id";
            this.lblMateriel_id.Size = new System.Drawing.Size(83, 12);
            this.lblMateriel_id.TabIndex = 48;
            this.lblMateriel_id.Text = "Materiel Type";
            this.lblMateriel_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBrand_id
            // 
            this.lblBrand_id.Location = new System.Drawing.Point(379, 47);
            this.lblBrand_id.Name = "lblBrand_id";
            this.lblBrand_id.Size = new System.Drawing.Size(79, 12);
            this.lblBrand_id.TabIndex = 47;
            this.lblBrand_id.Text = "Brand No.";
            this.lblBrand_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCust_id
            // 
            this.lblCust_id.Location = new System.Drawing.Point(31, 107);
            this.lblCust_id.Name = "lblCust_id";
            this.lblCust_id.Size = new System.Drawing.Size(97, 12);
            this.lblCust_id.TabIndex = 69;
            this.lblCust_id.Text = "Customer ID";
            this.lblCust_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomer1
            // 
            this.txtCustomer1.EditValue = "";
            this.txtCustomer1.EnterMoveNextControl = true;
            this.txtCustomer1.Location = new System.Drawing.Point(131, 104);
            this.txtCustomer1.Name = "txtCustomer1";
            this.txtCustomer1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomer1.Properties.MaxLength = 8;
            this.txtCustomer1.Size = new System.Drawing.Size(212, 20);
            this.txtCustomer1.TabIndex = 4;
            // 
            // btnFindCustomer
            // 
            this.btnFindCustomer.Location = new System.Drawing.Point(343, 104);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(19, 20);
            this.btnFindCustomer.TabIndex = 72;
            this.btnFindCustomer.Text = "...";
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // btnFindBrand
            // 
            this.btnFindBrand.Location = new System.Drawing.Point(669, 43);
            this.btnFindBrand.Name = "btnFindBrand";
            this.btnFindBrand.Size = new System.Drawing.Size(19, 20);
            this.btnFindBrand.TabIndex = 75;
            this.btnFindBrand.Text = "...";
            this.btnFindBrand.Click += new System.EventHandler(this.btnFindBrand_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtBrand_id);
            this.panel1.Controls.Add(this.lblMateriel_id);
            this.panel1.Controls.Add(this.txtArtwork_id1);
            this.panel1.Controls.Add(this.lblArtwork_id);
            this.panel1.Controls.Add(this.btnFindBrand);
            this.panel1.Controls.Add(this.txtArtwork_Name_en);
            this.panel1.Controls.Add(this.btnFindCustomer);
            this.panel1.Controls.Add(this.txtArtwork_Name_prc);
            this.panel1.Controls.Add(this.txtCustomer1);
            this.panel1.Controls.Add(this.lblArtwork_Name_en);
            this.panel1.Controls.Add(this.lblCust_id);
            this.panel1.Controls.Add(this.lblArtwork_Name);
            this.panel1.Controls.Add(this.txtMark_Content);
            this.panel1.Controls.Add(this.lblMark_Content);
            this.panel1.Controls.Add(this.lblDevelop_Date);
            this.panel1.Controls.Add(this.txtRange_Size);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.deDevelop_Date1);
            this.panel1.Controls.Add(this.deDevelop_Date2);
            this.panel1.Controls.Add(this.lblBrand_id);
            this.panel1.Controls.Add(this.txtMateriel_id);
            this.panel1.Controls.Add(this.chkMulticolor);
            this.panel1.Controls.Add(this.lblProduct_type);
            this.panel1.Controls.Add(this.lblMuticolor);
            this.panel1.Controls.Add(this.txtProdution_id);
            this.panel1.Controls.Add(this.lblRange_Size);
            this.panel1.Controls.Add(this.txtActualSize);
            this.panel1.Controls.Add(this.lblActual_Size);
            this.panel1.Controls.Add(this.lblOrder_Date);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 170);
            this.panel1.TabIndex = 0;
            // 
            // txtBrand_id
            // 
            this.txtBrand_id.EnterMoveNextControl = true;
            this.txtBrand_id.Location = new System.Drawing.Point(461, 43);
            this.txtBrand_id.Name = "txtBrand_id";
            this.txtBrand_id.Size = new System.Drawing.Size(208, 20);
            this.txtBrand_id.TabIndex = 91;
            // 
            // lblOrder_Date
            // 
            this.lblOrder_Date.Location = new System.Drawing.Point(353, 17);
            this.lblOrder_Date.Name = "lblOrder_Date";
            this.lblOrder_Date.Size = new System.Drawing.Size(105, 12);
            this.lblOrder_Date.TabIndex = 84;
            this.lblOrder_Date.Text = "Order Date";
            this.lblOrder_Date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel2.Controls.Add(this.btnLarge);
            this.panel2.Controls.Add(this.lblSelectAll);
            this.panel2.Controls.Add(this.chkSelectAll);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnAddReport);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 198);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 415);
            this.panel2.TabIndex = 83;
            // 
            // btnLarge
            // 
            this.btnLarge.Image = ((System.Drawing.Image)(resources.GetObject("btnLarge.Image")));
            this.btnLarge.Location = new System.Drawing.Point(841, 6);
            this.btnLarge.Name = "btnLarge";
            this.btnLarge.Size = new System.Drawing.Size(109, 29);
            this.btnLarge.TabIndex = 89;
            this.btnLarge.Text = "&Large Picture";
            this.btnLarge.Click += new System.EventHandler(this.btnLarge_Click);
            // 
            // lblSelectAll
            // 
            this.lblSelectAll.AutoSize = true;
            this.lblSelectAll.Location = new System.Drawing.Point(42, 17);
            this.lblSelectAll.Name = "lblSelectAll";
            this.lblSelectAll.Size = new System.Drawing.Size(49, 12);
            this.lblSelectAll.TabIndex = 88;
            this.lblSelectAll.Text = "Select All";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Location = new System.Drawing.Point(15, 13);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Properties.Caption = "";
            this.chkSelectAll.Size = new System.Drawing.Size(25, 19);
            this.chkSelectAll.TabIndex = 7;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTotal.Location = new System.Drawing.Point(122, 15);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 18);
            this.lblTotal.TabIndex = 86;
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(735, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 29);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "&Clear Report";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(633, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 29);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "&Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAddReport
            // 
            this.btnAddReport.Image = ((System.Drawing.Image)(resources.GetObject("btnAddReport.Image")));
            this.btnAddReport.Location = new System.Drawing.Point(500, 6);
            this.btnAddReport.Name = "btnAddReport";
            this.btnAddReport.Size = new System.Drawing.Size(122, 29);
            this.btnAddReport.TabIndex = 3;
            this.btnAddReport.Text = "&Add to Report";
            this.btnAddReport.Click += new System.EventHandler(this.btnAddReport_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(3, 41);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(976, 372);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // frmArtworkFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 613);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmArtworkFind";
            this.Text = "frmArtworkFind";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmArtworkFind_FormClosed);
            this.Load += new System.EventHandler(this.frmArtworkFind_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDevelop_Date2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDevelop_Date2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDevelop_Date1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDevelop_Date1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMark_Content.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArtwork_Name_prc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArtwork_Name_en.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArtwork_id1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRange_Size.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMulticolor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdution_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMateriel_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrand_id.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnFind;
        private DevExpress.XtraEditors.DateEdit deDevelop_Date2;
        private DevExpress.XtraEditors.DateEdit deDevelop_Date1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDevelop_Date;
        private System.Windows.Forms.Label lblMark_Content;
        private DevExpress.XtraEditors.TextEdit txtMark_Content;
        private System.Windows.Forms.Label lblArtwork_Name;
        private System.Windows.Forms.Label lblArtwork_Name_en;
        private DevExpress.XtraEditors.TextEdit txtArtwork_Name_prc;
        private DevExpress.XtraEditors.TextEdit txtArtwork_Name_en;
        private System.Windows.Forms.Label lblArtwork_id;
        private DevExpress.XtraEditors.TextEdit txtArtwork_id1;
        private DevExpress.XtraEditors.LookUpEdit txtRange_Size;
        private DevExpress.XtraEditors.CheckEdit chkMulticolor;
        private System.Windows.Forms.Label lblMuticolor;
        private System.Windows.Forms.Label lblActual_Size;
        private DevExpress.XtraEditors.TextEdit txtActualSize;
        private System.Windows.Forms.Label lblRange_Size;
        private DevExpress.XtraEditors.LookUpEdit txtProdution_id;
        private System.Windows.Forms.Label lblProduct_type;
        private DevExpress.XtraEditors.LookUpEdit txtMateriel_id;
        private System.Windows.Forms.Label lblMateriel_id;
        private System.Windows.Forms.Label lblBrand_id;
        private System.Windows.Forms.Label lblCust_id;
        private DevExpress.XtraEditors.TextEdit txtCustomer1;
        private DevExpress.XtraEditors.SimpleButton btnFindCustomer;
        private DevExpress.XtraEditors.SimpleButton btnFindBrand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnAddReport;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.CheckEdit chkSelectAll;
        private System.Windows.Forms.Label lblOrder_Date;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraEditors.SimpleButton btnLarge;
        private DevExpress.XtraEditors.TextEdit txtBrand_id;
    }
}