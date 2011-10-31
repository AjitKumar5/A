using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class View:BaseDBObject
    {
        public string Schema { get; set; }
        public bool IsRecompiled { get; set; }
        public bool IsSchemaBound { get; set; }
        public bool WithCheckOption { get; set; }
        public string Definition { get; set; }
        public bool UsesAnsiNull { get; set; }
        public bool UsesQuotedIdentifier { get; set; }

        public string Script(ScriptingOptions so)
        {

            StringBuilder sbScript = new StringBuilder();
            if (so.ScriptAnsiNulls)
            {
                sbScript.Append("SET ANSI_NULLS ");
                if (UsesAnsiNull)
                    sbScript.Append("ON" + System.Environment.NewLine);
                else
                    sbScript.Append("OFF" + System.Environment.NewLine);

                sbScript.Append("GO" + System.Environment.NewLine);
            }
            if (so.ScriptQuotedIdentifiers)
            {
                sbScript.Append("SET QUOTED_IDENTIFIER ");
                if (UsesQuotedIdentifier)
                    sbScript.Append("ON" + System.Environment.NewLine);
                else
                    sbScript.Append("OFF" + System.Environment.NewLine);

                sbScript.Append("GO" + System.Environment.NewLine);
            }
            sbScript.Append(Definition + System.Environment.NewLine + "GO" + System.Environment.NewLine);
            return sbScript.ToString().Trim();
        }
    }
}
