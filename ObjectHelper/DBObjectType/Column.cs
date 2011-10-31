using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Column : BaseDBObject
    {
        public int ColumnId { get; set; }
        public bool IsNullable { get; set; }
        public bool IsComputed { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsFileStream { get; set; }
        public bool IsReplicated { get; set; }
        public bool IsSparse { get; set; }
        public bool IsRowGuidCol { get; set; }
        public bool IsPersisted { get; set; }
        public bool IsUnique { get; set; }
        public bool IsColumnSet { get; set; }
        public string Definition { get; set; }
        public string Type { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }
        public int IdentitySeed { get; set; }
        public int IdentityIncrement { get; set; }
        public string Collation { get; set; }
        public bool IsUserDefinedDataType { get; set; }
        
        public string Script(ScriptingOptions so)
        {
            StringBuilder sbScript = new StringBuilder();

            sbScript.Append("[" + Name + "] ");
            if (IsComputed)
            {
                sbScript.Append("AS " + Definition + " ");
                if (IsPersisted)
                {
                    sbScript.Append("PERSISTED ");
                }
            }
            else
            {
                switch (Type.ToUpper())
                {
                    case "IMAGE":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "TEXT":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "UNIQUEIDENTIFIER":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "DATE":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "TIME":
                        if (Precision == -1)
                        {
                            sbScript.Append("[" + Type + "]" + "(max) ");
                        }
                        else
                        {
                            sbScript.Append("[" + Type + "]" + "(" + Scale + ") ");
                        }
                        break;
                    case "DATETIME2":
                        if (Precision == -1)
                        {
                            sbScript.Append("[" + Type + "]" + "(max) ");
                        }
                        else
                        {
                            sbScript.Append("[" + Type + "]" + "(" + Scale + ") ");
                        }
                        break;
                    case "DATETIMEOFFSET":
                        if (Precision == -1)
                        {
                            sbScript.Append("[" + Type + "]" + "(max) ");
                        }
                        else
                        {
                            sbScript.Append("[" + Type + "]" + "(" + Scale + ") ");
                        }
                        break;
                    case "TINYINT":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "SMALLINT":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "REAL":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "MONEY":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "DATETIME":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "SMALLDATETIME":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "INT":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "FLOAT":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "SQL_VARIANT":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "NTEXT":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "BIT":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "DECIMAL":
                        sbScript.Append("[" + Type + "]" + " (" + Precision + "," + Scale + ") ");
                        break;
                    case "NUMERIC":
                        sbScript.Append("[" + Type + "]" + " (" + Precision + "," + Scale + ") ");
                        break;
                    case "SMALLMONEY":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "BIGINT":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "HIERARCHYID":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "GEOMETRY":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "GEOGRAPHY":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    case "VARBINARY":
                        if (Precision == -1)
                        {
                            sbScript.Append("[" + Type + "]" + "(max) ");
                        }
                        else
                        {
                            sbScript.Append("[" + Type + "]" + "(" + Precision + ") ");
                        }
                        break;
                    case "VARCHAR":
                        if (Precision == -1)
                        {
                            sbScript.Append("[" + Type + "]" + "(max) ");
                        }
                        else
                        {
                            sbScript.Append("[" + Type + "]" + "(" + Precision + ") ");
                        }
                        break;
                    case "BINARY":
                        if (Precision == -1)
                        {
                            sbScript.Append("[" + Type + "]" + "(max) ");
                        }
                        else
                        {
                            sbScript.Append("[" + Type + "]" + "(" + Precision + ") ");
                        }
                        break;
                    case "CHAR":
                        if (Precision == -1)
                        {
                            sbScript.Append("[" + Type + "]" + "(max) ");
                        }
                        else
                        {
                            sbScript.Append("[" + Type + "]" + "(" + Precision + ") ");
                        }
                        break;
                    case "TIMESTAMP":
                        sbScript.Append("[" + Type + "]" + " ");
                        break;
                    case "NVARCHAR":
                        if (Precision == -1)
                        {
                            sbScript.Append("[" + Type + "]" + "(max) ");
                        }
                        else
                        {
                            sbScript.Append("[" + Type + "]" + "(" + Precision + ") ");
                        }
                        break;
                    case "NCHAR":
                        if (Precision == -1)
                        {
                            sbScript.Append("[" + Type + "]" + "(max) ");
                        }
                        else
                        {
                            sbScript.Append("[" + Type + "]" + "(" + Precision + ") ");
                        }
                        break;
                    case "XML":
                        sbScript.Append("[" + Type + "] ");
                        if (IsColumnSet)
                        {
                            sbScript.Append(" COLUMN_SET FOR ALL_SPARSE_COLUMNS ");
                        }
                        break;
                    case "SYSNAME":
                        sbScript.Append("[" + Type + "] ");
                        break;
                    default:
                        sbScript.Append("[" + Type + "] ");
                        break;
                }

                if (so.Collation)
                {
                    if (Collation != "")
                    {
                        if (!IsUserDefinedDataType)
                        {
                            sbScript.Append("COLLATE " + Collation + " ");
                        }
                    }
                }
                if (!so.NoIdentities)
                {
                    if (IsIdentity)
                    {
                        sbScript.Append("IDENTITY(" + IdentitySeed + "," + IdentityIncrement + ") ");
                    }
                }
                if (IsSparse)
                {
                    sbScript.Append("SPARSE ");
                }
                if (!so.NoFileStream)
                {
                    if (IsFileStream)
                    {
                        sbScript.Append("FILESTREAM ");
                    }
                }
                if (IsNullable)
                {
                    sbScript.Append("NULL ");
                }
                else
                {
                    sbScript.Append("NOT NULL ");
                }

                
                if (!IsReplicated)
                {
                    //sbScript.Append("NOT FOR REPLICATION ");
                }
                if (IsRowGuidCol)
                {
                    sbScript.Append("ROWGUIDCOL ");
                }
                if (IsUnique)
                {
                    sbScript.Append("UNIQUE ");
                }
            }
            return sbScript.ToString().Trim();
        }
    }
}
