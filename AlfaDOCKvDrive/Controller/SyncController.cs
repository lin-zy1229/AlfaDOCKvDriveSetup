using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AlfaDOCKvDrive.View;
using AlfaDOCKvDrive.Model;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace AlfaDOCKvDrive.Controller
{
    public class SyncController
    {
        public string createdDirFile = "", deletedFile="", changedDirFile="";

        //public Dictionary<string, string> alfaDriveDirFiles = new Dictionary<string, string>();
        
        public Dictionary<int, FileDirNode> alfaDriveDirFilesInfoArray = new Dictionary<int, FileDirNode>();
        public Dictionary<string, int> alfaDriveDirFilesInfoParentIDArray = new Dictionary<string, int>();

        //public Dictionary<string, JToken> alfaDriveDirFilesInfo = new Dictionary<string, JToken>();

        public FormSettings workingForm = null;
        internal void setForm(FormSettings formSettings)
        {
            workingForm = formSettings;
        }

        public List<string> renamedDirFiles = new List<string>();

        private static SyncController mainController;
        public static SyncController getInstance()
        {
            if (mainController == null)
            {
                mainController = new SyncController();
            }
            return mainController;
        }
        private SyncController()
        {
            downloadTimer.Interval = 60 * 60 * 1000;
            downloadTimer.Tick += DownloadTimer_Tick;


            this.bgwDownloader.WorkerReportsProgress = true;
            this.bgwDownloader.WorkerSupportsCancellation = true;
            this.bgwDownloader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerDownload_DoWork);
            this.bgwDownloader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerDownload_ProgressChanged);
            this.bgwDownloader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerDownload_RunWorkerCompleted);

            this.bgwUploader.WorkerReportsProgress = true;
            this.bgwUploader.WorkerSupportsCancellation = true;
            this.bgwUploader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerUpload_DoWork);
            this.bgwUploader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerUpload_ProgressChanged);
            this.bgwUploader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerUpload_RunWorkerCompleted);

            this.bgwDeleter.WorkerReportsProgress = true;
            this.bgwDeleter.WorkerSupportsCancellation = true;
            this.bgwDeleter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerDelete_DoWork);
            this.bgwDeleter.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerDelete_ProgressChanged);
            this.bgwDeleter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerDelete_RunWorkerCompleted);

            this.bgwRenamer.WorkerReportsProgress = true;
            this.bgwRenamer.WorkerSupportsCancellation = true;
            this.bgwRenamer.DoWork += BgwRenamer_DoWork;
            this.bgwRenamer.ProgressChanged += BgwRenamer_ProgressChanged;
            this.bgwRenamer.RunWorkerCompleted += BgwRenamer_RunWorkerCompleted;
        }

        private void BgwRenamer_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            
        }
        private void BgwRenamer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Console.WriteLine(String.Format( "Renaming...{0} to {1}", renameOld, renameNew));
            workingForm.SetStateLabelText(String.Format("Renaming...{0} to {1}", renameOld, renameNew));

            AlfaPackOfficeAPI.getInstance().renameFile(new FileInfo(renameOld).Name, new FileInfo(renameNew).Name, getFileId(new FileInfo(renameOld)));
        }

        private void BgwRenamer_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine(String.Format("Renaming completed"));
            workingForm.SetStateLabelText(String.Format("Renaming completed"));
        }

        private void bgWorkerDownload_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Console.WriteLine("Downloading...");
            workingForm.SetStateLabelText("Downloading...");

            AlfaPackOfficeAPI.getInstance().initFileInfo(-1, "");
            AlfaPackOfficeAPI.getInstance().getFiles(-1);
        }

        private void bgWorkerDownload_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void bgWorkerDownload_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Downloading completed!");
            workingForm.SetStateLabelText("Downloading completed!");

            //
            // add new added files during sync off
            //
            
            /*
            newFiles.Clear();
            foreach (string file in Directory.GetFiles(AlfaDrive.getInstance().DrivePath))
            {
                if (alfaDriveDirFilesInfo.Keys.Contains(new FileInfo(file).Name, new StringComparer()))
                {

                }
                else
                {
                    newFiles.Add(file);
                }
            }
            //remove app icon
            newFiles.Remove(AlfaDrive.getInstance().DrivePath + @"\" + AlfaDrive.APP_NAME + ".ico");
            while (bgwUploader.IsBusy)
            {
                Thread.Sleep(1000);
            }
            bgwUploader.RunWorkerAsync();
            */

            downloadTimer.Start();
            //
            // 
            //

        }

        private void DownloadTimer_Tick(object sender, EventArgs e)
        {
            while (bgwDownloader.IsBusy)
            {
                Thread.Sleep(1000);
            }
            bgwDownloader.RunWorkerAsync();
            downloadTimer.Stop();
        }

        System.Windows.Forms.Timer downloadTimer = new System.Windows.Forms.Timer();
        private void bgWorkerUpload_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            
            // upload new created files
            
            if (createdDirFile.Equals(""))
            {
                
            }
            else
            {
                if (!isSync)
                {
                    workingForm.SetStateLabelText("Sync canceled.");
                    Console.WriteLine("Sync canceled.");
                    return;
                }
                Console.WriteLine("Uploading..." + createdDirFile);
                workingForm.SetStateLabelText("Uploading..." + new FileInfo(createdDirFile).Name);
                AlfaPackOfficeAPI.getInstance().uploadFile(createdDirFile, getParentId(new FileInfo(createdDirFile)));
            }
            if (changedDirFile.Equals(""))
            {

            }
            else
            {
                if (!isSync)
                {
                    workingForm.SetStateLabelText("Sync canceled.");
                    Console.WriteLine("Sync canceled.");
                    return;
                }
                Console.WriteLine("Editing..." + changedDirFile);
                workingForm.SetStateLabelText("Editing..." + new FileInfo(changedDirFile).Name);
                AlfaPackOfficeAPI.getInstance().uploadFile(changedDirFile, getParentId(new FileInfo(changedDirFile)));
            }
            //
            // upload unsynced files
            //
            foreach (string file in newFiles)
            {
                if (!isSync)
                {
                    workingForm.SetStateLabelText("Sync canceled.");
                    Console.WriteLine("Sync canceled.");
                    return;
                }
                Console.WriteLine("Uploading..." + new FileInfo(file).Name);
                workingForm.SetStateLabelText("Uploading..." + new FileInfo(file).Name);
                AlfaPackOfficeAPI.getInstance().uploadFile(file, getParentId(new FileInfo(createdDirFile)));
            }
            newFiles.Clear();
            Console.WriteLine("Uploading completed...");
            workingForm.SetStateLabelText("Uploading completed...");
        }

        private void bgWorkerUpload_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void bgWorkerUpload_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (File.Exists(createdDirFile))
            {
                /*
                FileInfo fi = new FileInfo(createdDirFile);
                if (alfaDriveDirFilesInfo.Keys.Contains(fi.Name))
                {
                    alfaDriveDirFilesInfo[fi.Name] = JToken.Parse("");
                }
                else
                {
                    alfaDriveDirFilesInfo.Add(fi.Name, JToken.Parse(""));
                }
                */
                Console.WriteLine("Uploading completed..." + createdDirFile);
                workingForm.SetStateLabelText("Uploading completed..." + new FileInfo(createdDirFile).Name);
            }

            if (File.Exists(changedDirFile))
            {
                /*
                FileInfo fi = new FileInfo(createdDirFile);
                if (alfaDriveDirFilesInfo.Keys.Contains(fi.Name))
                {
                    alfaDriveDirFilesInfo[fi.Name] = JToken.Parse("");
                }
                else
                {
                    alfaDriveDirFilesInfo.Add(fi.Name, JToken.Parse(""));
                }
                */
                Console.WriteLine("Edit completed..." + changedDirFile);
                workingForm.SetStateLabelText("Edit completed..." + new FileInfo(changedDirFile).Name);
            }

            createdDirFile = "";
            changedDirFile = "";
        }

        private void bgWorkerDelete_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
           
            
            if (deletedFile.Equals("")) return;

            Console.WriteLine("Deleting..." + deletedFile);
            workingForm.SetStateLabelText("Deleting..." + new FileInfo(deletedFile).Name);

            AlfaPackOfficeAPI.getInstance().deleteFile(getFileId(new FileInfo(deletedFile)));

        }


        private void bgWorkerDelete_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void bgWorkerDelete_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!File.Exists(deletedFile))
            {
                FileInfo fi = new FileInfo(deletedFile);
                /*
                if (alfaDriveDirFilesInfo.Keys.Contains(fi.Name, new StringComparer()))
                {
                    alfaDriveDirFilesInfo.Remove(fi.Name);
                }
                */
                workingForm.SetStateLabelText("Deleting completed..." + fi.Name);
                Console.WriteLine("Deleting completed..." + deletedFile);
            }
            deletedFile = "";
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void runWatcher()
        {
            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.IncludeSubdirectories = true;
            
            watcher.Path = AlfaDOCKvDrive.Model.AlfaDrive.getInstance().DrivePath;
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            //watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;

        }
        private bool isSync = false;

        internal bool setSync(bool isSync)
        {
            if (this.isSync != isSync)
            {
                this.isSync = isSync;
                if (isSync)
                {
                    startSync();
                }
                else
                {
                    stopSync();
                }
            }
            return this.isSync;
        }

        private System.ComponentModel.BackgroundWorker bgwDownloader  = new System.ComponentModel.BackgroundWorker();
        private System.ComponentModel.BackgroundWorker bgwUploader = new System.ComponentModel.BackgroundWorker();
        private System.ComponentModel.BackgroundWorker bgwDeleter = new System.ComponentModel.BackgroundWorker();
        private System.ComponentModel.BackgroundWorker bgwRenamer = new System.ComponentModel.BackgroundWorker();

        public List<string> newFiles = new List<string>();
        private void startSync()
        {
            if (bgwDownloader.IsBusy)
            {
                MessageBox.Show("System is busy to work. You'd like to sync later.", AlfaDrive.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isSync = false;
                return;
            }
            bgwDownloader.RunWorkerAsync();

            

            //bgWorkerUpload.RunWorkerAsync();

            //bgWorkerDelete.RunWorkerAsync();
        }

        private void stopSync()
        {
            
        }

        // Define the event handlers.
        List<string> createdDirFileTempList = new List<string>();
        List<string> changedDirFileTempList = new List<string>();

        class StringComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return x.Trim().ToLower().Equals(y.Trim().ToLower());
            }
            

            public int GetHashCode(string obj)
            {
                return 0;
            }
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if (!isSync) return;
            // Specify what is done when a file is changed, created, or deleted.
            
            FileInfo fi = new FileInfo(e.FullPath);
            //if (!alfaDriveDirFilesInfo.Keys.Contains(fi.Name.ToString(), new StringComparer()))
            if (fi.Attributes != FileAttributes.Directory)
            {
                if (!containsInDriveFile(fi))
                {
                    //
                    // creating completed
                    //
                    if (createdDirFileTempList.Contains(e.FullPath, new StringComparer()))
                    {
                        Console.WriteLine("OnCreated File: " + e.FullPath + " " + e.ChangeType);
                        workingForm.SetStateLabelText("OnCreated File: " + e.Name + " " + e.ChangeType);

                        while (bgwUploader.IsBusy)
                        {
                            System.Threading.Thread.Sleep(1000);
                        }

                        createdDirFile = e.FullPath;
                        createdDirFileTempList.Remove(e.FullPath);
                        // need to wait until file creation finish completedly.
                        Thread.Sleep(500);
                        if (isSync) bgwUploader.RunWorkerAsync();
                    }
                    //
                    // changed
                    //
                    else
                    {

                    }
                }
                else
                {
                    if (changedDirFileTempList.Contains(e.FullPath, new StringComparer()))
                    {
                        Console.WriteLine("OnChanged File: " + e.FullPath + " " + e.ChangeType);
                        workingForm.SetStateLabelText("OnChanged File: " + e.Name + " " + e.ChangeType);

                        while (bgwUploader.IsBusy)
                        {
                            System.Threading.Thread.Sleep(1000);
                        }

                        changedDirFile = e.FullPath;
                        changedDirFileTempList.Remove(e.FullPath);
                        // need to wait until file creation finish completedly.
                        Thread.Sleep(500);
                        if (isSync) bgwUploader.RunWorkerAsync();
                    }
                }
            }
            else
            {

            }
        }
        private void OnCreated(object source, FileSystemEventArgs e)
        {
            if (isSync == false) return;

            while(bgwDownloader.IsBusy)
            {
                Thread.Sleep(1000);
            }
            // Specify what is done when a file is changed, created, or deleted.

            FileInfo fi = new FileInfo(e.FullPath);
            //if (!alfaDriveDirFilesInfoArray.Keys.Contains(fi.Name, new StringComparer()))
            if (containsInDriveFile(fi) == false)
            {
                Console.WriteLine("OnCreated File: " + e.FullPath + " " + e.ChangeType);
                workingForm.SetStateLabelText("OnCreated File: " + e.Name + " " + e.ChangeType);
                createdDirFileTempList.Add(e.FullPath);
            }
        }

        private int getParentId(FileInfo fi)
        {
            // get relative directory path string
            string key = fi.Directory.FullName.Substring(AlfaDrive.getInstance().DrivePath.Length);
            if (key == "")
            {

            }
            else
            {
                key = key.Substring(1) + @"\";
            }
            // check dir-parentId dictionary
            if (alfaDriveDirFilesInfoParentIDArray.ContainsKey(key))
            {
                // get parentId corresponding to the relative path string
                return alfaDriveDirFilesInfoParentIDArray[key];
            }
            return -2;
        }
        private int getFileId(FileInfo fi)
        {
            // get relative directory path string
            string key = fi.Directory.FullName.Substring(AlfaDrive.getInstance().DrivePath.Length);
            if (key == "")
            {

            }
            else
            {
                key = key.Substring(1) + @"\";
            }
            // check dir-parentId dictionary
            if (alfaDriveDirFilesInfoParentIDArray.ContainsKey(key))
            {
                // get parentId corresponding to the relative path string
                int parenteId = alfaDriveDirFilesInfoParentIDArray[key];
                // loop all files
                foreach (var jfile in alfaDriveDirFilesInfoArray[parenteId].JTokenList)
                {
                    if (jfile["filename"].ToString().ToLower().Equals(fi.Name.ToLower()))
                        return (int) jfile["id"];
                }
            }
            return -1;
        }


        private bool containsInDriveFile(FileInfo fi)
        {
            // get relative directory path string
            string key = fi.Directory.FullName.Substring(AlfaDrive.getInstance().DrivePath.Length);
            if (key == "")
            {

            }
            else
            {
                key = key.Substring(1) + @"\";
            }
            // check dir-parentId dictionary
            if (alfaDriveDirFilesInfoParentIDArray.ContainsKey(key))
            {
                // get parentId corresponding to the relative path string
                int parenteId = alfaDriveDirFilesInfoParentIDArray[key];
                // loop all files
                foreach (var jfile in alfaDriveDirFilesInfoArray[parenteId].JTokenList)
                {
                    if (jfile["filename"].ToString().ToLower().Equals(fi.Name.ToLower()))
                        return true;
                }
            }

            return false;
        }

        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            if (!isSync) return;
            // Specify what is done when a file is changed, created, or deleted.
            FileInfo fi = new FileInfo(e.FullPath);
            //if (alfaDriveDirFilesInfo.Keys.Contains(fi.Name, new StringComparer()))
            if(containsInDriveFile(fi))
            {
                Console.WriteLine("OnDeleted File: " + e.FullPath + " " + e.ChangeType);
                workingForm.SetStateLabelText("OnDeleted File: " + e.Name + " " + e.ChangeType);

                while (bgwDeleter.IsBusy)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                deletedFile = e.FullPath;
                if (isSync) bgwDeleter.RunWorkerAsync();
            }
        }
        private string renameOld = "";
        private string renameNew = "";
        private void OnRenamed(object source, RenamedEventArgs e)
        {
            if (!isSync) return;
            // Specify what is done when a file is renamed.
            FileInfo fi = new FileInfo(e.OldFullPath);
            //if (fi.Directory.Attributes != FileAttributes.Directory)
            {
                //if (alfaDriveDirFilesInfo.Keys.Contains(fi.Name, new StringComparer()))
                if (containsInDriveFile(fi))
                {
                    Console.WriteLine("OnRenamed File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
                    workingForm.SetStateLabelText(String.Format("OnRenamed File: {0} renamed to {1}", e.OldName, e.Name));

                    while (bgwRenamer.IsBusy)
                    {
                        Thread.Sleep(1000);
                    }
                    renameOld = e.OldFullPath;
                    renameNew = e.FullPath;

                    bgwRenamer.RunWorkerAsync();
                }
            }
            //else
            {

            }
        }

    }    
}