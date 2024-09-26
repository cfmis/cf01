namespace cf01.ReportForm
{
    partial class frmNewMould
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewMould));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.txtDept1 = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDept2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDept = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.deCheck_Date1 = new DevExpress.XtraEditors.DateEdit();
            this.deCheck_Date2 = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCheckDate = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCheck_Date1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCheck_Date1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCheck_Date2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCheck_Date2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnPrintPreview});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(680, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = false;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 25);
            this.btnExit.Text = "Exit(&E)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.AutoSize = false;
            this.btnPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.Image")));
            this.btnPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(70, 25);
            this.btnPrintPreview.Text = "Find(&F)";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtDept1
            // 
            this.txtDept1.EditValue = "";
            this.txtDept1.EnterMoveNextControl = true;
            this.txtDept1.Location = new System.Drawing.Point(116, 54);
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
            this.txtDept1.Size = new System.Drawing.Size(96, 20);
            this.txtDept1.TabIndex = 11;
            this.txtDept1.Leave += new System.EventHandler(this.txtDept1_Leave);
            // 
            // txtDept2
            // 
            this.txtDept2.EditValue = "";
            this.txtDept2.EnterMoveNextControl = true;
            this.txtDept2.Location = new System.Drawing.Point(228, 54);
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
            this.txtDept2.Size = new System.Drawing.Size(96, 20);
            this.txtDept2.TabIndex = 12;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(40, 53);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(70, 17);
            this.lblDept.TabIndex = 13;
            this.lblDept.Text = "做模部門";
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "~";
            // 
            // deCheck_Date1
            // 
            this.deCheck_Date1.EditValue = null;
            this.deCheck_Date1.EnterMoveNextControl = true;
            this.deCheck_Date1.Location = new System.Drawing.Point(116, 92);
            this.deCheck_Date1.Name = "deCheck_Date1";
            this.deCheck_Date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCheck_Date1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.deCheck_Date1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deCheck_Date1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.deCheck_Date1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deCheck_Date1.Size = new System.Drawing.Size(96, 20);
            this.deCheck_Date1.TabIndex = 30;
            this.deCheck_Date1.Leave += new System.EventHandler(this.deCheck_Date1_Leave);
            // 
            // deCheck_Date2
            // 
            this.deCheck_Date2.EditValue = null;
            this.deCheck_Date2.EnterMoveNextControl = true;
            this.deCheck_Date2.Location = new System.Drawing.Point(228, 92);
            this.deCheck_Date2.Name = "deCheck_Date2";
            this.deCheck_Date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCheck_Date2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.deCheck_Date2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deCheck_Date2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.deCheck_Date2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deCheck_Date2.Size = new System.Drawing.Size(96, 20);
            this.deCheck_Date2.TabIndex = 31;
            this.deCheck_Date2.Leave += new System.EventHandler(this.deCheck_Date2_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "~";
            // 
            // lblCheckDate
            // 
            this.lblCheckDate.Location = new System.Drawing.Point(40, 93);
            this.lblCheckDate.Name = "lblCheckDate";
            this.lblCheckDate.Size = new System.Drawing.Size(70, 17);
            this.lblCheckDate.TabIndex = 34;
            this.lblCheckDate.Text = "審批日期";
            this.lblCheckDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmNewMould
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(680, 369);
            this.Controls.Add(this.lblCheckDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deCheck_Date1);
            this.Controls.Add(this.deCheck_Date2);
            this.Controls.Add(this.txtDept1);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtDept2);
            this.Name = "frmNewMould";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNewMould";
            this.Load += new System.EventHandler(this.frmNewMould_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCheck_Date1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCheck_Date1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCheck_Date2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCheck_Date2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrintPreview;
        private DevExpress.XtraEditors.LookUpEdit txtDept1;
        private DevExpress.XtraEditors.LookUpEdit txtDept2;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DateEdit deCheck_Date1;
        private DevExpress.XtraEditors.DateEdit deCheck_Date2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCheckDate;
    }
}