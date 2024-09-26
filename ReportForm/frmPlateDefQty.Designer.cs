namespace cf01.ReportForm
{
    partial class frmPlateDefQty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlateDefQty));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rbShowQty2 = new System.Windows.Forms.RadioButton();
            this.rbShowQty1 = new System.Windows.Forms.RadioButton();
            this.textRecId2 = new System.Windows.Forms.TextBox();
            this.textRecId1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecDat2 = new System.Windows.Forms.MaskedTextBox();
            this.txtRecDat1 = new System.Windows.Forms.MaskedTextBox();
            this.textId2 = new System.Windows.Forms.TextBox();
            this.textId1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDat2 = new System.Windows.Forms.MaskedTextBox();
            this.txtDat1 = new System.Windows.Forms.MaskedTextBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.textMo2 = new System.Windows.Forms.TextBox();
            this.textMo1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1035, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 22);
            this.toolStripButton1.Text = "退出(&X)";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(63, 22);
            this.toolStripButton2.Text = "查詢(&F)";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(102, 22);
            this.toolStripButton3.Text = "匯出到Excel(&E)";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.textMo2);
            this.splitContainer1.Panel1.Controls.Add(this.textMo1);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.rbShowQty2);
            this.splitContainer1.Panel1.Controls.Add(this.rbShowQty1);
            this.splitContainer1.Panel1.Controls.Add(this.textRecId2);
            this.splitContainer1.Panel1.Controls.Add(this.textRecId1);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtRecDat2);
            this.splitContainer1.Panel1.Controls.Add(this.txtRecDat1);
            this.splitContainer1.Panel1.Controls.Add(this.textId2);
            this.splitContainer1.Panel1.Controls.Add(this.textId1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtDat2);
            this.splitContainer1.Panel1.Controls.Add(this.txtDat1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1035, 725);
            this.splitContainer1.SplitterDistance = 121;
            this.splitContainer1.TabIndex = 1;
            // 
            // rbShowQty2
            // 
            this.rbShowQty2.AutoSize = true;
            this.rbShowQty2.Location = new System.Drawing.Point(187, 85);
            this.rbShowQty2.Name = "rbShowQty2";
            this.rbShowQty2.Size = new System.Drawing.Size(71, 16);
            this.rbShowQty2.TabIndex = 19;
            this.rbShowQty2.Text = "顯示全部";
            this.rbShowQty2.UseVisualStyleBackColor = true;
            // 
            // rbShowQty1
            // 
            this.rbShowQty1.AutoSize = true;
            this.rbShowQty1.Checked = true;
            this.rbShowQty1.Location = new System.Drawing.Point(81, 85);
            this.rbShowQty1.Name = "rbShowQty1";
            this.rbShowQty1.Size = new System.Drawing.Size(95, 16);
            this.rbShowQty1.TabIndex = 18;
            this.rbShowQty1.TabStop = true;
            this.rbShowQty1.Text = "只顯示短缺數";
            this.rbShowQty1.UseVisualStyleBackColor = true;
            // 
            // textRecId2
            // 
            this.textRecId2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textRecId2.Location = new System.Drawing.Point(512, 46);
            this.textRecId2.MaxLength = 12;
            this.textRecId2.Name = "textRecId2";
            this.textRecId2.Size = new System.Drawing.Size(118, 22);
            this.textRecId2.TabIndex = 9;
            // 
            // textRecId1
            // 
            this.textRecId1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textRecId1.Location = new System.Drawing.Point(381, 46);
            this.textRecId1.MaxLength = 12;
            this.textRecId1.Name = "textRecId1";
            this.textRecId1.Size = new System.Drawing.Size(118, 22);
            this.textRecId1.TabIndex = 8;
            this.textRecId1.Leave += new System.EventHandler(this.textRecId1_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "收貨單號:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "收貨日期:";
            // 
            // txtRecDat2
            // 
            this.txtRecDat2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtRecDat2.Location = new System.Drawing.Point(187, 46);
            this.txtRecDat2.Mask = "0000/00/00";
            this.txtRecDat2.Name = "txtRecDat2";
            this.txtRecDat2.PromptChar = ' ';
            this.txtRecDat2.Size = new System.Drawing.Size(100, 22);
            this.txtRecDat2.TabIndex = 7;
            this.txtRecDat2.ValidatingType = typeof(System.DateTime);
            // 
            // txtRecDat1
            // 
            this.txtRecDat1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtRecDat1.Location = new System.Drawing.Point(81, 46);
            this.txtRecDat1.Mask = "0000/00/00";
            this.txtRecDat1.Name = "txtRecDat1";
            this.txtRecDat1.PromptChar = ' ';
            this.txtRecDat1.Size = new System.Drawing.Size(100, 22);
            this.txtRecDat1.TabIndex = 6;
            this.txtRecDat1.ValidatingType = typeof(System.DateTime);
            this.txtRecDat1.Leave += new System.EventHandler(this.txtRecDat1_Leave);
            // 
            // textId2
            // 
            this.textId2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textId2.Location = new System.Drawing.Point(512, 13);
            this.textId2.MaxLength = 12;
            this.textId2.Name = "textId2";
            this.textId2.Size = new System.Drawing.Size(118, 22);
            this.textId2.TabIndex = 3;
            // 
            // textId1
            // 
            this.textId1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textId1.Location = new System.Drawing.Point(381, 13);
            this.textId1.MaxLength = 12;
            this.textId1.Name = "textId1";
            this.textId1.Size = new System.Drawing.Size(118, 22);
            this.textId1.TabIndex = 2;
            this.textId1.Leave += new System.EventHandler(this.textId1_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "發貨單號:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "發貨日期:";
            // 
            // txtDat2
            // 
            this.txtDat2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDat2.Location = new System.Drawing.Point(187, 13);
            this.txtDat2.Mask = "0000/00/00";
            this.txtDat2.Name = "txtDat2";
            this.txtDat2.PromptChar = ' ';
            this.txtDat2.Size = new System.Drawing.Size(100, 22);
            this.txtDat2.TabIndex = 1;
            this.txtDat2.ValidatingType = typeof(System.DateTime);
            // 
            // txtDat1
            // 
            this.txtDat1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDat1.Location = new System.Drawing.Point(81, 13);
            this.txtDat1.Mask = "0000/00/00";
            this.txtDat1.Name = "txtDat1";
            this.txtDat1.PromptChar = ' ';
            this.txtDat1.Size = new System.Drawing.Size(100, 22);
            this.txtDat1.TabIndex = 0;
            this.txtDat1.ValidatingType = typeof(System.DateTime);
            this.txtDat1.Leave += new System.EventHandler(this.txtDat1_Leave);
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1035, 600);
            this.dgvDetails.TabIndex = 0;
            // 
            // textMo2
            // 
            this.textMo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textMo2.Location = new System.Drawing.Point(828, 13);
            this.textMo2.MaxLength = 9;
            this.textMo2.Name = "textMo2";
            this.textMo2.Size = new System.Drawing.Size(118, 22);
            this.textMo2.TabIndex = 5;
            // 
            // textMo1
            // 
            this.textMo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textMo1.Location = new System.Drawing.Point(697, 13);
            this.textMo1.MaxLength = 9;
            this.textMo1.Name = "textMo1";
            this.textMo1.Size = new System.Drawing.Size(118, 22);
            this.textMo1.TabIndex = 4;
            this.textMo1.Leave += new System.EventHandler(this.textMo1_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(639, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "發貨單號:";
            // 
            // frmPlateDefQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 750);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmPlateDefQty";
            this.Text = "frmPlateDefQty";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtDat2;
        private System.Windows.Forms.MaskedTextBox txtDat1;
        private System.Windows.Forms.TextBox textId2;
        private System.Windows.Forms.TextBox textId1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textRecId2;
        private System.Windows.Forms.TextBox textRecId1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtRecDat2;
        private System.Windows.Forms.MaskedTextBox txtRecDat1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.RadioButton rbShowQty2;
        private System.Windows.Forms.RadioButton rbShowQty1;
        private System.Windows.Forms.TextBox textMo2;
        private System.Windows.Forms.TextBox textMo1;
        private System.Windows.Forms.Label label5;
    }
}