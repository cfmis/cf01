namespace cf01.Forms
{
    partial class frmCustComplain_Find
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustComplain_Find));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConf = new System.Windows.Forms.ToolStripButton();
            this.gcDetails = new DevExpress.XtraGrid.GridControl();
            this.dgvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.appellate_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customer_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exception_note_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reslove_pro_revert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.essential_reason_dept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.essential_reason_qc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reason_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reason_type_big = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.goods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.goods_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblId = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.lblMo_id = new DevExpress.XtraEditors.LabelControl();
            this.txtId1 = new DevExpress.XtraEditors.TextEdit();
            this.txtMo_id1 = new DevExpress.XtraEditors.TextEdit();
            this.txtId2 = new DevExpress.XtraEditors.TextEdit();
            this.txtMo_id2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCust2 = new DevExpress.XtraEditors.TextEdit();
            this.txtCust1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtDate2 = new DevExpress.XtraEditors.DateEdit();
            this.dtDate1 = new DevExpress.XtraEditors.DateEdit();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVESET = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator2,
            this.btnConf,
            this.toolStripSeparator3,
            this.BTNSAVESET});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = false;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 35);
            this.btnClose.Text = "退出(&X)";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnConf
            // 
            this.btnConf.AutoSize = false;
            this.btnConf.Image = ((System.Drawing.Image)(resources.GetObject("btnConf.Image")));
            this.btnConf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(65, 35);
            this.btnConf.Text = "確認(&C)";
            this.btnConf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConf.Click += new System.EventHandler(this.btnConf_Click);
            // 
            // gcDetails
            // 
            this.gcDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcDetails.Location = new System.Drawing.Point(1, 116);
            this.gcDetails.MainView = this.dgvDetails;
            this.gcDetails.Name = "gcDetails";
            this.gcDetails.Size = new System.Drawing.Size(1014, 568);
            this.gcDetails.TabIndex = 3;
            this.gcDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetails});
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnPanelRowHeight = 30;
            this.dgvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.appellate_date,
            this.customer_id,
            this.exception_note_id,
            this.reslove_pro_revert,
            this.essential_reason_dept,
            this.essential_reason_qc,
            this.reason_type,
            this.reason_type_big,
            this.mo_id,
            this.goods_id,
            this.goods_name});
            this.dgvDetails.GridControl = this.gcDetails;
            this.dgvDetails.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.OptionsSelection.MultiSelect = true;
            this.dgvDetails.OptionsView.ColumnAutoWidth = false;
            this.dgvDetails.OptionsView.ShowGroupPanel = false;
            this.dgvDetails.PaintStyleName = "Style3D";
            this.dgvDetails.RowHeight = 30;
            this.dgvDetails.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDetails_MouseDown);
            // 
            // id
            // 
            this.id.Caption = "編號";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.OptionsColumn.AllowEdit = false;
            this.id.OptionsColumn.AllowMove = false;
            this.id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.id.OptionsColumn.ReadOnly = true;
            this.id.OptionsFilter.AllowAutoFilter = false;
            this.id.OptionsFilter.AllowFilter = false;
            this.id.Visible = true;
            this.id.VisibleIndex = 0;
            this.id.Width = 84;
            // 
            // appellate_date
            // 
            this.appellate_date.Caption = "受理日期";
            this.appellate_date.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.appellate_date.FieldName = "appellate_date";
            this.appellate_date.Name = "appellate_date";
            this.appellate_date.OptionsColumn.AllowEdit = false;
            this.appellate_date.OptionsColumn.AllowMove = false;
            this.appellate_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.appellate_date.OptionsColumn.ReadOnly = true;
            this.appellate_date.OptionsFilter.AllowAutoFilter = false;
            this.appellate_date.OptionsFilter.AllowFilter = false;
            this.appellate_date.Visible = true;
            this.appellate_date.VisibleIndex = 1;
            this.appellate_date.Width = 76;
            // 
            // customer_id
            // 
            this.customer_id.Caption = "客戶編號";
            this.customer_id.FieldName = "customer_id";
            this.customer_id.Name = "customer_id";
            this.customer_id.OptionsColumn.AllowEdit = false;
            this.customer_id.OptionsColumn.AllowMove = false;
            this.customer_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.customer_id.OptionsColumn.ReadOnly = true;
            this.customer_id.OptionsFilter.AllowAutoFilter = false;
            this.customer_id.OptionsFilter.AllowFilter = false;
            this.customer_id.Visible = true;
            this.customer_id.VisibleIndex = 2;
            this.customer_id.Width = 74;
            // 
            // exception_note_id
            // 
            this.exception_note_id.Caption = "產品異常通知單編號";
            this.exception_note_id.FieldName = "exception_note_id";
            this.exception_note_id.Name = "exception_note_id";
            this.exception_note_id.OptionsColumn.AllowEdit = false;
            this.exception_note_id.OptionsColumn.AllowMove = false;
            this.exception_note_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.exception_note_id.OptionsColumn.ReadOnly = true;
            this.exception_note_id.OptionsFilter.AllowAutoFilter = false;
            this.exception_note_id.OptionsFilter.AllowFilter = false;
            this.exception_note_id.Visible = true;
            this.exception_note_id.VisibleIndex = 3;
            this.exception_note_id.Width = 118;
            // 
            // reslove_pro_revert
            // 
            this.reslove_pro_revert.Caption = "即時解決方案回應";
            this.reslove_pro_revert.FieldName = "reslove_pro_revert";
            this.reslove_pro_revert.Name = "reslove_pro_revert";
            this.reslove_pro_revert.OptionsColumn.AllowEdit = false;
            this.reslove_pro_revert.OptionsColumn.AllowMove = false;
            this.reslove_pro_revert.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.reslove_pro_revert.OptionsColumn.ReadOnly = true;
            this.reslove_pro_revert.OptionsFilter.AllowAutoFilter = false;
            this.reslove_pro_revert.OptionsFilter.AllowFilter = false;
            this.reslove_pro_revert.Visible = true;
            this.reslove_pro_revert.VisibleIndex = 4;
            this.reslove_pro_revert.Width = 150;
            // 
            // essential_reason_dept
            // 
            this.essential_reason_dept.Caption = "產生原因(責任部門)";
            this.essential_reason_dept.FieldName = "essential_reason_dept";
            this.essential_reason_dept.Name = "essential_reason_dept";
            this.essential_reason_dept.OptionsColumn.AllowEdit = false;
            this.essential_reason_dept.OptionsColumn.AllowMove = false;
            this.essential_reason_dept.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.essential_reason_dept.OptionsColumn.ReadOnly = true;
            this.essential_reason_dept.OptionsFilter.AllowAutoFilter = false;
            this.essential_reason_dept.OptionsFilter.AllowFilter = false;
            this.essential_reason_dept.Visible = true;
            this.essential_reason_dept.VisibleIndex = 5;
            this.essential_reason_dept.Width = 126;
            // 
            // essential_reason_qc
            // 
            this.essential_reason_qc.Caption = "流出原因(QC)";
            this.essential_reason_qc.FieldName = "essential_reason_qc";
            this.essential_reason_qc.Name = "essential_reason_qc";
            this.essential_reason_qc.OptionsColumn.AllowEdit = false;
            this.essential_reason_qc.OptionsColumn.AllowMove = false;
            this.essential_reason_qc.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.essential_reason_qc.OptionsColumn.ReadOnly = true;
            this.essential_reason_qc.OptionsFilter.AllowAutoFilter = false;
            this.essential_reason_qc.OptionsFilter.AllowFilter = false;
            this.essential_reason_qc.Visible = true;
            this.essential_reason_qc.VisibleIndex = 6;
            this.essential_reason_qc.Width = 85;
            // 
            // reason_type
            // 
            this.reason_type.Caption = "原因分類";
            this.reason_type.FieldName = "reason_type";
            this.reason_type.Name = "reason_type";
            this.reason_type.OptionsColumn.AllowEdit = false;
            this.reason_type.OptionsColumn.AllowMove = false;
            this.reason_type.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.reason_type.OptionsColumn.ReadOnly = true;
            this.reason_type.OptionsFilter.AllowAutoFilter = false;
            this.reason_type.OptionsFilter.AllowFilter = false;
            this.reason_type.Visible = true;
            this.reason_type.VisibleIndex = 7;
            this.reason_type.Width = 77;
            // 
            // reason_type_big
            // 
            this.reason_type_big.AppearanceCell.Options.UseTextOptions = true;
            this.reason_type_big.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.reason_type_big.Caption = "原因分類(大類)";
            this.reason_type_big.FieldName = "reason_type_big";
            this.reason_type_big.Name = "reason_type_big";
            this.reason_type_big.OptionsColumn.AllowEdit = false;
            this.reason_type_big.OptionsColumn.AllowMove = false;
            this.reason_type_big.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.reason_type_big.OptionsColumn.ReadOnly = true;
            this.reason_type_big.OptionsFilter.AllowAutoFilter = false;
            this.reason_type_big.OptionsFilter.AllowFilter = false;
            this.reason_type_big.Visible = true;
            this.reason_type_big.VisibleIndex = 8;
            this.reason_type_big.Width = 95;
            // 
            // mo_id
            // 
            this.mo_id.Caption = "頁數";
            this.mo_id.FieldName = "mo_id";
            this.mo_id.Name = "mo_id";
            this.mo_id.OptionsColumn.AllowEdit = false;
            this.mo_id.OptionsColumn.AllowMove = false;
            this.mo_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.mo_id.OptionsColumn.ReadOnly = true;
            this.mo_id.OptionsFilter.AllowAutoFilter = false;
            this.mo_id.OptionsFilter.AllowFilter = false;
            this.mo_id.Visible = true;
            this.mo_id.VisibleIndex = 9;
            this.mo_id.Width = 80;
            // 
            // goods_id
            // 
            this.goods_id.Caption = "貨品編號";
            this.goods_id.FieldName = "goods_id";
            this.goods_id.Name = "goods_id";
            this.goods_id.OptionsColumn.AllowEdit = false;
            this.goods_id.OptionsColumn.AllowMove = false;
            this.goods_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.goods_id.OptionsColumn.ReadOnly = true;
            this.goods_id.OptionsFilter.AllowAutoFilter = false;
            this.goods_id.OptionsFilter.AllowFilter = false;
            this.goods_id.Visible = true;
            this.goods_id.VisibleIndex = 10;
            this.goods_id.Width = 120;
            // 
            // goods_name
            // 
            this.goods_name.Caption = "貨品名稱";
            this.goods_name.FieldName = "goods_name";
            this.goods_name.Name = "goods_name";
            this.goods_name.OptionsColumn.AllowEdit = false;
            this.goods_name.OptionsColumn.AllowMove = false;
            this.goods_name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.goods_name.OptionsFilter.AllowAutoFilter = false;
            this.goods_name.OptionsFilter.AllowFilter = false;
            this.goods_name.Visible = true;
            this.goods_name.VisibleIndex = 11;
            this.goods_name.Width = 200;
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(27, 18);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(52, 14);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "單據編號:";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(26, 44);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(52, 14);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "受理日期:";
            // 
            // lblMo_id
            // 
            this.lblMo_id.Location = new System.Drawing.Point(355, 44);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(52, 14);
            this.lblMo_id.TabIndex = 0;
            this.lblMo_id.Text = "制單編號:";
            // 
            // txtId1
            // 
            this.txtId1.EditValue = "";
            this.txtId1.EnterMoveNextControl = true;
            this.txtId1.Location = new System.Drawing.Point(85, 15);
            this.txtId1.Name = "txtId1";
            this.txtId1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId1.Properties.MaxLength = 12;
            this.txtId1.Size = new System.Drawing.Size(107, 20);
            this.txtId1.TabIndex = 0;
            this.txtId1.Leave += new System.EventHandler(this.txtId1_Leave);
            // 
            // txtMo_id1
            // 
            this.txtMo_id1.EditValue = "";
            this.txtMo_id1.EnterMoveNextControl = true;
            this.txtMo_id1.Location = new System.Drawing.Point(413, 41);
            this.txtMo_id1.Name = "txtMo_id1";
            this.txtMo_id1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id1.Properties.MaxLength = 9;
            this.txtMo_id1.Size = new System.Drawing.Size(107, 20);
            this.txtMo_id1.TabIndex = 6;
            this.txtMo_id1.Leave += new System.EventHandler(this.txtMo_id1_Leave);
            // 
            // txtId2
            // 
            this.txtId2.EditValue = "";
            this.txtId2.EnterMoveNextControl = true;
            this.txtId2.Location = new System.Drawing.Point(214, 15);
            this.txtId2.Name = "txtId2";
            this.txtId2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId2.Properties.MaxLength = 12;
            this.txtId2.Size = new System.Drawing.Size(107, 20);
            this.txtId2.TabIndex = 1;
            // 
            // txtMo_id2
            // 
            this.txtMo_id2.EditValue = "";
            this.txtMo_id2.EnterMoveNextControl = true;
            this.txtMo_id2.Location = new System.Drawing.Point(542, 41);
            this.txtMo_id2.Name = "txtMo_id2";
            this.txtMo_id2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id2.Properties.MaxLength = 9;
            this.txtMo_id2.Size = new System.Drawing.Size(107, 20);
            this.txtMo_id2.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(199, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(8, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "--";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(527, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(8, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "--";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.txtCust2);
            this.panelControl1.Controls.Add(this.txtCust1);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.dtDate2);
            this.panelControl1.Controls.Add(this.dtDate1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtMo_id2);
            this.panelControl1.Controls.Add(this.txtId2);
            this.panelControl1.Controls.Add(this.txtMo_id1);
            this.panelControl1.Controls.Add(this.txtId1);
            this.panelControl1.Controls.Add(this.lblMo_id);
            this.panelControl1.Controls.Add(this.lblDate);
            this.panelControl1.Controls.Add(this.lblId);
            this.panelControl1.Location = new System.Drawing.Point(0, 38);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1016, 78);
            this.panelControl1.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(527, 18);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(8, 14);
            this.labelControl5.TabIndex = 203;
            this.labelControl5.Text = "--";
            // 
            // txtCust2
            // 
            this.txtCust2.EditValue = "";
            this.txtCust2.EnterMoveNextControl = true;
            this.txtCust2.Location = new System.Drawing.Point(542, 15);
            this.txtCust2.Name = "txtCust2";
            this.txtCust2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCust2.Properties.MaxLength = 9;
            this.txtCust2.Size = new System.Drawing.Size(107, 20);
            this.txtCust2.TabIndex = 5;
            // 
            // txtCust1
            // 
            this.txtCust1.EditValue = "";
            this.txtCust1.EnterMoveNextControl = true;
            this.txtCust1.Location = new System.Drawing.Point(413, 15);
            this.txtCust1.Name = "txtCust1";
            this.txtCust1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCust1.Properties.MaxLength = 9;
            this.txtCust1.Size = new System.Drawing.Size(107, 20);
            this.txtCust1.TabIndex = 4;
            this.txtCust1.Leave += new System.EventHandler(this.txtCust1_Leave);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(355, 18);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(52, 14);
            this.labelControl6.TabIndex = 200;
            this.labelControl6.Text = "客戶編號:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(199, 44);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(8, 14);
            this.labelControl3.TabIndex = 197;
            this.labelControl3.Text = "--";
            // 
            // dtDate2
            // 
            this.dtDate2.EditValue = "";
            this.dtDate2.EnterMoveNextControl = true;
            this.dtDate2.Location = new System.Drawing.Point(214, 41);
            this.dtDate2.Name = "dtDate2";
            this.dtDate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate2.Properties.Mask.BeepOnError = true;
            this.dtDate2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dtDate2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDate2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtDate2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDate2.Size = new System.Drawing.Size(107, 20);
            this.dtDate2.TabIndex = 3;
            this.dtDate2.Tag = "2";
            // 
            // dtDate1
            // 
            this.dtDate1.EditValue = "";
            this.dtDate1.EnterMoveNextControl = true;
            this.dtDate1.Location = new System.Drawing.Point(85, 41);
            this.dtDate1.Name = "dtDate1";
            this.dtDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate1.Properties.Mask.BeepOnError = true;
            this.dtDate1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dtDate1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDate1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtDate1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDate1.Size = new System.Drawing.Size(107, 20);
            this.dtDate1.TabIndex = 2;
            this.dtDate1.Tag = "2";
            this.dtDate1.Leave += new System.EventHandler(this.dtDate1_Leave);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNSAVESET
            // 
            this.BTNSAVESET.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVESET.Image")));
            this.BTNSAVESET.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVESET.Name = "BTNSAVESET";
            this.BTNSAVESET.Size = new System.Drawing.Size(97, 35);
            this.BTNSAVESET.Text = "保存查找條件";
            this.BTNSAVESET.Click += new System.EventHandler(this.BTNSAVESET_Click);
            // 
            // frmCustComplain_Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 691);
            this.Controls.Add(this.gcDetails);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCustComplain_Find";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCustComplain_Find";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevExpress.XtraGrid.GridControl gcDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetails;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn appellate_date;
        private DevExpress.XtraGrid.Columns.GridColumn customer_id;
        private DevExpress.XtraGrid.Columns.GridColumn exception_note_id;
        private DevExpress.XtraGrid.Columns.GridColumn reslove_pro_revert;
        private DevExpress.XtraGrid.Columns.GridColumn essential_reason_dept;
        private DevExpress.XtraGrid.Columns.GridColumn essential_reason_qc;
        private DevExpress.XtraGrid.Columns.GridColumn reason_type;
        private System.Windows.Forms.ToolStripButton btnConf;
        private DevExpress.XtraGrid.Columns.GridColumn reason_type_big;
        private DevExpress.XtraEditors.LabelControl lblId;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.LabelControl lblMo_id;
        private DevExpress.XtraEditors.TextEdit txtId1;
        private DevExpress.XtraEditors.TextEdit txtMo_id1;
        private DevExpress.XtraEditors.TextEdit txtId2;
        private DevExpress.XtraEditors.TextEdit txtMo_id2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dtDate2;
        private DevExpress.XtraEditors.DateEdit dtDate1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn mo_id;
        private DevExpress.XtraGrid.Columns.GridColumn goods_id;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtCust2;
        private DevExpress.XtraEditors.TextEdit txtCust1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraGrid.Columns.GridColumn goods_name;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BTNSAVESET;
    }
}