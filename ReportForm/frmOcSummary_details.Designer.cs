namespace cf01.ReportForm
{
    partial class frmOcSummary_details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOcSummary_details));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNEXCEL = new System.Windows.Forms.ToolStripButton();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.rdog1 = new DevExpress.XtraEditors.RadioGroup();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.it_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdog1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNEXCEL});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(915, 38);
            this.toolStrip1.TabIndex = 141;
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
            // BTNEXCEL
            // 
            this.BTNEXCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXCEL.Image")));
            this.BTNEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXCEL.Name = "BTNEXCEL";
            this.BTNEXCEL.Size = new System.Drawing.Size(70, 35);
            this.BTNEXCEL.Text = "匯出EXCEL";
            this.BTNEXCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNEXCEL.Click += new System.EventHandler(this.BTNEXCEL_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.create_date,
            this.it_customer,
            this.mo_id,
            this.order_qty});
            this.dgvDetails.Location = new System.Drawing.Point(5, 41);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 40;
            this.dgvDetails.RowTemplate.Height = 20;
            this.dgvDetails.Size = new System.Drawing.Size(904, 482);
            this.dgvDetails.TabIndex = 143;
            this.dgvDetails.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetails_RowPostPaint);
            // 
            // rdog1
            // 
            this.rdog1.Location = new System.Drawing.Point(450, 3);
            this.rdog1.Name = "rdog1";
            this.rdog1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.rdog1.Properties.Appearance.Options.UseBackColor = true;
            this.rdog1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rdog1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "銷售訂單未批準"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "尚未轉生產計劃")});
            this.rdog1.Size = new System.Drawing.Size(267, 29);
            this.rdog1.TabIndex = 144;
            this.rdog1.SelectedIndexChanged += new System.EventHandler(this.rdog1_SelectedIndexChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "create_date";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "日期";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "it_customer";
            this.dataGridViewTextBoxColumn2.HeaderText = "客戶編號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "頁數";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "order_qty";
            this.dataGridViewTextBoxColumn4.HeaderText = "訂單數量";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // create_date
            // 
            this.create_date.DataPropertyName = "create_date";
            this.create_date.Frozen = true;
            this.create_date.HeaderText = "日期";
            this.create_date.Name = "create_date";
            this.create_date.ReadOnly = true;
            this.create_date.Width = 80;
            // 
            // it_customer
            // 
            this.it_customer.DataPropertyName = "it_customer";
            this.it_customer.HeaderText = "客戶編號";
            this.it_customer.Name = "it_customer";
            this.it_customer.ReadOnly = true;
            this.it_customer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            this.mo_id.HeaderText = "頁數";
            this.mo_id.Name = "mo_id";
            this.mo_id.ReadOnly = true;
            this.mo_id.Width = 120;
            // 
            // order_qty
            // 
            this.order_qty.DataPropertyName = "order_qty";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.order_qty.DefaultCellStyle = dataGridViewCellStyle1;
            this.order_qty.HeaderText = "訂單數量";
            this.order_qty.Name = "order_qty";
            this.order_qty.ReadOnly = true;
            this.order_qty.Width = 120;
            // 
            // frmOcSummary_details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 530);
            this.Controls.Add(this.rdog1);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOcSummary_details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOcSummary_details";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdog1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNEXCEL;
        private System.Windows.Forms.DataGridView dgvDetails;
        private DevExpress.XtraEditors.RadioGroup rdog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn it_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_qty;
    }
}