using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using cf01.CLS;
using cf01.ModuleForm;
using cf01.ModuleClass;

namespace cf01.ReportForm
{
    public partial class frmChkBox : Form
    {
        private DataView dView;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public frmChkBox()
        {
            InitializeComponent();
        }
      
        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = dgvDetails.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dgvDetails.CurrentRow.Cells[4].Value.ToString();
            this.count_rec();
        }

        private void count_rec()
        {
            int j = 0;
            /*
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if (dgvDetails.Rows[i].Cells[4].Value != null)
                {
                    if (Convert.ToBoolean(dgvDetails.Rows[i].Cells[4].Value.ToString()))
                        //if (Convert.ToBoolean(ds.Tables[0].Rows[i][4].ToString()))

                        //if (Convert.ToBoolean((dt.Rows[i][4]).ToString))
                        j++;
                }
            }
             */
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][4] != null)
                {
                    if (Convert.ToBoolean(dt.Rows[i][4].ToString()))
                        //if (Convert.ToBoolean(ds.Tables[0].Rows[i][4].ToString()))

                        //if (Convert.ToBoolean((dt.Rows[i][4]).ToString))
                        j++;
                }
            }
            textBox3.Text = j.ToString();
        }

        private void btmAdd_Click(object sender, EventArgs e)
        {
            double sum = 0;
            float avg = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dt.Rows[i][3].ToString());
            }
            avg = (float)sum / dt.Rows.Count;
            DataRow dr = dt.NewRow();
            dr["inc1unit"] = "ZZ1";
            dr["inc1desc"] = "ZZ111";
            dr["inc1cdesc"] = avg.ToString();
            dr["inc1cnt"] = sum;
            dr["inc1chk"] = false;
            dt.Rows.Add(dr);
        }

        private void btmFind_Click(object sender, EventArgs e)
        {
            //DataTable dtSource = DBUtility.GetGoods_DetailsById(textBox1.Text.Trim(), textBox2.Text.Trim());
            //if (dtSource.Rows.Count > 0)
            //{
            //    DataTable dtTemp = new DataTable();
            //    dtTemp = dtSource.Copy();
            //    dtTemp.Rows.Clear();

            //    for (int i = 0; i < dtSource.Rows.Count; i++)
            //    {
            //        DataRow dr = dtTemp.NewRow();
            //        dr["goods_id"] = dtSource.Rows[0][""].ToString();
            //    }

            //}
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            //XmlArgs args = new XmlArgs();
            //args.Add("inm1item", "F0-EYYYSTD-05C");
            //args.Add("inm1cdesc", 2);
            //string vl;
            //vl = args.Args;
            string _connString = System.Configuration.ConfigurationManager.AppSettings["ctr_leavy"];
            //string _type = "";
            SqlConnection con = new SqlConnection(_connString);
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "z_pr_inm01"; //指定存储过程名称
            SqlCmd.Connection = con;  //指定sql命令的连接属性
            //指定存储过程的参数并赋值
            SqlCmd.Parameters.Add("@arg", SqlDbType.Xml);
           // SqlCmd.Parameters["@arg"].Value = args.Args;
            DataSet ds = new DataSet();
            con.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
                da.Fill(ds, "inm01");
                dt = ds.Tables["inm01"];
                BindDataGridView();
                dgvDetails.DataSource = ds.Tables["inm01"];
                if (ds.Tables["inm01"].Rows.Count == 0)//(dgvDetails.Rows.Count == 0)
                    MessageBox.Show("沒有找到符合條件的記錄!", "系統信息", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message, "系統信息", MessageBoxButtons.OK);
            }

            con.Close();

        }

        private void BindDataGridView()
        {
            dgvDetails.Columns.Add("inm1item", "物料編號");
            dgvDetails.Columns["inm1item"].DataPropertyName = "inm1item";
            dgvDetails.Columns.Add("inm1cdesc", "物料描述");
            dgvDetails.Columns["inm1cdesc"].DataPropertyName = "inm1cdesc";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string _connString = System.Configuration.ConfigurationManager.AppSettings["ctr_leavy"];
            //conn c = new conn(_connString);
            ////DataTable dt1 = c.getDataProcedure("z_pr_inm01", new object[] { 1001, 1000, "t1", "教师1", 1 });
            //DataTable dt1 = c.getDataProcedure("z_pr_inm01", new object[] { "AB83XXGRF03150N012", "ABC" });
            //dgvDetails.DataSource = dt1;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = comboBox2.SelectedValue.ToString();

        }

        private void frmChkBox_Load(object sender, EventArgs e)
        {
            //string _connString = System.Configuration.ConfigurationManager.AppSettings["conn_string_dgsql1"];
            string _connString = "Data Source=dgsql1;Initial Catalog=dg_data;User ID=sa;Password=4337069";
            //using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            using (SqlConnection sqlconn = new SqlConnection(_connString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Select inc1unit,inc1desc,inc1cdesc,1 AS inc1cnt From inc01", sqlconn))
                {

                    da.Fill(ds, "inc01_rr01");
                    dt = ds.Tables["inc01_rr01"];
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "inc1chk";
                    dc.DataType = System.Type.GetType("System.Boolean");
                    dc.DefaultValue = true;
                    dt.Columns.Add(dc);
                    dView = new DataView(dt);
                    dView.Sort = "inc1unit Desc";


                    //inc1unit1.DataSource = dView;// ds.Tables["inc01_rr01"].DefaultView;
                   // inc1unit1.DisplayMember = "inc1unit";

                    dgvDetails.DataSource = dView;
                    //DataGridViewCheckBoxColumn dgvc = new DataGridViewCheckBoxColumn();
                    //dgvc.HeaderText = "狀態";
                    //dgvDetails.Columns.Add(dgvc);

                    comboBox1.DataSource = dView;// ds.Tables["inc01_rr01"].DefaultView;
                    comboBox1.DisplayMember = "inc1unit";
                    comboBox1.SelectedIndex = 0;

                    listBox1.DataSource = dView;
                    listBox1.DisplayMember = "inc1unit";


                    comboBox2.DisplayMember = "inc1unit";
                    comboBox2.ValueMember = "inc1cdesc";
                    comboBox2.DataSource = dt;

                    //textBox4.Text = comboBox2.SelectedValue.ToString();

                }
            }
            BindDataGridView();
        }


    }
}
