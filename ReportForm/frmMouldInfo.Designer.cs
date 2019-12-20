namespace cf01.ReportForm
{
    partial class frmMouldInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMouldInfo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDate2 = new DevExpress.XtraEditors.DateEdit();
            this.txtDept2 = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDept1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate1 = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bill_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mould_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.draw_ver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dept_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.goods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.complete_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.accomplish_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator2,
            this.btnFind,
            this.toolStripSeparator1,
            this.btnExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(763, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(64, 22);
            this.btnExit.Text = "退出(&E)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(63, 22);
            this.btnFind.Text = "查詢(&F)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(86, 22);
            this.btnExcel.Text = "匯出EXCEL";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtDate2);
            this.panel1.Controls.Add(this.txtDept2);
            this.panel1.Controls.Add(this.txtDept1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDate1);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 68);
            this.panel1.TabIndex = 1;
            // 
            // txtDate2
            // 
            this.txtDate2.EditValue = null;
            this.txtDate2.EnterMoveNextControl = true;
            this.txtDate2.Location = new System.Drawing.Point(225, 39);
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDate2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtDate2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDate2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDate2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDate2.Size = new System.Drawing.Size(100, 20);
            this.txtDate2.TabIndex = 3;
            // 
            // txtDept2
            // 
            this.txtDept2.EditValue = "";
            this.txtDept2.EnterMoveNextControl = true;
            this.txtDept2.Location = new System.Drawing.Point(225, 8);
            this.txtDept2.Name = "txtDept2";
            this.txtDept2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDept2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDept2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 100, DevExpress.Utils.FormatType.Custom, "", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Name", 150, DevExpress.Utils.FormatType.Custom, "", true, DevExpress.Utils.HorzAlignment.Default)});
            this.txtDept2.Properties.DropDownRows = 15;
            this.txtDept2.Properties.MaxLength = 3;
            this.txtDept2.Properties.NullText = "";
            this.txtDept2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtDept2.Size = new System.Drawing.Size(100, 20);
            this.txtDept2.TabIndex = 1;
            // 
            // txtDept1
            // 
            this.txtDept1.EditValue = "";
            this.txtDept1.EnterMoveNextControl = true;
            this.txtDept1.Location = new System.Drawing.Point(102, 8);
            this.txtDept1.Name = "txtDept1";
            this.txtDept1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDept1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDept1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 100, DevExpress.Utils.FormatType.Custom, "", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Name", 150, DevExpress.Utils.FormatType.Custom, "", true, DevExpress.Utils.HorzAlignment.Default)});
            this.txtDept1.Properties.DropDownRows = 15;
            this.txtDept1.Properties.MaxLength = 3;
            this.txtDept1.Properties.NullText = "";
            this.txtDept1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtDept1.Size = new System.Drawing.Size(100, 20);
            this.txtDept1.TabIndex = 0;
            this.txtDept1.TabStop = false;
            this.txtDept1.Leave += new System.EventHandler(this.txtDept1_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "~";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "通知單日期";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "做模部門";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate1
            // 
            this.txtDate1.EditValue = null;
            this.txtDate1.EnterMoveNextControl = true;
            this.txtDate1.Location = new System.Drawing.Point(102, 39);
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDate1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtDate1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDate1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDate1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDate1.Size = new System.Drawing.Size(100, 20);
            this.txtDate1.TabIndex = 2;
            this.txtDate1.Leave += new System.EventHandler(this.txtDate1_Leave);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 102);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(763, 324);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.ver,
            this.bill_date,
            this.mould_no,
            this.draw_ver,
            this.dept_id,
            this.mo_id,
            this.goods_id,
            this.name,
            this.complete_date,
            this.accomplish_date});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // id
            // 
            this.id.Caption = "做模通知單編號";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.Visible = true;
            this.id.VisibleIndex = 0;
            // 
            // ver
            // 
            this.ver.Caption = "版本";
            this.ver.FieldName = "ver";
            this.ver.Name = "ver";
            this.ver.Visible = true;
            this.ver.VisibleIndex = 1;
            // 
            // bill_date
            // 
            this.bill_date.Caption = "開單日期";
            this.bill_date.FieldName = "bill_date";
            this.bill_date.Name = "bill_date";
            this.bill_date.Visible = true;
            this.bill_date.VisibleIndex = 2;
            // 
            // mould_no
            // 
            this.mould_no.Caption = "畫稿編號";
            this.mould_no.FieldName = "mould_no";
            this.mould_no.Name = "mould_no";
            this.mould_no.Visible = true;
            this.mould_no.VisibleIndex = 3;
            // 
            // draw_ver
            // 
            this.draw_ver.Caption = "畫稿版本";
            this.draw_ver.FieldName = "draw_ver";
            this.draw_ver.Name = "draw_ver";
            this.draw_ver.Visible = true;
            this.draw_ver.VisibleIndex = 4;
            // 
            // dept_id
            // 
            this.dept_id.Caption = "做模部門";
            this.dept_id.FieldName = "dept_id";
            this.dept_id.Name = "dept_id";
            this.dept_id.Visible = true;
            this.dept_id.VisibleIndex = 5;
            // 
            // mo_id
            // 
            this.mo_id.Caption = "N單頁數";
            this.mo_id.FieldName = "mo_id";
            this.mo_id.Name = "mo_id";
            this.mo_id.Visible = true;
            this.mo_id.VisibleIndex = 6;
            // 
            // goods_id
            // 
            this.goods_id.Caption = "貨品編碼";
            this.goods_id.FieldName = "goods_id";
            this.goods_id.Name = "goods_id";
            this.goods_id.Visible = true;
            this.goods_id.VisibleIndex = 7;
            // 
            // name
            // 
            this.name.Caption = "貨品名稱";
            this.name.FieldName = "name";
            this.name.Name = "name";
            this.name.Visible = true;
            this.name.VisibleIndex = 8;
            // 
            // complete_date
            // 
            this.complete_date.Caption = "理論完成日期";
            this.complete_date.FieldName = "complete_date";
            this.complete_date.Name = "complete_date";
            this.complete_date.Visible = true;
            this.complete_date.VisibleIndex = 9;
            // 
            // accomplish_date
            // 
            this.accomplish_date.Caption = "完成日期";
            this.accomplish_date.FieldName = "accomplish_date";
            this.accomplish_date.Name = "accomplish_date";
            this.accomplish_date.Visible = true;
            this.accomplish_date.VisibleIndex = 10;
            // 
            // frmMouldInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(763, 430);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMouldInfo";
            this.Text = "frmMouldInfo";
            this.Load += new System.EventHandler(this.frmMouldInfo_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit txtDate1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit txtDept1;
        private DevExpress.XtraEditors.DateEdit txtDate2;
        private DevExpress.XtraEditors.LookUpEdit txtDept2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn bill_date;
        private DevExpress.XtraGrid.Columns.GridColumn mould_no;
        private DevExpress.XtraGrid.Columns.GridColumn draw_ver;
        private DevExpress.XtraGrid.Columns.GridColumn dept_id;
        private DevExpress.XtraGrid.Columns.GridColumn mo_id;
        private DevExpress.XtraGrid.Columns.GridColumn goods_id;
        private DevExpress.XtraGrid.Columns.GridColumn name;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private DevExpress.XtraGrid.Columns.GridColumn ver;
        private DevExpress.XtraGrid.Columns.GridColumn complete_date;
        private DevExpress.XtraGrid.Columns.GridColumn accomplish_date;
    }
}