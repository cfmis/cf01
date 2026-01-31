using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.ModuleClass;
using cf01.Forms;
using System.Threading;
using cf01.CLS;
using Microsoft.Reporting.WinForms;

namespace cf01.ReportForm
{
    public partial class frmSetMouldPosition : Form
    {
        private clsPublicOfGEO clsPublicOfGEO = new clsPublicOfGEO();
        public frmSetMouldPosition()
        {
            InitializeComponent();
        }

        private void frmSetMouldPosition_Load(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.RefreshReport();
        }

        Boolean Flag_date = true;
        private void cmdFind_Click(object sender, EventArgs e)
        {
            if (!Flag_date) //如返回FALSE ，則輸入的是無效日期是
            {
                MessageBox.Show("輸入的是無效的日期！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.ShowDialog();
            }).Start();

            LoadData(); //数据处理
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });

        }



        private void Next_obj(object obj)
        {
            //if (((TextBox)obj).SelectionLength == 0) return;  //  有选中的字符
            if (((TextBox)obj).Text.Length >= ((TextBox)obj).MaxLength)
            {
                SelectNextControl((Control)obj, true, true, true, true);
            }
        }

        private void txtdept_id1_TextChanged(object sender, EventArgs e)
        {
            Next_obj(sender);
        }

        private void txtdept_id2_TextChanged(object sender, EventArgs e)
        {
            Next_obj(sender);
        }

        private void txtMould1_TextChanged(object sender, EventArgs e)
        {
            Next_obj(sender);
        }

        private void txtMould2_TextChanged(object sender, EventArgs e)
        {
            Next_obj(sender);
        }

        private void txtArtwork1_TextChanged(object sender, EventArgs e)
        {
            Next_obj(sender);
        }

        private void txtArtwork2_TextChanged(object sender, EventArgs e)
        {
            Next_obj(sender);
        }

        private void txtProducts_type1_TextChanged(object sender, EventArgs e)
        {
            Next_obj(sender);
        }

        private void txtProducts_type2_TextChanged(object sender, EventArgs e)
        {
            Next_obj(sender);
        }

        private void txtSize1_TextChanged(object sender, EventArgs e)
        {
            Next_obj(sender);
        }

        private void txtSize2_TextChanged(object sender, EventArgs e)
        {
            Next_obj(sender);
        }

        private void txtUpdate_date1_TextChanged(object sender, EventArgs e)
        {
            Next_obj(sender);
        }

        private void txtUpdate_date2_TextChanged(object sender, EventArgs e)
        {
            Next_obj(sender);
        }


        private void txtdept_id1_Leave(object sender, EventArgs e)
        {
            txtdept_id2.Text = txtdept_id1.Text;
        }

        private void txtMould1_Leave(object sender, EventArgs e)
        {
            txtMould2.Text = txtMould1.Text;
        }

        private void txtArtwork1_Leave(object sender, EventArgs e)
        {
            txtArtwork2.Text = txtArtwork1.Text;
        }

        private void txtProducts_type1_Leave(object sender, EventArgs e)
        {
            txtProducts_type2.Text = txtProducts_type1.Text;
        }

        private void txtSize1_Leave(object sender, EventArgs e)
        {
            txtSize2.Text = txtSize1.Text;
        }


        private void mkUpdate_date1_Leave(object sender, EventArgs e)
        {
            if (mkUpdate_date1.Text != "    /  /")
            {
                Valid_Date(sender);
                if (Flag_date)
                {
                    mkUpdate_date2.Text = mkUpdate_date1.Text;
                }
            }
        }

        private void mkUpdate_data2_Leave(object sender, EventArgs e)
        {
            if (mkUpdate_date2.Text != "    /  /")
            {
                Valid_Date(sender);
            }
        }

        private void Valid_Date(object obj)
        {
            //判斷日期是否正確                
            if (!clsUtility.CheckDate(((MaskedTextBox)obj).Text.Trim()))
            {
                Flag_date = false;
                Reset_Focus(obj);
            }
            else
            {
                Flag_date = true;
            }
        }

        private void Reset_Focus(object obj)
        {
            this.ActiveControl = (MaskedTextBox)obj;  //設置獲得點               
            ((MaskedTextBox)obj).Focus();
            ((MaskedTextBox)obj).SelectAll();
        }

        private void mkUpdate_date1_TextChanged(object sender, EventArgs e)
        {
            // if (((MaskedTextBox)sender).Text.Length >=10)       
            if (mkUpdate_date1.Text.Length >= 10)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSetMouldPosition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Flag_date)
            {
                mkUpdate_date1.Text = "    /  /";
                mkUpdate_date2.Text = "    /  /";
            }

        }

        private void LoadData()
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            string strSql =
            @"SELECT Row_Number() over(ORDER BY A.update_date,A.mould_no) as seqno,0 as page_index,0 as column_index,
            A.dept_id,A.mould_no,A.id,A.pattern_id,A.products_type,A.measurement,(C.picture_path+'\\'+ Isnull(B.picture_name_h,'')) AS picture_path 
            FROM cd_mould_position A Inner JOIN cd_company C ON A.within_code=C.within_code
            LEFT JOIN cd_pattern B ON A.within_code=B.within_code And A.pattern_id=B.id             
            WHERE A.within_code ='0000' ";

            if (txtdept_id1.Text != "")
            {
                strSql = strSql + " AND A.dept_id >=" + "'" + txtdept_id1.Text + "'";
            }
            if (txtdept_id2.Text != "")
            {
                strSql = strSql + " AND A.dept_id <=" + "'" + txtdept_id2.Text + "'";
            }
            if (txtMould1.Text != "")
            {
                strSql = strSql + "AND A.mould_no >=" + "'" + txtMould1.Text + "'";
            }
            if (txtMould2.Text != "")
            {
                strSql = strSql + "AND A.mould_no <=" + "'" + txtMould2.Text + "'";
            }
            if (txtArtwork1.Text != "")
            {
                strSql = strSql + "AND A.pattern_id >=" + "'" + txtArtwork1.Text + "'";
            }
            if (txtArtwork2.Text != "")
            {
                strSql = strSql + " AND A.pattern_id <=" + "'" + txtArtwork2.Text + "'";
            }
            if (txtProducts_type1.Text != "")
            {
                strSql = strSql + " AND A.products_type >=" + "'" + txtProducts_type1.Text + "'";
            }
            if (txtProducts_type2.Text != "")
            {
                strSql = strSql + " AND A.products_type <=" + "'" + txtProducts_type2.Text + "'";
            }
            if (txtSize1.Text != "")
            {
                strSql = strSql + " AND A.measurement >=" + "'" + txtSize1.Text + "'";
            }
            if (txtSize2.Text != "")
            {
                strSql = strSql + " AND A.measurement <=" + "'" + txtSize2.Text + "'";
            }

            string temp_dat1 = "";
            string temp_dat2 = "";
            if (mkUpdate_date1.Text == "    /  /")
            {
                temp_dat1 = "";
            }
            else
            {
                temp_dat1 = mkUpdate_date1.Text;
            }

            if (mkUpdate_date2.Text == "    /  /")
            {
                temp_dat2 = "";
            }
            else
            {
                DateTime tDat = Convert.ToDateTime(mkUpdate_date2.Text);
                temp_dat2 = tDat.Date.AddDays(1).ToShortDateString();
            }

            if (temp_dat1 != "")
            {
                strSql = strSql + " AND A.update_date >=" + "'" + temp_dat1 + "'";
            }

            if (temp_dat2 != "")
            {
                strSql = strSql + " AND A.update_date <=" + "'" + temp_dat2 + "'";
            }
            strSql = strSql + " ORDER BY A.update_date,A.mould_no";

            DataTable mytb = clsPublicOfGEO.GetDataTable(strSql);

            if (mytb.Rows.Count == 0)
            {
                //MessageBox.Show("查不到符合條件的記錄！");
                MessageBox.Show("查不到符合條件的記錄！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            int page_sum = 42;
            int column_count = 14;
            for (int i = 0; i < mytb.Rows.Count; i++)
            {
                int seqid = Convert.ToInt32(mytb.Rows[i]["seqno"]);

                //區分頁數，每頁數42條記錄
                if (seqid % page_sum == 0)
                {
                    mytb.Rows[i]["page_index"] = seqid / page_sum;
                }
                else
                {
                    mytb.Rows[i]["page_index"] = Convert.ToInt32(seqid / page_sum) + 1;
                }

                //區分欄數，每欄14條記錄
                int temp_page = Convert.ToInt32(mytb.Rows[i]["page_index"]);
                int temp_seqid = seqid - 42 * (temp_page - 1);


                if (temp_seqid <= column_count)
                {
                    mytb.Rows[i]["column_index"] = 1;//在第1欄顯示
                }

                if (temp_seqid > column_count & temp_seqid <= 2 * column_count)
                {
                    mytb.Rows[i]["column_index"] = 2;//在第2欄顯示
                }

                if (temp_seqid > 2 * column_count & temp_seqid <= 3 * column_count)
                {
                    mytb.Rows[i]["column_index"] = 3;//在第3欄顯示
                }
            }

            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", mytb));
            this.reportViewer1.RefreshReport();
        }
    }
}
