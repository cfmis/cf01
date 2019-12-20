namespace cf01.Forms
{
    partial class frmQuotation_Price_List
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPriceList = new System.Windows.Forms.DataGridView();
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
            this.temp_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number_enter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_usd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_hkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_rmb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hkd_ex_fty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usd_ex_fty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_price_usd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_price_hkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_price_rmb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_hkd_ex_fty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rmb_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amtim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amusr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPriceList
            // 
            this.dgvPriceList.AllowUserToAddRows = false;
            this.dgvPriceList.AllowUserToDeleteRows = false;
            this.dgvPriceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPriceList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.temp_code,
            this.ver,
            this.number_enter,
            this.price_usd,
            this.price_hkd,
            this.price_rmb,
            this.hkd_ex_fty,
            this.usd_ex_fty,
            this.price_unit,
            this.discount,
            this.disc_price_usd,
            this.disc_price_hkd,
            this.disc_price_rmb,
            this.disc_hkd_ex_fty,
            this.rmb_remark,
            this.remark,
            this.amtim,
            this.amusr});
            this.dgvPriceList.Location = new System.Drawing.Point(4, 4);
            this.dgvPriceList.MultiSelect = false;
            this.dgvPriceList.Name = "dgvPriceList";
            this.dgvPriceList.ReadOnly = true;
            this.dgvPriceList.RowHeadersWidth = 15;
            this.dgvPriceList.RowTemplate.Height = 24;
            this.dgvPriceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPriceList.Size = new System.Drawing.Size(1214, 356);
            this.dgvPriceList.TabIndex = 0;
            this.dgvPriceList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPriceList_RowPostPaint);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "temp_code";
            this.dataGridViewTextBoxColumn1.HeaderText = "Temp Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ver";
            this.dataGridViewTextBoxColumn2.HeaderText = "Ver";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 30;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "number_enter";
            this.dataGridViewTextBoxColumn3.HeaderText = "BP";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "price_usd";
            this.dataGridViewTextBoxColumn4.HeaderText = "USD";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 55;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "price_hkd";
            this.dataGridViewTextBoxColumn5.HeaderText = "HKD";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 55;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "price_rmb";
            this.dataGridViewTextBoxColumn6.HeaderText = "RMB";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 55;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "hkd_ex_fty";
            this.dataGridViewTextBoxColumn7.HeaderText = "HKD Ex-Fty";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "usd_ex_fty";
            this.dataGridViewTextBoxColumn8.HeaderText = "USD Ex-Fty";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "price_unit";
            this.dataGridViewTextBoxColumn9.HeaderText = "Price Unit";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 40;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "discount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn10.HeaderText = "Discount (%)";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 50;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "disc_price_usd";
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn11.HeaderText = "Discounted USD";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 65;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "disc_price_hkd";
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn12.HeaderText = "Discounted HKD";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 65;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "disc_price_rmb";
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Blue;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn13.HeaderText = "Discounted RMB";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 65;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "disc_hkd_ex_fty";
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Blue;
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn14.HeaderText = "Discounted HKD Ex-Fty";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 75;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "rmb_remark";
            this.dataGridViewTextBoxColumn15.HeaderText = "Remark for RMB";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 110;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "remark";
            this.dataGridViewTextBoxColumn16.HeaderText = "Remark";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "amtim";
            this.dataGridViewTextBoxColumn17.HeaderText = "Update Date";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 110;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "amusr";
            this.dataGridViewTextBoxColumn18.HeaderText = "Update by";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 80;
            // 
            // temp_code
            // 
            this.temp_code.DataPropertyName = "temp_code";
            this.temp_code.HeaderText = "Temp Code";
            this.temp_code.Name = "temp_code";
            this.temp_code.ReadOnly = true;
            this.temp_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.temp_code.Width = 75;
            // 
            // ver
            // 
            this.ver.DataPropertyName = "ver";
            this.ver.HeaderText = "Ver";
            this.ver.Name = "ver";
            this.ver.ReadOnly = true;
            this.ver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ver.Width = 30;
            // 
            // number_enter
            // 
            this.number_enter.DataPropertyName = "number_enter";
            this.number_enter.HeaderText = "BP";
            this.number_enter.Name = "number_enter";
            this.number_enter.ReadOnly = true;
            this.number_enter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.number_enter.Width = 60;
            // 
            // price_usd
            // 
            this.price_usd.DataPropertyName = "price_usd";
            this.price_usd.HeaderText = "USD";
            this.price_usd.Name = "price_usd";
            this.price_usd.ReadOnly = true;
            this.price_usd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.price_usd.Width = 55;
            // 
            // price_hkd
            // 
            this.price_hkd.DataPropertyName = "price_hkd";
            this.price_hkd.HeaderText = "HKD";
            this.price_hkd.Name = "price_hkd";
            this.price_hkd.ReadOnly = true;
            this.price_hkd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.price_hkd.Width = 55;
            // 
            // price_rmb
            // 
            this.price_rmb.DataPropertyName = "price_rmb";
            this.price_rmb.HeaderText = "RMB";
            this.price_rmb.Name = "price_rmb";
            this.price_rmb.ReadOnly = true;
            this.price_rmb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.price_rmb.Width = 55;
            // 
            // hkd_ex_fty
            // 
            this.hkd_ex_fty.DataPropertyName = "hkd_ex_fty";
            this.hkd_ex_fty.HeaderText = "HKD Ex-Fty";
            this.hkd_ex_fty.Name = "hkd_ex_fty";
            this.hkd_ex_fty.ReadOnly = true;
            this.hkd_ex_fty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.hkd_ex_fty.Width = 60;
            // 
            // usd_ex_fty
            // 
            this.usd_ex_fty.DataPropertyName = "usd_ex_fty";
            this.usd_ex_fty.HeaderText = "USD Ex-Fty";
            this.usd_ex_fty.Name = "usd_ex_fty";
            this.usd_ex_fty.ReadOnly = true;
            this.usd_ex_fty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.usd_ex_fty.Width = 60;
            // 
            // price_unit
            // 
            this.price_unit.DataPropertyName = "price_unit";
            this.price_unit.HeaderText = "Price Unit";
            this.price_unit.Name = "price_unit";
            this.price_unit.ReadOnly = true;
            this.price_unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.price_unit.Width = 40;
            // 
            // discount
            // 
            this.discount.DataPropertyName = "discount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.discount.DefaultCellStyle = dataGridViewCellStyle1;
            this.discount.HeaderText = "Discount (%)";
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            this.discount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.discount.Width = 50;
            // 
            // disc_price_usd
            // 
            this.disc_price_usd.DataPropertyName = "disc_price_usd";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.disc_price_usd.DefaultCellStyle = dataGridViewCellStyle2;
            this.disc_price_usd.HeaderText = "Discounted USD";
            this.disc_price_usd.Name = "disc_price_usd";
            this.disc_price_usd.ReadOnly = true;
            this.disc_price_usd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.disc_price_usd.Width = 65;
            // 
            // disc_price_hkd
            // 
            this.disc_price_hkd.DataPropertyName = "disc_price_hkd";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            this.disc_price_hkd.DefaultCellStyle = dataGridViewCellStyle3;
            this.disc_price_hkd.HeaderText = "Discounted HKD";
            this.disc_price_hkd.Name = "disc_price_hkd";
            this.disc_price_hkd.ReadOnly = true;
            this.disc_price_hkd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.disc_price_hkd.Width = 65;
            // 
            // disc_price_rmb
            // 
            this.disc_price_rmb.DataPropertyName = "disc_price_rmb";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            this.disc_price_rmb.DefaultCellStyle = dataGridViewCellStyle4;
            this.disc_price_rmb.HeaderText = "Discounted RMB";
            this.disc_price_rmb.Name = "disc_price_rmb";
            this.disc_price_rmb.ReadOnly = true;
            this.disc_price_rmb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.disc_price_rmb.Width = 65;
            // 
            // disc_hkd_ex_fty
            // 
            this.disc_hkd_ex_fty.DataPropertyName = "disc_hkd_ex_fty";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue;
            this.disc_hkd_ex_fty.DefaultCellStyle = dataGridViewCellStyle5;
            this.disc_hkd_ex_fty.HeaderText = "Discounted HKD Ex-Fty";
            this.disc_hkd_ex_fty.Name = "disc_hkd_ex_fty";
            this.disc_hkd_ex_fty.ReadOnly = true;
            this.disc_hkd_ex_fty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.disc_hkd_ex_fty.Width = 75;
            // 
            // rmb_remark
            // 
            this.rmb_remark.DataPropertyName = "rmb_remark";
            this.rmb_remark.HeaderText = "Remark for RMB";
            this.rmb_remark.Name = "rmb_remark";
            this.rmb_remark.ReadOnly = true;
            this.rmb_remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rmb_remark.Width = 110;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "Remark";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // amtim
            // 
            this.amtim.DataPropertyName = "amtim";
            this.amtim.HeaderText = "Update Date";
            this.amtim.Name = "amtim";
            this.amtim.ReadOnly = true;
            this.amtim.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.amtim.Width = 110;
            // 
            // amusr
            // 
            this.amusr.DataPropertyName = "amusr";
            this.amusr.HeaderText = "Update by";
            this.amusr.Name = "amusr";
            this.amusr.ReadOnly = true;
            this.amusr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.amusr.Width = 80;
            // 
            // frmQuotation_Price_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 363);
            this.Controls.Add(this.dgvPriceList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuotation_Price_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Version List";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPriceList;
        private System.Windows.Forms.DataGridViewTextBoxColumn temp_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ver;
        private System.Windows.Forms.DataGridViewTextBoxColumn number_enter;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_usd;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_hkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_rmb;
        private System.Windows.Forms.DataGridViewTextBoxColumn hkd_ex_fty;
        private System.Windows.Forms.DataGridViewTextBoxColumn usd_ex_fty;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_price_usd;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_price_hkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_price_rmb;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_hkd_ex_fty;
        private System.Windows.Forms.DataGridViewTextBoxColumn rmb_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn amtim;
        private System.Windows.Forms.DataGridViewTextBoxColumn amusr;
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
    }
}