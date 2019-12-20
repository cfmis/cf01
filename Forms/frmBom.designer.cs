namespace cf01.Forms
{
    partial class frmBom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBom));
            this.myImageList = new System.Windows.Forms.ImageList(this.components);
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.Panel = new System.Windows.Forms.Panel();
            this.tabBom = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.goods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_goods_id = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dosage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_dosage = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.base_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_base_qty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.unit_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_unit_code = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.goods_bom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.log_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exp_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblCheck_dat = new System.Windows.Forms.Label();
            this.lblCheck_by = new System.Windows.Forms.Label();
            this.txtCheck_dat = new DevExpress.XtraEditors.TextEdit();
            this.txtCheck_by = new DevExpress.XtraEditors.TextEdit();
            this.lblAmtim = new System.Windows.Forms.Label();
            this.lblAmusr = new System.Windows.Forms.Label();
            this.lblCrtim = new System.Windows.Forms.Label();
            this.lblCrusr = new System.Windows.Forms.Label();
            this.txtAmtim = new DevExpress.XtraEditors.TextEdit();
            this.txtAmusr = new DevExpress.XtraEditors.TextEdit();
            this.txtCrtim = new DevExpress.XtraEditors.TextEdit();
            this.txtCrusr = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.txtGen_bom_id = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtColor_effect = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPlate_effect = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDo_color = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnit_code = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtState = new DevExpress.XtraEditors.TextEdit();
            this.txtExp_id = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picArt_code = new System.Windows.Forms.PictureBox();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtGoods_id = new DevExpress.XtraEditors.ButtonEdit();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.txtDetp_id = new DevExpress.XtraEditors.LookUpEdit();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNEDIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNDELETE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNITEMADD = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNITEMDEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNAPPROVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNCOPY = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNPRINT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnl_left = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel.SuspendLayout();
            this.tabBom.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_goods_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_dosage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_base_qty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_unit_code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_dat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmtim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmusr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrusr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGen_bom_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor_effect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlate_effect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDo_color.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit_code.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExp_id.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArt_code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetp_id.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pnl_left.SuspendLayout();
            this.SuspendLayout();
            // 
            // myImageList
            // 
            this.myImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("myImageList.ImageStream")));
            this.myImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.myImageList.Images.SetKeyName(0, "model.png");
            this.myImageList.Images.SetKeyName(1, "file3.png");
            // 
            // TreeView1
            // 
            this.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView1.ImageIndex = 0;
            this.TreeView1.ImageList = this.myImageList;
            this.TreeView1.Indent = 16;
            this.TreeView1.Location = new System.Drawing.Point(0, 0);
            this.TreeView1.Name = "TreeView1";
            this.TreeView1.SelectedImageIndex = 0;
            this.TreeView1.ShowRootLines = false;
            this.TreeView1.Size = new System.Drawing.Size(246, 733);
            this.TreeView1.TabIndex = 0;
            this.TreeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeSelect);
            this.TreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.tabBom);
            this.Panel.Controls.Add(this.toolStrip1);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(248, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(906, 733);
            this.Panel.TabIndex = 20;
            // 
            // tabBom
            // 
            this.tabBom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBom.Controls.Add(this.tabPage1);
            this.tabBom.Controls.Add(this.tabPage2);
            this.tabBom.Location = new System.Drawing.Point(3, 41);
            this.tabBom.Name = "tabBom";
            this.tabBom.SelectedIndex = 0;
            this.tabBom.Size = new System.Drawing.Size(902, 690);
            this.tabBom.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.gridControl1);
            this.tabPage1.Controls.Add(this.lblCheck_dat);
            this.tabPage1.Controls.Add(this.lblCheck_by);
            this.tabPage1.Controls.Add(this.txtCheck_dat);
            this.tabPage1.Controls.Add(this.txtCheck_by);
            this.tabPage1.Controls.Add(this.lblAmtim);
            this.tabPage1.Controls.Add(this.lblAmusr);
            this.tabPage1.Controls.Add(this.lblCrtim);
            this.tabPage1.Controls.Add(this.lblCrusr);
            this.tabPage1.Controls.Add(this.txtAmtim);
            this.tabPage1.Controls.Add(this.txtAmusr);
            this.tabPage1.Controls.Add(this.txtCrtim);
            this.tabPage1.Controls.Add(this.txtCrusr);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtRemark);
            this.tabPage1.Controls.Add(this.txtGen_bom_id);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtColor_effect);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtPlate_effect);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtDo_color);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtUnit_code);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtState);
            this.tabPage1.Controls.Add(this.txtExp_id);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblID);
            this.tabPage1.Controls.Add(this.txtGoods_id);
            this.tabPage1.Controls.Add(this.txtID);
            this.tabPage1.Controls.Add(this.txtDetp_id);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(894, 664);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "標準BOM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(2, 269);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.col_goods_id,
            this.col_dosage,
            this.col_base_qty,
            this.col_unit_code});
            this.gridControl1.Size = new System.Drawing.Size(882, 391);
            this.gridControl1.TabIndex = 93;
            this.gridControl1.Tag = "2";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.goods_id,
            this.name,
            this.dosage,
            this.base_qty,
            this.unit_code,
            this.goods_bom,
            this.remark,
            this.log_no,
            this.exp_id,
            this.sequence_id});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "Style3D";
            this.gridView1.Tag = "2";
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // goods_id
            // 
            this.goods_id.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.goods_id.AppearanceHeader.Options.UseForeColor = true;
            this.goods_id.Caption = "貨品編號";
            this.goods_id.ColumnEdit = this.col_goods_id;
            this.goods_id.FieldName = "goods_id";
            this.goods_id.MaxWidth = 180;
            this.goods_id.Name = "goods_id";
            this.goods_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.goods_id.OptionsFilter.AllowAutoFilter = false;
            this.goods_id.OptionsFilter.AllowFilter = false;
            this.goods_id.Tag = "1";
            this.goods_id.Visible = true;
            this.goods_id.VisibleIndex = 0;
            this.goods_id.Width = 171;
            // 
            // col_goods_id
            // 
            this.col_goods_id.AutoHeight = false;
            this.col_goods_id.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.col_goods_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.col_goods_id.MaxLength = 18;
            this.col_goods_id.Name = "col_goods_id";
            this.col_goods_id.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.col_goods_id_ButtonClick);
            this.col_goods_id.Leave += new System.EventHandler(this.col_goods_id_Leave);
            // 
            // name
            // 
            this.name.Caption = "貨品名稱";
            this.name.FieldName = "name";
            this.name.MaxWidth = 250;
            this.name.Name = "name";
            this.name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.name.OptionsColumn.ReadOnly = true;
            this.name.OptionsFilter.AllowAutoFilter = false;
            this.name.OptionsFilter.AllowFilter = false;
            this.name.Tag = "1";
            this.name.Visible = true;
            this.name.VisibleIndex = 1;
            this.name.Width = 205;
            // 
            // dosage
            // 
            this.dosage.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.dosage.AppearanceHeader.Options.UseForeColor = true;
            this.dosage.Caption = "用量";
            this.dosage.ColumnEdit = this.col_dosage;
            this.dosage.FieldName = "dosage";
            this.dosage.MaxWidth = 150;
            this.dosage.Name = "dosage";
            this.dosage.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.dosage.OptionsFilter.AllowAutoFilter = false;
            this.dosage.OptionsFilter.AllowFilter = false;
            this.dosage.Tag = "1";
            this.dosage.Visible = true;
            this.dosage.VisibleIndex = 2;
            this.dosage.Width = 60;
            // 
            // col_dosage
            // 
            this.col_dosage.AutoHeight = false;
            this.col_dosage.DisplayFormat.FormatString = "N3";
            this.col_dosage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_dosage.EditFormat.FormatString = "N3";
            this.col_dosage.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_dosage.Mask.EditMask = "n3";
            this.col_dosage.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.col_dosage.Name = "col_dosage";
            this.col_dosage.NullText = "0.000";
            this.col_dosage.Click += new System.EventHandler(this.col_dosage_Click);
            // 
            // base_qty
            // 
            this.base_qty.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.base_qty.AppearanceHeader.Options.UseForeColor = true;
            this.base_qty.Caption = "基數";
            this.base_qty.ColumnEdit = this.col_base_qty;
            this.base_qty.FieldName = "base_qty";
            this.base_qty.MaxWidth = 300;
            this.base_qty.Name = "base_qty";
            this.base_qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.base_qty.OptionsFilter.AllowAutoFilter = false;
            this.base_qty.OptionsFilter.AllowFilter = false;
            this.base_qty.Tag = "1";
            this.base_qty.Visible = true;
            this.base_qty.VisibleIndex = 3;
            this.base_qty.Width = 48;
            // 
            // col_base_qty
            // 
            this.col_base_qty.AutoHeight = false;
            this.col_base_qty.Mask.EditMask = "d";
            this.col_base_qty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.col_base_qty.Name = "col_base_qty";
            this.col_base_qty.NullText = "0";
            this.col_base_qty.NullValuePrompt = "0";
            this.col_base_qty.Click += new System.EventHandler(this.col_base_qty_Click);
            // 
            // unit_code
            // 
            this.unit_code.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.unit_code.AppearanceHeader.Options.UseForeColor = true;
            this.unit_code.Caption = "單位";
            this.unit_code.ColumnEdit = this.col_unit_code;
            this.unit_code.FieldName = "unit_code";
            this.unit_code.Name = "unit_code";
            this.unit_code.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.unit_code.OptionsFilter.AllowAutoFilter = false;
            this.unit_code.OptionsFilter.AllowFilter = false;
            this.unit_code.Visible = true;
            this.unit_code.VisibleIndex = 4;
            this.unit_code.Width = 49;
            // 
            // col_unit_code
            // 
            this.col_unit_code.AutoHeight = false;
            this.col_unit_code.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.col_unit_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.col_unit_code.MaxLength = 3;
            this.col_unit_code.Name = "col_unit_code";
            this.col_unit_code.NullText = "";
            this.col_unit_code.ShowHeader = false;
            this.col_unit_code.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // goods_bom
            // 
            this.goods_bom.Caption = "子層BOM_ID";
            this.goods_bom.FieldName = "goods_bom";
            this.goods_bom.Name = "goods_bom";
            this.goods_bom.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.goods_bom.OptionsFilter.AllowAutoFilter = false;
            this.goods_bom.OptionsFilter.AllowFilter = false;
            this.goods_bom.Visible = true;
            this.goods_bom.VisibleIndex = 5;
            this.goods_bom.Width = 201;
            // 
            // remark
            // 
            this.remark.Caption = "備註";
            this.remark.FieldName = "remark";
            this.remark.Name = "remark";
            this.remark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.remark.OptionsFilter.AllowAutoFilter = false;
            this.remark.OptionsFilter.AllowFilter = false;
            this.remark.Visible = true;
            this.remark.VisibleIndex = 6;
            this.remark.Width = 115;
            // 
            // log_no
            // 
            this.log_no.Caption = "序號";
            this.log_no.FieldName = "log_no";
            this.log_no.Name = "log_no";
            // 
            // exp_id
            // 
            this.exp_id.Caption = "版本";
            this.exp_id.FieldName = "exp_id";
            this.exp_id.Name = "exp_id";
            // 
            // sequence_id
            // 
            this.sequence_id.Caption = "gridColumn1";
            this.sequence_id.FieldName = "sequence_id";
            this.sequence_id.Name = "sequence_id";
            // 
            // lblCheck_dat
            // 
            this.lblCheck_dat.Location = new System.Drawing.Point(255, 243);
            this.lblCheck_dat.Name = "lblCheck_dat";
            this.lblCheck_dat.Size = new System.Drawing.Size(59, 13);
            this.lblCheck_dat.TabIndex = 92;
            this.lblCheck_dat.Text = "批準日期";
            this.lblCheck_dat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCheck_by
            // 
            this.lblCheck_by.Location = new System.Drawing.Point(5, 243);
            this.lblCheck_by.Name = "lblCheck_by";
            this.lblCheck_by.Size = new System.Drawing.Size(63, 13);
            this.lblCheck_by.TabIndex = 91;
            this.lblCheck_by.Text = "批準人";
            this.lblCheck_by.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCheck_dat
            // 
            this.txtCheck_dat.Enabled = false;
            this.txtCheck_dat.Location = new System.Drawing.Point(314, 240);
            this.txtCheck_dat.Name = "txtCheck_dat";
            this.txtCheck_dat.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCheck_dat.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCheck_dat.Properties.ReadOnly = true;
            this.txtCheck_dat.Size = new System.Drawing.Size(128, 20);
            this.txtCheck_dat.TabIndex = 90;
            this.txtCheck_dat.Tag = "2";
            // 
            // txtCheck_by
            // 
            this.txtCheck_by.Enabled = false;
            this.txtCheck_by.Location = new System.Drawing.Point(70, 240);
            this.txtCheck_by.Name = "txtCheck_by";
            this.txtCheck_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCheck_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCheck_by.Properties.ReadOnly = true;
            this.txtCheck_by.Size = new System.Drawing.Size(139, 20);
            this.txtCheck_by.TabIndex = 89;
            this.txtCheck_by.Tag = "2";
            // 
            // lblAmtim
            // 
            this.lblAmtim.Location = new System.Drawing.Point(253, 218);
            this.lblAmtim.Name = "lblAmtim";
            this.lblAmtim.Size = new System.Drawing.Size(61, 13);
            this.lblAmtim.TabIndex = 40;
            this.lblAmtim.Text = "修改日期";
            this.lblAmtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmusr
            // 
            this.lblAmusr.Location = new System.Drawing.Point(6, 218);
            this.lblAmusr.Name = "lblAmusr";
            this.lblAmusr.Size = new System.Drawing.Size(62, 13);
            this.lblAmusr.TabIndex = 39;
            this.lblAmusr.Text = "修改人";
            this.lblAmusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCrtim
            // 
            this.lblCrtim.Location = new System.Drawing.Point(257, 197);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(57, 13);
            this.lblCrtim.TabIndex = 38;
            this.lblCrtim.Text = "建檔日期";
            this.lblCrtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCrusr
            // 
            this.lblCrusr.Location = new System.Drawing.Point(4, 197);
            this.lblCrusr.Name = "lblCrusr";
            this.lblCrusr.Size = new System.Drawing.Size(64, 13);
            this.lblCrusr.TabIndex = 37;
            this.lblCrusr.Text = "建檔人";
            this.lblCrusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmtim
            // 
            this.txtAmtim.Enabled = false;
            this.txtAmtim.Location = new System.Drawing.Point(314, 216);
            this.txtAmtim.Name = "txtAmtim";
            this.txtAmtim.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtAmtim.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtAmtim.Properties.ReadOnly = true;
            this.txtAmtim.Size = new System.Drawing.Size(128, 20);
            this.txtAmtim.TabIndex = 36;
            this.txtAmtim.Tag = "2";
            // 
            // txtAmusr
            // 
            this.txtAmusr.Enabled = false;
            this.txtAmusr.Location = new System.Drawing.Point(70, 216);
            this.txtAmusr.Name = "txtAmusr";
            this.txtAmusr.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtAmusr.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtAmusr.Properties.ReadOnly = true;
            this.txtAmusr.Size = new System.Drawing.Size(139, 20);
            this.txtAmusr.TabIndex = 35;
            this.txtAmusr.Tag = "2";
            // 
            // txtCrtim
            // 
            this.txtCrtim.Enabled = false;
            this.txtCrtim.Location = new System.Drawing.Point(314, 192);
            this.txtCrtim.Name = "txtCrtim";
            this.txtCrtim.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCrtim.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCrtim.Properties.ReadOnly = true;
            this.txtCrtim.Size = new System.Drawing.Size(128, 20);
            this.txtCrtim.TabIndex = 34;
            this.txtCrtim.Tag = "2";
            // 
            // txtCrusr
            // 
            this.txtCrusr.Enabled = false;
            this.txtCrusr.Location = new System.Drawing.Point(70, 192);
            this.txtCrusr.Name = "txtCrusr";
            this.txtCrusr.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCrusr.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCrusr.Properties.ReadOnly = true;
            this.txtCrusr.Size = new System.Drawing.Size(139, 20);
            this.txtCrusr.TabIndex = 33;
            this.txtCrusr.Tag = "2";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(5, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "備 註";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(70, 148);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtRemark.Properties.LinesCount = 3;
            this.txtRemark.Properties.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(372, 41);
            this.txtRemark.TabIndex = 3;
            this.txtRemark.Tag = "2";
            // 
            // txtGen_bom_id
            // 
            this.txtGen_bom_id.EnterMoveNextControl = true;
            this.txtGen_bom_id.Location = new System.Drawing.Point(316, 76);
            this.txtGen_bom_id.Name = "txtGen_bom_id";
            this.txtGen_bom_id.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtGen_bom_id.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtGen_bom_id.Properties.ReadOnly = true;
            this.txtGen_bom_id.Size = new System.Drawing.Size(126, 20);
            this.txtGen_bom_id.TabIndex = 2;
            this.txtGen_bom_id.Tag = "2";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(251, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "損耗方案";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(5, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "做色效果";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtColor_effect
            // 
            this.txtColor_effect.Enabled = false;
            this.txtColor_effect.Location = new System.Drawing.Point(70, 124);
            this.txtColor_effect.Name = "txtColor_effect";
            this.txtColor_effect.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtColor_effect.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtColor_effect.Size = new System.Drawing.Size(372, 20);
            this.txtColor_effect.TabIndex = 20;
            this.txtColor_effect.Tag = "2";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "電鍍效果";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPlate_effect
            // 
            this.txtPlate_effect.Enabled = false;
            this.txtPlate_effect.Location = new System.Drawing.Point(70, 100);
            this.txtPlate_effect.Name = "txtPlate_effect";
            this.txtPlate_effect.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtPlate_effect.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtPlate_effect.Size = new System.Drawing.Size(372, 20);
            this.txtPlate_effect.TabIndex = 18;
            this.txtPlate_effect.Tag = "2";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "顏色做法";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDo_color
            // 
            this.txtDo_color.Enabled = false;
            this.txtDo_color.Location = new System.Drawing.Point(70, 52);
            this.txtDo_color.Name = "txtDo_color";
            this.txtDo_color.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtDo_color.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtDo_color.Properties.ReadOnly = true;
            this.txtDo_color.Size = new System.Drawing.Size(372, 20);
            this.txtDo_color.TabIndex = 16;
            this.txtDo_color.Tag = "2";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(476, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "基本單位";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUnit_code
            // 
            this.txtUnit_code.Enabled = false;
            this.txtUnit_code.Location = new System.Drawing.Point(541, 52);
            this.txtUnit_code.Name = "txtUnit_code";
            this.txtUnit_code.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtUnit_code.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtUnit_code.Size = new System.Drawing.Size(138, 20);
            this.txtUnit_code.TabIndex = 14;
            this.txtUnit_code.Tag = "2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(476, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "狀態";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtState
            // 
            this.txtState.Enabled = false;
            this.txtState.Location = new System.Drawing.Point(541, 4);
            this.txtState.Name = "txtState";
            this.txtState.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtState.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtState.Size = new System.Drawing.Size(138, 20);
            this.txtState.TabIndex = 12;
            this.txtState.Tag = "2";
            // 
            // txtExp_id
            // 
            this.txtExp_id.Enabled = false;
            this.txtExp_id.Location = new System.Drawing.Point(249, 4);
            this.txtExp_id.Name = "txtExp_id";
            this.txtExp_id.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtExp_id.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtExp_id.Size = new System.Drawing.Size(30, 20);
            this.txtExp_id.TabIndex = 11;
            this.txtExp_id.Tag = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picArt_code);
            this.groupBox1.Location = new System.Drawing.Point(685, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 173);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // picArt_code
            // 
            this.picArt_code.Location = new System.Drawing.Point(4, 10);
            this.picArt_code.Name = "picArt_code";
            this.picArt_code.Size = new System.Drawing.Size(158, 158);
            this.picArt_code.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picArt_code.TabIndex = 76;
            this.picArt_code.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(248, 28);
            this.txtName.Name = "txtName";
            this.txtName.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtName.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtName.Size = new System.Drawing.Size(431, 20);
            this.txtName.TabIndex = 9;
            this.txtName.Tag = "2";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(5, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "部門編號";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "貨品編號";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblID
            // 
            this.lblID.ForeColor = System.Drawing.Color.Blue;
            this.lblID.Location = new System.Drawing.Point(5, 6);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(64, 17);
            this.lblID.TabIndex = 5;
            this.lblID.Text = "編號";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGoods_id
            // 
            this.txtGoods_id.EnterMoveNextControl = true;
            this.txtGoods_id.Location = new System.Drawing.Point(70, 28);
            this.txtGoods_id.Name = "txtGoods_id";
            this.txtGoods_id.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtGoods_id.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtGoods_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtGoods_id.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtGoods_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGoods_id.Properties.MaxLength = 18;
            this.txtGoods_id.Properties.ReadOnly = true;
            this.txtGoods_id.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtGoods_id_Properties_ButtonClick);
            this.txtGoods_id.Size = new System.Drawing.Size(177, 20);
            this.txtGoods_id.TabIndex = 0;
            this.txtGoods_id.Tag = "2";
            this.txtGoods_id.Leave += new System.EventHandler(this.txtGoods_id_Leave);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.EnterMoveNextControl = true;
            this.txtID.Location = new System.Drawing.Point(70, 4);
            this.txtID.Name = "txtID";
            this.txtID.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtID.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtID.Size = new System.Drawing.Size(177, 20);
            this.txtID.TabIndex = 3;
            this.txtID.Tag = "";
            // 
            // txtDetp_id
            // 
            this.txtDetp_id.EditValue = "";
            this.txtDetp_id.Enabled = false;
            this.txtDetp_id.EnterMoveNextControl = true;
            this.txtDetp_id.Location = new System.Drawing.Point(70, 76);
            this.txtDetp_id.Name = "txtDetp_id";
            this.txtDetp_id.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtDetp_id.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtDetp_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDetp_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetp_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_id", 80, "部門"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_cdesc", 150, "名稱")});
            this.txtDetp_id.Properties.DropDownRows = 15;
            this.txtDetp_id.Properties.MaxLength = 3;
            this.txtDetp_id.Properties.NullText = "";
            this.txtDetp_id.Properties.PopupFormMinSize = new System.Drawing.Size(230, 0);
            this.txtDetp_id.Properties.PopupWidth = 230;
            this.txtDetp_id.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtDetp_id.Size = new System.Drawing.Size(177, 20);
            this.txtDetp_id.TabIndex = 1;
            this.txtDetp_id.Tag = "2";
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(894, 664);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNNEW,
            this.toolStripSeparator5,
            this.BTNEDIT,
            this.toolStripSeparator10,
            this.BTNDELETE,
            this.toolStripSeparator9,
            this.BTNITEMADD,
            this.toolStripSeparator2,
            this.BTNITEMDEL,
            this.toolStripSeparator6,
            this.BTNSAVE,
            this.toolStripSeparator3,
            this.BTNCANCEL,
            this.toolStripSeparator4,
            this.BTNAPPROVE,
            this.toolStripSeparator11,
            this.BTNCOPY,
            this.toolStripSeparator7,
            this.BTNPRINT,
            this.toolStripSeparator8,
            this.BTNFIND});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(906, 38);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.AutoSize = false;
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(49, 35);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNNEW
            // 
            this.BTNNEW.Image = ((System.Drawing.Image)(resources.GetObject("BTNNEW.Image")));
            this.BTNNEW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNNEW.Name = "BTNNEW";
            this.BTNNEW.Size = new System.Drawing.Size(49, 35);
            this.BTNNEW.Text = "新增(&N)";
            this.BTNNEW.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.BTNNEW.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNNEW.Click += new System.EventHandler(this.BTNNEW_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNEDIT
            // 
            this.BTNEDIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEDIT.Image")));
            this.BTNEDIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEDIT.Name = "BTNEDIT";
            this.BTNEDIT.Size = new System.Drawing.Size(48, 35);
            this.BTNEDIT.Text = "編輯(&E)";
            this.BTNEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNEDIT.Click += new System.EventHandler(this.BTNEDIT_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNDELETE
            // 
            this.BTNDELETE.Image = ((System.Drawing.Image)(resources.GetObject("BTNDELETE.Image")));
            this.BTNDELETE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNDELETE.Name = "BTNDELETE";
            this.BTNDELETE.Size = new System.Drawing.Size(49, 35);
            this.BTNDELETE.Text = "刪除(&D)";
            this.BTNDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNDELETE.Click += new System.EventHandler(this.BTNDELETE_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNITEMADD
            // 
            this.BTNITEMADD.Enabled = false;
            this.BTNITEMADD.Image = ((System.Drawing.Image)(resources.GetObject("BTNITEMADD.Image")));
            this.BTNITEMADD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNITEMADD.Name = "BTNITEMADD";
            this.BTNITEMADD.Size = new System.Drawing.Size(73, 35);
            this.BTNITEMADD.Text = "項目增加(&A)";
            this.BTNITEMADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNITEMADD.Click += new System.EventHandler(this.BTNITEMADD_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNITEMDEL
            // 
            this.BTNITEMDEL.Enabled = false;
            this.BTNITEMDEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNITEMDEL.Image")));
            this.BTNITEMDEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNITEMDEL.Name = "BTNITEMDEL";
            this.BTNITEMDEL.Size = new System.Drawing.Size(72, 35);
            this.BTNITEMDEL.Text = "項目刪除(&L)";
            this.BTNITEMDEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNITEMDEL.Click += new System.EventHandler(this.BTNITEMDEL_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNSAVE
            // 
            this.BTNSAVE.Enabled = false;
            this.BTNSAVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVE.Image")));
            this.BTNSAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVE.Name = "BTNSAVE";
            this.BTNSAVE.Size = new System.Drawing.Size(47, 35);
            this.BTNSAVE.Text = "保存(&S)";
            this.BTNSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNCANCEL
            // 
            this.BTNCANCEL.Enabled = false;
            this.BTNCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNCANCEL.Image")));
            this.BTNCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCANCEL.Name = "BTNCANCEL";
            this.BTNCANCEL.Size = new System.Drawing.Size(49, 35);
            this.BTNCANCEL.Text = "取消(&U)";
            this.BTNCANCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNCANCEL.Click += new System.EventHandler(this.BTNCANCEL_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNAPPROVE
            // 
            this.BTNAPPROVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNAPPROVE.Image")));
            this.BTNAPPROVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNAPPROVE.Name = "BTNAPPROVE";
            this.BTNAPPROVE.Size = new System.Drawing.Size(49, 35);
            this.BTNAPPROVE.Tag = "\"0\"";
            this.BTNAPPROVE.Text = "批準(&C)";
            this.BTNAPPROVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNAPPROVE.Click += new System.EventHandler(this.BTNAPPROVE_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNCOPY
            // 
            this.BTNCOPY.Image = ((System.Drawing.Image)(resources.GetObject("BTNCOPY.Image")));
            this.BTNCOPY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCOPY.Name = "BTNCOPY";
            this.BTNCOPY.Size = new System.Drawing.Size(49, 35);
            this.BTNCOPY.Text = "複制(&C)";
            this.BTNCOPY.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNPRINT
            // 
            this.BTNPRINT.Image = ((System.Drawing.Image)(resources.GetObject("BTNPRINT.Image")));
            this.BTNPRINT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNPRINT.Name = "BTNPRINT";
            this.BTNPRINT.Size = new System.Drawing.Size(47, 35);
            this.BTNPRINT.Text = "列印(&P)";
            this.BTNPRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(47, 35);
            this.BTNFIND.Text = "查詢(&F)";
            this.BTNFIND.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(246, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 733);
            this.splitter1.TabIndex = 19;
            this.splitter1.TabStop = false;
            // 
            // pnl_left
            // 
            this.pnl_left.Controls.Add(this.TreeView1);
            this.pnl_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_left.Location = new System.Drawing.Point(0, 0);
            this.pnl_left.Name = "pnl_left";
            this.pnl_left.Size = new System.Drawing.Size(246, 733);
            this.pnl_left.TabIndex = 18;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "cdesc";
            this.dataGridViewTextBoxColumn2.HeaderText = "名稱";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "desc";
            this.dataGridViewTextBoxColumn3.HeaderText = "英文名稱";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "rmk";
            this.dataGridViewTextBoxColumn4.HeaderText = "備註";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "amusr";
            this.dataGridViewTextBoxColumn7.HeaderText = "修改人";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "crtim";
            this.dataGridViewTextBoxColumn6.HeaderText = "建檔日期";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "crusr";
            this.dataGridViewTextBoxColumn5.HeaderText = "建檔人";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "amtim";
            this.dataGridViewTextBoxColumn8.HeaderText = "修改日期";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // frmBom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 733);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnl_left);
            this.Name = "frmBom";
            this.Text = "frmBom";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBom_FormClosed);
            this.Load += new System.EventHandler(this.frmBom_Load);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.tabBom.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_goods_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_dosage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_base_qty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_unit_code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_dat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmtim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmusr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrusr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGen_bom_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor_effect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlate_effect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDo_color.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit_code.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExp_id.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picArt_code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetp_id.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnl_left.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ImageList myImageList;
        private System.Windows.Forms.TreeView TreeView1;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnl_left;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        //private DevExpress.XtraGrid.Views.Grid.GridView gridView3; //allen
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton BTNEDIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton BTNDELETE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton BTNITEMADD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BTNITEMDEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BTNAPPROVE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton BTNCOPY;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton BTNPRINT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.TabControl tabBom;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraEditors.LookUpEdit txtDetp_id;
        private DevExpress.XtraEditors.ButtonEdit txtGoods_id;
        private DevExpress.XtraEditors.TextEdit txtID;
        private System.Windows.Forms.Label lblID;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtGen_bom_id;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtColor_effect;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtPlate_effect;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtDo_color;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtUnit_code;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtState;
        private DevExpress.XtraEditors.TextEdit txtExp_id;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picArt_code;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAmtim;
        private System.Windows.Forms.Label lblAmusr;
        private System.Windows.Forms.Label lblCrtim;
        private System.Windows.Forms.Label lblCrusr;
        private DevExpress.XtraEditors.TextEdit txtAmtim;
        private DevExpress.XtraEditors.TextEdit txtAmusr;
        private DevExpress.XtraEditors.TextEdit txtCrtim;
        private DevExpress.XtraEditors.TextEdit txtCrusr;
        private System.Windows.Forms.Label lblCheck_dat;
        private System.Windows.Forms.Label lblCheck_by;
        private DevExpress.XtraEditors.TextEdit txtCheck_dat;
        private DevExpress.XtraEditors.TextEdit txtCheck_by;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn goods_id;
        private DevExpress.XtraGrid.Columns.GridColumn name;
        private DevExpress.XtraGrid.Columns.GridColumn dosage;
        private DevExpress.XtraGrid.Columns.GridColumn base_qty;
        private DevExpress.XtraGrid.Columns.GridColumn unit_code;
        private DevExpress.XtraGrid.Columns.GridColumn goods_bom;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit col_goods_id;
        private DevExpress.XtraGrid.Columns.GridColumn remark;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit col_dosage;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit col_base_qty;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit col_unit_code;
        private DevExpress.XtraGrid.Columns.GridColumn log_no;
        private DevExpress.XtraGrid.Columns.GridColumn exp_id;
        private DevExpress.XtraGrid.Columns.GridColumn sequence_id;
    }
}