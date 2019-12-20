namespace cf01.Forms
{
    partial class frmNewDictionary
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
            this.textImg_path = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textCol_Field = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textObj_Desc = new System.Windows.Forms.TextBox();
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
            this.panel1.Size = new System.Drawing.Size(1074, 742);
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
            this.splitContainer1.Panel1.Controls.Add(this.textImg_path);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.textCol_Field);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.textObj_Desc);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.textObj_Id);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1074, 742);
            this.splitContainer1.SplitterDistance = 116;
            this.splitContainer1.TabIndex = 0;
            // 
            // textImg_path
            // 
            this.textImg_path.Location = new System.Drawing.Point(415, 50);
            this.textImg_path.Name = "textImg_path";
            this.textImg_path.ReadOnly = true;
            this.textImg_path.Size = new System.Drawing.Size(100, 22);
            this.textImg_path.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(355, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "圖片路徑:";
            // 
            // textCol_Field
            // 
            this.textCol_Field.Location = new System.Drawing.Point(143, 50);
            this.textCol_Field.Name = "textCol_Field";
            this.textCol_Field.ReadOnly = true;
            this.textCol_Field.Size = new System.Drawing.Size(195, 22);
            this.textCol_Field.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "表格欄位所屬字段:";
            // 
            // textObj_Desc
            // 
            this.textObj_Desc.Location = new System.Drawing.Point(247, 17);
            this.textObj_Desc.Name = "textObj_Desc";
            this.textObj_Desc.ReadOnly = true;
            this.textObj_Desc.Size = new System.Drawing.Size(195, 22);
            this.textObj_Desc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "代碼描述:";
            // 
            // textObj_Id
            // 
            this.textObj_Id.Location = new System.Drawing.Point(81, 17);
            this.textObj_Id.Name = "textObj_Id";
            this.textObj_Id.ReadOnly = true;
            this.textObj_Id.Size = new System.Drawing.Size(100, 22);
            this.textObj_Id.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "代碼:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1074, 622);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            this.dgvDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellDoubleClick);
            this.dgvDetails.CurrentCellChanged += new System.EventHandler(this.dgvDetails_CurrentCellChanged);
            // 
            // frmNewDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1074, 782);
            this.Name = "frmNewDictionary";
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
        private System.Windows.Forms.TextBox textImg_path;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textCol_Field;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textObj_Desc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textObj_Id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetails;
    }
}
