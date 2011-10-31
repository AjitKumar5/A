using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class PartitionFunction:BaseDBObject
    {
        public PartitionFunction()
        {
            RangeValues = new SortedList<int, string>();
        }

        public bool BoundaryValueOnRight{get;set;}
        public string Type { get; set; }
        public int MaxLength { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }
        public SortedList<int, string> RangeValues { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE PARTITION FUNCTION [" + Name + "] (");

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
                        sbScript.Append("[" + Type + "]" + "(" + MaxLength + ") ");
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
                    /*
                    if (parameter.IsColumnSet)
                    {
                        sbScript.Append(" COLUMN_SET FOR ALL_SPARSE_COLUMNS ");
                    }*/
                    break;
                case "SYSNAME":
                    sbScript.Append("[" + Type + "] ");
                    break;
                default:
                    sbScript.Append("[" + Type + "] ");
                    break;
            }
            
            sbScript.Append(")"+ System.Environment.NewLine);
            sbScript.Append("AS RANGE ");
            if (BoundaryValueOnRight)
            {
                sbScript.Append("RIGHT ");
            }
            else
            {
                sbScript.Append("LEFT ");
            }
            sbScript.Append("FOR VALUES (");
            for (int i = 1; i <= RangeValues.Count; i++)
            {
                switch (Type.ToUpper())
                {
                    case "INT":
                        sbScript.Append(RangeValues[i].ToString());
                        break;
                    case "DECIMAL":
                        sbScript.Append(RangeValues[i].ToString());
                        break;
                    case "BIGINT":
                        sbScript.Append(RangeValues[i].ToString());
                        break;
                    case "SMALLMONEY":
                        sbScript.Append(RangeValues[i].ToString());
                        break;
                    case "NUMERIC":
                        sbScript.Append(RangeValues[i].ToString());
                        break;
                    case "BIT":
                        sbScript.Append(RangeValues[i].ToString());
                        break;
                    case "FLOAT":
                        sbScript.Append(RangeValues[i].ToString());
                        break;
                    case "MONEY":
                        sbScript.Append(RangeValues[i].ToString());
                        break;
                    case "REAL":
                        sbScript.Append(RangeValues[i].ToString());
                        break;
                    case "SMALLINT":
                        sbScript.Append(RangeValues[i].ToString());
                        break;
                    case "TYNIINT":
                        sbScript.Append(RangeValues[i].ToString());
                        break;
                    default:
                        sbScript.Append("'" + RangeValues[i].ToString().Trim() + "'");
                        break;
                }
                if (i != this.RangeValues.Count)
                {
                    sbScript.Append(",");
                }
            }
                sbScript.Append(")");
            return sbScript.ToString();
        }
    }
}
