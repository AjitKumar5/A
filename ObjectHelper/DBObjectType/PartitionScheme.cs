using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class PartitionScheme :BaseDBObject
    {
        public List<string> FileGroups { get; set; }
        public string PartitionFunction { get; set; }

        public PartitionScheme()
        {
            FileGroups = new List<string>();
        }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE PARTITION SCHEME [" + Name + "]"+System.Environment.NewLine);
            sbScript.Append("AS PARTITION [" + PartitionFunction + "]" + System.Environment.NewLine);
            sbScript.Append("TO (");
            for (int i = 0; i < FileGroups.Count; i++)
            {
                sbScript.Append(FileGroups[i]);
                if (i != FileGroups.Count - 1)
                {
                    sbScript.Append(",");
                }
            }
            sbScript.Append(");");
            return sbScript.ToString();
        }
        
    }
}
