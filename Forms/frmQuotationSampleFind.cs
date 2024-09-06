using cf01.CLS;
using cf01.MDL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmQuotationSampleFind : Form
    {
        public DataTable dtFind = new DataTable();
        DataTable dtFindDetail = new DataTable();
        DataSet dtsFind = new DataSet();
        private clsAppPublic clsApp = new clsAppPublic();
        mdlQuotationSample mdl= new mdlQuotationSample();
        public frmQuotationSampleFind()
        {
            InitializeComponent();
            //mdl = md;
            clsApp.Initialize_find_value("frmQuotationSampleFind", pnlFindData.Controls);
            //InitFindData(mdl);
        }

        private void frmQuotationSampleFind_Load(object sender, EventArgs e)
        {
            clsQuotation.SetExcelType(lueExcelType);
            lueExcelType.EditValue = "Trims";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dtFind.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.Yes;//標記查詢到數據并退出
            }
            this.Close();
        }

        private void BTNSAVESET1_Click(object sender, EventArgs e)
        {
            //保存數據瀏覽頁面查詢條件            
            if (clsApp.set_find_Value("frmQuotationSampleFind", pnlFindData.Controls) > 0)
                MessageBox.Show("當前查詢條件保存成功!", "提示信息");
            else
                MessageBox.Show("當前查詢條件保存失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtInput_date1.EditValue = "";
            dtInput_date2.EditValue = "";
            txtSeason.Text = "";
            txtPlm_code.Text = "";
            txtCf_code.Text = "";
            txtMaterial.Text = "";
            txtSize.Text = "";
            txtMacys_color_code.Text = "";
            txtMo_id.Text = "";
            txtCf_color_code.Text = "";
            txtCreate_by.Text = "";
            dtCreate_date1.EditValue = "";
            dtCreate_date2.EditValue = "";
            txtMacys_color_code.Text = "";
            lueExcelType.EditValue = "";
        }

        private void btnSearchByParam_Click(object sender, EventArgs e)
        {
            btnSearchByParam.Focus();
            FindData();
            if (dtFind.Rows.Count > 0)
            {
                //this.DialogResult = DialogResult.Yes;//標記查詢到數據并退出
            }
            else
            {
                MessageBox.Show("未查詢到數據，請重新輸入條件查詢數據!", "提示信息");
            }

        }
        private void FindData()
        {
            //--start 20240906 記錄已打勾的查詢數據以方便添到新的查詢結果中
            txtSeason.Focus();
            DataRow[] drs = null;
            if (chkFind.Checked)
            {
                bool blFlag = false;               
                if (dgvDetails.RowCount > 0)
                {
                    for (int i = 0; i < dgvDetails.RowCount; i++)
                    {
                        if (dtFindDetail.Rows[i]["flag_select"].ToString() == "True")
                        {
                            blFlag = true;
                            break;
                        }
                    }
                    if (blFlag)
                    {
                        drs = dtFindDetail.Select("flag_select=true");
                    }
                }
            }
            //-- end

            mdl.input_date = dtInput_date1.EditValue.ToString();
            mdl.input_date2 = dtInput_date2.EditValue.ToString();
            mdl.season = txtSeason.Text;
            mdl.plm_code = txtPlm_code.Text;
            mdl.cf_code = txtCf_code.Text;
            mdl.material = txtMaterial.Text;
            mdl.size = txtSize.Text;
            mdl.macys_color_code = txtMacys_color_code.Text;
            mdl.mo_id = txtMo_id.Text;
            mdl.cf_color_code = txtCf_color_code.Text;
            mdl.excel_type = lueExcelType.EditValue.ToString();
            mdl.create_by = txtCreate_by.Text;
            mdl.create_date = dtCreate_date1.EditValue.ToString();
            mdl.create_date2 = dtCreate_date2.EditValue.ToString();
            mdl.brand_desc = txtBrand_desc.Text;
            mdl.flag_ck = chkFlag_ck.Checked ? 1 : 0;
            dtsFind = clsQuotationSample.FindDataByMdl(mdl);
            dtFind = dtsFind.Tables[0];//返回的所有數據
            dtFindDetail = dtsFind.Tables[1];//只是滿足查找條件的數據            
            dtFind = clsQuotationSample.SetGridDataBackgroudColor(dtFind);//設置斑馬線標識

            //start導入前一次打勾的查詢結果
            if (drs != null)
            {
                if (drs.Length > 0)
                {
                    DataRow[] drs_del;
                    foreach (DataRow row in drs)
                    {
                        drs_del = dtFindDetail.Select(string.Format("id={0}", row["id"]));
                        foreach (DataRow row_del in drs_del)
                        {
                            dtFindDetail.Rows.Remove(row_del);//先移走已存在的行
                        }
                    }
                    drs_del = null;
                    dtFindDetail.Select();
                    //將打勾的添加進新查詢的結果中                   
                    foreach (DataRow dr in drs)
                    {
                        dtFindDetail.ImportRow(dr);
                    }
                    drs = null;
                    //處理排序                    
                    DataView dvw = dtFindDetail.DefaultView;
                    dvw.Sort = "flag_select DESC";  //按Flag_select列 排序
                    dtFindDetail = dvw.ToTable();
                }
            }
            //--end
            dtFindDetail = clsQuotationSample.SetGridDataBackgroudColor(dtFindDetail);//設置斑馬線標識

            //處理序號
            //--start取不重復的序號
            ArrayList nStr = new ArrayList();
            string strSerialNo = "";
            for (int i = 0; i < dtFindDetail.Rows.Count; i++)
            {
                strSerialNo = dtFindDetail.Rows[i]["serial_no"].ToString();
                if (!nStr.Contains(strSerialNo))
                {
                    nStr.Add(strSerialNo);
                }
            }                
            //--end
            //--start重新整理序號
            int temp_seq_id = 0;
            string str_temp_seq_id = "";           
            for (int i=0;i<nStr.Count;i++)
            {
                temp_seq_id = 0;
                strSerialNo = nStr[i].ToString();
                for (int j = 0; j < dtFindDetail.Rows.Count; j++)
                {
                    if (dtFindDetail.Rows[j]["serial_no"].ToString() == strSerialNo)
                    {
                        temp_seq_id += 1;
                        str_temp_seq_id = temp_seq_id.ToString("00");
                        if (dtFindDetail.Rows[j]["seq_id"].ToString() != str_temp_seq_id)
                        {
                            dtFindDetail.Rows[j]["seq_id"] = str_temp_seq_id;
                        }
                    }
                }
            }
            //-- end           

            dgvDetails.DataSource = dtFindDetail;
        }
        private void InitFindData(mdlQuotationSample mdl)
        {
            dtInput_date1.EditValue = mdl.input_date;
            dtInput_date2.EditValue = mdl.input_date;
            txtSeason.Text = mdl.season;
            txtPlm_code.Text = mdl.plm_code;
            txtCf_code.Text = mdl.cf_code;
            txtMaterial.Text =mdl.material;
            txtSize.Text = mdl.size;
            txtMacys_color_code.Text = mdl.macys_color_code;
            txtMo_id.Text = mdl.mo_id;
            txtCf_color_code.Text = mdl.cf_color_code;
            txtCreate_by.Text = "";
            dtCreate_date1.EditValue = "";
            dtCreate_date2.EditValue = "";
        }

        private void frmQuotationSampleFind_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dtFind.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.Yes;//標記查詢到數據并退出
            }
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor = Color.Black,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);


            DataGridView grd = sender as DataGridView;
            if (grd.Rows[e.RowIndex].Cells["bgcolor"].Value.ToString() == "1")
            {
                //特別單價亮藍色背景
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))); // Color.Gray;
            }
            else
            {
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }

            //DataGridView grd1 = sender as DataGridView;
            if (grd.Rows[e.RowIndex].Cells["status"].Value.ToString() == "CANCELLED")
            {
                //刪除線
                grd.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Strikeout);
                grd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string isCk = chkCk.Checked ? "CK" : "";
            clsQuotationSample.ExportToExcel(dgvDetails, "", isCk);
        }

        private void btnExcelOpen_Click(object sender, EventArgs e)
        {
            string isCk = chkCk.Checked ? "CK" : "";
            clsQuotationSample.ExportToExcel(dgvDetails, "open", isCk);
        }

        private void chkAll_MouseUp(object sender, MouseEventArgs e)
        {
            if (dtsFind.Tables.Count > 0)
            {
                if (!chkAll.Checked)
                    dgvDetails.DataSource = dtFindDetail;
                else
                    dgvDetails.DataSource = dtFind;
            }
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetails.RowCount > 0)
            {
                int index = dgvDetails.CurrentRow.Index;
                if (index >= 0)
                {
                    //dgvDetails      
                    DataGridViewRow dgrw = dgvDetails.CurrentRow;
                    string artworkPath = dgrw.Cells["artwork_path"].Value.ToString();
                    SetArtwork(artworkPath);
                }


            }
        }

        private void SetArtwork(string artwork_full_path)
        {
            if (!string.IsNullOrEmpty(artwork_full_path))
            {               
                pic_artwork.Image = File.Exists(artwork_full_path) ? Image.FromFile(artwork_full_path) : null;
            }
            else
                pic_artwork.Image = null;
        }
    }
}
