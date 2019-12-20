using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MDL;
using System.Data.SqlClient;

namespace cf01.Forms
{
    public partial class frmQuotation_Set_Grant : Form
    {
        private DataTable dtStep1 = new DataTable();
        private DataTable dtStep2_h = new DataTable();
        private DataTable dtStep2_d = new DataTable();
        private DataTable dtStep3 = new DataTable();
        private DataTable dtStep3_del = new DataTable();
        //private mdlGroup_Grant mList = new mdlGroup_Grant();
        private List<mdlGroup_Grant> mList = new List<mdlGroup_Grant>();
      
        public frmQuotation_Set_Grant()
        {
            InitializeComponent();            
        }

        private void frmQuotation_Set_Grant_Load(object sender, EventArgs e)
        {
            this.tabPage2.Parent = null;
            this.tabPage3.Parent = null;
            //Step1
            string strSql=
            @"SELECT Convert(bit,0) as flag_select,A.uname as user_id,A.uname_desc as usrer_name,B.Rname as user_group 
              FROM tb_sy_user A,tb_sy_role B 
              WHERE A.Rid=B.Rid 
              ORDER BY B.Rid,A.Uname";
            dtStep1 = clsPublicOfCF01.GetDataTable(strSql);
            dgvStep1.DataSource = dtStep1;

            //Step2
            strSql = @"Select Convert(bit,0) as flag_select,typ_code AS group_id,typ_cdesc AS group_id_desc,
            Convert(bit,0) as flag_brand,'' as all_brand From bs_type Where typ_group='3' AND typ_code<>'' ";
            dtStep2_h = clsPublicOfCF01.GetDataTable(strSql);
            gridControl1.DataSource = dtStep2_h;

            dtStep2_d.Columns.Add("flag_select", typeof(bool));
            dtStep2_d.Columns.Add("group_id", typeof(string));
            dtStep2_d.Columns.Add("brand_id", typeof(string));
            dtStep2_d.Columns.Add("brand_name", typeof(string)); 
            gridControl2.DataSource = dtStep2_d;
            
            //Step3
            dtStep3.Columns.Add("user_id", typeof(string));
            dtStep3.Columns.Add("group_id", typeof(string));
            dtStep3.Columns.Add("brand_id", typeof(string));
            dtStep3.Columns.Add("flag_old_record", typeof(string));
            dtStep3_del = dtStep3.Clone();
            dgvStep3.DataSource = dtStep3;
           
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            DataRow[] dr = dtStep1.Select("flag_select=true");
            if (dr.Length == 0)
            {
                MessageBox.Show("請至少選擇一用戶!");
                return;
            }
            this.tabPage1.Parent = null;
            this.tabPage2.Parent = tabControl1;
            this.tabPage3.Parent = null;
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrevious2_Click(object sender, EventArgs e)
        {
            this.tabPage1.Parent = tabControl1;
            this.tabPage2.Parent = null;
            this.tabPage3.Parent = null;
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            this.tabPage1.Parent = null;
            this.tabPage2.Parent = null;
            this.tabPage3.Parent = tabControl1;
            Set_Grant_Data();
            dtStep3_del.Clear();
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrevious3_Click(object sender, EventArgs e)
        {
            this.tabPage1.Parent = null;
            this.tabPage2.Parent = tabControl1;
            this.tabPage3.Parent = null;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvStep3.RowCount > 0)
            {
                int cur_row = dgvStep3.CurrentCell.RowIndex;
                DataRow dr = dtStep3_del.NewRow();                
                dr["user_id"] = dtStep3.Rows[cur_row]["user_id"].ToString();
                dr["group_id"] = dtStep3.Rows[cur_row]["group_id"].ToString();
                dr["brand_id"] = dtStep3.Rows[cur_row]["brand_id"].ToString();
                dr["flag_old_record"] = dtStep3.Rows[cur_row]["flag_old_record"].ToString();
                dtStep3_del.Rows.Add(dr);
                dgvStep3.Rows.RemoveAt(cur_row);
            }

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            bool save_flag;            
            //刪除狀態是Y,牌子是"*"的記錄
            string sql_del_mostly_1 = @"Delete FROM dbo.sy_user_group Where usrid=@user_id AND grpid=@group_id AND usrhrst='Y' AND brand_all='*'";
            string sql_del_mostly_2 = @"Delete FROM dbo.sy_user_group Where usrid=@user_id AND grpid=@group_id AND usrhrst='Y' AND isnull(brand_all,'')=''";
            string sql_del_brand = @"Delete FROM dbo.sy_user_group_brand Where userid=@user_id and grpid=@group_id AND brand_id=@brand_id";
            string sql_del_brand_f = "";
            string sql_h_i =@"Insert Into sy_user_group(usrid,grpid,usrusr,usrtim,usrhrst,usrrst,brand_all) 
                             Values(@user_id,@group_id,@user_id,getdate(),'Y',@usrrst,@brand_all)";
            string sql_h_u = @"Update sy_user_group Set usrrst=@usrrst,brand_all=@brand_all WHERE usrid=@user_id AND grpid=@group_id AND usrhrst='Y'";
            string sql_d_i = @"Insert Into sy_user_group_brand(userid,grpid,brand_id,crusr,crtim) Values(@user_id,@group_id,@brand_id,@crusr,getdate())"; 
            SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    
                    //處理刪除開始
                    if (dtStep3_del.Rows.Count > 0)
                    {
                        dtStep3_del.AcceptChanges();
                        for (int i = 0; i < dtStep3_del.Rows.Count; i++)
                        {                           
                            if (!string.IsNullOrEmpty(dtStep3_del.Rows[i]["flag_old_record"].ToString()))
                            {
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@user_id", dtStep3_del.Rows[i]["user_id"].ToString());
                                myCommand.Parameters.AddWithValue("@group_id", dtStep3_del.Rows[i]["group_id"].ToString());                                 
                                if (dtStep3_del.Rows[i]["brand_id"].ToString() == "*")//牌子數標識為* 的舊記錄
                                {
                                    myCommand.CommandText = sql_del_mostly_1;
                                    myCommand.ExecuteNonQuery();
                                }
                                else                                   //牌子數標識不為* 的舊記錄
                                {
                                    sql_del_brand_f = 
                                        string.Format(@"Select '1' FROM dbo.sy_user_group_brand with(nolock) Where userid='{0}' AND grpid='{1}'", 
                                        dtStep3_del.Rows[i]["user_id"].ToString(),dtStep3_del.Rows[i]["group_id"].ToString());
                                    DataTable dtFind = clsPublicOfCF01.GetDataTable(sql_del_brand_f);
                                    if (dtFind.Rows.Count == 1)
                                    {
                                        //用戶組別只有1個牌子時直接刪除組別權限主表中的當前記錄
                                        myCommand.Parameters.Clear();
                                        myCommand.CommandText = sql_del_mostly_2;
                                        myCommand.Parameters.AddWithValue("@user_id", dtStep3_del.Rows[i]["user_id"].ToString());
                                        myCommand.Parameters.AddWithValue("@group_id", dtStep3_del.Rows[i]["group_id"].ToString());
                                        myCommand.ExecuteNonQuery();
                                    }
                                    //用戶組別有多于1個以上的牌子時直接刪除組別權限從表中的當前記錄
                                    myCommand.Parameters.Clear();
                                    myCommand.CommandText = sql_del_brand;
                                    myCommand.Parameters.AddWithValue("@user_id", dtStep3_del.Rows[i]["user_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@group_id", dtStep3_del.Rows[i]["group_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@brand_id", dtStep3_del.Rows[i]["brand_id"].ToString());
                                    myCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    //處理刪除結束

                    for (int i = 0; i < dtStep3.Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(dtStep3.Rows[i]["flag_old_record"].ToString())) //新根限
                        {                           
                            if (dtStep3.Rows[i]["brand_id"].ToString() == "*") //全部牌子
                            {
                                myCommand.Parameters.Clear();
                                myCommand.CommandText = sql_h_i;
                                myCommand.Parameters.AddWithValue("@user_id", dtStep3.Rows[i]["user_id"].ToString());
                                myCommand.Parameters.AddWithValue("@group_id", dtStep3.Rows[i]["group_id"].ToString());                               
                                myCommand.Parameters.AddWithValue("@usrrst", true);
                                myCommand.Parameters.AddWithValue("@brand_all", "*");
                                myCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                //組別下的部分牌子
                                //插入主表
                                string sql_h_f = string.Format(@"Select '1' From dbo.sy_user_group With(nolock) Where usrid='{0}' AND grpid='{1}' AND usrhrst='Y'",
                                    dtStep3.Rows[i]["user_id"].ToString(),dtStep3.Rows[i]["group_id"].ToString());
                                DataTable dtFind = clsPublicOfCF01.GetDataTable(sql_h_f);
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@user_id", dtStep3.Rows[i]["user_id"].ToString());
                                myCommand.Parameters.AddWithValue("@group_id", dtStep3.Rows[i]["group_id"].ToString());
                                myCommand.Parameters.AddWithValue("@usrrst", false);
                                myCommand.Parameters.AddWithValue("@brand_all", "");
                                if (dtFind.Rows.Count > 0)
                                {
                                    myCommand.CommandText = sql_h_u;
                                }
                                else
                                {
                                    myCommand.CommandText = sql_h_i;                            
                                }
                                myCommand.ExecuteNonQuery();

                                //插入從表
                                myCommand.Parameters.Clear();
                                myCommand.CommandText = sql_d_i;
                                myCommand.Parameters.AddWithValue("@user_id", dtStep3.Rows[i]["user_id"].ToString());
                                myCommand.Parameters.AddWithValue("@group_id", dtStep3.Rows[i]["group_id"].ToString());
                                myCommand.Parameters.AddWithValue("@brand_id", dtStep3.Rows[i]["brand_id"].ToString());
                                myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);
                                myCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    myTrans.Commit(); //數據提交
                    save_flag = true;
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    save_flag = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myTrans.Dispose();
                }

                if (save_flag)
                {                    
                    MessageBox.Show("組別權限設置成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Set_Step3_OK_Flag();
                    dtStep3_del.Clear();
                    Clear_Select_Flag();
                }
                else
                {
                    MessageBox.Show("組別權限設置失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }               
            }
        }

        private void Set_Step3_OK_Flag()
        {
            if (dtStep3.Rows.Count > 0)
            {
                for(int i=0;i<dtStep3.Rows.Count;i++)
                {
                    if (string.IsNullOrEmpty(dtStep3.Rows[i]["flag_old_record"].ToString()))
                    {
                        dtStep3.Rows[i]["flag_old_record"] = "Y";
                    }
                }
                dtStep3.AcceptChanges();
            }
        }

        /// <summary>
        /// 清除曾選中的記錄
        /// </summary>
        private void Clear_Select_Flag()
        {
            for (int i = 0; i < dtStep1.Rows.Count; i++)
            {
                if (dtStep1.Rows[i]["flag_select"].ToString() == "True")
                {
                    dtStep1.Rows[i]["flag_select"] = false;              
                }
            }
            dtStep1.AcceptChanges();
    
            for (int i = 0; i < dtStep2_h.Rows.Count; i++)
            {
                if (dtStep2_h.Rows[i]["flag_select"].ToString()=="True")
                {
                    dtStep2_h.Rows[i]["flag_select"] = false;
                    dtStep2_h.Rows[i]["flag_brand"] = false;
                    dtStep2_h.Rows[i]["all_brand"] = "";
                }
            }
            dtStep2_h.AcceptChanges();

            for (int i = 0; i < dtStep2_d.Rows.Count; i++)
            {
                if (dtStep2_d.Rows[i]["flag_select"].ToString() == "True")
                {
                    dtStep2_d.Rows[i]["flag_select"] = false;                       
                }
            }
            dtStep2_d.AcceptChanges();

        }

        private void btnExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clBrand_select_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.CloseEditor();   //關鍵語句,重要,否則CheckBox值不會立即更改
            string strGroup_id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "group_id").ToString();
            DataRow new_row; 
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "flag_select").ToString() == "True")
            {
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "flag_brand").ToString() == "False")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "all_brand", "");
                    //找出組別對應的所有牌子
                    string strSql = string.Format(
                    @"SELECT Distinct CONVERT(bit,0) as flag_select,S.group_id,S.brand_id,S.brand_name
                    FROM
                    (select distinct A.id as brand_id,A.name as brand_name,substring(B.group_id,2,1) as group_id
                    from {0}cd_brand A with(nolock),{0}cd_brand_group B with(nolock)
                    where A.within_code=B.within_code and A.id=B.id) S
                    WHERE S.group_id='{1}' 
                    ORDER BY S.group_id,S.brand_id", DBUtility.remote_db, strGroup_id);
                    DataTable dtBrnd = clsPublicOfCF01.GetDataTable(strSql);

                    if (dtBrnd.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtBrnd.Rows.Count; i++)
                        {
                            new_row = dtStep2_d.NewRow();
                            new_row["flag_select"] = false;
                            new_row["group_id"] = dtBrnd.Rows[i]["group_id"].ToString();
                            new_row["brand_id"] = dtBrnd.Rows[i]["brand_id"].ToString();
                            new_row["brand_name"] = dtBrnd.Rows[i]["brand_name"].ToString();
                            dtStep2_d.Rows.Add(new_row); //添加組別對應的牌子
                        }
                    }
                }
                else
                {
                    //勾選了全部牌子,則去掉曾生成的牌子記錄
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "all_brand", "*");
                    Remove_DataRow(strGroup_id); //移走組別對應的牌子
                }
            }
        }

