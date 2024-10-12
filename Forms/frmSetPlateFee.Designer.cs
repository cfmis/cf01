namespace cf01.Forms
{
    partial class frmSetPlateFee
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.cmbGoods_unit = new System.Windows.Forms.ComboBox();
            this.txtMt_fee = new System.Windows.Forms.TextBox();
            this.mkValidDate = new System.Windows.Forms.MaskedTextBox();
            this.txtShowgoods_name = new System.Windows.Forms.TextBox();
            this.txtShowgoods_id = new System.Windows.Forms.TextBox();
            this.cmbShowSetting = new System.Windows.Forms.ComboBox();
            this.cmbOperator3 = new System.Windows.Forms.ComboBox();
            this.cmbOperator2 = new System.Windows.Forms.ComboBox();
            this.cmbOperator1 = new System.Windows.Forms.ComboBox();
            this.txtqGoods_Ename = new System.Windows.Forms.TextBox();
            this.txtqGoods_name = new System.Windows.Forms.TextBox();
            this.txtqGoods_id = new System.Windows.Forms.TextBox();
            this.lblShowSetting = new System.Windows.Forms.Label();
            this.lblMtDesc = new System.Windows.Forms.Label();
            this.lblMtCdesc = new System.Windows.Forms.Label();
            this.lblMtItem = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Size = new System.Drawing.Size(1094, 713);
            this.panel1.Controls.SetChildIndex(this.splitContainer1, 0);
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
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.textBox7);
            this.splitContainer1.Panel1.Controls.Add(this.textBox6);
            this.splitContainer1.Panel1.Controls.Add(this.textBox5);
            this.splitContainer1.Panel1.Controls.Add(this.textBox4);
            this.splitContainer1.Panel1.Controls.Add(this.textBox3);
            this.splitContainer1.Panel1.Controls.Add(this.cmbCurrency);
            this.splitContainer1.Panel1.Controls.Add(this.cmbGoods_unit);
            this.splitContainer1.Panel1.Controls.Add(this.txtMt_fee);
            this.splitContainer1.Panel1.Controls.Add(this.mkValidDate);
            this.splitContainer1.Panel1.Controls.Add(this.txtShowgoods_name);
            this.splitContainer1.Panel1.Controls.Add(this.txtShowgoods_id);
            this.splitContainer1.Panel1.Controls.Add(this.cmbShowSetting);
            this.splitContainer1.Panel1.Controls.Add(this.cmbOperator3);
            this.splitContainer1.Panel1.Controls.Add(this.cmbOperator2);
            this.splitContainer1.Panel1.Controls.Add(this.cmbOperator1);
            this.splitContainer1.Panel1.Controls.Add(this.txtqGoods_Ename);
            this.splitContainer1.Panel1.Controls.Add(this.txtqGoods_name);
            this.splitContainer1.Panel1.Controls.Add(this.txtqGoods_id);
            this.splitContainer1.Panel1.Controls.Add(this.lblShowSetting);
            this.splitContainer1.Panel1.Controls.Add(this.lblMtDesc);
            this.splitContainer1.Panel1.Controls.Add(this.lblMtCdesc);
            this.splitContainer1.Panel1.Controls.Add(this.lblMtItem);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1090, 684);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 1;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(639, 105);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(64, 20);
            this.cmbCurrency.TabIndex = 10;
            this.cmbCurrency.SelectedValueChanged += new System.EventHandler(this.cmbCurrency_SelectedValueChanged);
            // 
            // cmbGoods_unit
            // 
            this.cmbGoods_unit.FormattingEnabled = true;
            this.cmbGoods_unit.Location = new System.Drawing.Point(570, 105);
            this.cmbGoods_unit.Name = "cmbGoods_unit";
            this.cmbGoods_unit.Size = new System.Drawing.Size(61, 20);
            this.cmbGoods_unit.TabIndex = 9;
            this.cmbGoods_unit.SelectedValueChanged += new System.EventHandler(this.cmbGoods_unit_SelectedValueChanged);
            // 
            // txtMt_fee
            // 
            this.txtMt_fee.Location = new System.Drawing.Point(482, 104);
            this.txtMt_fee.Name = "txtMt_fee";
            this.txtMt_fee.Size = new System.Drawing.Size(75, 22);
            this.txtMt_fee.TabIndex = 8;
            this.txtMt_fee.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // mkValidDate
            // 
            this.mkValidDate.Location = new System.Drawing.Point(408, 104);
            this.mkValidDate.Mask = "0000/00/00";
            this.mkValidDate.Name = "mkValidDate";
            this.mkValidDate.PromptChar = ' ';
            this.mkValidDate.Size = new System.Drawing.Size(68, 22);
            this.mkValidDate.TabIndex = 7;
            this.mkValidDate.ValidatingType = typeof(System.DateTime);
            this.mkValidDate.TextChanged += new System.EventHandler(this.mkValidDate_TextChanged);
            // 
            // txtShowgoods_name
            // 
            this.txtShowgoods_name.Location = new System.Drawing.Point(192, 101);
            this.txtShowgoods_name.Name = "txtShowgoods_name";
            this.txtShowgoods_name.Size = new System.Drawing.Size(187, 22);
            this.txtShowgoods_name.TabIndex = 6;
            // 
            // txtShowgoods_id
            // 
            this.txtShowgoods_id.Location = new System.Drawing.Point(34, 101);
            this.txtShowgoods_id.Name = "txtShowgoods_id";
            this.txtShowgoods_id.Size = new System.Drawing.Size(152, 22);
            this.txtShowgoods_id.TabIndex = 6;
            // 
            // cmbShowSetting
            // 
            this.cmbShowSetting.FormattingEnabled = true;
            this.cmbShowSetting.Location = new System.Drawing.Point(123, 75);
            this.cmbShowSetting.Name = "cmbShowSetting";
            this.cmbShowSetting.Size = new System.Drawing.Size(120, 20);
            this.cmbShowSetting.TabIndex = 4;
            // 
            // cmbOperator3
            // 
            this.cmbOperator3.FormattingEnabled = true;
            this.cmbOperator3.Location = new System.Drawing.Point(123, 48);
            this.cmbOperator3.Name = "cmbOperator3";
            this.cmbOperator3.Size = new System.Drawing.Size(61, 20);
            this.cmbOperator3.TabIndex = 4;
            // 
            // cmbOperator2
            // 
            this.cmbOperator2.FormattingEnabled = true;
            this.cmbOperator2.Location = new System.Drawing.Point(426, 18);
            this.cmbOperator2.Name = "cmbOperator2";
            this.cmbOperator2.Size = new System.Drawing.Size(61, 20);
            this.cmbOperator2.TabIndex = 2;
            // 
            // cmbOperator1
            // 
            this.cmbOperator1.FormattingEnabled = true;
            this.cmbOperator1.Location = new System.Drawing.Point(91, 18);
            this.cmbOperator1.Name = "cmbOperator1";
            this.cmbOperator1.Size = new System.Drawing.Size(61, 20);
            this.cmbOperator1.TabIndex = 0;
            // 
            // txtqGoods_Ename
            // 
            this.txtqGoods_Ename.Location = new System.Drawing.Point(190, 46);
            this.txtqGoods_Ename.Name = "txtqGoods_Ename";
            this.txtqGoods_Ename.Size = new System.Drawing.Size(171, 22);
            this.txtqGoods_Ename.TabIndex = 5;
            // 
            // txtqGoods_name
            // 
            this.txtqGoods_name.Location = new System.Drawing.Point(493, 16);
            this.txtqGoods_name.Name = "txtqGoods_name";
            this.txtqGoods_name.Size = new System.Drawing.Size(171, 22);
            this.txtqGoods_name.TabIndex = 3;
            // 
            // txtqGoods_id
            // 
            this.txtqGoods_id.Location = new System.Drawing.Point(158, 16);
            this.txtqGoods_id.Name = "txtqGoods_id";
            this.txtqGoods_id.Size = new System.Drawing.Size(171, 22);
            this.txtqGoods_id.TabIndex = 1;
            // 
            // lblShowSetting
            // 
            this.lblShowSetting.AutoSize = true;
            this.lblShowSetting.Location = new System.Drawing.Point(32, 78);
            this.lblShowSetting.Name = "lblShowSetting";
            this.lblShowSetting.Size = new System.Drawing.Size(53, 12);
            this.lblShowSetting.TabIndex = 0;
            this.lblShowSetting.Text = "顯示設定";
            // 
            // lblMtDesc
            // 
            this.lblMtDesc.AutoSize = true;
            this.lblMtDesc.Location = new System.Drawing.Point(32, 51);
            this.lblMtDesc.Name = "lblMtDesc";
            this.lblMtDesc.Size = new System.Drawing.Size(77, 12);
            this.lblMtDesc.TabIndex = 0;
            this.lblMtDesc.Text = "物料英文描述";
            // 
            // lblMtCdesc
            // 
            this.lblMtCdesc.AutoSize = true;
            this.lblMtCdesc.Location = new System.Drawing.Point(335, 21);
            this.lblMtCdesc.Name = "lblMtCdesc";
            this.lblMtCdesc.Size = new System.Drawing.Size(77, 12);
            this.lblMtCdesc.TabIndex = 0;
            this.lblMtCdesc.Text = "物料中文描述";
            // 
            // lblMtItem
            // 
            this.lblMtItem.AutoSize = true;
            this.lblMtItem.Location = new System.Drawing.Point(32, 21);
            this.lblMtItem.Name = "lblMtItem";
            this.lblMtItem.Size = new System.Drawing.Size(53, 12);
            this.lblMtItem.TabIndex = 0;
            this.lblMtItem.Text = "物料編號";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckBox});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersWidth = 18;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1090, 505);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // colCheckBox
            // 
            this.colCheckBox.HeaderText = "";
            this.colCheckBox.Name = "colCheckBox";
            this.colCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCheckBox.Width = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(547, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "顏色代號:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "尺碼大小:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "圖樣代號:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "產品種類:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "物料種類:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(620, 136);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(39, 22);
            this.textBox7.TabIndex = 19;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(502, 136);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(39, 22);
            this.textBox6.TabIndex = 20;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(359, 136);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(64, 22);
            this.textBox5.TabIndex = 18;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(234, 136);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(39, 22);
            this.textBox4.TabIndex = 16;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(102, 136);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(39, 22);
            this.textBox3.TabIndex = 17;
            // 
            // frmSetPlateFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1094, 713);
            this.Name = "frmSetPlateFee";
            this.Text = "frmSetPlateFee";
            this.Load += new System.EventHandler(this.frmSetPlateFee_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtqGoods_id;
        private System.Windows.Forms.Label lblMtItem;
        private System.Windows.Forms.ComboBox cmbOperator1;
        private System.Windows.Forms.ComboBox cmbOperator2;
        private System.Windows.Forms.TextBox txtqGoods_name;
        private System.Windows.Forms.Label lblMtCdesc;
        private System.Windows.Forms.ComboBox cmbOperator3;
        private System.Windows.Forms.TextBox txtqGoods_Ename;
        private System.Windows.Forms.Label lblMtDesc;
        private System.Windows.Forms.ComboBox cmbShowSetting;
        private System.Windows.Forms.Label lblShowSetting;
		private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.TextBox txtShowgoods_id;
        private System.Windows.Forms.TextBox txtShowgoods_name;
        private System.Windows.Forms.MaskedTextBox mkValidDate;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.ComboBox cmbGoods_unit;
		private System.Windows.Forms.TextBox txtMt_fee;
		private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
    }
}
