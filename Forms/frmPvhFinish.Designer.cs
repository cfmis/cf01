namespace cf01.Forms
{
    partial class frmPvhFinish
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPvhFinish));
            this.dgvFinish = new System.Windows.Forms.DataGridView();
            this.flagSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinish)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFinish
            // 
            this.dgvFinish.AllowUserToAddRows = false;
            this.dgvFinish.AllowUserToDeleteRows = false;
            this.dgvFinish.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFinish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flagSelect,
            this.contents});
            this.dgvFinish.Location = new System.Drawing.Point(13, 27);
            this.dgvFinish.Name = "dgvFinish";
            this.dgvFinish.RowTemplate.Height = 24;
            this.dgvFinish.Size = new System.Drawing.Size(382, 229);
            this.dgvFinish.TabIndex = 0;
            // 
            // flagSelect
            // 
            this.flagSelect.DataPropertyName = "flagSelect";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.NullValue = false;
            this.flagSelect.DefaultCellStyle = dataGridViewCellStyle3;
            this.flagSelect.HeaderText = "Select";
            this.flagSelect.Name = "flagSelect";
            this.flagSelect.Width = 80;
            // 
            // contents
            // 
            this.contents.DataPropertyName = "contents";
            this.contents.HeaderText = "Contents";
            this.contents.Name = "contents";
            this.contents.ReadOnly = true;
            this.contents.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.contents.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.contents.Width = 250;
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(326, 263);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 27);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "確定   ";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(230, 263);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 27);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "關閉   ";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Contents";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(89, 10);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 3;
            this.chkAll.Text = "全選";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkAll_MouseUp);
            // 
            // frmPvhFinish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 302);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvFinish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPvhFinish";
            this.Text = "Finish";
            this.Load += new System.EventHandler(this.frmPvhFinish_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinish)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFinish;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flagSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn contents;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.CheckBox chkAll;
    }
}