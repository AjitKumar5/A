using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class CLRUserDefinedFunction:BaseDBObject
    {
        public string Schema { get; set; }
        public string AssemblyName { get; set; }
        public string AssemblyClass { get; set; }
        public string AssemblyMethod { get; set; }
        public string TableVariableName { get; set; }
        public string ExecuteAsPrincipal { get; set; }
        public int ExecuteAsPrincipalId { get; set; }
        public bool IsTableValued { get; set; }

        public List<Column> Columns { get; set; }
        public List<Parameter> Parameters { get; set; }
        public Parameter Output { get; set; }

        public CLRUserDefinedFunction()
        {
            Parameters = new List<Parameter>();
            Columns = new List<Column>();
        }

        public string Script(ScriptingOptions so)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE FUNCTION [" + Schema + "].[" + Name + "]" + System.Environment.NewLine);
            sbScript.Append("("+ System.Environment.NewLine);
            for (int i = 0; i < Parameters.Count; i++)
            {
                sbScript.Append("\t" + ScriptParameter(Parameters[i],false));
                if (i != Parameters.Count - 1)
                {
                    sbScript.Append(",");
                }
                sbScript.AppendLine();
            }
            sbScript.Append(")");
            sbScript.AppendLine();
            sbScript.Append("RETURNS ");
            if (IsTableValued)
            {
                sbScript.Append("TABLE" + System.Environment.NewLine);
                sbScript.Append("(" + System.Environment.NewLine);
                for (int j = 0; j < Columns.Count; j++)
                {
                    sbScript.Append("\t" + Columns[j].Name + " ");

                    switch (Columns[j].Type.ToUpper())
                    {
                        case "IMAGE":
                            sbScript.Append("[" + Columns[j].Type + "] ");
                            break;
                        case "TEXT":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "UNIQUEIDENTIFIER":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "DATE":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "TIME":
                            if (Columns[j].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(max)");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(" + Columns[j].Precision + ")");
                            }
                            break;
                        case "DATETIME2":
                            if (Columns[j].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(max)");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(" + Columns[j].Precision + ")");
                            }
                            break;
                        case "DATETIMEOFFSET":
                            if (Columns[j].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(max)");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(" + Columns[j].Precision + ")");
                            }
                            break;
                        case "TINYINT":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "SMALLINT":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "REAL":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "MONEY":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "DATETIME":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "SMALLDATETIME":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "INT":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "FLOAT":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "SQL_VARIANT":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "NTEXT":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "BIT":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "DECIMAL":
                            sbScript.Append("[" + Columns[j].Type + "]" + "(" + Columns[j].Precision + "," + Columns[j].Scale + ")");
                            break;
                        case "NUMERIC":
                            sbScript.Append("[" + Columns[j].Type + "]" + "(" + Columns[j].Precision + "," + Columns[j].Scale + ")");
                            break;
                        case "SMALLMONEY":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "BIGINT":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "HIERARCHYID":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "GEOMETRY":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "GEOGRAPHY":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "VARBINARY":
                            if (Columns[j].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(max)");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(" + Columns[j].Precision + ")");
                            }
                            break;
                        case "VARCHAR":
                            if (Columns[j].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(max)");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(" + Columns[j].Precision + ")");
                            }
                            break;
                        case "BINARY":
                            if (Columns[j].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(max)");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(" + Columns[j].Precision + ")");
                            }
                            break;
                        case "CHAR":
                            if (Columns[j].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(max)");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(" + Columns[j].Precision + ")");
                            }
                            break;
                        case "TIMESTAMP":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        case "NVARCHAR":
                            if (Columns[j].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(max)");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(" + Columns[j].Precision + ")");
                            }
                            break;
                        case "NCHAR":
                            if (Columns[j].Precision == -1)
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(max)");
                            }
                            else
                            {
                                sbScript.Append("[" + Columns[j].Type + "]" + "(" + Columns[j].Precision + ")");
                            }
                            break;
                        case "XML":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            //if (parameter.IsColumnSet)
                            //{
                            //    sbScript.Append(" COLUMN_SET FOR ALL_SPARSE_COLUMNS ");
                            //}
                            break;
                        case "SYSNAME":
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                        default:
                            sbScript.Append("[" + Columns[j].Type + "]");
                            break;
                    }
                    sbScript.Append(" NULL");
                    if (j != Columns.Count - 1)
                    {
                        sbScript.Append(",");
                    }
                    sbScript.AppendLine();
                }
                sbScript.Append(") ");
                
            }
            else
            {
                sbScript.Append(ScriptParameter(Output, true));
                sbScript.AppendLine();
            }
            
            sbScript.Append("WITH EXECUTE AS ");
            if (ExecuteAsPrincipalId == 0)
            {
                sbScript.Append("CALLER");
            }
            else if (ExecuteAsPrincipalId < 0)
            {
                sbScript.Append("OWNER");
            }
            else if (ExecuteAsPrincipalId == 1)
            {
                sbScript.Append("SELF");
            }
            else
            {
                sbScript.Append(ExecuteAsPrincipal);
            }
            sbScript.AppendLine();
            sbScript.Append("EXTERNAL NAME [" + AssemblyName + "].[" + AssemblyClass + "].[" + AssemblyMethod + "]");
            return sbScript.ToString();
        }

        public string ScriptColumn(Column column)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append(column.Name + " ");
            return sbScript.ToString();
        }



        public string ScriptParameter(Parameter parameter, bool isOutput)
        {
            StringBuilder sbScript = new StringBuilder();
            if (!isOutput)
            {
                sbScript.Append(parameter.Name + " ");
            }
            switch (parameter.Type.ToUpper())
            {
                case "IMAGE":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "TEXT":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "UNIQUEIDENTIFIER":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "DATE":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "TIME":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        
                        if(!isOutput)
                            sbScript.Append( "(max)");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]" );

                        if (!isOutput)
                            sbScript.Append("("+parameter.Precision+")");
                    }
                    break;
                case "DATETIME2":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("(max)");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("("+parameter.Precision+")");
                    }
                    break;
                case "DATETIMEOFFSET":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("(max)");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("("+parameter.Precision+")");
                    }
                    break;
                case "TINYINT":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "SMALLINT":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "REAL":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "MONEY":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "DATETIME":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "SMALLDATETIME":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "INT":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "FLOAT":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "SQL_VARIANT":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "NTEXT":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "BIT":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "DECIMAL":
                    sbScript.Append("[" + parameter.Type + "]") ;
                    if(!isOutput)
                    sbScript.Append("(" + parameter.Precision + "," + parameter.Scale + ")");

                    break;
                case "NUMERIC":
                    sbScript.Append("[" + parameter.Type + "]");
                    if(!isOutput)
                    sbScript.Append( "(" + parameter.Precision + "," + parameter.Scale + ")");
                    break;
                case "SMALLMONEY":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "BIGINT":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "HIERARCHYID":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "GEOMETRY":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "GEOGRAPHY":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "VARBINARY":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if(!isOutput)
                            sbScript.Append( "(max)");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if(!isOutput)
                            sbScript.Append("(" + parameter.Precision + ")");
                    }
                    break;
                case "VARCHAR":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("(max)");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("("+parameter.Precision+")");
                    }
                    break;
                case "BINARY":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("(max)");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("("+parameter.Precision+")");
                    }
                    break;
                case "CHAR":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("(max)");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("("+parameter.Precision+") ");
                    }
                    break;
                case "TIMESTAMP":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                case "NVARCHAR":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("(max)");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("("+parameter.Precision+")");
                    }
                    break;
                case "NCHAR":
                    if (parameter.Precision == -1)
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("(max)");
                    }
                    else
                    {
                        sbScript.Append("[" + parameter.Type + "]");
                        if (!isOutput)
                            sbScript.Append("("+parameter.Precision+")");
                    }
                    break;
                case "XML":
                    sbScript.Append("[" + parameter.Type + "]");
                    //if (parameter.IsColumnSet)
                    //{
                    //    sbScript.Append(" COLUMN_SET FOR ALL_SPARSE_COLUMNS ");
                    //}
                    break;
                case "SYSNAME":
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
                default:
                    sbScript.Append("[" + parameter.Type + "]");
                    break;
            }

            return sbScript.ToString();
        }
    }
}
