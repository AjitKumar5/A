using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Trigger:BaseDBObject
    {
        public int ParentClass { get; set; }
        public string ParentObjectName { get; set; }
        public string Schema { get; set; }
        public string ParentObjectSchema { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsNotForReplication { get; set; }
        public bool IsInsteadOf { get;set;}
        public string Definition { get; set; }
        public bool IsAfter { get; set; }
        public bool IsDatabaseTrigger { get; set; }

        public string Script(ScriptingOptions so)
        {
            StringBuilder sbScript = new StringBuilder();

            if (so.ScriptAnsiNulls)
            {
                sbScript.Append("SET ANSI_NULLS ON"+System.Environment.NewLine);
                sbScript.Append("GO" + System.Environment.NewLine);
            }
            if (so.ScriptQuotedIdentifiers)
            {
                sbScript.Append("SET QUOTED_IDENTIFIER ON" + System.Environment.NewLine);
                sbScript.Append("GO" + System.Environment.NewLine);
            }

            sbScript.Append(Definition.Trim() + System.Environment.NewLine + "GO" + System.Environment.NewLine);

            if (so.ScriptAnsiNulls)
            {
                sbScript.Append("SET ANSI_NULLS OFF" + System.Environment.NewLine);
                sbScript.Append("GO" + System.Environment.NewLine);
            }
            if (so.ScriptQuotedIdentifiers)
            {
                sbScript.Append("SET QUOTED_IDENTIFIER OFF" + System.Environment.NewLine);
                sbScript.Append("GO" + System.Environment.NewLine);
            }
            return (sbScript.ToString().Trim());
        }
    }
}
