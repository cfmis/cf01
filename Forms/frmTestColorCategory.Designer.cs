namespace cf01.Forms
{
    partial class frmTestColorCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestColorCategory));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtColorCategory_id_sq = new System.Windows.Forms.TextBox();
            this.txtColorCategory_cdesc_sq = new System.Windows.Forms.TextBox();
            this.lblCc_cdesc_sq = new System.Windows.Forms.Label();
            this.lblCC_id_sq = new System.Windows.Forms.Label();
            this.lblCc_edsec = new System.Windows.Forms.Label();
            this.lblCc_cdesc = new System.Windows.Forms.Label();
            this.lblCC_id = new System.Windows.Forms.Label();
            this.txtColorCategory_edesc = new System.Windows.Forms.TextBox();
            this.txtColorCategory_cdesc = new System.Windows.Forms.TextBox();
            this.txtColorCategory_id = new System.Windows.Forms.TextBox();
            this.dgvColorCategory = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorCategory_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCc_cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCc_edesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCruser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCrtim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmuser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmtim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColorCategory)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(603, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
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
            this.splitContainer1.Panel1.Controls.Add(this.lblCc_edsec);
            this.splitContainer1.Panel1.Controls.Add(this.lblCc_cdesc);
            this.splitContainer1.Panel1.Controls.Add(this.lblCC_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtColorCategory_edesc);
            this.splitContainer1.Panel1.Controls.Add(this.txtColorCategory_cdesc);
            this.splitContainer1.Panel1.Controls.Add(this.txtColorCategory_id);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvColorCategory);
            this.splitContainer1.Size = new System.Drawing.Size(603, 508);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtColorCategory_id_sq);
            this.panel1.Controls.Add(this.txtColorCategory_cdesc_sq);
            this.panel1.Controls.Add(this.lblCc_cdesc_sq);
            this.panel1.Controls.Add(this.lblCC_id_sq);
            this.panel1.Location = new System.Drawing.Point(1, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 54);
            this.panel1.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSearch.Location = new System.Drawing.Point(515, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtColorCategory_id_sq
            // 
            this.txtColorCategory_id_sq.Location = new System.Drawing.Point(94, 23);
            this.txtColorCategory_id_sq.Name = "txtColorCategory_id_sq";
            this.txtColorCategory_id_sq.Size = new System.Drawing.Size(89, 22);
            this.txtColorCategory_id_sq.TabIndex = 4;
            // 
            // txtColorCategory_cdesc_sq
            // 
            this.txtColorCategory_cdesc_sq.Location = new System.Drawing.Point(265, 23);
            this.txtColorCategory_cdesc_sq.Name = "txtColorCategory_cdesc_sq";
            this.txtColorCategory_cdesc_sq.Size = new System.Drawing.Size(244, 22);
            this.txtColorCategory_cdesc_sq.TabIndex = 5;
            // 
            // lblCc_cdesc_sq
            // 
            this.lblCc_cdesc_sq.AutoSize = true;
            this.lblCc_cdesc_sq.Location = new System.Drawing.Point(205, 26);
            this.lblCc_cdesc_sq.Name = "lblCc_cdesc_sq";
            this.lblCc_cdesc_sq.Size = new System.Drawing.Size(53, 12);
            this.lblCc_cdesc_sq.TabIndex = 1;
            this.lblCc_cdesc_sq.Text = "中文描述";
            // 
            // lblCC_id_sq
            // 
            this.lblCC_id_sq.AutoSize = true;
            this.lblCC_id_sq.Location = new System.Drawing.Point(11, 26);
            this.lblCC_id_sq.Name = "lblCC_id_sq";
            this.lblCC_id_sq.Size = new System.Drawing.Size(77, 12);
            this.lblCC_id_sq.TabIndex = 1;
            this.lblCC_id_sq.Text = "顏色類別編號";
            // 
            // lblCc_edsec
            // 
            this.lblCc_edsec.AutoSize = true;
            this.lblCc_edsec.Location = new System.Drawing.Point(36, 60);
            this.lblCc_edsec.Name = "lblCc_edsec";
            this.lblCc_edsec.Size = new System.Drawing.Size(53, 12);
            this.lblCc_edsec.TabIndex = 1;
            this.lblCc_edsec.Text = "英文描述";
            // 
            // lblCc_cdesc
            // 
            this.lblCc_cdesc.AutoSize = true;
            this.lblCc_cdesc.Location = new System.Drawing.Point(207, 23);
            this.lblCc_cdesc.Name = "lblCc_cdesc";
            this.lblCc_cdesc.Size = new System.Drawing.Size(53, 12);
            this.lblCc_cdesc.TabIndex = 1;
            this.lblCc_cdesc.Text = "中文描述";
            // 
            // lblCC_id
            // 
            this.lblCC_id.AutoSize = true;
            this.lblCC_id.Location = new System.Drawing.Point(12, 23);
            this.lblCC_id.Name = "lblCC_id";
            this.lblCC_id.Size = new System.Drawing.Size(77, 12);
            this.lblCC_id.TabIndex = 1;
            this.lblCC_id.Text = "顏色類別編號";
            // 
            // txtColorCategory_edesc
            // 
            this.txtColorCategory_edesc.Location = new System.Drawing.Point(95, 57);
            this.txtColorCategory_edesc.Name = "txtColorCategory_edesc";
            this.txtColorCategory_edesc.Size = new System.Drawing.Size(496, 22);
            this.txtColorCategory_edesc.TabIndex = 2;
            // 
            // txtColorCategory_cdesc
            // 
            this.txtColorCategory_cdesc.Location = new System.Drawing.Point(266, 20);
            this.txtColorCategory_cdesc.Name = "txtColorCategory_cdesc";
            this.txtColorCategory_cdesc.Size = new System.Drawing.Size(325, 22);
            this.txtColorCategory_cdesc.TabIndex = 1;
            // 
            // txtColorCategory_id
            // 
            this.txtColorCategory_id.Location = new System.Drawing.Point(95, 20);
            this.txtColorCategory_id.Name = "txtColorCategory_id";
            this.txtColorCategory_id.Size = new System.Drawing.Size(89, 22);
            this.txtColorCategory_id.TabIndex = 0;
            // 
            // dgvColorCategory
            // 
            this.dgvColorCategory.AllowUserToAddRows = false;
            this.dgvColorCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColorCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colColorCategory_id,
            this.colCc_cdesc,
            this.colCc_edesc,
            this.colCruser,
            this.colCrtim,
            this.colAmuser,
            this.colAmtim});
            this.dgvColorCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColorCategory.Location = new System.Drawing.Point(0, 0);
            this.dgvColorCategory.Name = "dgvColorCategory";
            this.dgvColorCategory.RowHeadersWidth = 20;
            this.dgvColorCategory.RowTemplate.Height = 24;
            this.dgvColorCategory.Size = new System.Drawing.Size(603, 345);
            this.dgvColorCategory.TabIndex = 7;
            this.dgvColorCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColorProduct_CellClick);
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
            // colColorCategory_id
            // 
            this.colColorCategory_id.DataPropertyName = "id";
            this.colColorCategory_id.HeaderText = "顏色類別編號";
            this.colColorCategory_id.Name = "colColorCategory_id";
            // 
            // colCc_cdesc
            // 
            this.colCc_cdesc.DataPropertyName = "cdesc";
            this.colCc_cdesc.HeaderText = "中文描述";
            this.colCc_cdesc.Name = "colCc_cdesc";
            // 
            // colCc_edesc
            // 
            this.colCc_edesc.DataPropertyName = "edesc";
            this.colCc_edesc.HeaderText = "英文描述";
            this.colCc_edesc.Name = "colCc_edesc";
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
            // frmTestColorCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(603, 533);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmTestColorCategory";
            this.Text = "顏色類別";
            this.Load += new System.EventHandler(this.frmTestColorCategory_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColorCategory)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtColorCategory_id_sq;
        private System.Windows.Forms.TextBox txtColorCategory_cdesc_sq;
        private System.Windows.Forms.Label lblCc_cdesc_sq;
        private System.Windows.Forms.Label lblCC_id_sq;
        private System.Windows.Forms.Label lblCc_edsec;
        private System.Windows.Forms.Label lblCc_cdesc;
        private System.Windows.Forms.Label lblCC_id;
        private System.Windows.Forms.TextBox txtColorCategory_edesc;
        private System.Windows.Forms.TextBox txtColorCategory_cdesc;
        private System.Windows.Forms.TextBox txtColorCategory_id;
        private System.Windows.Forms.DataGridView dgvColorCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorCategory_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCc_cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCc_edesc;
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
    }
}