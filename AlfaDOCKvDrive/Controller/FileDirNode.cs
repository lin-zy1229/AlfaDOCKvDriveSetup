using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaDOCKvDrive.Controller
{
    public class FileDirNode
    {
        private string path = "";
        public string Path
        {
            get
            {
                return path;
            }
        }
        
        private List<JToken> jtokenList = new List<JToken>();
        public List<JToken> JTokenList
        { get { return jtokenList; } }

        public FileDirNode(string path)
        {
            this.path = path;
        }
    }
}