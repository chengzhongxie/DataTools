using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace DataTools
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Homes());
            }
            catch (Exception ex)
            {
                MessageCommon.ShowErr("亲！程序已炸！");
                LogUtilities.WriteLog("Error", "Main", ex.ToString());
            }
        }
    }
}
