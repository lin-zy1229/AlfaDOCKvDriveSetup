using SharpShell.SharpIconOverlayHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpShell.Interop;
using System.IO;

namespace AlfaDOCKvDrive.Model
{
    public class ReadOnlyFileIconOverlayHandler : SharpIconOverlayHandler
    {
        protected override int GetPriority()
        {
            return 90;
        }

        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            try
            {
                //  Get the file attributes.
                var fileAttributes = new FileInfo(path);

                //  Return true if the file is read only, meaning we'll show the overlay.
                return fileAttributes.IsReadOnly;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override System.Drawing.Icon GetOverlayIcon()
        {
            return Properties.Resources.AlfaDOCKvDrive;
        }
        
    }
}
