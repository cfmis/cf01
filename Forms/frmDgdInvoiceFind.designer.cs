namespace cf01.Forms
{
    partial class frmDgdInvoiceFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDgdInvoiceFind));
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
            this.btnImput = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtFindMo_id = new DevExpress.XtraEditors.TextEdit();
            this.lblFindMo_id = new DevExpress.XtraEditors.LabelControl();
            this.txtFindId = new DevExpress.XtraEditors.TextEdit();
            this.lblFindId = new DevExpress.XtraEditors.LabelControl();
            this.txtFindOc_no = new DevExpress.XtraEditors.TextEdit();
            this.lblFindOc_no = new DevExpress.XtraEditors.LabelControl();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gcIdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindMo_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindOc_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOcDgdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcDgdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcIdDetails
            // 
            this.gcIdDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcIdDetails.Location = new System.Drawing.Point(4, 69);
            this.gcIdDetails.MainView = this.dgvIdDetails;
            this.gcIdDetails.Name = "gcIdDetails";
            this.gcIdDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcIdDetails.Size = new System.Drawing.Size(1301, 438);
            this.gcIdDetails.TabIndex = 2;
            this.gcIdDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvIdDetails});
            // 
            // dgvIdDetails
            // 
            this.dgvIdDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
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
            this.dgvIdDetails.PaintStyleName = "Style3D";
            this.dgvIdDetails.RowHeight = 30;
            this.dgvIdDetails.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.dgvIdDetails.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.dgvIdDetails_SelectionChanged);
            // 
            // colId_chkSelect
            // 
            this.colId_chkSelect.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.colId_chkSelect.AppearanceCell.Options.UseBackColor = true;
            this.colId_chkSelect.Caption = "選取";
            this.colId_chkSelect.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colId_chkSelect.FieldName = "is_select";
            this.colId_chkSelect.Name = "colId_chkSelect";
            this.colId_chkSelect.OptionsColumn.AllowMove = false;
            this.colId_chkSelect.OptionsFilter.AllowAutoFilter = false;
            this.colId_chkSelect.OptionsFilter.AllowFilter = false;
            this.colId_chkSelect.Visible = true;
            this.colId_chkSelect.VisibleIndex = 0;
            this.colId_chkSelect.Width = 54;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colId_Id
            // 
            this.colId_Id.Caption = "單據編號";
            this.colId_Id.FieldName = "id";
            this.colId_Id.Name = "colId_Id";
            this.colId_Id.OptionsColumn.AllowEdit = false;
            this.colId_Id.OptionsColumn.AllowMove = false;
            this.colId_Id.OptionsFilter.AllowAutoFilter = false;
            this.colId_Id.OptionsFilter.AllowFilter = false;
            this.colId_Id.Visible = true;
            this.colId_Id.VisibleIndex = 1;
            this.colId_Id.Width = 100;
            // 
            // colId_Ship_date
            // 
            this.colId_Ship_date.Caption = "單據日期";
            this.colId_Ship_date.FieldName = "ship_date";
            this.colId_Ship_date.Name = "colId_Ship_date";
            this.colId_Ship_date.OptionsColumn.AllowEdit = false;
            this.colId_Ship_date.OptionsColumn.AllowMove = false;
            this.colId_Ship_date.OptionsFilter.AllowAutoFilter = false;
            this.colId_Ship_date.OptionsFilter.AllowFilter = false;
            this.colId_Ship_date.Visible = true;
            this.colId_Ship_date.VisibleIndex = 2;
            this.colId_Ship_date.Width = 80;
            // 
            // colId_Sequence_id
            // 
            this.colId_Sequence_id.Caption = "序號";
            this.colId_Sequence_id.FieldName = "sequence_id";
            this.colId_Sequence_id.Name = "colId_Sequence_id";
            this.colId_Sequence_id.OptionsColumn.AllowEdit = false;
            this.colId_Sequence_id.OptionsColumn.AllowMove = false;
            this.colId_Sequence_id.OptionsFilter.AllowAutoFilter = false;
            this.colId_Sequence_id.OptionsFilter.AllowFilter = false;
            this.colId_Sequence_id.Visible = true;
            this.colId_Sequence_id.VisibleIndex = 3;
            this.colId_Sequence_id.Width = 60;
            // 
            // colId_Mo_id
            // 
            this.colId_Mo_id.Caption = "制單編號";
            this.colId_Mo_id.FieldName = "mo_id";
            this.colId_Mo_id.Name = "colId_Mo_id";
            this.colId_Mo_id.OptionsColumn.AllowEdit = false;
            this.colId_Mo_id.OptionsColumn.AllowMove = false;
            this.colId_Mo_id.OptionsFilter.AllowAutoFilter = false;
            this.colId_Mo_id.OptionsFilter.AllowFilter = false;
            this.colId_Mo_id.Visible = true;
            this.colId_Mo_id.VisibleIndex = 4;
            this.colId_Mo_id.Width = 85;
            // 
            // colId_Goods_id
            // 
            this.colId_Goods_id.Caption = "產品編號";
            this.colId_Goods_id.FieldName = "goods_id";
            this.colId_Goods_id.Name = "colId_Goods_id";
            this.colId_Goods_id.OptionsColumn.AllowEdit = false;
            this.colId_Goods_id.OptionsColumn.AllowMove = false;
            this.colId_Goods_id.OptionsFilter.AllowAutoFilter = false;
            this.colId_Goods_id.OptionsFilter.AllowFilter = false;
            this.colId_Goods_id.Visible = true;
            this.colId_Goods_id.VisibleIndex = 5;
            this.colId_Goods_id.Width = 127;
            // 
            // colId_Goods_name
            // 
            this.colId_Goods_name.Caption = "產品描述";
            this.colId_Goods_name.FieldName = "goods_name";
            this.colId_Goods_name.Name = "colId_Goods_name";
            this.colId_Goods_name.OptionsColumn.AllowEdit = false;
            this.colId_Goods_name.OptionsColumn.AllowMove = false;
            this.colId_Goods_name.OptionsFilter.AllowAutoFilter = false;
            this.colId_Goods_name.OptionsFilter.AllowFilter = false;
            this.colId_Goods_name.Visible = true;
            this.colId_Goods_name.VisibleIndex = 6;
            this.colId_Goods_name.Width = 300;
            // 
            // colId_U_invoice_qty
            // 
            this.colId_U_invoice_qty.Caption = "發貨數量";
            this.colId_U_invoice_qty.FieldName = "u_invoice_qty";
            this.colId_U_invoice_qty.Name = "colId_U_invoice_qty";
            this.colId_U_invoice_qty.OptionsColumn.AllowEdit = false;
            this.colId_U_invoice_qty.OptionsColumn.AllowMove = false;
            this.colId_U_invoice_qty.OptionsFilter.AllowAutoFilter = false;
            this.colId_U_invoice_qty.OptionsFilter.AllowFilter = false;
            this.colId_U_invoice_qty.Visible = true;
            this.colId_U_invoice_qty.VisibleIndex = 7;
            this.colId_U_invoice_qty.Width = 80;
            // 
            // colId_Goods_unit
            // 
            this.colId_Goods_unit.AppearanceCell.Options.UseTextOptions = true;
            this.colId_Goods_unit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId_Goods_unit.Caption = "數量單位";
            this.colId_Goods_unit.FieldName = "goods_unit";
            this.colId_Goods_unit.Name = "colId_Goods_unit";
            this.colId_Goods_unit.OptionsColumn.AllowEdit = false;
            this.colId_Goods_unit.OptionsColumn.AllowMove = false;
            this.colId_Goods_unit.OptionsFilter.AllowAutoFilter = false;
            this.colId_Goods_unit.OptionsFilter.AllowFilter = false;
            this.colId_Goods_unit.Visible = true;
            this.colId_Goods_unit.VisibleIndex = 8;
            this.colId_Goods_unit.Width = 80;
            // 
            // colId_Sec_qty
            // 
            this.colId_Sec_qty.Caption = "重量";
            this.colId_Sec_qty.FieldName = "sec_qty";
            this.colId_Sec_qty.Name = "colId_Sec_qty";
            this.colId_Sec_qty.OptionsColumn.AllowEdit = false;
            this.colId_Sec_qty.OptionsColumn.AllowMove = false;
            this.colId_Sec_qty.OptionsFilter.AllowAutoFilter = false;
            this.colId_Sec_qty.OptionsFilter.AllowFilter = false;
            this.colId_Sec_qty.Visible = true;
            this.colId_Sec_qty.VisibleIndex = 9;
            this.colId_Sec_qty.Width = 60;
            // 
            // colId_Sec_unit
            // 
            this.colId_Sec_unit.AppearanceCell.Options.UseTextOptions = true;
            this.colId_Sec_unit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId_Sec_unit.Caption = "重量單位";
            this.colId_Sec_unit.FieldName = "sec_unit";
            this.colId_Sec_unit.Name = "colId_Sec_unit";
            this.colId_Sec_unit.OptionsColumn.AllowEdit = false;
            this.colId_Sec_unit.OptionsColumn.AllowMove = false;
            this.colId_Sec_unit.OptionsFilter.AllowAutoFilter = false;
            this.colId_Sec_unit.OptionsFilter.AllowFilter = false;
            this.colId_Sec_unit.Visible = true;
            this.colId_Sec_unit.VisibleIndex = 10;
            this.colId_Sec_unit.Width = 80;
            // 
            // colId_Order_id
            // 
            this.colId_Order_id.Caption = "OC No";
            this.colId_Order_id.FieldName = "order_id";
            this.colId_Order_id.Name = "colId_Order_id";
            this.colId_Order_id.OptionsColumn.AllowEdit = false;
            this.colId_Order_id.OptionsColumn.AllowMove = false;
            this.colId_Order_id.OptionsFilter.AllowAutoFilter = false;
            this.colId_Order_id.OptionsFilter.AllowFilter = false;
            this.colId_Order_id.Visible = true;
            this.colId_Order_id.VisibleIndex = 11;
            this.colId_Order_id.Width = 100;
            // 
            // btnImput
            // 
            this.btnImput.Image = ((System.Drawing.Image)(resources.GetObject("btnImput.Image")));
            this.btnImput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImput.Location = new System.Drawing.Point(775, 10);
            this.btnImput.Name = "btnImput";
            this.btnImput.Size = new System.Drawing.Size(80, 35);
            this.btnImput.TabIndex = 3;
            this.btnImput.Text = "過 賬  ";
            this.btnImput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImput.UseVisualStyleBackColor = true;
            this.btnImput.Click += new System.EventHandler(this.btnImput_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::cf01.Properties.Resources.find;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(663, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(80, 35);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查 找(&F)";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtFindMo_id
            // 
            this.txtFindMo_id.Location = new System.Drawing.Point(495, 14);
            this.txtFindMo_id.Name = "txtFindMo_id";
            this.txtFindMo_id.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFindMo_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFindMo_id.Size = new System.Drawing.Size(100, 22);
            this.txtFindMo_id.TabIndex = 2;
            // 
            // lblFindMo_id
            // 
            this.lblFindMo_id.Location = new System.Drawing.Point(439, 17);
            this.lblFindMo_id.Name = "lblFindMo_id";
            this.lblFindMo_id.Size = new System.Drawing.Size(52, 14);
            this.lblFindMo_id.TabIndex = 0;
            this.lblFindMo_id.Text = "制單頁數:";
            // 
            // txtFindId
            // 
            this.txtFindId.Location = new System.Drawing.Point(314, 14);
            this.txtFindId.Name = "txtFindId";
            this.txtFindId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFindId.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFindId.Size = new System.Drawing.Size(100, 22);
            this.txtFindId.TabIndex = 1;
            // 
            // lblFindId
            // 
            this.lblFindId.Location = new System.Drawing.Point(258, 17);
            this.lblFindId.Name = "lblFindId";
            this.lblFindId.Size = new System.Drawing.Size(52, 14);
            this.lblFindId.TabIndex = 0;
            this.lblFindId.Text = "單據編號:";
            // 
            // txtFindOc_no
            // 
            this.txtFindOc_no.Location = new System.Drawing.Point(105, 14);
            this.txtFindOc_no.Name = "txtFindOc_no";
            this.txtFindOc_no.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFindOc_no.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFindOc_no.Size = new System.Drawing.Size(126, 22);
            this.txtFindOc_no.TabIndex = 0;
            // 
            // lblFindOc_no
            // 
            this.lblFindOc_no.Location = new System.Drawing.Point(56, 17);
            this.lblFindOc_no.Name = "lblFindOc_no";
            this.lblFindOc_no.Size = new System.Drawing.Size(43, 14);
            this.lblFindOc_no.TabIndex = 0;
            this.lblFindOc_no.Text = "Oc編號:";
            // 
            // gcOcDgdDetails
            // 
            this.gcOcDgdDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcOcDgdDetails.Location = new System.Drawing.Point(4, 511);
            this.gcOcDgdDetails.MainView = this.dgvOcDgdDetails;
            this.gcOcDgdDetails.Name = "gcOcDgdDetails";
            this.gcOcDgdDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.gcOcDgdDetails.Size = new System.Drawing.Size(1301, 359);
            this.gcOcDgdDetails.TabIndex = 3;
            this.gcOcDgdDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvOcDgdDetails});
            // 
            // dgvOcDgdDetails
            // 
            this.dgvOcDgdDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
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
            this.dgvOcDgdDetails.OptionsBehavior.Editable = false;
            this.dgvOcDgdDetails.OptionsSelection.MultiSelect = true;
            this.dgvOcDgdDetails.OptionsView.ColumnAutoWidth = false;
            this.dgvOcDgdDetails.OptionsView.ShowGroupPanel = false;
            this.dgvOcDgdDetails.PaintStyleName = "Style3D";
            this.dgvOcDgdDetails.RowHeight = 30;
            this.dgvOcDgdDetails.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
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
            this.colOc_Goods_name.Width = 270;
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
            this.colOc_Goods_unit.AppearanceCell.Options.UseTextOptions = true;
            this.colOc_Goods_unit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            this.colOc_Sec_unit.AppearanceCell.Options.UseTextOptions = true;
            this.colOc_Sec_unit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnImput);
            this.panel1.Controls.Add(this.lblFindId);
            this.panel1.Controls.Add(this.txtFindOc_no);
            this.panel1.Controls.Add(this.txtFindId);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.lblFindOc_no);
            this.panel1.Controls.Add(this.txtFindMo_id);
            this.panel1.Controls.Add(this.lblFindMo_id);
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1301, 65);
            this.panel1.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.Image = global::cf01.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(918, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 35);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退 出(&X)";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmDgdInvoiceFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 872);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gcOcDgdDetails);
            this.Controls.Add(this.gcIdDetails);
            this.Name = "frmDgdInvoiceFind";
            this.Text = "frmDgInvoiceFind";
            ((System.ComponentModel.ISupportInitialize)(this.gcIdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindMo_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindOc_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOcDgdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcDgdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtFindOc_no;
        private DevExpress.XtraEditors.LabelControl lblFindOc_no;
        private DevExpress.XtraEditors.TextEdit txtFindId;
        private DevExpress.XtraEditors.LabelControl lblFindId;
        private DevExpress.XtraEditors.TextEdit txtFindMo_id;
        private DevExpress.XtraEditors.LabelControl lblFindMo_id;
        private System.Windows.Forms.Button btnQuery;
        private DevExpress.XtraGrid.GridControl gcIdDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvIdDetails;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
    }
}