namespace cf01.ReportForm
{
    partial class frmPreviewImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreviewImage));
            this.picArt = new System.Windows.Forms.PictureBox();
            this.myNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.myBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnReduce = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.txtArt_id = new DevExpress.XtraEditors.TextEdit();
            this.txtArtwork_Name = new DevExpress.XtraEditors.TextEdit();
            this.txtArtwork_Name_en = new DevExpress.XtraEditors.TextEdit();
            this.pnl = new System.Windows.Forms.Panel();
            this.lblArtwork_id = new System.Windows.Forms.Label();
            this.lblArtwork_Name = new System.Windows.Forms.Label();
            this.lblArtwork_Name_en = new System.Windows.Forms.Label();
            this.txtPictrue_path = new DevExpress.XtraEditors.TextEdit();
            this.lblCust_goods = new System.Windows.Forms.Label();
            this.txtCust_product_id = new DevExpress.XtraEditors.TextEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.txtAdd = new DevExpress.XtraEditors.TextEdit();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblReduce = new System.Windows.Forms.Label();
            this.txtReduce = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myNavigator)).BeginInit();
            this.myNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArt_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArtwork_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArtwork_Name_en.Properties)).BeginInit();
            this.pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPictrue_path.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust_product_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReduce.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picArt
            // 
            this.picArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picArt.Location = new System.Drawing.Point(111, 85);
            this.picArt.Name = "picArt";
            this.picArt.Size = new System.Drawing.Size(350, 350);
            this.picArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picArt.TabIndex = 0;
            this.picArt.TabStop = false;
            // 
            // myNavigator
            // 
            this.myNavigator.AddNewItem = null;
            this.myNavigator.AutoSize = false;
            this.myNavigator.CountItem = this.bindingNavigatorCountItem;
            this.myNavigator.DeleteItem = null;
            this.myNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.myNavigator.Location = new System.Drawing.Point(0, 0);
            this.myNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.myNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.myNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.myNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.myNavigator.Name = "myNavigator";
            this.myNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.myNavigator.Size = new System.Drawing.Size(896, 30);
            this.myNavigator.TabIndex = 2;
            this.myNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(24, 27);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(482, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 28);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnReduce
            // 
            this.btnReduce.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnReduce.Appearance.Options.UseFont = true;
            this.btnReduce.Location = new System.Drawing.Point(519, 34);
            this.btnReduce.Name = "btnReduce";
            this.btnReduce.Size = new System.Drawing.Size(32, 28);
            this.btnReduce.TabIndex = 4;
            this.btnReduce.Text = "-";
            this.btnReduce.Click += new System.EventHandler(this.btnReduce_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(331, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 26);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Exit";
            this.btnExit.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtArt_id
            // 
            this.txtArt_id.EnterMoveNextControl = true;
            this.txtArt_id.Location = new System.Drawing.Point(108, 62);
            this.txtArt_id.Name = "txtArt_id";
            this.txtArt_id.Properties.ReadOnly = true;
            this.txtArt_id.Size = new System.Drawing.Size(109, 20);
            this.txtArt_id.TabIndex = 6;
            // 
            // txtArtwork_Name
            // 
            this.txtArtwork_Name.EnterMoveNextControl = true;
            this.txtArtwork_Name.Location = new System.Drawing.Point(108, 98);
            this.txtArtwork_Name.Name = "txtArtwork_Name";
            this.txtArtwork_Name.Properties.ReadOnly = true;
            this.txtArtwork_Name.Size = new System.Drawing.Size(209, 20);
            this.txtArtwork_Name.TabIndex = 7;
            // 
            // txtArtwork_Name_en
            // 
            this.txtArtwork_Name_en.EnterMoveNextControl = true;
            this.txtArtwork_Name_en.Location = new System.Drawing.Point(108, 133);
            this.txtArtwork_Name_en.Name = "txtArtwork_Name_en";
            this.txtArtwork_Name_en.Properties.ReadOnly = true;
            this.txtArtwork_Name_en.Size = new System.Drawing.Size(209, 20);
            this.txtArtwork_Name_en.TabIndex = 8;
            // 
            // pnl
            // 
            this.pnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl.Controls.Add(this.picArt);
            this.pnl.Location = new System.Drawing.Point(330, 65);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(563, 494);
            this.pnl.TabIndex = 9;
            // 
            // lblArtwork_id
            // 
            this.lblArtwork_id.Location = new System.Drawing.Point(5, 65);
            this.lblArtwork_id.Name = "lblArtwork_id";
            this.lblArtwork_id.Size = new System.Drawing.Size(97, 12);
            this.lblArtwork_id.TabIndex = 10;
            this.lblArtwork_id.Text = "Artwor ID";
            this.lblArtwork_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblArtwork_Name
            // 
            this.lblArtwork_Name.Location = new System.Drawing.Point(5, 101);
            this.lblArtwork_Name.Name = "lblArtwork_Name";
            this.lblArtwork_Name.Size = new System.Drawing.Size(97, 12);
            this.lblArtwork_Name.TabIndex = 11;
            this.lblArtwork_Name.Text = "Art Desc_C";
            this.lblArtwork_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblArtwork_Name_en
            // 
            this.lblArtwork_Name_en.Location = new System.Drawing.Point(5, 137);
            this.lblArtwork_Name_en.Name = "lblArtwork_Name_en";
            this.lblArtwork_Name_en.Size = new System.Drawing.Size(97, 12);
            this.lblArtwork_Name_en.TabIndex = 12;
            this.lblArtwork_Name_en.Text = "Art Desc_E";
            this.lblArtwork_Name_en.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPictrue_path
            // 
            this.txtPictrue_path.Enabled = false;
            this.txtPictrue_path.Location = new System.Drawing.Point(108, 134);
            this.txtPictrue_path.Name = "txtPictrue_path";
            this.txtPictrue_path.Properties.ReadOnly = true;
            this.txtPictrue_path.Size = new System.Drawing.Size(197, 20);
            this.txtPictrue_path.TabIndex = 13;
            // 
            // lblCust_goods
            // 
            this.lblCust_goods.Location = new System.Drawing.Point(5, 172);
            this.lblCust_goods.Name = "lblCust_goods";
            this.lblCust_goods.Size = new System.Drawing.Size(97, 12);
            this.lblCust_goods.TabIndex = 15;
            this.lblCust_goods.Text = "Cust Product Code";
            this.lblCust_goods.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCust_product_id
            // 
            this.txtCust_product_id.EnterMoveNextControl = true;
            this.txtCust_product_id.Location = new System.Drawing.Point(108, 169);
            this.txtCust_product_id.Name = "txtCust_product_id";
            this.txtCust_product_id.Properties.ReadOnly = true;
            this.txtCust_product_id.Size = new System.Drawing.Size(209, 20);
            this.txtCust_product_id.TabIndex = 14;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(256, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(66, 26);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Text = "&Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtAdd
            // 
            this.txtAdd.EnterMoveNextControl = true;
            this.txtAdd.Location = new System.Drawing.Point(663, 37);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtAdd.Properties.Appearance.Options.UseFont = true;
            this.txtAdd.Properties.Mask.EditMask = "n0";
            this.txtAdd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAdd.Size = new System.Drawing.Size(35, 24);
            this.txtAdd.TabIndex = 17;
            this.txtAdd.Leave += new System.EventHandler(this.txtAdd_Leave);
            // 
            // lblAdd
            // 
            this.lblAdd.Location = new System.Drawing.Point(561, 43);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(101, 13);
            this.lblAdd.TabIndex = 19;
            this.lblAdd.Text = "放大百分比";
            this.lblAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReduce
            // 
            this.lblReduce.Location = new System.Drawing.Point(702, 43);
            this.lblReduce.Name = "lblReduce";
            this.lblReduce.Size = new System.Drawing.Size(120, 13);
            this.lblReduce.TabIndex = 21;
            this.lblReduce.Text = "縮小百分比";
            this.lblReduce.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReduce
            // 
            this.txtReduce.EnterMoveNextControl = true;
            this.txtReduce.Location = new System.Drawing.Point(822, 37);
            this.txtReduce.Name = "txtReduce";
            this.txtReduce.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtReduce.Properties.Appearance.Options.UseFont = true;
            this.txtReduce.Properties.Mask.EditMask = "n0";
            this.txtReduce.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtReduce.Size = new System.Drawing.Size(35, 24);
            this.txtReduce.TabIndex = 20;
            this.txtReduce.Leave += new System.EventHandler(this.txtReduce_Leave);
            // 
            // frmPreviewImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(896, 559);
            this.Controls.Add(this.lblReduce);
            this.Controls.Add(this.txtReduce);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblCust_goods);
            this.Controls.Add(this.txtCust_product_id);
            this.Controls.Add(this.txtArtwork_Name_en);
            this.Controls.Add(this.lblArtwork_Name_en);
            this.Controls.Add(this.lblArtwork_Name);
            this.Controls.Add(this.lblArtwork_id);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.txtArtwork_Name);
            this.Controls.Add(this.txtArt_id);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReduce);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.myNavigator);
            this.Controls.Add(this.txtPictrue_path);
            this.Name = "frmPreviewImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPreviewImage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPreviewImage_Load);
            this.Resize += new System.EventHandler(this.frmPreviewImage_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myNavigator)).EndInit();
            this.myNavigator.ResumeLayout(false);
            this.myNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArt_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArtwork_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArtwork_Name_en.Properties)).EndInit();
            this.pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPictrue_path.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCust_product_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReduce.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picArt;
        private System.Windows.Forms.BindingNavigator myNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource myBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnReduce;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.TextEdit txtArt_id;
        private DevExpress.XtraEditors.TextEdit txtArtwork_Name;
        private DevExpress.XtraEditors.TextEdit txtArtwork_Name_en;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label lblArtwork_id;
        private System.Windows.Forms.Label lblArtwork_Name;
        private System.Windows.Forms.Label lblArtwork_Name_en;
        private DevExpress.XtraEditors.TextEdit txtPictrue_path;
        private System.Windows.Forms.Label lblCust_goods;
        private DevExpress.XtraEditors.TextEdit txtCust_product_id;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.TextEdit txtAdd;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Label lblReduce;
        private DevExpress.XtraEditors.TextEdit txtReduce;

    }
}