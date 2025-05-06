namespace cf01.Forms
{
    partial class frmMoScheduleDepGroup
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
            this.lueDepGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDepGroup = new System.Windows.Forms.Label();
            this.txtPrdMo = new DevExpress.XtraEditors.TextEdit();
            this.lblPrdMo = new DevExpress.XtraEditors.LabelControl();
            this.txtPrdItem = new DevExpress.XtraEditors.TextEdit();
            this.lblPrdItem = new DevExpress.XtraEditors.LabelControl();
            this.btnConf = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colMatCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatCdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdMo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lueDepGroup
            // 
            this.lueDepGroup.EditValue = "";
            this.lueDepGroup.Location = new System.Drawing.Point(86, 219);
            this.lueDepGroup.Name = "lueDepGroup";
            this.lueDepGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDepGroup.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueDepGroup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("grp_code", 40, "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("grp_cdesc", 60, "描述")});
            this.lueDepGroup.Properties.NullText = "";
            this.lueDepGroup.Size = new System.Drawing.Size(121, 20);
            this.lueDepGroup.TabIndex = 25;
            // 
            // lblDepGroup
            // 
            this.lblDepGroup.AutoSize = true;
            this.lblDepGroup.Location = new System.Drawing.Point(24, 221);
            this.lblDepGroup.Name = "lblDepGroup";
            this.lblDepGroup.Size = new System.Drawing.Size(56, 12);
            this.lblDepGroup.TabIndex = 26;
            this.lblDepGroup.Text = "生產車間:";
            // 
            // txtPrdMo
            // 
            this.txtPrdMo.Location = new System.Drawing.Point(86, 28);
            this.txtPrdMo.Name = "txtPrdMo";
            this.txtPrdMo.Properties.ReadOnly = true;
            this.txtPrdMo.Size = new System.Drawing.Size(203, 20);
            this.txtPrdMo.TabIndex = 27;
            // 
            // lblPrdMo
            // 
            this.lblPrdMo.Location = new System.Drawing.Point(28, 31);
            this.lblPrdMo.Name = "lblPrdMo";
            this.lblPrdMo.Size = new System.Drawing.Size(52, 14);
            this.lblPrdMo.TabIndex = 28;
            this.lblPrdMo.Text = "制單編號:";
            // 
            // txtPrdItem
            // 
            this.txtPrdItem.Location = new System.Drawing.Point(86, 54);
            this.txtPrdItem.Name = "txtPrdItem";
            this.txtPrdItem.Properties.ReadOnly = true;
            this.txtPrdItem.Size = new System.Drawing.Size(203, 20);
            this.txtPrdItem.TabIndex = 27;
            // 
            // lblPrdItem
            // 
            this.lblPrdItem.Location = new System.Drawing.Point(28, 57);
            this.lblPrdItem.Name = "lblPrdItem";
            this.lblPrdItem.Size = new System.Drawing.Size(52, 14);
            this.lblPrdItem.TabIndex = 28;
            this.lblPrdItem.Text = "物料編號:";
            // 
            // btnConf
            // 
            this.btnConf.Location = new System.Drawing.Point(193, 260);
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(75, 23);
            this.btnConf.TabIndex = 29;
            this.btnConf.Text = "確定(&C)";
            this.btnConf.Click += new System.EventHandler(this.btnConf_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(86, 260);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 30;
            this.btnExit.Text = "關閉(&X)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
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
            this.colMatCode,
            this.colMatCdesc});
            this.dgvDetails.Location = new System.Drawing.Point(86, 84);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 25;
            this.dgvDetails.Size = new System.Drawing.Size(483, 123);
            this.dgvDetails.TabIndex = 31;
            // 
            // colMatCode
            // 
            this.colMatCode.DataPropertyName = "materiel_id";
            this.colMatCode.HeaderText = "原料編號";
            this.colMatCode.Name = "colMatCode";
            this.colMatCode.ReadOnly = true;
            this.colMatCode.Width = 140;
            // 
            // colMatCdesc
            // 
            this.colMatCdesc.DataPropertyName = "goods_name";
            this.colMatCdesc.HeaderText = "原料描述";
            this.colMatCdesc.Name = "colMatCdesc";
            this.colMatCdesc.ReadOnly = true;
            this.colMatCdesc.Width = 300;
            // 
            // frmMoScheduleDepGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 347);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConf);
            this.Controls.Add(this.lblPrdItem);
            this.Controls.Add(this.lblPrdMo);
            this.Controls.Add(this.txtPrdItem);
            this.Controls.Add(this.txtPrdMo);
            this.Controls.Add(this.lueDepGroup);
            this.Controls.Add(this.lblDepGroup);
            this.Name = "frmMoScheduleDepGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMoScheduleDepGroup";
            this.Load += new System.EventHandler(this.frmMoScheduleDepGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueDepGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdMo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LookUpEdit lueDepGroup;
        private System.Windows.Forms.Label lblDepGroup;
        private DevExpress.XtraEditors.TextEdit txtPrdMo;
        private DevExpress.XtraEditors.LabelControl lblPrdMo;
        private DevExpress.XtraEditors.TextEdit txtPrdItem;
        private DevExpress.XtraEditors.LabelControl lblPrdItem;
        private DevExpress.XtraEditors.SimpleButton btnConf;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatCdesc;
    }
}