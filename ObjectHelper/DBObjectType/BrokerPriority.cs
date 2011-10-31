using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class BrokerPriority:BaseDBObject
    {
        public int Priority { get; set; }
        public string LocalService { get; set; }
        public string RemoteService { get; set; }
        public string Contract { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE BROKER PRIORITY [" + Name+"]"+System.Environment.NewLine);
            sbScript.Append("\tFOR CONVERSATION" + System.Environment.NewLine);
            sbScript.Append("\tSET (CONTRACT_NAME = ");
            if(Contract!="ANY")
            {
                sbScript.Append("[" + Contract + "]" + "," + System.Environment.NewLine);
            }
            else
            {
                sbScript.Append(Contract  + "," + System.Environment.NewLine);
            }
             
            sbScript.Append("\t     LOCAL_SERVICE_NAME = ");
            if (LocalService != "ANY")
            {
                sbScript.Append("[" + LocalService + "]" + "," + System.Environment.NewLine);
            }
            else
            {
                sbScript.Append(LocalService + "," + System.Environment.NewLine);
            }

            sbScript.Append("\t     REMOTE_SERVICE_NAME = ");
            if (RemoteService != "ANY")
            {
                sbScript.Append("[" + RemoteService + "]" + "," + System.Environment.NewLine);
            }
            else
            {
                sbScript.Append(RemoteService + "," + System.Environment.NewLine);
            }
            sbScript.Append("\t     PRIORITY_LEVEL = " + Priority + ");" + System.Environment.NewLine);
            return sbScript.ToString();
        }
    }
}
