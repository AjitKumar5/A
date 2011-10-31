using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Table : BaseDBObject
    {
        public string Schema
        {
            get;
            set;
        }
        public string Filegroup
        {
            get;
            set;
        }
        public bool AnsiNullsStatus
        {
            get;
            set;
        }
        public bool QuotedIdentifierStatus
        {
            get;
            set;
        }
        public bool ChangeTrackingEnabled
        {
            get;
            set;
        }
        public bool TrackColumnsUpdatedEnabled
        {
            get;
            set;
        }
        public string PartitionScheme
        {
            get;
            set;
        }
        public string FileStreamGroup
        {
            get;
            set;
        }
        public string FileStreamPartitionScheme
        {
            get;
            set;
        }
        public string TextFileGroup
        {
            get;
            set;
        }
        public string PartitionedColumn
        {
            get;
            set;
        }
        public int NumberOfPartitions { get; set; }
        public SortedList<int, string> Partitions{get;set;}
        public List<Column> Columns { get; set; }
        public List<DefaultConstraint> DefaultConstraints { get; set; }
        public List<CheckConstraint> CheckConstraints { get; set; }
        public List<PrimaryKeyConstraint> PrimaryKeyConstraint { get; set; }
        public List<UniqueConstraint> UniqueConstraints { get; set; }
        public List<DBObjectType.ForeignKeyConstraint> ForeignKeys { get; set; }
        public List<FullTextIndex> FullTextIndexes { get; set; }
        
        //REFERENCES dorobit
        

        public string Script()
        {
            ScriptingOptions so = new ScriptingOptions();
            so.DataCompression = false;
            so.ServerMajorVersion = 9;
            so.ScriptAnsiNulls = false;
            so.ScriptQuotedIdentifiers = false;
            
            return Script(so);
        }

        public string Script(ScriptingOptions so)
        {

            StringBuilder sbScript = new StringBuilder();

            #region ANSI_NULLS, QUOTED IDENTIFIERS, ANSI PADDING 
            
            if (so.ScriptAnsiNulls)
            {
                sbScript.Append("SET ANSI_NULLS ");
                if (AnsiNullsStatus)
                {
                    sbScript.Append("ON" + System.Environment.NewLine);
                }
                else
                {
                    sbScript.Append("OFF" + System.Environment.NewLine);
                }
                sbScript.Append("GO" + System.Environment.NewLine);
            }

            if (so.ScriptQuotedIdentifiers)
            {
                sbScript.Append("SET QUOTED_IDENTIFIER ");
                if (QuotedIdentifierStatus)
                {
                    sbScript.Append("ON" + System.Environment.NewLine);
                }
                else
                {
                    sbScript.Append("OFF" + System.Environment.NewLine);
                }
                sbScript.Append("GO" + System.Environment.NewLine);
            }
            sbScript.Append("SET ANSI_PADDING ON" + System.Environment.NewLine + "GO" + System.Environment.NewLine);
            
            #endregion
            
            sbScript.Append("CREATE TABLE [" + Schema + "].[" + Name + "](" + System.Environment.NewLine);

            StringCollection scTableDefinition = new StringCollection();

            for (int i = 0; i < Columns.Count; i++)
            {
                Column column = Columns[i];
                scTableDefinition.Add(column.Script(so));
            }

            if (so.PrimaryKeys)
            {
                if (PrimaryKeyConstraint.Count > 0)
                {
                    PrimaryKeyConstraint pkIndex = PrimaryKeyConstraint[0];
                    scTableDefinition.Add(pkIndex.Script(so));
                }
            }
            if (so.UniqueConstraints)
            {
                for (int i = 0; i < UniqueConstraints.Count; i++)
                {
                    scTableDefinition.Add(UniqueConstraints[i].Script(so));
                }
            }

            if (so.ForeignKeys)
            {
                for (int i = 0; i <this.ForeignKeys.Count; i++)
                {
                    scTableDefinition.Add(ForeignKeys[i].Script(so));
                }  
            }

            for (int i = 0; i < scTableDefinition.Count; i++)
            {
                sbScript.Append("\t" + scTableDefinition[i] );
                if (i != scTableDefinition.Count - 1)
                {
                    sbScript.Append(",");
                }
                sbScript.Append(System.Environment.NewLine);
            }

                sbScript.Append(") ");
            if (PartitionScheme != "")
            {
                sbScript.Append(" ON [" + PartitionScheme + "](["+ PartitionedColumn +"])");
            }
            else
            {
                if (Filegroup != "")
                {
                    sbScript.Append(" ON [" + Filegroup + "]");
                }
                else
                {
                    if (PrimaryKeyConstraint != null)
                    {
                        if (PrimaryKeyConstraint.Count > 0)
                        {
                            if (PrimaryKeyConstraint[0].DataSpaceType == "FG")
                            {
                                sbScript.Append(" ON [" + PrimaryKeyConstraint[0].DataSpace + "]");
                            }
                        }
                    }
                }
            }
            if (FileStreamGroup != "")
            {
                sbScript.Append(" FILESTREAM_ON [" + FileStreamGroup + "]");
            }
            else if (FileStreamPartitionScheme != "")
            {
                sbScript.Append(" FILESTREAM_ON [" + FileStreamPartitionScheme + "]");
            }
            if (TextFileGroup != "")
            {
                sbScript.Append(" TEXTIMAGE_ON [" + TextFileGroup + "]");
            
            }
            if (so.DataCompression)
            {
                if (Partitions.Count > 1)
                {
                    sbScript.Append(System.Environment.NewLine);
                    sbScript.Append("WITH" + System.Environment.NewLine);
                    sbScript.Append("(" + System.Environment.NewLine);
                    for (int i = 1; i <= Partitions.Count; i++)
                    {
                        sbScript.Append("\tDATA_COMPRESSION = " + Partitions[i] + " ON PARTITIONS ("+i+")");
                        if (i != Partitions.Count)
                        {
                            sbScript.Append(",");
                        }
                        sbScript.Append(System.Environment.NewLine);
                    }
                    sbScript.Append(")" + System.Environment.NewLine);
                }
            }
            sbScript.Append(System.Environment.NewLine);
            sbScript.Append("GO" + System.Environment.NewLine);
            sbScript.Append("SET ANSI_PADDING OFF" + System.Environment.NewLine + "GO" + System.Environment.NewLine);


            if (so.DefaultConstraints)
            {
                foreach (DefaultConstraint constraint in DefaultConstraints)
                {
                    sbScript.Append(constraint.Script() + System.Environment.NewLine);
                    sbScript.Append("GO" + System.Environment.NewLine);
                    sbScript.Append(System.Environment.NewLine);
                }
            }

            if (so.CheckConstraints)
            {
                foreach (CheckConstraint constraint in CheckConstraints)
                {
                    sbScript.Append(constraint.Script() + System.Environment.NewLine);
                    sbScript.Append("GO" + System.Environment.NewLine);
                    sbScript.Append(System.Environment.NewLine);
                }
            }

            if (so.FullTextIndexes)
            {
                foreach (FullTextIndex index in this.FullTextIndexes)
                {
                    sbScript.Append(index.Script() + System.Environment.NewLine);
                    sbScript.Append("GO" + System.Environment.NewLine);
                    sbScript.Append(System.Environment.NewLine);
                }
            }

            return sbScript.ToString().Trim();
        }

        
    }
}
