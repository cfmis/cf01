namespace cf01.Forms
{
    partial class frmAddMenu
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.checkPid = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textGid = new System.Windows.Forms.TextBox();
            this.textGidSort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textFuncDesc = new System.Windows.Forms.TextBox();
            this.textFid = new System.Windows.Forms.TextBox();
            this.textGdesc = new System.Windows.Forms.TextBox();
            this.textPid = new System.Windows.Forms.TextBox();
            this.textPidDesc = new System.Windows.Forms.TextBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Size = new System.Drawing.Size(1025, 661);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1025, 661);
            this.splitContainer1.SplitterDistance = 268;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(268, 661);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
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
            this.splitContainer2.Panel1.Controls.Add(this.checkPid);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.textGid);
            this.splitContainer2.Panel1.Controls.Add(this.textGidSort);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.textFuncDesc);
            this.splitContainer2.Panel1.Controls.Add(this.textFid);
            this.splitContainer2.Panel1.Controls.Add(this.textGdesc);
            this.splitContainer2.Panel1.Controls.Add(this.textPid);
            this.splitContainer2.Panel1.Controls.Add(this.textPidDesc);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer2.Size = new System.Drawing.Size(753, 661);
            this.splitContainer2.SplitterDistance = 166;
            this.splitContainer2.TabIndex = 2;
            // 
            // checkPid
            // 
            this.checkPid.AutoSize = true;
            this.checkPid.Enabled = false;
            this.checkPid.Location = new System.Drawing.Point(421, 26);
            this.checkPid.Name = "checkPid";
            this.checkPid.Size = new System.Drawing.Size(60, 16);
            this.checkPid.TabIndex = 7;
            this.checkPid.Text = "根節點";
            this.checkPid.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "菜單排序:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "調用功能:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "節點描述:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "本級節點:";
            // 
            // textGid
            // 
            this.textGid.Location = new System.Drawing.Point(77, 56);
            this.textGid.Name = "textGid";
            this.textGid.ReadOnly = true;
            this.textGid.Size = new System.Drawing.Size(100, 22);
            this.textGid.TabIndex = 2;
            // 
            // textGidSort
            // 
            this.textGidSort.Location = new System.Drawing.Point(346, 95);
            this.textGidSort.Name = "textGidSort";
            this.textGidSort.ReadOnly = true;
            this.textGidSort.Size = new System.Drawing.Size(69, 22);
            this.textGidSort.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "上級節點:";
            // 
            // textFuncDesc
            // 
            this.textFuncDesc.Location = new System.Drawing.Point(152, 95);
            this.textFuncDesc.Name = "textFuncDesc";
            this.textFuncDesc.ReadOnly = true;
            this.textFuncDesc.Size = new System.Drawing.Size(124, 22);
            this.textFuncDesc.TabIndex = 5;
            // 
            // textFid
            // 
            this.textFid.Location = new System.Drawing.Point(77, 95);
            this.textFid.Name = "textFid";
            this.textFid.ReadOnly = true;
            this.textFid.Size = new System.Drawing.Size(69, 22);
            this.textFid.TabIndex = 4;
            // 
            // textGdesc
            // 
            this.textGdesc.Location = new System.Drawing.Point(253, 56);
            this.textGdesc.Name = "textGdesc";
            this.textGdesc.ReadOnly = true;
            this.textGdesc.Size = new System.Drawing.Size(182, 22);
            this.textGdesc.TabIndex = 3;
            // 
            // textPid
            // 
            this.textPid.Location = new System.Drawing.Point(77, 27);
            this.textPid.Name = "textPid";
            this.textPid.ReadOnly = true;
            this.textPid.Size = new System.Drawing.Size(100, 22);
            this.textPid.TabIndex = 0;
            // 
            // textPidDesc
            // 
            this.textPidDesc.Location = new System.Drawing.Point(202, 27);
            this.textPidDesc.Name = "textPidDesc";
            this.textPidDesc.ReadOnly = true;
            this.textPidDesc.Size = new System.Drawing.Size(182, 22);
            this.textPidDesc.TabIndex = 1;
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
            this.dgvDetails.Size = new System.Drawing.Size(753, 491);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            this.dgvDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellDoubleClick);
            // 
            // frmAddMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1025, 701);
            this.Name = "frmAddMenu";
            this.Load += new System.EventHandler(this.frmAddMenu_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textPid;
        private System.Windows.Forms.TextBox textPidDesc;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textGid;
        private System.Windows.Forms.TextBox textGdesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textGidSort;
        private System.Windows.Forms.TextBox textFid;
        private System.Windows.Forms.TextBox textFuncDesc;
        private System.Windows.Forms.CheckBox checkPid;
    }
}
