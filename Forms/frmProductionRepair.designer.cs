namespace cf01.Forms
{
    partial class frmProductionRepair
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionRepair));
            this.lblTemp_code = new System.Windows.Forms.Label();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNEDIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNDELETE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNITEMADD = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNITEMDEL = new System.Windows.Forms.ToolStripButton();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNPRINT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dgvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMo_id = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.goods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clGoods_id = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.goods_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_id_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.do_color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reason_repair = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clReason_repair = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.sec_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAmtount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInteger = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.is_deduct_amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clIs_deduct_amount = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.amt_deduction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.details_remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.is_ac_deduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clIs_ac_deduct = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ac_bill_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblorder_date = new System.Windows.Forms.Label();
            this.dtorder_date = new DevExpress.XtraEditors.DateEdit();
            this.luedepartment_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lbldepartment_id = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.memremark = new DevExpress.XtraEditors.MemoEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.luevendor_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lblVendor_id = new System.Windows.Forms.Label();
            this.lbllister_by = new System.Windows.Forms.Label();
            this.txtlister_by = new DevExpress.XtraEditors.TextEdit();
            this.lblAmtim = new System.Windows.Forms.Label();
            this.txtupdate_date = new DevExpress.XtraEditors.TextEdit();
            this.lblAmusr = new System.Windows.Forms.Label();
            this.txtupdate_by = new DevExpress.XtraEditors.TextEdit();
            this.lblCrtim = new System.Windows.Forms.Label();
            this.txtCreate_date = new DevExpress.XtraEditors.TextEdit();
            this.lblCrusr = new System.Windows.Forms.Label();
            this.txtCreate_by = new DevExpress.XtraEditors.TextEdit();
            this.bdsMostly = new System.Windows.Forms.BindingSource(this.components);
            this.bdsDetail = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clMo_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clGoods_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clReason_repair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clAmtount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clInteger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clIs_deduct_amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clIs_ac_deduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtorder_date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtorder_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedepartment_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memremark.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luevendor_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlister_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMostly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTemp_code
            // 
            this.lblTemp_code.ForeColor = System.Drawing.Color.Blue;
            this.lblTemp_code.Location = new System.Drawing.Point(532, 5);
            this.lblTemp_code.Name = "lblTemp_code";
            this.lblTemp_code.Size = new System.Drawing.Size(48, 13);
            this.lblTemp_code.TabIndex = 65;
            this.lblTemp_code.Text = "編號";
            this.lblTemp_code.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.EditValue = "";
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(583, 3);
            this.txtID.Name = "txtID";
            this.txtID.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtID.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Properties.MaxLength = 20;
            this.txtID.Properties.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(151, 22);
            this.txtID.TabIndex = 2;
            this.txtID.Tag = "1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNNEW,
            this.toolStripSeparator5,
            this.BTNEDIT,
            this.toolStripSeparator2,
            this.BTNDELETE,
            this.toolStripSeparator10,
            this.BTNITEMADD,
            this.toolStripSeparator9,
            this.BTNITEMDEL,
            this.BTNSAVE,
            this.toolStripSeparator6,
            this.BTNCANCEL,
            this.toolStripSeparator8,
            this.BTNFIND,
            this.toolStripSeparator4,
            this.BTNPRINT,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1016, 28);
            this.toolStrip1.TabIndex = 67;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Click += new System.EventHandler(this.toolStrip1_Click);
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
            // BTNNEW
            // 
            this.BTNNEW.Image = ((System.Drawing.Image)(resources.GetObject("BTNNEW.Image")));
            this.BTNNEW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNNEW.Name = "BTNNEW";
            this.BTNNEW.Size = new System.Drawing.Size(65, 25);
            this.BTNNEW.Text = "新增(&N)";
            this.BTNNEW.Click += new System.EventHandler(this.BTNNEW_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // BTNEDIT
            // 
            this.BTNEDIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEDIT.Image")));
            this.BTNEDIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEDIT.Name = "BTNEDIT";
            this.BTNEDIT.Size = new System.Drawing.Size(64, 25);
            this.BTNEDIT.Text = "編輯(&E)";
            this.BTNEDIT.Click += new System.EventHandler(this.BTNEDIT_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // BTNDELETE
            // 
            this.BTNDELETE.Image = ((System.Drawing.Image)(resources.GetObject("BTNDELETE.Image")));
            this.BTNDELETE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNDELETE.Name = "BTNDELETE";
            this.BTNDELETE.Size = new System.Drawing.Size(65, 25);
            this.BTNDELETE.Text = "刪除(&D)";
            this.BTNDELETE.Click += new System.EventHandler(this.BTNDELETE_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 28);
            // 
            // BTNITEMADD
            // 
            this.BTNITEMADD.Enabled = false;
            this.BTNITEMADD.Image = ((System.Drawing.Image)(resources.GetObject("BTNITEMADD.Image")));
            this.BTNITEMADD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNITEMADD.Name = "BTNITEMADD";
            this.BTNITEMADD.Size = new System.Drawing.Size(89, 25);
            this.BTNITEMADD.Text = "項目增加(&A)";
            this.BTNITEMADD.Click += new System.EventHandler(this.BTNITEMADD_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 28);
            // 
            // BTNITEMDEL
            // 
            this.BTNITEMDEL.Enabled = false;
            this.BTNITEMDEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNITEMDEL.Image")));
            this.BTNITEMDEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNITEMDEL.Name = "BTNITEMDEL";
            this.BTNITEMDEL.Size = new System.Drawing.Size(88, 25);
            this.BTNITEMDEL.Text = "項目刪除(&L)";
            this.BTNITEMDEL.Click += new System.EventHandler(this.BTNITEMDEL_Click);
            // 
            // BTNSAVE
            // 
            this.BTNSAVE.Enabled = false;
            this.BTNSAVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVE.Image")));
            this.BTNSAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVE.Name = "BTNSAVE";
            this.BTNSAVE.Size = new System.Drawing.Size(63, 25);
            this.BTNSAVE.Text = "保存(&S)";
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 28);
            // 
            // BTNCANCEL
            // 
            this.BTNCANCEL.Enabled = false;
            this.BTNCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNCANCEL.Image")));
            this.BTNCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCANCEL.Name = "BTNCANCEL";
            this.BTNCANCEL.Size = new System.Drawing.Size(65, 25);
            this.BTNCANCEL.Text = "取消(&U)";
            this.BTNCANCEL.Click += new System.EventHandler(this.BTNCANCEL_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Margin = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 28);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = global::cf01.Properties.Resources.find;
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(63, 25);
            this.BTNFIND.Text = "查詢(&F)";
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // BTNPRINT
            // 
            this.BTNPRINT.Image = ((System.Drawing.Image)(resources.GetObject("BTNPRINT.Image")));
            this.BTNPRINT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNPRINT.Name = "BTNPRINT";
            this.BTNPRINT.Size = new System.Drawing.Size(123, 25);
            this.BTNPRINT.Text = "補料申請單列印(&P)";
            this.BTNPRINT.Click += new System.EventHandler(this.BTNPRINT_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 176);
            this.gridControl1.MainView = this.dgvDetails;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.clMo_id,
            this.clGoods_id,
            this.clReason_repair,
            this.clIs_deduct_amount,
            this.clAmtount,
            this.clInteger,
            this.clIs_ac_deduct});
            this.gridControl1.Size = new System.Drawing.Size(1014, 560);
            this.gridControl1.TabIndex = 68;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetails});
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnPanelRowHeight = 30;
            this.dgvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sequence_id,
            this.mo_id,
            this.goods_id,
            this.goods_name,
            this.ref_id,
            this.ref_id_date,
            this.do_color,
            this.reason_repair,
            this.sec_qty,
            this.qty,
            this.is_deduct_amount,
            this.amt_deduction,
            this.details_remark,
            this.is_ac_deduct,
            this.ac_bill_id,
            this.id});
            this.dgvDetails.GridControl = this.gridControl1;
            this.dgvDetails.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.dgvDetails.IndicatorWidth = 30;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.OptionsBehavior.Editable = false;
            this.dgvDetails.OptionsCustomization.AllowColumnMoving = false;
            this.dgvDetails.OptionsCustomization.AllowFilter = false;
            this.dgvDetails.OptionsCustomization.AllowSort = false;
            this.dgvDetails.OptionsView.ColumnAutoWidth = false;
            this.dgvDetails.OptionsView.ShowGroupPanel = false;
            this.dgvDetails.PaintStyleName = "Style3D";
            this.dgvDetails.RowHeight = 22;
            this.dgvDetails.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.dgvDetails.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.dgvDetails_CustomDrawCell);
            // 
            // sequence_id
            // 
            this.sequence_id.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sequence_id.AppearanceHeader.Options.UseBackColor = true;
            this.sequence_id.Caption = "序號";
            this.sequence_id.FieldName = "sequence_id";
            this.sequence_id.Name = "sequence_id";
            this.sequence_id.OptionsColumn.AllowMove = false;
            this.sequence_id.OptionsColumn.AllowSize = false;
            this.sequence_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.sequence_id.OptionsColumn.ReadOnly = true;
            this.sequence_id.OptionsFilter.AllowAutoFilter = false;
            this.sequence_id.OptionsFilter.AllowFilter = false;
            this.sequence_id.Visible = true;
            this.sequence_id.VisibleIndex = 0;
            this.sequence_id.Width = 36;
            // 
            // mo_id
            // 
            this.mo_id.Caption = "正單頁數";
            this.mo_id.ColumnEdit = this.clMo_id;
            this.mo_id.FieldName = "mo_id";
            this.mo_id.Name = "mo_id";
            this.mo_id.OptionsColumn.AllowMove = false;
            this.mo_id.OptionsColumn.AllowSize = false;
            this.mo_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.mo_id.OptionsFilter.AllowAutoFilter = false;
            this.mo_id.OptionsFilter.AllowFilter = false;
            this.mo_id.Visible = true;
            this.mo_id.VisibleIndex = 1;
            this.mo_id.Width = 81;
            // 
            // clMo_id
            // 
            this.clMo_id.AutoHeight = false;
            this.clMo_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.clMo_id.MaxLength = 9;
            this.clMo_id.Name = "clMo_id";
            this.clMo_id.Leave += new System.EventHandler(this.clMo_id_Leave);
            // 
            // goods_id
            // 
            this.goods_id.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.goods_id.AppearanceCell.Options.UseBackColor = true;
            this.goods_id.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.goods_id.AppearanceHeader.Options.UseBackColor = true;
            this.goods_id.Caption = "貨品編碼";
            this.goods_id.ColumnEdit = this.clGoods_id;
            this.goods_id.FieldName = "goods_id";
            this.goods_id.Name = "goods_id";
            this.goods_id.OptionsColumn.AllowMove = false;
            this.goods_id.OptionsColumn.AllowSize = false;
            this.goods_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.goods_id.OptionsFilter.AllowAutoFilter = false;
            this.goods_id.OptionsFilter.AllowFilter = false;
            this.goods_id.Visible = true;
            this.goods_id.VisibleIndex = 2;
            this.goods_id.Width = 143;
            // 
            // clGoods_id
            // 
            this.clGoods_id.AutoHeight = false;
            this.clGoods_id.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clGoods_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.clGoods_id.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("goods_id", 140, "貨品編碼"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("goods_name", 150, "貨品名稱"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 90, "加工單號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("issue_date", "發料日期", 80, DevExpress.Utils.FormatType.DateTime, "yyyy-MM-dd", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("do_color", 150, "顏色做法"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sec_qty", 50, "重量(Kg)"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("prod_qty", 60, "數量(Pcs)"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("total_prices", 60, "總加工價")});
            this.clGoods_id.Name = "clGoods_id";
            this.clGoods_id.NullText = "";
            this.clGoods_id.PopupWidth = 780;
            this.clGoods_id.EditValueChanged += new System.EventHandler(this.clGoods_id_EditValueChanged);
            // 
            // goods_name
            // 
            this.goods_name.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.goods_name.AppearanceCell.Options.UseBackColor = true;
            this.goods_name.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.goods_name.AppearanceHeader.Options.UseBackColor = true;
            this.goods_name.Caption = "貨品名稱";
            this.goods_name.FieldName = "goods_name";
            this.goods_name.Name = "goods_name";
            this.goods_name.OptionsColumn.AllowMove = false;
            this.goods_name.OptionsColumn.AllowSize = false;
            this.goods_name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.goods_name.OptionsColumn.ReadOnly = true;
            this.goods_name.OptionsFilter.AllowAutoFilter = false;
            this.goods_name.OptionsFilter.AllowFilter = false;
            this.goods_name.Visible = true;
            this.goods_name.VisibleIndex = 3;
            this.goods_name.Width = 82;
            // 
            // ref_id
            // 
            this.ref_id.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ref_id.AppearanceCell.Options.UseBackColor = true;
            this.ref_id.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ref_id.AppearanceHeader.Options.UseBackColor = true;
            this.ref_id.Caption = "電鍍加工單號";
            this.ref_id.FieldName = "ref_id";
            this.ref_id.Name = "ref_id";
            this.ref_id.OptionsColumn.AllowMove = false;
            this.ref_id.OptionsColumn.AllowSize = false;
            this.ref_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ref_id.OptionsColumn.ReadOnly = true;
            this.ref_id.OptionsFilter.AllowAutoFilter = false;
            this.ref_id.OptionsFilter.AllowFilter = false;
            this.ref_id.Visible = true;
            this.ref_id.VisibleIndex = 4;
            this.ref_id.Width = 122;
            // 
            // ref_id_date
            // 
            this.ref_id_date.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ref_id_date.AppearanceCell.Options.UseBackColor = true;
            this.ref_id_date.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ref_id_date.AppearanceHeader.Options.UseBackColor = true;
            this.ref_id_date.Caption = "發貨日期";
            this.ref_id_date.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.ref_id_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ref_id_date.FieldName = "ref_id_date";
            this.ref_id_date.Name = "ref_id_date";
            this.ref_id_date.OptionsColumn.AllowMove = false;
            this.ref_id_date.OptionsColumn.AllowSize = false;
            this.ref_id_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ref_id_date.OptionsColumn.ReadOnly = true;
            this.ref_id_date.OptionsFilter.AllowAutoFilter = false;
            this.ref_id_date.OptionsFilter.AllowFilter = false;
            this.ref_id_date.Visible = true;
            this.ref_id_date.VisibleIndex = 5;
            this.ref_id_date.Width = 77;
            // 
            // do_color
            // 
            this.do_color.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.do_color.AppearanceCell.Options.UseBackColor = true;
            this.do_color.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.do_color.AppearanceHeader.Options.UseBackColor = true;
            this.do_color.Caption = "顏色做法";
            this.do_color.FieldName = "do_color";
            this.do_color.Name = "do_color";
            this.do_color.OptionsColumn.AllowMove = false;
            this.do_color.OptionsColumn.AllowSize = false;
            this.do_color.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.do_color.OptionsColumn.ReadOnly = true;
            this.do_color.OptionsFilter.AllowAutoFilter = false;
            this.do_color.OptionsFilter.AllowFilter = false;
            this.do_color.Visible = true;
            this.do_color.VisibleIndex = 6;
            this.do_color.Width = 102;
            // 
            // reason_repair
            // 
            this.reason_repair.Caption = "補料原因";
            this.reason_repair.ColumnEdit = this.clReason_repair;
            this.reason_repair.FieldName = "reason_repair";
            this.reason_repair.Name = "reason_repair";
            this.reason_repair.OptionsColumn.AllowMove = false;
            this.reason_repair.OptionsColumn.AllowSize = false;
            this.reason_repair.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.reason_repair.OptionsFilter.AllowAutoFilter = false;
            this.reason_repair.OptionsFilter.AllowFilter = false;
            this.reason_repair.Visible = true;
            this.reason_repair.VisibleIndex = 7;
            this.reason_repair.Width = 135;
            // 
            // clReason_repair
            // 
            this.clReason_repair.AutoHeight = false;
            this.clReason_repair.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clReason_repair.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 150, "cdesc")});
            this.clReason_repair.DropDownRows = 25;
            this.clReason_repair.ImmediatePopup = true;
            this.clReason_repair.Name = "clReason_repair";
            this.clReason_repair.NullText = "";
            this.clReason_repair.PopupWidth = 180;
            this.clReason_repair.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.clReason_repair.ShowHeader = false;
            this.clReason_repair.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // sec_qty
            // 
            this.sec_qty.Caption = "重量(Kg)";
            this.sec_qty.ColumnEdit = this.clAmtount;
            this.sec_qty.FieldName = "sec_qty";
            this.sec_qty.Name = "sec_qty";
            this.sec_qty.OptionsColumn.AllowMove = false;
            this.sec_qty.OptionsColumn.AllowSize = false;
            this.sec_qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.sec_qty.OptionsFilter.AllowAutoFilter = false;
            this.sec_qty.OptionsFilter.AllowFilter = false;
            this.sec_qty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.sec_qty.Visible = true;
            this.sec_qty.VisibleIndex = 8;
            this.sec_qty.Width = 61;
            // 
            // clAmtount
            // 
            this.clAmtount.AutoHeight = false;
            this.clAmtount.DisplayFormat.FormatString = "n2";
            this.clAmtount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clAmtount.EditFormat.FormatString = "n2";
            this.clAmtount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clAmtount.Mask.EditMask = "n2";
            this.clAmtount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.clAmtount.Name = "clAmtount";
            this.clAmtount.NullText = "0.00";
            // 
            // qty
            // 
            this.qty.Caption = "數量(Pcs)";
            this.qty.ColumnEdit = this.clInteger;
            this.qty.FieldName = "qty";
            this.qty.Name = "qty";
            this.qty.OptionsColumn.AllowMove = false;
            this.qty.OptionsColumn.AllowSize = false;
            this.qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.qty.OptionsFilter.AllowAutoFilter = false;
            this.qty.OptionsFilter.AllowFilter = false;
            this.qty.Visible = true;
            this.qty.VisibleIndex = 9;
            this.qty.Width = 67;
            // 
            // clInteger
            // 
            this.clInteger.AutoHeight = false;
            this.clInteger.DisplayFormat.FormatString = "n0";
            this.clInteger.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clInteger.EditFormat.FormatString = "n0";
            this.clInteger.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clInteger.Mask.EditMask = "n0";
            this.clInteger.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.clInteger.Name = "clInteger";
            // 
            // is_deduct_amount
            // 
            this.is_deduct_amount.Caption = "是否扣除金額";
            this.is_deduct_amount.ColumnEdit = this.clIs_deduct_amount;
            this.is_deduct_amount.FieldName = "is_deduct_amount";
            this.is_deduct_amount.Name = "is_deduct_amount";
            this.is_deduct_amount.OptionsColumn.AllowMove = false;
            this.is_deduct_amount.OptionsColumn.AllowSize = false;
            this.is_deduct_amount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.is_deduct_amount.OptionsFilter.AllowAutoFilter = false;
            this.is_deduct_amount.OptionsFilter.AllowFilter = false;
            this.is_deduct_amount.Visible = true;
            this.is_deduct_amount.VisibleIndex = 10;
            // 
            // clIs_deduct_amount
            // 
            this.clIs_deduct_amount.AutoHeight = false;
            this.clIs_deduct_amount.LookAndFeel.UseDefaultLookAndFeel = false;
            this.clIs_deduct_amount.Name = "clIs_deduct_amount";
            this.clIs_deduct_amount.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // amt_deduction
            // 
            this.amt_deduction.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.amt_deduction.AppearanceCell.Options.UseForeColor = true;
            this.amt_deduction.Caption = "扣數金額(HKD)";
            this.amt_deduction.ColumnEdit = this.clAmtount;
            this.amt_deduction.FieldName = "amt_deduction";
            this.amt_deduction.Name = "amt_deduction";
            this.amt_deduction.OptionsColumn.AllowMove = false;
            this.amt_deduction.OptionsColumn.AllowSize = false;
            this.amt_deduction.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.amt_deduction.OptionsFilter.AllowAutoFilter = false;
            this.amt_deduction.OptionsFilter.AllowFilter = false;
            this.amt_deduction.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.amt_deduction.Visible = true;
            this.amt_deduction.VisibleIndex = 11;
            this.amt_deduction.Width = 91;
            // 
            // details_remark
            // 
            this.details_remark.Caption = "其它備註";
            this.details_remark.FieldName = "details_remark";
            this.details_remark.Name = "details_remark";
            this.details_remark.OptionsColumn.AllowMove = false;
            this.details_remark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.details_remark.OptionsFilter.AllowAutoFilter = false;
            this.details_remark.OptionsFilter.AllowFilter = false;
            this.details_remark.Visible = true;
            this.details_remark.VisibleIndex = 12;
            this.details_remark.Width = 120;
            // 
            // is_ac_deduct
            // 
            this.is_ac_deduct.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.is_ac_deduct.AppearanceCell.Options.UseBackColor = true;
            this.is_ac_deduct.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.is_ac_deduct.AppearanceHeader.Options.UseBackColor = true;
            this.is_ac_deduct.Caption = "財務扣款狀態";
            this.is_ac_deduct.ColumnEdit = this.clIs_ac_deduct;
            this.is_ac_deduct.FieldName = "is_ac_deduct";
            this.is_ac_deduct.Name = "is_ac_deduct";
            this.is_ac_deduct.OptionsColumn.AllowMove = false;
            this.is_ac_deduct.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.is_ac_deduct.OptionsFilter.AllowAutoFilter = false;
            this.is_ac_deduct.OptionsFilter.AllowFilter = false;
            this.is_ac_deduct.Visible = true;
            this.is_ac_deduct.VisibleIndex = 13;
            this.is_ac_deduct.Width = 90;
            // 
            // clIs_ac_deduct
            // 
            this.clIs_ac_deduct.AutoHeight = false;
            this.clIs_ac_deduct.LookAndFeel.UseDefaultLookAndFeel = false;
            this.clIs_ac_deduct.Name = "clIs_ac_deduct";
            this.clIs_ac_deduct.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.clIs_ac_deduct.MouseUp += new System.Windows.Forms.MouseEventHandler(this.clIs_ac_deduct_MouseUp);
            // 
            // ac_bill_id
            // 
            this.ac_bill_id.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ac_bill_id.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.ac_bill_id.AppearanceCell.Options.UseBackColor = true;
            this.ac_bill_id.AppearanceCell.Options.UseForeColor = true;
            this.ac_bill_id.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ac_bill_id.AppearanceHeader.Options.UseBackColor = true;
            this.ac_bill_id.Caption = "傳票號碼";
            this.ac_bill_id.FieldName = "ac_bill_id";
            this.ac_bill_id.Name = "ac_bill_id";
            this.ac_bill_id.OptionsColumn.AllowMove = false;
            this.ac_bill_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ac_bill_id.OptionsFilter.AllowAutoFilter = false;
            this.ac_bill_id.OptionsFilter.AllowFilter = false;
            this.ac_bill_id.Visible = true;
            this.ac_bill_id.VisibleIndex = 14;
            this.ac_bill_id.Width = 120;
            // 
            // id
            // 
            this.id.Caption = "編號";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.OptionsFilter.AllowAutoFilter = false;
            this.id.OptionsFilter.AllowFilter = false;
            this.id.Tag = "2";
            this.id.Width = 20;
            // 
            // lblorder_date
            // 
            this.lblorder_date.ForeColor = System.Drawing.Color.Blue;
            this.lblorder_date.Location = new System.Drawing.Point(29, 30);
            this.lblorder_date.Name = "lblorder_date";
            this.lblorder_date.Size = new System.Drawing.Size(60, 13);
            this.lblorder_date.TabIndex = 120;
            this.lblorder_date.Text = "申請日期";
            this.lblorder_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtorder_date
            // 
            this.dtorder_date.EditValue = "";
            this.dtorder_date.Enabled = false;
            this.dtorder_date.EnterMoveNextControl = true;
            this.dtorder_date.Location = new System.Drawing.Point(92, 28);
            this.dtorder_date.Name = "dtorder_date";
            this.dtorder_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtorder_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtorder_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtorder_date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtorder_date.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtorder_date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtorder_date.Properties.Mask.BeepOnError = true;
            this.dtorder_date.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtorder_date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtorder_date.Properties.MaxLength = 10;
            this.dtorder_date.Properties.NullDate = "";
            this.dtorder_date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtorder_date.Size = new System.Drawing.Size(149, 22);
            this.dtorder_date.TabIndex = 3;
            this.dtorder_date.Tag = "2";
            // 
            // luedepartment_id
            // 
            this.luedepartment_id.EditValue = "";
            this.luedepartment_id.Enabled = false;
            this.luedepartment_id.EnterMoveNextControl = true;
            this.luedepartment_id.Location = new System.Drawing.Point(92, 3);
            this.luedepartment_id.Name = "luedepartment_id";
            this.luedepartment_id.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.luedepartment_id.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.luedepartment_id.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.luedepartment_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedepartment_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.luedepartment_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 80, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 200, "cdesc")});
            this.luedepartment_id.Properties.DropDownRows = 15;
            this.luedepartment_id.Properties.ImmediatePopup = true;
            this.luedepartment_id.Properties.NullText = "";
            this.luedepartment_id.Properties.PopupFormMinSize = new System.Drawing.Size(200, 0);
            this.luedepartment_id.Properties.PopupWidth = 280;
            this.luedepartment_id.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.luedepartment_id.Properties.ShowHeader = false;
            this.luedepartment_id.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luedepartment_id.Size = new System.Drawing.Size(149, 22);
            this.luedepartment_id.TabIndex = 0;
            this.luedepartment_id.Tag = "2";
            this.luedepartment_id.EditValueChanged += new System.EventHandler(this.luedepartment_id_EditValueChanged);
            // 
            // lbldepartment_id
            // 
            this.lbldepartment_id.ForeColor = System.Drawing.Color.Blue;
            this.lbldepartment_id.Location = new System.Drawing.Point(29, 5);
            this.lbldepartment_id.Name = "lbldepartment_id";
            this.lbldepartment_id.Size = new System.Drawing.Size(60, 13);
            this.lbldepartment_id.TabIndex = 180;
            this.lbldepartment_id.Text = "申請部門";
            this.lbldepartment_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(29, 51);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 13);
            this.label24.TabIndex = 199;
            this.label24.Text = "備 註";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // memremark
            // 
            this.memremark.EditValue = "";
            this.memremark.EnterMoveNextControl = true;
            this.memremark.Location = new System.Drawing.Point(92, 53);
            this.memremark.Name = "memremark";
            this.memremark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.memremark.Properties.MaxLength = 250;
            this.memremark.Properties.ReadOnly = true;
            this.memremark.Size = new System.Drawing.Size(912, 50);
            this.memremark.TabIndex = 5;
            this.memremark.Tag = "2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.luevendor_id);
            this.panel1.Controls.Add(this.lblVendor_id);
            this.panel1.Controls.Add(this.lbllister_by);
            this.panel1.Controls.Add(this.txtlister_by);
            this.panel1.Controls.Add(this.lblTemp_code);
            this.panel1.Controls.Add(this.lblAmtim);
            this.panel1.Controls.Add(this.txtupdate_date);
            this.panel1.Controls.Add(this.lblAmusr);
            this.panel1.Controls.Add(this.txtupdate_by);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.lblCrtim);
            this.panel1.Controls.Add(this.dtorder_date);
            this.panel1.Controls.Add(this.txtCreate_date);
            this.panel1.Controls.Add(this.lblCrusr);
            this.panel1.Controls.Add(this.lblorder_date);
            this.panel1.Controls.Add(this.txtCreate_by);
            this.panel1.Controls.Add(this.luedepartment_id);
            this.panel1.Controls.Add(this.memremark);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.lbldepartment_id);
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 141);
            this.panel1.TabIndex = 201;
            // 
            // luevendor_id
            // 
            this.luevendor_id.EditValue = "";
            this.luevendor_id.Enabled = false;
            this.luevendor_id.EnterMoveNextControl = true;
            this.luevendor_id.Location = new System.Drawing.Point(326, 3);
            this.luevendor_id.Name = "luevendor_id";
            this.luevendor_id.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.luevendor_id.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.luevendor_id.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.luevendor_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luevendor_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.luevendor_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 80, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 200, "cdesc")});
            this.luevendor_id.Properties.DropDownRows = 15;
            this.luevendor_id.Properties.NullText = "";
            this.luevendor_id.Properties.PopupFormMinSize = new System.Drawing.Size(200, 0);
            this.luevendor_id.Properties.PopupWidth = 280;
            this.luevendor_id.Properties.ShowHeader = false;
            this.luevendor_id.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luevendor_id.Size = new System.Drawing.Size(192, 22);
            this.luevendor_id.TabIndex = 1;
            this.luevendor_id.Tag = "2";
            this.luevendor_id.EditValueChanged += new System.EventHandler(this.luevendor_id_EditValueChanged);
            // 
            // lblVendor_id
            // 
            this.lblVendor_id.ForeColor = System.Drawing.Color.Blue;
            this.lblVendor_id.Location = new System.Drawing.Point(247, 5);
            this.lblVendor_id.Name = "lblVendor_id";
            this.lblVendor_id.Size = new System.Drawing.Size(77, 13);
            this.lblVendor_id.TabIndex = 213;
            this.lblVendor_id.Text = "外發供應商";
            this.lblVendor_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbllister_by
            // 
            this.lbllister_by.Location = new System.Drawing.Point(247, 30);
            this.lbllister_by.Name = "lbllister_by";
            this.lbllister_by.Size = new System.Drawing.Size(77, 13);
            this.lbllister_by.TabIndex = 211;
            this.lbllister_by.Text = "制表人";
            this.lbllister_by.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtlister_by
            // 
            this.txtlister_by.EditValue = "";
            this.txtlister_by.EnterMoveNextControl = true;
            this.txtlister_by.Location = new System.Drawing.Point(326, 28);
            this.txtlister_by.Name = "txtlister_by";
            this.txtlister_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtlister_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtlister_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtlister_by.Properties.MaxLength = 30;
            this.txtlister_by.Properties.ReadOnly = true;
            this.txtlister_by.Size = new System.Drawing.Size(192, 22);
            this.txtlister_by.TabIndex = 4;
            this.txtlister_by.Tag = "2";
            // 
            // lblAmtim
            // 
            this.lblAmtim.Location = new System.Drawing.Point(771, 110);
            this.lblAmtim.Name = "lblAmtim";
            this.lblAmtim.Size = new System.Drawing.Size(60, 13);
            this.lblAmtim.TabIndex = 209;
            this.lblAmtim.Text = "修改日期";
            this.lblAmtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtupdate_date
            // 
            this.txtupdate_date.EditValue = "";
            this.txtupdate_date.Enabled = false;
            this.txtupdate_date.Location = new System.Drawing.Point(834, 106);
            this.txtupdate_date.Name = "txtupdate_date";
            this.txtupdate_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtupdate_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtupdate_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtupdate_date.Properties.ReadOnly = true;
            this.txtupdate_date.Size = new System.Drawing.Size(170, 22);
            this.txtupdate_date.TabIndex = 9;
            this.txtupdate_date.Tag = "2";
            // 
            // lblAmusr
            // 
            this.lblAmusr.Location = new System.Drawing.Point(532, 110);
            this.lblAmusr.Name = "lblAmusr";
            this.lblAmusr.Size = new System.Drawing.Size(48, 13);
            this.lblAmusr.TabIndex = 208;
            this.lblAmusr.Text = "修改人";
            this.lblAmusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtupdate_by
            // 
            this.txtupdate_by.EditValue = "";
            this.txtupdate_by.Enabled = false;
            this.txtupdate_by.Location = new System.Drawing.Point(583, 106);
            this.txtupdate_by.Name = "txtupdate_by";
            this.txtupdate_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtupdate_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtupdate_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtupdate_by.Properties.MaxLength = 20;
            this.txtupdate_by.Properties.ReadOnly = true;
            this.txtupdate_by.Size = new System.Drawing.Size(151, 22);
            this.txtupdate_by.TabIndex = 8;
            this.txtupdate_by.Tag = "2";
            // 
            // lblCrtim
            // 
            this.lblCrtim.Location = new System.Drawing.Point(247, 110);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(77, 13);
            this.lblCrtim.TabIndex = 205;
            this.lblCrtim.Text = "建檔日期";
            this.lblCrtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreate_date
            // 
            this.txtCreate_date.Enabled = false;
            this.txtCreate_date.Location = new System.Drawing.Point(326, 106);
            this.txtCreate_date.Name = "txtCreate_date";
            this.txtCreate_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCreate_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCreate_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCreate_date.Properties.ReadOnly = true;
            this.txtCreate_date.Size = new System.Drawing.Size(192, 22);
            this.txtCreate_date.TabIndex = 7;
            this.txtCreate_date.Tag = "2";
            // 
            // lblCrusr
            // 
            this.lblCrusr.Location = new System.Drawing.Point(29, 110);
            this.lblCrusr.Name = "lblCrusr";
            this.lblCrusr.Size = new System.Drawing.Size(60, 13);
            this.lblCrusr.TabIndex = 204;
            this.lblCrusr.Text = "建檔人";
            this.lblCrusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreate_by
            // 
            this.txtCreate_by.Enabled = false;
            this.txtCreate_by.Location = new System.Drawing.Point(92, 106);
            this.txtCreate_by.Name = "txtCreate_by";
            this.txtCreate_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCreate_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCreate_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCreate_by.Properties.MaxLength = 20;
            this.txtCreate_by.Properties.ReadOnly = true;
            this.txtCreate_by.Size = new System.Drawing.Size(149, 22);
            this.txtCreate_by.TabIndex = 6;
            this.txtCreate_by.Tag = "2";
            // 
            // frmProductionRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "frmProductionRepair";
            this.Text = "frmProductionRepair";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProductionRepair_FormClosed);
            this.Load += new System.EventHandler(this.frmProductionRepair_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clMo_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clGoods_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clReason_repair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clAmtount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clInteger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clIs_deduct_amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clIs_ac_deduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtorder_date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtorder_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedepartment_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memremark.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.luevendor_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlister_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMostly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTemp_code;
        private DevExpress.XtraEditors.TextEdit txtID;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton BTNEDIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BTNDELETE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton BTNITEMADD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton BTNITEMDEL;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BTNPRINT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetails;
        private DevExpress.XtraGrid.Columns.GridColumn goods_id;
        private DevExpress.XtraGrid.Columns.GridColumn goods_name;
        private DevExpress.XtraGrid.Columns.GridColumn ref_id;
        private DevExpress.XtraGrid.Columns.GridColumn qty;
        private DevExpress.XtraGrid.Columns.GridColumn sec_qty;
        private DevExpress.XtraGrid.Columns.GridColumn ref_id_date;
        private DevExpress.XtraGrid.Columns.GridColumn amt_deduction;
        private DevExpress.XtraGrid.Columns.GridColumn do_color;
        private DevExpress.XtraGrid.Columns.GridColumn mo_id;
        private DevExpress.XtraGrid.Columns.GridColumn reason_repair;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn sequence_id;
        private System.Windows.Forms.Label lblorder_date;
        private DevExpress.XtraEditors.DateEdit dtorder_date;
        private DevExpress.XtraEditors.LookUpEdit luedepartment_id;
        private System.Windows.Forms.Label lbldepartment_id;
        private System.Windows.Forms.Label label24;
        private DevExpress.XtraEditors.MemoEdit memremark;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCrtim;
        private System.Windows.Forms.Label lblCrusr;
        private DevExpress.XtraEditors.TextEdit txtCreate_date;
        private DevExpress.XtraEditors.TextEdit txtCreate_by;
        private System.Windows.Forms.Label lblAmtim;
        private System.Windows.Forms.Label lblAmusr;
        private DevExpress.XtraEditors.TextEdit txtupdate_date;
        private DevExpress.XtraEditors.TextEdit txtupdate_by;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit clMo_id;
        private DevExpress.XtraGrid.Columns.GridColumn details_remark;
        private System.Windows.Forms.BindingSource bdsMostly;
        private System.Windows.Forms.BindingSource bdsDetail;
        private System.Windows.Forms.Label lbllister_by;
        private DevExpress.XtraEditors.TextEdit txtlister_by;
        private DevExpress.XtraEditors.LookUpEdit luevendor_id;
        private System.Windows.Forms.Label lblVendor_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit clGoods_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit clReason_repair;
        private DevExpress.XtraGrid.Columns.GridColumn is_deduct_amount;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit clIs_deduct_amount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit clAmtount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit clInteger;
        private DevExpress.XtraGrid.Columns.GridColumn is_ac_deduct;
        private DevExpress.XtraGrid.Columns.GridColumn ac_bill_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit clIs_ac_deduct;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}