        /// <summary>
        /// Step2 表格1牌子選項
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clGroup_Select_CheckedChanged(object sender, EventArgs e)
        {
            //第二頁第一表格如果去掉組別，則移走組別對應的牌子  
            gridView1.CloseEditor();
            string strGroup_id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "group_id").ToString();
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "flag_select").ToString() == "False")
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "flag_brand", false);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "all_brand", "");
                Remove_DataRow(strGroup_id);   //移走           
            }
            else
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "flag_brand", true);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "all_brand", "*");
            }
        }

        /// <summary>
        /// Step2 表格2 移走組別對應的的牌子
        /// </summary>
        /// <param name="_group"></param>
        private void Remove_DataRow(string _group)
        {
            //应该采用倒序循环刪除,因为正序删除时索引会发生变化
            for (int i = dtStep2_d.Rows.Count - 1; i >= 0; i--)
            {
                if (gridView2.GetRowCellValue(i, "group_id").ToString() == _group)
                {
                    dtStep2_d.Rows.RemoveAt(i);
                }
            }
        }


        private void clBrand_select_Click(object sender, EventArgs e)
        {
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "flag_select").ToString() == "False")
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "flag_brand", false);
                gridView1.CloseEditor();
            }
            
        }

        private void Set_Grant_Data()
        {
            mList.Clear();
            //step1的表dtStep1:flag_select，user_id，usrer_name，user_group
            //step2 主表dtStep2_h:flag_select,group_id,group_id_desc,flag_brand,all_brand
            //    明細表dtStep2_d:flag_select,group_id,brand_id,brand_name
            //step3的表dtStep3:user_id,group_id,brand_id
            string strSql ;
            DataTable dtUser_Exists = new DataTable();
            DataRow[] drUser = dtStep1.Select("flag_select=true"); //選擇的用戶
            DataRow[] drStep2_h = dtStep2_h.Select("flag_select=true");//包括全部牌子或某些牌子
            DataRow[] drStep2_d = dtStep2_d.Select("flag_select=true");
            string strUserid,strGroup,strBrand;
            for (int i = 0; i < drUser.Length; i++)
            {
                strUserid = drUser[i]["user_id"].ToString();
                for (int ii = 0; ii < drStep2_h.Length; ii++)
                {
                    if (drStep2_h[ii]["flag_brand"].ToString() == "True") //某組別全部牌子
                    {
                        strGroup = drStep2_h[ii]["group_id"].ToString();
                        strBrand = "*";
                        mdlGroup_Grant objList = new mdlGroup_Grant();
                        objList.user_id = strUserid.ToUpper();
                        objList.group_id = strGroup.ToUpper();
                        objList.brand_id = strBrand.ToUpper();
                        objList.flag_Old_Record = "";
                        mList.Add(objList);
                    }
                }
                
                //某組別下的某個牌子
                for (int ii = 0; ii < drStep2_d.Length; ii++)
                {
                    strGroup = drStep2_d[ii]["group_id"].ToString();
                    strBrand = drStep2_d[ii]["brand_id"].ToString();
                    mdlGroup_Grant objList = new mdlGroup_Grant();
                    objList.user_id = strUserid.ToUpper();
                    objList.group_id = strGroup.ToUpper();
                    objList.brand_id = strBrand.ToUpper();
                    objList.flag_Old_Record = "";
                    mList.Add(objList);
                }
               
                //用戶已有設置好的舊值
                strSql = string.Format(
                @"SELECT usrid,grpid,brand_all FROM dbo.sy_user_group WHERE usrid='{0}' and usrhrst='Y'
                Union ALL
                SELECT userid,grpid,brand_id FROM dbo.sy_user_group_brand WHERE userid='{0}' ", strUserid);
                dtUser_Exists = clsPublicOfCF01.GetDataTable(strSql);
                if (dtUser_Exists.Rows.Count > 0)
                {
                    for (int j = 0; j < dtUser_Exists.Rows.Count; j++)
                    {
                        strUserid = dtUser_Exists.Rows[j]["usrid"].ToString();
                        strGroup = dtUser_Exists.Rows[j]["grpid"].ToString();
                        strBrand = dtUser_Exists.Rows[j]["brand_all"].ToString();

                        for(int x = mList.Count-1;x >= 0;x--)
                        {

                            if (mList[x].user_id.ToUpper() == strUserid.ToUpper() && mList[x].group_id.ToUpper() == strGroup.ToUpper() && mList[x].brand_id.ToUpper() == strBrand.ToUpper())
                            {
                                mList.Remove(mList[x]);//如果存在已設置好的，則將這些記錄移除
                            }
                        }                                 

                        //重新將舊值添加進來,并做好標記
                        mdlGroup_Grant objList_old = new mdlGroup_Grant();
                        objList_old.user_id = strUserid;
                        objList_old.group_id = strGroup;
                        objList_old.brand_id = strBrand;
                        objList_old.flag_Old_Record = "Y";
                        mList.Add(objList_old);
                    }
                }
            }          

            //添加到STEP3表格
            if (mList.Count > 0)
            {
                dtStep3.Clear();
                foreach (mdlGroup_Grant obj in mList)
                {
                    DataRow dc=dtStep3.NewRow();
                    dc["user_id"] = obj.user_id;
                    dc["group_id"] = obj.group_id;
                    dc["brand_id"] = obj.brand_id;
                    dc["flag_old_record"] = obj.flag_Old_Record;
                    dtStep3.Rows.Add(dc);
                }
            }

            //移走相互矛盾的數據,即既只能看組別下的某幾個牌子（新增的）,又可以查看全部牌子的(舊的--要從列表中移走)
            for (int i = dtStep3.Rows.Count - 1; i >= 0; i--)
            {
                if (dtStep3.Rows[i]["brand_id"].ToString() == "*" && dtStep3.Rows[i]["flag_old_record"].ToString()=="Y")
                {
                    foreach (mdlGroup_Grant obj1 in mList)
                    {
                        if (obj1.user_id.ToUpper() == dtStep3.Rows[i]["user_id"].ToString() &&
                            obj1.group_id.ToUpper() == dtStep3.Rows[i]["group_id"].ToString() &&
                            obj1.brand_id.ToUpper() != "*" && obj1.flag_Old_Record=="" )                        
                        {
                            dtStep3.Rows.RemoveAt(i);
                            break;
                        }
                    }
                }                
                if (dtStep3.Rows[i]["brand_id"].ToString().Trim()=="" && dtStep3.Rows[i]["flag_old_record"].ToString() == "Y")
                {
                    dtStep3.Rows.RemoveAt(i);
                }
            }
        }
     

        private void dgvStep3_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvStep3.Rows.Count > 0)
            {
                if (dgvStep3.Rows[e.RowIndex].Cells["flag_old_record"].Value.ToString() == "Y")
                    dgvStep3.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                else
                    dgvStep3.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(0xCC, 0xFF, 0xCC);                    
            }
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if(dtStep1.Rows.Count > 0)
            {
                using (frmUserGroup ofrmFind = new frmUserGroup())
                {                   
                    ofrmFind.strUserid = dgvStep1.CurrentRow.Cells["user_id1"].Value.ToString(); //dtStep1.Rows[dgvStep1.CurrentRow.Index]["user_id"].ToString() 用注釋的這行內容會錯位;                    
                    ofrmFind.BTNNEW.Enabled = false;
                    ofrmFind.MaximizeBox = false;
                    ofrmFind.MinimizeBox = false;
                    ofrmFind.ShowDialog();
                }
            }
        }

     


       
    }
}
