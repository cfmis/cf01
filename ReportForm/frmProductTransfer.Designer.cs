namespace cf01.ReportForm
{
    partial class frmProductTransfer
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductTransfer));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.wip_id2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prd_dep_cdesc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.group_desc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prd_mo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prd_item2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prd_item_cdesc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.do_color2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.transfer_date_out2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.transfer_qty_out2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.transfer_date_in2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.transfer_qty_in2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qty_difference2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.weg_difference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSec_qty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.select_flag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.transfer_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prd_mo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prd_item = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prd_item_cdesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.do_color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.flag_desc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.wip_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.wip_id_cdesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.to_dep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.to_dep_cdesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.group_desc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.transfer_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.transfer_weg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.manual_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.crtim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatetime = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.prd_dep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.work_sort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVESET = new System.Windows.Forms.ToolStripButton();
            this.BTNEXCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.cmbTransfer_flag = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCrtim1 = new DevExpress.XtraEditors.DateEdit();
            this.txtCrtim2 = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGroup = new DevExpress.XtraEditors.TextEdit();
            this.txtPrd_item = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrd_mo2 = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtPrd_mo1 = new DevExpress.XtraEditors.TextEdit();
            this.txtWip_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lblOut_dept = new System.Windows.Forms.Label();
            this.lueWork_sort = new DevExpress.XtraEditors.LookUpEdit();
            this.lblIn_dept = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSec_qty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colDatetime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colDatetime.CalendarTimeProperties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTransfer_flag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_item.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_mo2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_mo1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWip_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWork_sort.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.wip_id2,
            this.prd_dep_cdesc2,
            this.group_desc2,
            this.prd_mo2,
            this.prd_item2,
            this.prd_item_cdesc2,
            this.do_color2,
            this.transfer_date_out2,
            this.transfer_qty_out2,
            this.transfer_date_in2,
            this.transfer_qty_in2,
            this.qty_difference2,
            this.weg_difference});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsCustomization.AllowSort = false;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.PaintStyleName = "Style3D";
            this.gridView2.RowHeight = 22;
            // 
            // wip_id2
            // 
            this.wip_id2.Caption = "負責部門";
            this.wip_id2.FieldName = "wip_id";
            this.wip_id2.Name = "wip_id2";
            this.wip_id2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.wip_id2.OptionsColumn.AllowIncrementalSearch = false;
            this.wip_id2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.wip_id2.OptionsColumn.AllowMove = false;
            this.wip_id2.OptionsColumn.AllowShowHide = false;
            this.wip_id2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.wip_id2.OptionsColumn.ReadOnly = true;
            this.wip_id2.OptionsFilter.AllowAutoFilter = false;
            this.wip_id2.OptionsFilter.AllowFilter = false;
            this.wip_id2.Visible = true;
            this.wip_id2.VisibleIndex = 0;
            this.wip_id2.Width = 60;
            // 
            // prd_dep_cdesc2
            // 
            this.prd_dep_cdesc2.Caption = "負責部門描述";
            this.prd_dep_cdesc2.FieldName = "prd_dep_cdesc";
            this.prd_dep_cdesc2.Name = "prd_dep_cdesc2";
            this.prd_dep_cdesc2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.prd_dep_cdesc2.OptionsColumn.AllowIncrementalSearch = false;
            this.prd_dep_cdesc2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.prd_dep_cdesc2.OptionsColumn.AllowMove = false;
            this.prd_dep_cdesc2.OptionsColumn.AllowShowHide = false;
            this.prd_dep_cdesc2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.prd_dep_cdesc2.OptionsColumn.ReadOnly = true;
            this.prd_dep_cdesc2.OptionsFilter.AllowAutoFilter = false;
            this.prd_dep_cdesc2.OptionsFilter.AllowFilter = false;
            this.prd_dep_cdesc2.Visible = true;
            this.prd_dep_cdesc2.VisibleIndex = 1;
            this.prd_dep_cdesc2.Width = 100;
            // 
            // group_desc2
            // 
            this.group_desc2.Caption = "工序分類";
            this.group_desc2.FieldName = "group_desc";
            this.group_desc2.Name = "group_desc2";
            this.group_desc2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.group_desc2.OptionsColumn.AllowIncrementalSearch = false;
            this.group_desc2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.group_desc2.OptionsColumn.AllowMove = false;
            this.group_desc2.OptionsColumn.AllowShowHide = false;
            this.group_desc2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.group_desc2.OptionsColumn.ReadOnly = true;
            this.group_desc2.OptionsFilter.AllowAutoFilter = false;
            this.group_desc2.OptionsFilter.AllowFilter = false;
            this.group_desc2.Visible = true;
            this.group_desc2.VisibleIndex = 2;
            this.group_desc2.Width = 69;
            // 
            // prd_mo2
            // 
            this.prd_mo2.Caption = "制單編號";
            this.prd_mo2.FieldName = "prd_mo";
            this.prd_mo2.Name = "prd_mo2";
            this.prd_mo2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.prd_mo2.OptionsColumn.AllowIncrementalSearch = false;
            this.prd_mo2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.prd_mo2.OptionsColumn.AllowMove = false;
            this.prd_mo2.OptionsColumn.AllowShowHide = false;
            this.prd_mo2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.prd_mo2.OptionsColumn.ReadOnly = true;
            this.prd_mo2.OptionsFilter.AllowAutoFilter = false;
            this.prd_mo2.OptionsFilter.AllowFilter = false;
            this.prd_mo2.Visible = true;
            this.prd_mo2.VisibleIndex = 3;
            this.prd_mo2.Width = 88;
            // 
            // prd_item2
            // 
            this.prd_item2.Caption = "物料編號";
            this.prd_item2.FieldName = "prd_item";
            this.prd_item2.Name = "prd_item2";
            this.prd_item2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.prd_item2.OptionsColumn.AllowIncrementalSearch = false;
            this.prd_item2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.prd_item2.OptionsColumn.AllowMove = false;
            this.prd_item2.OptionsColumn.AllowShowHide = false;
            this.prd_item2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.prd_item2.OptionsColumn.ReadOnly = true;
            this.prd_item2.OptionsFilter.AllowAutoFilter = false;
            this.prd_item2.OptionsFilter.AllowFilter = false;
            this.prd_item2.Visible = true;
            this.prd_item2.VisibleIndex = 4;
            this.prd_item2.Width = 150;
            // 
            // prd_item_cdesc2
            // 
            this.prd_item_cdesc2.Caption = "物料描述";
            this.prd_item_cdesc2.FieldName = "prd_item_cdesc";
            this.prd_item_cdesc2.Name = "prd_item_cdesc2";
            this.prd_item_cdesc2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.prd_item_cdesc2.OptionsColumn.AllowIncrementalSearch = false;
            this.prd_item_cdesc2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.prd_item_cdesc2.OptionsColumn.AllowMove = false;
            this.prd_item_cdesc2.OptionsColumn.AllowShowHide = false;
            this.prd_item_cdesc2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.prd_item_cdesc2.OptionsColumn.ReadOnly = true;
            this.prd_item_cdesc2.OptionsFilter.AllowAutoFilter = false;
            this.prd_item_cdesc2.OptionsFilter.AllowFilter = false;
            this.prd_item_cdesc2.Visible = true;
            this.prd_item_cdesc2.VisibleIndex = 5;
            this.prd_item_cdesc2.Width = 181;
            // 
            // do_color2
            // 
            this.do_color2.Caption = "顏色描述";
            this.do_color2.FieldName = "do_color";
            this.do_color2.Name = "do_color2";
            this.do_color2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.do_color2.OptionsColumn.AllowIncrementalSearch = false;
            this.do_color2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.do_color2.OptionsColumn.AllowMove = false;
            this.do_color2.OptionsColumn.AllowShowHide = false;
            this.do_color2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.do_color2.OptionsColumn.ReadOnly = true;
            this.do_color2.OptionsFilter.AllowAutoFilter = false;
            this.do_color2.OptionsFilter.AllowFilter = false;
            this.do_color2.Visible = true;
            this.do_color2.VisibleIndex = 6;
            this.do_color2.Width = 124;
            // 
            // transfer_date_out2
            // 
            this.transfer_date_out2.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.transfer_date_out2.AppearanceCell.Options.UseBackColor = true;
            this.transfer_date_out2.Caption = "發貨日期";
            this.transfer_date_out2.ColumnEdit = this.colDate;
            this.transfer_date_out2.FieldName = "transfer_date_out";
            this.transfer_date_out2.Name = "transfer_date_out2";
            this.transfer_date_out2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_date_out2.OptionsColumn.AllowIncrementalSearch = false;
            this.transfer_date_out2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_date_out2.OptionsColumn.AllowMove = false;
            this.transfer_date_out2.OptionsColumn.AllowShowHide = false;
            this.transfer_date_out2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_date_out2.OptionsColumn.ReadOnly = true;
            this.transfer_date_out2.OptionsFilter.AllowAutoFilter = false;
            this.transfer_date_out2.OptionsFilter.AllowFilter = false;
            this.transfer_date_out2.Visible = true;
            this.transfer_date_out2.VisibleIndex = 7;
            this.transfer_date_out2.Width = 80;
            // 
            // colDate
            // 
            this.colDate.AutoHeight = false;
            this.colDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDate.EditFormat.FormatString = "yyyy/MM/dd";
            this.colDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDate.Mask.EditMask = "yyyy/MM/dd";
            this.colDate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.colDate.MaxLength = 10;
            this.colDate.Name = "colDate";
            // 
            // transfer_qty_out2
            // 
            this.transfer_qty_out2.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.transfer_qty_out2.AppearanceCell.Options.UseBackColor = true;
            this.transfer_qty_out2.Caption = "發貨數量";
            this.transfer_qty_out2.ColumnEdit = this.colQty;
            this.transfer_qty_out2.FieldName = "transfer_qty_out";
            this.transfer_qty_out2.Name = "transfer_qty_out2";
            this.transfer_qty_out2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_qty_out2.OptionsColumn.AllowIncrementalSearch = false;
            this.transfer_qty_out2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_qty_out2.OptionsColumn.AllowMove = false;
            this.transfer_qty_out2.OptionsColumn.AllowShowHide = false;
            this.transfer_qty_out2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_qty_out2.OptionsColumn.ReadOnly = true;
            this.transfer_qty_out2.OptionsFilter.AllowAutoFilter = false;
            this.transfer_qty_out2.OptionsFilter.AllowFilter = false;
            this.transfer_qty_out2.Visible = true;
            this.transfer_qty_out2.VisibleIndex = 8;
            this.transfer_qty_out2.Width = 71;
            // 
            // colQty
            // 
            this.colQty.AutoHeight = false;
            this.colQty.DisplayFormat.FormatString = "n0";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.EditFormat.FormatString = "n0";
            this.colQty.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.Mask.EditMask = "n0";
            this.colQty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.colQty.Name = "colQty";
            // 
            // transfer_date_in2
            // 
            this.transfer_date_in2.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.transfer_date_in2.AppearanceCell.Options.UseBackColor = true;
            this.transfer_date_in2.Caption = "收貨日期";
            this.transfer_date_in2.ColumnEdit = this.colDate;
            this.transfer_date_in2.FieldName = "transfer_date_in";
            this.transfer_date_in2.Name = "transfer_date_in2";
            this.transfer_date_in2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_date_in2.OptionsColumn.AllowIncrementalSearch = false;
            this.transfer_date_in2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_date_in2.OptionsColumn.AllowMove = false;
            this.transfer_date_in2.OptionsColumn.AllowShowHide = false;
            this.transfer_date_in2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_date_in2.OptionsColumn.ReadOnly = true;
            this.transfer_date_in2.OptionsFilter.AllowAutoFilter = false;
            this.transfer_date_in2.OptionsFilter.AllowFilter = false;
            this.transfer_date_in2.Visible = true;
            this.transfer_date_in2.VisibleIndex = 9;
            this.transfer_date_in2.Width = 80;
            // 
            // transfer_qty_in2
            // 
            this.transfer_qty_in2.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.transfer_qty_in2.AppearanceCell.Options.UseBackColor = true;
            this.transfer_qty_in2.Caption = "收貨數量";
            this.transfer_qty_in2.ColumnEdit = this.colQty;
            this.transfer_qty_in2.FieldName = "transfer_qty_in";
            this.transfer_qty_in2.Name = "transfer_qty_in2";
            this.transfer_qty_in2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_qty_in2.OptionsColumn.AllowIncrementalSearch = false;
            this.transfer_qty_in2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_qty_in2.OptionsColumn.AllowMove = false;
            this.transfer_qty_in2.OptionsColumn.AllowShowHide = false;
            this.transfer_qty_in2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_qty_in2.OptionsColumn.ReadOnly = true;
            this.transfer_qty_in2.OptionsFilter.AllowAutoFilter = false;
            this.transfer_qty_in2.OptionsFilter.AllowFilter = false;
            this.transfer_qty_in2.Visible = true;
            this.transfer_qty_in2.VisibleIndex = 10;
            // 
            // qty_difference2
            // 
            this.qty_difference2.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.qty_difference2.AppearanceCell.Options.UseBackColor = true;
            this.qty_difference2.Caption = "數量差額";
            this.qty_difference2.ColumnEdit = this.colQty;
            this.qty_difference2.FieldName = "qty_difference";
            this.qty_difference2.Name = "qty_difference2";
            this.qty_difference2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.qty_difference2.OptionsColumn.AllowIncrementalSearch = false;
            this.qty_difference2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.qty_difference2.OptionsColumn.AllowMove = false;
            this.qty_difference2.OptionsColumn.AllowShowHide = false;
            this.qty_difference2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.qty_difference2.OptionsColumn.ReadOnly = true;
            this.qty_difference2.OptionsFilter.AllowAutoFilter = false;
            this.qty_difference2.OptionsFilter.AllowFilter = false;
            this.qty_difference2.Visible = true;
            this.qty_difference2.VisibleIndex = 11;
            // 
            // weg_difference
            // 
            this.weg_difference.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.weg_difference.AppearanceCell.Options.UseBackColor = true;
            this.weg_difference.Caption = "重量差額";
            this.weg_difference.ColumnEdit = this.colSec_qty;
            this.weg_difference.FieldName = "weg_difference";
            this.weg_difference.Name = "weg_difference";
            this.weg_difference.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.weg_difference.OptionsColumn.AllowIncrementalSearch = false;
            this.weg_difference.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.weg_difference.OptionsColumn.AllowMove = false;
            this.weg_difference.OptionsColumn.AllowShowHide = false;
            this.weg_difference.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.weg_difference.OptionsColumn.ReadOnly = true;
            this.weg_difference.OptionsFilter.AllowAutoFilter = false;
            this.weg_difference.OptionsFilter.AllowFilter = false;
            this.weg_difference.Visible = true;
            this.weg_difference.VisibleIndex = 12;
            // 
            // colSec_qty
            // 
            this.colSec_qty.AutoHeight = false;
            this.colSec_qty.DisplayFormat.FormatString = "n2";
            this.colSec_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSec_qty.EditFormat.FormatString = "n2";
            this.colSec_qty.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSec_qty.Mask.EditMask = "n2";
            this.colSec_qty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.colSec_qty.Name = "colSec_qty";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(6, 171);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colQty,
            this.colSec_qty,
            this.colDatetime,
            this.colDate,
            this.colSelect});
            this.gridControl1.Size = new System.Drawing.Size(1102, 391);
            this.gridControl1.TabIndex = 153;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.select_flag,
            this.transfer_date,
            this.prd_mo,
            this.prd_item,
            this.prd_item_cdesc,
            this.do_color,
            this.flag_desc,
            this.wip_id,
            this.wip_id_cdesc,
            this.to_dep,
            this.to_dep_cdesc,
            this.group_desc,
            this.transfer_qty,
            this.transfer_weg,
            this.manual_date,
            this.crtim,
            this.prd_dep,
            this.work_sort});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "Style3D";
            this.gridView1.RowHeight = 22;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // select_flag
            // 
            this.select_flag.AppearanceHeader.Options.UseTextOptions = true;
            this.select_flag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.select_flag.Caption = "選擇";
            this.select_flag.ColumnEdit = this.colSelect;
            this.select_flag.FieldName = "select_flag";
            this.select_flag.Name = "select_flag";
            this.select_flag.OptionsFilter.AllowAutoFilter = false;
            this.select_flag.OptionsFilter.AllowFilter = false;
            this.select_flag.Visible = true;
            this.select_flag.VisibleIndex = 0;
            this.select_flag.Width = 60;
            // 
            // colSelect
            // 
            this.colSelect.AutoHeight = false;
            this.colSelect.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colSelect.Name = "colSelect";
            this.colSelect.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // transfer_date
            // 
            this.transfer_date.Caption = "日期";
            this.transfer_date.ColumnEdit = this.colDate;
            this.transfer_date.FieldName = "transfer_date";
            this.transfer_date.Name = "transfer_date";
            this.transfer_date.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_date.OptionsColumn.AllowIncrementalSearch = false;
            this.transfer_date.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_date.OptionsColumn.AllowMove = false;
            this.transfer_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_date.OptionsColumn.ReadOnly = true;
            this.transfer_date.OptionsFilter.AllowAutoFilter = false;
            this.transfer_date.OptionsFilter.AllowFilter = false;
            this.transfer_date.Visible = true;
            this.transfer_date.VisibleIndex = 1;
            this.transfer_date.Width = 85;
            // 
            // prd_mo
            // 
            this.prd_mo.Caption = "制單編號";
            this.prd_mo.FieldName = "prd_mo";
            this.prd_mo.Name = "prd_mo";
            this.prd_mo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.prd_mo.OptionsColumn.AllowIncrementalSearch = false;
            this.prd_mo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.prd_mo.OptionsColumn.AllowMove = false;
            this.prd_mo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.prd_mo.OptionsColumn.ReadOnly = true;
            this.prd_mo.OptionsFilter.AllowAutoFilter = false;
            this.prd_mo.OptionsFilter.AllowFilter = false;
            this.prd_mo.Visible = true;
            this.prd_mo.VisibleIndex = 2;
            this.prd_mo.Width = 90;
            // 
            // prd_item
            // 
            this.prd_item.Caption = "物料編號";
            this.prd_item.FieldName = "prd_item";
            this.prd_item.Name = "prd_item";
            this.prd_item.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.prd_item.OptionsColumn.AllowIncrementalSearch = false;
            this.prd_item.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.prd_item.OptionsColumn.AllowMove = false;
            this.prd_item.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.prd_item.OptionsColumn.FixedWidth = true;
            this.prd_item.OptionsColumn.ReadOnly = true;
            this.prd_item.OptionsFilter.AllowAutoFilter = false;
            this.prd_item.OptionsFilter.AllowFilter = false;
            this.prd_item.Visible = true;
            this.prd_item.VisibleIndex = 3;
            this.prd_item.Width = 150;
            // 
            // prd_item_cdesc
            // 
            this.prd_item_cdesc.Caption = "物料描述";
            this.prd_item_cdesc.FieldName = "prd_item_cdesc";
            this.prd_item_cdesc.Name = "prd_item_cdesc";
            this.prd_item_cdesc.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.prd_item_cdesc.OptionsColumn.AllowIncrementalSearch = false;
            this.prd_item_cdesc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.prd_item_cdesc.OptionsColumn.AllowMove = false;
            this.prd_item_cdesc.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.prd_item_cdesc.OptionsColumn.ReadOnly = true;
            this.prd_item_cdesc.OptionsFilter.AllowAutoFilter = false;
            this.prd_item_cdesc.OptionsFilter.AllowFilter = false;
            this.prd_item_cdesc.Visible = true;
            this.prd_item_cdesc.VisibleIndex = 4;
            this.prd_item_cdesc.Width = 182;
            // 
            // do_color
            // 
            this.do_color.Caption = "顏色描述";
            this.do_color.FieldName = "do_color";
            this.do_color.Name = "do_color";
            this.do_color.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.do_color.OptionsColumn.AllowIncrementalSearch = false;
            this.do_color.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.do_color.OptionsColumn.AllowMove = false;
            this.do_color.OptionsColumn.AllowShowHide = false;
            this.do_color.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.do_color.OptionsColumn.ReadOnly = true;
            this.do_color.OptionsFilter.AllowAutoFilter = false;
            this.do_color.OptionsFilter.AllowFilter = false;
            this.do_color.Visible = true;
            this.do_color.VisibleIndex = 5;
            this.do_color.Width = 100;
            // 
            // flag_desc
            // 
            this.flag_desc.Caption = "收發類型";
            this.flag_desc.FieldName = "flag_desc";
            this.flag_desc.Name = "flag_desc";
            this.flag_desc.OptionsColumn.AllowEdit = false;
            this.flag_desc.OptionsColumn.AllowFocus = false;
            this.flag_desc.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.flag_desc.OptionsColumn.AllowIncrementalSearch = false;
            this.flag_desc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.flag_desc.OptionsColumn.AllowMove = false;
            this.flag_desc.OptionsColumn.AllowShowHide = false;
            this.flag_desc.OptionsColumn.AllowSize = false;
            this.flag_desc.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.flag_desc.OptionsColumn.ReadOnly = true;
            this.flag_desc.Visible = true;
            this.flag_desc.VisibleIndex = 6;
            this.flag_desc.Width = 65;
            // 
            // wip_id
            // 
            this.wip_id.Caption = "負責部門";
            this.wip_id.FieldName = "wip_id";
            this.wip_id.Name = "wip_id";
            this.wip_id.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.wip_id.OptionsColumn.AllowIncrementalSearch = false;
            this.wip_id.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.wip_id.OptionsColumn.AllowMove = false;
            this.wip_id.OptionsColumn.AllowShowHide = false;
            this.wip_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.wip_id.OptionsColumn.ReadOnly = true;
            this.wip_id.OptionsFilter.AllowAutoFilter = false;
            this.wip_id.OptionsFilter.AllowFilter = false;
            this.wip_id.Visible = true;
            this.wip_id.VisibleIndex = 7;
            this.wip_id.Width = 60;
            // 
            // wip_id_cdesc
            // 
            this.wip_id_cdesc.Caption = "負責部門描述";
            this.wip_id_cdesc.FieldName = "prd_dep_cdesc";
            this.wip_id_cdesc.Name = "wip_id_cdesc";
            this.wip_id_cdesc.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.wip_id_cdesc.OptionsColumn.AllowIncrementalSearch = false;
            this.wip_id_cdesc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.wip_id_cdesc.OptionsColumn.AllowMove = false;
            this.wip_id_cdesc.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.wip_id_cdesc.OptionsColumn.ReadOnly = true;
            this.wip_id_cdesc.OptionsFilter.AllowAutoFilter = false;
            this.wip_id_cdesc.OptionsFilter.AllowFilter = false;
            this.wip_id_cdesc.Visible = true;
            this.wip_id_cdesc.VisibleIndex = 8;
            this.wip_id_cdesc.Width = 90;
            // 
            // to_dep
            // 
            this.to_dep.Caption = "下部門";
            this.to_dep.FieldName = "to_dep";
            this.to_dep.Name = "to_dep";
            this.to_dep.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.to_dep.OptionsColumn.AllowIncrementalSearch = false;
            this.to_dep.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.to_dep.OptionsColumn.AllowMove = false;
            this.to_dep.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.to_dep.OptionsColumn.ReadOnly = true;
            this.to_dep.OptionsFilter.AllowAutoFilter = false;
            this.to_dep.OptionsFilter.AllowFilter = false;
            this.to_dep.Visible = true;
            this.to_dep.VisibleIndex = 9;
            this.to_dep.Width = 60;
            // 
            // to_dep_cdesc
            // 
            this.to_dep_cdesc.Caption = "下部門描述";
            this.to_dep_cdesc.FieldName = "to_dep_cdesc";
            this.to_dep_cdesc.Name = "to_dep_cdesc";
            this.to_dep_cdesc.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.to_dep_cdesc.OptionsColumn.AllowIncrementalSearch = false;
            this.to_dep_cdesc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.to_dep_cdesc.OptionsColumn.AllowMove = false;
            this.to_dep_cdesc.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.to_dep_cdesc.OptionsColumn.ReadOnly = true;
            this.to_dep_cdesc.OptionsFilter.AllowAutoFilter = false;
            this.to_dep_cdesc.OptionsFilter.AllowFilter = false;
            this.to_dep_cdesc.Visible = true;
            this.to_dep_cdesc.VisibleIndex = 10;
            this.to_dep_cdesc.Width = 80;
            // 
            // group_desc
            // 
            this.group_desc.Caption = "工序分類";
            this.group_desc.FieldName = "group_desc";
            this.group_desc.Name = "group_desc";
            this.group_desc.OptionsColumn.AllowEdit = false;
            this.group_desc.OptionsColumn.AllowFocus = false;
            this.group_desc.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.group_desc.OptionsColumn.AllowIncrementalSearch = false;
            this.group_desc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.group_desc.OptionsColumn.AllowMove = false;
            this.group_desc.OptionsColumn.AllowShowHide = false;
            this.group_desc.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.group_desc.OptionsFilter.AllowAutoFilter = false;
            this.group_desc.OptionsFilter.AllowFilter = false;
            this.group_desc.Visible = true;
            this.group_desc.VisibleIndex = 11;
            this.group_desc.Width = 80;
            // 
            // transfer_qty
            // 
            this.transfer_qty.AppearanceCell.BackColor = System.Drawing.Color.AntiqueWhite;
            this.transfer_qty.AppearanceCell.Options.UseBackColor = true;
            this.transfer_qty.Caption = "數量";
            this.transfer_qty.ColumnEdit = this.colQty;
            this.transfer_qty.FieldName = "transfer_qty";
            this.transfer_qty.Name = "transfer_qty";
            this.transfer_qty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_qty.OptionsColumn.AllowIncrementalSearch = false;
            this.transfer_qty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_qty.OptionsColumn.AllowMove = false;
            this.transfer_qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_qty.OptionsFilter.AllowAutoFilter = false;
            this.transfer_qty.OptionsFilter.AllowFilter = false;
            this.transfer_qty.Visible = true;
            this.transfer_qty.VisibleIndex = 12;
            this.transfer_qty.Width = 70;
            // 
            // transfer_weg
            // 
            this.transfer_weg.AppearanceCell.BackColor = System.Drawing.Color.AntiqueWhite;
            this.transfer_weg.AppearanceCell.Options.UseBackColor = true;
            this.transfer_weg.Caption = "重量";
            this.transfer_weg.ColumnEdit = this.colSec_qty;
            this.transfer_weg.FieldName = "transfer_weg";
            this.transfer_weg.Name = "transfer_weg";
            this.transfer_weg.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_weg.OptionsColumn.AllowIncrementalSearch = false;
            this.transfer_weg.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_weg.OptionsColumn.AllowMove = false;
            this.transfer_weg.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.transfer_weg.OptionsFilter.AllowAutoFilter = false;
            this.transfer_weg.OptionsFilter.AllowFilter = false;
            this.transfer_weg.Visible = true;
            this.transfer_weg.VisibleIndex = 13;
            this.transfer_weg.Width = 60;
            // 
            // manual_date
            // 
            this.manual_date.AppearanceCell.BackColor = System.Drawing.Color.AntiqueWhite;
            this.manual_date.AppearanceCell.Options.UseBackColor = true;
            this.manual_date.Caption = "當前電腦日期";
            this.manual_date.ColumnEdit = this.colDate;
            this.manual_date.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.manual_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.manual_date.FieldName = "manual_date";
            this.manual_date.Name = "manual_date";
            this.manual_date.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.manual_date.OptionsColumn.AllowIncrementalSearch = false;
            this.manual_date.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.manual_date.OptionsColumn.AllowMove = false;
            this.manual_date.OptionsColumn.AllowShowHide = false;
            this.manual_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.manual_date.OptionsFilter.AllowAutoFilter = false;
            this.manual_date.OptionsFilter.AllowFilter = false;
            this.manual_date.Visible = true;
            this.manual_date.VisibleIndex = 14;
            this.manual_date.Width = 85;
            // 
            // crtim
            // 
            this.crtim.Caption = "建檔日期";
            this.crtim.ColumnEdit = this.colDatetime;
            this.crtim.FieldName = "crtim";
            this.crtim.Name = "crtim";
            this.crtim.OptionsColumn.AllowEdit = false;
            this.crtim.OptionsColumn.AllowFocus = false;
            this.crtim.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.crtim.OptionsColumn.AllowIncrementalSearch = false;
            this.crtim.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.crtim.OptionsColumn.AllowMove = false;
            this.crtim.OptionsColumn.AllowShowHide = false;
            this.crtim.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.crtim.OptionsColumn.ReadOnly = true;
            this.crtim.OptionsFilter.AllowAutoFilter = false;
            this.crtim.OptionsFilter.AllowFilter = false;
            this.crtim.Visible = true;
            this.crtim.VisibleIndex = 15;
            this.crtim.Width = 130;
            // 
            // colDatetime
            // 
            this.colDatetime.AutoHeight = false;
            this.colDatetime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colDatetime.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colDatetime.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm";
            this.colDatetime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatetime.EditFormat.FormatString = "yyyy/MM/dd HH:mm";
            this.colDatetime.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatetime.Mask.EditMask = "yyyy/MM/dd HH:mm";
            this.colDatetime.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.colDatetime.Name = "colDatetime";
            // 
            // prd_dep
            // 
            this.prd_dep.Caption = "發貨部門";
            this.prd_dep.FieldName = "prd_dep";
            this.prd_dep.Name = "prd_dep";
            this.prd_dep.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.prd_dep.OptionsColumn.AllowIncrementalSearch = false;
            this.prd_dep.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.prd_dep.OptionsColumn.AllowMove = false;
            this.prd_dep.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.prd_dep.OptionsColumn.ReadOnly = true;
            this.prd_dep.OptionsFilter.AllowAutoFilter = false;
            this.prd_dep.OptionsFilter.AllowFilter = false;
            this.prd_dep.Width = 60;
            // 
            // work_sort
            // 
            this.work_sort.Caption = "工序分類編號";
            this.work_sort.FieldName = "work_sort";
            this.work_sort.Name = "work_sort";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNCANCEL,
            this.toolStripSeparator4,
            this.BTNFIND,
            this.toolStripSeparator9,
            this.BTNSAVESET,
            this.BTNEXCEL,
            this.toolStripSeparator3,
            this.BTNSAVE,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1116, 38);
            this.toolStrip1.TabIndex = 125;
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
            this.BTNEXIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNCANCEL
            // 
            this.BTNCANCEL.AutoSize = false;
            this.BTNCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNCANCEL.Image")));
            this.BTNCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCANCEL.Name = "BTNCANCEL";
            this.BTNCANCEL.Size = new System.Drawing.Size(65, 35);
            this.BTNCANCEL.Text = "重置(&U)";
            this.BTNCANCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNCANCEL.Click += new System.EventHandler(this.BTNCANCEL_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNFIND
            // 
            this.BTNFIND.AutoSize = false;
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(65, 35);
            this.BTNFIND.Text = "查找(&F)";
            this.BTNFIND.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNSAVESET
            // 
            this.BTNSAVESET.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVESET.Image")));
            this.BTNSAVESET.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVESET.Name = "BTNSAVESET";
            this.BTNSAVESET.Size = new System.Drawing.Size(83, 35);
            this.BTNSAVESET.Text = "保存查找條件";
            this.BTNSAVESET.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNSAVESET.ToolTipText = "保存查找條件";
            this.BTNSAVESET.Click += new System.EventHandler(this.BTNSAVESET_Click);
            // 
            // BTNEXCEL
            // 
            this.BTNEXCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXCEL.Image")));
            this.BTNEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXCEL.Name = "BTNEXCEL";
            this.BTNEXCEL.Size = new System.Drawing.Size(71, 35);
            this.BTNEXCEL.Text = "匯出EXCEL";
            this.BTNEXCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNEXCEL.Click += new System.EventHandler(this.BTNEXCEL_Click);
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
            this.BTNSAVE.Size = new System.Drawing.Size(59, 35);
            this.BTNSAVE.Text = "手動收貨";
            this.BTNSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.radioGroup1);
            this.panel1.Controls.Add(this.cmbTransfer_flag);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCrtim1);
            this.panel1.Controls.Add(this.txtCrtim2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtGroup);
            this.panel1.Controls.Add(this.txtPrd_item);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPrd_mo2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.txtPrd_mo1);
            this.panel1.Controls.Add(this.txtWip_id);
            this.panel1.Controls.Add(this.lblOut_dept);
            this.panel1.Controls.Add(this.lueWork_sort);
            this.panel1.Controls.Add(this.lblIn_dept);
            this.panel1.Location = new System.Drawing.Point(6, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 121);
            this.panel1.TabIndex = 152;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(717, 61);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "匯總表"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "明細表")});
            this.radioGroup1.Size = new System.Drawing.Size(178, 25);
            this.radioGroup1.TabIndex = 161;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // cmbTransfer_flag
            // 
            this.cmbTransfer_flag.EditValue = "";
            this.cmbTransfer_flag.EnterMoveNextControl = true;
            this.cmbTransfer_flag.Location = new System.Drawing.Point(528, 62);
            this.cmbTransfer_flag.Name = "cmbTransfer_flag";
            this.cmbTransfer_flag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTransfer_flag.Properties.Items.AddRange(new object[] {
            "0 --發貨",
            "1 --收貨",
            "2 --全部"});
            this.cmbTransfer_flag.Size = new System.Drawing.Size(135, 20);
            this.cmbTransfer_flag.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(442, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 159;
            this.label6.Text = "收發標識";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCrtim1
            // 
            this.txtCrtim1.EditValue = "";
            this.txtCrtim1.EnterMoveNextControl = true;
            this.txtCrtim1.Location = new System.Drawing.Point(111, 89);
            this.txtCrtim1.Name = "txtCrtim1";
            this.txtCrtim1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCrtim1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCrtim1.Properties.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm";
            this.txtCrtim1.Properties.EditFormat.FormatString = "yyyy/MM/dd HH:mm";
            this.txtCrtim1.Properties.Mask.EditMask = "yyyy/MM/dd HH:mm";
            this.txtCrtim1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtCrtim1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCrtim1.Properties.NullDate = "";
            this.txtCrtim1.Size = new System.Drawing.Size(135, 20);
            this.txtCrtim1.TabIndex = 4;
            this.txtCrtim1.Tag = "2";
            this.txtCrtim1.Leave += new System.EventHandler(this.txtCrtim1_Leave);
            // 
            // txtCrtim2
            // 
            this.txtCrtim2.EditValue = "";
            this.txtCrtim2.EnterMoveNextControl = true;
            this.txtCrtim2.Location = new System.Drawing.Point(275, 89);
            this.txtCrtim2.Name = "txtCrtim2";
            this.txtCrtim2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCrtim2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCrtim2.Properties.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm";
            this.txtCrtim2.Properties.EditFormat.FormatString = "yyyy/MM/dd HH:mm";
            this.txtCrtim2.Properties.Mask.EditMask = "yyyy/MM/dd HH:mm";
            this.txtCrtim2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtCrtim2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCrtim2.Properties.NullDate = "";
            this.txtCrtim2.Size = new System.Drawing.Size(135, 20);
            this.txtCrtim2.TabIndex = 5;
            this.txtCrtim2.Tag = "2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(25, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 156;
            this.label3.Text = "錄入日期";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.label7.Location = new System.Drawing.Point(252, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 16);
            this.label7.TabIndex = 157;
            this.label7.Text = "~";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(442, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 153;
            this.label4.Text = "組別";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGroup
            // 
            this.txtGroup.EditValue = "";
            this.txtGroup.EnterMoveNextControl = true;
            this.txtGroup.Location = new System.Drawing.Point(528, 35);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGroup.Properties.MaxLength = 1;
            this.txtGroup.Size = new System.Drawing.Size(135, 20);
            this.txtGroup.TabIndex = 6;
            // 
            // txtPrd_item
            // 
            this.txtPrd_item.EditValue = "";
            this.txtPrd_item.EnterMoveNextControl = true;
            this.txtPrd_item.Location = new System.Drawing.Point(111, 35);
            this.txtPrd_item.Name = "txtPrd_item";
            this.txtPrd_item.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrd_item.Properties.MaxLength = 18;
            this.txtPrd_item.Size = new System.Drawing.Size(299, 20);
            this.txtPrd_item.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(252, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 147;
            this.label2.Text = "~";
            // 
            // txtPrd_mo2
            // 
            this.txtPrd_mo2.EditValue = "";
            this.txtPrd_mo2.EnterMoveNextControl = true;
            this.txtPrd_mo2.Location = new System.Drawing.Point(275, 62);
            this.txtPrd_mo2.Name = "txtPrd_mo2";
            this.txtPrd_mo2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrd_mo2.Properties.MaxLength = 9;
            this.txtPrd_mo2.Size = new System.Drawing.Size(135, 20);
            this.txtPrd_mo2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(25, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 146;
            this.label5.Text = "頁  數";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(25, 37);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(80, 13);
            this.lblID.TabIndex = 126;
            this.lblID.Text = "貨品編碼";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrd_mo1
            // 
            this.txtPrd_mo1.EditValue = "";
            this.txtPrd_mo1.EnterMoveNextControl = true;
            this.txtPrd_mo1.Location = new System.Drawing.Point(111, 62);
            this.txtPrd_mo1.Name = "txtPrd_mo1";
            this.txtPrd_mo1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrd_mo1.Properties.MaxLength = 9;
            this.txtPrd_mo1.Size = new System.Drawing.Size(135, 20);
            this.txtPrd_mo1.TabIndex = 2;
            this.txtPrd_mo1.Leave += new System.EventHandler(this.txtPrd_mo1_Leave);
            // 
            // txtWip_id
            // 
            this.txtWip_id.EditValue = "";
            this.txtWip_id.EnterMoveNextControl = true;
            this.txtWip_id.Location = new System.Drawing.Point(111, 9);
            this.txtWip_id.Name = "txtWip_id";
            this.txtWip_id.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtWip_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtWip_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 60, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 170, "cdesc")});
            this.txtWip_id.Properties.DropDownRows = 15;
            this.txtWip_id.Properties.NullText = "";
            this.txtWip_id.Properties.PopupFormMinSize = new System.Drawing.Size(230, 0);
            this.txtWip_id.Properties.ShowHeader = false;
            this.txtWip_id.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtWip_id.Size = new System.Drawing.Size(135, 20);
            this.txtWip_id.TabIndex = 0;
            // 
            // lblOut_dept
            // 
            this.lblOut_dept.Location = new System.Drawing.Point(25, 12);
            this.lblOut_dept.Name = "lblOut_dept";
            this.lblOut_dept.Size = new System.Drawing.Size(80, 13);
            this.lblOut_dept.TabIndex = 130;
            this.lblOut_dept.Text = "負責部門";
            this.lblOut_dept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lueWork_sort
            // 
            this.lueWork_sort.EditValue = "";
            this.lueWork_sort.EnterMoveNextControl = true;
            this.lueWork_sort.Location = new System.Drawing.Point(528, 89);
            this.lueWork_sort.Name = "lueWork_sort";
            this.lueWork_sort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueWork_sort.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 30, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 70, "cdesc")});
            this.lueWork_sort.Properties.DropDownRows = 15;
            this.lueWork_sort.Properties.NullText = "";
            this.lueWork_sort.Properties.PopupFormMinSize = new System.Drawing.Size(230, 0);
            this.lueWork_sort.Properties.PopupWidth = 100;
            this.lueWork_sort.Properties.ShowHeader = false;
            this.lueWork_sort.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueWork_sort.Size = new System.Drawing.Size(135, 20);
            this.lueWork_sort.TabIndex = 8;
            // 
            // lblIn_dept
            // 
            this.lblIn_dept.Location = new System.Drawing.Point(442, 93);
            this.lblIn_dept.Name = "lblIn_dept";
            this.lblIn_dept.Size = new System.Drawing.Size(80, 13);
            this.lblIn_dept.TabIndex = 134;
            this.lblIn_dept.Text = "工序類型";
            this.lblIn_dept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmProductTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 574);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmProductTransfer";
            this.Text = "frmProductTransfer";
            this.Load += new System.EventHandler(this.frmProductTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSec_qty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colDatetime.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colDatetime)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTransfer_flag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_item.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_mo2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_mo1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWip_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWork_sort.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton BTNSAVESET;
        private System.Windows.Forms.ToolStripButton BTNEXCEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.DateEdit txtCrtim1;
        private DevExpress.XtraEditors.DateEdit txtCrtim2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtGroup;
        private DevExpress.XtraEditors.TextEdit txtPrd_item;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtPrd_mo2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblID;
        private DevExpress.XtraEditors.TextEdit txtPrd_mo1;
        private DevExpress.XtraEditors.LookUpEdit txtWip_id;
        private System.Windows.Forms.Label lblOut_dept;
        private DevExpress.XtraEditors.LookUpEdit lueWork_sort;
        private System.Windows.Forms.Label lblIn_dept;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTransfer_flag;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn transfer_date;
        private DevExpress.XtraGrid.Columns.GridColumn prd_mo;
        private DevExpress.XtraGrid.Columns.GridColumn prd_item;
        private DevExpress.XtraGrid.Columns.GridColumn prd_item_cdesc;
        private DevExpress.XtraGrid.Columns.GridColumn do_color;
        private DevExpress.XtraGrid.Columns.GridColumn transfer_qty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit colQty;
        private DevExpress.XtraGrid.Columns.GridColumn transfer_weg;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit colSec_qty;
        private DevExpress.XtraGrid.Columns.GridColumn flag_desc;
        private DevExpress.XtraGrid.Columns.GridColumn prd_dep;
        private DevExpress.XtraGrid.Columns.GridColumn wip_id;
        private DevExpress.XtraGrid.Columns.GridColumn wip_id_cdesc;
        private DevExpress.XtraGrid.Columns.GridColumn to_dep;
        private DevExpress.XtraGrid.Columns.GridColumn to_dep_cdesc;
        private DevExpress.XtraGrid.Columns.GridColumn group_desc;
        private DevExpress.XtraGrid.Columns.GridColumn crtim;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit colDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit colDatetime;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn wip_id2;
        private DevExpress.XtraGrid.Columns.GridColumn prd_dep_cdesc2;
        private DevExpress.XtraGrid.Columns.GridColumn group_desc2;
        private DevExpress.XtraGrid.Columns.GridColumn prd_mo2;
        private DevExpress.XtraGrid.Columns.GridColumn prd_item2;
        private DevExpress.XtraGrid.Columns.GridColumn prd_item_cdesc2;
        private DevExpress.XtraGrid.Columns.GridColumn do_color2;
        private DevExpress.XtraGrid.Columns.GridColumn transfer_date_out2;
        private DevExpress.XtraGrid.Columns.GridColumn transfer_qty_out2;
        private DevExpress.XtraGrid.Columns.GridColumn transfer_date_in2;
        private DevExpress.XtraGrid.Columns.GridColumn transfer_qty_in2;
        private DevExpress.XtraGrid.Columns.GridColumn qty_difference2;
        private DevExpress.XtraGrid.Columns.GridColumn weg_difference;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevExpress.XtraGrid.Columns.GridColumn select_flag;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colSelect;
        private DevExpress.XtraGrid.Columns.GridColumn work_sort;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn manual_date;
    }
}