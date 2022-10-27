namespace cf01.MM
{
    partial class frmProductTypeStdPriceArtwork
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
            this.lblArtwork = new DevExpress.XtraEditors.LabelControl();
            this.txtArtwork = new DevExpress.XtraEditors.TextEdit();
            this.dgvArtwork = new System.Windows.Forms.DataGridView();
            this.colArtwork = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.txtUpperSN = new DevExpress.XtraEditors.TextEdit();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtArtwork.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpperSN.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblArtwork
            // 
            this.lblArtwork.Location = new System.Drawing.Point(56, 26);
            this.lblArtwork.Name = "lblArtwork";
            this.lblArtwork.Size = new System.Drawing.Size(52, 14);
            this.lblArtwork.TabIndex = 0;
            this.lblArtwork.Text = "圖樣代號:";
            // 
            // txtArtwork
            // 
            this.txtArtwork.Location = new System.Drawing.Point(114, 23);
            this.txtArtwork.Name = "txtArtwork";
            this.txtArtwork.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArtwork.Properties.MaxLength = 7;
            this.txtArtwork.Size = new System.Drawing.Size(100, 20);
            this.txtArtwork.TabIndex = 1;
            this.txtArtwork.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArtwork_KeyDown);
            // 
            // dgvArtwork
            // 
            this.dgvArtwork.AllowUserToAddRows = false;
            this.dgvArtwork.ColumnHeadersHeight = 25;
            this.dgvArtwork.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArtwork});
            this.dgvArtwork.Location = new System.Drawing.Point(56, 79);
            this.dgvArtwork.Name = "dgvArtwork";
            this.dgvArtwork.ReadOnly = true;
            this.dgvArtwork.RowHeadersWidth = 20;
            this.dgvArtwork.RowTemplate.Height = 24;
            this.dgvArtwork.Size = new System.Drawing.Size(353, 265);
            this.dgvArtwork.TabIndex = 2;
            // 
            // colArtwork
            // 
            this.colArtwork.DataPropertyName = "Artwork";
            this.colArtwork.HeaderText = "圖樣代號";
            this.colArtwork.Name = "colArtwork";
            this.colArtwork.ReadOnly = true;
            this.colArtwork.Width = 160;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(430, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新增(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(430, 79);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "刪除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtUpperSN
            // 
            this.txtUpperSN.Location = new System.Drawing.Point(248, 23);
            this.txtUpperSN.Name = "txtUpperSN";
            this.txtUpperSN.Properties.ReadOnly = true;
            this.txtUpperSN.Size = new System.Drawing.Size(100, 20);
            this.txtUpperSN.TabIndex = 5;
            this.txtUpperSN.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "序號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "圖樣代號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 160;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(526, 22);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "退出(&X)";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmProductTypeStdPriceArtwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(618, 373);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtUpperSN);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvArtwork);
            this.Controls.Add(this.txtArtwork);
            this.Controls.Add(this.lblArtwork);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmProductTypeStdPriceArtwork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmProductTypeStdPriceArtwork";
            this.Load += new System.EventHandler(this.frmProductTypeStdPriceArtwork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtArtwork.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpperSN.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblArtwork;
        private DevExpress.XtraEditors.TextEdit txtArtwork;
        private System.Windows.Forms.DataGridView dgvArtwork;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.TextEdit txtUpperSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtwork;
    }
}