namespace cf01.ReportForm
{
    partial class frmTommy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTommy));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnImport = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.lblInformation = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.it_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trim_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.season_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artwork = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.english_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cf_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cf_color_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_goods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_color_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_usd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_mo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(47, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(379, 17);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 17;
            this.progressBar1.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.Control;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(500, 13);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(114, 37);
            this.btnImport.TabIndex = 16;
            this.btnImport.Text = "Excel 資料導入";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
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
            this.it_customer,
            this.trim_code,
            this.season_name,
            this.brand_id,
            this.mo_id,
            this.goods_id,
            this.artwork,
            this.english_name,
            this.size_id,
            this.size_name,
            this.cf_color,
            this.cf_color_name,
            this.customer_goods,
            this.customer_color_id,
            this.customer_size,
            this.total_usd,
            this.mo_type,
            this.total_mo});
            this.dgvDetails.Location = new System.Drawing.Point(2, 66);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(916, 518);
            this.dgvDetails.TabIndex = 18;
            this.dgvDetails.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetails_RowPostPaint);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(662, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 37);
            this.button1.TabIndex = 20;
            this.button1.Text = "匯出EXCEL";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblInformation
            // 
            this.lblInformation.Location = new System.Drawing.Point(47, 30);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(378, 21);
            this.lblInformation.TabIndex = 19;
            this.lblInformation.Text = "Excel表頭格式：trim_code , artwork , season , brand 共四個欄位";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "it_customer";
            this.dataGridViewTextBoxColumn1.HeaderText = "客戶編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "trim_code";
            this.dataGridViewTextBoxColumn2.HeaderText = "Trim Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "season_name";
            this.dataGridViewTextBoxColumn3.HeaderText = "季度";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "brand_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "牌子編號";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn5.HeaderText = "產品編號";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "artwork";
            this.dataGridViewTextBoxColumn6.HeaderText = "圖樣";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "english_name";
            this.dataGridViewTextBoxColumn7.HeaderText = "產品描述";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "size_id";
            this.dataGridViewTextBoxColumn8.HeaderText = "尺寸";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 50;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "size_name";
            this.dataGridViewTextBoxColumn9.HeaderText = "尺寸描述";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "cf_color";
            this.dataGridViewTextBoxColumn10.HeaderText = "CF顏色編號";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "cf_color_name";
            this.dataGridViewTextBoxColumn11.HeaderText = "CF顏色描述";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "customer_goods";
            this.dataGridViewTextBoxColumn12.HeaderText = "客產品編號";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "customer_color_id";
            this.dataGridViewTextBoxColumn13.HeaderText = "客顏色編號";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "customer_size";
            this.dataGridViewTextBoxColumn14.HeaderText = "客人尺寸";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "total_usd";
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn15.HeaderText = "金額(USD)";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "mo_type";
            this.dataGridViewTextBoxColumn16.HeaderText = "頁數類型";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "total_mo";
            this.dataGridViewTextBoxColumn17.HeaderText = "張數";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // it_customer
            // 
            this.it_customer.DataPropertyName = "it_customer";
            this.it_customer.HeaderText = "客戶編號";
            this.it_customer.Name = "it_customer";
            this.it_customer.ReadOnly = true;
            this.it_customer.Width = 80;
            // 
            // trim_code
            // 
            this.trim_code.DataPropertyName = "trim_code";
            this.trim_code.HeaderText = "Trim Code";
            this.trim_code.Name = "trim_code";
            this.trim_code.ReadOnly = true;
            // 
            // season_name
            // 
            this.season_name.DataPropertyName = "season_name";
            this.season_name.HeaderText = "季度";
            this.season_name.Name = "season_name";
            this.season_name.ReadOnly = true;
            this.season_name.Width = 40;
            // 
            // brand_id
            // 
            this.brand_id.DataPropertyName = "brand_id";
            this.brand_id.HeaderText = "牌子編號";
            this.brand_id.Name = "brand_id";
            this.brand_id.ReadOnly = true;
            this.brand_id.Width = 80;
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            this.mo_id.HeaderText = "頁數";
            this.mo_id.Name = "mo_id";
            this.mo_id.ReadOnly = true;
            this.mo_id.Width = 80;
            // 
            // goods_id
            // 
            this.goods_id.DataPropertyName = "goods_id";
            this.goods_id.HeaderText = "產品編號";
            this.goods_id.Name = "goods_id";
            this.goods_id.ReadOnly = true;
            this.goods_id.Width = 120;
            // 
            // artwork
            // 
            this.artwork.DataPropertyName = "artwork";
            this.artwork.HeaderText = "圖樣";
            this.artwork.Name = "artwork";
            this.artwork.ReadOnly = true;
            this.artwork.Width = 80;
            // 
            // english_name
            // 
            this.english_name.DataPropertyName = "english_name";
            this.english_name.HeaderText = "產品描述";
            this.english_name.Name = "english_name";
            this.english_name.ReadOnly = true;
            this.english_name.Width = 150;
            // 
            // size_id
            // 
            this.size_id.DataPropertyName = "size_id";
            this.size_id.HeaderText = "尺寸";
            this.size_id.Name = "size_id";
            this.size_id.ReadOnly = true;
            this.size_id.Width = 50;
            // 
            // size_name
            // 
            this.size_name.DataPropertyName = "size_name";
            this.size_name.HeaderText = "尺寸描述";
            this.size_name.Name = "size_name";
            this.size_name.ReadOnly = true;
            // 
            // cf_color
            // 
            this.cf_color.DataPropertyName = "cf_color";
            this.cf_color.HeaderText = "CF顏色編號";
            this.cf_color.Name = "cf_color";
            this.cf_color.ReadOnly = true;
            // 
            // cf_color_name
            // 
            this.cf_color_name.DataPropertyName = "cf_color_name";
            this.cf_color_name.HeaderText = "CF顏色描述";
            this.cf_color_name.Name = "cf_color_name";
            this.cf_color_name.ReadOnly = true;
            // 
            // customer_goods
            // 
            this.customer_goods.DataPropertyName = "customer_goods";
            this.customer_goods.HeaderText = "客產品編號";
            this.customer_goods.Name = "customer_goods";
            this.customer_goods.ReadOnly = true;
            // 
            // customer_color_id
            // 
            this.customer_color_id.DataPropertyName = "customer_color_id";
            this.customer_color_id.HeaderText = "客顏色編號";
            this.customer_color_id.Name = "customer_color_id";
            this.customer_color_id.ReadOnly = true;
            // 
            // customer_size
            // 
            this.customer_size.DataPropertyName = "customer_size";
            this.customer_size.HeaderText = "客人尺寸";
            this.customer_size.Name = "customer_size";
            this.customer_size.ReadOnly = true;
            // 
            // total_usd
            // 
            this.total_usd.DataPropertyName = "total_usd";
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.total_usd.DefaultCellStyle = dataGridViewCellStyle1;
            this.total_usd.HeaderText = "金額(USD)";
            this.total_usd.Name = "total_usd";
            this.total_usd.ReadOnly = true;
            // 
            // mo_type
            // 
            this.mo_type.DataPropertyName = "mo_type";
            this.mo_type.HeaderText = "頁數類型";
            this.mo_type.Name = "mo_type";
            this.mo_type.ReadOnly = true;
            // 
            // total_mo
            // 
            this.total_mo.DataPropertyName = "total_mo";
            this.total_mo.HeaderText = "張數";
            this.total_mo.Name = "total_mo";
            this.total_mo.ReadOnly = true;
            // 
            // frmTommy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 588);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnImport);
            this.Name = "frmTommy";
            this.Text = "Tommy OC Data Export ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn it_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn trim_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn season_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn artwork;
        private System.Windows.Forms.DataGridViewTextBoxColumn english_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn size_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn size_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cf_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn cf_color_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_goods;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_color_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_size;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_usd;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_mo;
    }
}