namespace cf01.MM
{
    partial class frmCountGoodsCostFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCountGoodsCostFind));
            this.dgvDetails1 = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtProcessName = new DevExpress.XtraEditors.TextEdit();
            this.lbID = new DevExpress.XtraEditors.LabelControl();
            this.lblMaterialId = new DevExpress.XtraEditors.LabelControl();
            this.lblMaterialName = new DevExpress.XtraEditors.LabelControl();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.txtProcesslId = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcesslId.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetails1
            // 
            this.dgvDetails1.AllowUserToAddRows = false;
            this.dgvDetails1.ColumnHeadersHeight = 28;
            this.dgvDetails1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colProductID,
            this.colProductName,
            this.colCreateUser,
            this.colCreateTime});
            this.dgvDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails1.Location = new System.Drawing.Point(0, 108);
            this.dgvDetails1.Name = "dgvDetails1";
            this.dgvDetails1.ReadOnly = true;
            this.dgvDetails1.RowHeadersWidth = 20;
            this.dgvDetails1.RowTemplate.Height = 24;
            this.dgvDetails1.Size = new System.Drawing.Size(1035, 507);
            this.dgvDetails1.TabIndex = 6;
            this.dgvDetails1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails1_CellDoubleClick);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "文件編號";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colProductID
            // 
            this.colProductID.DataPropertyName = "ProductID";
            this.colProductID.HeaderText = "產品編號";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Width = 180;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "產品描述";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 260;
            // 
            // colCreateUser
            // 
            this.colCreateUser.DataPropertyName = "CreateUser";
            this.colCreateUser.HeaderText = "建立人";
            this.colCreateUser.Name = "colCreateUser";
            this.colCreateUser.ReadOnly = true;
            this.colCreateUser.Width = 80;
            // 
            // colCreateTime
            // 
            this.colCreateTime.DataPropertyName = "CreateTime";
            this.colCreateTime.HeaderText = "建立日期";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.ReadOnly = true;
            this.colCreateTime.Width = 160;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtProcessName);
            this.panelControl2.Controls.Add(this.lbID);
            this.panelControl2.Controls.Add(this.lblMaterialId);
            this.panelControl2.Controls.Add(this.lblMaterialName);
            this.panelControl2.Controls.Add(this.txtID);
            this.panelControl2.Controls.Add(this.txtProcesslId);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 38);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1035, 70);
            this.panelControl2.TabIndex = 8;
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(326, 17);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProcessName.Size = new System.Drawing.Size(353, 20);
            this.txtProcessName.TabIndex = 1;
            // 
            // lbID
            // 
            this.lbID.Location = new System.Drawing.Point(686, 20);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(52, 14);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "文件編號:";
            // 
            // lblMaterialId
            // 
            this.lblMaterialId.Location = new System.Drawing.Point(28, 20);
            this.lblMaterialId.Name = "lblMaterialId";
            this.lblMaterialId.Size = new System.Drawing.Size(52, 14);
            this.lblMaterialId.TabIndex = 0;
            this.lblMaterialId.Text = "產品編號:";
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.Location = new System.Drawing.Point(268, 20);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(52, 14);
            this.lblMaterialName.TabIndex = 0;
            this.lblMaterialName.Text = "產品描述:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(744, 17);
            this.txtID.Name = "txtID";
            this.txtID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Size = new System.Drawing.Size(177, 20);
            this.txtID.TabIndex = 1;
            // 
            // txtProcesslId
            // 
            this.txtProcesslId.Location = new System.Drawing.Point(86, 17);
            this.txtProcesslId.Name = "txtProcesslId";
            this.txtProcesslId.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProcesslId.Size = new System.Drawing.Size(177, 20);
            this.txtProcesslId.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1035, 38);
            this.toolStrip1.TabIndex = 7;
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "dept_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "部門編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "process_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "工序編號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "process_name";
            this.dataGridViewTextBoxColumn3.HeaderText = "工序描述";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 160;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "cost_price";
            this.dataGridViewTextBoxColumn4.HeaderText = "單價";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PriceHKD";
            this.dataGridViewTextBoxColumn5.HeaderText = "單價(HKD)";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "product_qty";
            this.dataGridViewTextBoxColumn6.HeaderText = "基數";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "cost_unit";
            this.dataGridViewTextBoxColumn7.HeaderText = "單位";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "remark";
            this.dataGridViewTextBoxColumn8.HeaderText = "備註";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // frmCountGoodsCostFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 615);
            this.Controls.Add(this.dgvDetails1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCountGoodsCostFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCountGoodsCostFind";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcesslId.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetails1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtProcessName;
        private DevExpress.XtraEditors.LabelControl lbID;
        private DevExpress.XtraEditors.LabelControl lblMaterialId;
        private DevExpress.XtraEditors.LabelControl lblMaterialName;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.TextEdit txtProcesslId;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
    }
}