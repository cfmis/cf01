namespace cf01.ReportForm
{
    partial class frmShippingMark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShippingMark));
            this.txtMo_id = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGoods_id = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLinkman = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPictrue_name = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtcustomer_color_id = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtcustomer_goods = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtContract_cid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCustomer_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGoods_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMo_id1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkLabel = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.BTNPRINT = new System.Windows.Forms.ToolStripButton();
            this.btnView = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMo_id
            // 
            this.txtMo_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMo_id.Location = new System.Drawing.Point(81, 21);
            this.txtMo_id.MaxLength = 9;
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.Size = new System.Drawing.Size(141, 25);
            this.txtMo_id.TabIndex = 0;
            this.txtMo_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_id_KeyPress);
            this.txtMo_id.Leave += new System.EventHandler(this.txtMo_id_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbGoods_id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMo_id);
            this.groupBox1.Location = new System.Drawing.Point(4, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 51);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查詢條件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "貨品編碼";
            // 
            // cmbGoods_id
            // 
            this.cmbGoods_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGoods_id.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbGoods_id.FormattingEnabled = true;
            this.cmbGoods_id.Location = new System.Drawing.Point(305, 21);
            this.cmbGoods_id.Name = "cmbGoods_id";
            this.cmbGoods_id.Size = new System.Drawing.Size(243, 23);
            this.cmbGoods_id.TabIndex = 2;
            this.cmbGoods_id.SelectedIndexChanged += new System.EventHandler(this.cmbGoods_id_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "頁數";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNFIND,
            this.toolStripSeparator3,
            this.BTNPRINT,
            this.toolStripSeparator6,
            this.btnView});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(708, 38);
            this.toolStrip1.TabIndex = 153;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtLinkman);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtPictrue_name);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtcustomer_color_id);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtcustomer_goods);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtContract_cid);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtCustomer_name);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtColor);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtGoods_name);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtMo_id1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(4, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 406);
            this.panel1.TabIndex = 154;
            // 
            // txtLinkman
            // 
            this.txtLinkman.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLinkman.Location = new System.Drawing.Point(111, 152);
            this.txtLinkman.Name = "txtLinkman";
            this.txtLinkman.ReadOnly = true;
            this.txtLinkman.Size = new System.Drawing.Size(374, 22);
            this.txtLinkman.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(19, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "聯  系  人";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPictrue_name
            // 
            this.txtPictrue_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPictrue_name.Location = new System.Drawing.Point(111, 272);
            this.txtPictrue_name.Name = "txtPictrue_name";
            this.txtPictrue_name.ReadOnly = true;
            this.txtPictrue_name.Size = new System.Drawing.Size(374, 22);
            this.txtPictrue_name.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(19, 276);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "圖樣路徑";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Location = new System.Drawing.Point(111, 248);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(374, 22);
            this.txtRemark.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(19, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "備      註";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtcustomer_color_id
            // 
            this.txtcustomer_color_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcustomer_color_id.Location = new System.Drawing.Point(111, 224);
            this.txtcustomer_color_id.Name = "txtcustomer_color_id";
            this.txtcustomer_color_id.ReadOnly = true;
            this.txtcustomer_color_id.Size = new System.Drawing.Size(374, 22);
            this.txtcustomer_color_id.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(19, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "客戶顏色";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtcustomer_goods
            // 
            this.txtcustomer_goods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcustomer_goods.Location = new System.Drawing.Point(111, 200);
            this.txtcustomer_goods.Name = "txtcustomer_goods";
            this.txtcustomer_goods.ReadOnly = true;
            this.txtcustomer_goods.Size = new System.Drawing.Size(374, 22);
            this.txtcustomer_goods.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(19, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "客戶產品編號";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContract_cid
            // 
            this.txtContract_cid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContract_cid.Location = new System.Drawing.Point(111, 176);
            this.txtContract_cid.Name = "txtContract_cid";
            this.txtContract_cid.ReadOnly = true;
            this.txtContract_cid.Size = new System.Drawing.Size(374, 22);
            this.txtContract_cid.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(19, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "客戶訂單號";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomer_name
            // 
            this.txtCustomer_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomer_name.Location = new System.Drawing.Point(111, 128);
            this.txtCustomer_name.Name = "txtCustomer_name";
            this.txtCustomer_name.ReadOnly = true;
            this.txtCustomer_name.Size = new System.Drawing.Size(374, 22);
            this.txtCustomer_name.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(19, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "客     戶";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtColor
            // 
            this.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColor.Location = new System.Drawing.Point(111, 104);
            this.txtColor.Name = "txtColor";
            this.txtColor.ReadOnly = true;
            this.txtColor.Size = new System.Drawing.Size(374, 22);
            this.txtColor.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "顏     色";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGoods_name
            // 
            this.txtGoods_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGoods_name.Location = new System.Drawing.Point(111, 80);
            this.txtGoods_name.Name = "txtGoods_name";
            this.txtGoods_name.ReadOnly = true;
            this.txtGoods_name.Size = new System.Drawing.Size(374, 22);
            this.txtGoods_name.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "產品描述";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMo_id1
            // 
            this.txtMo_id1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMo_id1.Location = new System.Drawing.Point(111, 56);
            this.txtMo_id1.Name = "txtMo_id1";
            this.txtMo_id1.ReadOnly = true;
            this.txtMo_id1.Size = new System.Drawing.Size(136, 22);
            this.txtMo_id1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "制單編號";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(240, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "船頭版";
            // 
            // chkLabel
            // 
            this.chkLabel.AutoSize = true;
            this.chkLabel.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkLabel.Location = new System.Drawing.Point(572, 24);
            this.chkLabel.Name = "chkLabel";
            this.chkLabel.Size = new System.Drawing.Size(123, 20);
            this.chkLabel.TabIndex = 4;
            this.chkLabel.Text = "標簽貼紙格式";
            this.chkLabel.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(490, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
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
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(49, 35);
            this.BTNFIND.Text = "查找(&F)";
            this.BTNFIND.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // BTNPRINT
            // 
            this.BTNPRINT.Image = ((System.Drawing.Image)(resources.GetObject("BTNPRINT.Image")));
            this.BTNPRINT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNPRINT.Name = "BTNPRINT";
            this.BTNPRINT.Size = new System.Drawing.Size(53, 35);
            this.BTNPRINT.Text = "列 印(&P)";
            this.BTNPRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNPRINT.Click += new System.EventHandler(this.BTNPRINT_Click);
            // 
            // btnView
            // 
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(51, 35);
            this.btnView.Text = "預覽(&V)";
            this.btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmShippingMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 517);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmShippingMark";
            this.Text = "frmShippingMark";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmShippingMark_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMo_id;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGoods_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BTNPRINT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtcustomer_color_id;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtcustomer_goods;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtContract_cid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCustomer_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGoods_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMo_id1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPictrue_name;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLinkman;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripButton btnView;
        private System.Windows.Forms.CheckBox chkLabel;
    }
}