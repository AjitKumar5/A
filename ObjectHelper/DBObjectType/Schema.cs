using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Schema : BaseDBObject
    {
        public string Principal { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE SCHEMA [" + Name + "] AUTHORIZATION [" + Principal + "];");
            return sbScript.ToString();
        }
    }
}
