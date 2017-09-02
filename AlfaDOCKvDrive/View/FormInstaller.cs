using AlfaDOCKvDrive.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlfaDOCKvDrive.View
{
    public partial class FormInstaller : Form
    {
        public FormInstaller()
        {
            InitializeComponent();
            progressBar1.Value = 0;

            btnUninstall.Visible = isInstalled();
            btnInstall.Visible = !isInstalled();
            btnCancel.Visible = true;
            btnFinish.Visible = false;

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void FormInstaller_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {


            if (isUninstalled || formSettings == null)
            {
                System.Environment.Exit(3);
            }
            else
            {
                navMain();
            }
        }

        private void FormInstaller_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Really quit?", Model.AlfaDrive.APP_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (dr != DialogResult.OK)
            //{
            //    e.Cancel = true;
            //}
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (formSettings == null)
            {
                Application.Exit();
            }
            else
            {
                navMain();
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            btnInstall.Enabled = false;

            if (installHKLMCmd())
            {
                btnInstall.Visible = false;
                btnCancel.Visible = false;
                btnUninstall.Visible = false;
                btnFinish.Visible = true;
            }
            else
            {
                btnInstall.Enabled = true;
            }
        }



        public static SecurityIdentifier GetComputerSid()
        {
            return new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid;
        }

        private void installHKLM()
        {
            if (!Directory.Exists(AlfaDrive.getInstance().DrivePath))
            {
                Directory.CreateDirectory(AlfaDrive.getInstance().DrivePath);
            }
            int threadSleepTime = 500;
            //
            // SYNC ROOT MANAGER
            //
            progressBar1.Value = 20;
            // HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\SyncRootManager\[storage provider ID]![Windows SID]![Account ID]\DisplayNameResource
            string Windows_SID = GetComputerSid().Value + "-1001";

            var hklmReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            //
            // 1) Points to the resource where the Windows Shell or other applications can get a user-friendly name for your sync root.
            //
            lblState.Text = "Points to the resource where the Windows Shell or other applications can get a user-friendly name for your sync root.";
            string syncRootManagerKey = String.Format(@"Software\Microsoft\Windows\CurrentVersion\Explorer\SyncRootManager\{0}!{1}!{2}", AlfaDrive.APP_NAME, Windows_SID, AlfaDrive.Account_ID);
            string syncRootManager_UserSyncRootsKey = syncRootManagerKey + @"\UserSyncRoots";
            if (hklmReg.GetValue(syncRootManager_UserSyncRootsKey) == null) hklmReg.CreateSubKey(syncRootManager_UserSyncRootsKey);

            hklmReg.OpenSubKey(syncRootManagerKey, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("DisplayNameResource", AlfaDrive.APP_NAME, RegistryValueKind.String);
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            //
            // 2) Points to the resource where the Windows Shell or other applications can get an icon for your sync root.
            //
            lblState.Text = "Points to the resource where the Windows Shell or other applications can get an icon for your sync root.";
            hklmReg.OpenSubKey(syncRootManagerKey, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("IconResource", @"%USERPROFILE%\" + AlfaDrive.APP_NAME + @"\" + AlfaDrive.APP_NAME + ".ico", RegistryValueKind.String);
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            //
            // 3) The location on disk where the sync root is located.
            //
            lblState.Text = "The location on disk where the sync root is located.";
            hklmReg.OpenSubKey(syncRootManager_UserSyncRootsKey, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue(Windows_SID, @"%USERPROFILE%\" + AlfaDrive.APP_NAME, RegistryValueKind.String);
            Thread.Sleep(threadSleepTime); Application.DoEvents();



            //
            // NAVIGATION PANE
            //
            var hkcuReg = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            //
            // 1) Add your CLSID and name your extension
            //
            lblState.Text = "Add your CLSID and name your extension";
            progressBar1.Value = 25;
            string classKey = @"Software\Classes\CLSID\{" + AlfaDrive.GUID + "}";
            if (hkcuReg.GetValue(classKey) == null) hkcuReg.CreateSubKey(classKey);

            hkcuReg.OpenSubKey(classKey, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", AlfaDrive.APP_NAME, RegistryValueKind.String);
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            //
            // 2) Set the image for your icon.
            //
            lblState.Text = "Set the image for your icon.";
            progressBar1.Value = 30;
            string classKey_DefaultIcon = classKey + @"\DefaultIcon";
            if (hkcuReg.GetValue(classKey_DefaultIcon) == null) hkcuReg.CreateSubKey(classKey_DefaultIcon);
            hkcuReg.OpenSubKey(classKey_DefaultIcon, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", @"%%USERPROFILE%%\" + AlfaDrive.APP_NAME + @"\" + AlfaDrive.APP_NAME + ".ico", RegistryValueKind.String);
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            //
            // 3) Add your extension to the Navigation Pane and make it visible.
            //
            lblState.Text = "Add your extension to the Navigation Pane and make it visible.";
            progressBar1.Value = 37;
            hkcuReg.OpenSubKey(classKey, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("System.IsPinnedToNameSpaceTree", 1, RegistryValueKind.DWord);
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            // 
            // 4) Set the location for your extension in the Navigation Pane.
            //
            lblState.Text = "Set the location for your extension in the Navigation Pane.";
            progressBar1.Value = 45;
            hkcuReg.OpenSubKey(classKey, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("SortOrderIndex", 0x42, RegistryValueKind.DWord);
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            //
            // 5: Provide the dll that hosts your extension.
            //
            lblState.Text = "Provide the dll that hosts your extension.";
            progressBar1.Value = 52;
            string classKey_InProcServer32 = classKey + @"\InProcServer32";
            if (hkcuReg.GetValue(classKey_InProcServer32) == null) hkcuReg.CreateSubKey(classKey_InProcServer32);
            hkcuReg.OpenSubKey(classKey_InProcServer32, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", @"%systemroot%\system32\shell32.dll", RegistryValueKind.ExpandString); // Environment.SystemDirectory +
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            //
            // 6: Define the instance object
            // 
            lblState.Text = "Define the instance object.";
            progressBar1.Value = 60;
            string classKey_Instance = classKey + @"\Instance";
            if (hkcuReg.GetValue(classKey_Instance) == null) hkcuReg.CreateSubKey(classKey_Instance);
            hkcuReg.OpenSubKey(classKey_Instance, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("CLSID", "{0E5AAE11-A475-4c5b-AB00-C66DE400274E}", RegistryValueKind.String);
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            //
            // 7: Provide the file system attributes of the target folder
            //
            lblState.Text = "Provide the file system attributes of the target folder.";
            progressBar1.Value = 68;
            string classKey_Instance_InitPropertyBag = classKey_Instance + @"\InitPropertyBag";
            if (hkcuReg.GetValue(classKey_Instance_InitPropertyBag) == null) hkcuReg.CreateSubKey(classKey_Instance_InitPropertyBag);
            hkcuReg.OpenSubKey(classKey_Instance_InitPropertyBag, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("Attributes", 0x11, RegistryValueKind.DWord);
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            //
            // 8: Set the path for the sync root
            //
            lblState.Text = "Set the path for the sync root.";
            progressBar1.Value = 76;
            hkcuReg.OpenSubKey(classKey_Instance_InitPropertyBag, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("TargetFolderPath", @"%%USERPROFILE%%\" + AlfaDrive.APP_NAME, RegistryValueKind.ExpandString);
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            //
            // 9: Set appropriate shell flags
            //
            lblState.Text = "Set appropriate shell flags.";
            progressBar1.Value = 83;
            string classKey_ShellFolder = classKey + @"\ShellFolder";
            if (hkcuReg.GetValue(classKey_ShellFolder) == null) hkcuReg.CreateSubKey(classKey_ShellFolder);
            hkcuReg.OpenSubKey(classKey_ShellFolder, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("FolderValueFlags", 0x28, RegistryValueKind.DWord);
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            //
            // 10: Set the appropriate flags to control your shell behavior
            //
            lblState.Text = "Set the appropriate flags to control your shell behavior.";
            progressBar1.Value = 90;
            hkcuReg.OpenSubKey(classKey_ShellFolder, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("Attributes", 4034920525, RegistryValueKind.QWord);
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            //
            // 11: Register your extension in the namespace root
            //
            lblState.Text = "Register your extension in the namespace root.";
            progressBar1.Value = 95;
            string desktopNameSpaceKey = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\{" + AlfaDrive.GUID + "}";
            if (hkcuReg.GetValue(desktopNameSpaceKey) == null) hkcuReg.CreateSubKey(desktopNameSpaceKey);
            hkcuReg.OpenSubKey(desktopNameSpaceKey, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", AlfaDrive.APP_NAME, RegistryValueKind.String);
            Thread.Sleep(threadSleepTime); Application.DoEvents();
            //
            // 12 Hide your extension from the Desktop
            //
            lblState.Text = "Hide your extension from the Desktop.";
            progressBar1.Value = 100;
            string hideDesktopNameSpaceKey = @"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel";
            if (hkcuReg.GetValue(hideDesktopNameSpaceKey) == null) hkcuReg.CreateSubKey(hideDesktopNameSpaceKey);
            hkcuReg.OpenSubKey(hideDesktopNameSpaceKey, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("{" + AlfaDrive.GUID + "}", 0x1, RegistryValueKind.DWord);
            Thread.Sleep(threadSleepTime); Application.DoEvents();

            lblState.Text = "Setup completed.";
        }
        private bool installHKLMCmd()
        {
            progressBar1.Value = 0;
           
            if (isInstalled())
            {
                DialogResult dr = MessageBox.Show(AlfaDrive.APP_NAME + "is already installed on your PC." + Environment.NewLine + "Will you do force install?", AlfaDrive.APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr != DialogResult.Yes)
                {
                    return false;
                }
            }

            if (!Directory.Exists(AlfaDrive.getInstance().DrivePath))
            {
                Directory.CreateDirectory(AlfaDrive.getInstance().DrivePath);
            }
            unpackIco();

            string Windows_SID = GetComputerSid().Value + "-1001";

            regCmdLines = "";
            appendText(@"reg add HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\SyncRootManager\" + AlfaDrive.APP_NAME + @"!" + Windows_SID + @"!" + AlfaDrive.Account_ID + @" /v DisplayNameResource /t REG_SZ /d " + AlfaDrive.APP_NAME + @" /f /reg:64");
            appendText(@"reg add HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\SyncRootManager\" + AlfaDrive.APP_NAME + @"!" + Windows_SID + @"!" + AlfaDrive.Account_ID + @" /v IconResource /t REG_SZ /d %%USERPROFILE%%\" + AlfaDrive.APP_NAME + @"\" + AlfaDrive.APP_NAME + @".ico /f /reg:64");
            appendText(@"reg add HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\SyncRootManager\" + AlfaDrive.APP_NAME + @"!" + Windows_SID + @"!" + AlfaDrive.Account_ID + @"\UserSyncRoots /v " + Windows_SID + @" /t REG_SZ /d %%USERPROFILE%%\" + AlfaDrive.APP_NAME + @" /f /reg:64");

            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"} /ve /t REG_SZ /d " + AlfaDrive.APP_NAME + @" /f /reg:64");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\DefaultIcon /ve /t REG_EXPAND_SZ /d %%USERPROFILE%%\" + AlfaDrive.APP_NAME + @"\" + AlfaDrive.APP_NAME + @".ico /f /reg:64");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"} /v System.IsPinnedToNameSpaceTree /t REG_DWORD /d 0x1 /f /reg:64");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"} /v SortOrderIndex /t REG_DWORD /d 0x42 /f /reg:64");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\InProcServer32 /ve /t REG_EXPAND_SZ /d %%SystemRoot%%\system32\shell32.dll /f /reg:64");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\Instance /v CLSID /t REG_SZ /d {0E5AAE11-A475-4c5b-AB00-C66DE400274E} /f /reg:64");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\Instance\InitPropertyBag /v Attributes /t REG_DWORD /d 0x11 /f /reg:64");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\Instance\InitPropertyBag /v TargetFolderPath /t REG_EXPAND_SZ /d %%USERPROFILE%%\" + AlfaDrive.APP_NAME + @" /f /reg:64");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\ShellFolder /v FolderValueFlags /t REG_DWORD /d 0x28 /f /reg:64");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\ShellFolder /v Attributes /t REG_DWORD /d 0xF080004D /f /reg:64");

            appendText(@"reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\{" + AlfaDrive.GUID + @"} /ve /t REG_SZ /d " + AlfaDrive.APP_NAME + @" /f /reg:64");
            appendText(@"reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel /v {" + AlfaDrive.GUID + @"} /t REG_DWORD /d 0x1 /f /reg:64");
            appendText(@"exit");

            string batDir = Application.StartupPath;
            string regFilename = @"~working_temp.bat";
            System.IO.File.WriteAllText(batDir + @"\" + regFilename, regCmdLines);

            Process proc = null;
            try
            {

                proc = new Process();
                proc.StartInfo.WorkingDirectory = batDir;
                proc.StartInfo.FileName = batDir + @"\" + regFilename;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();
                proc.WaitForExit();
                File.Delete(batDir + @"\" + regFilename);
            }
            catch
            {
            }


            //Process regeditProcess = Process.Start(regFilename);
            //regeditProcess.WaitForExit();



            progressBar1.Value = 5;
            lblState.Text = "Points to the resource where the Windows Shell or other applications can get a user-friendly name for your sync root.";
            progressBar1.Value = 10;
            lblState.Text = "Points to the resource where the Windows Shell or other applications can get an icon for your sync root.";
            progressBar1.Value = 20;
            lblState.Text = "The location on disk where the sync root is located.";


            lblState.Text = "Add your CLSID and name your extension";
            progressBar1.Value = 25;
            lblState.Text = "Set the image for your icon.";
            progressBar1.Value = 30;
            lblState.Text = "Add your extension to the Navigation Pane and make it visible.";
            progressBar1.Value = 37;
            lblState.Text = "Set the location for your extension in the Navigation Pane.";
            progressBar1.Value = 45;
            lblState.Text = "Provide the dll that hosts your extension.";
            progressBar1.Value = 52;
            lblState.Text = "Define the instance object.";
            progressBar1.Value = 60;
            lblState.Text = "Provide the file system attributes of the target folder.";
            progressBar1.Value = 68;
            lblState.Text = "Set the path for the sync root.";
            progressBar1.Value = 76;
            lblState.Text = "Set appropriate shell flags.";
            progressBar1.Value = 83;
            lblState.Text = "Set the appropriate flags to control your shell behavior.";
            progressBar1.Value = 90;
            lblState.Text = "Register your extension in the namespace root.";
            progressBar1.Value = 95;
            lblState.Text = "Hide your extension from the Desktop.";

            progressBar1.Value = 100;
            lblState.Text = "Setup completed.";

            return true;
        }
        private void installHKLMReg()
        {
            if (!Directory.Exists(AlfaDrive.getInstance().DrivePath))
            {
                Directory.CreateDirectory(AlfaDrive.getInstance().DrivePath);
            }

            string Windows_SID = GetComputerSid().Value + "-1001";

            regCmdLines = "";
            appendText(@"reg add HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\SyncRootManager\" + AlfaDrive.APP_NAME + @"!" + Windows_SID + @"!" + AlfaDrive.Account_ID + @" /v DisplayNameResource /t REG_SZ /d " + AlfaDrive.APP_NAME + @" /f /reg:64");
            appendText(@"reg add HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\SyncRootManager\" + AlfaDrive.APP_NAME + @"!" + Windows_SID + @"!" + AlfaDrive.Account_ID + @" /v IconResource /t REG_SZ /d %%USERPROFILE%%\" + AlfaDrive.APP_NAME + @"\" + AlfaDrive.APP_NAME + @".ico /f /reg:64");
            appendText(@"reg add HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\SyncRootManager\" + AlfaDrive.APP_NAME + @"!" + Windows_SID + @"!" + AlfaDrive.Account_ID + @"\UserSyncRoots /v " + Windows_SID + @" /t REG_SZ /d %%USERPROFILE%%\" + AlfaDrive.APP_NAME + @" /f /reg:64");

            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"} /ve /t REG_SZ /d " + AlfaDrive.APP_NAME + @" /f");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\DefaultIcon /ve /t REG_EXPAND_SZ /d %%USERPROFILE%%\" + AlfaDrive.APP_NAME + @"\" + AlfaDrive.APP_NAME + @".ico /f");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"} /v System.IsPinnedToNameSpaceTree /t REG_DWORD /d 0x1 /f");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"} /v SortOrderIndex /t REG_DWORD /d 0x42 /f");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\InProcServer32 /ve /t REG_EXPAND_SZ /d %%SystemRoot%%\system32\shell32.dll /f");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\Instance /v CLSID /t REG_SZ /d {0E5AAE11-A475-4c5b-AB00-C66DE400274E} /f");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\Instance\InitPropertyBag /v Attributes /t REG_DWORD /d 0x11 /f");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\Instance\InitPropertyBag /v TargetFolderPath /t REG_EXPAND_SZ /d %%USERPROFILE%%\" + AlfaDrive.APP_NAME + @" /f");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\ShellFolder /v FolderValueFlags /t REG_DWORD /d 0x28 /f");
            appendText(@"reg add HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"}\ShellFolder /v Attributes /t REG_DWORD /d 0xF080004D /f");

            appendText(@"reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\{" + AlfaDrive.GUID + @"} /ve /t REG_SZ /d " + AlfaDrive.APP_NAME + @" /f");
            appendText(@"reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel /v {" + AlfaDrive.GUID + @"} /t REG_DWORD /d 0x1 /f");
            appendText(@"exit");

            string regFilename = Application.StartupPath + @"\install-alfaDOCKvDrive.reg";
            //System.IO.File.WriteAllText(regFilename, regCmdLines);

            Process regeditProcess = Process.Start("regedit.exe", "/s " + regFilename);
            regeditProcess.WaitForExit();



            progressBar1.Value = 5;
            lblState.Text = "Points to the resource where the Windows Shell or other applications can get a user-friendly name for your sync root.";
            progressBar1.Value = 10;
            lblState.Text = "Points to the resource where the Windows Shell or other applications can get an icon for your sync root.";
            progressBar1.Value = 20;
            lblState.Text = "The location on disk where the sync root is located.";


            lblState.Text = "Add your CLSID and name your extension";
            progressBar1.Value = 25;
            lblState.Text = "Set the image for your icon.";
            progressBar1.Value = 30;
            lblState.Text = "Add your extension to the Navigation Pane and make it visible.";
            progressBar1.Value = 37;
            lblState.Text = "Set the location for your extension in the Navigation Pane.";
            progressBar1.Value = 45;
            lblState.Text = "Provide the dll that hosts your extension.";
            progressBar1.Value = 52;
            lblState.Text = "Define the instance object.";
            progressBar1.Value = 60;
            lblState.Text = "Provide the file system attributes of the target folder.";
            progressBar1.Value = 68;
            lblState.Text = "Set the path for the sync root.";
            progressBar1.Value = 76;
            lblState.Text = "Set appropriate shell flags.";
            progressBar1.Value = 83;
            lblState.Text = "Set the appropriate flags to control your shell behavior.";
            progressBar1.Value = 90;
            lblState.Text = "Register your extension in the namespace root.";
            progressBar1.Value = 95;
            lblState.Text = "Hide your extension from the Desktop.";
            progressBar1.Value = 100;
            lblState.Text = "Setup completed.";
        }

        string regCmdLines = "";
        private void appendText(string v)
        {
            regCmdLines += v + "\r\n";
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            btnUninstall.Enabled = false;
            if (uninstallCmd())
            {
                btnInstall.Visible = false;
                btnCancel.Visible = false;
                btnUninstall.Visible = false;
                btnFinish.Visible = true;
                isUninstalled = true;
            }
            else
            {
                btnUninstall.Enabled = true;
            }
        }

        private bool uninstallCmd()
        {
            progressBar1.Value = 0;
            DialogResult dr = MessageBox.Show("Are you sure to uninstall " + AlfaDrive.APP_NAME + "?", AlfaDrive.APP_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr != DialogResult.OK)
            {

                return false;
            }

            string Windows_SID = GetComputerSid().Value + "-1001";

            regCmdLines = "";
            appendText(@"reg delete HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\SyncRootManager\" + AlfaDrive.APP_NAME + @"!" + Windows_SID + @"!" + AlfaDrive.Account_ID + @" /f /reg:64");

            appendText(@"reg delete HKCU\Software\Classes\CLSID\{" + AlfaDrive.GUID + @"} /f /reg:64");

            appendText(@"reg delete HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\{" + AlfaDrive.GUID + @"} /f /reg:64");
            appendText(@"reg delete HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel /v {" + AlfaDrive.GUID + @"} /f /reg:64");
            appendText(@"exit");

            string batDir = Application.StartupPath;
            string regFilename = @"working_temp2.bat";
            System.IO.File.WriteAllText(batDir + @"\" + regFilename, regCmdLines);

            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.WorkingDirectory = batDir;
                proc.StartInfo.FileName = batDir + @"\" + regFilename;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.UseShellExecute = false;

                proc.Start();
                proc.WaitForExit();
                File.Delete(batDir + @"\" + regFilename);
            }
            catch
            {
            }

            dr = MessageBox.Show("Would you like to remain your "+ AlfaDrive.APP_NAME + " data?", AlfaDrive.APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.No)
            {

                try
                {
                    Directory.Delete(AlfaDrive.getInstance().DrivePath, true);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            progressBar1.Value = 100;
            lblState.Text = "Uninstalled successfully.";

            return true;
        }

        private bool isUninstalled = false;
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (isUninstalled)
            {
                System.Environment.Exit(3);
            }
            else
            {
                btnInstall.Visible = false;
                btnCancel.Visible = true;
                btnUninstall.Visible = true;
                btnFinish.Visible = false;

                navMain();
            }
        }

        public FormSettings formSettings = null;
        private void navMain()
        {
            if (formSettings == null)
            {
                formSettings = new FormSettings();
                formSettings.Closed += (s, args) => this.Close();
                formSettings.InstallerForm = this;
            }
            formSettings.Show();
            this.Hide();
        }

        public static bool isInstalled()
        {
            var hkcuReg = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            string classKey = @"Software\Classes\CLSID\{" + AlfaDrive.GUID + "}";

            return hkcuReg.OpenSubKey(classKey, RegistryKeyPermissionCheck.ReadSubTree) != null;
            
        }

        String resourceName = AlfaDrive.APP_NAME+ ".ico";
        void unpackIco()
        {
            //byte[] filepx = Properties.Resources.PixelTimePlayer_setup;
            //File.WriteAllBytes(@"C:/windows/system32/PixelTimePlayer_setup.exe", filepx);

            String path = AlfaDrive.getInstance().DrivePath;

            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string res = string.Format("{0}.Resources." + resourceName , asm.GetName().Name);
            Stream stream = asm.GetManifestResourceStream(res);
            try
            {
                using (Stream file = File.Create(path + @"\" + resourceName ))
                {
                    CopyStream(stream, file);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }
    }
}
