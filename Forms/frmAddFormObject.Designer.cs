namespace cf01.Forms
{
    partial class frmAddFormObject
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textReadOnly = new System.Windows.Forms.TextBox();
            this.textColVisible = new System.Windows.Forms.TextBox();
            this.textColSort = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textColWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textColType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textObjName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textObjId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textObjType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textFormName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Size = new System.Drawing.Size(1101, 747);
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
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.textReadOnly);
            this.splitContainer1.Panel1.Controls.Add(this.textColVisible);
            this.splitContainer1.Panel1.Controls.Add(this.textColSort);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.textColWidth);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.textColType);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.textObjName);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.textObjId);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.textObjType);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.textFormName);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1101, 747);
            this.splitContainer1.SplitterDistance = 178;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1101, 79);
            this.panel2.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(889, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "查找(&L)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(638, 34);
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(243, 22);
            this.textBox3.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(579, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "控件代號:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(399, 31);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(173, 22);
            this.textBox2.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(340, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "控件類型:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 31);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 22);
            this.textBox1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "表單名:";
            // 
            // textReadOnly
            // 
            this.textReadOnly.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textReadOnly.Location = new System.Drawing.Point(771, 76);
            this.textReadOnly.MaxLength = 1;
            this.textReadOnly.Name = "textReadOnly";
            this.textReadOnly.ReadOnly = true;
            this.textReadOnly.Size = new System.Drawing.Size(37, 22);
            this.textReadOnly.TabIndex = 8;
            // 
            // textColVisible
            // 
            this.textColVisible.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textColVisible.Location = new System.Drawing.Point(668, 76);
            this.textColVisible.MaxLength = 1;
            this.textColVisible.Name = "textColVisible";
            this.textColVisible.ReadOnly = true;
            this.textColVisible.Size = new System.Drawing.Size(37, 22);
            this.textColVisible.TabIndex = 7;
            // 
            // textColSort
            // 
            this.textColSort.Location = new System.Drawing.Point(412, 76);
            this.textColSort.MaxLength = 10;
            this.textColSort.Name = "textColSort";
            this.textColSort.ReadOnly = true;
            this.textColSort.Size = new System.Drawing.Size(45, 22);
            this.textColSort.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(712, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "是否只讀:";
            // 
            // textColWidth
            // 
            this.textColWidth.Location = new System.Drawing.Point(520, 76);
            this.textColWidth.MaxLength = 10;
            this.textColWidth.Name = "textColWidth";
            this.textColWidth.ReadOnly = true;
            this.textColWidth.Size = new System.Drawing.Size(43, 22);
            this.textColWidth.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(609, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "是否可見:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(344, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "排序:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "表格寬度:";
            // 
            // textColType
            // 
            this.textColType.Location = new System.Drawing.Point(86, 76);
            this.textColType.MaxLength = 50;
            this.textColType.Name = "textColType";
            this.textColType.ReadOnly = true;
            this.textColType.Size = new System.Drawing.Size(243, 22);
            this.textColType.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "欄位類型:";
            // 
            // textObjName
            // 
            this.textObjName.Location = new System.Drawing.Point(412, 43);
            this.textObjName.MaxLength = 50;
            this.textObjName.Name = "textObjName";
            this.textObjName.ReadOnly = true;
            this.textObjName.Size = new System.Drawing.Size(243, 22);
            this.textObjName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(344, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "控件對象名:";
            // 
            // textObjId
            // 
            this.textObjId.Location = new System.Drawing.Point(86, 43);
            this.textObjId.MaxLength = 50;
            this.textObjId.Name = "textObjId";
            this.textObjId.ReadOnly = true;
            this.textObjId.Size = new System.Drawing.Size(243, 22);
            this.textObjId.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "控件代號:";
            // 
            // textObjType
            // 
            this.textObjType.Location = new System.Drawing.Point(412, 9);
            this.textObjType.MaxLength = 50;
            this.textObjType.Name = "textObjType";
            this.textObjType.ReadOnly = true;
            this.textObjType.Size = new System.Drawing.Size(243, 22);
            this.textObjType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "控件類型:";
            // 
            // textFormName
            // 
            this.textFormName.Location = new System.Drawing.Point(86, 9);
            this.textFormName.MaxLength = 50;
            this.textFormName.Name = "textFormName";
            this.textFormName.ReadOnly = true;
            this.textFormName.Size = new System.Drawing.Size(243, 22);
            this.textFormName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "表單名稱:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1101, 565);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            this.dgvDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellDoubleClick);
            // 
            // frmAddFormObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1101, 787);
            this.Name = "frmAddFormObject";
            this.Text = "表單控件定義";
            this.Load += new System.EventHandler(this.frmAddFormObject_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.TextBox textFormName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textColWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textObjId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textObjType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textColVisible;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textColType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textColSort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textObjName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textReadOnly;
        private System.Windows.Forms.Label label12;
    }
}
