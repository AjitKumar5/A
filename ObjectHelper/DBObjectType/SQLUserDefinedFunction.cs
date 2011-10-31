using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class SQLUserDefinedFunction:BaseDBObject
    {
        public string Schema { get; set; }
        public string Definition { get; set; }
        public bool QuotedIdentifiers { get; set; }
        public bool IsDeterministic { get; set; }
        public List<Parameter> Parameters { get; set; }
        public Parameter Output { get; set; }
        public bool IsTableValued { get; set; }

        public SQLUserDefinedFunction()
        {
            Parameters = new List<Parameter>();
        }

        public string Script(ScriptingOptions so)
        {
            StringBuilder sbScript = new StringBuilder();
            if (so.ScriptAnsiNulls)
            {
                sbScript.Append("SET ANSI_NULLS ON" + System.Environment.NewLine);
                sbScript.Append("GO" + System.Environment.NewLine);
            }
            if (QuotedIdentifiers)
            {
                sbScript.Append("SET QUOTED_IDENTIFIER ON" + System.Environment.NewLine);
                sbScript.Append("GO" + System.Environment.NewLine);
            }
            sbScript.Append(Definition);
            return sbScript.ToString();
        }

    }
}
