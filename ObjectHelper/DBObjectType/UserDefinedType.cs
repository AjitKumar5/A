using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class UserDefinedType:BaseDBObject
    {
        public string Schema { get; set; }
        public string AssemblyName { get; set; }
        public string AssemblyClass { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE TYPE [" + Schema + "].[" + Name + "]"+System.Environment.NewLine);
            sbScript.Append("EXTERNAL NAME [" + AssemblyName + "].[" + AssemblyClass + "];");
            return sbScript.ToString();
        }

    }
}
