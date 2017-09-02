using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlfaDOCKvDriveSetup
{
    public partial class Form1 : Form
    {
        const string alfaDockFolderName = "alfaDOCK vDrive";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            string alfaDrivePath = Environment.GetFolderPath(Environment.SpecialFolder.Favorites) + "\\" + alfaDockFolderName;
            if (!Directory.Exists(alfaDrivePath))
            {
                MessageBox.Show("Not exist alfaDock vDrive:" + alfaDrivePath);
                Directory.CreateDirectory(alfaDrivePath);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
