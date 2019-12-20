namespace cf01.Forms
{
    partial class frmQuotation_Group
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuotation_Group));
            this.txtTemp_code = new DevExpress.XtraEditors.TextEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.seq_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.group_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clLkpGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemp_code.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clLkpGroup)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTemp_code
            // 
            this.txtTemp_code.EditValue = "";
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
            this.panel3.Size = new System.Drawing.Size(757, 205);
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
            this.clLkpGroup});
            this.gridControl1.Size = new System.Drawing.Size(748, 196);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.seq_id,
            this.group_id,
            this.remark,
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
            this.seq_id.Visible = true;
            this.seq_id.VisibleIndex = 0;
            this.seq_id.Width = 53;
            // 
            // group_id
            // 
            this.group_id.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.group_id.AppearanceCell.Options.UseForeColor = true;
            this.group_id.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.group_id.AppearanceHeader.Options.UseFont = true;
            this.group_id.Caption = "組別";
            this.group_id.ColumnEdit = this.clLkpGroup;
            this.group_id.FieldName = "group_id";
            this.group_id.Name = "group_id";
            this.group_id.OptionsColumn.AllowMove = false;
            this.group_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.group_id.OptionsFilter.AllowAutoFilter = false;
            this.group_id.OptionsFilter.AllowFilter = false;
            this.group_id.Visible = true;
            this.group_id.VisibleIndex = 1;
            this.group_id.Width = 114;
            // 
            // clLkpGroup
            // 
            this.clLkpGroup.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.clLkpGroup.Appearance.Options.UseForeColor = true;
            this.clLkpGroup.AutoHeight = false;
            this.clLkpGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clLkpGroup.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 40, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 60, "cdesc")});
            this.clLkpGroup.Name = "clLkpGroup";
            this.clLkpGroup.NullText = "";
            this.clLkpGroup.ShowHeader = false;
            this.clLkpGroup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // remark
            // 
            this.remark.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.remark.AppearanceHeader.Options.UseFont = true;
            this.remark.Caption = "備註";
            this.remark.FieldName = "remark";
            this.remark.Name = "remark";
            this.remark.OptionsColumn.AllowMove = false;
            this.remark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.remark.OptionsFilter.AllowAutoFilter = false;
            this.remark.OptionsFilter.AllowFilter = false;
            this.remark.Tag = "2";
            this.remark.Visible = true;
            this.remark.VisibleIndex = 2;
            this.remark.Width = 112;
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
            this.create_by.VisibleIndex = 3;
            this.create_by.Width = 91;
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
            this.create_date.VisibleIndex = 4;
            this.create_date.Width = 109;
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
            this.update_by.VisibleIndex = 5;
            this.update_by.Width = 108;
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
            this.update_date.VisibleIndex = 6;
            this.update_date.Width = 127;
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
            this.toolStripSeparator3,
            this.BTNCANCEL,
            this.toolStripSeparator5,
            this.BTNSAVE,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(760, 38);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
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
            // frmQuotation_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 247);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtTemp_code);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuotation_Group";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "組別設置";
            this.Load += new System.EventHandler(this.frmQuotation_Group_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTemp_code.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clLkpGroup)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn remark;
        private DevExpress.XtraGrid.Columns.GridColumn seq_id;
        private DevExpress.XtraGrid.Columns.GridColumn temp_code;
        private DevExpress.XtraEditors.TextEdit txtTemp_code;
        private DevExpress.XtraGrid.Columns.GridColumn create_by;
        private DevExpress.XtraGrid.Columns.GridColumn create_date;
        private DevExpress.XtraGrid.Columns.GridColumn update_by;
        private DevExpress.XtraGrid.Columns.GridColumn update_date;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BTNDELETE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DevExpress.XtraGrid.Columns.GridColumn group_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit clLkpGroup;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}