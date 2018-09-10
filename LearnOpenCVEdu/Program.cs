using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

namespace LearnOpenCVEdu
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            CheckAdmin();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        /// <summary>
        /// 开机检查是否以管理员身份运行
        /// </summary>
        private static void CheckAdmin()
        {
            var wi = WindowsIdentity.GetCurrent();
            var wp = new WindowsPrincipal(wi);

            bool runAsAdmin = wp.IsInRole(WindowsBuiltInRole.Administrator);

            if (!runAsAdmin)
            {
                var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase);

                processInfo.UseShellExecute = true;
                processInfo.Verb = "runas";

                try
                {
                    Process.Start(processInfo);
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message);
                }

                Environment.Exit(0);
            }
        }
    }
}
