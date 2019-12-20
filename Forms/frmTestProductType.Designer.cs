namespace cf01.Forms
{
    partial class frmTestProductType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestProductType));
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
            this.txtPT_id_sq = new System.Windows.Forms.TextBox();
            this.txtPT_cdesc_sq = new System.Windows.Forms.TextBox();
            this.lblPT_cdesc_sq = new System.Windows.Forms.Label();
            this.lblPT_id_sq = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblPT_edesc = new System.Windows.Forms.Label();
            this.lblPT_cdesc = new System.Windows.Forms.Label();
            this.lblPT_id = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtPT_edesc = new System.Windows.Forms.TextBox();
            this.txtPT_cdesc = new System.Windows.Forms.TextBox();
            this.txtPT_id = new System.Windows.Forms.TextBox();
            this.dgvProductType = new System.Windows.Forms.DataGridView();
            this.colPt_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPt_cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPt_edesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductType)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(612, 25);
            this.toolStrip1.TabIndex = 4;
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
            this.splitContainer1.Panel1.Controls.Add(this.lblRemark);
            this.splitContainer1.Panel1.Controls.Add(this.lblPT_edesc);
            this.splitContainer1.Panel1.Controls.Add(this.lblPT_cdesc);
            this.splitContainer1.Panel1.Controls.Add(this.lblPT_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtRemark);
            this.splitContainer1.Panel1.Controls.Add(this.txtPT_edesc);
            this.splitContainer1.Panel1.Controls.Add(this.txtPT_cdesc);
            this.splitContainer1.Panel1.Controls.Add(this.txtPT_id);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvProductType);
            this.splitContainer1.Size = new System.Drawing.Size(612, 510);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtPT_id_sq);
            this.panel1.Controls.Add(this.txtPT_cdesc_sq);
            this.panel1.Controls.Add(this.lblPT_cdesc_sq);
            this.panel1.Controls.Add(this.lblPT_id_sq);
            this.panel1.Location = new System.Drawing.Point(1, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 54);
            this.panel1.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSearch.Location = new System.Drawing.Point(515, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPT_id_sq
            // 
            this.txtPT_id_sq.Location = new System.Drawing.Point(94, 23);
            this.txtPT_id_sq.Name = "txtPT_id_sq";
            this.txtPT_id_sq.Size = new System.Drawing.Size(89, 22);
            this.txtPT_id_sq.TabIndex = 5;
            // 
            // txtPT_cdesc_sq
            // 
            this.txtPT_cdesc_sq.Location = new System.Drawing.Point(265, 23);
            this.txtPT_cdesc_sq.Name = "txtPT_cdesc_sq";
            this.txtPT_cdesc_sq.Size = new System.Drawing.Size(244, 22);
            this.txtPT_cdesc_sq.TabIndex = 6;
            // 
            // lblPT_cdesc_sq
            // 
            this.lblPT_cdesc_sq.AutoSize = true;
            this.lblPT_cdesc_sq.Location = new System.Drawing.Point(205, 26);
            this.lblPT_cdesc_sq.Name = "lblPT_cdesc_sq";
            this.lblPT_cdesc_sq.Size = new System.Drawing.Size(53, 12);
            this.lblPT_cdesc_sq.TabIndex = 1;
            this.lblPT_cdesc_sq.Text = "中文描述";
            // 
            // lblPT_id_sq
            // 
            this.lblPT_id_sq.AutoSize = true;
            this.lblPT_id_sq.Location = new System.Drawing.Point(2, 26);
            this.lblPT_id_sq.Name = "lblPT_id_sq";
            this.lblPT_id_sq.Size = new System.Drawing.Size(89, 12);
            this.lblPT_id_sq.TabIndex = 1;
            this.lblPT_id_sq.Text = "測試產品類型ID";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(60, 82);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(29, 12);
            this.lblRemark.TabIndex = 1;
            this.lblRemark.Text = "備註";
            // 
            // lblPT_edesc
            // 
            this.lblPT_edesc.AutoSize = true;
            this.lblPT_edesc.Location = new System.Drawing.Point(36, 48);
            this.lblPT_edesc.Name = "lblPT_edesc";
            this.lblPT_edesc.Size = new System.Drawing.Size(53, 12);
            this.lblPT_edesc.TabIndex = 1;
            this.lblPT_edesc.Text = "英文描述";
            // 
            // lblPT_cdesc
            // 
            this.lblPT_cdesc.AutoSize = true;
            this.lblPT_cdesc.Location = new System.Drawing.Point(207, 16);
            this.lblPT_cdesc.Name = "lblPT_cdesc";
            this.lblPT_cdesc.Size = new System.Drawing.Size(53, 12);
            this.lblPT_cdesc.TabIndex = 1;
            this.lblPT_cdesc.Text = "中文描述";
            // 
            // lblPT_id
            // 
            this.lblPT_id.AutoSize = true;
            this.lblPT_id.Location = new System.Drawing.Point(3, 16);
            this.lblPT_id.Name = "lblPT_id";
            this.lblPT_id.Size = new System.Drawing.Size(89, 12);
            this.lblPT_id.TabIndex = 1;
            this.lblPT_id.Text = "測試產品類型ID";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(95, 79);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(496, 22);
            this.txtRemark.TabIndex = 3;
            // 
            // txtPT_edesc
            // 
            this.txtPT_edesc.Location = new System.Drawing.Point(95, 45);
            this.txtPT_edesc.Name = "txtPT_edesc";
            this.txtPT_edesc.Size = new System.Drawing.Size(496, 22);
            this.txtPT_edesc.TabIndex = 2;
            // 
            // txtPT_cdesc
            // 
            this.txtPT_cdesc.Location = new System.Drawing.Point(266, 13);
            this.txtPT_cdesc.Name = "txtPT_cdesc";
            this.txtPT_cdesc.Size = new System.Drawing.Size(325, 22);
            this.txtPT_cdesc.TabIndex = 1;
            // 
            // txtPT_id
            // 
            this.txtPT_id.Location = new System.Drawing.Point(95, 13);
            this.txtPT_id.Name = "txtPT_id";
            this.txtPT_id.Size = new System.Drawing.Size(89, 22);
            this.txtPT_id.TabIndex = 0;
            // 
            // dgvProductType
            // 
            this.dgvProductType.AllowUserToAddRows = false;
            this.dgvProductType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPt_id,
            this.colPt_cdesc,
            this.colPt_edesc,
            this.colRemark,
            this.colCruser,
            this.colCrtim,
            this.colAmuser,
            this.colAmtim});
            this.dgvProductType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductType.Location = new System.Drawing.Point(0, 0);
            this.dgvProductType.Name = "dgvProductType";
            this.dgvProductType.RowHeadersWidth = 20;
            this.dgvProductType.RowTemplate.Height = 24;
            this.dgvProductType.Size = new System.Drawing.Size(612, 348);
            this.dgvProductType.TabIndex = 8;
            this.dgvProductType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductType_CellClick);
            // 
            // colPt_id
            // 
            this.colPt_id.DataPropertyName = "id";
            this.colPt_id.HeaderText = "測試產品ID";
            this.colPt_id.Name = "colPt_id";
            // 
            // colPt_cdesc
            // 
            this.colPt_cdesc.DataPropertyName = "cdesc";
            this.colPt_cdesc.HeaderText = "中文描述";
            this.colPt_cdesc.Name = "colPt_cdesc";
            // 
            // colPt_edesc
            // 
            this.colPt_edesc.DataPropertyName = "edesc";
            this.colPt_edesc.HeaderText = "英文描述";
            this.colPt_edesc.Name = "colPt_edesc";
            this.colPt_edesc.Width = 150;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "remark";
            this.colRemark.HeaderText = "備註";
            this.colRemark.Name = "colRemark";
            this.colRemark.Width = 150;
            // 
            // colCruser
            // 
            this.colCruser.DataPropertyName = "crusr";
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
            this.dataGridViewTextBoxColumn1.HeaderText = "測試產品ID";
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
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "remark";
            this.dataGridViewTextBoxColumn4.HeaderText = "備註";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "cruser";
            this.dataGridViewTextBoxColumn5.HeaderText = "創建人";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "crtim";
            this.dataGridViewTextBoxColumn6.HeaderText = "建檔日期";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "amusr";
            this.dataGridViewTextBoxColumn7.HeaderText = "修改人";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "amtim";
            this.dataGridViewTextBoxColumn8.HeaderText = "修改日期";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // frmTestProductType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(612, 535);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmTestProductType";
            this.Text = "測試產品類型";
            this.Load += new System.EventHandler(this.frmTestProductType_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductType)).EndInit();
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
        private System.Windows.Forms.TextBox txtPT_id_sq;
        private System.Windows.Forms.TextBox txtPT_cdesc_sq;
        private System.Windows.Forms.Label lblPT_cdesc_sq;
        private System.Windows.Forms.Label lblPT_id_sq;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblPT_edesc;
        private System.Windows.Forms.Label lblPT_cdesc;
        private System.Windows.Forms.Label lblPT_id;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtPT_edesc;
        private System.Windows.Forms.TextBox txtPT_cdesc;
        private System.Windows.Forms.TextBox txtPT_id;
        private System.Windows.Forms.DataGridView dgvProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPt_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPt_cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPt_edesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}