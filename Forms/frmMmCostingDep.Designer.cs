namespace cf01.Forms
{
    partial class frmMmCostingDep
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dgvDepCharges = new System.Windows.Forms.DataGridView();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.dgvWip = new System.Windows.Forms.DataGridView();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
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
            this.colSe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWp_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWp_cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDep_chareges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDep_std_charges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProd_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty_ok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeg_ok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNext_wp_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNext_wp_cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDep_cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(896, 35);
            this.panelControl1.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(368, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "已添加的部門";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dgvDepCharges);
            this.panelControl2.Controls.Add(this.panelControl5);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 35);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(896, 184);
            this.panelControl2.TabIndex = 1;
            // 
            // dgvDepCharges
            // 
            this.dgvDepCharges.AllowUserToAddRows = false;
            this.dgvDepCharges.ColumnHeadersHeight = 25;
            this.dgvDepCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDepCharges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDep,
            this.colDep_cdesc,
            this.colDepCharges});
            this.dgvDepCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepCharges.Location = new System.Drawing.Point(89, 2);
            this.dgvDepCharges.Name = "dgvDepCharges";
            this.dgvDepCharges.RowHeadersWidth = 20;
            this.dgvDepCharges.RowTemplate.Height = 24;
            this.dgvDepCharges.Size = new System.Drawing.Size(805, 180);
            this.dgvDepCharges.TabIndex = 1;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.btnDelete);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl5.Location = new System.Drawing.Point(2, 2);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(87, 180);
            this.panelControl5.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(5, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "移除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 219);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(896, 35);
            this.panelControl3.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "生產流程";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.dgvWip);
            this.panelControl4.Controls.Add(this.panelControl6);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 254);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(896, 305);
            this.panelControl4.TabIndex = 3;
            // 
            // dgvWip
            // 
            this.dgvWip.AllowUserToAddRows = false;
            this.dgvWip.ColumnHeadersHeight = 25;
            this.dgvWip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvWip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSe,
            this.colGoods_id,
            this.colGoods_cname,
            this.colWp_id,
            this.colWp_cdesc,
            this.colDep_chareges,
            this.colDep_std_charges,
            this.colProd_qty,
            this.colQty_ok,
            this.colWeg_ok,
            this.colNext_wp_id,
            this.colNext_wp_cdesc});
            this.dgvWip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWip.Location = new System.Drawing.Point(89, 2);
            this.dgvWip.Name = "dgvWip";
            this.dgvWip.RowHeadersWidth = 20;
            this.dgvWip.RowTemplate.Height = 24;
            this.dgvWip.Size = new System.Drawing.Size(805, 301);
            this.dgvWip.TabIndex = 1;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.btnAdd);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl6.Location = new System.Drawing.Point(2, 2);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(87, 301);
            this.panelControl6.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(5, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "dep_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "部門編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "dep_cdesc";
            this.dataGridViewTextBoxColumn2.HeaderText = "部門描述";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "dep_charges";
            this.dataGridViewTextBoxColumn3.HeaderText = "加工費";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "sequence_id";
            this.dataGridViewTextBoxColumn4.FillWeight = 60F;
            this.dataGridViewTextBoxColumn4.HeaderText = "序號";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 60;
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
            this.dataGridViewTextBoxColumn6.DataPropertyName = "goods_cname";
            this.dataGridViewTextBoxColumn6.HeaderText = "物料描述";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 180;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "wp_id";
            this.dataGridViewTextBoxColumn7.HeaderText = "負責部門";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "wp_cdesc";
            this.dataGridViewTextBoxColumn8.HeaderText = "負責部門";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "price";
            this.dataGridViewTextBoxColumn9.HeaderText = "加工費";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "prod_qty";
            this.dataGridViewTextBoxColumn10.HeaderText = "生產數量";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "qty_ok";
            this.dataGridViewTextBoxColumn11.HeaderText = "完成數量";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "weg_ok";
            this.dataGridViewTextBoxColumn12.HeaderText = "完成重量";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 80;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "next_wp_id";
            this.dataGridViewTextBoxColumn13.HeaderText = "收貨部門";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "next_wp_cdesc";
            this.dataGridViewTextBoxColumn14.HeaderText = "收貨部門";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 80;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "next_wp_cdesc";
            this.dataGridViewTextBoxColumn15.HeaderText = "收貨部門";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // colSe
            // 
            this.colSe.DataPropertyName = "sequence_id";
            this.colSe.FillWeight = 60F;
            this.colSe.HeaderText = "序號";
            this.colSe.Name = "colSe";
            this.colSe.Width = 60;
            // 
            // colGoods_id
            // 
            this.colGoods_id.DataPropertyName = "goods_id";
            this.colGoods_id.HeaderText = "物料編號";
            this.colGoods_id.Name = "colGoods_id";
            this.colGoods_id.Width = 160;
            // 
            // colGoods_cname
            // 
            this.colGoods_cname.DataPropertyName = "goods_cname";
            this.colGoods_cname.HeaderText = "物料描述";
            this.colGoods_cname.Name = "colGoods_cname";
            this.colGoods_cname.Width = 180;
            // 
            // colWp_id
            // 
            this.colWp_id.DataPropertyName = "wp_id";
            this.colWp_id.HeaderText = "負責部門";
            this.colWp_id.Name = "colWp_id";
            this.colWp_id.Width = 80;
            // 
            // colWp_cdesc
            // 
            this.colWp_cdesc.DataPropertyName = "wp_cdesc";
            this.colWp_cdesc.HeaderText = "負責部門";
            this.colWp_cdesc.Name = "colWp_cdesc";
            // 
            // colDep_chareges
            // 
            this.colDep_chareges.DataPropertyName = "dep_charges";
            this.colDep_chareges.HeaderText = "加工費";
            this.colDep_chareges.Name = "colDep_chareges";
            this.colDep_chareges.Width = 80;
            // 
            // colDep_std_charges
            // 
            this.colDep_std_charges.DataPropertyName = "dep_std_charges";
            this.colDep_std_charges.HeaderText = "標準加工費";
            this.colDep_std_charges.Name = "colDep_std_charges";
            // 
            // colProd_qty
            // 
            this.colProd_qty.DataPropertyName = "prod_qty";
            this.colProd_qty.HeaderText = "生產數量";
            this.colProd_qty.Name = "colProd_qty";
            this.colProd_qty.Width = 80;
            // 
            // colQty_ok
            // 
            this.colQty_ok.DataPropertyName = "qty_ok";
            this.colQty_ok.HeaderText = "完成數量";
            this.colQty_ok.Name = "colQty_ok";
            this.colQty_ok.Width = 80;
            // 
            // colWeg_ok
            // 
            this.colWeg_ok.DataPropertyName = "weg_ok";
            this.colWeg_ok.HeaderText = "完成重量";
            this.colWeg_ok.Name = "colWeg_ok";
            this.colWeg_ok.Width = 80;
            // 
            // colNext_wp_id
            // 
            this.colNext_wp_id.DataPropertyName = "next_wp_id";
            this.colNext_wp_id.HeaderText = "收貨部門";
            this.colNext_wp_id.Name = "colNext_wp_id";
            this.colNext_wp_id.Width = 80;
            // 
            // colNext_wp_cdesc
            // 
            this.colNext_wp_cdesc.DataPropertyName = "next_wp_cdesc";
            this.colNext_wp_cdesc.HeaderText = "收貨部門";
            this.colNext_wp_cdesc.Name = "colNext_wp_cdesc";
            // 
            // colDep
            // 
            this.colDep.DataPropertyName = "dep_id";
            this.colDep.HeaderText = "部門編號";
            this.colDep.Name = "colDep";
            this.colDep.Width = 80;
            // 
            // colDep_cdesc
            // 
            this.colDep_cdesc.DataPropertyName = "dep_cdesc";
            this.colDep_cdesc.HeaderText = "部門描述";
            this.colDep_cdesc.Name = "colDep_cdesc";
            // 
            // colDepCharges
            // 
            this.colDepCharges.DataPropertyName = "dep_charges";
            this.colDepCharges.HeaderText = "加工費";
            this.colDepCharges.Name = "colDepCharges";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(198, 11);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(220, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "標準加工費:可由部門按產品類型來設定。";
            // 
            // frmMmCostingDep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 571);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmMmCostingDep";
            this.Text = "frmMmCostingDep";
            this.Load += new System.EventHandler(this.frmMmCostingDep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.DataGridView dgvDepCharges;
        private System.Windows.Forms.DataGridView dgvWip;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDep_cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepCharges;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DevExpress.XtraEditors.SimpleButton btnExit;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colSe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWp_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWp_cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDep_chareges;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDep_std_charges;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProd_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty_ok;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeg_ok;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNext_wp_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNext_wp_cdesc;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
    }
}