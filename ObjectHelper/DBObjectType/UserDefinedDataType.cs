using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class UserDefinedDataType:BaseDBObject
    {
        public string Schema { get; set; }
        public string SystemType { get; set; }
        public int Length { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }
        public int MaxLength { get; set; }
        public bool IsNullable { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE TYPE ["+Schema+"].["+Name+"] FROM ");

            switch (SystemType.ToUpper())
            {
                case "IMAGE":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "TEXT":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "UNIQUEIDENTIFIER":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "DATE":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "TIME":
                    if (Precision == -1)
                    {
                        sbScript.Append("[" + SystemType + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + SystemType + "]" + "(" + Scale + ") ");
                    }
                    break;
                case "DATETIME2":
                    if (Precision == -1)
                    {
                        sbScript.Append("[" + SystemType + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + SystemType + "]" + "(" + Scale + ") ");
                    }
                    break;
                case "DATETIMEOFFSET":
                    if (Precision == -1)
                    {
                        sbScript.Append("[" + SystemType + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + SystemType + "]" + "(" + Scale + ") ");
                    }
                    break;
                case "TINYINT":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "SMALLINT":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "REAL":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "MONEY":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "DATETIME":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "SMALLDATETIME":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "INT":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "FLOAT":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "SQL_VARIANT":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "NTEXT":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "BIT":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "DECIMAL":
                    sbScript.Append("[" + SystemType + "]" + " (" + Precision + "," + Scale + ") ");
                    break;
                case "NUMERIC":
                    sbScript.Append("[" + SystemType + "]" + " (" + Precision + "," + Scale + ") ");
                    break;
                case "SMALLMONEY":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "BIGINT":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "HIERARCHYID":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "GEOMETRY":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "GEOGRAPHY":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                case "VARBINARY":
                    if (Precision == -1)
                    {
                        sbScript.Append("[" + SystemType + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + SystemType + "]" + "(" + Length + ") ");
                    }
                    break;
                case "VARCHAR":
                    if (Precision == -1)
                    {
                        sbScript.Append("[" + SystemType + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + SystemType + "]" + "(" + Length + ") ");
                    }
                    break;
                case "BINARY":
                    if (Precision == -1)
                    {
                        sbScript.Append("[" + SystemType + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + SystemType + "]" + "(" + Length + ") ");
                    }
                    break;
                case "CHAR":
                    if (Precision == -1)
                    {
                        sbScript.Append("[" + SystemType + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + SystemType + "]" + "(" + Length + ") ");
                    }
                    break;
                case "TIMESTAMP":
                    sbScript.Append("[" + SystemType + "]" + " ");
                    break;
                case "NVARCHAR":
                    if (Precision == -1)
                    {
                        sbScript.Append("[" + SystemType + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + SystemType + "]" + "(" + Length + ") ");
                    }
                    break;
                case "NCHAR":
                    if (Precision == -1)
                    {
                        sbScript.Append("[" + SystemType + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + SystemType + "]" + "(" + Length + ") ");
                    }
                    break;
                case "SYSNAME":
                    sbScript.Append("[" + SystemType + "] ");
                    break;
                default:
                    sbScript.Append("[" + SystemType + "] ");
                    break;
            }


            if (IsNullable)
            {
                sbScript.Append(" NULL;");
            }
            else
            {
                sbScript.Append(" NOT NULL;");
            }
            return sbScript.ToString();
        }
    }
}
