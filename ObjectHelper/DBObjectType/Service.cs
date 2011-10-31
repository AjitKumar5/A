using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Service:BaseDBObject
    {
        public string Principal { get; set; }
        public string ServiceQueueSchema { get; set; }
        public string ServiceQueue { get; set; }
        public List<string> Contracts { get; set; }

        public Service()
        {
            Contracts = new List<string>();
        }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE SERVICE [" + Name + "]"+System.Environment.NewLine);
            sbScript.Append("AUTHORIZATION [" + Principal + "]" + System.Environment.NewLine);
            sbScript.Append("ON QUEUE [" + ServiceQueueSchema + "].["+ ServiceQueue +"]" + System.Environment.NewLine);
            if (Contracts.Count > 0)
            {
                
                for (int i = 0; i < Contracts.Count; i++)
                {
                    if (i == 0)
                    {
                        sbScript.Append("\t([" + Contracts[i].ToString() + "]");
                    }
                    else
                    {
                        sbScript.Append("\t [" + Contracts[i].ToString()+"]");
                    }
                    
                    if (i != Contracts.Count - 1)
                    {
                        sbScript.Append(","+System.Environment.NewLine);
                    }
                    else
                    {
                        sbScript.Append(");");
                    }
                }

            }
           
            return sbScript.ToString().Trim();
        }
    }

}
