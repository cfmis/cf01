namespace cf01.MM
{
    partial class frmProductTypeStdPriceColorGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductTypeStdPriceColorGroup));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtColorName = new DevExpress.XtraEditors.TextEdit();
            this.txtColorID = new DevExpress.XtraEditors.TextEdit();
            this.lblColorID = new DevExpress.XtraEditors.LabelControl();
            this.txtGroupID = new DevExpress.XtraEditors.TextEdit();
            this.lblGroupID = new DevExpress.XtraEditors.LabelControl();
            this.dgvColorGroup = new System.Windows.Forms.DataGridView();
            this.colGroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtColorIDFind = new DevExpress.XtraEditors.TextEdit();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColorGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorIDFind.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnAddGroup,
            this.toolStripSeparator5,
            this.btnAddColor,
            this.toolStripSeparator6,
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
            // btnAddGroup
            // 
            this.btnAddGroup.AutoSize = false;
            this.btnAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGroup.Image")));
            this.btnAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(85, 35);
            this.btnAddGroup.Text = "新增組別(A)";
            this.btnAddGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddGroup.ToolTipText = "新增組別";
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // btnAddColor
            // 
            this.btnAddColor.AutoSize = false;
            this.btnAddColor.Image = ((System.Drawing.Image)(resources.GetObject("btnAddColor.Image")));
            this.btnAddColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(65, 35);
            this.btnAddColor.Text = "新增顏色";
            this.btnAddColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
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
            this.panelControl1.Controls.Add(this.txtColorName);
            this.panelControl1.Controls.Add(this.txtColorID);
            this.panelControl1.Controls.Add(this.lblColorID);
            this.panelControl1.Controls.Add(this.txtGroupID);
            this.panelControl1.Controls.Add(this.lblGroupID);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 38);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(864, 59);
            this.panelControl1.TabIndex = 1;
            // 
            // txtColorName
            // 
            this.txtColorName.Location = new System.Drawing.Point(407, 21);
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.Size = new System.Drawing.Size(161, 20);
            this.txtColorName.TabIndex = 2;
            // 
            // txtColorID
            // 
            this.txtColorID.Location = new System.Drawing.Point(298, 21);
            this.txtColorID.Name = "txtColorID";
            this.txtColorID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColorID.Properties.MaxLength = 4;
            this.txtColorID.Size = new System.Drawing.Size(92, 20);
            this.txtColorID.TabIndex = 1;
            this.txtColorID.Leave += new System.EventHandler(this.txtColorID_Leave);
            // 
            // lblColorID
            // 
            this.lblColorID.Location = new System.Drawing.Point(240, 24);
            this.lblColorID.Name = "lblColorID";
            this.lblColorID.Size = new System.Drawing.Size(52, 14);
            this.lblColorID.TabIndex = 0;
            this.lblColorID.Text = "顏色代號:";
            // 
            // txtGroupID
            // 
            this.txtGroupID.Location = new System.Drawing.Point(113, 21);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGroupID.Properties.MaxLength = 4;
            this.txtGroupID.Properties.ReadOnly = true;
            this.txtGroupID.Size = new System.Drawing.Size(100, 20);
            this.txtGroupID.TabIndex = 0;
            // 
            // lblGroupID
            // 
            this.lblGroupID.Location = new System.Drawing.Point(37, 24);
            this.lblGroupID.Name = "lblGroupID";
            this.lblGroupID.Size = new System.Drawing.Size(52, 14);
            this.lblGroupID.TabIndex = 0;
            this.lblGroupID.Text = "顏色組別:";
            // 
            // dgvColorGroup
            // 
            this.dgvColorGroup.AllowUserToAddRows = false;
            this.dgvColorGroup.ColumnHeadersHeight = 25;
            this.dgvColorGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvColorGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGroupID,
            this.colColorID,
            this.colColorName});
            this.dgvColorGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColorGroup.Location = new System.Drawing.Point(0, 97);
            this.dgvColorGroup.Name = "dgvColorGroup";
            this.dgvColorGroup.ReadOnly = true;
            this.dgvColorGroup.RowHeadersWidth = 20;
            this.dgvColorGroup.RowTemplate.Height = 24;
            this.dgvColorGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColorGroup.Size = new System.Drawing.Size(864, 491);
            this.dgvColorGroup.TabIndex = 1;
            this.dgvColorGroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColorGroup_CellDoubleClick);
            this.dgvColorGroup.SelectionChanged += new System.EventHandler(this.dgvColorGroup_SelectionChanged);
            // 
            // colGroupID
            // 
            this.colGroupID.DataPropertyName = "GroupID";
            this.colGroupID.HeaderText = "組別代號";
            this.colGroupID.Name = "colGroupID";
            this.colGroupID.ReadOnly = true;
            // 
            // colColorID
            // 
            this.colColorID.DataPropertyName = "ColorID";
            this.colColorID.HeaderText = "顏色代號";
            this.colColorID.Name = "colColorID";
            this.colColorID.ReadOnly = true;
            // 
            // colColorName
            // 
            this.colColorName.DataPropertyName = "ColorName";
            this.colColorName.HeaderText = "顏色描述";
            this.colColorName.Name = "colColorName";
            this.colColorName.ReadOnly = true;
            this.colColorName.Width = 180;
            // 
            // txtColorIDFind
            // 
            this.txtColorIDFind.Location = new System.Drawing.Point(469, 10);
            this.txtColorIDFind.Name = "txtColorIDFind";
            this.txtColorIDFind.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColorIDFind.Properties.MaxLength = 4;
            this.txtColorIDFind.Size = new System.Drawing.Size(100, 20);
            this.txtColorIDFind.TabIndex = 3;
            this.txtColorIDFind.Leave += new System.EventHandler(this.txtGroupIDFind_Leave);
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
            // frmProductTypeStdPriceColorGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 588);
            this.Controls.Add(this.txtColorIDFind);
            this.Controls.Add(this.dgvColorGroup);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmProductTypeStdPriceColorGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmProductTypeStdPriceColorGroup";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColorGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorIDFind.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtColorID;
        private DevExpress.XtraEditors.LabelControl lblColorID;
        private DevExpress.XtraEditors.TextEdit txtGroupID;
        private DevExpress.XtraEditors.LabelControl lblGroupID;
        private System.Windows.Forms.ToolStripButton btnAddGroup;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevExpress.XtraEditors.TextEdit txtColorName;
        private System.Windows.Forms.DataGridView dgvColorGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorName;
        private DevExpress.XtraEditors.TextEdit txtColorIDFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnAddColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}