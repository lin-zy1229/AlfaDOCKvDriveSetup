using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaDOCKvDrive.Model
{
    public class AlfaDrive
    {
        public const string APP_NAME = "AlfaDOCKvDrive";
        //public const string GUID = "325ddf1c-6571-4ea7-a255-2f139a9b64ed";
        //public const string GUID = "9b4992c5-8a13-4dce-9e42-24d83916b797";
        //public const string GUID = "9b78ed88-a507-4de3-bb43-8751c0a9774c";
        //public const string GUID = "bc97b5cb-42cb-4754-adc8-1c90ee396980";
        //public const string GUID = "a6350b19-fdf8-48db-bb4e-3980441f53bc";
        //public const string GUID = "50dc06dd-8e98-4524-b090-95b5f52c2dfa";
        //public const string GUID = "b4dcf670-4711-48f7-b6d4-eaa2a972ed66"; 
        //public const string GUID = "7ec43b3c-f6b9-447d-b86a-57a5fd08b36c";
        //public const string GUID = "0fa0770f-8001-4cae-9d45-24d6e8984050";
        //public const string GUID = "0fa0770f-8001-4cae-9d45-24d6e8984051";
          public const string GUID = "0fa0770f-8001-4cae-9d45-24d6e8984500";

        public const string INSTANCE_CLSID = "0E5AAE11-A475-4c5b-AB00-C66DE400274E";

        public const string Account_ID = "Personal";


        public string DrivePath
        {
            get { return System.Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + APP_NAME; }
        }

        internal void init()
        {
            
        }

        private static AlfaDrive alfaDrive;
        public static AlfaDrive getInstance()
        {
            if (alfaDrive == null)
            {
                alfaDrive = new AlfaDrive();
            }
            return alfaDrive;
        }
        private AlfaDrive()
        {
            
        }

        public string compName = "";
        public string compId = "";
        public string compPassword = "";

        public string userName = "";
        public string userId = "";
        public string userPassword = "";
        internal void setCredential(string compName, string compId, string compPassword, string userName, string userId, string userPassword)
        {
            this.compName = compName;
            this.compId = compId;
            this.compPassword = compPassword;

            this.userName = userName;
            this.userId = userId;
            this.userPassword = userPassword;

        }
    }
}
