namespace cf01.Forms
{
    partial class frmMmFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMmFind));
            this.dgvMmFind = new System.Windows.Forms.DataGridView();
            this.txtDetp_id = new DevExpress.XtraEditors.LookUpEdit();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.BTNOK = new System.Windows.Forms.ToolStripButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrd_item2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrd_item1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMat_code = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrd_code = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtArt_code = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSize_code = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtClr_code = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGoods_name = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkPur = new System.Windows.Forms.CheckBox();
            this.prd_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clr_cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clr_make = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prd_dep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dep_cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMmFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetp_id.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMmFind
            // 
            this.dgvMmFind.AllowUserToAddRows = false;
            this.dgvMmFind.AllowUserToDeleteRows = false;
            this.dgvMmFind.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMmFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMmFind.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prd_item,
            this.item_cdesc,
            this.item_unit,
            this.clr_cdesc,
            this.clr_make,
            this.prd_dep,
            this.dep_cdesc,
            this.modality});
            this.dgvMmFind.Location = new System.Drawing.Point(2, 170);
            this.dgvMmFind.MultiSelect = false;
            this.dgvMmFind.Name = "dgvMmFind";
            this.dgvMmFind.ReadOnly = true;
            this.dgvMmFind.RowTemplate.Height = 24;
            this.dgvMmFind.Size = new System.Drawing.Size(1014, 332);
            this.dgvMmFind.TabIndex = 52;
            this.dgvMmFind.SelectionChanged += new System.EventHandler(this.dgvMmFind_SelectionChanged);
            // 
            // txtDetp_id
            // 
            this.txtDetp_id.EditValue = "";
            this.txtDetp_id.Location = new System.Drawing.Point(103, 34);
            this.txtDetp_id.Name = "txtDetp_id";
            this.txtDetp_id.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDetp_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDetp_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetp_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_id", 80, "部門編號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_cdesc", 150, "部門名稱")});
            this.txtDetp_id.Properties.DropDownRows = 15;
            this.txtDetp_id.Properties.MaxLength = 3;
            this.txtDetp_id.Properties.NullText = "";
            this.txtDetp_id.Properties.PopupFormMinSize = new System.Drawing.Size(230, 0);
            this.txtDetp_id.Properties.PopupWidth = 230;
            this.txtDetp_id.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtDetp_id.Size = new System.Drawing.Size(157, 22);
            this.txtDetp_id.TabIndex = 0;
            this.txtDetp_id.Tag = "2";
            this.txtDetp_id.Click += new System.EventHandler(this.txtDetp_id_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(65, 22);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(63, 22);
            this.BTNFIND.Text = "查詢(&F)";
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // BTNOK
            // 
            this.BTNOK.Image = ((System.Drawing.Image)(resources.GetObject("BTNOK.Image")));
            this.BTNOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNOK.Name = "BTNOK";
            this.BTNOK.Size = new System.Drawing.Size(65, 22);
            this.BTNOK.Text = "確認(&O)";
            this.BTNOK.Click += new System.EventHandler(this.BTNOK_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(28, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 12);
            this.label8.TabIndex = 46;
            this.label8.Text = "部門編號";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "~";
            // 
            // txtPrd_item2
            // 
            this.txtPrd_item2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrd_item2.Location = new System.Drawing.Point(273, 59);
            this.txtPrd_item2.MaxLength = 18;
            this.txtPrd_item2.Name = "txtPrd_item2";
            this.txtPrd_item2.Size = new System.Drawing.Size(157, 22);
            this.txtPrd_item2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(28, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "貨品編號";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrd_item1
            // 
            this.txtPrd_item1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrd_item1.Location = new System.Drawing.Point(103, 59);
            this.txtPrd_item1.MaxLength = 18;
            this.txtPrd_item1.Name = "txtPrd_item1";
            this.txtPrd_item1.Size = new System.Drawing.Size(157, 22);
            this.txtPrd_item1.TabIndex = 1;
            this.txtPrd_item1.Leave += new System.EventHandler(this.txtPrd_item1_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(102, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 32;
            this.label1.Text = "物料類型(1~2位)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMat_code
            // 
            this.txtMat_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMat_code.Location = new System.Drawing.Point(103, 111);
            this.txtMat_code.MaxLength = 2;
            this.txtMat_code.Name = "txtMat_code";
            this.txtMat_code.Size = new System.Drawing.Size(52, 22);
            this.txtMat_code.TabIndex = 3;
            this.txtMat_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNFIND,
            this.toolStripSeparator2,
            this.BTNOK});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1015, 25);
            this.toolStrip1.TabIndex = 30;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(160, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 54;
            this.label2.Text = "產品類型(3~4位)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPrd_code
            // 
            this.txtPrd_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrd_code.Location = new System.Drawing.Point(161, 111);
            this.txtPrd_code.MaxLength = 2;
            this.txtPrd_code.Name = "txtPrd_code";
            this.txtPrd_code.Size = new System.Drawing.Size(52, 22);
            this.txtPrd_code.TabIndex = 4;
            this.txtPrd_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(220, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 24);
            this.label5.TabIndex = 56;
            this.label5.Text = "圖樣編號(5~11位)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtArt_code
            // 
            this.txtArt_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArt_code.Location = new System.Drawing.Point(219, 111);
            this.txtArt_code.MaxLength = 7;
            this.txtArt_code.Name = "txtArt_code";
            this.txtArt_code.Size = new System.Drawing.Size(85, 22);
            this.txtArt_code.TabIndex = 5;
            this.txtArt_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(311, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 25);
            this.label13.TabIndex = 58;
            this.label13.Text = "尺寸(12~14位)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSize_code
            // 
            this.txtSize_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSize_code.Location = new System.Drawing.Point(310, 111);
            this.txtSize_code.MaxLength = 3;
            this.txtSize_code.Name = "txtSize_code";
            this.txtSize_code.Size = new System.Drawing.Size(57, 22);
            this.txtSize_code.TabIndex = 6;
            this.txtSize_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(375, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 25);
            this.label14.TabIndex = 60;
            this.label14.Text = "顏色(15~18位)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtClr_code
            // 
            this.txtClr_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClr_code.Location = new System.Drawing.Point(373, 111);
            this.txtClr_code.MaxLength = 4;
            this.txtClr_code.Name = "txtClr_code";
            this.txtClr_code.Size = new System.Drawing.Size(57, 22);
            this.txtClr_code.TabIndex = 7;
            this.txtClr_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(28, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 12);
            this.label6.TabIndex = 62;
            this.label6.Text = "貨品名稱";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGoods_name
            // 
            this.txtGoods_name.Location = new System.Drawing.Point(103, 137);
            this.txtGoods_name.MaxLength = 50;
            this.txtGoods_name.Name = "txtGoods_name";
            this.txtGoods_name.Size = new System.Drawing.Size(327, 22);
            this.txtGoods_name.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.FillWeight = 180F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Bom ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 180;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn2.FillWeight = 170F;
            this.dataGridViewTextBoxColumn2.HeaderText = "貨品編號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 170;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn3.FillWeight = 200F;
            this.dataGridViewTextBoxColumn3.HeaderText = "貨品名稱";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "dept_id";
            this.dataGridViewTextBoxColumn4.FillWeight = 60F;
            this.dataGridViewTextBoxColumn4.HeaderText = "部門";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "dept_name";
            this.dataGridViewTextBoxColumn5.FillWeight = 130F;
            this.dataGridViewTextBoxColumn5.HeaderText = "部門名稱";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Create_date";
            this.dataGridViewTextBoxColumn6.FillWeight = 55F;
            this.dataGridViewTextBoxColumn6.HeaderText = "建檔日期";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "check_date";
            this.dataGridViewTextBoxColumn7.HeaderText = "批準日期";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // chkPur
            // 
            this.chkPur.AutoSize = true;
            this.chkPur.Enabled = false;
            this.chkPur.Location = new System.Drawing.Point(472, 117);
            this.chkPur.Name = "chkPur";
            this.chkPur.Size = new System.Drawing.Size(96, 16);
            this.chkPur.TabIndex = 64;
            this.chkPur.Text = "只顯示採購件";
            this.chkPur.UseVisualStyleBackColor = true;
            this.chkPur.Visible = false;
            // 
            // prd_item
            // 
            this.prd_item.DataPropertyName = "prd_item";
            this.prd_item.FillWeight = 150F;
            this.prd_item.HeaderText = "貨品編號";
            this.prd_item.Name = "prd_item";
            this.prd_item.ReadOnly = true;
            this.prd_item.Width = 150;
            // 
            // item_cdesc
            // 
            this.item_cdesc.DataPropertyName = "item_cdesc";
            this.item_cdesc.FillWeight = 250F;
            this.item_cdesc.HeaderText = "貨品名稱";
            this.item_cdesc.Name = "item_cdesc";
            this.item_cdesc.ReadOnly = true;
            this.item_cdesc.Width = 250;
            // 
            // item_unit
            // 
            this.item_unit.DataPropertyName = "item_unit";
            this.item_unit.HeaderText = "單位";
            this.item_unit.Name = "item_unit";
            this.item_unit.ReadOnly = true;
            this.item_unit.Width = 55;
            // 
            // clr_cdesc
            // 
            this.clr_cdesc.DataPropertyName = "clr_cdesc";
            this.clr_cdesc.FillWeight = 80F;
            this.clr_cdesc.HeaderText = "顏色名稱";
            this.clr_cdesc.Name = "clr_cdesc";
            this.clr_cdesc.ReadOnly = true;
            this.clr_cdesc.Width = 80;
            // 
            // clr_make
            // 
            this.clr_make.DataPropertyName = "clr_make";
            this.clr_make.HeaderText = "顏色做法";
            this.clr_make.Name = "clr_make";
            this.clr_make.ReadOnly = true;
            this.clr_make.Width = 200;
            // 
            // prd_dep
            // 
            this.prd_dep.DataPropertyName = "prd_dep";
            this.prd_dep.FillWeight = 55F;
            this.prd_dep.HeaderText = "部門";
            this.prd_dep.Name = "prd_dep";
            this.prd_dep.ReadOnly = true;
            this.prd_dep.Width = 55;
            // 
            // dep_cdesc
            // 
            this.dep_cdesc.DataPropertyName = "dep_cdesc";
            this.dep_cdesc.HeaderText = "部門名稱";
            this.dep_cdesc.Name = "dep_cdesc";
            this.dep_cdesc.ReadOnly = true;
            // 
            // modality
            // 
            this.modality.DataPropertyName = "modality";
            this.modality.HeaderText = "管制類型";
            this.modality.Name = "modality";
            this.modality.ReadOnly = true;
            this.modality.Width = 80;
            // 
            // frmMmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 500);
            this.Controls.Add(this.chkPur);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGoods_name);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtClr_code);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSize_code);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtArt_code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrd_code);
            this.Controls.Add(this.dgvMmFind);
            this.Controls.Add(this.txtDetp_id);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrd_item2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrd_item1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMat_code);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMmFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMmFind";
            this.Load += new System.EventHandler(this.frmMmFind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMmFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetp_id.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMmFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DevExpress.XtraEditors.LookUpEdit txtDetp_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripButton BTNOK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrd_item2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrd_item1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMat_code;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrd_code;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtArt_code;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSize_code;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtClr_code;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGoods_name;
        private System.Windows.Forms.CheckBox chkPur;
        private System.Windows.Forms.DataGridViewTextBoxColumn prd_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clr_cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clr_make;
        private System.Windows.Forms.DataGridViewTextBoxColumn prd_dep;
        private System.Windows.Forms.DataGridViewTextBoxColumn dep_cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn modality;
    }
}