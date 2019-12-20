namespace cf01.Forms
{
    partial class frmTest_item_set_find
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest_item_set_find));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNPRINT = new System.Windows.Forms.ToolStripButton();
            this.BTNEXCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTest_item2 = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDatum = new System.Windows.Forms.Label();
            this.txtTest_item1 = new DevExpress.XtraEditors.LookUpEdit();
            this.lblBrand_category = new System.Windows.Forms.Label();
            this.txtID1 = new DevExpress.XtraEditors.LookUpEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.test_item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.test_item_cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.test_item_edesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTest_item2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTest_item1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNCANCEL,
            this.toolStripSeparator4,
            this.BTNFIND,
            this.toolStripSeparator8,
            this.BTNPRINT,
            this.BTNEXCEL,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1064, 28);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.AutoSize = false;
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(65, 25);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // BTNCANCEL
            // 
            this.BTNCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNCANCEL.Image")));
            this.BTNCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCANCEL.Name = "BTNCANCEL";
            this.BTNCANCEL.Size = new System.Drawing.Size(65, 25);
            this.BTNCANCEL.Text = "重置(&U)";
            this.BTNCANCEL.Click += new System.EventHandler(this.BTNCANCEL_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(63, 25);
            this.BTNFIND.Text = "查詢(&F)";
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 28);
            // 
            // BTNPRINT
            // 
            this.BTNPRINT.Image = ((System.Drawing.Image)(resources.GetObject("BTNPRINT.Image")));
            this.BTNPRINT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNPRINT.Name = "BTNPRINT";
            this.BTNPRINT.Size = new System.Drawing.Size(63, 25);
            this.BTNPRINT.Text = "列印(&P)";
            this.BTNPRINT.Click += new System.EventHandler(this.BTNPRINT_Click);
            // 
            // BTNEXCEL
            // 
            this.BTNEXCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXCEL.Image")));
            this.BTNEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXCEL.Name = "BTNEXCEL";
            this.BTNEXCEL.Size = new System.Drawing.Size(86, 25);
            this.BTNEXCEL.Text = "匯出EXCEL";
            this.BTNEXCEL.Click += new System.EventHandler(this.BTNEXCEL_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTest_item2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtID2);
            this.panel1.Controls.Add(this.lblDatum);
            this.panel1.Controls.Add(this.txtTest_item1);
            this.panel1.Controls.Add(this.lblBrand_category);
            this.panel1.Controls.Add(this.txtID1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(2, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1061, 94);
            this.panel1.TabIndex = 14;
            this.panel1.Tag = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 106;
            this.label3.Text = "--";
            // 
            // txtTest_item2
            // 
            this.txtTest_item2.EditValue = "";
            this.txtTest_item2.EnterMoveNextControl = true;
            this.txtTest_item2.Location = new System.Drawing.Point(287, 48);
            this.txtTest_item2.Name = "txtTest_item2";
            this.txtTest_item2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTest_item2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTest_item2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 70, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 100, "cdesc"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("edesc", 250, "edesc")});
            this.txtTest_item2.Properties.DropDownRows = 20;
            this.txtTest_item2.Properties.MaxLength = 10;
            this.txtTest_item2.Properties.NullText = "";
            this.txtTest_item2.Properties.PopupFormMinSize = new System.Drawing.Size(420, 0);
            this.txtTest_item2.Properties.ShowHeader = false;
            this.txtTest_item2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtTest_item2.Size = new System.Drawing.Size(171, 20);
            this.txtTest_item2.TabIndex = 5;
            this.txtTest_item2.Tag = "2";
            this.txtTest_item2.Click += new System.EventHandler(this.txtTest_item2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 12);
            this.label1.TabIndex = 102;
            this.label1.Text = "--";
            // 
            // txtID2
            // 
            this.txtID2.EditValue = "";
            this.txtID2.EnterMoveNextControl = true;
            this.txtID2.Location = new System.Drawing.Point(287, 17);
            this.txtID2.Name = "txtID2";
            this.txtID2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtID2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID2.Properties.DropDownRows = 20;
            this.txtID2.Properties.MaxLength = 10;
            this.txtID2.Properties.NullText = "";
            this.txtID2.Properties.PopupFormMinSize = new System.Drawing.Size(200, 0);
            this.txtID2.Properties.ShowHeader = false;
            this.txtID2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtID2.Size = new System.Drawing.Size(171, 20);
            this.txtID2.TabIndex = 1;
            this.txtID2.Tag = "2";
            this.txtID2.Click += new System.EventHandler(this.txtID2_Click);
            // 
            // lblDatum
            // 
            this.lblDatum.Location = new System.Drawing.Point(7, 52);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(80, 13);
            this.lblDatum.TabIndex = 98;
            this.lblDatum.Text = "測試頂目";
            this.lblDatum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTest_item1
            // 
            this.txtTest_item1.EditValue = "";
            this.txtTest_item1.EnterMoveNextControl = true;
            this.txtTest_item1.Location = new System.Drawing.Point(91, 48);
            this.txtTest_item1.Name = "txtTest_item1";
            this.txtTest_item1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTest_item1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTest_item1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 70, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 100, "cdesc"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("edesc", 250, "edesc")});
            this.txtTest_item1.Properties.DropDownRows = 20;
            this.txtTest_item1.Properties.MaxLength = 10;
            this.txtTest_item1.Properties.NullText = "";
            this.txtTest_item1.Properties.PopupFormMinSize = new System.Drawing.Size(420, 0);
            this.txtTest_item1.Properties.ShowHeader = false;
            this.txtTest_item1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtTest_item1.Size = new System.Drawing.Size(171, 20);
            this.txtTest_item1.TabIndex = 4;
            this.txtTest_item1.Tag = "2";
            this.txtTest_item1.Click += new System.EventHandler(this.txtTest_item1_Click);
            this.txtTest_item1.Leave += new System.EventHandler(this.txtTest_item1_Leave);
            // 
            // lblBrand_category
            // 
            this.lblBrand_category.Location = new System.Drawing.Point(7, 21);
            this.lblBrand_category.Name = "lblBrand_category";
            this.lblBrand_category.Size = new System.Drawing.Size(80, 13);
            this.lblBrand_category.TabIndex = 19;
            this.lblBrand_category.Text = "測試類別";
            this.lblBrand_category.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID1
            // 
            this.txtID1.EditValue = "";
            this.txtID1.EnterMoveNextControl = true;
            this.txtID1.Location = new System.Drawing.Point(91, 17);
            this.txtID1.Name = "txtID1";
            this.txtID1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtID1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID1.Properties.DropDownRows = 20;
            this.txtID1.Properties.MaxLength = 10;
            this.txtID1.Properties.NullText = "";
            this.txtID1.Properties.PopupFormMinSize = new System.Drawing.Size(200, 0);
            this.txtID1.Properties.ShowHeader = false;
            this.txtID1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtID1.Size = new System.Drawing.Size(171, 20);
            this.txtID1.TabIndex = 0;
            this.txtID1.Tag = "2";
            this.txtID1.Click += new System.EventHandler(this.txtID1_Click);
            this.txtID1.Leave += new System.EventHandler(this.txtID1_Leave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(-2, 402);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1032, 118);
            this.panel2.TabIndex = 10;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToOrderColumns = true;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cdesc,
            this.edesc,
            this.type,
            this.test_item_id,
            this.test_item_cdesc,
            this.test_item_edesc,
            this.prod_type,
            this.prod_cdesc});
            this.dgvDetails.Location = new System.Drawing.Point(2, 125);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1061, 325);
            this.dgvDetails.TabIndex = 15;
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.dgvDetails_SelectionChanged);
            this.dgvDetails.DoubleClick += new System.EventHandler(this.dgvDetails_DoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "測試分類";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "cdesc";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "中文名稱";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "edesc";
            this.dataGridViewTextBoxColumn3.HeaderText = "英文名稱";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "type";
            this.dataGridViewTextBoxColumn4.HeaderText = "分類";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 30;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "test_item_id";
            this.dataGridViewTextBoxColumn5.HeaderText = "測試項目編號";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "test_item_cdesc";
            this.dataGridViewTextBoxColumn6.HeaderText = "測試項目中文名稱";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "test_item_edesc";
            this.dataGridViewTextBoxColumn7.HeaderText = "測試項目英文名稱";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 300;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "prod_type";
            this.dataGridViewTextBoxColumn8.HeaderText = "prod_type";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.Frozen = true;
            this.id.HeaderText = "測試分類";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 80;
            // 
            // cdesc
            // 
            this.cdesc.DataPropertyName = "cdesc";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.cdesc.DefaultCellStyle = dataGridViewCellStyle2;
            this.cdesc.HeaderText = "中文名稱";
            this.cdesc.Name = "cdesc";
            this.cdesc.ReadOnly = true;
            this.cdesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cdesc.Width = 150;
            // 
            // edesc
            // 
            this.edesc.DataPropertyName = "edesc";
            this.edesc.HeaderText = "英文名稱";
            this.edesc.Name = "edesc";
            this.edesc.ReadOnly = true;
            this.edesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.edesc.Width = 150;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "分類";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // test_item_id
            // 
            this.test_item_id.DataPropertyName = "test_item_id";
            this.test_item_id.HeaderText = "測試項目編號";
            this.test_item_id.Name = "test_item_id";
            this.test_item_id.ReadOnly = true;
            this.test_item_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.test_item_id.Width = 90;
            // 
            // test_item_cdesc
            // 
            this.test_item_cdesc.DataPropertyName = "test_item_cdesc";
            this.test_item_cdesc.HeaderText = "測試項目中文名稱";
            this.test_item_cdesc.Name = "test_item_cdesc";
            this.test_item_cdesc.ReadOnly = true;
            this.test_item_cdesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.test_item_cdesc.Width = 150;
            // 
            // test_item_edesc
            // 
            this.test_item_edesc.DataPropertyName = "test_item_edesc";
            this.test_item_edesc.HeaderText = "測試項目英文名稱";
            this.test_item_edesc.Name = "test_item_edesc";
            this.test_item_edesc.ReadOnly = true;
            this.test_item_edesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.test_item_edesc.Width = 250;
            // 
            // prod_type
            // 
            this.prod_type.DataPropertyName = "prod_type";
            this.prod_type.HeaderText = "產品類型";
            this.prod_type.Name = "prod_type";
            this.prod_type.ReadOnly = true;
            this.prod_type.Width = 80;
            // 
            // prod_cdesc
            // 
            this.prod_cdesc.DataPropertyName = "prod_cdesc";
            this.prod_cdesc.HeaderText = "產品類型描述";
            this.prod_cdesc.Name = "prod_cdesc";
            this.prod_cdesc.ReadOnly = true;
            this.prod_cdesc.Width = 120;
            // 
            // frmTest_item_set_find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 450);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmTest_item_set_find";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "測試項目設置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTest_item_set_find_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTest_item2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTest_item1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton BTNPRINT;
        private System.Windows.Forms.ToolStripButton BTNEXCEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit txtTest_item2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit txtID2;
        private System.Windows.Forms.Label lblDatum;
        private DevExpress.XtraEditors.LookUpEdit txtTest_item1;
        private System.Windows.Forms.Label lblBrand_category;
        private DevExpress.XtraEditors.LookUpEdit txtID1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn edesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn test_item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn test_item_cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn test_item_edesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_cdesc;
    }
}