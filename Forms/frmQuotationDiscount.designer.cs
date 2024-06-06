namespace cf01.Forms
{
    partial class frmQuotationDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuotationDiscount));
            this.txtTemp_code = new DevExpress.XtraEditors.TextEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.seq_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.number_enter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBp = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.moq_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.valid_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.price_usd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clprice = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.price_hkd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.price_rmb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.usd_ex_fty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hkd_ex_fty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.price_unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vnd_bp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.price_vnd_usd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.price_vnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.price_vnd_grs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.price_vnd_pcs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.create_by = new DevExpress.XtraGrid.Columns.GridColumn();
            this.create_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.update_by = new DevExpress.XtraGrid.Columns.GridColumn();
            this.update_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.temp_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNDELETE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemp_code.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clBp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clprice)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTemp_code
            // 
            this.txtTemp_code.Location = new System.Drawing.Point(647, 13);
            this.txtTemp_code.Name = "txtTemp_code";
            this.txtTemp_code.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtTemp_code.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtTemp_code.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTemp_code.Properties.ReadOnly = true;
            this.txtTemp_code.Size = new System.Drawing.Size(113, 20);
            this.txtTemp_code.TabIndex = 256;
            this.txtTemp_code.Tag = "1";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.gridControl1);
            this.panel3.Location = new System.Drawing.Point(2, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1239, 555);
            this.panel3.TabIndex = 11;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.clBp,
            this.clprice,
            this.clQty});
            this.gridControl1.Size = new System.Drawing.Size(1234, 533);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.seq_id,
            this.number_enter,
            this.moq_qty,
            this.valid_date,
            this.remark,
            this.price_usd,
            this.price_hkd,
            this.price_rmb,
            this.usd_ex_fty,
            this.hkd_ex_fty,
            this.price_unit,
            this.vnd_bp,
            this.price_vnd_usd,
            this.price_vnd,
            this.price_vnd_grs,
            this.price_vnd_pcs,
            this.create_by,
            this.create_date,
            this.update_by,
            this.update_date,
            this.temp_code});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "Style3D";
            this.gridView1.RowHeight = 30;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // seq_id
            // 
            this.seq_id.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.seq_id.AppearanceHeader.Options.UseFont = true;
            this.seq_id.Caption = "No.";
            this.seq_id.FieldName = "seq_id";
            this.seq_id.Name = "seq_id";
            this.seq_id.OptionsColumn.ReadOnly = true;
            this.seq_id.OptionsFilter.AllowAutoFilter = false;
            this.seq_id.OptionsFilter.AllowFilter = false;
            this.seq_id.Visible = true;
            this.seq_id.VisibleIndex = 0;
            this.seq_id.Width = 34;
            // 
            // number_enter
            // 
            this.number_enter.AppearanceCell.ForeColor = System.Drawing.Color.Maroon;
            this.number_enter.AppearanceCell.Options.UseForeColor = true;
            this.number_enter.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.number_enter.AppearanceHeader.Options.UseFont = true;
            this.number_enter.Caption = "BP";
            this.number_enter.ColumnEdit = this.clBp;
            this.number_enter.FieldName = "number_enter";
            this.number_enter.Name = "number_enter";
            this.number_enter.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.number_enter.OptionsColumn.AllowMove = false;
            this.number_enter.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.number_enter.OptionsFilter.AllowAutoFilter = false;
            this.number_enter.OptionsFilter.AllowFilter = false;
            this.number_enter.Tag = "2";
            this.number_enter.Visible = true;
            this.number_enter.VisibleIndex = 1;
            this.number_enter.Width = 76;
            // 
            // clBp
            // 
            this.clBp.AutoHeight = false;
            this.clBp.DisplayFormat.FormatString = "n3";
            this.clBp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clBp.EditFormat.FormatString = "n3";
            this.clBp.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clBp.Mask.EditMask = "n3";
            this.clBp.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.clBp.Name = "clBp";
            this.clBp.Leave += new System.EventHandler(this.clBp_Leave);
            // 
            // moq_qty
            // 
            this.moq_qty.Caption = "Moq(Pcs)";
            this.moq_qty.ColumnEdit = this.clQty;
            this.moq_qty.FieldName = "moq_qty";
            this.moq_qty.Name = "moq_qty";
            this.moq_qty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.moq_qty.OptionsColumn.AllowMove = false;
            this.moq_qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.moq_qty.OptionsFilter.AllowAutoFilter = false;
            this.moq_qty.OptionsFilter.AllowFilter = false;
            this.moq_qty.Visible = true;
            this.moq_qty.VisibleIndex = 2;
            this.moq_qty.Width = 68;
            // 
            // clQty
            // 
            this.clQty.AutoHeight = false;
            this.clQty.DisplayFormat.FormatString = "n0";
            this.clQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clQty.EditFormat.FormatString = "n0";
            this.clQty.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clQty.Mask.EditMask = "n0";
            this.clQty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.clQty.Name = "clQty";
            // 
            // valid_date
            // 
            this.valid_date.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valid_date.AppearanceHeader.Options.UseFont = true;
            this.valid_date.Caption = "Valid Date";
            this.valid_date.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.valid_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.valid_date.FieldName = "valid_date";
            this.valid_date.Name = "valid_date";
            this.valid_date.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.valid_date.OptionsColumn.AllowMove = false;
            this.valid_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.valid_date.OptionsFilter.AllowAutoFilter = false;
            this.valid_date.OptionsFilter.AllowFilter = false;
            this.valid_date.Visible = true;
            this.valid_date.VisibleIndex = 3;
            this.valid_date.Width = 90;
            // 
            // remark
            // 
            this.remark.Caption = "Remark";
            this.remark.FieldName = "remark";
            this.remark.Name = "remark";
            this.remark.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.remark.OptionsColumn.AllowMove = false;
            this.remark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.remark.OptionsFilter.AllowAutoFilter = false;
            this.remark.OptionsFilter.AllowFilter = false;
            this.remark.Visible = true;
            this.remark.VisibleIndex = 4;
            this.remark.Width = 113;
            // 
            // price_usd
            // 
            this.price_usd.Caption = "USD";
            this.price_usd.ColumnEdit = this.clprice;
            this.price_usd.FieldName = "price_usd";
            this.price_usd.Name = "price_usd";
            this.price_usd.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.price_usd.OptionsColumn.AllowMove = false;
            this.price_usd.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.price_usd.OptionsFilter.AllowAutoFilter = false;
            this.price_usd.OptionsFilter.AllowFilter = false;
            this.price_usd.Visible = true;
            this.price_usd.VisibleIndex = 5;
            this.price_usd.Width = 69;
            // 
            // clprice
            // 
            this.clprice.AutoHeight = false;
            this.clprice.DisplayFormat.FormatString = "n3";
            this.clprice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clprice.EditFormat.FormatString = "n3";
            this.clprice.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clprice.Mask.EditMask = "n3";
            this.clprice.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.clprice.Name = "clprice";
            this.clprice.NullText = "0";
            // 
            // price_hkd
            // 
            this.price_hkd.Caption = "HKD";
            this.price_hkd.ColumnEdit = this.clprice;
            this.price_hkd.FieldName = "price_hkd";
            this.price_hkd.Name = "price_hkd";
            this.price_hkd.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.price_hkd.OptionsColumn.AllowMove = false;
            this.price_hkd.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.price_hkd.OptionsFilter.AllowAutoFilter = false;
            this.price_hkd.OptionsFilter.AllowFilter = false;
            this.price_hkd.Tag = "";
            this.price_hkd.Visible = true;
            this.price_hkd.VisibleIndex = 6;
            this.price_hkd.Width = 66;
            // 
            // price_rmb
            // 
            this.price_rmb.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price_rmb.AppearanceHeader.Options.UseFont = true;
            this.price_rmb.Caption = "RMB";
            this.price_rmb.ColumnEdit = this.clprice;
            this.price_rmb.FieldName = "price_rmb";
            this.price_rmb.Name = "price_rmb";
            this.price_rmb.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.price_rmb.OptionsColumn.AllowMove = false;
            this.price_rmb.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.price_rmb.OptionsFilter.AllowAutoFilter = false;
            this.price_rmb.OptionsFilter.AllowFilter = false;
            this.price_rmb.Visible = true;
            this.price_rmb.VisibleIndex = 7;
            this.price_rmb.Width = 76;
            // 
            // usd_ex_fty
            // 
            this.usd_ex_fty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usd_ex_fty.AppearanceHeader.Options.UseFont = true;
            this.usd_ex_fty.Caption = "USD Ex-Fty";
            this.usd_ex_fty.ColumnEdit = this.clprice;
            this.usd_ex_fty.FieldName = "usd_ex_fty";
            this.usd_ex_fty.Name = "usd_ex_fty";
            this.usd_ex_fty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.usd_ex_fty.OptionsColumn.AllowMove = false;
            this.usd_ex_fty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.usd_ex_fty.OptionsFilter.AllowAutoFilter = false;
            this.usd_ex_fty.OptionsFilter.AllowFilter = false;
            this.usd_ex_fty.Visible = true;
            this.usd_ex_fty.VisibleIndex = 8;
            this.usd_ex_fty.Width = 76;
            // 
            // hkd_ex_fty
            // 
            this.hkd_ex_fty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hkd_ex_fty.AppearanceHeader.Options.UseFont = true;
            this.hkd_ex_fty.Caption = "USD Ex-Fty";
            this.hkd_ex_fty.ColumnEdit = this.clprice;
            this.hkd_ex_fty.FieldName = "hkd_ex_fty";
            this.hkd_ex_fty.Name = "hkd_ex_fty";
            this.hkd_ex_fty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.hkd_ex_fty.OptionsColumn.AllowMove = false;
            this.hkd_ex_fty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.hkd_ex_fty.OptionsFilter.AllowAutoFilter = false;
            this.hkd_ex_fty.OptionsFilter.AllowFilter = false;
            this.hkd_ex_fty.Visible = true;
            this.hkd_ex_fty.VisibleIndex = 9;
            this.hkd_ex_fty.Width = 73;
            // 
            // price_unit
            // 
            this.price_unit.Caption = "Price Unit";
            this.price_unit.FieldName = "price_unit";
            this.price_unit.Name = "price_unit";
            this.price_unit.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.price_unit.OptionsColumn.AllowMove = false;
            this.price_unit.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.price_unit.OptionsColumn.ReadOnly = true;
            this.price_unit.OptionsFilter.AllowAutoFilter = false;
            this.price_unit.OptionsFilter.AllowFilter = false;
            this.price_unit.Visible = true;
            this.price_unit.VisibleIndex = 10;
            this.price_unit.Width = 71;
            // 
            // vnd_bp
            // 
            this.vnd_bp.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.vnd_bp.AppearanceCell.Options.UseForeColor = true;
            this.vnd_bp.Caption = "BP(VND)";
            this.vnd_bp.ColumnEdit = this.clprice;
            this.vnd_bp.FieldName = "vnd_bp";
            this.vnd_bp.Name = "vnd_bp";
            this.vnd_bp.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.vnd_bp.OptionsColumn.AllowMove = false;
            this.vnd_bp.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.vnd_bp.OptionsColumn.ReadOnly = true;
            this.vnd_bp.OptionsFilter.AllowAutoFilter = false;
            this.vnd_bp.OptionsFilter.AllowFilter = false;
            this.vnd_bp.Visible = true;
            this.vnd_bp.VisibleIndex = 11;
            this.vnd_bp.Width = 66;
            // 
            // price_vnd_usd
            // 
            this.price_vnd_usd.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.price_vnd_usd.AppearanceCell.Options.UseForeColor = true;
            this.price_vnd_usd.Caption = "VND USD";
            this.price_vnd_usd.ColumnEdit = this.clprice;
            this.price_vnd_usd.FieldName = "price_vnd_usd";
            this.price_vnd_usd.Name = "price_vnd_usd";
            this.price_vnd_usd.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.price_vnd_usd.OptionsColumn.AllowMove = false;
            this.price_vnd_usd.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.price_vnd_usd.OptionsFilter.AllowAutoFilter = false;
            this.price_vnd_usd.OptionsFilter.AllowFilter = false;
            this.price_vnd_usd.Visible = true;
            this.price_vnd_usd.VisibleIndex = 12;
            // 
            // price_vnd
            // 
            this.price_vnd.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.price_vnd.AppearanceCell.Options.UseForeColor = true;
            this.price_vnd.Caption = "VND";
            this.price_vnd.ColumnEdit = this.clprice;
            this.price_vnd.FieldName = "price_vnd";
            this.price_vnd.Name = "price_vnd";
            this.price_vnd.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.price_vnd.OptionsColumn.AllowMove = false;
            this.price_vnd.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.price_vnd.OptionsFilter.AllowAutoFilter = false;
            this.price_vnd.OptionsFilter.AllowFilter = false;
            this.price_vnd.Visible = true;
            this.price_vnd.VisibleIndex = 13;
            this.price_vnd.Width = 81;
            // 
            // price_vnd_grs
            // 
            this.price_vnd_grs.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.price_vnd_grs.AppearanceCell.Options.UseForeColor = true;
            this.price_vnd_grs.Caption = "VND/GRS";
            this.price_vnd_grs.ColumnEdit = this.clprice;
            this.price_vnd_grs.FieldName = "price_vnd_grs";
            this.price_vnd_grs.Name = "price_vnd_grs";
            this.price_vnd_grs.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.price_vnd_grs.OptionsColumn.AllowMove = false;
            this.price_vnd_grs.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.price_vnd_grs.OptionsFilter.AllowAutoFilter = false;
            this.price_vnd_grs.OptionsFilter.AllowFilter = false;
            this.price_vnd_grs.Visible = true;
            this.price_vnd_grs.VisibleIndex = 14;
            // 
            // price_vnd_pcs
            // 
            this.price_vnd_pcs.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.price_vnd_pcs.AppearanceCell.Options.UseForeColor = true;
            this.price_vnd_pcs.Caption = "VND/PCS";
            this.price_vnd_pcs.ColumnEdit = this.clprice;
            this.price_vnd_pcs.FieldName = "price_vnd_pcs";
            this.price_vnd_pcs.Name = "price_vnd_pcs";
            this.price_vnd_pcs.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.price_vnd_pcs.OptionsColumn.AllowMove = false;
            this.price_vnd_pcs.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.price_vnd_pcs.OptionsFilter.AllowAutoFilter = false;
            this.price_vnd_pcs.OptionsFilter.AllowFilter = false;
            this.price_vnd_pcs.Visible = true;
            this.price_vnd_pcs.VisibleIndex = 15;
            // 
            // create_by
            // 
            this.create_by.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create_by.AppearanceHeader.Options.UseFont = true;
            this.create_by.Caption = "Create by";
            this.create_by.FieldName = "crusr";
            this.create_by.Name = "create_by";
            this.create_by.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.create_by.OptionsColumn.AllowMove = false;
            this.create_by.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.create_by.OptionsColumn.ReadOnly = true;
            this.create_by.OptionsFilter.AllowAutoFilter = false;
            this.create_by.OptionsFilter.AllowFilter = false;
            this.create_by.Visible = true;
            this.create_by.VisibleIndex = 16;
            this.create_by.Width = 92;
            // 
            // create_date
            // 
            this.create_date.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create_date.AppearanceHeader.Options.UseFont = true;
            this.create_date.Caption = "Create date";
            this.create_date.FieldName = "crtim";
            this.create_date.Name = "create_date";
            this.create_date.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.create_date.OptionsColumn.AllowMove = false;
            this.create_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.create_date.OptionsColumn.ReadOnly = true;
            this.create_date.OptionsFilter.AllowAutoFilter = false;
            this.create_date.OptionsFilter.AllowFilter = false;
            this.create_date.Visible = true;
            this.create_date.VisibleIndex = 17;
            this.create_date.Width = 81;
            // 
            // update_by
            // 
            this.update_by.Caption = "Upadte by";
            this.update_by.FieldName = "amusr";
            this.update_by.Name = "update_by";
            this.update_by.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.update_by.OptionsColumn.AllowMove = false;
            this.update_by.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.update_by.OptionsColumn.ReadOnly = true;
            this.update_by.OptionsFilter.AllowAutoFilter = false;
            this.update_by.OptionsFilter.AllowFilter = false;
            this.update_by.Visible = true;
            this.update_by.VisibleIndex = 18;
            this.update_by.Width = 71;
            // 
            // update_date
            // 
            this.update_date.Caption = "Update Date";
            this.update_date.FieldName = "amtim";
            this.update_date.Name = "update_date";
            this.update_date.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.update_date.OptionsColumn.AllowMove = false;
            this.update_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.update_date.OptionsColumn.ReadOnly = true;
            this.update_date.OptionsFilter.AllowAutoFilter = false;
            this.update_date.OptionsFilter.AllowFilter = false;
            this.update_date.Visible = true;
            this.update_date.VisibleIndex = 19;
            this.update_date.Width = 27;
            // 
            // temp_code
            // 
            this.temp_code.Caption = "Temp_code";
            this.temp_code.FieldName = "temp_code";
            this.temp_code.Name = "temp_code";
            this.temp_code.OptionsFilter.AllowAutoFilter = false;
            this.temp_code.OptionsFilter.AllowFilter = false;
            this.temp_code.Width = 79;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNNEW,
            this.toolStripSeparator2,
            this.BTNDELETE,
            this.toolStripSeparator5,
            this.BTNCANCEL,
            this.toolStripSeparator3,
            this.BTNSAVE,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1242, 38);
            this.toolStrip1.TabIndex = 258;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.AutoSize = false;
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(65, 35);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNNEW
            // 
            this.BTNNEW.Image = ((System.Drawing.Image)(resources.GetObject("BTNNEW.Image")));
            this.BTNNEW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNNEW.Name = "BTNNEW";
            this.BTNNEW.Size = new System.Drawing.Size(65, 35);
            this.BTNNEW.Text = "新增(&A)";
            this.BTNNEW.Click += new System.EventHandler(this.BTNNEW_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNDELETE
            // 
            this.BTNDELETE.Image = ((System.Drawing.Image)(resources.GetObject("BTNDELETE.Image")));
            this.BTNDELETE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNDELETE.Name = "BTNDELETE";
            this.BTNDELETE.Size = new System.Drawing.Size(65, 35);
            this.BTNDELETE.Text = "刪除(&D)";
            this.BTNDELETE.Click += new System.EventHandler(this.BTNDELTE_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNCANCEL
            // 
            this.BTNCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNCANCEL.Image")));
            this.BTNCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCANCEL.Name = "BTNCANCEL";
            this.BTNCANCEL.Size = new System.Drawing.Size(65, 35);
            this.BTNCANCEL.Text = "恢復(&U)";
            this.BTNCANCEL.Click += new System.EventHandler(this.BTNCANCEL_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNSAVE
            // 
            this.BTNSAVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVE.Image")));
            this.BTNSAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVE.Name = "BTNSAVE";
            this.BTNSAVE.Size = new System.Drawing.Size(63, 35);
            this.BTNSAVE.Text = "保存(&S)";
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // frmQuotationDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 597);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtTemp_code);
            this.Name = "frmQuotationDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuotationDiscount";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuotationDiscount_FormClosed);
            this.Load += new System.EventHandler(this.frmQuotationDiscount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTemp_code.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clBp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clprice)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn number_enter;
        private DevExpress.XtraGrid.Columns.GridColumn price_hkd;
        private DevExpress.XtraGrid.Columns.GridColumn price_unit;
        private DevExpress.XtraGrid.Columns.GridColumn hkd_ex_fty;
        private DevExpress.XtraGrid.Columns.GridColumn seq_id;
        private DevExpress.XtraGrid.Columns.GridColumn temp_code;
        private DevExpress.XtraGrid.Columns.GridColumn valid_date;
        private DevExpress.XtraEditors.TextEdit txtTemp_code;
        private DevExpress.XtraGrid.Columns.GridColumn create_by;
        private DevExpress.XtraGrid.Columns.GridColumn create_date;
        private DevExpress.XtraGrid.Columns.GridColumn update_by;
        private DevExpress.XtraGrid.Columns.GridColumn update_date;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit clBp;
        private DevExpress.XtraGrid.Columns.GridColumn usd_ex_fty;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BTNDELETE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DevExpress.XtraGrid.Columns.GridColumn price_rmb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private DevExpress.XtraGrid.Columns.GridColumn price_usd;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit clprice;
        private DevExpress.XtraGrid.Columns.GridColumn vnd_bp;
        private DevExpress.XtraGrid.Columns.GridColumn price_vnd_usd;
        private DevExpress.XtraGrid.Columns.GridColumn price_vnd;
        private DevExpress.XtraGrid.Columns.GridColumn price_vnd_grs;
        private DevExpress.XtraGrid.Columns.GridColumn price_vnd_pcs;
        private DevExpress.XtraGrid.Columns.GridColumn moq_qty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit clQty;
        private DevExpress.XtraGrid.Columns.GridColumn remark;
    }
}