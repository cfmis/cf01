using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using cf01.Forms;
using cf01.ReportForm;
using cf01.MM;

namespace cf01
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (DBUtility.GetDatabaseSeting()) //判斷數據庫連接是否有效
            {
                //PC的運行登入界面1
                Application.Run(new frmLogin());
                if (frm_Main.isRunMain == true)
                {
                    Application.Run(new frm_Main());
                }

                //Application.Run(new frmProductProcessCost());
                //Application.Run(new frmMmCosting());
                //Application.Run(new frmProductCosting());
                //Application.Run(new frmOrderProCard());
                //Application.Run(new ModuleForm.frmBaseBackGroundForm());
                //Application.Run(new frmOrderProCardBatchPrint());
                //Application.Run(new frmPurDelivery());
                //Application.Run(new frmEagraveProduct());
                //Application.Run(new frmProductionRepair_Find());
                //Application.Run(new frmOrderProCard());


            }
            else
            {
                // 打開數據庫連接配置信息
                Forms.frmConfig.flag_readonly = false;//數據庫連接信息窗體用到此變量
                Application.Run(new Forms.frmConfig());

                //已加密的配置
                //Forms.frmCfg.flag_readonly = false;//數據庫連接信息窗體用到此變量                
                //Application.Run(new Forms.frmCfg());
                Application.Exit();
            }
        }
    }
}
