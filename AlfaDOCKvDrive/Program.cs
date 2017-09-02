using AlfaDOCKvDrive.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlfaDOCKvDrive
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(FormInstaller.isInstalled())
            {
                Application.Run(new FormSettings());
            }
            else
            {
                Application.Run(new FormInstaller());
            }
            
        }
    }
}
