namespace cf01.Forms
{
    partial class frmZipperOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZipperOrder));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConf = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTran = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdateMo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.xtbControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtbPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblMoGroup = new DevExpress.XtraEditors.LabelControl();
            this.txtCust_name = new DevExpress.XtraEditors.TextEdit();
            this.lblCust_name = new DevExpress.XtraEditors.LabelControl();
            this.txtCrtim = new DevExpress.XtraEditors.TextEdit();
            this.lblCrtim = new DevExpress.XtraEditors.LabelControl();
            this.txtCrusr = new DevExpress.XtraEditors.TextEdit();
            this.lblCrusr = new DevExpress.XtraEditors.LabelControl();
            this.txtCust_po = new DevExpress.XtraEditors.TextEdit();
            this.lblCust_po = new DevExpress.XtraEditors.LabelControl();
            this.txtIt_customer = new DevExpress.XtraEditors.TextEdit();
            this.lblIt_customer = new DevExpress.XtraEditors.LabelControl();
            this.txtOrder_date = new DevExpress.XtraEditors.TextEdit();
            this.lblOrder_date = new DevExpress.XtraEditors.LabelControl();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.lblId = new DevExpress.XtraEditors.LabelControl();
            this.lueMoGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.xtbPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcDetails = new DevExpress.XtraGrid.GridControl();
            this.dgvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cloMat_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrder_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoods_unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpec_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpec_oth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColor_c = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColor_y = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColor_oth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManu_craft_group = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManu_craft_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManu_craft_cdesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrd_process_group = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrd_process_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrd_process_cdesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZipper_head = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZipper_head_oth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCrusr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCrtim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.palAll2 = new DevExpress.XtraEditors.PanelControl();
            this.btnShowTest = new DevExpress.XtraEditors.SimpleButton();
            this.lblPrd_remark = new DevExpress.XtraEditors.LabelControl();
            this.chkNoMagTest = new DevExpress.XtraEditors.CheckEdit();
            this.txtSize = new DevExpress.XtraEditors.TextEdit();
            this.lueSize_unit = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSize_diff_oth = new DevExpress.XtraEditors.TextEdit();
            this.luePrd_use = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPack_type_oth = new DevExpress.XtraEditors.TextEdit();
            this.lueWash_type = new DevExpress.XtraEditors.LookUpEdit();
            this.txtRemark2 = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark1 = new DevExpress.XtraEditors.TextEdit();
            this.txtWash_type_oth = new DevExpress.XtraEditors.TextEdit();
            this.luePack_type = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSize_cm = new DevExpress.XtraEditors.TextEdit();
            this.lueSize_diff = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSize_inc = new DevExpress.XtraEditors.TextEdit();
            this.lueTest_std = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCloth_type = new DevExpress.XtraEditors.TextEdit();
            this.txtTest_std_cdesc = new DevExpress.XtraEditors.TextEdit();
            this.txtPrd_use_oth = new DevExpress.XtraEditors.TextEdit();
            this.lblTest_std_cdesc = new DevExpress.XtraEditors.LabelControl();
            this.lblTestStd = new DevExpress.XtraEditors.LabelControl();
            this.lblCloth = new DevExpress.XtraEditors.LabelControl();
            this.lblSize_diff = new DevExpress.XtraEditors.LabelControl();
            this.lblSize_in = new DevExpress.XtraEditors.LabelControl();
            this.lblSize_diff_oth = new DevExpress.XtraEditors.LabelControl();
            this.lblSize_cm = new DevExpress.XtraEditors.LabelControl();
            this.lblPack_oth = new DevExpress.XtraEditors.LabelControl();
            this.lblRemark2 = new DevExpress.XtraEditors.LabelControl();
            this.lblRemark1 = new DevExpress.XtraEditors.LabelControl();
            this.lblSize_unit = new DevExpress.XtraEditors.LabelControl();
            this.lblSize = new DevExpress.XtraEditors.LabelControl();
            this.lblWash_type_oth = new DevExpress.XtraEditors.LabelControl();
            this.lblPrd_use = new DevExpress.XtraEditors.LabelControl();
            this.lblPrd_use_oth = new DevExpress.XtraEditors.LabelControl();
            this.lblPack = new DevExpress.XtraEditors.LabelControl();
            this.lblWash_type = new DevExpress.XtraEditors.LabelControl();
            this.palMe = new DevExpress.XtraEditors.PanelControl();
            this.txtNaked_cdesc = new DevExpress.XtraEditors.TextEdit();
            this.lueZipper_color = new DevExpress.XtraEditors.LookUpEdit();
            this.lblZipper_color = new DevExpress.XtraEditors.LabelControl();
            this.lueZipper_tooth = new DevExpress.XtraEditors.LookUpEdit();
            this.lblZipper_tooth = new DevExpress.XtraEditors.LabelControl();
            this.lueNaked_select = new DevExpress.XtraEditors.LookUpEdit();
            this.lblZipper_color_rmk = new DevExpress.XtraEditors.LabelControl();
            this.lblNaked_select = new DevExpress.XtraEditors.LabelControl();
            this.txtZipper_color_oth = new DevExpress.XtraEditors.TextEdit();
            this.palAll1 = new DevExpress.XtraEditors.PanelControl();
            this.luePull_card_color_id = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPull_card_no = new DevExpress.XtraEditors.TextEdit();
            this.txtSequence_id = new DevExpress.XtraEditors.TextEdit();
            this.lblMo_id = new DevExpress.XtraEditors.LabelControl();
            this.txtMo_id = new DevExpress.XtraEditors.TextEdit();
            this.lueManu_craft_group = new DevExpress.XtraEditors.LookUpEdit();
            this.lblSequence_id = new DevExpress.XtraEditors.LabelControl();
            this.luePrd_process_id1 = new DevExpress.XtraEditors.LookUpEdit();
            this.luePrd_process_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lblSpec_oth = new DevExpress.XtraEditors.LabelControl();
            this.lueManu_craft_id = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSpec_oth = new DevExpress.XtraEditors.TextEdit();
            this.lblSpec_id = new DevExpress.XtraEditors.LabelControl();
            this.lblMat = new DevExpress.XtraEditors.LabelControl();
            this.lueSpec_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPull_card_color = new DevExpress.XtraEditors.LabelControl();
            this.lueMat_type = new DevExpress.XtraEditors.LookUpEdit();
            this.lblGoods_id = new DevExpress.XtraEditors.LabelControl();
            this.lblColor = new DevExpress.XtraEditors.LabelControl();
            this.lblPull_card_no = new DevExpress.XtraEditors.LabelControl();
            this.lueZipper_head = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblPrd_process_oth = new DevExpress.XtraEditors.LabelControl();
            this.lblCust_goods_style = new DevExpress.XtraEditors.LabelControl();
            this.lblManu_craft_oth = new DevExpress.XtraEditors.LabelControl();
            this.lblManu_craft = new DevExpress.XtraEditors.LabelControl();
            this.lueGoods_unit = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblPrd_process_color = new DevExpress.XtraEditors.LabelControl();
            this.lblPrd_Pprocess_dp = new DevExpress.XtraEditors.LabelControl();
            this.lblPrd_Pprocess_up = new DevExpress.XtraEditors.LabelControl();
            this.lblPrd_Pprocess = new DevExpress.XtraEditors.LabelControl();
            this.lblColor_Oth = new DevExpress.XtraEditors.LabelControl();
            this.lblZipperHead = new DevExpress.XtraEditors.LabelControl();
            this.lblColor_Y = new DevExpress.XtraEditors.LabelControl();
            this.lblZipperHead_oth = new DevExpress.XtraEditors.LabelControl();
            this.lblColor_C = new DevExpress.XtraEditors.LabelControl();
            this.txtPrd_seq = new DevExpress.XtraEditors.TextEdit();
            this.txtSample_qty = new DevExpress.XtraEditors.TextEdit();
            this.txtPull_card_color = new DevExpress.XtraEditors.TextEdit();
            this.txtOrder_qty = new DevExpress.XtraEditors.TextEdit();
            this.txtZipper_head_oth = new DevExpress.XtraEditors.TextEdit();
            this.txtPrd_process_oth1 = new DevExpress.XtraEditors.TextEdit();
            this.txtPrd_process_oth = new DevExpress.XtraEditors.TextEdit();
            this.txtCust_goods_style = new DevExpress.XtraEditors.TextEdit();
            this.txtManu_craft_oth = new DevExpress.XtraEditors.TextEdit();
            this.txtManu_craft_cdesc = new DevExpress.XtraEditors.TextEdit();
            this.txtGoods_id = new DevExpress.XtraEditors.TextEdit();
            this.lblPrd_seq_info = new DevExpress.XtraEditors.LabelControl();
            this.lblPrd_seq = new DevExpress.XtraEditors.LabelControl();
            this.txtPrd_process_cdesc1 = new DevExpress.XtraEditors.TextEdit();
            this.txtPrd_process_cdesc = new DevExpress.XtraEditors.TextEdit();
            this.txtPrd_process_color1 = new DevExpress.XtraEditors.TextEdit();
            this.lblSample_qty = new DevExpress.XtraEditors.LabelControl();
            this.txtPrd_process_color = new DevExpress.XtraEditors.TextEdit();
            this.lblGoods_unit = new DevExpress.XtraEditors.LabelControl();
            this.lblOrder_qty = new DevExpress.XtraEditors.LabelControl();
            this.txtColor_C = new DevExpress.XtraEditors.TextEdit();
            this.txtColor_Y = new DevExpress.XtraEditors.TextEdit();
            this.txtColor_oth = new DevExpress.XtraEditors.TextEdit();
            this.txtPrd_remark = new DevExpress.XtraEditors.MemoEdit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtbControl1)).BeginInit();
            this.xtbControl1.SuspendLayout();
            this.xtbPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrusr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust_po.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIt_customer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrder_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoGroup.Properties)).BeginInit();
            this.xtbPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palAll2)).BeginInit();
            this.palAll2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNoMagTest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSize_unit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize_diff_oth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePrd_use.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPack_type_oth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWash_type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWash_type_oth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePack_type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize_cm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSize_diff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize_inc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTest_std.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCloth_type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTest_std_cdesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_use_oth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palMe)).BeginInit();
            this.palMe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNaked_cdesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueZipper_color.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueZipper_tooth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNaked_select.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZipper_color_oth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palAll1)).BeginInit();
            this.palAll1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luePull_card_color_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPull_card_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSequence_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueManu_craft_group.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePrd_process_id1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePrd_process_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueManu_craft_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpec_oth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSpec_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMat_type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueZipper_head.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoods_unit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_seq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSample_qty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPull_card_color.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrder_qty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZipper_head_oth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_process_oth1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_process_oth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust_goods_style.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManu_craft_oth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManu_craft_cdesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_process_cdesc1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_process_cdesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_process_color1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_process_color.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor_C.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor_Y.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor_oth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_remark.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnNew,
            this.toolStripSeparator2,
            this.btnEdit,
            this.toolStripSeparator3,
            this.btnUndo,
            this.toolStripSeparator7,
            this.btnDel,
            this.toolStripSeparator4,
            this.btnSave,
            this.toolStripSeparator5,
            this.btnConf,
            this.toolStripSeparator6,
            this.btnTran,
            this.toolStripSeparator11,
            this.btnUpdateMo,
            this.toolStripSeparator12,
            this.btnPrint,
            this.toolStripSeparator9,
            this.btnExcel,
            this.toolStripSeparator8,
            this.btnFind,
            this.toolStripSeparator10});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1183, 38);
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
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
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
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(65, 35);
            this.btnEdit.Text = "修改(&E)";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
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
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 38);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 35);
            this.btnSave.Text = "儲存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // btnConf
            // 
            this.btnConf.AutoSize = false;
            this.btnConf.Image = ((System.Drawing.Image)(resources.GetObject("btnConf.Image")));
            this.btnConf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(65, 35);
            this.btnConf.Text = "批準(&C)";
            this.btnConf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // btnTran
            // 
            this.btnTran.AutoSize = false;
            this.btnTran.Image = ((System.Drawing.Image)(resources.GetObject("btnTran.Image")));
            this.btnTran.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTran.Name = "btnTran";
            this.btnTran.Size = new System.Drawing.Size(72, 35);
            this.btnTran.Text = "轉申購單(&T)";
            this.btnTran.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTran.Click += new System.EventHandler(this.btnTran_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 38);
            // 
            // btnUpdateMo
            // 
            this.btnUpdateMo.AutoSize = false;
            this.btnUpdateMo.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateMo.Image")));
            this.btnUpdateMo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateMo.Name = "btnUpdateMo";
            this.btnUpdateMo.Size = new System.Drawing.Size(85, 35);
            this.btnUpdateMo.Text = "更新制單(&M)";
            this.btnUpdateMo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUpdateMo.ToolTipText = "將OC中的制單更新到此記錄中";
            this.btnUpdateMo.Click += new System.EventHandler(this.btnUpdateMo_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 38);
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
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 38);
            // 
            // btnExcel
            // 
            this.btnExcel.AutoSize = false;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(65, 35);
            this.btnExcel.Text = "Excel(&E)";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 38);
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
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 38);
            // 
            // xtbControl1
            // 
            this.xtbControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtbControl1.Location = new System.Drawing.Point(0, 38);
            this.xtbControl1.Name = "xtbControl1";
            this.xtbControl1.SelectedTabPage = this.xtbPage1;
            this.xtbControl1.Size = new System.Drawing.Size(1183, 648);
            this.xtbControl1.TabIndex = 1;
            this.xtbControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtbPage1,
            this.xtbPage2});
            this.xtbControl1.Click += new System.EventHandler(this.xtbControl1_Click);
            // 
            // xtbPage1
            // 
            this.xtbPage1.Appearance.PageClient.BackColor = System.Drawing.Color.Silver;
            this.xtbPage1.Appearance.PageClient.Options.UseBackColor = true;
            this.xtbPage1.Controls.Add(this.panelControl1);
            this.xtbPage1.Name = "xtbPage1";
            this.xtbPage1.Size = new System.Drawing.Size(1177, 619);
            this.xtbPage1.Text = "訂單基本資料";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblMoGroup);
            this.panelControl1.Controls.Add(this.txtCust_name);
            this.panelControl1.Controls.Add(this.lblCust_name);
            this.panelControl1.Controls.Add(this.txtCrtim);
            this.panelControl1.Controls.Add(this.lblCrtim);
            this.panelControl1.Controls.Add(this.txtCrusr);
            this.panelControl1.Controls.Add(this.lblCrusr);
            this.panelControl1.Controls.Add(this.txtCust_po);
            this.panelControl1.Controls.Add(this.lblCust_po);
            this.panelControl1.Controls.Add(this.txtIt_customer);
            this.panelControl1.Controls.Add(this.lblIt_customer);
            this.panelControl1.Controls.Add(this.txtOrder_date);
            this.panelControl1.Controls.Add(this.lblOrder_date);
            this.panelControl1.Controls.Add(this.txtId);
            this.panelControl1.Controls.Add(this.lblId);
            this.panelControl1.Controls.Add(this.lueMoGroup);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1177, 619);
            this.panelControl1.TabIndex = 2;
            // 
            // lblMoGroup
            // 
            this.lblMoGroup.Location = new System.Drawing.Point(37, 34);
            this.lblMoGroup.Name = "lblMoGroup";
            this.lblMoGroup.Size = new System.Drawing.Size(28, 14);
            this.lblMoGroup.TabIndex = 2;
            this.lblMoGroup.Text = "組別:";
            // 
            // txtCust_name
            // 
            this.txtCust_name.Location = new System.Drawing.Point(258, 57);
            this.txtCust_name.Name = "txtCust_name";
            this.txtCust_name.Properties.ReadOnly = true;
            this.txtCust_name.Size = new System.Drawing.Size(185, 20);
            this.txtCust_name.TabIndex = 1;
            // 
            // lblCust_name
            // 
            this.lblCust_name.Location = new System.Drawing.Point(195, 60);
            this.lblCust_name.Name = "lblCust_name";
            this.lblCust_name.Size = new System.Drawing.Size(52, 14);
            this.lblCust_name.TabIndex = 0;
            this.lblCust_name.Text = "客戶名稱:";
            // 
            // txtCrtim
            // 
            this.txtCrtim.Location = new System.Drawing.Point(258, 83);
            this.txtCrtim.Name = "txtCrtim";
            this.txtCrtim.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCrtim.Properties.MaxLength = 8;
            this.txtCrtim.Properties.ReadOnly = true;
            this.txtCrtim.Size = new System.Drawing.Size(185, 20);
            this.txtCrtim.TabIndex = 1;
            this.txtCrtim.Leave += new System.EventHandler(this.txtIt_customer_Leave);
            // 
            // lblCrtim
            // 
            this.lblCrtim.Location = new System.Drawing.Point(195, 86);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(52, 14);
            this.lblCrtim.TabIndex = 0;
            this.lblCrtim.Text = "建立時間:";
            // 
            // txtCrusr
            // 
            this.txtCrusr.Location = new System.Drawing.Point(72, 83);
            this.txtCrusr.Name = "txtCrusr";
            this.txtCrusr.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCrusr.Properties.MaxLength = 8;
            this.txtCrusr.Properties.ReadOnly = true;
            this.txtCrusr.Size = new System.Drawing.Size(100, 20);
            this.txtCrusr.TabIndex = 1;
            this.txtCrusr.Leave += new System.EventHandler(this.txtIt_customer_Leave);
            // 
            // lblCrusr
            // 
            this.lblCrusr.Location = new System.Drawing.Point(25, 86);
            this.lblCrusr.Name = "lblCrusr";
            this.lblCrusr.Size = new System.Drawing.Size(40, 14);
            this.lblCrusr.TabIndex = 0;
            this.lblCrusr.Text = "建立人:";
            // 
            // txtCust_po
            // 
            this.txtCust_po.Location = new System.Drawing.Point(258, 31);
            this.txtCust_po.Name = "txtCust_po";
            this.txtCust_po.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCust_po.Properties.MaxLength = 50;
            this.txtCust_po.Properties.ReadOnly = true;
            this.txtCust_po.Size = new System.Drawing.Size(185, 20);
            this.txtCust_po.TabIndex = 1;
            this.txtCust_po.Leave += new System.EventHandler(this.txtIt_customer_Leave);
            // 
            // lblCust_po
            // 
            this.lblCust_po.Location = new System.Drawing.Point(205, 34);
            this.lblCust_po.Name = "lblCust_po";
            this.lblCust_po.Size = new System.Drawing.Size(42, 14);
            this.lblCust_po.TabIndex = 0;
            this.lblCust_po.Text = "客戶Po:";
            // 
            // txtIt_customer
            // 
            this.txtIt_customer.Location = new System.Drawing.Point(72, 57);
            this.txtIt_customer.Name = "txtIt_customer";
            this.txtIt_customer.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIt_customer.Properties.MaxLength = 8;
            this.txtIt_customer.Properties.ReadOnly = true;
            this.txtIt_customer.Size = new System.Drawing.Size(100, 20);
            this.txtIt_customer.TabIndex = 1;
            this.txtIt_customer.Leave += new System.EventHandler(this.txtIt_customer_Leave);
            // 
            // lblIt_customer
            // 
            this.lblIt_customer.Location = new System.Drawing.Point(13, 60);
            this.lblIt_customer.Name = "lblIt_customer";
            this.lblIt_customer.Size = new System.Drawing.Size(52, 14);
            this.lblIt_customer.TabIndex = 0;
            this.lblIt_customer.Text = "客戶編號:";
            // 
            // txtOrder_date
            // 
            this.txtOrder_date.Location = new System.Drawing.Point(258, 5);
            this.txtOrder_date.Name = "txtOrder_date";
            this.txtOrder_date.Properties.Mask.EditMask = "9999/99/99";
            this.txtOrder_date.Properties.ReadOnly = true;
            this.txtOrder_date.Size = new System.Drawing.Size(185, 20);
            this.txtOrder_date.TabIndex = 1;
            // 
            // lblOrder_date
            // 
            this.lblOrder_date.Location = new System.Drawing.Point(195, 8);
            this.lblOrder_date.Name = "lblOrder_date";
            this.lblOrder_date.Size = new System.Drawing.Size(52, 14);
            this.lblOrder_date.TabIndex = 0;
            this.lblOrder_date.Text = "訂單日期:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(72, 5);
            this.txtId.Name = "txtId";
            this.txtId.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 1;
            this.txtId.Leave += new System.EventHandler(this.txtId_Leave);
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(37, 8);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(28, 14);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "編號:";
            // 
            // lueMoGroup
            // 
            this.lueMoGroup.Location = new System.Drawing.Point(72, 31);
            this.lueMoGroup.Name = "lueMoGroup";
            this.lueMoGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMoGroup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("mo_group", "組別")});
            this.lueMoGroup.Properties.NullText = "";
            this.lueMoGroup.Size = new System.Drawing.Size(100, 20);
            this.lueMoGroup.TabIndex = 3;
            // 
            // xtbPage2
            // 
            this.xtbPage2.Controls.Add(this.gcDetails);
            this.xtbPage2.Controls.Add(this.palAll2);
            this.xtbPage2.Controls.Add(this.palMe);
            this.xtbPage2.Controls.Add(this.palAll1);
            this.xtbPage2.Name = "xtbPage2";
            this.xtbPage2.Size = new System.Drawing.Size(1177, 619);
            this.xtbPage2.Text = "訂單明細資料";
            // 
            // gcDetails
            // 
            this.gcDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetails.Location = new System.Drawing.Point(0, 381);
            this.gcDetails.MainView = this.dgvDetails;
            this.gcDetails.Name = "gcDetails";
            this.gcDetails.Size = new System.Drawing.Size(1177, 238);
            this.gcDetails.TabIndex = 1;
            this.gcDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetails});
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnPanelRowHeight = 30;
            this.dgvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSequence_id,
            this.cloMat_type,
            this.colMo_id,
            this.colGoods_id,
            this.colOrder_qty,
            this.colGoods_unit,
            this.colSpec_id,
            this.colSpec_oth,
            this.colColor_c,
            this.colColor_y,
            this.colColor_oth,
            this.colManu_craft_group,
            this.colManu_craft_id,
            this.colManu_craft_cdesc,
            this.colPrd_process_group,
            this.colPrd_process_id,
            this.colPrd_process_cdesc,
            this.colZipper_head,
            this.colZipper_head_oth,
            this.colCrusr,
            this.colCrtim});
            this.dgvDetails.GridControl = this.gcDetails;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.OptionsBehavior.ReadOnly = true;
            this.dgvDetails.OptionsSelection.MultiSelect = true;
            this.dgvDetails.OptionsView.ColumnAutoWidth = false;
            this.dgvDetails.OptionsView.ShowGroupPanel = false;
            this.dgvDetails.RowHeight = 30;
            this.dgvDetails.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.dgvDetails_SelectionChanged);
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
            // cloMat_type
            // 
            this.cloMat_type.Caption = "質地";
            this.cloMat_type.FieldName = "mat_type";
            this.cloMat_type.Name = "cloMat_type";
            this.cloMat_type.Visible = true;
            this.cloMat_type.VisibleIndex = 1;
            this.cloMat_type.Width = 60;
            // 
            // colMo_id
            // 
            this.colMo_id.Caption = "制單編號";
            this.colMo_id.FieldName = "mo_id";
            this.colMo_id.Name = "colMo_id";
            this.colMo_id.Visible = true;
            this.colMo_id.VisibleIndex = 2;
            this.colMo_id.Width = 80;
            // 
            // colGoods_id
            // 
            this.colGoods_id.Caption = "產品編號";
            this.colGoods_id.FieldName = "goods_id";
            this.colGoods_id.Name = "colGoods_id";
            this.colGoods_id.Visible = true;
            this.colGoods_id.VisibleIndex = 3;
            this.colGoods_id.Width = 120;
            // 
            // colOrder_qty
            // 
            this.colOrder_qty.Caption = "訂單數量";
            this.colOrder_qty.FieldName = "order_qty";
            this.colOrder_qty.Name = "colOrder_qty";
            this.colOrder_qty.Visible = true;
            this.colOrder_qty.VisibleIndex = 4;
            this.colOrder_qty.Width = 80;
            // 
            // colGoods_unit
            // 
            this.colGoods_unit.Caption = "數量單位";
            this.colGoods_unit.FieldName = "goods_unit";
            this.colGoods_unit.Name = "colGoods_unit";
            this.colGoods_unit.Visible = true;
            this.colGoods_unit.VisibleIndex = 5;
            this.colGoods_unit.Width = 60;
            // 
            // colSpec_id
            // 
            this.colSpec_id.Caption = "規格";
            this.colSpec_id.FieldName = "spec_cdesc";
            this.colSpec_id.Name = "colSpec_id";
            this.colSpec_id.Visible = true;
            this.colSpec_id.VisibleIndex = 6;
            this.colSpec_id.Width = 60;
            // 
            // colSpec_oth
            // 
            this.colSpec_oth.Caption = "其它規格";
            this.colSpec_oth.FieldName = "spec_oth";
            this.colSpec_oth.Name = "colSpec_oth";
            this.colSpec_oth.Visible = true;
            this.colSpec_oth.VisibleIndex = 7;
            this.colSpec_oth.Width = 80;
            // 
            // colColor_c
            // 
            this.colColor_c.Caption = "C卡顏色編號";
            this.colColor_c.FieldName = "color_c";
            this.colColor_c.Name = "colColor_c";
            this.colColor_c.Visible = true;
            this.colColor_c.VisibleIndex = 8;
            this.colColor_c.Width = 80;
            // 
            // colColor_y
            // 
            this.colColor_y.Caption = "Y卡顏色編號";
            this.colColor_y.FieldName = "color_c";
            this.colColor_y.Name = "colColor_y";
            this.colColor_y.Visible = true;
            this.colColor_y.VisibleIndex = 9;
            this.colColor_y.Width = 80;
            // 
            // colColor_oth
            // 
            this.colColor_oth.Caption = "其它顏色";
            this.colColor_oth.FieldName = "color_oth";
            this.colColor_oth.Name = "colColor_oth";
            this.colColor_oth.Visible = true;
            this.colColor_oth.VisibleIndex = 10;
            this.colColor_oth.Width = 80;
            // 
            // colManu_craft_group
            // 
            this.colManu_craft_group.Caption = "製作工藝";
            this.colManu_craft_group.FieldName = "manu_craft_group_cdesc";
            this.colManu_craft_group.Name = "colManu_craft_group";
            this.colManu_craft_group.Visible = true;
            this.colManu_craft_group.VisibleIndex = 11;
            this.colManu_craft_group.Width = 80;
            // 
            // colManu_craft_id
            // 
            this.colManu_craft_id.Caption = "工藝序號";
            this.colManu_craft_id.FieldName = "manu_craft_id";
            this.colManu_craft_id.Name = "colManu_craft_id";
            this.colManu_craft_id.Visible = true;
            this.colManu_craft_id.VisibleIndex = 12;
            this.colManu_craft_id.Width = 80;
            // 
            // colManu_craft_cdesc
            // 
            this.colManu_craft_cdesc.Caption = "工藝描述";
            this.colManu_craft_cdesc.FieldName = "manu_craft_cdesc";
            this.colManu_craft_cdesc.Name = "colManu_craft_cdesc";
            this.colManu_craft_cdesc.Visible = true;
            this.colManu_craft_cdesc.VisibleIndex = 13;
            this.colManu_craft_cdesc.Width = 180;
            // 
            // colPrd_process_group
            // 
            this.colPrd_process_group.Caption = "製作工序";
            this.colPrd_process_group.FieldName = "prd_process_group_cdesc";
            this.colPrd_process_group.Name = "colPrd_process_group";
            this.colPrd_process_group.Visible = true;
            this.colPrd_process_group.VisibleIndex = 14;
            this.colPrd_process_group.Width = 80;
            // 
            // colPrd_process_id
            // 
            this.colPrd_process_id.Caption = "工序序號";
            this.colPrd_process_id.FieldName = "prd_process_id";
            this.colPrd_process_id.Name = "colPrd_process_id";
            this.colPrd_process_id.Visible = true;
            this.colPrd_process_id.VisibleIndex = 15;
            this.colPrd_process_id.Width = 80;
            // 
            // colPrd_process_cdesc
            // 
            this.colPrd_process_cdesc.Caption = "工序描述";
            this.colPrd_process_cdesc.FieldName = "prd_process_cdesc";
            this.colPrd_process_cdesc.Name = "colPrd_process_cdesc";
            this.colPrd_process_cdesc.Visible = true;
            this.colPrd_process_cdesc.VisibleIndex = 16;
            this.colPrd_process_cdesc.Width = 180;
            // 
            // colZipper_head
            // 
            this.colZipper_head.Caption = "拉頭標準";
            this.colZipper_head.FieldName = "zipper_head";
            this.colZipper_head.Name = "colZipper_head";
            this.colZipper_head.Visible = true;
            this.colZipper_head.VisibleIndex = 17;
            this.colZipper_head.Width = 80;
            // 
            // colZipper_head_oth
            // 
            this.colZipper_head_oth.Caption = "其它拉頭";
            this.colZipper_head_oth.FieldName = "zipper_head_oth";
            this.colZipper_head_oth.Name = "colZipper_head_oth";
            this.colZipper_head_oth.Visible = true;
            this.colZipper_head_oth.VisibleIndex = 18;
            this.colZipper_head_oth.Width = 80;
            // 
            // colCrusr
            // 
            this.colCrusr.Caption = "建立人";
            this.colCrusr.FieldName = "crusr";
            this.colCrusr.Name = "colCrusr";
            this.colCrusr.Visible = true;
            this.colCrusr.VisibleIndex = 19;
            this.colCrusr.Width = 80;
            // 
            // colCrtim
            // 
            this.colCrtim.Caption = "建立日期";
            this.colCrtim.FieldName = "crtim_str";
            this.colCrtim.Name = "colCrtim";
            this.colCrtim.Visible = true;
            this.colCrtim.VisibleIndex = 20;
            this.colCrtim.Width = 120;
            // 
            // palAll2
            // 
            this.palAll2.Controls.Add(this.btnShowTest);
            this.palAll2.Controls.Add(this.lblPrd_remark);
            this.palAll2.Controls.Add(this.chkNoMagTest);
            this.palAll2.Controls.Add(this.txtSize);
            this.palAll2.Controls.Add(this.lueSize_unit);
            this.palAll2.Controls.Add(this.txtSize_diff_oth);
            this.palAll2.Controls.Add(this.luePrd_use);
            this.palAll2.Controls.Add(this.txtPack_type_oth);
            this.palAll2.Controls.Add(this.lueWash_type);
            this.palAll2.Controls.Add(this.txtRemark2);
            this.palAll2.Controls.Add(this.txtRemark1);
            this.palAll2.Controls.Add(this.txtWash_type_oth);
            this.palAll2.Controls.Add(this.luePack_type);
            this.palAll2.Controls.Add(this.txtSize_cm);
            this.palAll2.Controls.Add(this.lueSize_diff);
            this.palAll2.Controls.Add(this.txtSize_inc);
            this.palAll2.Controls.Add(this.lueTest_std);
            this.palAll2.Controls.Add(this.txtCloth_type);
            this.palAll2.Controls.Add(this.txtTest_std_cdesc);
            this.palAll2.Controls.Add(this.txtPrd_use_oth);
            this.palAll2.Controls.Add(this.lblTest_std_cdesc);
            this.palAll2.Controls.Add(this.lblTestStd);
            this.palAll2.Controls.Add(this.lblCloth);
            this.palAll2.Controls.Add(this.lblSize_diff);
            this.palAll2.Controls.Add(this.lblSize_in);
            this.palAll2.Controls.Add(this.lblSize_diff_oth);
            this.palAll2.Controls.Add(this.lblSize_cm);
            this.palAll2.Controls.Add(this.lblPack_oth);
            this.palAll2.Controls.Add(this.lblRemark2);
            this.palAll2.Controls.Add(this.lblRemark1);
            this.palAll2.Controls.Add(this.lblSize_unit);
            this.palAll2.Controls.Add(this.lblSize);
            this.palAll2.Controls.Add(this.lblWash_type_oth);
            this.palAll2.Controls.Add(this.lblPrd_use);
            this.palAll2.Controls.Add(this.lblPrd_use_oth);
            this.palAll2.Controls.Add(this.lblPack);
            this.palAll2.Controls.Add(this.lblWash_type);
            this.palAll2.Controls.Add(this.txtPrd_remark);
            this.palAll2.Dock = System.Windows.Forms.DockStyle.Top;
            this.palAll2.Location = new System.Drawing.Point(0, 226);
            this.palAll2.Name = "palAll2";
            this.palAll2.Size = new System.Drawing.Size(1177, 155);
            this.palAll2.TabIndex = 10;
            // 
            // btnShowTest
            // 
            this.btnShowTest.Location = new System.Drawing.Point(844, 84);
            this.btnShowTest.Name = "btnShowTest";
            this.btnShowTest.Size = new System.Drawing.Size(75, 25);
            this.btnShowTest.TabIndex = 13;
            this.btnShowTest.Text = "測試項目";
            this.btnShowTest.Click += new System.EventHandler(this.btnShowTest_Click);
            // 
            // lblPrd_remark
            // 
            this.lblPrd_remark.Location = new System.Drawing.Point(6, 109);
            this.lblPrd_remark.Name = "lblPrd_remark";
            this.lblPrd_remark.Size = new System.Drawing.Size(52, 14);
            this.lblPrd_remark.TabIndex = 11;
            this.lblPrd_remark.Text = "生產備註:";
            // 
            // chkNoMagTest
            // 
            this.chkNoMagTest.EditValue = true;
            this.chkNoMagTest.Location = new System.Drawing.Point(844, 58);
            this.chkNoMagTest.Name = "chkNoMagTest";
            this.chkNoMagTest.Properties.AutoWidth = true;
            this.chkNoMagTest.Properties.Caption = "無磁過檢針機";
            this.chkNoMagTest.Size = new System.Drawing.Size(95, 19);
            this.chkNoMagTest.TabIndex = 10;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(64, 32);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(100, 20);
            this.txtSize.TabIndex = 9;
            // 
            // lueSize_unit
            // 
            this.lueSize_unit.Location = new System.Drawing.Point(265, 32);
            this.lueSize_unit.Name = "lueSize_unit";
            this.lueSize_unit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSize_unit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("unit_id", 40, "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("unit_cdesc", 60, "描述")});
            this.lueSize_unit.Properties.NullText = "";
            this.lueSize_unit.Size = new System.Drawing.Size(119, 20);
            this.lueSize_unit.TabIndex = 8;
            // 
            // txtSize_diff_oth
            // 
            this.txtSize_diff_oth.Location = new System.Drawing.Point(716, 32);
            this.txtSize_diff_oth.Name = "txtSize_diff_oth";
            this.txtSize_diff_oth.Size = new System.Drawing.Size(119, 20);
            this.txtSize_diff_oth.TabIndex = 5;
            // 
            // luePrd_use
            // 
            this.luePrd_use.Location = new System.Drawing.Point(467, 8);
            this.luePrd_use.Name = "luePrd_use";
            this.luePrd_use.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePrd_use.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 60, "描述")});
            this.luePrd_use.Properties.NullText = "";
            this.luePrd_use.Size = new System.Drawing.Size(151, 20);
            this.luePrd_use.TabIndex = 7;
            this.luePrd_use.EditValueChanged += new System.EventHandler(this.luePrd_use_EditValueChanged);
            // 
            // txtPack_type_oth
            // 
            this.txtPack_type_oth.Location = new System.Drawing.Point(265, 58);
            this.txtPack_type_oth.Name = "txtPack_type_oth";
            this.txtPack_type_oth.Size = new System.Drawing.Size(119, 20);
            this.txtPack_type_oth.TabIndex = 5;
            // 
            // lueWash_type
            // 
            this.lueWash_type.Location = new System.Drawing.Point(467, 58);
            this.lueWash_type.Name = "lueWash_type";
            this.lueWash_type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueWash_type.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 60, "描述")});
            this.lueWash_type.Properties.NullText = "";
            this.lueWash_type.Size = new System.Drawing.Size(151, 20);
            this.lueWash_type.TabIndex = 7;
            this.lueWash_type.EditValueChanged += new System.EventHandler(this.lueTestStd_EditValueChanged);
            // 
            // txtRemark2
            // 
            this.txtRemark2.Location = new System.Drawing.Point(467, 83);
            this.txtRemark2.Name = "txtRemark2";
            this.txtRemark2.Size = new System.Drawing.Size(368, 20);
            this.txtRemark2.TabIndex = 5;
            // 
            // txtRemark1
            // 
            this.txtRemark1.Location = new System.Drawing.Point(64, 83);
            this.txtRemark1.Name = "txtRemark1";
            this.txtRemark1.Size = new System.Drawing.Size(320, 20);
            this.txtRemark1.TabIndex = 5;
            // 
            // txtWash_type_oth
            // 
            this.txtWash_type_oth.Location = new System.Drawing.Point(716, 58);
            this.txtWash_type_oth.Name = "txtWash_type_oth";
            this.txtWash_type_oth.Size = new System.Drawing.Size(119, 20);
            this.txtWash_type_oth.TabIndex = 5;
            // 
            // luePack_type
            // 
            this.luePack_type.Location = new System.Drawing.Point(65, 58);
            this.luePack_type.Name = "luePack_type";
            this.luePack_type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePack_type.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 60, "描述")});
            this.luePack_type.Properties.NullText = "";
            this.luePack_type.Size = new System.Drawing.Size(100, 20);
            this.luePack_type.TabIndex = 7;
            this.luePack_type.EditValueChanged += new System.EventHandler(this.lueTestStd_EditValueChanged);
            // 
            // txtSize_cm
            // 
            this.txtSize_cm.Enabled = false;
            this.txtSize_cm.Location = new System.Drawing.Point(1049, 86);
            this.txtSize_cm.Name = "txtSize_cm";
            this.txtSize_cm.Size = new System.Drawing.Size(100, 20);
            this.txtSize_cm.TabIndex = 5;
            this.txtSize_cm.Visible = false;
            // 
            // lueSize_diff
            // 
            this.lueSize_diff.Location = new System.Drawing.Point(467, 32);
            this.lueSize_diff.Name = "lueSize_diff";
            this.lueSize_diff.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSize_diff.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 60, "描述")});
            this.lueSize_diff.Properties.NullText = "";
            this.lueSize_diff.Size = new System.Drawing.Size(151, 20);
            this.lueSize_diff.TabIndex = 7;
            this.lueSize_diff.EditValueChanged += new System.EventHandler(this.lueTestStd_EditValueChanged);
            // 
            // txtSize_inc
            // 
            this.txtSize_inc.Enabled = false;
            this.txtSize_inc.Location = new System.Drawing.Point(1049, 60);
            this.txtSize_inc.Name = "txtSize_inc";
            this.txtSize_inc.Size = new System.Drawing.Size(119, 20);
            this.txtSize_inc.TabIndex = 5;
            this.txtSize_inc.Visible = false;
            // 
            // lueTest_std
            // 
            this.lueTest_std.Location = new System.Drawing.Point(64, 8);
            this.lueTest_std.Name = "lueTest_std";
            this.lueTest_std.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTest_std.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 60, "描述")});
            this.lueTest_std.Properties.NullText = "";
            this.lueTest_std.Size = new System.Drawing.Size(100, 20);
            this.lueTest_std.TabIndex = 7;
            this.lueTest_std.EditValueChanged += new System.EventHandler(this.lueTestStd_EditValueChanged);
            // 
            // txtCloth_type
            // 
            this.txtCloth_type.Location = new System.Drawing.Point(906, 8);
            this.txtCloth_type.Name = "txtCloth_type";
            this.txtCloth_type.Size = new System.Drawing.Size(151, 20);
            this.txtCloth_type.TabIndex = 5;
            // 
            // txtTest_std_cdesc
            // 
            this.txtTest_std_cdesc.Location = new System.Drawing.Point(265, 8);
            this.txtTest_std_cdesc.Name = "txtTest_std_cdesc";
            this.txtTest_std_cdesc.Size = new System.Drawing.Size(119, 20);
            this.txtTest_std_cdesc.TabIndex = 5;
            // 
            // txtPrd_use_oth
            // 
            this.txtPrd_use_oth.Location = new System.Drawing.Point(716, 8);
            this.txtPrd_use_oth.Name = "txtPrd_use_oth";
            this.txtPrd_use_oth.Size = new System.Drawing.Size(119, 20);
            this.txtPrd_use_oth.TabIndex = 5;
            // 
            // lblTest_std_cdesc
            // 
            this.lblTest_std_cdesc.Location = new System.Drawing.Point(207, 11);
            this.lblTest_std_cdesc.Name = "lblTest_std_cdesc";
            this.lblTest_std_cdesc.Size = new System.Drawing.Size(52, 14);
            this.lblTest_std_cdesc.TabIndex = 4;
            this.lblTest_std_cdesc.Text = "其它標準:";
            // 
            // lblTestStd
            // 
            this.lblTestStd.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblTestStd.Location = new System.Drawing.Point(6, 11);
            this.lblTestStd.Name = "lblTestStd";
            this.lblTestStd.Size = new System.Drawing.Size(52, 14);
            this.lblTestStd.TabIndex = 4;
            this.lblTestStd.Text = "測試標準:";
            // 
            // lblCloth
            // 
            this.lblCloth.Location = new System.Drawing.Point(844, 11);
            this.lblCloth.Name = "lblCloth";
            this.lblCloth.Size = new System.Drawing.Size(57, 14);
            this.lblCloth.TabIndex = 6;
            this.lblCloth.Text = "面料/布料:";
            // 
            // lblSize_diff
            // 
            this.lblSize_diff.Location = new System.Drawing.Point(410, 36);
            this.lblSize_diff.Name = "lblSize_diff";
            this.lblSize_diff.Size = new System.Drawing.Size(52, 14);
            this.lblSize_diff.TabIndex = 4;
            this.lblSize_diff.Text = "尺寸公差:";
            // 
            // lblSize_in
            // 
            this.lblSize_in.Enabled = false;
            this.lblSize_in.Location = new System.Drawing.Point(981, 64);
            this.lblSize_in.Name = "lblSize_in";
            this.lblSize_in.Size = new System.Drawing.Size(62, 14);
            this.lblSize_in.TabIndex = 6;
            this.lblSize_in.Text = "英吋(Inch):";
            this.lblSize_in.Visible = false;
            // 
            // lblSize_diff_oth
            // 
            this.lblSize_diff_oth.Location = new System.Drawing.Point(657, 36);
            this.lblSize_diff_oth.Name = "lblSize_diff_oth";
            this.lblSize_diff_oth.Size = new System.Drawing.Size(52, 14);
            this.lblSize_diff_oth.TabIndex = 4;
            this.lblSize_diff_oth.Text = "特殊要求:";
            // 
            // lblSize_cm
            // 
            this.lblSize_cm.Location = new System.Drawing.Point(844, 36);
            this.lblSize_cm.Name = "lblSize_cm";
            this.lblSize_cm.Size = new System.Drawing.Size(286, 14);
            this.lblSize_cm.TabIndex = 6;
            this.lblSize_cm.Text = "公分(cm)(以0.5cm為進位);英吋(Inch)(以1/8\"為進位)";
            // 
            // lblPack_oth
            // 
            this.lblPack_oth.Location = new System.Drawing.Point(184, 60);
            this.lblPack_oth.Name = "lblPack_oth";
            this.lblPack_oth.Size = new System.Drawing.Size(76, 14);
            this.lblPack_oth.TabIndex = 4;
            this.lblPack_oth.Text = "其它包裝要求:";
            // 
            // lblRemark2
            // 
            this.lblRemark2.Location = new System.Drawing.Point(427, 86);
            this.lblRemark2.Name = "lblRemark2";
            this.lblRemark2.Size = new System.Drawing.Size(35, 14);
            this.lblRemark2.TabIndex = 4;
            this.lblRemark2.Text = "備註2:";
            // 
            // lblRemark1
            // 
            this.lblRemark1.Location = new System.Drawing.Point(24, 86);
            this.lblRemark1.Name = "lblRemark1";
            this.lblRemark1.Size = new System.Drawing.Size(35, 14);
            this.lblRemark1.TabIndex = 4;
            this.lblRemark1.Text = "備註1:";
            // 
            // lblSize_unit
            // 
            this.lblSize_unit.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblSize_unit.Location = new System.Drawing.Point(207, 36);
            this.lblSize_unit.Name = "lblSize_unit";
            this.lblSize_unit.Size = new System.Drawing.Size(52, 14);
            this.lblSize_unit.TabIndex = 6;
            this.lblSize_unit.Text = "尺寸單位:";
            // 
            // lblSize
            // 
            this.lblSize.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblSize.Location = new System.Drawing.Point(30, 36);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(28, 14);
            this.lblSize.TabIndex = 6;
            this.lblSize.Text = "尺寸:";
            // 
            // lblWash_type_oth
            // 
            this.lblWash_type_oth.Location = new System.Drawing.Point(633, 60);
            this.lblWash_type_oth.Name = "lblWash_type_oth";
            this.lblWash_type_oth.Size = new System.Drawing.Size(76, 14);
            this.lblWash_type_oth.TabIndex = 4;
            this.lblWash_type_oth.Text = "其它洗水要求:";
            // 
            // lblPrd_use
            // 
            this.lblPrd_use.Location = new System.Drawing.Point(434, 11);
            this.lblPrd_use.Name = "lblPrd_use";
            this.lblPrd_use.Size = new System.Drawing.Size(28, 14);
            this.lblPrd_use.TabIndex = 6;
            this.lblPrd_use.Text = "應用:";
            // 
            // lblPrd_use_oth
            // 
            this.lblPrd_use_oth.Location = new System.Drawing.Point(681, 11);
            this.lblPrd_use_oth.Name = "lblPrd_use_oth";
            this.lblPrd_use_oth.Size = new System.Drawing.Size(28, 14);
            this.lblPrd_use_oth.TabIndex = 6;
            this.lblPrd_use_oth.Text = "其它:";
            // 
            // lblPack
            // 
            this.lblPack.Location = new System.Drawing.Point(7, 60);
            this.lblPack.Name = "lblPack";
            this.lblPack.Size = new System.Drawing.Size(52, 14);
            this.lblPack.TabIndex = 4;
            this.lblPack.Text = "包裝要求:";
            // 
            // lblWash_type
            // 
            this.lblWash_type.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblWash_type.Location = new System.Drawing.Point(410, 60);
            this.lblWash_type.Name = "lblWash_type";
            this.lblWash_type.Size = new System.Drawing.Size(52, 14);
            this.lblWash_type.TabIndex = 4;
            this.lblWash_type.Text = "洗水要求:";
            // 
            // palMe
            // 
            this.palMe.Controls.Add(this.txtNaked_cdesc);
            this.palMe.Controls.Add(this.lueZipper_color);
            this.palMe.Controls.Add(this.lblZipper_color);
            this.palMe.Controls.Add(this.lueZipper_tooth);
            this.palMe.Controls.Add(this.lblZipper_tooth);
            this.palMe.Controls.Add(this.lueNaked_select);
            this.palMe.Controls.Add(this.lblZipper_color_rmk);
            this.palMe.Controls.Add(this.lblNaked_select);
            this.palMe.Controls.Add(this.txtZipper_color_oth);
            this.palMe.Dock = System.Windows.Forms.DockStyle.Top;
            this.palMe.Location = new System.Drawing.Point(0, 188);
            this.palMe.Name = "palMe";
            this.palMe.Size = new System.Drawing.Size(1177, 38);
            this.palMe.TabIndex = 8;
            // 
            // txtNaked_cdesc
            // 
            this.txtNaked_cdesc.Location = new System.Drawing.Point(170, 7);
            this.txtNaked_cdesc.Name = "txtNaked_cdesc";
            this.txtNaked_cdesc.Size = new System.Drawing.Size(214, 20);
            this.txtNaked_cdesc.TabIndex = 8;
            // 
            // lueZipper_color
            // 
            this.lueZipper_color.Location = new System.Drawing.Point(716, 7);
            this.lueZipper_color.Name = "lueZipper_color";
            this.lueZipper_color.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueZipper_color.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("clr_code", 30, "顏色代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("clr_cdesc", 80, "顏色描述")});
            this.lueZipper_color.Properties.DropDownRows = 12;
            this.lueZipper_color.Properties.NullText = "";
            this.lueZipper_color.Properties.PopupWidth = 120;
            this.lueZipper_color.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lueZipper_color.Size = new System.Drawing.Size(114, 20);
            this.lueZipper_color.TabIndex = 7;
            this.lueZipper_color.EditValueChanged += new System.EventHandler(this.lueZipper_color_EditValueChanged);
            // 
            // lblZipper_color
            // 
            this.lblZipper_color.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblZipper_color.Location = new System.Drawing.Point(657, 10);
            this.lblZipper_color.Name = "lblZipper_color";
            this.lblZipper_color.Size = new System.Drawing.Size(52, 14);
            this.lblZipper_color.TabIndex = 4;
            this.lblZipper_color.Text = "鏈齒顏色:";
            // 
            // lueZipper_tooth
            // 
            this.lueZipper_tooth.Location = new System.Drawing.Point(467, 7);
            this.lueZipper_tooth.Name = "lueZipper_tooth";
            this.lueZipper_tooth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueZipper_tooth.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 30, "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 80, "描述")});
            this.lueZipper_tooth.Properties.NullText = "";
            this.lueZipper_tooth.Properties.PopupWidth = 120;
            this.lueZipper_tooth.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lueZipper_tooth.Size = new System.Drawing.Size(151, 20);
            this.lueZipper_tooth.TabIndex = 7;
            // 
            // lblZipper_tooth
            // 
            this.lblZipper_tooth.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblZipper_tooth.Location = new System.Drawing.Point(410, 10);
            this.lblZipper_tooth.Name = "lblZipper_tooth";
            this.lblZipper_tooth.Size = new System.Drawing.Size(52, 14);
            this.lblZipper_tooth.TabIndex = 4;
            this.lblZipper_tooth.Text = "鏈牙款式:";
            // 
            // lueNaked_select
            // 
            this.lueNaked_select.Location = new System.Drawing.Point(64, 7);
            this.lueNaked_select.Name = "lueNaked_select";
            this.lueNaked_select.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueNaked_select.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 30, "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 80, "描述")});
            this.lueNaked_select.Properties.NullText = "";
            this.lueNaked_select.Properties.PopupWidth = 120;
            this.lueNaked_select.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lueNaked_select.Size = new System.Drawing.Size(100, 20);
            this.lueNaked_select.TabIndex = 7;
            this.lueNaked_select.EditValueChanged += new System.EventHandler(this.lueNaked_select_EditValueChanged);
            // 
            // lblZipper_color_rmk
            // 
            this.lblZipper_color_rmk.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblZipper_color_rmk.Location = new System.Drawing.Point(1063, 10);
            this.lblZipper_color_rmk.Name = "lblZipper_color_rmk";
            this.lblZipper_color_rmk.Size = new System.Drawing.Size(178, 14);
            this.lblZipper_color_rmk.TabIndex = 4;
            this.lblZipper_color_rmk.Text = "(注：彩牙不建議做在歐牙款上。)";
            // 
            // lblNaked_select
            // 
            this.lblNaked_select.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblNaked_select.Location = new System.Drawing.Point(6, 10);
            this.lblNaked_select.Name = "lblNaked_select";
            this.lblNaked_select.Size = new System.Drawing.Size(52, 14);
            this.lblNaked_select.TabIndex = 4;
            this.lblNaked_select.Text = "光身選擇:";
            // 
            // txtZipper_color_oth
            // 
            this.txtZipper_color_oth.Location = new System.Drawing.Point(844, 7);
            this.txtZipper_color_oth.Name = "txtZipper_color_oth";
            this.txtZipper_color_oth.Size = new System.Drawing.Size(213, 20);
            this.txtZipper_color_oth.TabIndex = 5;
            // 
            // palAll1
            // 
            this.palAll1.Controls.Add(this.luePull_card_color_id);
            this.palAll1.Controls.Add(this.txtPull_card_no);
            this.palAll1.Controls.Add(this.txtSequence_id);
            this.palAll1.Controls.Add(this.lblMo_id);
            this.palAll1.Controls.Add(this.txtMo_id);
            this.palAll1.Controls.Add(this.lueManu_craft_group);
            this.palAll1.Controls.Add(this.lblSequence_id);
            this.palAll1.Controls.Add(this.luePrd_process_id1);
            this.palAll1.Controls.Add(this.luePrd_process_id);
            this.palAll1.Controls.Add(this.lblSpec_oth);
            this.palAll1.Controls.Add(this.lueManu_craft_id);
            this.palAll1.Controls.Add(this.txtSpec_oth);
            this.palAll1.Controls.Add(this.lblSpec_id);
            this.palAll1.Controls.Add(this.lblMat);
            this.palAll1.Controls.Add(this.lueSpec_id);
            this.palAll1.Controls.Add(this.lblPull_card_color);
            this.palAll1.Controls.Add(this.lueMat_type);
            this.palAll1.Controls.Add(this.lblGoods_id);
            this.palAll1.Controls.Add(this.lblColor);
            this.palAll1.Controls.Add(this.lblPull_card_no);
            this.palAll1.Controls.Add(this.lueZipper_head);
            this.palAll1.Controls.Add(this.labelControl1);
            this.palAll1.Controls.Add(this.lblPrd_process_oth);
            this.palAll1.Controls.Add(this.lblCust_goods_style);
            this.palAll1.Controls.Add(this.lblManu_craft_oth);
            this.palAll1.Controls.Add(this.lblManu_craft);
            this.palAll1.Controls.Add(this.lueGoods_unit);
            this.palAll1.Controls.Add(this.labelControl2);
            this.palAll1.Controls.Add(this.lblPrd_process_color);
            this.palAll1.Controls.Add(this.lblPrd_Pprocess_dp);
            this.palAll1.Controls.Add(this.lblPrd_Pprocess_up);
            this.palAll1.Controls.Add(this.lblPrd_Pprocess);
            this.palAll1.Controls.Add(this.lblColor_Oth);
            this.palAll1.Controls.Add(this.lblZipperHead);
            this.palAll1.Controls.Add(this.lblColor_Y);
            this.palAll1.Controls.Add(this.lblZipperHead_oth);
            this.palAll1.Controls.Add(this.lblColor_C);
            this.palAll1.Controls.Add(this.txtPrd_seq);
            this.palAll1.Controls.Add(this.txtSample_qty);
            this.palAll1.Controls.Add(this.txtPull_card_color);
            this.palAll1.Controls.Add(this.txtOrder_qty);
            this.palAll1.Controls.Add(this.txtZipper_head_oth);
            this.palAll1.Controls.Add(this.txtPrd_process_oth1);
            this.palAll1.Controls.Add(this.txtPrd_process_oth);
            this.palAll1.Controls.Add(this.txtCust_goods_style);
            this.palAll1.Controls.Add(this.txtManu_craft_oth);
            this.palAll1.Controls.Add(this.txtManu_craft_cdesc);
            this.palAll1.Controls.Add(this.txtGoods_id);
            this.palAll1.Controls.Add(this.lblPrd_seq_info);
            this.palAll1.Controls.Add(this.lblPrd_seq);
            this.palAll1.Controls.Add(this.txtPrd_process_cdesc1);
            this.palAll1.Controls.Add(this.txtPrd_process_cdesc);
            this.palAll1.Controls.Add(this.txtPrd_process_color1);
            this.palAll1.Controls.Add(this.lblSample_qty);
            this.palAll1.Controls.Add(this.txtPrd_process_color);
            this.palAll1.Controls.Add(this.lblGoods_unit);
            this.palAll1.Controls.Add(this.lblOrder_qty);
            this.palAll1.Controls.Add(this.txtColor_C);
            this.palAll1.Controls.Add(this.txtColor_Y);
            this.palAll1.Controls.Add(this.txtColor_oth);
            this.palAll1.Dock = System.Windows.Forms.DockStyle.Top;
            this.palAll1.Location = new System.Drawing.Point(0, 0);
            this.palAll1.Name = "palAll1";
            this.palAll1.Size = new System.Drawing.Size(1177, 188);
            this.palAll1.TabIndex = 9;
            // 
            // luePull_card_color_id
            // 
            this.luePull_card_color_id.Location = new System.Drawing.Point(716, 157);
            this.luePull_card_color_id.Name = "luePull_card_color_id";
            this.luePull_card_color_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePull_card_color_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("clr_code", 40, "顏色代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("clr_cdesc", 120, "顏色描述")});
            this.luePull_card_color_id.Properties.NullText = "";
            this.luePull_card_color_id.Size = new System.Drawing.Size(114, 20);
            this.luePull_card_color_id.TabIndex = 8;
            this.luePull_card_color_id.EditValueChanged += new System.EventHandler(this.luePull_card_color_id_EditValueChanged);
            // 
            // txtPull_card_no
            // 
            this.txtPull_card_no.Location = new System.Drawing.Point(467, 157);
            this.txtPull_card_no.Name = "txtPull_card_no";
            this.txtPull_card_no.Size = new System.Drawing.Size(151, 20);
            this.txtPull_card_no.TabIndex = 5;
            // 
            // txtSequence_id
            // 
            this.txtSequence_id.Location = new System.Drawing.Point(64, 5);
            this.txtSequence_id.Name = "txtSequence_id";
            this.txtSequence_id.Properties.ReadOnly = true;
            this.txtSequence_id.Size = new System.Drawing.Size(100, 20);
            this.txtSequence_id.TabIndex = 1;
            // 
            // lblMo_id
            // 
            this.lblMo_id.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblMo_id.Location = new System.Drawing.Point(410, 8);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(52, 14);
            this.lblMo_id.TabIndex = 0;
            this.lblMo_id.Text = "制單編號:";
            // 
            // txtMo_id
            // 
            this.txtMo_id.Location = new System.Drawing.Point(467, 5);
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id.Properties.MaxLength = 9;
            this.txtMo_id.Properties.ReadOnly = true;
            this.txtMo_id.Size = new System.Drawing.Size(151, 20);
            this.txtMo_id.TabIndex = 1;
            this.txtMo_id.Leave += new System.EventHandler(this.txtMo_id_Leave);
            // 
            // lueManu_craft_group
            // 
            this.lueManu_craft_group.Location = new System.Drawing.Point(64, 81);
            this.lueManu_craft_group.Name = "lueManu_craft_group";
            this.lueManu_craft_group.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueManu_craft_group.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 60, "描述")});
            this.lueManu_craft_group.Properties.NullText = "";
            this.lueManu_craft_group.Size = new System.Drawing.Size(100, 20);
            this.lueManu_craft_group.TabIndex = 7;
            this.lueManu_craft_group.EditValueChanged += new System.EventHandler(this.lueManu_craft_group_EditValueChanged);
            // 
            // lblSequence_id
            // 
            this.lblSequence_id.Location = new System.Drawing.Point(30, 8);
            this.lblSequence_id.Name = "lblSequence_id";
            this.lblSequence_id.Size = new System.Drawing.Size(28, 14);
            this.lblSequence_id.TabIndex = 0;
            this.lblSequence_id.Text = "序號:";
            // 
            // luePrd_process_id1
            // 
            this.luePrd_process_id1.Location = new System.Drawing.Point(164, 131);
            this.luePrd_process_id1.Name = "luePrd_process_id1";
            this.luePrd_process_id1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePrd_process_id1.Properties.NullText = "";
            this.luePrd_process_id1.Size = new System.Drawing.Size(95, 20);
            this.luePrd_process_id1.TabIndex = 7;
            this.luePrd_process_id1.EditValueChanged += new System.EventHandler(this.luePrd_process_id1_EditValueChanged);
            // 
            // luePrd_process_id
            // 
            this.luePrd_process_id.Location = new System.Drawing.Point(164, 105);
            this.luePrd_process_id.Name = "luePrd_process_id";
            this.luePrd_process_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePrd_process_id.Properties.NullText = "";
            this.luePrd_process_id.Size = new System.Drawing.Size(95, 20);
            this.luePrd_process_id.TabIndex = 7;
            this.luePrd_process_id.EditValueChanged += new System.EventHandler(this.luePrd_process_id_EditValueChanged);
            // 
            // lblSpec_oth
            // 
            this.lblSpec_oth.Location = new System.Drawing.Point(207, 31);
            this.lblSpec_oth.Name = "lblSpec_oth";
            this.lblSpec_oth.Size = new System.Drawing.Size(52, 14);
            this.lblSpec_oth.TabIndex = 0;
            this.lblSpec_oth.Text = "其它規格:";
            // 
            // lueManu_craft_id
            // 
            this.lueManu_craft_id.Location = new System.Drawing.Point(164, 81);
            this.lueManu_craft_id.Name = "lueManu_craft_id";
            this.lueManu_craft_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueManu_craft_id.Properties.NullText = "";
            this.lueManu_craft_id.Size = new System.Drawing.Size(95, 20);
            this.lueManu_craft_id.TabIndex = 7;
            this.lueManu_craft_id.EditValueChanged += new System.EventHandler(this.lueManu_craft_id_EditValueChanged);
            // 
            // txtSpec_oth
            // 
            this.txtSpec_oth.Location = new System.Drawing.Point(265, 29);
            this.txtSpec_oth.Name = "txtSpec_oth";
            this.txtSpec_oth.Properties.ReadOnly = true;
            this.txtSpec_oth.Size = new System.Drawing.Size(119, 20);
            this.txtSpec_oth.TabIndex = 1;
            // 
            // lblSpec_id
            // 
            this.lblSpec_id.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblSpec_id.Location = new System.Drawing.Point(30, 31);
            this.lblSpec_id.Name = "lblSpec_id";
            this.lblSpec_id.Size = new System.Drawing.Size(28, 14);
            this.lblSpec_id.TabIndex = 2;
            this.lblSpec_id.Text = "規格:";
            // 
            // lblMat
            // 
            this.lblMat.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblMat.Location = new System.Drawing.Point(231, 8);
            this.lblMat.Name = "lblMat";
            this.lblMat.Size = new System.Drawing.Size(28, 14);
            this.lblMat.TabIndex = 2;
            this.lblMat.Text = "質地:";
            // 
            // lueSpec_id
            // 
            this.lueSpec_id.Location = new System.Drawing.Point(64, 29);
            this.lueSpec_id.Name = "lueSpec_id";
            this.lueSpec_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSpec_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 60, "描述")});
            this.lueSpec_id.Properties.NullText = "";
            this.lueSpec_id.Properties.ReadOnly = true;
            this.lueSpec_id.Size = new System.Drawing.Size(100, 20);
            this.lueSpec_id.TabIndex = 3;
            // 
            // lblPull_card_color
            // 
            this.lblPull_card_color.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblPull_card_color.Location = new System.Drawing.Point(625, 160);
            this.lblPull_card_color.Name = "lblPull_card_color";
            this.lblPull_card_color.Size = new System.Drawing.Size(84, 14);
            this.lblPull_card_color.TabIndex = 6;
            this.lblPull_card_color.Text = "拉頭+拉片顏色:";
            // 
            // lueMat_type
            // 
            this.lueMat_type.Location = new System.Drawing.Point(265, 5);
            this.lueMat_type.Name = "lueMat_type";
            this.lueMat_type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMat_type.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("mat_code", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("mat_cdesc", 60, "描述")});
            this.lueMat_type.Properties.NullText = "";
            this.lueMat_type.Properties.ReadOnly = true;
            this.lueMat_type.Size = new System.Drawing.Size(119, 20);
            this.lueMat_type.TabIndex = 3;
            this.lueMat_type.EditValueChanged += new System.EventHandler(this.lueMat_type_EditValueChanged);
            // 
            // lblGoods_id
            // 
            this.lblGoods_id.Location = new System.Drawing.Point(410, 31);
            this.lblGoods_id.Name = "lblGoods_id";
            this.lblGoods_id.Size = new System.Drawing.Size(52, 14);
            this.lblGoods_id.TabIndex = 6;
            this.lblGoods_id.Text = "成品編號:";
            // 
            // lblColor
            // 
            this.lblColor.Location = new System.Drawing.Point(6, 58);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(124, 14);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "布帶、布膠及鏈齒顏色:";
            // 
            // lblPull_card_no
            // 
            this.lblPull_card_no.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblPull_card_no.Location = new System.Drawing.Point(410, 160);
            this.lblPull_card_no.Name = "lblPull_card_no";
            this.lblPull_card_no.Size = new System.Drawing.Size(52, 14);
            this.lblPull_card_no.TabIndex = 6;
            this.lblPull_card_no.Text = "拉片編號:";
            // 
            // lueZipper_head
            // 
            this.lueZipper_head.Location = new System.Drawing.Point(64, 157);
            this.lueZipper_head.Name = "lueZipper_head";
            this.lueZipper_head.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueZipper_head.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 30, "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 80, "描述")});
            this.lueZipper_head.Properties.NullText = "";
            this.lueZipper_head.Properties.PopupWidth = 120;
            this.lueZipper_head.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lueZipper_head.Size = new System.Drawing.Size(100, 20);
            this.lueZipper_head.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(848, 133);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "特殊做法:";
            // 
            // lblPrd_process_oth
            // 
            this.lblPrd_process_oth.Location = new System.Drawing.Point(848, 111);
            this.lblPrd_process_oth.Name = "lblPrd_process_oth";
            this.lblPrd_process_oth.Size = new System.Drawing.Size(52, 14);
            this.lblPrd_process_oth.TabIndex = 4;
            this.lblPrd_process_oth.Text = "特殊做法:";
            // 
            // lblCust_goods_style
            // 
            this.lblCust_goods_style.Location = new System.Drawing.Point(847, 84);
            this.lblCust_goods_style.Name = "lblCust_goods_style";
            this.lblCust_goods_style.Size = new System.Drawing.Size(52, 14);
            this.lblCust_goods_style.TabIndex = 4;
            this.lblCust_goods_style.Text = "客人款號:";
            // 
            // lblManu_craft_oth
            // 
            this.lblManu_craft_oth.Location = new System.Drawing.Point(657, 84);
            this.lblManu_craft_oth.Name = "lblManu_craft_oth";
            this.lblManu_craft_oth.Size = new System.Drawing.Size(52, 14);
            this.lblManu_craft_oth.TabIndex = 4;
            this.lblManu_craft_oth.Text = "特殊做法:";
            // 
            // lblManu_craft
            // 
            this.lblManu_craft.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblManu_craft.Location = new System.Drawing.Point(6, 84);
            this.lblManu_craft.Name = "lblManu_craft";
            this.lblManu_craft.Size = new System.Drawing.Size(52, 14);
            this.lblManu_craft.TabIndex = 4;
            this.lblManu_craft.Text = "制作工藝:";
            // 
            // lueGoods_unit
            // 
            this.lueGoods_unit.Location = new System.Drawing.Point(906, 5);
            this.lueGoods_unit.Name = "lueGoods_unit";
            this.lueGoods_unit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoods_unit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", 60, "描述")});
            this.lueGoods_unit.Properties.NullText = "";
            this.lueGoods_unit.Size = new System.Drawing.Size(151, 20);
            this.lueGoods_unit.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(681, 133);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "色號:";
            // 
            // lblPrd_process_color
            // 
            this.lblPrd_process_color.Location = new System.Drawing.Point(681, 111);
            this.lblPrd_process_color.Name = "lblPrd_process_color";
            this.lblPrd_process_color.Size = new System.Drawing.Size(28, 14);
            this.lblPrd_process_color.TabIndex = 4;
            this.lblPrd_process_color.Text = "色號:";
            // 
            // lblPrd_Pprocess_dp
            // 
            this.lblPrd_Pprocess_dp.Location = new System.Drawing.Point(130, 133);
            this.lblPrd_Pprocess_dp.Name = "lblPrd_Pprocess_dp";
            this.lblPrd_Pprocess_dp.Size = new System.Drawing.Size(28, 14);
            this.lblPrd_Pprocess_dp.TabIndex = 4;
            this.lblPrd_Pprocess_dp.Text = "下止:";
            // 
            // lblPrd_Pprocess_up
            // 
            this.lblPrd_Pprocess_up.Location = new System.Drawing.Point(130, 111);
            this.lblPrd_Pprocess_up.Name = "lblPrd_Pprocess_up";
            this.lblPrd_Pprocess_up.Size = new System.Drawing.Size(28, 14);
            this.lblPrd_Pprocess_up.TabIndex = 4;
            this.lblPrd_Pprocess_up.Text = "上止:";
            // 
            // lblPrd_Pprocess
            // 
            this.lblPrd_Pprocess.Location = new System.Drawing.Point(6, 104);
            this.lblPrd_Pprocess.Name = "lblPrd_Pprocess";
            this.lblPrd_Pprocess.Size = new System.Drawing.Size(52, 14);
            this.lblPrd_Pprocess.TabIndex = 4;
            this.lblPrd_Pprocess.Text = "制作工序:";
            // 
            // lblColor_Oth
            // 
            this.lblColor_Oth.Location = new System.Drawing.Point(657, 58);
            this.lblColor_Oth.Name = "lblColor_Oth";
            this.lblColor_Oth.Size = new System.Drawing.Size(52, 14);
            this.lblColor_Oth.TabIndex = 6;
            this.lblColor_Oth.Text = "其它顏色:";
            // 
            // lblZipperHead
            // 
            this.lblZipperHead.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblZipperHead.Location = new System.Drawing.Point(30, 160);
            this.lblZipperHead.Name = "lblZipperHead";
            this.lblZipperHead.Size = new System.Drawing.Size(28, 14);
            this.lblZipperHead.TabIndex = 4;
            this.lblZipperHead.Text = "拉頭:";
            // 
            // lblColor_Y
            // 
            this.lblColor_Y.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblColor_Y.Location = new System.Drawing.Point(390, 58);
            this.lblColor_Y.Name = "lblColor_Y";
            this.lblColor_Y.Size = new System.Drawing.Size(72, 14);
            this.lblColor_Y.TabIndex = 6;
            this.lblColor_Y.Text = "Y卡顏色編號:";
            // 
            // lblZipperHead_oth
            // 
            this.lblZipperHead_oth.Location = new System.Drawing.Point(183, 160);
            this.lblZipperHead_oth.Name = "lblZipperHead_oth";
            this.lblZipperHead_oth.Size = new System.Drawing.Size(76, 14);
            this.lblZipperHead_oth.TabIndex = 4;
            this.lblZipperHead_oth.Text = "其它特殊拉頭:";
            // 
            // lblColor_C
            // 
            this.lblColor_C.Location = new System.Drawing.Point(188, 58);
            this.lblColor_C.Name = "lblColor_C";
            this.lblColor_C.Size = new System.Drawing.Size(71, 14);
            this.lblColor_C.TabIndex = 6;
            this.lblColor_C.Text = "C卡顏色編號:";
            // 
            // txtPrd_seq
            // 
            this.txtPrd_seq.Location = new System.Drawing.Point(906, 28);
            this.txtPrd_seq.Name = "txtPrd_seq";
            this.txtPrd_seq.Properties.ReadOnly = true;
            this.txtPrd_seq.Size = new System.Drawing.Size(151, 20);
            this.txtPrd_seq.TabIndex = 5;
            // 
            // txtSample_qty
            // 
            this.txtSample_qty.Location = new System.Drawing.Point(716, 29);
            this.txtSample_qty.Name = "txtSample_qty";
            this.txtSample_qty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSample_qty.Size = new System.Drawing.Size(114, 20);
            this.txtSample_qty.TabIndex = 5;
            // 
            // txtPull_card_color
            // 
            this.txtPull_card_color.Location = new System.Drawing.Point(844, 157);
            this.txtPull_card_color.Name = "txtPull_card_color";
            this.txtPull_card_color.Size = new System.Drawing.Size(213, 20);
            this.txtPull_card_color.TabIndex = 5;
            // 
            // txtOrder_qty
            // 
            this.txtOrder_qty.Location = new System.Drawing.Point(716, 5);
            this.txtOrder_qty.Name = "txtOrder_qty";
            this.txtOrder_qty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOrder_qty.Size = new System.Drawing.Size(114, 20);
            this.txtOrder_qty.TabIndex = 5;
            // 
            // txtZipper_head_oth
            // 
            this.txtZipper_head_oth.Location = new System.Drawing.Point(265, 157);
            this.txtZipper_head_oth.Name = "txtZipper_head_oth";
            this.txtZipper_head_oth.Size = new System.Drawing.Size(119, 20);
            this.txtZipper_head_oth.TabIndex = 5;
            // 
            // txtPrd_process_oth1
            // 
            this.txtPrd_process_oth1.Location = new System.Drawing.Point(906, 131);
            this.txtPrd_process_oth1.Name = "txtPrd_process_oth1";
            this.txtPrd_process_oth1.Size = new System.Drawing.Size(151, 20);
            this.txtPrd_process_oth1.TabIndex = 5;
            // 
            // txtPrd_process_oth
            // 
            this.txtPrd_process_oth.Location = new System.Drawing.Point(906, 105);
            this.txtPrd_process_oth.Name = "txtPrd_process_oth";
            this.txtPrd_process_oth.Size = new System.Drawing.Size(151, 20);
            this.txtPrd_process_oth.TabIndex = 5;
            // 
            // txtCust_goods_style
            // 
            this.txtCust_goods_style.Location = new System.Drawing.Point(906, 81);
            this.txtCust_goods_style.Name = "txtCust_goods_style";
            this.txtCust_goods_style.Size = new System.Drawing.Size(151, 20);
            this.txtCust_goods_style.TabIndex = 5;
            // 
            // txtManu_craft_oth
            // 
            this.txtManu_craft_oth.Location = new System.Drawing.Point(716, 81);
            this.txtManu_craft_oth.Name = "txtManu_craft_oth";
            this.txtManu_craft_oth.Size = new System.Drawing.Size(114, 20);
            this.txtManu_craft_oth.TabIndex = 5;
            // 
            // txtManu_craft_cdesc
            // 
            this.txtManu_craft_cdesc.Location = new System.Drawing.Point(265, 81);
            this.txtManu_craft_cdesc.Name = "txtManu_craft_cdesc";
            this.txtManu_craft_cdesc.Size = new System.Drawing.Size(354, 20);
            this.txtManu_craft_cdesc.TabIndex = 5;
            // 
            // txtGoods_id
            // 
            this.txtGoods_id.Location = new System.Drawing.Point(468, 29);
            this.txtGoods_id.Name = "txtGoods_id";
            this.txtGoods_id.Size = new System.Drawing.Size(151, 20);
            this.txtGoods_id.TabIndex = 5;
            // 
            // lblPrd_seq_info
            // 
            this.lblPrd_seq_info.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblPrd_seq_info.Location = new System.Drawing.Point(847, 50);
            this.lblPrd_seq_info.Name = "lblPrd_seq_info";
            this.lblPrd_seq_info.Size = new System.Drawing.Size(274, 14);
            this.lblPrd_seq_info.TabIndex = 6;
            this.lblPrd_seq_info.Text = "(落單後,請將\"產品序號\"填入到訂單的\"畫稿編號\"中)";
            // 
            // lblPrd_seq
            // 
            this.lblPrd_seq.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblPrd_seq.Location = new System.Drawing.Point(847, 30);
            this.lblPrd_seq.Name = "lblPrd_seq";
            this.lblPrd_seq.Size = new System.Drawing.Size(52, 14);
            this.lblPrd_seq.TabIndex = 6;
            this.lblPrd_seq.Text = "產品序號:";
            // 
            // txtPrd_process_cdesc1
            // 
            this.txtPrd_process_cdesc1.Location = new System.Drawing.Point(265, 131);
            this.txtPrd_process_cdesc1.Name = "txtPrd_process_cdesc1";
            this.txtPrd_process_cdesc1.Size = new System.Drawing.Size(354, 20);
            this.txtPrd_process_cdesc1.TabIndex = 5;
            // 
            // txtPrd_process_cdesc
            // 
            this.txtPrd_process_cdesc.Location = new System.Drawing.Point(265, 105);
            this.txtPrd_process_cdesc.Name = "txtPrd_process_cdesc";
            this.txtPrd_process_cdesc.Size = new System.Drawing.Size(354, 20);
            this.txtPrd_process_cdesc.TabIndex = 5;
            // 
            // txtPrd_process_color1
            // 
            this.txtPrd_process_color1.Location = new System.Drawing.Point(716, 131);
            this.txtPrd_process_color1.Name = "txtPrd_process_color1";
            this.txtPrd_process_color1.Size = new System.Drawing.Size(114, 20);
            this.txtPrd_process_color1.TabIndex = 5;
            // 
            // lblSample_qty
            // 
            this.lblSample_qty.Location = new System.Drawing.Point(657, 31);
            this.lblSample_qty.Name = "lblSample_qty";
            this.lblSample_qty.Size = new System.Drawing.Size(52, 14);
            this.lblSample_qty.TabIndex = 6;
            this.lblSample_qty.Text = "樣品數量:";
            // 
            // txtPrd_process_color
            // 
            this.txtPrd_process_color.Location = new System.Drawing.Point(716, 105);
            this.txtPrd_process_color.Name = "txtPrd_process_color";
            this.txtPrd_process_color.Size = new System.Drawing.Size(114, 20);
            this.txtPrd_process_color.TabIndex = 5;
            // 
            // lblGoods_unit
            // 
            this.lblGoods_unit.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblGoods_unit.Location = new System.Drawing.Point(849, 8);
            this.lblGoods_unit.Name = "lblGoods_unit";
            this.lblGoods_unit.Size = new System.Drawing.Size(52, 14);
            this.lblGoods_unit.TabIndex = 6;
            this.lblGoods_unit.Text = "數量單位:";
            // 
            // lblOrder_qty
            // 
            this.lblOrder_qty.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblOrder_qty.Location = new System.Drawing.Point(657, 8);
            this.lblOrder_qty.Name = "lblOrder_qty";
            this.lblOrder_qty.Size = new System.Drawing.Size(52, 14);
            this.lblOrder_qty.TabIndex = 6;
            this.lblOrder_qty.Text = "訂單數量:";
            // 
            // txtColor_C
            // 
            this.txtColor_C.Location = new System.Drawing.Point(265, 55);
            this.txtColor_C.Name = "txtColor_C";
            this.txtColor_C.Size = new System.Drawing.Size(119, 20);
            this.txtColor_C.TabIndex = 5;
            // 
            // txtColor_Y
            // 
            this.txtColor_Y.Location = new System.Drawing.Point(467, 55);
            this.txtColor_Y.Name = "txtColor_Y";
            this.txtColor_Y.Size = new System.Drawing.Size(151, 20);
            this.txtColor_Y.TabIndex = 5;
            // 
            // txtColor_oth
            // 
            this.txtColor_oth.Location = new System.Drawing.Point(716, 55);
            this.txtColor_oth.Name = "txtColor_oth";
            this.txtColor_oth.Size = new System.Drawing.Size(114, 20);
            this.txtColor_oth.TabIndex = 5;
            // 
            // txtPrd_remark
            // 
            this.txtPrd_remark.Location = new System.Drawing.Point(64, 106);
            this.txtPrd_remark.Name = "txtPrd_remark";
            this.txtPrd_remark.Properties.ReadOnly = true;
            this.txtPrd_remark.Size = new System.Drawing.Size(771, 43);
            this.txtPrd_remark.TabIndex = 12;
            // 
            // frmZipperOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 686);
            this.Controls.Add(this.xtbControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmZipperOrder";
            this.Text = "frmZiperOrder";
            this.Load += new System.EventHandler(this.frmZipperOrder_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtbControl1)).EndInit();
            this.xtbControl1.ResumeLayout(false);
            this.xtbPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrusr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust_po.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIt_customer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrder_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoGroup.Properties)).EndInit();
            this.xtbPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palAll2)).EndInit();
            this.palAll2.ResumeLayout(false);
            this.palAll2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNoMagTest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSize_unit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize_diff_oth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePrd_use.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPack_type_oth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWash_type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWash_type_oth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePack_type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize_cm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSize_diff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize_inc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTest_std.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCloth_type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTest_std_cdesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_use_oth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palMe)).EndInit();
            this.palMe.ResumeLayout(false);
            this.palMe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNaked_cdesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueZipper_color.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueZipper_tooth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNaked_select.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZipper_color_oth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palAll1)).EndInit();
            this.palAll1.ResumeLayout(false);
            this.palAll1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luePull_card_color_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPull_card_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSequence_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueManu_craft_group.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePrd_process_id1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePrd_process_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueManu_craft_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpec_oth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSpec_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMat_type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueZipper_head.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoods_unit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_seq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSample_qty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPull_card_color.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrder_qty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZipper_head_oth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_process_oth1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_process_oth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust_goods_style.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManu_craft_oth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManu_craft_cdesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_process_cdesc1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_process_cdesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_process_color1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_process_color.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor_C.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor_Y.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor_oth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_remark.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private DevExpress.XtraTab.XtraTabControl xtbControl1;
        private DevExpress.XtraTab.XtraTabPage xtbPage1;
        private DevExpress.XtraTab.XtraTabPage xtbPage2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl lblId;
        private DevExpress.XtraEditors.TextEdit txtOrder_date;
        private DevExpress.XtraEditors.LabelControl lblOrder_date;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraEditors.TextEdit txtIt_customer;
        private DevExpress.XtraEditors.LabelControl lblIt_customer;
        private DevExpress.XtraEditors.TextEdit txtCust_name;
        private DevExpress.XtraEditors.LabelControl lblCust_name;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private DevExpress.XtraGrid.GridControl gcDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetails;
        private DevExpress.XtraEditors.TextEdit txtSequence_id;
        private DevExpress.XtraEditors.LabelControl lblSequence_id;
        private DevExpress.XtraEditors.TextEdit txtMo_id;
        private DevExpress.XtraEditors.LabelControl lblMo_id;
        private DevExpress.XtraEditors.TextEdit txtSpec_oth;
        private DevExpress.XtraEditors.LabelControl lblSpec_oth;
        private DevExpress.XtraEditors.LookUpEdit lueSpec_id;
        private DevExpress.XtraEditors.LabelControl lblSpec_id;
        private DevExpress.XtraEditors.LookUpEdit lueMat_type;
        private DevExpress.XtraEditors.LabelControl lblMat;
        private DevExpress.XtraEditors.LabelControl lblColor;
        private DevExpress.XtraEditors.LabelControl lblColor_Oth;
        private DevExpress.XtraEditors.LabelControl lblColor_Y;
        private DevExpress.XtraEditors.LabelControl lblColor_C;
        private DevExpress.XtraEditors.TextEdit txtColor_oth;
        private DevExpress.XtraEditors.TextEdit txtColor_Y;
        private DevExpress.XtraEditors.TextEdit txtColor_C;
        private DevExpress.XtraEditors.LabelControl lblManu_craft;
        private DevExpress.XtraEditors.LookUpEdit lueManu_craft_group;
        private DevExpress.XtraEditors.LookUpEdit lueManu_craft_id;
        private DevExpress.XtraEditors.TextEdit txtManu_craft_cdesc;
        private DevExpress.XtraEditors.LabelControl lblPrd_Pprocess;
        private DevExpress.XtraEditors.LookUpEdit luePrd_process_id;
        private DevExpress.XtraEditors.TextEdit txtPrd_process_cdesc;
        private DevExpress.XtraEditors.TextEdit txtPrd_process_color;
        private DevExpress.XtraEditors.LookUpEdit lueZipper_head;
        private DevExpress.XtraEditors.LabelControl lblZipperHead;
        private DevExpress.XtraEditors.TextEdit txtZipper_head_oth;
        private DevExpress.XtraEditors.LabelControl lblPull_card_color;
        private DevExpress.XtraEditors.LabelControl lblPull_card_no;
        private DevExpress.XtraEditors.TextEdit txtPull_card_color;
        private DevExpress.XtraEditors.TextEdit txtPull_card_no;
        private DevExpress.XtraEditors.LabelControl lblGoods_id;
        private DevExpress.XtraEditors.TextEdit txtGoods_id;
        private DevExpress.XtraEditors.LookUpEdit lueTest_std;
        private DevExpress.XtraEditors.LabelControl lblTestStd;
        private DevExpress.XtraEditors.TextEdit txtTest_std_cdesc;
        private DevExpress.XtraEditors.LookUpEdit luePrd_use;
        private DevExpress.XtraEditors.TextEdit txtPrd_use_oth;
        private DevExpress.XtraEditors.LabelControl lblCloth;
        private DevExpress.XtraEditors.TextEdit txtCloth_type;
        private DevExpress.XtraEditors.LabelControl lblOrder_qty;
        private DevExpress.XtraEditors.TextEdit txtOrder_qty;
        private DevExpress.XtraEditors.LookUpEdit lueGoods_unit;
        private DevExpress.XtraEditors.LabelControl lblSize_cm;
        private DevExpress.XtraEditors.LabelControl lblSize;
        private DevExpress.XtraEditors.TextEdit txtSize_cm;
        private DevExpress.XtraEditors.LabelControl lblSize_in;
        private DevExpress.XtraEditors.TextEdit txtSize_inc;
        private DevExpress.XtraEditors.LookUpEdit lueSize_diff;
        private DevExpress.XtraEditors.LabelControl lblSize_diff_oth;
        private DevExpress.XtraEditors.LabelControl lblSize_diff;
        private DevExpress.XtraEditors.TextEdit txtSize_diff_oth;
        private DevExpress.XtraEditors.LookUpEdit luePack_type;
        private DevExpress.XtraEditors.LabelControl lblPack;
        private DevExpress.XtraEditors.LabelControl lblPack_oth;
        private DevExpress.XtraEditors.TextEdit txtPack_type_oth;
        private DevExpress.XtraEditors.LookUpEdit lueWash_type;
        private DevExpress.XtraEditors.LabelControl lblWash_type;
        private DevExpress.XtraEditors.LabelControl lblWash_type_oth;
        private DevExpress.XtraEditors.TextEdit txtWash_type_oth;
        private DevExpress.XtraEditors.LabelControl lblZipperHead_oth;
        private DevExpress.XtraEditors.PanelControl palMe;
        private DevExpress.XtraEditors.LookUpEdit lueNaked_select;
        private DevExpress.XtraEditors.LabelControl lblNaked_select;
        private DevExpress.XtraEditors.LabelControl lblPrd_use_oth;
        private DevExpress.XtraEditors.LookUpEdit lueZipper_tooth;
        private DevExpress.XtraEditors.LabelControl lblZipper_tooth;
        private DevExpress.XtraEditors.LookUpEdit lueZipper_color;
        private DevExpress.XtraEditors.LabelControl lblZipper_color;
        private DevExpress.XtraEditors.TextEdit txtZipper_color_oth;
        private DevExpress.XtraGrid.Columns.GridColumn colSequence_id;
        private DevExpress.XtraGrid.Columns.GridColumn colMo_id;
        private DevExpress.XtraEditors.PanelControl palAll1;
        private DevExpress.XtraEditors.PanelControl palAll2;
        private DevExpress.XtraGrid.Columns.GridColumn cloMat_type;
        private DevExpress.XtraGrid.Columns.GridColumn colGoods_id;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder_qty;
        private DevExpress.XtraGrid.Columns.GridColumn colGoods_unit;
        private DevExpress.XtraGrid.Columns.GridColumn colSpec_id;
        private DevExpress.XtraGrid.Columns.GridColumn colSpec_oth;
        private DevExpress.XtraGrid.Columns.GridColumn colColor_c;
        private DevExpress.XtraGrid.Columns.GridColumn colColor_y;
        private DevExpress.XtraGrid.Columns.GridColumn colColor_oth;
        private DevExpress.XtraGrid.Columns.GridColumn colManu_craft_group;
        private DevExpress.XtraGrid.Columns.GridColumn colManu_craft_id;
        private DevExpress.XtraGrid.Columns.GridColumn colManu_craft_cdesc;
        private DevExpress.XtraGrid.Columns.GridColumn colPrd_process_group;
        private DevExpress.XtraGrid.Columns.GridColumn colPrd_process_id;
        private DevExpress.XtraGrid.Columns.GridColumn colPrd_process_cdesc;
        private DevExpress.XtraGrid.Columns.GridColumn colZipper_head;
        private DevExpress.XtraGrid.Columns.GridColumn colZipper_head_oth;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private DevExpress.XtraEditors.LabelControl lblTest_std_cdesc;
        private DevExpress.XtraEditors.LabelControl lblPrd_use;
        private DevExpress.XtraEditors.TextEdit txtCust_po;
        private DevExpress.XtraEditors.LabelControl lblCust_po;
        private System.Windows.Forms.ToolStripButton btnConf;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private DevExpress.XtraEditors.LabelControl lblZipper_color_rmk;
        private DevExpress.XtraEditors.LabelControl lblManu_craft_oth;
        private DevExpress.XtraEditors.TextEdit txtManu_craft_oth;
        private DevExpress.XtraEditors.LabelControl lblPrd_process_oth;
        private DevExpress.XtraEditors.TextEdit txtPrd_process_oth;
        private DevExpress.XtraEditors.TextEdit txtRemark2;
        private DevExpress.XtraEditors.TextEdit txtRemark1;
        private DevExpress.XtraEditors.LabelControl lblRemark1;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private DevExpress.XtraEditors.TextEdit txtSample_qty;
        private DevExpress.XtraEditors.LabelControl lblSample_qty;
        private DevExpress.XtraEditors.LabelControl lblPrd_process_color;
        private DevExpress.XtraEditors.LabelControl lblRemark2;
        private DevExpress.XtraEditors.LabelControl lblGoods_unit;
        private DevExpress.XtraEditors.LookUpEdit lueMoGroup;
        private DevExpress.XtraEditors.LabelControl lblMoGroup;
        private DevExpress.XtraEditors.TextEdit txtPrd_seq;
        private DevExpress.XtraEditors.LabelControl lblPrd_seq;
        private DevExpress.XtraEditors.LabelControl lblPrd_seq_info;
        private System.Windows.Forms.ToolStripButton btnTran;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private DevExpress.XtraEditors.TextEdit txtNaked_cdesc;
        private DevExpress.XtraEditors.LabelControl lblCust_goods_style;
        private DevExpress.XtraEditors.TextEdit txtCust_goods_style;
        private DevExpress.XtraEditors.TextEdit txtCrtim;
        private DevExpress.XtraEditors.LabelControl lblCrtim;
        private DevExpress.XtraEditors.TextEdit txtCrusr;
        private DevExpress.XtraEditors.LabelControl lblCrusr;
        private DevExpress.XtraGrid.Columns.GridColumn colCrusr;
        private DevExpress.XtraGrid.Columns.GridColumn colCrtim;
        private System.Windows.Forms.ToolStripButton btnUpdateMo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private DevExpress.XtraEditors.LookUpEdit luePull_card_color_id;
        private DevExpress.XtraEditors.TextEdit txtSize;
        private DevExpress.XtraEditors.LookUpEdit lueSize_unit;
        private DevExpress.XtraEditors.LabelControl lblSize_unit;
        private DevExpress.XtraEditors.LookUpEdit luePrd_process_id1;
        private DevExpress.XtraEditors.TextEdit txtPrd_process_cdesc1;
        private DevExpress.XtraEditors.TextEdit txtPrd_process_color1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPrd_process_oth1;
        private DevExpress.XtraEditors.LabelControl lblPrd_Pprocess_dp;
        private DevExpress.XtraEditors.LabelControl lblPrd_Pprocess_up;
        private DevExpress.XtraEditors.CheckEdit chkNoMagTest;
        private DevExpress.XtraEditors.LabelControl lblPrd_remark;
        private DevExpress.XtraEditors.SimpleButton btnShowTest;
        private DevExpress.XtraEditors.MemoEdit txtPrd_remark;
    }
}