using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class CLRTrigger:Trigger
    {
        //public string ParentObjectName { get; set; }
        public string AssemblyClass { get; set; }
        public string AssemblyMethod { get; set; }
        public string AssemblyName { get; set; }
        public string ExecuteAs { get; set; }
        public StringCollection Events { get; set; }

        public CLRTrigger()
        {
            Events = new StringCollection();
        }

        public new string Script(ScriptingOptions so)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE TRIGGER ");
            if (Schema != "")
            {
                sbScript.Append("[" + Schema + "].");
            }
                
            sbScript.Append("[" + Name + "]" + System.Environment.NewLine);
            if (ParentObjectName != "")
            {
                sbScript.Append("ON ");
                if (ParentObjectSchema != "")
                {
                    sbScript.Append("[" + ParentObjectSchema + "].");
                }
                sbScript.Append("[" + ParentObjectName + "]" + System.Environment.NewLine);
            }
            else
            {
                sbScript.Append("ON DATABASE" + System.Environment.NewLine);
            }

            if (ExecuteAs != "")
            {
                sbScript.Append("WITH EXECUTE AS " + ExecuteAs + System.Environment.NewLine);
            }
            
            if(IsInsteadOf)
                sbScript.Append("INSTEAD OF ");
            else if(IsAfter)
                sbScript.Append("AFTER ");
            else
                sbScript.Append("FOR ");

            for (int i = 0; i < Events.Count; i++)
            {
                sbScript.Append(Events[i]);
                if (i != Events.Count - 1)
                {
                    sbScript.Append(",");
                }
            }
            sbScript.Append(System.Environment.NewLine + "AS" + System.Environment.NewLine);
            sbScript.Append("EXTERNAL NAME [" + AssemblyName+"].["+AssemblyClass+"].["+ AssemblyMethod +"]"+ System.Environment.NewLine);
            sbScript.Append("GO");
            return sbScript.ToString();
        }
    }
}
