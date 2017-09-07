using AlfaDOCKvDrive.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlfaDOCKvDrive.Controller
{
    public class AlfaPackOfficeAPI
    {
        public const string version = "0.03";

        int offset = 0;
        int rowcount = 100;

        private static AlfaPackOfficeAPI alfaPackOfficeAPI;
        public static AlfaPackOfficeAPI getInstance()
        {
            if (alfaPackOfficeAPI == null)
            {
                alfaPackOfficeAPI = new AlfaPackOfficeAPI();
            }
            return alfaPackOfficeAPI;
        }
        private AlfaPackOfficeAPI()
        {
        }
        // GET FILES
        const string GET_FILES_URL = @"https://www.alfadock-pack.com/api/adsocket/getSocketFiles";
        internal void initFileInfo(int parentID, string path)
        {
            //
            // create web request
            //
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GET_FILES_URL);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            // parameter
            string payload = String.Format(@"compid={0}&offset={1}&rowCount={2}&soctype={3}&sortOrder={4}&sortValue={5}&deleted={6}&filter={7}&parentid={8}&content={9}&admin={10}",
                 AlfaDOCKvDrive.Model.AlfaDrive.getInstance().compId,
                 offset,
                 rowcount,
                 "office",
                 "ASC",
                 "filename",
                 0,
                 3,
                 parentID,
                 "",
                 0
                 );

            var payloadBytes = Encoding.ASCII.GetBytes(payload);
            request.ContentLength = payloadBytes.Length;

            var requestStream = request.GetRequestStream();
            requestStream.Write(payloadBytes, 0, payloadBytes.Length);
            requestStream.Close();

            request.Accept = "application/json; charset=utf-8";
            //
            // get web response
            //
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return;
            }
            var reader = new System.IO.StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();

            var responseJsonArray = JArray.Parse(responseString);

            /*
             {"filename":"New folder",
             "guid":"",
             "thumbguid":"https://sirpi.s3-ap-northeast-1.amazonaws.com/981ae1df-41bc-46a6-a448-94cce79d63ac?AWSAccessKeyId=AKIAJACPTVWI6S554HTQ&Expires=2135372555&Signature=tMAvKPZzEGBKRbIg40ogHLkbFQo%3D",
             "attribute":0,
             "type":"office",
             "size":"0",
             "id":1552572,
             "username":"",
             "custname":null,
             "opername":null,
             "procname":null,
             "outguid":null,
             "quoteRequest":0,
             "prog_name":null,
             "mach_name":null,
             "mat_name":null,
             "mat_size":null,
             "numofsheets":0,
             "processtime":null,
             "totalFilescount":34,
             "filetype":0,
             "innerFiles":null,
             "pdf":null,
             "fileid":-1,
             "totalfolders":3,
             "totalfiles":31,
             "mo_no":null,
             "drawing_no":null,
             "parent_no":null,
             "product_no":null,
             "product_name":null,
             "material_size":null,
             "processids":null,
             "duedate":null}
            */

            if (parentID == -1)
            {
                SyncController.getInstance().alfaDriveDirFilesInfoArray.Clear();
                SyncController.getInstance().alfaDriveDirFilesInfoParentIDArray.Clear();
            }

            FileDirNode fnode = new FileDirNode(path);
            SyncController.getInstance().alfaDriveDirFilesInfoArray.Add(parentID, fnode);
            SyncController.getInstance().alfaDriveDirFilesInfoParentIDArray.Add(path, parentID);
            //
            // register cloud files
            //
            foreach (var jfile in responseJsonArray)
            {
                var filename = jfile["filename"].ToString();
                var guid = jfile["guid"].ToString();
                var filetype = (int)jfile["filetype"];
                var id = (int) jfile["id"];

                SyncController.getInstance().alfaDriveDirFilesInfoArray[parentID].JTokenList.Add(jfile);

                if (filetype == 0)
                {
                    initFileInfo(id, path + filename + @"\");
                }
                else
                {

                }

                
            }
        }
        public void getFiles(int parentId)
        {
            //
            // downloading
            //
            foreach (var jfile in SyncController.getInstance().alfaDriveDirFilesInfoArray[parentId].JTokenList)
            {
                var filename = jfile["filename"].ToString();
                var guid = jfile["guid"].ToString();
                var filetype = (int) jfile["filetype"];
                var id = (int)jfile["id"];
                //
                // download file
                //
                // File.Create(AlfaDrive.getInstance().path + @"\" + filename);
                if (filetype == 0)
                {
                    Directory.CreateDirectory(AlfaDrive.getInstance().DrivePath + @"\" + SyncController.getInstance().alfaDriveDirFilesInfoArray[parentId].Path + filename);
                    getFiles(id);
                }
                else if (filetype == 1) {
                    downloadFileByGuid(guid, SyncController.getInstance().alfaDriveDirFilesInfoArray[parentId].Path + filename);
                }
            }
        }

        // DOWNLOAD URL
        // https://www.alfadock-pack.com/api/file/downloadFileByGUID?guid=0f5653fa-68d4-4e6b-b61a-e8050d463bb5&filename=(13).png
        private string downloadFileByGuid(string guid, string absFilename)
        {
            string localfilename = AlfaDrive.getInstance().DrivePath + @"\" + absFilename;
            string filename = new FileInfo(localfilename).Name;
            if (File.Exists(localfilename))
            {
                return localfilename;
            }

            Console.WriteLine(string.Format("Downloading...{0}", absFilename));
            SyncController.getInstance().workingForm.SetStateLabelText(string.Format("Downloading...{0}", absFilename));

            File.Create(localfilename).Close();

            
            WebClient wb = new WebClient();
            wb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
            string url = String.Format(@"https://www.alfadock-pack.com/api/file/downloadFileByGUID?guid={0}&filename={1}",
                guid,
                filename);
            wb.DownloadFile(url, localfilename);
            

            return localfilename;
        }
        // https://www.alfadock-pack.com/api/adsocket/uploadSocketFolder
        /*
         cid			1					Company id
         userid			188					Userid
         parentId			-1					-1 : Root location. Folderid - Inside folder
         foldername		alfaDOCK - Response Sheet		Folder name
         sockType		office					It should be office
        */
        const string CREATE_FOLER_URL = "https://www.alfadock-pack.com/api/adsocket/uploadSocketFolder";

        internal void createFoloder(int parentId, string foldername)
        {
            //
            // create web request
            //
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(CREATE_FOLER_URL);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                // parameter
                string payload = String.Format(@"cid={0}&userid={1}&parentId={2}&foldername={3}&sockType={4}",
                    AlfaDOCKvDrive.Model.AlfaDrive.getInstance().compId,
                    AlfaDOCKvDrive.Model.AlfaDrive.getInstance().userId,
                    parentId,
                    foldername,
                    "office"
                     );

                var payloadBytes = Encoding.ASCII.GetBytes(payload);
                request.ContentLength = payloadBytes.Length;

                var requestStream = request.GetRequestStream();
                requestStream.Write(payloadBytes, 0, payloadBytes.Length);
                requestStream.Close();

                request.Accept = "application/json; charset=utf-8";
                //
                // get web response
                //
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
            // once renaming done, initialize files info
            initFileInfo(-1, "");
        }


        // http://13.112.195.153/api/adsocket/renameFile
        const string RENAME_FILE_URL = @"http://13.112.195.153/api/adsocket/renameFile";
        // fileid - int
        // filename - string
        internal void renameFile(string renameOld, string renameNew, int fileid)
        {
            //
            // create web request
            //
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(RENAME_FILE_URL);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                // parameter
                string payload = String.Format(@"fileid={0}&filename={1}",
                     fileid,
                     renameNew
                     );

                var payloadBytes = Encoding.ASCII.GetBytes(payload);
                request.ContentLength = payloadBytes.Length;

                var requestStream = request.GetRequestStream();
                requestStream.Write(payloadBytes, 0, payloadBytes.Length);
                requestStream.Close();

                request.Accept = "application/json; charset=utf-8";
                //
                // get web response
                //
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return;
                }
            }
            catch (Exception ex){ Console.WriteLine(ex.StackTrace); }
            // once renaming done, initialize files info
            initFileInfo(-1, "");
        }


        // Delete file
        // http://13.112.195.153/api/adsocket/DeleteFile
        const string DELETE_FILE_URL = @"http://13.112.195.153/api/adsocket/DeleteFile";
        // fielid - int
        internal void deleteFile(int fileId)
        {
            //
            // create web request
            //
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(DELETE_FILE_URL);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            // parameter
            string payload = String.Format(@"fileid={0}",
                 fileId
                 );

            var payloadBytes = Encoding.ASCII.GetBytes(payload);
            request.ContentLength = payloadBytes.Length;

            var requestStream = request.GetRequestStream();
            requestStream.Write(payloadBytes, 0, payloadBytes.Length);
            requestStream.Close();

            request.Accept = "application/json; charset=utf-8";
            //
            // get web response
            //
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return;
            }

            initFileInfo(-1, "");
        }


        // UPLOAD Files
        // https://www.alfadock-pack.com/api/adsocket/uploadOfficeSocketFiles
        const string UPLOAD_FILE_URL = @"https://www.alfadock-pack.com/api/adsocket/uploadOfficeSocketFiles";
        public void uploadFile(string localfilename, int parentId)
        {
            if (parentId == -2) parentId = -1;

            if (!File.Exists(localfilename)) return;

            FileInfo fi = new FileInfo(localfilename);
            string filename = fi.Name;

            FileStream fs = new FileStream(localfilename, FileMode.Open, FileAccess.Read);
            byte[] fileBytes = new byte[fs.Length];
            fs.Read(fileBytes, 0, fileBytes.Length);
            fs.Close();

            // Generate post objects
            Dictionary<string, object> postParameters = new Dictionary<string, object>();
            postParameters.Add("file", new FormUpload.FileParameter(fileBytes, filename)); //application/msword
            postParameters.Add("cid", AlfaDOCKvDrive.Model.AlfaDrive.getInstance().compId);
            postParameters.Add("userid", AlfaDOCKvDrive.Model.AlfaDrive.getInstance().userId);
            postParameters.Add("filename", filename);
            postParameters.Add("replace", "false");
            postParameters.Add("fileLength", fi.Length.ToString());
            postParameters.Add("socType","office");
            postParameters.Add("parentid", parentId);

            // Create request and receive response
            string userAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36"; // "Someone";
            HttpWebResponse response = FormUpload.MultipartFormDataPost(UPLOAD_FILE_URL, userAgent, postParameters);
            
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return;
            }
            var reader = new System.IO.StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();
        }
    }
}
