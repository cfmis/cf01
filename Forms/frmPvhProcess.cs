using cf01.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmPvhProcess : Form
    {
        public string strProcess = string.Empty;
        public DataTable dtProcess = new DataTable();
        string field_type = string.Empty;
        public frmPvhProcess(string fieldType)
        {
            InitializeComponent();
            field_type = fieldType;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            strProcess = "";
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            strProcess = "";
            for (int i = 0; i < dtProcess.Rows.Count;i++){
                if(dtProcess.Rows[i]["flagSelect"].ToString()=="True")
                {
                    if (strProcess != "")
                    {
                        strProcess += ";" + dtProcess.Rows[i]["contents"].ToString();
                    }else
                    {
                        strProcess = dtProcess.Rows[i]["contents"].ToString();
                    }
                }
            }
            this.Close();
        }

        private void frmPvhProcess_Load(object sender, EventArgs e)
        {
            dtProcess = clsDevelopentPvh.GetProcess(field_type);
            dgvProcess.DataSource = dtProcess;
        }

        private void chkAll_MouseUp(object sender, MouseEventArgs e)
        {
            bool status = false;
            if (chkAll.Checked)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            for (int i = 0; i < dtProcess.Rows.Count; i++)
            {
                dtProcess.Rows[i]["flagSelect"] = status;               
            }
        }
    }
}
