using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmExpPictureToExcel : Form
    {
        clsCommonUse commUse = new clsCommonUse();
        public frmExpPictureToExcel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strSql;
            strSql = "SELECT TOP 1000 id,Isnull(picture_name_h,'') as picture_name FROM dgerp2.cferp.dbo.cd_pattern Where id>='TOMM' AND id<='TOMMZZZZZ'";
            DataTable dtArt;
            dtArt = commUse.GetDataTable(strSql);
            dgvDetails.DataSource = dtArt;
            string path = DBUtility.imagePath;
            string name = "";
            string rang = "";
            clsInsertPictureToExcel ipt = new clsInsertPictureToExcel();
            ipt.Open();
            string excelVer = ipt.GetExcelVer();


            string strFileName;
            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默認文件后缀
            dlg.DefaultExt = "xls ";
            //文件后缀列表
            if (excelVer == "11.0")
                dlg.Filter = "EXCEL文件(*.XLS)|*.xls ";
            else
                dlg.Filter = "EXCEL文件(*.XLSX)|*.xlsx ";

            //默認路径是系统当前路径   
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            //返回文件路径   
            strFileName = dlg.FileName;


            ipt.SetRowHeight(90,3, 20);
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                rang = "C" + (i+1).ToString();
                name = path + dgvDetails.Rows[i].Cells["colPicture_name"].Value.ToString();
                //FileInfo file = new FileInfo(name);
                //ipt.InsertPicture(rang, @name);
                //if(file.Exists)
                if(File.Exists(name))
                    ipt.InsertPicture(rang, @name, 120, 80);
                //ipt.InsertPicture(rang, @"C:/3/A888003.BMP");
                //ipt.InsertPicture(rang, @"C:/3/A888003.BMP", 120, 80);
            }
            ipt.SaveFile(strFileName);
            //ipt.SaveFile(@"C:/3/ExcelTest1.xls");
            ipt.Dispose();
        }
    }
}
