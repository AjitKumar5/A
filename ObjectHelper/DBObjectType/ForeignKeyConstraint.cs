using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class ForeignKeyConstraint : BaseDBObject
    {
        public ForeignKeyConstraint()
        {
            Columns = new List<ForeingKeyColumns>();
        }

        public int ParentObjectId { get; set; }
        public string Schema { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsNotForReplication { get; set; }
        public bool IsNotTrusted { get; set; }
        public string DeleteAction { get; set; }
        public string UpdateAction { get; set; }
        public List<ForeingKeyColumns> Columns { get; set; }

        public string Script(ScriptingOptions so)
        {
            StringBuilder sbScript = new StringBuilder();

            sbScript.Append("CONSTRAINT [" + Name + "] FOREIGN KEY ");
            sbScript.Append("(");
            for (int i = 0; i < Columns.Count; i++)
            {
                sbScript.Append( Columns[i].ParentColumnName);
                if (i != Columns.Count-1)
                {
                    sbScript.Append(",");
                }
            }
            sbScript.Append(") REFERENCES [" + Columns[0].ReferencedObjectSchema+"].[" + Columns[0].ReferencedObjectName+"] (");
            for (int i = 0; i < Columns.Count; i++)
            {
                sbScript.Append(Columns[i].ReferenceColumnName);
                if (i != Columns.Count-1)
                {
                    sbScript.Append(",");
                }
            }
            sbScript.Append(") ");
            if (DeleteAction != "NO_ACTION")
            {
                sbScript.Append("ON DELETE " + DeleteAction + " "); 
            }
            if (UpdateAction != "NO_ACTION")
            {
                sbScript.Append("ON UPDATE " + UpdateAction + " "); 
            }
            if (IsNotForReplication)
            {
                sbScript.Append("NOT FOR REPLICATION");
            }
            return sbScript.ToString();
        }
    }

    public class ForeingKeyColumns
    {
        public int ConstraintObjectId { get; set; }
        public int ConstraintColumnId { get; set; }
        public string ParentColumnName { get; set; }
        public string ReferencedObjectName { get; set; }
        public int ReferencedObjectId { get; set; }
        public string ReferencedObjectSchema { get; set; }
        public string ReferenceColumnName { get; set; }
    }
}
