using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cf01.CLS
{
    public class clsGetAuthority
    {
        public static DataTable GetUserRole()
        {
            string _userid = DBUtility._user_id;
            DataTable dtUserRole = new DataTable();
            try
            {
                string strSQL = @" SELECT rid FROM tb_sy_user a with(nolock) WHERE  a.Uname = '" + _userid + "'";

                dtUserRole = clsPublicOfCF01.GetDataTable(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtUserRole;
        }

    }
}
