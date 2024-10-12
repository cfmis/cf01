namespace cf01.Forms
{
    partial class frmCustComplain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustComplain));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
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
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNPRINT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dgvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMo_id = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.goods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.goods_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.oc_info = new DevExpress.XtraGrid.Columns.GridColumn();
            this.order_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unit_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clUnit_code = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.arrive_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exception_detail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.disposal_pro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.solve_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblreport_date = new System.Windows.Forms.Label();
            this.dtappellate_date = new DevExpress.XtraEditors.DateEdit();
            this.bteexception_note_id = new DevExpress.XtraEditors.ButtonEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.luecustomer_id = new DevExpress.XtraEditors.LookUpEdit();
            this.btnFindCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.lueseller_id = new DevExpress.XtraEditors.LookUpEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.grpBox1 = new System.Windows.Forms.GroupBox();
            this.txtreason_type_big = new DevExpress.XtraEditors.TextEdit();
            this.luereason_type = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.memessential_reason_qc = new DevExpress.XtraEditors.MemoEdit();
            this.memessential_reason_dept = new DevExpress.XtraEditors.MemoEdit();
            this.lblremark = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.memreslove_pro_revert = new DevExpress.XtraEditors.MemoEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpBox2 = new System.Windows.Forms.GroupBox();
            this.lineY1 = new cf01.ModuleClass.LineY();
            this.dtdept_date2 = new DevExpress.XtraEditors.DateEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtdept_responsible_person2 = new DevExpress.XtraEditors.TextEdit();
            this.dtdept_date1 = new DevExpress.XtraEditors.DateEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtdept_responsible_person1 = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.memdept_prevent_recurrent_step = new DevExpress.XtraEditors.MemoEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.memdept_correct_step = new DevExpress.XtraEditors.MemoEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lineX1 = new cf01.ModuleClass.LineX();
            this.lineY2 = new cf01.ModuleClass.LineY();
            this.dtqc_exception_note_date = new DevExpress.XtraEditors.DateEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtqc_exception_note_by = new DevExpress.XtraEditors.TextEdit();
            this.label21 = new System.Windows.Forms.Label();
            this.memqc_amend_effect_confirm = new DevExpress.XtraEditors.MemoEdit();
            this.dtqc_date2 = new DevExpress.XtraEditors.DateEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtqc_responsible_person2 = new DevExpress.XtraEditors.TextEdit();
            this.dtqc_date1 = new DevExpress.XtraEditors.DateEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtqc_responsible_person1 = new DevExpress.XtraEditors.TextEdit();
            this.label19 = new System.Windows.Forms.Label();
            this.memqc_prevent_recurrent_step = new DevExpress.XtraEditors.MemoEdit();
            this.label20 = new System.Windows.Forms.Label();
            this.memqc_correct_step = new DevExpress.XtraEditors.MemoEdit();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.memremark = new DevExpress.XtraEditors.MemoEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtbill_create_date = new DevExpress.XtraEditors.DateEdit();
            this.txtbill_create_by = new DevExpress.XtraEditors.TextEdit();
            this.dtbill_date = new DevExpress.XtraEditors.DateEdit();
            this.txtCustomer_name = new DevExpress.XtraEditors.TextEdit();
            this.label28 = new System.Windows.Forms.Label();
            this.txtnew_mo_id = new DevExpress.XtraEditors.TextEdit();
            this.lblAmtim = new System.Windows.Forms.Label();
            this.txtupdate_date = new DevExpress.XtraEditors.TextEdit();
            this.lblAmusr = new System.Windows.Forms.Label();
            this.txtupdate_by = new DevExpress.XtraEditors.TextEdit();
            this.lblCrtim = new System.Windows.Forms.Label();
            this.txtCreate_date = new DevExpress.XtraEditors.TextEdit();
            this.lblCrusr = new System.Windows.Forms.Label();
            this.txtCreate_by = new DevExpress.XtraEditors.TextEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.dgvDept = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dept_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDepartment = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.responsible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDel1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd1 = new DevExpress.XtraEditors.SimpleButton();
            this.bdsMostly = new System.Windows.Forms.BindingSource(this.components);
            this.bdsDept = new System.Windows.Forms.BindingSource(this.components);
            this.bdsDetail = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clMo_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clUnit_code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtappellate_date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtappellate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteexception_note_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecustomer_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueseller_id.Properties)).BeginInit();
            this.grpBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtreason_type_big.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luereason_type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memessential_reason_qc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memessential_reason_dept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memreslove_pro_revert.Properties)).BeginInit();
            this.grpBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtdept_date2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdept_date2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdept_responsible_person2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdept_date1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdept_date1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdept_responsible_person1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memdept_prevent_recurrent_step.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memdept_correct_step.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtqc_exception_note_date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtqc_exception_note_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtqc_exception_note_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memqc_amend_effect_confirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtqc_date2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtqc_date2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtqc_responsible_person2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtqc_date1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtqc_date1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtqc_responsible_person1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memqc_prevent_recurrent_step.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memqc_correct_step.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memremark.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbill_create_date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbill_create_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbill_create_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbill_date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbill_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnew_mo_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMostly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTemp_code
            // 
            this.lblTemp_code.ForeColor = System.Drawing.Color.Blue;
            this.lblTemp_code.Location = new System.Drawing.Point(27, 3);
            this.lblTemp_code.Name = "lblTemp_code";
            this.lblTemp_code.Size = new System.Drawing.Size(59, 17);
            this.lblTemp_code.TabIndex = 65;
            this.lblTemp_code.Text = "編號";
            this.lblTemp_code.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.EditValue = "";
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(92, 3);
            this.txtID.Name = "txtID";
            this.txtID.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtID.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Properties.MaxLength = 12;
            this.txtID.Properties.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(124, 22);
            this.txtID.TabIndex = 66;
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
            this.BTNPRINT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1016, 28);
            this.toolStrip1.TabIndex = 67;
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
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 618);
            this.gridControl1.MainView = this.dgvDetails;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.clMo_id,
            this.clUnit_code});
            this.gridControl1.Size = new System.Drawing.Size(1014, 121);
            this.gridControl1.TabIndex = 68;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetails});
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnPanelRowHeight = 30;
            this.dgvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.mo_id,
            this.goods_id,
            this.goods_name,
            this.oc_info,
            this.order_qty,
            this.unit_code,
            this.arrive_date,
            this.exception_detail,
            this.disposal_pro,
            this.solve_date,
            this.remark1,
            this.id,
            this.sequence_id});
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
            // mo_id
            // 
            this.mo_id.Caption = "頁數";
            this.mo_id.ColumnEdit = this.clMo_id;
            this.mo_id.FieldName = "mo_id";
            this.mo_id.Name = "mo_id";
            this.mo_id.OptionsColumn.AllowMove = false;
            this.mo_id.OptionsColumn.AllowSize = false;
            this.mo_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.mo_id.OptionsFilter.AllowAutoFilter = false;
            this.mo_id.OptionsFilter.AllowFilter = false;
            this.mo_id.Tag = "2";
            this.mo_id.Visible = true;
            this.mo_id.VisibleIndex = 0;
            this.mo_id.Width = 93;
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
            this.goods_id.Caption = "貨品編碼";
            this.goods_id.FieldName = "goods_id";
            this.goods_id.Name = "goods_id";
            this.goods_id.OptionsColumn.AllowMove = false;
            this.goods_id.OptionsColumn.AllowSize = false;
            this.goods_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.goods_id.OptionsColumn.ReadOnly = true;
            this.goods_id.OptionsFilter.AllowAutoFilter = false;
            this.goods_id.OptionsFilter.AllowFilter = false;
            this.goods_id.Tag = "2";
            this.goods_id.Visible = true;
            this.goods_id.VisibleIndex = 1;
            this.goods_id.Width = 143;
            // 
            // goods_name
            // 
            this.goods_name.Caption = "貨品名稱";
            this.goods_name.FieldName = "goods_name";
            this.goods_name.Name = "goods_name";
            this.goods_name.OptionsColumn.AllowMove = false;
            this.goods_name.OptionsColumn.AllowSize = false;
            this.goods_name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.goods_name.OptionsColumn.ReadOnly = true;
            this.goods_name.OptionsFilter.AllowAutoFilter = false;
            this.goods_name.OptionsFilter.AllowFilter = false;
            this.goods_name.Tag = "2";
            this.goods_name.Visible = true;
            this.goods_name.VisibleIndex = 2;
            this.goods_name.Width = 150;
            // 
            // oc_info
            // 
            this.oc_info.Caption = "OC資料";
            this.oc_info.FieldName = "oc_info";
            this.oc_info.Name = "oc_info";
            this.oc_info.OptionsColumn.AllowMove = false;
            this.oc_info.OptionsColumn.AllowSize = false;
            this.oc_info.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.oc_info.OptionsColumn.ReadOnly = true;
            this.oc_info.OptionsFilter.AllowAutoFilter = false;
            this.oc_info.OptionsFilter.AllowFilter = false;
            this.oc_info.Visible = true;
            this.oc_info.VisibleIndex = 3;
            this.oc_info.Width = 102;
            // 
            // order_qty
            // 
            this.order_qty.Caption = "訂單數量";
            this.order_qty.FieldName = "order_qty";
            this.order_qty.Name = "order_qty";
            this.order_qty.OptionsColumn.AllowMove = false;
            this.order_qty.OptionsColumn.AllowSize = false;
            this.order_qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.order_qty.OptionsFilter.AllowAutoFilter = false;
            this.order_qty.OptionsFilter.AllowFilter = false;
            this.order_qty.Visible = true;
            this.order_qty.VisibleIndex = 4;
            this.order_qty.Width = 86;
            // 
            // unit_code
            // 
            this.unit_code.Caption = "單位";
            this.unit_code.ColumnEdit = this.clUnit_code;
            this.unit_code.FieldName = "unit_code";
            this.unit_code.Name = "unit_code";
            this.unit_code.OptionsColumn.AllowMove = false;
            this.unit_code.OptionsColumn.AllowSize = false;
            this.unit_code.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.unit_code.OptionsFilter.AllowAutoFilter = false;
            this.unit_code.OptionsFilter.AllowFilter = false;
            this.unit_code.Visible = true;
            this.unit_code.VisibleIndex = 5;
            this.unit_code.Width = 50;
            // 
            // clUnit_code
            // 
            this.clUnit_code.AutoHeight = false;
            this.clUnit_code.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clUnit_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.clUnit_code.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 30, "id")});
            this.clUnit_code.DropDownRows = 10;
            this.clUnit_code.Name = "clUnit_code";
            this.clUnit_code.NullText = "";
            this.clUnit_code.PopupWidth = 40;
            this.clUnit_code.ShowHeader = false;
            this.clUnit_code.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // arrive_date
            // 
            this.arrive_date.Caption = "交貨日期";
            this.arrive_date.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.arrive_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.arrive_date.FieldName = "arrive_date";
            this.arrive_date.Name = "arrive_date";
            this.arrive_date.OptionsColumn.AllowMove = false;
            this.arrive_date.OptionsColumn.AllowSize = false;
            this.arrive_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.arrive_date.OptionsFilter.AllowAutoFilter = false;
            this.arrive_date.OptionsFilter.AllowFilter = false;
            this.arrive_date.Visible = true;
            this.arrive_date.VisibleIndex = 6;
            this.arrive_date.Width = 92;
            // 
            // exception_detail
            // 
            this.exception_detail.Caption = "產品異常詳細內容(投訴數量)";
            this.exception_detail.FieldName = "exception_detail";
            this.exception_detail.Name = "exception_detail";
            this.exception_detail.OptionsColumn.AllowMove = false;
            this.exception_detail.OptionsColumn.AllowSize = false;
            this.exception_detail.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.exception_detail.OptionsFilter.AllowAutoFilter = false;
            this.exception_detail.OptionsFilter.AllowFilter = false;
            this.exception_detail.Visible = true;
            this.exception_detail.VisibleIndex = 7;
            this.exception_detail.Width = 170;
            // 
            // disposal_pro
            // 
            this.disposal_pro.Caption = "要求處理方案";
            this.disposal_pro.FieldName = "disposal_pro";
            this.disposal_pro.Name = "disposal_pro";
            this.disposal_pro.OptionsColumn.AllowMove = false;
            this.disposal_pro.OptionsColumn.AllowSize = false;
            this.disposal_pro.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.disposal_pro.OptionsFilter.AllowAutoFilter = false;
            this.disposal_pro.OptionsFilter.AllowFilter = false;
            this.disposal_pro.Visible = true;
            this.disposal_pro.VisibleIndex = 8;
            this.disposal_pro.Width = 102;
            // 
            // solve_date
            // 
            this.solve_date.Caption = "要求解決日期";
            this.solve_date.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.solve_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.solve_date.FieldName = "solve_date";
            this.solve_date.Name = "solve_date";
            this.solve_date.OptionsColumn.AllowMove = false;
            this.solve_date.OptionsColumn.AllowSize = false;
            this.solve_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.solve_date.OptionsFilter.AllowAutoFilter = false;
            this.solve_date.OptionsFilter.AllowFilter = false;
            this.solve_date.Visible = true;
            this.solve_date.VisibleIndex = 9;
            // 
            // remark1
            // 
            this.remark1.Caption = "備註";
            this.remark1.FieldName = "remark";
            this.remark1.Name = "remark1";
            this.remark1.OptionsColumn.AllowMove = false;
            this.remark1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.remark1.OptionsFilter.AllowAutoFilter = false;
            this.remark1.OptionsFilter.AllowFilter = false;
            this.remark1.Visible = true;
            this.remark1.VisibleIndex = 10;
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
            // sequence_id
            // 
            this.sequence_id.Caption = "序號";
            this.sequence_id.FieldName = "sequence_id";
            this.sequence_id.Name = "sequence_id";
            // 
            // lblreport_date
            // 
            this.lblreport_date.ForeColor = System.Drawing.Color.Blue;
            this.lblreport_date.Location = new System.Drawing.Point(247, 3);
            this.lblreport_date.Name = "lblreport_date";
            this.lblreport_date.Size = new System.Drawing.Size(60, 17);
            this.lblreport_date.TabIndex = 120;
            this.lblreport_date.Text = "受理日期";
            this.lblreport_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtappellate_date
            // 
            this.dtappellate_date.EditValue = "";
            this.dtappellate_date.Enabled = false;
            this.dtappellate_date.EnterMoveNextControl = true;
            this.dtappellate_date.Location = new System.Drawing.Point(307, 3);
            this.dtappellate_date.Name = "dtappellate_date";
            this.dtappellate_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtappellate_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtappellate_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtappellate_date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtappellate_date.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtappellate_date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtappellate_date.Properties.Mask.BeepOnError = true;
            this.dtappellate_date.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtappellate_date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtappellate_date.Properties.MaxLength = 10;
            this.dtappellate_date.Properties.NullDate = "";
            this.dtappellate_date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtappellate_date.Size = new System.Drawing.Size(132, 22);
            this.dtappellate_date.TabIndex = 119;
            this.dtappellate_date.Tag = "2";
            // 
            // bteexception_note_id
            // 
            this.bteexception_note_id.EnterMoveNextControl = true;
            this.bteexception_note_id.Location = new System.Drawing.Point(866, 4);
            this.bteexception_note_id.Name = "bteexception_note_id";
            this.bteexception_note_id.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.bteexception_note_id.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.bteexception_note_id.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.bteexception_note_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", 20, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.bteexception_note_id.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.bteexception_note_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bteexception_note_id.Properties.ReadOnly = true;
            this.bteexception_note_id.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteexception_note_id_Properties_ButtonClick);
            this.bteexception_note_id.Size = new System.Drawing.Size(144, 22);
            this.bteexception_note_id.TabIndex = 121;
            this.bteexception_note_id.Tag = "2";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(738, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 122;
            this.label1.Text = "產品異常通知單編號";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // luecustomer_id
            // 
            this.luecustomer_id.EditValue = "";
            this.luecustomer_id.Enabled = false;
            this.luecustomer_id.EnterMoveNextControl = true;
            this.luecustomer_id.Location = new System.Drawing.Point(92, 28);
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
            this.luecustomer_id.Properties.NullText = "";
            this.luecustomer_id.Properties.PopupFormMinSize = new System.Drawing.Size(200, 0);
            this.luecustomer_id.Properties.PopupWidth = 280;
            this.luecustomer_id.Properties.ShowHeader = false;
            this.luecustomer_id.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luecustomer_id.Size = new System.Drawing.Size(124, 22);
            this.luecustomer_id.TabIndex = 123;
            this.luecustomer_id.Tag = "2";
            this.luecustomer_id.EditValueChanged += new System.EventHandler(this.luecustomer_id_EditValueChanged);
            // 
            // btnFindCustomer
            // 
            this.btnFindCustomer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnFindCustomer.Location = new System.Drawing.Point(217, 28);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(22, 22);
            this.btnFindCustomer.TabIndex = 126;
            this.btnFindCustomer.Text = "...";
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // lueseller_id
            // 
            this.lueseller_id.EditValue = "";
            this.lueseller_id.Enabled = false;
            this.lueseller_id.EnterMoveNextControl = true;
            this.lueseller_id.Location = new System.Drawing.Point(687, 28);
            this.lueseller_id.Name = "lueseller_id";
            this.lueseller_id.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.lueseller_id.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.lueseller_id.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.lueseller_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueseller_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueseller_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 40, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 120, "cdesc")});
            this.lueseller_id.Properties.DropDownRows = 15;
            this.lueseller_id.Properties.NullText = "";
            this.lueseller_id.Properties.PopupFormMinSize = new System.Drawing.Size(280, 0);
            this.lueseller_id.Properties.PopupWidth = 160;
            this.lueseller_id.Properties.ShowHeader = false;
            this.lueseller_id.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueseller_id.Size = new System.Drawing.Size(116, 22);
            this.lueseller_id.TabIndex = 145;
            this.lueseller_id.Tag = "2";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(624, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 146;
            this.label13.Text = "銷售員編號";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpBox1
            // 
            this.grpBox1.Controls.Add(this.txtreason_type_big);
            this.grpBox1.Controls.Add(this.luereason_type);
            this.grpBox1.Controls.Add(this.label2);
            this.grpBox1.Controls.Add(this.label3);
            this.grpBox1.Controls.Add(this.memessential_reason_qc);
            this.grpBox1.Controls.Add(this.memessential_reason_dept);
            this.grpBox1.Controls.Add(this.lblremark);
            this.grpBox1.Controls.Add(this.label26);
            this.grpBox1.Controls.Add(this.label27);
            this.grpBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBox1.Location = new System.Drawing.Point(466, 46);
            this.grpBox1.Name = "grpBox1";
            this.grpBox1.Size = new System.Drawing.Size(547, 150);
            this.grpBox1.TabIndex = 147;
            this.grpBox1.TabStop = false;
            this.grpBox1.Text = "根本原因";
            // 
            // txtreason_type_big
            // 
            this.txtreason_type_big.Enabled = false;
            this.txtreason_type_big.Location = new System.Drawing.Point(365, 14);
            this.txtreason_type_big.Name = "txtreason_type_big";
            this.txtreason_type_big.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtreason_type_big.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtreason_type_big.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtreason_type_big.Properties.ReadOnly = true;
            this.txtreason_type_big.Size = new System.Drawing.Size(177, 22);
            this.txtreason_type_big.TabIndex = 203;
            this.txtreason_type_big.Tag = "2";
            // 
            // luereason_type
            // 
            this.luereason_type.EditValue = "";
            this.luereason_type.Enabled = false;
            this.luereason_type.EnterMoveNextControl = true;
            this.luereason_type.Location = new System.Drawing.Point(74, 14);
            this.luereason_type.Name = "luereason_type";
            this.luereason_type.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.luereason_type.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.luereason_type.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.luereason_type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luereason_type.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("person_type", 100, "原因"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("person_type_big", 50, "原因大類")});
            this.luereason_type.Properties.DropDownRows = 20;
            this.luereason_type.Properties.NullText = "";
            this.luereason_type.Properties.PopupFormMinSize = new System.Drawing.Size(200, 0);
            this.luereason_type.Properties.PopupWidth = 150;
            this.luereason_type.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luereason_type.Size = new System.Drawing.Size(291, 22);
            this.luereason_type.TabIndex = 186;
            this.luereason_type.Tag = "1";
            this.luereason_type.EditValueChanged += new System.EventHandler(this.luereason_type_EditValueChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 182;
            this.label2.Text = "(QC部門)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 181;
            this.label3.Text = "流出原因";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // memessential_reason_qc
            // 
            this.memessential_reason_qc.EditValue = "";
            this.memessential_reason_qc.EnterMoveNextControl = true;
            this.memessential_reason_qc.Location = new System.Drawing.Point(74, 93);
            this.memessential_reason_qc.Name = "memessential_reason_qc";
            this.memessential_reason_qc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.memessential_reason_qc.Properties.MaxLength = 200;
            this.memessential_reason_qc.Size = new System.Drawing.Size(468, 53);
            this.memessential_reason_qc.TabIndex = 178;
            // 
            // memessential_reason_dept
            // 
            this.memessential_reason_dept.EditValue = "";
            this.memessential_reason_dept.EnterMoveNextControl = true;
            this.memessential_reason_dept.Location = new System.Drawing.Point(74, 39);
            this.memessential_reason_dept.Name = "memessential_reason_dept";
            this.memessential_reason_dept.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.memessential_reason_dept.Properties.MaxLength = 200;
            this.memessential_reason_dept.Size = new System.Drawing.Size(468, 53);
            this.memessential_reason_dept.TabIndex = 177;
            // 
            // lblremark
            // 
            this.lblremark.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblremark.Location = new System.Drawing.Point(3, 48);
            this.lblremark.Name = "lblremark";
            this.lblremark.Size = new System.Drawing.Size(67, 15);
            this.lblremark.TabIndex = 179;
            this.lblremark.Text = "產生原因";
            this.lblremark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Blue;
            this.label26.Location = new System.Drawing.Point(11, 14);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(59, 32);
            this.label26.TabIndex = 187;
            this.label26.Text = "原因分類(小類)";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(2, 65);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 13);
            this.label27.TabIndex = 180;
            this.label27.Text = "(責任部門)";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // memreslove_pro_revert
            // 
            this.memreslove_pro_revert.EditValue = "";
            this.memreslove_pro_revert.EnterMoveNextControl = true;
            this.memreslove_pro_revert.Location = new System.Drawing.Point(92, 54);
            this.memreslove_pro_revert.Name = "memreslove_pro_revert";
            this.memreslove_pro_revert.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.memreslove_pro_revert.Properties.MaxLength = 200;
            this.memreslove_pro_revert.Size = new System.Drawing.Size(347, 142);
            this.memreslove_pro_revert.TabIndex = 178;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(28, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 35);
            this.label4.TabIndex = 179;
            this.label4.Text = "即時解決方案回應";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 180;
            this.label5.Text = "客戶編號";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpBox2
            // 
            this.grpBox2.Controls.Add(this.lineY1);
            this.grpBox2.Controls.Add(this.dtdept_date2);
            this.grpBox2.Controls.Add(this.label11);
            this.grpBox2.Controls.Add(this.label12);
            this.grpBox2.Controls.Add(this.txtdept_responsible_person2);
            this.grpBox2.Controls.Add(this.dtdept_date1);
            this.grpBox2.Controls.Add(this.label10);
            this.grpBox2.Controls.Add(this.label9);
            this.grpBox2.Controls.Add(this.txtdept_responsible_person1);
            this.grpBox2.Controls.Add(this.label7);
            this.grpBox2.Controls.Add(this.memdept_prevent_recurrent_step);
            this.grpBox2.Controls.Add(this.label6);
            this.grpBox2.Controls.Add(this.memdept_correct_step);
            this.grpBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBox2.Location = new System.Drawing.Point(92, 193);
            this.grpBox2.Name = "grpBox2";
            this.grpBox2.Size = new System.Drawing.Size(921, 87);
            this.grpBox2.TabIndex = 181;
            this.grpBox2.TabStop = false;
            // 
            // lineY1
            // 
            this.lineY1.LineColor = System.Drawing.Color.Gray;
            this.lineY1.LineWidth = 1;
            this.lineY1.Location = new System.Drawing.Point(448, 10);
            this.lineY1.Name = "lineY1";
            this.lineY1.Size = new System.Drawing.Size(1, 73);
            this.lineY1.TabIndex = 192;
            // 
            // dtdept_date2
            // 
            this.dtdept_date2.EditValue = "";
            this.dtdept_date2.Enabled = false;
            this.dtdept_date2.EnterMoveNextControl = true;
            this.dtdept_date2.Location = new System.Drawing.Point(750, 60);
            this.dtdept_date2.Name = "dtdept_date2";
            this.dtdept_date2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtdept_date2.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtdept_date2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtdept_date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtdept_date2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtdept_date2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtdept_date2.Properties.Mask.BeepOnError = true;
            this.dtdept_date2.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtdept_date2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtdept_date2.Properties.MaxLength = 10;
            this.dtdept_date2.Properties.NullDate = "";
            this.dtdept_date2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtdept_date2.Size = new System.Drawing.Size(166, 22);
            this.dtdept_date2.TabIndex = 191;
            this.dtdept_date2.Tag = "2";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(689, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 190;
            this.label11.Text = "日期";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(456, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 189;
            this.label12.Text = "責任人";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtdept_responsible_person2
            // 
            this.txtdept_responsible_person2.EditValue = "";
            this.txtdept_responsible_person2.EnterMoveNextControl = true;
            this.txtdept_responsible_person2.Location = new System.Drawing.Point(517, 60);
            this.txtdept_responsible_person2.Name = "txtdept_responsible_person2";
            this.txtdept_responsible_person2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtdept_responsible_person2.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtdept_responsible_person2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtdept_responsible_person2.Properties.MaxLength = 20;
            this.txtdept_responsible_person2.Properties.ReadOnly = true;
            this.txtdept_responsible_person2.Size = new System.Drawing.Size(143, 22);
            this.txtdept_responsible_person2.TabIndex = 188;
            this.txtdept_responsible_person2.Tag = "2";
            // 
            // dtdept_date1
            // 
            this.dtdept_date1.EditValue = "";
            this.dtdept_date1.Enabled = false;
            this.dtdept_date1.EnterMoveNextControl = true;
            this.dtdept_date1.Location = new System.Drawing.Point(299, 60);
            this.dtdept_date1.Name = "dtdept_date1";
            this.dtdept_date1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtdept_date1.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtdept_date1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtdept_date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtdept_date1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtdept_date1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtdept_date1.Properties.Mask.BeepOnError = true;
            this.dtdept_date1.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtdept_date1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtdept_date1.Properties.MaxLength = 10;
            this.dtdept_date1.Properties.NullDate = "";
            this.dtdept_date1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtdept_date1.Size = new System.Drawing.Size(123, 22);
            this.dtdept_date1.TabIndex = 187;
            this.dtdept_date1.Tag = "2";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(233, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 186;
            this.label10.Text = "日期";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 185;
            this.label9.Text = "責任人";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtdept_responsible_person1
            // 
            this.txtdept_responsible_person1.EditValue = "";
            this.txtdept_responsible_person1.EnterMoveNextControl = true;
            this.txtdept_responsible_person1.Location = new System.Drawing.Point(60, 60);
            this.txtdept_responsible_person1.Name = "txtdept_responsible_person1";
            this.txtdept_responsible_person1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtdept_responsible_person1.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtdept_responsible_person1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtdept_responsible_person1.Properties.MaxLength = 20;
            this.txtdept_responsible_person1.Properties.ReadOnly = true;
            this.txtdept_responsible_person1.Size = new System.Drawing.Size(144, 22);
            this.txtdept_responsible_person1.TabIndex = 184;
            this.txtdept_responsible_person1.Tag = "2";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(459, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 39);
            this.label7.TabIndex = 183;
            this.label7.Text = "預防再次發生措施";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // memdept_prevent_recurrent_step
            // 
            this.memdept_prevent_recurrent_step.EditValue = "";
            this.memdept_prevent_recurrent_step.EnterMoveNextControl = true;
            this.memdept_prevent_recurrent_step.Location = new System.Drawing.Point(517, 10);
            this.memdept_prevent_recurrent_step.Name = "memdept_prevent_recurrent_step";
            this.memdept_prevent_recurrent_step.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.memdept_prevent_recurrent_step.Properties.MaxLength = 200;
            this.memdept_prevent_recurrent_step.Size = new System.Drawing.Size(399, 49);
            this.memdept_prevent_recurrent_step.TabIndex = 182;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 181;
            this.label6.Text = "糾正措施";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // memdept_correct_step
            // 
            this.memdept_correct_step.EditValue = "";
            this.memdept_correct_step.EnterMoveNextControl = true;
            this.memdept_correct_step.Location = new System.Drawing.Point(60, 10);
            this.memdept_correct_step.Name = "memdept_correct_step";
            this.memdept_correct_step.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.memdept_correct_step.Properties.MaxLength = 200;
            this.memdept_correct_step.Size = new System.Drawing.Size(362, 49);
            this.memdept_correct_step.TabIndex = 178;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 182;
            this.label8.Text = "責任部門";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 308);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 184;
            this.label14.Text = "QC部門";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.lineX1);
            this.groupBox1.Controls.Add(this.lineY2);
            this.groupBox1.Controls.Add(this.dtqc_exception_note_date);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txtqc_exception_note_by);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.memqc_amend_effect_confirm);
            this.groupBox1.Controls.Add(this.dtqc_date2);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtqc_responsible_person2);
            this.groupBox1.Controls.Add(this.dtqc_date1);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtqc_responsible_person1);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.memqc_prevent_recurrent_step);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.memqc_correct_step);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(91, 277);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(922, 138);
            this.groupBox1.TabIndex = 183;
            this.groupBox1.TabStop = false;
            // 
            // lineX1
            // 
            this.lineX1.LineColor = System.Drawing.Color.Gray;
            this.lineX1.LineWidth = 1;
            this.lineX1.Location = new System.Drawing.Point(3, 85);
            this.lineX1.Name = "lineX1";
            this.lineX1.Size = new System.Drawing.Size(915, 1);
            this.lineX1.TabIndex = 201;
            // 
            // lineY2
            // 
            this.lineY2.LineColor = System.Drawing.Color.Gray;
            this.lineY2.LineWidth = 1;
            this.lineY2.Location = new System.Drawing.Point(449, 10);
            this.lineY2.Name = "lineY2";
            this.lineY2.Size = new System.Drawing.Size(1, 73);
            this.lineY2.TabIndex = 200;
            // 
            // dtqc_exception_note_date
            // 
            this.dtqc_exception_note_date.EditValue = "";
            this.dtqc_exception_note_date.Enabled = false;
            this.dtqc_exception_note_date.EnterMoveNextControl = true;
            this.dtqc_exception_note_date.Location = new System.Drawing.Point(751, 112);
            this.dtqc_exception_note_date.Name = "dtqc_exception_note_date";
            this.dtqc_exception_note_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtqc_exception_note_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtqc_exception_note_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtqc_exception_note_date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtqc_exception_note_date.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtqc_exception_note_date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtqc_exception_note_date.Properties.Mask.BeepOnError = true;
            this.dtqc_exception_note_date.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtqc_exception_note_date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtqc_exception_note_date.Properties.MaxLength = 10;
            this.dtqc_exception_note_date.Properties.NullDate = "";
            this.dtqc_exception_note_date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtqc_exception_note_date.Size = new System.Drawing.Size(166, 22);
            this.dtqc_exception_note_date.TabIndex = 199;
            this.dtqc_exception_note_date.Tag = "2";
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(687, 115);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 13);
            this.label25.TabIndex = 198;
            this.label25.Text = "完成日期";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(692, 92);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(54, 13);
            this.label22.TabIndex = 197;
            this.label22.Text = "擔當";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtqc_exception_note_by
            // 
            this.txtqc_exception_note_by.EditValue = "";
            this.txtqc_exception_note_by.EnterMoveNextControl = true;
            this.txtqc_exception_note_by.Location = new System.Drawing.Point(751, 89);
            this.txtqc_exception_note_by.Name = "txtqc_exception_note_by";
            this.txtqc_exception_note_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtqc_exception_note_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtqc_exception_note_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtqc_exception_note_by.Properties.MaxLength = 20;
            this.txtqc_exception_note_by.Properties.ReadOnly = true;
            this.txtqc_exception_note_by.Size = new System.Drawing.Size(166, 22);
            this.txtqc_exception_note_by.TabIndex = 196;
            this.txtqc_exception_note_by.Tag = "2";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(4, 98);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 193;
            this.label21.Text = "檢討成效";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // memqc_amend_effect_confirm
            // 
            this.memqc_amend_effect_confirm.EditValue = "";
            this.memqc_amend_effect_confirm.EnterMoveNextControl = true;
            this.memqc_amend_effect_confirm.Location = new System.Drawing.Point(60, 89);
            this.memqc_amend_effect_confirm.Name = "memqc_amend_effect_confirm";
            this.memqc_amend_effect_confirm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.memqc_amend_effect_confirm.Properties.MaxLength = 200;
            this.memqc_amend_effect_confirm.Size = new System.Drawing.Size(600, 45);
            this.memqc_amend_effect_confirm.TabIndex = 192;
            // 
            // dtqc_date2
            // 
            this.dtqc_date2.EditValue = "";
            this.dtqc_date2.Enabled = false;
            this.dtqc_date2.EnterMoveNextControl = true;
            this.dtqc_date2.Location = new System.Drawing.Point(751, 60);
            this.dtqc_date2.Name = "dtqc_date2";
            this.dtqc_date2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtqc_date2.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtqc_date2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtqc_date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtqc_date2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtqc_date2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtqc_date2.Properties.Mask.BeepOnError = true;
            this.dtqc_date2.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtqc_date2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtqc_date2.Properties.MaxLength = 10;
            this.dtqc_date2.Properties.NullDate = "";
            this.dtqc_date2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtqc_date2.Size = new System.Drawing.Size(166, 22);
            this.dtqc_date2.TabIndex = 191;
            this.dtqc_date2.Tag = "2";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(684, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 190;
            this.label15.Text = "日期";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(454, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 189;
            this.label16.Text = "責任人";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtqc_responsible_person2
            // 
            this.txtqc_responsible_person2.EditValue = "";
            this.txtqc_responsible_person2.EnterMoveNextControl = true;
            this.txtqc_responsible_person2.Location = new System.Drawing.Point(518, 60);
            this.txtqc_responsible_person2.Name = "txtqc_responsible_person2";
            this.txtqc_responsible_person2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtqc_responsible_person2.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtqc_responsible_person2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtqc_responsible_person2.Properties.MaxLength = 20;
            this.txtqc_responsible_person2.Properties.ReadOnly = true;
            this.txtqc_responsible_person2.Size = new System.Drawing.Size(143, 22);
            this.txtqc_responsible_person2.TabIndex = 188;
            this.txtqc_responsible_person2.Tag = "2";
            // 
            // dtqc_date1
            // 
            this.dtqc_date1.EditValue = "";
            this.dtqc_date1.Enabled = false;
            this.dtqc_date1.EnterMoveNextControl = true;
            this.dtqc_date1.Location = new System.Drawing.Point(299, 60);
            this.dtqc_date1.Name = "dtqc_date1";
            this.dtqc_date1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtqc_date1.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtqc_date1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtqc_date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtqc_date1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtqc_date1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtqc_date1.Properties.Mask.BeepOnError = true;
            this.dtqc_date1.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtqc_date1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtqc_date1.Properties.MaxLength = 10;
            this.dtqc_date1.Properties.NullDate = "";
            this.dtqc_date1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtqc_date1.Size = new System.Drawing.Size(123, 22);
            this.dtqc_date1.TabIndex = 187;
            this.dtqc_date1.Tag = "2";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(233, 63);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 186;
            this.label17.Text = "日期";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(4, 63);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 185;
            this.label18.Text = "責任人";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtqc_responsible_person1
            // 
            this.txtqc_responsible_person1.EditValue = "";
            this.txtqc_responsible_person1.EnterMoveNextControl = true;
            this.txtqc_responsible_person1.Location = new System.Drawing.Point(60, 60);
            this.txtqc_responsible_person1.Name = "txtqc_responsible_person1";
            this.txtqc_responsible_person1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtqc_responsible_person1.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtqc_responsible_person1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtqc_responsible_person1.Properties.MaxLength = 20;
            this.txtqc_responsible_person1.Properties.ReadOnly = true;
            this.txtqc_responsible_person1.Size = new System.Drawing.Size(144, 22);
            this.txtqc_responsible_person1.TabIndex = 184;
            this.txtqc_responsible_person1.Tag = "2";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(457, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 39);
            this.label19.TabIndex = 183;
            this.label19.Text = "預防再次發生措施";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // memqc_prevent_recurrent_step
            // 
            this.memqc_prevent_recurrent_step.EditValue = "";
            this.memqc_prevent_recurrent_step.EnterMoveNextControl = true;
            this.memqc_prevent_recurrent_step.Location = new System.Drawing.Point(518, 10);
            this.memqc_prevent_recurrent_step.Name = "memqc_prevent_recurrent_step";
            this.memqc_prevent_recurrent_step.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.memqc_prevent_recurrent_step.Properties.MaxLength = 200;
            this.memqc_prevent_recurrent_step.Size = new System.Drawing.Size(399, 49);
            this.memqc_prevent_recurrent_step.TabIndex = 182;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(4, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 13);
            this.label20.TabIndex = 181;
            this.label20.Text = "糾正措施";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // memqc_correct_step
            // 
            this.memqc_correct_step.EditValue = "";
            this.memqc_correct_step.EnterMoveNextControl = true;
            this.memqc_correct_step.Location = new System.Drawing.Point(60, 10);
            this.memqc_correct_step.Name = "memqc_correct_step";
            this.memqc_correct_step.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.memqc_correct_step.Properties.MaxLength = 200;
            this.memqc_correct_step.Size = new System.Drawing.Size(362, 49);
            this.memqc_correct_step.TabIndex = 178;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(20, 419);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 31);
            this.label23.TabIndex = 196;
            this.label23.Text = "關係部門責任者確認";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(640, 419);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 13);
            this.label24.TabIndex = 199;
            this.label24.Text = "備 註";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // memremark
            // 
            this.memremark.EditValue = "";
            this.memremark.EnterMoveNextControl = true;
            this.memremark.Location = new System.Drawing.Point(682, 417);
            this.memremark.Name = "memremark";
            this.memremark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.memremark.Properties.MaxLength = 200;
            this.memremark.Size = new System.Drawing.Size(330, 134);
            this.memremark.TabIndex = 200;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtbill_create_date);
            this.panel1.Controls.Add(this.txtbill_create_by);
            this.panel1.Controls.Add(this.dtbill_date);
            this.panel1.Controls.Add(this.txtCustomer_name);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.txtnew_mo_id);
            this.panel1.Controls.Add(this.lblTemp_code);
            this.panel1.Controls.Add(this.lblAmtim);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.txtupdate_date);
            this.panel1.Controls.Add(this.lblAmusr);
            this.panel1.Controls.Add(this.txtupdate_by);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.lblCrtim);
            this.panel1.Controls.Add(this.dtappellate_date);
            this.panel1.Controls.Add(this.txtCreate_date);
            this.panel1.Controls.Add(this.lblCrusr);
            this.panel1.Controls.Add(this.lblreport_date);
            this.panel1.Controls.Add(this.bteexception_note_id);
            this.panel1.Controls.Add(this.txtCreate_by);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.luecustomer_id);
            this.panel1.Controls.Add(this.memremark);
            this.panel1.Controls.Add(this.btnFindCustomer);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lueseller_id);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.memreslove_pro_revert);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.grpBox1);
            this.panel1.Controls.Add(this.grpBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 584);
            this.panel1.TabIndex = 201;
            // 
            // dtbill_create_date
            // 
            this.dtbill_create_date.EditValue = "";
            this.dtbill_create_date.Enabled = false;
            this.dtbill_create_date.EnterMoveNextControl = true;
            this.dtbill_create_date.Location = new System.Drawing.Point(466, 24);
            this.dtbill_create_date.Name = "dtbill_create_date";
            this.dtbill_create_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtbill_create_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtbill_create_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtbill_create_date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtbill_create_date.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtbill_create_date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtbill_create_date.Properties.Mask.BeepOnError = true;
            this.dtbill_create_date.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtbill_create_date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtbill_create_date.Properties.MaxLength = 10;
            this.dtbill_create_date.Properties.NullDate = "";
            this.dtbill_create_date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtbill_create_date.Size = new System.Drawing.Size(95, 22);
            this.dtbill_create_date.TabIndex = 215;
            this.dtbill_create_date.Tag = "2";
            this.dtbill_create_date.Visible = false;
            // 
            // txtbill_create_by
            // 
            this.txtbill_create_by.Enabled = false;
            this.txtbill_create_by.Location = new System.Drawing.Point(567, 3);
            this.txtbill_create_by.Name = "txtbill_create_by";
            this.txtbill_create_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtbill_create_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtbill_create_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtbill_create_by.Properties.MaxLength = 20;
            this.txtbill_create_by.Properties.ReadOnly = true;
            this.txtbill_create_by.Size = new System.Drawing.Size(84, 22);
            this.txtbill_create_by.TabIndex = 214;
            this.txtbill_create_by.Tag = "2";
            this.txtbill_create_by.Visible = false;
            // 
            // dtbill_date
            // 
            this.dtbill_date.EditValue = "";
            this.dtbill_date.Enabled = false;
            this.dtbill_date.EnterMoveNextControl = true;
            this.dtbill_date.Location = new System.Drawing.Point(466, 3);
            this.dtbill_date.Name = "dtbill_date";
            this.dtbill_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtbill_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtbill_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtbill_date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtbill_date.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtbill_date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtbill_date.Properties.Mask.BeepOnError = true;
            this.dtbill_date.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtbill_date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtbill_date.Properties.MaxLength = 10;
            this.dtbill_date.Properties.NullDate = "";
            this.dtbill_date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtbill_date.Size = new System.Drawing.Size(95, 22);
            this.dtbill_date.TabIndex = 213;
            this.dtbill_date.Tag = "2";
            this.dtbill_date.Visible = false;
            // 
            // txtCustomer_name
            // 
            this.txtCustomer_name.Enabled = false;
            this.txtCustomer_name.Location = new System.Drawing.Point(239, 28);
            this.txtCustomer_name.Name = "txtCustomer_name";
            this.txtCustomer_name.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCustomer_name.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCustomer_name.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCustomer_name.Properties.MaxLength = 20;
            this.txtCustomer_name.Properties.ReadOnly = true;
            this.txtCustomer_name.Size = new System.Drawing.Size(200, 22);
            this.txtCustomer_name.TabIndex = 212;
            this.txtCustomer_name.Tag = "2";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(807, 29);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(57, 13);
            this.label28.TabIndex = 211;
            this.label28.Text = "新頁數";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnew_mo_id
            // 
            this.txtnew_mo_id.EditValue = "";
            this.txtnew_mo_id.EnterMoveNextControl = true;
            this.txtnew_mo_id.Location = new System.Drawing.Point(866, 28);
            this.txtnew_mo_id.Name = "txtnew_mo_id";
            this.txtnew_mo_id.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtnew_mo_id.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtnew_mo_id.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtnew_mo_id.Properties.MaxLength = 30;
            this.txtnew_mo_id.Properties.ReadOnly = true;
            this.txtnew_mo_id.Size = new System.Drawing.Size(144, 22);
            this.txtnew_mo_id.TabIndex = 210;
            this.txtnew_mo_id.Tag = "2";
            // 
            // lblAmtim
            // 
            this.lblAmtim.Location = new System.Drawing.Point(768, 561);
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
            this.txtupdate_date.Location = new System.Drawing.Point(842, 557);
            this.txtupdate_date.Name = "txtupdate_date";
            this.txtupdate_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtupdate_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtupdate_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtupdate_date.Properties.ReadOnly = true;
            this.txtupdate_date.Size = new System.Drawing.Size(170, 22);
            this.txtupdate_date.TabIndex = 207;
            this.txtupdate_date.Tag = "2";
            // 
            // lblAmusr
            // 
            this.lblAmusr.Location = new System.Drawing.Point(553, 561);
            this.lblAmusr.Name = "lblAmusr";
            this.lblAmusr.Size = new System.Drawing.Size(47, 13);
            this.lblAmusr.TabIndex = 208;
            this.lblAmusr.Text = "修改人";
            this.lblAmusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtupdate_by
            // 
            this.txtupdate_by.EditValue = "";
            this.txtupdate_by.Enabled = false;
            this.txtupdate_by.Location = new System.Drawing.Point(605, 557);
            this.txtupdate_by.Name = "txtupdate_by";
            this.txtupdate_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtupdate_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtupdate_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtupdate_by.Properties.MaxLength = 20;
            this.txtupdate_by.Properties.ReadOnly = true;
            this.txtupdate_by.Size = new System.Drawing.Size(144, 22);
            this.txtupdate_by.TabIndex = 206;
            this.txtupdate_by.Tag = "2";
            // 
            // lblCrtim
            // 
            this.lblCrtim.Location = new System.Drawing.Point(277, 561);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(62, 13);
            this.lblCrtim.TabIndex = 205;
            this.lblCrtim.Text = "建檔日期";
            this.lblCrtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreate_date
            // 
            this.txtCreate_date.Enabled = false;
            this.txtCreate_date.Location = new System.Drawing.Point(345, 557);
            this.txtCreate_date.Name = "txtCreate_date";
            this.txtCreate_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCreate_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCreate_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCreate_date.Properties.ReadOnly = true;
            this.txtCreate_date.Size = new System.Drawing.Size(192, 22);
            this.txtCreate_date.TabIndex = 203;
            this.txtCreate_date.Tag = "2";
            // 
            // lblCrusr
            // 
            this.lblCrusr.Location = new System.Drawing.Point(30, 561);
            this.lblCrusr.Name = "lblCrusr";
            this.lblCrusr.Size = new System.Drawing.Size(56, 13);
            this.lblCrusr.TabIndex = 204;
            this.lblCrusr.Text = "建檔人";
            this.lblCrusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreate_by
            // 
            this.txtCreate_by.Enabled = false;
            this.txtCreate_by.Location = new System.Drawing.Point(91, 557);
            this.txtCreate_by.Name = "txtCreate_by";
            this.txtCreate_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCreate_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCreate_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCreate_by.Properties.MaxLength = 20;
            this.txtCreate_by.Properties.ReadOnly = true;
            this.txtCreate_by.Size = new System.Drawing.Size(150, 22);
            this.txtCreate_by.TabIndex = 202;
            this.txtCreate_by.Tag = "2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.gridControl2);
            this.panel2.Controls.Add(this.btnDel1);
            this.panel2.Controls.Add(this.btnAdd1);
            this.panel2.Location = new System.Drawing.Point(91, 447);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(546, 137);
            this.panel2.TabIndex = 210;
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(2, 1);
            this.gridControl2.MainView = this.dgvDept;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.clDepartment});
            this.gridControl2.Size = new System.Drawing.Size(443, 131);
            this.gridControl2.TabIndex = 69;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDept});
            // 
            // dgvDept
            // 
            this.dgvDept.ColumnPanelRowHeight = 30;
            this.dgvDept.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.dept_id,
            this.responsible,
            this.remark,
            this.id1,
            this.gridColumn12});
            this.dgvDept.GridControl = this.gridControl2;
            this.dgvDept.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.dgvDept.IndicatorWidth = 30;
            this.dgvDept.Name = "dgvDept";
            this.dgvDept.OptionsBehavior.Editable = false;
            this.dgvDept.OptionsCustomization.AllowColumnMoving = false;
            this.dgvDept.OptionsCustomization.AllowFilter = false;
            this.dgvDept.OptionsCustomization.AllowSort = false;
            this.dgvDept.OptionsView.ColumnAutoWidth = false;
            this.dgvDept.OptionsView.ShowGroupPanel = false;
            this.dgvDept.PaintStyleName = "Style3D";
            this.dgvDept.RowHeight = 22;
            this.dgvDept.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.dgvDept.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.dgvDept_CustomDrawCell);
            // 
            // dept_id
            // 
            this.dept_id.Caption = "部門";
            this.dept_id.ColumnEdit = this.clDepartment;
            this.dept_id.FieldName = "dept_id";
            this.dept_id.Name = "dept_id";
            this.dept_id.OptionsColumn.AllowMove = false;
            this.dept_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.dept_id.OptionsFilter.AllowAutoFilter = false;
            this.dept_id.OptionsFilter.AllowFilter = false;
            this.dept_id.Tag = "2";
            this.dept_id.Visible = true;
            this.dept_id.VisibleIndex = 0;
            this.dept_id.Width = 112;
            // 
            // clDepartment
            // 
            this.clDepartment.AutoHeight = false;
            this.clDepartment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clDepartment.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 100, "id")});
            this.clDepartment.DropDownRows = 10;
            this.clDepartment.MaxLength = 30;
            this.clDepartment.Name = "clDepartment";
            this.clDepartment.NullText = "";
            this.clDepartment.PopupWidth = 100;
            this.clDepartment.ShowHeader = false;
            this.clDepartment.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // responsible
            // 
            this.responsible.Caption = "責任人";
            this.responsible.FieldName = "responsible";
            this.responsible.Name = "responsible";
            this.responsible.OptionsColumn.AllowMove = false;
            this.responsible.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.responsible.OptionsFilter.AllowAutoFilter = false;
            this.responsible.OptionsFilter.AllowFilter = false;
            this.responsible.Visible = true;
            this.responsible.VisibleIndex = 1;
            this.responsible.Width = 104;
            // 
            // remark
            // 
            this.remark.Caption = "備註";
            this.remark.FieldName = "remark";
            this.remark.Name = "remark";
            this.remark.OptionsColumn.AllowMove = false;
            this.remark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.remark.OptionsFilter.AllowAutoFilter = false;
            this.remark.OptionsFilter.AllowFilter = false;
            this.remark.Visible = true;
            this.remark.VisibleIndex = 2;
            this.remark.Width = 177;
            // 
            // id1
            // 
            this.id1.Caption = "編號";
            this.id1.FieldName = "id";
            this.id1.Name = "id1";
            this.id1.OptionsFilter.AllowAutoFilter = false;
            this.id1.OptionsFilter.AllowFilter = false;
            this.id1.Tag = "2";
            this.id1.Width = 20;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "序號";
            this.gridColumn12.FieldName = "sequence_id";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // btnDel1
            // 
            this.btnDel1.Enabled = false;
            this.btnDel1.Image = ((System.Drawing.Image)(resources.GetObject("btnDel1.Image")));
            this.btnDel1.Location = new System.Drawing.Point(464, 69);
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
            this.btnAdd1.Location = new System.Drawing.Point(464, 28);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(64, 27);
            this.btnAdd1.TabIndex = 42;
            this.btnAdd1.Text = "增加";
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // frmCustComplain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "frmCustComplain";
            this.Text = "frmCustComplain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCustComplain_FormClosed);
            this.Load += new System.EventHandler(this.frmCustComplain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clMo_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clUnit_code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtappellate_date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtappellate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteexception_note_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luecustomer_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueseller_id.Properties)).EndInit();
            this.grpBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtreason_type_big.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luereason_type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memessential_reason_qc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memessential_reason_dept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memreslove_pro_revert.Properties)).EndInit();
            this.grpBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtdept_date2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdept_date2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdept_responsible_person2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdept_date1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdept_date1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdept_responsible_person1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memdept_prevent_recurrent_step.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memdept_correct_step.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtqc_exception_note_date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtqc_exception_note_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtqc_exception_note_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memqc_amend_effect_confirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtqc_date2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtqc_date2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtqc_responsible_person2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtqc_date1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtqc_date1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtqc_responsible_person1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memqc_prevent_recurrent_step.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memqc_correct_step.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memremark.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtbill_create_date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbill_create_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbill_create_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbill_date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbill_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnew_mo_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMostly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDept)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn oc_info;
        private DevExpress.XtraGrid.Columns.GridColumn order_qty;
        private DevExpress.XtraGrid.Columns.GridColumn unit_code;
        private DevExpress.XtraGrid.Columns.GridColumn arrive_date;
        private DevExpress.XtraGrid.Columns.GridColumn exception_detail;
        private DevExpress.XtraGrid.Columns.GridColumn disposal_pro;
        private DevExpress.XtraGrid.Columns.GridColumn mo_id;
        private DevExpress.XtraGrid.Columns.GridColumn solve_date;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn sequence_id;
        private System.Windows.Forms.Label lblreport_date;
        private DevExpress.XtraEditors.DateEdit dtappellate_date;
        private DevExpress.XtraEditors.ButtonEdit bteexception_note_id;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit luecustomer_id;
        private DevExpress.XtraEditors.SimpleButton btnFindCustomer;
        private DevExpress.XtraEditors.LookUpEdit lueseller_id;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grpBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label27;
        private DevExpress.XtraEditors.MemoEdit memessential_reason_qc;
        private DevExpress.XtraEditors.MemoEdit memessential_reason_dept;
        private System.Windows.Forms.Label lblremark;
        private DevExpress.XtraEditors.MemoEdit memreslove_pro_revert;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpBox2;
        private DevExpress.XtraEditors.MemoEdit memdept_correct_step;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.MemoEdit memdept_prevent_recurrent_step;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.DateEdit dtdept_date2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit txtdept_responsible_person2;
        private DevExpress.XtraEditors.DateEdit dtdept_date1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit txtdept_responsible_person1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label21;
        private DevExpress.XtraEditors.MemoEdit memqc_amend_effect_confirm;
        private DevExpress.XtraEditors.DateEdit dtqc_date2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.TextEdit txtqc_responsible_person2;
        private DevExpress.XtraEditors.DateEdit dtqc_date1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private DevExpress.XtraEditors.TextEdit txtqc_responsible_person1;
        private System.Windows.Forms.Label label19;
        private DevExpress.XtraEditors.MemoEdit memqc_prevent_recurrent_step;
        private System.Windows.Forms.Label label20;
        private DevExpress.XtraEditors.MemoEdit memqc_correct_step;
        private DevExpress.XtraEditors.DateEdit dtqc_exception_note_date;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label22;
        private DevExpress.XtraEditors.TextEdit txtqc_exception_note_by;
        private System.Windows.Forms.Label label23;
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
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnDel1;
        private DevExpress.XtraEditors.SimpleButton btnAdd1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDept;
        private DevExpress.XtraGrid.Columns.GridColumn dept_id;
        private DevExpress.XtraGrid.Columns.GridColumn responsible;
        private DevExpress.XtraGrid.Columns.GridColumn id1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn remark;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit clDepartment;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit clMo_id;
        private DevExpress.XtraGrid.Columns.GridColumn remark1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit clUnit_code;
        private DevExpress.XtraEditors.LookUpEdit luereason_type;
        private System.Windows.Forms.Label label26;
        private DevExpress.XtraEditors.TextEdit txtreason_type_big;
        private System.Windows.Forms.BindingSource bdsMostly;
        private System.Windows.Forms.BindingSource bdsDept;
        private System.Windows.Forms.BindingSource bdsDetail;
        private System.Windows.Forms.Label label28;
        private DevExpress.XtraEditors.TextEdit txtnew_mo_id;
        private ModuleClass.LineY lineY1;
        private ModuleClass.LineX lineX1;
        private ModuleClass.LineY lineY2;
        private DevExpress.XtraEditors.TextEdit txtCustomer_name;
        private DevExpress.XtraEditors.DateEdit dtbill_create_date;
        private DevExpress.XtraEditors.TextEdit txtbill_create_by;
        private DevExpress.XtraEditors.DateEdit dtbill_date;
    }
}