using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINE_Backup_Restore.lib
{
    public class backupData
    {
        public string Header;
        public string SaveDate;
        public ArrayList SendMessage;
        public ArrayList SendParson;

        public backupData()
        {
            SendMessage = new ArrayList();
            SendParson = new ArrayList();
        }
    }
}
