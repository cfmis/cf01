namespace cf01.ReportForm
{
    partial class frmReturnPlate_From302
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturnPlate_From302));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblDep = new System.Windows.Forms.Label();
            this.txtDep = new System.Windows.Forms.TextBox();
            this.mktDate1 = new System.Windows.Forms.MaskedTextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mktDate2 = new System.Windows.Forms.MaskedTextBox();
            this.lblMo = new System.Windows.Forms.Label();
            this.txtMo = new System.Windows.Forms.TextBox();
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
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIr_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOp_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_id_302 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_name_302 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWp_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNext_wp_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator2,
            this.btnExcel,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1236, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMo);
            this.panel1.Controls.Add(this.lblMo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.mktDate2);
            this.panel1.Controls.Add(this.mktDate1);
            this.panel1.Controls.Add(this.txtDep);
            this.panel1.Controls.Add(this.lblDep);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1236, 52);
            this.panel1.TabIndex = 1;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.ColumnHeadersHeight = 30;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colIr_date,
            this.colSeq,
            this.colMo_id,
            this.colGoods_id,
            this.colGoods_name,
            this.colOp_color,
            this.colRemark,
            this.colGoods_id_302,
            this.colGoods_name_302,
            this.colWp_id,
            this.colNext_wp_id});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 90);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1236, 647);
            this.dgvDetails.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = false;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 35);
            this.btnExit.Text = "退出(&X)";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 35);
            this.btnFind.Text = "查找(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnExcel
            // 
            this.btnExcel.AutoSize = false;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(87, 35);
            this.btnExcel.Text = "匯出到Excel";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // lblDep
            // 
            this.lblDep.AutoSize = true;
            this.lblDep.Location = new System.Drawing.Point(28, 15);
            this.lblDep.Name = "lblDep";
            this.lblDep.Size = new System.Drawing.Size(32, 12);
            this.lblDep.TabIndex = 0;
            this.lblDep.Text = "部門:";
            // 
            // txtDep
            // 
            this.txtDep.Location = new System.Drawing.Point(66, 10);
            this.txtDep.Name = "txtDep";
            this.txtDep.Size = new System.Drawing.Size(100, 22);
            this.txtDep.TabIndex = 0;
            // 
            // mktDate1
            // 
            this.mktDate1.Location = new System.Drawing.Point(442, 10);
            this.mktDate1.Mask = "0000/00/00";
            this.mktDate1.Name = "mktDate1";
            this.mktDate1.PromptChar = ' ';
            this.mktDate1.Size = new System.Drawing.Size(100, 22);
            this.mktDate1.TabIndex = 2;
            this.mktDate1.ValidatingType = typeof(System.DateTime);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(404, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(32, 12);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "日期:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(548, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "To:";
            // 
            // mktDate2
            // 
            this.mktDate2.Location = new System.Drawing.Point(575, 10);
            this.mktDate2.Mask = "0000/00/00";
            this.mktDate2.Name = "mktDate2";
            this.mktDate2.PromptChar = ' ';
            this.mktDate2.Size = new System.Drawing.Size(100, 22);
            this.mktDate2.TabIndex = 3;
            this.mktDate2.ValidatingType = typeof(System.DateTime);
            // 
            // lblMo
            // 
            this.lblMo.AutoSize = true;
            this.lblMo.Location = new System.Drawing.Point(201, 15);
            this.lblMo.Name = "lblMo";
            this.lblMo.Size = new System.Drawing.Size(56, 12);
            this.lblMo.TabIndex = 5;
            this.lblMo.Text = "制單編號:";
            // 
            // txtMo
            // 
            this.txtMo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo.Location = new System.Drawing.Point(263, 10);
            this.txtMo.MaxLength = 9;
            this.txtMo.Name = "txtMo";
            this.txtMo.Size = new System.Drawing.Size(118, 22);
            this.txtMo.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "返電單號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ir_date";
            this.dataGridViewTextBoxColumn2.HeaderText = "返電日期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "sequence_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "序號";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn5.HeaderText = "物料編號";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 160;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "goods_name";
            this.dataGridViewTextBoxColumn6.HeaderText = "物料描述";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 240;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "op_color";
            this.dataGridViewTextBoxColumn7.HeaderText = "顏色做法";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 160;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "remark";
            this.dataGridViewTextBoxColumn8.HeaderText = "備註";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 160;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "goods_id_302";
            this.dataGridViewTextBoxColumn9.HeaderText = "物料編號(302)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 160;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "goods_name_302";
            this.dataGridViewTextBoxColumn10.HeaderText = "物料描述(302)";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 240;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "wp_id";
            this.dataGridViewTextBoxColumn11.HeaderText = "負責部門";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 60;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "next_wp_id";
            this.dataGridViewTextBoxColumn12.HeaderText = "收貨部門";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 60;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "返電單號";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 120;
            // 
            // colIr_date
            // 
            this.colIr_date.DataPropertyName = "ir_date";
            this.colIr_date.HeaderText = "返電日期";
            this.colIr_date.Name = "colIr_date";
            this.colIr_date.ReadOnly = true;
            // 
            // colSeq
            // 
            this.colSeq.DataPropertyName = "sequence_id";
            this.colSeq.HeaderText = "序號";
            this.colSeq.Name = "colSeq";
            this.colSeq.ReadOnly = true;
            this.colSeq.Width = 40;
            // 
            // colMo_id
            // 
            this.colMo_id.DataPropertyName = "mo_id";
            this.colMo_id.HeaderText = "制單編號";
            this.colMo_id.Name = "colMo_id";
            this.colMo_id.ReadOnly = true;
            this.colMo_id.Width = 80;
            // 
            // colGoods_id
            // 
            this.colGoods_id.DataPropertyName = "goods_id";
            this.colGoods_id.HeaderText = "物料編號";
            this.colGoods_id.Name = "colGoods_id";
            this.colGoods_id.ReadOnly = true;
            this.colGoods_id.Width = 160;
            // 
            // colGoods_name
            // 
            this.colGoods_name.DataPropertyName = "goods_name";
            this.colGoods_name.HeaderText = "物料描述";
            this.colGoods_name.Name = "colGoods_name";
            this.colGoods_name.ReadOnly = true;
            this.colGoods_name.Width = 240;
            // 
            // colOp_color
            // 
            this.colOp_color.DataPropertyName = "op_color";
            this.colOp_color.HeaderText = "顏色做法";
            this.colOp_color.Name = "colOp_color";
            this.colOp_color.ReadOnly = true;
            this.colOp_color.Width = 160;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "remark";
            this.colRemark.HeaderText = "備註";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Width = 160;
            // 
            // colGoods_id_302
            // 
            this.colGoods_id_302.DataPropertyName = "goods_id_302";
            this.colGoods_id_302.HeaderText = "物料編號(302)";
            this.colGoods_id_302.Name = "colGoods_id_302";
            this.colGoods_id_302.ReadOnly = true;
            this.colGoods_id_302.Width = 160;
            // 
            // colGoods_name_302
            // 
            this.colGoods_name_302.DataPropertyName = "goods_name_302";
            this.colGoods_name_302.HeaderText = "物料描述(302)";
            this.colGoods_name_302.Name = "colGoods_name_302";
            this.colGoods_name_302.ReadOnly = true;
            this.colGoods_name_302.Width = 240;
            // 
            // colWp_id
            // 
            this.colWp_id.DataPropertyName = "wp_id";
            this.colWp_id.HeaderText = "負責部門";
            this.colWp_id.Name = "colWp_id";
            this.colWp_id.ReadOnly = true;
            this.colWp_id.Width = 60;
            // 
            // colNext_wp_id
            // 
            this.colNext_wp_id.DataPropertyName = "next_wp_id";
            this.colNext_wp_id.HeaderText = "收貨部門";
            this.colNext_wp_id.Name = "colNext_wp_id";
            this.colNext_wp_id.ReadOnly = true;
            this.colNext_wp_id.Width = 60;
            // 
            // frmReturnPlate_From302
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 737);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmReturnPlate_From302";
            this.Text = "frmReturnPlate_From302";
            this.Load += new System.EventHandler(this.frmReturnPlate_From302_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TextBox txtDep;
        private System.Windows.Forms.Label lblDep;
        private System.Windows.Forms.MaskedTextBox mktDate1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.MaskedTextBox mktDate2;
        private System.Windows.Forms.TextBox txtMo;
        private System.Windows.Forms.Label lblMo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIr_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOp_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_id_302;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_name_302;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWp_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNext_wp_id;
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
    }
}