using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using DevExpress.XtraEditors;
using cf01.ModuleClass;
using System.Data.SqlClient;

namespace cf01.Forms
{
    public partial class frmArtEdit : Form
    {
       
        public static string str_language = "0";
        public static string _comp;
        public static string _id;
        public static string _ver;
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        public frmArtEdit()
        {
            InitializeComponent();
            str_language = DBUtility._language;
            
            myBindingSource.DataSource = frmArtRequest.dtArt_request_change; 
            myNavigator.BindingSource = myBindingSource;            
            //綁定數據
            txtSeq_id.DataBindings.Add("Text", myBindingSource, "seq_id");
            txtHk_work_date.DataBindings.Add("Text", myBindingSource, "hk_work_date");
            txtDg_work_date.DataBindings.Add("Text", myBindingSource, "dg_work_date");
            cmbProvide_original.DataBindings.Add("Text", myBindingSource, "provide_original");
            txtResponsible_dept.DataBindings.Add("Text", myBindingSource, "responsible_dept");
            txtChange_content.DataBindings.Add("Text", myBindingSource, "change_content");
            txtCrusr.DataBindings.Add("Text", myBindingSource, "crusr");
            txtCrtim.DataBindings.Add("Text", myBindingSource, "crtim");
            txtAmusr.DataBindings.Add("Text", myBindingSource, "amusr");
            txtAmtim.DataBindings.Add("Text", myBindingSource, "amtim");
        }

