namespace cf01.ReportForm
{
    partial class frmSetProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetProcess));
            this.txtDept = new System.Windows.Forms.TextBox();
            this.txtMat_goods = new System.Windows.Forms.TextBox();
            this.txtGoods_id = new System.Windows.Forms.TextBox();
            this.txtMat_goods_desc = new System.Windows.Forms.TextBox();
            this.txtGoods_id_desc = new System.Windows.Forms.TextBox();
            this.txtDept_Desc = new System.Windows.Forms.TextBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblMat_goods = new System.Windows.Forms.Label();
            this.lblGoods_id = new System.Windows.Forms.Label();
            this.lblProcess = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.txtProcess_desc = new System.Windows.Forms.TextBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNext_dept = new System.Windows.Forms.Label();
            this.txtNext_dept_name = new System.Windows.Forms.TextBox();
            this.txtNext_dept = new System.Windows.Forms.TextBox();
            this.txtAA = new DevExpress.XtraEditors.LookUpEdit();
            this.txtBB = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCC = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDD = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProcess_group_id = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.process_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotate_speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grind_ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grind_stone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.polished_beads = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grind_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(125, 52);
            this.txtDept.Name = "txtDept";
            this.txtDept.ReadOnly = true;
            this.txtDept.Size = new System.Drawing.Size(63, 22);
            this.txtDept.TabIndex = 1;
            // 
            // txtMat_goods
            // 
            this.txtMat_goods.Location = new System.Drawing.Point(125, 79);
            this.txtMat_goods.Name = "txtMat_goods";
            this.txtMat_goods.ReadOnly = true;
            this.txtMat_goods.Size = new System.Drawing.Size(184, 22);
            this.txtMat_goods.TabIndex = 2;
            // 
            // txtGoods_id
            // 
            this.txtGoods_id.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGoods_id.Location = new System.Drawing.Point(125, 135);
            this.txtGoods_id.Name = "txtGoods_id";
            this.txtGoods_id.ReadOnly = true;
            this.txtGoods_id.Size = new System.Drawing.Size(184, 23);
            this.txtGoods_id.TabIndex = 3;
            // 
            // txtMat_goods_desc
            // 
            this.txtMat_goods_desc.Location = new System.Drawing.Point(311, 79);
            this.txtMat_goods_desc.Name = "txtMat_goods_desc";
            this.txtMat_goods_desc.ReadOnly = true;
            this.txtMat_goods_desc.Size = new System.Drawing.Size(509, 22);
            this.txtMat_goods_desc.TabIndex = 4;
            // 
            // txtGoods_id_desc
            // 
            this.txtGoods_id_desc.Location = new System.Drawing.Point(311, 136);
            this.txtGoods_id_desc.Name = "txtGoods_id_desc";
            this.txtGoods_id_desc.ReadOnly = true;
            this.txtGoods_id_desc.Size = new System.Drawing.Size(509, 22);
            this.txtGoods_id_desc.TabIndex = 5;
            // 
            // txtDept_Desc
            // 
            this.txtDept_Desc.Location = new System.Drawing.Point(190, 52);
            this.txtDept_Desc.Name = "txtDept_Desc";
            this.txtDept_Desc.ReadOnly = true;
            this.txtDept_Desc.Size = new System.Drawing.Size(119, 22);
            this.txtDept_Desc.TabIndex = 6;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(92, 57);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(29, 12);
            this.lblDept.TabIndex = 8;
            this.lblDept.Text = "部門";
            // 
            // lblMat_goods
            // 
            this.lblMat_goods.AutoSize = true;
            this.lblMat_goods.Location = new System.Drawing.Point(68, 84);
            this.lblMat_goods.Name = "lblMat_goods";
            this.lblMat_goods.Size = new System.Drawing.Size(53, 12);
            this.lblMat_goods.TabIndex = 24;
            this.lblMat_goods.Text = "貨品編碼";
            // 
            // lblGoods_id
            // 
            this.lblGoods_id.AutoSize = true;
            this.lblGoods_id.Location = new System.Drawing.Point(20, 140);
            this.lblGoods_id.Name = "lblGoods_id";
            this.lblGoods_id.Size = new System.Drawing.Size(101, 12);
            this.lblGoods_id.TabIndex = 25;
            this.lblGoods_id.Text = "下一部門貨品編碼";
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(44, 235);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(77, 12);
            this.lblProcess.TabIndex = 26;
            this.lblProcess.Text = "工序組別代碼";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNSAVE,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(832, 33);
            this.toolStrip1.TabIndex = 27;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.AutoSize = false;
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(65, 30);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // BTNSAVE
            // 
            this.BTNSAVE.AutoSize = false;
            this.BTNSAVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVE.Image")));
            this.BTNSAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVE.Name = "BTNSAVE";
            this.BTNSAVE.Size = new System.Drawing.Size(63, 22);
            this.BTNSAVE.Text = "保存(&S)";
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 33);
            // 
            // txtProcess_desc
            // 
            this.txtProcess_desc.Location = new System.Drawing.Point(311, 257);
            this.txtProcess_desc.Name = "txtProcess_desc";
            this.txtProcess_desc.ReadOnly = true;
            this.txtProcess_desc.Size = new System.Drawing.Size(509, 22);
            this.txtProcess_desc.TabIndex = 28;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.process_id,
            this.cdesc,
            this.rotate_speed,
            this.grind_ratio,
            this.grind_stone,
            this.polished_beads,
            this.grind_time});
            this.dgvDetails.Location = new System.Drawing.Point(125, 288);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 30;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(695, 184);
            this.dgvDetails.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(320, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "* 根據交下部門貨品編號的產品類型,尺寸,顏色帶出工序代碼";
            // 
            // lblNext_dept
            // 
            this.lblNext_dept.AutoSize = true;
            this.lblNext_dept.Location = new System.Drawing.Point(68, 110);
            this.lblNext_dept.Name = "lblNext_dept";
            this.lblNext_dept.Size = new System.Drawing.Size(53, 12);
            this.lblNext_dept.TabIndex = 33;
            this.lblNext_dept.Text = "下一部門";
            // 
            // txtNext_dept_name
            // 
            this.txtNext_dept_name.Location = new System.Drawing.Point(190, 107);
            this.txtNext_dept_name.Name = "txtNext_dept_name";
            this.txtNext_dept_name.ReadOnly = true;
            this.txtNext_dept_name.Size = new System.Drawing.Size(119, 22);
            this.txtNext_dept_name.TabIndex = 32;
            // 
            // txtNext_dept
            // 
            this.txtNext_dept.Location = new System.Drawing.Point(125, 107);
            this.txtNext_dept.Name = "txtNext_dept";
            this.txtNext_dept.ReadOnly = true;
            this.txtNext_dept.Size = new System.Drawing.Size(63, 22);
            this.txtNext_dept.TabIndex = 31;
            // 
            // txtAA
            // 
            this.txtAA.EnterMoveNextControl = true;
            this.txtAA.Location = new System.Drawing.Point(125, 229);
            this.txtAA.Name = "txtAA";
            this.txtAA.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtAA.Properties.Appearance.Options.UseForeColor = true;
            this.txtAA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtAA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAA.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 100, "id")});
            this.txtAA.Properties.NullText = "";
            this.txtAA.Properties.ShowHeader = false;
            this.txtAA.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtAA.Size = new System.Drawing.Size(91, 22);
            this.txtAA.TabIndex = 34;
            this.txtAA.EditValueChanged += new System.EventHandler(this.txtAA_EditValueChanged);
            // 
            // txtBB
            // 
            this.txtBB.EnterMoveNextControl = true;
            this.txtBB.Location = new System.Drawing.Point(218, 229);
            this.txtBB.Name = "txtBB";
            this.txtBB.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtBB.Properties.Appearance.Options.UseForeColor = true;
            this.txtBB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtBB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtBB.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 30, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("size_min", 50, "Size_Min"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("size_max", 50, "Size_Max")});
            this.txtBB.Properties.NullText = "";
            this.txtBB.Properties.PopupFormMinSize = new System.Drawing.Size(130, 0);
            this.txtBB.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtBB.Size = new System.Drawing.Size(91, 22);
            this.txtBB.TabIndex = 35;
            this.txtBB.EditValueChanged += new System.EventHandler(this.txtBB_EditValueChanged);
            // 
            // txtCC
            // 
            this.txtCC.EnterMoveNextControl = true;
            this.txtCC.Location = new System.Drawing.Point(311, 229);
            this.txtCC.Name = "txtCC";
            this.txtCC.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtCC.Properties.Appearance.Options.UseForeColor = true;
            this.txtCC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCC.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 100, "id")});
            this.txtCC.Properties.NullText = "";
            this.txtCC.Properties.ShowHeader = false;
            this.txtCC.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtCC.Size = new System.Drawing.Size(87, 22);
            this.txtCC.TabIndex = 36;
            this.txtCC.EditValueChanged += new System.EventHandler(this.txtCC_EditValueChanged);
            // 
            // txtDD
            // 
            this.txtDD.EditValue = "";
            this.txtDD.EnterMoveNextControl = true;
            this.txtDD.Location = new System.Drawing.Point(400, 229);
            this.txtDD.Name = "txtDD";
            this.txtDD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtDD.Properties.Appearance.Options.UseForeColor = true;
            this.txtDD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDD.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDD.Properties.MaxLength = 1;
            this.txtDD.Size = new System.Drawing.Size(54, 22);
            this.txtDD.TabIndex = 38;
            this.txtDD.EditValueChanged += new System.EventHandler(this.txtDD_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "Prod (AA)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "Size (BB)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "Color (CC)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 42;
            this.label5.Text = "凹凸(A/T)";
            // 
            // txtProcess_group_id
            // 
            this.txtProcess_group_id.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtProcess_group_id.Location = new System.Drawing.Point(125, 257);
            this.txtProcess_group_id.Name = "txtProcess_group_id";
            this.txtProcess_group_id.ReadOnly = true;
            this.txtProcess_group_id.Size = new System.Drawing.Size(184, 23);
            this.txtProcess_group_id.TabIndex = 43;
            this.txtProcess_group_id.TextChanged += new System.EventHandler(this.txtProcess_group_id_TextChanged);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(125, 164);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(695, 42);
            this.txtRemark.TabIndex = 44;
            this.txtRemark.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 45;
            this.label6.Text = "工序備注";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "process_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "工序";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 55;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "cdesc";
            this.dataGridViewTextBoxColumn2.HeaderText = "工序名稱";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 110;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "rotate_speed";
            this.dataGridViewTextBoxColumn3.HeaderText = "轉速";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "grind_ratio";
            this.dataGridViewTextBoxColumn4.HeaderText = "水_磁力針_產品_拋光劑";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 160;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "grind_stone";
            this.dataGridViewTextBoxColumn5.HeaderText = "材料1";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "polished_beads";
            this.dataGridViewTextBoxColumn6.HeaderText = "材料2";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "grind_time";
            this.dataGridViewTextBoxColumn7.HeaderText = "時間";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // process_id
            // 
            this.process_id.DataPropertyName = "process_id";
            this.process_id.HeaderText = "工序";
            this.process_id.Name = "process_id";
            this.process_id.ReadOnly = true;
            this.process_id.Width = 55;
            // 
            // cdesc
            // 
            this.cdesc.DataPropertyName = "cdesc";
            this.cdesc.HeaderText = "工序名稱";
            this.cdesc.Name = "cdesc";
            this.cdesc.ReadOnly = true;
            this.cdesc.Width = 110;
            // 
            // rotate_speed
            // 
            this.rotate_speed.DataPropertyName = "rotate_speed";
            this.rotate_speed.HeaderText = "轉速";
            this.rotate_speed.Name = "rotate_speed";
            this.rotate_speed.ReadOnly = true;
            this.rotate_speed.Width = 60;
            // 
            // grind_ratio
            // 
            this.grind_ratio.DataPropertyName = "grind_ratio";
            this.grind_ratio.HeaderText = "水_磁力針_產品_拋光劑";
            this.grind_ratio.Name = "grind_ratio";
            this.grind_ratio.ReadOnly = true;
            this.grind_ratio.Width = 160;
            // 
            // grind_stone
            // 
            this.grind_stone.DataPropertyName = "grind_stone";
            this.grind_stone.HeaderText = "材料1";
            this.grind_stone.Name = "grind_stone";
            this.grind_stone.ReadOnly = true;
            this.grind_stone.Width = 60;
            // 
            // polished_beads
            // 
            this.polished_beads.DataPropertyName = "polished_beads";
            this.polished_beads.HeaderText = "材料2";
            this.polished_beads.Name = "polished_beads";
            this.polished_beads.ReadOnly = true;
            this.polished_beads.Width = 60;
            // 
            // grind_time
            // 
            this.grind_time.DataPropertyName = "grind_time";
            this.grind_time.HeaderText = "時間";
            this.grind_time.Name = "grind_time";
            this.grind_time.ReadOnly = true;
            this.grind_time.Width = 80;
            // 
            // frmSetProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 477);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtProcess_group_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDD);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.txtBB);
            this.Controls.Add(this.txtAA);
            this.Controls.Add(this.lblNext_dept);
            this.Controls.Add(this.txtNext_dept_name);
            this.Controls.Add(this.txtNext_dept);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.txtProcess_desc);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.lblGoods_id);
            this.Controls.Add(this.lblMat_goods);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.txtDept_Desc);
            this.Controls.Add(this.txtGoods_id_desc);
            this.Controls.Add(this.txtMat_goods_desc);
            this.Controls.Add(this.txtGoods_id);
            this.Controls.Add(this.txtMat_goods);
            this.Controls.Add(this.txtDept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmSetProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSetProcess";
            this.Load += new System.EventHandler(this.frmSetProcess_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDD.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.TextBox txtMat_goods;
        private System.Windows.Forms.TextBox txtGoods_id;
        private System.Windows.Forms.TextBox txtMat_goods_desc;
        private System.Windows.Forms.TextBox txtGoods_id_desc;
        private System.Windows.Forms.TextBox txtDept_Desc;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblMat_goods;
        private System.Windows.Forms.Label lblGoods_id;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.TextBox txtProcess_desc;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn process_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotate_speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn grind_ratio;
        private System.Windows.Forms.DataGridViewTextBoxColumn grind_stone;
        private System.Windows.Forms.DataGridViewTextBoxColumn polished_beads;
        private System.Windows.Forms.DataGridViewTextBoxColumn grind_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNext_dept;
        private System.Windows.Forms.TextBox txtNext_dept_name;
        private System.Windows.Forms.TextBox txtNext_dept;
        private DevExpress.XtraEditors.LookUpEdit txtAA;
        private DevExpress.XtraEditors.LookUpEdit txtBB;
        private DevExpress.XtraEditors.LookUpEdit txtCC;
        private DevExpress.XtraEditors.TextEdit txtDD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProcess_group_id;
        private System.Windows.Forms.RichTextBox txtRemark;
        private System.Windows.Forms.Label label6;
    }
}