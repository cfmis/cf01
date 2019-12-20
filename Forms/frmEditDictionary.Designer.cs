namespace cf01.Forms
{
    partial class frmEditDictionary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditDictionary));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtShowName = new System.Windows.Forms.TextBox();
            this.show_name = new System.Windows.Forms.Label();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.language_id = new System.Windows.Forms.Label();
            this.txtColName = new System.Windows.Forms.TextBox();
            this.col_name = new System.Windows.Forms.Label();
            this.col_code = new System.Windows.Forms.Label();
            this.txtColCode = new System.Windows.Forms.TextBox();
            this.txtFormname = new System.Windows.Forms.TextBox();
            this.formname = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.BTNFIND = new System.Windows.Forms.Button();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.label_condition_lang = new System.Windows.Forms.Label();
            this.label_condition = new System.Windows.Forms.Label();
            this.cmbFieldName = new System.Windows.Forms.ComboBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNEDIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNDELETE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNREFRESH = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtShowName);
            this.splitContainer1.Panel1.Controls.Add(this.show_name);
            this.splitContainer1.Panel1.Controls.Add(this.txtLanguage);
            this.splitContainer1.Panel1.Controls.Add(this.language_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtColName);
            this.splitContainer1.Panel1.Controls.Add(this.col_name);
            this.splitContainer1.Panel1.Controls.Add(this.col_code);
            this.splitContainer1.Panel1.Controls.Add(this.txtColCode);
            this.splitContainer1.Panel1.Controls.Add(this.txtFormname);
            this.splitContainer1.Panel1.Controls.Add(this.formname);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(791, 548);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtShowName
            // 
            this.txtShowName.Location = new System.Drawing.Point(359, 76);
            this.txtShowName.Name = "txtShowName";
            this.txtShowName.ReadOnly = true;
            this.txtShowName.Size = new System.Drawing.Size(144, 22);
            this.txtShowName.TabIndex = 9;
            // 
            // show_name
            // 
            this.show_name.AutoSize = true;
            this.show_name.Location = new System.Drawing.Point(251, 80);
            this.show_name.Name = "show_name";
            this.show_name.Size = new System.Drawing.Size(92, 12);
            this.show_name.TabIndex = 8;
            this.show_name.Text = "標籤顯示的名稱:";
            // 
            // txtLanguage
            // 
            this.txtLanguage.Location = new System.Drawing.Point(94, 76);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.ReadOnly = true;
            this.txtLanguage.Size = new System.Drawing.Size(33, 22);
            this.txtLanguage.TabIndex = 7;
            // 
            // language_id
            // 
            this.language_id.AutoSize = true;
            this.language_id.Location = new System.Drawing.Point(22, 80);
            this.language_id.Name = "language_id";
            this.language_id.Size = new System.Drawing.Size(56, 12);
            this.language_id.TabIndex = 6;
            this.language_id.Text = "語言代號:";
            // 
            // txtColName
            // 
            this.txtColName.Location = new System.Drawing.Point(546, 49);
            this.txtColName.Name = "txtColName";
            this.txtColName.ReadOnly = true;
            this.txtColName.Size = new System.Drawing.Size(144, 22);
            this.txtColName.TabIndex = 5;
            // 
            // col_name
            // 
            this.col_name.AutoSize = true;
            this.col_name.Location = new System.Drawing.Point(476, 53);
            this.col_name.Name = "col_name";
            this.col_name.Size = new System.Drawing.Size(56, 12);
            this.col_name.TabIndex = 4;
            this.col_name.Text = "標籤稱謂:";
            // 
            // col_code
            // 
            this.col_code.AutoSize = true;
            this.col_code.Location = new System.Drawing.Point(251, 53);
            this.col_code.Name = "col_code";
            this.col_code.Size = new System.Drawing.Size(56, 12);
            this.col_code.TabIndex = 3;
            this.col_code.Text = "標籤代號:";
            // 
            // txtColCode
            // 
            this.txtColCode.Location = new System.Drawing.Point(324, 49);
            this.txtColCode.Name = "txtColCode";
            this.txtColCode.ReadOnly = true;
            this.txtColCode.Size = new System.Drawing.Size(144, 22);
            this.txtColCode.TabIndex = 2;
            // 
            // txtFormname
            // 
            this.txtFormname.Location = new System.Drawing.Point(94, 49);
            this.txtFormname.Name = "txtFormname";
            this.txtFormname.ReadOnly = true;
            this.txtFormname.Size = new System.Drawing.Size(144, 22);
            this.txtFormname.TabIndex = 1;
            // 
            // formname
            // 
            this.formname.AutoSize = true;
            this.formname.Location = new System.Drawing.Point(22, 53);
            this.formname.Name = "formname";
            this.formname.Size = new System.Drawing.Size(56, 12);
            this.formname.TabIndex = 0;
            this.formname.Text = "所屬表單:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cmbLanguage);
            this.splitContainer2.Panel1.Controls.Add(this.BTNFIND);
            this.splitContainer2.Panel1.Controls.Add(this.txtKeyWord);
            this.splitContainer2.Panel1.Controls.Add(this.cmbOperator);
            this.splitContainer2.Panel1.Controls.Add(this.label_condition_lang);
            this.splitContainer2.Panel1.Controls.Add(this.label_condition);
            this.splitContainer2.Panel1.Controls.Add(this.cmbFieldName);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer2.Size = new System.Drawing.Size(787, 416);
            this.splitContainer2.SplitterDistance = 76;
            this.splitContainer2.TabIndex = 0;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(84, 45);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 20);
            this.cmbLanguage.TabIndex = 5;
            // 
            // BTNFIND
            // 
            this.BTNFIND.Location = new System.Drawing.Point(478, 16);
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(75, 23);
            this.BTNFIND.TabIndex = 4;
            this.BTNFIND.Text = "查找(&F)";
            this.BTNFIND.UseVisualStyleBackColor = true;
            this.BTNFIND.Click += new System.EventHandler(this.btmFind_Click);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(338, 15);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(119, 22);
            this.txtKeyWord.TabIndex = 3;
            this.txtKeyWord.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // cmbOperator
            // 
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Location = new System.Drawing.Point(211, 17);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(121, 20);
            this.cmbOperator.TabIndex = 2;
            this.cmbOperator.SelectedIndexChanged += new System.EventHandler(this.cmbOperator_SelectedIndexChanged);
            // 
            // label_condition_lang
            // 
            this.label_condition_lang.AutoSize = true;
            this.label_condition_lang.Location = new System.Drawing.Point(22, 48);
            this.label_condition_lang.Name = "label_condition_lang";
            this.label_condition_lang.Size = new System.Drawing.Size(32, 12);
            this.label_condition_lang.TabIndex = 0;
            this.label_condition_lang.Text = "語言:";
            this.label_condition_lang.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_condition
            // 
            this.label_condition.AutoSize = true;
            this.label_condition.Location = new System.Drawing.Point(22, 20);
            this.label_condition.Name = "label_condition";
            this.label_condition.Size = new System.Drawing.Size(56, 12);
            this.label_condition.TabIndex = 0;
            this.label_condition.Text = "查詢條件:";
            this.label_condition.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbFieldName
            // 
            this.cmbFieldName.FormattingEnabled = true;
            this.cmbFieldName.Location = new System.Drawing.Point(84, 17);
            this.cmbFieldName.Name = "cmbFieldName";
            this.cmbFieldName.Size = new System.Drawing.Size(121, 20);
            this.cmbFieldName.TabIndex = 1;
            this.cmbFieldName.SelectedIndexChanged += new System.EventHandler(this.cmbFieldName_SelectedIndexChanged);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersWidth = 18;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(787, 336);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator2,
            this.BTNSAVE,
            this.toolStripSeparator1,
            this.BTNCANCEL,
            this.toolStripSeparator3,
            this.BTNNEW,
            this.toolStripSeparator4,
            this.BTNEDIT,
            this.toolStripSeparator5,
            this.BTNDELETE,
            this.toolStripSeparator6,
            this.BTNREFRESH,
            this.toolStripSeparator7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(791, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(65, 29);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // BTNSAVE
            // 
            this.BTNSAVE.Enabled = false;
            this.BTNSAVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVE.Image")));
            this.BTNSAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVE.Name = "BTNSAVE";
            this.BTNSAVE.Size = new System.Drawing.Size(63, 29);
            this.BTNSAVE.Text = "儲存(&S)";
            this.BTNSAVE.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // BTNCANCEL
            // 
            this.BTNCANCEL.Enabled = false;
            this.BTNCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNCANCEL.Image")));
            this.BTNCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCANCEL.Name = "BTNCANCEL";
            this.BTNCANCEL.Size = new System.Drawing.Size(65, 29);
            this.BTNCANCEL.Text = "取消(&U)";
            this.BTNCANCEL.Click += new System.EventHandler(this.toolCancel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // BTNNEW
            // 
            this.BTNNEW.Image = ((System.Drawing.Image)(resources.GetObject("BTNNEW.Image")));
            this.BTNNEW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNNEW.Name = "BTNNEW";
            this.BTNNEW.Size = new System.Drawing.Size(65, 29);
            this.BTNNEW.Text = "添加(&A)";
            this.BTNNEW.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // BTNEDIT
            // 
            this.BTNEDIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEDIT.Image")));
            this.BTNEDIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEDIT.Name = "BTNEDIT";
            this.BTNEDIT.Size = new System.Drawing.Size(64, 29);
            this.BTNEDIT.Text = "修改(&E)";
            this.BTNEDIT.Click += new System.EventHandler(this.toolAmend_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // BTNDELETE
            // 
            this.BTNDELETE.Image = ((System.Drawing.Image)(resources.GetObject("BTNDELETE.Image")));
            this.BTNDELETE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNDELETE.Name = "BTNDELETE";
            this.BTNDELETE.Size = new System.Drawing.Size(65, 29);
            this.BTNDELETE.Text = "刪除(&D)";
            this.BTNDELETE.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 32);
            // 
            // BTNREFRESH
            // 
            this.BTNREFRESH.Image = ((System.Drawing.Image)(resources.GetObject("BTNREFRESH.Image")));
            this.BTNREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNREFRESH.Name = "BTNREFRESH";
            this.BTNREFRESH.Size = new System.Drawing.Size(65, 29);
            this.BTNREFRESH.Text = "刷新(&R)";
            this.BTNREFRESH.Click += new System.EventHandler(this.btmFind_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 32);
            // 
            // frmEditDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 548);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmEditDictionary";
            this.Text = "frmEditDictionary";
            this.Load += new System.EventHandler(this.frmEditDictionary_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripButton BTNEDIT;
        private System.Windows.Forms.ToolStripButton BTNDELETE;
        private System.Windows.Forms.ToolStripButton BTNREFRESH;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ComboBox cmbFieldName;
        private System.Windows.Forms.Label label_condition;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button BTNFIND;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label label_condition_lang;
        private System.Windows.Forms.TextBox txtFormname;
        private System.Windows.Forms.Label formname;
        private System.Windows.Forms.Label col_code;
        private System.Windows.Forms.TextBox txtColCode;
        private System.Windows.Forms.TextBox txtColName;
        private System.Windows.Forms.Label col_name;
        private System.Windows.Forms.TextBox txtShowName;
        private System.Windows.Forms.Label show_name;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.Label language_id;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}