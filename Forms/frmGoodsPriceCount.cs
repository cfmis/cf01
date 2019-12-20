using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using cf01.CLS;
using cf01.MDL;
using cf01.MM;

namespace cf01.Forms
{
    public partial class frmGoodsPriceCount : Form
    {
        private string edit_flag = "1";
        private string userid = DBUtility._user_id;
        private bool append_mode = true;
        private bool edit_mode = true;
        private string within_code = DBUtility.within_code;
        public static string get_formula_type = "";
        public static string get_plate_price = "0";
        public static string get_plate_type = "";
        private string remote_db = DBUtility.remote_db;
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        
        public frmGoodsPriceCount()
        {
            InitializeComponent();
        }


        private bool findBomHead()
        {
            bool result = true;
            MenuTree.Nodes.Clear();
            string prd_item = txtPrd_item.Text;
            string strSql = "";
            int _type = 0;
            int select_type = 0;
            if (rdbFromBom.Checked == true)//从BOM中查找
                select_type = 0;
            else
                select_type = 1;//从OC中查找
            if (rdbNoSet.Checked == true)
                _type = 0;
            else
                if (rdbIsSet.Checked == true)
                    _type = 1;
                else
                    if (rdbAll.Checked == true)
                        _type = 2;
            SqlParameter[] paras;
            if (select_type == 0)//从BOM中查找
            {
                strSql = @"usp_goods_price_count";
                paras = new SqlParameter[] {
               new SqlParameter("@_type",_type),
               new SqlParameter("@prd_item",prd_item)
                };
            }
            else//从OC中查找
            {
                
                strSql = @"usp_goods_price_count_oc";
                paras = new SqlParameter[] {
               new SqlParameter("@_type",_type),
               new SqlParameter("@prd_item",prd_item),
               new SqlParameter("@dat1",mktDat1.Text),
               new SqlParameter("@dat2",Convert.ToDateTime(mktDat2.Text).AddDays(1).ToString("yyyy/MM/dd"))
                };
            }

            DataTable dtBom_h = clsPublicOfCF01.ExecuteProcedureReturnTable(strSql, paras);
            dgvDetails.DataSource = dtBom_h;
            if (dgvDetails.Rows.Count > 0)
            {
                //if (dgvDetails.Rows.Count == 1)
                //{
                //    showBomTree(0);
                //}
            }
            else
            {
                result = false;

            }

            return result;
        }


        protected void InitMenu(string pid)
        {
            MenuTree.Nodes.Clear();

            //添加主菜单
            TreeNode TopNode;
            
            string strSql = "";
            strSql = " SELECT a.id,a.goods_id,b.name AS goods_name " +
                " FROM it_bom_mostly a " +
                " LEFT JOIN it_goods b ON a.within_code=b.within_code  AND a.goods_id=b.id" +
                " WHERE a.within_code='" + within_code + "' AND a.goods_id='" + pid + "'";
            DataTable dtBom_h = clsConErp.GetDataTable(strSql);
            if (dtBom_h.Rows.Count > 0)
            {
                string id=dtBom_h.Rows[0]["id"].ToString();
                string goods_id=dtBom_h.Rows[0]["goods_id"].ToString();
                string goods_name=dtBom_h.Rows[0]["goods_name"].ToString();
                TopNode = new TreeNode();
                TopNode.Text = goods_id + "[" + goods_name + "]";
                TopNode.Tag = id;//goods_id ;//保存表單名
                TopNode.ImageIndex = 2;
                MenuTree.Nodes.Add(TopNode);
                AddRoutingBom(TopNode, goods_id);//添加Routing
                AddChildNode(TopNode, goods_id);//递归调用
                MenuTree.ExpandAll();//展開
                //TopNode.ImageIndex = TopNode.SelectedImageIndex = 2;                        
            }
            
        }


        /// <summary>
        /// 递归调用方法，添加菜单的子菜单
        /// </summary>
        /// <param name="tsi"></param>
        public void AddChildNode(TreeNode subNode, string pid)
        {
            //DataRow[] drArr = dt.Select(String.Format("Pid={0} and Uname='{1}'", pid, userName));//查出这个菜单的所有的子菜单            
            //if (drArr.Length == 0)
            //{
            //    subNode.ImageIndex = subNode.SelectedImageIndex = 1;
            //}

            string strSql = "";

            //strSql = " SELECT id,goods_id FROM it_bom_mostly WHERE within_code='" + within_code + "' AND goods_id='" + pid + "'";
            //DataTable dtBom_h = clsConErp.GetDataTable(strSql);

            //string id = dtBom_h.Rows[0]["id"].ToString();

            //strSql = " SELECT id,goods_id FROM it_bom WHERE within_code='" + within_code + "' AND id='" + id + "'";


            strSql = " SELECT a.id,a.goods_id,b.id AS d_id,b.goods_id AS d_goods_id,c.name AS goods_name" +
                " FROM it_bom_mostly a" +
                " INNER JOIN it_bom b ON a.within_code=b.within_code AND a.id=b.id" +
                " LEFT JOIN it_goods c ON b.within_code=c.within_code  AND b.goods_id=c.id" +
                " WHERE a.within_code='" + within_code + "' AND a.goods_id='" + pid + "'";

            TreeNode subNode1;
            DataTable dtBom_d = clsConErp.GetDataTable(strSql);
            if (dtBom_d.Rows.Count == 0)
            {
                subNode.ImageIndex = 3;
            }
            else
            {
                for (int i = 0; i < dtBom_d.Rows.Count; i++)
                {
                    //DataRow[] drArr = dtBom_d.Select("id>='' ");
                    ////if (drArr.Length == 0)
                    ////{
                    ////    subNode.ImageIndex = subNode.SelectedImageIndex = 1;
                    ////}


                    //foreach (DataRow dr in drArr)
                    //{
                    string ppid = dtBom_d.Rows[i]["d_goods_id"].ToString();
                    string d_id = dtBom_d.Rows[i]["d_id"].ToString();
                    string goods_name = dtBom_d.Rows[0]["goods_name"].ToString();
                    subNode1 = new TreeNode();//实例化一个菜单项
                    subNode1.Text = ppid + "[" + goods_name + "]";//实例化一个菜单项
                    subNode1.Tag = d_id;//保存表單名
                    subNode1.ImageIndex = 2;
                    subNode.Nodes.Add(subNode1);

                    AddRoutingBom(subNode1, ppid);//添加Routing

                    //break;
                    AddChildNode(subNode1, ppid);//递归调用的方法                     
                    //InitMenu(ppid);
                    //}
                }
            }
        }

