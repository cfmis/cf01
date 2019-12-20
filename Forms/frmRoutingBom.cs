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

namespace cf01.Forms
{
    public partial class frmRoutingBom : Form
    {
        private string edit_flag = "1";
        private string userid = DBUtility._user_id;
        private bool append_mode = false;
        private bool edit_mode = false;
        private string within_code = DBUtility.within_code;
        public static string query_goods_id = "";
        public static string query_prd_type = "";
        public static string query_prd_type_cdesc = "";
        public static string query_routing_id = "";
        private string remote_db = DBUtility.remote_db;
        private clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        private bool routing_from_template;
        public frmRoutingBom()
        {
            InitializeComponent();
        }

        private void showBomTree(string pid)
        {
            //string pid = dgvDetails.Rows[rows].Cells["colPrd_item"].Value.ToString();


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
                TopNode.Tag = goods_id+"[]";// id;// ;//保存表單名
                TopNode.ImageIndex = 2;
                TopNode.SelectedImageIndex = 2;
                MenuTree.Nodes.Add(TopNode);
                addRoutingBom(TopNode, goods_id);//添加Routing
                addChildNode(TopNode, goods_id);//递归调用
                MenuTree.ExpandAll();//展開
                //TopNode.ImageIndex = TopNode.SelectedImageIndex = 2;                        
            }
            
        }


        /// <summary>
        /// 递归调用方法，添加菜单的子菜单
        /// </summary>
        /// <param name="tsi"></param>
        public void addChildNode(TreeNode subNode, string pid)
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
                subNode.SelectedImageIndex = 3;
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
                    string goods_name = dtBom_d.Rows[i]["goods_name"].ToString();
                    subNode1 = new TreeNode();//实例化一个菜单项
                    subNode1.Text = ppid + "[" + goods_name + "]";//实例化一个菜单项
                    subNode1.Tag = ppid + "[]";//保存表單名
                    subNode1.ImageIndex = 2;
                    subNode1.SelectedImageIndex = 2;
                    subNode.Nodes.Add(subNode1);

                    addRoutingBom(subNode1, ppid);//添加Routing

