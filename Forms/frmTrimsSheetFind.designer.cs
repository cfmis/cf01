namespace cf01.Forms
{
    partial class frmTrimsSheetFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrimsSheetFind));
            this.label1 = new System.Windows.Forms.Label();
            this.txttrim_code = new System.Windows.Forms.TextBox();
            this.dgvMoList = new System.Windows.Forms.DataGridView();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
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
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.season = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.season_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cf_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cf_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_hkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_usd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hkd_ex_fty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usd_ex_fty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lead_time_max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trim Code";
            // 
            // txttrim_code
            // 
            this.txttrim_code.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttrim_code.Location = new System.Drawing.Point(78, 21);
            this.txttrim_code.Name = "txttrim_code";
            this.txttrim_code.Size = new System.Drawing.Size(192, 26);
            this.txttrim_code.TabIndex = 1;
            // 
            // dgvMoList
            // 
            this.dgvMoList.AllowUserToAddRows = false;
            this.dgvMoList.AllowUserToDeleteRows = false;
            this.dgvMoList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMoList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.cust_code,
            this.material,
            this.brand,
            this.brand_desc,
            this.season,
            this.season_desc,
            this.cf_code,
            this.cust_color,
            this.cf_color,
            this.product_desc,
            this.size,
            this.price_hkd,
            this.price_usd,
            this.hkd_ex_fty,
            this.usd_ex_fty,
            this.price_unit,
            this.lead_time_max,
            this.sub});
            this.dgvMoList.Location = new System.Drawing.Point(3, 69);
            this.dgvMoList.Name = "dgvMoList";
            this.dgvMoList.RowHeadersWidth = 20;
            this.dgvMoList.RowTemplate.Height = 24;
            this.dgvMoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMoList.Size = new System.Drawing.Size(1013, 482);
            this.dgvMoList.TabIndex = 2;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(421, 15);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(80, 33);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "確 定  ";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::cf01.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(544, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 33);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退 出  ";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::cf01.Properties.Resources.find;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(296, 15);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(80, 33);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "查 找  ";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "頁數";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "oc_remark";
            this.dataGridViewTextBoxColumn2.HeaderText = "OC 備註";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 400;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "material";
            this.dataGridViewTextBoxColumn3.HeaderText = "Material";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "brand";
            this.dataGridViewTextBoxColumn4.HeaderText = "Brand";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "brand_desc";
            this.dataGridViewTextBoxColumn5.HeaderText = "Brand Desc.";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "season";
            this.dataGridViewTextBoxColumn6.HeaderText = "Season";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "season_desc";
            this.dataGridViewTextBoxColumn7.HeaderText = "Season Desc";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "cf_code";
            this.dataGridViewTextBoxColumn8.HeaderText = "CF Code";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "cust_color";
            this.dataGridViewTextBoxColumn9.HeaderText = "Customer Color";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "cf_color";
            this.dataGridViewTextBoxColumn10.HeaderText = "CF Color";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "product_desc";
            this.dataGridViewTextBoxColumn11.HeaderText = "Product Desc.";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Width = 120;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "size";
            this.dataGridViewTextBoxColumn12.HeaderText = "Size";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "price_hkd";
            this.dataGridViewTextBoxColumn13.HeaderText = "Price HKD(FOB)";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "price_usd";
            this.dataGridViewTextBoxColumn14.HeaderText = "Price USD(FOB)";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn14.Width = 80;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "hkd_ex_fty";
            this.dataGridViewTextBoxColumn15.HeaderText = "Price HKD (EX-FTY)";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn15.Width = 80;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "usd_ex_fty";
            this.dataGridViewTextBoxColumn16.HeaderText = "Price USD (EX-FTY)";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn16.Width = 80;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "price_unit";
            this.dataGridViewTextBoxColumn17.HeaderText = "Price Unit";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn17.Width = 60;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "lead_time_max";
            this.dataGridViewTextBoxColumn18.HeaderText = "Lead Time(Max)";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "sub";
            this.dataGridViewTextBoxColumn19.HeaderText = "Ref No.";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.date.Width = 80;
            // 
            // cust_code
            // 
            this.cust_code.DataPropertyName = "cust_code";
            this.cust_code.HeaderText = "Trim Code";
            this.cust_code.Name = "cust_code";
            this.cust_code.ReadOnly = true;
            this.cust_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // material
            // 
            this.material.DataPropertyName = "material";
            this.material.HeaderText = "Material";
            this.material.Name = "material";
            this.material.ReadOnly = true;
            this.material.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // brand
            // 
            this.brand.DataPropertyName = "brand";
            this.brand.HeaderText = "Brand";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            this.brand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.brand.Width = 80;
            // 
            // brand_desc
            // 
            this.brand_desc.DataPropertyName = "brand_desc";
            this.brand_desc.HeaderText = "Brand Desc.";
            this.brand_desc.Name = "brand_desc";
            this.brand_desc.ReadOnly = true;
            this.brand_desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // season
            // 
            this.season.DataPropertyName = "season";
            this.season.HeaderText = "Season";
            this.season.Name = "season";
            this.season.ReadOnly = true;
            this.season.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.season.Width = 60;
            // 
            // season_desc
            // 
            this.season_desc.DataPropertyName = "season_desc";
            this.season_desc.HeaderText = "Season Desc";
            this.season_desc.Name = "season_desc";
            this.season_desc.ReadOnly = true;
            this.season_desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.season_desc.Width = 80;
            // 
            // cf_code
            // 
            this.cf_code.DataPropertyName = "cf_code";
            this.cf_code.HeaderText = "CF Code";
            this.cf_code.Name = "cf_code";
            this.cf_code.ReadOnly = true;
            this.cf_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cf_code.Width = 80;
            // 
            // cust_color
            // 
            this.cust_color.DataPropertyName = "cust_color";
            this.cust_color.HeaderText = "Customer Color";
            this.cust_color.Name = "cust_color";
            this.cust_color.ReadOnly = true;
            this.cust_color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cf_color
            // 
            this.cf_color.DataPropertyName = "cf_color";
            this.cf_color.HeaderText = "CF Color";
            this.cf_color.Name = "cf_color";
            this.cf_color.ReadOnly = true;
            this.cf_color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cf_color.Width = 80;
            // 
            // product_desc
            // 
            this.product_desc.DataPropertyName = "product_desc";
            this.product_desc.HeaderText = "Product Desc.";
            this.product_desc.Name = "product_desc";
            this.product_desc.ReadOnly = true;
            this.product_desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.product_desc.Width = 120;
            // 
            // size
            // 
            this.size.DataPropertyName = "size";
            this.size.HeaderText = "Size";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // price_hkd
            // 
            this.price_hkd.DataPropertyName = "price_hkd";
            this.price_hkd.HeaderText = "Price HKD(FOB)";
            this.price_hkd.Name = "price_hkd";
            this.price_hkd.ReadOnly = true;
            this.price_hkd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.price_hkd.Width = 80;
            // 
            // price_usd
            // 
            this.price_usd.DataPropertyName = "price_usd";
            this.price_usd.HeaderText = "Price USD(FOB)";
            this.price_usd.Name = "price_usd";
            this.price_usd.ReadOnly = true;
            this.price_usd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.price_usd.Width = 80;
            // 
            // hkd_ex_fty
            // 
            this.hkd_ex_fty.DataPropertyName = "hkd_ex_fty";
            this.hkd_ex_fty.HeaderText = "Price HKD (EX-FTY)";
            this.hkd_ex_fty.Name = "hkd_ex_fty";
            this.hkd_ex_fty.ReadOnly = true;
            this.hkd_ex_fty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.hkd_ex_fty.Width = 80;
            // 
            // usd_ex_fty
            // 
            this.usd_ex_fty.DataPropertyName = "usd_ex_fty";
            this.usd_ex_fty.HeaderText = "Price USD (EX-FTY)";
            this.usd_ex_fty.Name = "usd_ex_fty";
            this.usd_ex_fty.ReadOnly = true;
            this.usd_ex_fty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.usd_ex_fty.Width = 80;
            // 
            // price_unit
            // 
            this.price_unit.DataPropertyName = "price_unit";
            this.price_unit.HeaderText = "Price Unit";
            this.price_unit.Name = "price_unit";
            this.price_unit.ReadOnly = true;
            this.price_unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.price_unit.Width = 60;
            // 
            // lead_time_max
            // 
            this.lead_time_max.DataPropertyName = "lead_time_max";
            this.lead_time_max.HeaderText = "Lead Time(Max)";
            this.lead_time_max.Name = "lead_time_max";
            this.lead_time_max.ReadOnly = true;
            this.lead_time_max.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sub
            // 
            this.sub.DataPropertyName = "sub";
            this.sub.HeaderText = "Ref No.";
            this.sub.Name = "sub";
            this.sub.ReadOnly = true;
            this.sub.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmTrimsSheetFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 554);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.dgvMoList);
            this.Controls.Add(this.txttrim_code);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTrimsSheetFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrimsSheetFind";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTrimsSheetFind_FormClosed);
            this.Load += new System.EventHandler(this.frmTrimsSheetFind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttrim_code;
        private System.Windows.Forms.DataGridView dgvMoList;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnExit;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn material;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn season;
        private System.Windows.Forms.DataGridViewTextBoxColumn season_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cf_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn cf_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_hkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_usd;
        private System.Windows.Forms.DataGridViewTextBoxColumn hkd_ex_fty;
        private System.Windows.Forms.DataGridViewTextBoxColumn usd_ex_fty;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn lead_time_max;
        private System.Windows.Forms.DataGridViewTextBoxColumn sub;
    }
}