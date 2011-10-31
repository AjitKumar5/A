using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Route:BaseDBObject
    {
        public string RemoteService { get; set; }
        public string BrokerInstance { get; set; }
        public int LifeTime { get; set; }
        public string Address { get; set; }
        public string MirrorAddress { get; set; }
        public string Principal { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE ROUTE [" +Name+"]"+System.Environment.NewLine);
            sbScript.Append("AUTHORIZATION [" + Principal + "]" + System.Environment.NewLine);
            sbScript.Append("WITH" + System.Environment.NewLine);
            if (RemoteService != "")
            {
                sbScript.Append("\tSERVICE NAME = '"+RemoteService+"'," + System.Environment.NewLine);
            }
            if (BrokerInstance != "")
            {
                sbScript.Append("\tBROKER INSTANCE = '" + BrokerInstance + "'," + System.Environment.NewLine);
            }
            if (LifeTime > 0)
            {
                sbScript.Append("\tLIFETIME = " +LifeTime + "," + System.Environment.NewLine);
            }
            sbScript.Append("\tADDRESS = '" + Address + "'");
            if (MirrorAddress != "")
            {
                sbScript.Append(System.Environment.NewLine);
                sbScript.Append("\tMIRROR_ADDRESS ='" + MirrorAddress + "'");
            }
            sbScript.Append(";");

            return sbScript.ToString();
        }
    }
}
