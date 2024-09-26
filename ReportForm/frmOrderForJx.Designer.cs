namespace cf01.ReportForm
{
    partial class frmOrderForJx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderForJx));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSaveQueryValue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSavePrintOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIsPrint = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDat2 = new System.Windows.Forms.MaskedTextBox();
            this.textDep1 = new System.Windows.Forms.TextBox();
            this.txtDat1 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textMo2 = new System.Windows.Forms.TextBox();
            this.textMo1 = new System.Windows.Forms.TextBox();
            this.textDep2 = new System.Windows.Forms.TextBox();
            this.dgvMoInfo = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolExit,
            this.toolStripSeparator1,
            this.toolFind,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.toolPrint,
            this.toolStripSeparator4,
            this.toolSaveQueryValue,
            this.toolStripSeparator5,
            this.toolSavePrintOrder,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(986, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolExit
            // 
            this.toolExit.AutoSize = false;
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(65, 30);
            this.toolExit.Text = "退出(&X)";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // toolFind
            // 
            this.toolFind.Image = ((System.Drawing.Image)(resources.GetObject("toolFind.Image")));
            this.toolFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFind.Name = "toolFind";
            this.toolFind.Size = new System.Drawing.Size(63, 30);
            this.toolFind.Text = "查詢(&F)";
            this.toolFind.Click += new System.EventHandler(this.toolFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(102, 30);
            this.toolStripButton1.Text = "匯出到Excel(&E)";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // toolPrint
            // 
            this.toolPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolPrint.Image")));
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(99, 30);
            this.toolPrint.Text = "列印工序卡(&P)";
            this.toolPrint.Click += new System.EventHandler(this.toolPrint_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 33);
            // 
            // toolSaveQueryValue
            // 
            this.toolSaveQueryValue.ForeColor = System.Drawing.Color.Blue;
            this.toolSaveQueryValue.Image = ((System.Drawing.Image)(resources.GetObject("toolSaveQueryValue.Image")));
            this.toolSaveQueryValue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveQueryValue.Name = "toolSaveQueryValue";
            this.toolSaveQueryValue.Size = new System.Drawing.Size(97, 30);
            this.toolSaveQueryValue.Text = "保存查詢條件";
            this.toolSaveQueryValue.Click += new System.EventHandler(this.toolSaveQueryValue_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 33);
            // 
            // toolSavePrintOrder
            // 
            this.toolSavePrintOrder.Image = ((System.Drawing.Image)(resources.GetObject("toolSavePrintOrder.Image")));
            this.toolSavePrintOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSavePrintOrder.Name = "toolSavePrintOrder";
            this.toolSavePrintOrder.Size = new System.Drawing.Size(97, 30);
            this.toolSavePrintOrder.Text = "保存打印單據";
            this.toolSavePrintOrder.Click += new System.EventHandler(this.toolSavePrintOrder_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 33);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 33);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvMoInfo);
            this.splitContainer1.Size = new System.Drawing.Size(986, 675);
            this.splitContainer1.SplitterDistance = 79;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkIsPrint);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDat2);
            this.panel1.Controls.Add(this.textDep1);
            this.panel1.Controls.Add(this.txtDat1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textMo2);
            this.panel1.Controls.Add(this.textMo1);
            this.panel1.Controls.Add(this.textDep2);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 79);
            this.panel1.TabIndex = 1;
            // 
            // chkIsPrint
            // 
            this.chkIsPrint.AutoSize = true;
            this.chkIsPrint.ForeColor = System.Drawing.Color.LimeGreen;
            this.chkIsPrint.Location = new System.Drawing.Point(351, 48);
            this.chkIsPrint.Name = "chkIsPrint";
            this.chkIsPrint.Size = new System.Drawing.Size(96, 16);
            this.chkIsPrint.TabIndex = 6;
            this.chkIsPrint.Text = "已打印的記錄";
            this.chkIsPrint.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "入單日期:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部門:";
            // 
            // txtDat2
            // 
            this.txtDat2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDat2.Location = new System.Drawing.Point(541, 15);
            this.txtDat2.Mask = "0000/00/00 00:00:00";
            this.txtDat2.Name = "txtDat2";
            this.txtDat2.PromptChar = ' ';
            this.txtDat2.Size = new System.Drawing.Size(114, 22);
            this.txtDat2.TabIndex = 3;
            this.txtDat2.ValidatingType = typeof(System.DateTime);
            // 
            // textDep1
            // 
            this.textDep1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textDep1.Location = new System.Drawing.Point(65, 15);
            this.textDep1.MaxLength = 3;
            this.textDep1.Name = "textDep1";
            this.textDep1.Size = new System.Drawing.Size(100, 22);
            this.textDep1.TabIndex = 0;
            this.textDep1.Leave += new System.EventHandler(this.textDep1_Leave);
            // 
            // txtDat1
            // 
            this.txtDat1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDat1.Location = new System.Drawing.Point(408, 15);
            this.txtDat1.Mask = "0000/00/00 00:00:00";
            this.txtDat1.Name = "txtDat1";
            this.txtDat1.PromptChar = ' ';
            this.txtDat1.Size = new System.Drawing.Size(114, 22);
            this.txtDat1.TabIndex = 2;
            this.txtDat1.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "制單編號:";
            // 
            // textMo2
            // 
            this.textMo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textMo2.Location = new System.Drawing.Point(184, 43);
            this.textMo2.MaxLength = 9;
            this.textMo2.Name = "textMo2";
            this.textMo2.Size = new System.Drawing.Size(100, 22);
            this.textMo2.TabIndex = 5;
            // 
            // textMo1
            // 
            this.textMo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textMo1.Location = new System.Drawing.Point(65, 43);
            this.textMo1.MaxLength = 9;
            this.textMo1.Name = "textMo1";
            this.textMo1.Size = new System.Drawing.Size(100, 22);
            this.textMo1.TabIndex = 4;
            this.textMo1.Leave += new System.EventHandler(this.textMo1_Leave);
            // 
            // textDep2
            // 
            this.textDep2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textDep2.Location = new System.Drawing.Point(184, 15);
            this.textDep2.MaxLength = 3;
            this.textDep2.Name = "textDep2";
            this.textDep2.Size = new System.Drawing.Size(100, 22);
            this.textDep2.TabIndex = 1;
            // 
            // dgvMoInfo
            // 
            this.dgvMoInfo.AllowUserToAddRows = false;
            this.dgvMoInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMoInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox});
            this.dgvMoInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvMoInfo.Name = "dgvMoInfo";
            this.dgvMoInfo.RowHeadersWidth = 35;
            this.dgvMoInfo.RowTemplate.Height = 30;
            this.dgvMoInfo.Size = new System.Drawing.Size(982, 588);
            this.dgvMoInfo.TabIndex = 0;
            this.dgvMoInfo.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvMoInfo_CellPainting);
            this.dgvMoInfo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMoInfo_RowPostPaint);
            // 
            // CheckBox
            // 
            this.CheckBox.Frozen = true;
            this.CheckBox.HeaderText = "  ";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Width = 40;
            // 
            // frmOrderForJx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(986, 708);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmOrderForJx";
            this.Text = "frmOrderForJx";
            this.Load += new System.EventHandler(this.frmOrderForJx_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.TextBox textDep2;
        private System.Windows.Forms.TextBox textDep1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMoInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtDat1;
        private System.Windows.Forms.MaskedTextBox txtDat2;
        private System.Windows.Forms.TextBox textMo2;
        private System.Windows.Forms.TextBox textMo1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripButton toolSaveQueryValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolSavePrintOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.CheckBox chkIsPrint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
    }
}