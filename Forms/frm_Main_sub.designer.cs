namespace cf01.Forms
{
    partial class frm_Main_sub
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main_sub));
            this.MenuTree = new System.Windows.Forms.TreeView();
            this.myImageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkExpand = new System.Windows.Forms.CheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.palRight = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.palRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuTree
            // 
            this.MenuTree.BackColor = System.Drawing.SystemColors.MenuBar;
            this.MenuTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MenuTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTree.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MenuTree.ImageIndex = 0;
            this.MenuTree.ImageList = this.myImageList;
            this.MenuTree.Indent = 25;
            this.MenuTree.Location = new System.Drawing.Point(0, 0);
            this.MenuTree.Name = "MenuTree";
            this.MenuTree.SelectedImageIndex = 0;
            this.MenuTree.Size = new System.Drawing.Size(204, 727);
            this.MenuTree.TabIndex = 2;
            this.MenuTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MenuTree_AfterSelect);
            this.MenuTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.MenuTree_NodeMouseClick);
            // 
            // myImageList
            // 
            this.myImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("myImageList.ImageStream")));
            this.myImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.myImageList.Images.SetKeyName(0, "model.png");
            this.myImageList.Images.SetKeyName(1, "file3.png");
            this.myImageList.Images.SetKeyName(2, "files1.png");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chkExpand);
            this.panel1.Controls.Add(this.MenuTree);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 731);
            this.panel1.TabIndex = 5;
            // 
            // chkExpand
            // 
            this.chkExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkExpand.AutoSize = true;
            this.chkExpand.BackColor = System.Drawing.SystemColors.MenuBar;
            this.chkExpand.Checked = true;
            this.chkExpand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExpand.Location = new System.Drawing.Point(126, 3);
            this.chkExpand.Name = "chkExpand";
            this.chkExpand.Size = new System.Drawing.Size(60, 16);
            this.chkExpand.TabIndex = 3;
            this.chkExpand.Text = "Expand";
            this.chkExpand.UseVisualStyleBackColor = false;
            this.chkExpand.CheckedChanged += new System.EventHandler(this.chkExpand_CheckedChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(208, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 731);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // palRight
            // 
            this.palRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.palRight.Controls.Add(this.pictureBox1);
            this.palRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palRight.Location = new System.Drawing.Point(211, 0);
            this.palRight.Name = "palRight";
            this.palRight.Size = new System.Drawing.Size(811, 731);
            this.palRight.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(265, 178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // frm_Main_sub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 731);
            this.ControlBox = false;
            this.Controls.Add(this.palRight);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Main_sub";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Menu List";
            this.Load += new System.EventHandler(this.frm_test_Load);
            this.Resize += new System.EventHandler(this.frm_Main_sub_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.palRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView MenuTree;
        private System.Windows.Forms.ImageList myImageList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkExpand;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel palRight;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}