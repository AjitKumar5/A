using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class ServiceQueue : BaseDBObject
    {
        public string Schema{get; set;}
        public string Principal { get; set; }
        public string PrincipalId { get; set; }
        public int MaxReaders { get; set; }
        public string ActivationProcedure { get; set; }
        public bool IsActivationEnabled { get; set; }
        public bool IsReceiveEnabled { get; set; }
        public bool IsEnqueueEnabled { get; set; }
        public bool IsRetentionEnabled { get; set; }
        public string FileGroup { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE QUEUE [" + Schema + "].[" + Name + "]"+System.Environment.NewLine);
            if (IsEnqueueEnabled)
            {
                sbScript.Append("\tWITH STATUS = ON, " + System.Environment.NewLine);
            }
            else
            {
                sbScript.Append("\tWITH STATUS = OFF, " + System.Environment.NewLine);
            }
            if (IsRetentionEnabled)
            {
                sbScript.Append("\tRETENTION = ON, " + System.Environment.NewLine);
            }
            else
            {
                sbScript.Append("\tRETENTION = OFF, " + System.Environment.NewLine);
            }
            if (IsActivationEnabled)
            {
                sbScript.Append("\tACTIVATION ("+ System.Environment.NewLine);
                if (ActivationProcedure != "")
                {
                    sbScript.Append("\t\tPROCEDURE_NAME = "+ ActivationProcedure);
                }
                if (MaxReaders != 0)
                {
                    sbScript.Append("," + System.Environment.NewLine);
                    sbScript.Append("\t\tMAX_QUEUE_READERS = " + MaxReaders );
                }
                if (PrincipalId != "")
                {
                    if (PrincipalId == "1")
                    {
                        sbScript.Append(","+System.Environment.NewLine);
                        sbScript.Append("\t\tEXECUTE AS SELF");
                    }
                    else if (PrincipalId == "-2")
                    {
                        sbScript.Append(","+System.Environment.NewLine);
                        sbScript.Append("\t\tEXECUTE AS OWNER");
                    }
                    else
                    {
                        sbScript.Append(","+System.Environment.NewLine);
                        sbScript.Append("\t\tEXECUTE AS [" + Principal+ "]");
                    }
                }
                sbScript.Append(")"+System.Environment.NewLine);

            }
            if(FileGroup!="")
            {
                sbScript.Append("\tON [" +FileGroup+ "]");
            }
            return sbScript.ToString().Trim();
        }
    }
}
