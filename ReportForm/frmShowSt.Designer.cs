namespace cf01.ReportForm
{
    partial class frmShowSt
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtStBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSet = new cf01.SqlDataSet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbNomal = new System.Windows.Forms.RadioButton();
            this.txtGoods_id = new System.Windows.Forms.TextBox();
            this.txtMt = new System.Windows.Forms.TextBox();
            this.txtLot_no2 = new System.Windows.Forms.TextBox();
            this.txtMo_id2 = new System.Windows.Forms.TextBox();
            this.txtLot_no1 = new System.Windows.Forms.TextBox();
            this.txtMo_id1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDept2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDept1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIn_date1 = new DevExpress.XtraEditors.DateEdit();
            this.txtIn_date2 = new DevExpress.XtraEditors.DateEdit();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clArtwork = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnArtWork = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.loc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carton_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sec_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.in_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picture_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExcel1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRecords = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPro = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtArtwork = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtStBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIn_date1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIn_date1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIn_date2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIn_date2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clArtwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dtStBindingSource
            // 
            this.dtStBindingSource.DataMember = "dtSt";
            this.dtStBindingSource.DataSource = this.sqlDataSet;
            // 
            // sqlDataSet
            // 
            this.sqlDataSet.DataSetName = "SqlDataSet";
            this.sqlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNFIND,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1013, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.AutoSize = false;
            this.BTNEXIT.Image = global::cf01.Properties.Resources.exit;
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(49, 30);
            this.BTNEXIT.Text = "退出";
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = global::cf01.Properties.Resources.find;
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(49, 30);
            this.BTNFIND.Text = "查詢";
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(844, 28);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(47, 16);
            this.rbAll.TabIndex = 25;
            this.rbAll.Text = "所有";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.Visible = false;
            // 
            // rbNomal
            // 
            this.rbNomal.AutoSize = true;
            this.rbNomal.Checked = true;
            this.rbNomal.Location = new System.Drawing.Point(791, 28);
            this.rbNomal.Name = "rbNomal";
            this.rbNomal.Size = new System.Drawing.Size(47, 16);
            this.rbNomal.TabIndex = 24;
            this.rbNomal.TabStop = true;
            this.rbNomal.Text = "正常";
            this.rbNomal.UseVisualStyleBackColor = true;
            this.rbNomal.Visible = false;
            // 
            // txtGoods_id
            // 
            this.txtGoods_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGoods_id.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGoods_id.Location = new System.Drawing.Point(397, 35);
            this.txtGoods_id.MaxLength = 18;
            this.txtGoods_id.Name = "txtGoods_id";
            this.txtGoods_id.Size = new System.Drawing.Size(211, 23);
            this.txtGoods_id.TabIndex = 21;
            this.txtGoods_id.Leave += new System.EventHandler(this.txtGoods_id_Leave);
            // 
            // txtMt
            // 
            this.txtMt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMt.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMt.Location = new System.Drawing.Point(397, 74);
            this.txtMt.MaxLength = 2;
            this.txtMt.Name = "txtMt";
            this.txtMt.Size = new System.Drawing.Size(43, 23);
            this.txtMt.TabIndex = 6;
            // 
            // txtLot_no2
            // 
            this.txtLot_no2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLot_no2.Location = new System.Drawing.Point(198, 101);
            this.txtLot_no2.MaxLength = 20;
            this.txtLot_no2.Name = "txtLot_no2";
            this.txtLot_no2.Size = new System.Drawing.Size(114, 22);
            this.txtLot_no2.TabIndex = 5;
            // 
            // txtMo_id2
            // 
            this.txtMo_id2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id2.Location = new System.Drawing.Point(198, 74);
            this.txtMo_id2.MaxLength = 9;
            this.txtMo_id2.Name = "txtMo_id2";
            this.txtMo_id2.Size = new System.Drawing.Size(114, 22);
            this.txtMo_id2.TabIndex = 3;
            // 
            // txtLot_no1
            // 
            this.txtLot_no1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLot_no1.Location = new System.Drawing.Point(72, 101);
            this.txtLot_no1.MaxLength = 20;
            this.txtLot_no1.Name = "txtLot_no1";
            this.txtLot_no1.Size = new System.Drawing.Size(114, 22);
            this.txtLot_no1.TabIndex = 4;
            this.txtLot_no1.Leave += new System.EventHandler(this.txtLot_no1_Leave);
            // 
            // txtMo_id1
            // 
            this.txtMo_id1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id1.Location = new System.Drawing.Point(73, 74);
            this.txtMo_id1.MaxLength = 9;
            this.txtMo_id1.Name = "txtMo_id1";
            this.txtMo_id1.Size = new System.Drawing.Size(114, 22);
            this.txtMo_id1.TabIndex = 2;
            this.txtMo_id1.Leave += new System.EventHandler(this.txtMo_id1_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "貨品編號:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "倉存記錄:";
            this.label5.Visible = false;
            // 
            // txtDept2
            // 
            this.txtDept2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDept2.Location = new System.Drawing.Point(198, 46);
            this.txtDept2.MaxLength = 3;
            this.txtDept2.Name = "txtDept2";
            this.txtDept2.Size = new System.Drawing.Size(114, 22);
            this.txtDept2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "批號:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "制單編號:";
            // 
            // txtDept1
            // 
            this.txtDept1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDept1.Location = new System.Drawing.Point(72, 46);
            this.txtDept1.MaxLength = 3;
            this.txtDept1.Name = "txtDept1";
            this.txtDept1.Size = new System.Drawing.Size(114, 22);
            this.txtDept1.TabIndex = 0;
            this.txtDept1.Leave += new System.EventHandler(this.txtDept1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "倉庫號:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(337, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "入倉日期:";
            // 
            // txtIn_date1
            // 
            this.txtIn_date1.EditValue = null;
            this.txtIn_date1.EnterMoveNextControl = true;
            this.txtIn_date1.Location = new System.Drawing.Point(397, 101);
            this.txtIn_date1.Name = "txtIn_date1";
            this.txtIn_date1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtIn_date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtIn_date1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtIn_date1.Properties.Mask.BeepOnError = true;
            this.txtIn_date1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtIn_date1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtIn_date1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtIn_date1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtIn_date1.Size = new System.Drawing.Size(147, 20);
            this.txtIn_date1.TabIndex = 11;
            this.txtIn_date1.Tag = "2";
            this.txtIn_date1.Leave += new System.EventHandler(this.txtIn_date1_Leave);
            // 
            // txtIn_date2
            // 
            this.txtIn_date2.EditValue = null;
            this.txtIn_date2.EnterMoveNextControl = true;
            this.txtIn_date2.Location = new System.Drawing.Point(554, 101);
            this.txtIn_date2.Name = "txtIn_date2";
            this.txtIn_date2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtIn_date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtIn_date2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtIn_date2.Properties.Mask.BeepOnError = true;
            this.txtIn_date2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtIn_date2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtIn_date2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtIn_date2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtIn_date2.Size = new System.Drawing.Size(156, 20);
            this.txtIn_date2.TabIndex = 12;
            this.txtIn_date2.Tag = "2";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(397, 127);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "電鍍"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "克胚")});
            this.radioGroup1.Size = new System.Drawing.Size(156, 23);
            this.radioGroup1.TabIndex = 30;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(5, 156);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.clArtwork});
            this.gridControl1.Size = new System.Drawing.Size(1003, 391);
            this.gridControl1.TabIndex = 31;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "Style3D";
            this.gridView1.RowHeight = 25;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "倉號";
            this.gridColumn1.FieldName = "loc_id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 52;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "頁數";
            this.gridColumn2.FieldName = "mo_id";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 104;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "貨品編號";
            this.gridColumn3.FieldName = "goods_id";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 160;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "貨品名稱";
            this.gridColumn4.FieldName = "goods_name";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn4.OptionsFilter.AllowFilter = false;
            this.gridColumn4.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 208;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "批號";
            this.gridColumn5.FieldName = "lot_no";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 88;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "貨架位置";
            this.gridColumn6.FieldName = "carton_code";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 107;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "數量";
            this.gridColumn7.FieldName = "qty";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowMove = false;
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn7.OptionsFilter.AllowFilter = false;
            this.gridColumn7.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "重量";
            this.gridColumn8.FieldName = "sec_qty";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowMove = false;
            this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn8.OptionsFilter.AllowFilter = false;
            this.gridColumn8.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "圖樣";
            this.gridColumn9.ColumnEdit = this.clArtwork;
            this.gridColumn9.FieldName = "artwork";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowMove = false;
            this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn9.OptionsFilter.AllowFilter = false;
            this.gridColumn9.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 87;
            // 
            // clArtwork
            // 
            this.clArtwork.Appearance.Options.UseTextOptions = true;
            this.clArtwork.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clArtwork.Name = "clArtwork";
            this.clArtwork.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "圖樣路徑";
            this.gridColumn10.FieldName = "picture_name";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn10.OptionsFilter.AllowFilter = false;
            this.gridColumn10.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "入倉日期";
            this.gridColumn11.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn11.FieldName = "in_date";
            this.gridColumn11.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            // 
            // btnArtWork
            // 
            this.btnArtWork.Image = global::cf01.Properties.Resources.Excel1;
            this.btnArtWork.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArtWork.Location = new System.Drawing.Point(735, 81);
            this.btnArtWork.Name = "btnArtWork";
            this.btnArtWork.Size = new System.Drawing.Size(137, 39);
            this.btnArtWork.TabIndex = 32;
            this.btnArtWork.Text = " 匯出Excel有圖樣";
            this.btnArtWork.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArtWork.UseVisualStyleBackColor = true;
            this.btnArtWork.Click += new System.EventHandler(this.btnArtWork_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Enabled = false;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dtStBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "cf01.Reports.rdlSt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(5, 431);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(270, 90);
            this.reportViewer1.TabIndex = 34;
            this.reportViewer1.Visible = false;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loc_id,
            this.mo_id,
            this.goods_id,
            this.goods_name,
            this.carton_code,
            this.lot_no,
            this.qty,
            this.sec_qty,
            this.in_date,
            this.picture_name});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetails.Location = new System.Drawing.Point(5, 457);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersWidth = 30;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(865, 90);
            this.dgvDetails.TabIndex = 11;
            this.dgvDetails.Visible = false;
            // 
            // loc_id
            // 
            this.loc_id.DataPropertyName = "loc_id";
            this.loc_id.HeaderText = "倉號";
            this.loc_id.Name = "loc_id";
            this.loc_id.ReadOnly = true;
            this.loc_id.Width = 80;
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            this.mo_id.HeaderText = "頁數";
            this.mo_id.Name = "mo_id";
            this.mo_id.ReadOnly = true;
            // 
            // goods_id
            // 
            this.goods_id.DataPropertyName = "goods_id";
            this.goods_id.HeaderText = "貨品編號";
            this.goods_id.Name = "goods_id";
            this.goods_id.ReadOnly = true;
            this.goods_id.Width = 150;
            // 
            // goods_name
            // 
            this.goods_name.DataPropertyName = "goods_name";
            this.goods_name.HeaderText = "貨品名稱";
            this.goods_name.Name = "goods_name";
            this.goods_name.ReadOnly = true;
            this.goods_name.Width = 200;
            // 
            // carton_code
            // 
            this.carton_code.DataPropertyName = "carton_code";
            this.carton_code.HeaderText = "貨架位置";
            this.carton_code.Name = "carton_code";
            this.carton_code.ReadOnly = true;
            // 
            // lot_no
            // 
            this.lot_no.DataPropertyName = "lot_no";
            this.lot_no.HeaderText = "批號";
            this.lot_no.Name = "lot_no";
            this.lot_no.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.HeaderText = "數量";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // sec_qty
            // 
            this.sec_qty.DataPropertyName = "sec_qty";
            this.sec_qty.HeaderText = "重量";
            this.sec_qty.Name = "sec_qty";
            this.sec_qty.ReadOnly = true;
            // 
            // in_date
            // 
            this.in_date.DataPropertyName = "in_date";
            this.in_date.HeaderText = "入倉日期";
            this.in_date.Name = "in_date";
            this.in_date.ReadOnly = true;
            // 
            // picture_name
            // 
            this.picture_name.DataPropertyName = "picture_name";
            this.picture_name.HeaderText = "圖樣";
            this.picture_name.Name = "picture_name";
            this.picture_name.ReadOnly = true;
            this.picture_name.Visible = false;
            // 
            // btnExcel1
            // 
            this.btnExcel1.Location = new System.Drawing.Point(881, 81);
            this.btnExcel1.Name = "btnExcel1";
            this.btnExcel1.Size = new System.Drawing.Size(111, 39);
            this.btnExcel1.TabIndex = 35;
            this.btnExcel1.Text = " 匯出Excel無圖樣";
            this.btnExcel1.UseVisualStyleBackColor = true;
            this.btnExcel1.Click += new System.EventHandler(this.btnExcel1_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(791, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 26);
            this.button1.TabIndex = 36;
            this.button1.Text = "Rdc Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRecords
            // 
            this.txtRecords.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRecords.ForeColor = System.Drawing.Color.Blue;
            this.txtRecords.Location = new System.Drawing.Point(72, 126);
            this.txtRecords.MaxLength = 20;
            this.txtRecords.Name = "txtRecords";
            this.txtRecords.ReadOnly = true;
            this.txtRecords.Size = new System.Drawing.Size(60, 25);
            this.txtRecords.TabIndex = 37;
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(398, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(325, 17);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 38;
            this.progressBar1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(401, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "1~2位";
            // 
            // txtPro
            // 
            this.txtPro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPro.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPro.Location = new System.Drawing.Point(447, 74);
            this.txtPro.MaxLength = 2;
            this.txtPro.Name = "txtPro";
            this.txtPro.Size = new System.Drawing.Size(43, 23);
            this.txtPro.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(450, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 41;
            this.label8.Text = "3~4位";
            // 
            // txtArtwork
            // 
            this.txtArtwork.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArtwork.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtArtwork.Location = new System.Drawing.Point(496, 74);
            this.txtArtwork.MaxLength = 7;
            this.txtArtwork.Name = "txtArtwork";
            this.txtArtwork.Size = new System.Drawing.Size(102, 23);
            this.txtArtwork.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(496, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 12);
            this.label9.TabIndex = 43;
            this.label9.Text = "ArtWork(7位圖樣)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(602, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 12);
            this.label10.TabIndex = 45;
            this.label10.Text = "Size(尺寸)";
            // 
            // txtSize
            // 
            this.txtSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSize.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSize.Location = new System.Drawing.Point(604, 74);
            this.txtSize.MaxLength = 3;
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(52, 23);
            this.txtSize.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(671, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 47;
            this.label11.Text = "顏色";
            // 
            // txtColor
            // 
            this.txtColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColor.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtColor.Location = new System.Drawing.Point(662, 74);
            this.txtColor.MaxLength = 4;
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(48, 23);
            this.txtColor.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(337, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 12);
            this.label12.TabIndex = 48;
            this.label12.Text = "貨品編號:";
            // 
            // frmShowSt
            // 
            this.ClientSize = new System.Drawing.Size(1013, 550);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtArtwork);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtRecords);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExcel1);
            this.Controls.Add(this.btnArtWork);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.txtIn_date2);
            this.Controls.Add(this.txtIn_date1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.rbNomal);
            this.Controls.Add(this.txtGoods_id);
            this.Controls.Add(this.txtMt);
            this.Controls.Add(this.txtLot_no2);
            this.Controls.Add(this.txtMo_id2);
            this.Controls.Add(this.txtLot_no1);
            this.Controls.Add(this.txtMo_id1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDept2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDept1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmShowSt";
            ((System.ComponentModel.ISupportInitialize)(this.dtStBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIn_date1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIn_date1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIn_date2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIn_date2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clArtwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbNomal;
        private System.Windows.Forms.TextBox txtGoods_id;
        private System.Windows.Forms.TextBox txtMt;
        private System.Windows.Forms.TextBox txtLot_no2;
        private System.Windows.Forms.TextBox txtMo_id2;
        private System.Windows.Forms.TextBox txtLot_no1;
        private System.Windows.Forms.TextBox txtMo_id1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDept2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDept1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.DateEdit txtIn_date1;
        private DevExpress.XtraEditors.DateEdit txtIn_date2;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit clArtwork;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private System.Windows.Forms.Button btnArtWork;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SqlDataSet sqlDataSet;
        private System.Windows.Forms.BindingSource dtStBindingSource;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button btnExcel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtRecords;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtArtwork;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtColor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn loc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn carton_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn sec_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn in_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn picture_name;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.Label label12;

      
    }
}
