using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;

namespace cf01.ReportForm
{
    public partial class frmTrm01 : Form
    {
        public frmTrm01()
        {
            InitializeComponent();
        }
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        //private DataView dView,tView;
        private void btmAdd_Click(object sender, EventArgs e)
        {

        }

        private void frmTrm01_Load(object sender, EventArgs e)
        {
            //string _connString = System.Configuration.ConfigurationManager.AppSettings["conn_string_dgsql1"];
            // string _connString = DBUtility.GetConnectionString("DGSQL1");
            //using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            //using (SqlConnection sqlconn = new SqlConnection(DBUtility.connectionString))
            //{
                //using (SqlDataAdapter da = new SqlDataAdapter("Select inc1unit,inc1desc,inc1cdesc,1 AS inc1cnt From inc01", sqlconn))
                //{
                //    DataTable dtt = new DataTable();
                //    da.Fill(ds, "inc01_rr01");
                //    dt = ds.Tables["inc01_rr01"];
                //    dtt = ds.Tables["inc01_rr01"];
                //    DataColumn dc = new DataColumn();
                //    dc.ColumnName = "inc1chk";
                //    dc.DataType = System.Type.GetType("System.Boolean");
                //    dc.DefaultValue = true;
                //    dt.Columns.Add(dc);
                //    dView = new DataView(dt);
                //    dView.Sort = "inc1unit Desc";
                //    tView = new DataView(dtt);

                //    comboBox2.DataSource = tView;// ds.Tables["inc01_rr01"].DefaultView;
                //    comboBox2.DisplayMember = "inc1unit";

                //    dgvDetails.DataSource = dView;
                //    //DataGridViewCheckBoxColumn dgvc = new DataGridViewCheckBoxColumn();
                //    //dgvc.HeaderText = "狀態";
                //    //dgvDetails.Columns.Add(dgvc);

                //    comboBox1.DataSource = dView;// ds.Tables["inc01_rr01"].DefaultView;
                //    comboBox1.DisplayMember = "inc1unit";
                //    comboBox1.SelectedIndex = 0;

                //}
            //}
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btmFind_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage();
            //msg.To.Add("drjworld@qq.com");
            //msg.To.Add("drjchina@163.com");
            msg.To.Add("leavy_lai@chingfung.com");

            //msg.From = new MailAddress("erp_info@chingfung.com", "天行健", System.Text.Encoding.UTF8);
            msg.From = new MailAddress("erp_info@chingfung.com");
            msg.Subject = "这是测试邮件";//邮件标题 
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码 
            msg.Body = "邮件内容";//邮件内容 
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码 
            msg.IsBodyHtml = false;//是否是HTML邮件 
            //msg.Priority = MailPriority.High;//邮件优先级

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("erp_info@chingfung.com", "9999");
            //注册的邮箱和密码 
            client.Host = "192.168.3.19";
            object userState = msg;
            try
            {
                client.SendAsync(msg, userState);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

        }
    }
}
