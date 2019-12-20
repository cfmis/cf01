namespace cf01.Forms
{
    partial class frmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRid = new System.Windows.Forms.Label();
            this.lblUid = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblUser_desc = new System.Windows.Forms.Label();
            this.txtUser_desc = new System.Windows.Forms.TextBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.labLanguage = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUser_group = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbRole
            // 
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(150, 74);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(121, 20);
            this.cmbRole.TabIndex = 1;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // lblRid
            // 
            this.lblRid.Location = new System.Drawing.Point(66, 72);
            this.lblRid.Name = "lblRid";
            this.lblRid.Size = new System.Drawing.Size(73, 17);
            this.lblRid.TabIndex = 1;
            this.lblRid.Text = "角色：";
            this.lblRid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUid
            // 
            this.lblUid.Location = new System.Drawing.Point(66, 40);
            this.lblUid.Name = "lblUid";
            this.lblUid.Size = new System.Drawing.Size(73, 17);
            this.lblUid.TabIndex = 2;
            this.lblUid.Text = "用戶：";
            this.lblUid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(150, 40);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(121, 22);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Validated += new System.EventHandler(this.txtUserName_Validated);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmit.Image")));
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(210, 221);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(72, 25);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "提交(&S)";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblUser_desc
            // 
            this.lblUser_desc.Location = new System.Drawing.Point(66, 106);
            this.lblUser_desc.Name = "lblUser_desc";
            this.lblUser_desc.Size = new System.Drawing.Size(73, 17);
            this.lblUser_desc.TabIndex = 2;
            this.lblUser_desc.Text = "用戶描述：";
            this.lblUser_desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser_desc
            // 
            this.txtUser_desc.Location = new System.Drawing.Point(150, 107);
            this.txtUser_desc.Name = "txtUser_desc";
            this.txtUser_desc.Size = new System.Drawing.Size(121, 22);
            this.txtUser_desc.TabIndex = 2;
            this.txtUser_desc.Validated += new System.EventHandler(this.txtUser_desc_Validated);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.ItemHeight = 12;
            this.cmbLanguage.Items.AddRange(new object[] {
            "0--繁體中文",
            "1--簡體中文",
            "2--English"});
            this.cmbLanguage.Location = new System.Drawing.Point(150, 141);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 20);
            this.cmbLanguage.TabIndex = 3;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // labLanguage
            // 
            this.labLanguage.Location = new System.Drawing.Point(66, 141);
            this.labLanguage.Name = "labLanguage";
            this.labLanguage.Size = new System.Drawing.Size(73, 17);
            this.labLanguage.TabIndex = 4;
            this.labLanguage.Text = "語言：";
            this.labLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(105, 221);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 25);
            this.btnExit.TabIndex = 43;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.Info;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(385, 23);
            this.lblTitle.TabIndex = 44;
            this.lblTitle.Text = "新增加的用戶！";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(66, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "跟單組別：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbUser_group
            // 
            this.cmbUser_group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser_group.FormattingEnabled = true;
            this.cmbUser_group.ItemHeight = 12;
            this.cmbUser_group.Location = new System.Drawing.Point(150, 177);
            this.cmbUser_group.Name = "cmbUser_group";
            this.cmbUser_group.Size = new System.Drawing.Size(121, 20);
            this.cmbUser_group.TabIndex = 45;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 269);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbUser_group);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.labLanguage);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtUser_desc);
            this.Controls.Add(this.lblUser_desc);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUid);
            this.Controls.Add(this.lblRid);
            this.Controls.Add(this.cmbRole);
            this.Name = "frmUser";
            this.Text = "用戶";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRid;
        private System.Windows.Forms.Label lblUid;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblUser_desc;
        private System.Windows.Forms.TextBox txtUser_desc;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label labLanguage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUser_group;
    }
}