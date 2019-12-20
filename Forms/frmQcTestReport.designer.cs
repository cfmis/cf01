namespace cf01.Forms
{
    partial class frmQcTestReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQcTestReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNPRINT = new System.Windows.Forms.ToolStripButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dgvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.item_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contents = new DevExpress.XtraGrid.Columns.GridColumn();
            this.details_remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clItem_no = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lblorder_date = new System.Windows.Forms.Label();
            this.dtcon_date = new DevExpress.XtraEditors.DateEdit();
            this.luecustomer_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lbldepartment_id = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.memremark = new DevExpress.XtraEditors.MemoEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtcontact = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcustomer_name = new DevExpress.XtraEditors.TextEdit();
            this.lblAmtim = new System.Windows.Forms.Label();
            this.txtupdate_date = new DevExpress.XtraEditors.TextEdit();
            this.lblAmusr = new System.Windows.Forms.Label();
            this.txtupdate_by = new DevExpress.XtraEditors.TextEdit();
            this.txtCreate_date = new DevExpress.XtraEditors.TextEdit();
            this.lblCrusr = new System.Windows.Forms.Label();
            this.txtCreate_by = new DevExpress.XtraEditors.TextEdit();
            this.lblCrtim = new System.Windows.Forms.Label();
            this.bdsMostly = new System.Windows.Forms.BindingSource(this.components);
            this.bdsDetail = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbgpage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.dgvDetails_result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sequence_id2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.test_item_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.test_require = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMemrequire = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.test_is_pass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clsTest_is_pass = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.test_result = new DevExpress.XtraGrid.Columns.GridColumn();
            this.details_remark2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTest_item_id = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnDel1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd1 = new DevExpress.XtraEditors.SimpleButton();
            this.tbgpage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.BTNSAVESET = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtMo_id1 = new DevExpress.XtraEditors.TextEdit();
            this.txtId1 = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId2 = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtDate1 = new DevExpress.XtraEditors.DateEdit();
            this.dtDate2 = new DevExpress.XtraEditors.DateEdit();
            this.dgvFind = new System.Windows.Forms.DataGridView();
            this.id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.con_date1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sequence_id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_no1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contents1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.details_remark1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bdsDetail_result = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clItem_no)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcon_date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcon_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecustomer_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memremark.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcontact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomer_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMostly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDetail)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbgpage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clMemrequire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsTest_is_pass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clTest_item_id)).BeginInit();
            this.tbgpage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDetail_result)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTemp_code
            // 
            this.lblTemp_code.ForeColor = System.Drawing.Color.Blue;
            this.lblTemp_code.Location = new System.Drawing.Point(3, 4);
            this.lblTemp_code.Name = "lblTemp_code";
            this.lblTemp_code.Size = new System.Drawing.Size(58, 13);
            this.lblTemp_code.TabIndex = 65;
            this.lblTemp_code.Text = "報告編號";
            this.lblTemp_code.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.EditValue = "";
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(62, 2);
            this.txtID.Name = "txtID";
            this.txtID.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtID.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Properties.MaxLength = 20;
            this.txtID.Properties.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(117, 22);
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
            this.toolStripSeparator4,
            this.BTNPRINT});
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
            this.BTNPRINT.Size = new System.Drawing.Size(63, 25);
            this.BTNPRINT.Text = "列印(&P)";
            this.BTNPRINT.Click += new System.EventHandler(this.BTNPRINT_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(2, 83);
            this.gridControl1.MainView = this.dgvDetails;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.clItem_no});
            this.gridControl1.Size = new System.Drawing.Size(1001, 280);
            this.gridControl1.TabIndex = 68;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetails});
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnPanelRowHeight = 30;
            this.dgvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sequence_id,
            this.item_no,
            this.contents,
            this.details_remark,
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
            this.dgvDetails.RowHeight = 28;
            this.dgvDetails.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.dgvDetails.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.dgvDetails_CustomDrawCell);
            this.dgvDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDetails_KeyDown);
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
            this.sequence_id.Width = 50;
            // 
            // item_no
            // 
            this.item_no.Caption = "產品測試項目";
            this.item_no.FieldName = "item_no";
            this.item_no.Name = "item_no";
            this.item_no.OptionsColumn.AllowMove = false;
            this.item_no.OptionsColumn.AllowSize = false;
            this.item_no.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.item_no.OptionsFilter.AllowAutoFilter = false;
            this.item_no.OptionsFilter.AllowFilter = false;
            this.item_no.Visible = true;
            this.item_no.VisibleIndex = 1;
            this.item_no.Width = 250;
            // 
            // contents
            // 
            this.contents.Caption = "內容";
            this.contents.FieldName = "contents";
            this.contents.Name = "contents";
            this.contents.OptionsColumn.AllowMove = false;
            this.contents.OptionsColumn.AllowSize = false;
            this.contents.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.contents.OptionsFilter.AllowAutoFilter = false;
            this.contents.OptionsFilter.AllowFilter = false;
            this.contents.Visible = true;
            this.contents.VisibleIndex = 2;
            this.contents.Width = 400;
            // 
            // details_remark
            // 
            this.details_remark.Caption = "備註";
            this.details_remark.FieldName = "details_remark";
            this.details_remark.Name = "details_remark";
            this.details_remark.OptionsColumn.AllowMove = false;
            this.details_remark.OptionsColumn.AllowSize = false;
            this.details_remark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.details_remark.OptionsFilter.AllowAutoFilter = false;
            this.details_remark.OptionsFilter.AllowFilter = false;
            this.details_remark.Visible = true;
            this.details_remark.VisibleIndex = 3;
            this.details_remark.Width = 249;
            // 
            // id
            // 
            this.id.Caption = "編號";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.OptionsFilter.AllowAutoFilter = false;
            this.id.OptionsFilter.AllowFilter = false;
            this.id.Tag = "";
            this.id.Width = 20;
            // 
            // clItem_no
            // 
            this.clItem_no.AutoHeight = false;
            this.clItem_no.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clItem_no.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 250, "cdesc")});
            this.clItem_no.DropDownRows = 15;
            this.clItem_no.ImmediatePopup = true;
            this.clItem_no.Name = "clItem_no";
            this.clItem_no.NullText = "";
            this.clItem_no.PopupWidth = 280;
            this.clItem_no.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.clItem_no.ShowHeader = false;
            this.clItem_no.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // lblorder_date
            // 
            this.lblorder_date.ForeColor = System.Drawing.Color.Blue;
            this.lblorder_date.Location = new System.Drawing.Point(180, 4);
            this.lblorder_date.Name = "lblorder_date";
            this.lblorder_date.Size = new System.Drawing.Size(60, 13);
            this.lblorder_date.TabIndex = 120;
            this.lblorder_date.Text = "報告日期";
            this.lblorder_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtcon_date
            // 
            this.dtcon_date.EditValue = "";
            this.dtcon_date.Enabled = false;
            this.dtcon_date.EnterMoveNextControl = true;
            this.dtcon_date.Location = new System.Drawing.Point(239, 2);
            this.dtcon_date.Name = "dtcon_date";
            this.dtcon_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtcon_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtcon_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtcon_date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtcon_date.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtcon_date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtcon_date.Properties.Mask.BeepOnError = true;
            this.dtcon_date.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtcon_date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtcon_date.Properties.MaxLength = 10;
            this.dtcon_date.Properties.NullDate = "";
            this.dtcon_date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtcon_date.Size = new System.Drawing.Size(101, 22);
            this.dtcon_date.TabIndex = 3;
            this.dtcon_date.Tag = "2";
            // 
            // luecustomer_id
            // 
            this.luecustomer_id.EditValue = "";
            this.luecustomer_id.Enabled = false;
            this.luecustomer_id.EnterMoveNextControl = true;
            this.luecustomer_id.Location = new System.Drawing.Point(62, 26);
            this.luecustomer_id.Name = "luecustomer_id";
            this.luecustomer_id.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.luecustomer_id.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.luecustomer_id.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.luecustomer_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luecustomer_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.luecustomer_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 80, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 200, "cdesc")});
            this.luecustomer_id.Properties.DropDownRows = 15;
            this.luecustomer_id.Properties.ImmediatePopup = true;
            this.luecustomer_id.Properties.NullText = "";
            this.luecustomer_id.Properties.PopupFormMinSize = new System.Drawing.Size(200, 0);
            this.luecustomer_id.Properties.PopupWidth = 280;
            this.luecustomer_id.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.luecustomer_id.Properties.ShowHeader = false;
            this.luecustomer_id.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luecustomer_id.Size = new System.Drawing.Size(117, 22);
            this.luecustomer_id.TabIndex = 0;
            this.luecustomer_id.Tag = "2";
            // 
            // lbldepartment_id
            // 
            this.lbldepartment_id.ForeColor = System.Drawing.Color.Blue;
            this.lbldepartment_id.Location = new System.Drawing.Point(3, 28);
            this.lbldepartment_id.Name = "lbldepartment_id";
            this.lbldepartment_id.Size = new System.Drawing.Size(58, 13);
            this.lbldepartment_id.TabIndex = 180;
            this.lbldepartment_id.Text = "客戶代碼";
            this.lbldepartment_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(551, 4);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 13);
            this.label24.TabIndex = 199;
            this.label24.Text = "備 註";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // memremark
            // 
            this.memremark.EditValue = "";
            this.memremark.EnterMoveNextControl = true;
            this.memremark.Location = new System.Drawing.Point(601, 2);
            this.memremark.Name = "memremark";
            this.memremark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.memremark.Properties.MaxLength = 250;
            this.memremark.Properties.ReadOnly = true;
            this.memremark.Size = new System.Drawing.Size(393, 46);
            this.memremark.TabIndex = 5;
            this.memremark.Tag = "2";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtcontact);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtcustomer_name);
            this.panel1.Controls.Add(this.lblTemp_code);
            this.panel1.Controls.Add(this.lblAmtim);
            this.panel1.Controls.Add(this.txtupdate_date);
            this.panel1.Controls.Add(this.lblAmusr);
            this.panel1.Controls.Add(this.txtupdate_by);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.dtcon_date);
            this.panel1.Controls.Add(this.txtCreate_date);
            this.panel1.Controls.Add(this.lblCrusr);
            this.panel1.Controls.Add(this.txtCreate_by);
            this.panel1.Controls.Add(this.luecustomer_id);
            this.panel1.Controls.Add(this.memremark);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.lbldepartment_id);
            this.panel1.Controls.Add(this.lblorder_date);
            this.panel1.Controls.Add(this.lblCrtim);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 79);
            this.panel1.TabIndex = 201;
            // 
            // txtcontact
            // 
            this.txtcontact.EditValue = "";
            this.txtcontact.Location = new System.Drawing.Point(395, 2);
            this.txtcontact.Name = "txtcontact";
            this.txtcontact.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtcontact.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtcontact.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtcontact.Properties.MaxLength = 20;
            this.txtcontact.Properties.ReadOnly = true;
            this.txtcontact.Size = new System.Drawing.Size(150, 22);
            this.txtcontact.TabIndex = 212;
            this.txtcontact.Tag = "2";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(346, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 211;
            this.label1.Text = "聯系人";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtcustomer_name
            // 
            this.txtcustomer_name.EditValue = "";
            this.txtcustomer_name.Enabled = false;
            this.txtcustomer_name.Location = new System.Drawing.Point(179, 26);
            this.txtcustomer_name.Name = "txtcustomer_name";
            this.txtcustomer_name.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtcustomer_name.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtcustomer_name.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtcustomer_name.Properties.MaxLength = 20;
            this.txtcustomer_name.Properties.ReadOnly = true;
            this.txtcustomer_name.Size = new System.Drawing.Size(366, 22);
            this.txtcustomer_name.TabIndex = 210;
            this.txtcustomer_name.Tag = "2";
            // 
            // lblAmtim
            // 
            this.lblAmtim.Location = new System.Drawing.Point(756, 55);
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
            this.txtupdate_date.Location = new System.Drawing.Point(819, 52);
            this.txtupdate_date.Name = "txtupdate_date";
            this.txtupdate_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtupdate_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtupdate_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtupdate_date.Properties.ReadOnly = true;
            this.txtupdate_date.Size = new System.Drawing.Size(175, 22);
            this.txtupdate_date.TabIndex = 9;
            this.txtupdate_date.Tag = "2";
            // 
            // lblAmusr
            // 
            this.lblAmusr.Location = new System.Drawing.Point(550, 55);
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
            this.txtupdate_by.Location = new System.Drawing.Point(601, 52);
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
            // txtCreate_date
            // 
            this.txtCreate_date.Enabled = false;
            this.txtCreate_date.Location = new System.Drawing.Point(395, 52);
            this.txtCreate_date.Name = "txtCreate_date";
            this.txtCreate_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCreate_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCreate_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCreate_date.Properties.ReadOnly = true;
            this.txtCreate_date.Size = new System.Drawing.Size(150, 22);
            this.txtCreate_date.TabIndex = 7;
            this.txtCreate_date.Tag = "2";
            // 
            // lblCrusr
            // 
            this.lblCrusr.Location = new System.Drawing.Point(3, 55);
            this.lblCrusr.Name = "lblCrusr";
            this.lblCrusr.Size = new System.Drawing.Size(58, 13);
            this.lblCrusr.TabIndex = 204;
            this.lblCrusr.Text = "建檔人";
            this.lblCrusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreate_by
            // 
            this.txtCreate_by.Enabled = false;
            this.txtCreate_by.Location = new System.Drawing.Point(62, 52);
            this.txtCreate_by.Name = "txtCreate_by";
            this.txtCreate_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCreate_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCreate_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCreate_by.Properties.MaxLength = 20;
            this.txtCreate_by.Properties.ReadOnly = true;
            this.txtCreate_by.Size = new System.Drawing.Size(117, 22);
            this.txtCreate_by.TabIndex = 6;
            this.txtCreate_by.Tag = "2";
            // 
            // lblCrtim
            // 
            this.lblCrtim.Location = new System.Drawing.Point(332, 55);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(61, 13);
            this.lblCrtim.TabIndex = 205;
            this.lblCrtim.Text = "建檔日期";
            this.lblCrtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbgpage1);
            this.tabControl1.Controls.Add(this.tbgpage2);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1016, 709);
            this.tabControl1.TabIndex = 202;
            // 
            // tbgpage1
            // 
            this.tbgpage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbgpage1.Controls.Add(this.panel3);
            this.tbgpage1.Controls.Add(this.panel1);
            this.tbgpage1.Controls.Add(this.gridControl1);
            this.tbgpage1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbgpage1.Location = new System.Drawing.Point(4, 25);
            this.tbgpage1.Name = "tbgpage1";
            this.tbgpage1.Padding = new System.Windows.Forms.Padding(3);
            this.tbgpage1.Size = new System.Drawing.Size(1008, 680);
            this.tbgpage1.TabIndex = 0;
            this.tbgpage1.Text = "數據編輯";
            this.tbgpage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.gridControl2);
            this.panel3.Controls.Add(this.btnDel1);
            this.panel3.Controls.Add(this.btnAdd1);
            this.panel3.Location = new System.Drawing.Point(3, 367);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1000, 309);
            this.panel3.TabIndex = 211;
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.Location = new System.Drawing.Point(4, 34);
            this.gridControl2.MainView = this.dgvDetails_result;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.clTest_item_id,
            this.clsTest_is_pass,
            this.clMemrequire});
            this.gridControl2.Size = new System.Drawing.Size(993, 272);
            this.gridControl2.TabIndex = 69;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetails_result});
            // 
            // dgvDetails_result
            // 
            this.dgvDetails_result.ColumnPanelRowHeight = 30;
            this.dgvDetails_result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sequence_id2,
            this.test_item_id,
            this.test_require,
            this.test_is_pass,
            this.test_result,
            this.details_remark2,
            this.gridColumn1});
            this.dgvDetails_result.GridControl = this.gridControl2;
            this.dgvDetails_result.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.dgvDetails_result.IndicatorWidth = 30;
            this.dgvDetails_result.Name = "dgvDetails_result";
            this.dgvDetails_result.OptionsBehavior.Editable = false;
            this.dgvDetails_result.OptionsCustomization.AllowColumnMoving = false;
            this.dgvDetails_result.OptionsCustomization.AllowFilter = false;
            this.dgvDetails_result.OptionsCustomization.AllowSort = false;
            this.dgvDetails_result.OptionsView.ColumnAutoWidth = false;
            this.dgvDetails_result.OptionsView.ShowGroupPanel = false;
            this.dgvDetails_result.PaintStyleName = "Style3D";
            this.dgvDetails_result.RowHeight = 30;
            this.dgvDetails_result.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.dgvDetails_result.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.dgvDetails_result_CustomDrawCell);
            this.dgvDetails_result.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDetails_result_KeyDown);
            // 
            // sequence_id2
            // 
            this.sequence_id2.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sequence_id2.AppearanceHeader.Options.UseBackColor = true;
            this.sequence_id2.Caption = "序號";
            this.sequence_id2.FieldName = "sequence_id";
            this.sequence_id2.Name = "sequence_id2";
            this.sequence_id2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.sequence_id2.OptionsColumn.AllowMove = false;
            this.sequence_id2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.sequence_id2.OptionsColumn.ReadOnly = true;
            this.sequence_id2.OptionsFilter.AllowAutoFilter = false;
            this.sequence_id2.OptionsFilter.AllowFilter = false;
            this.sequence_id2.Visible = true;
            this.sequence_id2.VisibleIndex = 0;
            this.sequence_id2.Width = 38;
            // 
            // test_item_id
            // 
            this.test_item_id.Caption = "測試項目";
            this.test_item_id.FieldName = "test_item_id";
            this.test_item_id.Name = "test_item_id";
            this.test_item_id.OptionsColumn.AllowMove = false;
            this.test_item_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.test_item_id.OptionsFilter.AllowAutoFilter = false;
            this.test_item_id.OptionsFilter.AllowFilter = false;
            this.test_item_id.Tag = "";
            this.test_item_id.Visible = true;
            this.test_item_id.VisibleIndex = 1;
            this.test_item_id.Width = 256;
            // 
            // test_require
            // 
            this.test_require.Caption = "測試方法和要求";
            this.test_require.ColumnEdit = this.clMemrequire;
            this.test_require.FieldName = "test_require";
            this.test_require.Name = "test_require";
            this.test_require.OptionsColumn.AllowMove = false;
            this.test_require.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.test_require.OptionsFilter.AllowAutoFilter = false;
            this.test_require.OptionsFilter.AllowFilter = false;
            this.test_require.Visible = true;
            this.test_require.VisibleIndex = 2;
            this.test_require.Width = 349;
            // 
            // clMemrequire
            // 
            this.clMemrequire.Name = "clMemrequire";
            // 
            // test_is_pass
            // 
            this.test_is_pass.Caption = "是否合格";
            this.test_is_pass.ColumnEdit = this.clsTest_is_pass;
            this.test_is_pass.FieldName = "test_is_pass";
            this.test_is_pass.Name = "test_is_pass";
            this.test_is_pass.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.test_is_pass.OptionsColumn.AllowMove = false;
            this.test_is_pass.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.test_is_pass.OptionsFilter.AllowAutoFilter = false;
            this.test_is_pass.OptionsFilter.AllowFilter = false;
            this.test_is_pass.Visible = true;
            this.test_is_pass.VisibleIndex = 3;
            this.test_is_pass.Width = 59;
            // 
            // clsTest_is_pass
            // 
            this.clsTest_is_pass.AutoHeight = false;
            this.clsTest_is_pass.Name = "clsTest_is_pass";
            this.clsTest_is_pass.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // test_result
            // 
            this.test_result.Caption = "測試成績";
            this.test_result.FieldName = "test_result";
            this.test_result.Name = "test_result";
            this.test_result.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.test_result.OptionsColumn.AllowMove = false;
            this.test_result.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.test_result.OptionsFilter.AllowAutoFilter = false;
            this.test_result.OptionsFilter.AllowFilter = false;
            this.test_result.Visible = true;
            this.test_result.VisibleIndex = 4;
            this.test_result.Width = 132;
            // 
            // details_remark2
            // 
            this.details_remark2.Caption = "備註";
            this.details_remark2.FieldName = "details_remark2";
            this.details_remark2.Name = "details_remark2";
            this.details_remark2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.details_remark2.OptionsColumn.AllowMove = false;
            this.details_remark2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.details_remark2.OptionsFilter.AllowAutoFilter = false;
            this.details_remark2.OptionsFilter.AllowFilter = false;
            this.details_remark2.Visible = true;
            this.details_remark2.VisibleIndex = 5;
            this.details_remark2.Width = 109;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "編號";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Tag = "2";
            this.gridColumn1.Width = 20;
            // 
            // clTest_item_id
            // 
            this.clTest_item_id.AutoHeight = false;
            this.clTest_item_id.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clTest_item_id.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 250, "cdesc")});
            this.clTest_item_id.DropDownRows = 20;
            this.clTest_item_id.ImmediatePopup = true;
            this.clTest_item_id.MaxLength = 30;
            this.clTest_item_id.Name = "clTest_item_id";
            this.clTest_item_id.NullText = "";
            this.clTest_item_id.PopupWidth = 280;
            this.clTest_item_id.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.clTest_item_id.ShowHeader = false;
            this.clTest_item_id.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // btnDel1
            // 
            this.btnDel1.Enabled = false;
            this.btnDel1.Image = ((System.Drawing.Image)(resources.GetObject("btnDel1.Image")));
            this.btnDel1.Location = new System.Drawing.Point(114, 4);
            this.btnDel1.Name = "btnDel1";
            this.btnDel1.Size = new System.Drawing.Size(65, 27);
            this.btnDel1.TabIndex = 43;
            this.btnDel1.Text = "刪除";
            this.btnDel1.Click += new System.EventHandler(this.btnDel1_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.Enabled = false;
            this.btnAdd1.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd1.Image")));
            this.btnAdd1.Location = new System.Drawing.Point(36, 4);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(64, 27);
            this.btnAdd1.TabIndex = 42;
            this.btnAdd1.Text = "增加";
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // tbgpage2
            // 
            this.tbgpage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbgpage2.Controls.Add(this.panel2);
            this.tbgpage2.Controls.Add(this.dgvFind);
            this.tbgpage2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbgpage2.ImageIndex = 0;
            this.tbgpage2.Location = new System.Drawing.Point(4, 25);
            this.tbgpage2.Name = "tbgpage2";
            this.tbgpage2.Padding = new System.Windows.Forms.Padding(3);
            this.tbgpage2.Size = new System.Drawing.Size(1008, 680);
            this.tbgpage2.TabIndex = 1;
            this.tbgpage2.Text = " 查 詢 ";
            this.tbgpage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.BTNSAVESET);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtMo_id1);
            this.panel2.Controls.Add(this.txtId1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtId2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Controls.Add(this.labelControl3);
            this.panel2.Controls.Add(this.dtDate1);
            this.panel2.Controls.Add(this.dtDate2);
            this.panel2.Location = new System.Drawing.Point(6, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 104);
            this.panel2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 14);
            this.label5.TabIndex = 211;
            this.label5.Text = "頁      數:";
            // 
            // BTNSAVESET
            // 
            this.BTNSAVESET.BackColor = System.Drawing.SystemColors.Control;
            this.BTNSAVESET.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVESET.Image")));
            this.BTNSAVESET.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNSAVESET.Location = new System.Drawing.Point(578, 38);
            this.BTNSAVESET.Name = "BTNSAVESET";
            this.BTNSAVESET.Size = new System.Drawing.Size(116, 33);
            this.BTNSAVESET.TabIndex = 213;
            this.BTNSAVESET.Text = "保存查找條件";
            this.BTNSAVESET.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNSAVESET.UseVisualStyleBackColor = false;
            this.BTNSAVESET.Click += new System.EventHandler(this.BTNSAVESET_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(444, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 33);
            this.btnSearch.TabIndex = 212;
            this.btnSearch.Text = "查  找(&F)";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMo_id1
            // 
            this.txtMo_id1.EditValue = "";
            this.txtMo_id1.EnterMoveNextControl = true;
            this.txtMo_id1.Location = new System.Drawing.Point(117, 14);
            this.txtMo_id1.Name = "txtMo_id1";
            this.txtMo_id1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMo_id1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id1.Properties.MaxLength = 9;
            this.txtMo_id1.Size = new System.Drawing.Size(234, 22);
            this.txtMo_id1.TabIndex = 0;
            // 
            // txtId1
            // 
            this.txtId1.EditValue = "";
            this.txtId1.EnterMoveNextControl = true;
            this.txtId1.Location = new System.Drawing.Point(117, 66);
            this.txtId1.Name = "txtId1";
            this.txtId1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtId1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId1.Properties.MaxLength = 20;
            this.txtId1.Size = new System.Drawing.Size(107, 22);
            this.txtId1.TabIndex = 4;
            this.txtId1.Leave += new System.EventHandler(this.txtId1_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 207;
            this.label4.Text = "入單日期:";
            // 
            // txtId2
            // 
            this.txtId2.EditValue = "";
            this.txtId2.EnterMoveNextControl = true;
            this.txtId2.Location = new System.Drawing.Point(244, 66);
            this.txtId2.Name = "txtId2";
            this.txtId2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtId2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId2.Properties.MaxLength = 20;
            this.txtId2.Size = new System.Drawing.Size(107, 22);
            this.txtId2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 206;
            this.label3.Text = "報告編號:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(230, 67);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(8, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "--";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(229, 40);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(8, 14);
            this.labelControl3.TabIndex = 197;
            this.labelControl3.Text = "--";
            // 
            // dtDate1
            // 
            this.dtDate1.EditValue = "";
            this.dtDate1.EnterMoveNextControl = true;
            this.dtDate1.Location = new System.Drawing.Point(117, 39);
            this.dtDate1.Name = "dtDate1";
            this.dtDate1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate1.Properties.Mask.BeepOnError = true;
            this.dtDate1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dtDate1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDate1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtDate1.Properties.NullDate = "";
            this.dtDate1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDate1.Size = new System.Drawing.Size(107, 22);
            this.dtDate1.TabIndex = 2;
            this.dtDate1.Leave += new System.EventHandler(this.dtDate1_Leave);
            // 
            // dtDate2
            // 
            this.dtDate2.EditValue = "";
            this.dtDate2.EnterMoveNextControl = true;
            this.dtDate2.Location = new System.Drawing.Point(244, 39);
            this.dtDate2.Name = "dtDate2";
            this.dtDate2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtDate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate2.Properties.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.dtDate2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtDate2.Properties.EditFormat.FormatString = "yyyy/MM/dd";
            this.dtDate2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtDate2.Properties.Mask.BeepOnError = true;
            this.dtDate2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dtDate2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDate2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtDate2.Properties.NullDate = "";
            this.dtDate2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDate2.Size = new System.Drawing.Size(107, 22);
            this.dtDate2.TabIndex = 3;
            // 
            // dgvFind
            // 
            this.dgvFind.AllowUserToAddRows = false;
            this.dgvFind.AllowUserToDeleteRows = false;
            this.dgvFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFind.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id1,
            this.con_date1,
            this.customer_id,
            this.customer_name,
            this.remark1,
            this.sequence_id1,
            this.item_no1,
            this.contents1,
            this.details_remark1});
            this.dgvFind.Location = new System.Drawing.Point(4, 108);
            this.dgvFind.Name = "dgvFind";
            this.dgvFind.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFind.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFind.RowHeadersWidth = 20;
            this.dgvFind.RowTemplate.Height = 24;
            this.dgvFind.Size = new System.Drawing.Size(997, 562);
            this.dgvFind.TabIndex = 5;
            this.dgvFind.SelectionChanged += new System.EventHandler(this.dgvFind_SelectionChanged);
            // 
            // id1
            // 
            this.id1.DataPropertyName = "id";
            this.id1.HeaderText = "單據編號";
            this.id1.Name = "id1";
            this.id1.ReadOnly = true;
            this.id1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id1.Width = 105;
            // 
            // con_date1
            // 
            this.con_date1.DataPropertyName = "con_date";
            this.con_date1.HeaderText = "入單日期";
            this.con_date1.Name = "con_date1";
            this.con_date1.ReadOnly = true;
            this.con_date1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.con_date1.Width = 80;
            // 
            // customer_id
            // 
            this.customer_id.DataPropertyName = "customer_id";
            this.customer_id.HeaderText = "客戶編號";
            this.customer_id.Name = "customer_id";
            this.customer_id.ReadOnly = true;
            this.customer_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.customer_id.Width = 70;
            // 
            // customer_name
            // 
            this.customer_name.DataPropertyName = "customer_name";
            this.customer_name.HeaderText = "客戶名稱";
            this.customer_name.Name = "customer_name";
            this.customer_name.ReadOnly = true;
            this.customer_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.customer_name.Width = 150;
            // 
            // remark1
            // 
            this.remark1.DataPropertyName = "remark";
            this.remark1.HeaderText = "備註";
            this.remark1.Name = "remark1";
            this.remark1.ReadOnly = true;
            this.remark1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.remark1.Visible = false;
            this.remark1.Width = 150;
            // 
            // sequence_id1
            // 
            this.sequence_id1.DataPropertyName = "sequence_id";
            this.sequence_id1.HeaderText = "序號";
            this.sequence_id1.Name = "sequence_id1";
            this.sequence_id1.ReadOnly = true;
            this.sequence_id1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sequence_id1.Width = 50;
            // 
            // item_no1
            // 
            this.item_no1.DataPropertyName = "item_no";
            this.item_no1.HeaderText = "產品測試項目";
            this.item_no1.Name = "item_no1";
            this.item_no1.ReadOnly = true;
            this.item_no1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.item_no1.Width = 160;
            // 
            // contents1
            // 
            this.contents1.DataPropertyName = "contents";
            this.contents1.HeaderText = "內容";
            this.contents1.Name = "contents1";
            this.contents1.ReadOnly = true;
            this.contents1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.contents1.Width = 200;
            // 
            // details_remark1
            // 
            this.details_remark1.DataPropertyName = "details_remark";
            this.details_remark1.HeaderText = "明細資料備註";
            this.details_remark1.Name = "details_remark1";
            this.details_remark1.ReadOnly = true;
            this.details_remark1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.details_remark1.Width = 150;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "tb_query.png");
            // 
            // frmQcTestReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "frmQcTestReport";
            this.Text = "frmQcTestReport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQcTestReport_FormClosed);
            this.Load += new System.EventHandler(this.frmQcTestReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clItem_no)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcon_date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcon_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecustomer_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memremark.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtcontact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomer_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMostly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDetail)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tbgpage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clMemrequire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsTest_is_pass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clTest_item_id)).EndInit();
            this.tbgpage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDetail_result)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetails;
        private DevExpress.XtraGrid.Columns.GridColumn contents;
        private DevExpress.XtraGrid.Columns.GridColumn item_no;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn sequence_id;
        private System.Windows.Forms.Label lblorder_date;
        private DevExpress.XtraEditors.DateEdit dtcon_date;
        private DevExpress.XtraEditors.LookUpEdit luecustomer_id;
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
        private DevExpress.XtraGrid.Columns.GridColumn details_remark;
        private System.Windows.Forms.BindingSource bdsMostly;
        private System.Windows.Forms.BindingSource bdsDetail;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbgpage1;
        private System.Windows.Forms.TabPage tbgpage2;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtMo_id1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dtDate2;
        private DevExpress.XtraEditors.DateEdit dtDate1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtId2;
        private DevExpress.XtraEditors.TextEdit txtId1;
        private System.Windows.Forms.DataGridView dgvFind;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button BTNSAVESET;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.TextEdit txtcontact;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtcustomer_name;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetails_result;
        private DevExpress.XtraGrid.Columns.GridColumn test_item_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit clTest_item_id;
        private DevExpress.XtraGrid.Columns.GridColumn test_require;
        private DevExpress.XtraGrid.Columns.GridColumn details_remark2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn sequence_id2;
        private DevExpress.XtraEditors.SimpleButton btnDel1;
        private DevExpress.XtraEditors.SimpleButton btnAdd1;
        private System.Windows.Forms.BindingSource bdsDetail_result;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit clItem_no;
        private DevExpress.XtraGrid.Columns.GridColumn test_result;
        private DevExpress.XtraGrid.Columns.GridColumn test_is_pass;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit clsTest_is_pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn con_date1;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequence_id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_no1;
        private System.Windows.Forms.DataGridViewTextBoxColumn contents1;
        private System.Windows.Forms.DataGridViewTextBoxColumn details_remark1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit clMemrequire;
    }
}