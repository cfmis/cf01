using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.MDL;
using cf01.CLS;
using cf01.Forms;
using cf01.Reports;

namespace cf01.MM
{
    public partial class frmProductTypeStdPrice : Form
    {
        private DataTable dtSizeDetails = new DataTable();
        private DataTable dtColorGroup = new DataTable();
        private DataTable dtColorDetails = new DataTable();
        frmProductTypeStdPriceFind frmProductTypeStdPriceFind;
        public static string searchState;
        public static string searchID = "";
        public frmProductTypeStdPrice()
        {
            InitializeComponent();
            dgvSizeDetails.AutoGenerateColumns = false;
            dgvColorGroup.AutoGenerateColumns = false;
            dgvColorDetails.AutoGenerateColumns = false;
        }
        private void LoadData(string ID)
        {
            if (ID == "")
                return;
            DataTable dtProductType = clsMmProductTypeStdPrice.LoadProductType(ID);
            if (dtProductType.Rows.Count > 0)
            {
                DataRow dr = dtProductType.Rows[0];
                txtArtWork.Text = dr["ArtWork"].ToString();
                txtProductType.Text = dr["ProductType"].ToString();
                txtCreateUser.Text = dr["CreateUser"].ToString();
                txtCreateTime.Text = dr["CreateTime"].ToString();
                txtAmendUser.Text = dr["AmendUser"].ToString();
                txtAmendTime.Text = dr["AmendTime"].ToString();
                txtSN.Text = dr["SN"].ToString();
                txtVer.Text = dr["Ver"].ToString();
            }
            else
            {
                txtArtWork.Text = "";
                txtProductType.Text = "";
                txtCreateUser.Text = "";
                txtCreateTime.Text = "";
                txtAmendUser.Text = "";
                txtAmendTime.Text = "";
                txtSN.Text = "";
                txtVer.Text = "";
            }
            LoadSizeDetails();
            LoadColorGroup(0);
            LoadColorDetails(0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mdlProductTypePrice mdlPtp = new mdlProductTypePrice();
            mdlPtp.ID = txtID.Text;
            mdlPtp.Ver = txtVer.Text == "" ? 0 : Convert.ToInt32(txtVer.Text);
            mdlPtp.ArtWork = txtArtWork.Text;
            mdlPtp.ProductType = txtProductType.Text;
            string result=clsMmProductTypeStdPrice.Save(mdlPtp);
            txtID.Text = result;
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            LoadData(txtID.Text.Trim());
        }

        private void btnAddSize_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSizeDetails.Rows.Count; i++)
            {
                if (txtSizeID.Text.Trim() == dgvSizeDetails.Rows[i].Cells["colSizeID"].Value.ToString().Trim())
                {
                    MessageBox.Show("此尺寸已存在!");
                }
            }
            SaveSize();
            //if (result == "")
            //{
            //    DataRow dr = dtSizeDetails.NewRow();
            //    dr["Seq"] = txtSizeSeq.Text.Trim();
            //    dr["SizeID"] = txtSizeID.Text.Trim();
            //    dr["SizeName"] = txtSizeName.Text.Trim();
            //    dtSizeDetails.Rows.Add(dr);
            //}
        }
        private string SaveSize()
        {
            string result = "";
            if (txtSizeID.Text.Trim() == "")
            {
                MessageBox.Show("尺寸代號不能為空!");
                return result;
            }
            
            if (txtSizeSeq.Text == "")
                txtSizeSeq.Text = GenSeqNo(dgvSizeDetails, "colSizeSeq");
            mdlProductTypePriceSize mdlMtps = new mdlProductTypePriceSize();
            mdlMtps.UpperSN = txtSN.Text == "" ? 0 : Convert.ToInt32(txtSN.Text);
            mdlMtps.Seq = txtSizeSeq.Text.Trim();
            mdlMtps.SizeID = txtSizeID.Text.Trim();
            result = clsMmProductTypeStdPrice.SaveSize(mdlMtps);
            if (result != "")
                MessageBox.Show(result);
            else
                LoadSizeDetails();
            return result;
        }
        private void LoadSizeDetails()
        {
            int SN = txtSN.Text == "" ? 0 : Convert.ToInt32(txtSN.Text);
            dtSizeDetails = clsMmProductTypeStdPrice.LoadSizeDetails(Convert.ToInt32(SN));
            dgvSizeDetails.DataSource = dtSizeDetails;
            if(dtSizeDetails.Rows.Count==0)
            {
                txtSizeID.Text = "";
                txtSizeName.Text = "";
                txtSizeSeq.Text = "";
            }
        }
        private void btnAddColorGroup_Click(object sender, EventArgs e)
        {
            SaveColorGroup();
            
            //DataRow dr = dtColorGroup.NewRow();
            //dr["UpperSeq"] = dgvSizeDetails.Rows[dgvSizeDetails.CurrentRow.Index].Cells["colSizeSeq"].Value.ToString(); //通过索引赋值
            //dr["Seq"] = txtColorGroupSeq.Text;
            //dr["ValueDesc"] = txtValueDesc.Text.Trim();
            //dr["Price"] = txtPrice.Text.Trim();
            //dr["Curr"] = lueCurr.Text.Trim();
            //dtColorGroup.Rows.Add(dr);
        }
        private string GenSeqNo(DataGridView dgv,string cellsName)
        {
            string Seq = "";
            string MaxSeq = "000";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                Seq = dgv.Rows[i].Cells[cellsName].Value.ToString();
                MaxSeq = string.Compare(MaxSeq, Seq) >= 0 ? MaxSeq : Seq;
            }
            int MaxSeqInt = Convert.ToInt32(MaxSeq);
            Seq = (MaxSeqInt + 1).ToString().PadLeft(3, '0');
            return Seq;
        }
        private void dgvColorGroup_SelectionChanged(object sender, EventArgs e)
        {
            //LoadColorGroup(dgvColorGroup.CurrentRow.Index);
            int row = dgvColorGroup.CurrentRow.Index;
            DataGridViewRow dr = dgvColorGroup.Rows[row];
            txtColorGroupSeq.Text = dr.Cells["colColorGroupSeq"].Value.ToString();
            txtPrice.Text = dr.Cells["colPrice"].Value.ToString();
            txtValueDesc.Text = dr.Cells["colValueDesc"].Value.ToString();
            lueCurr.Text= dr.Cells["colCurr"].Value.ToString();
            LoadColorDetails(row);
        }
        private void LoadColorGroup(int row)
        {
            int UpperSN = dgvSizeDetails.Rows.Count == 0 ? 0 : Convert.ToInt32(dgvSizeDetails.Rows[row].Cells["colSizeSN"].Value);
            dtColorGroup = clsMmProductTypeStdPrice.LoadColorGroup(UpperSN);
            dgvColorGroup.DataSource = dtColorGroup;
            if(dtColorGroup.Rows.Count==0)
            {
                txtValueDesc.Text = "";
                txtPrice.Text = "";
                lueCurr.Text = "";
                txtColorGroupSeq.Text = "";
            }
        }
        private void LoadColorDetails(int row)
        {
            int UpperSN = dgvColorGroup.Rows.Count == 0 ? 0 : Convert.ToInt32(dgvColorGroup.Rows[row].Cells["colColorGroupSN"].Value);
            dtColorDetails = clsMmProductTypeStdPrice.LoadColorDetails(UpperSN);
            dgvColorDetails.DataSource = dtColorDetails;
            if(dtColorDetails.Rows.Count==0)
            {
                txtColorID.Text = "";
                txtColorName.Text = "";
                txtColorSeq.Text = "";
            }
        }
        private void dgvSizeDetails_SelectionChanged(object sender, EventArgs e)
        {
            int row = dgvSizeDetails.CurrentRow.Index;
            DataGridViewRow dr = dgvSizeDetails.Rows[row];
            txtSizeSeq.Text = dr.Cells["colSizeSeq"].Value.ToString();
            txtSizeID.Text = dr.Cells["colSizeID"].Value.ToString();
            txtSizeName.Text = dr.Cells["colSizeName"].Value.ToString();
            LoadColorGroup(row);
            LoadColorDetails(0);
        }

        private void btnSaveSize_Click(object sender, EventArgs e)
        {
            //List<mdlProductTypePriceSize> lsMtps = new List<mdlProductTypePriceSize>();
            //for (int i = 0; i < dgvSizeDetails.Rows.Count; i++)
            //{
            //    mdlProductTypePriceSize mdlMtps = new mdlProductTypePriceSize();
            //    DataGridViewRow drSize = dgvSizeDetails.Rows[i];
            //    mdlMtps.ID = txtID.Text.Trim();
            //    mdlMtps.Seq = drSize.Cells["colSizeSeq"].Value.ToString();
            //    mdlMtps.SizeID = drSize.Cells["colSizeID"].Value.ToString();
            //    lsMtps.Add(mdlMtps);
            //}
            //string result = clsMmProductTypeStdPrice.SaveSize(lsMtps);
            //txtID.Text = result;
            SaveSize();
        }

        private void btnSaveColorGroup_Click(object sender, EventArgs e)
        {
            SaveColorGroup();
        }
        private string SaveColorGroup()
        {
            string result = "";
            if (dgvSizeDetails.Rows.Count == 0 || dgvSizeDetails.CurrentRow.Index < 0)
            {
                MessageBox.Show("沒有選擇尺寸!");
                return result;
            }
            if (txtPrice.Text == "" || Convert.ToDecimal(txtPrice.Text) == 0)
            {
                MessageBox.Show("價錢不能為空!");
                txtPrice.Focus();
                return result;
            }
            if (txtColorGroupSeq.Text == "")
                txtColorGroupSeq.Text = GenSeqNo(dgvColorGroup, "colColorGroupSeq");
            mdlProductTypePriceColorGroup mdlPtpc = new mdlProductTypePriceColorGroup();
            mdlPtpc.UpperSN = Convert.ToInt32(dgvSizeDetails.Rows[dgvSizeDetails.CurrentRow.Index].Cells["colSizeSN"].Value);
            mdlPtpc.Seq = txtColorGroupSeq.Text.Trim();
            mdlPtpc.ColorGroup = "";
            mdlPtpc.ValueDesc = txtValueDesc.Text.Trim();
            mdlPtpc.Price = txtPrice.Text == "" ? 0 : Convert.ToDecimal(txtPrice.Text);
            mdlPtpc.Curr = lueCurr.Text;
            result = clsMmProductTypeStdPrice.SaveColorGroup(mdlPtpc);
            if (result != "")
                MessageBox.Show(result);
            else
            {
                LoadColorGroup(dgvSizeDetails.CurrentRow.Index);
            }
            return result;
        }

        private void btnAddColorDetails_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvColorDetails.Rows.Count; i++)
            {
                if (txtColorID.Text.Trim() == dgvColorDetails.Rows[i].Cells["colColorID"].Value.ToString().Trim())
                {
                    MessageBox.Show("此顏色代號已存在!");
                    return;
                }
            }
            SaveColorDetails();
        }
        private string SaveColorDetails()
        {
            string result = "";
            if (txtColorID.Text.Trim()=="")
            {
                MessageBox.Show("顏色代號不能為空!");
                txtColorID.Focus();
                return result;
            }
            if (txtColorSeq.Text == "")
                txtColorSeq.Text = GenSeqNo(dgvColorDetails, "colColorSeq");
            mdlProductTypePriceColorDetails mdlPtpcd = new mdlProductTypePriceColorDetails();
            mdlPtpcd.UpperSN = Convert.ToInt32(dgvColorGroup.Rows[dgvColorGroup.CurrentRow.Index].Cells["colColorGroupSN"].Value);
            mdlPtpcd.Seq = txtColorSeq.Text;
            mdlPtpcd.ColorID = txtColorID.Text;
            mdlPtpcd.ColorName = txtColorName.Text;
            result = clsMmProductTypeStdPrice.SaveColorDetails(mdlPtpcd);
            if (result != "")
                MessageBox.Show(result);
            else
            {
                LoadColorDetails(dgvColorGroup.CurrentRow.Index);
            }
            return result;
        }
        private void dgvColorDetails_SelectionChanged(object sender, EventArgs e)
        {
            int row = dgvColorDetails.CurrentRow.Index;
            DataGridViewRow dr = dgvColorDetails.Rows[row];
            txtColorSeq.Text = dr.Cells["colColorSeq"].Value.ToString();
            txtColorID.Text = dr.Cells["colColorID"].Value.ToString();
            txtColorName.Text = dr.Cells["colColorName"].Value.ToString();
        }

        private void btnSaveColorDetails_Click(object sender, EventArgs e)
        {
            SaveColorDetails();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            LoadData("ZZZZZZ");
        }

        private void txtSizeID_Leave(object sender, EventArgs e)
        {
            DataTable dtSize = clsMmProductTypeStdPrice.GetSize(txtSizeID.Text);
            if (dtSize.Rows.Count > 0)
                txtSizeName.Text = dtSize.Rows[0]["SizeName"].ToString().Trim();
            else
                txtSizeName.Text = "";
        }

        private void txtColorID_Leave(object sender, EventArgs e)
        {
            DataTable dtColor = clsMmProductTypeStdPrice.GetColor(txtColorID.Text);
            if (dtColor.Rows.Count > 0)
                txtColorName.Text = dtColor.Rows[0]["ColorName"].ToString().Trim();
            else
                txtColorName.Text = "";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            searchState = "Y";
            if (frmProductTypeStdPriceFind == null)
            {
                frmProductTypeStdPriceFind = new frmProductTypeStdPriceFind();
            }
            frmProductTypeStdPriceFind.ShowDialog();
            if(searchID!="")
            {
                txtID.Text = searchID;
                LoadData(txtID.Text);
            }
        }
    }
}