        private void frmArtEdit_Load(object sender, EventArgs e)
        {
            myBindingSource.MoveLast();            
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            string sql_f1 = String.Format("SELECT MAX(ver) AS ver FROM dbo.se_art_request with(nolock) WHERE company_code='{0}' AND art_requ_id='{1}'", _comp, _id);
            DataTable dtMaxVer = clsPublicOfCF01.GetDataTable(sql_f1);            
            string temp_max_ver = dtMaxVer.Rows[0]["ver"].ToString();//取此畫稿的最大版本
            if (temp_max_ver == "")
            {
                return;
            }

            string temp_new_ver="";
            if (_ver == temp_max_ver)
            {
                DialogResult result = MessageBox.Show("畫稿將產生新的版本！"+"\n"+"\n"+"是否要進行此操作?", myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    #region 取下一個版本號
                    switch (temp_max_ver)
                    {
                        case "0":
                            temp_new_ver = "A";
                            break;
                        case "A":
                            temp_new_ver = "B";
                            break;
                        case "B":
                            temp_new_ver = "C";
                            break;
                        case "C":
                            temp_new_ver = "D";
                            break;
                        case "D":
                            temp_new_ver = "E";
                            break;
                        case "E":
                            temp_new_ver = "F";
                            break;
                        case "F":
                            temp_new_ver = "G";
                            break;
                        case "G":
                            temp_new_ver = "H";
                            break;
                        case "H":
                            temp_new_ver = "I";
                            break;
                        case "I":
                            temp_new_ver = "J";
                            break;
                        case "J":
                            temp_new_ver = "K";
                            break;
                        case "K":
                            temp_new_ver = "L";
                            break;
                        case "L":
                            temp_new_ver = "M";
                            break;
                        case "M":
                            temp_new_ver = "N";
                            break;
                        case "N":
                            temp_new_ver = "P";
                            break;
                        case "P":
                            temp_new_ver = "Q";
                            break;
                        case "Q":
                            temp_new_ver = "R";
                            break;
                        case "R":
                            temp_new_ver = "S";
                            break;
                        case "S":
                            temp_new_ver = "T";
                            break;
                        case "T":
                            temp_new_ver = "U";
                            break;
                        case "U":
                            temp_new_ver = "V";
                            break;
                        case "V":
                            temp_new_ver = "W";
                            break;
                        case "W":
                            temp_new_ver = "X";
                            break;
                        case "X":
                            temp_new_ver = "Y";
                            break;
                        case "Y":
                            temp_new_ver = "Z";
                            break;
                        default:
                            MessageBox.Show("已超出26個版本,不可再繼續產生新版本！", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                    }
                    #endregion
                }
                else
                {
                    return;
                }
                int iResult = 0;
                SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@company_code",_comp),
                    new SqlParameter("@art_requ_id",_id),
                    new SqlParameter("@ver",_ver),
                    new SqlParameter("@max_ver",temp_new_ver)
                };
                try
                {
                    iResult = clsPublicOfCF01.ExecuteNonQuery("usp_artwork_new_version", paras, true);
                }
                catch (Exception E)
                {                   
                    throw new Exception(E.Message);                    
                }

                if (iResult < 0)
                {
                    string strMsg = String.Format("畫稿編號【{0}】已成功生成新的版本【{1}】 ", _id, temp_new_ver);
                    frmArtRequest._max_ver = temp_new_ver; //保存最新的版本號
                    MessageBox.Show(strMsg, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

            }
            else
            {
                MessageBox.Show(string.Format("此版本已經有新的版本【{0}】,請返回檢查！",temp_max_ver), myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            txtSeq_id.Focus();
            txtChange_content.Focus();
            if (frmArtRequest.dtArt_request_change.Rows.Count > 0)
            {
                bool save_flag = false;
                string strSeq_id = "";
                string rowStatus = "";
                const string sql_item_i =
                    @"INSERT INTO se_art_request_change
                              (company_code,art_requ_id,ver,seq_id,hk_work_date,dg_work_date,Provide_original,responsible_dept,change_content,crtim,crusr)
                        VALUES(@company_code,@art_requ_id,@ver,@seq_id,@hk_work_date,@dg_work_date,@Provide_original,@responsible_dept,@change_content,getdate(),@crusr)";
                const string sql_item_u =
                    @"UPDATE se_art_request_change SET hk_work_date=@hk_work_date,dg_work_date=@dg_work_date,Provide_original=@Provide_original,responsible_dept=@responsible_dept,
                          change_content=@change_content,amtim=getdate(),amusr=@amusr WHERE company_code=@company_code AND art_requ_id=@art_requ_id AND ver=@ver AND seq_id=@seq_id";
                SqlConnection myCon = new SqlConnection(DBUtility.connectionString);
                myCon.Open();
                SqlTransaction myTrans = myCon.BeginTransaction();
                using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
                {
                    try
                    {
                        //保存明細資料                       
                        for (int i = 0; i < frmArtRequest.dtArt_request_change.Rows.Count; i++)
                        {
                            rowStatus = frmArtRequest.dtArt_request_change.Rows[i].RowState.ToString();
                            if (rowStatus == "Added" || rowStatus == "Modified")
                            {
                                if (rowStatus == "Added")
                                {
                                    myCommand.CommandText = sql_item_i;                                   
                                    strSeq_id = frmArtRequest.Get_Details_Seq(_comp, _id, _ver, "2");//新增狀態重新取最大序號
                                }
                                if (rowStatus == "Modified")
                                {
                                    myCommand.CommandText = sql_item_u;
                                    strSeq_id = frmArtRequest.dtArt_request_change.Rows[i]["seq_id"].ToString();//編輯狀態原序號保持不變                                   
                                }                               
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@company_code", _comp);
                                myCommand.Parameters.AddWithValue("@art_requ_id", _id);
                                myCommand.Parameters.AddWithValue("@ver", _ver);
                                myCommand.Parameters.AddWithValue("@seq_id", strSeq_id);
                                myCommand.Parameters.AddWithValue("@hk_work_date", frmArtRequest.dtArt_request_change.Rows[i]["hk_work_date"].ToString());
                                myCommand.Parameters.AddWithValue("@dg_work_date", frmArtRequest.dtArt_request_change.Rows[i]["dg_work_date"].ToString());
                                myCommand.Parameters.AddWithValue("@Provide_original", frmArtRequest.dtArt_request_change.Rows[i]["Provide_original"].ToString());
                                myCommand.Parameters.AddWithValue("@responsible_dept", frmArtRequest.dtArt_request_change.Rows[i]["responsible_dept"].ToString());
                                myCommand.Parameters.AddWithValue("@change_content", frmArtRequest.dtArt_request_change.Rows[i]["change_content"].ToString());
                                myCommand.Parameters.AddWithValue("@crusr", DBUtility._user_id);
                                myCommand.Parameters.AddWithValue("@amusr", DBUtility._user_id);
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
                        myCon.Dispose();
                        myTrans.Dispose();
                    }
                }
                if (save_flag)
                {
                    myBindingSource.MoveFirst();
                    myBindingSource.MoveLast();                    
                    MessageBox.Show(myMsg.msgSave_ok,myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private static void CheckDate(object obj)
        {
            string strdate = ((DateEdit)obj).Text;
            if (String.IsNullOrEmpty(strdate))
            {
                return;
            }

            bool Flag = clsValidRule.CheckDateFormat(strdate);
            if (!Flag)
            {
                string strMsg;
                if (str_language == "2")
                    strMsg = "Data Fromat is Error.";
                else
                    strMsg = "輸入的日期有誤！";
                MessageBox.Show(strMsg, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((DateEdit)obj).Focus();
                ((DateEdit)obj).SelectAll();
            }
        }

        private void txtHk_work_date_Leave(object sender, EventArgs e)
        {
          CheckDate(sender);
        }

        private void txtDg_work_date_Leave(object sender, EventArgs e)
        {
            CheckDate(sender);
        }

    }
}
