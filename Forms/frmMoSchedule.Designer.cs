namespace cf01.Forms
{
    partial class frmMoSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoSchedule));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode5 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode6 = new DevExpress.XtraGrid.GridLevelNode();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNewSchedule = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExpToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetParas = new System.Windows.Forms.ToolStripButton();
            this.btnExcelByMachine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExpSum = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDepPrd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMachine_status = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMakeOrderStatus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.palShowHasSchedule = new System.Windows.Forms.Panel();
            this.gcSchedule = new DevExpress.XtraGrid.GridControl();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvSchedule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclSeq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclScheduleSeq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclScheduleDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit11 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gclPrdMo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclPassDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclPrdGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luePrdGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gclUrgentFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueGvUrgentFlag = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.remark_105 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclPrdItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPrdItemFind = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gclArtWork = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gclPrdIitemCdesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclPlQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclScheduleQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclCpQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclNotCpQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclPrdQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grc_hk_req_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclPmcRqDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gclDepRpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gclPrdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclPrdMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnScheduleMachine = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gclMachineStdRunNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclMachineStdLineNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclMachineStdQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclNeedMonNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclModuleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclNeedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclReqTotTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gclEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclModuleNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclModuleInstall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclWorkTypeDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclPrdDep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclNextWpId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclPrdWorker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclUpdateFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclPmcRpPDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gclArtWorkFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclScheduleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclModuleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueModuleType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gclNextDoColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclNextVendId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclMoRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclDepRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueGvStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grcPrdItemGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glcPreTrQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcPreTrDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclPreTrFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclTransferToJx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclWipRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grc_order_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grc_av_prd_days = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gric_cs_req_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grc_re_prd_days = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grc_hk_period_flag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbGvStatus = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.imgArtWork = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.prgStatus = new System.Windows.Forms.ProgressBar();
            this.btnAddToMachine = new DevExpress.XtraEditors.SimpleButton();
            this.lblNeedPrdDays = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblReqTotTime = new System.Windows.Forms.Label();
            this.lblNotCpQty = new System.Windows.Forms.Label();
            this.lblScheduleQty = new System.Windows.Forms.Label();
            this.txtReqTotTime = new DevExpress.XtraEditors.TextEdit();
            this.txtNeedPrdDays = new DevExpress.XtraEditors.TextEdit();
            this.txtNotCpQty = new DevExpress.XtraEditors.TextEdit();
            this.txtScheduleQty = new DevExpress.XtraEditors.TextEdit();
            this.palShowNotMachine = new System.Windows.Forms.Panel();
            this.gcWaitSchedule = new DevExpress.XtraGrid.GridControl();
            this.gvWaitSchedule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn46 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemTextEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemLookUpEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.palShowMore = new System.Windows.Forms.Panel();
            this.btnSetUrgentMo = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetMachine = new DevExpress.XtraEditors.SimpleButton();
            this.lueSetUrgentMo = new DevExpress.XtraEditors.LookUpEdit();
            this.luePrdMachine = new DevExpress.XtraEditors.LookUpEdit();
            this.btnGenScheduleSeq = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetMoStatus = new DevExpress.XtraEditors.SimpleButton();
            this.cmbSetStatus = new System.Windows.Forms.ComboBox();
            this.lblSetUrgentMo = new System.Windows.Forms.Label();
            this.lblDepMachine = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSetStatus = new System.Windows.Forms.Label();
            this.txtPrdMachine = new DevExpress.XtraEditors.TextEdit();
            this.cmbCpStatus = new System.Windows.Forms.ComboBox();
            this.lblPrdMachine = new System.Windows.Forms.Label();
            this.lblCpStatus = new System.Windows.Forms.Label();
            this.cmbMoStatus = new System.Windows.Forms.ComboBox();
            this.lblMoStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDep = new DevExpress.XtraEditors.TextEdit();
            this.btnShowMore = new DevExpress.XtraEditors.SimpleButton();
            this.lueDepGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.txtOver3Days = new DevExpress.XtraEditors.TextEdit();
            this.chkOver3Days = new DevExpress.XtraEditors.CheckEdit();
            this.lblDepGroup = new System.Windows.Forms.Label();
            this.lblPrd_dept = new System.Windows.Forms.Label();
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
            this.chkScheduleByMachine = new DevExpress.XtraEditors.CheckEdit();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.palShowHasSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSchedule)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePrdGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGvUrgentFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrdItemFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnScheduleMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueModuleType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGvStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGvStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgArtWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqTotTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNeedPrdDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotCpQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScheduleQty.Properties)).BeginInit();
            this.palShowNotMachine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWaitSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWaitSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            this.palShowMore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueSetUrgentMo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePrdMachine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdMachine.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOver3Days.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOver3Days.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkScheduleByMachine.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator7,
            this.btnFind,
            this.toolStripSeparator9,
            this.btnNewSchedule,
            this.toolStripSeparator8,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnExpToExcel,
            this.toolStripSeparator3,
            this.btnSetParas,
            this.btnExcelByMachine,
            this.toolStripSeparator2,
            this.btnExpSum,
            this.toolStripSeparator10,
            this.btnDepPrd,
            this.toolStripSeparator5,
            this.btnMachine_status,
            this.toolStripSeparator6,
            this.btnMakeOrderStatus,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1210, 38);
            this.toolStrip1.TabIndex = 8;
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
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 35);
            this.btnFind.Text = "刷新(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 38);
            // 
            // btnNewSchedule
            // 
            this.btnNewSchedule.Image = ((System.Drawing.Image)(resources.GetObject("btnNewSchedule.Image")));
            this.btnNewSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewSchedule.Name = "btnNewSchedule";
            this.btnNewSchedule.Size = new System.Drawing.Size(76, 35);
            this.btnNewSchedule.Text = "添加排期(&A)";
            this.btnNewSchedule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewSchedule.Click += new System.EventHandler(this.btnNewSchedule_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 38);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // btnSetParas
            // 
            this.btnSetParas.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSetParas.AutoSize = false;
            this.btnSetParas.Image = ((System.Drawing.Image)(resources.GetObject("btnSetParas.Image")));
            this.btnSetParas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetParas.Name = "btnSetParas";
            this.btnSetParas.Size = new System.Drawing.Size(75, 35);
            this.btnSetParas.Text = "參數設置";
            this.btnSetParas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSetParas.Click += new System.EventHandler(this.btnSetParas_Click);
            // 
            // btnExcelByMachine
            // 
            this.btnExcelByMachine.AutoSize = false;
            this.btnExcelByMachine.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelByMachine.Image")));
            this.btnExcelByMachine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcelByMachine.Name = "btnExcelByMachine";
            this.btnExcelByMachine.Size = new System.Drawing.Size(65, 35);
            this.btnExcelByMachine.Text = "按機器";
            this.btnExcelByMachine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcelByMachine.Click += new System.EventHandler(this.btnExcelByMachine_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnExpSum
            // 
            this.btnExpSum.AutoSize = false;
            this.btnExpSum.Image = ((System.Drawing.Image)(resources.GetObject("btnExpSum.Image")));
            this.btnExpSum.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpSum.Name = "btnExpSum";
            this.btnExpSum.Size = new System.Drawing.Size(65, 35);
            this.btnExpSum.Text = "匯出總表";
            this.btnExpSum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExpSum.Click += new System.EventHandler(this.btnExpSum_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 38);
            // 
            // btnDepPrd
            // 
            this.btnDepPrd.AutoSize = false;
            this.btnDepPrd.Image = ((System.Drawing.Image)(resources.GetObject("btnDepPrd.Image")));
            this.btnDepPrd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDepPrd.Name = "btnDepPrd";
            this.btnDepPrd.Size = new System.Drawing.Size(100, 35);
            this.btnDepPrd.Text = "部門生產狀態";
            this.btnDepPrd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDepPrd.Click += new System.EventHandler(this.btnDepPrd_Click);
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
            this.btnMachine_status.Size = new System.Drawing.Size(100, 35);
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 166);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1210, 468);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.palShowHasSchedule);
            this.tabPage1.Controls.Add(this.palShowNotMachine);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1202, 442);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // palShowHasSchedule
            // 
            this.palShowHasSchedule.Controls.Add(this.gcSchedule);
            this.palShowHasSchedule.Controls.Add(this.panel3);
            this.palShowHasSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palShowHasSchedule.Location = new System.Drawing.Point(3, 3);
            this.palShowHasSchedule.Name = "palShowHasSchedule";
            this.palShowHasSchedule.Size = new System.Drawing.Size(1196, 155);
            this.palShowHasSchedule.TabIndex = 40;
            // 
            // gcSchedule
            // 
            this.gcSchedule.ContextMenuStrip = this.contextMenu;
            this.gcSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.RelationName = "Level2";
            gridLevelNode3.RelationName = "Level3";
            this.gcSchedule.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3});
            this.gcSchedule.Location = new System.Drawing.Point(0, 0);
            this.gcSchedule.MainView = this.gvSchedule;
            this.gcSchedule.Name = "gcSchedule";
            this.gcSchedule.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit4,
            this.repositoryItemTextEdit2,
            this.repositoryItemLookUpEdit3,
            this.cmbGvStatus,
            this.lueGvStatus,
            this.lueGvUrgentFlag,
            this.repositoryItemImageEdit1,
            this.imgArtWork,
            this.repositoryItemPictureEdit1,
            this.btnScheduleMachine,
            this.repositoryItemDateEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5,
            this.lueModuleType,
            this.luePrdGroup,
            this.repositoryItemTextEdit11,
            this.btnPrdItemFind});
            this.gcSchedule.Size = new System.Drawing.Size(1196, 120);
            this.gcSchedule.TabIndex = 37;
            this.gcSchedule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSchedule});
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutMenuItem,
            this.pasteMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(101, 48);
            // 
            // cutMenuItem
            // 
            this.cutMenuItem.Name = "cutMenuItem";
            this.cutMenuItem.Size = new System.Drawing.Size(100, 22);
            this.cutMenuItem.Text = "選取";
            this.cutMenuItem.Click += new System.EventHandler(this.cutMenuItem_Click);
            // 
            // pasteMenuItem
            // 
            this.pasteMenuItem.Name = "pasteMenuItem";
            this.pasteMenuItem.Size = new System.Drawing.Size(100, 22);
            this.pasteMenuItem.Text = "插單";
            this.pasteMenuItem.Click += new System.EventHandler(this.pasteMenuItem_Click);
            // 
            // gvSchedule
            // 
            this.gvSchedule.ColumnPanelRowHeight = 35;
            this.gvSchedule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclSeq,
            this.gclScheduleSeq,
            this.gclScheduleDate,
            this.gclPrdMo,
            this.gclPassDays,
            this.gclPrdGroup,
            this.gclUrgentFlag,
            this.remark_105,
            this.gclPrdItem,
            this.gclArtWork,
            this.gclPrdIitemCdesc,
            this.gclPlQty,
            this.gclScheduleQty,
            this.gclCpQty,
            this.gclNotCpQty,
            this.gclPrdQty,
            this.grc_hk_req_date,
            this.gclPmcRqDate,
            this.grc_re_prd_days,
            this.gclDepRpDate,
            this.gclPrdDate,
            this.gclPrdMachine,
            this.gclMachineStdRunNum,
            this.gclMachineStdLineNum,
            this.gclMachineStdQty,
            this.gclNeedMonNum,
            this.gclModuleTime,
            this.gclNeedTime,
            this.gclReqTotTime,
            this.gclStartTime,
            this.gclEndTime,
            this.gclModuleNo,
            this.gclModuleInstall,
            this.gclWorkTypeDesc,
            this.gclOrderQty,
            this.gclOrderDate,
            this.gclPrdDep,
            this.gclNextWpId,
            this.gclPrdWorker,
            this.gclUpdateFlag,
            this.gclPmcRpPDate,
            this.gclArtWorkFile,
            this.gclScheduleID,
            this.gclModuleType,
            this.gclNextDoColor,
            this.gclNextVendId,
            this.gclMoRemark,
            this.gclDepRemark,
            this.gclStatus,
            this.grcPrdItemGroup,
            this.glcPreTrQty,
            this.grcPreTrDate,
            this.gclPreTrFlag,
            this.gclTransferToJx,
            this.gclWipRemark,
            this.grc_order_date,
            this.grc_av_prd_days,
            this.gric_cs_req_date,
            this.grc_hk_period_flag});
            this.gvSchedule.FooterPanelHeight = 30;
            this.gvSchedule.GridControl = this.gcSchedule;
            this.gvSchedule.IndicatorWidth = 40;
            this.gvSchedule.Name = "gvSchedule";
            this.gvSchedule.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.gvSchedule.OptionsCustomization.AllowSort = false;
            this.gvSchedule.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text;
            this.gvSchedule.OptionsSelection.MultiSelect = true;
            this.gvSchedule.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvSchedule.OptionsView.ColumnAutoWidth = false;
            this.gvSchedule.OptionsView.ShowFooter = true;
            this.gvSchedule.OptionsView.ShowGroupPanel = false;
            this.gvSchedule.RowHeight = 35;
            this.gvSchedule.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvSchedule_CustomDrawRowIndicator);
            this.gvSchedule.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvSchedule_RowStyle);
            this.gvSchedule.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvSchedule_SelectionChanged);
            this.gvSchedule.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvSchedule_CellValueChanged);
            this.gvSchedule.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvSchedule_CustomColumnDisplayText);
            this.gvSchedule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvSchedule_MouseDown);
            this.gvSchedule.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gvSchedule_MouseUp);
            // 
            // gclSeq
            // 
            this.gclSeq.Name = "gclSeq";
            this.gclSeq.OptionsColumn.AllowEdit = false;
            this.gclSeq.OptionsColumn.ReadOnly = true;
            this.gclSeq.Width = 30;
            // 
            // gclScheduleSeq
            // 
            this.gclScheduleSeq.AppearanceHeader.Options.UseTextOptions = true;
            this.gclScheduleSeq.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclScheduleSeq.Caption = "排序";
            this.gclScheduleSeq.FieldName = "schedule_seq";
            this.gclScheduleSeq.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gclScheduleSeq.Name = "gclScheduleSeq";
            this.gclScheduleSeq.Visible = true;
            this.gclScheduleSeq.VisibleIndex = 0;
            this.gclScheduleSeq.Width = 41;
            // 
            // gclScheduleDate
            // 
            this.gclScheduleDate.Caption = "排單日期";
            this.gclScheduleDate.ColumnEdit = this.repositoryItemTextEdit11;
            this.gclScheduleDate.FieldName = "schedule_date";
            this.gclScheduleDate.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gclScheduleDate.Name = "gclScheduleDate";
            this.gclScheduleDate.Visible = true;
            this.gclScheduleDate.VisibleIndex = 1;
            this.gclScheduleDate.Width = 100;
            // 
            // repositoryItemTextEdit11
            // 
            this.repositoryItemTextEdit11.AutoHeight = false;
            this.repositoryItemTextEdit11.Mask.EditMask = "9999/99/99";
            this.repositoryItemTextEdit11.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.repositoryItemTextEdit11.Name = "repositoryItemTextEdit11";
            // 
            // gclPrdMo
            // 
            this.gclPrdMo.Caption = "制單編號";
            this.gclPrdMo.FieldName = "prd_mo";
            this.gclPrdMo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gclPrdMo.Name = "gclPrdMo";
            this.gclPrdMo.OptionsColumn.ReadOnly = true;
            this.gclPrdMo.Visible = true;
            this.gclPrdMo.VisibleIndex = 2;
            this.gclPrdMo.Width = 100;
            // 
            // gclPassDays
            // 
            this.gclPassDays.Caption = "已過天數";
            this.gclPassDays.FieldName = "pass_days";
            this.gclPassDays.Name = "gclPassDays";
            this.gclPassDays.Visible = true;
            this.gclPassDays.VisibleIndex = 3;
            this.gclPassDays.Width = 60;
            // 
            // gclPrdGroup
            // 
            this.gclPrdGroup.AppearanceCell.Options.UseTextOptions = true;
            this.gclPrdGroup.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclPrdGroup.Caption = "組別";
            this.gclPrdGroup.ColumnEdit = this.luePrdGroup;
            this.gclPrdGroup.FieldName = "prd_group";
            this.gclPrdGroup.Name = "gclPrdGroup";
            this.gclPrdGroup.Visible = true;
            this.gclPrdGroup.VisibleIndex = 4;
            this.gclPrdGroup.Width = 60;
            // 
            // luePrdGroup
            // 
            this.luePrdGroup.AutoHeight = false;
            this.luePrdGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePrdGroup.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("grp_code", 40, "組別代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("grp_cdesc", 60, "描述")});
            this.luePrdGroup.Name = "luePrdGroup";
            this.luePrdGroup.NullText = "";
            // 
            // gclUrgentFlag
            // 
            this.gclUrgentFlag.Caption = "急單標識";
            this.gclUrgentFlag.ColumnEdit = this.lueGvUrgentFlag;
            this.gclUrgentFlag.FieldName = "urgent_flag";
            this.gclUrgentFlag.Name = "gclUrgentFlag";
            this.gclUrgentFlag.Visible = true;
            this.gclUrgentFlag.VisibleIndex = 5;
            this.gclUrgentFlag.Width = 60;
            // 
            // lueGvUrgentFlag
            // 
            this.lueGvUrgentFlag.AutoHeight = false;
            this.lueGvUrgentFlag.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGvUrgentFlag.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_id", 40, "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_cdesc", 60, "描述")});
            this.lueGvUrgentFlag.Name = "lueGvUrgentFlag";
            this.lueGvUrgentFlag.NullText = "";
            // 
            // remark_105
            // 
            this.remark_105.Caption = "備註105";
            this.remark_105.FieldName = "remark_105";
            this.remark_105.Name = "remark_105";
            this.remark_105.Width = 205;
            // 
            // gclPrdItem
            // 
            this.gclPrdItem.Caption = "物料編號";
            this.gclPrdItem.ColumnEdit = this.btnPrdItemFind;
            this.gclPrdItem.FieldName = "prd_item";
            this.gclPrdItem.Name = "gclPrdItem";
            this.gclPrdItem.OptionsColumn.ReadOnly = true;
            this.gclPrdItem.Visible = true;
            this.gclPrdItem.VisibleIndex = 6;
            this.gclPrdItem.Width = 160;
            // 
            // btnPrdItemFind
            // 
            this.btnPrdItemFind.AutoHeight = false;
            this.btnPrdItemFind.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnPrdItemFind.Name = "btnPrdItemFind";
            this.btnPrdItemFind.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnPrdItemFind_ButtonClick);
            // 
            // gclArtWork
            // 
            this.gclArtWork.Caption = "圖樣";
            this.gclArtWork.ColumnEdit = this.repositoryItemPictureEdit1;
            this.gclArtWork.FieldName = "ArtWork";
            this.gclArtWork.Name = "gclArtWork";
            this.gclArtWork.OptionsColumn.ReadOnly = true;
            this.gclArtWork.Width = 60;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // gclPrdIitemCdesc
            // 
            this.gclPrdIitemCdesc.Caption = "物料描述";
            this.gclPrdIitemCdesc.FieldName = "goods_name";
            this.gclPrdIitemCdesc.Name = "gclPrdIitemCdesc";
            this.gclPrdIitemCdesc.OptionsColumn.ReadOnly = true;
            this.gclPrdIitemCdesc.Visible = true;
            this.gclPrdIitemCdesc.VisibleIndex = 7;
            this.gclPrdIitemCdesc.Width = 250;
            // 
            // gclPlQty
            // 
            this.gclPlQty.Caption = "計劃數量";
            this.gclPlQty.DisplayFormat.FormatString = "#,##0";
            this.gclPlQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gclPlQty.FieldName = "pl_qty";
            this.gclPlQty.Name = "gclPlQty";
            this.gclPlQty.OptionsColumn.ReadOnly = true;
            this.gclPlQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pl_qty", "{0:#,##0}")});
            this.gclPlQty.Visible = true;
            this.gclPlQty.VisibleIndex = 8;
            this.gclPlQty.Width = 60;
            // 
            // gclScheduleQty
            // 
            this.gclScheduleQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gclScheduleQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclScheduleQty.Caption = "排期數量";
            this.gclScheduleQty.DisplayFormat.FormatString = "#,##0";
            this.gclScheduleQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gclScheduleQty.FieldName = "schedule_qty";
            this.gclScheduleQty.Name = "gclScheduleQty";
            this.gclScheduleQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "schedule_qty", "{0:#,##0}")});
            this.gclScheduleQty.Visible = true;
            this.gclScheduleQty.VisibleIndex = 9;
            this.gclScheduleQty.Width = 60;
            // 
            // gclCpQty
            // 
            this.gclCpQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gclCpQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclCpQty.Caption = "已完成數量";
            this.gclCpQty.DisplayFormat.FormatString = "#,##0";
            this.gclCpQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gclCpQty.FieldName = "cp_qty";
            this.gclCpQty.Name = "gclCpQty";
            this.gclCpQty.OptionsColumn.ReadOnly = true;
            this.gclCpQty.Visible = true;
            this.gclCpQty.VisibleIndex = 10;
            // 
            // gclNotCpQty
            // 
            this.gclNotCpQty.Caption = "未完成數量";
            this.gclNotCpQty.DisplayFormat.FormatString = "#,##0";
            this.gclNotCpQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gclNotCpQty.FieldName = "not_cp_qty";
            this.gclNotCpQty.Name = "gclNotCpQty";
            this.gclNotCpQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "not_cp_qty", "{0:#,##0}")});
            this.gclNotCpQty.Visible = true;
            this.gclNotCpQty.VisibleIndex = 11;
            // 
            // gclPrdQty
            // 
            this.gclPrdQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gclPrdQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclPrdQty.Caption = "已生產數量";
            this.gclPrdQty.DisplayFormat.FormatString = "#,##0";
            this.gclPrdQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gclPrdQty.FieldName = "prd_qty";
            this.gclPrdQty.Name = "gclPrdQty";
            this.gclPrdQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prd_qty", "{0:#,##0}")});
            this.gclPrdQty.Visible = true;
            this.gclPrdQty.VisibleIndex = 12;
            this.gclPrdQty.Width = 60;
            // 
            // grc_hk_req_date
            // 
            this.grc_hk_req_date.Caption = "計劃回港期";
            this.grc_hk_req_date.FieldName = "hk_req_date";
            this.grc_hk_req_date.Name = "grc_hk_req_date";
            this.grc_hk_req_date.Visible = true;
            this.grc_hk_req_date.VisibleIndex = 13;
            // 
            // gclPmcRqDate
            // 
            this.gclPmcRqDate.Caption = "PMC要求日期";
            this.gclPmcRqDate.ColumnEdit = this.repositoryItemTextEdit4;
            this.gclPmcRqDate.FieldName = "pmc_rq_date";
            this.gclPmcRqDate.Name = "gclPmcRqDate";
            this.gclPmcRqDate.Visible = true;
            this.gclPmcRqDate.VisibleIndex = 14;
            this.gclPmcRqDate.Width = 80;
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Mask.EditMask = "9999/99/99";
            this.repositoryItemTextEdit4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.repositoryItemTextEdit4.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // gclDepRpDate
            // 
            this.gclDepRpDate.Caption = "部門复期";
            this.gclDepRpDate.ColumnEdit = this.repositoryItemTextEdit3;
            this.gclDepRpDate.FieldName = "dep_rp_date";
            this.gclDepRpDate.Name = "gclDepRpDate";
            this.gclDepRpDate.Visible = true;
            this.gclDepRpDate.VisibleIndex = 16;
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Mask.EditMask = "9999/99/99";
            this.repositoryItemTextEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.repositoryItemTextEdit3.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // gclPrdDate
            // 
            this.gclPrdDate.Caption = "生產日期";
            this.gclPrdDate.FieldName = "prd_date";
            this.gclPrdDate.Name = "gclPrdDate";
            this.gclPrdDate.OptionsColumn.ReadOnly = true;
            this.gclPrdDate.Visible = true;
            this.gclPrdDate.VisibleIndex = 17;
            // 
            // gclPrdMachine
            // 
            this.gclPrdMachine.Caption = "安排機器";
            this.gclPrdMachine.ColumnEdit = this.btnScheduleMachine;
            this.gclPrdMachine.FieldName = "prd_machine";
            this.gclPrdMachine.Name = "gclPrdMachine";
            this.gclPrdMachine.Visible = true;
            this.gclPrdMachine.VisibleIndex = 18;
            this.gclPrdMachine.Width = 80;
            // 
            // btnScheduleMachine
            // 
            this.btnScheduleMachine.AutoHeight = false;
            this.btnScheduleMachine.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnScheduleMachine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.btnScheduleMachine.Name = "btnScheduleMachine";
            this.btnScheduleMachine.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnScheduleMachine_ButtonClick);
            // 
            // gclMachineStdRunNum
            // 
            this.gclMachineStdRunNum.AppearanceHeader.Options.UseTextOptions = true;
            this.gclMachineStdRunNum.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclMachineStdRunNum.Caption = "標準碑數";
            this.gclMachineStdRunNum.DisplayFormat.FormatString = "#,##0";
            this.gclMachineStdRunNum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gclMachineStdRunNum.FieldName = "machine_std_run_num";
            this.gclMachineStdRunNum.Name = "gclMachineStdRunNum";
            this.gclMachineStdRunNum.Visible = true;
            this.gclMachineStdRunNum.VisibleIndex = 19;
            this.gclMachineStdRunNum.Width = 60;
            // 
            // gclMachineStdLineNum
            // 
            this.gclMachineStdLineNum.AppearanceHeader.Options.UseTextOptions = true;
            this.gclMachineStdLineNum.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclMachineStdLineNum.Caption = "每碑行數";
            this.gclMachineStdLineNum.FieldName = "machine_std_line_num";
            this.gclMachineStdLineNum.Name = "gclMachineStdLineNum";
            this.gclMachineStdLineNum.Visible = true;
            this.gclMachineStdLineNum.VisibleIndex = 20;
            this.gclMachineStdLineNum.Width = 40;
            // 
            // gclMachineStdQty
            // 
            this.gclMachineStdQty.Caption = "標準時產量";
            this.gclMachineStdQty.DisplayFormat.FormatString = "#,##0";
            this.gclMachineStdQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gclMachineStdQty.FieldName = "machine_std_qty";
            this.gclMachineStdQty.Name = "gclMachineStdQty";
            this.gclMachineStdQty.Visible = true;
            this.gclMachineStdQty.VisibleIndex = 21;
            // 
            // gclNeedMonNum
            // 
            this.gclNeedMonNum.Caption = "需要碑數";
            this.gclNeedMonNum.DisplayFormat.FormatString = "#,##0";
            this.gclNeedMonNum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gclNeedMonNum.FieldName = "need_mon_num";
            this.gclNeedMonNum.Name = "gclNeedMonNum";
            this.gclNeedMonNum.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "need_mon_num", "{0:#,##0}")});
            this.gclNeedMonNum.Visible = true;
            this.gclNeedMonNum.VisibleIndex = 22;
            this.gclNeedMonNum.Width = 60;
            // 
            // gclModuleTime
            // 
            this.gclModuleTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gclModuleTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclModuleTime.Caption = "需校模時間";
            this.gclModuleTime.FieldName = "req_module_time";
            this.gclModuleTime.Name = "gclModuleTime";
            this.gclModuleTime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "req_module_time", "{0:#,##0}")});
            this.gclModuleTime.Visible = true;
            this.gclModuleTime.VisibleIndex = 23;
            this.gclModuleTime.Width = 50;
            // 
            // gclNeedTime
            // 
            this.gclNeedTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gclNeedTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclNeedTime.Caption = "需生產時間";
            this.gclNeedTime.DisplayFormat.FormatString = "#,##0.00";
            this.gclNeedTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gclNeedTime.FieldName = "req_prd_time";
            this.gclNeedTime.Name = "gclNeedTime";
            this.gclNeedTime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "req_prd_time", "{0:0.##}")});
            this.gclNeedTime.Visible = true;
            this.gclNeedTime.VisibleIndex = 24;
            this.gclNeedTime.Width = 50;
            // 
            // gclReqTotTime
            // 
            this.gclReqTotTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gclReqTotTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclReqTotTime.Caption = "合計需時";
            this.gclReqTotTime.FieldName = "req_tot_time";
            this.gclReqTotTime.Name = "gclReqTotTime";
            this.gclReqTotTime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "req_tot_time", "{0:0.##}")});
            this.gclReqTotTime.Visible = true;
            this.gclReqTotTime.VisibleIndex = 25;
            this.gclReqTotTime.Width = 40;
            // 
            // gclStartTime
            // 
            this.gclStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gclStartTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclStartTime.Caption = "預計開始時間";
            this.gclStartTime.ColumnEdit = this.repositoryItemTextEdit5;
            this.gclStartTime.FieldName = "start_time";
            this.gclStartTime.Name = "gclStartTime";
            this.gclStartTime.Visible = true;
            this.gclStartTime.VisibleIndex = 26;
            this.gclStartTime.Width = 120;
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.AutoHeight = false;
            this.repositoryItemTextEdit5.Mask.EditMask = "9999/99/99 99:99";
            this.repositoryItemTextEdit5.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.repositoryItemTextEdit5.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            // 
            // gclEndTime
            // 
            this.gclEndTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gclEndTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclEndTime.Caption = "預計完成時間";
            this.gclEndTime.FieldName = "end_time";
            this.gclEndTime.Name = "gclEndTime";
            this.gclEndTime.Visible = true;
            this.gclEndTime.VisibleIndex = 27;
            this.gclEndTime.Width = 120;
            // 
            // gclModuleNo
            // 
            this.gclModuleNo.Caption = "模具編號";
            this.gclModuleNo.FieldName = "module_no";
            this.gclModuleNo.Name = "gclModuleNo";
            this.gclModuleNo.Visible = true;
            this.gclModuleNo.VisibleIndex = 28;
            // 
            // gclModuleInstall
            // 
            this.gclModuleInstall.Caption = "上模";
            this.gclModuleInstall.FieldName = "module_install";
            this.gclModuleInstall.Name = "gclModuleInstall";
            this.gclModuleInstall.Visible = true;
            this.gclModuleInstall.VisibleIndex = 29;
            // 
            // gclWorkTypeDesc
            // 
            this.gclWorkTypeDesc.AppearanceHeader.Options.UseTextOptions = true;
            this.gclWorkTypeDesc.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclWorkTypeDesc.Caption = "工作類型";
            this.gclWorkTypeDesc.FieldName = "work_type_desc";
            this.gclWorkTypeDesc.Name = "gclWorkTypeDesc";
            this.gclWorkTypeDesc.OptionsColumn.ReadOnly = true;
            this.gclWorkTypeDesc.Visible = true;
            this.gclWorkTypeDesc.VisibleIndex = 30;
            this.gclWorkTypeDesc.Width = 60;
            // 
            // gclOrderQty
            // 
            this.gclOrderQty.Caption = "訂單數量";
            this.gclOrderQty.DisplayFormat.FormatString = "#,##0";
            this.gclOrderQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gclOrderQty.FieldName = "order_qty";
            this.gclOrderQty.Name = "gclOrderQty";
            this.gclOrderQty.OptionsColumn.ReadOnly = true;
            this.gclOrderQty.Visible = true;
            this.gclOrderQty.VisibleIndex = 31;
            this.gclOrderQty.Width = 60;
            // 
            // gclOrderDate
            // 
            this.gclOrderDate.Caption = "落單日期";
            this.gclOrderDate.FieldName = "order_date";
            this.gclOrderDate.Name = "gclOrderDate";
            this.gclOrderDate.OptionsColumn.ReadOnly = true;
            this.gclOrderDate.Visible = true;
            this.gclOrderDate.VisibleIndex = 32;
            this.gclOrderDate.Width = 80;
            // 
            // gclPrdDep
            // 
            this.gclPrdDep.AppearanceHeader.Options.UseTextOptions = true;
            this.gclPrdDep.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclPrdDep.Caption = "生產部門";
            this.gclPrdDep.FieldName = "prd_dep";
            this.gclPrdDep.Name = "gclPrdDep";
            this.gclPrdDep.OptionsColumn.ReadOnly = true;
            this.gclPrdDep.Visible = true;
            this.gclPrdDep.VisibleIndex = 33;
            // 
            // gclNextWpId
            // 
            this.gclNextWpId.AppearanceHeader.Options.UseTextOptions = true;
            this.gclNextWpId.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclNextWpId.Caption = "下部門";
            this.gclNextWpId.FieldName = "next_wp_id";
            this.gclNextWpId.Name = "gclNextWpId";
            this.gclNextWpId.Visible = true;
            this.gclNextWpId.VisibleIndex = 34;
            // 
            // gclPrdWorker
            // 
            this.gclPrdWorker.AppearanceHeader.Options.UseTextOptions = true;
            this.gclPrdWorker.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclPrdWorker.Caption = "安排工號";
            this.gclPrdWorker.FieldName = "prd_worker";
            this.gclPrdWorker.Name = "gclPrdWorker";
            this.gclPrdWorker.OptionsColumn.ReadOnly = true;
            this.gclPrdWorker.Visible = true;
            this.gclPrdWorker.VisibleIndex = 35;
            this.gclPrdWorker.Width = 100;
            // 
            // gclUpdateFlag
            // 
            this.gclUpdateFlag.AppearanceHeader.Options.UseTextOptions = true;
            this.gclUpdateFlag.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclUpdateFlag.Caption = "更新狀態";
            this.gclUpdateFlag.FieldName = "update_flag";
            this.gclUpdateFlag.Name = "gclUpdateFlag";
            this.gclUpdateFlag.OptionsColumn.ReadOnly = true;
            this.gclUpdateFlag.Width = 80;
            // 
            // gclPmcRpPDate
            // 
            this.gclPmcRpPDate.Caption = "PMC回复日期";
            this.gclPmcRpPDate.ColumnEdit = this.repositoryItemTextEdit1;
            this.gclPmcRpPDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.gclPmcRpPDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gclPmcRpPDate.FieldName = "pmc_rp_date";
            this.gclPmcRpPDate.Name = "gclPmcRpPDate";
            this.gclPmcRpPDate.Visible = true;
            this.gclPmcRpPDate.VisibleIndex = 36;
            this.gclPmcRpPDate.Width = 80;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "9999/99/99";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gclArtWorkFile
            // 
            this.gclArtWorkFile.AppearanceHeader.Options.UseTextOptions = true;
            this.gclArtWorkFile.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclArtWorkFile.Caption = "圖片文件";
            this.gclArtWorkFile.FieldName = "art_image";
            this.gclArtWorkFile.Name = "gclArtWorkFile";
            this.gclArtWorkFile.OptionsColumn.ReadOnly = true;
            // 
            // gclScheduleID
            // 
            this.gclScheduleID.Caption = "排期單號";
            this.gclScheduleID.FieldName = "schedule_id";
            this.gclScheduleID.Name = "gclScheduleID";
            this.gclScheduleID.Visible = true;
            this.gclScheduleID.VisibleIndex = 43;
            // 
            // gclModuleType
            // 
            this.gclModuleType.AppearanceHeader.Options.UseTextOptions = true;
            this.gclModuleType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclModuleType.Caption = "模具類型";
            this.gclModuleType.ColumnEdit = this.lueModuleType;
            this.gclModuleType.FieldName = "module_type";
            this.gclModuleType.Name = "gclModuleType";
            this.gclModuleType.Visible = true;
            this.gclModuleType.VisibleIndex = 37;
            this.gclModuleType.Width = 40;
            // 
            // lueModuleType
            // 
            this.lueModuleType.AutoHeight = false;
            this.lueModuleType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueModuleType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_id", "序號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_cdesc", 40, "描述")});
            this.lueModuleType.Name = "lueModuleType";
            this.lueModuleType.NullText = "";
            // 
            // gclNextDoColor
            // 
            this.gclNextDoColor.Caption = "電鍍顏色";
            this.gclNextDoColor.FieldName = "next_do_color";
            this.gclNextDoColor.Name = "gclNextDoColor";
            this.gclNextDoColor.Visible = true;
            this.gclNextDoColor.VisibleIndex = 38;
            // 
            // gclNextVendId
            // 
            this.gclNextVendId.Caption = "電鍍廠";
            this.gclNextVendId.FieldName = "next_vend_id";
            this.gclNextVendId.Name = "gclNextVendId";
            this.gclNextVendId.Visible = true;
            this.gclNextVendId.VisibleIndex = 39;
            // 
            // gclMoRemark
            // 
            this.gclMoRemark.Caption = "PMC備註";
            this.gclMoRemark.FieldName = "mo_remark";
            this.gclMoRemark.Name = "gclMoRemark";
            this.gclMoRemark.Visible = true;
            this.gclMoRemark.VisibleIndex = 40;
            // 
            // gclDepRemark
            // 
            this.gclDepRemark.Caption = "部門備註";
            this.gclDepRemark.FieldName = "dep_remark";
            this.gclDepRemark.Name = "gclDepRemark";
            this.gclDepRemark.Visible = true;
            this.gclDepRemark.VisibleIndex = 41;
            // 
            // gclStatus
            // 
            this.gclStatus.Caption = "完成狀態";
            this.gclStatus.ColumnEdit = this.lueGvStatus;
            this.gclStatus.FieldName = "status";
            this.gclStatus.Name = "gclStatus";
            this.gclStatus.Visible = true;
            this.gclStatus.VisibleIndex = 42;
            this.gclStatus.Width = 56;
            // 
            // lueGvStatus
            // 
            this.lueGvStatus.AutoHeight = false;
            this.lueGvStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGvStatus.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_id", 40, "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_cdesc", 80, "描述")});
            this.lueGvStatus.Name = "lueGvStatus";
            this.lueGvStatus.NullText = "";
            // 
            // grcPrdItemGroup
            // 
            this.grcPrdItemGroup.Caption = "產品分類";
            this.grcPrdItemGroup.FieldName = "prd_item_group";
            this.grcPrdItemGroup.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.grcPrdItemGroup.Name = "grcPrdItemGroup";
            this.grcPrdItemGroup.Visible = true;
            this.grcPrdItemGroup.VisibleIndex = 53;
            this.grcPrdItemGroup.Width = 120;
            // 
            // glcPreTrQty
            // 
            this.glcPreTrQty.Caption = "上部門來貨數";
            this.glcPreTrQty.DisplayFormat.FormatString = "#,##0";
            this.glcPreTrQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.glcPreTrQty.FieldName = "pre_tr_qty";
            this.glcPreTrQty.Name = "glcPreTrQty";
            this.glcPreTrQty.Visible = true;
            this.glcPreTrQty.VisibleIndex = 44;
            // 
            // grcPreTrDate
            // 
            this.grcPreTrDate.Caption = "上部門來貨日期";
            this.grcPreTrDate.FieldName = "pre_tr_date";
            this.grcPreTrDate.Name = "grcPreTrDate";
            this.grcPreTrDate.Visible = true;
            this.grcPreTrDate.VisibleIndex = 45;
            // 
            // gclPreTrFlag
            // 
            this.gclPreTrFlag.Caption = "來貨狀態";
            this.gclPreTrFlag.FieldName = "pre_tr_flag";
            this.gclPreTrFlag.Name = "gclPreTrFlag";
            this.gclPreTrFlag.Visible = true;
            this.gclPreTrFlag.VisibleIndex = 46;
            // 
            // gclTransferToJx
            // 
            this.gclTransferToJx.Caption = "發貨到JX";
            this.gclTransferToJx.FieldName = "transfer_date_jx";
            this.gclTransferToJx.Name = "gclTransferToJx";
            this.gclTransferToJx.Visible = true;
            this.gclTransferToJx.VisibleIndex = 47;
            // 
            // gclWipRemark
            // 
            this.gclWipRemark.AppearanceCell.Options.UseTextOptions = true;
            this.gclWipRemark.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclWipRemark.Caption = "計劃單備註";
            this.gclWipRemark.FieldName = "wip_remark";
            this.gclWipRemark.Name = "gclWipRemark";
            this.gclWipRemark.Visible = true;
            this.gclWipRemark.VisibleIndex = 48;
            this.gclWipRemark.Width = 160;
            // 
            // grc_order_date
            // 
            this.grc_order_date.Caption = "訂單日期";
            this.grc_order_date.FieldName = "order_date";
            this.grc_order_date.Name = "grc_order_date";
            this.grc_order_date.Visible = true;
            this.grc_order_date.VisibleIndex = 49;
            // 
            // grc_av_prd_days
            // 
            this.grc_av_prd_days.Caption = "可生產天數";
            this.grc_av_prd_days.FieldName = "av_prd_days";
            this.grc_av_prd_days.Name = "grc_av_prd_days";
            this.grc_av_prd_days.Visible = true;
            this.grc_av_prd_days.VisibleIndex = 50;
            // 
            // gric_cs_req_date
            // 
            this.gric_cs_req_date.Caption = "客人要求交貨期";
            this.gric_cs_req_date.FieldName = "cs_req_date";
            this.gric_cs_req_date.Name = "gric_cs_req_date";
            this.gric_cs_req_date.Visible = true;
            this.gric_cs_req_date.VisibleIndex = 51;
            // 
            // grc_re_prd_days
            // 
            this.grc_re_prd_days.Caption = "距離回港天數";
            this.grc_re_prd_days.FieldName = "re_prd_days";
            this.grc_re_prd_days.Name = "grc_re_prd_days";
            this.grc_re_prd_days.Visible = true;
            this.grc_re_prd_days.VisibleIndex = 15;
            this.grc_re_prd_days.Width = 85;
            // 
            // grc_hk_period_flag
            // 
            this.grc_hk_period_flag.Caption = "回港已過期";
            this.grc_hk_period_flag.FieldNameSortGroup = "hk_period_flag";
            this.grc_hk_period_flag.Name = "grc_hk_period_flag";
            this.grc_hk_period_flag.Visible = true;
            this.grc_hk_period_flag.VisibleIndex = 52;
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            this.repositoryItemLookUpEdit4.NullText = "";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("unit_id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("unit_cdesc", "單位描述")});
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            this.repositoryItemLookUpEdit3.NullText = "";
            // 
            // cmbGvStatus
            // 
            this.cmbGvStatus.AutoHeight = false;
            this.cmbGvStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGvStatus.Name = "cmbGvStatus";
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // imgArtWork
            // 
            this.imgArtWork.AutoHeight = false;
            this.imgArtWork.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imgArtWork.Name = "imgArtWork";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "yyyy/mm/dd";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "yyyy/mm/dd";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.prgStatus);
            this.panel3.Controls.Add(this.btnAddToMachine);
            this.panel3.Controls.Add(this.lblNeedPrdDays);
            this.panel3.Controls.Add(this.lblTotal);
            this.panel3.Controls.Add(this.lblReqTotTime);
            this.panel3.Controls.Add(this.lblNotCpQty);
            this.panel3.Controls.Add(this.lblScheduleQty);
            this.panel3.Controls.Add(this.txtReqTotTime);
            this.panel3.Controls.Add(this.txtNeedPrdDays);
            this.panel3.Controls.Add(this.txtNotCpQty);
            this.panel3.Controls.Add(this.txtScheduleQty);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel3.Location = new System.Drawing.Point(0, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1196, 35);
            this.panel3.TabIndex = 38;
            // 
            // prgStatus
            // 
            this.prgStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.prgStatus.Location = new System.Drawing.Point(1091, 6);
            this.prgStatus.Name = "prgStatus";
            this.prgStatus.Size = new System.Drawing.Size(100, 23);
            this.prgStatus.TabIndex = 27;
            // 
            // btnAddToMachine
            // 
            this.btnAddToMachine.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddToMachine.Location = new System.Drawing.Point(995, 6);
            this.btnAddToMachine.Name = "btnAddToMachine";
            this.btnAddToMachine.Size = new System.Drawing.Size(67, 23);
            this.btnAddToMachine.TabIndex = 26;
            this.btnAddToMachine.Text = "添加到機器";
            this.btnAddToMachine.Visible = false;
            this.btnAddToMachine.Click += new System.EventHandler(this.btnAddToMachine_Click);
            // 
            // lblNeedPrdDays
            // 
            this.lblNeedPrdDays.AutoSize = true;
            this.lblNeedPrdDays.Location = new System.Drawing.Point(711, 10);
            this.lblNeedPrdDays.Name = "lblNeedPrdDays";
            this.lblNeedPrdDays.Size = new System.Drawing.Size(21, 14);
            this.lblNeedPrdDays.TabIndex = 25;
            this.lblNeedPrdDays.Text = "天";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(758, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(133, 14);
            this.lblTotal.TabIndex = 25;
            this.lblTotal.Text = "選中單元格的總和：";
            // 
            // lblReqTotTime
            // 
            this.lblReqTotTime.AutoSize = true;
            this.lblReqTotTime.Location = new System.Drawing.Point(400, 10);
            this.lblReqTotTime.Name = "lblReqTotTime";
            this.lblReqTotTime.Size = new System.Drawing.Size(109, 14);
            this.lblReqTotTime.TabIndex = 25;
            this.lblReqTotTime.Text = "合計需生產時間:";
            // 
            // lblNotCpQty
            // 
            this.lblNotCpQty.AutoSize = true;
            this.lblNotCpQty.Location = new System.Drawing.Point(198, 10);
            this.lblNotCpQty.Name = "lblNotCpQty";
            this.lblNotCpQty.Size = new System.Drawing.Size(81, 14);
            this.lblNotCpQty.TabIndex = 25;
            this.lblNotCpQty.Text = "未完成數量:";
            // 
            // lblScheduleQty
            // 
            this.lblScheduleQty.AutoSize = true;
            this.lblScheduleQty.Location = new System.Drawing.Point(18, 10);
            this.lblScheduleQty.Name = "lblScheduleQty";
            this.lblScheduleQty.Size = new System.Drawing.Size(67, 14);
            this.lblScheduleQty.TabIndex = 25;
            this.lblScheduleQty.Text = "排期數量:";
            // 
            // txtReqTotTime
            // 
            this.txtReqTotTime.EditValue = "";
            this.txtReqTotTime.Location = new System.Drawing.Point(511, 7);
            this.txtReqTotTime.Name = "txtReqTotTime";
            this.txtReqTotTime.Properties.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.txtReqTotTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtReqTotTime.Properties.ReadOnly = true;
            this.txtReqTotTime.Size = new System.Drawing.Size(110, 20);
            this.txtReqTotTime.TabIndex = 0;
            // 
            // txtNeedPrdDays
            // 
            this.txtNeedPrdDays.EditValue = "";
            this.txtNeedPrdDays.Location = new System.Drawing.Point(629, 7);
            this.txtNeedPrdDays.Name = "txtNeedPrdDays";
            this.txtNeedPrdDays.Properties.DisplayFormat.FormatString = "{0:#,##0}";
            this.txtNeedPrdDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNeedPrdDays.Properties.ReadOnly = true;
            this.txtNeedPrdDays.Size = new System.Drawing.Size(76, 20);
            this.txtNeedPrdDays.TabIndex = 0;
            // 
            // txtNotCpQty
            // 
            this.txtNotCpQty.EditValue = "";
            this.txtNotCpQty.Location = new System.Drawing.Point(285, 7);
            this.txtNotCpQty.Name = "txtNotCpQty";
            this.txtNotCpQty.Properties.DisplayFormat.FormatString = "{0:#,##0}";
            this.txtNotCpQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNotCpQty.Properties.ReadOnly = true;
            this.txtNotCpQty.Size = new System.Drawing.Size(110, 20);
            this.txtNotCpQty.TabIndex = 0;
            // 
            // txtScheduleQty
            // 
            this.txtScheduleQty.EditValue = "";
            this.txtScheduleQty.Location = new System.Drawing.Point(87, 7);
            this.txtScheduleQty.Name = "txtScheduleQty";
            this.txtScheduleQty.Properties.DisplayFormat.FormatString = "{0:#,##0}";
            this.txtScheduleQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtScheduleQty.Properties.ReadOnly = true;
            this.txtScheduleQty.Size = new System.Drawing.Size(110, 20);
            this.txtScheduleQty.TabIndex = 0;
            // 
            // palShowNotMachine
            // 
            this.palShowNotMachine.Controls.Add(this.gcWaitSchedule);
            this.palShowNotMachine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.palShowNotMachine.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.palShowNotMachine.Location = new System.Drawing.Point(3, 158);
            this.palShowNotMachine.Name = "palShowNotMachine";
            this.palShowNotMachine.Size = new System.Drawing.Size(1196, 281);
            this.palShowNotMachine.TabIndex = 39;
            this.palShowNotMachine.Visible = false;
            // 
            // gcWaitSchedule
            // 
            this.gcWaitSchedule.ContextMenuStrip = this.contextMenu;
            this.gcWaitSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode4.RelationName = "Level1";
            gridLevelNode5.RelationName = "Level2";
            gridLevelNode6.RelationName = "Level3";
            this.gcWaitSchedule.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode4,
            gridLevelNode5,
            gridLevelNode6});
            this.gcWaitSchedule.Location = new System.Drawing.Point(0, 0);
            this.gcWaitSchedule.MainView = this.gvWaitSchedule;
            this.gcWaitSchedule.Name = "gcWaitSchedule";
            this.gcWaitSchedule.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit7,
            this.repositoryItemTextEdit10,
            this.repositoryItemLookUpEdit8,
            this.repositoryItemComboBox1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEdit1,
            this.repositoryItemImageEdit2,
            this.repositoryItemImageEdit3,
            this.repositoryItemPictureEdit2,
            this.repositoryItemButtonEdit1,
            this.repositoryItemDateEdit2,
            this.repositoryItemTextEdit8,
            this.repositoryItemTextEdit9,
            this.repositoryItemTextEdit7,
            this.repositoryItemTextEdit6,
            this.repositoryItemLookUpEdit5,
            this.repositoryItemLookUpEdit6});
            this.gcWaitSchedule.Size = new System.Drawing.Size(1196, 281);
            this.gcWaitSchedule.TabIndex = 38;
            this.gcWaitSchedule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWaitSchedule});
            // 
            // gvWaitSchedule
            // 
            this.gvWaitSchedule.ColumnPanelRowHeight = 35;
            this.gvWaitSchedule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn39,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn45,
            this.gridColumn46,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn40,
            this.gridColumn41,
            this.gridColumn43,
            this.gridColumn44,
            this.gridColumn6,
            this.gridColumn42});
            this.gvWaitSchedule.FooterPanelHeight = 30;
            this.gvWaitSchedule.GridControl = this.gcWaitSchedule;
            this.gvWaitSchedule.IndicatorWidth = 40;
            this.gvWaitSchedule.Name = "gvWaitSchedule";
            this.gvWaitSchedule.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text;
            this.gvWaitSchedule.OptionsSelection.MultiSelect = true;
            this.gvWaitSchedule.OptionsView.ColumnAutoWidth = false;
            this.gvWaitSchedule.OptionsView.ShowFooter = true;
            this.gvWaitSchedule.OptionsView.ShowGroupPanel = false;
            this.gvWaitSchedule.RowHeight = 35;
            this.gvWaitSchedule.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvWaitSchedule_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Width = 30;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "排序";
            this.gridColumn2.FieldName = "schedule_seq";
            this.gridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 41;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "排單日期";
            this.gridColumn3.FieldName = "schedule_date";
            this.gridColumn3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "制單編號";
            this.gridColumn4.FieldName = "prd_mo";
            this.gridColumn4.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 80;
            // 
            // gridColumn39
            // 
            this.gridColumn39.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn39.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn39.Caption = "組別";
            this.gridColumn39.ColumnEdit = this.repositoryItemLookUpEdit6;
            this.gridColumn39.FieldName = "prd_group";
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.Visible = true;
            this.gridColumn39.VisibleIndex = 3;
            this.gridColumn39.Width = 40;
            // 
            // repositoryItemLookUpEdit6
            // 
            this.repositoryItemLookUpEdit6.AutoHeight = false;
            this.repositoryItemLookUpEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit6.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_id", 40, "組別代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_cdesc", 60, "描述")});
            this.repositoryItemLookUpEdit6.Name = "repositoryItemLookUpEdit6";
            this.repositoryItemLookUpEdit6.NullText = "";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "急單標識";
            this.gridColumn5.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn5.FieldName = "urgent_flag";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 60;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_id", 40, "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_cdesc", 60, "描述")});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "物料編號";
            this.gridColumn7.FieldName = "prd_item";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 140;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "圖樣";
            this.gridColumn8.ColumnEdit = this.repositoryItemPictureEdit2;
            this.gridColumn8.FieldName = "ArtWork";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Width = 60;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            this.repositoryItemPictureEdit2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "物料描述";
            this.gridColumn9.FieldName = "goods_name";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 250;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "計劃數量";
            this.gridColumn10.DisplayFormat.FormatString = "#,##0";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "pl_qty";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pl_qty", "{0:#,##0}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            this.gridColumn10.Width = 60;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn11.Caption = "排期數量";
            this.gridColumn11.DisplayFormat.FormatString = "#,##0";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "schedule_qty";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "schedule_qty", "{0:#,##0}")});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 60;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn12.Caption = "生產數量";
            this.gridColumn12.DisplayFormat.FormatString = "#,##0";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn12.FieldName = "prd_qty";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            this.gridColumn12.Width = 60;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "未完成數量";
            this.gridColumn13.DisplayFormat.FormatString = "#,##0";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "not_cp_qty";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "not_cp_qty", "{0:#,##0}")});
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 10;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "安排機器";
            this.gridColumn14.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn14.FieldName = "prd_machine";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 11;
            this.gridColumn14.Width = 80;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn15.Caption = "標準碑數";
            this.gridColumn15.DisplayFormat.FormatString = "#,##0";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "machine_std_run_num";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 12;
            this.gridColumn15.Width = 60;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn16.Caption = "每碑行數";
            this.gridColumn16.FieldName = "machine_std_line_num";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 13;
            this.gridColumn16.Width = 40;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "標準時產量";
            this.gridColumn17.DisplayFormat.FormatString = "#,##0";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn17.FieldName = "machine_std_qty";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 14;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "需要碑數";
            this.gridColumn18.DisplayFormat.FormatString = "#,##0";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn18.FieldName = "need_mon_num";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "need_mon_num", "{0:#,##0}")});
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 15;
            this.gridColumn18.Width = 60;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn19.Caption = "需校模時間";
            this.gridColumn19.FieldName = "req_module_time";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "req_module_time", "{0:#,##0}")});
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 16;
            this.gridColumn19.Width = 50;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn20.Caption = "需生產時間";
            this.gridColumn20.DisplayFormat.FormatString = "#,##0.00";
            this.gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn20.FieldName = "req_prd_time";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "req_prd_time", "{0:0.##}")});
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 17;
            this.gridColumn20.Width = 50;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn21.Caption = "合計需時";
            this.gridColumn21.FieldName = "req_tot_time";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "req_tot_time", "{0:0.##}")});
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 18;
            this.gridColumn21.Width = 40;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn22.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn22.Caption = "預計開始時間";
            this.gridColumn22.ColumnEdit = this.repositoryItemTextEdit6;
            this.gridColumn22.FieldName = "start_time";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 19;
            this.gridColumn22.Width = 120;
            // 
            // repositoryItemTextEdit6
            // 
            this.repositoryItemTextEdit6.AutoHeight = false;
            this.repositoryItemTextEdit6.Mask.EditMask = "9999/99/99 99:99";
            this.repositoryItemTextEdit6.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.repositoryItemTextEdit6.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit6.Name = "repositoryItemTextEdit6";
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn23.Caption = "預計完成時間";
            this.gridColumn23.FieldName = "end_time";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 20;
            this.gridColumn23.Width = 120;
            // 
            // gridColumn45
            // 
            this.gridColumn45.Caption = "模具編號";
            this.gridColumn45.FieldName = "module_no";
            this.gridColumn45.Name = "gridColumn45";
            this.gridColumn45.Visible = true;
            this.gridColumn45.VisibleIndex = 21;
            // 
            // gridColumn46
            // 
            this.gridColumn46.Caption = "上模";
            this.gridColumn46.FieldName = "module_install";
            this.gridColumn46.Name = "gridColumn46";
            this.gridColumn46.Visible = true;
            this.gridColumn46.VisibleIndex = 22;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "生產日期";
            this.gridColumn24.FieldName = "prd_date";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.ReadOnly = true;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 23;
            // 
            // gridColumn25
            // 
            this.gridColumn25.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn25.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn25.Caption = "工作類型";
            this.gridColumn25.FieldName = "work_type_desc";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.ReadOnly = true;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 24;
            this.gridColumn25.Width = 60;
            // 
            // gridColumn26
            // 
            this.gridColumn26.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn26.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn26.Caption = "已移交數量";
            this.gridColumn26.DisplayFormat.FormatString = "#,##0";
            this.gridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn26.FieldName = "cp_qty";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.ReadOnly = true;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 25;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "訂單數量";
            this.gridColumn27.DisplayFormat.FormatString = "#,##0";
            this.gridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn27.FieldName = "order_qty";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.ReadOnly = true;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 26;
            this.gridColumn27.Width = 60;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "落單日期";
            this.gridColumn28.FieldName = "order_date";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.ReadOnly = true;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 27;
            this.gridColumn28.Width = 80;
            // 
            // gridColumn29
            // 
            this.gridColumn29.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn29.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn29.Caption = "生產部門";
            this.gridColumn29.FieldName = "prd_dep";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.ReadOnly = true;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 28;
            // 
            // gridColumn30
            // 
            this.gridColumn30.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn30.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn30.Caption = "下部門";
            this.gridColumn30.FieldName = "next_wp_id";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.ReadOnly = true;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 29;
            // 
            // gridColumn31
            // 
            this.gridColumn31.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn31.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn31.Caption = "安排工號";
            this.gridColumn31.FieldName = "prd_worker";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.ReadOnly = true;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 30;
            this.gridColumn31.Width = 100;
            // 
            // gridColumn32
            // 
            this.gridColumn32.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn32.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn32.Caption = "更新狀態";
            this.gridColumn32.FieldName = "update_flag";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.ReadOnly = true;
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 31;
            this.gridColumn32.Width = 80;
            // 
            // gridColumn33
            // 
            this.gridColumn33.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn33.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn33.Caption = "圖片文件";
            this.gridColumn33.FieldName = "art_image";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.ReadOnly = true;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 32;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "PMC要求日期";
            this.gridColumn34.ColumnEdit = this.repositoryItemTextEdit7;
            this.gridColumn34.FieldName = "pmc_rq_date";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 33;
            this.gridColumn34.Width = 80;
            // 
            // repositoryItemTextEdit7
            // 
            this.repositoryItemTextEdit7.AutoHeight = false;
            this.repositoryItemTextEdit7.Mask.EditMask = "9999/99/99";
            this.repositoryItemTextEdit7.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.repositoryItemTextEdit7.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit7.Name = "repositoryItemTextEdit7";
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "PMC回复日期";
            this.gridColumn35.ColumnEdit = this.repositoryItemTextEdit8;
            this.gridColumn35.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.gridColumn35.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn35.FieldName = "pmc_rp_date";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 34;
            this.gridColumn35.Width = 80;
            // 
            // repositoryItemTextEdit8
            // 
            this.repositoryItemTextEdit8.AutoHeight = false;
            this.repositoryItemTextEdit8.Mask.EditMask = "9999/99/99";
            this.repositoryItemTextEdit8.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.repositoryItemTextEdit8.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit8.Name = "repositoryItemTextEdit8";
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "部門复期";
            this.gridColumn36.ColumnEdit = this.repositoryItemTextEdit9;
            this.gridColumn36.FieldName = "dep_rp_date";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 35;
            // 
            // repositoryItemTextEdit9
            // 
            this.repositoryItemTextEdit9.AutoHeight = false;
            this.repositoryItemTextEdit9.Mask.EditMask = "9999/99/99";
            this.repositoryItemTextEdit9.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.repositoryItemTextEdit9.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit9.Name = "repositoryItemTextEdit9";
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "排期單號";
            this.gridColumn37.FieldName = "schedule_id";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 36;
            // 
            // gridColumn38
            // 
            this.gridColumn38.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn38.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn38.Caption = "模具類型";
            this.gridColumn38.ColumnEdit = this.repositoryItemLookUpEdit5;
            this.gridColumn38.FieldName = "module_type";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 37;
            this.gridColumn38.Width = 40;
            // 
            // repositoryItemLookUpEdit5
            // 
            this.repositoryItemLookUpEdit5.AutoHeight = false;
            this.repositoryItemLookUpEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit5.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_id", "序號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_cdesc", 40, "描述")});
            this.repositoryItemLookUpEdit5.Name = "repositoryItemLookUpEdit5";
            this.repositoryItemLookUpEdit5.NullText = "";
            // 
            // gridColumn40
            // 
            this.gridColumn40.Caption = "電鍍顏色";
            this.gridColumn40.FieldName = "next_do_color";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 38;
            // 
            // gridColumn41
            // 
            this.gridColumn41.Caption = "電鍍廠";
            this.gridColumn41.FieldName = "next_vend_id";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.Visible = true;
            this.gridColumn41.VisibleIndex = 39;
            // 
            // gridColumn43
            // 
            this.gridColumn43.Caption = "PMC備註";
            this.gridColumn43.FieldName = "mo_remark";
            this.gridColumn43.Name = "gridColumn43";
            this.gridColumn43.Visible = true;
            this.gridColumn43.VisibleIndex = 40;
            // 
            // gridColumn44
            // 
            this.gridColumn44.Caption = "部門備註";
            this.gridColumn44.FieldName = "dep_remark";
            this.gridColumn44.Name = "gridColumn44";
            this.gridColumn44.Visible = true;
            this.gridColumn44.VisibleIndex = 41;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "完成狀態";
            this.gridColumn6.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.gridColumn6.FieldName = "status";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 42;
            this.gridColumn6.Width = 56;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_id", 40, "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_cdesc", 80, "描述")});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            // 
            // gridColumn42
            // 
            this.gridColumn42.Caption = "產品分類";
            this.gridColumn42.FieldName = "prd_item_group";
            this.gridColumn42.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.Visible = true;
            this.gridColumn42.VisibleIndex = 43;
            this.gridColumn42.Width = 120;
            // 
            // repositoryItemLookUpEdit7
            // 
            this.repositoryItemLookUpEdit7.AutoHeight = false;
            this.repositoryItemLookUpEdit7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit7.Name = "repositoryItemLookUpEdit7";
            this.repositoryItemLookUpEdit7.NullText = "";
            // 
            // repositoryItemTextEdit10
            // 
            this.repositoryItemTextEdit10.AutoHeight = false;
            this.repositoryItemTextEdit10.Name = "repositoryItemTextEdit10";
            // 
            // repositoryItemLookUpEdit8
            // 
            this.repositoryItemLookUpEdit8.AutoHeight = false;
            this.repositoryItemLookUpEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit8.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("unit_id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("unit_cdesc", "單位描述")});
            this.repositoryItemLookUpEdit8.Name = "repositoryItemLookUpEdit8";
            this.repositoryItemLookUpEdit8.NullText = "";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemImageEdit2
            // 
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            // 
            // repositoryItemImageEdit3
            // 
            this.repositoryItemImageEdit3.AutoHeight = false;
            this.repositoryItemImageEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit3.Name = "repositoryItemImageEdit3";
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.DisplayFormat.FormatString = "yyyy/mm/dd";
            this.repositoryItemDateEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemDateEdit2.EditFormat.FormatString = "yyyy/mm/dd";
            this.repositoryItemDateEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1202, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // palShowMore
            // 
            this.palShowMore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.palShowMore.Controls.Add(this.btnSetUrgentMo);
            this.palShowMore.Controls.Add(this.btnSetMachine);
            this.palShowMore.Controls.Add(this.lueSetUrgentMo);
            this.palShowMore.Controls.Add(this.luePrdMachine);
            this.palShowMore.Controls.Add(this.btnGenScheduleSeq);
            this.palShowMore.Controls.Add(this.btnSetMoStatus);
            this.palShowMore.Controls.Add(this.cmbSetStatus);
            this.palShowMore.Controls.Add(this.lblSetUrgentMo);
            this.palShowMore.Controls.Add(this.lblDepMachine);
            this.palShowMore.Controls.Add(this.label1);
            this.palShowMore.Controls.Add(this.lblSetStatus);
            this.palShowMore.Dock = System.Windows.Forms.DockStyle.Top;
            this.palShowMore.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.palShowMore.Location = new System.Drawing.Point(0, 97);
            this.palShowMore.Name = "palShowMore";
            this.palShowMore.Size = new System.Drawing.Size(1210, 69);
            this.palShowMore.TabIndex = 14;
            this.palShowMore.Visible = false;
            // 
            // btnSetUrgentMo
            // 
            this.btnSetUrgentMo.Location = new System.Drawing.Point(429, 36);
            this.btnSetUrgentMo.Name = "btnSetUrgentMo";
            this.btnSetUrgentMo.Size = new System.Drawing.Size(75, 23);
            this.btnSetUrgentMo.TabIndex = 31;
            this.btnSetUrgentMo.Text = "確認";
            this.btnSetUrgentMo.Click += new System.EventHandler(this.btnSetUrgentMo_Click);
            // 
            // btnSetMachine
            // 
            this.btnSetMachine.Location = new System.Drawing.Point(785, 4);
            this.btnSetMachine.Name = "btnSetMachine";
            this.btnSetMachine.Size = new System.Drawing.Size(75, 23);
            this.btnSetMachine.TabIndex = 31;
            this.btnSetMachine.Text = "確認";
            this.btnSetMachine.Click += new System.EventHandler(this.btnSetMachine_Click);
            // 
            // lueSetUrgentMo
            // 
            this.lueSetUrgentMo.EditValue = "";
            this.lueSetUrgentMo.Location = new System.Drawing.Point(297, 38);
            this.lueSetUrgentMo.Name = "lueSetUrgentMo";
            this.lueSetUrgentMo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSetUrgentMo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueSetUrgentMo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_id", 40, "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("flag_cdesc", 60, "描述")});
            this.lueSetUrgentMo.Properties.NullText = "";
            this.lueSetUrgentMo.Size = new System.Drawing.Size(121, 20);
            this.lueSetUrgentMo.TabIndex = 3;
            // 
            // luePrdMachine
            // 
            this.luePrdMachine.EditValue = "";
            this.luePrdMachine.Location = new System.Drawing.Point(669, 6);
            this.luePrdMachine.Name = "luePrdMachine";
            this.luePrdMachine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePrdMachine.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.luePrdMachine.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("machine_id", 60, "機器代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("machine_rate", 40, "標準轉數"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("machine_mul", 40, "行/碑數")});
            this.luePrdMachine.Properties.NullText = "";
            this.luePrdMachine.Size = new System.Drawing.Size(109, 20);
            this.luePrdMachine.TabIndex = 2;
            // 
            // btnGenScheduleSeq
            // 
            this.btnGenScheduleSeq.Location = new System.Drawing.Point(54, 31);
            this.btnGenScheduleSeq.Name = "btnGenScheduleSeq";
            this.btnGenScheduleSeq.Size = new System.Drawing.Size(75, 23);
            this.btnGenScheduleSeq.TabIndex = 29;
            this.btnGenScheduleSeq.Text = "重排次序";
            this.btnGenScheduleSeq.Click += new System.EventHandler(this.btnGenScheduleSeq_Click);
            // 
            // btnSetMoStatus
            // 
            this.btnSetMoStatus.Location = new System.Drawing.Point(429, 4);
            this.btnSetMoStatus.Name = "btnSetMoStatus";
            this.btnSetMoStatus.Size = new System.Drawing.Size(75, 23);
            this.btnSetMoStatus.TabIndex = 28;
            this.btnSetMoStatus.Text = "確認";
            this.btnSetMoStatus.Click += new System.EventHandler(this.btnSetMoStatus_Click);
            // 
            // cmbSetStatus
            // 
            this.cmbSetStatus.FormattingEnabled = true;
            this.cmbSetStatus.Location = new System.Drawing.Point(297, 5);
            this.cmbSetStatus.Name = "cmbSetStatus";
            this.cmbSetStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbSetStatus.TabIndex = 1;
            // 
            // lblSetUrgentMo
            // 
            this.lblSetUrgentMo.AutoSize = true;
            this.lblSetUrgentMo.Location = new System.Drawing.Point(224, 41);
            this.lblSetUrgentMo.Name = "lblSetUrgentMo";
            this.lblSetUrgentMo.Size = new System.Drawing.Size(67, 14);
            this.lblSetUrgentMo.TabIndex = 24;
            this.lblSetUrgentMo.Text = "急單狀態:";
            // 
            // lblDepMachine
            // 
            this.lblDepMachine.AutoSize = true;
            this.lblDepMachine.Location = new System.Drawing.Point(600, 7);
            this.lblDepMachine.Name = "lblDepMachine";
            this.lblDepMachine.Size = new System.Drawing.Size(67, 14);
            this.lblDepMachine.TabIndex = 24;
            this.lblDepMachine.Text = "生產機器:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "批量設定制單的各種狀態:";
            // 
            // lblSetStatus
            // 
            this.lblSetStatus.AutoSize = true;
            this.lblSetStatus.Location = new System.Drawing.Point(224, 7);
            this.lblSetStatus.Name = "lblSetStatus";
            this.lblSetStatus.Size = new System.Drawing.Size(67, 14);
            this.lblSetStatus.TabIndex = 24;
            this.lblSetStatus.Text = "制單狀態:";
            // 
            // txtPrdMachine
            // 
            this.txtPrdMachine.Location = new System.Drawing.Point(275, 33);
            this.txtPrdMachine.Name = "txtPrdMachine";
            this.txtPrdMachine.Size = new System.Drawing.Size(121, 20);
            this.txtPrdMachine.TabIndex = 5;
            // 
            // cmbCpStatus
            // 
            this.cmbCpStatus.FormattingEnabled = true;
            this.cmbCpStatus.Location = new System.Drawing.Point(94, 32);
            this.cmbCpStatus.Name = "cmbCpStatus";
            this.cmbCpStatus.Size = new System.Drawing.Size(109, 21);
            this.cmbCpStatus.TabIndex = 4;
            // 
            // lblPrdMachine
            // 
            this.lblPrdMachine.AutoSize = true;
            this.lblPrdMachine.Location = new System.Drawing.Point(206, 35);
            this.lblPrdMachine.Name = "lblPrdMachine";
            this.lblPrdMachine.Size = new System.Drawing.Size(67, 14);
            this.lblPrdMachine.TabIndex = 24;
            this.lblPrdMachine.Text = "機器代號:";
            // 
            // lblCpStatus
            // 
            this.lblCpStatus.AutoSize = true;
            this.lblCpStatus.Location = new System.Drawing.Point(10, 35);
            this.lblCpStatus.Name = "lblCpStatus";
            this.lblCpStatus.Size = new System.Drawing.Size(81, 14);
            this.lblCpStatus.TabIndex = 24;
            this.lblCpStatus.Text = "完成數狀態:";
            // 
            // cmbMoStatus
            // 
            this.cmbMoStatus.FormattingEnabled = true;
            this.cmbMoStatus.Location = new System.Drawing.Point(478, 5);
            this.cmbMoStatus.Name = "cmbMoStatus";
            this.cmbMoStatus.Size = new System.Drawing.Size(109, 21);
            this.cmbMoStatus.TabIndex = 3;
            // 
            // lblMoStatus
            // 
            this.lblMoStatus.AutoSize = true;
            this.lblMoStatus.Location = new System.Drawing.Point(409, 8);
            this.lblMoStatus.Name = "lblMoStatus";
            this.lblMoStatus.Size = new System.Drawing.Size(67, 14);
            this.lblMoStatus.TabIndex = 24;
            this.lblMoStatus.Text = "制單狀態:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDep);
            this.panel1.Controls.Add(this.btnShowMore);
            this.panel1.Controls.Add(this.txtPrdMachine);
            this.panel1.Controls.Add(this.lueDepGroup);
            this.panel1.Controls.Add(this.txtOver3Days);
            this.panel1.Controls.Add(this.chkOver3Days);
            this.panel1.Controls.Add(this.cmbCpStatus);
            this.panel1.Controls.Add(this.lblPrdMachine);
            this.panel1.Controls.Add(this.cmbMoStatus);
            this.panel1.Controls.Add(this.lblCpStatus);
            this.panel1.Controls.Add(this.lblMoStatus);
            this.panel1.Controls.Add(this.lblDepGroup);
            this.panel1.Controls.Add(this.lblPrd_dept);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1210, 59);
            this.panel1.TabIndex = 0;
            // 
            // txtDep
            // 
            this.txtDep.Location = new System.Drawing.Point(94, 6);
            this.txtDep.Name = "txtDep";
            this.txtDep.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDep.Properties.MaxLength = 3;
            this.txtDep.Size = new System.Drawing.Size(109, 20);
            this.txtDep.TabIndex = 1;
            this.txtDep.Leave += new System.EventHandler(this.txtDep_Leave);
            // 
            // btnShowMore
            // 
            this.btnShowMore.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnShowMore.Location = new System.Drawing.Point(1141, 12);
            this.btnShowMore.Name = "btnShowMore";
            this.btnShowMore.Size = new System.Drawing.Size(67, 32);
            this.btnShowMore.TabIndex = 29;
            this.btnShowMore.Text = ">>";
            this.btnShowMore.Click += new System.EventHandler(this.btnShowMore_Click);
            // 
            // lueDepGroup
            // 
            this.lueDepGroup.EditValue = "";
            this.lueDepGroup.Location = new System.Drawing.Point(275, 6);
            this.lueDepGroup.Name = "lueDepGroup";
            this.lueDepGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDepGroup.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueDepGroup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("grp_code", 40, "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("grp_cdesc", 60, "描述")});
            this.lueDepGroup.Properties.NullText = "";
            this.lueDepGroup.Size = new System.Drawing.Size(121, 20);
            this.lueDepGroup.TabIndex = 2;
            // 
            // txtOver3Days
            // 
            this.txtOver3Days.EditValue = "3";
            this.txtOver3Days.Location = new System.Drawing.Point(810, 5);
            this.txtOver3Days.Name = "txtOver3Days";
            this.txtOver3Days.Size = new System.Drawing.Size(57, 20);
            this.txtOver3Days.TabIndex = 28;
            // 
            // chkOver3Days
            // 
            this.chkOver3Days.Location = new System.Drawing.Point(623, 3);
            this.chkOver3Days.Name = "chkOver3Days";
            this.chkOver3Days.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkOver3Days.Properties.Appearance.Options.UseFont = true;
            this.chkOver3Days.Properties.AutoWidth = true;
            this.chkOver3Days.Properties.Caption = "只匯出超過此日期的制單:";
            this.chkOver3Days.Size = new System.Drawing.Size(181, 21);
            this.chkOver3Days.TabIndex = 17;
            // 
            // lblDepGroup
            // 
            this.lblDepGroup.AutoSize = true;
            this.lblDepGroup.Location = new System.Drawing.Point(206, 8);
            this.lblDepGroup.Name = "lblDepGroup";
            this.lblDepGroup.Size = new System.Drawing.Size(67, 14);
            this.lblDepGroup.TabIndex = 24;
            this.lblDepGroup.Text = "生產車間:";
            // 
            // lblPrd_dept
            // 
            this.lblPrd_dept.AutoSize = true;
            this.lblPrd_dept.Location = new System.Drawing.Point(24, 8);
            this.lblPrd_dept.Name = "lblPrd_dept";
            this.lblPrd_dept.Size = new System.Drawing.Size(67, 14);
            this.lblPrd_dept.TabIndex = 24;
            this.lblPrd_dept.Text = "生產部門:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "arrange_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "arrange_seq";
            this.dataGridViewTextBoxColumn2.HeaderText = "安排順序";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 45;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "arrange_date";
            this.dataGridViewTextBoxColumn3.HeaderText = "排期日期";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "prd_mo";
            this.dataGridViewTextBoxColumn4.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "mo_urgent";
            this.dataGridViewTextBoxColumn5.HeaderText = "急單(代號)";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "flag_desc";
            this.dataGridViewTextBoxColumn6.HeaderText = "急單(描述)";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "prd_item";
            this.dataGridViewTextBoxColumn7.HeaderText = "物料編號";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 160;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "goods_name";
            this.dataGridViewTextBoxColumn8.HeaderText = "物料描述";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 250;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "arrange_qty";
            this.dataGridViewTextBoxColumn9.HeaderText = "要求數量";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "arrange_machine";
            this.dataGridViewTextBoxColumn10.HeaderText = "安排機器";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "order_date";
            this.dataGridViewTextBoxColumn11.HeaderText = "落單日期";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "req_f_date";
            this.dataGridViewTextBoxColumn12.HeaderText = "要求完成時間";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 120;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "hour_std_qty";
            this.dataGridViewTextBoxColumn13.HeaderText = "機器標準啤數/時";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "estimated_start_date";
            this.dataGridViewTextBoxColumn14.HeaderText = "預計開始日期";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            this.dataGridViewTextBoxColumn14.Width = 120;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "estimated_start_time";
            this.dataGridViewTextBoxColumn15.HeaderText = "預計開始時間";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "estimated_date";
            this.dataGridViewTextBoxColumn16.HeaderText = "預計完成日期";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Visible = false;
            this.dataGridViewTextBoxColumn16.Width = 160;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "estimated_time";
            this.dataGridViewTextBoxColumn17.HeaderText = "預計完成時間";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Visible = false;
            this.dataGridViewTextBoxColumn17.Width = 160;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "req_time";
            this.dataGridViewTextBoxColumn18.HeaderText = "預計所需時間";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 80;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "prd_date";
            this.dataGridViewTextBoxColumn19.HeaderText = "實際開始日期";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Width = 80;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "prd_start_time";
            this.dataGridViewTextBoxColumn20.HeaderText = "實際開始時間";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "prd_end_time";
            this.dataGridViewTextBoxColumn21.HeaderText = "實際結束時間";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.Width = 60;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "prd_req_time";
            this.dataGridViewTextBoxColumn22.HeaderText = "實際預計完成時間";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.Visible = false;
            this.dataGridViewTextBoxColumn22.Width = 60;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "prd_qty";
            this.dataGridViewTextBoxColumn23.HeaderText = "實際生產數量";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.Visible = false;
            this.dataGridViewTextBoxColumn23.Width = 50;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "to_dep";
            this.dataGridViewTextBoxColumn24.HeaderText = "預計校模時間";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.Visible = false;
            this.dataGridViewTextBoxColumn24.Width = 60;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "prd_dep";
            this.dataGridViewTextBoxColumn25.HeaderText = "生產部門";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.Visible = false;
            this.dataGridViewTextBoxColumn25.Width = 60;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "prd_seq";
            this.dataGridViewTextBoxColumn26.HeaderText = "序號";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.Visible = false;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "prd_ver";
            this.dataGridViewTextBoxColumn27.HeaderText = "版本號";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.Visible = false;
            this.dataGridViewTextBoxColumn27.Width = 50;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "to_dep";
            this.dataGridViewTextBoxColumn28.HeaderText = "下一部門";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.Width = 60;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "art_image";
            this.dataGridViewTextBoxColumn29.HeaderText = "圖片文件";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.Visible = false;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "prd_worker";
            this.dataGridViewTextBoxColumn30.HeaderText = "安排工號";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "Prd_status";
            this.dataGridViewTextBoxColumn31.HeaderText = "完成狀態";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "Prd_status_desc";
            this.dataGridViewTextBoxColumn32.HeaderText = "完成狀態";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            // 
            // chkScheduleByMachine
            // 
            this.chkScheduleByMachine.Location = new System.Drawing.Point(822, 11);
            this.chkScheduleByMachine.Name = "chkScheduleByMachine";
            this.chkScheduleByMachine.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkScheduleByMachine.Properties.Appearance.Options.UseFont = true;
            this.chkScheduleByMachine.Properties.Caption = "按機器排期";
            this.chkScheduleByMachine.Size = new System.Drawing.Size(103, 21);
            this.chkScheduleByMachine.TabIndex = 17;
            this.chkScheduleByMachine.CheckedChanged += new System.EventHandler(this.chkScheduleByMachine_CheckedChanged);
            this.chkScheduleByMachine.Click += new System.EventHandler(this.chkScheduleByMachine_Click);
            // 
            // frmMoSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 634);
            this.Controls.Add(this.chkScheduleByMachine);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.palShowMore);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMoSchedule";
            this.Text = "frmMoSchedule";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMoSchedule_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.palShowHasSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSchedule)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePrdGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGvUrgentFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrdItemFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnScheduleMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueModuleType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGvStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGvStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgArtWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqTotTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNeedPrdDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotCpQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScheduleQty.Properties)).EndInit();
            this.palShowNotMachine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcWaitSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWaitSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            this.palShowMore.ResumeLayout(false);
            this.palShowMore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueSetUrgentMo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePrdMachine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdMachine.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOver3Days.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOver3Days.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkScheduleByMachine.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnNewSchedule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSetParas;
        private System.Windows.Forms.ToolStripButton btnDepPrd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExpToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnMachine_status;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnMakeOrderStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel palShowMore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPrd_dept;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem cutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteMenuItem;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private DevExpress.XtraGrid.GridControl gcSchedule;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSchedule;
        private DevExpress.XtraGrid.Columns.GridColumn gclScheduleSeq;
        private DevExpress.XtraGrid.Columns.GridColumn gclScheduleDate;
        private DevExpress.XtraGrid.Columns.GridColumn gclPrdMo;
        private DevExpress.XtraGrid.Columns.GridColumn gclUrgentFlag;
        private DevExpress.XtraGrid.Columns.GridColumn gclStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gclPrdItem;
        private DevExpress.XtraGrid.Columns.GridColumn gclArtWork;
        private DevExpress.XtraGrid.Columns.GridColumn gclPrdIitemCdesc;
        private DevExpress.XtraGrid.Columns.GridColumn gclOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn gclPlQty;
        private DevExpress.XtraGrid.Columns.GridColumn gclScheduleQty;
        private DevExpress.XtraGrid.Columns.GridColumn gclPrdMachine;
        private DevExpress.XtraGrid.Columns.GridColumn gclOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn gclStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn gclMachineStdRunNum;
        private DevExpress.XtraGrid.Columns.GridColumn gclEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn gclNeedTime;
        private DevExpress.XtraGrid.Columns.GridColumn gclPrdQty;
        private DevExpress.XtraGrid.Columns.GridColumn gclCpQty;
        private DevExpress.XtraGrid.Columns.GridColumn gclPrdDep;
        private DevExpress.XtraGrid.Columns.GridColumn gclNextWpId;
        private DevExpress.XtraGrid.Columns.GridColumn gclPrdWorker;
        private DevExpress.XtraGrid.Columns.GridColumn gclUpdateFlag;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbGvStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueGvStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueGvUrgentFlag;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit imgArtWork;
        private DevExpress.XtraGrid.Columns.GridColumn gclArtWorkFile;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gclSeq;
        private DevExpress.XtraGrid.Columns.GridColumn gclModuleTime;
        private DevExpress.XtraGrid.Columns.GridColumn gclNeedMonNum;
        private DevExpress.XtraGrid.Columns.GridColumn gclMachineStdLineNum;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnScheduleMachine;
        private DevExpress.XtraGrid.Columns.GridColumn gclPmcRqDate;
        private DevExpress.XtraGrid.Columns.GridColumn gclPmcRpPDate;
        private DevExpress.XtraGrid.Columns.GridColumn gclDepRpDate;
        private DevExpress.XtraGrid.Columns.GridColumn gclScheduleID;
        private DevExpress.XtraGrid.Columns.GridColumn gclPrdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gclNotCpQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn gclReqTotTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraGrid.Columns.GridColumn gclMachineStdQty;
        private DevExpress.XtraGrid.Columns.GridColumn gclModuleType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueModuleType;
        private DevExpress.XtraGrid.Columns.GridColumn gclPrdGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luePrdGroup;
        private DevExpress.XtraGrid.Columns.GridColumn gclNextDoColor;
        private DevExpress.XtraGrid.Columns.GridColumn gclNextVendId;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.TextEdit txtScheduleQty;
        private DevExpress.XtraEditors.TextEdit txtNeedPrdDays;
        private DevExpress.XtraEditors.TextEdit txtNotCpQty;
        private DevExpress.XtraEditors.TextEdit txtReqTotTime;
        private DevExpress.XtraGrid.Columns.GridColumn gclWorkTypeDesc;
        private System.Windows.Forms.Label lblDepGroup;
        private System.Windows.Forms.Label lblNeedPrdDays;
        private System.Windows.Forms.Label lblReqTotTime;
        private System.Windows.Forms.Label lblNotCpQty;
        private System.Windows.Forms.Label lblScheduleQty;
        private System.Windows.Forms.Panel palShowNotMachine;
        private System.Windows.Forms.Panel palShowHasSchedule;
        private DevExpress.XtraGrid.GridControl gcWaitSchedule;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWaitSchedule;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit7;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit8;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraEditors.CheckEdit chkScheduleByMachine;
        private DevExpress.XtraEditors.TextEdit txtPrdMachine;
        private DevExpress.XtraEditors.SimpleButton btnAddToMachine;
        private System.Windows.Forms.Label lblPrdMachine;
        private System.Windows.Forms.ComboBox cmbSetStatus;
        private System.Windows.Forms.Label lblSetStatus;
        private DevExpress.XtraEditors.SimpleButton btnShowMore;
        private DevExpress.XtraEditors.SimpleButton btnSetMoStatus;
        private System.Windows.Forms.ComboBox cmbMoStatus;
        private System.Windows.Forms.Label lblMoStatus;
        private DevExpress.XtraGrid.Columns.GridColumn grcPrdItemGroup;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn42;
        private DevExpress.XtraEditors.SimpleButton btnGenScheduleSeq;
        private System.Windows.Forms.Label lblTotal;
        private DevExpress.XtraEditors.LookUpEdit luePrdMachine;
        private System.Windows.Forms.Label lblDepMachine;
        private DevExpress.XtraEditors.SimpleButton btnSetMachine;
        private DevExpress.XtraEditors.SimpleButton btnSetUrgentMo;
        private DevExpress.XtraEditors.LookUpEdit lueSetUrgentMo;
        private System.Windows.Forms.Label lblSetUrgentMo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gclMoRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gclDepRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn44;
        private System.Windows.Forms.ToolStripButton btnExcelByMachine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevExpress.XtraGrid.Columns.GridColumn gclModuleNo;
        private DevExpress.XtraGrid.Columns.GridColumn gclModuleInstall;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn45;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn46;
        private System.Windows.Forms.ComboBox cmbCpStatus;
        private System.Windows.Forms.Label lblCpStatus;
        private DevExpress.XtraEditors.CheckEdit chkOver3Days;
        private DevExpress.XtraEditors.TextEdit txtOver3Days;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit11;
        private System.Windows.Forms.ProgressBar prgStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnPrdItemFind;
        private DevExpress.XtraEditors.LookUpEdit lueDepGroup;
        private DevExpress.XtraGrid.Columns.GridColumn gclPassDays;
        private DevExpress.XtraGrid.Columns.GridColumn remark_105;
        private DevExpress.XtraEditors.TextEdit txtDep;
        private DevExpress.XtraGrid.Columns.GridColumn glcPreTrQty;
        private DevExpress.XtraGrid.Columns.GridColumn grcPreTrDate;
        private DevExpress.XtraGrid.Columns.GridColumn gclPreTrFlag;
        private System.Windows.Forms.ToolStripButton btnExpSum;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private DevExpress.XtraGrid.Columns.GridColumn gclTransferToJx;
        private DevExpress.XtraGrid.Columns.GridColumn gclWipRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grc_hk_req_date;
        private DevExpress.XtraGrid.Columns.GridColumn grc_order_date;
        private DevExpress.XtraGrid.Columns.GridColumn grc_av_prd_days;
        private DevExpress.XtraGrid.Columns.GridColumn gric_cs_req_date;
        private DevExpress.XtraGrid.Columns.GridColumn grc_re_prd_days;
        private DevExpress.XtraGrid.Columns.GridColumn grc_hk_period_flag;
    }
}