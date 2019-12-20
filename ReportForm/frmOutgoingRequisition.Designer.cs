namespace cf01.ReportForm
{
    partial class frmOutgoingRequisition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutgoingRequisition));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rdbNotRequest = new System.Windows.Forms.RadioButton();
            this.rdbRequest = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDate2 = new System.Windows.Forms.MaskedTextBox();
            this.txtDate1 = new System.Windows.Forms.MaskedTextBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.dgvDetials = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBill_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrder_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProd_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDept_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDept_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetials)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.btnFind,
            this.btnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(52, 22);
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(52, 22);
            this.btnFind.Text = "查詢";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 22);
            this.btnPrint.Text = "列印工序卡";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rdbNotRequest);
            this.splitContainer1.Panel1.Controls.Add(this.rdbRequest);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtDate2);
            this.splitContainer1.Panel1.Controls.Add(this.txtDate1);
            this.splitContainer1.Panel1.Controls.Add(this.txtDept);
            this.splitContainer1.Panel1.Controls.Add(this.lblDept);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetials);
            this.splitContainer1.Size = new System.Drawing.Size(784, 512);
            this.splitContainer1.SplitterDistance = 102;
            this.splitContainer1.TabIndex = 1;
            // 
            // rdbNotRequest
            // 
            this.rdbNotRequest.AutoSize = true;
            this.rdbNotRequest.Location = new System.Drawing.Point(477, 22);
            this.rdbNotRequest.Name = "rdbNotRequest";
            this.rdbNotRequest.Size = new System.Drawing.Size(83, 16);
            this.rdbNotRequest.TabIndex = 9;
            this.rdbNotRequest.TabStop = true;
            this.rdbNotRequest.Text = "未申請外發";
            this.rdbNotRequest.UseVisualStyleBackColor = true;
            // 
            // rdbRequest
            // 
            this.rdbRequest.AutoSize = true;
            this.rdbRequest.Location = new System.Drawing.Point(477, 65);
            this.rdbRequest.Name = "rdbRequest";
            this.rdbRequest.Size = new System.Drawing.Size(83, 16);
            this.rdbRequest.TabIndex = 9;
            this.rdbRequest.TabStop = true;
            this.rdbRequest.Text = "已申請外發";
            this.rdbRequest.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "申請日期：";
            // 
            // txtDate2
            // 
            this.txtDate2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate2.Location = new System.Drawing.Point(277, 64);
            this.txtDate2.Mask = "0000/00/00 00:00:00";
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.PromptChar = ' ';
            this.txtDate2.Size = new System.Drawing.Size(128, 22);
            this.txtDate2.TabIndex = 7;
            this.txtDate2.ValidatingType = typeof(System.DateTime);
            // 
            // txtDate1
            // 
            this.txtDate1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate1.Location = new System.Drawing.Point(143, 64);
            this.txtDate1.Mask = "0000/00/00 00:00:00";
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.PromptChar = ' ';
            this.txtDate1.Size = new System.Drawing.Size(128, 22);
            this.txtDate1.TabIndex = 6;
            this.txtDate1.ValidatingType = typeof(System.DateTime);
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(143, 21);
            this.txtDept.MaxLength = 3;
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(114, 22);
            this.txtDept.TabIndex = 1;
            this.txtDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDept_KeyDown);
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(96, 24);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(41, 12);
            this.lblDept.TabIndex = 0;
            this.lblDept.Text = "部門：";
            // 
            // dgvDetials
            // 
            this.dgvDetials.AllowUserToAddRows = false;
            this.dgvDetials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckbox,
            this.colMo_id,
            this.colGoods_id,
            this.colGoods_name,
            this.colBill_date,
            this.colOrder_qty,
            this.colProd_qty,
            this.colDept_id,
            this.colDept_name,
            this.colVendor_id});
            this.dgvDetials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetials.Location = new System.Drawing.Point(0, 0);
            this.dgvDetials.Name = "dgvDetials";
            this.dgvDetials.RowTemplate.Height = 24;
            this.dgvDetials.Size = new System.Drawing.Size(784, 406);
            this.dgvDetials.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "物料編號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "物料名稱";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "申請日期";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "訂單數量";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "生產數量";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "部門編號";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "部門名稱";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "供應商";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // colCheckbox
            // 
            this.colCheckbox.HeaderText = "";
            this.colCheckbox.Name = "colCheckbox";
            this.colCheckbox.Width = 20;
            // 
            // colMo_id
            // 
            this.colMo_id.DataPropertyName = "mo_id";
            this.colMo_id.HeaderText = "制單編號";
            this.colMo_id.Name = "colMo_id";
            // 
            // colGoods_id
            // 
            this.colGoods_id.DataPropertyName = "goods_id";
            this.colGoods_id.HeaderText = "物料編號";
            this.colGoods_id.Name = "colGoods_id";
            this.colGoods_id.Width = 150;
            // 
            // colGoods_name
            // 
            this.colGoods_name.DataPropertyName = "goods_id";
            this.colGoods_name.HeaderText = "物料名稱";
            this.colGoods_name.Name = "colGoods_name";
            this.colGoods_name.Width = 250;
            // 
            // colBill_date
            // 
            this.colBill_date.DataPropertyName = "bill_date";
            this.colBill_date.HeaderText = "申請日期";
            this.colBill_date.Name = "colBill_date";
            // 
            // colOrder_qty
            // 
            this.colOrder_qty.DataPropertyName = "order_qty";
            this.colOrder_qty.HeaderText = "訂單數量";
            this.colOrder_qty.Name = "colOrder_qty";
            // 
            // colProd_qty
            // 
            this.colProd_qty.DataPropertyName = "prod_qty";
            this.colProd_qty.HeaderText = "生產數量";
            this.colProd_qty.Name = "colProd_qty";
            // 
            // colDept_id
            // 
            this.colDept_id.DataPropertyName = "wp_id";
            this.colDept_id.HeaderText = "部門編號";
            this.colDept_id.Name = "colDept_id";
            // 
            // colDept_name
            // 
            this.colDept_name.HeaderText = "部門名稱";
            this.colDept_name.Name = "colDept_name";
            // 
            // colVendor_id
            // 
            this.colVendor_id.DataPropertyName = "vendor_id";
            this.colVendor_id.HeaderText = "供應商";
            this.colVendor_id.Name = "colVendor_id";
            // 
            // frmOutgoingRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(784, 537);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmOutgoingRequisition";
            this.Text = "外發申請單查詢";
            this.Load += new System.EventHandler(this.frmOutgoingRequisition_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetials)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtDate2;
        private System.Windows.Forms.MaskedTextBox txtDate1;
        private System.Windows.Forms.RadioButton rdbRequest;
        private System.Windows.Forms.RadioButton rdbNotRequest;
        private System.Windows.Forms.DataGridView dgvDetials;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBill_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrder_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProd_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDept_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDept_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendor_id;
    }
}