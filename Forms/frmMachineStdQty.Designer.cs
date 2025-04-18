namespace cf01.Forms
{
    partial class frmMachineStdQty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMachineStdQty));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbFindDep = new System.Windows.Forms.ComboBox();
            this.txtDepGroup = new System.Windows.Forms.TextBox();
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.lblDepGroup = new System.Windows.Forms.Label();
            this.lblMachine = new System.Windows.Forms.Label();
            this.txtStdQty = new System.Windows.Forms.TextBox();
            this.txtRunNo = new System.Windows.Forms.TextBox();
            this.lblStdQty = new System.Windows.Forms.Label();
            this.lblRunNo = new System.Windows.Forms.Label();
            this.txtLineNo = new System.Windows.Forms.TextBox();
            this.lblLineNo = new System.Windows.Forms.Label();
            this.lblDep = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdMachine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRunQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStdQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator2,
            this.BTNSAVE,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(944, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.AutoSize = false;
            this.BTNEXIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(65, 35);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
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
            // BTNSAVE
            // 
            this.BTNSAVE.AutoSize = false;
            this.BTNSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BTNSAVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVE.Image")));
            this.BTNSAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVE.Name = "BTNSAVE";
            this.BTNSAVE.Size = new System.Drawing.Size(65, 35);
            this.BTNSAVE.Text = "儲存(&S)";
            this.BTNSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 38);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmbFindDep);
            this.splitContainer1.Panel1.Controls.Add(this.txtDepGroup);
            this.splitContainer1.Panel1.Controls.Add(this.txtMachine);
            this.splitContainer1.Panel1.Controls.Add(this.lblDepGroup);
            this.splitContainer1.Panel1.Controls.Add(this.lblMachine);
            this.splitContainer1.Panel1.Controls.Add(this.txtStdQty);
            this.splitContainer1.Panel1.Controls.Add(this.txtRunNo);
            this.splitContainer1.Panel1.Controls.Add(this.lblStdQty);
            this.splitContainer1.Panel1.Controls.Add(this.lblRunNo);
            this.splitContainer1.Panel1.Controls.Add(this.txtLineNo);
            this.splitContainer1.Panel1.Controls.Add(this.lblLineNo);
            this.splitContainer1.Panel1.Controls.Add(this.lblDep);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(944, 646);
            this.splitContainer1.SplitterDistance = 97;
            this.splitContainer1.TabIndex = 1;
            // 
            // cmbFindDep
            // 
            this.cmbFindDep.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbFindDep.FormattingEnabled = true;
            this.cmbFindDep.Location = new System.Drawing.Point(100, 21);
            this.cmbFindDep.Name = "cmbFindDep";
            this.cmbFindDep.Size = new System.Drawing.Size(136, 21);
            this.cmbFindDep.TabIndex = 27;
            this.cmbFindDep.Leave += new System.EventHandler(this.cmbFindDep_Leave);
            // 
            // txtDepGroup
            // 
            this.txtDepGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDepGroup.Location = new System.Drawing.Point(572, 19);
            this.txtDepGroup.Name = "txtDepGroup";
            this.txtDepGroup.ReadOnly = true;
            this.txtDepGroup.Size = new System.Drawing.Size(136, 23);
            this.txtDepGroup.TabIndex = 1;
            // 
            // txtMachine
            // 
            this.txtMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMachine.Location = new System.Drawing.Point(336, 25);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(154, 23);
            this.txtMachine.TabIndex = 1;
            // 
            // lblDepGroup
            // 
            this.lblDepGroup.AutoSize = true;
            this.lblDepGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDepGroup.Location = new System.Drawing.Point(569, 24);
            this.lblDepGroup.Name = "lblDepGroup";
            this.lblDepGroup.Size = new System.Drawing.Size(40, 17);
            this.lblDepGroup.TabIndex = 0;
            this.lblDepGroup.Text = "位置:";
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMachine.Location = new System.Drawing.Point(289, 24);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(40, 17);
            this.lblMachine.TabIndex = 0;
            this.lblMachine.Text = "機器:";
            // 
            // txtStdQty
            // 
            this.txtStdQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtStdQty.Location = new System.Drawing.Point(572, 54);
            this.txtStdQty.Name = "txtStdQty";
            this.txtStdQty.Size = new System.Drawing.Size(136, 23);
            this.txtStdQty.TabIndex = 4;
            // 
            // txtRunNo
            // 
            this.txtRunNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRunNo.Location = new System.Drawing.Point(100, 54);
            this.txtRunNo.Name = "txtRunNo";
            this.txtRunNo.Size = new System.Drawing.Size(136, 23);
            this.txtRunNo.TabIndex = 3;
            this.txtRunNo.Leave += new System.EventHandler(this.txtRunNo_Leave);
            // 
            // lblStdQty
            // 
            this.lblStdQty.AutoSize = true;
            this.lblStdQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblStdQty.Location = new System.Drawing.Point(498, 57);
            this.lblStdQty.Name = "lblStdQty";
            this.lblStdQty.Size = new System.Drawing.Size(68, 17);
            this.lblStdQty.TabIndex = 0;
            this.lblStdQty.Text = "標準數量:";
            // 
            // lblRunNo
            // 
            this.lblRunNo.AutoSize = true;
            this.lblRunNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblRunNo.Location = new System.Drawing.Point(30, 57);
            this.lblRunNo.Name = "lblRunNo";
            this.lblRunNo.Size = new System.Drawing.Size(68, 17);
            this.lblRunNo.TabIndex = 0;
            this.lblRunNo.Text = "標準轉數:";
            // 
            // txtLineNo
            // 
            this.txtLineNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLineNo.Location = new System.Drawing.Point(336, 54);
            this.txtLineNo.Name = "txtLineNo";
            this.txtLineNo.Size = new System.Drawing.Size(154, 23);
            this.txtLineNo.TabIndex = 2;
            this.txtLineNo.Leave += new System.EventHandler(this.txtLineNo_Leave);
            // 
            // lblLineNo
            // 
            this.lblLineNo.AutoSize = true;
            this.lblLineNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLineNo.Location = new System.Drawing.Point(261, 57);
            this.lblLineNo.Name = "lblLineNo";
            this.lblLineNo.Size = new System.Drawing.Size(68, 17);
            this.lblLineNo.TabIndex = 0;
            this.lblLineNo.Text = "每碑行數:";
            // 
            // lblDep
            // 
            this.lblDep.AutoSize = true;
            this.lblDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDep.Location = new System.Drawing.Point(58, 24);
            this.lblDep.Name = "lblDep";
            this.lblDep.Size = new System.Drawing.Size(40, 17);
            this.lblDep.TabIndex = 0;
            this.lblDep.Text = "部門:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeColumns = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.ColumnHeadersHeight = 30;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDep,
            this.colPrdMachine,
            this.colRunQty,
            this.colLineNo,
            this.colStdQty});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 25;
            this.dgvDetails.Size = new System.Drawing.Size(942, 543);
            this.dgvDetails.TabIndex = 1;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            this.dgvDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellDoubleClick);
            // 
            // colDep
            // 
            this.colDep.DataPropertyName = "dep";
            this.colDep.HeaderText = "部門";
            this.colDep.Name = "colDep";
            // 
            // colPrdMachine
            // 
            this.colPrdMachine.DataPropertyName = "machine_id";
            this.colPrdMachine.HeaderText = "機器代號";
            this.colPrdMachine.Name = "colPrdMachine";
            this.colPrdMachine.Width = 140;
            // 
            // colRunQty
            // 
            this.colRunQty.DataPropertyName = "machine_rate";
            this.colRunQty.HeaderText = "標準轉數";
            this.colRunQty.Name = "colRunQty";
            // 
            // colLineNo
            // 
            this.colLineNo.DataPropertyName = "machine_mul";
            this.colLineNo.HeaderText = "每碑行數";
            this.colLineNo.Name = "colLineNo";
            // 
            // colStdQty
            // 
            this.colStdQty.DataPropertyName = "machine_std_qty";
            this.colStdQty.HeaderText = "小時標準數量";
            this.colStdQty.Name = "colStdQty";
            this.colStdQty.Width = 160;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "dep";
            this.dataGridViewTextBoxColumn1.HeaderText = "部門";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "machine_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "機器代號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "machine_mul";
            this.dataGridViewTextBoxColumn3.HeaderText = "行(碑)數";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "machine_rate";
            this.dataGridViewTextBoxColumn4.HeaderText = "轉數";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "machine_std_qty";
            this.dataGridViewTextBoxColumn5.HeaderText = "小時標準數量";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // frmMachineStdQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 684);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMachineStdQty";
            this.Text = "frmMachineStdQty";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMachineStdQty_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.Label lblDep;
        private System.Windows.Forms.TextBox txtStdQty;
        private System.Windows.Forms.TextBox txtRunNo;
        private System.Windows.Forms.Label lblStdQty;
        private System.Windows.Forms.Label lblRunNo;
        private System.Windows.Forms.TextBox txtLineNo;
        private System.Windows.Forms.Label lblLineNo;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ComboBox cmbFindDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdMachine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRunQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStdQty;
        private System.Windows.Forms.TextBox txtDepGroup;
        private System.Windows.Forms.Label lblDepGroup;
    }
}