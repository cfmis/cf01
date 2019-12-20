namespace cf01.ReportForm
{
    partial class frmSetMouldPosition
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetMouldPosition));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dtSetMouldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSet = new cf01.SqlDataSet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdClose = new System.Windows.Forms.ToolStripButton();
            this.cmdFind = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mkUpdate_date2 = new System.Windows.Forms.MaskedTextBox();
            this.mkUpdate_date1 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSize2 = new System.Windows.Forms.TextBox();
            this.txtSize1 = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtProducts_type2 = new System.Windows.Forms.TextBox();
            this.txtProducts_type1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArtwork2 = new System.Windows.Forms.TextBox();
            this.txtArtwork1 = new System.Windows.Forms.TextBox();
            this.lblArtwork = new System.Windows.Forms.Label();
            this.txtMould2 = new System.Windows.Forms.TextBox();
            this.txtMould1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDept_id = new System.Windows.Forms.Label();
            this.txtdept_id2 = new System.Windows.Forms.TextBox();
            this.txtdept_id1 = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dtSetMouldBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtSetMouldBindingSource
            // 
            this.dtSetMouldBindingSource.DataMember = "dtSetMould";
            this.dtSetMouldBindingSource.DataSource = this.sqlDataSet;
            // 
            // sqlDataSet
            // 
            this.sqlDataSet.DataSetName = "SqlDataSet";
            this.sqlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdClose,
            this.cmdFind});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(918, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(65, 22);
            this.cmdClose.Text = "退出(&X)";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdFind
            // 
            this.cmdFind.Image = ((System.Drawing.Image)(resources.GetObject("cmdFind.Image")));
            this.cmdFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(63, 22);
            this.cmdFind.Text = "查詢(&F)";
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mkUpdate_date2);
            this.panel1.Controls.Add(this.mkUpdate_date1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSize2);
            this.panel1.Controls.Add(this.txtSize1);
            this.panel1.Controls.Add(this.lblSize);
            this.panel1.Controls.Add(this.txtProducts_type2);
            this.panel1.Controls.Add(this.txtProducts_type1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtArtwork2);
            this.panel1.Controls.Add(this.txtArtwork1);
            this.panel1.Controls.Add(this.lblArtwork);
            this.panel1.Controls.Add(this.txtMould2);
            this.panel1.Controls.Add(this.txtMould1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDept_id);
            this.panel1.Controls.Add(this.txtdept_id2);
            this.panel1.Controls.Add(this.txtdept_id1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 108);
            this.panel1.TabIndex = 1;
            // 
            // mkUpdate_date2
            // 
            this.mkUpdate_date2.Location = new System.Drawing.Point(723, 60);
            this.mkUpdate_date2.Mask = "0000/00/00";
            this.mkUpdate_date2.Name = "mkUpdate_date2";
            this.mkUpdate_date2.PromptChar = ' ';
            this.mkUpdate_date2.Size = new System.Drawing.Size(86, 22);
            this.mkUpdate_date2.TabIndex = 22;
            this.mkUpdate_date2.Leave += new System.EventHandler(this.mkUpdate_data2_Leave);
            // 
            // mkUpdate_date1
            // 
            this.mkUpdate_date1.Location = new System.Drawing.Point(632, 60);
            this.mkUpdate_date1.Mask = "0000/00/00";
            this.mkUpdate_date1.Name = "mkUpdate_date1";
            this.mkUpdate_date1.PromptChar = ' ';
            this.mkUpdate_date1.Size = new System.Drawing.Size(86, 22);
            this.mkUpdate_date1.TabIndex = 20;
            this.mkUpdate_date1.TextChanged += new System.EventHandler(this.mkUpdate_date1_TextChanged);
            this.mkUpdate_date1.Leave += new System.EventHandler(this.mkUpdate_date1_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(570, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "修改日期:";
            // 
            // txtSize2
            // 
            this.txtSize2.Location = new System.Drawing.Point(354, 57);
            this.txtSize2.MaxLength = 3;
            this.txtSize2.Name = "txtSize2";
            this.txtSize2.Size = new System.Drawing.Size(54, 22);
            this.txtSize2.TabIndex = 14;
            this.txtSize2.TextChanged += new System.EventHandler(this.txtSize2_TextChanged);
            // 
            // txtSize1
            // 
            this.txtSize1.Location = new System.Drawing.Point(295, 57);
            this.txtSize1.MaxLength = 3;
            this.txtSize1.Name = "txtSize1";
            this.txtSize1.Size = new System.Drawing.Size(54, 22);
            this.txtSize1.TabIndex = 13;
            this.txtSize1.TextChanged += new System.EventHandler(this.txtSize1_TextChanged);
            this.txtSize1.Leave += new System.EventHandler(this.txtSize1_Leave);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(231, 62);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(32, 12);
            this.lblSize.TabIndex = 12;
            this.lblSize.Text = "尺寸:";
            // 
            // txtProducts_type2
            // 
            this.txtProducts_type2.Location = new System.Drawing.Point(140, 57);
            this.txtProducts_type2.MaxLength = 2;
            this.txtProducts_type2.Name = "txtProducts_type2";
            this.txtProducts_type2.Size = new System.Drawing.Size(54, 22);
            this.txtProducts_type2.TabIndex = 11;
            this.txtProducts_type2.TextChanged += new System.EventHandler(this.txtProducts_type2_TextChanged);
            // 
            // txtProducts_type1
            // 
            this.txtProducts_type1.Location = new System.Drawing.Point(80, 57);
            this.txtProducts_type1.MaxLength = 2;
            this.txtProducts_type1.Name = "txtProducts_type1";
            this.txtProducts_type1.Size = new System.Drawing.Size(54, 22);
            this.txtProducts_type1.TabIndex = 10;
            this.txtProducts_type1.TextChanged += new System.EventHandler(this.txtProducts_type1_TextChanged);
            this.txtProducts_type1.Leave += new System.EventHandler(this.txtProducts_type1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "產品類型:";
            // 
            // txtArtwork2
            // 
            this.txtArtwork2.Location = new System.Drawing.Point(723, 14);
            this.txtArtwork2.MaxLength = 7;
            this.txtArtwork2.Name = "txtArtwork2";
            this.txtArtwork2.Size = new System.Drawing.Size(86, 22);
            this.txtArtwork2.TabIndex = 8;
            this.txtArtwork2.TextChanged += new System.EventHandler(this.txtArtwork2_TextChanged);
            // 
            // txtArtwork1
            // 
            this.txtArtwork1.Location = new System.Drawing.Point(632, 14);
            this.txtArtwork1.MaxLength = 7;
            this.txtArtwork1.Name = "txtArtwork1";
            this.txtArtwork1.Size = new System.Drawing.Size(86, 22);
            this.txtArtwork1.TabIndex = 7;
            this.txtArtwork1.TextChanged += new System.EventHandler(this.txtArtwork1_TextChanged);
            this.txtArtwork1.Leave += new System.EventHandler(this.txtArtwork1_Leave);
            // 
            // lblArtwork
            // 
            this.lblArtwork.AutoSize = true;
            this.lblArtwork.Location = new System.Drawing.Point(570, 19);
            this.lblArtwork.Name = "lblArtwork";
            this.lblArtwork.Size = new System.Drawing.Size(56, 12);
            this.lblArtwork.TabIndex = 6;
            this.lblArtwork.Text = "圖樣編號:";
            // 
            // txtMould2
            // 
            this.txtMould2.Location = new System.Drawing.Point(416, 14);
            this.txtMould2.MaxLength = 13;
            this.txtMould2.Name = "txtMould2";
            this.txtMould2.Size = new System.Drawing.Size(113, 22);
            this.txtMould2.TabIndex = 5;
            this.txtMould2.TextChanged += new System.EventHandler(this.txtMould2_TextChanged);
            // 
            // txtMould1
            // 
            this.txtMould1.Location = new System.Drawing.Point(295, 14);
            this.txtMould1.MaxLength = 13;
            this.txtMould1.Name = "txtMould1";
            this.txtMould1.Size = new System.Drawing.Size(117, 22);
            this.txtMould1.TabIndex = 4;
            this.txtMould1.TextChanged += new System.EventHandler(this.txtMould1_TextChanged);
            this.txtMould1.Leave += new System.EventHandler(this.txtMould1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "模具編號:";
            // 
            // lblDept_id
            // 
            this.lblDept_id.AutoSize = true;
            this.lblDept_id.Location = new System.Drawing.Point(12, 19);
            this.lblDept_id.Name = "lblDept_id";
            this.lblDept_id.Size = new System.Drawing.Size(56, 12);
            this.lblDept_id.TabIndex = 2;
            this.lblDept_id.Text = "部門編號:";
            // 
            // txtdept_id2
            // 
            this.txtdept_id2.Location = new System.Drawing.Point(140, 14);
            this.txtdept_id2.MaxLength = 3;
            this.txtdept_id2.Name = "txtdept_id2";
            this.txtdept_id2.Size = new System.Drawing.Size(54, 22);
            this.txtdept_id2.TabIndex = 1;
            this.txtdept_id2.TextChanged += new System.EventHandler(this.txtdept_id2_TextChanged);
            // 
            // txtdept_id1
            // 
            this.txtdept_id1.Location = new System.Drawing.Point(80, 14);
            this.txtdept_id1.MaxLength = 3;
            this.txtdept_id1.Name = "txtdept_id1";
            this.txtdept_id1.Size = new System.Drawing.Size(54, 22);
            this.txtdept_id1.TabIndex = 0;
            this.txtdept_id1.TextChanged += new System.EventHandler(this.txtdept_id1_TextChanged);
            this.txtdept_id1.Leave += new System.EventHandler(this.txtdept_id1_Leave);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dtSetMouldBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "cf01.Reports.rdlMouldPosition.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 133);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(918, 314);
            this.reportViewer1.TabIndex = 2;
            // 
            // frmSetMouldPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 447);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSetMouldPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模具罷放位置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetMouldPosition_FormClosing);
            this.Load += new System.EventHandler(this.frmSetMouldPosition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtSetMouldBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ToolStripButton cmdClose;
        private System.Windows.Forms.ToolStripButton cmdFind;
        private System.Windows.Forms.TextBox txtdept_id1;
        private System.Windows.Forms.Label lblDept_id;
        private System.Windows.Forms.TextBox txtdept_id2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMould2;
        private System.Windows.Forms.TextBox txtMould1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArtwork2;
        private System.Windows.Forms.TextBox txtArtwork1;
        private System.Windows.Forms.Label lblArtwork;
        private System.Windows.Forms.TextBox txtProducts_type2;
        private System.Windows.Forms.TextBox txtProducts_type1;
        private System.Windows.Forms.TextBox txtSize2;
        private System.Windows.Forms.TextBox txtSize1;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label label3;
        private SqlDataSet sqlDataSet;
        private System.Windows.Forms.BindingSource dtSetMouldBindingSource;
        private System.Windows.Forms.MaskedTextBox mkUpdate_date1;
        private System.Windows.Forms.MaskedTextBox mkUpdate_date2;
    }
}