namespace cf01.Forms
{
    partial class frmQuotationSub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuotationSub));
            this.txtTemp_code = new DevExpress.XtraEditors.TextEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.seq_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sub = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSub = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.pvh_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.attn_path = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBtnAttn_path = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Satus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clLkpStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.approval_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.approval_by = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.create_by = new DevExpress.XtraGrid.Columns.GridColumn();
            this.create_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.update_by = new DevExpress.XtraGrid.Columns.GridColumn();
            this.update_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.approval_status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clisApproval = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.clSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clBtnAttn_path)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clLkpStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clisApproval)).BeginInit();
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
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.clBtnAttn_path,
            this.clisApproval,
            this.clSub,
            this.clLkpStatus});
            this.gridControl1.Size = new System.Drawing.Size(1230, 546);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.seq_id,
            this.sub,
            this.pvh_no,
            this.attn_path,
            this.Satus,
            this.approval_date,
            this.approval_by,
            this.remark,
            this.create_by,
            this.create_date,
            this.update_by,
            this.update_date,
            this.approval_status,
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
            this.seq_id.Visible = true;
            this.seq_id.VisibleIndex = 0;
            this.seq_id.Width = 33;
            // 
            // sub
            // 
            this.sub.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.sub.AppearanceHeader.Options.UseFont = true;
            this.sub.Caption = "Sub Items";
            this.sub.ColumnEdit = this.clSub;
            this.sub.FieldName = "sub";
            this.sub.Name = "sub";
            this.sub.OptionsColumn.AllowMove = false;
            this.sub.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.sub.OptionsFilter.AllowAutoFilter = false;
            this.sub.OptionsFilter.AllowFilter = false;
            this.sub.Tag = "2";
            this.sub.Visible = true;
            this.sub.VisibleIndex = 1;
            this.sub.Width = 117;
            // 
            // clSub
            // 
            this.clSub.AutoHeight = false;
            this.clSub.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.clSub.MaxLength = 150;
            this.clSub.Name = "clSub";
            this.clSub.Leave += new System.EventHandler(this.clSub_Leave);
            // 
            // pvh_no
            // 
            this.pvh_no.Caption = "PVH/JV REF. NO.";
            this.pvh_no.FieldName = "pvh_no";
            this.pvh_no.Name = "pvh_no";
            this.pvh_no.OptionsColumn.AllowMove = false;
            this.pvh_no.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pvh_no.OptionsFilter.AllowAutoFilter = false;
            this.pvh_no.OptionsFilter.AllowFilter = false;
            this.pvh_no.Visible = true;
            this.pvh_no.VisibleIndex = 2;
            this.pvh_no.Width = 230;
            // 
            // attn_path
            // 
            this.attn_path.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.attn_path.AppearanceHeader.Options.UseFont = true;
            this.attn_path.Caption = "Attachment Path";
            this.attn_path.ColumnEdit = this.clBtnAttn_path;
            this.attn_path.FieldName = "attn_path";
            this.attn_path.Name = "attn_path";
            this.attn_path.OptionsColumn.AllowMove = false;
            this.attn_path.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.attn_path.OptionsFilter.AllowAutoFilter = false;
            this.attn_path.OptionsFilter.AllowFilter = false;
            this.attn_path.Tag = "2";
            this.attn_path.Visible = true;
            this.attn_path.VisibleIndex = 3;
            this.attn_path.Width = 140;
            // 
            // clBtnAttn_path
            // 
            this.clBtnAttn_path.AutoHeight = false;
            this.clBtnAttn_path.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.clBtnAttn_path.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.clBtnAttn_path.MaxLength = 255;
            this.clBtnAttn_path.Name = "clBtnAttn_path";
            this.clBtnAttn_path.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.clBtnTest_report_no_ButtonClick);
            this.clBtnAttn_path.DoubleClick += new System.EventHandler(this.clBtnAttn_path_DoubleClick);
            // 
            // Satus
            // 
            this.Satus.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.Satus.AppearanceCell.Options.UseForeColor = true;
            this.Satus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Satus.AppearanceHeader.Options.UseFont = true;
            this.Satus.Caption = "Status";
            this.Satus.ColumnEdit = this.clLkpStatus;
            this.Satus.FieldName = "status";
            this.Satus.Name = "Satus";
            this.Satus.OptionsColumn.AllowMove = false;
            this.Satus.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Satus.OptionsFilter.AllowAutoFilter = false;
            this.Satus.OptionsFilter.AllowFilter = false;
            this.Satus.Visible = true;
            this.Satus.VisibleIndex = 4;
            this.Satus.Width = 110;
            // 
            // clLkpStatus
            // 
            this.clLkpStatus.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.clLkpStatus.Appearance.Options.UseForeColor = true;
            this.clLkpStatus.AutoHeight = false;
            this.clLkpStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clLkpStatus.Name = "clLkpStatus";
            this.clLkpStatus.ShowHeader = false;
            this.clLkpStatus.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.clLkpStatus.EditValueChanged += new System.EventHandler(this.clLkpStatus_EditValueChanged);
            // 
            // approval_date
            // 
            this.approval_date.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.approval_date.AppearanceCell.Options.UseForeColor = true;
            this.approval_date.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.approval_date.AppearanceHeader.Options.UseFont = true;
            this.approval_date.Caption = "Status Date";
            this.approval_date.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.approval_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.approval_date.FieldName = "approval_date";
            this.approval_date.Name = "approval_date";
            this.approval_date.OptionsColumn.AllowMove = false;
            this.approval_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.approval_date.OptionsFilter.AllowAutoFilter = false;
            this.approval_date.OptionsFilter.AllowFilter = false;
            this.approval_date.Visible = true;
            this.approval_date.VisibleIndex = 5;
            this.approval_date.Width = 102;
            // 
            // approval_by
            // 
            this.approval_by.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.approval_by.AppearanceCell.Options.UseForeColor = true;
            this.approval_by.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.approval_by.AppearanceHeader.Options.UseFont = true;
            this.approval_by.Caption = "Set Status by";
            this.approval_by.FieldName = "approval_by";
            this.approval_by.Name = "approval_by";
            this.approval_by.OptionsColumn.AllowMove = false;
            this.approval_by.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.approval_by.OptionsColumn.ReadOnly = true;
            this.approval_by.OptionsFilter.AllowAutoFilter = false;
            this.approval_by.OptionsFilter.AllowFilter = false;
            this.approval_by.Visible = true;
            this.approval_by.VisibleIndex = 6;
            this.approval_by.Width = 97;
            // 
            // remark
            // 
            this.remark.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.remark.AppearanceHeader.Options.UseFont = true;
            this.remark.Caption = "Remark";
            this.remark.FieldName = "remark";
            this.remark.Name = "remark";
            this.remark.OptionsColumn.AllowMove = false;
            this.remark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.remark.OptionsFilter.AllowAutoFilter = false;
            this.remark.OptionsFilter.AllowFilter = false;
            this.remark.Tag = "2";
            this.remark.Visible = true;
            this.remark.VisibleIndex = 7;
            this.remark.Width = 263;
            // 
            // create_by
            // 
            this.create_by.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.create_by.AppearanceHeader.Options.UseFont = true;
            this.create_by.Caption = "Create by";
            this.create_by.FieldName = "crusr";
            this.create_by.Name = "create_by";
            this.create_by.OptionsColumn.AllowMove = false;
            this.create_by.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.create_by.OptionsColumn.ReadOnly = true;
            this.create_by.OptionsFilter.AllowAutoFilter = false;
            this.create_by.OptionsFilter.AllowFilter = false;
            this.create_by.Visible = true;
            this.create_by.VisibleIndex = 8;
            this.create_by.Width = 92;
            // 
            // create_date
            // 
            this.create_date.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.create_date.AppearanceHeader.Options.UseFont = true;
            this.create_date.Caption = "Create date";
            this.create_date.FieldName = "crtim";
            this.create_date.Name = "create_date";
            this.create_date.OptionsColumn.AllowMove = false;
            this.create_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.create_date.OptionsColumn.ReadOnly = true;
            this.create_date.OptionsFilter.AllowAutoFilter = false;
            this.create_date.OptionsFilter.AllowFilter = false;
            this.create_date.Visible = true;
            this.create_date.VisibleIndex = 9;
            this.create_date.Width = 81;
            // 
            // update_by
            // 
            this.update_by.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.update_by.AppearanceHeader.Options.UseFont = true;
            this.update_by.Caption = "Upadte by";
            this.update_by.FieldName = "amusr";
            this.update_by.Name = "update_by";
            this.update_by.OptionsColumn.AllowMove = false;
            this.update_by.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.update_by.OptionsColumn.ReadOnly = true;
            this.update_by.OptionsFilter.AllowAutoFilter = false;
            this.update_by.OptionsFilter.AllowFilter = false;
            this.update_by.Visible = true;
            this.update_by.VisibleIndex = 10;
            this.update_by.Width = 71;
            // 
            // update_date
            // 
            this.update_date.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.update_date.AppearanceHeader.Options.UseFont = true;
            this.update_date.Caption = "Update Date";
            this.update_date.FieldName = "amtim";
            this.update_date.Name = "update_date";
            this.update_date.OptionsColumn.AllowMove = false;
            this.update_date.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.update_date.OptionsColumn.ReadOnly = true;
            this.update_date.OptionsFilter.AllowAutoFilter = false;
            this.update_date.OptionsFilter.AllowFilter = false;
            this.update_date.Visible = true;
            this.update_date.VisibleIndex = 11;
            this.update_date.Width = 27;
            // 
            // approval_status
            // 
            this.approval_status.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.approval_status.AppearanceCell.Options.UseForeColor = true;
            this.approval_status.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.approval_status.AppearanceHeader.Options.UseFont = true;
            this.approval_status.Caption = "Approved";
            this.approval_status.ColumnEdit = this.clisApproval;
            this.approval_status.FieldName = "approval_status";
            this.approval_status.Name = "approval_status";
            this.approval_status.OptionsColumn.AllowMove = false;
            this.approval_status.OptionsFilter.AllowAutoFilter = false;
            this.approval_status.OptionsFilter.AllowFilter = false;
            this.approval_status.Width = 71;
            // 
            // clisApproval
            // 
            this.clisApproval.AutoHeight = false;
            this.clisApproval.Name = "clisApproval";
            this.clisApproval.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.clisApproval.CheckedChanged += new System.EventHandler(this.clisApproval_CheckedChanged);
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
            // frmQuotationSub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 597);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtTemp_code);
            this.Name = "frmQuotationSub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuotationSub";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuotationSub_FormClosed);
            this.Load += new System.EventHandler(this.frmQuotationSub_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTemp_code.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clBtnAttn_path)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clLkpStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clisApproval)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn sub;
        private DevExpress.XtraGrid.Columns.GridColumn attn_path;
        private DevExpress.XtraGrid.Columns.GridColumn approval_status;
        private DevExpress.XtraGrid.Columns.GridColumn remark;
        private DevExpress.XtraGrid.Columns.GridColumn seq_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit clBtnAttn_path;
        private DevExpress.XtraGrid.Columns.GridColumn temp_code;
        private DevExpress.XtraGrid.Columns.GridColumn approval_date;
        private DevExpress.XtraEditors.TextEdit txtTemp_code;
        private DevExpress.XtraGrid.Columns.GridColumn create_by;
        private DevExpress.XtraGrid.Columns.GridColumn create_date;
        private DevExpress.XtraGrid.Columns.GridColumn update_by;
        private DevExpress.XtraGrid.Columns.GridColumn update_date;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit clisApproval;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit clSub;
        private DevExpress.XtraGrid.Columns.GridColumn approval_by;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BTNDELETE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DevExpress.XtraGrid.Columns.GridColumn Satus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit clLkpStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private DevExpress.XtraGrid.Columns.GridColumn pvh_no;
    }
}