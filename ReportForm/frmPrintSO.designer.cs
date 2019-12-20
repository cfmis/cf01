namespace cf01.ReportForm
{
    partial class frmPrintSO
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
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoodsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTatolQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoodsUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTatolAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRowCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBrandId = new System.Windows.Forms.Label();
            this.txtBrandId = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(251, 22);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 22);
            this.dtpStartDate.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(463, 22);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 22);
            this.dtpEndDate.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(463, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查詢";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomer,
            this.colGoodsId,
            this.colTatolQty,
            this.colGoodsUnit,
            this.colUnitPrice,
            this.colpUnit,
            this.colTatolAmount,
            this.colRowCount});
            this.dataGridView1.Location = new System.Drawing.Point(9, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(604, 223);
            this.dataGridView1.TabIndex = 3;
            // 
            // colCustomer
            // 
            this.colCustomer.DataPropertyName = "it_customer";
            this.colCustomer.HeaderText = "客戶編號";
            this.colCustomer.Name = "colCustomer";
            // 
            // colGoodsId
            // 
            this.colGoodsId.DataPropertyName = "bom_goods_id";
            this.colGoodsId.HeaderText = "貨品編號";
            this.colGoodsId.Name = "colGoodsId";
            // 
            // colTatolQty
            // 
            this.colTatolQty.DataPropertyName = "total_order_qty";
            this.colTatolQty.HeaderText = "訂單總數";
            this.colTatolQty.Name = "colTatolQty";
            // 
            // colGoodsUnit
            // 
            this.colGoodsUnit.DataPropertyName = "goods_unit";
            this.colGoodsUnit.HeaderText = "單位";
            this.colGoodsUnit.Name = "colGoodsUnit";
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "unit_price";
            this.colUnitPrice.HeaderText = "單價";
            this.colUnitPrice.Name = "colUnitPrice";
            // 
            // colpUnit
            // 
            this.colpUnit.DataPropertyName = "p_unit";
            this.colpUnit.HeaderText = "單價單位";
            this.colpUnit.Name = "colpUnit";
            // 
            // colTatolAmount
            // 
            this.colTatolAmount.DataPropertyName = "total_amount";
            this.colTatolAmount.HeaderText = "總金額（HK）";
            this.colTatolAmount.Name = "colTatolAmount";
            // 
            // colRowCount
            // 
            this.colRowCount.DataPropertyName = "row_count";
            this.colRowCount.HeaderText = "條數";
            this.colRowCount.Name = "colRowCount";
            // 
            // lblBrandId
            // 
            this.lblBrandId.AutoSize = true;
            this.lblBrandId.Location = new System.Drawing.Point(9, 27);
            this.lblBrandId.Name = "lblBrandId";
            this.lblBrandId.Size = new System.Drawing.Size(65, 12);
            this.lblBrandId.TabIndex = 4;
            this.lblBrandId.Text = "牌子編號：";
            // 
            // txtBrandId
            // 
            this.txtBrandId.Location = new System.Drawing.Point(69, 22);
            this.txtBrandId.Name = "txtBrandId";
            this.txtBrandId.Size = new System.Drawing.Size(100, 22);
            this.txtBrandId.TabIndex = 5;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(185, 27);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(65, 12);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "訂單日期：";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(425, 27);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(17, 12);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "至";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(544, 60);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmPrintSO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 348);
            this.Controls.Add(this.txtBrandId);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblBrandId);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Name = "frmPrintSO";
            this.Text = "frmPrintSO";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblBrandId;
        private System.Windows.Forms.TextBox txtBrandId;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoodsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTatolQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoodsUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTatolAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowCount;
    }
}