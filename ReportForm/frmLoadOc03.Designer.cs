namespace cf01.ReportForm
{
    partial class frmLoadOc03
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadOc03));
            this.ts = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNEXCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExpToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.progressIndicatorAbout = new ProgressControls.ProgressIndicator();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.cmbMoGroup = new System.Windows.Forms.ComboBox();
            this.lblMoGroup = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.mo_id = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.m_id = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.seller_id = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.order_status = new System.Windows.Forms.Label();
            this.cmbCpl = new System.Windows.Forms.ComboBox();
            this.btnFindBrand = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.contract_id = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.it_customer = new System.Windows.Forms.Label();
            this.order_date = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.brand_id = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.dgvPrdDetails = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTNExpMo = new System.Windows.Forms.Button();
            this.order_mo_flow = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrdDetails)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.AutoSize = false;
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNFIND,
            this.toolStripSeparator2,
            this.BTNEXCEL,
            this.toolStripSeparator3,
            this.btnExpToExcel,
            this.toolStripSeparator4});
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ts.Size = new System.Drawing.Size(1024, 32);
            this.ts.TabIndex = 0;
            this.ts.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(44, 29);
            this.BTNEXIT.Text = "&Exit";
            this.BTNEXIT.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(46, 29);
            this.BTNFIND.Text = "&Find";
            this.BTNFIND.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // BTNEXCEL
            // 
            this.BTNEXCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXCEL.Image")));
            this.BTNEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXCEL.Name = "BTNEXCEL";
            this.BTNEXCEL.Size = new System.Drawing.Size(89, 29);
            this.BTNEXCEL.Text = "Exp &To Excel";
            this.BTNEXCEL.Click += new System.EventHandler(this.cmdExp_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // btnExpToExcel
            // 
            this.btnExpToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExpToExcel.Image")));
            this.btnExpToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpToExcel.Name = "btnExpToExcel";
            this.btnExpToExcel.Size = new System.Drawing.Size(143, 29);
            this.btnExpToExcel.Text = "匯出到Excel(快捷方法)";
            this.btnExpToExcel.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.progressIndicatorAbout);
            this.splitContainer1.Panel1.Controls.Add(this.dateEdit2);
            this.splitContainer1.Panel1.Controls.Add(this.dateEdit1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbMoGroup);
            this.splitContainer1.Panel1.Controls.Add(this.lblMoGroup);
            this.splitContainer1.Panel1.Controls.Add(this.textBox12);
            this.splitContainer1.Panel1.Controls.Add(this.mo_id);
            this.splitContainer1.Panel1.Controls.Add(this.textBox11);
            this.splitContainer1.Panel1.Controls.Add(this.m_id);
            this.splitContainer1.Panel1.Controls.Add(this.textBox10);
            this.splitContainer1.Panel1.Controls.Add(this.seller_id);
            this.splitContainer1.Panel1.Controls.Add(this.textBox8);
            this.splitContainer1.Panel1.Controls.Add(this.textBox9);
            this.splitContainer1.Panel1.Controls.Add(this.btnFindCustomer);
            this.splitContainer1.Panel1.Controls.Add(this.order_status);
            this.splitContainer1.Panel1.Controls.Add(this.cmbCpl);
            this.splitContainer1.Panel1.Controls.Add(this.btnFindBrand);
            this.splitContainer1.Panel1.Controls.Add(this.textBox6);
            this.splitContainer1.Panel1.Controls.Add(this.textBox5);
            this.splitContainer1.Panel1.Controls.Add(this.textBox4);
            this.splitContainer1.Panel1.Controls.Add(this.contract_id);
            this.splitContainer1.Panel1.Controls.Add(this.textBox3);
            this.splitContainer1.Panel1.Controls.Add(this.it_customer);
            this.splitContainer1.Panel1.Controls.Add(this.order_date);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.brand_id);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1024, 638);
            this.splitContainer1.SplitterDistance = 123;
            this.splitContainer1.TabIndex = 1;
            // 
            // progressIndicatorAbout
            // 
            this.progressIndicatorAbout.Location = new System.Drawing.Point(706, 8);
            this.progressIndicatorAbout.Name = "progressIndicatorAbout";
            this.progressIndicatorAbout.Percentage = 0F;
            this.progressIndicatorAbout.Size = new System.Drawing.Size(100, 100);
            this.progressIndicatorAbout.TabIndex = 3;
            this.progressIndicatorAbout.Text = "progressIndicator1";
            this.progressIndicatorAbout.Visible = false;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(561, 9);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dateEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(100, 22);
            this.dateEdit2.TabIndex = 3;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(455, 9);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(100, 22);
            this.dateEdit1.TabIndex = 2;
            // 
            // cmbMoGroup
            // 
            this.cmbMoGroup.FormattingEnabled = true;
            this.cmbMoGroup.Location = new System.Drawing.Point(618, 86);
            this.cmbMoGroup.Name = "cmbMoGroup";
            this.cmbMoGroup.Size = new System.Drawing.Size(67, 20);
            this.cmbMoGroup.TabIndex = 100;
            // 
            // lblMoGroup
            // 
            this.lblMoGroup.AutoSize = true;
            this.lblMoGroup.Location = new System.Drawing.Point(559, 94);
            this.lblMoGroup.Name = "lblMoGroup";
            this.lblMoGroup.Size = new System.Drawing.Size(57, 12);
            this.lblMoGroup.TabIndex = 99;
            this.lblMoGroup.Text = "Mo Group:";
            // 
            // textBox12
            // 
            this.textBox12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox12.Location = new System.Drawing.Point(561, 62);
            this.textBox12.MaxLength = 9;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 22);
            this.textBox12.TabIndex = 11;
            // 
            // mo_id
            // 
            this.mo_id.AutoSize = true;
            this.mo_id.Location = new System.Drawing.Point(370, 65);
            this.mo_id.Name = "mo_id";
            this.mo_id.Size = new System.Drawing.Size(46, 12);
            this.mo_id.TabIndex = 98;
            this.mo_id.Text = "MO No.:";
            // 
            // textBox11
            // 
            this.textBox11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox11.Location = new System.Drawing.Point(455, 62);
            this.textBox11.MaxLength = 9;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 22);
            this.textBox11.TabIndex = 10;
            this.textBox11.Leave += new System.EventHandler(this.textBox11_Leave);
            // 
            // m_id
            // 
            this.m_id.AutoSize = true;
            this.m_id.Location = new System.Drawing.Point(370, 90);
            this.m_id.Name = "m_id";
            this.m_id.Size = new System.Drawing.Size(52, 12);
            this.m_id.TabIndex = 95;
            this.m_id.Text = "Currency:";
            // 
            // textBox10
            // 
            this.textBox10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox10.Location = new System.Drawing.Point(220, 62);
            this.textBox10.MaxLength = 8;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 22);
            this.textBox10.TabIndex = 9;
            // 
            // seller_id
            // 
            this.seller_id.AutoSize = true;
            this.seller_id.Location = new System.Drawing.Point(29, 65);
            this.seller_id.Name = "seller_id";
            this.seller_id.Size = new System.Drawing.Size(49, 12);
            this.seller_id.TabIndex = 93;
            this.seller_id.Text = "Seller ID:";
            // 
            // textBox8
            // 
            this.textBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox8.Location = new System.Drawing.Point(455, 86);
            this.textBox8.MaxLength = 3;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 22);
            this.textBox8.TabIndex = 13;
            // 
            // textBox9
            // 
            this.textBox9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox9.Location = new System.Drawing.Point(114, 62);
            this.textBox9.MaxLength = 8;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 22);
            this.textBox9.TabIndex = 8;
            this.textBox9.Leave += new System.EventHandler(this.textBox9_Leave);
            // 
            // btnFindCustomer
            // 
            this.btnFindCustomer.Location = new System.Drawing.Point(324, 37);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(22, 23);
            this.btnFindCustomer.TabIndex = 90;
            this.btnFindCustomer.Text = "...";
            this.btnFindCustomer.UseVisualStyleBackColor = true;
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // order_status
            // 
            this.order_status.AutoSize = true;
            this.order_status.Location = new System.Drawing.Point(27, 90);
            this.order_status.Name = "order_status";
            this.order_status.Size = new System.Drawing.Size(65, 12);
            this.order_status.TabIndex = 89;
            this.order_status.Text = "Order Status:";
            // 
            // cmbCpl
            // 
            this.cmbCpl.FormattingEnabled = true;
            this.cmbCpl.Location = new System.Drawing.Point(114, 88);
            this.cmbCpl.Name = "cmbCpl";
            this.cmbCpl.Size = new System.Drawing.Size(206, 20);
            this.cmbCpl.TabIndex = 12;
            // 
            // btnFindBrand
            // 
            this.btnFindBrand.Location = new System.Drawing.Point(324, 7);
            this.btnFindBrand.Name = "btnFindBrand";
            this.btnFindBrand.Size = new System.Drawing.Size(22, 23);
            this.btnFindBrand.TabIndex = 87;
            this.btnFindBrand.Text = "...";
            this.btnFindBrand.UseVisualStyleBackColor = true;
            this.btnFindBrand.Click += new System.EventHandler(this.btnFindBrand_Click);
            // 
            // textBox6
            // 
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox6.Location = new System.Drawing.Point(561, 35);
            this.textBox6.MaxLength = 8;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 7;
            // 
            // textBox5
            // 
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox5.Location = new System.Drawing.Point(455, 35);
            this.textBox5.MaxLength = 8;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 6;
            this.textBox5.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // textBox4
            // 
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox4.Location = new System.Drawing.Point(220, 35);
            this.textBox4.MaxLength = 8;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 5;
            // 
            // contract_id
            // 
            this.contract_id.AutoSize = true;
            this.contract_id.Location = new System.Drawing.Point(370, 38);
            this.contract_id.Name = "contract_id";
            this.contract_id.Size = new System.Drawing.Size(42, 12);
            this.contract_id.TabIndex = 81;
            this.contract_id.Text = "PO No.:";
            // 
            // textBox3
            // 
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.Location = new System.Drawing.Point(114, 35);
            this.textBox3.MaxLength = 8;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 4;
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // it_customer
            // 
            this.it_customer.AutoSize = true;
            this.it_customer.Location = new System.Drawing.Point(29, 38);
            this.it_customer.Name = "it_customer";
            this.it_customer.Size = new System.Drawing.Size(81, 12);
            this.it_customer.TabIndex = 82;
            this.it_customer.Text = "Customer Code:";
            // 
            // order_date
            // 
            this.order_date.AutoSize = true;
            this.order_date.Location = new System.Drawing.Point(370, 11);
            this.order_date.Name = "order_date";
            this.order_date.Size = new System.Drawing.Size(59, 12);
            this.order_date.TabIndex = 80;
            this.order_date.Text = "Order Date:";
            // 
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(220, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(114, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // brand_id
            // 
            this.brand_id.AutoSize = true;
            this.brand_id.Location = new System.Drawing.Point(29, 11);
            this.brand_id.Name = "brand_id";
            this.brand_id.Size = new System.Drawing.Size(37, 12);
            this.brand_id.TabIndex = 75;
            this.brand_id.Text = "Brand:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvDetails);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvPrdDetails);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(1024, 511);
            this.splitContainer2.SplitterDistance = 241;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersWidth = 18;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1024, 241);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // dgvPrdDetails
            // 
            this.dgvPrdDetails.AllowUserToAddRows = false;
            this.dgvPrdDetails.AllowUserToDeleteRows = false;
            this.dgvPrdDetails.ColumnHeadersHeight = 28;
            this.dgvPrdDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPrdDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrdDetails.Location = new System.Drawing.Point(0, 35);
            this.dgvPrdDetails.Name = "dgvPrdDetails";
            this.dgvPrdDetails.RowHeadersWidth = 18;
            this.dgvPrdDetails.RowTemplate.Height = 24;
            this.dgvPrdDetails.Size = new System.Drawing.Size(1024, 231);
            this.dgvPrdDetails.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BTNExpMo);
            this.panel1.Controls.Add(this.order_mo_flow);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 35);
            this.panel1.TabIndex = 0;
            // 
            // BTNExpMo
            // 
            this.BTNExpMo.AutoSize = true;
            this.BTNExpMo.Image = ((System.Drawing.Image)(resources.GetObject("BTNExpMo.Image")));
            this.BTNExpMo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNExpMo.Location = new System.Drawing.Point(408, 7);
            this.BTNExpMo.Name = "BTNExpMo";
            this.BTNExpMo.Size = new System.Drawing.Size(162, 23);
            this.BTNExpMo.TabIndex = 4;
            this.BTNExpMo.Text = "Exp To Excel";
            this.BTNExpMo.UseVisualStyleBackColor = true;
            this.BTNExpMo.Click += new System.EventHandler(this.BTNExpMo_Click);
            // 
            // order_mo_flow
            // 
            this.order_mo_flow.AutoSize = true;
            this.order_mo_flow.Location = new System.Drawing.Point(7, 10);
            this.order_mo_flow.Name = "order_mo_flow";
            this.order_mo_flow.Size = new System.Drawing.Size(125, 12);
            this.order_mo_flow.TabIndex = 3;
            this.order_mo_flow.Text = "Order Pproduction Status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mo  No.:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(213, 7);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmLoadOc03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 670);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ts);
            this.Name = "frmLoadOc03";
            this.Text = "frmLoadOc03";
            this.Load += new System.EventHandler(this.frmLoadOc03_Load);
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrdDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripButton BTNEXCEL;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label contract_id;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label it_customer;
        private System.Windows.Forms.Label order_date;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label brand_id;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridView dgvPrdDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label order_mo_flow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTNExpMo;
        private System.Windows.Forms.Button btnFindBrand;
        private System.Windows.Forms.Label order_status;
        private System.Windows.Forms.ComboBox cmbCpl;
        private System.Windows.Forms.Button btnFindCustomer;
        private System.Windows.Forms.Label seller_id;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label m_id;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label mo_id;
        private System.Windows.Forms.TextBox textBox11;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblMoGroup;
        private System.Windows.Forms.ComboBox cmbMoGroup;
        private System.Windows.Forms.ToolStripButton btnExpToExcel;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private ProgressControls.ProgressIndicator progressIndicatorAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}