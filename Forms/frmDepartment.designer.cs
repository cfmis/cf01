namespace cf01.Forms
{
    partial class frmDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepartment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.BTNEDIT = new System.Windows.Forms.ToolStripButton();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.BTNDELETE = new System.Windows.Forms.ToolStripButton();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lueGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDept_cdesc = new System.Windows.Forms.Label();
            this.lblDept_group = new System.Windows.Forms.Label();
            this.lblDept_desc = new System.Windows.Forms.Label();
            this.lblDept_id = new System.Windows.Forms.Label();
            this.txtDept_cdesc = new System.Windows.Forms.TextBox();
            this.txtDept_desc = new System.Windows.Forms.TextBox();
            this.txtDept_id = new System.Windows.Forms.TextBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.BTNNEW,
            this.BTNEDIT,
            this.BTNSAVE,
            this.BTNDELETE,
            this.BTNFIND,
            this.BTNCANCEL});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(692, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(52, 22);
            this.BTNEXIT.Text = "退出";
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // BTNNEW
            // 
            this.BTNNEW.Image = ((System.Drawing.Image)(resources.GetObject("BTNNEW.Image")));
            this.BTNNEW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNNEW.Name = "BTNNEW";
            this.BTNNEW.Size = new System.Drawing.Size(52, 22);
            this.BTNNEW.Text = "新增";
            this.BTNNEW.Click += new System.EventHandler(this.BTNNEW_Click);
            // 
            // BTNEDIT
            // 
            this.BTNEDIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEDIT.Image")));
            this.BTNEDIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEDIT.Name = "BTNEDIT";
            this.BTNEDIT.Size = new System.Drawing.Size(52, 22);
            this.BTNEDIT.Text = "編輯";
            this.BTNEDIT.Click += new System.EventHandler(this.BTNEDIT_Click);
            // 
            // BTNSAVE
            // 
            this.BTNSAVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVE.Image")));
            this.BTNSAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVE.Name = "BTNSAVE";
            this.BTNSAVE.Size = new System.Drawing.Size(52, 22);
            this.BTNSAVE.Text = "保存";
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // BTNDELETE
            // 
            this.BTNDELETE.Image = ((System.Drawing.Image)(resources.GetObject("BTNDELETE.Image")));
            this.BTNDELETE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNDELETE.Name = "BTNDELETE";
            this.BTNDELETE.Size = new System.Drawing.Size(52, 22);
            this.BTNDELETE.Text = "刪除";
            this.BTNDELETE.Click += new System.EventHandler(this.BTNDELETE_Click);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(52, 22);
            this.BTNFIND.Text = "查詢";
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // BTNCANCEL
            // 
            this.BTNCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNCANCEL.Image")));
            this.BTNCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCANCEL.Name = "BTNCANCEL";
            this.BTNCANCEL.Size = new System.Drawing.Size(52, 22);
            this.BTNCANCEL.Text = "取消";
            this.BTNCANCEL.Click += new System.EventHandler(this.BTNCANCEL_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lueGroup);
            this.splitContainer1.Panel1.Controls.Add(this.lblDept_cdesc);
            this.splitContainer1.Panel1.Controls.Add(this.lblDept_group);
            this.splitContainer1.Panel1.Controls.Add(this.lblDept_desc);
            this.splitContainer1.Panel1.Controls.Add(this.lblDept_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtDept_cdesc);
            this.splitContainer1.Panel1.Controls.Add(this.txtDept_desc);
            this.splitContainer1.Panel1.Controls.Add(this.txtDept_id);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(692, 513);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.TabIndex = 2;
            // 
            // lueGroup
            // 
            this.lueGroup.EditValue = "";
            this.lueGroup.EnterMoveNextControl = true;
            this.lueGroup.Location = new System.Drawing.Point(92, 50);
            this.lueGroup.Name = "lueGroup";
            this.lueGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGroup.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueGroup.Properties.DropDownRows = 15;
            this.lueGroup.Properties.MaxLength = 5;
            this.lueGroup.Properties.NullText = "";
            this.lueGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueGroup.Size = new System.Drawing.Size(185, 20);
            this.lueGroup.TabIndex = 2;
            this.lueGroup.Tag = "1";
            // 
            // lblDept_cdesc
            // 
            this.lblDept_cdesc.AutoSize = true;
            this.lblDept_cdesc.Location = new System.Drawing.Point(369, 55);
            this.lblDept_cdesc.Name = "lblDept_cdesc";
            this.lblDept_cdesc.Size = new System.Drawing.Size(77, 12);
            this.lblDept_cdesc.TabIndex = 1;
            this.lblDept_cdesc.Text = "部門中文描述";
            // 
            // lblDept_group
            // 
            this.lblDept_group.AutoSize = true;
            this.lblDept_group.Location = new System.Drawing.Point(21, 55);
            this.lblDept_group.Name = "lblDept_group";
            this.lblDept_group.Size = new System.Drawing.Size(53, 12);
            this.lblDept_group.TabIndex = 1;
            this.lblDept_group.Text = "部門組別";
            // 
            // lblDept_desc
            // 
            this.lblDept_desc.AutoSize = true;
            this.lblDept_desc.Location = new System.Drawing.Point(369, 18);
            this.lblDept_desc.Name = "lblDept_desc";
            this.lblDept_desc.Size = new System.Drawing.Size(77, 12);
            this.lblDept_desc.TabIndex = 1;
            this.lblDept_desc.Text = "部門英文描述";
            // 
            // lblDept_id
            // 
            this.lblDept_id.AutoSize = true;
            this.lblDept_id.Location = new System.Drawing.Point(33, 18);
            this.lblDept_id.Name = "lblDept_id";
            this.lblDept_id.Size = new System.Drawing.Size(41, 12);
            this.lblDept_id.TabIndex = 1;
            this.lblDept_id.Text = "部門ID";
            // 
            // txtDept_cdesc
            // 
            this.txtDept_cdesc.Location = new System.Drawing.Point(463, 52);
            this.txtDept_cdesc.Name = "txtDept_cdesc";
            this.txtDept_cdesc.Size = new System.Drawing.Size(185, 22);
            this.txtDept_cdesc.TabIndex = 3;
            // 
            // txtDept_desc
            // 
            this.txtDept_desc.Location = new System.Drawing.Point(463, 15);
            this.txtDept_desc.Name = "txtDept_desc";
            this.txtDept_desc.Size = new System.Drawing.Size(185, 22);
            this.txtDept_desc.TabIndex = 1;
            // 
            // txtDept_id
            // 
            this.txtDept_id.Location = new System.Drawing.Point(92, 15);
            this.txtDept_id.MaxLength = 3;
            this.txtDept_id.Name = "txtDept_id";
            this.txtDept_id.Size = new System.Drawing.Size(185, 22);
            this.txtDept_id.TabIndex = 0;
            // 
            // dgvDetails
            // 
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetails.Location = new System.Drawing.Point(0, 3);
            this.dgvDetails.Name = "dgvDetails";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(692, 423);
            this.dgvDetails.TabIndex = 4;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // frmDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 538);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmDepartment";
            this.Text = "frmDepartment";
            this.Load += new System.EventHandler(this.frmDepartment_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripButton BTNEDIT;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripButton BTNDELETE;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblDept_id;
        private System.Windows.Forms.TextBox txtDept_id;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Label lblDept_cdesc;
        private System.Windows.Forms.Label lblDept_group;
        private System.Windows.Forms.Label lblDept_desc;
        private System.Windows.Forms.TextBox txtDept_cdesc;
        private System.Windows.Forms.TextBox txtDept_desc;
        private DevExpress.XtraEditors.LookUpEdit lueGroup;
    }
}