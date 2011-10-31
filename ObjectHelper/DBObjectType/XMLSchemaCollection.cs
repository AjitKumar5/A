using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class XMLSchemaCollection:BaseDBObject
    {

        public string Definition { get; set; }
        public string Schema { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE XML SCHEMA COLLECTION [" + Schema + "].[" + Name + "] AS N'" + Definition + "'");
            return sbScript.ToString();
        }
    }
}
