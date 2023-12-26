namespace cf01.MM
{
    partial class frmCountGoodsCostFindProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCountGoodsCostFindProcess));
            this.dgvDetails1 = new System.Windows.Forms.DataGridView();
            this.colPrdDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPriceHKD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBaseQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPriceUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtProcessName = new DevExpress.XtraEditors.TextEdit();
            this.lblDepId = new DevExpress.XtraEditors.LabelControl();
            this.lblMaterialId = new DevExpress.XtraEditors.LabelControl();
            this.lblMaterialName = new DevExpress.XtraEditors.LabelControl();
            this.txtDepId = new DevExpress.XtraEditors.TextEdit();
            this.txtProcesslId = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepId.Properties)).BeginInit();
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
            this.colPrdDep,
            this.colProcessID,
            this.colProcessName,
            this.colPrice,
            this.colPriceHKD,
            this.colBaseQty,
            this.colPriceUnit,
            this.Column5});
            this.dgvDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails1.Location = new System.Drawing.Point(0, 108);
            this.dgvDetails1.Name = "dgvDetails1";
            this.dgvDetails1.ReadOnly = true;
            this.dgvDetails1.RowHeadersWidth = 20;
            this.dgvDetails1.RowTemplate.Height = 24;
            this.dgvDetails1.Size = new System.Drawing.Size(1075, 509);
            this.dgvDetails1.TabIndex = 1;
            this.dgvDetails1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails1_CellDoubleClick);
            // 
            // colPrdDep
            // 
            this.colPrdDep.DataPropertyName = "dept_id";
            this.colPrdDep.HeaderText = "部門編號";
            this.colPrdDep.Name = "colPrdDep";
            this.colPrdDep.ReadOnly = true;
            this.colPrdDep.Width = 80;
            // 
            // colProcessID
            // 
            this.colProcessID.DataPropertyName = "process_id";
            this.colProcessID.HeaderText = "工序編號";
            this.colProcessID.Name = "colProcessID";
            this.colProcessID.ReadOnly = true;
            this.colProcessID.Width = 80;
            // 
            // colProcessName
            // 
            this.colProcessName.DataPropertyName = "process_name";
            this.colProcessName.HeaderText = "工序描述";
            this.colProcessName.Name = "colProcessName";
            this.colProcessName.ReadOnly = true;
            this.colProcessName.Width = 160;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "cost_price";
            this.colPrice.HeaderText = "單價";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 80;
            // 
            // colPriceHKD
            // 
            this.colPriceHKD.DataPropertyName = "PriceHKD";
            this.colPriceHKD.HeaderText = "單價(HKD)";
            this.colPriceHKD.Name = "colPriceHKD";
            this.colPriceHKD.ReadOnly = true;
            // 
            // colBaseQty
            // 
            this.colBaseQty.DataPropertyName = "product_qty";
            this.colBaseQty.HeaderText = "基數";
            this.colBaseQty.Name = "colBaseQty";
            this.colBaseQty.ReadOnly = true;
            this.colBaseQty.Width = 80;
            // 
            // colPriceUnit
            // 
            this.colPriceUnit.DataPropertyName = "cost_unit";
            this.colPriceUnit.HeaderText = "單位";
            this.colPriceUnit.Name = "colPriceUnit";
            this.colPriceUnit.ReadOnly = true;
            this.colPriceUnit.Width = 60;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "remark";
            this.Column5.HeaderText = "備註";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtProcessName);
            this.panelControl2.Controls.Add(this.lblDepId);
            this.panelControl2.Controls.Add(this.lblMaterialId);
            this.panelControl2.Controls.Add(this.lblMaterialName);
            this.panelControl2.Controls.Add(this.txtDepId);
            this.panelControl2.Controls.Add(this.txtProcesslId);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 38);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1075, 70);
            this.panelControl2.TabIndex = 5;
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(326, 17);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProcessName.Size = new System.Drawing.Size(353, 20);
            this.txtProcessName.TabIndex = 1;
            // 
            // lblDepId
            // 
            this.lblDepId.Location = new System.Drawing.Point(686, 20);
            this.lblDepId.Name = "lblDepId";
            this.lblDepId.Size = new System.Drawing.Size(52, 14);
            this.lblDepId.TabIndex = 0;
            this.lblDepId.Text = "部門編號:";
            // 
            // lblMaterialId
            // 
            this.lblMaterialId.Location = new System.Drawing.Point(28, 20);
            this.lblMaterialId.Name = "lblMaterialId";
            this.lblMaterialId.Size = new System.Drawing.Size(52, 14);
            this.lblMaterialId.TabIndex = 0;
            this.lblMaterialId.Text = "物料編號:";
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.Location = new System.Drawing.Point(268, 20);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(52, 14);
            this.lblMaterialName.TabIndex = 0;
            this.lblMaterialName.Text = "物料描述:";
            // 
            // txtDepId
            // 
            this.txtDepId.Location = new System.Drawing.Point(744, 17);
            this.txtDepId.Name = "txtDepId";
            this.txtDepId.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDepId.Size = new System.Drawing.Size(177, 20);
            this.txtDepId.TabIndex = 1;
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
            this.toolStrip1.Size = new System.Drawing.Size(1075, 38);
            this.toolStrip1.TabIndex = 3;
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
            // frmCountGoodsCostFindProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 617);
            this.Controls.Add(this.dgvDetails1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCountGoodsCostFindProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCountGoodsCostFindProcess";
            this.Load += new System.EventHandler(this.frmCountGoodsCostFindProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcesslId.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDetails1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtProcessName;
        private DevExpress.XtraEditors.LabelControl lblDepId;
        private DevExpress.XtraEditors.LabelControl lblMaterialId;
        private DevExpress.XtraEditors.LabelControl lblMaterialName;
        private DevExpress.XtraEditors.TextEdit txtDepId;
        private DevExpress.XtraEditors.TextEdit txtProcesslId;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPriceHKD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBaseQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPriceUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}