namespace cf01.MM
{
    partial class frmProductTypeStdPriceSizeGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductTypeStdPriceSizeGroup));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtSizeName = new DevExpress.XtraEditors.TextEdit();
            this.txtSizeID = new DevExpress.XtraEditors.TextEdit();
            this.lblSizeID = new DevExpress.XtraEditors.LabelControl();
            this.txtGroupID = new DevExpress.XtraEditors.TextEdit();
            this.lblGroupID = new DevExpress.XtraEditors.LabelControl();
            this.dgvSizeGroup = new System.Windows.Forms.DataGridView();
            this.colGroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSizeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSizeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddCharge1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddCharge2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddCharge3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSizeIDFind = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSizeGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizeIDFind.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnAdd,
            this.btnSave,
            this.toolStripSeparator2,
            this.btnDelete,
            this.toolStripSeparator4,
            this.btnFind,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(864, 38);
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
            // btnAdd
            // 
            this.btnAdd.AutoSize = false;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 35);
            this.btnAdd.Text = "新增(&A)";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 35);
            this.btnSave.Text = "儲存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 35);
            this.btnDelete.Text = "刪除(&D)";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 35);
            this.btnFind.Text = "查詢(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtSizeName);
            this.panelControl1.Controls.Add(this.txtSizeID);
            this.panelControl1.Controls.Add(this.lblSizeID);
            this.panelControl1.Controls.Add(this.txtGroupID);
            this.panelControl1.Controls.Add(this.lblGroupID);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 38);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(864, 59);
            this.panelControl1.TabIndex = 1;
            // 
            // txtSizeName
            // 
            this.txtSizeName.Location = new System.Drawing.Point(407, 21);
            this.txtSizeName.Name = "txtSizeName";
            this.txtSizeName.Size = new System.Drawing.Size(161, 20);
            this.txtSizeName.TabIndex = 2;
            // 
            // txtSizeID
            // 
            this.txtSizeID.Location = new System.Drawing.Point(298, 21);
            this.txtSizeID.Name = "txtSizeID";
            this.txtSizeID.Properties.MaxLength = 3;
            this.txtSizeID.Size = new System.Drawing.Size(92, 20);
            this.txtSizeID.TabIndex = 1;
            this.txtSizeID.Leave += new System.EventHandler(this.txtSizeID_Leave);
            // 
            // lblSizeID
            // 
            this.lblSizeID.Location = new System.Drawing.Point(240, 24);
            this.lblSizeID.Name = "lblSizeID";
            this.lblSizeID.Size = new System.Drawing.Size(52, 14);
            this.lblSizeID.TabIndex = 0;
            this.lblSizeID.Text = "尺寸代號:";
            // 
            // txtGroupID
            // 
            this.txtGroupID.Location = new System.Drawing.Point(113, 21);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGroupID.Properties.MaxLength = 4;
            this.txtGroupID.Size = new System.Drawing.Size(100, 20);
            this.txtGroupID.TabIndex = 0;
            // 
            // lblGroupID
            // 
            this.lblGroupID.Location = new System.Drawing.Point(37, 24);
            this.lblGroupID.Name = "lblGroupID";
            this.lblGroupID.Size = new System.Drawing.Size(52, 14);
            this.lblGroupID.TabIndex = 0;
            this.lblGroupID.Text = "尺寸組別:";
            // 
            // dgvSizeGroup
            // 
            this.dgvSizeGroup.AllowUserToAddRows = false;
            this.dgvSizeGroup.ColumnHeadersHeight = 25;
            this.dgvSizeGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSizeGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGroupID,
            this.colSizeID,
            this.colSizeName,
            this.colAddCharge1,
            this.colAddCharge2,
            this.colAddCharge3});
            this.dgvSizeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSizeGroup.Location = new System.Drawing.Point(0, 97);
            this.dgvSizeGroup.Name = "dgvSizeGroup";
            this.dgvSizeGroup.ReadOnly = true;
            this.dgvSizeGroup.RowHeadersWidth = 20;
            this.dgvSizeGroup.RowTemplate.Height = 24;
            this.dgvSizeGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSizeGroup.Size = new System.Drawing.Size(864, 491);
            this.dgvSizeGroup.TabIndex = 1;
            this.dgvSizeGroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSizeGroup_CellDoubleClick);
            this.dgvSizeGroup.SelectionChanged += new System.EventHandler(this.dgvSizeGroup_SelectionChanged);
            // 
            // colGroupID
            // 
            this.colGroupID.DataPropertyName = "GroupID";
            this.colGroupID.HeaderText = "組別代號";
            this.colGroupID.Name = "colGroupID";
            this.colGroupID.ReadOnly = true;
            // 
            // colSizeID
            // 
            this.colSizeID.DataPropertyName = "SizeID";
            this.colSizeID.HeaderText = "尺寸代號";
            this.colSizeID.Name = "colSizeID";
            this.colSizeID.ReadOnly = true;
            // 
            // colSizeName
            // 
            this.colSizeName.DataPropertyName = "SizeName";
            this.colSizeName.HeaderText = "尺寸描述";
            this.colSizeName.Name = "colSizeName";
            this.colSizeName.ReadOnly = true;
            this.colSizeName.Width = 180;
            // 
            // colAddCharge1
            // 
            this.colAddCharge1.DataPropertyName = "add_charge1";
            this.colAddCharge1.HeaderText = "噴沙";
            this.colAddCharge1.Name = "colAddCharge1";
            this.colAddCharge1.ReadOnly = true;
            this.colAddCharge1.Width = 80;
            // 
            // colAddCharge2
            // 
            this.colAddCharge2.DataPropertyName = "add_charge2";
            this.colAddCharge2.HeaderText = "噴LAC.";
            this.colAddCharge2.Name = "colAddCharge2";
            this.colAddCharge2.ReadOnly = true;
            this.colAddCharge2.Width = 80;
            // 
            // colAddCharge3
            // 
            this.colAddCharge3.DataPropertyName = "add_charge3";
            this.colAddCharge3.HeaderText = "不锈鋼";
            this.colAddCharge3.Name = "colAddCharge3";
            this.colAddCharge3.ReadOnly = true;
            this.colAddCharge3.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "GroupID";
            this.dataGridViewTextBoxColumn1.HeaderText = "組別代號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SizeID";
            this.dataGridViewTextBoxColumn2.HeaderText = "尺寸代號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SizeName";
            this.dataGridViewTextBoxColumn3.HeaderText = "尺寸描述";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 180;
            // 
            // txtSizeIDFind
            // 
            this.txtSizeIDFind.Location = new System.Drawing.Point(370, 10);
            this.txtSizeIDFind.Name = "txtSizeIDFind";
            this.txtSizeIDFind.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSizeIDFind.Properties.MaxLength = 4;
            this.txtSizeIDFind.Size = new System.Drawing.Size(100, 20);
            this.txtSizeIDFind.TabIndex = 3;
            this.txtSizeIDFind.Leave += new System.EventHandler(this.txtGroupIDFind_Leave);
            // 
            // frmProductTypeStdPriceSizeGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 588);
            this.Controls.Add(this.txtSizeIDFind);
            this.Controls.Add(this.dgvSizeGroup);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmProductTypeStdPriceSizeGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmProductTypeStdPriceSizeGroup";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSizeGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSizeIDFind.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtSizeID;
        private DevExpress.XtraEditors.LabelControl lblSizeID;
        private DevExpress.XtraEditors.TextEdit txtGroupID;
        private DevExpress.XtraEditors.LabelControl lblGroupID;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevExpress.XtraEditors.TextEdit txtSizeName;
        private System.Windows.Forms.DataGridView dgvSizeGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DevExpress.XtraEditors.TextEdit txtSizeIDFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSizeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSizeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddCharge1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddCharge2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddCharge3;
    }
}