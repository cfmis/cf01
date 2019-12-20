namespace cf01.Forms
{
    partial class frmConfig
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
            this.grpbox = new System.Windows.Forms.GroupBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_loginid = new System.Windows.Forms.TextBox();
            this.txt_database = new System.Windows.Forms.TextBox();
            this.txt_Servername = new System.Windows.Forms.TextBox();
            this.txt_dbms = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_loginid = new System.Windows.Forms.Label();
            this.lbl_database = new System.Windows.Forms.Label();
            this.lbl_Servername = new System.Windows.Forms.Label();
            this.lbl_dbms = new System.Windows.Forms.Label();
            this.grpbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbox
            // 
            this.grpbox.Controls.Add(this.btn_cancel);
            this.grpbox.Controls.Add(this.btn_save);
            this.grpbox.Controls.Add(this.btn_test);
            this.grpbox.Controls.Add(this.txt_password);
            this.grpbox.Controls.Add(this.txt_loginid);
            this.grpbox.Controls.Add(this.txt_database);
            this.grpbox.Controls.Add(this.txt_Servername);
            this.grpbox.Controls.Add(this.txt_dbms);
            this.grpbox.Controls.Add(this.lbl_password);
            this.grpbox.Controls.Add(this.lbl_loginid);
            this.grpbox.Controls.Add(this.lbl_database);
            this.grpbox.Controls.Add(this.lbl_Servername);
            this.grpbox.Controls.Add(this.lbl_dbms);
            this.grpbox.Location = new System.Drawing.Point(8, 4);
            this.grpbox.Name = "grpbox";
            this.grpbox.Size = new System.Drawing.Size(412, 265);
            this.grpbox.TabIndex = 0;
            this.grpbox.TabStop = false;
            this.grpbox.Text = "數據庫配置信息";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(300, 214);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(78, 27);
            this.btn_cancel.TabIndex = 12;
            this.btn_cancel.Text = "退出&C";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(175, 214);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(97, 27);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "保存測試信息&S";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(72, 214);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(78, 27);
            this.btn_test.TabIndex = 10;
            this.btn_test.Text = "連接測試(&T)";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(150, 175);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(228, 22);
            this.txt_password.TabIndex = 9;
            // 
            // txt_loginid
            // 
            this.txt_loginid.Location = new System.Drawing.Point(150, 138);
            this.txt_loginid.Name = "txt_loginid";
            this.txt_loginid.Size = new System.Drawing.Size(228, 22);
            this.txt_loginid.TabIndex = 8;
            // 
            // txt_database
            // 
            this.txt_database.Location = new System.Drawing.Point(150, 100);
            this.txt_database.Name = "txt_database";
            this.txt_database.Size = new System.Drawing.Size(228, 22);
            this.txt_database.TabIndex = 7;
            // 
            // txt_Servername
            // 
            this.txt_Servername.Location = new System.Drawing.Point(150, 62);
            this.txt_Servername.Name = "txt_Servername";
            this.txt_Servername.Size = new System.Drawing.Size(228, 22);
            this.txt_Servername.TabIndex = 6;
            // 
            // txt_dbms
            // 
            this.txt_dbms.Location = new System.Drawing.Point(150, 26);
            this.txt_dbms.Name = "txt_dbms";
            this.txt_dbms.ReadOnly = true;
            this.txt_dbms.Size = new System.Drawing.Size(228, 22);
            this.txt_dbms.TabIndex = 5;
            this.txt_dbms.Text = "MSS Microsoft SQL Server";
            // 
            // lbl_password
            // 
            this.lbl_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_password.Location = new System.Drawing.Point(19, 179);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_password.Size = new System.Drawing.Size(132, 15);
            this.lbl_password.TabIndex = 4;
            this.lbl_password.Text = "連接數據庫密碼";
            this.lbl_password.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_loginid
            // 
            this.lbl_loginid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_loginid.Location = new System.Drawing.Point(19, 143);
            this.lbl_loginid.Name = "lbl_loginid";
            this.lbl_loginid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_loginid.Size = new System.Drawing.Size(132, 15);
            this.lbl_loginid.TabIndex = 3;
            this.lbl_loginid.Text = "連接數據庫名";
            this.lbl_loginid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_database
            // 
            this.lbl_database.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_database.Location = new System.Drawing.Point(19, 106);
            this.lbl_database.Name = "lbl_database";
            this.lbl_database.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_database.Size = new System.Drawing.Size(132, 15);
            this.lbl_database.TabIndex = 2;
            this.lbl_database.Text = "數據庫名稱";
            this.lbl_database.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Servername
            // 
            this.lbl_Servername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Servername.Location = new System.Drawing.Point(19, 68);
            this.lbl_Servername.Name = "lbl_Servername";
            this.lbl_Servername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_Servername.Size = new System.Drawing.Size(132, 15);
            this.lbl_Servername.TabIndex = 1;
            this.lbl_Servername.Text = "服務器名稱";
            this.lbl_Servername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_dbms
            // 
            this.lbl_dbms.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_dbms.Location = new System.Drawing.Point(19, 32);
            this.lbl_dbms.Name = "lbl_dbms";
            this.lbl_dbms.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_dbms.Size = new System.Drawing.Size(132, 13);
            this.lbl_dbms.TabIndex = 0;
            this.lbl_dbms.Text = "數據庫類型";
            this.lbl_dbms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(429, 279);
            this.ControlBox = false;
            this.Controls.Add(this.grpbox);
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataBaseConfig";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.grpbox.ResumeLayout(false);
            this.grpbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbox;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_loginid;
        private System.Windows.Forms.TextBox txt_database;
        private System.Windows.Forms.TextBox txt_Servername;
        private System.Windows.Forms.TextBox txt_dbms;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_loginid;
        private System.Windows.Forms.Label lbl_database;
        private System.Windows.Forms.Label lbl_Servername;
        private System.Windows.Forms.Label lbl_dbms;
    }
}