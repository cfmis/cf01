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

namespace cf01.Forms
{
    public partial class frmUnitPriceCount : Form
    {
        //clsPublicOfGEO cslGeo = new clsPublicOfGEO();
        private string within_code = DBUtility.within_code;
        public frmUnitPriceCount()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmProgress wForm = new frmProgress();
            new Thread((ThreadStart)delegate
            {
                wForm.TopMost = true;
                wForm.ShowDialog();
            }).Start();
            bool result;
            //**********************
            result=findBomHead(); //数据处理
            //**********************
            wForm.Invoke((EventHandler)delegate { wForm.Close(); });
            if(result==false)
                MessageBox.Show("沒有找到符合條件的記錄!");



        }

        private bool findBomHead()
        {
            bool result = true;
            MenuTree.Nodes.Clear();
            string prd_item = txtPrd_item.Text;
            string strSql = "";
            int _type = 0;
            if (rdbNoSet.Checked == true)
                _type = 0;
            else
                if (rdbIsSet.Checked == true)
                    _type = 1;
                else
                    if (rdbAll.Checked == true)
                        _type = 2;
            strSql = " SELECT a.id,a.goods_id,b.name AS goods_name " +
                " FROM it_bom_mostly a " +
                " LEFT JOIN it_goods b ON a.within_code=b.within_code AND a.goods_id=b.id" +
                " WHERE a.within_code='" + within_code + "' AND a.goods_id like '" + "%" + prd_item + "%'";

            strSql = @"usp_goods_price_count";
            SqlParameter[] paras = new SqlParameter[] {
               new SqlParameter("@_type",_type),
               new SqlParameter("@prd_item",prd_item)
            };


            DataTable dtBom_h = clsPublicOfCF01.ExecuteProcedureReturnTable(strSql, paras);
            dgvDetails.DataSource = dtBom_h;
            if (dgvDetails.Rows.Count > 0)
            {
                showBomTree(0);
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
            DataTable dtBom_h = clsPublicOfGEO.GetDataTable(strSql);
            if (dtBom_h.Rows.Count > 0)
            {
                string id=dtBom_h.Rows[0]["id"].ToString();
                string goods_id=dtBom_h.Rows[0]["goods_id"].ToString();
                string goods_name=dtBom_h.Rows[0]["goods_name"].ToString();
                TopNode = new TreeNode();
                TopNode.Text = goods_id + "--" + goods_name;
                TopNode.Tag = id;// goods_id;//保存表單名                       
                MenuTree.Nodes.Add(TopNode);
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
            //DataTable dtBom_h = clsPublicOfGEO.GetDataTable(strSql);

            //string id = dtBom_h.Rows[0]["id"].ToString();

            //strSql = " SELECT id,goods_id FROM it_bom WHERE within_code='" + within_code + "' AND id='" + id + "'";


            strSql = " SELECT a.id,a.goods_id,b.id AS d_id,b.goods_id AS d_goods_id,c.name AS goods_name" +
                " FROM it_bom_mostly a" +
                " INNER JOIN it_bom b ON a.within_code=b.within_code AND a.id=b.id" +
                " LEFT JOIN it_goods c ON b.within_code=c.within_code  AND b.goods_id=c.id" +
                " WHERE a.within_code='" + within_code + "' AND a.goods_id='" + pid + "'";

            TreeNode subNode1;
            DataTable dtBom_d = clsPublicOfGEO.GetDataTable(strSql);
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
                    subNode1.Text = ppid + "--" + goods_name;//实例化一个菜单项
                    subNode1.Tag = d_id;//保存表單名
                    subNode.Nodes.Add(subNode1);
                    //break;
                    AddChildNode(subNode1, ppid);//递归调用的方法                     
                    //InitMenu(ppid);
                //}
            }
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                showBomTree(dgvDetails.CurrentCell.RowIndex);
            }
        }
        private void showBomTree(int rows)
        {
            string pid = dgvDetails.Rows[rows].Cells["colBomGoods_id"].Value.ToString();


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

    }
}
