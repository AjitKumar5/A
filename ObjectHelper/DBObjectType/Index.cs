using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Index : BaseDBObject
    {
        public int IndexId { get;set; }
        public string Type {get;set;}
        public bool IsUnique { get; set; }
        public bool IsPrimary {get;set;}
        public bool IgnoreDupKey { get; set; }
        public bool IsUniqueConstraint { get; set; }
        public int FillFactor { get; set; }
        public bool IsPadded { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsHypothetical { get; set; }
        public bool AllowRowLocks { get; set; }
        public bool AllowPageLocks { get; set; }
        public bool HasFilter { get; set; }
        public bool StatisticsNoRecompute { get; set; }
        public string FilterDefinition { get; set; }
        public string DataSpaceType { get; set; }
        public string DataSpace { get; set; }
        public string PartitionedColumn { get; set; }
        public string FileStreamFileGroup { get; set; }
        public string ObjectName { get; set; }
        public string ObjectSchema { get; set; }
        public SortedList<int, string> Partitions { get; set; }
        public List<IndexColumn> Columns { get; set; }

        public Index()
        { 
        }

        public virtual string Script(ScriptingOptions os)
        {
            StringBuilder sbScript = new StringBuilder();

            sbScript.Append("CREATE ");
            if (IsUnique)
            {
                sbScript.Append("UNIQUE ");
            }
            sbScript.Append(Type +" INDEX [" + Name + "] ON ");
            sbScript.Append("[" + ObjectSchema + "].[" + ObjectName + "]");
            
            //+ IsUnique +  " [" + Name + "] PRIMARY KEY " + Type);
            sbScript.AppendLine();
            sbScript.Append("(");
            sbScript.AppendLine();
            for (int i = 0; i < Columns.Count; i++)
            {
                sbScript.Append("\t[" + Columns[i].Name + "]");
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
                sbScript.AppendLine();
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
            if (FileStreamFileGroup != "")
            {
                if (Type == "CLUSTERED")
                {
                    sbScript.Append(" FILESTREAM_ON [" + FileStreamFileGroup + "]");
                }
            }
            sbScript.Append(System.Environment.NewLine + "GO");
            return sbScript.ToString();

            
        }
    }
}
