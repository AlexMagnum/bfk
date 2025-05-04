using bfk_pruyom.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bfk_pruyom
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            using (var loginForm = new Login())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Dashboard());
                }
            }
        }
    }
}
