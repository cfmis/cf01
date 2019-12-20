namespace cf01.Forms
{
    partial class frmTestMatType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestMatType));
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
            this.txtMat_id_sq = new System.Windows.Forms.TextBox();
            this.lblMat_id_sq = new System.Windows.Forms.Label();
            this.txtMat_name_sq = new System.Windows.Forms.TextBox();
            this.lblMat_name_sq = new System.Windows.Forms.Label();
            this.txtMat_id = new System.Windows.Forms.TextBox();
            this.txtSeq_id = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtMat_cdesc = new System.Windows.Forms.TextBox();
            this.lblRmark = new System.Windows.Forms.Label();
            this.lblMat_name = new System.Windows.Forms.Label();
            this.lblSeq_id = new System.Windows.Forms.Label();
            this.lblMat_id = new System.Windows.Forms.Label();
            this.dgvMat_type = new System.Windows.Forms.DataGridView();
            this.lblMat_edesc = new System.Windows.Forms.Label();
            this.txtMat_edesc = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMat_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMat_cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMat_edesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeq_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMat_type)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(613, 25);
            this.toolStrip1.TabIndex = 0;
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
            this.splitContainer1.Panel1.Controls.Add(this.txtMat_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtSeq_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtRemark);
            this.splitContainer1.Panel1.Controls.Add(this.txtMat_edesc);
            this.splitContainer1.Panel1.Controls.Add(this.txtMat_cdesc);
            this.splitContainer1.Panel1.Controls.Add(this.lblMat_edesc);
            this.splitContainer1.Panel1.Controls.Add(this.lblRmark);
            this.splitContainer1.Panel1.Controls.Add(this.lblMat_name);
            this.splitContainer1.Panel1.Controls.Add(this.lblSeq_id);
            this.splitContainer1.Panel1.Controls.Add(this.lblMat_id);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvMat_type);
            this.splitContainer1.Size = new System.Drawing.Size(613, 455);
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtMat_id_sq);
            this.panel1.Controls.Add(this.lblMat_id_sq);
            this.panel1.Controls.Add(this.txtMat_name_sq);
            this.panel1.Controls.Add(this.lblMat_name_sq);
            this.panel1.Location = new System.Drawing.Point(2, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 44);
            this.panel1.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(491, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMat_id_sq
            // 
            this.txtMat_id_sq.Location = new System.Drawing.Point(71, 15);
            this.txtMat_id_sq.Name = "txtMat_id_sq";
            this.txtMat_id_sq.Size = new System.Drawing.Size(100, 22);
            this.txtMat_id_sq.TabIndex = 5;
            // 
            // lblMat_id_sq
            // 
            this.lblMat_id_sq.AutoSize = true;
            this.lblMat_id_sq.Location = new System.Drawing.Point(12, 18);
            this.lblMat_id_sq.Name = "lblMat_id_sq";
            this.lblMat_id_sq.Size = new System.Drawing.Size(53, 12);
            this.lblMat_id_sq.TabIndex = 0;
            this.lblMat_id_sq.Text = "材料編號";
            // 
            // txtMat_name_sq
            // 
            this.txtMat_name_sq.Location = new System.Drawing.Point(267, 15);
            this.txtMat_name_sq.Name = "txtMat_name_sq";
            this.txtMat_name_sq.Size = new System.Drawing.Size(163, 22);
            this.txtMat_name_sq.TabIndex = 6;
            // 
            // lblMat_name_sq
            // 
            this.lblMat_name_sq.AutoSize = true;
            this.lblMat_name_sq.Location = new System.Drawing.Point(208, 20);
            this.lblMat_name_sq.Name = "lblMat_name_sq";
            this.lblMat_name_sq.Size = new System.Drawing.Size(53, 12);
            this.lblMat_name_sq.TabIndex = 0;
            this.lblMat_name_sq.Text = "材料名稱";
            // 
            // txtMat_id
            // 
            this.txtMat_id.Location = new System.Drawing.Point(74, 13);
            this.txtMat_id.MaxLength = 10;
            this.txtMat_id.Name = "txtMat_id";
            this.txtMat_id.Size = new System.Drawing.Size(100, 22);
            this.txtMat_id.TabIndex = 0;
            // 
            // txtSeq_id
            // 
            this.txtSeq_id.Location = new System.Drawing.Point(494, 13);
            this.txtSeq_id.Name = "txtSeq_id";
            this.txtSeq_id.Size = new System.Drawing.Size(100, 22);
            this.txtSeq_id.TabIndex = 2;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(73, 69);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(520, 22);
            this.txtRemark.TabIndex = 4;
            // 
            // txtMat_cdesc
            // 
            this.txtMat_cdesc.Location = new System.Drawing.Point(270, 13);
            this.txtMat_cdesc.Name = "txtMat_cdesc";
            this.txtMat_cdesc.Size = new System.Drawing.Size(163, 22);
            this.txtMat_cdesc.TabIndex = 1;
            // 
            // lblRmark
            // 
            this.lblRmark.AutoSize = true;
            this.lblRmark.Location = new System.Drawing.Point(38, 72);
            this.lblRmark.Name = "lblRmark";
            this.lblRmark.Size = new System.Drawing.Size(29, 12);
            this.lblRmark.TabIndex = 1;
            this.lblRmark.Text = "備註";
            // 
            // lblMat_name
            // 
            this.lblMat_name.AutoSize = true;
            this.lblMat_name.Location = new System.Drawing.Point(211, 16);
            this.lblMat_name.Name = "lblMat_name";
            this.lblMat_name.Size = new System.Drawing.Size(53, 12);
            this.lblMat_name.TabIndex = 0;
            this.lblMat_name.Text = "中文描述";
            // 
            // lblSeq_id
            // 
            this.lblSeq_id.AutoSize = true;
            this.lblSeq_id.Location = new System.Drawing.Point(455, 16);
            this.lblSeq_id.Name = "lblSeq_id";
            this.lblSeq_id.Size = new System.Drawing.Size(29, 12);
            this.lblSeq_id.TabIndex = 1;
            this.lblSeq_id.Text = "序號";
            // 
            // lblMat_id
            // 
            this.lblMat_id.AutoSize = true;
            this.lblMat_id.Location = new System.Drawing.Point(15, 16);
            this.lblMat_id.Name = "lblMat_id";
            this.lblMat_id.Size = new System.Drawing.Size(53, 12);
            this.lblMat_id.TabIndex = 0;
            this.lblMat_id.Text = "材料編號";
            // 
            // dgvMat_type
            // 
            this.dgvMat_type.AllowUserToAddRows = false;
            this.dgvMat_type.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMat_type.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMat_id,
            this.colMat_cdesc,
            this.colMat_edesc,
            this.colSeq_id,
            this.colRemark});
            this.dgvMat_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMat_type.Location = new System.Drawing.Point(0, 0);
            this.dgvMat_type.Name = "dgvMat_type";
            this.dgvMat_type.RowHeadersWidth = 20;
            this.dgvMat_type.RowTemplate.Height = 24;
            this.dgvMat_type.Size = new System.Drawing.Size(613, 303);
            this.dgvMat_type.TabIndex = 8;
            this.dgvMat_type.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMat_type_CellClick);
            // 
            // lblMat_edesc
            // 
            this.lblMat_edesc.AutoSize = true;
            this.lblMat_edesc.Location = new System.Drawing.Point(15, 44);
            this.lblMat_edesc.Name = "lblMat_edesc";
            this.lblMat_edesc.Size = new System.Drawing.Size(53, 12);
            this.lblMat_edesc.TabIndex = 0;
            this.lblMat_edesc.Text = "英文描述";
            // 
            // txtMat_edesc
            // 
            this.txtMat_edesc.Location = new System.Drawing.Point(74, 41);
            this.txtMat_edesc.Name = "txtMat_edesc";
            this.txtMat_edesc.Size = new System.Drawing.Size(359, 22);
            this.txtMat_edesc.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "材料編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn2.HeaderText = "材料名稱";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "seq_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "序號";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "remark";
            this.dataGridViewTextBoxColumn4.HeaderText = "備註";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 250;
            // 
            // colMat_id
            // 
            this.colMat_id.DataPropertyName = "id";
            this.colMat_id.HeaderText = "材料編號";
            this.colMat_id.Name = "colMat_id";
            // 
            // colMat_cdesc
            // 
            this.colMat_cdesc.DataPropertyName = "name";
            this.colMat_cdesc.HeaderText = "材料中文描述";
            this.colMat_cdesc.Name = "colMat_cdesc";
            this.colMat_cdesc.Width = 150;
            // 
            // colMat_edesc
            // 
            this.colMat_edesc.DataPropertyName = "name_english";
            this.colMat_edesc.HeaderText = "材料英文描述";
            this.colMat_edesc.Name = "colMat_edesc";
            this.colMat_edesc.Width = 150;
            // 
            // colSeq_id
            // 
            this.colSeq_id.DataPropertyName = "seq_id";
            this.colSeq_id.HeaderText = "序號";
            this.colSeq_id.Name = "colSeq_id";
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "remark";
            this.colRemark.HeaderText = "備註";
            this.colRemark.Name = "colRemark";
            this.colRemark.Width = 250;
            // 
            // frmTestMatType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(613, 480);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmTestMatType";
            this.Text = "材料類別";
            this.Load += new System.EventHandler(this.frmTestMatType_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMat_type)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtMat_id;
        private System.Windows.Forms.TextBox txtSeq_id;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtMat_cdesc;
        private System.Windows.Forms.Label lblRmark;
        private System.Windows.Forms.Label lblMat_name;
        private System.Windows.Forms.Label lblSeq_id;
        private System.Windows.Forms.Label lblMat_id;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtMat_id_sq;
        private System.Windows.Forms.Label lblMat_id_sq;
        private System.Windows.Forms.TextBox txtMat_name_sq;
        private System.Windows.Forms.Label lblMat_name_sq;
        private System.Windows.Forms.DataGridView dgvMat_type;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox txtMat_edesc;
        private System.Windows.Forms.Label lblMat_edesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMat_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMat_cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMat_edesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeq_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
    }
}