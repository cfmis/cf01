namespace cf01.ReportForm
{
    partial class frmShowPlateFee
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
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblVendInv = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblVend = new System.Windows.Forms.Label();
            this.mkbDate2 = new System.Windows.Forms.MaskedTextBox();
            this.mkbDate1 = new System.Windows.Forms.MaskedTextBox();
            this.lblRecDat = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
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
            this.panel1.Controls.Add(this.splitContainer1);
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
            this.splitContainer1.Panel1.Controls.Add(this.textBox4);
            this.splitContainer1.Panel1.Controls.Add(this.textBox3);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendInv);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lblVend);
            this.splitContainer1.Panel1.Controls.Add(this.mkbDate2);
            this.splitContainer1.Panel1.Controls.Add(this.mkbDate1);
            this.splitContainer1.Panel1.Controls.Add(this.lblRecDat);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(712, 541);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(225, 38);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(104, 38);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 4;
            // 
            // lblVendInv
            // 
            this.lblVendInv.AutoSize = true;
            this.lblVendInv.Location = new System.Drawing.Point(25, 48);
            this.lblVendInv.Name = "lblVendInv";
            this.lblVendInv.Size = new System.Drawing.Size(53, 12);
            this.lblVendInv.TabIndex = 4;
            this.lblVendInv.Text = "發票編號";
            // 
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(493, 13);
            this.textBox2.MaxLength = 8;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(387, 13);
            this.textBox1.MaxLength = 8;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // lblVend
            // 
            this.lblVend.AutoSize = true;
            this.lblVend.Location = new System.Drawing.Point(334, 20);
            this.lblVend.Name = "lblVend";
            this.lblVend.Size = new System.Drawing.Size(41, 12);
            this.lblVend.TabIndex = 2;
            this.lblVend.Text = "供應商";
            // 
            // mkbDate2
            // 
            this.mkbDate2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mkbDate2.Location = new System.Drawing.Point(225, 13);
            this.mkbDate2.Mask = "0000/00/00";
            this.mkbDate2.Name = "mkbDate2";
            this.mkbDate2.PromptChar = ' ';
            this.mkbDate2.Size = new System.Drawing.Size(100, 22);
            this.mkbDate2.TabIndex = 1;
            this.mkbDate2.ValidatingType = typeof(System.DateTime);
            // 
            // mkbDate1
            // 
            this.mkbDate1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mkbDate1.Location = new System.Drawing.Point(104, 13);
            this.mkbDate1.Mask = "0000/00/00";
            this.mkbDate1.Name = "mkbDate1";
            this.mkbDate1.PromptChar = ' ';
            this.mkbDate1.Size = new System.Drawing.Size(100, 22);
            this.mkbDate1.TabIndex = 0;
            this.mkbDate1.ValidatingType = typeof(System.DateTime);
            this.mkbDate1.Leave += new System.EventHandler(this.mkbDate1_Leave);
            // 
            // lblRecDat
            // 
            this.lblRecDat.AutoSize = true;
            this.lblRecDat.Location = new System.Drawing.Point(25, 20);
            this.lblRecDat.Name = "lblRecDat";
            this.lblRecDat.Size = new System.Drawing.Size(53, 12);
            this.lblRecDat.TabIndex = 0;
            this.lblRecDat.Text = "收貨日期";
            // 
            // dgvDetails
            // 
            this.dgvDetails.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(712, 427);
            this.dgvDetails.TabIndex = 0;
            // 
            // frmShowPlateFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(712, 566);
            this.Name = "frmShowPlateFee";
            this.Text = "frmShowPlateFee";
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
        private System.Windows.Forms.MaskedTextBox mkbDate1;
        private System.Windows.Forms.Label lblRecDat;
        private System.Windows.Forms.MaskedTextBox mkbDate2;
        private System.Windows.Forms.Label lblVend;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblVendInv;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView dgvDetails;
    }
}
