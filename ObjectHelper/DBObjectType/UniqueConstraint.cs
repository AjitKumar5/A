using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class UniqueConstraint:Index
    {
        

        public UniqueConstraint()
            : base()
        {
        }

        public new string Script(ScriptingOptions so)
        {
            StringBuilder sbScript = new StringBuilder();

            sbScript.Append("CONSTRAINT [" + Name + "] UNIQUE " + Type);
            sbScript.Append(" (");

            for (int i = 0; i < Columns.Count; i++)
            {
                sbScript.Append("[" + Columns[i].Name + "]");
                if (Columns[i].IsDescendingKey)
                {
                    sbScript.Append(" DESC");
                }
                else
                {
                    sbScript.Append(" ASC");
                }
                if (i != Columns.Count - 1)
                {
                    sbScript.Append(",");
                }
            }

            sbScript.Append(") ");

            sbScript.Append(" WITH (");
            sbScript.Append("PAD_INDEX = ");
            if (IsPadded)
            {
                sbScript.Append("ON");
            }
            else
            {
                sbScript.Append("OFF");
            }
            sbScript.Append(", STATISTICS_NORECOMPUTE = ");
            if (StatisticsNoRecompute)
            {
                sbScript.Append("ON");
            }
            else
            {
                sbScript.Append("OFF");
            }
            sbScript.Append(", IGNORE_DUP_KEY = ");
            if (IgnoreDupKey)
            {
                sbScript.Append("ON");
            }
            else
            {
                sbScript.Append("OFF");
            }
            sbScript.Append(", ALLOW_ROW_LOCKS = ");
            if (AllowRowLocks)
            {
                sbScript.Append("ON");
            }
            else
            {
                sbScript.Append("OFF");
            }
            sbScript.Append(", ALLOW_PAGE_LOCKS = ");
            if (AllowPageLocks)
            {
                sbScript.Append("ON");
            }
            else
            {
                sbScript.Append("OFF");
            }
            if (FillFactor != 0)
            {
                sbScript.Append(", FILLFACTOR = " + FillFactor);
            }
            sbScript.Append(")");

            //sbScript.AppendLine();
            sbScript.Append("ON ");
            if (DataSpaceType == "FG")
            {
                sbScript.Append("[" + DataSpace + "]");
            }
            else if (DataSpaceType == "PS")
            {
                sbScript.Append("[" + DataSpace + "] (" + PartitionedColumn + ")");
            }

            return sbScript.ToString();
        }
    }
}
