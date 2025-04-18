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
            this.lblWorkIn1 = new DevExpress.XtraEditors.LabelControl();
            this.txtWorkIn1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtWorkOut1 = new DevExpress.XtraEditors.TextEdit();
            this.lblWorkIn2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtWorkIn2 = new DevExpress.XtraEditors.TextEdit();
            this.txtWorkOut2 = new DevExpress.XtraEditors.TextEdit();
            this.lblWorkIn3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtWorkIn3 = new DevExpress.XtraEditors.TextEdit();
            this.txtWorkOut3 = new DevExpress.XtraEditors.TextEdit();
            this.lblBreakIn3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtBreakIn3 = new DevExpress.XtraEditors.TextEdit();
            this.txtBreakOut3 = new DevExpress.XtraEditors.TextEdit();
            this.lblBreakIn4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtBreakIn4 = new DevExpress.XtraEditors.TextEdit();
            this.txtBreakOut4 = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartPrdTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoonBreak.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfternoonBreak.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEveningBreak.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkIn1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkOut1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkIn2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkOut2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkIn3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkOut3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakIn3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakOut3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakIn4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakOut4.Properties)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(580, 41);
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
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
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
            this.lblPrd_dept.Location = new System.Drawing.Point(36, 63);
            this.lblPrd_dept.Name = "lblPrd_dept";
            this.lblPrd_dept.Size = new System.Drawing.Size(67, 14);
            this.lblPrd_dept.TabIndex = 26;
            this.lblPrd_dept.Text = "生產部門:";
            // 
            // cmbFindDep
            // 
            this.cmbFindDep.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbFindDep.FormattingEnabled = true;
            this.cmbFindDep.Location = new System.Drawing.Point(114, 60);
            this.cmbFindDep.Name = "cmbFindDep";
            this.cmbFindDep.Size = new System.Drawing.Size(100, 21);
            this.cmbFindDep.TabIndex = 27;
            this.cmbFindDep.Leave += new System.EventHandler(this.cmbFindDep_Leave);
            // 
            // lblStartPrdTime
            // 
            this.lblStartPrdTime.Location = new System.Drawing.Point(27, 90);
            this.lblStartPrdTime.Name = "lblStartPrdTime";
            this.lblStartPrdTime.Size = new System.Drawing.Size(76, 14);
            this.lblStartPrdTime.TabIndex = 28;
            this.lblStartPrdTime.Text = "開始生產時間:";
            // 
            // txtStartPrdTime
            // 
            this.txtStartPrdTime.EditValue = "";
            this.txtStartPrdTime.Location = new System.Drawing.Point(114, 87);
            this.txtStartPrdTime.Name = "txtStartPrdTime";
            this.txtStartPrdTime.Properties.Mask.EditMask = "99:99";
            this.txtStartPrdTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtStartPrdTime.Size = new System.Drawing.Size(100, 20);
            this.txtStartPrdTime.TabIndex = 29;
            // 
            // lblNoonBreak
            // 
            this.lblNoonBreak.Location = new System.Drawing.Point(346, 117);
            this.lblNoonBreak.Name = "lblNoonBreak";
            this.lblNoonBreak.Size = new System.Drawing.Size(76, 14);
            this.lblNoonBreak.TabIndex = 28;
            this.lblNoonBreak.Text = "中午下班時間:";
            // 
            // txtNoonBreak
            // 
            this.txtNoonBreak.EditValue = "";
            this.txtNoonBreak.Location = new System.Drawing.Point(433, 114);
            this.txtNoonBreak.Name = "txtNoonBreak";
            this.txtNoonBreak.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNoonBreak.Size = new System.Drawing.Size(100, 20);
            this.txtNoonBreak.TabIndex = 29;
            // 
            // lblAfternoonBreak
            // 
            this.lblAfternoonBreak.Location = new System.Drawing.Point(346, 143);
            this.lblAfternoonBreak.Name = "lblAfternoonBreak";
            this.lblAfternoonBreak.Size = new System.Drawing.Size(76, 14);
            this.lblAfternoonBreak.TabIndex = 28;
            this.lblAfternoonBreak.Text = "下午下班時間:";
            // 
            // txtAfternoonBreak
            // 
            this.txtAfternoonBreak.EditValue = "";
            this.txtAfternoonBreak.Location = new System.Drawing.Point(433, 140);
            this.txtAfternoonBreak.Name = "txtAfternoonBreak";
            this.txtAfternoonBreak.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAfternoonBreak.Size = new System.Drawing.Size(100, 20);
            this.txtAfternoonBreak.TabIndex = 29;
            // 
            // lblEveningBreak
            // 
            this.lblEveningBreak.Location = new System.Drawing.Point(346, 195);
            this.lblEveningBreak.Name = "lblEveningBreak";
            this.lblEveningBreak.Size = new System.Drawing.Size(76, 14);
            this.lblEveningBreak.TabIndex = 28;
            this.lblEveningBreak.Text = "晚上下班時間:";
            // 
            // txtEveningBreak
            // 
            this.txtEveningBreak.EditValue = "";
            this.txtEveningBreak.Location = new System.Drawing.Point(433, 192);
            this.txtEveningBreak.Name = "txtEveningBreak";
            this.txtEveningBreak.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtEveningBreak.Size = new System.Drawing.Size(100, 20);
            this.txtEveningBreak.TabIndex = 29;
            // 
            // lblWorkIn1
            // 
            this.lblWorkIn1.Location = new System.Drawing.Point(51, 117);
            this.lblWorkIn1.Name = "lblWorkIn1";
            this.lblWorkIn1.Size = new System.Drawing.Size(52, 14);
            this.lblWorkIn1.TabIndex = 28;
            this.lblWorkIn1.Text = "上午上班:";
            // 
            // txtWorkIn1
            // 
            this.txtWorkIn1.EditValue = "";
            this.txtWorkIn1.Location = new System.Drawing.Point(114, 114);
            this.txtWorkIn1.Name = "txtWorkIn1";
            this.txtWorkIn1.Properties.DisplayFormat.FormatString = "99:99";
            this.txtWorkIn1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtWorkIn1.Properties.EditFormat.FormatString = "99:99";
            this.txtWorkIn1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtWorkIn1.Properties.Mask.EditMask = "99:99";
            this.txtWorkIn1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtWorkIn1.Size = new System.Drawing.Size(100, 20);
            this.txtWorkIn1.TabIndex = 29;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(220, 117);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(9, 14);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "~";
            // 
            // txtWorkOut1
            // 
            this.txtWorkOut1.EditValue = "";
            this.txtWorkOut1.Location = new System.Drawing.Point(235, 114);
            this.txtWorkOut1.Name = "txtWorkOut1";
            this.txtWorkOut1.Properties.DisplayFormat.FormatString = "99:99";
            this.txtWorkOut1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtWorkOut1.Properties.Mask.EditMask = "99:99";
            this.txtWorkOut1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtWorkOut1.Size = new System.Drawing.Size(100, 20);
            this.txtWorkOut1.TabIndex = 29;
            // 
            // lblWorkIn2
            // 
            this.lblWorkIn2.Location = new System.Drawing.Point(51, 143);
            this.lblWorkIn2.Name = "lblWorkIn2";
            this.lblWorkIn2.Size = new System.Drawing.Size(52, 14);
            this.lblWorkIn2.TabIndex = 28;
            this.lblWorkIn2.Text = "下午上班:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(220, 143);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(9, 14);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "~";
            // 
            // txtWorkIn2
            // 
            this.txtWorkIn2.EditValue = "";
            this.txtWorkIn2.Location = new System.Drawing.Point(114, 140);
            this.txtWorkIn2.Name = "txtWorkIn2";
            this.txtWorkIn2.Properties.DisplayFormat.FormatString = "99:99";
            this.txtWorkIn2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtWorkIn2.Properties.Mask.EditMask = "99:99";
            this.txtWorkIn2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtWorkIn2.Size = new System.Drawing.Size(100, 20);
            this.txtWorkIn2.TabIndex = 29;
            // 
            // txtWorkOut2
            // 
            this.txtWorkOut2.EditValue = "";
            this.txtWorkOut2.Location = new System.Drawing.Point(235, 140);
            this.txtWorkOut2.Name = "txtWorkOut2";
            this.txtWorkOut2.Properties.DisplayFormat.FormatString = "99:99";
            this.txtWorkOut2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtWorkOut2.Properties.Mask.EditMask = "99:99";
            this.txtWorkOut2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtWorkOut2.Size = new System.Drawing.Size(100, 20);
            this.txtWorkOut2.TabIndex = 29;
            // 
            // lblWorkIn3
            // 
            this.lblWorkIn3.Location = new System.Drawing.Point(51, 169);
            this.lblWorkIn3.Name = "lblWorkIn3";
            this.lblWorkIn3.Size = new System.Drawing.Size(52, 14);
            this.lblWorkIn3.TabIndex = 28;
            this.lblWorkIn3.Text = "晚上上班:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(220, 169);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(9, 14);
            this.labelControl5.TabIndex = 28;
            this.labelControl5.Text = "~";
            // 
            // txtWorkIn3
            // 
            this.txtWorkIn3.EditValue = "";
            this.txtWorkIn3.Location = new System.Drawing.Point(114, 166);
            this.txtWorkIn3.Name = "txtWorkIn3";
            this.txtWorkIn3.Properties.DisplayFormat.FormatString = "99:99";
            this.txtWorkIn3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtWorkIn3.Properties.Mask.EditMask = "99:99";
            this.txtWorkIn3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtWorkIn3.Size = new System.Drawing.Size(100, 20);
            this.txtWorkIn3.TabIndex = 29;
            // 
            // txtWorkOut3
            // 
            this.txtWorkOut3.EditValue = "";
            this.txtWorkOut3.Location = new System.Drawing.Point(235, 166);
            this.txtWorkOut3.Name = "txtWorkOut3";
            this.txtWorkOut3.Properties.DisplayFormat.FormatString = "99:99";
            this.txtWorkOut3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtWorkOut3.Properties.Mask.EditMask = "99:99";
            this.txtWorkOut3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtWorkOut3.Size = new System.Drawing.Size(100, 20);
            this.txtWorkOut3.TabIndex = 29;
            // 
            // lblBreakIn3
            // 
            this.lblBreakIn3.Location = new System.Drawing.Point(51, 195);
            this.lblBreakIn3.Name = "lblBreakIn3";
            this.lblBreakIn3.Size = new System.Drawing.Size(52, 14);
            this.lblBreakIn3.TabIndex = 28;
            this.lblBreakIn3.Text = "晚上下班:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(220, 195);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(9, 14);
            this.labelControl7.TabIndex = 28;
            this.labelControl7.Text = "~";
            // 
            // txtBreakIn3
            // 
            this.txtBreakIn3.EditValue = "";
            this.txtBreakIn3.Location = new System.Drawing.Point(114, 192);
            this.txtBreakIn3.Name = "txtBreakIn3";
            this.txtBreakIn3.Properties.DisplayFormat.FormatString = "99:99";
            this.txtBreakIn3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtBreakIn3.Properties.Mask.EditMask = "99:99";
            this.txtBreakIn3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtBreakIn3.Size = new System.Drawing.Size(100, 20);
            this.txtBreakIn3.TabIndex = 29;
            // 
            // txtBreakOut3
            // 
            this.txtBreakOut3.EditValue = "";
            this.txtBreakOut3.Location = new System.Drawing.Point(235, 192);
            this.txtBreakOut3.Name = "txtBreakOut3";
            this.txtBreakOut3.Properties.DisplayFormat.FormatString = "99:99";
            this.txtBreakOut3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtBreakOut3.Properties.Mask.EditMask = "99:99";
            this.txtBreakOut3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtBreakOut3.Size = new System.Drawing.Size(100, 20);
            this.txtBreakOut3.TabIndex = 29;
            // 
            // lblBreakIn4
            // 
            this.lblBreakIn4.Location = new System.Drawing.Point(51, 221);
            this.lblBreakIn4.Name = "lblBreakIn4";
            this.lblBreakIn4.Size = new System.Drawing.Size(52, 14);
            this.lblBreakIn4.TabIndex = 28;
            this.lblBreakIn4.Text = "夜間下班:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(220, 221);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(9, 14);
            this.labelControl9.TabIndex = 28;
            this.labelControl9.Text = "~";
            // 
            // txtBreakIn4
            // 
            this.txtBreakIn4.EditValue = "";
            this.txtBreakIn4.Location = new System.Drawing.Point(114, 218);
            this.txtBreakIn4.Name = "txtBreakIn4";
            this.txtBreakIn4.Properties.DisplayFormat.FormatString = "99:99";
            this.txtBreakIn4.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtBreakIn4.Properties.Mask.EditMask = "99:99";
            this.txtBreakIn4.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtBreakIn4.Size = new System.Drawing.Size(100, 20);
            this.txtBreakIn4.TabIndex = 29;
            // 
            // txtBreakOut4
            // 
            this.txtBreakOut4.EditValue = "";
            this.txtBreakOut4.Location = new System.Drawing.Point(235, 218);
            this.txtBreakOut4.Name = "txtBreakOut4";
            this.txtBreakOut4.Properties.DisplayFormat.FormatString = "99:99";
            this.txtBreakOut4.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtBreakOut4.Properties.Mask.EditMask = "99:99";
            this.txtBreakOut4.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtBreakOut4.Size = new System.Drawing.Size(100, 20);
            this.txtBreakOut4.TabIndex = 29;
            // 
            // frmMoScheduleBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 303);
            this.Controls.Add(this.txtEveningBreak);
            this.Controls.Add(this.lblEveningBreak);
            this.Controls.Add(this.txtAfternoonBreak);
            this.Controls.Add(this.lblAfternoonBreak);
            this.Controls.Add(this.txtBreakOut4);
            this.Controls.Add(this.txtBreakIn4);
            this.Controls.Add(this.txtBreakOut3);
            this.Controls.Add(this.txtBreakIn3);
            this.Controls.Add(this.txtWorkOut3);
            this.Controls.Add(this.txtWorkIn3);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.txtWorkOut2);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtWorkIn2);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lblBreakIn4);
            this.Controls.Add(this.txtWorkOut1);
            this.Controls.Add(this.lblBreakIn3);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lblWorkIn3);
            this.Controls.Add(this.txtWorkIn1);
            this.Controls.Add(this.lblWorkIn2);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblWorkIn1);
            this.Controls.Add(this.txtNoonBreak);
            this.Controls.Add(this.lblNoonBreak);
            this.Controls.Add(this.txtStartPrdTime);
            this.Controls.Add(this.lblStartPrdTime);
            this.Controls.Add(this.lblPrd_dept);
            this.Controls.Add(this.cmbFindDep);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "frmMoScheduleBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMoScheduleBase";
            this.Load += new System.EventHandler(this.frmMoScheduleBase_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartPrdTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoonBreak.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfternoonBreak.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEveningBreak.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkIn1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkOut1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkIn2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkOut2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkIn3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkOut3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakIn3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakOut3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakIn4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakOut4.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblWorkIn1;
        private DevExpress.XtraEditors.TextEdit txtWorkIn1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtWorkOut1;
        private DevExpress.XtraEditors.LabelControl lblWorkIn2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtWorkIn2;
        private DevExpress.XtraEditors.TextEdit txtWorkOut2;
        private DevExpress.XtraEditors.LabelControl lblWorkIn3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtWorkIn3;
        private DevExpress.XtraEditors.TextEdit txtWorkOut3;
        private DevExpress.XtraEditors.LabelControl lblBreakIn3;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtBreakIn3;
        private DevExpress.XtraEditors.TextEdit txtBreakOut3;
        private DevExpress.XtraEditors.LabelControl lblBreakIn4;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtBreakIn4;
        private DevExpress.XtraEditors.TextEdit txtBreakOut4;
    }
}