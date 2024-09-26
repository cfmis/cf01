namespace cf01.Forms
{
    partial class frmDgdInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDgdInvoice));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.lblId = new DevExpress.XtraEditors.LabelControl();
            this.lblIt_Customer = new DevExpress.XtraEditors.LabelControl();
            this.txtIt_Customer = new DevExpress.XtraEditors.TextEdit();
            this.lblSeparate = new DevExpress.XtraEditors.LabelControl();
            this.txtSeparate = new DevExpress.XtraEditors.TextEdit();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.lblFax = new DevExpress.XtraEditors.LabelControl();
            this.txtFax = new DevExpress.XtraEditors.TextEdit();
            this.lblLinkman = new DevExpress.XtraEditors.LabelControl();
            this.txtLinkman = new DevExpress.XtraEditors.TextEdit();
            this.lblL_phone = new DevExpress.XtraEditors.LabelControl();
            this.txtL_phone = new DevExpress.XtraEditors.TextEdit();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.lblIssues_wh = new DevExpress.XtraEditors.LabelControl();
            this.txtIssues_wh = new DevExpress.XtraEditors.TextEdit();
            this.lblBill_type_no = new DevExpress.XtraEditors.LabelControl();
            this.lblMerchandiser = new DevExpress.XtraEditors.LabelControl();
            this.txtMerchandiser_phone = new DevExpress.XtraEditors.TextEdit();
            this.lueMerchandiser = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMerchandiser_phone = new DevExpress.XtraEditors.LabelControl();
            this.lblPo_no = new DevExpress.XtraEditors.LabelControl();
            this.txtPo_no = new DevExpress.XtraEditors.TextEdit();
            this.lblShipping_methods = new DevExpress.XtraEditors.LabelControl();
            this.txtShipping_methods = new DevExpress.XtraEditors.TextEdit();
            this.lblSeller_id = new DevExpress.XtraEditors.LabelControl();
            this.lueSeller_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lblShip_date = new DevExpress.XtraEditors.LabelControl();
            this.txtShip_date = new DevExpress.XtraEditors.TextEdit();
            this.lueBill_type_no = new DevExpress.XtraEditors.LookUpEdit();
            this.lueM_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lblM_id = new DevExpress.XtraEditors.LabelControl();
            this.txtExchange_rate = new DevExpress.XtraEditors.TextEdit();
            this.lblExchange_rate = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dgvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colMo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoods_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustomer_goods = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer_color_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colU_invoice_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoods_unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSec_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSec_unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPackage_num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBox_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTable_head = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrder_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContract_cid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIs_print = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSo_sequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSo_ver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShipment_suit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colU_invoice_qty_pcs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLueGoods_id = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lblGoods_sum = new DevExpress.XtraEditors.LabelControl();
            this.txtGoods_sum = new DevExpress.XtraEditors.TextEdit();
            this.lblOther_fare = new DevExpress.XtraEditors.LabelControl();
            this.txtOther_fare = new DevExpress.XtraEditors.TextEdit();
            this.lblDisc_rate = new DevExpress.XtraEditors.LabelControl();
            this.txtDisc_rate = new DevExpress.XtraEditors.TextEdit();
            this.lblDisc_amt = new DevExpress.XtraEditors.LabelControl();
            this.txtDisc_amt = new DevExpress.XtraEditors.TextEdit();
            this.lblDisc_spare = new DevExpress.XtraEditors.LabelControl();
            this.txtDisc_spare = new DevExpress.XtraEditors.TextEdit();
            this.lblTotal_sum = new DevExpress.XtraEditors.LabelControl();
            this.txtTotal_sum = new DevExpress.XtraEditors.TextEdit();
            this.txtCust_name = new DevExpress.XtraEditors.TextEdit();
            this.txtFake_address = new DevExpress.XtraEditors.TextEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtbControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtbPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.xtbPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcIdDetails = new DevExpress.XtraGrid.GridControl();
            this.dgvIdDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId_chkSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colId_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Ship_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Sequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Mo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Goods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Goods_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_U_invoice_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Goods_unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Sec_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Sec_unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId_Order_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnImput = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtFindMo_id = new DevExpress.XtraEditors.TextEdit();
            this.lblFindMo_id = new DevExpress.XtraEditors.LabelControl();
            this.txtFindId = new DevExpress.XtraEditors.TextEdit();
            this.lblFindId = new DevExpress.XtraEditors.LabelControl();
            this.txtFindOc_no = new DevExpress.XtraEditors.TextEdit();
            this.lblFindOc_no = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.gcOcDgdDetails = new DevExpress.XtraGrid.GridControl();
            this.dgvOcDgdDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOc_Ship_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_Sequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_Mo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_Goods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_Goods_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_State = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_Order_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_Order_Goods_unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_U_invoice_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_Goods_unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_Sec_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_Sec_unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOc_Order_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIt_Customer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeparate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkman.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtL_phone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssues_wh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMerchandiser_phone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMerchandiser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPo_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipping_methods.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSeller_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShip_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBill_type_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueM_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchange_rate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colLueGoods_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_sum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOther_fare.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisc_rate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisc_amt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisc_spare.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal_sum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFake_address.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtbControl1)).BeginInit();
            this.xtbControl1.SuspendLayout();
            this.xtbPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.xtbPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindMo_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindOc_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOcDgdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcDgdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
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
            this.btnSave,
            this.toolStripSeparator4,
            this.btnDelete,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1308, 38);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 35);
            this.btnDelete.Text = "刪除(&D)";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(92, 18);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 0;
            this.txtId.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            this.txtId.Leave += new System.EventHandler(this.txtId_Leave);
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(20, 21);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(52, 14);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "單據編號:";
            // 
            // lblIt_Customer
            // 
            this.lblIt_Customer.Location = new System.Drawing.Point(20, 50);
            this.lblIt_Customer.Name = "lblIt_Customer";
            this.lblIt_Customer.Size = new System.Drawing.Size(52, 14);
            this.lblIt_Customer.TabIndex = 2;
            this.lblIt_Customer.Text = "客戶編號:";
            // 
            // txtIt_Customer
            // 
            this.txtIt_Customer.Location = new System.Drawing.Point(92, 49);
            this.txtIt_Customer.Name = "txtIt_Customer";
            this.txtIt_Customer.Size = new System.Drawing.Size(100, 20);
            this.txtIt_Customer.TabIndex = 3;
            this.txtIt_Customer.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            this.txtIt_Customer.Leave += new System.EventHandler(this.txtIt_Customer_Leave);
            // 
            // lblSeparate
            // 
            this.lblSeparate.Location = new System.Drawing.Point(470, 21);
            this.lblSeparate.Name = "lblSeparate";
            this.lblSeparate.Size = new System.Drawing.Size(28, 14);
            this.lblSeparate.TabIndex = 4;
            this.lblSeparate.Text = "來源:";
            // 
            // txtSeparate
            // 
            this.txtSeparate.Location = new System.Drawing.Point(509, 18);
            this.txtSeparate.Name = "txtSeparate";
            this.txtSeparate.Size = new System.Drawing.Size(100, 20);
            this.txtSeparate.TabIndex = 5;
            this.txtSeparate.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(255, 57);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(28, 14);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "電話:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(297, 49);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPhone.TabIndex = 7;
            this.txtPhone.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(470, 58);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(28, 14);
            this.lblFax.TabIndex = 8;
            this.lblFax.Text = "傳真:";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(509, 49);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(100, 20);
            this.txtFax.TabIndex = 9;
            this.txtFax.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblLinkman
            // 
            this.lblLinkman.Location = new System.Drawing.Point(32, 77);
            this.lblLinkman.Name = "lblLinkman";
            this.lblLinkman.Size = new System.Drawing.Size(40, 14);
            this.lblLinkman.TabIndex = 10;
            this.lblLinkman.Text = "聯繫人:";
            // 
            // txtLinkman
            // 
            this.txtLinkman.Location = new System.Drawing.Point(92, 75);
            this.txtLinkman.Name = "txtLinkman";
            this.txtLinkman.Size = new System.Drawing.Size(100, 20);
            this.txtLinkman.TabIndex = 11;
            this.txtLinkman.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblL_phone
            // 
            this.lblL_phone.Location = new System.Drawing.Point(219, 77);
            this.lblL_phone.Name = "lblL_phone";
            this.lblL_phone.Size = new System.Drawing.Size(64, 14);
            this.lblL_phone.TabIndex = 12;
            this.lblL_phone.Text = "聯繫人電話:";
            // 
            // txtL_phone
            // 
            this.txtL_phone.Location = new System.Drawing.Point(297, 75);
            this.txtL_phone.Name = "txtL_phone";
            this.txtL_phone.Size = new System.Drawing.Size(100, 20);
            this.txtL_phone.TabIndex = 13;
            this.txtL_phone.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(446, 79);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 14);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "電郵地址:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(509, 75);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 15;
            this.txtEmail.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblIssues_wh
            // 
            this.lblIssues_wh.Location = new System.Drawing.Point(20, 101);
            this.lblIssues_wh.Name = "lblIssues_wh";
            this.lblIssues_wh.Size = new System.Drawing.Size(52, 14);
            this.lblIssues_wh.TabIndex = 16;
            this.lblIssues_wh.Text = "出貨倉位:";
            // 
            // txtIssues_wh
            // 
            this.txtIssues_wh.Location = new System.Drawing.Point(92, 98);
            this.txtIssues_wh.Name = "txtIssues_wh";
            this.txtIssues_wh.Size = new System.Drawing.Size(100, 20);
            this.txtIssues_wh.TabIndex = 17;
            this.txtIssues_wh.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblBill_type_no
            // 
            this.lblBill_type_no.Location = new System.Drawing.Point(231, 101);
            this.lblBill_type_no.Name = "lblBill_type_no";
            this.lblBill_type_no.Size = new System.Drawing.Size(52, 14);
            this.lblBill_type_no.TabIndex = 18;
            this.lblBill_type_no.Text = "單據種類:";
            // 
            // lblMerchandiser
            // 
            this.lblMerchandiser.Location = new System.Drawing.Point(458, 101);
            this.lblMerchandiser.Name = "lblMerchandiser";
            this.lblMerchandiser.Size = new System.Drawing.Size(40, 14);
            this.lblMerchandiser.TabIndex = 18;
            this.lblMerchandiser.Text = "跟單員:";
            // 
            // txtMerchandiser_phone
            // 
            this.txtMerchandiser_phone.Location = new System.Drawing.Point(723, 98);
            this.txtMerchandiser_phone.Name = "txtMerchandiser_phone";
            this.txtMerchandiser_phone.Size = new System.Drawing.Size(100, 20);
            this.txtMerchandiser_phone.TabIndex = 19;
            this.txtMerchandiser_phone.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lueMerchandiser
            // 
            this.lueMerchandiser.Location = new System.Drawing.Point(509, 98);
            this.lueMerchandiser.Name = "lueMerchandiser";
            this.lueMerchandiser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMerchandiser.Properties.NullText = "";
            this.lueMerchandiser.Size = new System.Drawing.Size(100, 20);
            this.lueMerchandiser.TabIndex = 20;
            this.lueMerchandiser.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblMerchandiser_phone
            // 
            this.lblMerchandiser_phone.Location = new System.Drawing.Point(651, 101);
            this.lblMerchandiser_phone.Name = "lblMerchandiser_phone";
            this.lblMerchandiser_phone.Size = new System.Drawing.Size(64, 14);
            this.lblMerchandiser_phone.TabIndex = 18;
            this.lblMerchandiser_phone.Text = "跟單員電話:";
            // 
            // lblPo_no
            // 
            this.lblPo_no.Location = new System.Drawing.Point(20, 127);
            this.lblPo_no.Name = "lblPo_no";
            this.lblPo_no.Size = new System.Drawing.Size(52, 14);
            this.lblPo_no.TabIndex = 16;
            this.lblPo_no.Text = "訂單編號:";
            // 
            // txtPo_no
            // 
            this.txtPo_no.Location = new System.Drawing.Point(92, 127);
            this.txtPo_no.Name = "txtPo_no";
            this.txtPo_no.Size = new System.Drawing.Size(100, 20);
            this.txtPo_no.TabIndex = 17;
            this.txtPo_no.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblShipping_methods
            // 
            this.lblShipping_methods.Location = new System.Drawing.Point(263, 127);
            this.lblShipping_methods.Name = "lblShipping_methods";
            this.lblShipping_methods.Size = new System.Drawing.Size(20, 14);
            this.lblShipping_methods.TabIndex = 18;
            this.lblShipping_methods.Text = "Via:";
            // 
            // txtShipping_methods
            // 
            this.txtShipping_methods.Location = new System.Drawing.Point(297, 127);
            this.txtShipping_methods.Name = "txtShipping_methods";
            this.txtShipping_methods.Size = new System.Drawing.Size(100, 20);
            this.txtShipping_methods.TabIndex = 19;
            this.txtShipping_methods.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblSeller_id
            // 
            this.lblSeller_id.Location = new System.Drawing.Point(434, 127);
            this.lblSeller_id.Name = "lblSeller_id";
            this.lblSeller_id.Size = new System.Drawing.Size(64, 14);
            this.lblSeller_id.TabIndex = 18;
            this.lblSeller_id.Text = "銷售員編號:";
            // 
            // lueSeller_id
            // 
            this.lueSeller_id.Location = new System.Drawing.Point(509, 127);
            this.lueSeller_id.Name = "lueSeller_id";
            this.lueSeller_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSeller_id.Properties.NullText = "";
            this.lueSeller_id.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lueSeller_id.Size = new System.Drawing.Size(100, 20);
            this.lueSeller_id.TabIndex = 20;
            this.lueSeller_id.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblShip_date
            // 
            this.lblShip_date.Location = new System.Drawing.Point(231, 21);
            this.lblShip_date.Name = "lblShip_date";
            this.lblShip_date.Size = new System.Drawing.Size(52, 14);
            this.lblShip_date.TabIndex = 18;
            this.lblShip_date.Text = "送貨日期:";
            // 
            // txtShip_date
            // 
            this.txtShip_date.Location = new System.Drawing.Point(297, 18);
            this.txtShip_date.Name = "txtShip_date";
            this.txtShip_date.Size = new System.Drawing.Size(100, 20);
            this.txtShip_date.TabIndex = 19;
            this.txtShip_date.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lueBill_type_no
            // 
            this.lueBill_type_no.Location = new System.Drawing.Point(297, 98);
            this.lueBill_type_no.Name = "lueBill_type_no";
            this.lueBill_type_no.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBill_type_no.Properties.NullText = "";
            this.lueBill_type_no.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lueBill_type_no.Size = new System.Drawing.Size(100, 20);
            this.lueBill_type_no.TabIndex = 21;
            this.lueBill_type_no.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lueM_id
            // 
            this.lueM_id.Location = new System.Drawing.Point(92, 153);
            this.lueM_id.Name = "lueM_id";
            this.lueM_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueM_id.Properties.NullText = "";
            this.lueM_id.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lueM_id.Size = new System.Drawing.Size(100, 20);
            this.lueM_id.TabIndex = 20;
            this.lueM_id.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            this.lueM_id.Leave += new System.EventHandler(this.lueM_id_Leave);
            // 
            // lblM_id
            // 
            this.lblM_id.Location = new System.Drawing.Point(20, 153);
            this.lblM_id.Name = "lblM_id";
            this.lblM_id.Size = new System.Drawing.Size(52, 14);
            this.lblM_id.TabIndex = 18;
            this.lblM_id.Text = "貨幣編號:";
            // 
            // txtExchange_rate
            // 
            this.txtExchange_rate.Location = new System.Drawing.Point(297, 153);
            this.txtExchange_rate.Name = "txtExchange_rate";
            this.txtExchange_rate.Properties.Mask.EditMask = "n";
            this.txtExchange_rate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtExchange_rate.Size = new System.Drawing.Size(100, 20);
            this.txtExchange_rate.TabIndex = 19;
            this.txtExchange_rate.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblExchange_rate
            // 
            this.lblExchange_rate.Location = new System.Drawing.Point(255, 153);
            this.lblExchange_rate.Name = "lblExchange_rate";
            this.lblExchange_rate.Size = new System.Drawing.Size(28, 14);
            this.lblExchange_rate.TabIndex = 18;
            this.lblExchange_rate.Text = "比率:";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.dgvDetails;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.colLueGoods_id});
            this.gridControl1.Size = new System.Drawing.Size(1302, 438);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetails});
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnPanelRowHeight = 30;
            this.dgvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeq,
            this.colMo_id,
            this.colGoods_id,
            this.colGoods_name,
            this.colColor,
            this.colcustomer_goods,
            this.colCustomer_color_id,
            this.colU_invoice_qty,
            this.colGoods_unit,
            this.colSec_qty,
            this.colSec_unit,
            this.colPackage_num,
            this.colBox_no,
            this.colSpec,
            this.colLocation_id,
            this.colTable_head,
            this.colOrder_id,
            this.colContract_cid,
            this.colRemark,
            this.colIs_print,
            this.colSo_sequence_id,
            this.colSo_ver,
            this.colShipment_suit,
            this.colU_invoice_qty_pcs});
            this.dgvDetails.GridControl = this.gridControl1;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.OptionsSelection.MultiSelect = true;
            this.dgvDetails.OptionsView.ColumnAutoWidth = false;
            this.dgvDetails.OptionsView.ShowGroupPanel = false;
            this.dgvDetails.PaintStyleName = "Skin";
            this.dgvDetails.RowHeight = 25;
            this.dgvDetails.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.dgvDetails_ValidatingEditor);
            // 
            // colSeq
            // 
            this.colSeq.Caption = "序號";
            this.colSeq.ColumnEdit = this.repositoryItemTextEdit1;
            this.colSeq.FieldName = "sequence_id";
            this.colSeq.MaxWidth = 60;
            this.colSeq.Name = "colSeq";
            this.colSeq.Visible = true;
            this.colSeq.VisibleIndex = 0;
            this.colSeq.Width = 60;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // colMo_id
            // 
            this.colMo_id.Caption = "制單編號";
            this.colMo_id.FieldName = "mo_id";
            this.colMo_id.MaxWidth = 80;
            this.colMo_id.Name = "colMo_id";
            this.colMo_id.Visible = true;
            this.colMo_id.VisibleIndex = 1;
            this.colMo_id.Width = 80;
            // 
            // colGoods_id
            // 
            this.colGoods_id.Caption = "產品編號";
            this.colGoods_id.FieldName = "goods_id";
            this.colGoods_id.MaxWidth = 120;
            this.colGoods_id.Name = "colGoods_id";
            this.colGoods_id.Visible = true;
            this.colGoods_id.VisibleIndex = 2;
            this.colGoods_id.Width = 120;
            // 
            // colGoods_name
            // 
            this.colGoods_name.Caption = "產品描述";
            this.colGoods_name.FieldName = "goods_name";
            this.colGoods_name.MaxWidth = 200;
            this.colGoods_name.Name = "colGoods_name";
            this.colGoods_name.Visible = true;
            this.colGoods_name.VisibleIndex = 3;
            this.colGoods_name.Width = 200;
            // 
            // colColor
            // 
            this.colColor.Caption = "顏色";
            this.colColor.FieldName = "color";
            this.colColor.MaxWidth = 80;
            this.colColor.Name = "colColor";
            this.colColor.Visible = true;
            this.colColor.VisibleIndex = 4;
            this.colColor.Width = 80;
            // 
            // colcustomer_goods
            // 
            this.colcustomer_goods.Caption = "客戶產品編號";
            this.colcustomer_goods.FieldName = "customer_goods";
            this.colcustomer_goods.MaxWidth = 80;
            this.colcustomer_goods.Name = "colcustomer_goods";
            this.colcustomer_goods.Width = 80;
            // 
            // colCustomer_color_id
            // 
            this.colCustomer_color_id.Caption = "客戶顏色編號";
            this.colCustomer_color_id.FieldName = "customer_color_id";
            this.colCustomer_color_id.MaxWidth = 80;
            this.colCustomer_color_id.Name = "colCustomer_color_id";
            this.colCustomer_color_id.Visible = true;
            this.colCustomer_color_id.VisibleIndex = 5;
            this.colCustomer_color_id.Width = 80;
            // 
            // colU_invoice_qty
            // 
            this.colU_invoice_qty.Caption = "發貨數量";
            this.colU_invoice_qty.FieldName = "u_invoice_qty";
            this.colU_invoice_qty.MaxWidth = 80;
            this.colU_invoice_qty.Name = "colU_invoice_qty";
            this.colU_invoice_qty.Visible = true;
            this.colU_invoice_qty.VisibleIndex = 6;
            this.colU_invoice_qty.Width = 80;
            // 
            // colGoods_unit
            // 
            this.colGoods_unit.Caption = "數量單位";
            this.colGoods_unit.FieldName = "goods_unit";
            this.colGoods_unit.MaxWidth = 60;
            this.colGoods_unit.Name = "colGoods_unit";
            this.colGoods_unit.Visible = true;
            this.colGoods_unit.VisibleIndex = 7;
            this.colGoods_unit.Width = 60;
            // 
            // colSec_qty
            // 
            this.colSec_qty.Caption = "重量";
            this.colSec_qty.FieldName = "sec_qty";
            this.colSec_qty.MaxWidth = 60;
            this.colSec_qty.Name = "colSec_qty";
            this.colSec_qty.Visible = true;
            this.colSec_qty.VisibleIndex = 8;
            this.colSec_qty.Width = 60;
            // 
            // colSec_unit
            // 
            this.colSec_unit.Caption = "重量單位";
            this.colSec_unit.FieldName = "sec_unit";
            this.colSec_unit.MaxWidth = 60;
            this.colSec_unit.Name = "colSec_unit";
            this.colSec_unit.Visible = true;
            this.colSec_unit.VisibleIndex = 9;
            this.colSec_unit.Width = 60;
            // 
            // colPackage_num
            // 
            this.colPackage_num.Caption = "包數";
            this.colPackage_num.FieldName = "package_num";
            this.colPackage_num.Name = "colPackage_num";
            this.colPackage_num.Visible = true;
            this.colPackage_num.VisibleIndex = 10;
            this.colPackage_num.Width = 60;
            // 
            // colBox_no
            // 
            this.colBox_no.Caption = "箱號";
            this.colBox_no.FieldName = "box_no";
            this.colBox_no.Name = "colBox_no";
            this.colBox_no.Visible = true;
            this.colBox_no.VisibleIndex = 11;
            this.colBox_no.Width = 60;
            // 
            // colSpec
            // 
            this.colSpec.Caption = "規格";
            this.colSpec.FieldName = "spec";
            this.colSpec.Name = "colSpec";
            this.colSpec.Visible = true;
            this.colSpec.VisibleIndex = 12;
            this.colSpec.Width = 80;
            // 
            // colLocation_id
            // 
            this.colLocation_id.Caption = "倉庫";
            this.colLocation_id.FieldName = "location_id";
            this.colLocation_id.Name = "colLocation_id";
            this.colLocation_id.Visible = true;
            this.colLocation_id.VisibleIndex = 17;
            this.colLocation_id.Width = 60;
            // 
            // colTable_head
            // 
            this.colTable_head.Caption = "客戶款號";
            this.colTable_head.FieldName = "table_head";
            this.colTable_head.MaxWidth = 80;
            this.colTable_head.Name = "colTable_head";
            this.colTable_head.Visible = true;
            this.colTable_head.VisibleIndex = 13;
            this.colTable_head.Width = 80;
            // 
            // colOrder_id
            // 
            this.colOrder_id.Caption = "OC No";
            this.colOrder_id.FieldName = "order_id";
            this.colOrder_id.Name = "colOrder_id";
            this.colOrder_id.Visible = true;
            this.colOrder_id.VisibleIndex = 14;
            this.colOrder_id.Width = 100;
            // 
            // colContract_cid
            // 
            this.colContract_cid.Caption = "PO/NO";
            this.colContract_cid.FieldName = "contract_cid";
            this.colContract_cid.Name = "colContract_cid";
            this.colContract_cid.Visible = true;
            this.colContract_cid.VisibleIndex = 15;
            this.colContract_cid.Width = 100;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "備註";
            this.colRemark.FieldName = "remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 16;
            this.colRemark.Width = 160;
            // 
            // colIs_print
            // 
            this.colIs_print.Caption = "列印";
            this.colIs_print.FieldName = "is_print";
            this.colIs_print.Name = "colIs_print";
            this.colIs_print.Visible = true;
            this.colIs_print.VisibleIndex = 18;
            this.colIs_print.Width = 60;
            // 
            // colSo_sequence_id
            // 
            this.colSo_sequence_id.Caption = "訂單序號";
            this.colSo_sequence_id.FieldName = "so_sequence_id";
            this.colSo_sequence_id.Name = "colSo_sequence_id";
            this.colSo_sequence_id.Visible = true;
            this.colSo_sequence_id.VisibleIndex = 19;
            this.colSo_sequence_id.Width = 80;
            // 
            // colSo_ver
            // 
            this.colSo_ver.Caption = "訂單版本";
            this.colSo_ver.FieldName = "so_ver";
            this.colSo_ver.Name = "colSo_ver";
            this.colSo_ver.Visible = true;
            this.colSo_ver.VisibleIndex = 20;
            this.colSo_ver.Width = 80;
            // 
            // colShipment_suit
            // 
            this.colShipment_suit.Caption = "整套";
            this.colShipment_suit.FieldName = "shipment_suit";
            this.colShipment_suit.Name = "colShipment_suit";
            this.colShipment_suit.Visible = true;
            this.colShipment_suit.VisibleIndex = 21;
            this.colShipment_suit.Width = 60;
            // 
            // colU_invoice_qty_pcs
            // 
            this.colU_invoice_qty_pcs.Caption = "發貨數量(PCS)";
            this.colU_invoice_qty_pcs.FieldName = "u_invoice_qty_pcs";
            this.colU_invoice_qty_pcs.Name = "colU_invoice_qty_pcs";
            this.colU_invoice_qty_pcs.Visible = true;
            this.colU_invoice_qty_pcs.VisibleIndex = 22;
            this.colU_invoice_qty_pcs.Width = 80;
            // 
            // colLueGoods_id
            // 
            this.colLueGoods_id.AutoHeight = false;
            this.colLueGoods_id.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colLueGoods_id.Name = "colLueGoods_id";
            this.colLueGoods_id.NullText = "";
            // 
            // lblGoods_sum
            // 
            this.lblGoods_sum.Location = new System.Drawing.Point(410, 153);
            this.lblGoods_sum.Name = "lblGoods_sum";
            this.lblGoods_sum.Size = new System.Drawing.Size(88, 14);
            this.lblGoods_sum.TabIndex = 18;
            this.lblGoods_sum.Text = "發票貨品總金額:";
            // 
            // txtGoods_sum
            // 
            this.txtGoods_sum.Location = new System.Drawing.Point(509, 153);
            this.txtGoods_sum.Name = "txtGoods_sum";
            this.txtGoods_sum.Properties.Mask.EditMask = "n";
            this.txtGoods_sum.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGoods_sum.Size = new System.Drawing.Size(100, 20);
            this.txtGoods_sum.TabIndex = 19;
            this.txtGoods_sum.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblOther_fare
            // 
            this.lblOther_fare.Location = new System.Drawing.Point(663, 153);
            this.lblOther_fare.Name = "lblOther_fare";
            this.lblOther_fare.Size = new System.Drawing.Size(52, 14);
            this.lblOther_fare.TabIndex = 18;
            this.lblOther_fare.Text = "其它費用:";
            // 
            // txtOther_fare
            // 
            this.txtOther_fare.Location = new System.Drawing.Point(723, 153);
            this.txtOther_fare.Name = "txtOther_fare";
            this.txtOther_fare.Properties.Mask.EditMask = "n";
            this.txtOther_fare.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOther_fare.Size = new System.Drawing.Size(100, 20);
            this.txtOther_fare.TabIndex = 19;
            this.txtOther_fare.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblDisc_rate
            // 
            this.lblDisc_rate.Location = new System.Drawing.Point(44, 179);
            this.lblDisc_rate.Name = "lblDisc_rate";
            this.lblDisc_rate.Size = new System.Drawing.Size(28, 14);
            this.lblDisc_rate.TabIndex = 18;
            this.lblDisc_rate.Text = "折扣:";
            // 
            // txtDisc_rate
            // 
            this.txtDisc_rate.Location = new System.Drawing.Point(92, 179);
            this.txtDisc_rate.Name = "txtDisc_rate";
            this.txtDisc_rate.Properties.Mask.EditMask = "n";
            this.txtDisc_rate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDisc_rate.Size = new System.Drawing.Size(100, 20);
            this.txtDisc_rate.TabIndex = 19;
            this.txtDisc_rate.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblDisc_amt
            // 
            this.lblDisc_amt.Location = new System.Drawing.Point(255, 179);
            this.lblDisc_amt.Name = "lblDisc_amt";
            this.lblDisc_amt.Size = new System.Drawing.Size(40, 14);
            this.lblDisc_amt.TabIndex = 18;
            this.lblDisc_amt.Text = "折扣額:";
            // 
            // txtDisc_amt
            // 
            this.txtDisc_amt.Location = new System.Drawing.Point(297, 179);
            this.txtDisc_amt.Name = "txtDisc_amt";
            this.txtDisc_amt.Properties.Mask.EditMask = "n";
            this.txtDisc_amt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDisc_amt.Size = new System.Drawing.Size(100, 20);
            this.txtDisc_amt.TabIndex = 19;
            this.txtDisc_amt.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblDisc_spare
            // 
            this.lblDisc_spare.Location = new System.Drawing.Point(434, 176);
            this.lblDisc_spare.Name = "lblDisc_spare";
            this.lblDisc_spare.Size = new System.Drawing.Size(64, 14);
            this.lblDisc_spare.TabIndex = 18;
            this.lblDisc_spare.Text = "折扣後金額:";
            // 
            // txtDisc_spare
            // 
            this.txtDisc_spare.Location = new System.Drawing.Point(509, 176);
            this.txtDisc_spare.Name = "txtDisc_spare";
            this.txtDisc_spare.Properties.Mask.EditMask = "n";
            this.txtDisc_spare.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDisc_spare.Size = new System.Drawing.Size(100, 20);
            this.txtDisc_spare.TabIndex = 19;
            this.txtDisc_spare.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // lblTotal_sum
            // 
            this.lblTotal_sum.Location = new System.Drawing.Point(675, 179);
            this.lblTotal_sum.Name = "lblTotal_sum";
            this.lblTotal_sum.Size = new System.Drawing.Size(40, 14);
            this.lblTotal_sum.TabIndex = 18;
            this.lblTotal_sum.Text = "總金額:";
            // 
            // txtTotal_sum
            // 
            this.txtTotal_sum.Location = new System.Drawing.Point(723, 179);
            this.txtTotal_sum.Name = "txtTotal_sum";
            this.txtTotal_sum.Properties.Mask.EditMask = "n";
            this.txtTotal_sum.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal_sum.Size = new System.Drawing.Size(100, 20);
            this.txtTotal_sum.TabIndex = 19;
            this.txtTotal_sum.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // txtCust_name
            // 
            this.txtCust_name.Location = new System.Drawing.Point(723, 18);
            this.txtCust_name.Name = "txtCust_name";
            this.txtCust_name.Size = new System.Drawing.Size(100, 20);
            this.txtCust_name.TabIndex = 23;
            this.txtCust_name.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // txtFake_address
            // 
            this.txtFake_address.Location = new System.Drawing.Point(723, 47);
            this.txtFake_address.Name = "txtFake_address";
            this.txtFake_address.Size = new System.Drawing.Size(479, 20);
            this.txtFake_address.TabIndex = 22;
            this.txtFake_address.EditValueChanged += new System.EventHandler(this.txtShip_date_EditValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Controls.Add(this.panelControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 220);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1302, 585);
            this.panel2.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 438);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1302, 147);
            this.panelControl1.TabIndex = 2;
            // 
            // xtbControl1
            // 
            this.xtbControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtbControl1.Location = new System.Drawing.Point(0, 38);
            this.xtbControl1.Name = "xtbControl1";
            this.xtbControl1.SelectedTabPage = this.xtbPage1;
            this.xtbControl1.Size = new System.Drawing.Size(1308, 834);
            this.xtbControl1.TabIndex = 4;
            this.xtbControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtbPage1,
            this.xtbPage2});
            // 
            // xtbPage1
            // 
            this.xtbPage1.Controls.Add(this.panel2);
            this.xtbPage1.Controls.Add(this.panelControl2);
            this.xtbPage1.Name = "xtbPage1";
            this.xtbPage1.Size = new System.Drawing.Size(1302, 805);
            this.xtbPage1.Text = "生成送貨單";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtCust_name);
            this.panelControl2.Controls.Add(this.lblId);
            this.panelControl2.Controls.Add(this.txtFake_address);
            this.panelControl2.Controls.Add(this.txtEmail);
            this.panelControl2.Controls.Add(this.lueBill_type_no);
            this.panelControl2.Controls.Add(this.txtShip_date);
            this.panelControl2.Controls.Add(this.lblEmail);
            this.panelControl2.Controls.Add(this.lueM_id);
            this.panelControl2.Controls.Add(this.lblIssues_wh);
            this.panelControl2.Controls.Add(this.txtShipping_methods);
            this.panelControl2.Controls.Add(this.txtL_phone);
            this.panelControl2.Controls.Add(this.lblExchange_rate);
            this.panelControl2.Controls.Add(this.lblShip_date);
            this.panelControl2.Controls.Add(this.lueSeller_id);
            this.panelControl2.Controls.Add(this.lblL_phone);
            this.panelControl2.Controls.Add(this.lblShipping_methods);
            this.panelControl2.Controls.Add(this.txtIssues_wh);
            this.panelControl2.Controls.Add(this.txtId);
            this.panelControl2.Controls.Add(this.txtLinkman);
            this.panelControl2.Controls.Add(this.lblDisc_rate);
            this.panelControl2.Controls.Add(this.lblPo_no);
            this.panelControl2.Controls.Add(this.lueMerchandiser);
            this.panelControl2.Controls.Add(this.lblLinkman);
            this.panelControl2.Controls.Add(this.lblGoods_sum);
            this.panelControl2.Controls.Add(this.txtPo_no);
            this.panelControl2.Controls.Add(this.lblIt_Customer);
            this.panelControl2.Controls.Add(this.txtFax);
            this.panelControl2.Controls.Add(this.lblDisc_amt);
            this.panelControl2.Controls.Add(this.lblBill_type_no);
            this.panelControl2.Controls.Add(this.lblM_id);
            this.panelControl2.Controls.Add(this.lblFax);
            this.panelControl2.Controls.Add(this.txtExchange_rate);
            this.panelControl2.Controls.Add(this.txtOther_fare);
            this.panelControl2.Controls.Add(this.txtIt_Customer);
            this.panelControl2.Controls.Add(this.txtPhone);
            this.panelControl2.Controls.Add(this.lblDisc_spare);
            this.panelControl2.Controls.Add(this.txtGoods_sum);
            this.panelControl2.Controls.Add(this.txtMerchandiser_phone);
            this.panelControl2.Controls.Add(this.lblMerchandiser);
            this.panelControl2.Controls.Add(this.txtDisc_rate);
            this.panelControl2.Controls.Add(this.lblOther_fare);
            this.panelControl2.Controls.Add(this.lblSeparate);
            this.panelControl2.Controls.Add(this.lblPhone);
            this.panelControl2.Controls.Add(this.lblTotal_sum);
            this.panelControl2.Controls.Add(this.txtTotal_sum);
            this.panelControl2.Controls.Add(this.lblSeller_id);
            this.panelControl2.Controls.Add(this.lblMerchandiser_phone);
            this.panelControl2.Controls.Add(this.txtDisc_amt);
            this.panelControl2.Controls.Add(this.txtDisc_spare);
            this.panelControl2.Controls.Add(this.txtSeparate);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1302, 220);
            this.panelControl2.TabIndex = 24;
            // 
            // xtbPage2
            // 
            this.xtbPage2.Controls.Add(this.gcIdDetails);
            this.xtbPage2.Controls.Add(this.panelControl3);
            this.xtbPage2.Controls.Add(this.panelControl4);
            this.xtbPage2.Name = "xtbPage2";
            this.xtbPage2.Size = new System.Drawing.Size(1302, 805);
            this.xtbPage2.Text = "資料查詢";
            // 
            // gcIdDetails
            // 
            this.gcIdDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcIdDetails.Location = new System.Drawing.Point(0, 82);
            this.gcIdDetails.MainView = this.dgvIdDetails;
            this.gcIdDetails.Name = "gcIdDetails";
            this.gcIdDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcIdDetails.Size = new System.Drawing.Size(1302, 439);
            this.gcIdDetails.TabIndex = 2;
            this.gcIdDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvIdDetails});
            // 
            // dgvIdDetails
            // 
            this.dgvIdDetails.ColumnPanelRowHeight = 30;
            this.dgvIdDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId_chkSelect,
            this.colId_Id,
            this.colId_Ship_date,
            this.colId_Sequence_id,
            this.colId_Mo_id,
            this.colId_Goods_id,
            this.colId_Goods_name,
            this.colId_U_invoice_qty,
            this.colId_Goods_unit,
            this.colId_Sec_qty,
            this.colId_Sec_unit,
            this.colId_Order_id});
            this.dgvIdDetails.GridControl = this.gcIdDetails;
            this.dgvIdDetails.Name = "dgvIdDetails";
            this.dgvIdDetails.OptionsSelection.MultiSelect = true;
            this.dgvIdDetails.OptionsView.ColumnAutoWidth = false;
            this.dgvIdDetails.OptionsView.ShowGroupPanel = false;
            this.dgvIdDetails.RowHeight = 30;
            this.dgvIdDetails.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.dgvIdDetails_SelectionChanged);
            // 
            // colId_chkSelect
            // 
            this.colId_chkSelect.Caption = "選取";
            this.colId_chkSelect.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colId_chkSelect.FieldName = "is_select";
            this.colId_chkSelect.Name = "colId_chkSelect";
            this.colId_chkSelect.Visible = true;
            this.colId_chkSelect.VisibleIndex = 0;
            this.colId_chkSelect.Width = 40;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colId_Id
            // 
            this.colId_Id.Caption = "單據編號";
            this.colId_Id.FieldName = "id";
            this.colId_Id.Name = "colId_Id";
            this.colId_Id.Visible = true;
            this.colId_Id.VisibleIndex = 1;
            this.colId_Id.Width = 100;
            // 
            // colId_Ship_date
            // 
            this.colId_Ship_date.Caption = "單據日期";
            this.colId_Ship_date.FieldName = "ship_date";
            this.colId_Ship_date.Name = "colId_Ship_date";
            this.colId_Ship_date.Visible = true;
            this.colId_Ship_date.VisibleIndex = 2;
            this.colId_Ship_date.Width = 80;
            // 
            // colId_Sequence_id
            // 
            this.colId_Sequence_id.Caption = "序號";
            this.colId_Sequence_id.FieldName = "sequence_id";
            this.colId_Sequence_id.Name = "colId_Sequence_id";
            this.colId_Sequence_id.Visible = true;
            this.colId_Sequence_id.VisibleIndex = 3;
            this.colId_Sequence_id.Width = 60;
            // 
            // colId_Mo_id
            // 
            this.colId_Mo_id.Caption = "制單編號";
            this.colId_Mo_id.FieldName = "mo_id";
            this.colId_Mo_id.Name = "colId_Mo_id";
            this.colId_Mo_id.Visible = true;
            this.colId_Mo_id.VisibleIndex = 4;
            this.colId_Mo_id.Width = 80;
            // 
            // colId_Goods_id
            // 
            this.colId_Goods_id.Caption = "產品編號";
            this.colId_Goods_id.FieldName = "goods_id";
            this.colId_Goods_id.Name = "colId_Goods_id";
            this.colId_Goods_id.Visible = true;
            this.colId_Goods_id.VisibleIndex = 5;
            this.colId_Goods_id.Width = 120;
            // 
            // colId_Goods_name
            // 
            this.colId_Goods_name.Caption = "產品描述";
            this.colId_Goods_name.FieldName = "goods_name";
            this.colId_Goods_name.Name = "colId_Goods_name";
            this.colId_Goods_name.Visible = true;
            this.colId_Goods_name.VisibleIndex = 6;
            this.colId_Goods_name.Width = 300;
            // 
            // colId_U_invoice_qty
            // 
            this.colId_U_invoice_qty.Caption = "發貨數量";
            this.colId_U_invoice_qty.FieldName = "u_invoice_qty";
            this.colId_U_invoice_qty.Name = "colId_U_invoice_qty";
            this.colId_U_invoice_qty.Visible = true;
            this.colId_U_invoice_qty.VisibleIndex = 7;
            this.colId_U_invoice_qty.Width = 80;
            // 
            // colId_Goods_unit
            // 
            this.colId_Goods_unit.Caption = "數量單位";
            this.colId_Goods_unit.FieldName = "goods_unit";
            this.colId_Goods_unit.Name = "colId_Goods_unit";
            this.colId_Goods_unit.Visible = true;
            this.colId_Goods_unit.VisibleIndex = 8;
            this.colId_Goods_unit.Width = 80;
            // 
            // colId_Sec_qty
            // 
            this.colId_Sec_qty.Caption = "重量";
            this.colId_Sec_qty.FieldName = "sec_qty";
            this.colId_Sec_qty.Name = "colId_Sec_qty";
            this.colId_Sec_qty.Visible = true;
            this.colId_Sec_qty.VisibleIndex = 9;
            this.colId_Sec_qty.Width = 60;
            // 
            // colId_Sec_unit
            // 
            this.colId_Sec_unit.Caption = "重量單位";
            this.colId_Sec_unit.FieldName = "sec_unit";
            this.colId_Sec_unit.Name = "colId_Sec_unit";
            this.colId_Sec_unit.Visible = true;
            this.colId_Sec_unit.VisibleIndex = 10;
            this.colId_Sec_unit.Width = 80;
            // 
            // colId_Order_id
            // 
            this.colId_Order_id.Caption = "OC No";
            this.colId_Order_id.FieldName = "order_id";
            this.colId_Order_id.Name = "colId_Order_id";
            this.colId_Order_id.Visible = true;
            this.colId_Order_id.VisibleIndex = 11;
            this.colId_Order_id.Width = 100;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnImput);
            this.panelControl3.Controls.Add(this.btnQuery);
            this.panelControl3.Controls.Add(this.txtFindMo_id);
            this.panelControl3.Controls.Add(this.lblFindMo_id);
            this.panelControl3.Controls.Add(this.txtFindId);
            this.panelControl3.Controls.Add(this.lblFindId);
            this.panelControl3.Controls.Add(this.txtFindOc_no);
            this.panelControl3.Controls.Add(this.lblFindOc_no);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1302, 82);
            this.panelControl3.TabIndex = 0;
            // 
            // btnImput
            // 
            this.btnImput.Location = new System.Drawing.Point(746, 27);
            this.btnImput.Name = "btnImput";
            this.btnImput.Size = new System.Drawing.Size(80, 30);
            this.btnImput.TabIndex = 3;
            this.btnImput.Text = "過賬";
            this.btnImput.UseVisualStyleBackColor = true;
            this.btnImput.Click += new System.EventHandler(this.btnImput_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(634, 27);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(80, 30);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查找";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtFindMo_id
            // 
            this.txtFindMo_id.Location = new System.Drawing.Point(462, 26);
            this.txtFindMo_id.Name = "txtFindMo_id";
            this.txtFindMo_id.Size = new System.Drawing.Size(100, 20);
            this.txtFindMo_id.TabIndex = 1;
            // 
            // lblFindMo_id
            // 
            this.lblFindMo_id.Location = new System.Drawing.Point(402, 29);
            this.lblFindMo_id.Name = "lblFindMo_id";
            this.lblFindMo_id.Size = new System.Drawing.Size(52, 14);
            this.lblFindMo_id.TabIndex = 0;
            this.lblFindMo_id.Text = "單據編號:";
            // 
            // txtFindId
            // 
            this.txtFindId.Location = new System.Drawing.Point(281, 26);
            this.txtFindId.Name = "txtFindId";
            this.txtFindId.Size = new System.Drawing.Size(100, 20);
            this.txtFindId.TabIndex = 1;
            // 
            // lblFindId
            // 
            this.lblFindId.Location = new System.Drawing.Point(221, 29);
            this.lblFindId.Name = "lblFindId";
            this.lblFindId.Size = new System.Drawing.Size(52, 14);
            this.lblFindId.TabIndex = 0;
            this.lblFindId.Text = "單據編號:";
            // 
            // txtFindOc_no
            // 
            this.txtFindOc_no.Location = new System.Drawing.Point(90, 26);
            this.txtFindOc_no.Name = "txtFindOc_no";
            this.txtFindOc_no.Size = new System.Drawing.Size(100, 20);
            this.txtFindOc_no.TabIndex = 1;
            // 
            // lblFindOc_no
            // 
            this.lblFindOc_no.Location = new System.Drawing.Point(41, 29);
            this.lblFindOc_no.Name = "lblFindOc_no";
            this.lblFindOc_no.Size = new System.Drawing.Size(43, 14);
            this.lblFindOc_no.TabIndex = 0;
            this.lblFindOc_no.Text = "Oc編號:";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.gcOcDgdDetails);
            this.panelControl4.Controls.Add(this.panelControl5);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(0, 521);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(1302, 284);
            this.panelControl4.TabIndex = 1;
            // 
            // gcOcDgdDetails
            // 
            this.gcOcDgdDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOcDgdDetails.Location = new System.Drawing.Point(2, 50);
            this.gcOcDgdDetails.MainView = this.dgvOcDgdDetails;
            this.gcOcDgdDetails.Name = "gcOcDgdDetails";
            this.gcOcDgdDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.gcOcDgdDetails.Size = new System.Drawing.Size(1298, 232);
            this.gcOcDgdDetails.TabIndex = 3;
            this.gcOcDgdDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvOcDgdDetails});
            // 
            // dgvOcDgdDetails
            // 
            this.dgvOcDgdDetails.ColumnPanelRowHeight = 30;
            this.dgvOcDgdDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOc_Ship_date,
            this.colOc_Sequence_id,
            this.colOc_Mo_id,
            this.colOc_Goods_id,
            this.colOc_Goods_name,
            this.colOc_Id,
            this.colOc_State,
            this.colOc_Order_qty,
            this.colOc_Order_Goods_unit,
            this.colOc_U_invoice_qty,
            this.colOc_Goods_unit,
            this.colOc_Sec_qty,
            this.colOc_Sec_unit,
            this.colOc_Order_id});
            this.dgvOcDgdDetails.GridControl = this.gcOcDgdDetails;
            this.dgvOcDgdDetails.Name = "dgvOcDgdDetails";
            this.dgvOcDgdDetails.OptionsSelection.MultiSelect = true;
            this.dgvOcDgdDetails.OptionsView.ColumnAutoWidth = false;
            this.dgvOcDgdDetails.OptionsView.ShowGroupPanel = false;
            this.dgvOcDgdDetails.RowHeight = 30;
            // 
            // colOc_Ship_date
            // 
            this.colOc_Ship_date.Caption = "單據日期";
            this.colOc_Ship_date.FieldName = "ship_date";
            this.colOc_Ship_date.Name = "colOc_Ship_date";
            this.colOc_Ship_date.Visible = true;
            this.colOc_Ship_date.VisibleIndex = 8;
            this.colOc_Ship_date.Width = 80;
            // 
            // colOc_Sequence_id
            // 
            this.colOc_Sequence_id.Caption = "序號";
            this.colOc_Sequence_id.FieldName = "sequence_id";
            this.colOc_Sequence_id.Name = "colOc_Sequence_id";
            this.colOc_Sequence_id.Visible = true;
            this.colOc_Sequence_id.VisibleIndex = 0;
            this.colOc_Sequence_id.Width = 60;
            // 
            // colOc_Mo_id
            // 
            this.colOc_Mo_id.Caption = "制單編號";
            this.colOc_Mo_id.FieldName = "mo_id";
            this.colOc_Mo_id.Name = "colOc_Mo_id";
            this.colOc_Mo_id.Visible = true;
            this.colOc_Mo_id.VisibleIndex = 1;
            this.colOc_Mo_id.Width = 80;
            // 
            // colOc_Goods_id
            // 
            this.colOc_Goods_id.Caption = "產品編號";
            this.colOc_Goods_id.FieldName = "goods_id";
            this.colOc_Goods_id.Name = "colOc_Goods_id";
            this.colOc_Goods_id.Visible = true;
            this.colOc_Goods_id.VisibleIndex = 2;
            this.colOc_Goods_id.Width = 120;
            // 
            // colOc_Goods_name
            // 
            this.colOc_Goods_name.Caption = "產品描述";
            this.colOc_Goods_name.FieldName = "goods_name";
            this.colOc_Goods_name.Name = "colOc_Goods_name";
            this.colOc_Goods_name.Visible = true;
            this.colOc_Goods_name.VisibleIndex = 3;
            this.colOc_Goods_name.Width = 300;
            // 
            // colOc_Id
            // 
            this.colOc_Id.Caption = "單據編號";
            this.colOc_Id.FieldName = "id";
            this.colOc_Id.Name = "colOc_Id";
            this.colOc_Id.Visible = true;
            this.colOc_Id.VisibleIndex = 6;
            this.colOc_Id.Width = 100;
            // 
            // colOc_State
            // 
            this.colOc_State.Caption = "過賬狀態";
            this.colOc_State.FieldName = "state";
            this.colOc_State.Name = "colOc_State";
            this.colOc_State.Visible = true;
            this.colOc_State.VisibleIndex = 7;
            this.colOc_State.Width = 60;
            // 
            // colOc_Order_qty
            // 
            this.colOc_Order_qty.Caption = "訂單數量";
            this.colOc_Order_qty.FieldName = "order_qty";
            this.colOc_Order_qty.Name = "colOc_Order_qty";
            this.colOc_Order_qty.Visible = true;
            this.colOc_Order_qty.VisibleIndex = 4;
            this.colOc_Order_qty.Width = 80;
            // 
            // colOc_Order_Goods_unit
            // 
            this.colOc_Order_Goods_unit.Caption = "數量單位";
            this.colOc_Order_Goods_unit.FieldName = "order_goods_unit";
            this.colOc_Order_Goods_unit.Name = "colOc_Order_Goods_unit";
            this.colOc_Order_Goods_unit.Visible = true;
            this.colOc_Order_Goods_unit.VisibleIndex = 5;
            this.colOc_Order_Goods_unit.Width = 60;
            // 
            // colOc_U_invoice_qty
            // 
            this.colOc_U_invoice_qty.Caption = "發貨數量";
            this.colOc_U_invoice_qty.FieldName = "u_invoice_qty";
            this.colOc_U_invoice_qty.Name = "colOc_U_invoice_qty";
            this.colOc_U_invoice_qty.Visible = true;
            this.colOc_U_invoice_qty.VisibleIndex = 9;
            this.colOc_U_invoice_qty.Width = 80;
            // 
            // colOc_Goods_unit
            // 
            this.colOc_Goods_unit.Caption = "數量單位";
            this.colOc_Goods_unit.FieldName = "goods_unit";
            this.colOc_Goods_unit.Name = "colOc_Goods_unit";
            this.colOc_Goods_unit.Visible = true;
            this.colOc_Goods_unit.VisibleIndex = 10;
            this.colOc_Goods_unit.Width = 80;
            // 
            // colOc_Sec_qty
            // 
            this.colOc_Sec_qty.Caption = "重量";
            this.colOc_Sec_qty.FieldName = "sec_qty";
            this.colOc_Sec_qty.Name = "colOc_Sec_qty";
            this.colOc_Sec_qty.Visible = true;
            this.colOc_Sec_qty.VisibleIndex = 11;
            this.colOc_Sec_qty.Width = 60;
            // 
            // colOc_Sec_unit
            // 
            this.colOc_Sec_unit.Caption = "重量單位";
            this.colOc_Sec_unit.FieldName = "sec_unit";
            this.colOc_Sec_unit.Name = "colOc_Sec_unit";
            this.colOc_Sec_unit.Visible = true;
            this.colOc_Sec_unit.VisibleIndex = 12;
            this.colOc_Sec_unit.Width = 80;
            // 
            // colOc_Order_id
            // 
            this.colOc_Order_id.Caption = "OC No";
            this.colOc_Order_id.FieldName = "order_id";
            this.colOc_Order_id.Name = "colOc_Order_id";
            this.colOc_Order_id.Visible = true;
            this.colOc_Order_id.VisibleIndex = 13;
            this.colOc_Order_id.Width = 100;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // panelControl5
            // 
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl5.Location = new System.Drawing.Point(2, 2);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(1298, 48);
            this.panelControl5.TabIndex = 0;
            // 
            // frmDgdInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 872);
            this.Controls.Add(this.xtbControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmDgdInvoice";
            this.Text = "frmSoInvoice";
            this.Load += new System.EventHandler(this.frmDgdDeliverGoods_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIt_Customer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeparate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinkman.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtL_phone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssues_wh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMerchandiser_phone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMerchandiser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPo_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipping_methods.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSeller_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShip_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBill_type_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueM_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchange_rate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colLueGoods_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_sum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOther_fare.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisc_rate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisc_amt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisc_spare.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal_sum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFake_address.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtbControl1)).EndInit();
            this.xtbControl1.ResumeLayout(false);
            this.xtbPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.xtbPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcIdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindMo_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindOc_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcOcDgdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcDgdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraEditors.LabelControl lblId;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.TextEdit txtIt_Customer;
        private DevExpress.XtraEditors.LabelControl lblIt_Customer;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl lblPhone;
        private DevExpress.XtraEditors.TextEdit txtSeparate;
        private DevExpress.XtraEditors.LabelControl lblSeparate;
        private DevExpress.XtraEditors.TextEdit txtFax;
        private DevExpress.XtraEditors.LabelControl lblFax;
        private DevExpress.XtraEditors.TextEdit txtL_phone;
        private DevExpress.XtraEditors.LabelControl lblL_phone;
        private DevExpress.XtraEditors.TextEdit txtLinkman;
        private DevExpress.XtraEditors.LabelControl lblLinkman;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.LabelControl lblBill_type_no;
        private DevExpress.XtraEditors.TextEdit txtIssues_wh;
        private DevExpress.XtraEditors.LabelControl lblIssues_wh;
        private DevExpress.XtraEditors.LookUpEdit lueMerchandiser;
        private DevExpress.XtraEditors.TextEdit txtMerchandiser_phone;
        private DevExpress.XtraEditors.LabelControl lblMerchandiser_phone;
        private DevExpress.XtraEditors.LabelControl lblMerchandiser;
        private DevExpress.XtraEditors.TextEdit txtPo_no;
        private DevExpress.XtraEditors.LabelControl lblPo_no;
        private DevExpress.XtraEditors.TextEdit txtShipping_methods;
        private DevExpress.XtraEditors.LabelControl lblShipping_methods;
        private DevExpress.XtraEditors.LookUpEdit lueSeller_id;
        private DevExpress.XtraEditors.LabelControl lblSeller_id;
        private DevExpress.XtraEditors.TextEdit txtShip_date;
        private DevExpress.XtraEditors.LabelControl lblShip_date;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colSeq;
        private DevExpress.XtraGrid.Columns.GridColumn colMo_id;
        private DevExpress.XtraGrid.Columns.GridColumn colGoods_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.LookUpEdit lueBill_type_no;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DevExpress.XtraGrid.Columns.GridColumn colGoods_name;
        private DevExpress.XtraGrid.Columns.GridColumn colColor;
        private DevExpress.XtraGrid.Columns.GridColumn colcustomer_goods;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer_color_id;
        private DevExpress.XtraGrid.Columns.GridColumn colU_invoice_qty;
        private DevExpress.XtraGrid.Columns.GridColumn colGoods_unit;
        private DevExpress.XtraGrid.Columns.GridColumn colSec_qty;
        private DevExpress.XtraGrid.Columns.GridColumn colSec_unit;
        private DevExpress.XtraGrid.Columns.GridColumn colTable_head;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder_id;
        private DevExpress.XtraGrid.Columns.GridColumn colContract_cid;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation_id;
        private DevExpress.XtraGrid.Columns.GridColumn colPackage_num;
        private DevExpress.XtraGrid.Columns.GridColumn colBox_no;
        private DevExpress.XtraGrid.Columns.GridColumn colSpec;
        private DevExpress.XtraGrid.Columns.GridColumn colIs_print;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit colLueGoods_id;
        private DevExpress.XtraGrid.Columns.GridColumn colSo_sequence_id;
        private DevExpress.XtraGrid.Columns.GridColumn colSo_ver;
        private DevExpress.XtraGrid.Columns.GridColumn colShipment_suit;
        private DevExpress.XtraGrid.Columns.GridColumn colU_invoice_qty_pcs;
        private DevExpress.XtraEditors.LookUpEdit lueM_id;
        private DevExpress.XtraEditors.LabelControl lblM_id;
        private DevExpress.XtraEditors.TextEdit txtExchange_rate;
        private DevExpress.XtraEditors.LabelControl lblExchange_rate;
        private DevExpress.XtraEditors.TextEdit txtGoods_sum;
        private DevExpress.XtraEditors.LabelControl lblGoods_sum;
        private DevExpress.XtraEditors.TextEdit txtOther_fare;
        private DevExpress.XtraEditors.LabelControl lblOther_fare;
        private DevExpress.XtraEditors.TextEdit txtDisc_rate;
        private DevExpress.XtraEditors.LabelControl lblDisc_rate;
        private DevExpress.XtraEditors.TextEdit txtDisc_amt;
        private DevExpress.XtraEditors.LabelControl lblDisc_amt;
        private DevExpress.XtraEditors.TextEdit txtDisc_spare;
        private DevExpress.XtraEditors.LabelControl lblDisc_spare;
        private DevExpress.XtraEditors.TextEdit txtTotal_sum;
        private DevExpress.XtraEditors.LabelControl lblTotal_sum;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit txtFake_address;
        private DevExpress.XtraEditors.TextEdit txtCust_name;
        private DevExpress.XtraTab.XtraTabControl xtbControl1;
        private DevExpress.XtraTab.XtraTabPage xtbPage1;
        private DevExpress.XtraTab.XtraTabPage xtbPage2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.TextEdit txtFindOc_no;
        private DevExpress.XtraEditors.LabelControl lblFindOc_no;
        private DevExpress.XtraEditors.TextEdit txtFindId;
        private DevExpress.XtraEditors.LabelControl lblFindId;
        private DevExpress.XtraEditors.TextEdit txtFindMo_id;
        private DevExpress.XtraEditors.LabelControl lblFindMo_id;
        private System.Windows.Forms.Button btnQuery;
        private DevExpress.XtraGrid.GridControl gcIdDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvIdDetails;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn colId_chkSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Ship_date;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Sequence_id;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Mo_id;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Goods_id;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Goods_name;
        private DevExpress.XtraGrid.Columns.GridColumn colId_U_invoice_qty;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Goods_unit;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Sec_qty;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Sec_unit;
        private DevExpress.XtraGrid.Columns.GridColumn colId_Order_id;
        private DevExpress.XtraGrid.GridControl gcOcDgdDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvOcDgdDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_State;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_Ship_date;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_Sequence_id;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_Mo_id;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_Goods_id;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_Goods_name;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_U_invoice_qty;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_Goods_unit;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_Sec_qty;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_Sec_unit;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_Order_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_Order_qty;
        private DevExpress.XtraGrid.Columns.GridColumn colOc_Order_Goods_unit;
        private System.Windows.Forms.Button btnImput;
    }
}