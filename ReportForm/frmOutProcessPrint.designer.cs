namespace cf01.ReportForm
{
    partial class frmOutProcessPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutProcessPrint));
            this.lblCrtim = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtID2 = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID1 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVendor_id2 = new DevExpress.XtraEditors.LookUpEdit();
            this.txtVendor_id1 = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDat1 = new DevExpress.XtraEditors.DateEdit();
            this.txtDat2 = new DevExpress.XtraEditors.DateEdit();
            this.txtDepFrom = new DevExpress.XtraEditors.TextEdit();
            this.txtMoFrom = new DevExpress.XtraEditors.TextEdit();
            this.lblDepId = new System.Windows.Forms.Label();
            this.lblMoId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDepTo = new DevExpress.XtraEditors.TextEdit();
            this.txtMoTo = new DevExpress.XtraEditors.TextEdit();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.colSelectFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issue_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sequence_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoodsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sec_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID1.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendor_id2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendor_id1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCrtim
            // 
            this.lblCrtim.Location = new System.Drawing.Point(6, 26);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(80, 13);
            this.lblCrtim.TabIndex = 83;
            this.lblCrtim.Text = "開單日期:";
            this.lblCrtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 12);
            this.label6.TabIndex = 113;
            this.label6.Text = "--";
            // 
            // txtID2
            // 
            this.txtID2.EnterMoveNextControl = true;
            this.txtID2.Location = new System.Drawing.Point(288, 55);
            this.txtID2.Name = "txtID2";
            this.txtID2.Size = new System.Drawing.Size(171, 20);
            this.txtID2.TabIndex = 115;
            this.txtID2.Tag = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 12);
            this.label5.TabIndex = 117;
            this.label5.Text = "--";
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(8, 58);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(80, 13);
            this.lblID.TabIndex = 116;
            this.lblID.Text = "單據編號:";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID1
            // 
            this.txtID1.EnterMoveNextControl = true;
            this.txtID1.Location = new System.Drawing.Point(92, 55);
            this.txtID1.Name = "txtID1";
            this.txtID1.Size = new System.Drawing.Size(171, 20);
            this.txtID1.TabIndex = 114;
            this.txtID1.Tag = "1";
            this.txtID1.Leave += new System.EventHandler(this.txtID1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 12);
            this.label1.TabIndex = 121;
            this.label1.Text = "--";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 120;
            this.label2.Text = "供應商編號:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator3,
            this.btnPrint,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1104, 38);
            this.toolStrip1.TabIndex = 123;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = false;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 35);
            this.btnExit.Text = "退出(&X)";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 35);
            this.btnFind.Text = "查詢(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = false;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 35);
            this.btnPrint.Text = "列印工序卡(&P)";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.ColumnHeadersHeight = 28;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelectFlag,
            this.id,
            this.issue_date,
            this.vendor_id,
            this.vendor,
            this.sequence_id,
            this.colMoId,
            this.colGoodsId,
            this.goods_cname,
            this.colDoColor,
            this.colProdQty,
            this.sec_qty,
            this.colRequestReturnDate,
            this.colDepId});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 164);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1104, 399);
            this.dgvDetails.TabIndex = 125;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtVendor_id2);
            this.panel1.Controls.Add(this.txtVendor_id1);
            this.panel1.Controls.Add(this.txtDat1);
            this.panel1.Controls.Add(this.txtDat2);
            this.panel1.Controls.Add(this.lblCrtim);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtDepFrom);
            this.panel1.Controls.Add(this.txtMoFrom);
            this.panel1.Controls.Add(this.txtID1);
            this.panel1.Controls.Add(this.lblDepId);
            this.panel1.Controls.Add(this.lblMoId);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDepTo);
            this.panel1.Controls.Add(this.txtMoTo);
            this.panel1.Controls.Add(this.txtID2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 126);
            this.panel1.TabIndex = 133;
            // 
            // txtVendor_id2
            // 
            this.txtVendor_id2.EditValue = "";
            this.txtVendor_id2.Location = new System.Drawing.Point(288, 83);
            this.txtVendor_id2.Name = "txtVendor_id2";
            this.txtVendor_id2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtVendor_id2.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtVendor_id2.Properties.Appearance.Options.UseForeColor = true;
            this.txtVendor_id2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtVendor_id2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 80, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 150, "cdesc")});
            this.txtVendor_id2.Properties.DropDownRows = 15;
            this.txtVendor_id2.Properties.NullText = "";
            this.txtVendor_id2.Properties.PopupFormMinSize = new System.Drawing.Size(230, 0);
            this.txtVendor_id2.Properties.ShowHeader = false;
            this.txtVendor_id2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtVendor_id2.Size = new System.Drawing.Size(171, 20);
            this.txtVendor_id2.TabIndex = 135;
            this.txtVendor_id2.Click += new System.EventHandler(this.txtVendor_id2_Click);
            // 
            // txtVendor_id1
            // 
            this.txtVendor_id1.EditValue = "";
            this.txtVendor_id1.Location = new System.Drawing.Point(92, 83);
            this.txtVendor_id1.Name = "txtVendor_id1";
            this.txtVendor_id1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtVendor_id1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtVendor_id1.Properties.Appearance.Options.UseForeColor = true;
            this.txtVendor_id1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtVendor_id1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 80, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 150, "cdesc")});
            this.txtVendor_id1.Properties.DropDownRows = 15;
            this.txtVendor_id1.Properties.NullText = "";
            this.txtVendor_id1.Properties.PopupFormMinSize = new System.Drawing.Size(230, 0);
            this.txtVendor_id1.Properties.ShowHeader = false;
            this.txtVendor_id1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtVendor_id1.Size = new System.Drawing.Size(171, 20);
            this.txtVendor_id1.TabIndex = 134;
            this.txtVendor_id1.Click += new System.EventHandler(this.txtVendor_id1_Click);
            this.txtVendor_id1.Leave += new System.EventHandler(this.txtVendor_id1_Leave);
            // 
            // txtDat1
            // 
            this.txtDat1.EditValue = null;
            this.txtDat1.EnterMoveNextControl = true;
            this.txtDat1.Location = new System.Drawing.Point(92, 23);
            this.txtDat1.Name = "txtDat1";
            this.txtDat1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDat1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtDat1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDat1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDat1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDat1.Size = new System.Drawing.Size(171, 20);
            this.txtDat1.TabIndex = 132;
            this.txtDat1.Tag = "2";
            this.txtDat1.Leave += new System.EventHandler(this.txtDat1_Leave);
            // 
            // txtDat2
            // 
            this.txtDat2.EditValue = null;
            this.txtDat2.EnterMoveNextControl = true;
            this.txtDat2.Location = new System.Drawing.Point(288, 23);
            this.txtDat2.Name = "txtDat2";
            this.txtDat2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDat2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtDat2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDat2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDat2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDat2.Size = new System.Drawing.Size(171, 20);
            this.txtDat2.TabIndex = 133;
            this.txtDat2.Tag = "2";
            // 
            // txtDepFrom
            // 
            this.txtDepFrom.EnterMoveNextControl = true;
            this.txtDepFrom.Location = new System.Drawing.Point(555, 51);
            this.txtDepFrom.Name = "txtDepFrom";
            this.txtDepFrom.Size = new System.Drawing.Size(171, 20);
            this.txtDepFrom.TabIndex = 114;
            this.txtDepFrom.Tag = "1";
            this.txtDepFrom.Leave += new System.EventHandler(this.txtDepFrom_Leave);
            // 
            // txtMoFrom
            // 
            this.txtMoFrom.EnterMoveNextControl = true;
            this.txtMoFrom.Location = new System.Drawing.Point(555, 23);
            this.txtMoFrom.Name = "txtMoFrom";
            this.txtMoFrom.Size = new System.Drawing.Size(171, 20);
            this.txtMoFrom.TabIndex = 114;
            this.txtMoFrom.Tag = "1";
            this.txtMoFrom.Leave += new System.EventHandler(this.txtMoFrom_Leave);
            // 
            // lblDepId
            // 
            this.lblDepId.Location = new System.Drawing.Point(471, 54);
            this.lblDepId.Name = "lblDepId";
            this.lblDepId.Size = new System.Drawing.Size(80, 13);
            this.lblDepId.TabIndex = 116;
            this.lblDepId.Text = "部門編號:";
            this.lblDepId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMoId
            // 
            this.lblMoId.Location = new System.Drawing.Point(471, 26);
            this.lblMoId.Name = "lblMoId";
            this.lblMoId.Size = new System.Drawing.Size(80, 13);
            this.lblMoId.TabIndex = 116;
            this.lblMoId.Text = "制單編號:";
            this.lblMoId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(732, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 117;
            this.label4.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(732, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 117;
            this.label3.Text = "--";
            // 
            // txtDepTo
            // 
            this.txtDepTo.EnterMoveNextControl = true;
            this.txtDepTo.Location = new System.Drawing.Point(751, 51);
            this.txtDepTo.Name = "txtDepTo";
            this.txtDepTo.Size = new System.Drawing.Size(171, 20);
            this.txtDepTo.TabIndex = 115;
            this.txtDepTo.Tag = "1";
            // 
            // txtMoTo
            // 
            this.txtMoTo.EnterMoveNextControl = true;
            this.txtMoTo.Location = new System.Drawing.Point(751, 23);
            this.txtMoTo.Name = "txtMoTo";
            this.txtMoTo.Size = new System.Drawing.Size(171, 20);
            this.txtMoTo.TabIndex = 115;
            this.txtMoTo.Tag = "1";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Location = new System.Drawing.Point(41, 171);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(18, 17);
            this.chkSelectAll.TabIndex = 136;
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Click += new System.EventHandler(this.chkSelectAll_Click);
            // 
            // colSelectFlag
            // 
            this.colSelectFlag.DataPropertyName = "SelectFlag";
            this.colSelectFlag.Frozen = true;
            this.colSelectFlag.HeaderText = "";
            this.colSelectFlag.Name = "colSelectFlag";
            this.colSelectFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelectFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelectFlag.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "單據編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "issue_date";
            this.dataGridViewTextBoxColumn2.HeaderText = "開單日期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "vendor_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "供應商編號";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "vendor_name";
            this.dataGridViewTextBoxColumn4.HeaderText = "供應商名稱";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn5.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn6.HeaderText = "貨品編號";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "goods_name";
            this.dataGridViewTextBoxColumn7.HeaderText = "貨品名稱";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "check_flag";
            this.dataGridViewTextBoxColumn8.HeaderText = "點貨狀態";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "check_flag_name";
            this.dataGridViewTextBoxColumn9.HeaderText = "狀態名稱";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "check_flag_name";
            this.dataGridViewTextBoxColumn10.HeaderText = "狀態名稱";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 90;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "pictrue_name";
            this.dataGridViewTextBoxColumn11.HeaderText = "pictrue_name";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "check_flag_name";
            this.dataGridViewTextBoxColumn12.HeaderText = "狀態名稱";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 90;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "picture_name";
            this.dataGridViewTextBoxColumn13.HeaderText = "pictrue_name";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "單據編號";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // issue_date
            // 
            this.issue_date.DataPropertyName = "issue_date";
            this.issue_date.HeaderText = "開單日期";
            this.issue_date.Name = "issue_date";
            this.issue_date.ReadOnly = true;
            this.issue_date.Width = 80;
            // 
            // vendor_id
            // 
            this.vendor_id.DataPropertyName = "vendor_id";
            this.vendor_id.HeaderText = "供應商編號";
            this.vendor_id.Name = "vendor_id";
            this.vendor_id.ReadOnly = true;
            this.vendor_id.Width = 80;
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "供應商名稱";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            this.vendor.Width = 160;
            // 
            // sequence_id
            // 
            this.sequence_id.DataPropertyName = "sequence_id";
            this.sequence_id.HeaderText = "序號";
            this.sequence_id.Name = "sequence_id";
            this.sequence_id.ReadOnly = true;
            this.sequence_id.Width = 40;
            // 
            // colMoId
            // 
            this.colMoId.DataPropertyName = "mo_id";
            this.colMoId.HeaderText = "制單編號";
            this.colMoId.Name = "colMoId";
            this.colMoId.ReadOnly = true;
            this.colMoId.Width = 85;
            // 
            // colGoodsId
            // 
            this.colGoodsId.DataPropertyName = "goods_id";
            this.colGoodsId.HeaderText = "物料編號";
            this.colGoodsId.Name = "colGoodsId";
            this.colGoodsId.ReadOnly = true;
            this.colGoodsId.Width = 140;
            // 
            // goods_cname
            // 
            this.goods_cname.DataPropertyName = "goods_cname";
            this.goods_cname.HeaderText = "物料描述";
            this.goods_cname.Name = "goods_cname";
            this.goods_cname.ReadOnly = true;
            this.goods_cname.Width = 150;
            // 
            // colDoColor
            // 
            this.colDoColor.DataPropertyName = "do_color";
            this.colDoColor.HeaderText = "顏色做法";
            this.colDoColor.Name = "colDoColor";
            this.colDoColor.ReadOnly = true;
            // 
            // colProdQty
            // 
            this.colProdQty.DataPropertyName = "prod_qty";
            this.colProdQty.HeaderText = "發貨數量";
            this.colProdQty.Name = "colProdQty";
            this.colProdQty.ReadOnly = true;
            this.colProdQty.Width = 70;
            // 
            // sec_qty
            // 
            this.sec_qty.DataPropertyName = "sec_qty";
            this.sec_qty.HeaderText = "發貨重量";
            this.sec_qty.Name = "sec_qty";
            this.sec_qty.ReadOnly = true;
            this.sec_qty.Width = 60;
            // 
            // colRequestReturnDate
            // 
            this.colRequestReturnDate.DataPropertyName = "RequestReturnDate";
            this.colRequestReturnDate.HeaderText = "要求交回日期";
            this.colRequestReturnDate.Name = "colRequestReturnDate";
            this.colRequestReturnDate.ReadOnly = true;
            // 
            // colDepId
            // 
            this.colDepId.DataPropertyName = "department_id";
            this.colDepId.HeaderText = "發貨部門";
            this.colDepId.Name = "colDepId";
            this.colDepId.ReadOnly = true;
            this.colDepId.Width = 80;
            // 
            // frmOutProcessPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 563);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmOutProcessPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOutProcessPrint";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOut_Process_FormClosed);
            this.Load += new System.EventHandler(this.frmOut_Process_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID1.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendor_id2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendor_id1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCrtim;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtID2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblID;
        private DevExpress.XtraEditors.TextEdit txtID1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraEditors.TextEdit txtDepFrom;
        private DevExpress.XtraEditors.TextEdit txtMoFrom;
        private System.Windows.Forms.Label lblDepId;
        private System.Windows.Forms.Label lblMoId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtDepTo;
        private DevExpress.XtraEditors.TextEdit txtMoTo;
        private DevExpress.XtraEditors.DateEdit txtDat1;
        private DevExpress.XtraEditors.DateEdit txtDat2;
        private DevExpress.XtraEditors.LookUpEdit txtVendor_id2;
        private DevExpress.XtraEditors.LookUpEdit txtVendor_id1;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelectFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn issue_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequence_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoodsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn sec_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestReturnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepId;
    }
}