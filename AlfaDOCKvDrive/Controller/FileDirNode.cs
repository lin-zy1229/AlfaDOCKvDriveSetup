using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaDOCKvDrive.Controller
{
    public  class FileDirNode
    {
        int id;
        int parentId;
        JToken jtoken;

        public FileDirNode(int id, int parentId, JToken jtoken)
        {
            this.id = id;
            this.parentId = parentId;
            this.jtoken = jtoken;
        }
    }
}
