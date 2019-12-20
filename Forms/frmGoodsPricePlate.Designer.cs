namespace cf01.Forms
{
    partial class frmGoodsPricePlate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoodsPricePlate));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVend = new System.Windows.Forms.Label();
            this.txtPrd_vend = new System.Windows.Forms.TextBox();
            this.lblPrd_item = new System.Windows.Forms.Label();
            this.txtPrd_name = new System.Windows.Forms.TextBox();
            this.txtPrd_dep = new System.Windows.Forms.TextBox();
            this.txtPrd_item = new System.Windows.Forms.TextBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDo_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSec_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSec_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice_rmk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMin_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoudle_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProd_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSec_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssue_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVend_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnWeg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnQty = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
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
            this.btnWeg,
            this.toolStripSeparator2,
            this.btnQty,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(971, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            // panel1
            // 
            this.panel1.Controls.Add(this.lblVend);
            this.panel1.Controls.Add(this.txtPrd_vend);
            this.panel1.Controls.Add(this.lblPrd_item);
            this.panel1.Controls.Add(this.txtPrd_name);
            this.panel1.Controls.Add(this.txtPrd_dep);
            this.panel1.Controls.Add(this.txtPrd_item);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 41);
            this.panel1.TabIndex = 1;
            // 
            // lblVend
            // 
            this.lblVend.AutoSize = true;
            this.lblVend.Location = new System.Drawing.Point(619, 13);
            this.lblVend.Name = "lblVend";
            this.lblVend.Size = new System.Drawing.Size(41, 12);
            this.lblVend.TabIndex = 5;
            this.lblVend.Text = "供应商";
            this.lblVend.Visible = false;
            // 
            // txtPrd_vend
            // 
            this.txtPrd_vend.Location = new System.Drawing.Point(666, 9);
            this.txtPrd_vend.Name = "txtPrd_vend";
            this.txtPrd_vend.Size = new System.Drawing.Size(100, 22);
            this.txtPrd_vend.TabIndex = 4;
            this.txtPrd_vend.Visible = false;
            // 
            // lblPrd_item
            // 
            this.lblPrd_item.AutoSize = true;
            this.lblPrd_item.Location = new System.Drawing.Point(12, 13);
            this.lblPrd_item.Name = "lblPrd_item";
            this.lblPrd_item.Size = new System.Drawing.Size(53, 12);
            this.lblPrd_item.TabIndex = 3;
            this.lblPrd_item.Text = "物料编号";
            // 
            // txtPrd_name
            // 
            this.txtPrd_name.Location = new System.Drawing.Point(283, 9);
            this.txtPrd_name.Name = "txtPrd_name";
            this.txtPrd_name.ReadOnly = true;
            this.txtPrd_name.Size = new System.Drawing.Size(304, 22);
            this.txtPrd_name.TabIndex = 2;
            // 
            // txtPrd_dep
            // 
            this.txtPrd_dep.Location = new System.Drawing.Point(839, 9);
            this.txtPrd_dep.Name = "txtPrd_dep";
            this.txtPrd_dep.Size = new System.Drawing.Size(100, 22);
            this.txtPrd_dep.TabIndex = 1;
            this.txtPrd_dep.Visible = false;
            // 
            // txtPrd_item
            // 
            this.txtPrd_item.Location = new System.Drawing.Point(72, 9);
            this.txtPrd_item.Name = "txtPrd_item";
            this.txtPrd_item.ReadOnly = true;
            this.txtPrd_item.Size = new System.Drawing.Size(192, 22);
            this.txtPrd_item.TabIndex = 0;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.ColumnHeadersHeight = 30;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colSeq,
            this.colMo_id,
            this.colDo_color,
            this.colPrice,
            this.colUnit,
            this.colSec_price,
            this.colSec_unit,
            this.colPrice_rmk,
            this.colMin_price,
            this.colMoudle_price,
            this.colProd_qty,
            this.colSec_qty,
            this.colIssue_date,
            this.colVend_id});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 79);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(971, 629);
            this.dgvDetails.TabIndex = 2;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "加工單號";
            this.colId.Name = "colId";
            // 
            // colSeq
            // 
            this.colSeq.DataPropertyName = "sequence_id";
            this.colSeq.HeaderText = "序号";
            this.colSeq.Name = "colSeq";
            this.colSeq.Width = 60;
            // 
            // colMo_id
            // 
            this.colMo_id.DataPropertyName = "mo_id";
            this.colMo_id.HeaderText = "制單編號";
            this.colMo_id.Name = "colMo_id";
            this.colMo_id.Width = 80;
            // 
            // colDo_color
            // 
            this.colDo_color.DataPropertyName = "do_color";
            this.colDo_color.HeaderText = "顏色做法";
            this.colDo_color.Name = "colDo_color";
            this.colDo_color.Width = 160;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "price";
            this.colPrice.HeaderText = "價格";
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 40;
            // 
            // colUnit
            // 
            this.colUnit.DataPropertyName = "p_unit";
            this.colUnit.HeaderText = "單價單位";
            this.colUnit.Name = "colUnit";
            this.colUnit.Width = 40;
            // 
            // colSec_price
            // 
            this.colSec_price.DataPropertyName = "sec_price";
            this.colSec_price.HeaderText = "重量价格";
            this.colSec_price.Name = "colSec_price";
            this.colSec_price.Width = 40;
            // 
            // colSec_unit
            // 
            this.colSec_unit.DataPropertyName = "sec_p_unit";
            this.colSec_unit.HeaderText = "单价单位";
            this.colSec_unit.Name = "colSec_unit";
            this.colSec_unit.Width = 40;
            // 
            // colPrice_rmk
            // 
            this.colPrice_rmk.DataPropertyName = "process_request";
            this.colPrice_rmk.HeaderText = "價格備註";
            this.colPrice_rmk.Name = "colPrice_rmk";
            this.colPrice_rmk.Width = 60;
            // 
            // colMin_price
            // 
            this.colMin_price.DataPropertyName = "mould_fee";
            this.colMin_price.HeaderText = "最低消費金額";
            this.colMin_price.Name = "colMin_price";
            this.colMin_price.Width = 60;
            // 
            // colMoudle_price
            // 
            this.colMoudle_price.DataPropertyName = "former_free";
            this.colMoudle_price.HeaderText = "版費";
            this.colMoudle_price.Name = "colMoudle_price";
            this.colMoudle_price.Width = 40;
            // 
            // colProd_qty
            // 
            this.colProd_qty.DataPropertyName = "prod_qty";
            this.colProd_qty.HeaderText = "数量";
            this.colProd_qty.Name = "colProd_qty";
            this.colProd_qty.Width = 40;
            // 
            // colSec_qty
            // 
            this.colSec_qty.DataPropertyName = "sec_qty";
            this.colSec_qty.HeaderText = "重量";
            this.colSec_qty.Name = "colSec_qty";
            this.colSec_qty.Width = 40;
            // 
            // colIssue_date
            // 
            this.colIssue_date.DataPropertyName = "issue_date";
            this.colIssue_date.HeaderText = "加工單日期";
            this.colIssue_date.Name = "colIssue_date";
            this.colIssue_date.Width = 80;
            // 
            // colVend_id
            // 
            this.colVend_id.DataPropertyName = "vendor_id";
            this.colVend_id.HeaderText = "供應商";
            this.colVend_id.Name = "colVend_id";
            this.colVend_id.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "加工單號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "sequence_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "序号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "do_color";
            this.dataGridViewTextBoxColumn4.HeaderText = "顏色做法";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 160;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "price";
            this.dataGridViewTextBoxColumn5.HeaderText = "價格";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "p_unit";
            this.dataGridViewTextBoxColumn6.HeaderText = "單價單位";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "sec_price";
            this.dataGridViewTextBoxColumn7.HeaderText = "重量价格";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "sec_p_unit";
            this.dataGridViewTextBoxColumn8.HeaderText = "单价单位";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "process_request";
            this.dataGridViewTextBoxColumn9.HeaderText = "價格備註";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 60;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "mould_fee";
            this.dataGridViewTextBoxColumn10.HeaderText = "最低消費金額";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "former_free";
            this.dataGridViewTextBoxColumn11.HeaderText = "版費";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 60;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "prod_qty";
            this.dataGridViewTextBoxColumn12.HeaderText = "数量";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 60;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "sec_qty";
            this.dataGridViewTextBoxColumn13.HeaderText = "重量";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 60;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "issue_date";
            this.dataGridViewTextBoxColumn14.HeaderText = "加工單日期";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 80;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "vendor_id";
            this.dataGridViewTextBoxColumn15.HeaderText = "供應商";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Width = 80;
            // 
            // btnWeg
            // 
            this.btnWeg.AutoSize = false;
            this.btnWeg.Image = ((System.Drawing.Image)(resources.GetObject("btnWeg.Image")));
            this.btnWeg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWeg.Name = "btnWeg";
            this.btnWeg.Size = new System.Drawing.Size(65, 35);
            this.btnWeg.Text = "取重量";
            this.btnWeg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnWeg.Click += new System.EventHandler(this.btnWeg_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnQty
            // 
            this.btnQty.AutoSize = false;
            this.btnQty.Image = ((System.Drawing.Image)(resources.GetObject("btnQty.Image")));
            this.btnQty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQty.Name = "btnQty";
            this.btnQty.Size = new System.Drawing.Size(65, 35);
            this.btnQty.Text = "取数量";
            this.btnQty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQty.Click += new System.EventHandler(this.btnQty_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // frmGoodsPricePlate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 708);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmGoodsPricePlate";
            this.Text = "frmGoodsPricePlate";
            this.Load += new System.EventHandler(this.frmGoodsPricePlate_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPrd_item;
        private System.Windows.Forms.TextBox txtPrd_dep;
        private System.Windows.Forms.TextBox txtPrd_name;
        private System.Windows.Forms.Label lblPrd_item;
        private System.Windows.Forms.Label lblVend;
        private System.Windows.Forms.TextBox txtPrd_vend;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDo_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSec_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSec_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice_rmk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMin_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoudle_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProd_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSec_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssue_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVend_id;
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
        private System.Windows.Forms.ToolStripButton btnWeg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnQty;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}