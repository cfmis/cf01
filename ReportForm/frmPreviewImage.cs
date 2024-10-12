using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;
using cf01.Reports;
using cf01.CLS;
using DevExpress.XtraReports.UI;

namespace cf01.ReportForm
{
    public partial class frmPreviewImage : Form
    {
        DataTable dtLargeImage;
        public frmPreviewImage(DataTable dt)
        {
            InitializeComponent();
            //dtLargeImage = frmArtworkSearch.tbReport;
            dtLargeImage = dt;
            myBindingSource.DataSource = dtLargeImage;
            myNavigator.BindingSource = myBindingSource;
            //綁定數據
            txtArt_id.DataBindings.Add("Text", myBindingSource, "art_id");
            txtArtwork_Name.DataBindings.Add("Text", myBindingSource, "name_prc");
            txtArtwork_Name_en.DataBindings.Add("Text", myBindingSource, "name_en");
            txtPictrue_path.DataBindings.Add("Text", myBindingSource, "picture_name");
            txtCust_product_id.DataBindings.Add("Text", myBindingSource, "customer_goods");


            clsControlInfoHelper oMutilang = new clsControlInfoHelper(this.Name, this.Controls);
            oMutilang.GenerateContorl();
            
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            SetPictrue();
        }
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {          
            SetPictrue();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {           
            SetPictrue();
        }     

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            SetPictrue();
        }
        private void SetPictrue()
        {
            //DevExpress.XtraEditors.PictureEdit pbx = new DevExpress.XtraEditors.PictureEdit();
            //pbx.Name = name;
            //pbx.Location = new Point(pbx.Location.X + x, pbx.Location.Y + 3);
            //pbx.Size = size;
            //pbx.Tag = Url;
            //pbx.Visible = true;
            // pbx.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + ".\\images\\" + name + "_up.jpg");
            picArt.Image = Image.FromFile(txtPictrue_path.Text);            
        }

        private void frmPreviewImage_Load(object sender, EventArgs e)
        {
            myBindingSource.MoveFirst();
            SetPictrue();
        }

        private void SetPicLocation()
        {
            this.picArt.Location = new Point(pnl.Width / 2 - (this.picArt.Width / 2),
                                                 pnl.Height / 2 - (this.picArt.Height / 2));
        }

        private void frmPreviewImage_Resize(object sender, EventArgs e)
        {
            SetPicLocation();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (picArt.Width < pnl.Width || picArt.Height < pnl.Height)
            {
                SetSize(true);
            }
        }

        private void btnReduce_Click(object sender, EventArgs e)
        {            
            SetSize(false);                   
        }


        private void txtAdd_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAdd.Text))
            {
                SetSize_percent(true, Convert.ToInt32(txtAdd.Text));
                txtAdd.EditValue = null;
            }
        }

        private void txtReduce_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtReduce.Text))
            {
                SetSize_percent(false, Convert.ToInt32(txtReduce.Text));
                txtReduce.EditValue = null;
            }
        }

        private void SetSize(bool flag)
        {
            if (flag)
            {
                picArt.Width = picArt.Width + 10;
                picArt.Height = picArt.Height + 10;
            }
            else
            {
                picArt.Width = picArt.Width - 10;
                picArt.Height = picArt.Height - 10;
            }
            SetPicLocation();
        }


        private void SetSize_percent(bool flag,int iValue)
        {
            if (flag)  //放大
            {
                if (pnl.Width > picArt.Width + picArt.Width * iValue / 100)
                {
                    picArt.Width = picArt.Width + picArt.Width * iValue / 100;
                    picArt.Height = picArt.Height + picArt.Height * iValue / 100;
                }
            }
            else      //縮小
            {
                if (picArt.Width - picArt.Width * iValue / 100 >=100)
                {
                    picArt.Width = picArt.Width - picArt.Width * iValue / 100;
                    picArt.Height = picArt.Height - picArt.Height * iValue / 100;
                }
                else
                {
                    picArt.Width = 100;
                    picArt.Height = 100;
                }
            }
             SetPicLocation();   
        }
                    

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtLargeImage.Rows.Count>0)
            {
                //加載報表
                xrLargeImage mMyRepot = new xrLargeImage() { DataSource = dtLargeImage };
                mMyRepot.ShowPreview();
            }


        }

   

     

   
    
        
    }
}
