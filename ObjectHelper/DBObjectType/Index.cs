using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ObjectHelper.DBObjectType
{
    public class Index : BaseDbObject
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
        public int ReferencedObjecId { get; set; }
        public string ReferencedObjectType { get; set; }
        public SortedList<int, string> Partitions { get; set; }
        public List<IndexColumn> Columns { get; set; }

        public Index()
        { 
            Columns=new List<IndexColumn>();
            Partitions = new SortedList<int, string>();
        }

        public virtual string Script(ScriptingOptions os)
        {
            var sbScript = new StringBuilder();

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

            var sortedColumns = Columns.Where(c => !c.IsIncluded).OrderBy(c => c.IndexColumnId).ToArray();
            for (int i = 0; i < sortedColumns.Count(); i++)
            {
                var column = sortedColumns[i];
                sbScript.Append("\t[" + column.Name + "]");
                sbScript.Append(column.IsDescendingKey ? " DESC" : " ASC");
                
                if (i != sortedColumns.Count() - 1)
                    sbScript.Append(",");

                sbScript.AppendLine();
            }
            
            sbScript.Append(") ");

            var includedColumns = Columns.Where(c => c.IsIncluded).OrderBy(c => c.IndexColumnId).ToArray();
            if(includedColumns.Count() > 0)
            {
                sbScript.AppendLine();
                sbScript.Append("INCLUDE (");
                sbScript.AppendLine();

                for (int i = 0; i < includedColumns.Count(); i++)
                {
                    var column = includedColumns[i];
                    sbScript.Append("\t[" + column.Name + "]");

                    if (i != includedColumns.Count() - 1)
                        sbScript.Append(",");

                    sbScript.AppendLine();
                }

                sbScript.Append(") ");
            }

            sbScript.Append(" WITH (");
            sbScript.Append("PAD_INDEX = ");
            sbScript.Append(IsPadded ? "ON" : "OFF");
            sbScript.Append(", STATISTICS_NORECOMPUTE = ");
            sbScript.Append(StatisticsNoRecompute ? "ON" : "OFF");
            sbScript.Append(", IGNORE_DUP_KEY = ");
            sbScript.Append(IgnoreDupKey ? "ON" : "OFF");
            sbScript.Append(", ALLOW_ROW_LOCKS = ");
            sbScript.Append(AllowRowLocks ? "ON" : "OFF");
            sbScript.Append(", ALLOW_PAGE_LOCKS = ");
            sbScript.Append(AllowPageLocks ? "ON" : "OFF");
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
            sbScript.Append(Environment.NewLine + "GO");
            return sbScript.ToString();

            
        }
    }
}
