namespace cf01.Forms
{
    partial class frmTestCustProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestCustProduct));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCustProd_id_sq = new System.Windows.Forms.TextBox();
            this.txtCustProd_cdesc_sq = new System.Windows.Forms.TextBox();
            this.lblCp_cdesc_sq = new System.Windows.Forms.Label();
            this.lblCustProd_id_sq = new System.Windows.Forms.Label();
            this.lblCp_edsec = new System.Windows.Forms.Label();
            this.lblCp_cdesc = new System.Windows.Forms.Label();
            this.lblCustProd_id = new System.Windows.Forms.Label();
            this.txtCustProd_edesc = new System.Windows.Forms.TextBox();
            this.txtCustProd_cdesc = new System.Windows.Forms.TextBox();
            this.txtCustProd_id = new System.Windows.Forms.TextBox();
            this.dgvCustProduct = new System.Windows.Forms.DataGridView();
            this.colCustProd_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustProd_cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustProd_edesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCruser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCrtim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmuser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmtim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.btnNew,
            this.btnEdit,
            this.btnSave,
            this.btnDelete,
            this.btnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(623, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(52, 22);
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(52, 22);
            this.btnNew.Text = "新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(52, 22);
            this.btnEdit.Text = "編輯";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 22);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(52, 22);
            this.btnDelete.Text = "刪除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 22);
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.lblCp_edsec);
            this.splitContainer1.Panel1.Controls.Add(this.lblCp_cdesc);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustProd_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustProd_edesc);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustProd_cdesc);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustProd_id);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCustProduct);
            this.splitContainer1.Size = new System.Drawing.Size(623, 513);
            this.splitContainer1.SplitterDistance = 161;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtCustProd_id_sq);
            this.panel1.Controls.Add(this.txtCustProd_cdesc_sq);
            this.panel1.Controls.Add(this.lblCp_cdesc_sq);
            this.panel1.Controls.Add(this.lblCustProd_id_sq);
            this.panel1.Location = new System.Drawing.Point(1, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 54);
            this.panel1.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSearch.Location = new System.Drawing.Point(417, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCustProd_id_sq
            // 
            this.txtCustProd_id_sq.Location = new System.Drawing.Point(94, 23);
            this.txtCustProd_id_sq.Name = "txtCustProd_id_sq";
            this.txtCustProd_id_sq.Size = new System.Drawing.Size(89, 22);
            this.txtCustProd_id_sq.TabIndex = 4;
            // 
            // txtCustProd_cdesc_sq
            // 
            this.txtCustProd_cdesc_sq.Location = new System.Drawing.Point(265, 23);
            this.txtCustProd_cdesc_sq.Name = "txtCustProd_cdesc_sq";
            this.txtCustProd_cdesc_sq.Size = new System.Drawing.Size(122, 22);
            this.txtCustProd_cdesc_sq.TabIndex = 5;
            // 
            // lblCp_cdesc_sq
            // 
            this.lblCp_cdesc_sq.AutoSize = true;
            this.lblCp_cdesc_sq.Location = new System.Drawing.Point(205, 26);
            this.lblCp_cdesc_sq.Name = "lblCp_cdesc_sq";
            this.lblCp_cdesc_sq.Size = new System.Drawing.Size(53, 12);
            this.lblCp_cdesc_sq.TabIndex = 1;
            this.lblCp_cdesc_sq.Text = "中文描述";
            // 
            // lblCustProd_id_sq
            // 
            this.lblCustProd_id_sq.AutoSize = true;
            this.lblCustProd_id_sq.Location = new System.Drawing.Point(11, 26);
            this.lblCustProd_id_sq.Name = "lblCustProd_id_sq";
            this.lblCustProd_id_sq.Size = new System.Drawing.Size(77, 12);
            this.lblCustProd_id_sq.TabIndex = 1;
            this.lblCustProd_id_sq.Text = "客戶產品編號";
            // 
            // lblCp_edsec
            // 
            this.lblCp_edsec.AutoSize = true;
            this.lblCp_edsec.Location = new System.Drawing.Point(416, 23);
            this.lblCp_edsec.Name = "lblCp_edsec";
            this.lblCp_edsec.Size = new System.Drawing.Size(53, 12);
            this.lblCp_edsec.TabIndex = 1;
            this.lblCp_edsec.Text = "英文描述";
            // 
            // lblCp_cdesc
            // 
            this.lblCp_cdesc.AutoSize = true;
            this.lblCp_cdesc.Location = new System.Drawing.Point(207, 23);
            this.lblCp_cdesc.Name = "lblCp_cdesc";
            this.lblCp_cdesc.Size = new System.Drawing.Size(53, 12);
            this.lblCp_cdesc.TabIndex = 1;
            this.lblCp_cdesc.Text = "中文描述";
            // 
            // lblCustProd_id
            // 
            this.lblCustProd_id.AutoSize = true;
            this.lblCustProd_id.Location = new System.Drawing.Point(12, 23);
            this.lblCustProd_id.Name = "lblCustProd_id";
            this.lblCustProd_id.Size = new System.Drawing.Size(77, 12);
            this.lblCustProd_id.TabIndex = 1;
            this.lblCustProd_id.Text = "客戶產品編號";
            // 
            // txtCustProd_edesc
            // 
            this.txtCustProd_edesc.Location = new System.Drawing.Point(475, 20);
            this.txtCustProd_edesc.Name = "txtCustProd_edesc";
            this.txtCustProd_edesc.Size = new System.Drawing.Size(122, 22);
            this.txtCustProd_edesc.TabIndex = 2;
            // 
            // txtCustProd_cdesc
            // 
            this.txtCustProd_cdesc.Location = new System.Drawing.Point(266, 20);
            this.txtCustProd_cdesc.Name = "txtCustProd_cdesc";
            this.txtCustProd_cdesc.Size = new System.Drawing.Size(122, 22);
            this.txtCustProd_cdesc.TabIndex = 1;
            // 
            // txtCustProd_id
            // 
            this.txtCustProd_id.Location = new System.Drawing.Point(95, 20);
            this.txtCustProd_id.Name = "txtCustProd_id";
            this.txtCustProd_id.Size = new System.Drawing.Size(89, 22);
            this.txtCustProd_id.TabIndex = 0;
            // 
            // dgvCustProduct
            // 
            this.dgvCustProduct.AllowUserToAddRows = false;
            this.dgvCustProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustProd_id,
            this.colCustProd_cdesc,
            this.colCustProd_edesc,
            this.colCruser,
            this.colCrtim,
            this.colAmuser,
            this.colAmtim});
            this.dgvCustProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustProduct.Location = new System.Drawing.Point(0, 0);
            this.dgvCustProduct.Name = "dgvCustProduct";
            this.dgvCustProduct.RowHeadersWidth = 20;
            this.dgvCustProduct.RowTemplate.Height = 24;
            this.dgvCustProduct.Size = new System.Drawing.Size(623, 348);
            this.dgvCustProduct.TabIndex = 7;
            this.dgvCustProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustProduct_CellClick);
            // 
            // colCustProd_id
            // 
            this.colCustProd_id.DataPropertyName = "id";
            this.colCustProd_id.HeaderText = "客戶產品編號";
            this.colCustProd_id.Name = "colCustProd_id";
            // 
            // colCustProd_cdesc
            // 
            this.colCustProd_cdesc.DataPropertyName = "cdesc";
            this.colCustProd_cdesc.HeaderText = "中文描述";
            this.colCustProd_cdesc.Name = "colCustProd_cdesc";
            // 
            // colCustProd_edesc
            // 
            this.colCustProd_edesc.DataPropertyName = "edesc";
            this.colCustProd_edesc.HeaderText = "英文描述";
            this.colCustProd_edesc.Name = "colCustProd_edesc";
            // 
            // colCruser
            // 
            this.colCruser.DataPropertyName = "cruser";
            this.colCruser.HeaderText = "創建人";
            this.colCruser.Name = "colCruser";
            // 
            // colCrtim
            // 
            this.colCrtim.DataPropertyName = "crtim";
            this.colCrtim.HeaderText = "建檔日期";
            this.colCrtim.Name = "colCrtim";
            // 
            // colAmuser
            // 
            this.colAmuser.DataPropertyName = "amusr";
            this.colAmuser.HeaderText = "修改人";
            this.colAmuser.Name = "colAmuser";
            // 
            // colAmtim
            // 
            this.colAmtim.DataPropertyName = "amtim";
            this.colAmtim.HeaderText = "修改日期";
            this.colAmtim.Name = "colAmtim";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "客戶產品編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "cdesc";
            this.dataGridViewTextBoxColumn2.HeaderText = "中文描述";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "edesc";
            this.dataGridViewTextBoxColumn3.HeaderText = "英文描述";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "cruser";
            this.dataGridViewTextBoxColumn4.HeaderText = "創建人";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "crtim";
            this.dataGridViewTextBoxColumn5.HeaderText = "建檔日期";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "amusr";
            this.dataGridViewTextBoxColumn6.HeaderText = "修改人";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "amtim";
            this.dataGridViewTextBoxColumn7.HeaderText = "修改日期";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // frmTestCustProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(623, 538);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmTestCustProduct";
            this.Text = "客戶產品類型";
            this.Load += new System.EventHandler(this.frmTestCustProduct_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblCp_edsec;
        private System.Windows.Forms.Label lblCp_cdesc;
        private System.Windows.Forms.Label lblCustProd_id;
        private System.Windows.Forms.TextBox txtCustProd_edesc;
        private System.Windows.Forms.TextBox txtCustProd_cdesc;
        private System.Windows.Forms.TextBox txtCustProd_id;
        private System.Windows.Forms.DataGridView dgvCustProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustProd_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustProd_cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustProd_edesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCruser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCrtim;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmuser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmtim;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCustProd_id_sq;
        private System.Windows.Forms.TextBox txtCustProd_cdesc_sq;
        private System.Windows.Forms.Label lblCp_cdesc_sq;
        private System.Windows.Forms.Label lblCustProd_id_sq;
    }
}