namespace cf01.Forms
{
    partial class frmNewDictLang
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radioMenu = new System.Windows.Forms.RadioButton();
            this.radioForm = new System.Windows.Forms.RadioButton();
            this.textShow_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textLanguage_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textObj_Id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Size = new System.Drawing.Size(1070, 687);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.radioMenu);
            this.splitContainer1.Panel1.Controls.Add(this.radioForm);
            this.splitContainer1.Panel1.Controls.Add(this.textShow_name);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.textLanguage_id);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.textObj_Id);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1070, 687);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.TabIndex = 0;
            // 
            // radioMenu
            // 
            this.radioMenu.AutoSize = true;
            this.radioMenu.Enabled = false;
            this.radioMenu.Location = new System.Drawing.Point(825, 17);
            this.radioMenu.Name = "radioMenu";
            this.radioMenu.Size = new System.Drawing.Size(83, 16);
            this.radioMenu.TabIndex = 3;
            this.radioMenu.TabStop = true;
            this.radioMenu.Text = "菜單的控件";
            this.radioMenu.UseVisualStyleBackColor = true;
            // 
            // radioForm
            // 
            this.radioForm.AutoSize = true;
            this.radioForm.Enabled = false;
            this.radioForm.Location = new System.Drawing.Point(713, 17);
            this.radioForm.Name = "radioForm";
            this.radioForm.Size = new System.Drawing.Size(83, 16);
            this.radioForm.TabIndex = 2;
            this.radioForm.TabStop = true;
            this.radioForm.Text = "表單的控件";
            this.radioForm.UseVisualStyleBackColor = true;
            // 
            // textShow_name
            // 
            this.textShow_name.Location = new System.Drawing.Point(441, 14);
            this.textShow_name.MaxLength = 50;
            this.textShow_name.Name = "textShow_name";
            this.textShow_name.ReadOnly = true;
            this.textShow_name.Size = new System.Drawing.Size(235, 22);
            this.textShow_name.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "顯示名稱:";
            // 
            // textLanguage_id
            // 
            this.textLanguage_id.Location = new System.Drawing.Point(256, 14);
            this.textLanguage_id.MaxLength = 1;
            this.textLanguage_id.Name = "textLanguage_id";
            this.textLanguage_id.ReadOnly = true;
            this.textLanguage_id.Size = new System.Drawing.Size(100, 22);
            this.textLanguage_id.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "語言代碼:";
            // 
            // textObj_Id
            // 
            this.textObj_Id.Location = new System.Drawing.Point(76, 14);
            this.textObj_Id.Name = "textObj_Id";
            this.textObj_Id.ReadOnly = true;
            this.textObj_Id.Size = new System.Drawing.Size(100, 22);
            this.textObj_Id.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "代碼:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1070, 611);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // frmNewDictLang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1070, 727);
            this.Name = "frmNewDictLang";
            this.Load += new System.EventHandler(this.frmNewDictLang_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textObj_Id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textShow_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textLanguage_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.RadioButton radioMenu;
        private System.Windows.Forms.RadioButton radioForm;
    }
}