                    //break;
                    addChildNode(subNode1, ppid);//递归调用的方法                     
                    //InitMenu(ppid);
                    //}
                }
            }
        }

        
        private void addRoutingBom(TreeNode subNode,string goods_id)
        {
            string text_info = "";
            TreeNode subNode1 = new TreeNode();
            TreeNode subNode2;
            DataTable dtRoutingBom;
            dtRoutingBom = loadRoutingBom(goods_id);//查找物料的Routing
            if (dtRoutingBom.Rows.Count == 0)//若沒找到物料的Routing，就找產品類型的
            {
                string prd_type = "";
                if (goods_id.Substring(0, 2) == "F0")
                    prd_type = txtPrd_Type.Text;
                else
                    prd_type = goods_id.Substring(2, 2);
                dtRoutingBom = loadRoutingBom(prd_type);
                text_info = " ( Template " + prd_type + " )";//說明Routing是從類型中提取
            }
            if (dtRoutingBom.Rows.Count > 0)
            {
                subNode1.Text = "工序" + "{" + goods_id + "}" + text_info;//实例化一个菜单项
                subNode1.Tag = goods_id + "{}";//保存表單名
                subNode1.ImageIndex = 0;
                subNode1.SelectedImageIndex = 0;
                subNode.Nodes.Add(subNode1);
                fillRoutingTreeNode(subNode1, dtRoutingBom);//填入工序TreeView
            }
            else
            {
                subNode1.Text = goods_id + "{" + "未定義工序" + "}";
                subNode1.Tag = goods_id + "{}";//goods_id ;//保存表單名
                subNode1.ImageIndex = 4;
                subNode1.SelectedImageIndex = 4;
                subNode.Nodes.Add(subNode1);
            }

        }
        private DataTable loadRoutingBom(string goods_id)
        {
            string strSql = "";
            strSql = "Select a.goods_id,a.routing_id,b.cdesc AS routing_cdesc,a.prd_sort,a.dep,b.work_time" +
                " From bs_routing_bom a " +
                " Left Join bs_routing b On a.routing_id=b.id And a.dep=b.dep " +
                " Where goods_id='" + goods_id + "'" +
                " Order By a.prd_sort";
            DataTable dtRoutingBom = clsPublicOfCF01.GetDataTable(strSql);
            return dtRoutingBom;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            frmRoutingBom_Find frmRoutingBom_Find = new frmRoutingBom_Find();
            frmRoutingBom_Find.ShowDialog();
            frmRoutingBom_Find.Dispose();
            if (frmRoutingBom.query_goods_id != "")
            {
                tabControl1.SelectedIndex = 0;
                DataTable dtGoods = findGoodsInfo(frmRoutingBom.query_goods_id);
                txtGoods_id.Text = dtGoods.Rows[0]["id"].ToString();
                txtPrd_Type.Text = dtGoods.Rows[0]["prd_type"].ToString();
                txtGoods_Name.Text = dtGoods.Rows[0]["goods_name"].ToString();
                txtPrd_Type_Cdesc.Text = dtGoods.Rows[0]["prd_type_name"].ToString();
                showBomTree(frmRoutingBom.query_goods_id);
            }
            else
            {
                if (frmRoutingBom.query_prd_type != "")
                {
                    tabControl1.SelectedIndex = 1;
                    txtPrd_Type.Text = frmRoutingBom.query_prd_type;
                    txtPrd_Type_Cdesc.Text = frmRoutingBom.query_prd_type_cdesc;
                    changeTabContro();
                }
            }
            //frmRoutingBom.query_goods_id = "";
            

            
        }
        private DataTable findGoodsInfo(string goods_id)
        {
            string strSql = "";
            strSql = "Select a.id,a.name AS goods_name,a.base_class AS prd_type,b.name AS prd_type_name" +
                " FROM it_goods a " +
                " LEFT JOIN cd_goods_class b ON a.within_code=b.within_code AND a.base_class=b.id " +
                "";
            strSql += " Where a.within_code='" + within_code + "'";
            strSql += " AND a.id='" + goods_id + "'";
            DataTable dtGoods = clsConErp.GetDataTable(strSql);
            return dtGoods;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Save();
        }
        private void Save()
        {
            if (edit_mode == false)
            {
                MessageBox.Show("不是編輯狀態!");
                return;
            }
            if (!checkValid())
                return;
            string goods_id, routing_id,dep;
            string crusr = userid;
            string strSql;
            string result;
            int prd_sort = (txtPrd_Sort.Text.Trim() != "" ? Convert.ToInt32(txtPrd_Sort.Text) : 1);
            goods_id = txtGoods_Routing.Text;
            routing_id = txtRouting_id.Text;
            dep = txtDep.Text;
            if (edit_flag == "1")//新增
                strSql = string.Format(@"INSERT INTO bs_routing_bom (goods_id,routing_id,dep,prd_sort,crusr,crtim)
                    VALUES ('{0}','{1}','{2}','{3}','{4}',GETDATE())"
                        , goods_id, routing_id, dep, prd_sort, crusr, userid);
            else
                strSql = string.Format(@"UPDATE bs_routing_bom SET prd_sort='{0}',crusr='{1}',crtim=GETDATE()
                    WHERE goods_id='{2}' AND routing_id='{3}'"
                    , prd_sort, userid, goods_id, routing_id);
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result != "")
                MessageBox.Show("儲存記錄失敗!");
            else
            {
                edit_flag = "0";
                append_mode = false;
                edit_mode = false;
                routing_from_template = false;

                setTextBoxEnabled();
                loadGoodsRounting(goods_id);
                //showBomTree(frmRoutingBom.query_goods_id);
            }

        }

        private bool checkValid()
        {
            if (txtRouting_id.Text == "")
            {
                MessageBox.Show("工序編碼不能為空!");
                txtRouting_id.Focus();
                return false;
            }
            if (edit_flag == "1")//如果是新增狀態，檢查是否已存在編號
            {
                if (checkExistId() == true)
                {
                    MessageBox.Show("編號已存在,不能新增!");
                    return false;
                }
            }
            else
            {
                if (edit_flag == "2")//如果是編輯狀態，檢查是否已存在編號
                {
                    if (checkExistId() == false)
                    {
                        MessageBox.Show("沒有要編輯的記錄!");
                        return false;
                    }
                }
            }
            return true;
        }
        private bool checkExistId()
        {
            string strSql = "Select goods_id From bs_routing_bom Where goods_id='" + txtGoods_Routing.Text + "' AND routing_id='" + txtRouting_id.Text + "'";
            if (clsPublicOfCF01.GetDataTable(strSql).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }


        private void frmGoodsPriceCount_Load(object sender, EventArgs e)
        {

            dgvRouting.AutoGenerateColumns = false;

        }

        //物料編號TreeView
        //單擊菜單時，顯示對應項的資料
        private void MenuTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            cleanRoutingTextBox();
            string id = e.Node.Text.ToString();
            int len = id.IndexOf("[");//點擊第1層，物料編號
            if (len < 0)
            {
                len = id.IndexOf("{");//點擊第2層，工序的物料編號
                if (len >= 0)
                {
                    id = e.Node.Parent.Text.ToString();
                    //len_end = id.IndexOf("}");
                }
                else
                {
                    len = id.IndexOf("(");//點擊第3層，工序代碼
                    if (len >= 0)
                    {
                        id = e.Node.Parent.Parent.Text.ToString();
                        //len_end = id.IndexOf(">");
                    }
                    else
                        return;
                }
                len = id.IndexOf("[");
            }
            int len_end = id.IndexOf("]");
             
            txtGoods_Routing.Text = id.Substring(0, len);
            txtGoods_Routing_Name.Text = id.Substring(len+1, len_end - len - 1);
            id = txtGoods_Routing.Text.Trim();
            loadGoodsRounting(id);//提取物料的工序

            //判斷是否點擊工序代碼，如果是點擊工序代碼，則要提取該工序的所用機器
            id = e.Node.Tag.ToString().Trim();
            len = id.IndexOf("<");
            len_end = id.IndexOf(">");
            if (len >= 0 && len_end >= 0)
            {
                id = id.Substring(0, len);//獲取工序代碼
                findRoutingIdInDgv(id);
            }
        }
        private void loadGoodsRounting(string goods_id)
        {
            routing_from_template = false;
            lblFromTemplate.Visible = false;
            DataTable dtRoutingBom = loadRoutingBom(goods_id);//查找物料的Routing
            if (goods_id.Length != 2)//如果goods_id 是物料編號，因為goods_id有可能是產品類型
            {
                if (dtRoutingBom.Rows.Count == 0)
                {
                    string prd_type = "";
                    if (goods_id.Substring(0, 2) == "F0")
                        prd_type = txtPrd_Type.Text;
                    else
                        prd_type = goods_id.Substring(2, 2);//查找產品類型的Routing
                    dtRoutingBom = loadRoutingBom(prd_type);
                    if (dtRoutingBom.Rows.Count > 0)
                    {
                        routing_from_template = true;
                        lblFromTemplate.Visible = true;
                    }
                }
            }
            dgvRouting.DataSource = dtRoutingBom;
            edit_mode = false;
            fillRoutingTextBox(0);
            loadRoutingSource(0);
        }
        private void findRoutingIdInDgv(string id)
        {
            for (int i = 0; i < dgvRouting.Rows.Count; i++)
            {
                if (id == dgvRouting.Rows[i].Cells["colRRouting_Id"].Value.ToString())
                {
                    dgvRouting.Rows[0].Cells["colRPrd_Sort"].Selected = false;
                    dgvRouting.Rows[i].Cells["colRRouting_Id"].Selected = true;
                    //dgvRouting.Rows[i].Cells["colRRouting_Id"].
                    fillRoutingTextBox(i);
                    loadRoutingSource(i);
                    break;
                }

            }
        }
        private void cleanRoutingTextBox()
        {
            routing_from_template = false;
            txtGoods_Routing.Text = "";
            dgvRouting.DataSource = null;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTabContro();
        }
        private void changeTabContro()
        {
            if (tabControl1.SelectedIndex == 1)
            {
                lblGoods_Routing.Text = "產品類型:";
                prdTypeRouting();
            }
            else
            {
                lblGoods_Routing.Text = "物料編號:";
            }
        }
        private void prdTypeRouting()
        {
            tvRouting.Nodes.Clear();
            //添加主菜单
            TreeNode TopNode = new TreeNode();

            string prd_type = "";
            prd_type = txtPrd_Type.Text;
            DataTable dtRoutingBom = loadRoutingBom(prd_type);
            TopNode.Text = prd_type + "{" + txtPrd_Type_Cdesc.Text.Trim() + "}";
            TopNode.Tag = prd_type + "{}";//goods_id ;//保存表單名
            if (dtRoutingBom.Rows.Count > 0)
            {
                TopNode.ImageIndex = 0;
                TopNode.SelectedImageIndex = 0;
                tvRouting.Nodes.Add(TopNode);
                //fillRoutingTreeNode(TopNode, dtRoutingBom);//填入TreeView
                addChildNodeRouting(TopNode, prd_type);
                tvRouting.ExpandAll();//展開
            }
            else
            {
                TopNode.Text += "{" + "未定義工序" + "}";
                TopNode.ImageIndex = 4;
                TopNode.SelectedImageIndex = 4;
                tvRouting.Nodes.Add(TopNode);
                fillRoutingTreeNode(TopNode, dtRoutingBom);//填入TreeView
            }
            
            
        }


        /// <summary>
        /// 递归调用方法，添加菜单的子菜单
        /// </summary>
        /// <param name="tsi"></param>
        public void addChildNodeRouting(TreeNode subNode, string pid)
        {

            string strSql = "";

            strSql = " SELECT a.id,a.goods_id,b.id AS d_id,b.goods_id AS d_goods_id,c.name AS goods_name" +
                " FROM it_bom_mostly a" +
                " INNER JOIN it_bom b ON a.within_code=b.within_code AND a.id=b.id" +
                " LEFT JOIN it_goods c ON b.within_code=c.within_code  AND b.goods_id=c.id" +
                " WHERE a.within_code='" + within_code + "' AND a.goods_id='" + pid + "'";
            strSql = "SELECT a.goods_id,a.routing_id,a.dep,a.prd_sort,b.cdesc AS routing_name" +
                " FROM bs_routing_bom a" +
                " LEFT JOIN bs_routing b ON a.routing_id=b.id AND a.dep=b.dep"+
                " WHERE a.goods_id='" + pid + "'";
            TreeNode subNode1;
            DataTable dtBom_d = clsPublicOfCF01.GetDataTable(strSql);
            if (dtBom_d.Rows.Count == 0)
            {
                subNode.ImageIndex = 1;
                subNode.SelectedImageIndex = 1;
            }
            else
            {
                for (int i = 0; i < dtBom_d.Rows.Count; i++)
                {

                    string ppid = dtBom_d.Rows[i]["routing_id"].ToString();
                    string routing_name = dtBom_d.Rows[i]["routing_name"].ToString();
                    subNode1 = new TreeNode();//实例化一个菜单项
                    subNode1.Text = ppid + "<" + routing_name + ">";//实例化一个菜单项
                    subNode1.Tag = ppid + "<>";//保存表單名
                    subNode1.ImageIndex = 0;
                    subNode1.SelectedImageIndex = 0;
                    subNode.Nodes.Add(subNode1);

                    //break;
                    addChildNodeRouting(subNode1, ppid);//递归调用的方法                     
                    //InitMenu(ppid);
                    //}
                }
            }
        }


        private void fillRoutingTreeNode(TreeNode subNode, DataTable dtRoutingBom)
        {
            TreeNode subNode1;

            for (int j = 0; j < dtRoutingBom.Rows.Count; j++)
            {

                subNode1 = new TreeNode();//实例化一个菜单项
                subNode1.Text = "(" + dtRoutingBom.Rows[j]["prd_sort"].ToString() + ")" + "-->" + dtRoutingBom.Rows[j]["routing_id"].ToString() + "<" + dtRoutingBom.Rows[j]["routing_cdesc"].ToString() + ">";//实例化一个菜单项 (goods_id)
                subNode1.Tag = dtRoutingBom.Rows[j]["routing_id"].ToString() + "<>";//保存表單名
                subNode1.ImageIndex = 1;
                subNode.Nodes.Add(subNode1);
            }
        }

        private void dgvRouting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillRoutingTextBox(dgvRouting.CurrentCell.RowIndex);
            loadRoutingSource(dgvRouting.CurrentCell.RowIndex);
        }
        private void fillRoutingTextBox(int row)
        {
            if (dgvRouting.Rows.Count == 0)
                return;
            //cleanTextBox(0);//全部清空文本框
            if (edit_mode == false)
            {
                DataGridViewRow CurrentRow = dgvRouting.Rows[row];
                txtPrd_Sort.Text = CurrentRow.Cells["colRPrd_Sort"].Value.ToString();
                txtRouting_id.Text = CurrentRow.Cells["colRRouting_Id"].Value.ToString();
                txtRouting_Cdesc.Text = CurrentRow.Cells["colRPrd_Type_Cdesc"].Value.ToString();
                txtDep.Text = CurrentRow.Cells["colRDep"].Value.ToString();
                txtWork_Time.Text = CurrentRow.Cells["colRWork_Time"].Value.ToString();
            }
        }
        private void loadRoutingSource(int rowNo)
        {
            string routing_id = "", dep = "";
            if (dgvRouting.Rows.Count != 0)
            {
                DataGridViewRow CurrentRow = dgvRouting.Rows[rowNo];
                routing_id = CurrentRow.Cells["colRRouting_Id"].Value.ToString();
                dep = CurrentRow.Cells["colRDep"].Value.ToString();
            }

            string strSql = " Select a.dep,a.routing_id,b.cdesc,a.source_id,d.resource_name" +
                ",Convert(INT,c.standard_qty) AS standard_qty,Convert(INT,c.rows_count) AS rows_count,Convert(INT,c.hours_stele_qty) AS hours_stele_qty" +
                " From bs_routing_source a" +
                " LEFT JOIN bs_routing b ON a.routing_id=b.id AND a.dep=b.dep " +
                " LEFT JOIN " + remote_db + "cd_machine_standard c ON a.source_id=c.machine_id COLLATE Chinese_PRC_CI_AS AND a.dep=c.dept_id COLLATE Chinese_PRC_CI_AS" +
                " LEFT JOIN " + remote_db + "cd_resource d ON c.within_code=d.within_code AND c.dept_id=d.department_id AND c.machine_id=d.resource_id" +
                " Where a.routing_id='" + routing_id + "' AND a.dep='" + dep + "'";
            DataTable dtRoutingSource = clsPublicOfCF01.GetDataTable(strSql);
            dgvRoutingSource.DataSource = dtRoutingSource;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!checkEditState())
                return;
            Edit();
        }
        private void Edit()
        {
            edit_flag = "2";
            append_mode = false;
            edit_mode = true;
            setTextBoxEnabled();
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (!checkEditState())
                return;
            addNew();
        }
        private bool checkEditState()
        {
            bool result = true;
            //if (routing_from_template == true)
            //{
            //    MessageBox.Show("存在從模辦建立的工序，請先儲存!");
            //    result = false;
            //}
            if (txtGoods_Routing.Text.Trim() == "")
            {
                MessageBox.Show("物料編號為空!");
                txtGoods_Routing.Focus();
                result = false;
            }
            return result;
        }
        private void addNew()
        {
            append_mode = true;
            edit_mode = true;
            cleanTextBox(1);
            setTextBoxEnabled();
            edit_flag = "1";
            txtRouting_id.Focus();

        }
        private void cleanTextBox(int clean_part)
        {
            txtPrd_Sort.Text = "";
            txtRouting_id.Text = "";
            txtRouting_Cdesc.Text = "";
            txtDep.Text = "";
        }
        private void setTextBoxEnabled()
        {
            txtRouting_id.ReadOnly = !append_mode;
            if (append_mode == true && edit_mode == true)
                txtRouting_id.BackColor = Color.White;
            else
                txtRouting_id.BackColor = Color.Silver;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                showBomTree(frmRoutingBom.query_goods_id);
            else
                prdTypeRouting();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!checkEditState())
                return;
            Delete();
        }
        private void Delete()
        {
            if (checkExistId() == false)
            {
                MessageBox.Show("沒有要刪除的記錄!");
                return;
            }
            string result;
            string strSql = string.Format(@"DELETE bs_routing_bom WHERE goods_id='{0}' AND routing_id='{1}'", txtGoods_Routing.Text, txtRouting_id.Text);
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result != "")
                MessageBox.Show("刪除記錄失敗!");
            else
            {
                edit_flag = "0";
                append_mode = false;
                edit_mode = false;
                setTextBoxEnabled();
                cleanTextBox(0);//清空全部文本框
                loadGoodsRounting(txtGoods_Routing.Text);
            }
        }

        private void btnSaveBath_Click(object sender, EventArgs e)
        {
            if (routing_from_template == false)
            {
                MessageBox.Show("沒有要儲存的模辦!");
                return;
            }
            if(txtGoods_Routing.Text.Trim()=="")
            {
                MessageBox.Show("物料編號為空!");
                txtGoods_Routing.Focus();
                return;
            }
            string goods_id, routing_id, dep;
            string crusr = userid;
            string strSql = "";
            string result;
            goods_id = txtGoods_Routing.Text.Trim();
            for (int i = 0; i < dgvRouting.Rows.Count; i++)
            {
                int prd_sort = (txtPrd_Sort.Text.Trim() != "" ? Convert.ToInt32(txtPrd_Sort.Text) : 1);
                DataGridViewRow CurrentRow = dgvRouting.Rows[i];
                routing_id = CurrentRow.Cells["colRRouting_Id"].Value.ToString();
                dep = CurrentRow.Cells["colRDep"].Value.ToString();
                prd_sort = (CurrentRow.Cells["colRPrd_Sort"].Value.ToString() != "" ? Convert.ToInt32(CurrentRow.Cells["colRPrd_Sort"].Value) : 1);
                strSql += string.Format(@"INSERT INTO bs_routing_bom (goods_id,routing_id,dep,prd_sort,crusr,crtim)
                    VALUES ('{0}','{1}','{2}','{3}','{4}',GETDATE())"
                        , goods_id, routing_id, dep, prd_sort, crusr, userid);
            }
            if (strSql != "")
            {
                result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
                if (result != "")
                    MessageBox.Show("儲存記錄失敗!");
                else
                {
                    edit_flag = "0";
                    append_mode = false;
                    edit_mode = false;
                    routing_from_template = false;

                    setTextBoxEnabled();
                    loadGoodsRounting(goods_id);
                    MessageBox.Show("儲存記錄成功!");
                    //showBomTree(frmRoutingBom.query_goods_id);
                }
            }
        }

        private void btnShowRouting_Click(object sender, EventArgs e)
        {
            query_goods_id = txtGoods_Routing.Text.Trim();
            frmRouting frmRouting = new frmRouting();
            frmRouting.ShowDialog();
            frmRouting.Dispose();
            if (frmRoutingBom.query_routing_id != "" && edit_mode==true)
            {
                txtRouting_id.Text = frmRoutingBom.query_routing_id;
                loadRouting(txtRouting_id.Text.Trim());
            }
        }
        private void loadRouting(string id)
        {
            string strSql = "Select id,cdesc,dep,work_time From bs_routing Where id='" + id + "'";
            DataTable dtRouting =clsPublicOfCF01.GetDataTable(strSql);
            if (dtRouting.Rows.Count > 0)
            {
                txtRouting_Cdesc.Text = dtRouting.Rows[0]["cdesc"].ToString();
                txtDep.Text = dtRouting.Rows[0]["dep"].ToString();
                txtWork_Time.Text = dtRouting.Rows[0]["work_time"].ToString();
            }
        }
        //產品類型TreeView
        private void tvRouting_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //cleanRoutingTextBox();
            string id = e.Node.Text.ToString();
            id = e.Node.Tag.ToString();
            string id_desc = e.Node.Text.ToString();
            int len = id.IndexOf("{");//點擊第1層，產品類型
            int len_end = 0;
            if (len >= 0)
            {
                len_end = id.IndexOf("}");
            }
            else
            {
                len = id.IndexOf("<");
                if (len >= 0)
                {
                    len_end = id.LastIndexOf(">");

                }
                else
                    return;
            }
            txtGoods_Routing.Text = id.Substring(0, len);
            len = id_desc.IndexOf("{");//點擊第1層，產品類型
            len_end = 0;
            if (len >= 0)
            {
                len_end = id_desc.IndexOf("}");
            }
            else
            {
                len = id_desc.IndexOf("<");
                if (len >= 0)
                {
                    len_end = id_desc.LastIndexOf(">");

                }
                else
                    return;
            }
            
            txtGoods_Routing_Name.Text = id_desc.Substring(len + 1, len_end - len - 1);
            id = txtGoods_Routing.Text.Trim();
            dgvRouting.DataSource = loadTypeRoutingBom(id);
            ////判斷是否點擊工序代碼，如果是點擊工序代碼，則要提取該工序的所用機器
            //id = e.Node.Tag.ToString().Trim();
            //len = id.IndexOf("<");
            //len_end = id.IndexOf(">");
            //if (len >= 0 && len_end >= 0)
            //{
            //    id = id.Substring(0, len);//獲取工序代碼
            //    findRoutingIdInDgv(id);
            //}
        }

        private DataTable loadTypeRoutingBom(string id)
        {
            string strSql = "";
            strSql = "Select a.goods_id,a.routing_id,b.cdesc AS routing_cdesc,a.prd_sort,a.dep,b.work_time" +
                " From bs_routing_bom a " +
                " Left Join bs_routing b On a.routing_id=b.id And a.dep=b.dep " +
                " Where goods_id='" + id + "'" +
                " Order By a.prd_sort";
            DataTable dtRoutingBom = clsPublicOfCF01.GetDataTable(strSql);
            return dtRoutingBom;
        }
    }
}
