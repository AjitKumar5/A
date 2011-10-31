using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Synonym:BaseDBObject
    {
        public string Schema { get; set; }
        public string Definition { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();

            sbScript.Append("CREATE SYNONYM [" + Name + "] FOR " + Definition);

            return sbScript.ToString();
        }
    }
}
