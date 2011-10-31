using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class UserDefinedTableType : BaseDBObject
    {
        public string Schema { get; set; }

        public List<UserDefinedTableTypeColumn> Columns { get; set; }

        public List<UserDefinedTableTypeIndex> Indexes { get; set; }

        public List<UserDefinedTableTypeCheckConstraint> CheckConstraints { get; set; }

        public UserDefinedTableType()
        {
            Columns = new List<UserDefinedTableTypeColumn>();
            Indexes = new List<UserDefinedTableTypeIndex>();
            CheckConstraints = new List<UserDefinedTableTypeCheckConstraint>();
        }

        public string Script(ScriptingOptions so)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE TYPE [" + Schema + "].["+Name+"] AS TABLE(" + System.Environment.NewLine);
            for (int i = 0; i < Columns.Count; i++)
            {
                sbScript.Append("\t["+Columns[i].Name + "] ");

                if (!Columns[i].IsComputed)
                {
                    switch (Columns[i].DataType.ToUpper())
                    {
                        case "IMAGE":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "TEXT":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "UNIQUEIDENTIFIER":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "DATE":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "TIME":
                            if (Columns[i].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(max) ");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(" + Columns[i].Scale + ") ");
                            }
                            break;
                        case "DATETIME2":
                            if (Columns[i].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(max) ");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(" + Columns[i].Scale + ") ");
                            }
                            break;
                        case "DATETIMEOFFSET":
                            if (Columns[i].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(max) ");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(" + Columns[i].Scale + ") ");
                            }
                            break;
                        case "TINYINT":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "SMALLINT":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "REAL":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "MONEY":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "DATETIME":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "SMALLDATETIME":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "INT":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "FLOAT":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "SQL_VARIANT":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "NTEXT":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "BIT":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "DECIMAL":
                            sbScript.Append("[" + Columns[i].DataType + "]" + " (" + Columns[i].Precision + "," + Columns[i].Scale + ") ");
                            break;
                        case "NUMERIC":
                            sbScript.Append("[" + Columns[i].DataType + "]" + " (" + Columns[i].Precision + "," + Columns[i].Scale + ") ");
                            break;
                        case "SMALLMONEY":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "BIGINT":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "HIERARCHYID":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "GEOMETRY":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "GEOGRAPHY":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        case "VARBINARY":
                            if (Columns[i].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(max) ");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(" + Columns[i].Length + ") ");
                            }
                            break;
                        case "VARCHAR":
                            if (Columns[i].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(max) ");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(" + Columns[i].Length + ") ");
                            }
                            break;
                        case "BINARY":
                            if (Columns[i].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(max) ");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(" + Columns[i].Length + ") ");
                            }
                            break;
                        case "CHAR":
                            if (Columns[i].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(max) ");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(" + Columns[i].Length + ") ");
                            }
                            break;
                        case "TIMESTAMP":
                            sbScript.Append("[" + Columns[i].DataType + "]" + " ");
                            break;
                        case "NVARCHAR":
                            if (Columns[i].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(max) ");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(" + Columns[i].Length + ") ");
                            }
                            break;
                        case "NCHAR":
                            if (Columns[i].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(max) ");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[i].DataType + "]" + "(" + Columns[i].Length + ") ");
                            }
                            break;
                        case "XML":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            if (Columns[i].IsColumnSet)
                            {
                                sbScript.Append(" COLUMN_SET FOR ALL_SPARSE_COLUMNS ");
                            }
                            break;
                        case "SYSNAME":
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                        default:
                            sbScript.Append("[" + Columns[i].DataType + "] ");
                            break;
                    }
                }
                else
                { 
                    sbScript.Append(" AS " + Columns[i].Definition);
                    if (Columns[i].IsPersisted)
                    {
                        sbScript.Append(" PERSISTED ");
                    }
                }
                if (Columns[i].Identity)
                {
                    sbScript.Append("IDENTITY("+ Columns[i].IdentitySeed+","+ Columns[i].IdentityIncrement +")");
                }
                if (Columns[i].IsRowGuidCol)
                {
                    sbScript.Append(" ROWGUIDCOL ");
                }

                if (!Columns[i].IsNullable)
                {
                    sbScript.Append(" NOT NULL");
                }

                if (Columns[i].Default != "")
                {
                    sbScript.Append(" DEFAULT " + Columns[i].Default);
                }

                if (i != Columns.Count - 1)
                {
                    sbScript.Append(",");
                }
                else
                {
                    if (Name == "LocationTableType6")
                    {
                        string a = "a";
                    }
                    if (Indexes.Count > 0 || CheckConstraints.Count > 0)
                    {
                        sbScript.Append(",");
                    }
                }

                
                sbScript.AppendLine();
            }
            for (int i = 0; i < Indexes.Count; i++)
            {
                if (Indexes[i].IsPrimaryKey)
                {
                    sbScript.Append("\tPRIMARY KEY ");
                }else if (Indexes[i].IsUnique)
                {
                    sbScript.Append("\tUNIQUE ");
                }
                sbScript.Append(Indexes[i].TypeDesc + System.Environment.NewLine);
                sbScript.Append("\t(" + System.Environment.NewLine);
                for (int j = 0; j < Indexes[i].Columns.Count; j++)
                {
                    sbScript.Append("\t\t[" + Indexes[i].Columns[j].Name+"]");
                    if (Indexes[i].Columns[j].IsDescendingKey)
                    {
                        sbScript.Append(" DESC");
                    }
                    else
                    {
                        sbScript.Append(" ASC");
                    }
                    if (j != Indexes[i].Columns.Count - 1)
                    {
                        sbScript.Append(",");
                    }
                    sbScript.Append(System.Environment.NewLine);
                }
                sbScript.Append("\t)");
                if (Indexes[i].IgnoreDupKey)
                {
                    sbScript.Append("WITH (IGNORE_DUP_KEY = ON)");
                }
                else
                {
                    sbScript.Append("WITH (IGNORE_DUP_KEY = OFF)");
                }
                if (i != Indexes.Count - 1)
                {
                    sbScript.Append(",");
                }
                else
                {
                    if (CheckConstraints.Count > 0)
                    {
                        sbScript.Append(",");
                    }
                }
                
                sbScript.AppendLine();
            }
            for (int i = 0; i < CheckConstraints.Count; i++)
            {
                sbScript.Append("\tCHECK ("+CheckConstraints[i].Definition+")");
                if (i != CheckConstraints.Count - 1)
                {
                    sbScript.Append(",");
                }
                sbScript.AppendLine();
            }
            sbScript.Append(")");
            
            return sbScript.ToString();
        
        }
    }

    public class UserDefinedTableTypeCheckConstraint :BaseDBObject
    {
        public int ParentObjectId { get; set; }
        public string Definition { get; set; }
    }

    public class UserDefinedTableTypeColumn:BaseDBObject
    {
        public int Id { get; set; }
        public bool IsNullable { get; set; }
        public bool IsComputed { get; set; }
        public bool IsRowGuidCol { get; set; }
        public bool IsFullTextIndexed { get; set; }
        public bool IsPersisted { get; set; }
        public string Collation { get; set; }
        public bool Identity { get; set; }
        public int IdentitySeed { get; set; }
        public int IdentityIncrement { get; set; }
        public string Default { get; set; }
        public bool IsFileStream { get; set; }
        public bool IsSparse { get; set; }
        public string DataType { get; set; }
        public int Length { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }
        public string Definition { get; set; }
        public bool IsColumnSet { get; set; }
    }

    public class UserDefinedTableTypeIndex:BaseDBObject
    {
        public int IndexId { get; set; }
        public string TypeDesc { get; set; }
        public bool IsUnique { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IgnoreDupKey { get; set; }
        public string FilterDefinition { get; set; }

        public List<IndexColumn> Columns { get; set; }
        public UserDefinedTableTypeIndex()
        {
            Columns = new List<IndexColumn>();
        }
    }
}
