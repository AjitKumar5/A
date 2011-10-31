using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Aggregate :BaseDBObject
    {

        public Aggregate()
        {
            InputParameters = new List<Parameter>();
        }

        public string AssemblyName { get; set; }
        public string AssemblyClass { get; set; }
        public string Schema { get; set; }
        public Parameter OutputParameter { get; set; }
        public List<Parameter> InputParameters { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE AGGREGATE [" + Schema+"].["+Name+"]" + System.Environment.NewLine);
            sbScript.Append("(");

            for (int i = 0; i < this.InputParameters.Count; i++)
            {
                sbScript.Append(ScriptParameter(InputParameters[i]));
                if (i != InputParameters.Count - 1)
                {
                    sbScript.Append(",");
                }
                //sbScript.Append(System.Environment.NewLine);
            }

            sbScript.Append(")"+System.Environment.NewLine);
            sbScript.Append("RETURNS " + ScriptParameter(OutputParameter) + System.Environment.NewLine);
            sbScript.Append("EXTERNAL NAME [" + AssemblyName + "].[" + AssemblyClass + "]" + System.Environment.NewLine);
            return sbScript.ToString().Trim();
        }


        private string ScriptParameter(Parameter parameter)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append(parameter.Name + " ");
            switch (parameter.Type.ToUpper())
            {
                case "IMAGE":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "TEXT":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "UNIQUEIDENTIFIER":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "DATE":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "TIME":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(" + parameter.Scale + ") ");
                    }
                    break;
                case "DATETIME2":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(" + parameter.Scale + ") ");
                    }
                    break;
                case "DATETIMEOFFSET":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(" + parameter.Scale + ") ");
                    }
                    break;
                case "TINYINT":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "SMALLINT":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "REAL":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "MONEY":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "DATETIME":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "SMALLDATETIME":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "INT":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "FLOAT":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "SQL_VARIANT":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "NTEXT":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "BIT":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "DECIMAL":
                    sbScript.Append("[" + parameter.Type + "]" + " (" + parameter.Precision + "," + parameter.Scale + ") ");
                    break;
                case "NUMERIC":
                    sbScript.Append("[" + parameter.Type + "]" + " (" + parameter.Precision + "," + parameter.Scale + ") ");
                    break;
                case "SMALLMONEY":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "BIGINT":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "HIERARCHYID":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "GEOMETRY":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "GEOGRAPHY":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                case "VARBINARY":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(" + parameter.Precision + ") ");
                    }
                    break;
                case "VARCHAR":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(" + parameter.Precision + ") ");
                    }
                    break;
                case "BINARY":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(" + parameter.Precision + ") ");
                    }
                    break;
                case "CHAR":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(" + parameter.Precision + ") ");
                    }
                    break;
                case "TIMESTAMP":
                    sbScript.Append("[" + parameter.Type + "]" + " ");
                    break;
                case "NVARCHAR":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(" + parameter.Precision + ") ");
                    }
                    break;
                case "NCHAR":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(max) ");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]" + "(" + parameter.Precision + ") ");
                    }
                    break;
                case "XML":
                    sbScript.Append("[" + parameter.Type + "] ");
                    /*
                    if (parameter.IsColumnSet)
                    {
                        sbScript.Append(" COLUMN_SET FOR ALL_SPARSE_COLUMNS ");
                    }*/
                    break;
                case "SYSNAME":
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
                default:
                    sbScript.Append("[" + parameter.Type + "] ");
                    break;
            }
            return sbScript.ToString().Trim();
        }
    }
}
