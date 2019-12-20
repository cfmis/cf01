namespace cf01.ReportForm
{
    partial class frmEagraveProduct 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEagraveProduct));
            this.label6 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtDat2 = new DevExpress.XtraEditors.DateEdit();
            this.txtDat1 = new DevExpress.XtraEditors.DateEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVESET = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNEXCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvDetails1 = new System.Windows.Forms.DataGridView();
            this.dept_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jo_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.work_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_work = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.process_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdobDetails = new System.Windows.Forms.RadioButton();
            this.rdobTotal = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDept_id = new DevExpress.XtraEditors.TextEdit();
            this.dgvDetails2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Machine_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat1.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails2)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 12);
            this.label6.TabIndex = 137;
            this.label6.Text = "--";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(7, 43);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(67, 13);
            this.lblDate.TabIndex = 136;
            this.lblDate.Text = "生產日期";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDat2
            // 
            this.txtDat2.EditValue = null;
            this.txtDat2.EnterMoveNextControl = true;
            this.txtDat2.Location = new System.Drawing.Point(276, 39);
            this.txtDat2.Name = "txtDat2";
            this.txtDat2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDat2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDat2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDat2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtDat2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDat2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDat2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDat2.Size = new System.Drawing.Size(156, 22);
            this.txtDat2.TabIndex = 2;
            this.txtDat2.Tag = "2";
            // 
            // txtDat1
            // 
            this.txtDat1.EditValue = null;
            this.txtDat1.EnterMoveNextControl = true;
            this.txtDat1.Location = new System.Drawing.Point(82, 39);
            this.txtDat1.Name = "txtDat1";
            this.txtDat1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDat1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDat1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDat1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtDat1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDat1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDat1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDat1.Size = new System.Drawing.Size(156, 22);
            this.txtDat1.TabIndex = 1;
            this.txtDat1.Tag = "2";
            this.txtDat1.Leave += new System.EventHandler(this.txtDat1_Leave);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNCANCEL,
            this.toolStripSeparator4,
            this.BTNFIND,
            this.toolStripSeparator8,
            this.toolStripSeparator9,
            this.BTNSAVESET,
            this.toolStripSeparator3,
            this.BTNEXCEL,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1005, 38);
            this.toolStrip1.TabIndex = 140;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.AutoSize = false;
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
            // BTNCANCEL
            // 
            this.BTNCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNCANCEL.Image")));
            this.BTNCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCANCEL.Name = "BTNCANCEL";
            this.BTNCANCEL.Size = new System.Drawing.Size(49, 35);
            this.BTNCANCEL.Text = "重置(&U)";
            this.BTNCANCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNCANCEL.Click += new System.EventHandler(this.BTNCANCEL_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(47, 35);
            this.BTNFIND.Text = "查找(&F)";
            this.BTNFIND.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNSAVESET
            // 
            this.BTNSAVESET.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVESET.Image")));
            this.BTNSAVESET.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVESET.Name = "BTNSAVESET";
            this.BTNSAVESET.Size = new System.Drawing.Size(81, 35);
            this.BTNSAVESET.Text = "保存查找條件";
            this.BTNSAVESET.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNSAVESET.ToolTipText = "保存查找條件";
            this.BTNSAVESET.Click += new System.EventHandler(this.BTNSAVESET_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNEXCEL
            // 
            this.BTNEXCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXCEL.Image")));
            this.BTNEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXCEL.Name = "BTNEXCEL";
            this.BTNEXCEL.Size = new System.Drawing.Size(69, 35);
            this.BTNEXCEL.Text = "匯出匯總表";
            this.BTNEXCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNEXCEL.Click += new System.EventHandler(this.BTNEXCEL_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // dgvDetails1
            // 
            this.dgvDetails1.AllowUserToAddRows = false;
            this.dgvDetails1.AllowUserToDeleteRows = false;
            this.dgvDetails1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetails1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dept_id,
            this.jo_date,
            this.work_id,
            this.employer,
            this.type_work,
            this.process_name,
            this.prod_qty});
            this.dgvDetails1.Location = new System.Drawing.Point(5, 114);
            this.dgvDetails1.Name = "dgvDetails1";
            this.dgvDetails1.ReadOnly = true;
            this.dgvDetails1.RowTemplate.Height = 24;
            this.dgvDetails1.Size = new System.Drawing.Size(995, 544);
            this.dgvDetails1.TabIndex = 141;
            // 
            // dept_id
            // 
            this.dept_id.DataPropertyName = "dept_id";
            this.dept_id.HeaderText = "部門";
            this.dept_id.Name = "dept_id";
            this.dept_id.ReadOnly = true;
            this.dept_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dept_id.Width = 80;
            // 
            // jo_date
            // 
            this.jo_date.DataPropertyName = "jo_date";
            this.jo_date.HeaderText = "年月";
            this.jo_date.Name = "jo_date";
            this.jo_date.ReadOnly = true;
            this.jo_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.jo_date.Width = 80;
            // 
            // work_id
            // 
            this.work_id.DataPropertyName = "work_id";
            this.work_id.HeaderText = "工號";
            this.work_id.Name = "work_id";
            this.work_id.ReadOnly = true;
            this.work_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // employer
            // 
            this.employer.DataPropertyName = "employer";
            this.employer.HeaderText = "姓名";
            this.employer.Name = "employer";
            this.employer.ReadOnly = true;
            this.employer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.employer.Width = 120;
            // 
            // type_work
            // 
            this.type_work.DataPropertyName = "type_work";
            this.type_work.HeaderText = "工種代碼";
            this.type_work.Name = "type_work";
            this.type_work.ReadOnly = true;
            this.type_work.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // process_name
            // 
            this.process_name.DataPropertyName = "process_name";
            this.process_name.HeaderText = "工種名稱";
            this.process_name.Name = "process_name";
            this.process_name.ReadOnly = true;
            this.process_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.process_name.Width = 150;
            // 
            // prod_qty
            // 
            this.prod_qty.DataPropertyName = "prod_qty";
            this.prod_qty.HeaderText = "生產數";
            this.prod_qty.Name = "prod_qty";
            this.prod_qty.ReadOnly = true;
            this.prod_qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdobDetails);
            this.panel1.Controls.Add(this.rdobTotal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDept_id);
            this.panel1.Controls.Add(this.txtDat2);
            this.panel1.Controls.Add(this.txtDat1);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(7, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 70);
            this.panel1.TabIndex = 143;
            // 
            // rdobDetails
            // 
            this.rdobDetails.AutoSize = true;
            this.rdobDetails.Location = new System.Drawing.Point(374, 14);
            this.rdobDetails.Name = "rdobDetails";
            this.rdobDetails.Size = new System.Drawing.Size(59, 16);
            this.rdobDetails.TabIndex = 141;
            this.rdobDetails.Text = "明細表";
            this.rdobDetails.UseVisualStyleBackColor = true;
            this.rdobDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rdobDetails_MouseUp);
            // 
            // rdobTotal
            // 
            this.rdobTotal.AutoSize = true;
            this.rdobTotal.Checked = true;
            this.rdobTotal.Location = new System.Drawing.Point(275, 13);
            this.rdobTotal.Name = "rdobTotal";
            this.rdobTotal.Size = new System.Drawing.Size(59, 16);
            this.rdobTotal.TabIndex = 140;
            this.rdobTotal.TabStop = true;
            this.rdobTotal.Text = "匯總表";
            this.rdobTotal.UseVisualStyleBackColor = true;
            this.rdobTotal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rdobTotal_MouseUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 139;
            this.label1.Text = "部 門";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDept_id
            // 
            this.txtDept_id.EditValue = "";
            this.txtDept_id.EnterMoveNextControl = true;
            this.txtDept_id.Location = new System.Drawing.Point(82, 8);
            this.txtDept_id.Name = "txtDept_id";
            this.txtDept_id.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDept_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDept_id.Properties.MaxLength = 3;
            this.txtDept_id.Size = new System.Drawing.Size(156, 22);
            this.txtDept_id.TabIndex = 0;
            // 
            // dgvDetails2
            // 
            this.dgvDetails2.AllowUserToAddRows = false;
            this.dgvDetails2.AllowUserToDeleteRows = false;
            this.dgvDetails2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetails2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.id,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.Machine_id});
            this.dgvDetails2.Location = new System.Drawing.Point(5, 116);
            this.dgvDetails2.Name = "dgvDetails2";
            this.dgvDetails2.ReadOnly = true;
            this.dgvDetails2.RowTemplate.Height = 24;
            this.dgvDetails2.Size = new System.Drawing.Size(995, 540);
            this.dgvDetails2.TabIndex = 144;
            this.dgvDetails2.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "oi_date";
            this.dataGridViewTextBoxColumn1.HeaderText = "年度";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "頁數";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "total_hkd";
            this.dataGridViewTextBoxColumn3.HeaderText = "金額(HKD)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "頁數";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "dept_id";
            this.dataGridViewTextBoxColumn5.HeaderText = "部門";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn6.HeaderText = "貨品編號";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "prod_qty";
            this.dataGridViewTextBoxColumn7.HeaderText = "生產件數";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "prod_qty";
            this.dataGridViewTextBoxColumn15.HeaderText = "生產數";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "dept_id";
            this.dataGridViewTextBoxColumn8.HeaderText = "部門";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "單據號";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "jo_date";
            this.dataGridViewTextBoxColumn9.HeaderText = "日期";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "work_id";
            this.dataGridViewTextBoxColumn10.HeaderText = "工號";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "employer";
            this.dataGridViewTextBoxColumn11.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Width = 120;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "type_work";
            this.dataGridViewTextBoxColumn12.HeaderText = "工種代碼";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "process_name";
            this.dataGridViewTextBoxColumn13.HeaderText = "工種名稱";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn13.Width = 150;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "prod_qty";
            this.dataGridViewTextBoxColumn14.HeaderText = "生產數";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Machine_id
            // 
            this.Machine_id.DataPropertyName = "Machine_id";
            this.Machine_id.HeaderText = "設備編號";
            this.Machine_id.Name = "Machine_id";
            this.Machine_id.ReadOnly = true;
            this.Machine_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmEagraveProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 663);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDetails1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvDetails2);
            this.Name = "frmEagraveProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEagraveProduct ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEagraveProduct_FormClosed);
            this.Load += new System.EventHandler(this.frmEagraveProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDat2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat1.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.DateEdit txtDat2;
        private DevExpress.XtraEditors.DateEdit txtDat1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton BTNSAVESET;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BTNEXCEL;
        private System.Windows.Forms.DataGridView dgvDetails1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtDept_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn jo_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn work_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn employer;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_work;
        private System.Windows.Forms.DataGridViewTextBoxColumn process_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_qty;
        private System.Windows.Forms.RadioButton rdobDetails;
        private System.Windows.Forms.RadioButton rdobTotal;
        private System.Windows.Forms.DataGridView dgvDetails2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Machine_id;

        
    }
}