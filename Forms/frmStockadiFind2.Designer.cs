namespace cf01.Forms
{
    partial class frmStockadiFind2
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
            System.Windows.Forms.Button btnClear;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockadiFind2));
            System.Windows.Forms.Button btnOk;
            System.Windows.Forms.Button btnSearch;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMo_id = new System.Windows.Forms.TextBox();
            this.lblSales_group = new DevExpress.XtraEditors.LabelControl();
            this.txtGoods_id = new System.Windows.Forms.TextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtLocationId = new System.Windows.Forms.TextBox();
            this.BTNSAVESET1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.location_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carton_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnClear = new System.Windows.Forms.Button();
            btnOk = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(btnClear);
            this.panel2.Controls.Add(btnOk);
            this.panel2.Controls.Add(btnSearch);
            this.panel2.Controls.Add(this.BTNSAVESET1);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(5, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(861, 44);
            this.panel2.TabIndex = 236;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.location_id,
            this.mo_id,
            this.goods_id,
            this.goods_name,
            this.carton_code});
            this.dataGridView1.Location = new System.Drawing.Point(6, 173);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(856, 463);
            this.dataGridView1.TabIndex = 234;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.txtMo_id);
            this.panel1.Controls.Add(this.lblSales_group);
            this.panel1.Controls.Add(this.txtGoods_id);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.txtLocationId);
            this.panel1.Location = new System.Drawing.Point(6, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 115);
            this.panel1.TabIndex = 235;
            // 
            // txtMo_id
            // 
            this.txtMo_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMo_id.Location = new System.Drawing.Point(95, 40);
            this.txtMo_id.MaxLength = 9;
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.Size = new System.Drawing.Size(130, 25);
            this.txtMo_id.TabIndex = 1;
            // 
            // lblSales_group
            // 
            this.lblSales_group.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSales_group.Location = new System.Drawing.Point(40, 77);
            this.lblSales_group.Name = "lblSales_group";
            this.lblSales_group.Size = new System.Drawing.Size(48, 14);
            this.lblSales_group.TabIndex = 213;
            this.lblSales_group.Text = "貨品編號";
            // 
            // txtGoods_id
            // 
            this.txtGoods_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGoods_id.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGoods_id.Location = new System.Drawing.Point(95, 73);
            this.txtGoods_id.MaxLength = 20;
            this.txtGoods_id.Name = "txtGoods_id";
            this.txtGoods_id.Size = new System.Drawing.Size(260, 25);
            this.txtGoods_id.TabIndex = 2;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(40, 10);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 222;
            this.labelControl5.Text = "倉庫編號";
            // 
            // txtLocationId
            // 
            this.txtLocationId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocationId.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLocationId.Location = new System.Drawing.Point(95, 7);
            this.txtLocationId.MaxLength = 3;
            this.txtLocationId.Name = "txtLocationId";
            this.txtLocationId.Size = new System.Drawing.Size(130, 25);
            this.txtLocationId.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnClear.Location = new System.Drawing.Point(297, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(133, 34);
            btnClear.TabIndex = 233;
            btnClear.Text = "清除查詢條件";
            btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOk
            // 
            btnOk.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnOk.Location = new System.Drawing.Point(184, 4);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(85, 34);
            btnOk.TabIndex = 232;
            btnOk.Text = " 確 定";
            btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnOk.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            btnSearch.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            btnSearch.Image = global::cf01.Properties.Resources.find;
            btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSearch.Location = new System.Drawing.Point(94, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(85, 34);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "  查  詢";
            btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // BTNSAVESET1
            // 
            this.BTNSAVESET1.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVESET1.Image")));
            this.BTNSAVESET1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNSAVESET1.Location = new System.Drawing.Point(439, 4);
            this.BTNSAVESET1.Name = "BTNSAVESET1";
            this.BTNSAVESET1.Size = new System.Drawing.Size(133, 34);
            this.BTNSAVESET1.TabIndex = 10;
            this.BTNSAVESET1.Text = "保存查找條件";
            this.BTNSAVESET1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTNSAVESET1.UseVisualStyleBackColor = false;
            this.BTNSAVESET1.Click += new System.EventHandler(this.BTNSAVESET1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::cf01.Properties.Resources.exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 34);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "  退 出";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(40, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 231;
            this.labelControl1.Text = "制單編號";
            // 
            // location_id
            // 
            this.location_id.DataPropertyName = "location_id";
            this.location_id.HeaderText = "倉庫編號";
            this.location_id.Name = "location_id";
            this.location_id.ReadOnly = true;
            this.location_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.location_id.Width = 70;
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            dataGridViewCellStyle3.NullValue = null;
            this.mo_id.DefaultCellStyle = dataGridViewCellStyle3;
            this.mo_id.HeaderText = "制單編號";
            this.mo_id.Name = "mo_id";
            this.mo_id.ReadOnly = true;
            this.mo_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mo_id.Width = 120;
            // 
            // goods_id
            // 
            this.goods_id.DataPropertyName = "goods_id";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.goods_id.DefaultCellStyle = dataGridViewCellStyle4;
            this.goods_id.HeaderText = "貨品編號";
            this.goods_id.Name = "goods_id";
            this.goods_id.ReadOnly = true;
            this.goods_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goods_id.Width = 200;
            // 
            // goods_name
            // 
            this.goods_name.DataPropertyName = "goods_name";
            this.goods_name.HeaderText = "貨品描述";
            this.goods_name.Name = "goods_name";
            this.goods_name.ReadOnly = true;
            this.goods_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goods_name.Width = 200;
            // 
            // carton_code
            // 
            this.carton_code.DataPropertyName = "carton_code";
            this.carton_code.HeaderText = "貨架位置";
            this.carton_code.Name = "carton_code";
            this.carton_code.ReadOnly = true;
            this.carton_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.carton_code.Width = 250;
            // 
            // frmStockadiFind2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 645);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockadiFind2";
            this.Text = "frmStockadiFind2";
            this.Load += new System.EventHandler(this.frmStockadiFind2_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BTNSAVESET1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMo_id;
        private DevExpress.XtraEditors.LabelControl lblSales_group;
        private System.Windows.Forms.TextBox txtGoods_id;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox txtLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn location_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn carton_code;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}