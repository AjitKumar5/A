using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ObjectHelper
{
    public class ScriptGenerator
    {

        public ScriptGenerator()
        {
            ResultSets = new Hashtable();
        }

        public string GenerateScript(ScriptingOptions so)
        {
            StringBuilder sql = new StringBuilder();

            int resultSetCount = 0;

            if (so.PartitionFunctions)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.PartitionFunctions.sql"));
                sql.AppendLine();
                ResultSets.Add("PartitionFunctionCollection", resultSetCount++);
                ResultSets.Add("PartitionFunctionRangeValuesCollection", resultSetCount++);
            }
            if (so.Tables)
            {
                sql.Append("SELECT COUNT(*) FROM sys.tables;");
                sql.AppendLine();
                ResultSets.Add("TableCount", resultSetCount++);
                sql.Append(GetResourceScript("ObjectHelper.SQL.Tables_" + so.ServerMajorVersion.ToString() + ".sql"));
                sql.AppendLine();
                ResultSets.Add("TableCollection", resultSetCount++);

                if (so.DataCompression)
                {
                    if (so.ServerMajorVersion >= 10)
                    {
                        sql.Append(GetResourceScript("ObjectHelper.SQL.TableDataCompression_" + so.ServerMajorVersion.ToString() + ".sql"));
                        sql.AppendLine();
                        ResultSets.Add("TableDataCompressionCollection", resultSetCount++);
                    }
                    else
                    {
                        so.DataCompression = false;
                    }
                }
                if (so.DefaultConstraints)
                {
                    sql.Append(GetResourceScript("ObjectHelper.SQL.DefaultConstraints.sql"));
                    sql.AppendLine();
                    ResultSets.Add("DefaultConstraintCollection", resultSetCount++);
                }
                if (so.CheckConstraints)
                {
                    sql.Append(GetResourceScript("ObjectHelper.SQL.CheckConstraints.sql"));
                    sql.AppendLine();
                    ResultSets.Add("CheckConstraintCollection", resultSetCount++);
                }
                if (so.ForeignKeys)
                {
                    sql.Append(GetResourceScript("ObjectHelper.SQL.ForeignKeys.sql"));
                    sql.AppendLine();
                    ResultSets.Add("ForeignKeyCollection", resultSetCount++);
                    ResultSets.Add("ForeignKeyColumnCollection", resultSetCount++);
                }
                if (so.FullTextIndexes)
                {
                    sql.Append(GetResourceScript("ObjectHelper.SQL.FullTextIndexes_"+so.ServerMajorVersion+".sql"));
                    sql.AppendLine();
                    ResultSets.Add("FullTextIndexCollection", resultSetCount++);
                    ResultSets.Add("FullTextIndexColumnCollection", resultSetCount++);
                }
                sql.Append(GetResourceScript("ObjectHelper.SQL.Columns_" + so.ServerMajorVersion.ToString() + ".sql"));
                sql.AppendLine();
                ResultSets.Add("ColumnCollection", resultSetCount++);
            }
            if (so.Contracts)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Contracts.sql"));
                sql.AppendLine();
                ResultSets.Add("ContractCollection", resultSetCount++);
                ResultSets.Add("ContractMessageTypeCollection", resultSetCount++);
            }
            if (so.MessageTypes)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.MessageTypes.sql"));
                sql.AppendLine();
                ResultSets.Add("MessageTypeCollection", resultSetCount++);
            }
            if (so.XMLSchemaCollections)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.XMLSchemaCollections.sql"));
                sql.AppendLine();
                ResultSets.Add("XMLSchemaCollection", resultSetCount++);
            }
            if (so.UniqueConstraints || so.PrimaryKeys || so.ClusteredIndexes || so.NonClusteredIndexes)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Indexes_"+so.ServerMajorVersion+".sql"));
                sql.AppendLine();
                ResultSets.Add("IndexCollection", resultSetCount++);
                sql.Append(GetResourceScript("ObjectHelper.SQL.IndexColumns.sql"));
                sql.AppendLine();
                ResultSets.Add("IndexColumnCollection", resultSetCount++);
            }
            if (so.DMLTriggers || so.DDLTriggers)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Triggers_"+so.ServerMajorVersion+".sql"));
                sql.AppendLine();
                ResultSets.Add("TriggerCollection", resultSetCount++);
            }
            if (so.CLRTriggers)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.CLRTriggers_"+so.ServerMajorVersion+".sql"));
                sql.AppendLine();
                ResultSets.Add("CLRTriggerCollection", resultSetCount++);
                ResultSets.Add("CLRTriggerEventCollection", resultSetCount++);
            }
            if (so.StoredProcedures)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.StoredProcedures.sql"));
                sql.AppendLine();
                ResultSets.Add("SPCollection", resultSetCount++);

            }
            if (so.Aggregates || so.StoredProcedures || so.SQLUserDefinedFunctions || so.CLRUserDefinedFunctions)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Parameters_"+so.ServerMajorVersion+".sql"));
                sql.AppendLine();
                ResultSets.Add("ParameterCollection", resultSetCount++);
            }
            if (so.Aggregates)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Aggregates.sql"));
                sql.AppendLine();
                ResultSets.Add("AggregateCollection", resultSetCount++);
            }
            if (so.Views)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Views.sql"));
                sql.AppendLine();
                ResultSets.Add("ViewCollection", resultSetCount++);
            }
            
            if (so.ApplicationRoles || so.DatabaseRoles || so.Users) //DOROBIT DALSIE
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Principals.sql"));
                sql.AppendLine();
                ResultSets.Add("PrincipalCollection", resultSetCount++);
            }

            if (so.Assemblies) 
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Assemblies_"+ so.ServerMajorVersion.ToString() +".sql"));
                sql.AppendLine();
                ResultSets.Add("AssemblyCollection", resultSetCount++);
            }

            if (so.Defaults)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Defaults.sql"));
                sql.AppendLine();
                ResultSets.Add("DefaultCollection", resultSetCount++);
            }

            if (so.Synonyms)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Synonyms.sql"));
                sql.AppendLine();
                ResultSets.Add("SynonymCollection", resultSetCount++);
            }

            if (so.ServiceQueues)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.ServiceQueues.sql"));
                sql.AppendLine();
                ResultSets.Add("QueueCollection", resultSetCount++);
            }
            if (so.FullTextCatalogs)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.FullTextCatalogs.sql"));
                sql.AppendLine();
                ResultSets.Add("FullTextCatalogCollection", resultSetCount++);
            }

            if (so.FullTextStopLists)
            {
                if (so.ServerMajorVersion >= 10)
                {
                    sql.Append(GetResourceScript("ObjectHelper.SQL.FullTextStopLists.sql"));
                    sql.AppendLine();
                    ResultSets.Add("FullTextStopListCollection", resultSetCount++);
                    ResultSets.Add("FullTextStopWordCollection", resultSetCount++);
                }
                else
                {
                    so.FullTextStopLists = false;
                }

            }
            if (so.Services)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Services.sql"));
                sql.AppendLine();
                ResultSets.Add("ServiceCollection", resultSetCount++);
                ResultSets.Add("ServiceContractCollection", resultSetCount++);
            }
            if (so.BrokerPriorities)
            {
                if (so.ServerMajorVersion >= 10)
                {
                    sql.Append(GetResourceScript("ObjectHelper.SQL.BrokerPriorities.sql"));
                    sql.AppendLine();
                    ResultSets.Add("BrokerPriorityCollection", resultSetCount++);
                }
                else
                {
                    so.BrokerPriorities = false;
                }
            }
            if (so.PartitionSchemes)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.PartitionSchemes.sql"));
                sql.AppendLine();
                ResultSets.Add("PartitionSchemeCollection", resultSetCount++);
                ResultSets.Add("PartitionSchemeFileGroupCollection", resultSetCount++);
            }
            if (so.RemoteServiceBindings)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.RemoteServiceBindings.sql"));
                sql.AppendLine();
                ResultSets.Add("RemoteServiceBindingCollection", resultSetCount++);
            }
            if (so.Rules)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Rules.sql"));
                sql.AppendLine();
                ResultSets.Add("RuleCollection", resultSetCount++);
            }
            if (so.Routes)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Routes.sql"));
                sql.AppendLine();
                ResultSets.Add("RouteCollection", resultSetCount++);
            }
            if (so.Schemas)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.Schemas.sql"));
                sql.AppendLine();
                ResultSets.Add("SchemaCollection", resultSetCount++);
            }
            if (so.SQLUserDefinedFunctions)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.SQLUserDefinedFunctions.sql"));
                sql.AppendLine();
                ResultSets.Add("UserDefinedFunctionCollection", resultSetCount++);
            }
            if (so.CLRUserDefinedFunctions)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.CLRUserDefinedFunctions_"+so.ServerMajorVersion+".sql"));
                sql.AppendLine();
                ResultSets.Add("CLRUserDefinedFunctionCollection", resultSetCount++);
                ResultSets.Add("CLRUserDefinedFunctionColumnCollection", resultSetCount++);
            }
            if (so.UserDefinedDataTypes)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.UserDefinedDataTypes_"+so.ServerMajorVersion+".sql"));
                sql.AppendLine();
                ResultSets.Add("UserDefinedDataTypeCollection", resultSetCount++);
            }
            if (so.UserDefinedTypes)
            {
                sql.Append(GetResourceScript("ObjectHelper.SQL.UserDefinedTypes.sql"));
                sql.AppendLine();
                ResultSets.Add("UserDefinedTypeCollection", resultSetCount++);
            }
            if (so.UserDefinedTableTypes)
            {
                if (so.ServerMajorVersion >= 10)
                {
                    sql.Append(GetResourceScript("ObjectHelper.SQL.UserDefinedTableTypes.sql"));
                    sql.AppendLine();
                    ResultSets.Add("UserDefinedTableTypeCollection", resultSetCount++);
                    ResultSets.Add("UserDefinedTableTypeColumnCollection", resultSetCount++);
                    ResultSets.Add("UserDefinedTableTypeIndexCollection", resultSetCount++);
                    ResultSets.Add("UserDefinedTableTypeIndexColumnCollection", resultSetCount++);
                    ResultSets.Add("UserDefinedTableTypeCheckConstraintCollection", resultSetCount++);
                }
                else
                {
                    so.UserDefinedTableTypes = false;
                }
            }

            return sql.ToString();
        }

        public Hashtable ResultSets
        {
            get;
            set;
        }

        private String GetResourceScript(string resourceName)
        {
            System.Reflection.Assembly _assembly;

            StreamReader _textStreamReader;
            _assembly = System.Reflection.Assembly.GetExecutingAssembly();

            string[] resourceNames = _assembly.GetManifestResourceNames();
            _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream(resourceName));
            string sql = _textStreamReader.ReadToEnd();
            return (sql);
        }
    }
}