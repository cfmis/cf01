using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;

namespace cf01.CLS
{
    class clsGeneralDataConvert
    {
        /// <summary>
        /// 將GridView 打印
        /// </summary>
        /// <param name="pdgv"></param>
        public static void GridView_To_Print(DataGridView pdgv) //通用的打印方法
        {
            if (pdgv.RowCount > 0)
            {
                PrintDGV.Print_DataGridView(pdgv);
            }
        }

        /// <summary>
        /// 將GridView 轉成EXCEL
        /// </summary>
        /// <param name="pdgv"></param>
        public static void GridView_To_Excel(DataGridView pdgv)
        {
            if (pdgv.RowCount > 0)
            {
                ExpToExcel.DataGridViewToExcel(pdgv);
            }
        }
    }
}
