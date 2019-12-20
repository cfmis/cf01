namespace cf01.Forms
{
    partial class frmPackingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPackingList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNewRec = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelRec = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBatchPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.xtbControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.chkPrint = new DevExpress.XtraEditors.CheckEdit();
            this.gcHead = new DevExpress.XtraGrid.GridControl();
            this.gvHead = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colId_h = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPack_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDetails = new DevExpress.XtraGrid.GridControl();
            this.gvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoods_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPcs_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBox_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNw_each = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGw_each = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTal_nw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTal_gw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmbUnit_code = new System.Windows.Forms.ComboBox();
            this.lueCarton_size = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSec_unit = new DevExpress.XtraEditors.LookUpEdit();
            this.txtOrder_id = new DevExpress.XtraEditors.TextEdit();
            this.lblOrder_id = new DevExpress.XtraEditors.LabelControl();
            this.txtTr_id_weg = new DevExpress.XtraEditors.TextEdit();
            this.txtTr_id_seq = new DevExpress.XtraEditors.TextEdit();
            this.lblTr_id_weg = new DevExpress.XtraEditors.LabelControl();
            this.lblTr_id_seq = new DevExpress.XtraEditors.LabelControl();
            this.txtTr_id = new DevExpress.XtraEditors.TextEdit();
            this.lblTr_id = new DevExpress.XtraEditors.LabelControl();
            this.txtRef_id = new DevExpress.XtraEditors.TextEdit();
            this.txtPo_no = new DevExpress.XtraEditors.TextEdit();
            this.lblPo_no = new DevExpress.XtraEditors.LabelControl();
            this.txtCube_ctn = new DevExpress.XtraEditors.TextEdit();
            this.lblCube_ctn = new DevExpress.XtraEditors.LabelControl();
            this.txtBox_qty = new DevExpress.XtraEditors.TextEdit();
            this.lblBox_qty = new DevExpress.XtraEditors.LabelControl();
            this.txtTal_gw = new DevExpress.XtraEditors.TextEdit();
            this.txtColor = new DevExpress.XtraEditors.TextEdit();
            this.txtGoods_name = new DevExpress.XtraEditors.TextEdit();
            this.txtGoods_ename = new DevExpress.XtraEditors.TextEdit();
            this.lblColor = new DevExpress.XtraEditors.LabelControl();
            this.lblGoods_name = new DevExpress.XtraEditors.LabelControl();
            this.txtRemark_d = new DevExpress.XtraEditors.TextEdit();
            this.lblGoods_ename = new DevExpress.XtraEditors.LabelControl();
            this.txtSymbol = new DevExpress.XtraEditors.TextEdit();
            this.lbRemark = new DevExpress.XtraEditors.LabelControl();
            this.lblTal_gw = new DevExpress.XtraEditors.LabelControl();
            this.lblSymbol = new DevExpress.XtraEditors.LabelControl();
            this.txtTal_nw = new DevExpress.XtraEditors.TextEdit();
            this.txtNw_each = new DevExpress.XtraEditors.TextEdit();
            this.txtBox_no = new DevExpress.XtraEditors.TextEdit();
            this.lblCarton_size = new DevExpress.XtraEditors.LabelControl();
            this.lblTal_nw = new DevExpress.XtraEditors.LabelControl();
            this.lblSec_unit = new DevExpress.XtraEditors.LabelControl();
            this.lblNw_each = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotal_cube = new DevExpress.XtraEditors.TextEdit();
            this.txtGw_each = new DevExpress.XtraEditors.TextEdit();
            this.txtPbox_qty = new DevExpress.XtraEditors.TextEdit();
            this.lblTotal_cube = new DevExpress.XtraEditors.LabelControl();
            this.lblUnit_code = new DevExpress.XtraEditors.LabelControl();
            this.lblGw_each = new DevExpress.XtraEditors.LabelControl();
            this.lblPbox_qty = new DevExpress.XtraEditors.LabelControl();
            this.txtPcs_qty = new DevExpress.XtraEditors.TextEdit();
            this.lblTransfer_amount = new DevExpress.XtraEditors.LabelControl();
            this.lblShowInfo = new DevExpress.XtraEditors.LabelControl();
            this.chkSet = new DevExpress.XtraEditors.CheckEdit();
            this.txtBarCode = new DevExpress.XtraEditors.TextEdit();
            this.lblBarCode = new DevExpress.XtraEditors.LabelControl();
            this.lueGoods_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lblGoods_id = new DevExpress.XtraEditors.LabelControl();
            this.txtSeq = new DevExpress.XtraEditors.TextEdit();
            this.lblSeq = new DevExpress.XtraEditors.LabelControl();
            this.txtMo_id = new DevExpress.XtraEditors.TextEdit();
            this.lblMo_id = new DevExpress.XtraEditors.LabelControl();
            this.lblRef_id = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkAftSavePrint = new DevExpress.XtraEditors.CheckEdit();
            this.rdbAftSave = new DevExpress.XtraEditors.RadioGroup();
            this.lueOrigin_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lueType = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTypeNo = new DevExpress.XtraEditors.LabelControl();
            this.lblUpdate_Date = new DevExpress.XtraEditors.LabelControl();
            this.lblCreate_Date = new DevExpress.XtraEditors.LabelControl();
            this.lblUpdate_By = new DevExpress.XtraEditors.LabelControl();
            this.lblRemark = new DevExpress.XtraEditors.LabelControl();
            this.lblCreate_By = new DevExpress.XtraEditors.LabelControl();
            this.txtUpdate_Date = new DevExpress.XtraEditors.TextEdit();
            this.txtCreate_Date = new DevExpress.XtraEditors.TextEdit();
            this.txtUpdate_By = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.TextEdit();
            this.txtCreate_By = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtSailing_date = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtFax = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCustomer = new DevExpress.XtraEditors.TextEdit();
            this.txtLinkman = new DevExpress.XtraEditors.TextEdit();
            this.lblDestination = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDestination = new DevExpress.XtraEditors.TextEdit();
            this.txtShipping_tool = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCustomer_id = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblState = new DevExpress.XtraEditors.LabelControl();
            this.txtState = new DevExpress.XtraEditors.TextEdit();
            this.lblTransfer_Date = new DevExpress.XtraEditors.LabelControl();
            this.lblId = new DevExpress.XtraEditors.LabelControl();
            this.txtPacking_date = new DevExpress.XtraEditors.TextEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtDate2 = new DevExpress.XtraEditors.TextEdit();
            this.txtDate1 = new DevExpress.XtraEditors.TextEdit();
            this.btnPrint1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtPid2 = new DevExpress.XtraEditors.TextEdit();
            this.txtPid1 = new DevExpress.XtraEditors.TextEdit();
            this.lblPid = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtbControl1)).BeginInit();
            this.xtbControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCarton_size.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSec_unit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrder_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTr_id_weg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTr_id_seq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTr_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRef_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPo_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCube_ctn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBox_qty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTal_gw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_ename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark_d.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSymbol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTal_nw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNw_each.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBox_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal_cube.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGw_each.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPbox_qty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPcs_qty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoods_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAftSavePrint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbAftSave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOrigin_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdate_Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdate_By.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_By.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSailing_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkman.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipping_tool.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPacking_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPid2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPid1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnNew,
            this.toolStripSeparator2,
            this.btnNewRec,
            this.toolStripSeparator5,
            this.btnUndo,
            this.toolStripSeparator4,
            this.btnSave,
            this.toolStripSeparator6,
            this.btnDelete,
            this.toolStripSeparator7,
            this.btnDelRec,
            this.toolStripSeparator3,
            this.btnPrint,
            this.toolStripSeparator8,
            this.btnBatchPrint,
            this.toolStripSeparator9,
            this.btnFind});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(970, 35);
            this.toolStrip1.TabIndex = 0;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = false;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(65, 35);
            this.btnNew.Text = "新單(&A)";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // btnNewRec
            // 
            this.btnNewRec.AutoSize = false;
            this.btnNewRec.Image = ((System.Drawing.Image)(resources.GetObject("btnNewRec.Image")));
            this.btnNewRec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewRec.Name = "btnNewRec";
            this.btnNewRec.Size = new System.Drawing.Size(65, 32);
            this.btnNewRec.Text = "新記錄";
            this.btnNewRec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewRec.Click += new System.EventHandler(this.btnNewRec_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 35);
            // 
            // btnUndo
            // 
            this.btnUndo.AutoSize = false;
            this.btnUndo.Enabled = false;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(65, 35);
            this.btnUndo.Text = "取消(&U)";
            this.btnUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 35);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 35);
            this.btnSave.Text = "儲存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 35);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 35);
            this.btnDelete.Text = "刪除單據";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 35);
            // 
            // btnDelRec
            // 
            this.btnDelRec.AutoSize = false;
            this.btnDelRec.Image = ((System.Drawing.Image)(resources.GetObject("btnDelRec.Image")));
            this.btnDelRec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelRec.Name = "btnDelRec";
            this.btnDelRec.Size = new System.Drawing.Size(65, 35);
            this.btnDelRec.Text = "刪除記錄(&D)";
            this.btnDelRec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelRec.Click += new System.EventHandler(this.btnDelRec_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = false;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 35);
            this.btnPrint.Text = "列印(&P)";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 35);
            // 
            // btnBatchPrint
            // 
            this.btnBatchPrint.AutoSize = false;
            this.btnBatchPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnBatchPrint.Image")));
            this.btnBatchPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBatchPrint.Name = "btnBatchPrint";
            this.btnBatchPrint.Size = new System.Drawing.Size(65, 35);
            this.btnBatchPrint.Text = "批量列印";
            this.btnBatchPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBatchPrint.Click += new System.EventHandler(this.btnBatchPrint_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 35);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 35);
            this.btnFind.Text = "查詢(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // xtbControl1
            // 
            this.xtbControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtbControl1.Location = new System.Drawing.Point(0, 35);
            this.xtbControl1.Name = "xtbControl1";
            this.xtbControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtbControl1.Size = new System.Drawing.Size(970, 567);
            this.xtbControl1.TabIndex = 1;
            this.xtbControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtbControl1.Click += new System.EventHandler(this.xtbControl1_Click);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.splitContainerControl1);
            this.xtraTabPage1.Controls.Add(this.panelControl2);
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(964, 538);
            this.xtraTabPage1.Text = "數據錄入";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 353);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.chkPrint);
            this.splitContainerControl1.Panel1.Controls.Add(this.gcHead);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcDetails);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(964, 185);
            this.splitContainerControl1.SplitterPosition = 353;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // chkPrint
            // 
            this.chkPrint.Location = new System.Drawing.Point(18, 3);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Properties.Caption = "";
            this.chkPrint.Size = new System.Drawing.Size(33, 19);
            this.chkPrint.TabIndex = 50;
            this.chkPrint.Click += new System.EventHandler(this.chkPrint_Click);
            // 
            // gcHead
            // 
            this.gcHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHead.Location = new System.Drawing.Point(0, 0);
            this.gcHead.MainView = this.gvHead;
            this.gcHead.Name = "gcHead";
            this.gcHead.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcHead.Size = new System.Drawing.Size(353, 185);
            this.gcHead.TabIndex = 0;
            this.gcHead.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHead});
            // 
            // gvHead
            // 
            this.gvHead.ColumnPanelRowHeight = 25;
            this.gvHead.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelect,
            this.colId_h,
            this.colPack_date,
            this.colCustomer_id});
            this.gvHead.GridControl = this.gcHead;
            this.gvHead.Name = "gvHead";
            this.gvHead.OptionsSelection.MultiSelect = true;
            this.gvHead.OptionsView.ColumnAutoWidth = false;
            this.gvHead.OptionsView.ShowGroupPanel = false;
            this.gvHead.RowHeight = 25;
            this.gvHead.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvHead_RowCellClick);
            // 
            // colSelect
            // 
            this.colSelect.Caption = "選取";
            this.colSelect.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSelect.FieldName = "check";
            this.colSelect.Name = "colSelect";
            this.colSelect.Visible = true;
            this.colSelect.VisibleIndex = 0;
            this.colSelect.Width = 36;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colId_h
            // 
            this.colId_h.Caption = "單據編號";
            this.colId_h.FieldName = "id";
            this.colId_h.Name = "colId_h";
            this.colId_h.OptionsColumn.AllowEdit = false;
            this.colId_h.Visible = true;
            this.colId_h.VisibleIndex = 1;
            this.colId_h.Width = 120;
            // 
            // colPack_date
            // 
            this.colPack_date.Caption = "裝箱日期";
            this.colPack_date.FieldName = "packing_date";
            this.colPack_date.Name = "colPack_date";
            this.colPack_date.OptionsColumn.AllowEdit = false;
            this.colPack_date.Visible = true;
            this.colPack_date.VisibleIndex = 2;
            this.colPack_date.Width = 80;
            // 
            // colCustomer_id
            // 
            this.colCustomer_id.Caption = "客人編號";
            this.colCustomer_id.FieldName = "customer_id";
            this.colCustomer_id.Name = "colCustomer_id";
            this.colCustomer_id.OptionsColumn.AllowEdit = false;
            this.colCustomer_id.Visible = true;
            this.colCustomer_id.VisibleIndex = 3;
            this.colCustomer_id.Width = 80;
            // 
            // gcDetails
            // 
            this.gcDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetails.Location = new System.Drawing.Point(0, 0);
            this.gcDetails.MainView = this.gvDetails;
            this.gcDetails.Name = "gcDetails";
            this.gcDetails.Size = new System.Drawing.Size(606, 185);
            this.gcDetails.TabIndex = 2;
            this.gcDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetails});
            // 
            // gvDetails
            // 
            this.gvDetails.ColumnPanelRowHeight = 25;
            this.gvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSequence_id,
            this.colMo_id,
            this.colGoods_id,
            this.colGoods_name,
            this.colSet,
            this.colPcs_qty,
            this.colBox_no,
            this.colNw_each,
            this.colGw_each,
            this.colTal_nw,
            this.colTal_gw,
            this.colRemark});
            this.gvDetails.GridControl = this.gcDetails;
            this.gvDetails.Name = "gvDetails";
            this.gvDetails.OptionsBehavior.Editable = false;
            this.gvDetails.OptionsBehavior.ReadOnly = true;
            this.gvDetails.OptionsSelection.MultiSelect = true;
            this.gvDetails.OptionsView.ColumnAutoWidth = false;
            this.gvDetails.OptionsView.ShowGroupPanel = false;
            this.gvDetails.RowHeight = 25;
            this.gvDetails.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvDetails_RowCellClick);
            // 
            // colSequence_id
            // 
            this.colSequence_id.Caption = "序號";
            this.colSequence_id.FieldName = "sequence_id";
            this.colSequence_id.Name = "colSequence_id";
            this.colSequence_id.Visible = true;
            this.colSequence_id.VisibleIndex = 0;
            this.colSequence_id.Width = 60;
            // 
            // colMo_id
            // 
            this.colMo_id.Caption = "制單編號";
            this.colMo_id.FieldName = "mo_id";
            this.colMo_id.Name = "colMo_id";
            this.colMo_id.Visible = true;
            this.colMo_id.VisibleIndex = 1;
            this.colMo_id.Width = 100;
            // 
            // colGoods_id
            // 
            this.colGoods_id.Caption = "產品編號";
            this.colGoods_id.FieldName = "item_no";
            this.colGoods_id.Name = "colGoods_id";
            this.colGoods_id.Visible = true;
            this.colGoods_id.VisibleIndex = 2;
            this.colGoods_id.Width = 180;
            // 
            // colGoods_name
            // 
            this.colGoods_name.Caption = "產品描述";
            this.colGoods_name.FieldName = "descript";
            this.colGoods_name.Name = "colGoods_name";
            this.colGoods_name.Visible = true;
            this.colGoods_name.VisibleIndex = 3;
            this.colGoods_name.Width = 260;
            // 
            // colSet
            // 
            this.colSet.Caption = "整套";
            this.colSet.FieldName = "shipment_suit";
            this.colSet.Name = "colSet";
            this.colSet.Visible = true;
            this.colSet.VisibleIndex = 4;
            this.colSet.Width = 40;
            // 
            // colPcs_qty
            // 
            this.colPcs_qty.Caption = "數量";
            this.colPcs_qty.FieldName = "pcs_qty";
            this.colPcs_qty.Name = "colPcs_qty";
            this.colPcs_qty.Visible = true;
            this.colPcs_qty.VisibleIndex = 5;
            this.colPcs_qty.Width = 80;
            // 
            // colBox_no
            // 
            this.colBox_no.Caption = "箱數";
            this.colBox_no.FieldName = "box_no";
            this.colBox_no.Name = "colBox_no";
            this.colBox_no.Visible = true;
            this.colBox_no.VisibleIndex = 6;
            this.colBox_no.Width = 60;
            // 
            // colNw_each
            // 
            this.colNw_each.Caption = "凈重/箱";
            this.colNw_each.FieldName = "nw_each";
            this.colNw_each.Name = "colNw_each";
            this.colNw_each.Visible = true;
            this.colNw_each.VisibleIndex = 7;
            this.colNw_each.Width = 70;
            // 
            // colGw_each
            // 
            this.colGw_each.Caption = "毛重/箱";
            this.colGw_each.FieldName = "gw_each";
            this.colGw_each.Name = "colGw_each";
            this.colGw_each.Visible = true;
            this.colGw_each.VisibleIndex = 8;
            this.colGw_each.Width = 70;
            // 
            // colTal_nw
            // 
            this.colTal_nw.Caption = "總凈重";
            this.colTal_nw.FieldName = "tal_nw";
            this.colTal_nw.Name = "colTal_nw";
            this.colTal_nw.Visible = true;
            this.colTal_nw.VisibleIndex = 9;
            this.colTal_nw.Width = 70;
            // 
            // colTal_gw
            // 
            this.colTal_gw.Caption = "總毛重";
            this.colTal_gw.FieldName = "tal_gw";
            this.colTal_gw.Name = "colTal_gw";
            this.colTal_gw.Visible = true;
            this.colTal_gw.VisibleIndex = 10;
            this.colTal_gw.Width = 70;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "備註";
            this.colRemark.FieldName = "remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 11;
            this.colRemark.Width = 200;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cmbUnit_code);
            this.panelControl2.Controls.Add(this.lueCarton_size);
            this.panelControl2.Controls.Add(this.lueSec_unit);
            this.panelControl2.Controls.Add(this.txtOrder_id);
            this.panelControl2.Controls.Add(this.lblOrder_id);
            this.panelControl2.Controls.Add(this.txtTr_id_weg);
            this.panelControl2.Controls.Add(this.txtTr_id_seq);
            this.panelControl2.Controls.Add(this.lblTr_id_weg);
            this.panelControl2.Controls.Add(this.lblTr_id_seq);
            this.panelControl2.Controls.Add(this.txtTr_id);
            this.panelControl2.Controls.Add(this.lblTr_id);
            this.panelControl2.Controls.Add(this.txtRef_id);
            this.panelControl2.Controls.Add(this.txtPo_no);
            this.panelControl2.Controls.Add(this.lblPo_no);
            this.panelControl2.Controls.Add(this.txtCube_ctn);
            this.panelControl2.Controls.Add(this.lblCube_ctn);
            this.panelControl2.Controls.Add(this.txtBox_qty);
            this.panelControl2.Controls.Add(this.lblBox_qty);
            this.panelControl2.Controls.Add(this.txtTal_gw);
            this.panelControl2.Controls.Add(this.txtColor);
            this.panelControl2.Controls.Add(this.txtGoods_name);
            this.panelControl2.Controls.Add(this.txtGoods_ename);
            this.panelControl2.Controls.Add(this.lblColor);
            this.panelControl2.Controls.Add(this.lblGoods_name);
            this.panelControl2.Controls.Add(this.txtRemark_d);
            this.panelControl2.Controls.Add(this.lblGoods_ename);
            this.panelControl2.Controls.Add(this.txtSymbol);
            this.panelControl2.Controls.Add(this.lbRemark);
            this.panelControl2.Controls.Add(this.lblTal_gw);
            this.panelControl2.Controls.Add(this.lblSymbol);
            this.panelControl2.Controls.Add(this.txtTal_nw);
            this.panelControl2.Controls.Add(this.txtNw_each);
            this.panelControl2.Controls.Add(this.txtBox_no);
            this.panelControl2.Controls.Add(this.lblCarton_size);
            this.panelControl2.Controls.Add(this.lblTal_nw);
            this.panelControl2.Controls.Add(this.lblSec_unit);
            this.panelControl2.Controls.Add(this.lblNw_each);
            this.panelControl2.Controls.Add(this.labelControl8);
            this.panelControl2.Controls.Add(this.txtTotal_cube);
            this.panelControl2.Controls.Add(this.txtGw_each);
            this.panelControl2.Controls.Add(this.txtPbox_qty);
            this.panelControl2.Controls.Add(this.lblTotal_cube);
            this.panelControl2.Controls.Add(this.lblUnit_code);
            this.panelControl2.Controls.Add(this.lblGw_each);
            this.panelControl2.Controls.Add(this.lblPbox_qty);
            this.panelControl2.Controls.Add(this.txtPcs_qty);
            this.panelControl2.Controls.Add(this.lblTransfer_amount);
            this.panelControl2.Controls.Add(this.lblShowInfo);
            this.panelControl2.Controls.Add(this.chkSet);
            this.panelControl2.Controls.Add(this.txtBarCode);
            this.panelControl2.Controls.Add(this.lblBarCode);
            this.panelControl2.Controls.Add(this.lueGoods_id);
            this.panelControl2.Controls.Add(this.lblGoods_id);
            this.panelControl2.Controls.Add(this.txtSeq);
            this.panelControl2.Controls.Add(this.lblSeq);
            this.panelControl2.Controls.Add(this.txtMo_id);
            this.panelControl2.Controls.Add(this.lblMo_id);
            this.panelControl2.Controls.Add(this.lblRef_id);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 135);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(964, 218);
            this.panelControl2.TabIndex = 1;
            // 
            // cmbUnit_code
            // 
            this.cmbUnit_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit_code.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnit_code.FormattingEnabled = true;
            this.cmbUnit_code.Location = new System.Drawing.Point(257, 59);
            this.cmbUnit_code.MaxLength = 3;
            this.cmbUnit_code.Name = "cmbUnit_code";
            this.cmbUnit_code.Size = new System.Drawing.Size(114, 20);
            this.cmbUnit_code.TabIndex = 4;
            this.cmbUnit_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lueCarton_size
            // 
            this.lueCarton_size.Location = new System.Drawing.Point(826, 59);
            this.lueCarton_size.Name = "lueCarton_size";
            this.lueCarton_size.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCarton_size.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", 40, "描述")});
            this.lueCarton_size.Properties.ImmediatePopup = true;
            this.lueCarton_size.Properties.NullText = "";
            this.lueCarton_size.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lueCarton_size.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueCarton_size.Size = new System.Drawing.Size(133, 20);
            this.lueCarton_size.TabIndex = 7;
            this.lueCarton_size.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lueSec_unit
            // 
            this.lueSec_unit.Location = new System.Drawing.Point(75, 106);
            this.lueSec_unit.Name = "lueSec_unit";
            this.lueSec_unit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSec_unit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", 40, "描述")});
            this.lueSec_unit.Properties.NullText = "";
            this.lueSec_unit.Size = new System.Drawing.Size(114, 20);
            this.lueSec_unit.TabIndex = 13;
            this.lueSec_unit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtOrder_id
            // 
            this.txtOrder_id.Location = new System.Drawing.Point(257, 132);
            this.txtOrder_id.Name = "txtOrder_id";
            this.txtOrder_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrder_id.Properties.MaxLength = 9;
            this.txtOrder_id.Size = new System.Drawing.Size(114, 20);
            this.txtOrder_id.TabIndex = 19;
            this.txtOrder_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblOrder_id
            // 
            this.lblOrder_id.Location = new System.Drawing.Point(207, 135);
            this.lblOrder_id.Name = "lblOrder_id";
            this.lblOrder_id.Size = new System.Drawing.Size(44, 14);
            this.lblOrder_id.TabIndex = 49;
            this.lblOrder_id.Text = "OC編號:";
            // 
            // txtTr_id_weg
            // 
            this.txtTr_id_weg.Location = new System.Drawing.Point(638, 183);
            this.txtTr_id_weg.Name = "txtTr_id_weg";
            this.txtTr_id_weg.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTr_id_weg.Properties.MaxLength = 9;
            this.txtTr_id_weg.Size = new System.Drawing.Size(114, 20);
            this.txtTr_id_weg.TabIndex = 26;
            this.txtTr_id_weg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtTr_id_seq
            // 
            this.txtTr_id_seq.Location = new System.Drawing.Point(446, 183);
            this.txtTr_id_seq.Name = "txtTr_id_seq";
            this.txtTr_id_seq.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTr_id_seq.Properties.MaxLength = 9;
            this.txtTr_id_seq.Size = new System.Drawing.Size(114, 20);
            this.txtTr_id_seq.TabIndex = 25;
            this.txtTr_id_seq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblTr_id_weg
            // 
            this.lblTr_id_weg.Location = new System.Drawing.Point(567, 186);
            this.lblTr_id_weg.Name = "lblTr_id_weg";
            this.lblTr_id_weg.Size = new System.Drawing.Size(64, 14);
            this.lblTr_id_weg.TabIndex = 48;
            this.lblTr_id_weg.Text = "轉出單重量:";
            // 
            // lblTr_id_seq
            // 
            this.lblTr_id_seq.Location = new System.Drawing.Point(377, 186);
            this.lblTr_id_seq.Name = "lblTr_id_seq";
            this.lblTr_id_seq.Size = new System.Drawing.Size(64, 14);
            this.lblTr_id_seq.TabIndex = 48;
            this.lblTr_id_seq.Text = "轉出單序號:";
            // 
            // txtTr_id
            // 
            this.txtTr_id.Location = new System.Drawing.Point(257, 183);
            this.txtTr_id.Name = "txtTr_id";
            this.txtTr_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTr_id.Properties.MaxLength = 9;
            this.txtTr_id.Size = new System.Drawing.Size(114, 20);
            this.txtTr_id.TabIndex = 24;
            this.txtTr_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblTr_id
            // 
            this.lblTr_id.Location = new System.Drawing.Point(211, 186);
            this.lblTr_id.Name = "lblTr_id";
            this.lblTr_id.Size = new System.Drawing.Size(40, 14);
            this.lblTr_id.TabIndex = 48;
            this.lblTr_id.Text = "轉出單:";
            // 
            // txtRef_id
            // 
            this.txtRef_id.Location = new System.Drawing.Point(75, 183);
            this.txtRef_id.Name = "txtRef_id";
            this.txtRef_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRef_id.Properties.MaxLength = 9;
            this.txtRef_id.Size = new System.Drawing.Size(114, 20);
            this.txtRef_id.TabIndex = 23;
            this.txtRef_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtPo_no
            // 
            this.txtPo_no.Location = new System.Drawing.Point(75, 132);
            this.txtPo_no.Name = "txtPo_no";
            this.txtPo_no.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPo_no.Properties.MaxLength = 9;
            this.txtPo_no.Size = new System.Drawing.Size(114, 20);
            this.txtPo_no.TabIndex = 18;
            this.txtPo_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblPo_no
            // 
            this.lblPo_no.Location = new System.Drawing.Point(30, 135);
            this.lblPo_no.Name = "lblPo_no";
            this.lblPo_no.Size = new System.Drawing.Size(42, 14);
            this.lblPo_no.TabIndex = 48;
            this.lblPo_no.Text = "PO/NO:";
            // 
            // txtCube_ctn
            // 
            this.txtCube_ctn.Location = new System.Drawing.Point(257, 107);
            this.txtCube_ctn.Name = "txtCube_ctn";
            this.txtCube_ctn.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCube_ctn.Properties.MaxLength = 9;
            this.txtCube_ctn.Size = new System.Drawing.Size(114, 20);
            this.txtCube_ctn.TabIndex = 14;
            this.txtCube_ctn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblCube_ctn
            // 
            this.lblCube_ctn.Location = new System.Drawing.Point(206, 110);
            this.lblCube_ctn.Name = "lblCube_ctn";
            this.lblCube_ctn.Size = new System.Drawing.Size(45, 14);
            this.lblCube_ctn.TabIndex = 33;
            this.lblCube_ctn.Text = "體積/箱:";
            // 
            // txtBox_qty
            // 
            this.txtBox_qty.Location = new System.Drawing.Point(446, 59);
            this.txtBox_qty.Name = "txtBox_qty";
            this.txtBox_qty.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBox_qty.Properties.MaxLength = 9;
            this.txtBox_qty.Size = new System.Drawing.Size(114, 20);
            this.txtBox_qty.TabIndex = 5;
            this.txtBox_qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            this.txtBox_qty.Leave += new System.EventHandler(this.txtBox_qty_Leave);
            // 
            // lblBox_qty
            // 
            this.lblBox_qty.Location = new System.Drawing.Point(413, 63);
            this.lblBox_qty.Name = "lblBox_qty";
            this.lblBox_qty.Size = new System.Drawing.Size(28, 14);
            this.lblBox_qty.TabIndex = 33;
            this.lblBox_qty.Text = "箱數:";
            // 
            // txtTal_gw
            // 
            this.txtTal_gw.Location = new System.Drawing.Point(826, 83);
            this.txtTal_gw.Name = "txtTal_gw";
            this.txtTal_gw.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTal_gw.Properties.MaxLength = 9;
            this.txtTal_gw.Size = new System.Drawing.Size(133, 20);
            this.txtTal_gw.TabIndex = 12;
            this.txtTal_gw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(826, 107);
            this.txtColor.Name = "txtColor";
            this.txtColor.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColor.Properties.MaxLength = 9;
            this.txtColor.Size = new System.Drawing.Size(133, 20);
            this.txtColor.TabIndex = 17;
            this.txtColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtGoods_name
            // 
            this.txtGoods_name.Location = new System.Drawing.Point(75, 158);
            this.txtGoods_name.Name = "txtGoods_name";
            this.txtGoods_name.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGoods_name.Properties.MaxLength = 9;
            this.txtGoods_name.Size = new System.Drawing.Size(296, 20);
            this.txtGoods_name.TabIndex = 21;
            this.txtGoods_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtGoods_ename
            // 
            this.txtGoods_ename.Location = new System.Drawing.Point(446, 158);
            this.txtGoods_ename.Name = "txtGoods_ename";
            this.txtGoods_ename.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGoods_ename.Properties.MaxLength = 9;
            this.txtGoods_ename.Size = new System.Drawing.Size(306, 20);
            this.txtGoods_ename.TabIndex = 22;
            this.txtGoods_ename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblColor
            // 
            this.lblColor.Location = new System.Drawing.Point(791, 110);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(28, 14);
            this.lblColor.TabIndex = 34;
            this.lblColor.Text = "顏色:";
            // 
            // lblGoods_name
            // 
            this.lblGoods_name.Location = new System.Drawing.Point(20, 161);
            this.lblGoods_name.Name = "lblGoods_name";
            this.lblGoods_name.Size = new System.Drawing.Size(52, 14);
            this.lblGoods_name.TabIndex = 34;
            this.lblGoods_name.Text = "產品描述:";
            // 
            // txtRemark_d
            // 
            this.txtRemark_d.Location = new System.Drawing.Point(446, 132);
            this.txtRemark_d.Name = "txtRemark_d";
            this.txtRemark_d.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemark_d.Properties.MaxLength = 9;
            this.txtRemark_d.Size = new System.Drawing.Size(306, 20);
            this.txtRemark_d.TabIndex = 20;
            this.txtRemark_d.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblGoods_ename
            // 
            this.lblGoods_ename.Location = new System.Drawing.Point(389, 161);
            this.lblGoods_ename.Name = "lblGoods_ename";
            this.lblGoods_ename.Size = new System.Drawing.Size(52, 14);
            this.lblGoods_ename.TabIndex = 34;
            this.lblGoods_ename.Text = "英文描述:";
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(638, 107);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSymbol.Properties.MaxLength = 9;
            this.txtSymbol.Size = new System.Drawing.Size(114, 20);
            this.txtSymbol.TabIndex = 16;
            this.txtSymbol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lbRemark
            // 
            this.lbRemark.Location = new System.Drawing.Point(413, 135);
            this.lbRemark.Name = "lbRemark";
            this.lbRemark.Size = new System.Drawing.Size(28, 14);
            this.lbRemark.TabIndex = 34;
            this.lbRemark.Text = "備註:";
            // 
            // lblTal_gw
            // 
            this.lblTal_gw.Location = new System.Drawing.Point(779, 86);
            this.lblTal_gw.Name = "lblTal_gw";
            this.lblTal_gw.Size = new System.Drawing.Size(40, 14);
            this.lblTal_gw.TabIndex = 31;
            this.lblTal_gw.Text = "總毛重:";
            // 
            // lblSymbol
            // 
            this.lblSymbol.Location = new System.Drawing.Point(603, 110);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(28, 14);
            this.lblSymbol.TabIndex = 27;
            this.lblSymbol.Text = "符號:";
            // 
            // txtTal_nw
            // 
            this.txtTal_nw.Location = new System.Drawing.Point(638, 83);
            this.txtTal_nw.Name = "txtTal_nw";
            this.txtTal_nw.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTal_nw.Properties.MaxLength = 9;
            this.txtTal_nw.Size = new System.Drawing.Size(114, 20);
            this.txtTal_nw.TabIndex = 11;
            this.txtTal_nw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtNw_each
            // 
            this.txtNw_each.Location = new System.Drawing.Point(75, 83);
            this.txtNw_each.Name = "txtNw_each";
            this.txtNw_each.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNw_each.Properties.MaxLength = 9;
            this.txtNw_each.Size = new System.Drawing.Size(114, 20);
            this.txtNw_each.TabIndex = 8;
            this.txtNw_each.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            this.txtNw_each.Leave += new System.EventHandler(this.txtNw_each_Leave);
            // 
            // txtBox_no
            // 
            this.txtBox_no.Location = new System.Drawing.Point(446, 83);
            this.txtBox_no.Name = "txtBox_no";
            this.txtBox_no.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBox_no.Properties.MaxLength = 9;
            this.txtBox_no.Size = new System.Drawing.Size(114, 20);
            this.txtBox_no.TabIndex = 10;
            this.txtBox_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblCarton_size
            // 
            this.lblCarton_size.Location = new System.Drawing.Point(767, 62);
            this.lblCarton_size.Name = "lblCarton_size";
            this.lblCarton_size.Size = new System.Drawing.Size(52, 14);
            this.lblCarton_size.TabIndex = 30;
            this.lblCarton_size.Text = "紙箱尺寸:";
            // 
            // lblTal_nw
            // 
            this.lblTal_nw.Location = new System.Drawing.Point(591, 86);
            this.lblTal_nw.Name = "lblTal_nw";
            this.lblTal_nw.Size = new System.Drawing.Size(40, 14);
            this.lblTal_nw.TabIndex = 29;
            this.lblTal_nw.Text = "總凈重:";
            // 
            // lblSec_unit
            // 
            this.lblSec_unit.Location = new System.Drawing.Point(20, 109);
            this.lblSec_unit.Name = "lblSec_unit";
            this.lblSec_unit.Size = new System.Drawing.Size(52, 14);
            this.lblSec_unit.TabIndex = 30;
            this.lblSec_unit.Text = "重量單位:";
            // 
            // lblNw_each
            // 
            this.lblNw_each.Location = new System.Drawing.Point(27, 86);
            this.lblNw_each.Name = "lblNw_each";
            this.lblNw_each.Size = new System.Drawing.Size(45, 14);
            this.lblNw_each.TabIndex = 29;
            this.lblNw_each.Text = "凈重/箱:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(413, 86);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(28, 14);
            this.labelControl8.TabIndex = 28;
            this.labelControl8.Text = "箱號:";
            // 
            // txtTotal_cube
            // 
            this.txtTotal_cube.Location = new System.Drawing.Point(446, 107);
            this.txtTotal_cube.Name = "txtTotal_cube";
            this.txtTotal_cube.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal_cube.Properties.MaxLength = 9;
            this.txtTotal_cube.Size = new System.Drawing.Size(114, 20);
            this.txtTotal_cube.TabIndex = 15;
            this.txtTotal_cube.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtGw_each
            // 
            this.txtGw_each.Location = new System.Drawing.Point(257, 83);
            this.txtGw_each.Name = "txtGw_each";
            this.txtGw_each.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGw_each.Properties.MaxLength = 9;
            this.txtGw_each.Size = new System.Drawing.Size(114, 20);
            this.txtGw_each.TabIndex = 9;
            this.txtGw_each.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            this.txtGw_each.Leave += new System.EventHandler(this.txtGw_each_Leave);
            // 
            // txtPbox_qty
            // 
            this.txtPbox_qty.Location = new System.Drawing.Point(638, 59);
            this.txtPbox_qty.Name = "txtPbox_qty";
            this.txtPbox_qty.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPbox_qty.Properties.MaxLength = 9;
            this.txtPbox_qty.Size = new System.Drawing.Size(114, 20);
            this.txtPbox_qty.TabIndex = 6;
            this.txtPbox_qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblTotal_cube
            // 
            this.lblTotal_cube.Location = new System.Drawing.Point(401, 110);
            this.lblTotal_cube.Name = "lblTotal_cube";
            this.lblTotal_cube.Size = new System.Drawing.Size(40, 14);
            this.lblTotal_cube.TabIndex = 26;
            this.lblTotal_cube.Text = "總體積:";
            // 
            // lblUnit_code
            // 
            this.lblUnit_code.Location = new System.Drawing.Point(199, 62);
            this.lblUnit_code.Name = "lblUnit_code";
            this.lblUnit_code.Size = new System.Drawing.Size(52, 14);
            this.lblUnit_code.TabIndex = 25;
            this.lblUnit_code.Text = "數量單位:";
            // 
            // lblGw_each
            // 
            this.lblGw_each.Location = new System.Drawing.Point(206, 86);
            this.lblGw_each.Name = "lblGw_each";
            this.lblGw_each.Size = new System.Drawing.Size(45, 14);
            this.lblGw_each.TabIndex = 26;
            this.lblGw_each.Text = "毛重/箱:";
            // 
            // lblPbox_qty
            // 
            this.lblPbox_qty.Location = new System.Drawing.Point(586, 62);
            this.lblPbox_qty.Name = "lblPbox_qty";
            this.lblPbox_qty.Size = new System.Drawing.Size(45, 14);
            this.lblPbox_qty.TabIndex = 35;
            this.lblPbox_qty.Text = "數量/箱:";
            // 
            // txtPcs_qty
            // 
            this.txtPcs_qty.Location = new System.Drawing.Point(75, 59);
            this.txtPcs_qty.Name = "txtPcs_qty";
            this.txtPcs_qty.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPcs_qty.Properties.MaxLength = 9;
            this.txtPcs_qty.Size = new System.Drawing.Size(114, 20);
            this.txtPcs_qty.TabIndex = 3;
            this.txtPcs_qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            this.txtPcs_qty.Leave += new System.EventHandler(this.txtPcs_qty_Leave);
            // 
            // lblTransfer_amount
            // 
            this.lblTransfer_amount.Location = new System.Drawing.Point(44, 62);
            this.lblTransfer_amount.Name = "lblTransfer_amount";
            this.lblTransfer_amount.Size = new System.Drawing.Size(28, 14);
            this.lblTransfer_amount.TabIndex = 32;
            this.lblTransfer_amount.Text = "數量:";
            // 
            // lblShowInfo
            // 
            this.lblShowInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblShowInfo.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblShowInfo.Location = new System.Drawing.Point(611, 5);
            this.lblShowInfo.Name = "lblShowInfo";
            this.lblShowInfo.Size = new System.Drawing.Size(64, 19);
            this.lblShowInfo.TabIndex = 24;
            this.lblShowInfo.Text = "編輯狀態";
            // 
            // chkSet
            // 
            this.chkSet.EditValue = true;
            this.chkSet.Location = new System.Drawing.Point(430, 35);
            this.chkSet.Name = "chkSet";
            this.chkSet.Properties.Caption = "整套";
            this.chkSet.Size = new System.Drawing.Size(75, 19);
            this.chkSet.TabIndex = 28;
            this.chkSet.TabStop = false;
            this.chkSet.Click += new System.EventHandler(this.chkSet_Click);
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(75, 10);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Properties.Appearance.BackColor = System.Drawing.Color.SandyBrown;
            this.txtBarCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtBarCode.Size = new System.Drawing.Size(353, 20);
            this.txtBarCode.TabIndex = 0;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // lblBarCode
            // 
            this.lblBarCode.Location = new System.Drawing.Point(32, 13);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(40, 14);
            this.lblBarCode.TabIndex = 18;
            this.lblBarCode.Text = "條形碼:";
            // 
            // lueGoods_id
            // 
            this.lueGoods_id.Location = new System.Drawing.Point(257, 35);
            this.lueGoods_id.Name = "lueGoods_id";
            this.lueGoods_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoods_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("goods_id", 200, "產品編號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("goods_name", 300, "產品描述")});
            this.lueGoods_id.Properties.NullText = "";
            this.lueGoods_id.Properties.PopupWidth = 300;
            this.lueGoods_id.Size = new System.Drawing.Size(172, 20);
            this.lueGoods_id.TabIndex = 2;
            this.lueGoods_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            this.lueGoods_id.Leave += new System.EventHandler(this.lueGoods_id_Leave);
            // 
            // lblGoods_id
            // 
            this.lblGoods_id.Location = new System.Drawing.Point(199, 38);
            this.lblGoods_id.Name = "lblGoods_id";
            this.lblGoods_id.Size = new System.Drawing.Size(52, 14);
            this.lblGoods_id.TabIndex = 17;
            this.lblGoods_id.Text = "產品編號:";
            // 
            // txtSeq
            // 
            this.txtSeq.Location = new System.Drawing.Point(638, 35);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSeq.Properties.MaxLength = 9;
            this.txtSeq.Size = new System.Drawing.Size(114, 20);
            this.txtSeq.TabIndex = 27;
            this.txtSeq.TabStop = false;
            this.txtSeq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblSeq
            // 
            this.lblSeq.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblSeq.Location = new System.Drawing.Point(603, 38);
            this.lblSeq.Name = "lblSeq";
            this.lblSeq.Size = new System.Drawing.Size(28, 14);
            this.lblSeq.TabIndex = 16;
            this.lblSeq.Text = "序號:";
            // 
            // txtMo_id
            // 
            this.txtMo_id.Location = new System.Drawing.Point(75, 35);
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id.Properties.MaxLength = 9;
            this.txtMo_id.Size = new System.Drawing.Size(114, 20);
            this.txtMo_id.TabIndex = 1;
            this.txtMo_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            this.txtMo_id.Leave += new System.EventHandler(this.txtMo_id_Leave);
            // 
            // lblMo_id
            // 
            this.lblMo_id.Location = new System.Drawing.Point(20, 38);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(52, 14);
            this.lblMo_id.TabIndex = 20;
            this.lblMo_id.Text = "制單編號:";
            // 
            // lblRef_id
            // 
            this.lblRef_id.Location = new System.Drawing.Point(20, 186);
            this.lblRef_id.Name = "lblRef_id";
            this.lblRef_id.Size = new System.Drawing.Size(52, 14);
            this.lblRef_id.TabIndex = 48;
            this.lblRef_id.Text = "參考單號:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkAftSavePrint);
            this.panelControl1.Controls.Add(this.rdbAftSave);
            this.panelControl1.Controls.Add(this.lueOrigin_id);
            this.panelControl1.Controls.Add(this.lueType);
            this.panelControl1.Controls.Add(this.lblTypeNo);
            this.panelControl1.Controls.Add(this.lblUpdate_Date);
            this.panelControl1.Controls.Add(this.lblCreate_Date);
            this.panelControl1.Controls.Add(this.lblUpdate_By);
            this.panelControl1.Controls.Add(this.lblRemark);
            this.panelControl1.Controls.Add(this.lblCreate_By);
            this.panelControl1.Controls.Add(this.txtUpdate_Date);
            this.panelControl1.Controls.Add(this.txtCreate_Date);
            this.panelControl1.Controls.Add(this.txtUpdate_By);
            this.panelControl1.Controls.Add(this.txtRemark);
            this.panelControl1.Controls.Add(this.txtCreate_By);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.txtSailing_date);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.txtFax);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.txtPhone);
            this.panelControl1.Controls.Add(this.lblCustomer);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.txtCustomer);
            this.panelControl1.Controls.Add(this.txtLinkman);
            this.panelControl1.Controls.Add(this.lblDestination);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtDestination);
            this.panelControl1.Controls.Add(this.txtShipping_tool);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtCustomer_id);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lblState);
            this.panelControl1.Controls.Add(this.txtState);
            this.panelControl1.Controls.Add(this.lblTransfer_Date);
            this.panelControl1.Controls.Add(this.lblId);
            this.panelControl1.Controls.Add(this.txtPacking_date);
            this.panelControl1.Controls.Add(this.txtId);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(964, 135);
            this.panelControl1.TabIndex = 0;
            // 
            // chkAftSavePrint
            // 
            this.chkAftSavePrint.Location = new System.Drawing.Point(767, 94);
            this.chkAftSavePrint.Name = "chkAftSavePrint";
            this.chkAftSavePrint.Properties.AutoWidth = true;
            this.chkAftSavePrint.Properties.Caption = "新單儲存後列印";
            this.chkAftSavePrint.Size = new System.Drawing.Size(107, 19);
            this.chkAftSavePrint.TabIndex = 36;
            // 
            // rdbAftSave
            // 
            this.rdbAftSave.Location = new System.Drawing.Point(767, 6);
            this.rdbAftSave.Name = "rdbAftSave";
            this.rdbAftSave.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "儲存後自動建立新單"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "儲存後自動建立新記錄"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "無操作")});
            this.rdbAftSave.Size = new System.Drawing.Size(190, 75);
            this.rdbAftSave.TabIndex = 16;
            // 
            // lueOrigin_id
            // 
            this.lueOrigin_id.Location = new System.Drawing.Point(638, 5);
            this.lueOrigin_id.Name = "lueOrigin_id";
            this.lueOrigin_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOrigin_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", 40, "描述")});
            this.lueOrigin_id.Properties.NullText = "";
            this.lueOrigin_id.Properties.ShowHeader = false;
            this.lueOrigin_id.Size = new System.Drawing.Size(114, 20);
            this.lueOrigin_id.TabIndex = 3;
            this.lueOrigin_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            this.lueOrigin_id.Leave += new System.EventHandler(this.txtMo_id_Leave);
            // 
            // lueType
            // 
            this.lueType.Location = new System.Drawing.Point(257, 5);
            this.lueType.Name = "lueType";
            this.lueType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "單據類型"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", 40, "描述")});
            this.lueType.Properties.NullText = "";
            this.lueType.Size = new System.Drawing.Size(114, 20);
            this.lueType.TabIndex = 1;
            this.lueType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblTypeNo
            // 
            this.lblTypeNo.Location = new System.Drawing.Point(199, 8);
            this.lblTypeNo.Name = "lblTypeNo";
            this.lblTypeNo.Size = new System.Drawing.Size(52, 14);
            this.lblTypeNo.TabIndex = 35;
            this.lblTypeNo.Text = "單據類型:";
            // 
            // lblUpdate_Date
            // 
            this.lblUpdate_Date.Location = new System.Drawing.Point(579, 106);
            this.lblUpdate_Date.Name = "lblUpdate_Date";
            this.lblUpdate_Date.Size = new System.Drawing.Size(52, 14);
            this.lblUpdate_Date.TabIndex = 28;
            this.lblUpdate_Date.Text = "修改日期:";
            // 
            // lblCreate_Date
            // 
            this.lblCreate_Date.Location = new System.Drawing.Point(199, 106);
            this.lblCreate_Date.Name = "lblCreate_Date";
            this.lblCreate_Date.Size = new System.Drawing.Size(52, 14);
            this.lblCreate_Date.TabIndex = 29;
            this.lblCreate_Date.Text = "建檔日期:";
            // 
            // lblUpdate_By
            // 
            this.lblUpdate_By.Location = new System.Drawing.Point(401, 106);
            this.lblUpdate_By.Name = "lblUpdate_By";
            this.lblUpdate_By.Size = new System.Drawing.Size(40, 14);
            this.lblUpdate_By.TabIndex = 27;
            this.lblUpdate_By.Text = "修改人:";
            // 
            // lblRemark
            // 
            this.lblRemark.Location = new System.Drawing.Point(44, 81);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(28, 14);
            this.lblRemark.TabIndex = 25;
            this.lblRemark.Text = "備註:";
            // 
            // lblCreate_By
            // 
            this.lblCreate_By.Location = new System.Drawing.Point(32, 106);
            this.lblCreate_By.Name = "lblCreate_By";
            this.lblCreate_By.Size = new System.Drawing.Size(40, 14);
            this.lblCreate_By.TabIndex = 26;
            this.lblCreate_By.Text = "建檔人:";
            // 
            // txtUpdate_Date
            // 
            this.txtUpdate_Date.Location = new System.Drawing.Point(638, 103);
            this.txtUpdate_Date.Name = "txtUpdate_Date";
            this.txtUpdate_Date.Properties.ReadOnly = true;
            this.txtUpdate_Date.Size = new System.Drawing.Size(114, 20);
            this.txtUpdate_Date.TabIndex = 17;
            this.txtUpdate_Date.TabStop = false;
            this.txtUpdate_Date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtCreate_Date
            // 
            this.txtCreate_Date.Location = new System.Drawing.Point(257, 103);
            this.txtCreate_Date.Name = "txtCreate_Date";
            this.txtCreate_Date.Properties.ReadOnly = true;
            this.txtCreate_Date.Size = new System.Drawing.Size(114, 20);
            this.txtCreate_Date.TabIndex = 15;
            this.txtCreate_Date.TabStop = false;
            this.txtCreate_Date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtUpdate_By
            // 
            this.txtUpdate_By.Location = new System.Drawing.Point(446, 103);
            this.txtUpdate_By.Name = "txtUpdate_By";
            this.txtUpdate_By.Properties.ReadOnly = true;
            this.txtUpdate_By.Size = new System.Drawing.Size(114, 20);
            this.txtUpdate_By.TabIndex = 16;
            this.txtUpdate_By.TabStop = false;
            this.txtUpdate_By.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(78, 78);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(482, 20);
            this.txtRemark.TabIndex = 12;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtCreate_By
            // 
            this.txtCreate_By.Location = new System.Drawing.Point(78, 103);
            this.txtCreate_By.Name = "txtCreate_By";
            this.txtCreate_By.Properties.ReadOnly = true;
            this.txtCreate_By.Size = new System.Drawing.Size(114, 20);
            this.txtCreate_By.TabIndex = 14;
            this.txtCreate_By.TabStop = false;
            this.txtCreate_By.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(199, 55);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 14);
            this.labelControl7.TabIndex = 23;
            this.labelControl7.Text = "出口日期:";
            // 
            // txtSailing_date
            // 
            this.txtSailing_date.Location = new System.Drawing.Point(257, 53);
            this.txtSailing_date.Name = "txtSailing_date";
            this.txtSailing_date.Properties.Mask.EditMask = "9999/99/99";
            this.txtSailing_date.Properties.MaxLength = 10;
            this.txtSailing_date.Size = new System.Drawing.Size(114, 20);
            this.txtSailing_date.TabIndex = 9;
            this.txtSailing_date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(44, 55);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(28, 14);
            this.labelControl6.TabIndex = 21;
            this.labelControl6.Text = "傳真:";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(78, 53);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(114, 20);
            this.txtFax.TabIndex = 8;
            this.txtFax.TabStop = false;
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(603, 32);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 14);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "電話:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(638, 29);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(114, 20);
            this.txtPhone.TabIndex = 7;
            this.txtPhone.TabStop = false;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(199, 32);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(52, 14);
            this.lblCustomer.TabIndex = 17;
            this.lblCustomer.Text = "客人描述:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(401, 32);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 14);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "聯繫人:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(257, 29);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(114, 20);
            this.txtCustomer.TabIndex = 5;
            this.txtCustomer.TabStop = false;
            this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtLinkman
            // 
            this.txtLinkman.Location = new System.Drawing.Point(446, 29);
            this.txtLinkman.Name = "txtLinkman";
            this.txtLinkman.Size = new System.Drawing.Size(114, 20);
            this.txtLinkman.TabIndex = 6;
            this.txtLinkman.TabStop = false;
            this.txtLinkman.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblDestination
            // 
            this.lblDestination.Location = new System.Drawing.Point(591, 55);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(40, 14);
            this.lblDestination.TabIndex = 15;
            this.lblDestination.Text = "目的地:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(389, 55);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "運輸工具:";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(638, 52);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(114, 20);
            this.txtDestination.TabIndex = 11;
            this.txtDestination.TabStop = false;
            this.txtDestination.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtShipping_tool
            // 
            this.txtShipping_tool.Location = new System.Drawing.Point(446, 53);
            this.txtShipping_tool.Name = "txtShipping_tool";
            this.txtShipping_tool.Size = new System.Drawing.Size(114, 20);
            this.txtShipping_tool.TabIndex = 10;
            this.txtShipping_tool.TabStop = false;
            this.txtShipping_tool.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 32);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "客人編號:";
            // 
            // txtCustomer_id
            // 
            this.txtCustomer_id.Location = new System.Drawing.Point(78, 29);
            this.txtCustomer_id.Name = "txtCustomer_id";
            this.txtCustomer_id.Size = new System.Drawing.Size(114, 20);
            this.txtCustomer_id.TabIndex = 4;
            this.txtCustomer_id.TabStop = false;
            this.txtCustomer_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            this.txtCustomer_id.Leave += new System.EventHandler(this.txtCustomer_id_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(579, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "訂單來源:";
            // 
            // lblState
            // 
            this.lblState.Location = new System.Drawing.Point(579, 81);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(52, 14);
            this.lblState.TabIndex = 9;
            this.lblState.Text = "單據狀態:";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(638, 78);
            this.txtState.Name = "txtState";
            this.txtState.Properties.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(114, 20);
            this.txtState.TabIndex = 13;
            this.txtState.TabStop = false;
            this.txtState.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // lblTransfer_Date
            // 
            this.lblTransfer_Date.Location = new System.Drawing.Point(389, 8);
            this.lblTransfer_Date.Name = "lblTransfer_Date";
            this.lblTransfer_Date.Size = new System.Drawing.Size(52, 14);
            this.lblTransfer_Date.TabIndex = 3;
            this.lblTransfer_Date.Text = "裝箱日期:";
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(20, 8);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(52, 14);
            this.lblId.TabIndex = 5;
            this.lblId.Text = "單據編號:";
            // 
            // txtPacking_date
            // 
            this.txtPacking_date.Location = new System.Drawing.Point(446, 5);
            this.txtPacking_date.Name = "txtPacking_date";
            this.txtPacking_date.Properties.Mask.EditMask = "9999/99/99";
            this.txtPacking_date.Properties.MaxLength = 10;
            this.txtPacking_date.Size = new System.Drawing.Size(114, 20);
            this.txtPacking_date.TabIndex = 2;
            this.txtPacking_date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(78, 5);
            this.txtId.Name = "txtId";
            this.txtId.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId.Properties.MaxLength = 13;
            this.txtId.Size = new System.Drawing.Size(114, 20);
            this.txtId.TabIndex = 0;
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            this.txtId.Leave += new System.EventHandler(this.txtId_Leave);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.labelControl9);
            this.xtraTabPage2.Controls.Add(this.txtDate2);
            this.xtraTabPage2.Controls.Add(this.txtDate1);
            this.xtraTabPage2.Controls.Add(this.btnPrint1);
            this.xtraTabPage2.Controls.Add(this.txtPid2);
            this.xtraTabPage2.Controls.Add(this.txtPid1);
            this.xtraTabPage2.Controls.Add(this.lblPid);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(964, 538);
            this.xtraTabPage2.Text = "數據瀏覽";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(37, 55);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(52, 14);
            this.labelControl9.TabIndex = 5;
            this.labelControl9.Text = "裝箱日期:";
            // 
            // txtDate2
            // 
            this.txtDate2.Location = new System.Drawing.Point(269, 52);
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.Properties.Mask.EditMask = "9999/99/99";
            this.txtDate2.Properties.MaxLength = 10;
            this.txtDate2.Size = new System.Drawing.Size(159, 20);
            this.txtDate2.TabIndex = 4;
            this.txtDate2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtDate1
            // 
            this.txtDate1.Location = new System.Drawing.Point(94, 52);
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.Properties.Mask.EditMask = "9999/99/99";
            this.txtDate1.Properties.MaxLength = 10;
            this.txtDate1.Size = new System.Drawing.Size(159, 20);
            this.txtDate1.TabIndex = 3;
            this.txtDate1.EditValueChanged += new System.EventHandler(this.txtDate1_EditValueChanged);
            this.txtDate1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // btnPrint1
            // 
            this.btnPrint1.Location = new System.Drawing.Point(434, 23);
            this.btnPrint1.Name = "btnPrint1";
            this.btnPrint1.Size = new System.Drawing.Size(75, 23);
            this.btnPrint1.TabIndex = 5;
            this.btnPrint1.Text = "列印";
            this.btnPrint1.Click += new System.EventHandler(this.btnPrint1_Click);
            // 
            // txtPid2
            // 
            this.txtPid2.Location = new System.Drawing.Point(269, 26);
            this.txtPid2.Name = "txtPid2";
            this.txtPid2.Size = new System.Drawing.Size(159, 20);
            this.txtPid2.TabIndex = 2;
            this.txtPid2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            // 
            // txtPid1
            // 
            this.txtPid1.Location = new System.Drawing.Point(94, 26);
            this.txtPid1.Name = "txtPid1";
            this.txtPid1.Size = new System.Drawing.Size(159, 20);
            this.txtPid1.TabIndex = 1;
            this.txtPid1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            this.txtPid1.Leave += new System.EventHandler(this.txtPid1_Leave);
            // 
            // lblPid
            // 
            this.lblPid.Location = new System.Drawing.Point(35, 29);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(52, 14);
            this.lblPid.TabIndex = 0;
            this.lblPid.Text = "單據編號:";
            // 
            // frmPackingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 602);
            this.Controls.Add(this.xtbControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmPackingList";
            this.Text = "frmPackingList";
            this.Load += new System.EventHandler(this.frmPackingList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtbControl1)).EndInit();
            this.xtbControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkPrint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCarton_size.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSec_unit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrder_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTr_id_weg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTr_id_seq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTr_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRef_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPo_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCube_ctn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBox_qty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTal_gw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_ename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark_d.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSymbol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTal_nw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNw_each.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBox_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal_cube.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGw_each.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPbox_qty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPcs_qty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoods_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAftSavePrint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbAftSave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOrigin_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdate_Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdate_By.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_By.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSailing_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkman.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipping_tool.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPacking_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPid2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPid1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevExpress.XtraTab.XtraTabControl xtbControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblTransfer_Date;
        private DevExpress.XtraEditors.LabelControl lblId;
        private DevExpress.XtraEditors.TextEdit txtPacking_date;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblState;
        private DevExpress.XtraEditors.TextEdit txtState;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtShipping_tool;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCustomer_id;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtFax;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtLinkman;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtSailing_date;
        private DevExpress.XtraEditors.LabelControl lblUpdate_Date;
        private DevExpress.XtraEditors.LabelControl lblCreate_Date;
        private DevExpress.XtraEditors.LabelControl lblUpdate_By;
        private DevExpress.XtraEditors.LabelControl lblRemark;
        private DevExpress.XtraEditors.LabelControl lblCreate_By;
        private DevExpress.XtraEditors.TextEdit txtUpdate_Date;
        private DevExpress.XtraEditors.TextEdit txtCreate_Date;
        private DevExpress.XtraEditors.TextEdit txtUpdate_By;
        private DevExpress.XtraEditors.TextEdit txtRemark;
        private DevExpress.XtraEditors.TextEdit txtCreate_By;
        private DevExpress.XtraEditors.LookUpEdit lueType;
        private DevExpress.XtraEditors.LabelControl lblTypeNo;
        private DevExpress.XtraEditors.LookUpEdit lueOrigin_id;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lblShowInfo;
        private DevExpress.XtraEditors.CheckEdit chkSet;
        private DevExpress.XtraEditors.TextEdit txtBarCode;
        private DevExpress.XtraEditors.LabelControl lblBarCode;
        private DevExpress.XtraEditors.LookUpEdit lueGoods_id;
        private DevExpress.XtraEditors.LabelControl lblGoods_id;
        private DevExpress.XtraEditors.TextEdit txtSeq;
        private DevExpress.XtraEditors.LabelControl lblSeq;
        private DevExpress.XtraEditors.TextEdit txtMo_id;
        private DevExpress.XtraEditors.LabelControl lblMo_id;
        private DevExpress.XtraEditors.TextEdit txtBox_qty;
        private DevExpress.XtraEditors.LabelControl lblBox_qty;
        private DevExpress.XtraEditors.TextEdit txtTal_gw;
        private DevExpress.XtraEditors.TextEdit txtRemark_d;
        private DevExpress.XtraEditors.TextEdit txtSymbol;
        private DevExpress.XtraEditors.LabelControl lbRemark;
        private DevExpress.XtraEditors.LabelControl lblTal_gw;
        private DevExpress.XtraEditors.LabelControl lblSymbol;
        private DevExpress.XtraEditors.TextEdit txtNw_each;
        private DevExpress.XtraEditors.TextEdit txtBox_no;
        private DevExpress.XtraEditors.LabelControl lblSec_unit;
        private DevExpress.XtraEditors.LabelControl lblNw_each;
        private DevExpress.XtraEditors.TextEdit txtGw_each;
        private DevExpress.XtraEditors.TextEdit txtPbox_qty;
        private DevExpress.XtraEditors.LabelControl lblUnit_code;
        private DevExpress.XtraEditors.LabelControl lblGw_each;
        private DevExpress.XtraEditors.LabelControl lblPbox_qty;
        private DevExpress.XtraEditors.TextEdit txtPcs_qty;
        private DevExpress.XtraEditors.LabelControl lblTransfer_amount;
        private DevExpress.XtraEditors.TextEdit txtOrder_id;
        private DevExpress.XtraEditors.LabelControl lblOrder_id;
        private DevExpress.XtraEditors.TextEdit txtPo_no;
        private DevExpress.XtraEditors.LabelControl lblPo_no;
        private DevExpress.XtraEditors.TextEdit txtGoods_ename;
        private DevExpress.XtraEditors.LabelControl lblGoods_ename;
        private DevExpress.XtraEditors.TextEdit txtRef_id;
        private DevExpress.XtraEditors.LabelControl lblRef_id;
        private DevExpress.XtraEditors.TextEdit txtTotal_cube;
        private DevExpress.XtraEditors.LabelControl lblTotal_cube;
        private DevExpress.XtraEditors.LookUpEdit lueSec_unit;
        private DevExpress.XtraEditors.TextEdit txtCube_ctn;
        private DevExpress.XtraEditors.LabelControl lblCube_ctn;
        private DevExpress.XtraEditors.TextEdit txtTal_nw;
        private DevExpress.XtraEditors.LabelControl lblTal_nw;
        private DevExpress.XtraEditors.TextEdit txtTr_id;
        private DevExpress.XtraEditors.LabelControl lblTr_id;
        private DevExpress.XtraEditors.TextEdit txtColor;
        private DevExpress.XtraEditors.LabelControl lblColor;
        private DevExpress.XtraEditors.LabelControl lblCarton_size;
        private System.Windows.Forms.ToolStripButton btnNewRec;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private DevExpress.XtraEditors.TextEdit txtGoods_name;
        private DevExpress.XtraEditors.LabelControl lblGoods_name;
        private DevExpress.XtraEditors.TextEdit txtTr_id_weg;
        private DevExpress.XtraEditors.TextEdit txtTr_id_seq;
        private DevExpress.XtraEditors.LabelControl lblTr_id_weg;
        private DevExpress.XtraEditors.LabelControl lblTr_id_seq;
        private DevExpress.XtraEditors.RadioGroup rdbAftSave;
        private DevExpress.XtraGrid.GridControl gcDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colSequence_id;
        private DevExpress.XtraGrid.Columns.GridColumn colMo_id;
        private DevExpress.XtraGrid.Columns.GridColumn colGoods_id;
        private DevExpress.XtraGrid.Columns.GridColumn colGoods_name;
        private DevExpress.XtraGrid.Columns.GridColumn colSet;
        private DevExpress.XtraGrid.GridControl gcHead;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHead;
        private DevExpress.XtraGrid.Columns.GridColumn colId_h;
        private DevExpress.XtraGrid.Columns.GridColumn colPack_date;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer_id;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.ToolStripButton btnDelRec;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private DevExpress.XtraEditors.LabelControl lblDestination;
        private DevExpress.XtraEditors.TextEdit txtDestination;
        private DevExpress.XtraEditors.CheckEdit chkAftSavePrint;
        private System.Windows.Forms.ComboBox cmbUnit_code;
        private DevExpress.XtraGrid.Columns.GridColumn colSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.CheckEdit chkPrint;
        private System.Windows.Forms.ToolStripButton btnBatchPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private DevExpress.XtraGrid.Columns.GridColumn colPcs_qty;
        private DevExpress.XtraGrid.Columns.GridColumn colNw_each;
        private DevExpress.XtraGrid.Columns.GridColumn colGw_each;
        private DevExpress.XtraGrid.Columns.GridColumn colTal_nw;
        private DevExpress.XtraGrid.Columns.GridColumn colTal_gw;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colBox_no;
        private DevExpress.XtraEditors.LookUpEdit lueCarton_size;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btnPrint1;
        private DevExpress.XtraEditors.TextEdit txtPid2;
        private DevExpress.XtraEditors.TextEdit txtPid1;
        private DevExpress.XtraEditors.LabelControl lblPid;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtDate1;
        private DevExpress.XtraEditors.TextEdit txtDate2;
        private DevExpress.XtraEditors.LabelControl lblCustomer;
        private DevExpress.XtraEditors.TextEdit txtCustomer;
    }
}