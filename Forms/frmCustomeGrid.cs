using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using System.Data.SqlClient;

namespace cf01.Forms
{
    public partial class frmCustomeGrid : Form
    {
        public DataTable dtSeting;
        public string windows_id;
        public object obj_grid;
        public string object_type;
        public frmCustomeGrid(string form_id,object grid_obj,string grid_type)
        {
            InitializeComponent();
            windows_id = form_id;
            obj_grid = grid_obj;
            object_type = grid_type;

            string strSql = string.Format(
            @"Select user_id,window_id,obj_id,col_id,col_caption,obj_type,col_width,sort_id,isvisible
            FROM dbo.sy_custome_grid WHERE user_id='{0}' and window_id='{1}' Order by sort_id", DBUtility._user_id, form_id);
            dtSeting = clsPublicOfCF01.GetDataTable(strSql);
            dgvDetail.DataSource = dtSeting;
        }

        private void frmCustomeGrid_Load(object sender, EventArgs e)
        {
            if (object_type == "VS")
            {
                DataGridView myDataGrid = (DataGridView)obj_grid;
                string col_caption,col_name;
                int col_width,col_sort;                
                if (dtSeting.Rows.Count == 0)
                {
                    for (int i = 0; i < myDataGrid.ColumnCount; i++)
                    {
                        if (myDataGrid.Columns[i].Visible)
                        {
                            col_caption = myDataGrid.Columns[i].HeaderText;//列標題
                            col_name = myDataGrid.Columns[i].Name;//列名
                            col_width = myDataGrid.Columns[i].Width;//列寬
                            col_sort = myDataGrid.Columns[i].Index;//列位置                                                    
                            DataRow dr = dtSeting.NewRow();
                            dr["user_id"] = DBUtility._user_id;
                            dr["window_id"] = windows_id;
                            dr["obj_id"] = myDataGrid.Name; // obj_grid;
                            dr["obj_type"] = object_type;
                            dr["col_id"] = col_name;
                            dr["col_width"] = col_width;
                            dr["col_caption"] = col_caption;
                            dr["isvisible"] = true ;
                            dr["sort_id"] = col_sort;
                            dtSeting.Rows.Add(dr);
                        }                        
                    }
                }
            }            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            if (dtSeting.Rows.Count > 0)
            {                
                string strSql_i = 
                @"INSERT INTO sy_custome_grid(user_id,window_id,obj_id,col_id,col_caption,obj_type,col_width,sort_id,isvisible,crusr,crtim) 
                    VALUES(@user_id,@window_id,@obj_id,@col_id,@col_caption,@obj_type,@col_width,@sort_id,@isvisible,@user_id,getdate())";
                string strSql_u =
                @"Update sy_custome_grid SET col_caption=@col_caption,col_width=@col_width,sort_id=@sort_id,isvisible=@isvisible,crusr=@user_id,crtim=getdate()
                Where user_id=@user_id And window_id=@window_id And obj_id=@obj_id And col_id=@col_id And obj_type=@obj_type";
                bool save_flag,isDisplay;
                string rowStatus;
                save_flag = false;
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        for (int i = 0; i < dtSeting.Rows.Count; i++)
                            {
                                rowStatus = dtSeting.Rows[i].RowState.ToString();
                                if (rowStatus == "Added" || rowStatus == "Modified")
                                {
                                    myCommand.Parameters.Clear();
                                    if (rowStatus == "Added")
                                        myCommand.CommandText = strSql_i;
                                    else
                                        myCommand.CommandText = strSql_u;
                                    myCommand.Parameters.AddWithValue("@user_id", dtSeting.Rows[i]["user_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@window_id", dtSeting.Rows[i]["window_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@obj_id", dtSeting.Rows[i]["obj_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@col_id", dtSeting.Rows[i]["col_id"].ToString());
                                    myCommand.Parameters.AddWithValue("@col_caption", dtSeting.Rows[i]["col_caption"].ToString());
                                    myCommand.Parameters.AddWithValue("@obj_type", dtSeting.Rows[i]["obj_type"].ToString());
                                    myCommand.Parameters.AddWithValue("@col_width", dtSeting.Rows[i]["col_width"]);
                                    myCommand.Parameters.AddWithValue("@sort_id", dtSeting.Rows[i]["sort_id"]);   
                                    if (dtSeting.Rows[i]["isvisible"].ToString() == "True")
                                        isDisplay = true;
                                    else
                                        isDisplay = false;
                                    myCommand.Parameters.AddWithValue("@isvisible", isDisplay);
                                    myCommand.ExecuteNonQuery();
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
                }

                if (save_flag)
                {
                    MessageBox.Show("欄位設置成功!", "提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);                   
                    dtSeting.AcceptChanges();
                }
                else
                    MessageBox.Show("欄位設置失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("注意：只可以輸入數字!", "系統提示提", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
