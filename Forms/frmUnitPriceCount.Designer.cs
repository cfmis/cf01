namespace cf01.Forms
{
    partial class frmUnitPriceCount
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
            this.lblPrd_item = new System.Windows.Forms.Label();
            this.txtPrd_item = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.MenuTree = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdbIsSet = new System.Windows.Forms.RadioButton();
            this.rdbNoSet = new System.Windows.Forms.RadioButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBomGoods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBomGoods_nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBomId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPrd_item
            // 
            this.lblPrd_item.AutoSize = true;
            this.lblPrd_item.Location = new System.Drawing.Point(16, 23);
            this.lblPrd_item.Name = "lblPrd_item";
            this.lblPrd_item.Size = new System.Drawing.Size(53, 12);
            this.lblPrd_item.TabIndex = 0;
            this.lblPrd_item.Text = "產品編號";
            // 
            // txtPrd_item
            // 
            this.txtPrd_item.Location = new System.Drawing.Point(75, 13);
            this.txtPrd_item.Name = "txtPrd_item";
            this.txtPrd_item.Size = new System.Drawing.Size(190, 22);
            this.txtPrd_item.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(295, 7);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "查找(&F)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // MenuTree
            // 
            this.MenuTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTree.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MenuTree.ItemHeight = 25;
            this.MenuTree.Location = new System.Drawing.Point(0, 0);
            this.MenuTree.Name = "MenuTree";
            this.MenuTree.Size = new System.Drawing.Size(174, 423);
            this.MenuTree.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(809, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 671);
            this.panel1.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 244);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MenuTree);
            this.splitContainer1.Size = new System.Drawing.Size(809, 427);
            this.splitContainer1.SplitterDistance = 178;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvDetails);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(809, 244);
            this.panel2.TabIndex = 0;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.ColumnHeadersHeight = 30;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBomGoods_id,
            this.colBomGoods_nam,
            this.colBomId});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 56);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(805, 184);
            this.dgvDetails.TabIndex = 3;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.lblPrd_item);
            this.panel3.Controls.Add(this.btnFind);
            this.panel3.Controls.Add(this.txtPrd_item);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(805, 56);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rdbAll);
            this.panel4.Controls.Add(this.rdbIsSet);
            this.panel4.Controls.Add(this.rdbNoSet);
            this.panel4.Location = new System.Drawing.Point(417, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(326, 28);
            this.panel4.TabIndex = 3;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(220, 6);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(47, 16);
            this.rdbAll.TabIndex = 2;
            this.rdbAll.Text = "全部";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // rdbIsSet
            // 
            this.rdbIsSet.AutoSize = true;
            this.rdbIsSet.Location = new System.Drawing.Point(119, 6);
            this.rdbIsSet.Name = "rdbIsSet";
            this.rdbIsSet.Size = new System.Drawing.Size(95, 16);
            this.rdbIsSet.TabIndex = 1;
            this.rdbIsSet.Text = "已設定的計价";
            this.rdbIsSet.UseVisualStyleBackColor = true;
            // 
            // rdbNoSet
            // 
            this.rdbNoSet.AutoSize = true;
            this.rdbNoSet.Checked = true;
            this.rdbNoSet.Location = new System.Drawing.Point(16, 6);
            this.rdbNoSet.Name = "rdbNoSet";
            this.rdbNoSet.Size = new System.Drawing.Size(95, 16);
            this.rdbNoSet.TabIndex = 0;
            this.rdbNoSet.TabStop = true;
            this.rdbNoSet.Text = "未設定的計价";
            this.rdbNoSet.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "物料編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 160;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "goods_name";
            this.dataGridViewTextBoxColumn2.HeaderText = "物料描述";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 260;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn3.HeaderText = "BOM序號";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // colBomGoods_id
            // 
            this.colBomGoods_id.DataPropertyName = "goods_id";
            this.colBomGoods_id.HeaderText = "物料編號";
            this.colBomGoods_id.Name = "colBomGoods_id";
            this.colBomGoods_id.ReadOnly = true;
            this.colBomGoods_id.Width = 160;
            // 
            // colBomGoods_nam
            // 
            this.colBomGoods_nam.DataPropertyName = "goods_name";
            this.colBomGoods_nam.HeaderText = "物料描述";
            this.colBomGoods_nam.Name = "colBomGoods_nam";
            this.colBomGoods_nam.ReadOnly = true;
            this.colBomGoods_nam.Width = 260;
            // 
            // colBomId
            // 
            this.colBomId.DataPropertyName = "id";
            this.colBomId.HeaderText = "BOM序號";
            this.colBomId.Name = "colBomId";
            this.colBomId.ReadOnly = true;
            this.colBomId.Width = 200;
            // 
            // frmUnitPriceCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 696);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmUnitPriceCount";
            this.Text = "frmUnitPriceCount";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrd_item;
        private System.Windows.Forms.TextBox txtPrd_item;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TreeView MenuTree;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBomGoods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBomGoods_nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBomId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbIsSet;
        private System.Windows.Forms.RadioButton rdbNoSet;
    }
}