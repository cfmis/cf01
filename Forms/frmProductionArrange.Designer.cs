namespace cf01.Forms
{
    partial class frmProductionArrange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionArrange));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExpToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMachine_status = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMakeOrderStatus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInput = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvImputExcel = new System.Windows.Forms.DataGridView();
            this.colDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoUrgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReqDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblRemark3 = new System.Windows.Forms.Label();
            this.lblRemark2 = new System.Windows.Forms.Label();
            this.lblRemark1 = new System.Windows.Forms.Label();
            this.lblImput = new System.Windows.Forms.Label();
            this.btnSaveExcel = new System.Windows.Forms.Button();
            this.btnImputExcel = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtNow_date = new System.Windows.Forms.MaskedTextBox();
            this.lblNow_date = new System.Windows.Forms.Label();
            this.cmbPrd_status = new System.Windows.Forms.ComboBox();
            this.lblPrd_status = new System.Windows.Forms.Label();
            this.txtProductNo = new System.Windows.Forms.TextBox();
            this.lblProductNo = new System.Windows.Forms.Label();
            this.cmbMachine = new System.Windows.Forms.ComboBox();
            this.txtReq_f_date = new System.Windows.Forms.TextBox();
            this.lblReq_f_date = new System.Windows.Forms.Label();
            this.txtCust_o_date = new System.Windows.Forms.TextBox();
            this.lblCust_o_date = new System.Windows.Forms.Label();
            this.cmbMoUrgent = new System.Windows.Forms.ComboBox();
            this.lblMoUrgent = new System.Windows.Forms.Label();
            this.lblDept = new System.Windows.Forms.Label();
            this.txtgoods_desc = new System.Windows.Forms.TextBox();
            this.cmbProductDept = new System.Windows.Forms.ComboBox();
            this.lblmo_id = new System.Windows.Forms.Label();
            this.lblArrange_id = new System.Windows.Forms.Label();
            this.txtmo_id = new System.Windows.Forms.TextBox();
            this.txtArrange_id = new System.Windows.Forms.TextBox();
            this.cmbGoods_id = new System.Windows.Forms.ComboBox();
            this.msktxtActive_start_time = new System.Windows.Forms.MaskedTextBox();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.msktxtEstimate_start_time = new System.Windows.Forms.MaskedTextBox();
            this.txtPrd_qty = new System.Windows.Forms.TextBox();
            this.msktxtActive_start_date = new System.Windows.Forms.MaskedTextBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.msktxtEstimate_time = new System.Windows.Forms.MaskedTextBox();
            this.msktxtEstimate_start_date = new System.Windows.Forms.MaskedTextBox();
            this.lblNext_dept = new System.Windows.Forms.Label();
            this.msktxtEstimate_date = new System.Windows.Forms.MaskedTextBox();
            this.txtArrange_seq = new System.Windows.Forms.TextBox();
            this.txtRequest_time = new System.Windows.Forms.TextBox();
            this.txtMachine_stand_qty = new System.Windows.Forms.TextBox();
            this.lblRequest_time = new System.Windows.Forms.Label();
            this.txtToDept_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGoods_id = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEstimate_date = new System.Windows.Forms.Label();
            this.masktxtPrd_date = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrd_seq = new System.Windows.Forms.Label();
            this.lblEstimate_time = new System.Windows.Forms.Label();
            this.txtToDep = new System.Windows.Forms.TextBox();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.txtPrd_ver = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblArrange_seq = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrd_seq = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMachine = new System.Windows.Forms.Label();
            this.tabDetail = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvPA = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrange_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrange_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_mo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMo_urgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlag_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtWork = new System.Windows.Forms.DataGridViewImageColumn();
            this.colGoods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrange_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrange_machine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCust_o_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReq_f_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMachine_stand_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstimated_start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstimated_start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstimated_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstimated_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colreq_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive_start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive_start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_end_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_req_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_dep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_ver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArt_image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_status_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabFind = new System.Windows.Forms.TabPage();
            this.mcFindDate = new System.Windows.Forms.MonthCalendar();
            this.lblPrd_dept = new System.Windows.Forms.Label();
            this.lblCpStatus = new System.Windows.Forms.Label();
            this.lblArrange_machine = new System.Windows.Forms.Label();
            this.cmbFindStatus = new System.Windows.Forms.ComboBox();
            this.lblMo_id_sq = new System.Windows.Forms.Label();
            this.txtFindWorker = new System.Windows.Forms.TextBox();
            this.chkIsCancel = new System.Windows.Forms.CheckBox();
            this.lblFindWorker = new System.Windows.Forms.Label();
            this.grbMoStatus = new System.Windows.Forms.GroupBox();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdbNoComplete = new System.Windows.Forms.RadioButton();
            this.rdbIsComplete = new System.Windows.Forms.RadioButton();
            this.mktFindDate = new System.Windows.Forms.MaskedTextBox();
            this.grbMachineStatus = new System.Windows.Forms.GroupBox();
            this.rdbAllMachine = new System.Windows.Forms.RadioButton();
            this.rdbNoMachine = new System.Windows.Forms.RadioButton();
            this.rdbIsMachine = new System.Windows.Forms.RadioButton();
            this.lblFindDate = new System.Windows.Forms.Label();
            this.txtMo_id_sq = new System.Windows.Forms.TextBox();
            this.lblMoStatus = new System.Windows.Forms.Label();
            this.cmbFindMachine = new System.Windows.Forms.ComboBox();
            this.lblMachineStatus = new System.Windows.Forms.Label();
            this.cmbFindDep = new System.Windows.Forms.ComboBox();
            this.btnActiveFind = new System.Windows.Forms.Button();
            this.tabInsert = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtSeqFrom = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHour_std_qty = new System.Windows.Forms.TextBox();
            this.lblLine_num = new System.Windows.Forms.Label();
            this.btnSaveArrange = new System.Windows.Forms.Button();
            this.btnArrange_seq = new System.Windows.Forms.Button();
            this.lblhour_std_qty = new System.Windows.Forms.Label();
            this.lblHour_run_num = new System.Windows.Forms.Label();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHour_run_num = new System.Windows.Forms.TextBox();
            this.txtLine_num = new System.Windows.Forms.TextBox();
            this.txttSeqTo = new System.Windows.Forms.TextBox();
            this.tabSort = new System.Windows.Forms.TabPage();
            this.lblSortTo = new System.Windows.Forms.Label();
            this.lblSortFrom = new System.Windows.Forms.Label();
            this.dgvSortFrom = new System.Windows.Forms.DataGridView();
            this.colSort_From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSortCode_From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSortType_From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.dgvSortTo = new System.Windows.Forms.DataGridView();
            this.colSort_To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSortCode_To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSortType_To = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnConfSort = new System.Windows.Forms.Button();
            this.btnAddSort = new System.Windows.Forms.Button();
            this.btnDelSort = new System.Windows.Forms.Button();
            this.timFind = new System.Windows.Forms.Timer(this.components);
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
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkSetWorker = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabInput.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImputExcel)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabDetail.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPA)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabFind.SuspendLayout();
            this.grbMoStatus.SuspendLayout();
            this.grbMachineStatus.SuspendLayout();
            this.tabInsert.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortTo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator7,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnCancel,
            this.toolStripSeparator2,
            this.btnDel,
            this.toolStripSeparator3,
            this.btnFind,
            this.toolStripSeparator9,
            this.btnExpToExcel,
            this.toolStripSeparator5,
            this.btnMachine_status,
            this.toolStripSeparator6,
            this.btnMakeOrderStatus,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1284, 38);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = false;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 35);
            this.btnExit.Text = "退出(&X)";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 38);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 35);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.Text = "取消(&U)";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnDel
            // 
            this.btnDel.AutoSize = false;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(65, 35);
            this.btnDel.Text = "刪除(&D)";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 35);
            this.btnFind.Text = "查找(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 38);
            // 
            // btnExpToExcel
            // 
            this.btnExpToExcel.AutoSize = false;
            this.btnExpToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExpToExcel.Image")));
            this.btnExpToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpToExcel.Name = "btnExpToExcel";
            this.btnExpToExcel.Size = new System.Drawing.Size(65, 35);
            this.btnExpToExcel.Text = "匯出(&E)";
            this.btnExpToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExpToExcel.Click += new System.EventHandler(this.btnExpToExcel_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // btnMachine_status
            // 
            this.btnMachine_status.AutoSize = false;
            this.btnMachine_status.Image = ((System.Drawing.Image)(resources.GetObject("btnMachine_status.Image")));
            this.btnMachine_status.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMachine_status.Name = "btnMachine_status";
            this.btnMachine_status.Size = new System.Drawing.Size(97, 35);
            this.btnMachine_status.Text = "機器生產狀態";
            this.btnMachine_status.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMachine_status.Click += new System.EventHandler(this.btnMachine_status_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // btnMakeOrderStatus
            // 
            this.btnMakeOrderStatus.AutoSize = false;
            this.btnMakeOrderStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnMakeOrderStatus.Image")));
            this.btnMakeOrderStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMakeOrderStatus.Name = "btnMakeOrderStatus";
            this.btnMakeOrderStatus.Size = new System.Drawing.Size(65, 35);
            this.btnMakeOrderStatus.Text = "制單狀態";
            this.btnMakeOrderStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMakeOrderStatus.Click += new System.EventHandler(this.btnMakeOrderStatus_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInput);
            this.tabControl1.Controls.Add(this.tabDetail);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.ItemSize = new System.Drawing.Size(20, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1284, 694);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabInput
            // 
            this.tabInput.BackColor = System.Drawing.Color.OldLace;
            this.tabInput.Controls.Add(this.panel5);
            this.tabInput.Controls.Add(this.panel4);
            this.tabInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabInput.Location = new System.Drawing.Point(4, 29);
            this.tabInput.Name = "tabInput";
            this.tabInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabInput.Size = new System.Drawing.Size(1276, 661);
            this.tabInput.TabIndex = 0;
            this.tabInput.Text = "排程錄入";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvImputExcel);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 262);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1270, 396);
            this.panel5.TabIndex = 50;
            // 
            // dgvImputExcel
            // 
            this.dgvImputExcel.AllowUserToAddRows = false;
            this.dgvImputExcel.ColumnHeadersHeight = 30;
            this.dgvImputExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvImputExcel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDep,
            this.colMo,
            this.colItem,
            this.colQty,
            this.colDate,
            this.colMac,
            this.colGroup,
            this.colMoUrgent,
            this.colVer,
            this.colToDep,
            this.colPrdSeq,
            this.colCustDate,
            this.colReqDate});
            this.dgvImputExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImputExcel.Location = new System.Drawing.Point(0, 61);
            this.dgvImputExcel.Name = "dgvImputExcel";
            this.dgvImputExcel.RowTemplate.Height = 24;
            this.dgvImputExcel.Size = new System.Drawing.Size(1270, 335);
            this.dgvImputExcel.TabIndex = 47;
            this.dgvImputExcel.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvImputExcel_RowPostPaint);
            // 
            // colDep
            // 
            this.colDep.DataPropertyName = "部門";
            this.colDep.FillWeight = 80F;
            this.colDep.HeaderText = "部門";
            this.colDep.Name = "colDep";
            this.colDep.Width = 80;
            // 
            // colMo
            // 
            this.colMo.DataPropertyName = "制單編號";
            this.colMo.FillWeight = 120F;
            this.colMo.HeaderText = "制單編號";
            this.colMo.Name = "colMo";
            // 
            // colItem
            // 
            this.colItem.DataPropertyName = "產品編號";
            this.colItem.FillWeight = 200F;
            this.colItem.HeaderText = "產品編號";
            this.colItem.Name = "colItem";
            this.colItem.Width = 200;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "要求數量";
            this.colQty.HeaderText = "要求數量";
            this.colQty.Name = "colQty";
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "排期日期";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDate.HeaderText = "排期日期";
            this.colDate.Name = "colDate";
            // 
            // colMac
            // 
            this.colMac.DataPropertyName = "安排機器";
            this.colMac.HeaderText = "安排機器";
            this.colMac.Name = "colMac";
            // 
            // colGroup
            // 
            this.colGroup.DataPropertyName = "組別";
            this.colGroup.HeaderText = "組別";
            this.colGroup.Name = "colGroup";
            // 
            // colMoUrgent
            // 
            this.colMoUrgent.DataPropertyName = "急單";
            this.colMoUrgent.HeaderText = "急單";
            this.colMoUrgent.Name = "colMoUrgent";
            this.colMoUrgent.Width = 80;
            // 
            // colVer
            // 
            this.colVer.DataPropertyName = "版本號";
            this.colVer.HeaderText = "版本號";
            this.colVer.Name = "colVer";
            // 
            // colToDep
            // 
            this.colToDep.DataPropertyName = "下部門";
            this.colToDep.HeaderText = "下部門";
            this.colToDep.Name = "colToDep";
            // 
            // colPrdSeq
            // 
            this.colPrdSeq.DataPropertyName = "序號";
            this.colPrdSeq.HeaderText = "序號";
            this.colPrdSeq.Name = "colPrdSeq";
            // 
            // colCustDate
            // 
            this.colCustDate.DataPropertyName = "客落單日期";
            this.colCustDate.HeaderText = "客落單日期";
            this.colCustDate.Name = "colCustDate";
            // 
            // colReqDate
            // 
            this.colReqDate.DataPropertyName = "要求完成時間";
            this.colReqDate.HeaderText = "要求完成時間";
            this.colReqDate.Name = "colReqDate";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnEdit);
            this.panel6.Controls.Add(this.lblRemark3);
            this.panel6.Controls.Add(this.lblRemark2);
            this.panel6.Controls.Add(this.lblRemark1);
            this.panel6.Controls.Add(this.lblImput);
            this.panel6.Controls.Add(this.btnSaveExcel);
            this.panel6.Controls.Add(this.btnImputExcel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1270, 61);
            this.panel6.TabIndex = 48;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(827, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 31);
            this.btnEdit.TabIndex = 53;
            this.btnEdit.Text = "儲存修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // lblRemark3
            // 
            this.lblRemark3.AutoSize = true;
            this.lblRemark3.ForeColor = System.Drawing.Color.Red;
            this.lblRemark3.Location = new System.Drawing.Point(370, 23);
            this.lblRemark3.Name = "lblRemark3";
            this.lblRemark3.Size = new System.Drawing.Size(106, 17);
            this.lblRemark3.TabIndex = 52;
            this.lblRemark3.Text = "欄為必有內容。";
            // 
            // lblRemark2
            // 
            this.lblRemark2.AutoSize = true;
            this.lblRemark2.ForeColor = System.Drawing.Color.Blue;
            this.lblRemark2.Location = new System.Drawing.Point(339, 23);
            this.lblRemark2.Name = "lblRemark2";
            this.lblRemark2.Size = new System.Drawing.Size(36, 17);
            this.lblRemark2.TabIndex = 51;
            this.lblRemark2.Text = "藍色";
            // 
            // lblRemark1
            // 
            this.lblRemark1.AutoSize = true;
            this.lblRemark1.ForeColor = System.Drawing.Color.Red;
            this.lblRemark1.Location = new System.Drawing.Point(22, 23);
            this.lblRemark1.Name = "lblRemark1";
            this.lblRemark1.Size = new System.Drawing.Size(321, 17);
            this.lblRemark1.TabIndex = 50;
            this.lblRemark1.Text = "注意：匯入的Excel文件，須按照下表的格式。其中";
            // 
            // lblImput
            // 
            this.lblImput.AutoSize = true;
            this.lblImput.Location = new System.Drawing.Point(4, 2);
            this.lblImput.Name = "lblImput";
            this.lblImput.Size = new System.Drawing.Size(96, 17);
            this.lblImput.TabIndex = 49;
            this.lblImput.Text = "批量匯入記錄:";
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(700, 16);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(94, 31);
            this.btnSaveExcel.TabIndex = 48;
            this.btnSaveExcel.Text = "儲存新記錄";
            this.btnSaveExcel.UseVisualStyleBackColor = true;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // btnImputExcel
            // 
            this.btnImputExcel.Location = new System.Drawing.Point(572, 16);
            this.btnImputExcel.Name = "btnImputExcel";
            this.btnImputExcel.Size = new System.Drawing.Size(94, 31);
            this.btnImputExcel.TabIndex = 46;
            this.btnImputExcel.Text = "從Excel匯入";
            this.btnImputExcel.UseVisualStyleBackColor = true;
            this.btnImputExcel.Click += new System.EventHandler(this.btnImputExcel_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtNow_date);
            this.panel4.Controls.Add(this.lblNow_date);
            this.panel4.Controls.Add(this.cmbPrd_status);
            this.panel4.Controls.Add(this.lblPrd_status);
            this.panel4.Controls.Add(this.txtProductNo);
            this.panel4.Controls.Add(this.lblProductNo);
            this.panel4.Controls.Add(this.cmbMachine);
            this.panel4.Controls.Add(this.txtReq_f_date);
            this.panel4.Controls.Add(this.lblReq_f_date);
            this.panel4.Controls.Add(this.txtCust_o_date);
            this.panel4.Controls.Add(this.lblCust_o_date);
            this.panel4.Controls.Add(this.cmbMoUrgent);
            this.panel4.Controls.Add(this.lblMoUrgent);
            this.panel4.Controls.Add(this.lblDept);
            this.panel4.Controls.Add(this.txtgoods_desc);
            this.panel4.Controls.Add(this.cmbProductDept);
            this.panel4.Controls.Add(this.lblmo_id);
            this.panel4.Controls.Add(this.lblArrange_id);
            this.panel4.Controls.Add(this.txtmo_id);
            this.panel4.Controls.Add(this.txtArrange_id);
            this.panel4.Controls.Add(this.cmbGoods_id);
            this.panel4.Controls.Add(this.msktxtActive_start_time);
            this.panel4.Controls.Add(this.cmbGroup);
            this.panel4.Controls.Add(this.msktxtEstimate_start_time);
            this.panel4.Controls.Add(this.txtPrd_qty);
            this.panel4.Controls.Add(this.msktxtActive_start_date);
            this.panel4.Controls.Add(this.lblGroup);
            this.panel4.Controls.Add(this.msktxtEstimate_time);
            this.panel4.Controls.Add(this.msktxtEstimate_start_date);
            this.panel4.Controls.Add(this.lblNext_dept);
            this.panel4.Controls.Add(this.msktxtEstimate_date);
            this.panel4.Controls.Add(this.txtArrange_seq);
            this.panel4.Controls.Add(this.txtRequest_time);
            this.panel4.Controls.Add(this.txtMachine_stand_qty);
            this.panel4.Controls.Add(this.lblRequest_time);
            this.panel4.Controls.Add(this.txtToDept_name);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lblGoods_id);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.lblEstimate_date);
            this.panel4.Controls.Add(this.masktxtPrd_date);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.lblPrd_seq);
            this.panel4.Controls.Add(this.lblEstimate_time);
            this.panel4.Controls.Add(this.txtToDep);
            this.panel4.Controls.Add(this.txtBarCode);
            this.panel4.Controls.Add(this.txtPrd_ver);
            this.panel4.Controls.Add(this.lblBarcode);
            this.panel4.Controls.Add(this.lblArrange_seq);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtPrd_seq);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lblMachine);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1270, 259);
            this.panel4.TabIndex = 49;
            // 
            // txtNow_date
            // 
            this.txtNow_date.Location = new System.Drawing.Point(798, 9);
            this.txtNow_date.Mask = "0000/00/00";
            this.txtNow_date.Name = "txtNow_date";
            this.txtNow_date.PromptChar = ' ';
            this.txtNow_date.Size = new System.Drawing.Size(123, 23);
            this.txtNow_date.TabIndex = 61;
            this.txtNow_date.ValidatingType = typeof(System.DateTime);
            // 
            // lblNow_date
            // 
            this.lblNow_date.AutoSize = true;
            this.lblNow_date.Location = new System.Drawing.Point(725, 12);
            this.lblNow_date.Name = "lblNow_date";
            this.lblNow_date.Size = new System.Drawing.Size(68, 17);
            this.lblNow_date.TabIndex = 60;
            this.lblNow_date.Text = "當前日期:";
            // 
            // cmbPrd_status
            // 
            this.cmbPrd_status.FormattingEnabled = true;
            this.cmbPrd_status.Location = new System.Drawing.Point(798, 150);
            this.cmbPrd_status.Name = "cmbPrd_status";
            this.cmbPrd_status.Size = new System.Drawing.Size(123, 24);
            this.cmbPrd_status.TabIndex = 59;
            // 
            // lblPrd_status
            // 
            this.lblPrd_status.AutoSize = true;
            this.lblPrd_status.Location = new System.Drawing.Point(729, 154);
            this.lblPrd_status.Name = "lblPrd_status";
            this.lblPrd_status.Size = new System.Drawing.Size(64, 17);
            this.lblPrd_status.TabIndex = 58;
            this.lblPrd_status.Text = "生產狀態";
            // 
            // txtProductNo
            // 
            this.txtProductNo.Location = new System.Drawing.Point(1112, 12);
            this.txtProductNo.MaxLength = 10;
            this.txtProductNo.Name = "txtProductNo";
            this.txtProductNo.Size = new System.Drawing.Size(123, 23);
            this.txtProductNo.TabIndex = 57;
            this.txtProductNo.Visible = false;
            this.txtProductNo.Leave += new System.EventHandler(this.txtProductNo_Leave);
            // 
            // lblProductNo
            // 
            this.lblProductNo.AutoSize = true;
            this.lblProductNo.Location = new System.Drawing.Point(1043, 18);
            this.lblProductNo.Name = "lblProductNo";
            this.lblProductNo.Size = new System.Drawing.Size(64, 17);
            this.lblProductNo.TabIndex = 56;
            this.lblProductNo.Text = "安排工號";
            this.lblProductNo.Visible = false;
            // 
            // cmbMachine
            // 
            this.cmbMachine.DropDownWidth = 206;
            this.cmbMachine.FormattingEnabled = true;
            this.cmbMachine.Location = new System.Drawing.Point(123, 122);
            this.cmbMachine.Name = "cmbMachine";
            this.cmbMachine.Size = new System.Drawing.Size(151, 24);
            this.cmbMachine.TabIndex = 55;
            this.cmbMachine.Leave += new System.EventHandler(this.cmbMachine_Leave);
            // 
            // txtReq_f_date
            // 
            this.txtReq_f_date.Location = new System.Drawing.Point(798, 122);
            this.txtReq_f_date.Name = "txtReq_f_date";
            this.txtReq_f_date.Size = new System.Drawing.Size(123, 23);
            this.txtReq_f_date.TabIndex = 52;
            // 
            // lblReq_f_date
            // 
            this.lblReq_f_date.AutoSize = true;
            this.lblReq_f_date.Location = new System.Drawing.Point(701, 126);
            this.lblReq_f_date.Name = "lblReq_f_date";
            this.lblReq_f_date.Size = new System.Drawing.Size(92, 17);
            this.lblReq_f_date.TabIndex = 51;
            this.lblReq_f_date.Text = "要求完成時間";
            // 
            // txtCust_o_date
            // 
            this.txtCust_o_date.Location = new System.Drawing.Point(798, 94);
            this.txtCust_o_date.Name = "txtCust_o_date";
            this.txtCust_o_date.Size = new System.Drawing.Size(123, 23);
            this.txtCust_o_date.TabIndex = 50;
            // 
            // lblCust_o_date
            // 
            this.lblCust_o_date.AutoSize = true;
            this.lblCust_o_date.Location = new System.Drawing.Point(715, 97);
            this.lblCust_o_date.Name = "lblCust_o_date";
            this.lblCust_o_date.Size = new System.Drawing.Size(78, 17);
            this.lblCust_o_date.TabIndex = 49;
            this.lblCust_o_date.Text = "客落單日期";
            // 
            // cmbMoUrgent
            // 
            this.cmbMoUrgent.FormattingEnabled = true;
            this.cmbMoUrgent.Location = new System.Drawing.Point(574, 150);
            this.cmbMoUrgent.Name = "cmbMoUrgent";
            this.cmbMoUrgent.Size = new System.Drawing.Size(123, 24);
            this.cmbMoUrgent.TabIndex = 48;
            // 
            // lblMoUrgent
            // 
            this.lblMoUrgent.AutoSize = true;
            this.lblMoUrgent.Location = new System.Drawing.Point(533, 154);
            this.lblMoUrgent.Name = "lblMoUrgent";
            this.lblMoUrgent.Size = new System.Drawing.Size(36, 17);
            this.lblMoUrgent.TabIndex = 46;
            this.lblMoUrgent.Text = "急單";
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(54, 40);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(64, 17);
            this.lblDept.TabIndex = 37;
            this.lblDept.Text = "生產部門";
            // 
            // txtgoods_desc
            // 
            this.txtgoods_desc.Enabled = false;
            this.txtgoods_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtgoods_desc.Location = new System.Drawing.Point(574, 66);
            this.txtgoods_desc.Name = "txtgoods_desc";
            this.txtgoods_desc.ReadOnly = true;
            this.txtgoods_desc.Size = new System.Drawing.Size(347, 23);
            this.txtgoods_desc.TabIndex = 20;
            // 
            // cmbProductDept
            // 
            this.cmbProductDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductDept.DropDownWidth = 150;
            this.cmbProductDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbProductDept.Location = new System.Drawing.Point(123, 36);
            this.cmbProductDept.Name = "cmbProductDept";
            this.cmbProductDept.Size = new System.Drawing.Size(151, 24);
            this.cmbProductDept.TabIndex = 30;
            this.cmbProductDept.SelectedIndexChanged += new System.EventHandler(this.cmbProductDept_SelectedIndexChanged);
            this.cmbProductDept.Leave += new System.EventHandler(this.cmbProductDept_Leave);
            // 
            // lblmo_id
            // 
            this.lblmo_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblmo_id.ForeColor = System.Drawing.Color.Black;
            this.lblmo_id.Location = new System.Drawing.Point(50, 69);
            this.lblmo_id.Name = "lblmo_id";
            this.lblmo_id.Size = new System.Drawing.Size(68, 16);
            this.lblmo_id.TabIndex = 0;
            this.lblmo_id.Text = "制單編號";
            // 
            // lblArrange_id
            // 
            this.lblArrange_id.AutoSize = true;
            this.lblArrange_id.Location = new System.Drawing.Point(743, 39);
            this.lblArrange_id.Name = "lblArrange_id";
            this.lblArrange_id.Size = new System.Drawing.Size(50, 17);
            this.lblArrange_id.TabIndex = 45;
            this.lblArrange_id.Text = "記錄號";
            // 
            // txtmo_id
            // 
            this.txtmo_id.BackColor = System.Drawing.Color.GhostWhite;
            this.txtmo_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtmo_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtmo_id.Location = new System.Drawing.Point(123, 66);
            this.txtmo_id.MaxLength = 9;
            this.txtmo_id.Name = "txtmo_id";
            this.txtmo_id.Size = new System.Drawing.Size(116, 23);
            this.txtmo_id.TabIndex = 5;
            this.txtmo_id.Leave += new System.EventHandler(this.txtmo_id_Leave);
            // 
            // txtArrange_id
            // 
            this.txtArrange_id.Location = new System.Drawing.Point(798, 33);
            this.txtArrange_id.Name = "txtArrange_id";
            this.txtArrange_id.Size = new System.Drawing.Size(123, 23);
            this.txtArrange_id.TabIndex = 44;
            // 
            // cmbGoods_id
            // 
            this.cmbGoods_id.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbGoods_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbGoods_id.FormattingEnabled = true;
            this.cmbGoods_id.Location = new System.Drawing.Point(376, 66);
            this.cmbGoods_id.MaxLength = 18;
            this.cmbGoods_id.Name = "cmbGoods_id";
            this.cmbGoods_id.Size = new System.Drawing.Size(193, 24);
            this.cmbGoods_id.TabIndex = 6;
            this.cmbGoods_id.TextChanged += new System.EventHandler(this.cmbGoods_id_TextChanged);
            // 
            // msktxtActive_start_time
            // 
            this.msktxtActive_start_time.Enabled = false;
            this.msktxtActive_start_time.Location = new System.Drawing.Point(376, 209);
            this.msktxtActive_start_time.Mask = "90:00";
            this.msktxtActive_start_time.Name = "msktxtActive_start_time";
            this.msktxtActive_start_time.PromptChar = ' ';
            this.msktxtActive_start_time.Size = new System.Drawing.Size(123, 23);
            this.msktxtActive_start_time.TabIndex = 41;
            this.msktxtActive_start_time.ValidatingType = typeof(System.DateTime);
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.DropDownWidth = 150;
            this.cmbGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(574, 36);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(123, 24);
            this.cmbGroup.TabIndex = 43;
            // 
            // msktxtEstimate_start_time
            // 
            this.msktxtEstimate_start_time.Location = new System.Drawing.Point(376, 151);
            this.msktxtEstimate_start_time.Mask = "90:00";
            this.msktxtEstimate_start_time.Name = "msktxtEstimate_start_time";
            this.msktxtEstimate_start_time.PromptChar = ' ';
            this.msktxtEstimate_start_time.Size = new System.Drawing.Size(123, 23);
            this.msktxtEstimate_start_time.TabIndex = 41;
            this.msktxtEstimate_start_time.ValidatingType = typeof(System.DateTime);
            // 
            // txtPrd_qty
            // 
            this.txtPrd_qty.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtPrd_qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtPrd_qty.Location = new System.Drawing.Point(574, 94);
            this.txtPrd_qty.Name = "txtPrd_qty";
            this.txtPrd_qty.ReadOnly = true;
            this.txtPrd_qty.Size = new System.Drawing.Size(123, 23);
            this.txtPrd_qty.TabIndex = 14;
            // 
            // msktxtActive_start_date
            // 
            this.msktxtActive_start_date.Enabled = false;
            this.msktxtActive_start_date.Location = new System.Drawing.Point(123, 209);
            this.msktxtActive_start_date.Mask = "0000/00/00";
            this.msktxtActive_start_date.Name = "msktxtActive_start_date";
            this.msktxtActive_start_date.PromptChar = ' ';
            this.msktxtActive_start_date.Size = new System.Drawing.Size(151, 23);
            this.msktxtActive_start_date.TabIndex = 40;
            this.msktxtActive_start_date.ValidatingType = typeof(System.DateTime);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup.Location = new System.Drawing.Point(533, 39);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(36, 17);
            this.lblGroup.TabIndex = 42;
            this.lblGroup.Text = "組別";
            // 
            // msktxtEstimate_time
            // 
            this.msktxtEstimate_time.Location = new System.Drawing.Point(376, 180);
            this.msktxtEstimate_time.Mask = "90:00";
            this.msktxtEstimate_time.Name = "msktxtEstimate_time";
            this.msktxtEstimate_time.PromptChar = ' ';
            this.msktxtEstimate_time.Size = new System.Drawing.Size(123, 23);
            this.msktxtEstimate_time.TabIndex = 41;
            this.msktxtEstimate_time.ValidatingType = typeof(System.DateTime);
            // 
            // msktxtEstimate_start_date
            // 
            this.msktxtEstimate_start_date.Location = new System.Drawing.Point(123, 151);
            this.msktxtEstimate_start_date.Mask = "0000/00/00";
            this.msktxtEstimate_start_date.Name = "msktxtEstimate_start_date";
            this.msktxtEstimate_start_date.PromptChar = ' ';
            this.msktxtEstimate_start_date.Size = new System.Drawing.Size(151, 23);
            this.msktxtEstimate_start_date.TabIndex = 40;
            this.msktxtEstimate_start_date.ValidatingType = typeof(System.DateTime);
            // 
            // lblNext_dept
            // 
            this.lblNext_dept.AutoSize = true;
            this.lblNext_dept.Location = new System.Drawing.Point(54, 97);
            this.lblNext_dept.Name = "lblNext_dept";
            this.lblNext_dept.Size = new System.Drawing.Size(64, 17);
            this.lblNext_dept.TabIndex = 37;
            this.lblNext_dept.Text = "下一部門";
            // 
            // msktxtEstimate_date
            // 
            this.msktxtEstimate_date.Location = new System.Drawing.Point(123, 180);
            this.msktxtEstimate_date.Mask = "0000/00/00";
            this.msktxtEstimate_date.Name = "msktxtEstimate_date";
            this.msktxtEstimate_date.PromptChar = ' ';
            this.msktxtEstimate_date.Size = new System.Drawing.Size(151, 23);
            this.msktxtEstimate_date.TabIndex = 40;
            this.msktxtEstimate_date.ValidatingType = typeof(System.DateTime);
            // 
            // txtArrange_seq
            // 
            this.txtArrange_seq.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtArrange_seq.Location = new System.Drawing.Point(574, 123);
            this.txtArrange_seq.Name = "txtArrange_seq";
            this.txtArrange_seq.ReadOnly = true;
            this.txtArrange_seq.Size = new System.Drawing.Size(123, 23);
            this.txtArrange_seq.TabIndex = 38;
            // 
            // txtRequest_time
            // 
            this.txtRequest_time.Location = new System.Drawing.Point(574, 180);
            this.txtRequest_time.Name = "txtRequest_time";
            this.txtRequest_time.Size = new System.Drawing.Size(123, 23);
            this.txtRequest_time.TabIndex = 39;
            // 
            // txtMachine_stand_qty
            // 
            this.txtMachine_stand_qty.Enabled = false;
            this.txtMachine_stand_qty.Location = new System.Drawing.Point(376, 123);
            this.txtMachine_stand_qty.Name = "txtMachine_stand_qty";
            this.txtMachine_stand_qty.ReadOnly = true;
            this.txtMachine_stand_qty.Size = new System.Drawing.Size(123, 23);
            this.txtMachine_stand_qty.TabIndex = 38;
            // 
            // lblRequest_time
            // 
            this.lblRequest_time.AutoSize = true;
            this.lblRequest_time.Location = new System.Drawing.Point(505, 186);
            this.lblRequest_time.Name = "lblRequest_time";
            this.lblRequest_time.Size = new System.Drawing.Size(64, 17);
            this.lblRequest_time.TabIndex = 37;
            this.lblRequest_time.Text = "完成需時";
            // 
            // txtToDept_name
            // 
            this.txtToDept_name.Enabled = false;
            this.txtToDept_name.Location = new System.Drawing.Point(166, 94);
            this.txtToDept_name.Name = "txtToDept_name";
            this.txtToDept_name.ReadOnly = true;
            this.txtToDept_name.Size = new System.Drawing.Size(108, 23);
            this.txtToDept_name.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 37;
            this.label6.Text = "實際開始日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "預計開始日期";
            // 
            // lblGoods_id
            // 
            this.lblGoods_id.AutoSize = true;
            this.lblGoods_id.Location = new System.Drawing.Point(307, 69);
            this.lblGoods_id.Name = "lblGoods_id";
            this.lblGoods_id.Size = new System.Drawing.Size(64, 17);
            this.lblGoods_id.TabIndex = 37;
            this.lblGoods_id.Text = "物料編號";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "實際開始時間";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(307, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 37;
            this.label8.Text = "安排日期";
            // 
            // lblEstimate_date
            // 
            this.lblEstimate_date.AutoSize = true;
            this.lblEstimate_date.Location = new System.Drawing.Point(26, 186);
            this.lblEstimate_date.Name = "lblEstimate_date";
            this.lblEstimate_date.Size = new System.Drawing.Size(92, 17);
            this.lblEstimate_date.TabIndex = 37;
            this.lblEstimate_date.Text = "預計完成日期";
            // 
            // masktxtPrd_date
            // 
            this.masktxtPrd_date.Location = new System.Drawing.Point(376, 39);
            this.masktxtPrd_date.Mask = "0000/00/00";
            this.masktxtPrd_date.Name = "masktxtPrd_date";
            this.masktxtPrd_date.PromptChar = ' ';
            this.masktxtPrd_date.Size = new System.Drawing.Size(123, 23);
            this.masktxtPrd_date.TabIndex = 40;
            this.masktxtPrd_date.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "預計開始時間";
            // 
            // lblPrd_seq
            // 
            this.lblPrd_seq.AutoSize = true;
            this.lblPrd_seq.Location = new System.Drawing.Point(335, 97);
            this.lblPrd_seq.Name = "lblPrd_seq";
            this.lblPrd_seq.Size = new System.Drawing.Size(36, 17);
            this.lblPrd_seq.TabIndex = 37;
            this.lblPrd_seq.Text = "序號";
            // 
            // lblEstimate_time
            // 
            this.lblEstimate_time.AutoSize = true;
            this.lblEstimate_time.Location = new System.Drawing.Point(279, 186);
            this.lblEstimate_time.Name = "lblEstimate_time";
            this.lblEstimate_time.Size = new System.Drawing.Size(92, 17);
            this.lblEstimate_time.TabIndex = 37;
            this.lblEstimate_time.Text = "預計完成時間";
            // 
            // txtToDep
            // 
            this.txtToDep.Enabled = false;
            this.txtToDep.Location = new System.Drawing.Point(123, 94);
            this.txtToDep.Name = "txtToDep";
            this.txtToDep.ReadOnly = true;
            this.txtToDep.Size = new System.Drawing.Size(38, 23);
            this.txtToDep.TabIndex = 39;
            this.txtToDep.TextChanged += new System.EventHandler(this.txtToDep_TextChanged);
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.Plum;
            this.txtBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBarCode.Location = new System.Drawing.Point(123, 9);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(376, 23);
            this.txtBarCode.TabIndex = 0;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // txtPrd_ver
            // 
            this.txtPrd_ver.Enabled = false;
            this.txtPrd_ver.Location = new System.Drawing.Point(243, 66);
            this.txtPrd_ver.Name = "txtPrd_ver";
            this.txtPrd_ver.ReadOnly = true;
            this.txtPrd_ver.Size = new System.Drawing.Size(31, 23);
            this.txtPrd_ver.TabIndex = 39;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblBarcode.ForeColor = System.Drawing.Color.Black;
            this.lblBarcode.Location = new System.Drawing.Point(40, 12);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(78, 17);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "條碼掃描區";
            // 
            // lblArrange_seq
            // 
            this.lblArrange_seq.AutoSize = true;
            this.lblArrange_seq.Location = new System.Drawing.Point(505, 126);
            this.lblArrange_seq.Name = "lblArrange_seq";
            this.lblArrange_seq.Size = new System.Drawing.Size(64, 17);
            this.lblArrange_seq.TabIndex = 37;
            this.lblArrange_seq.Text = "生產順序";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(505, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "生產數量";
            // 
            // txtPrd_seq
            // 
            this.txtPrd_seq.Enabled = false;
            this.txtPrd_seq.Location = new System.Drawing.Point(376, 94);
            this.txtPrd_seq.Name = "txtPrd_seq";
            this.txtPrd_seq.ReadOnly = true;
            this.txtPrd_seq.Size = new System.Drawing.Size(123, 23);
            this.txtPrd_seq.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "機器標準啤數";
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Location = new System.Drawing.Point(54, 126);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(64, 17);
            this.lblMachine.TabIndex = 37;
            this.lblMachine.Text = "安排機器";
            // 
            // tabDetail
            // 
            this.tabDetail.BackColor = System.Drawing.Color.OldLace;
            this.tabDetail.Controls.Add(this.panel2);
            this.tabDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabDetail.Location = new System.Drawing.Point(4, 29);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetail.Size = new System.Drawing.Size(1276, 661);
            this.tabDetail.TabIndex = 1;
            this.tabDetail.Text = "排程明細";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl3);
            this.panel2.Controls.Add(this.tabControl2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1270, 655);
            this.panel2.TabIndex = 3;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage1);
            this.tabControl3.Controls.Add(this.tabPage2);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 238);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1270, 417);
            this.tabControl3.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvPA);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1262, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "明細";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvPA
            // 
            this.dgvPA.AllowUserToAddRows = false;
            this.dgvPA.ColumnHeadersHeight = 40;
            this.dgvPA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colArrange_seq,
            this.colArrange_date,
            this.colPrd_mo,
            this.colMo_urgent,
            this.colFlag_desc,
            this.colPrd_item,
            this.colArtWork,
            this.colGoods_name,
            this.colArrange_qty,
            this.colArrange_machine,
            this.colCust_o_date,
            this.colReq_f_date,
            this.colMachine_stand_qty,
            this.colEstimated_start_date,
            this.colEstimated_start_time,
            this.colEstimated_date,
            this.colEstimated_time,
            this.colreq_time,
            this.colActive_start_date,
            this.colActive_start_time,
            this.colPrd_end_time,
            this.colPrd_req_time,
            this.colPrd_qty,
            this.colJmTime,
            this.colPrd_dep,
            this.colPrd_seq,
            this.colPrd_ver,
            this.colToDept,
            this.colArt_image,
            this.colProductNo,
            this.colPrd_status,
            this.colPrd_status_desc});
            this.dgvPA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPA.Location = new System.Drawing.Point(3, 3);
            this.dgvPA.Name = "dgvPA";
            this.dgvPA.RowHeadersWidth = 40;
            this.dgvPA.RowTemplate.Height = 80;
            this.dgvPA.Size = new System.Drawing.Size(1256, 382);
            this.dgvPA.TabIndex = 1;
            this.dgvPA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPA_CellClick);
            this.dgvPA.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPA_CellFormatting);
            this.dgvPA.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPA_CellLeave);
            this.dgvPA.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPA_RowPostPaint);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "arrange_id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            this.colId.Width = 50;
            // 
            // colArrange_seq
            // 
            this.colArrange_seq.DataPropertyName = "arrange_seq";
            this.colArrange_seq.HeaderText = "安排順序";
            this.colArrange_seq.Name = "colArrange_seq";
            this.colArrange_seq.Width = 45;
            // 
            // colArrange_date
            // 
            this.colArrange_date.DataPropertyName = "arrange_date";
            this.colArrange_date.HeaderText = "排期日期";
            this.colArrange_date.Name = "colArrange_date";
            // 
            // colPrd_mo
            // 
            this.colPrd_mo.DataPropertyName = "prd_mo";
            this.colPrd_mo.HeaderText = "制單編號";
            this.colPrd_mo.Name = "colPrd_mo";
            // 
            // colMo_urgent
            // 
            this.colMo_urgent.DataPropertyName = "mo_urgent";
            this.colMo_urgent.HeaderText = "急單(代號)";
            this.colMo_urgent.Name = "colMo_urgent";
            this.colMo_urgent.Visible = false;
            this.colMo_urgent.Width = 70;
            // 
            // colFlag_desc
            // 
            this.colFlag_desc.DataPropertyName = "flag_desc";
            this.colFlag_desc.HeaderText = "急單(描述)";
            this.colFlag_desc.Name = "colFlag_desc";
            // 
            // colPrd_item
            // 
            this.colPrd_item.DataPropertyName = "prd_item";
            this.colPrd_item.HeaderText = "物料編號";
            this.colPrd_item.Name = "colPrd_item";
            this.colPrd_item.Width = 200;
            // 
            // colArtWork
            // 
            this.colArtWork.DataPropertyName = "art";
            this.colArtWork.HeaderText = "ArtWork";
            this.colArtWork.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colArtWork.Name = "colArtWork";
            this.colArtWork.Width = 80;
            // 
            // colGoods_name
            // 
            this.colGoods_name.DataPropertyName = "goods_name";
            this.colGoods_name.HeaderText = "物料描述";
            this.colGoods_name.Name = "colGoods_name";
            this.colGoods_name.Width = 250;
            // 
            // colArrange_qty
            // 
            this.colArrange_qty.DataPropertyName = "arrange_qty";
            this.colArrange_qty.HeaderText = "要求數量";
            this.colArrange_qty.Name = "colArrange_qty";
            // 
            // colArrange_machine
            // 
            this.colArrange_machine.DataPropertyName = "arrange_machine";
            this.colArrange_machine.HeaderText = "安排機器";
            this.colArrange_machine.Name = "colArrange_machine";
            // 
            // colCust_o_date
            // 
            this.colCust_o_date.DataPropertyName = "order_date";
            this.colCust_o_date.HeaderText = "落單日期";
            this.colCust_o_date.Name = "colCust_o_date";
            // 
            // colReq_f_date
            // 
            this.colReq_f_date.DataPropertyName = "req_f_date";
            this.colReq_f_date.HeaderText = "要求完成時間";
            this.colReq_f_date.Name = "colReq_f_date";
            this.colReq_f_date.Width = 120;
            // 
            // colMachine_stand_qty
            // 
            this.colMachine_stand_qty.DataPropertyName = "hour_std_qty";
            this.colMachine_stand_qty.HeaderText = "機器標準啤數/時";
            this.colMachine_stand_qty.Name = "colMachine_stand_qty";
            // 
            // colEstimated_start_date
            // 
            this.colEstimated_start_date.DataPropertyName = "estimated_start_date";
            this.colEstimated_start_date.HeaderText = "預計開始日期";
            this.colEstimated_start_date.Name = "colEstimated_start_date";
            this.colEstimated_start_date.Visible = false;
            // 
            // colEstimated_start_time
            // 
            this.colEstimated_start_time.DataPropertyName = "estimated_start_time";
            this.colEstimated_start_time.HeaderText = "預計開始時間";
            this.colEstimated_start_time.Name = "colEstimated_start_time";
            this.colEstimated_start_time.Visible = false;
            // 
            // colEstimated_date
            // 
            this.colEstimated_date.DataPropertyName = "estimated_date";
            this.colEstimated_date.HeaderText = "預計完成日期";
            this.colEstimated_date.Name = "colEstimated_date";
            this.colEstimated_date.Visible = false;
            this.colEstimated_date.Width = 160;
            // 
            // colEstimated_time
            // 
            this.colEstimated_time.DataPropertyName = "estimated_time";
            this.colEstimated_time.HeaderText = "預計完成時間";
            this.colEstimated_time.Name = "colEstimated_time";
            this.colEstimated_time.Width = 160;
            // 
            // colreq_time
            // 
            this.colreq_time.DataPropertyName = "req_time";
            this.colreq_time.HeaderText = "預計所需時間";
            this.colreq_time.Name = "colreq_time";
            this.colreq_time.Width = 80;
            // 
            // colActive_start_date
            // 
            this.colActive_start_date.DataPropertyName = "prd_date";
            this.colActive_start_date.HeaderText = "實際開始日期";
            this.colActive_start_date.Name = "colActive_start_date";
            // 
            // colActive_start_time
            // 
            this.colActive_start_time.DataPropertyName = "prd_start_time";
            this.colActive_start_time.HeaderText = "實際開始時間";
            this.colActive_start_time.Name = "colActive_start_time";
            // 
            // colPrd_end_time
            // 
            this.colPrd_end_time.DataPropertyName = "prd_end_time";
            this.colPrd_end_time.HeaderText = "實際結束時間";
            this.colPrd_end_time.Name = "colPrd_end_time";
            // 
            // colPrd_req_time
            // 
            this.colPrd_req_time.DataPropertyName = "prd_req_time";
            this.colPrd_req_time.HeaderText = "實際預計完成時間";
            this.colPrd_req_time.Name = "colPrd_req_time";
            // 
            // colPrd_qty
            // 
            this.colPrd_qty.DataPropertyName = "prd_qty";
            this.colPrd_qty.HeaderText = "實際生產數量";
            this.colPrd_qty.Name = "colPrd_qty";
            // 
            // colJmTime
            // 
            this.colJmTime.HeaderText = "預計校模時間";
            this.colJmTime.Name = "colJmTime";
            // 
            // colPrd_dep
            // 
            this.colPrd_dep.DataPropertyName = "prd_dep";
            this.colPrd_dep.HeaderText = "生產部門";
            this.colPrd_dep.Name = "colPrd_dep";
            this.colPrd_dep.Width = 60;
            // 
            // colPrd_seq
            // 
            this.colPrd_seq.DataPropertyName = "prd_seq";
            this.colPrd_seq.HeaderText = "序號";
            this.colPrd_seq.Name = "colPrd_seq";
            this.colPrd_seq.Visible = false;
            // 
            // colPrd_ver
            // 
            this.colPrd_ver.DataPropertyName = "prd_ver";
            this.colPrd_ver.HeaderText = "版本號";
            this.colPrd_ver.Name = "colPrd_ver";
            this.colPrd_ver.Visible = false;
            this.colPrd_ver.Width = 50;
            // 
            // colToDept
            // 
            this.colToDept.DataPropertyName = "to_dep";
            this.colToDept.HeaderText = "下一部門";
            this.colToDept.Name = "colToDept";
            this.colToDept.Width = 60;
            // 
            // colArt_image
            // 
            this.colArt_image.DataPropertyName = "art_image";
            this.colArt_image.HeaderText = "圖片文件";
            this.colArt_image.Name = "colArt_image";
            this.colArt_image.Visible = false;
            // 
            // colProductNo
            // 
            this.colProductNo.DataPropertyName = "prd_worker";
            this.colProductNo.HeaderText = "安排工號";
            this.colProductNo.Name = "colProductNo";
            // 
            // colPrd_status
            // 
            this.colPrd_status.DataPropertyName = "Prd_status";
            this.colPrd_status.HeaderText = "完成狀態";
            this.colPrd_status.Name = "colPrd_status";
            // 
            // colPrd_status_desc
            // 
            this.colPrd_status_desc.DataPropertyName = "Prd_status_desc";
            this.colPrd_status_desc.HeaderText = "完成狀態";
            this.colPrd_status_desc.Name = "colPrd_status_desc";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1262, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabFind);
            this.tabControl2.Controls.Add(this.tabInsert);
            this.tabControl2.Controls.Add(this.tabSort);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Padding = new System.Drawing.Point(0, 0);
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1270, 238);
            this.tabControl2.TabIndex = 23;
            // 
            // tabFind
            // 
            this.tabFind.Controls.Add(this.mcFindDate);
            this.tabFind.Controls.Add(this.lblPrd_dept);
            this.tabFind.Controls.Add(this.lblCpStatus);
            this.tabFind.Controls.Add(this.lblArrange_machine);
            this.tabFind.Controls.Add(this.cmbFindStatus);
            this.tabFind.Controls.Add(this.lblMo_id_sq);
            this.tabFind.Controls.Add(this.txtFindWorker);
            this.tabFind.Controls.Add(this.chkIsCancel);
            this.tabFind.Controls.Add(this.lblFindWorker);
            this.tabFind.Controls.Add(this.grbMoStatus);
            this.tabFind.Controls.Add(this.mktFindDate);
            this.tabFind.Controls.Add(this.grbMachineStatus);
            this.tabFind.Controls.Add(this.lblFindDate);
            this.tabFind.Controls.Add(this.txtMo_id_sq);
            this.tabFind.Controls.Add(this.lblMoStatus);
            this.tabFind.Controls.Add(this.cmbFindMachine);
            this.tabFind.Controls.Add(this.lblMachineStatus);
            this.tabFind.Controls.Add(this.cmbFindDep);
            this.tabFind.Controls.Add(this.btnActiveFind);
            this.tabFind.Location = new System.Drawing.Point(4, 25);
            this.tabFind.Name = "tabFind";
            this.tabFind.Padding = new System.Windows.Forms.Padding(3);
            this.tabFind.Size = new System.Drawing.Size(1262, 209);
            this.tabFind.TabIndex = 0;
            this.tabFind.Text = "查詢條件";
            this.tabFind.UseVisualStyleBackColor = true;
            // 
            // mcFindDate
            // 
            this.mcFindDate.Location = new System.Drawing.Point(613, 6);
            this.mcFindDate.Name = "mcFindDate";
            this.mcFindDate.TabIndex = 31;
            this.mcFindDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcFindDate_DateChanged);
            // 
            // lblPrd_dept
            // 
            this.lblPrd_dept.AutoSize = true;
            this.lblPrd_dept.Location = new System.Drawing.Point(25, 20);
            this.lblPrd_dept.Name = "lblPrd_dept";
            this.lblPrd_dept.Size = new System.Drawing.Size(64, 17);
            this.lblPrd_dept.TabIndex = 0;
            this.lblPrd_dept.Text = "生產部門";
            // 
            // lblCpStatus
            // 
            this.lblCpStatus.AutoSize = true;
            this.lblCpStatus.Location = new System.Drawing.Point(20, 95);
            this.lblCpStatus.Name = "lblCpStatus";
            this.lblCpStatus.Size = new System.Drawing.Size(64, 17);
            this.lblCpStatus.TabIndex = 30;
            this.lblCpStatus.Text = "完成狀態";
            // 
            // lblArrange_machine
            // 
            this.lblArrange_machine.AutoSize = true;
            this.lblArrange_machine.Location = new System.Drawing.Point(421, 20);
            this.lblArrange_machine.Name = "lblArrange_machine";
            this.lblArrange_machine.Size = new System.Drawing.Size(36, 17);
            this.lblArrange_machine.TabIndex = 0;
            this.lblArrange_machine.Text = "機器";
            // 
            // cmbFindStatus
            // 
            this.cmbFindStatus.FormattingEnabled = true;
            this.cmbFindStatus.Location = new System.Drawing.Point(462, 49);
            this.cmbFindStatus.Name = "cmbFindStatus";
            this.cmbFindStatus.Size = new System.Drawing.Size(121, 24);
            this.cmbFindStatus.TabIndex = 29;
            // 
            // lblMo_id_sq
            // 
            this.lblMo_id_sq.AutoSize = true;
            this.lblMo_id_sq.Location = new System.Drawing.Point(205, 20);
            this.lblMo_id_sq.Name = "lblMo_id_sq";
            this.lblMo_id_sq.Size = new System.Drawing.Size(64, 17);
            this.lblMo_id_sq.TabIndex = 0;
            this.lblMo_id_sq.Text = "制單編號";
            // 
            // txtFindWorker
            // 
            this.txtFindWorker.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFindWorker.Location = new System.Drawing.Point(274, 49);
            this.txtFindWorker.MaxLength = 10;
            this.txtFindWorker.Name = "txtFindWorker";
            this.txtFindWorker.Size = new System.Drawing.Size(114, 23);
            this.txtFindWorker.TabIndex = 28;
            this.txtFindWorker.Leave += new System.EventHandler(this.txtFindWorker_Leave);
            // 
            // chkIsCancel
            // 
            this.chkIsCancel.AutoSize = true;
            this.chkIsCancel.Location = new System.Drawing.Point(462, 94);
            this.chkIsCancel.Name = "chkIsCancel";
            this.chkIsCancel.Size = new System.Drawing.Size(139, 21);
            this.chkIsCancel.TabIndex = 11;
            this.chkIsCancel.Text = "已取消排程的記錄";
            this.chkIsCancel.UseVisualStyleBackColor = true;
            // 
            // lblFindWorker
            // 
            this.lblFindWorker.AutoSize = true;
            this.lblFindWorker.Location = new System.Drawing.Point(205, 55);
            this.lblFindWorker.Name = "lblFindWorker";
            this.lblFindWorker.Size = new System.Drawing.Size(64, 17);
            this.lblFindWorker.TabIndex = 27;
            this.lblFindWorker.Text = "安排人員";
            // 
            // grbMoStatus
            // 
            this.grbMoStatus.Controls.Add(this.rdbAll);
            this.grbMoStatus.Controls.Add(this.rdbNoComplete);
            this.grbMoStatus.Controls.Add(this.rdbIsComplete);
            this.grbMoStatus.Location = new System.Drawing.Point(90, 81);
            this.grbMoStatus.Name = "grbMoStatus";
            this.grbMoStatus.Size = new System.Drawing.Size(298, 40);
            this.grbMoStatus.TabIndex = 13;
            this.grbMoStatus.TabStop = false;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(221, 14);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(54, 21);
            this.rdbAll.TabIndex = 2;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "所有";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // rdbNoComplete
            // 
            this.rdbNoComplete.AutoSize = true;
            this.rdbNoComplete.Checked = true;
            this.rdbNoComplete.Location = new System.Drawing.Point(16, 14);
            this.rdbNoComplete.Name = "rdbNoComplete";
            this.rdbNoComplete.Size = new System.Drawing.Size(68, 21);
            this.rdbNoComplete.TabIndex = 0;
            this.rdbNoComplete.TabStop = true;
            this.rdbNoComplete.Text = "未完成";
            this.rdbNoComplete.UseVisualStyleBackColor = true;
            // 
            // rdbIsComplete
            // 
            this.rdbIsComplete.AutoSize = true;
            this.rdbIsComplete.Location = new System.Drawing.Point(114, 14);
            this.rdbIsComplete.Name = "rdbIsComplete";
            this.rdbIsComplete.Size = new System.Drawing.Size(68, 21);
            this.rdbIsComplete.TabIndex = 1;
            this.rdbIsComplete.TabStop = true;
            this.rdbIsComplete.Text = "已完成";
            this.rdbIsComplete.UseVisualStyleBackColor = true;
            // 
            // mktFindDate
            // 
            this.mktFindDate.Location = new System.Drawing.Point(90, 52);
            this.mktFindDate.Mask = "0000/00/00";
            this.mktFindDate.Name = "mktFindDate";
            this.mktFindDate.PromptChar = ' ';
            this.mktFindDate.Size = new System.Drawing.Size(109, 23);
            this.mktFindDate.TabIndex = 26;
            this.mktFindDate.ValidatingType = typeof(System.DateTime);
            // 
            // grbMachineStatus
            // 
            this.grbMachineStatus.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbMachineStatus.Controls.Add(this.rdbAllMachine);
            this.grbMachineStatus.Controls.Add(this.rdbNoMachine);
            this.grbMachineStatus.Controls.Add(this.rdbIsMachine);
            this.grbMachineStatus.Location = new System.Drawing.Point(90, 127);
            this.grbMachineStatus.Name = "grbMachineStatus";
            this.grbMachineStatus.Size = new System.Drawing.Size(298, 40);
            this.grbMachineStatus.TabIndex = 14;
            this.grbMachineStatus.TabStop = false;
            // 
            // rdbAllMachine
            // 
            this.rdbAllMachine.AutoSize = true;
            this.rdbAllMachine.Checked = true;
            this.rdbAllMachine.Location = new System.Drawing.Point(221, 14);
            this.rdbAllMachine.Name = "rdbAllMachine";
            this.rdbAllMachine.Size = new System.Drawing.Size(54, 21);
            this.rdbAllMachine.TabIndex = 2;
            this.rdbAllMachine.TabStop = true;
            this.rdbAllMachine.Text = "全部";
            this.rdbAllMachine.UseVisualStyleBackColor = true;
            // 
            // rdbNoMachine
            // 
            this.rdbNoMachine.AutoSize = true;
            this.rdbNoMachine.Location = new System.Drawing.Point(16, 14);
            this.rdbNoMachine.Name = "rdbNoMachine";
            this.rdbNoMachine.Size = new System.Drawing.Size(96, 21);
            this.rdbNoMachine.TabIndex = 0;
            this.rdbNoMachine.Text = "未安排機器";
            this.rdbNoMachine.UseVisualStyleBackColor = true;
            // 
            // rdbIsMachine
            // 
            this.rdbIsMachine.AutoSize = true;
            this.rdbIsMachine.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.rdbIsMachine.Location = new System.Drawing.Point(114, 14);
            this.rdbIsMachine.Name = "rdbIsMachine";
            this.rdbIsMachine.Size = new System.Drawing.Size(96, 21);
            this.rdbIsMachine.TabIndex = 1;
            this.rdbIsMachine.Text = "已安排機器";
            this.rdbIsMachine.UseVisualStyleBackColor = false;
            // 
            // lblFindDate
            // 
            this.lblFindDate.AutoSize = true;
            this.lblFindDate.Location = new System.Drawing.Point(25, 52);
            this.lblFindDate.Name = "lblFindDate";
            this.lblFindDate.Size = new System.Drawing.Size(64, 17);
            this.lblFindDate.TabIndex = 25;
            this.lblFindDate.Text = "當前日期";
            // 
            // txtMo_id_sq
            // 
            this.txtMo_id_sq.BackColor = System.Drawing.Color.GhostWhite;
            this.txtMo_id_sq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id_sq.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMo_id_sq.Location = new System.Drawing.Point(274, 17);
            this.txtMo_id_sq.MaxLength = 9;
            this.txtMo_id_sq.Name = "txtMo_id_sq";
            this.txtMo_id_sq.Size = new System.Drawing.Size(114, 23);
            this.txtMo_id_sq.TabIndex = 7;
            // 
            // lblMoStatus
            // 
            this.lblMoStatus.AutoSize = true;
            this.lblMoStatus.Location = new System.Drawing.Point(393, 55);
            this.lblMoStatus.Name = "lblMoStatus";
            this.lblMoStatus.Size = new System.Drawing.Size(64, 17);
            this.lblMoStatus.TabIndex = 15;
            this.lblMoStatus.Text = "生產狀態";
            // 
            // cmbFindMachine
            // 
            this.cmbFindMachine.FormattingEnabled = true;
            this.cmbFindMachine.Location = new System.Drawing.Point(462, 17);
            this.cmbFindMachine.Name = "cmbFindMachine";
            this.cmbFindMachine.Size = new System.Drawing.Size(121, 24);
            this.cmbFindMachine.TabIndex = 24;
            this.cmbFindMachine.Leave += new System.EventHandler(this.cmbFindMachine_Leave);
            // 
            // lblMachineStatus
            // 
            this.lblMachineStatus.AutoSize = true;
            this.lblMachineStatus.Location = new System.Drawing.Point(20, 139);
            this.lblMachineStatus.Name = "lblMachineStatus";
            this.lblMachineStatus.Size = new System.Drawing.Size(64, 17);
            this.lblMachineStatus.TabIndex = 15;
            this.lblMachineStatus.Text = "機器安排";
            // 
            // cmbFindDep
            // 
            this.cmbFindDep.FormattingEnabled = true;
            this.cmbFindDep.Location = new System.Drawing.Point(90, 17);
            this.cmbFindDep.Name = "cmbFindDep";
            this.cmbFindDep.Size = new System.Drawing.Size(109, 24);
            this.cmbFindDep.TabIndex = 23;
            this.cmbFindDep.Leave += new System.EventHandler(this.cmbFindDep_Leave);
            // 
            // btnActiveFind
            // 
            this.btnActiveFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActiveFind.Location = new System.Drawing.Point(1126, 6);
            this.btnActiveFind.Name = "btnActiveFind";
            this.btnActiveFind.Size = new System.Drawing.Size(136, 30);
            this.btnActiveFind.TabIndex = 22;
            this.btnActiveFind.Text = "開啟自動查找";
            this.btnActiveFind.UseVisualStyleBackColor = true;
            this.btnActiveFind.Click += new System.EventHandler(this.btnActiveFind_Click);
            // 
            // tabInsert
            // 
            this.tabInsert.Controls.Add(this.groupBox1);
            this.tabInsert.Controls.Add(this.txtSeqFrom);
            this.tabInsert.Controls.Add(this.label9);
            this.tabInsert.Controls.Add(this.txtHour_std_qty);
            this.tabInsert.Controls.Add(this.lblLine_num);
            this.tabInsert.Controls.Add(this.btnSaveArrange);
            this.tabInsert.Controls.Add(this.btnArrange_seq);
            this.tabInsert.Controls.Add(this.lblhour_std_qty);
            this.tabInsert.Controls.Add(this.lblHour_run_num);
            this.tabInsert.Controls.Add(this.btnAnalyze);
            this.tabInsert.Controls.Add(this.label1);
            this.tabInsert.Controls.Add(this.txtHour_run_num);
            this.tabInsert.Controls.Add(this.txtLine_num);
            this.tabInsert.Controls.Add(this.txttSeqTo);
            this.tabInsert.Location = new System.Drawing.Point(4, 25);
            this.tabInsert.Name = "tabInsert";
            this.tabInsert.Padding = new System.Windows.Forms.Padding(3);
            this.tabInsert.Size = new System.Drawing.Size(1262, 209);
            this.tabInsert.TabIndex = 1;
            this.tabInsert.Text = "插單";
            this.tabInsert.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(13, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 55);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "調整形式";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(236, 25);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "對換";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(22, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(208, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "插入記錄，對應記錄往後排列";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // txtSeqFrom
            // 
            this.txtSeqFrom.Location = new System.Drawing.Point(42, 18);
            this.txtSeqFrom.Name = "txtSeqFrom";
            this.txtSeqFrom.Size = new System.Drawing.Size(75, 23);
            this.txtSeqFrom.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(123, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "-->";
            // 
            // txtHour_std_qty
            // 
            this.txtHour_std_qty.Location = new System.Drawing.Point(766, 17);
            this.txtHour_std_qty.Name = "txtHour_std_qty";
            this.txtHour_std_qty.Size = new System.Drawing.Size(76, 23);
            this.txtHour_std_qty.TabIndex = 4;
            // 
            // lblLine_num
            // 
            this.lblLine_num.AutoSize = true;
            this.lblLine_num.Location = new System.Drawing.Point(575, 18);
            this.lblLine_num.Name = "lblLine_num";
            this.lblLine_num.Size = new System.Drawing.Size(64, 17);
            this.lblLine_num.TabIndex = 16;
            this.lblLine_num.Text = "行(人)數:";
            // 
            // btnSaveArrange
            // 
            this.btnSaveArrange.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSaveArrange.Enabled = false;
            this.btnSaveArrange.Location = new System.Drawing.Point(858, 68);
            this.btnSaveArrange.Name = "btnSaveArrange";
            this.btnSaveArrange.Size = new System.Drawing.Size(105, 33);
            this.btnSaveArrange.TabIndex = 3;
            this.btnSaveArrange.Text = "儲存排序結果";
            this.btnSaveArrange.UseVisualStyleBackColor = false;
            this.btnSaveArrange.Click += new System.EventHandler(this.btnSaveArrange_Click);
            // 
            // btnArrange_seq
            // 
            this.btnArrange_seq.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnArrange_seq.Location = new System.Drawing.Point(284, 12);
            this.btnArrange_seq.Name = "btnArrange_seq";
            this.btnArrange_seq.Size = new System.Drawing.Size(95, 33);
            this.btnArrange_seq.TabIndex = 2;
            this.btnArrange_seq.Text = "調整順序";
            this.btnArrange_seq.UseVisualStyleBackColor = false;
            this.btnArrange_seq.Click += new System.EventHandler(this.btnArrange_seq_Click);
            // 
            // lblhour_std_qty
            // 
            this.lblhour_std_qty.AutoSize = true;
            this.lblhour_std_qty.Location = new System.Drawing.Point(678, 18);
            this.lblhour_std_qty.Name = "lblhour_std_qty";
            this.lblhour_std_qty.Size = new System.Drawing.Size(82, 17);
            this.lblhour_std_qty.TabIndex = 20;
            this.lblhour_std_qty.Text = "每小時標準:";
            // 
            // lblHour_run_num
            // 
            this.lblHour_run_num.AutoSize = true;
            this.lblHour_run_num.Location = new System.Drawing.Point(417, 18);
            this.lblHour_run_num.Name = "lblHour_run_num";
            this.lblHour_run_num.Size = new System.Drawing.Size(82, 17);
            this.lblHour_run_num.TabIndex = 17;
            this.lblHour_run_num.Text = "每小時轉數:";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAnalyze.Location = new System.Drawing.Point(858, 12);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(105, 33);
            this.btnAnalyze.TabIndex = 3;
            this.btnAnalyze.Text = "計算生產時間";
            this.btnAnalyze.UseVisualStyleBackColor = false;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "由";
            // 
            // txtHour_run_num
            // 
            this.txtHour_run_num.Location = new System.Drawing.Point(499, 17);
            this.txtHour_run_num.Name = "txtHour_run_num";
            this.txtHour_run_num.Size = new System.Drawing.Size(71, 23);
            this.txtHour_run_num.TabIndex = 19;
            this.txtHour_run_num.TextChanged += new System.EventHandler(this.txtHour_run_num_TextChanged);
            // 
            // txtLine_num
            // 
            this.txtLine_num.Location = new System.Drawing.Point(641, 17);
            this.txtLine_num.Name = "txtLine_num";
            this.txtLine_num.Size = new System.Drawing.Size(36, 23);
            this.txtLine_num.TabIndex = 18;
            this.txtLine_num.TextChanged += new System.EventHandler(this.txtLine_num_TextChanged);
            // 
            // txttSeqTo
            // 
            this.txttSeqTo.Location = new System.Drawing.Point(160, 18);
            this.txttSeqTo.Name = "txttSeqTo";
            this.txttSeqTo.Size = new System.Drawing.Size(75, 23);
            this.txttSeqTo.TabIndex = 1;
            // 
            // tabSort
            // 
            this.tabSort.Controls.Add(this.lblSortTo);
            this.tabSort.Controls.Add(this.lblSortFrom);
            this.tabSort.Controls.Add(this.dgvSortFrom);
            this.tabSort.Controls.Add(this.txtSort);
            this.tabSort.Controls.Add(this.dgvSortTo);
            this.tabSort.Controls.Add(this.btnConfSort);
            this.tabSort.Controls.Add(this.btnAddSort);
            this.tabSort.Controls.Add(this.btnDelSort);
            this.tabSort.Location = new System.Drawing.Point(4, 25);
            this.tabSort.Name = "tabSort";
            this.tabSort.Size = new System.Drawing.Size(1262, 209);
            this.tabSort.TabIndex = 2;
            this.tabSort.Text = "排序";
            this.tabSort.UseVisualStyleBackColor = true;
            // 
            // lblSortTo
            // 
            this.lblSortTo.AutoSize = true;
            this.lblSortTo.Location = new System.Drawing.Point(308, 10);
            this.lblSortTo.Name = "lblSortTo";
            this.lblSortTo.Size = new System.Drawing.Size(96, 17);
            this.lblSortTo.TabIndex = 6;
            this.lblSortTo.Text = "已排序的欄位:";
            // 
            // lblSortFrom
            // 
            this.lblSortFrom.AutoSize = true;
            this.lblSortFrom.Location = new System.Drawing.Point(6, 10);
            this.lblSortFrom.Name = "lblSortFrom";
            this.lblSortFrom.Size = new System.Drawing.Size(96, 17);
            this.lblSortFrom.TabIndex = 5;
            this.lblSortFrom.Text = "可選擇的欄位:";
            // 
            // dgvSortFrom
            // 
            this.dgvSortFrom.AllowUserToAddRows = false;
            this.dgvSortFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSortFrom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSort_From,
            this.colSortCode_From,
            this.colSortType_From});
            this.dgvSortFrom.Location = new System.Drawing.Point(9, 34);
            this.dgvSortFrom.Name = "dgvSortFrom";
            this.dgvSortFrom.RowHeadersVisible = false;
            this.dgvSortFrom.RowTemplate.Height = 24;
            this.dgvSortFrom.Size = new System.Drawing.Size(223, 172);
            this.dgvSortFrom.TabIndex = 0;
            // 
            // colSort_From
            // 
            this.colSort_From.DataPropertyName = "sort_fields";
            this.colSort_From.HeaderText = "欄位";
            this.colSort_From.Name = "colSort_From";
            this.colSort_From.Width = 120;
            // 
            // colSortCode_From
            // 
            this.colSortCode_From.DataPropertyName = "sort_select_code";
            this.colSortCode_From.HeaderText = "欄位代號";
            this.colSortCode_From.Name = "colSortCode_From";
            this.colSortCode_From.Visible = false;
            this.colSortCode_From.Width = 120;
            // 
            // colSortType_From
            // 
            this.colSortType_From.DataPropertyName = "sort_s";
            this.colSortType_From.HeaderText = "排序類型";
            this.colSortType_From.Name = "colSortType_From";
            this.colSortType_From.Visible = false;
            // 
            // txtSort
            // 
            this.txtSort.Location = new System.Drawing.Point(566, 145);
            this.txtSort.Name = "txtSort";
            this.txtSort.Size = new System.Drawing.Size(337, 23);
            this.txtSort.TabIndex = 19;
            this.txtSort.Visible = false;
            // 
            // dgvSortTo
            // 
            this.dgvSortTo.AllowUserToAddRows = false;
            this.dgvSortTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSortTo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSort_To,
            this.colSortCode_To,
            this.colSortType_To});
            this.dgvSortTo.Location = new System.Drawing.Point(308, 36);
            this.dgvSortTo.Name = "dgvSortTo";
            this.dgvSortTo.RowHeadersVisible = false;
            this.dgvSortTo.RowTemplate.Height = 24;
            this.dgvSortTo.Size = new System.Drawing.Size(223, 170);
            this.dgvSortTo.TabIndex = 1;
            // 
            // colSort_To
            // 
            this.colSort_To.DataPropertyName = "sort_fields";
            this.colSort_To.FillWeight = 120F;
            this.colSort_To.HeaderText = "欄位";
            this.colSort_To.Name = "colSort_To";
            // 
            // colSortCode_To
            // 
            this.colSortCode_To.DataPropertyName = "sort_select_code";
            this.colSortCode_To.FillWeight = 120F;
            this.colSortCode_To.HeaderText = "欄位代號";
            this.colSortCode_To.Name = "colSortCode_To";
            this.colSortCode_To.Visible = false;
            // 
            // colSortType_To
            // 
            this.colSortType_To.DataPropertyName = "sort_s";
            this.colSortType_To.HeaderText = "排序類型";
            this.colSortType_To.Items.AddRange(new object[] {
            "升序",
            "降序"});
            this.colSortType_To.Name = "colSortType_To";
            this.colSortType_To.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnConfSort
            // 
            this.btnConfSort.BackColor = System.Drawing.Color.LightGray;
            this.btnConfSort.Location = new System.Drawing.Point(566, 36);
            this.btnConfSort.Name = "btnConfSort";
            this.btnConfSort.Size = new System.Drawing.Size(96, 31);
            this.btnConfSort.TabIndex = 4;
            this.btnConfSort.Text = "確定";
            this.btnConfSort.UseVisualStyleBackColor = false;
            this.btnConfSort.Click += new System.EventHandler(this.btnConfSort_Click);
            // 
            // btnAddSort
            // 
            this.btnAddSort.BackColor = System.Drawing.Color.LightGray;
            this.btnAddSort.Location = new System.Drawing.Point(247, 88);
            this.btnAddSort.Name = "btnAddSort";
            this.btnAddSort.Size = new System.Drawing.Size(55, 30);
            this.btnAddSort.TabIndex = 2;
            this.btnAddSort.Text = ">";
            this.btnAddSort.UseVisualStyleBackColor = false;
            this.btnAddSort.Click += new System.EventHandler(this.btnAddSort_Click);
            // 
            // btnDelSort
            // 
            this.btnDelSort.BackColor = System.Drawing.Color.LightGray;
            this.btnDelSort.Location = new System.Drawing.Point(247, 145);
            this.btnDelSort.Name = "btnDelSort";
            this.btnDelSort.Size = new System.Drawing.Size(55, 30);
            this.btnDelSort.TabIndex = 3;
            this.btnDelSort.Text = "<";
            this.btnDelSort.UseVisualStyleBackColor = false;
            this.btnDelSort.Click += new System.EventHandler(this.btnDelSort_Click);
            // 
            // timFind
            // 
            this.timFind.Interval = 10000;
            this.timFind.Tick += new System.EventHandler(this.timFind_Tick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "arrange_id";
            this.dataGridViewTextBoxColumn1.FillWeight = 80F;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "prd_dep";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.FillWeight = 120F;
            this.dataGridViewTextBoxColumn2.HeaderText = "生產部門";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "prd_mo";
            this.dataGridViewTextBoxColumn3.FillWeight = 120F;
            this.dataGridViewTextBoxColumn3.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "prd_item";
            this.dataGridViewTextBoxColumn4.FillWeight = 200F;
            this.dataGridViewTextBoxColumn4.HeaderText = "物料編號";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "prd_ver";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn5.HeaderText = "版本";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "prd_seq";
            this.dataGridViewTextBoxColumn6.HeaderText = "序號";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "to_dep";
            this.dataGridViewTextBoxColumn7.HeaderText = "下一部門";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "arrange_seq";
            this.dataGridViewTextBoxColumn8.HeaderText = "生產順序";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "arrange_date";
            this.dataGridViewTextBoxColumn9.HeaderText = "安排生產日期";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 90;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "arrange_qty";
            this.dataGridViewTextBoxColumn10.HeaderText = "安排生產數量";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 60;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "estimated_date";
            this.dataGridViewTextBoxColumn11.HeaderText = "預計完成日期";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 50;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "estimated_time";
            this.dataGridViewTextBoxColumn12.HeaderText = "預計完成時間";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "req_time";
            this.dataGridViewTextBoxColumn13.HeaderText = "完成所需時鐘";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            this.dataGridViewTextBoxColumn13.Width = 50;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "arrange_machine";
            this.dataGridViewTextBoxColumn14.FillWeight = 120F;
            this.dataGridViewTextBoxColumn14.HeaderText = "機器";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            this.dataGridViewTextBoxColumn14.Width = 50;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "estimated_date";
            this.dataGridViewTextBoxColumn15.FillWeight = 120F;
            this.dataGridViewTextBoxColumn15.HeaderText = "預計完成日期";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Visible = false;
            this.dataGridViewTextBoxColumn15.Width = 60;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "estimated_time";
            this.dataGridViewTextBoxColumn16.HeaderText = "預計完成時間";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Visible = false;
            this.dataGridViewTextBoxColumn16.Width = 50;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "req_time";
            this.dataGridViewTextBoxColumn17.HeaderText = "完成所需時鐘";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Visible = false;
            this.dataGridViewTextBoxColumn17.Width = 250;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "arrange_machine";
            this.dataGridViewTextBoxColumn18.HeaderText = "機器";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Visible = false;
            this.dataGridViewTextBoxColumn18.Width = 60;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "hour_std_qty";
            this.dataGridViewTextBoxColumn19.HeaderText = "機器標準啤數/時";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Visible = false;
            this.dataGridViewTextBoxColumn19.Width = 250;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "arrange_machine";
            this.dataGridViewTextBoxColumn20.HeaderText = "機器";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Visible = false;
            this.dataGridViewTextBoxColumn20.Width = 200;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "hour_std_qty";
            this.dataGridViewTextBoxColumn21.HeaderText = "機器標準啤數/時";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.Visible = false;
            this.dataGridViewTextBoxColumn21.Width = 250;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "hour_std_qty";
            this.dataGridViewTextBoxColumn22.HeaderText = "機器標準啤數/時";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.Visible = false;
            this.dataGridViewTextBoxColumn22.Width = 160;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "arrange_machine";
            this.dataGridViewTextBoxColumn23.HeaderText = "機器";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.Visible = false;
            this.dataGridViewTextBoxColumn23.Width = 160;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "hour_std_qty";
            this.dataGridViewTextBoxColumn24.HeaderText = "機器標準啤數/時";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.Visible = false;
            this.dataGridViewTextBoxColumn24.Width = 80;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "estimated_date";
            this.dataGridViewTextBoxColumn25.HeaderText = "預計完成日期";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.Visible = false;
            this.dataGridViewTextBoxColumn25.Width = 80;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "estimated_time";
            this.dataGridViewTextBoxColumn26.HeaderText = "預計完成時間";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.Visible = false;
            this.dataGridViewTextBoxColumn26.Width = 80;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "req_time";
            this.dataGridViewTextBoxColumn27.HeaderText = "完成所需時鐘";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.Visible = false;
            this.dataGridViewTextBoxColumn27.Width = 80;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "arrange_machine";
            this.dataGridViewTextBoxColumn28.HeaderText = "機器";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.Visible = false;
            this.dataGridViewTextBoxColumn28.Width = 160;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "hour_std_qty";
            this.dataGridViewTextBoxColumn29.HeaderText = "機器標準啤數/時";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.Visible = false;
            this.dataGridViewTextBoxColumn29.Width = 80;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "req_time";
            this.dataGridViewTextBoxColumn30.HeaderText = "完成所需時鐘";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.Visible = false;
            this.dataGridViewTextBoxColumn30.Width = 60;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "arrange_machine";
            this.dataGridViewTextBoxColumn31.HeaderText = "機器";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.Visible = false;
            this.dataGridViewTextBoxColumn31.Width = 60;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "hour_std_qty";
            this.dataGridViewTextBoxColumn32.HeaderText = "機器標準啤數/時";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.Visible = false;
            this.dataGridViewTextBoxColumn32.Width = 50;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.DataPropertyName = "to_dep";
            this.dataGridViewTextBoxColumn33.HeaderText = "下一部門";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.Visible = false;
            this.dataGridViewTextBoxColumn33.Width = 60;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "to_dep";
            this.dataGridViewTextBoxColumn34.HeaderText = "下一部門";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.Visible = false;
            this.dataGridViewTextBoxColumn34.Width = 60;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "to_dep";
            this.dataGridViewTextBoxColumn35.HeaderText = "下一部門";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.Visible = false;
            this.dataGridViewTextBoxColumn35.Width = 60;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "to_dep";
            this.dataGridViewTextBoxColumn36.HeaderText = "下一部門";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.Visible = false;
            this.dataGridViewTextBoxColumn36.Width = 60;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "art_image";
            this.dataGridViewTextBoxColumn37.HeaderText = "圖片文件";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.Visible = false;
            this.dataGridViewTextBoxColumn37.Width = 60;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "art_image";
            this.dataGridViewTextBoxColumn38.HeaderText = "圖片文件";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.Visible = false;
            this.dataGridViewTextBoxColumn38.Width = 50;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "to_dep";
            this.dataGridViewTextBoxColumn39.HeaderText = "Image";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.Visible = false;
            this.dataGridViewTextBoxColumn39.Width = 60;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "art_image";
            this.dataGridViewTextBoxColumn40.HeaderText = "圖片文件";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.Visible = false;
            this.dataGridViewTextBoxColumn40.Width = 50;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "to_dep";
            this.dataGridViewTextBoxColumn41.HeaderText = "下一部門";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.Visible = false;
            this.dataGridViewTextBoxColumn41.Width = 60;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "art_image";
            this.dataGridViewTextBoxColumn42.HeaderText = "圖片文件";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.Visible = false;
            this.dataGridViewTextBoxColumn42.Width = 50;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.DataPropertyName = "to_dep";
            this.dataGridViewTextBoxColumn43.HeaderText = "下一部門";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.Visible = false;
            this.dataGridViewTextBoxColumn43.Width = 60;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.DataPropertyName = "art_image";
            this.dataGridViewTextBoxColumn44.HeaderText = "圖片文件";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.Visible = false;
            this.dataGridViewTextBoxColumn44.Width = 60;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.DataPropertyName = "art_image";
            this.dataGridViewTextBoxColumn45.HeaderText = "圖片文件";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.Visible = false;
            this.dataGridViewTextBoxColumn45.Width = 50;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.DataPropertyName = "to_dep";
            this.dataGridViewTextBoxColumn46.HeaderText = "下一部門";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.Width = 60;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.DataPropertyName = "art_image";
            this.dataGridViewTextBoxColumn47.HeaderText = "圖片文件";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.Visible = false;
            this.dataGridViewTextBoxColumn47.Width = 120;
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.DataPropertyName = "prd_worker";
            this.dataGridViewTextBoxColumn48.HeaderText = "安排工號";
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.Visible = false;
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.DataPropertyName = "Prd_status";
            this.dataGridViewTextBoxColumn49.FillWeight = 120F;
            this.dataGridViewTextBoxColumn49.HeaderText = "完成狀態";
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.DataPropertyName = "Prd_status_desc";
            this.dataGridViewTextBoxColumn50.FillWeight = 120F;
            this.dataGridViewTextBoxColumn50.HeaderText = "完成狀態";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.Visible = false;
            // 
            // chkSetWorker
            // 
            this.chkSetWorker.AutoSize = true;
            this.chkSetWorker.Checked = true;
            this.chkSetWorker.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetWorker.Location = new System.Drawing.Point(624, 12);
            this.chkSetWorker.Name = "chkSetWorker";
            this.chkSetWorker.Size = new System.Drawing.Size(72, 16);
            this.chkSetWorker.TabIndex = 8;
            this.chkSetWorker.Text = "安排人員";
            this.chkSetWorker.UseVisualStyleBackColor = true;
            // 
            // frmProductionArrange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1284, 732);
            this.Controls.Add(this.chkSetWorker);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmProductionArrange";
            this.Text = "安排生產計劃";
            this.Load += new System.EventHandler(this.frmProductionArrange_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabInput.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImputExcel)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabDetail.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPA)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabFind.ResumeLayout(false);
            this.tabFind.PerformLayout();
            this.grbMoStatus.ResumeLayout(false);
            this.grbMoStatus.PerformLayout();
            this.grbMachineStatus.ResumeLayout(false);
            this.grbMachineStatus.PerformLayout();
            this.tabInsert.ResumeLayout(false);
            this.tabInsert.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabSort.ResumeLayout(false);
            this.tabSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInput;
        private System.Windows.Forms.TabPage tabDetail;
        private System.Windows.Forms.Label lblPrd_dept;
        private System.Windows.Forms.DataGridView dgvPA;
        private System.Windows.Forms.Label lblArrange_machine;
        private System.Windows.Forms.TextBox txtPrd_qty;
        private System.Windows.Forms.ComboBox cmbGoods_id;
        private System.Windows.Forms.TextBox txtmo_id;
        private System.Windows.Forms.Label lblmo_id;
        private System.Windows.Forms.TextBox txtgoods_desc;
        private System.Windows.Forms.ComboBox cmbProductDept;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtRequest_time;
        private System.Windows.Forms.TextBox txtPrd_ver;
        private System.Windows.Forms.Label lblRequest_time;
        private System.Windows.Forms.TextBox txtPrd_seq;
        private System.Windows.Forms.Label lblArrange_seq;
        private System.Windows.Forms.Label lblEstimate_time;
        private System.Windows.Forms.TextBox txtToDep;
        private System.Windows.Forms.Label lblPrd_seq;
        private System.Windows.Forms.Label lblGoods_id;
        private System.Windows.Forms.TextBox txtArrange_seq;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblNext_dept;
        private System.Windows.Forms.Label lblEstimate_date;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.TextBox txtToDept_name;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.MaskedTextBox masktxtPrd_date;
        private System.Windows.Forms.MaskedTextBox msktxtEstimate_date;
        private System.Windows.Forms.TextBox txtMo_id_sq;
        private System.Windows.Forms.Label lblMo_id_sq;
        private System.Windows.Forms.MaskedTextBox msktxtEstimate_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnArrange_seq;
        private System.Windows.Forms.TextBox txttSeqTo;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.MaskedTextBox msktxtEstimate_start_time;
        private System.Windows.Forms.MaskedTextBox msktxtEstimate_start_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox msktxtActive_start_time;
        private System.Windows.Forms.MaskedTextBox msktxtActive_start_date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMachine_stand_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripButton btnMachine_status;
        private System.Windows.Forms.ToolStripButton btnMakeOrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbIsComplete;
        private System.Windows.Forms.RadioButton rdbNoComplete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.TextBox txtArrange_id;
        private System.Windows.Forms.Label lblArrange_id;
        private System.Windows.Forms.Button btnSaveArrange;
        private System.Windows.Forms.RadioButton rdbAllMachine;
        private System.Windows.Forms.RadioButton rdbIsMachine;
        private System.Windows.Forms.RadioButton rdbNoMachine;
        private System.Windows.Forms.CheckBox chkIsCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.TextBox txtHour_std_qty;
        private System.Windows.Forms.TextBox txtHour_run_num;
        private System.Windows.Forms.TextBox txtLine_num;
        private System.Windows.Forms.Label lblHour_run_num;
        private System.Windows.Forms.Label lblLine_num;
        private System.Windows.Forms.Label lblhour_std_qty;
        private System.Windows.Forms.Button btnImputExcel;
        private System.Windows.Forms.DataGridView dgvImputExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.Button btnSaveExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblImput;
        private System.Windows.Forms.Label lblRemark1;
        private System.Windows.Forms.Label lblRemark3;
        private System.Windows.Forms.Label lblRemark2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.GroupBox grbMoStatus;
        private System.Windows.Forms.Label lblMoStatus;
        private System.Windows.Forms.GroupBox grbMachineStatus;
        private System.Windows.Forms.Label lblMachineStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.Label lblMoUrgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbMoUrgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.TextBox txtSort;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dgvSortFrom;
        private System.Windows.Forms.DataGridView dgvSortTo;
        private System.Windows.Forms.Button btnAddSort;
        private System.Windows.Forms.Button btnDelSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.Button btnConfSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSort_To;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSortCode_To;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSortType_To;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSort_From;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSortCode_From;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSortType_From;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.Label lblSortTo;
        private System.Windows.Forms.Label lblSortFrom;
        private System.Windows.Forms.Timer timFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private System.Windows.Forms.TextBox txtCust_o_date;
        private System.Windows.Forms.Label lblCust_o_date;
        private System.Windows.Forms.TextBox txtReq_f_date;
        private System.Windows.Forms.Label lblReq_f_date;
        private System.Windows.Forms.Button btnActiveFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMac;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoUrgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqDate;
        private System.Windows.Forms.ComboBox cmbMachine;
        private System.Windows.Forms.TextBox txtProductNo;
        private System.Windows.Forms.Label lblProductNo;
        private System.Windows.Forms.ComboBox cmbFindDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private System.Windows.Forms.ComboBox cmbFindMachine;
        private System.Windows.Forms.MaskedTextBox mktFindDate;
        private System.Windows.Forms.Label lblFindDate;
        private System.Windows.Forms.TextBox txtFindWorker;
        private System.Windows.Forms.Label lblFindWorker;
        private System.Windows.Forms.ComboBox cmbPrd_status;
        private System.Windows.Forms.Label lblPrd_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private System.Windows.Forms.ComboBox cmbFindStatus;
        private System.Windows.Forms.Label lblCpStatus;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnExpToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.TextBox txtSeqFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.MonthCalendar mcFindDate;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabFind;
        private System.Windows.Forms.TabPage tabInsert;
        private System.Windows.Forms.TabPage tabSort;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrange_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrange_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_mo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMo_urgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlag_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_item;
        private System.Windows.Forms.DataGridViewImageColumn colArtWork;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrange_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrange_machine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCust_o_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReq_f_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMachine_stand_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstimated_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstimated_start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstimated_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstimated_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn colreq_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActive_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActive_start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_end_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_req_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_dep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_ver;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArt_image;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_status_desc;
        private System.Windows.Forms.MaskedTextBox txtNow_date;
        private System.Windows.Forms.Label lblNow_date;
        private System.Windows.Forms.CheckBox chkSetWorker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}