namespace cf01.ReportForm
{
    partial class frmPlate01
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlate01));
            this.dsfrmPlan01BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSet = new cf01.SqlDataSet();
            this.dsfrmPlate01BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.txtId1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtVend2 = new System.Windows.Forms.TextBox();
            this.datPlan2 = new System.Windows.Forms.DateTimePicker();
            this.datPlan1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVend1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdClose = new System.Windows.Forms.ToolStripButton();
            this.cmdFind = new System.Windows.Forms.ToolStripButton();
            this.dsfrmPlate01TableAdapter = new cf01.SqlDataSetTableAdapters.dsfrmPlate01TableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dsfrmPlan01BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsfrmPlate01BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsfrmPlan01BindingSource
            // 
            this.dsfrmPlan01BindingSource.DataMember = "dsfrmPlan01";
            this.dsfrmPlan01BindingSource.DataSource = this.sqlDataSet;
            // 
            // sqlDataSet
            // 
            this.sqlDataSet.DataSetName = "SqlDataSet";
            this.sqlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsfrmPlate01BindingSource
            // 
            this.dsfrmPlate01BindingSource.DataMember = "dsfrmPlate01";
            this.dsfrmPlate01BindingSource.DataSource = this.sqlDataSet;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox2);
            this.splitContainer1.Panel1.Controls.Add(this.txtId1);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel1.Controls.Add(this.txtVend2);
            this.splitContainer1.Panel1.Controls.Add(this.datPlan2);
            this.splitContainer1.Panel1.Controls.Add(this.datPlan1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtVend1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(675, 435);
            this.splitContainer1.SplitterDistance = 106;
            this.splitContainer1.TabIndex = 0;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(187, 77);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "外發記錄";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            this.checkBox2.Click += new System.EventHandler(this.checkBox2_Click);
            // 
            // txtId1
            // 
            this.txtId1.Location = new System.Drawing.Point(357, 74);
            this.txtId1.Name = "txtId1";
            this.txtId1.Size = new System.Drawing.Size(100, 22);
            this.txtId1.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(80, 77);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "不要顯示顏色";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // txtVend2
            // 
            this.txtVend2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVend2.Location = new System.Drawing.Point(175, 42);
            this.txtVend2.MaxLength = 8;
            this.txtVend2.Name = "txtVend2";
            this.txtVend2.Size = new System.Drawing.Size(89, 22);
            this.txtVend2.TabIndex = 1;
            // 
            // datPlan2
            // 
            this.datPlan2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datPlan2.Location = new System.Drawing.Point(453, 42);
            this.datPlan2.Name = "datPlan2";
            this.datPlan2.Size = new System.Drawing.Size(83, 22);
            this.datPlan2.TabIndex = 3;
            // 
            // datPlan1
            // 
            this.datPlan1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datPlan1.Location = new System.Drawing.Point(353, 42);
            this.datPlan1.Name = "datPlan1";
            this.datPlan1.Size = new System.Drawing.Size(83, 22);
            this.datPlan1.TabIndex = 2;
            this.datPlan1.Value = new System.DateTime(2013, 7, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "發貨日期:";
            // 
            // txtVend1
            // 
            this.txtVend1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVend1.Location = new System.Drawing.Point(80, 42);
            this.txtVend1.MaxLength = 8;
            this.txtVend1.Name = "txtVend1";
            this.txtVend1.Size = new System.Drawing.Size(89, 22);
            this.txtVend1.TabIndex = 0;
            this.txtVend1.Leave += new System.EventHandler(this.txtVend1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "供應商:";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dsfrmPlan01BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "cf01.Reports.TestReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(675, 325);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.reportViewer1_ReportExport);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdClose,
            this.cmdFind});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(675, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmdClose
            // 
            this.cmdClose.AutoSize = false;
            this.cmdClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(55, 28);
            this.cmdClose.Text = "退出(&X)";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdFind
            // 
            this.cmdFind.AutoSize = false;
            this.cmdFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdFind.Image = ((System.Drawing.Image)(resources.GetObject("cmdFind.Image")));
            this.cmdFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(47, 28);
            this.cmdFind.Text = "查詢(&F)";
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // dsfrmPlate01TableAdapter
            // 
            this.dsfrmPlate01TableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmPlate01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 435);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPlate01";
            this.Text = "frmPlate01";
            this.Load += new System.EventHandler(this.frmPlate01_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsfrmPlan01BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsfrmPlate01BindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cmdClose;
        private System.Windows.Forms.ToolStripButton cmdFind;
        private System.Windows.Forms.TextBox txtVend2;
        private System.Windows.Forms.DateTimePicker datPlan2;
        private System.Windows.Forms.DateTimePicker datPlan1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVend1;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SqlDataSet sqlDataSet;
        private System.Windows.Forms.BindingSource dsfrmPlate01BindingSource;
        private SqlDataSetTableAdapters.dsfrmPlate01TableAdapter dsfrmPlate01TableAdapter;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtId1;
        private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.BindingSource dsfrmPlan01BindingSource;
        private System.Windows.Forms.Button button1;
    }
}