namespace cf01.Forms
{
    partial class frmSaleReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleReturn));
            this.grpBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVESET = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIssues_date2 = new DevExpress.XtraEditors.DateEdit();
            this.txtIssues_date1 = new DevExpress.XtraEditors.DateEdit();
            this.lblCrtim = new System.Windows.Forms.Label();
            this.txtIt_customer = new DevExpress.XtraEditors.TextEdit();
            this.lblCustomer_goods = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID2 = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID1 = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.goods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.goods_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ii_location = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sample_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.issues_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sec_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSec_qty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.lot_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remain_flag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkRemainFlag = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.remain_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.obligate_mo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.order_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.so_sequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.grpBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssues_date2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssues_date2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssues_date1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssues_date1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIt_customer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSec_qty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemainFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colRemainQty)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBox1
            // 
            this.grpBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBox1.Controls.Add(this.button1);
            this.grpBox1.Controls.Add(this.txtID2);
            this.grpBox1.Controls.Add(this.label5);
            this.grpBox1.Controls.Add(this.lblID);
            this.grpBox1.Controls.Add(this.txtID1);
            this.grpBox1.Controls.Add(this.textEdit1);
            this.grpBox1.Controls.Add(this.label1);
            this.grpBox1.Controls.Add(this.txtIt_customer);
            this.grpBox1.Controls.Add(this.lblCustomer_goods);
            this.grpBox1.Controls.Add(this.label6);
            this.grpBox1.Controls.Add(this.txtIssues_date2);
            this.grpBox1.Controls.Add(this.txtIssues_date1);
            this.grpBox1.Controls.Add(this.lblCrtim);
            this.grpBox1.Location = new System.Drawing.Point(8, 52);
            this.grpBox1.Name = "grpBox1";
            this.grpBox1.Size = new System.Drawing.Size(906, 101);
            this.grpBox1.TabIndex = 0;
            this.grpBox1.TabStop = false;
            this.grpBox1.Text = "查找條件(Credit)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNSAVESET,
            this.toolStripSeparator8,
            this.BTNFIND,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(920, 43);
            this.toolStrip1.TabIndex = 26;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.AutoSize = false;
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(60, 40);
            this.BTNEXIT.Text = " 退  出(&X)";
            this.BTNEXIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // BTNSAVESET
            // 
            this.BTNSAVESET.Image = global::cf01.Properties.Resources.w_set;
            this.BTNSAVESET.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVESET.Name = "BTNSAVESET";
            this.BTNSAVESET.Size = new System.Drawing.Size(83, 40);
            this.BTNSAVESET.Text = "保存查找條件";
            this.BTNSAVESET.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNSAVESET.Click += new System.EventHandler(this.BTNSAVESET_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 43);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(58, 40);
            this.BTNFIND.Text = " 查  詢(&F)";
            this.BTNFIND.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(315, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 12);
            this.label6.TabIndex = 116;
            this.label6.Text = "~";
            // 
            // txtIssues_date2
            // 
            this.txtIssues_date2.EditValue = null;
            this.txtIssues_date2.EnterMoveNextControl = true;
            this.txtIssues_date2.Location = new System.Drawing.Point(345, 42);
            this.txtIssues_date2.Name = "txtIssues_date2";
            this.txtIssues_date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtIssues_date2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtIssues_date2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtIssues_date2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtIssues_date2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtIssues_date2.Size = new System.Drawing.Size(120, 20);
            this.txtIssues_date2.TabIndex = 3;
            this.txtIssues_date2.Tag = "2";
            // 
            // txtIssues_date1
            // 
            this.txtIssues_date1.EditValue = null;
            this.txtIssues_date1.EnterMoveNextControl = true;
            this.txtIssues_date1.Location = new System.Drawing.Point(181, 42);
            this.txtIssues_date1.Name = "txtIssues_date1";
            this.txtIssues_date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtIssues_date1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtIssues_date1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtIssues_date1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtIssues_date1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtIssues_date1.Size = new System.Drawing.Size(119, 20);
            this.txtIssues_date1.TabIndex = 2;
            this.txtIssues_date1.Tag = "2";
            // 
            // lblCrtim
            // 
            this.lblCrtim.Location = new System.Drawing.Point(73, 45);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(102, 13);
            this.lblCrtim.TabIndex = 115;
            this.lblCrtim.Text = "出貨日期";
            this.lblCrtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIt_customer
            // 
            this.txtIt_customer.EnterMoveNextControl = true;
            this.txtIt_customer.Location = new System.Drawing.Point(181, 69);
            this.txtIt_customer.Name = "txtIt_customer";
            this.txtIt_customer.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIt_customer.Properties.MaxLength = 8;
            this.txtIt_customer.Size = new System.Drawing.Size(119, 20);
            this.txtIt_customer.TabIndex = 4;
            this.txtIt_customer.Tag = "2";
            // 
            // lblCustomer_goods
            // 
            this.lblCustomer_goods.Location = new System.Drawing.Point(88, 73);
            this.lblCustomer_goods.Name = "lblCustomer_goods";
            this.lblCustomer_goods.Size = new System.Drawing.Size(87, 13);
            this.lblCustomer_goods.TabIndex = 118;
            this.lblCustomer_goods.Text = "客戶編號";
            this.lblCustomer_goods.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textEdit1
            // 
            this.textEdit1.EnterMoveNextControl = true;
            this.textEdit1.Location = new System.Drawing.Point(345, 69);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textEdit1.Properties.MaxLength = 1;
            this.textEdit1.Size = new System.Drawing.Size(120, 20);
            this.textEdit1.TabIndex = 5;
            this.textEdit1.Tag = "2";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(303, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "組別";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID2
            // 
            this.txtID2.EnterMoveNextControl = true;
            this.txtID2.Location = new System.Drawing.Point(345, 16);
            this.txtID2.Name = "txtID2";
            this.txtID2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID2.Properties.MaxLength = 10;
            this.txtID2.Size = new System.Drawing.Size(120, 20);
            this.txtID2.TabIndex = 1;
            this.txtID2.Tag = "1";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(315, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 12);
            this.label5.TabIndex = 124;
            this.label5.Text = "~";
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(80, 19);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(97, 13);
            this.lblID.TabIndex = 123;
            this.lblID.Text = "編號(Credit ID)";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID1
            // 
            this.txtID1.EnterMoveNextControl = true;
            this.txtID1.Location = new System.Drawing.Point(181, 16);
            this.txtID1.Name = "txtID1";
            this.txtID1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID1.Properties.MaxLength = 10;
            this.txtID1.Size = new System.Drawing.Size(119, 20);
            this.txtID1.TabIndex = 0;
            this.txtID1.Tag = "1";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(7, 157);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkRemainFlag,
            this.colQty,
            this.colSec_qty,
            this.colRemainQty});
            this.gridControl1.Size = new System.Drawing.Size(908, 454);
            this.gridControl1.TabIndex = 27;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 40;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sequence_id,
            this.mo_id,
            this.goods_id,
            this.goods_name,
            this.ii_location,
            this.sample_qty,
            this.issues_qty,
            this.sec_qty,
            this.lot_no,
            this.remain_flag,
            this.remain_qty,
            this.obligate_mo_id,
            this.id,
            this.state,
            this.order_id,
            this.so_sequence_id});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "Style3D";
            this.gridView1.RowHeight = 22;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // sequence_id
            // 
            this.sequence_id.Caption = "序號";
            this.sequence_id.FieldName = "sequence_id";
            this.sequence_id.Name = "sequence_id";
            this.sequence_id.OptionsColumn.AllowEdit = false;
            this.sequence_id.OptionsColumn.ReadOnly = true;
            this.sequence_id.OptionsFilter.AllowAutoFilter = false;
            this.sequence_id.OptionsFilter.AllowFilter = false;
            this.sequence_id.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            // 
            // mo_id
            // 
            this.mo_id.Caption = "頁數";
            this.mo_id.FieldName = "mo_id";
            this.mo_id.Name = "mo_id";
            this.mo_id.OptionsColumn.AllowEdit = false;
            this.mo_id.OptionsColumn.AllowIncrementalSearch = false;
            this.mo_id.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.mo_id.OptionsColumn.AllowMove = false;
            this.mo_id.OptionsColumn.AllowShowHide = false;
            this.mo_id.OptionsColumn.AllowSize = false;
            this.mo_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.mo_id.OptionsColumn.ReadOnly = true;
            this.mo_id.OptionsFilter.AllowAutoFilter = false;
            this.mo_id.OptionsFilter.AllowFilter = false;
            this.mo_id.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.mo_id.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.mo_id.Visible = true;
            this.mo_id.VisibleIndex = 0;
            this.mo_id.Width = 95;
            // 
            // goods_id
            // 
            this.goods_id.Caption = "貨品編碼";
            this.goods_id.FieldName = "goods_id";
            this.goods_id.Name = "goods_id";
            this.goods_id.OptionsColumn.AllowEdit = false;
            this.goods_id.OptionsColumn.AllowIncrementalSearch = false;
            this.goods_id.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.goods_id.OptionsColumn.AllowMove = false;
            this.goods_id.OptionsColumn.AllowShowHide = false;
            this.goods_id.OptionsColumn.AllowSize = false;
            this.goods_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.goods_id.OptionsColumn.ReadOnly = true;
            this.goods_id.OptionsFilter.AllowAutoFilter = false;
            this.goods_id.OptionsFilter.AllowFilter = false;
            this.goods_id.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.goods_id.Visible = true;
            this.goods_id.VisibleIndex = 1;
            this.goods_id.Width = 170;
            // 
            // goods_name
            // 
            this.goods_name.Caption = "貨品描述";
            this.goods_name.FieldName = "goods_name";
            this.goods_name.Name = "goods_name";
            this.goods_name.OptionsColumn.AllowEdit = false;
            this.goods_name.OptionsColumn.AllowIncrementalSearch = false;
            this.goods_name.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.goods_name.OptionsColumn.AllowMove = false;
            this.goods_name.OptionsColumn.AllowShowHide = false;
            this.goods_name.OptionsColumn.AllowSize = false;
            this.goods_name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.goods_name.OptionsColumn.ReadOnly = true;
            this.goods_name.OptionsFilter.AllowAutoFilter = false;
            this.goods_name.OptionsFilter.AllowFilter = false;
            this.goods_name.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.goods_name.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.goods_name.Visible = true;
            this.goods_name.VisibleIndex = 2;
            this.goods_name.Width = 254;
            // 
            // ii_location
            // 
            this.ii_location.Caption = "出貨倉庫";
            this.ii_location.FieldName = "ii_location";
            this.ii_location.Name = "ii_location";
            this.ii_location.OptionsColumn.AllowEdit = false;
            this.ii_location.OptionsColumn.AllowIncrementalSearch = false;
            this.ii_location.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ii_location.OptionsColumn.AllowMove = false;
            this.ii_location.OptionsColumn.AllowShowHide = false;
            this.ii_location.OptionsColumn.AllowSize = false;
            this.ii_location.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ii_location.OptionsColumn.ReadOnly = true;
            this.ii_location.OptionsFilter.AllowAutoFilter = false;
            this.ii_location.OptionsFilter.AllowFilter = false;
            this.ii_location.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.ii_location.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.ii_location.Visible = true;
            this.ii_location.VisibleIndex = 3;
            this.ii_location.Width = 70;
            // 
            // sample_qty
            // 
            this.sample_qty.Caption = "提倉數量";
            this.sample_qty.ColumnEdit = this.colQty;
            this.sample_qty.FieldName = "sample_qty";
            this.sample_qty.Name = "sample_qty";
            this.sample_qty.OptionsColumn.AllowEdit = false;
            this.sample_qty.OptionsColumn.AllowIncrementalSearch = false;
            this.sample_qty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.sample_qty.OptionsColumn.AllowMove = false;
            this.sample_qty.OptionsColumn.AllowShowHide = false;
            this.sample_qty.OptionsColumn.AllowSize = false;
            this.sample_qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.sample_qty.OptionsColumn.ReadOnly = true;
            this.sample_qty.OptionsFilter.AllowAutoFilter = false;
            this.sample_qty.OptionsFilter.AllowFilter = false;
            this.sample_qty.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.sample_qty.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.sample_qty.Visible = true;
            this.sample_qty.VisibleIndex = 4;
            this.sample_qty.Width = 70;
            // 
            // colQty
            // 
            this.colQty.AutoHeight = false;
            this.colQty.DisplayFormat.FormatString = "n0";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.EditFormat.FormatString = "n0";
            this.colQty.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.Mask.EditMask = "n0";
            this.colQty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.colQty.Name = "colQty";
            // 
            // issues_qty
            // 
            this.issues_qty.Caption = "實際扣倉數量";
            this.issues_qty.ColumnEdit = this.colQty;
            this.issues_qty.FieldName = "issues_qty";
            this.issues_qty.Name = "issues_qty";
            this.issues_qty.OptionsColumn.AllowEdit = false;
            this.issues_qty.OptionsColumn.AllowIncrementalSearch = false;
            this.issues_qty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.issues_qty.OptionsColumn.AllowMove = false;
            this.issues_qty.OptionsColumn.AllowShowHide = false;
            this.issues_qty.OptionsColumn.AllowSize = false;
            this.issues_qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.issues_qty.OptionsColumn.ReadOnly = true;
            this.issues_qty.OptionsFilter.AllowAutoFilter = false;
            this.issues_qty.OptionsFilter.AllowFilter = false;
            this.issues_qty.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.issues_qty.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.issues_qty.Visible = true;
            this.issues_qty.VisibleIndex = 5;
            this.issues_qty.Width = 93;
            // 
            // sec_qty
            // 
            this.sec_qty.Caption = "實際扣倉重量";
            this.sec_qty.ColumnEdit = this.colSec_qty;
            this.sec_qty.FieldName = "sec_qty";
            this.sec_qty.Name = "sec_qty";
            this.sec_qty.OptionsColumn.AllowEdit = false;
            this.sec_qty.OptionsColumn.AllowIncrementalSearch = false;
            this.sec_qty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.sec_qty.OptionsColumn.AllowMove = false;
            this.sec_qty.OptionsColumn.AllowShowHide = false;
            this.sec_qty.OptionsColumn.AllowSize = false;
            this.sec_qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.sec_qty.OptionsColumn.ReadOnly = true;
            this.sec_qty.OptionsFilter.AllowAutoFilter = false;
            this.sec_qty.OptionsFilter.AllowFilter = false;
            this.sec_qty.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.sec_qty.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.sec_qty.Visible = true;
            this.sec_qty.VisibleIndex = 6;
            this.sec_qty.Width = 90;
            // 
            // colSec_qty
            // 
            this.colSec_qty.AutoHeight = false;
            this.colSec_qty.DisplayFormat.FormatString = "n2";
            this.colSec_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSec_qty.EditFormat.FormatString = "n2";
            this.colSec_qty.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSec_qty.Mask.EditMask = "n2";
            this.colSec_qty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.colSec_qty.Name = "colSec_qty";
            // 
            // lot_no
            // 
            this.lot_no.Caption = "批號";
            this.lot_no.FieldName = "lot_no";
            this.lot_no.Name = "lot_no";
            this.lot_no.OptionsColumn.AllowEdit = false;
            this.lot_no.OptionsColumn.AllowIncrementalSearch = false;
            this.lot_no.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.lot_no.OptionsColumn.AllowMove = false;
            this.lot_no.OptionsColumn.AllowShowHide = false;
            this.lot_no.OptionsColumn.AllowSize = false;
            this.lot_no.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.lot_no.OptionsColumn.ReadOnly = true;
            this.lot_no.OptionsFilter.AllowAutoFilter = false;
            this.lot_no.OptionsFilter.AllowFilter = false;
            this.lot_no.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.lot_no.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.lot_no.Visible = true;
            this.lot_no.VisibleIndex = 7;
            this.lot_no.Width = 90;
            // 
            // remain_flag
            // 
            this.remain_flag.Caption = "仍有實物存貨標記";
            this.remain_flag.ColumnEdit = this.chkRemainFlag;
            this.remain_flag.FieldName = "remain_flag";
            this.remain_flag.Name = "remain_flag";
            this.remain_flag.OptionsColumn.AllowIncrementalSearch = false;
            this.remain_flag.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.remain_flag.OptionsColumn.AllowMove = false;
            this.remain_flag.OptionsColumn.AllowShowHide = false;
            this.remain_flag.OptionsColumn.AllowSize = false;
            this.remain_flag.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.remain_flag.OptionsFilter.AllowAutoFilter = false;
            this.remain_flag.OptionsFilter.AllowFilter = false;
            this.remain_flag.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.remain_flag.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.remain_flag.Visible = true;
            this.remain_flag.VisibleIndex = 8;
            this.remain_flag.Width = 120;
            // 
            // chkRemainFlag
            // 
            this.chkRemainFlag.AutoHeight = false;
            this.chkRemainFlag.Name = "chkRemainFlag";
            // 
            // remain_qty
            // 
            this.remain_qty.Caption = "仍有實物存貨數量";
            this.remain_qty.ColumnEdit = this.colRemainQty;
            this.remain_qty.FieldName = "remain_qty";
            this.remain_qty.Name = "remain_qty";
            this.remain_qty.OptionsColumn.AllowIncrementalSearch = false;
            this.remain_qty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.remain_qty.OptionsColumn.AllowMove = false;
            this.remain_qty.OptionsColumn.AllowShowHide = false;
            this.remain_qty.OptionsColumn.AllowSize = false;
            this.remain_qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.remain_qty.OptionsFilter.AllowAutoFilter = false;
            this.remain_qty.OptionsFilter.AllowFilter = false;
            this.remain_qty.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.remain_qty.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.remain_qty.Visible = true;
            this.remain_qty.VisibleIndex = 9;
            this.remain_qty.Width = 120;
            // 
            // colRemainQty
            // 
            this.colRemainQty.AutoHeight = false;
            this.colRemainQty.Mask.EditMask = "n0";
            this.colRemainQty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.colRemainQty.Name = "colRemainQty";
            // 
            // obligate_mo_id
            // 
            this.obligate_mo_id.Caption = "庫存頁數";
            this.obligate_mo_id.FieldName = "obligate_mo_id";
            this.obligate_mo_id.Name = "obligate_mo_id";
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // state
            // 
            this.state.Caption = "狀態";
            this.state.FieldName = "state";
            this.state.Name = "state";
            // 
            // order_id
            // 
            this.order_id.Caption = "OC NO";
            this.order_id.FieldName = "order_id";
            this.order_id.Name = "order_id";
            // 
            // so_sequence_id
            // 
            this.so_sequence_id.Caption = "OC SEQ";
            this.so_sequence_id.FieldName = "so_sequence_id";
            this.so_sequence_id.Name = "so_sequence_id";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(527, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 36);
            this.button1.TabIndex = 125;
            this.button1.Text = "生成銷貨退回單 ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmSaleReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 618);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grpBox1);
            this.Name = "frmSaleReturn";
            this.Text = "frmSaleReturn";
            this.Load += new System.EventHandler(this.frmSaleReturn_Load);
            this.grpBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssues_date2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssues_date2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssues_date1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssues_date1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIt_customer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSec_qty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemainFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colRemainQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNSAVESET;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.DateEdit txtIssues_date2;
        private DevExpress.XtraEditors.DateEdit txtIssues_date1;
        private System.Windows.Forms.Label lblCrtim;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtIt_customer;
        private System.Windows.Forms.Label lblCustomer_goods;
        private DevExpress.XtraEditors.TextEdit txtID2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblID;
        private DevExpress.XtraEditors.TextEdit txtID1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn sequence_id;
        private DevExpress.XtraGrid.Columns.GridColumn mo_id;
        private DevExpress.XtraGrid.Columns.GridColumn goods_id;
        private DevExpress.XtraGrid.Columns.GridColumn goods_name;
        private DevExpress.XtraGrid.Columns.GridColumn ii_location;
        private DevExpress.XtraGrid.Columns.GridColumn sample_qty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit colQty;
        private DevExpress.XtraGrid.Columns.GridColumn issues_qty;
        private DevExpress.XtraGrid.Columns.GridColumn sec_qty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit colSec_qty;
        private DevExpress.XtraGrid.Columns.GridColumn lot_no;
        private DevExpress.XtraGrid.Columns.GridColumn remain_flag;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkRemainFlag;
        private DevExpress.XtraGrid.Columns.GridColumn remain_qty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit colRemainQty;
        private DevExpress.XtraGrid.Columns.GridColumn obligate_mo_id;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraGrid.Columns.GridColumn order_id;
        private DevExpress.XtraGrid.Columns.GridColumn so_sequence_id;
        private System.Windows.Forms.Button button1;
    }
}