        private void showBomTree(int rows)
        {
            string pid = dgvDetails.Rows[rows].Cells["colPrd_item"].Value.ToString();


            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();

            //**********************
            InitMenu(pid); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });


            
        }
        private void AddRoutingBom(TreeNode subNode,string goods_id)
        {
            string strSql = "";
            TreeNode subNode1 = new TreeNode();
            TreeNode subNode2;
            strSql = "Select a.goods_id,a.routing_id,b.cdesc AS routing_cdesc" +
                " From bs_routing_bom a " +
                " Left Join bs_routing b On a.routing_id=b.id " +
                " Where goods_id='" + goods_id + "'" +
                " Order By a.prd_sort";
            DataTable dtRoutingBom = clsPublicOfCF01.GetDataTable(strSql);
            if (dtRoutingBom.Rows.Count > 0)
            {
                //subNode1 = new TreeNode();//实例化一个菜单项
                subNode1.Text = "工序" + "[" + goods_id + "]";//实例化一个菜单项
                subNode1.Tag = goods_id + "-01";//保存表單名
                subNode1.ImageIndex = 0;
                subNode.Nodes.Add(subNode1);
            }
            for (int j = 0; j < dtRoutingBom.Rows.Count; j++)
            {
                subNode2 = new TreeNode();//实例化一个菜单项
                subNode2.Text = dtRoutingBom.Rows[j]["routing_id"].ToString() + "[" + dtRoutingBom.Rows[j]["routing_cdesc"].ToString() + "]";//实例化一个菜单项 (goods_id)
                subNode2.Tag = goods_id + "-01";//保存表單名
                subNode2.ImageIndex = 1;
                subNode1.Nodes.Add(subNode2);
            }
        }

        private void countUnitPrice()
        {
            if (edit_mode == false)
                return;
            //if (!checkNumberValid())
            //    return;
            double result_a, result_b, result_c1, result_c2, result_c3, result_c4;
            double number_a, number_b, number_c, number_d, number_e, number_f, number_g;
            double rate_a, rate_d;
            number_a = (txtNumber_A.Text != "" ? Convert.ToSingle(txtNumber_A.Text) : 0);
            rate_a = (txtRate_A.Text != "" ? Convert.ToSingle(txtRate_A.Text) : 1);
            number_b = (txtNumber_B.Text != "" ? Convert.ToSingle(txtNumber_B.Text) : 0);
            result_a = Math.Round((number_a / rate_a) * number_b, 3);
            txtResult_A.Text = result_a.ToString();
            //txtNumber_C.Text = Math.Round(result_a * number_b, 3).ToString();
            number_c = (txtNumber_C.Text != "" ? Convert.ToSingle(txtNumber_C.Text) : 0);
            number_d = (txtNumber_D.Text != "" ? Convert.ToSingle(txtNumber_D.Text) : 0);
            rate_d = (txtRate_D.Text != "" ? Convert.ToSingle(txtRate_D.Text) : 1);
            number_e = (txtNumber_E.Text != "" ? Convert.ToSingle(txtNumber_E.Text) : 0);
            result_b = Math.Round((number_d / rate_d) * number_e * number_c, 3);
            txtResult_B.Text = result_b.ToString();
            number_f = (txtNumber_F.Text != "" ? Convert.ToSingle(txtNumber_F.Text) : 0);
            number_g = (txtNumber_G.Text != "" ? Convert.ToSingle(txtNumber_G.Text) : 0);
            result_c1 = Math.Round(result_a + (result_b * number_f * number_g), 3);
            result_c2 = Math.Round(result_c1 * 144, 3);
            result_c3 = Math.Round(result_c1 * 1000, 3);
            result_c4 = Math.Round(result_c1 * 12, 3);
            txtResult_C1.Text = result_c1.ToString();
            txtResult_C2.Text = result_c2.ToString();
            txtResult_C3.Text = result_c3.ToString();
            txtResult_C4.Text = result_c4.ToString();

        }
        private void countMatCost(int row)
        {
            if (dgvWipMat.Rows.Count == 0)
                return;
            //int i = dgvWipMat.CurrentCell.RowIndex;
            DataGridViewRow CurrentRow = this.dgvWipMat.Rows[row];
            CurrentRow.Cells["colMFormula_type"].Value = txtId.Text;
            CurrentRow.Cells["colMMat_type"].Value = txtMat_type.Text;
            CurrentRow.Cells["colMNumber_a"].Value = txtNumber_A.Text;
            CurrentRow.Cells["colMRate_a"].Value = (txtRate_A.Text != "" ? Convert.ToSingle(txtRate_A.Text) : 1);
            CurrentRow.Cells["colMNumber_b"].Value = txtNumber_B.Text;
            CurrentRow.Cells["colMResult_a"].Value = txtResult_A.Text;
            CurrentRow.Cells["colMNumber_c"].Value = txtNumber_C.Text;
            CurrentRow.Cells["colMNumber_d"].Value = txtNumber_D.Text;
            CurrentRow.Cells["colMRate_d"].Value = (txtRate_D.Text != "" ? Convert.ToSingle(txtRate_D.Text) : 1);
            CurrentRow.Cells["colMNumber_e"].Value = txtNumber_E.Text;
            CurrentRow.Cells["colMResult_b"].Value = txtResult_B.Text;
            CurrentRow.Cells["colMNumber_f"].Value = txtNumber_F.Text;
            CurrentRow.Cells["colMNumber_g"].Value = txtNumber_G.Text;
            CurrentRow.Cells["colMResult_c1"].Value = txtResult_C1.Text;
            CurrentRow.Cells["colMResult_c2"].Value = txtResult_C2.Text;
            CurrentRow.Cells["colMResult_c3"].Value = txtResult_C3.Text;
            CurrentRow.Cells["colMResult_c4"].Value = txtResult_C4.Text;

            sumGoodsCost();
        }
        private void sumGoodsCost()
        {
            double result_a, result_b, result_c1, result_c2, result_c3, result_c4;
            //double number_a, number_b, number_c, number_d, number_e, number_f, number_g;
            //double rate_a, rate_d;
            result_a = 0;
            result_b = 0;
            result_c1 = 0;
            result_c2 = 0;
            result_c3 = 0;
            result_c4 = 0;
            DataGridViewRow CurrentRow;
            for (int i = 0; i < dgvWipMat.Rows.Count; i++)
            {
                CurrentRow = this.dgvWipMat.Rows[i];
                if (CurrentRow.Cells["colMChk"].Value != null && (bool)CurrentRow.Cells["colMChk"].Value == true)
                {
                    result_a = result_a + (CurrentRow.Cells["colMResult_a"].Value != null && CurrentRow.Cells["colMResult_a"].Value.ToString() != "" ? Convert.ToDouble(CurrentRow.Cells["colMResult_a"].Value) : 0);
                    result_b = result_b + (CurrentRow.Cells["colMResult_b"].Value != null && CurrentRow.Cells["colMResult_b"].Value.ToString() != "" ? Convert.ToDouble(CurrentRow.Cells["colMResult_b"].Value) : 0);
                    result_c1 = result_c1 + (CurrentRow.Cells["colMResult_c1"].Value != null && CurrentRow.Cells["colMResult_c1"].Value.ToString() != "" ? Convert.ToDouble(CurrentRow.Cells["colMResult_c1"].Value) : 0);
                    result_c2 = result_c2 + (CurrentRow.Cells["colMResult_c2"].Value != null && CurrentRow.Cells["colMResult_c2"].Value.ToString() != "" ? Convert.ToDouble(CurrentRow.Cells["colMResult_c2"].Value) : 0);
                    result_c3 = result_c3 + (CurrentRow.Cells["colMResult_c3"].Value != null && CurrentRow.Cells["colMResult_c3"].Value.ToString() != "" ? Convert.ToDouble(CurrentRow.Cells["colMResult_c3"].Value) : 0);
                    result_c4 = result_c4 + (CurrentRow.Cells["colMResult_c4"].Value != null && CurrentRow.Cells["colMResult_c4"].Value.ToString() != "" ? Convert.ToDouble(CurrentRow.Cells["colMResult_c4"].Value) : 0);
                }
            }

            //CurrentRow = this.dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex];
            //CurrentRow.Cells["colResult_a"].Value=result_a;
            //CurrentRow.Cells["colResult_b"].Value = result_b;
            //CurrentRow.Cells["colResult_c1"].Value = result_c1;
            //CurrentRow.Cells["colResult_c2"].Value = result_c2;
            //CurrentRow.Cells["colResult_c3"].Value = result_c3;
            //CurrentRow.Cells["colResult_c4"].Value = result_c4;
            txtGResult_A.Text = "";
            txtGResult_B.Text = "";
            txtGResult_C1.Text = "";
            txtGResult_C2.Text = "";
            txtGResult_C3.Text = "";
            txtGResult_C4.Text = "";
            txtGResult_A.Text = result_a.ToString();
            txtGResult_B.Text = result_b.ToString();
            txtGResult_C1.Text = result_c1.ToString();
            txtGResult_C2.Text = result_c2.ToString();
            txtGResult_C3.Text = result_c3.ToString();
            txtGResult_C4.Text = result_c4.ToString();
        }
        private bool checkNumberValid()
        {
            bool result = true;
            //if (txtNumber_A.Text == "")
            //    result = false;
            //if (txtRate_A.Text == "")
            //    result = false;
            //if (txtNumber_B.Text == "")
            //    result = false;
            //if (txtNumber_C.Text == "")
            //    result = false;
            //if (txtNumber_D.Text == "")
            //    result = false;
            //if (txtNumber_E.Text == "")
            //    result = false;
            //if (txtRate_D.Text == "")
            //    result = false;
            //if (txtNumber_E.Text == "")
            //    result = false;
            //if (txtNumber_F.Text == "")
            //    result = false;
            //if (txtNumber_G.Text == "")
            //    result = false;
            return result;

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtUnitRate.Text = "";
            if (rdbFromBom.Checked==true && txtPrd_item.Text == "")
                return;
            if (rdbFromOc.Checked == true)
            {
                if (clsValidRule.CheckDateIsEmpty(this.mktDat1.Text) == false || clsValidRule.CheckDateIsEmpty(this.mktDat2.Text) == false)
                {
                    if (clsValidRule.CheckDateFormat(this.mktDat1.Text) == false || clsValidRule.CheckDateFormat(this.mktDat2.Text) == false)
                    {
                        MessageBox.Show("計劃單日期格式不正確!");
                        this.mktDat1.Focus();
                        return;
                    }
                }
            }
            dgvWipDetails.DataSource = null;
            dgvWipMat.DataSource = null;
            findData();
        }
        private void findData()
        {
            chkSelectAll.Checked = false;
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            bool result;
            //**********************
            result = findBomHead(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            if (result == false)
                MessageBox.Show("沒有找到符合條件的記錄!");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtId.Focus();
            Save();
        }
        private void Save()
        {
            string result = "";
            string strSql = "";
            string prd_item = "";
            int ver = 0;
            string bom_id = "";
            string cdesc = "";
            cdesc = txtCdesc.Text;
            string formula_type = txtId.Text;
            string ref_prd_mo = txtOcMo_id.Text;
            float result_a, result_b, result_c1, result_c2, result_c3, result_c4;
            float number_a, number_b, number_c, number_d, number_e, number_f, number_g;
            float rate_a, rate_d;
            number_a = (txtNumber_A.Text != "" ? Convert.ToSingle(txtNumber_A.Text) : 0);
            rate_a = (txtRate_A.Text != "" ? Convert.ToSingle(txtRate_A.Text) : 0);
            number_b = (txtNumber_B.Text != "" ? Convert.ToSingle(txtNumber_B.Text) : 0);
            result_a = (txtGResult_A.Text != "" ? Convert.ToSingle(txtGResult_A.Text) : 0);
            number_c = (txtNumber_C.Text != "" ? Convert.ToSingle(txtNumber_C.Text) : 0);
            number_d = (txtNumber_D.Text != "" ? Convert.ToSingle(txtNumber_D.Text) : 0);
            rate_d = (txtRate_D.Text != "" ? Convert.ToSingle(txtRate_D.Text) : 0);
            number_e = (txtNumber_E.Text != "" ? Convert.ToSingle(txtNumber_E.Text) : 0);
            result_b = (txtGResult_B.Text != "" ? Convert.ToSingle(txtGResult_B.Text) : 0);
            number_f = (txtNumber_F.Text != "" ? Convert.ToSingle(txtNumber_F.Text) : 0);
            number_g = (txtNumber_G.Text != "" ? Convert.ToSingle(txtNumber_G.Text) : 0);
            result_c1 = (txtGResult_C1.Text != "" ? Convert.ToSingle(txtGResult_C1.Text) : 0);
            result_c2 = (txtGResult_C2.Text != "" ? Convert.ToSingle(txtGResult_C2.Text) : 0);
            result_c3 = (txtGResult_C3.Text != "" ? Convert.ToSingle(txtGResult_C3.Text) : 0);
            result_c4 = (txtGResult_C4.Text != "" ? Convert.ToSingle(txtGResult_C4.Text) : 0);


//            for (int i = 0; i < dgvDetails.Rows.Count; i++)
//            {
//                if (dgvDetails.Rows[i].Cells["colChk"].Value != null && (bool)dgvDetails.Rows[i].Cells["colChk"].Value == true)
//                {
//                    prd_item = dgvDetails.Rows[i].Cells["colPrd_item"].Value.ToString();
//                    bom_id = dgvDetails.Rows[i].Cells["colBomId"].Value.ToString();
//                    strSql += string.Format(@"INSERT INTO mm_goods_price_count (within_code,prd_item,bom_id,cdesc,ver,formula_type,number_a,rate_a
//                        ,number_b,result_a,number_c,number_d,rate_d
//                        ,number_e,result_b,number_f,number_g,result_c1,result_c2,result_c3,result_c4,crusr,crtim)
//                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'
//                        ,'{15}','{16}','{17}','{18}','{19}','{20}','{21}',GETDATE())"
//                        ,within_code, prd_item,bom_id, cdesc,ver, formula_type, number_a, rate_a, number_b, result_a, number_c, number_d, rate_d
//                        , number_e, result_b, number_f, number_g, result_c1, result_c2, result_c3, result_c4, userid);

//                }
//            }



            prd_item = txtGoods_id.Text.Trim();
            bom_id = dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["colBomId"].Value.ToString();
            if (checkExistId(prd_item) == false)
            {

                strSql += string.Format(@"INSERT INTO mm_goods_price_count (within_code,prd_item,bom_id,cdesc,ver,formula_type,ref_prd_mo,number_a,rate_a
                        ,number_b,result_a,number_c,number_d,rate_d
                        ,number_e,result_b,number_f,number_g,result_c1,result_c2,result_c3,result_c4,crusr,crtim)
                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'
                        ,'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}',GETDATE())"
                    , within_code, prd_item, bom_id, cdesc, ver, formula_type, ref_prd_mo, number_a, rate_a, number_b, result_a, number_c, number_d, rate_d
                    , number_e, result_b, number_f, number_g, result_c1, result_c2, result_c3, result_c4, userid);

            }
            else
                strSql += string.Format(@"UPDATE mm_goods_price_count SET bom_id='{0}',cdesc='{1}',ver='{2}',formula_type='{3}',number_a='{4}',rate_a='{5}'
                        ,number_b='{6}',result_a='{7}',number_c='{8}',number_d='{9}',rate_d='{10}'
                        ,number_e='{11}',result_b='{12}',number_f='{13}',number_g='{14}',result_c1='{15}',result_c2='{16}',result_c3='{17}',result_c4='{18}',crusr='{19}'
                        ,ref_prd_mo='{20}',crtim=GETDATE()
                        WHERE within_code='{21}' AND prd_item='{22}'"
                            , bom_id, cdesc, ver, formula_type, number_a, rate_a, number_b, result_a, number_c, number_d, rate_d
                            , number_e, result_b, number_f, number_g, result_c1, result_c2, result_c3, result_c4, userid, ref_prd_mo, within_code, prd_item);
            bom_id = prd_item;
            DataGridViewRow CurrentRow;
            for (int j = 0; j < dgvWipMat.Rows.Count; j++)
            {
                CurrentRow=dgvWipMat.Rows[j];
                if (CurrentRow.Cells["colMChk"].Value != null && (bool)CurrentRow.Cells["colMChk"].Value == true)
                {
                    prd_item = dgvWipMat.Rows[j].Cells["colMGoods_id"].Value.ToString();
                    cdesc = "";
                    formula_type = CurrentRow.Cells["colMFormula_type"].Value.ToString();
                    number_a = (CurrentRow.Cells["colMNumber_a"].Value != null && CurrentRow.Cells["colMNumber_a"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMNumber_a"].Value) : 0);
                    rate_a = (CurrentRow.Cells["colMRate_a"].Value != null && CurrentRow.Cells["colMRate_a"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMRate_a"].Value) : 0);
                    number_b = (CurrentRow.Cells["colMNumber_b"].Value != null && CurrentRow.Cells["colMNumber_b"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMNumber_b"].Value) : 0);
                    number_c = (CurrentRow.Cells["colMNumber_c"].Value != null && CurrentRow.Cells["colMNumber_c"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMNumber_c"].Value) : 0);
                    number_d = (CurrentRow.Cells["colMNumber_d"].Value != null && CurrentRow.Cells["colMNumber_d"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMNumber_d"].Value) : 0);
                    rate_d = (CurrentRow.Cells["colMRate_d"].Value != null && CurrentRow.Cells["colMRate_d"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMRate_d"].Value) : 0);
                    number_e = (CurrentRow.Cells["colMNumber_e"].Value != null && CurrentRow.Cells["colMNumber_e"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMNumber_e"].Value) : 0);
                    number_f = (CurrentRow.Cells["colMNumber_f"].Value != null && CurrentRow.Cells["colMNumber_f"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMNumber_f"].Value) : 0);
                    number_g = (CurrentRow.Cells["colMResult_a"].Value != null && CurrentRow.Cells["colMResult_a"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMResult_a"].Value) : 0);
                    result_a = (CurrentRow.Cells["colMResult_a"].Value != null && CurrentRow.Cells["colMResult_a"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMResult_a"].Value) : 0);
                    result_b = (CurrentRow.Cells["colMResult_b"].Value != null && CurrentRow.Cells["colMResult_b"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMResult_b"].Value) : 0);
                    result_c1 = (CurrentRow.Cells["colMResult_c1"].Value != null && CurrentRow.Cells["colMResult_c1"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMResult_c1"].Value) : 0);
                    result_c2 = (CurrentRow.Cells["colMResult_c2"].Value != null && CurrentRow.Cells["colMResult_c2"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMResult_c2"].Value) : 0);
                    result_c3 = (CurrentRow.Cells["colMResult_c3"].Value != null && CurrentRow.Cells["colMResult_c3"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMResult_c3"].Value) : 0);
                    result_c4 = (CurrentRow.Cells["colMResult_c4"].Value != null && CurrentRow.Cells["colMResult_c4"].Value.ToString() != "" ? Convert.ToSingle(CurrentRow.Cells["colMResult_c4"].Value) : 0);
                    if (checkExistId(prd_item) == false)
                    {


                        strSql += string.Format(@"INSERT INTO mm_goods_price_count (within_code,prd_item,bom_id,cdesc,ver,formula_type,ref_prd_mo,number_a,rate_a
                        ,number_b,result_a,number_c,number_d,rate_d
                        ,number_e,result_b,number_f,number_g,result_c1,result_c2,result_c3,result_c4,crusr,crtim)
                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'
                        ,'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}',GETDATE())"
                            , within_code, prd_item, bom_id, cdesc, ver, formula_type, ref_prd_mo, number_a, rate_a, number_b, result_a, number_c, number_d, rate_d
                            , number_e, result_b, number_f, number_g, result_c1, result_c2, result_c3, result_c4, userid);
                    }
                    else
                        strSql += string.Format(@"UPDATE mm_goods_price_count SET bom_id='{0}',cdesc='{1}',ver='{2}',formula_type='{3}',number_a='{4}',rate_a='{5}'
                        ,number_b='{6}',result_a='{7}',number_c='{8}',number_d='{9}',rate_d='{10}'
                        ,number_e='{11}',result_b='{12}',number_f='{13}',number_g='{14}',result_c1='{15}',result_c2='{16}',result_c3='{17}',result_c4='{18}',crusr='{19}'
                        ,ref_prd_mo='{20}',crtim=GETDATE()
                        WHERE within_code='{21}' AND prd_item='{22}'"
                            , bom_id, cdesc, ver, formula_type, number_a, rate_a, number_b, result_a, number_c, number_d, rate_d
                            , number_e, result_b, number_f, number_g, result_c1, result_c2, result_c3, result_c4, userid, ref_prd_mo, within_code, prd_item);
                }
            }
            if (strSql != "")
                result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result != "")
                MessageBox.Show("儲存記錄失敗!");
            else
            {
                edit_flag = "0";
                append_mode = false;
                edit_mode = false;
                chkSelectAll.Checked = false;
                rdbIsSet.Checked = true;
                findData();
                //setTextBoxEnabled();
            }


        }
        private bool checkExistId(string prd_item)
        {
            string strSql = "";

            strSql = "Select prd_item From mm_goods_price_count Where prd_item='" + prd_item + "'";
            if (clsPublicOfCF01.GetDataTable(strSql).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                dgvDetails.Rows[i].Cells["colChk"].Value = chkSelectAll.Checked;
            }
        }

        private void frmGoodsPriceCount_Load(object sender, EventArgs e)
        {
            dgvDetails.AutoGenerateColumns = false;
            dgvWipDetails.AutoGenerateColumns = false;
            dgvWipMat.AutoGenerateColumns = false;
            mktDat1.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            mktDat2.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void loadFormula(string id,string mat_type)
        {
            if (txtId.Text == "" && txtMat_type.Text=="")
                return;
            string strSql;
            strSql = "Select * from mm_goods_price_formula where id>=''";
            if (id != "")
                strSql += " and  id='" + id + "'";
            if (mat_type != "")
                strSql += " and  mat_type='" + txtMat_type.Text + "'";
            cleanFormula();
            DataTable dtPrice = clsPublicOfCF01.GetDataTable(strSql);
            if (dtPrice.Rows.Count == 0)
            {
                MessageBox.Show("公式不存在!");
                return;
            }

            txtId.Text = dtPrice.Rows[0]["id"].ToString();
            txtMat_type.Text = dtPrice.Rows[0]["mat_type"].ToString();
            txtCdesc.Text = dtPrice.Rows[0]["cdesc"].ToString();
            txtNumber_A.Text = dtPrice.Rows[0]["number_a"].ToString();
            txtNumber_B.Text = dtPrice.Rows[0]["number_b"].ToString();
            txtNumber_C.Text = dtPrice.Rows[0]["number_c"].ToString();
            txtNumber_D.Text = dtPrice.Rows[0]["number_d"].ToString();
            txtNumber_E.Text = dtPrice.Rows[0]["number_e"].ToString();
            txtNumber_F.Text = dtPrice.Rows[0]["number_f"].ToString();
            txtNumber_G.Text = dtPrice.Rows[0]["number_g"].ToString();
            txtRate_A.Text = dtPrice.Rows[0]["rate_a"].ToString();
            txtRate_D.Text = dtPrice.Rows[0]["rate_d"].ToString();
            txtResult_A.Text = dtPrice.Rows[0]["result_a"].ToString();
            txtResult_B.Text = dtPrice.Rows[0]["result_b"].ToString();
            txtResult_C1.Text = dtPrice.Rows[0]["result_c1"].ToString();
            txtResult_C2.Text = dtPrice.Rows[0]["result_c2"].ToString();
            txtResult_C3.Text = dtPrice.Rows[0]["result_c3"].ToString();
            txtResult_C4.Text = dtPrice.Rows[0]["result_c4"].ToString();
            
        }
        private void cleanFormula()
        {
            txtId.Text = "";
            txtMat_type.Text = "";
            txtCdesc.Text = "";
            txtNumber_A.Text = "0";
            txtNumber_B.Text = "0";
            txtNumber_C.Text = "0";
            txtNumber_D.Text = "0";
            txtNumber_E.Text = "0";
            txtNumber_F.Text = "0";
            txtNumber_G.Text = "0";
            txtRate_A.Text = "1000";
            txtRate_D.Text = "1000";
            txtResult_A.Text = "0";
            txtResult_B.Text = "0";
            txtResult_C1.Text = "0";
            txtResult_C2.Text = "0";
            txtResult_C3.Text = "0";
            txtResult_C4.Text = "0";
        }
        private void cleanTextBox()
        {
            //txtId.Text = "";
            txtCdesc.Text = "";

            txtRate_A.Text = "";
            txtRate_D.Text = "";
            txtNumber_A.Text = "";
            txtNumber_B.Text = "";
            txtNumber_C.Text = "";
            txtNumber_D.Text = "";
            txtNumber_E.Text = "";
            txtNumber_E.Text = "";
            txtNumber_F.Text = "";
            txtNumber_G.Text = "";
            txtResult_A.Text = "0";
            txtResult_B.Text = "0";
            txtResult_C1.Text = "0";
            txtResult_C2.Text = "0";
            txtResult_C3.Text = "0";
            txtResult_C4.Text = "0";
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            loadFormula(txtId.Text,"");
        }

        private void btnShowBom_Click(object sender, EventArgs e)
        {
            txtUnitRate.Text = "";
            if (dgvDetails.Rows.Count > 0)
            {
                showBomTree(dgvDetails.CurrentCell.RowIndex);
            }
        }

        private void btnShowFormula_Click(object sender, EventArgs e)
        {
            frmGoodsPriceFormula frmFormulaFind = new frmGoodsPriceFormula();
            frmFormulaFind.ShowDialog();
            if (get_formula_type != "")
            {
                txtId.Text = get_formula_type;
                loadFormula(txtId.Text, "");
                if (dgvWipMat.Rows.Count > 0)
                    countMatCost(dgvWipMat.CurrentCell.RowIndex);//填入數值到表格中
            }
            get_formula_type = "";
            frmFormulaFind.Dispose();
        }

        private void btnShowWip_Click(object sender, EventArgs e)
        {
            txtUnitRate.Text = "";
            if (dgvDetails.Rows.Count > 0)
            {
                findItemFromOc();
            }
        }
        private void findItemFromOc()
        {
            string prd_item = dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["colPrd_item"].Value.ToString();
            string strSql = "";
            strSql = "Select b.mo_id From so_order_manage a" +
                " INNER JOIN so_order_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                " WHERE b.within_code='" + within_code + "' AND b.goods_id='" + prd_item + "' AND a.state<>'2' ";
            strSql += " ORDER BY a.order_date DESC,b.mo_id";
            DataTable dtOc = clsConErp.GetDataTable(strSql);
            if (dtOc.Rows.Count > 0)
            {
                txtOcMo_id.Text = dtOc.Rows[0]["mo_id"].ToString();
                showWipDetails(txtOcMo_id.Text);
            }
        }

        private void showWipDetails(string mo_id)
        {
            dgvWipDetails.DataSource = null;
            dgvWipMat.DataSource = null;
            string strSql = "";
            strSql = "Select a.mo_id,b.flag,b.goods_id,c.name AS goods_name,c.do_color,CONVERT(INT,b.s_qty) AS s_qty" +
                ",CONVERT(INT,b.prod_qty) AS prod_qty,CONVERT(INT,b.obligate_qty) AS obligate_qty" +
                ",b.wp_id,b.next_wp_id,CONVERT(INT,b.c_qty_ok) AS c_qty_ok,CONVERT(decimal(18,2),b.c_sec_qty_ok) AS c_sec_qty_ok" +
                ",CONVERT(VARCHAR(20),b.f_complete_date,120) AS f_complete_date" +
                ",b.id,b.ver,b.sequence_id" +
                " INTO #tb0 "+
                " From jo_bill_mostly a" +
                " INNER JOIN jo_bill_goods_details b ON a.within_code=b.within_code AND a.id=b.id AND a.ver=b.ver" +
                " LEFT JOIN it_goods c ON b.within_code=c.within_code AND b.goods_id=c.id" +
                " WHERE a.within_code='" + within_code + "' AND a.mo_id='" + mo_id + "'";
            strSql += " UPDATE #tb0 SET flag='0'+flag WHERE LEN(RTRIM(flag))=2 ";
            strSql += " SELECT * FROM #tb0 ORDER BY flag";
            strSql += " DROP TABLE #tb0";//sequence_id
            DataTable dtWipDetails = clsConErp.GetDataTable(strSql);
            dgvWipDetails.DataSource = dtWipDetails;
            if (dtWipDetails.Rows.Count > 0)
            {
                string id = dgvWipDetails.Rows[dgvWipDetails.CurrentCell.RowIndex].Cells["colWgoods_id"].Value.ToString();//
                loadUnitRate(id);
                showWipMatDetails(dgvWipDetails.Rows.Count - 1);//顯示F0的成份
            }
        }
        private void showWipMatDetails(int row)
        {
            
            string id = dgvWipDetails.Rows[row].Cells["colWid"].Value.ToString();
            string seq = dgvWipDetails.Rows[row].Cells["colWseq"].Value.ToString();
            string strSql = "";
            strSql = "Select b.sequence_id,b.materiel_id,c.name AS goods_name,c.do_color,CONVERT(INT,b.fl_qty) AS fl_qty,CONVERT(decimal(18,2),b.sec_qty) AS sec_qty" +
                ",b.location,CONVERT(INT,b.i_qty) AS i_qty" +
                ",d.bom_id,d.ver,d.formula_type,e.cdesc,e.mat_type,d.result_a,d.result_b,d.result_c1,d.result_c2,d.result_c3,d.result_c4" +
                ",d.number_a,d.number_b,d.number_c,d.number_d,d.number_e,d.number_f,d.number_g" +
                ",d.rate_a,d.rate_b,d.rate_c,d.rate_d" +
                ",d.crusr,Convert(varchar(20),d.crtim,120) AS crtim" +
                " FROM " + remote_db + "jo_bill_materiel_details b" +
                " LEFT JOIN " + remote_db + "it_goods c ON b.within_code=c.within_code AND b.materiel_id=c.id ";
            strSql += " LEFT JOIN mm_goods_price_count d ON b.within_code=d.within_code COLLATE Chinese_Taiwan_Stroke_CI_AS AND b.materiel_id=d.prd_item COLLATE Chinese_Taiwan_Stroke_CI_AS";
            strSql += " LEFT JOIN mm_goods_price_formula e ON d.formula_type=e.id ";
            strSql += " WHERE b.within_code='" + within_code + "' AND b.id='" + id + "' AND b.upper_sequence='" + seq + "'";
            strSql += " ORDER BY b.sequence_id";//sequence_id
            DataTable dtWipMatDetails = clsPublicOfCF01.GetDataTable(strSql);
            dgvWipMat.DataSource = dtWipMatDetails;
            DataGridViewRow CurrentRow;
            for (int i = 0; i < dgvWipMat.Rows.Count; i++)
            {
                CurrentRow = this.dgvWipMat.Rows[i];
                if (CurrentRow.Cells["colMFormula_type"].Value != null && CurrentRow.Cells["colMFormula_type"].Value.ToString() != "")
                {
                    CurrentRow.Cells["colMSelect"].Value = true;
                }
                else
                {
                    txtMat_type.Text = CurrentRow.Cells["colMGoods_id"].Value.ToString().Substring(0, 2);
                    loadFormula("", txtMat_type.Text);
                    countMatCost(i);
                }
                CurrentRow.Cells["colMChk"].Value = true;
            }
            sumGoodsCost();

        }

        private void dgvWipDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //showWipMatDetails(dgvWipDetails.CurrentCell.RowIndex);//2017/05/21暫時不對應顯示流程
            string id = dgvWipDetails.Rows[dgvWipDetails.CurrentCell.RowIndex].Cells["colWgoods_id"].Value.ToString();
            loadUnitRate(id);
        }

        private void btnShowPlate_Click(object sender, EventArgs e)
        {
            if (dgvWipDetails.Rows.Count == 0)
                return;
            int row=dgvWipDetails.CurrentCell.RowIndex;
            frmGoodsPricePlate frmPlate = new frmGoodsPricePlate();
            frmPlate.prd_item = dgvWipDetails.Rows[row].Cells["colWgoods_id"].Value.ToString();
            frmPlate.prd_name = dgvWipDetails.Rows[row].Cells["colWgoods_name"].Value.ToString();
            frmPlate.prd_dep = dgvWipDetails.Rows[row].Cells["colWwp_id"].Value.ToString();

            frmPlate.ShowDialog();
            txtNumber_D.Text = "0";
            //获取电镀单价
            if (get_plate_type != "" & get_plate_price!="")
            {


                if (get_plate_type == "qty")
                    txtNumber_D.Text = get_plate_price;
                else
                {
                    if (txtUnitRate.Text != "" & txtUnitRate.Text != "0")//如果是重量单价，就要转换成每PCS单价
                        txtNumber_D.Text = Math.Round(Convert.ToSingle(get_plate_price) / Convert.ToSingle(txtUnitRate.Text), 3).ToString();
                }
                
            }
            get_plate_type = "";


            frmPlate.Dispose();
        }

        private void MenuTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string id = e.Node.Text.ToString();
            
            int len = id.IndexOf("[");
            if (len == 0)
                return;
            id = id.Substring(0, len);
            loadUnitRate(id);
        }
        private void loadUnitRate(string id)
        {
            txtUnitRate1.Text = "";
            string strSql = "";
            strSql = "Select Convert(INT,a.rate) AS rate" +
                " From it_coding a" +
                " WHERE a.within_code='" + within_code + "' AND a.id='" + id + "'";
            DataTable dtRate = clsConErp.GetDataTable(strSql);
            if (dtRate.Rows.Count > 0)
            {
                if (txtUnitRate.Text == "" || txtUnitRate.Text == "0")
                    txtUnitRate.Text = dtRate.Rows[0]["rate"].ToString();
                txtUnitRate1.Text = dtRate.Rows[0]["rate"].ToString();
            }
        }

        private void txtNumber_A_Leave(object sender, EventArgs e)
        {
            countUnitPrice();
            countMatCost(dgvWipMat.CurrentCell.RowIndex);
        }

        private void dgvWipMat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow CurrentRow = this.dgvWipMat.Rows[dgvWipMat.CurrentCell.RowIndex];
            //if (CurrentRow.Cells["colMSelect"].Value == null || (bool)CurrentRow.Cells["colMSelect"].Value == false)
            //{
            //    txtMat_type.Text = CurrentRow.Cells["colMGoods_id"].Value.ToString().Substring(0, 2);
            //    loadFormula("", txtMat_type.Text);
            //    countMatCost(dgvWipMat.CurrentCell.RowIndex);
                
            //}
            fillFormula();
            //if (dgvWipMat.Rows[dgvWipMat.CurrentCell.RowIndex].Cells["colMChk"].Value != null && (bool)dgvWipMat.Rows[dgvWipMat.CurrentCell.RowIndex].Cells["colMChk"].Value == true)
                sumGoodsCost();
        }
        private void fillFormula()
        {

            DataGridViewRow CurrentRow = this.dgvWipMat.Rows[dgvWipMat.CurrentCell.RowIndex];
            txtId.Text = CurrentRow.Cells["colMFormula_type"].Value.ToString();
            txtNumber_A.Text = CurrentRow.Cells["colMNumber_a"].Value.ToString();
            txtRate_A.Text = CurrentRow.Cells["colMRate_a"].Value.ToString();
            txtNumber_B.Text = CurrentRow.Cells["colMNumber_b"].Value.ToString();
            txtResult_A.Text = CurrentRow.Cells["colMResult_a"].Value.ToString();
            txtNumber_C.Text = CurrentRow.Cells["colMNumber_c"].Value.ToString();
            txtNumber_D.Text = CurrentRow.Cells["colMNumber_d"].Value.ToString();
            txtRate_D.Text = CurrentRow.Cells["colMRate_d"].Value.ToString();
            txtNumber_E.Text = CurrentRow.Cells["colMNumber_e"].Value.ToString();
            txtResult_B.Text=CurrentRow.Cells["colMResult_b"].Value.ToString();
            txtNumber_F.Text=CurrentRow.Cells["colMNumber_f"].Value.ToString();
            txtNumber_G.Text=CurrentRow.Cells["colMNumber_g"].Value.ToString();
            txtResult_C1.Text=CurrentRow.Cells["colMResult_c1"].Value.ToString();
            txtResult_C2.Text=CurrentRow.Cells["colMResult_c2"].Value.ToString();
            txtResult_C3.Text=CurrentRow.Cells["colMResult_c3"].Value.ToString();
            txtResult_C4.Text = CurrentRow.Cells["colMResult_c4"].Value.ToString();
        }
        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGoods_id.Text = dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["colPrd_item"].Value.ToString();
            txtGoods_name.Text = dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["colGoods_name"].Value.ToString();
            findItemFromOc();
        }
    }
}
