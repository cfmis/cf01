namespace cf01.ReportForm
{
    partial class frmOrderPacking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderPacking));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNPRINT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVESET = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMo_id2 = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMo_id1 = new DevExpress.XtraEditors.TextEdit();
            this.lblOut_dept = new System.Windows.Forms.Label();
            this.txtLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGoods_id2 = new DevExpress.XtraEditors.TextEdit();
            this.lblID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtCheck_date2 = new DevExpress.XtraEditors.DateEdit();
            this.txtCheck_date1 = new DevExpress.XtraEditors.DateEdit();
            this.txtGoods_id1 = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.flag_select = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clFlag_select = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.location = new DevExpress.XtraGrid.Columns.GridColumn();
            this.carton_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dept_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.materiel_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fl_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.issues_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sec_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.already_sec_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSec_qty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.plate_effect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.outer_layer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.color_effect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkSelect = new DevExpress.XtraEditors.CheckEdit();
            this.chkDelivery = new DevExpress.XtraEditors.CheckEdit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_id2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_id1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clFlag_select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSec_qty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDelivery.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNFIND,
            this.toolStripSeparator9,
            this.BTNPRINT,
            this.toolStripSeparator2,
            this.BTNSAVESET,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1175, 38);
            this.toolStrip1.TabIndex = 125;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.AutoSize = false;
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(65, 35);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNFIND
            // 
            this.BTNFIND.AutoSize = false;
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(65, 35);
            this.BTNFIND.Text = "查找(&F)";
            this.BTNFIND.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNPRINT
            // 
            this.BTNPRINT.Image = ((System.Drawing.Image)(resources.GetObject("BTNPRINT.Image")));
            this.BTNPRINT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNPRINT.Name = "BTNPRINT";
            this.BTNPRINT.Size = new System.Drawing.Size(107, 35);
            this.BTNPRINT.Text = "列印成品執貨單(&P)";
            this.BTNPRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNPRINT.Click += new System.EventHandler(this.BTNPRINT_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNSAVESET
            // 
            this.BTNSAVESET.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVESET.Image")));
            this.BTNSAVESET.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVESET.Name = "BTNSAVESET";
            this.BTNSAVESET.Size = new System.Drawing.Size(81, 35);
            this.BTNSAVESET.Text = "保存查找條件";
            this.BTNSAVESET.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNSAVESET.ToolTipText = "保存查找條件";
            this.BTNSAVESET.Click += new System.EventHandler(this.BTNSAVESET_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 161;
            this.label2.Text = "--";
            // 
            // txtMo_id2
            // 
            this.txtMo_id2.EnterMoveNextControl = true;
            this.txtMo_id2.Location = new System.Drawing.Point(388, 104);
            this.txtMo_id2.Name = "txtMo_id2";
            this.txtMo_id2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id2.Properties.MaxLength = 9;
            this.txtMo_id2.Size = new System.Drawing.Size(177, 20);
            this.txtMo_id2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(75, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 160;
            this.label5.Text = "頁  數";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMo_id1
            // 
            this.txtMo_id1.EnterMoveNextControl = true;
            this.txtMo_id1.Location = new System.Drawing.Point(161, 104);
            this.txtMo_id1.Name = "txtMo_id1";
            this.txtMo_id1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id1.Properties.MaxLength = 9;
            this.txtMo_id1.Size = new System.Drawing.Size(177, 20);
            this.txtMo_id1.TabIndex = 3;
            this.txtMo_id1.Leave += new System.EventHandler(this.txtMo_id1_Leave);
            // 
            // lblOut_dept
            // 
            this.lblOut_dept.Location = new System.Drawing.Point(75, 57);
            this.lblOut_dept.Name = "lblOut_dept";
            this.lblOut_dept.Size = new System.Drawing.Size(80, 13);
            this.lblOut_dept.TabIndex = 159;
            this.lblOut_dept.Text = "倉庫";
            this.lblOut_dept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocation
            // 
            this.txtLocation.EnterMoveNextControl = true;
            this.txtLocation.Location = new System.Drawing.Point(161, 52);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtLocation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 60, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 170, "cdesc")});
            this.txtLocation.Properties.DropDownRows = 15;
            this.txtLocation.Properties.NullText = "";
            this.txtLocation.Properties.PopupFormMinSize = new System.Drawing.Size(230, 0);
            this.txtLocation.Properties.ShowHeader = false;
            this.txtLocation.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtLocation.Size = new System.Drawing.Size(177, 20);
            this.txtLocation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 12);
            this.label1.TabIndex = 158;
            this.label1.Text = "--";
            // 
            // txtGoods_id2
            // 
            this.txtGoods_id2.EnterMoveNextControl = true;
            this.txtGoods_id2.Location = new System.Drawing.Point(388, 130);
            this.txtGoods_id2.Name = "txtGoods_id2";
            this.txtGoods_id2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGoods_id2.Properties.MaxLength = 15;
            this.txtGoods_id2.Size = new System.Drawing.Size(177, 20);
            this.txtGoods_id2.TabIndex = 6;
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(75, 133);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(80, 13);
            this.lblID.TabIndex = 157;
            this.lblID.Text = "貨品編碼";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 12);
            this.label6.TabIndex = 156;
            this.label6.Text = "--";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(75, 82);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 13);
            this.lblDate.TabIndex = 155;
            this.lblDate.Text = "批準日期";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCheck_date2
            // 
            this.txtCheck_date2.EditValue = null;
            this.txtCheck_date2.EnterMoveNextControl = true;
            this.txtCheck_date2.Location = new System.Drawing.Point(388, 78);
            this.txtCheck_date2.Name = "txtCheck_date2";
            this.txtCheck_date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCheck_date2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCheck_date2.Properties.Mask.EditMask = "G";
            this.txtCheck_date2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCheck_date2.Properties.MaxLength = 30;
            this.txtCheck_date2.Size = new System.Drawing.Size(177, 20);
            this.txtCheck_date2.TabIndex = 2;
            this.txtCheck_date2.Tag = "2";
            // 
            // txtCheck_date1
            // 
            this.txtCheck_date1.EditValue = null;
            this.txtCheck_date1.EnterMoveNextControl = true;
            this.txtCheck_date1.Location = new System.Drawing.Point(161, 78);
            this.txtCheck_date1.Name = "txtCheck_date1";
            this.txtCheck_date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCheck_date1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCheck_date1.Properties.Mask.EditMask = "G";
            this.txtCheck_date1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCheck_date1.Properties.MaxLength = 30;
            this.txtCheck_date1.Size = new System.Drawing.Size(177, 20);
            this.txtCheck_date1.TabIndex = 1;
            this.txtCheck_date1.Tag = "2";
            this.txtCheck_date1.Leave += new System.EventHandler(this.txtCheck_date1_Leave);
            // 
            // txtGoods_id1
            // 
            this.txtGoods_id1.EnterMoveNextControl = true;
            this.txtGoods_id1.Location = new System.Drawing.Point(161, 130);
            this.txtGoods_id1.Name = "txtGoods_id1";
            this.txtGoods_id1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGoods_id1.Properties.MaxLength = 15;
            this.txtGoods_id1.Size = new System.Drawing.Size(177, 20);
            this.txtGoods_id1.TabIndex = 5;
            this.txtGoods_id1.Leave += new System.EventHandler(this.txtGoods_id1_Leave);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(6, 197);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.clFlag_select,
            this.colQty,
            this.colSec_qty});
            this.gridControl1.Size = new System.Drawing.Size(1163, 379);
            this.gridControl1.TabIndex = 162;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.flag_select,
            this.location,
            this.carton_code,
            this.dept_id,
            this.mo_id,
            this.materiel_id,
            this.name,
            this.fl_qty,
            this.issues_qty,
            this.unit,
            this.sec_qty,
            this.already_sec_qty,
            this.color,
            this.plate_effect,
            this.outer_layer,
            this.color_effect});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "Style3D";
            this.gridView1.RowHeight = 22;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // flag_select
            // 
            this.flag_select.Caption = "全選";
            this.flag_select.ColumnEdit = this.clFlag_select;
            this.flag_select.FieldName = "flag_select";
            this.flag_select.Name = "flag_select";
            this.flag_select.OptionsColumn.AllowSize = false;
            this.flag_select.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.flag_select.OptionsFilter.AllowAutoFilter = false;
            this.flag_select.OptionsFilter.AllowFilter = false;
            this.flag_select.Visible = true;
            this.flag_select.VisibleIndex = 0;
            this.flag_select.Width = 38;
            // 
            // clFlag_select
            // 
            this.clFlag_select.AutoHeight = false;
            this.clFlag_select.Name = "clFlag_select";
            this.clFlag_select.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.clFlag_select.CheckedChanged += new System.EventHandler(this.clFlag_select_CheckedChanged);
            // 
            // location
            // 
            this.location.Caption = "倉庫";
            this.location.FieldName = "location";
            this.location.Name = "location";
            this.location.OptionsColumn.AllowSize = false;
            this.location.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.location.OptionsColumn.ReadOnly = true;
            this.location.OptionsFilter.AllowAutoFilter = false;
            this.location.OptionsFilter.AllowFilter = false;
            this.location.Visible = true;
            this.location.VisibleIndex = 1;
            this.location.Width = 77;
            // 
            // carton_code
            // 
            this.carton_code.Caption = "倉位";
            this.carton_code.FieldName = "carton_code";
            this.carton_code.Name = "carton_code";
            this.carton_code.OptionsColumn.AllowSize = false;
            this.carton_code.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.carton_code.OptionsColumn.ReadOnly = true;
            this.carton_code.OptionsFilter.AllowAutoFilter = false;
            this.carton_code.OptionsFilter.AllowFilter = false;
            this.carton_code.Visible = true;
            this.carton_code.VisibleIndex = 2;
            this.carton_code.Width = 52;
            // 
            // dept_id
            // 
            this.dept_id.Caption = "部門編號";
            this.dept_id.FieldName = "dept_id";
            this.dept_id.Name = "dept_id";
            this.dept_id.OptionsColumn.AllowSize = false;
            this.dept_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.dept_id.OptionsColumn.ReadOnly = true;
            this.dept_id.OptionsFilter.AllowAutoFilter = false;
            this.dept_id.OptionsFilter.AllowFilter = false;
            this.dept_id.Visible = true;
            this.dept_id.VisibleIndex = 3;
            this.dept_id.Width = 80;
            // 
            // mo_id
            // 
            this.mo_id.Caption = "頁數";
            this.mo_id.FieldName = "mo_id";
            this.mo_id.Name = "mo_id";
            this.mo_id.OptionsColumn.AllowSize = false;
            this.mo_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.mo_id.OptionsColumn.ReadOnly = true;
            this.mo_id.OptionsFilter.AllowAutoFilter = false;
            this.mo_id.OptionsFilter.AllowFilter = false;
            this.mo_id.Visible = true;
            this.mo_id.VisibleIndex = 4;
            this.mo_id.Width = 111;
            // 
            // materiel_id
            // 
            this.materiel_id.Caption = "物料編號";
            this.materiel_id.FieldName = "materiel_id";
            this.materiel_id.Name = "materiel_id";
            this.materiel_id.OptionsColumn.AllowSize = false;
            this.materiel_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.materiel_id.OptionsColumn.ReadOnly = true;
            this.materiel_id.OptionsFilter.AllowAutoFilter = false;
            this.materiel_id.OptionsFilter.AllowFilter = false;
            this.materiel_id.Visible = true;
            this.materiel_id.VisibleIndex = 5;
            this.materiel_id.Width = 193;
            // 
            // name
            // 
            this.name.Caption = "物料名稱";
            this.name.FieldName = "name";
            this.name.Name = "name";
            this.name.OptionsColumn.AllowSize = false;
            this.name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.name.OptionsColumn.ReadOnly = true;
            this.name.OptionsFilter.AllowAutoFilter = false;
            this.name.OptionsFilter.AllowFilter = false;
            this.name.Visible = true;
            this.name.VisibleIndex = 6;
            this.name.Width = 80;
            // 
            // fl_qty
            // 
            this.fl_qty.Caption = "安排領料數量";
            this.fl_qty.ColumnEdit = this.colQty;
            this.fl_qty.FieldName = "fl_qty";
            this.fl_qty.Name = "fl_qty";
            this.fl_qty.OptionsColumn.AllowSize = false;
            this.fl_qty.OptionsColumn.ReadOnly = true;
            this.fl_qty.OptionsFilter.AllowAutoFilter = false;
            this.fl_qty.OptionsFilter.AllowFilter = false;
            this.fl_qty.Visible = true;
            this.fl_qty.VisibleIndex = 7;
            this.fl_qty.Width = 80;
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
            this.issues_qty.Caption = "已發料數量";
            this.issues_qty.ColumnEdit = this.colQty;
            this.issues_qty.FieldName = "issues_qty";
            this.issues_qty.Name = "issues_qty";
            this.issues_qty.OptionsColumn.ReadOnly = true;
            this.issues_qty.OptionsFilter.AllowAutoFilter = false;
            this.issues_qty.OptionsFilter.AllowFilter = false;
            this.issues_qty.Visible = true;
            this.issues_qty.VisibleIndex = 8;
            this.issues_qty.Width = 89;
            // 
            // unit
            // 
            this.unit.Caption = "單位";
            this.unit.FieldName = "unit";
            this.unit.Name = "unit";
            this.unit.OptionsColumn.AllowSize = false;
            this.unit.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.unit.OptionsColumn.ReadOnly = true;
            this.unit.OptionsFilter.AllowAutoFilter = false;
            this.unit.OptionsFilter.AllowFilter = false;
            this.unit.Visible = true;
            this.unit.VisibleIndex = 9;
            this.unit.Width = 47;
            // 
            // sec_qty
            // 
            this.sec_qty.Caption = "重量";
            this.sec_qty.FieldName = "sec_qty";
            this.sec_qty.Name = "sec_qty";
            this.sec_qty.OptionsColumn.AllowSize = false;
            this.sec_qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.sec_qty.OptionsColumn.ReadOnly = true;
            this.sec_qty.OptionsFilter.AllowAutoFilter = false;
            this.sec_qty.OptionsFilter.AllowFilter = false;
            this.sec_qty.Tag = "2";
            this.sec_qty.Visible = true;
            this.sec_qty.VisibleIndex = 10;
            this.sec_qty.Width = 70;
            // 
            // already_sec_qty
            // 
            this.already_sec_qty.Caption = "已發料重量";
            this.already_sec_qty.ColumnEdit = this.colSec_qty;
            this.already_sec_qty.FieldName = "already_sec_qty";
            this.already_sec_qty.Name = "already_sec_qty";
            this.already_sec_qty.OptionsColumn.AllowSize = false;
            this.already_sec_qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.already_sec_qty.OptionsColumn.ReadOnly = true;
            this.already_sec_qty.OptionsFilter.AllowAutoFilter = false;
            this.already_sec_qty.OptionsFilter.AllowFilter = false;
            this.already_sec_qty.Visible = true;
            this.already_sec_qty.VisibleIndex = 11;
            this.already_sec_qty.Width = 69;
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
            // color
            // 
            this.color.Caption = "顏色";
            this.color.FieldName = "color";
            this.color.Name = "color";
            this.color.OptionsColumn.AllowSize = false;
            this.color.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.color.OptionsColumn.ReadOnly = true;
            this.color.OptionsFilter.AllowAutoFilter = false;
            this.color.OptionsFilter.AllowFilter = false;
            this.color.Visible = true;
            this.color.VisibleIndex = 12;
            this.color.Width = 100;
            // 
            // plate_effect
            // 
            this.plate_effect.Caption = "電鍍效果";
            this.plate_effect.FieldName = "plate_effect";
            this.plate_effect.Name = "plate_effect";
            this.plate_effect.OptionsColumn.AllowSize = false;
            this.plate_effect.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.plate_effect.OptionsColumn.ReadOnly = true;
            this.plate_effect.OptionsFilter.AllowAutoFilter = false;
            this.plate_effect.OptionsFilter.AllowFilter = false;
            this.plate_effect.Visible = true;
            this.plate_effect.VisibleIndex = 13;
            this.plate_effect.Width = 80;
            // 
            // outer_layer
            // 
            this.outer_layer.Caption = "外層";
            this.outer_layer.FieldName = "outer_layer";
            this.outer_layer.Name = "outer_layer";
            this.outer_layer.OptionsColumn.AllowSize = false;
            this.outer_layer.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.outer_layer.OptionsColumn.ReadOnly = true;
            this.outer_layer.OptionsFilter.AllowAutoFilter = false;
            this.outer_layer.OptionsFilter.AllowFilter = false;
            this.outer_layer.Visible = true;
            this.outer_layer.VisibleIndex = 14;
            this.outer_layer.Width = 80;
            // 
            // color_effect
            // 
            this.color_effect.Caption = "做色效果";
            this.color_effect.FieldName = "color_effect";
            this.color_effect.Name = "color_effect";
            this.color_effect.OptionsColumn.AllowSize = false;
            this.color_effect.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.color_effect.OptionsColumn.ReadOnly = true;
            this.color_effect.OptionsFilter.AllowAutoFilter = false;
            this.color_effect.OptionsFilter.AllowFilter = false;
            this.color_effect.Visible = true;
            this.color_effect.VisibleIndex = 15;
            this.color_effect.Width = 80;
            // 
            // chkSelect
            // 
            this.chkSelect.Location = new System.Drawing.Point(29, 175);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Properties.Caption = "全選";
            this.chkSelect.Size = new System.Drawing.Size(48, 19);
            this.chkSelect.TabIndex = 163;
            this.chkSelect.CheckedChanged += new System.EventHandler(this.chkSelect_CheckedChanged);
            // 
            // chkDelivery
            // 
            this.chkDelivery.Location = new System.Drawing.Point(156, 175);
            this.chkDelivery.Name = "chkDelivery";
            this.chkDelivery.Properties.Caption = "選中當前頁數,自動將當前頁數所有貨品選中";
            this.chkDelivery.Size = new System.Drawing.Size(282, 19);
            this.chkDelivery.TabIndex = 164;
            // 
            // frmOrderPacking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 588);
            this.Controls.Add(this.chkDelivery);
            this.Controls.Add(this.chkSelect);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMo_id2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMo_id1);
            this.Controls.Add(this.lblOut_dept);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGoods_id2);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtCheck_date2);
            this.Controls.Add(this.txtCheck_date1);
            this.Controls.Add(this.txtGoods_id1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmOrderPacking";
            this.Text = "frmOderPacking";
            this.Load += new System.EventHandler(this.frmOderPacking1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_id2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_id1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clFlag_select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSec_qty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDelivery.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton BTNSAVESET;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BTNPRINT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtMo_id2;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtMo_id1;
        private System.Windows.Forms.Label lblOut_dept;
        private DevExpress.XtraEditors.LookUpEdit txtLocation;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtGoods_id2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.DateEdit txtCheck_date2;
        private DevExpress.XtraEditors.DateEdit txtCheck_date1;
        private DevExpress.XtraEditors.TextEdit txtGoods_id1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn flag_select;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit clFlag_select;
        private DevExpress.XtraGrid.Columns.GridColumn location;
        private DevExpress.XtraGrid.Columns.GridColumn carton_code;
        private DevExpress.XtraGrid.Columns.GridColumn dept_id;
        private DevExpress.XtraGrid.Columns.GridColumn mo_id;
        private DevExpress.XtraGrid.Columns.GridColumn materiel_id;
        private DevExpress.XtraGrid.Columns.GridColumn name;
        private DevExpress.XtraGrid.Columns.GridColumn fl_qty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit colQty;
        private DevExpress.XtraGrid.Columns.GridColumn issues_qty;
        private DevExpress.XtraGrid.Columns.GridColumn unit;
        private DevExpress.XtraGrid.Columns.GridColumn sec_qty;
        private DevExpress.XtraGrid.Columns.GridColumn already_sec_qty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit colSec_qty;
        private DevExpress.XtraGrid.Columns.GridColumn color;
        private DevExpress.XtraGrid.Columns.GridColumn plate_effect;
        private DevExpress.XtraGrid.Columns.GridColumn outer_layer;
        private DevExpress.XtraGrid.Columns.GridColumn color_effect;
        private DevExpress.XtraEditors.CheckEdit chkSelect;
        private DevExpress.XtraEditors.CheckEdit chkDelivery;
    }
}