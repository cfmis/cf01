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
        //private DataTable dtSizeGroup = new DataTable();
        //private DataTable dtColorGroup = new DataTable();
        //private DataTable dtColorDetails = new DataTable();
        frmProductTypeStdPriceFind frmProductTypeStdPriceFind;
        public static string searchColorGroup;
        public static string searchSizeGroup;
        public static string searchState;
        public static string searchID = ""; 
        public DataTable dtSizeGroupCopy = new DataTable();
        public frmProductTypeStdPrice()
        {
            InitializeComponent();
            dgvSizeGroup.AutoGenerateColumns = false;
            dgvColorGroup.AutoGenerateColumns = false;
            dgvColorDetails.AutoGenerateColumns = false;
            dgvSizeDetails.AutoGenerateColumns = false;
            dgvSizeGroupCopy.AutoGenerateColumns = false;
            dtSizeGroupCopy = clsMmProductTypeStdPrice.LoadPrdSizeGroup(-100);
            dtSizeGroupCopy.Columns.Add("SelectFlag", typeof(bool));
            dgvSizeGroupCopy.DataSource = dtSizeGroupCopy;
        }
        private void LoadData(string ID)
        {
            if (ID == "")
                return;
            txtID.ReadOnly = false;
            DataTable dtProductType = clsMmProductTypeStdPrice.LoadProductType(ID);
            if (dtProductType.Rows.Count > 0)
            {
                DataRow dr = dtProductType.Rows[0];
                txtArtWork.Text = dr["ArtWork"].ToString();
                txtProductType.Text = dr["ProductType"].ToString();
                txtRemark.Text = dr["Remark"].ToString();
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
                txtBasePrice.Text = "";
                cmbUnit.Text = "";
                txtRemark.Text = "";
            }
            LoadPrdSizeGroup();
            LoadColorGroup(0);
            LoadColorDetails();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductType.Text.Trim() == "" && txtArtWork.Text.Trim() == "")
            {
                MessageBox.Show("沒有儲存的記錄!");
                return;
            }
            mdlProductTypePrice mdlPtp = new mdlProductTypePrice();
            mdlPtp.ID = txtID.Text.Trim();
            mdlPtp.Ver = txtVer.Text == "" ? 0 : Convert.ToInt32(txtVer.Text);
            mdlPtp.ArtWork = txtArtWork.Text;
            mdlPtp.ProductType = txtProductType.Text;
            mdlPtp.Remark = txtRemark.Text;
            string result=clsMmProductTypeStdPrice.Save(mdlPtp);
            txtID.Text = result;
            txtID.ReadOnly = false;
            LoadData(txtID.Text.Trim());
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            LoadData(txtID.Text.Trim());
        }


        private string SaveSizeGroup()
        {
            string result = "";
            if (txtSN.Text.Trim() == "")
            {
                MessageBox.Show("沒有可編輯的記錄!");
                return result;
            }
            if (txtSizeID.Text.Trim() == "")
            {
                MessageBox.Show("尺寸代號不能為空!");
                return result;
            }
            bool appendMode = false;
            if (txtSizeGroupSeq.Text == "")
            {
                txtSizeGroupSeq.Text = GenSeqNo(dgvSizeGroup, "colSizeGroupSeq");
                appendMode = true;
            }
            mdlProductTypePriceSize mdlMtps = new mdlProductTypePriceSize();
            mdlMtps.UpperSN = txtSN.Text == "" ? 0 : Convert.ToInt32(txtSN.Text);
            mdlMtps.Seq = txtSizeGroupSeq.Text.Trim();
            mdlMtps.SizeGroup = txtSizeGroup.Text.Trim();
            mdlMtps.SizeID = txtSizeID.Text.Trim();
            mdlMtps.SizeName = txtSizeName.Text.Trim();
            mdlMtps.BasePrice = txtBasePrice.Text.Trim() != "" ? Convert.ToDecimal(txtBasePrice.Text) : 0;
            mdlMtps.Unit = cmbUnit.Text.Trim();
            result = clsMmProductTypeStdPrice.SavePrdSizeGroup(mdlMtps);
            if (result != "")
                MessageBox.Show(result);
            else
            {
                int oldCurrentRow = dgvSizeGroup.CurrentRow.Index;
                if (appendMode == true)
                    oldCurrentRow = dgvSizeGroup.Rows.Count;
                LoadPrdSizeGroup();
                dgvSizeGroup.CurrentCell = dgvSizeGroup.Rows[oldCurrentRow].Cells[0];
                dgvSizeGroupSelectRow(oldCurrentRow);
            }
            return result;
        }
        private void LoadPrdSizeGroup()
        {
            int SN = txtSN.Text == "" ? 0 : Convert.ToInt32(txtSN.Text);
            DataTable dtSizeGroup = clsMmProductTypeStdPrice.LoadPrdSizeGroup(Convert.ToInt32(SN));
            dgvSizeGroup.DataSource = dtSizeGroup;
            if(dtSizeGroup.Rows.Count==0)
            {
                txtSizeGroup.Text = "";
                txtSizeGroupSeq.Text = "";
                txtSizeID.Text = "";
                txtSizeName.Text = "";
                txtBasePrice.Text = "";
                cmbUnit.Text = "";
                txtAddCharge1.Text = "";
                txtAddCharge2.Text = "";
                txtAddCharge3.Text = "";
                chkAddCharge1.Checked = false;
                chkAddCharge2.Checked = false;
                chkAddCharge3.Checked = false;
            }
        }
        private void btnAddColorGroup_Click(object sender, EventArgs e)
        {
            txtColorGroup.Text = "";
            txtValueDesc.Text = "";
            txtColorGroupSeq.Text = "";
            txtRate.Text = "";
            txtPrice.Text = "";
            lueCurr.Text = "";
            txtValueRemark.Text = "";
            chkAddCharge1.Checked = false;
            chkAddCharge2.Checked = false;
            chkAddCharge3.Checked = false;
            txtColorGroup.Focus();
            //SaveColorGroup();
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
        private void dgvColorGroupRowSelect(int row)
        {
            DataGridViewRow dr = dgvColorGroup.Rows[row];
            txtColorGroup.Text = dr.Cells["colColorGroup"].Value.ToString();
            txtColorGroupSeq.Text = dr.Cells["colColorGroupSeq"].Value.ToString();
            txtRate.Text = dr.Cells["colRate"].Value.ToString();
            txtPrice.Text = dr.Cells["colPrice"].Value.ToString();
            txtValueDesc.Text = dr.Cells["colValueDesc"].Value.ToString();
            txtValueRemark.Text = dr.Cells["colValueRemark"].Value.ToString();
            lueCurr.Text = dr.Cells["colCurr"].Value.ToString();
            if (dr.Cells["colColorAddCharge1"].Value.ToString() != "0")
                chkAddCharge1.Checked = true;
            else
                chkAddCharge1.Checked = false;
            if (dr.Cells["colColorAddCharge2"].Value.ToString() != "0")
                chkAddCharge2.Checked = true;
            else
                chkAddCharge2.Checked = false;
            if (dr.Cells["colColorAddCharge3"].Value.ToString() != "0")
                chkAddCharge3.Checked = true;
            else
                chkAddCharge3.Checked = false;
            LoadColorDetails();
        }
        private void LoadColorGroup(int row)
        {
            int UpperSN = dgvSizeGroup.Rows.Count == 0 ? -1 : Convert.ToInt32(dgvSizeGroup.Rows[row].Cells["colSizeGroupSN"].Value);
            DataTable dtColorGroup = clsMmProductTypeStdPrice.LoadColorGroup(UpperSN);
            dgvColorGroup.DataSource = dtColorGroup;
            if(dtColorGroup.Rows.Count==0)
            {
                SetColorGroupTextBlank();
            }
        }
        private void SetColorGroupTextBlank()
        {
            txtColorGroup.Text = "";
            txtValueDesc.Text = "";
            txtRate.Text = "";
            txtPrice.Text = "";
            lueCurr.Text = "";
            txtColorGroupSeq.Text = "";
            chkAddCharge1.Checked = false;
            chkAddCharge2.Checked = false;
            chkAddCharge3.Checked = false;
        }
        private void LoadColorDetails()
        {
            //int UpperSN = dgvColorGroup.Rows.Count == 0 ? 0 : Convert.ToInt32(dgvColorGroup.Rows[row].Cells["colColorGroupSN"].Value);
            //dtColorDetails = clsMmProductTypeStdPrice.LoadColorDetails(UpperSN);
            //dgvColorDetails.DataSource = dtColorDetails;
            //if(dtColorDetails.Rows.Count==0)
            //{
            //    txtColorID.Text = "";
            //    txtColorName.Text = "";
            //    txtColorSeq.Text = "";
            //}
            string ColorGroup = "";
            ColorGroup = txtColorGroup.Text == "" ? "CZZZZ" : txtColorGroup.Text;
            DataTable dtColorDetails = clsMmProductTypeStdPrice.LoadColorGroup(ColorGroup, "");
            dgvColorDetails.DataSource = dtColorDetails;


        }


        private void btnSaveColorGroup_Click(object sender, EventArgs e)
        {
            SaveColorGroup();
        }
        private string SaveColorGroup()
        {
            string result = "";
            if (txtColorGroupSeq.Text=="")
            {
                for (int i = 0; i < dgvColorGroup.Rows.Count; i++)
                {
                    if (txtColorGroup.Text.Trim() == dgvColorGroup.Rows[i].Cells["colColorGroup"].Value.ToString().Trim())
                    {
                        MessageBox.Show("此顏色組別已存在!");
                        return result;
                    }
                }
            }
            
            if (dgvSizeGroup.Rows.Count == 0 || dgvSizeGroup.CurrentRow.Index < 0)
            {
                MessageBox.Show("沒有選擇尺寸組別!");
                return result;
            }
            if (txtColorGroup.Text == "")
            {
                MessageBox.Show("顏色組別不能為空!");
                txtColorGroup.Focus();
                return result;
            }
            if (txtPrice.Text == "" || Convert.ToDecimal(txtPrice.Text) == 0)
            {
                MessageBox.Show("價錢不能為空!");
                txtPrice.Focus();
                return result;
            }
            bool appendMode = false;
            if (txtColorGroupSeq.Text == "")
            {
                txtColorGroupSeq.Text = GenSeqNo(dgvColorGroup, "colColorGroupSeq");
                appendMode = true;
            }
            mdlProductTypePriceColorGroup mdlPtpc = new mdlProductTypePriceColorGroup();
            mdlPtpc.UpperSN = Convert.ToInt32(dgvSizeGroup.Rows[dgvSizeGroup.CurrentRow.Index].Cells["colSizeGroupSN"].Value);
            mdlPtpc.Seq = txtColorGroupSeq.Text.Trim();
            mdlPtpc.ColorGroup = txtColorGroup.Text;
            mdlPtpc.ValueDesc = txtValueDesc.Text.Trim();
            mdlPtpc.ValueRemark = txtValueRemark.Text.Trim();
            mdlPtpc.Rate = txtRate.Text == "" ? 0 : Convert.ToDecimal(txtRate.Text);
            mdlPtpc.Price = txtPrice.Text == "" ? 0 : Convert.ToDecimal(txtPrice.Text);
            mdlPtpc.Curr = lueCurr.Text;
            if (chkAddCharge1.Checked == true)
                mdlPtpc.AddCharge1 = txtAddCharge1.Text != "" ? Convert.ToDecimal(txtAddCharge1.Text) : 0;
            else
                mdlPtpc.AddCharge1 = 0;
            if (chkAddCharge2.Checked == true)
                mdlPtpc.AddCharge2 = txtAddCharge2.Text != "" ? Convert.ToDecimal(txtAddCharge2.Text) : 0;
            else
                mdlPtpc.AddCharge2 = 0;
            if (chkAddCharge3.Checked == true)
                mdlPtpc.AddCharge3 = txtAddCharge3.Text != "" ? Convert.ToDecimal(txtAddCharge3.Text) : 0;
            else
                mdlPtpc.AddCharge3 = 0;
            result = clsMmProductTypeStdPrice.SaveColorGroup(mdlPtpc);
            if (result != "")
                MessageBox.Show(result);
            else
            {
                int oldCurrentRow = 0;
                if (dgvColorGroup.Rows.Count > 0)
                    oldCurrentRow = dgvColorGroup.CurrentRow.Index;
                if (appendMode == true)
                    oldCurrentRow = dgvColorGroup.Rows.Count;
                LoadColorGroup(dgvSizeGroup.CurrentRow.Index);
                dgvColorGroup.CurrentCell = dgvColorGroup.Rows[oldCurrentRow].Cells[0];
                dgvColorGroupRowSelect(oldCurrentRow);
                //chkAddCharge1.Checked = false;
                //chkAddCharge2.Checked = false;
                //chkAddCharge3.Checked = false;
            }
            return result;
        }

        private void btnAddColorDetails_Click(object sender, EventArgs e)
        {

        }

        private void dgvColorDetails_SelectionChanged(object sender, EventArgs e)
        {
            //int row = dgvColorDetails.CurrentRow.Index;
            //DataGridViewRow dr = dgvColorDetails.Rows[row];
            //txtColorSeq.Text = dr.Cells["colColorSeq"].Value.ToString();
            //txtColorID.Text = dr.Cells["colColorID"].Value.ToString();
            //txtColorName.Text = dr.Cells["colColorName"].Value.ToString();
        }

        private void btnSaveColorDetails_Click(object sender, EventArgs e)
        {
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtID.ReadOnly = true;
            chkAddCharge1.Checked = false;
            chkAddCharge2.Checked = false;
            chkAddCharge3.Checked = false;
            LoadData("ZZZZZZ");
        }

        private void txtColorID_Leave(object sender, EventArgs e)
        {

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

        private void txtRate_Leave(object sender, EventArgs e)
        {
            CountPrice();
        }
        private void CountPrice()
        {
            decimal Price = 0;
            if (txtBasePrice.Text.Trim() != "" && txtRate.Text.Trim() != "")
                Price = Math.Round(Convert.ToDecimal(txtBasePrice.Text) * Convert.ToDecimal(txtRate.Text), 2);
            else
                Price = 0;
            if (chkAddCharge1.Checked == true)
                Price = Price + (txtAddCharge1.Text == "" ? 0 : Convert.ToDecimal(txtAddCharge1.Text));
            if (chkAddCharge2.Checked == true)
                Price = Price + (txtAddCharge2.Text == "" ? 0 : Convert.ToDecimal(txtAddCharge2.Text));
            if (chkAddCharge3.Checked == true)
                Price = Price + (txtAddCharge3.Text == "" ? 0 : Convert.ToDecimal(txtAddCharge3.Text));
            decimal Pricec = Price - Math.Truncate(Price);
            string Unit = cmbUnit.Text.Trim();
            if (Unit == "GRS" || Unit == "K")
            {
                if (Pricec < (decimal)0.5)
                    Price = Math.Truncate(Price);
                else
                    Price = Math.Truncate(Price) + 1;
            }else if (Unit == "SET" || Unit == "DZ" || Unit == "PCS")
            {
                if (Pricec < (decimal)0.4)
                    Price = Math.Truncate(Price);
                else if (Pricec >= (decimal)0.4 && Pricec < (decimal)0.7)
                    Price = Math.Truncate(Price) + (decimal)0.5;
                else
                    Price = Math.Truncate(Price) + 1;
            }
            txtPrice.Text = Price.ToString();
        }
        private void btnSizeGroup_Click(object sender, EventArgs e)
        {
            frmProductTypeStdPriceSizeGroup frmProductTypeStdPriceSizeGroup = new frmProductTypeStdPriceSizeGroup();
            frmProductTypeStdPriceSizeGroup.ShowDialog();
            if (searchSizeGroup != "")
            {
                txtSizeGroup.Text = searchSizeGroup;
                txtSizeGroup.Focus();
            }
        }

        private void btnColorGroup_Click(object sender, EventArgs e)
        {
            frmProductTypeStdPriceColorGroup frmProductTypeStdPriceColorGroup = new frmProductTypeStdPriceColorGroup();
            frmProductTypeStdPriceColorGroup.ShowDialog();
            if (searchColorGroup != "")
            {
                txtColorGroup.Text = searchColorGroup;
                txtColorGroup.Focus();
            }
        }

        private void txtColorGroup_Leave(object sender, EventArgs e)
        {
            DataTable dtColorDetails = clsMmProductTypeStdPrice.LoadColorGroup(txtColorGroup.Text, "");
            dgvColorDetails.DataSource = dtColorDetails;
            if (dtColorDetails.Rows.Count == 0)
            {
                txtRate.Text = "";
                MessageBox.Show("此顏色組別不存在!");
            }
            else
                txtRate.Text = dtColorDetails.Rows[0]["Rate"].ToString();
            CountPrice();
        }

        private void dgvSizeGroup_SelectionChanged(object sender, EventArgs e)
        {
            dgvSizeGroupSelectRow(dgvSizeGroup.CurrentRow.Index);
        }
        private void dgvSizeGroupSelectRow(int row)
        {
            DataGridViewRow dr = dgvSizeGroup.Rows[row];
            txtSizeGroupSeq.Text = dr.Cells["colSizeGroupSeq"].Value.ToString();
            txtSizeGroup.Text = dr.Cells["colSizeGroup"].Value.ToString();
            txtSizeID.Text = dr.Cells["colSizeID"].Value.ToString();
            txtSizeName.Text = dr.Cells["colSizeName"].Value.ToString();
            txtAddCharge1.Text = dr.Cells["colSizeAddCharge1"].Value.ToString();
            txtAddCharge2.Text = dr.Cells["colSizeAddCharge2"].Value.ToString();
            txtAddCharge3.Text = dr.Cells["colSizeAddCharge3"].Value.ToString();
            txtBasePrice.Text = dr.Cells["colBasePrice"].Value.ToString();
            cmbUnit.Text = dr.Cells["colUnit"].Value.ToString();
            SetColorGroupTextBlank();
            LoadColorGroup(row);
            LoadColorDetails();
        }
        private void txtSizeGroup_Leave(object sender, EventArgs e)
        {
            DataTable dtSizeGroup = clsMmProductTypeStdPrice.LoadSizeDetails(txtSizeGroup.Text,"");
            if (dtSizeGroup.Rows.Count == 0)
                MessageBox.Show("此尺寸組別不存在!");
        }

        private void txtSizeID_Leave(object sender, EventArgs e)
        {
            DataTable dtSize=clsMmProductTypeStdPrice.GetSize(txtSizeID.Text);
            if (dtSize.Rows.Count > 0)
            {
                DataRow drSize = dtSize.Rows[0];
                txtSizeName.Text = drSize["SizeName"].ToString();
                txtAddCharge1.Text = drSize["add_charge1"].ToString();
                txtAddCharge2.Text = drSize["add_charge2"].ToString();
                txtAddCharge3.Text = drSize["add_charge3"].ToString();
            }
            else
            {
                txtSizeName.Text = "";
                txtAddCharge1.Text = "";
                txtAddCharge2.Text = "";
                txtAddCharge3.Text = "";
            }
            //if (txtAddCharge1.Text != "")
            //    chkAddCharge1.Checked = true;
            //else
            //    chkAddCharge1.Checked = false;
            //if (txtAddCharge2.Text != "")
            //    chkAddCharge2.Checked = true;
            //else
            //    chkAddCharge2.Checked = false;
            //if (txtAddCharge3.Text != "")
            //    chkAddCharge3.Checked = true;
            //else
            //    chkAddCharge3.Checked = false;
        }

        private void btnSaveSize_Click(object sender, EventArgs e)
        {
            if(txtSizeGroupSeq.Text=="")
            {
                for (int i = 0; i < dgvSizeGroup.Rows.Count; i++)
                {
                    if (txtSizeID.Text.Trim() == dgvSizeGroup.Rows[i].Cells["colSizeID"].Value.ToString().Trim())
                    {
                        MessageBox.Show("此尺寸代號已存在!");
                        return;
                    }
                }
            }
            SaveSizeGroup();
        }

        private void txtSizeGroup1_Leave(object sender, EventArgs e)
        {
            LoadSizeDetails();
        }
        private void LoadSizeDetails()
        { 
            DataTable dtSizeDetails = clsMmProductTypeStdPrice.LoadSizeDetails(txtSizeGroup1.Text, "");
            if (dtSizeDetails.Rows.Count == 0)
                MessageBox.Show("此尺寸組別不存在!");
            dgvSizeDetails.DataSource = dtSizeDetails;
            if (dgvSizeDetails.Rows.Count > 0)
                chkSelectSizeFlag.Checked = true;
            else
                chkSelectSizeFlag.Checked = false;
        }

        private void btnFindSizeGroup_Click(object sender, EventArgs e)
        {
            LoadSizeDetails();
        }

        private void btnAddSizeGroup_Click(object sender, EventArgs e)
        {
            if(txtSN.Text.Trim()=="")
            {
                MessageBox.Show("沒有可編輯的記錄!");
                return;
            }
            
            if (xTC1.SelectedTabPageIndex == 0)
            {
                if (dgvSizeDetails.Rows.Count == 0)
                {
                    MessageBox.Show("沒有要添加的記錄!");
                    return;
                }
                for (int i = 0; i < dgvSizeDetails.Rows.Count; i++)
                {
                    if ((bool)dgvSizeDetails.Rows[i].Cells["colSelectSizeFlag"].Value == true)
                    {
                        string SizeID = "";
                        bool ExistFlag = false;
                        DataGridViewRow drSD = dgvSizeDetails.Rows[i];
                        SizeID = drSD.Cells["colSizeIDDetails"].Value.ToString().Trim();
                        for (int j = 0; j < dgvSizeGroup.Rows.Count; j++)
                        {
                            if (SizeID == dgvSizeGroup.Rows[j].Cells["colSizeID"].Value.ToString().Trim())
                            {
                                ExistFlag = true;
                                break;
                            }
                        }
                        if (ExistFlag == false)
                        {
                            string result = "";
                            string Seq = "";
                            Seq = GenSeqNo(dgvSizeGroup, "colSizeGroupSeq");
                            mdlProductTypePriceSize mdlMtps = new mdlProductTypePriceSize();
                            mdlMtps.UpperSN = txtSN.Text == "" ? 0 : Convert.ToInt32(txtSN.Text);
                            mdlMtps.Seq = Seq;
                            mdlMtps.SizeGroup = drSD.Cells["colSizeGroupDetails"].Value.ToString().Trim();
                            mdlMtps.SizeID = SizeID;
                            mdlMtps.SizeName = drSD.Cells["colSizeNameDetails"].Value.ToString().Trim();
                            mdlMtps.BasePrice = 0;
                            mdlMtps.Unit = "";
                            result = clsMmProductTypeStdPrice.SavePrdSizeGroup(mdlMtps);
                            if (result != "")
                                MessageBox.Show(result);
                            else
                                LoadPrdSizeGroup();
                        }
                    }
                }
            }else
            {
                if (dgvSizeGroupCopy.Rows.Count == 0)
                {
                    MessageBox.Show("沒有要添加的記錄!");
                    return;
                }
                for (int i = 0; i < dgvSizeGroupCopy.Rows.Count; i++)
                {
                    if ((bool)dgvSizeGroupCopy.Rows[i].Cells["colSelectFlagCopy"].Value == true)
                    {
                        string SizeID = "";
                        bool ExistFlag = false;
                        DataGridViewRow drSD = dgvSizeGroupCopy.Rows[i];
                        SizeID = drSD.Cells["colSizeIDCopy"].Value.ToString().Trim();
                        for (int j = 0; j < dgvSizeGroup.Rows.Count; j++)
                        {
                            if (SizeID == dgvSizeGroup.Rows[j].Cells["colSizeID"].Value.ToString().Trim())
                            {
                                ExistFlag = true;
                                break;
                            }
                        }
                        if (ExistFlag == false)
                        {
                            string result = "";
                            string Seq = "";
                            Seq = GenSeqNo(dgvSizeGroup, "colSizeGroupSeq");
                            mdlProductTypePriceSize mdlMtps = new mdlProductTypePriceSize();
                            mdlMtps.UpperSN = txtSN.Text == "" ? 0 : Convert.ToInt32(txtSN.Text);
                            mdlMtps.Seq = Seq;
                            mdlMtps.SizeGroup = drSD.Cells["colSizeGroupCopy"].Value.ToString().Trim();
                            mdlMtps.SizeID = SizeID;
                            mdlMtps.SizeName = drSD.Cells["colSizeNameCopy"].Value.ToString().Trim();
                            mdlMtps.BasePrice = drSD.Cells["colBasePriceCopy"].Value.ToString().Trim() != "" ? Convert.ToDecimal(drSD.Cells["colBasePriceCopy"].Value) : 0;
                            mdlMtps.Unit= drSD.Cells["colUnitCopy"].Value.ToString().Trim();
                            result = clsMmProductTypeStdPrice.SavePrdSizeGroup(mdlMtps);
                            if (result != "")
                                MessageBox.Show(result);
                            else
                                LoadPrdSizeGroup();
                        }
                    }
                }
            }
        }

        private void btnDelSize_Click(object sender, EventArgs e)
        {
            if (dgvSizeGroup.Rows.Count == 0)
                return;
            int SN = Convert.ToInt32(dgvSizeGroup.Rows[dgvSizeGroup.CurrentRow.Index].Cells["colSizeGroupSN"].Value.ToString());
            string result = "";
            result = clsMmProductTypeStdPrice.DeletePrdSizeGroup(SN);
            if (result != "")
                MessageBox.Show(result);
            else
                LoadPrdSizeGroup();
        }

        private void frmProductTypeStdPrice_Load(object sender, EventArgs e)
        {
            DataTable dtUnit = clsBs_Unit.LoadUnit("0");
            for (int i = 0; i < dtUnit.Rows.Count; i++)
            {
                cmbUnit.Properties.Items.Add(dtUnit.Rows[i]["unit_id"].ToString().Trim());
            }
        }



        private void chkAddCharge1_CheckedChanged(object sender, EventArgs e)
        {
            CountPrice();
        }

        private void chkAddCharge2_CheckedChanged(object sender, EventArgs e)
        {
            CountPrice();
        }

        private void chkAddCharge3_CheckedChanged(object sender, EventArgs e)
        {
            CountPrice();
        }

        private void txtAddCharge1_Leave(object sender, EventArgs e)
        {
            CountPrice();
        }

        private void txtAddCharge2_Leave(object sender, EventArgs e)
        {
            CountPrice();
        }

        private void txtAddCharge3_Leave(object sender, EventArgs e)
        {
            CountPrice();
        }

        private void txtBasePrice_Leave(object sender, EventArgs e)
        {
            CountPrice();
        }

        private void cmbUnit_Leave(object sender, EventArgs e)
        {
            CountPrice();
        }

        private void btnDelColorGroup_Click(object sender, EventArgs e)
        {
            if (dgvColorGroup.Rows.Count == 0)
                return;
            int SN = Convert.ToInt32(dgvColorGroup.Rows[dgvColorGroup.CurrentRow.Index].Cells["colColorGroupSN"].Value.ToString());
            string result = "";
            result = clsMmProductTypeStdPrice.DeletePrdColorGroup(SN);
            if (result != "")
                MessageBox.Show(result);
            else
            {
                int row = dgvSizeGroup.CurrentRow.Index;
                LoadColorGroup(row);
                LoadColorDetails();
            }
        }

        private void chkSelectSizeFlag_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSizeDetails.Rows.Count; i++)
            {
                dgvSizeDetails.Rows[i].Cells["colSelectSizeFlag"].Value = chkSelectSizeFlag.Checked;
            }
        }

        private void dgvColorGroup_SelectionChanged(object sender, EventArgs e)
        {
            dgvColorGroupRowSelect(dgvColorGroup.CurrentRow.Index);
        }

        private void dgvColorGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvColorGroupRowSelect(dgvColorGroup.CurrentRow.Index);
        }

        private void dgvSizeGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSizeGroupSelectRow(dgvSizeGroup.CurrentRow.Index);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確認將此單複製成新的單號嗎？", "Confirm Message", MessageBoxButtons.OKCancel,MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                return;
            if(txtID.Text.Trim()=="")
            {
                MessageBox.Show("單號不存在!");
                return;
            }
            string result = clsMmProductTypeStdPrice.CopyID(txtID.Text.Trim(), Convert.ToInt32(txtSN.Text));
            txtID.Text = result;
            LoadData(txtID.Text.Trim());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確認刪除此單的記錄嗎？", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                return;
            if (txtID.Text.Trim() == "")
            {
                MessageBox.Show("單號不存在!");
                return;
            }
            string result = clsMmProductTypeStdPrice.DeleteID(txtID.Text.Trim(), Convert.ToInt32(txtSN.Text));
            LoadData(txtID.Text.Trim());
            txtID.Text = "";
        }

        private void btnAddArtWork_Click(object sender, EventArgs e)
        {
            if(txtSN.Text=="")
            {
                MessageBox.Show("沒有主表記錄!");
                return;
            }
            frmProductTypeStdPriceArtwork frmProductTypeStdPriceArtwork = new frmProductTypeStdPriceArtwork();
            frmProductTypeStdPriceArtwork.UpperSN = Convert.ToInt32(txtSN.Text);
            frmProductTypeStdPriceArtwork.ShowDialog();
        }

        private void btnCopyLine_Click(object sender, EventArgs e)
        {
            if (dgvSizeGroup.Rows.Count == 0)
                return;
            DataGridViewRow dr = dgvSizeGroup.Rows[dgvSizeGroup.CurrentRow.Index];
            DataRow drSizeGroup = dtSizeGroupCopy.NewRow();
            drSizeGroup["SelectFlag"] = false;
            drSizeGroup["Seq"] = dr.Cells["colSizeGroupSeq"].Value;
            drSizeGroup["SizeGroup"] = dr.Cells["colSizeGroup"].Value; 
            drSizeGroup["SizeID"] = dr.Cells["colSizeID"].Value;
            drSizeGroup["SizeName"] = dr.Cells["colSizeName"].Value;
            drSizeGroup["BasePrice"] = dr.Cells["colBasePrice"].Value;
            drSizeGroup["Unit"] = dr.Cells["colUnit"].Value;
            drSizeGroup["add_charge1"] = dr.Cells["colSizeAddCharge1"].Value;
            drSizeGroup["add_charge2"] = dr.Cells["colSizeAddCharge2"].Value;
            drSizeGroup["add_charge3"] = dr.Cells["colSizeAddCharge3"].Value;
            drSizeGroup["SizeStyle"] = dr.Cells["colSizeStyle"].Value;
            dtSizeGroupCopy.Rows.Add(drSizeGroup);
            dgvSizeGroupCopy.DataSource = dtSizeGroupCopy;
        }

        private void btnCleanCopy_Click(object sender, EventArgs e)
        {
            if (dgvSizeGroupCopy.Rows.Count == 0)
                return;
            DataRow dr = dtSizeGroupCopy.Rows[dgvSizeGroupCopy.CurrentRow.Index];
            dtSizeGroupCopy.Rows.Remove(dr);
            dgvSizeGroupCopy.DataSource = dtSizeGroupCopy;
        }

        private void chkSelectFlagCopy_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSizeGroupCopy.Rows.Count; i++)
            {
                dgvSizeGroupCopy.Rows[i].Cells["colSelectFlagCopy"].Value = chkSelectFlagCopy.Checked;
            }
        }

        private void btnAddSize_Click(object sender, EventArgs e)
        {

            //txtSizeGroup.Text = "";
            txtSizeGroupSeq.Text = "";
            txtSizeID.Text = "";
            txtSizeName.Text = "";
            //txtBasePrice.Text = "";
            //cmbUnit.Text = "";
            //chkAddCharge1.Checked = false;
            //txtAddCharge1.Text = "";
            //chkAddCharge2.Checked = false;
            //txtAddCharge2.Text = "";
            //chkAddCharge3.Checked = false;
            //txtAddCharge3.Text = "";
            txtSizeID.Focus();
            //SaveSizeGroup();

        }
    }
}
