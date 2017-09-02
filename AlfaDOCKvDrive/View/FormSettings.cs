using AlfaDOCKvDrive.Controller;
using AlfaDOCKvDrive.Model;
using System;
using System.Windows.Forms;

namespace AlfaDOCKvDrive.View
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            Model.AlfaDrive.getInstance().init();

            Controller.SyncController.getInstance().setForm(this);
            Controller.SyncController.getInstance().runWatcher();

            this.Text = Model.AlfaDrive.APP_NAME;

            notifyIcon1.BalloonTipText = Model.AlfaDrive.APP_NAME + " launched.";
            //notifyIcon1.BalloonTipTitle = Model.AlfaDrive.APP_NAME + "1.0";
            notifyIcon1.ShowBalloonTip(2000);

            //chkSync.Checked = true;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void FormSettings_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        bool byProgrammatically = false;
        private void chkSync_CheckedChanged(object sender, EventArgs e)
        {
            if (byProgrammatically)
            {
                byProgrammatically = false;
            }
            else
            {
                AlfaDrive.getInstance().setCredential(
                    txtCompName.Text,
                    txtCompId.Text,
                    txtCompPassword.Text,
                    txtUserName.Text,
                    txtUserId.Text,
                    txtUserPassword.Text);
                byProgrammatically = true;
                chkSync.Checked = SyncController.getInstance().setSync(chkSync.Checked);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Really quit?", Model.AlfaDrive.APP_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (dr != DialogResult.OK)
            //{
            //    e.Cancel = true;
            //}
            this.Hide();
            e.Cancel = true;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private delegate void SetStateLabelTextCallBack(string Value);
        public void SetStateLabelText(string Value)
        {
            if (lblState.InvokeRequired)
            {
                SetStateLabelTextCallBack d = new SetStateLabelTextCallBack(SetStateLabelText);
                lblState.BeginInvoke(d, Value);
            }
            else
            {
                lblState.Text = Value;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AlfaDrive.getInstance().setCredential(
                txtCompName.Text,
                txtCompId.Text,
                txtCompPassword.Text,
                txtUserName.Text,
                txtUserId.Text,
                txtUserPassword.Text);
        }

        private void btnGotoUninstall_Click(object sender, EventArgs e)
        {
            if(installerForm ==null)
            {
                installerForm = new FormInstaller();
                installerForm.formSettings = this;
                installerForm.Closed += (s, args) => this.Close();
            }
            installerForm.Show();
            this.Hide();
        }
        private FormInstaller installerForm = null;
        public FormInstaller InstallerForm
        {
            set
            {
                installerForm = value;
            }
        }
        private void navMain()
        {
            installerForm.Show();
            this.Hide();
        }
        

        private void ShowThisForm()
        {
            if (installerForm != null && installerForm.Visible == false || installerForm == null)
            {
                this.Show();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowThisForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(3);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowThisForm();
            }
        }
    }
}