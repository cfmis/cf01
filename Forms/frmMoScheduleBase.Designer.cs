namespace cf01.Forms
{
    partial class frmMoScheduleBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoScheduleBase));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPrd_dept = new System.Windows.Forms.Label();
            this.cmbFindDep = new System.Windows.Forms.ComboBox();
            this.lblStartPrdTime = new DevExpress.XtraEditors.LabelControl();
            this.txtStartPrdTime = new DevExpress.XtraEditors.TextEdit();
            this.lblNoonBreak = new DevExpress.XtraEditors.LabelControl();
            this.txtNoonBreak = new DevExpress.XtraEditors.TextEdit();
            this.lblAfternoonBreak = new DevExpress.XtraEditors.LabelControl();
            this.txtAfternoonBreak = new DevExpress.XtraEditors.TextEdit();
            this.lblEveningBreak = new DevExpress.XtraEditors.LabelControl();
            this.txtEveningBreak = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartPrdTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoonBreak.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfternoonBreak.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEveningBreak.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator7,
            this.btnFind,
            this.toolStripSeparator9,
            this.btnSave,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1017, 41);
            this.toolStrip1.TabIndex = 9;
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
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 41);
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
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 41);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 35);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // lblPrd_dept
            // 
            this.lblPrd_dept.AutoSize = true;
            this.lblPrd_dept.Location = new System.Drawing.Point(24, 63);
            this.lblPrd_dept.Name = "lblPrd_dept";
            this.lblPrd_dept.Size = new System.Drawing.Size(63, 14);
            this.lblPrd_dept.TabIndex = 26;
            this.lblPrd_dept.Text = "生產部門";
            // 
            // cmbFindDep
            // 
            this.cmbFindDep.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbFindDep.FormattingEnabled = true;
            this.cmbFindDep.Location = new System.Drawing.Point(100, 60);
            this.cmbFindDep.Name = "cmbFindDep";
            this.cmbFindDep.Size = new System.Drawing.Size(126, 21);
            this.cmbFindDep.TabIndex = 27;
            this.cmbFindDep.Leave += new System.EventHandler(this.cmbFindDep_Leave);
            // 
            // lblStartPrdTime
            // 
            this.lblStartPrdTime.Location = new System.Drawing.Point(27, 111);
            this.lblStartPrdTime.Name = "lblStartPrdTime";
            this.lblStartPrdTime.Size = new System.Drawing.Size(76, 14);
            this.lblStartPrdTime.TabIndex = 28;
            this.lblStartPrdTime.Text = "開始生產時間:";
            // 
            // txtStartPrdTime
            // 
            this.txtStartPrdTime.EditValue = "";
            this.txtStartPrdTime.Location = new System.Drawing.Point(114, 108);
            this.txtStartPrdTime.Name = "txtStartPrdTime";
            this.txtStartPrdTime.Properties.Mask.EditMask = "99:99";
            this.txtStartPrdTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtStartPrdTime.Size = new System.Drawing.Size(100, 20);
            this.txtStartPrdTime.TabIndex = 29;
            // 
            // lblNoonBreak
            // 
            this.lblNoonBreak.Location = new System.Drawing.Point(232, 111);
            this.lblNoonBreak.Name = "lblNoonBreak";
            this.lblNoonBreak.Size = new System.Drawing.Size(76, 14);
            this.lblNoonBreak.TabIndex = 28;
            this.lblNoonBreak.Text = "中午下班時間:";
            // 
            // txtNoonBreak
            // 
            this.txtNoonBreak.EditValue = "";
            this.txtNoonBreak.Location = new System.Drawing.Point(319, 108);
            this.txtNoonBreak.Name = "txtNoonBreak";
            this.txtNoonBreak.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNoonBreak.Size = new System.Drawing.Size(100, 20);
            this.txtNoonBreak.TabIndex = 29;
            // 
            // lblAfternoonBreak
            // 
            this.lblAfternoonBreak.Location = new System.Drawing.Point(434, 111);
            this.lblAfternoonBreak.Name = "lblAfternoonBreak";
            this.lblAfternoonBreak.Size = new System.Drawing.Size(76, 14);
            this.lblAfternoonBreak.TabIndex = 28;
            this.lblAfternoonBreak.Text = "下午下班時間:";
            // 
            // txtAfternoonBreak
            // 
            this.txtAfternoonBreak.EditValue = "";
            this.txtAfternoonBreak.Location = new System.Drawing.Point(521, 108);
            this.txtAfternoonBreak.Name = "txtAfternoonBreak";
            this.txtAfternoonBreak.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAfternoonBreak.Size = new System.Drawing.Size(100, 20);
            this.txtAfternoonBreak.TabIndex = 29;
            // 
            // lblEveningBreak
            // 
            this.lblEveningBreak.Location = new System.Drawing.Point(638, 111);
            this.lblEveningBreak.Name = "lblEveningBreak";
            this.lblEveningBreak.Size = new System.Drawing.Size(76, 14);
            this.lblEveningBreak.TabIndex = 28;
            this.lblEveningBreak.Text = "晚上下班時間:";
            // 
            // txtEveningBreak
            // 
            this.txtEveningBreak.EditValue = "";
            this.txtEveningBreak.Location = new System.Drawing.Point(725, 108);
            this.txtEveningBreak.Name = "txtEveningBreak";
            this.txtEveningBreak.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtEveningBreak.Size = new System.Drawing.Size(100, 20);
            this.txtEveningBreak.TabIndex = 29;
            // 
            // frmMoScheduleBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 560);
            this.Controls.Add(this.txtEveningBreak);
            this.Controls.Add(this.lblEveningBreak);
            this.Controls.Add(this.txtAfternoonBreak);
            this.Controls.Add(this.lblAfternoonBreak);
            this.Controls.Add(this.txtNoonBreak);
            this.Controls.Add(this.lblNoonBreak);
            this.Controls.Add(this.txtStartPrdTime);
            this.Controls.Add(this.lblStartPrdTime);
            this.Controls.Add(this.lblPrd_dept);
            this.Controls.Add(this.cmbFindDep);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "frmMoScheduleBase";
            this.Text = "frmMoScheduleBase";
            this.Load += new System.EventHandler(this.frmMoScheduleBase_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartPrdTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoonBreak.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfternoonBreak.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEveningBreak.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblPrd_dept;
        private System.Windows.Forms.ComboBox cmbFindDep;
        private DevExpress.XtraEditors.LabelControl lblStartPrdTime;
        private DevExpress.XtraEditors.TextEdit txtStartPrdTime;
        private DevExpress.XtraEditors.LabelControl lblNoonBreak;
        private DevExpress.XtraEditors.TextEdit txtNoonBreak;
        private DevExpress.XtraEditors.LabelControl lblAfternoonBreak;
        private DevExpress.XtraEditors.TextEdit txtAfternoonBreak;
        private DevExpress.XtraEditors.LabelControl lblEveningBreak;
        private DevExpress.XtraEditors.TextEdit txtEveningBreak;
    }
}