namespace cf01.Forms
{
    partial class frmButtonWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmButtonWork));
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
            this.group_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.work_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.work_time_normal_s = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTime_range = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.work_time_normal_e = new DevExpress.XtraGrid.Columns.GridColumn();
            this.workers_normal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.work_time_overtime_s = new DevExpress.XtraGrid.Columns.GridColumn();
            this.work_time_overtime_e = new DevExpress.XtraGrid.Columns.GridColumn();
            this.workers_overtime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.running_machines = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qty_total = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInteger = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.details_remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblorder_date = new System.Windows.Forms.Label();
            this.dtcon_date = new DevExpress.XtraEditors.DateEdit();
            this.luedepartment_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lbldepartment_id = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.memremark = new DevExpress.XtraEditors.MemoEdit();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbgpage1 = new System.Windows.Forms.TabPage();
            this.tbgpage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.BTNSAVESET = new System.Windows.Forms.Button();
            this.txtDept2 = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtDept1 = new DevExpress.XtraEditors.TextEdit();
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
            this.department_id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department_name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sequence_id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_type1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.work_date1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.work_time_normal_s1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.work_time_normal_e1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workers_normal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.work_time_overtime_s1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.work_time_overtime_e1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workers_overtime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.running_machines1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_total1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.details_remark1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clTime_range)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clInteger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcon_date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcon_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedepartment_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memremark.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMostly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDetail)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbgpage1.SuspendLayout();
            this.tbgpage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTemp_code
            // 
            this.lblTemp_code.ForeColor = System.Drawing.Color.Blue;
            this.lblTemp_code.Location = new System.Drawing.Point(255, 8);
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
            this.txtID.Location = new System.Drawing.Point(306, 5);
            this.txtID.Name = "txtID";
            this.txtID.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtID.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Properties.MaxLength = 20;
            this.txtID.Properties.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(192, 22);
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
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(2, 123);
            this.gridControl1.MainView = this.dgvDetails;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.clTime_range,
            this.clInteger,
            this.clDate});
            this.gridControl1.Size = new System.Drawing.Size(1001, 553);
            this.gridControl1.TabIndex = 68;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetails});
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnPanelRowHeight = 30;
            this.dgvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sequence_id,
            this.group_type,
            this.work_date,
            this.work_time_normal_s,
            this.work_time_normal_e,
            this.workers_normal,
            this.work_time_overtime_s,
            this.work_time_overtime_e,
            this.workers_overtime,
            this.running_machines,
            this.qty_total,
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
            this.dgvDetails.RowHeight = 30;
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
            this.sequence_id.Width = 36;
            // 
            // group_type
            // 
            this.group_type.Caption = "車間(組別工種)";
            this.group_type.FieldName = "group_type";
            this.group_type.Name = "group_type";
            this.group_type.OptionsColumn.AllowMove = false;
            this.group_type.OptionsColumn.AllowSize = false;
            this.group_type.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.group_type.OptionsFilter.AllowAutoFilter = false;
            this.group_type.OptionsFilter.AllowFilter = false;
            this.group_type.Visible = true;
            this.group_type.VisibleIndex = 1;
            this.group_type.Width = 171;
            // 
            // work_date
            // 
            this.work_date.Caption = "工作日期";
            this.work_date.ColumnEdit = this.clDate;
            this.work_date.DisplayFormat.FormatString = "DateTime \"yyyy-MM-dd\"";
            this.work_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.work_date.FieldName = "work_date";
            this.work_date.Name = "work_date";
            this.work_date.OptionsColumn.AllowMove = false;
            this.work_date.OptionsColumn.AllowSize = false;
            this.work_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.work_date.OptionsFilter.AllowAutoFilter = false;
            this.work_date.OptionsFilter.AllowFilter = false;
            this.work_date.Visible = true;
            this.work_date.VisibleIndex = 2;
            this.work_date.Width = 88;
            // 
            // clDate
            // 
            this.clDate.AutoHeight = false;
            this.clDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.clDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clDate.EditFormat.FormatString = "yyyy-MM-dd";
            this.clDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clDate.Mask.EditMask = "yyyy-MM-dd";
            this.clDate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.clDate.Name = "clDate";
            this.clDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // work_time_normal_s
            // 
            this.work_time_normal_s.Caption = "正常班時段(起)";
            this.work_time_normal_s.ColumnEdit = this.clTime_range;
            this.work_time_normal_s.FieldName = "work_time_normal_s";
            this.work_time_normal_s.Name = "work_time_normal_s";
            this.work_time_normal_s.OptionsColumn.AllowMove = false;
            this.work_time_normal_s.OptionsColumn.AllowSize = false;
            this.work_time_normal_s.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.work_time_normal_s.OptionsFilter.AllowAutoFilter = false;
            this.work_time_normal_s.OptionsFilter.AllowFilter = false;
            this.work_time_normal_s.Visible = true;
            this.work_time_normal_s.VisibleIndex = 3;
            this.work_time_normal_s.Width = 97;
            // 
            // clTime_range
            // 
            this.clTime_range.AutoHeight = false;
            this.clTime_range.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.clTime_range.Mask.EditMask = "90:00";
            this.clTime_range.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.clTime_range.MaxLength = 5;
            this.clTime_range.Name = "clTime_range";
            // 
            // work_time_normal_e
            // 
            this.work_time_normal_e.Caption = "正常班時段(止)";
            this.work_time_normal_e.ColumnEdit = this.clTime_range;
            this.work_time_normal_e.FieldName = "work_time_normal_e";
            this.work_time_normal_e.Name = "work_time_normal_e";
            this.work_time_normal_e.OptionsColumn.AllowMove = false;
            this.work_time_normal_e.OptionsColumn.AllowSize = false;
            this.work_time_normal_e.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.work_time_normal_e.OptionsFilter.AllowAutoFilter = false;
            this.work_time_normal_e.OptionsFilter.AllowFilter = false;
            this.work_time_normal_e.Visible = true;
            this.work_time_normal_e.VisibleIndex = 4;
            this.work_time_normal_e.Width = 95;
            // 
            // workers_normal
            // 
            this.workers_normal.Caption = "人次(正常班)";
            this.workers_normal.FieldName = "workers_normal";
            this.workers_normal.Name = "workers_normal";
            this.workers_normal.OptionsColumn.AllowMove = false;
            this.workers_normal.OptionsColumn.AllowSize = false;
            this.workers_normal.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.workers_normal.OptionsFilter.AllowAutoFilter = false;
            this.workers_normal.OptionsFilter.AllowFilter = false;
            this.workers_normal.Visible = true;
            this.workers_normal.VisibleIndex = 5;
            this.workers_normal.Width = 85;
            // 
            // work_time_overtime_s
            // 
            this.work_time_overtime_s.Caption = "加班時段(起)";
            this.work_time_overtime_s.ColumnEdit = this.clTime_range;
            this.work_time_overtime_s.FieldName = "work_time_overtime_s";
            this.work_time_overtime_s.Name = "work_time_overtime_s";
            this.work_time_overtime_s.OptionsColumn.AllowMove = false;
            this.work_time_overtime_s.OptionsColumn.AllowSize = false;
            this.work_time_overtime_s.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.work_time_overtime_s.OptionsFilter.AllowAutoFilter = false;
            this.work_time_overtime_s.OptionsFilter.AllowFilter = false;
            this.work_time_overtime_s.Visible = true;
            this.work_time_overtime_s.VisibleIndex = 6;
            this.work_time_overtime_s.Width = 82;
            // 
            // work_time_overtime_e
            // 
            this.work_time_overtime_e.Caption = "加班時段(始)";
            this.work_time_overtime_e.ColumnEdit = this.clTime_range;
            this.work_time_overtime_e.FieldName = "work_time_overtime_e";
            this.work_time_overtime_e.Name = "work_time_overtime_e";
            this.work_time_overtime_e.OptionsColumn.AllowMove = false;
            this.work_time_overtime_e.OptionsColumn.AllowSize = false;
            this.work_time_overtime_e.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.work_time_overtime_e.OptionsFilter.AllowAutoFilter = false;
            this.work_time_overtime_e.OptionsFilter.AllowFilter = false;
            this.work_time_overtime_e.Visible = true;
            this.work_time_overtime_e.VisibleIndex = 7;
            this.work_time_overtime_e.Width = 81;
            // 
            // workers_overtime
            // 
            this.workers_overtime.Caption = "人次(加班)";
            this.workers_overtime.FieldName = "workers_overtime";
            this.workers_overtime.Name = "workers_overtime";
            this.workers_overtime.OptionsColumn.AllowMove = false;
            this.workers_overtime.OptionsColumn.AllowSize = false;
            this.workers_overtime.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.workers_overtime.OptionsFilter.AllowAutoFilter = false;
            this.workers_overtime.OptionsFilter.AllowFilter = false;
            this.workers_overtime.Visible = true;
            this.workers_overtime.VisibleIndex = 8;
            this.workers_overtime.Width = 82;
            // 
            // running_machines
            // 
            this.running_machines.Caption = "開機臺數";
            this.running_machines.FieldName = "running_machines";
            this.running_machines.Name = "running_machines";
            this.running_machines.OptionsColumn.AllowMove = false;
            this.running_machines.OptionsColumn.AllowSize = false;
            this.running_machines.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.running_machines.OptionsFilter.AllowAutoFilter = false;
            this.running_machines.OptionsFilter.AllowFilter = false;
            this.running_machines.Visible = true;
            this.running_machines.VisibleIndex = 9;
            this.running_machines.Width = 73;
            // 
            // qty_total
            // 
            this.qty_total.Caption = "生產總數量(PCS)";
            this.qty_total.ColumnEdit = this.clInteger;
            this.qty_total.FieldName = "qty_total";
            this.qty_total.Name = "qty_total";
            this.qty_total.OptionsColumn.AllowMove = false;
            this.qty_total.OptionsColumn.AllowSize = false;
            this.qty_total.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.qty_total.OptionsFilter.AllowAutoFilter = false;
            this.qty_total.OptionsFilter.AllowFilter = false;
            this.qty_total.Visible = true;
            this.qty_total.VisibleIndex = 10;
            this.qty_total.Width = 101;
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
            // details_remark
            // 
            this.details_remark.Caption = "其它備註";
            this.details_remark.FieldName = "details_remark";
            this.details_remark.Name = "details_remark";
            this.details_remark.OptionsColumn.AllowMove = false;
            this.details_remark.OptionsColumn.AllowSize = false;
            this.details_remark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.details_remark.OptionsFilter.AllowAutoFilter = false;
            this.details_remark.OptionsFilter.AllowFilter = false;
            this.details_remark.Visible = true;
            this.details_remark.VisibleIndex = 11;
            this.details_remark.Width = 126;
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
            this.lblorder_date.Location = new System.Drawing.Point(502, 8);
            this.lblorder_date.Name = "lblorder_date";
            this.lblorder_date.Size = new System.Drawing.Size(60, 13);
            this.lblorder_date.TabIndex = 120;
            this.lblorder_date.Text = "入單日期";
            this.lblorder_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtcon_date
            // 
            this.dtcon_date.EditValue = "";
            this.dtcon_date.Enabled = false;
            this.dtcon_date.EnterMoveNextControl = true;
            this.dtcon_date.Location = new System.Drawing.Point(565, 5);
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
            this.dtcon_date.Size = new System.Drawing.Size(149, 22);
            this.dtcon_date.TabIndex = 3;
            this.dtcon_date.Tag = "2";
            // 
            // luedepartment_id
            // 
            this.luedepartment_id.EditValue = "";
            this.luedepartment_id.Enabled = false;
            this.luedepartment_id.EnterMoveNextControl = true;
            this.luedepartment_id.Location = new System.Drawing.Point(72, 5);
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
            this.lbldepartment_id.Location = new System.Drawing.Point(9, 8);
            this.lbldepartment_id.Name = "lbldepartment_id";
            this.lbldepartment_id.Size = new System.Drawing.Size(60, 13);
            this.lbldepartment_id.TabIndex = 180;
            this.lbldepartment_id.Text = "部門";
            this.lbldepartment_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(9, 28);
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
            this.memremark.Location = new System.Drawing.Point(72, 30);
            this.memremark.Name = "memremark";
            this.memremark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.memremark.Properties.MaxLength = 250;
            this.memremark.Properties.ReadOnly = true;
            this.memremark.Size = new System.Drawing.Size(426, 50);
            this.memremark.TabIndex = 5;
            this.memremark.Tag = "2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTemp_code);
            this.panel1.Controls.Add(this.lblAmtim);
            this.panel1.Controls.Add(this.txtupdate_date);
            this.panel1.Controls.Add(this.lblAmusr);
            this.panel1.Controls.Add(this.txtupdate_by);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.lblCrtim);
            this.panel1.Controls.Add(this.dtcon_date);
            this.panel1.Controls.Add(this.txtCreate_date);
            this.panel1.Controls.Add(this.lblCrusr);
            this.panel1.Controls.Add(this.lblorder_date);
            this.panel1.Controls.Add(this.txtCreate_by);
            this.panel1.Controls.Add(this.luedepartment_id);
            this.panel1.Controls.Add(this.memremark);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.lbldepartment_id);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 116);
            this.panel1.TabIndex = 201;
            // 
            // lblAmtim
            // 
            this.lblAmtim.Location = new System.Drawing.Point(751, 87);
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
            this.txtupdate_date.Location = new System.Drawing.Point(814, 83);
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
            this.lblAmusr.Location = new System.Drawing.Point(512, 87);
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
            this.txtupdate_by.Location = new System.Drawing.Point(563, 83);
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
            this.lblCrtim.Location = new System.Drawing.Point(227, 87);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(77, 13);
            this.lblCrtim.TabIndex = 205;
            this.lblCrtim.Text = "建檔日期";
            this.lblCrtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreate_date
            // 
            this.txtCreate_date.Enabled = false;
            this.txtCreate_date.Location = new System.Drawing.Point(306, 83);
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
            this.lblCrusr.Location = new System.Drawing.Point(9, 87);
            this.lblCrusr.Name = "lblCrusr";
            this.lblCrusr.Size = new System.Drawing.Size(60, 13);
            this.lblCrusr.TabIndex = 204;
            this.lblCrusr.Text = "建檔人";
            this.lblCrusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreate_by
            // 
            this.txtCreate_by.Enabled = false;
            this.txtCreate_by.Location = new System.Drawing.Point(72, 83);
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
            this.panel2.Controls.Add(this.labelControl4);
            this.panel2.Controls.Add(this.BTNSAVESET);
            this.panel2.Controls.Add(this.txtDept2);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtDept1);
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
            this.label5.Text = "部門編號:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(235, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(8, 14);
            this.labelControl4.TabIndex = 210;
            this.labelControl4.Text = "--";
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
            // txtDept2
            // 
            this.txtDept2.EditValue = "";
            this.txtDept2.EnterMoveNextControl = true;
            this.txtDept2.Location = new System.Drawing.Point(258, 14);
            this.txtDept2.Name = "txtDept2";
            this.txtDept2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDept2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDept2.Properties.MaxLength = 3;
            this.txtDept2.Size = new System.Drawing.Size(107, 22);
            this.txtDept2.TabIndex = 1;
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
            // txtDept1
            // 
            this.txtDept1.EditValue = "";
            this.txtDept1.EnterMoveNextControl = true;
            this.txtDept1.Location = new System.Drawing.Point(117, 14);
            this.txtDept1.Name = "txtDept1";
            this.txtDept1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDept1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDept1.Properties.MaxLength = 3;
            this.txtDept1.Size = new System.Drawing.Size(107, 22);
            this.txtDept1.TabIndex = 0;
            this.txtDept1.Leave += new System.EventHandler(this.txtDept1_Leave);
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
            this.txtId2.Location = new System.Drawing.Point(258, 66);
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
            this.label3.Text = "單據編號:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(236, 67);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(8, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "--";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(235, 40);
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
            this.dtDate2.Location = new System.Drawing.Point(258, 39);
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
            this.department_id1,
            this.department_name1,
            this.sequence_id1,
            this.group_type1,
            this.work_date1,
            this.work_time_normal_s1,
            this.work_time_normal_e1,
            this.workers_normal1,
            this.work_time_overtime_s1,
            this.work_time_overtime_e1,
            this.workers_overtime1,
            this.running_machines1,
            this.qty_total1,
            this.details_remark1,
            this.remark1});
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
            // department_id1
            // 
            this.department_id1.DataPropertyName = "department_id";
            this.department_id1.HeaderText = "部門";
            this.department_id1.Name = "department_id1";
            this.department_id1.ReadOnly = true;
            this.department_id1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.department_id1.Width = 50;
            // 
            // department_name1
            // 
            this.department_name1.DataPropertyName = "department_name";
            this.department_name1.HeaderText = "部門名稱";
            this.department_name1.Name = "department_name1";
            this.department_name1.ReadOnly = true;
            this.department_name1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.department_name1.Width = 80;
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
            // group_type1
            // 
            this.group_type1.DataPropertyName = "group_type";
            this.group_type1.HeaderText = "車間組別工種";
            this.group_type1.Name = "group_type1";
            this.group_type1.ReadOnly = true;
            this.group_type1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.group_type1.Width = 130;
            // 
            // work_date1
            // 
            this.work_date1.DataPropertyName = "work_date";
            this.work_date1.HeaderText = "工作日期";
            this.work_date1.Name = "work_date1";
            this.work_date1.ReadOnly = true;
            this.work_date1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.work_date1.Width = 80;
            // 
            // work_time_normal_s1
            // 
            this.work_time_normal_s1.DataPropertyName = "work_time_normal_s";
            this.work_time_normal_s1.HeaderText = "上班時段(起)";
            this.work_time_normal_s1.Name = "work_time_normal_s1";
            this.work_time_normal_s1.ReadOnly = true;
            this.work_time_normal_s1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.work_time_normal_s1.Width = 60;
            // 
            // work_time_normal_e1
            // 
            this.work_time_normal_e1.DataPropertyName = "work_time_normal_e";
            this.work_time_normal_e1.HeaderText = "上班時段(止)";
            this.work_time_normal_e1.Name = "work_time_normal_e1";
            this.work_time_normal_e1.ReadOnly = true;
            this.work_time_normal_e1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.work_time_normal_e1.Width = 60;
            // 
            // workers_normal1
            // 
            this.workers_normal1.DataPropertyName = "workers_normal";
            this.workers_normal1.HeaderText = "人次(加班)";
            this.workers_normal1.Name = "workers_normal1";
            this.workers_normal1.ReadOnly = true;
            this.workers_normal1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.workers_normal1.Width = 80;
            // 
            // work_time_overtime_s1
            // 
            this.work_time_overtime_s1.DataPropertyName = "work_time_overtime_s";
            this.work_time_overtime_s1.HeaderText = "加班時段(起)";
            this.work_time_overtime_s1.Name = "work_time_overtime_s1";
            this.work_time_overtime_s1.ReadOnly = true;
            this.work_time_overtime_s1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.work_time_overtime_s1.Width = 60;
            // 
            // work_time_overtime_e1
            // 
            this.work_time_overtime_e1.DataPropertyName = "work_time_overtime_e";
            this.work_time_overtime_e1.HeaderText = "加班時段(止)";
            this.work_time_overtime_e1.Name = "work_time_overtime_e1";
            this.work_time_overtime_e1.ReadOnly = true;
            this.work_time_overtime_e1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.work_time_overtime_e1.Width = 60;
            // 
            // workers_overtime1
            // 
            this.workers_overtime1.DataPropertyName = "workers_overtime";
            this.workers_overtime1.HeaderText = "人次(加班)";
            this.workers_overtime1.Name = "workers_overtime1";
            this.workers_overtime1.ReadOnly = true;
            this.workers_overtime1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.workers_overtime1.Width = 80;
            // 
            // running_machines1
            // 
            this.running_machines1.DataPropertyName = "running_machines";
            this.running_machines1.HeaderText = "開機數量";
            this.running_machines1.Name = "running_machines1";
            this.running_machines1.ReadOnly = true;
            this.running_machines1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.running_machines1.Width = 80;
            // 
            // qty_total1
            // 
            this.qty_total1.DataPropertyName = "qty_total";
            this.qty_total1.HeaderText = "生產總數";
            this.qty_total1.Name = "qty_total1";
            this.qty_total1.ReadOnly = true;
            this.qty_total1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.qty_total1.Width = 80;
            // 
            // details_remark1
            // 
            this.details_remark1.DataPropertyName = "details_remark";
            this.details_remark1.HeaderText = "明細資料備註";
            this.details_remark1.Name = "details_remark1";
            this.details_remark1.ReadOnly = true;
            this.details_remark1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // remark1
            // 
            this.remark1.DataPropertyName = "remark";
            this.remark1.HeaderText = "備註";
            this.remark1.Name = "remark1";
            this.remark1.ReadOnly = true;
            this.remark1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.remark1.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "tb_query.png");
            // 
            // frmButtonWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "frmButtonWork";
            this.Text = "frmButtonWork";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmButtonWork_FormClosed);
            this.Load += new System.EventHandler(this.frmButtonWork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clTime_range)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clInteger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcon_date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcon_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedepartment_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memremark.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMostly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDetail)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tbgpage1.ResumeLayout(false);
            this.tbgpage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn workers_normal;
        private DevExpress.XtraGrid.Columns.GridColumn work_time_overtime_s;
        private DevExpress.XtraGrid.Columns.GridColumn work_date;
        private DevExpress.XtraGrid.Columns.GridColumn qty_total;
        private DevExpress.XtraGrid.Columns.GridColumn work_time_normal_s;
        private DevExpress.XtraGrid.Columns.GridColumn workers_overtime;
        private DevExpress.XtraGrid.Columns.GridColumn group_type;
        private DevExpress.XtraGrid.Columns.GridColumn running_machines;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn sequence_id;
        private System.Windows.Forms.Label lblorder_date;
        private DevExpress.XtraEditors.DateEdit dtcon_date;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit clTime_range;
        private DevExpress.XtraGrid.Columns.GridColumn details_remark;
        private System.Windows.Forms.BindingSource bdsMostly;
        private System.Windows.Forms.BindingSource bdsDetail;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit clInteger;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit clDate;
        private DevExpress.XtraGrid.Columns.GridColumn work_time_normal_e;
        private DevExpress.XtraGrid.Columns.GridColumn work_time_overtime_e;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbgpage1;
        private System.Windows.Forms.TabPage tbgpage2;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtDept2;
        private DevExpress.XtraEditors.TextEdit txtDept1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn con_date1;
        private System.Windows.Forms.DataGridViewTextBoxColumn department_id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn department_name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequence_id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn group_type1;
        private System.Windows.Forms.DataGridViewTextBoxColumn work_date1;
        private System.Windows.Forms.DataGridViewTextBoxColumn work_time_normal_s1;
        private System.Windows.Forms.DataGridViewTextBoxColumn work_time_normal_e1;
        private System.Windows.Forms.DataGridViewTextBoxColumn workers_normal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn work_time_overtime_s1;
        private System.Windows.Forms.DataGridViewTextBoxColumn work_time_overtime_e1;
        private System.Windows.Forms.DataGridViewTextBoxColumn workers_overtime1;
        private System.Windows.Forms.DataGridViewTextBoxColumn running_machines1;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_total1;
        private System.Windows.Forms.DataGridViewTextBoxColumn details_remark1;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark1;
        private System.Windows.Forms.Button BTNSAVESET;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imageList1;
    }
}