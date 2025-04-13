using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.OleDb;
using System.IO;
using cf01.CLS;
using cf01.MDL;
using cf01.ModuleClass;
using cf01.ReportForm;

namespace cf01.Forms
{
    public partial class frmArrangeMoAdd : Form
    {
        public static string prdDep = "";
        public static string prdDate = "";
        public frmArrangeMoAdd()
        {
            InitializeComponent();
        }

        private void frmArrangeMoAdd_Load(object sender, EventArgs e)
        {
            InitControlers();
            cmbArrDep.SelectedValue = prdDep;
            datArrDateFrom.Text = prdDate;
        }
        private void InitControlers()
        {
            DataTable dtPrd_dept = clsProductionSchedule.GetAllPrd_dept();
            cmbArrDep.DataSource = dtPrd_dept;
            cmbArrDep.DisplayMember = "int9loc";
            cmbArrDep.ValueMember = "int9loc";
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            SaveArrange();
            //frmArrangeMo.sendDate = datArrDateTo.Text;
        }
        private void SaveArrange()
        {
            //mdlArrangeMoMaster mdjArrange = new mdlArrangeMoMaster();
            //string dateFrom = Convert.ToDateTime(datArrDateFrom.Text).ToString("yyyy/MM/dd");
            //string dateTo = Convert.ToDateTime(datArrDateTo.Text).ToString("yyyy/MM/dd");
            //string fromId = cmbArrDep.SelectedValue.ToString().Trim() + "-" + dateFrom.Substring(0, 4) + dateFrom.Substring(5, 2) + dateFrom.Substring(8, 2);
            //string id= cmbArrDep.SelectedValue.ToString().Trim() + "-" + dateTo.Substring(0, 4) + dateTo.Substring(5, 2) + dateTo.Substring(8, 2);
            //string result = clsArrangeMo.SaveArrangeMo(cmbArrDep.SelectedValue.ToString(), fromId, id, dateTo);
        }
    }
}
