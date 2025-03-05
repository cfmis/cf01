namespace cf01.Forms
{
    partial class frmDgdDeliverGoods_Find2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDgdDeliverGoods_Find2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.chkSelectAll = new DevExpress.XtraEditors.CheckEdit();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.flag_select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.box_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upd_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prd_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetails.ColumnHeadersHeight = 35;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flag_select,
            this.mo_id,
            this.qty,
            this.weg,
            this.box_no,
            this.package_num,
            this.upd_flag,
            this.prd_id});
            this.dgvDetails.Location = new System.Drawing.Point(10, 39);
            this.dgvDetails.Name = "dgvDetails";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetails.RowHeadersWidth = 45;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(582, 363);
            this.dgvDetails.TabIndex = 22;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Location = new System.Drawing.Point(77, 9);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Properties.Caption = " 全選";
            this.chkSelectAll.Size = new System.Drawing.Size(63, 19);
            this.chkSelectAll.TabIndex = 148;
            this.chkSelectAll.ToolTip = "Select All";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(236, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 149;
            this.btnOK.Text = "確定";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Image = global::cf01.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(352, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 27);
            this.btnExit.TabIndex = 150;
            this.btnExit.Text = "退出";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // flag_select
            // 
            this.flag_select.DataPropertyName = "flag_select";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.NullValue = false;
            this.flag_select.DefaultCellStyle = dataGridViewCellStyle1;
            this.flag_select.Frozen = true;
            this.flag_select.HeaderText = "";
            this.flag_select.Name = "flag_select";
            this.flag_select.Width = 60;
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mo_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.mo_id.HeaderText = "制單頁數";
            this.mo_id.Name = "mo_id";
            this.mo_id.ReadOnly = true;
            this.mo_id.Width = 110;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.qty.DefaultCellStyle = dataGridViewCellStyle3;
            this.qty.HeaderText = "數量";
            this.qty.MaxInputLength = 1;
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // weg
            // 
            this.weg.DataPropertyName = "weg";
            this.weg.HeaderText = "重量";
            this.weg.MaxInputLength = 20;
            this.weg.Name = "weg";
            this.weg.ReadOnly = true;
            this.weg.Width = 90;
            // 
            // box_no
            // 
            this.box_no.DataPropertyName = "box_no";
            this.box_no.HeaderText = " 箱號";
            this.box_no.Name = "box_no";
            this.box_no.ReadOnly = true;
            this.box_no.Width = 90;
            // 
            // package_num
            // 
            this.package_num.DataPropertyName = "package_num";
            this.package_num.HeaderText = "件數";
            this.package_num.Name = "package_num";
            this.package_num.ReadOnly = true;
            this.package_num.Width = 90;
            // 
            // upd_flag
            // 
            this.upd_flag.DataPropertyName = "upd_flag";
            this.upd_flag.HeaderText = "狀態";
            this.upd_flag.Name = "upd_flag";
            this.upd_flag.ReadOnly = true;
            this.upd_flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.upd_flag.Visible = false;
            // 
            // prd_id
            // 
            this.prd_id.DataPropertyName = "prd_id";
            this.prd_id.HeaderText = "id";
            this.prd_id.MaxInputLength = 50;
            this.prd_id.Name = "prd_id";
            this.prd_id.ReadOnly = true;
            this.prd_id.Visible = false;
            // 
            // frmDgdDeliverGoods_Find2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 413);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.dgvDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDgdDeliverGoods_Find2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDgdDeliverGoods_Find2";
            this.Load += new System.EventHandler(this.frmDgdDeliverGoods_Find2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetails;
        private DevExpress.XtraEditors.CheckEdit chkSelectAll;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flag_select;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn weg;
        private System.Windows.Forms.DataGridViewTextBoxColumn box_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn package_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn upd_flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn prd_id;
    }
}