using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Runtime.Serialization.Formatters.Binary;
using ObjectHelper.DBObjectType;

namespace ObjectHelper
{
    public delegate void ObjectFetchedEventHandler(object sender, FetchEventArgs e);

    public partial class ObjectDB
    {
        string _connString;
        private SqlDatabase sqlDatabase;
        Hashtable hsResultSets = new Hashtable();

        public ObjectDB(string connString)
        {
            _connString = connString;
            _tables = new List<Table>();
        }

        public event ObjectFetchedEventHandler ObjectFetched;

        protected virtual void OnObjectFetched(FetchEventArgs e)
        {
            if (ObjectFetched != null)
            {
                ObjectFetched(this,e);
            }
        }

        private List<Table> _tables = new List<Table>();
        private List<Index> _indexes = new List<Index>();
        private List<Trigger> _ddlTriggers = new List<Trigger>();
        private List<Trigger> _dmlTriggers = new List<Trigger>();
        private List<CLRTrigger> _clrTriggers = new List<CLRTrigger>();
        private List<StoredProcedure> _storedProcedures = new List<StoredProcedure>();
        private List<View> _views = new List<View>();
        private List<Principal> _appRoles = new List<Principal>();
        private List<Principal> _databaseRoles = new List<Principal>();
        private List<Principal> _users = new List<Principal>();
        private List<DBObjectType.Assembly> _assemblies = new List<DBObjectType.Assembly>();
        private List<Aggregate> _aggregates = new List<Aggregate>();
        private List<Default> _defaults = new List<Default>();
        private List<Synonym> _synonyms = new List<Synonym>();
        private List<XMLSchemaCollection> _xmlSchemaCollections = new List<XMLSchemaCollection>();
        private List<MessageType> _messageTypes = new List<MessageType>();
        private List<Contract> _contracts = new List<Contract>();
        private List<PartitionFunction> _partitionFunctions = new List<PartitionFunction>();
        private List<ServiceQueue> _serviceQueues = new List<ServiceQueue>();
        private List<FullTextCatalog> _fullTextCatalogs = new List<FullTextCatalog>();
        private List<FullTextStopList> _fullTextStopLists = new List<FullTextStopList>();
        private List<Service> _services = new List<Service>();
        private List<BrokerPriority> _brokerPriorities = new List<BrokerPriority>();
        private List<PartitionScheme> _partitionSchemes = new List<PartitionScheme>();
        private List<RemoteServiceBinding> _remoteServiceBindings = new List<RemoteServiceBinding>();
        private List<DBObjectType.Rule> _rules = new List<DBObjectType.Rule>();
        private List<Route> _routes = new List<Route>();
        private List<Schema> _schemas = new List<Schema>();
        private List<SQLUserDefinedFunction> _sqlUserDefinedFunctions = new List<SQLUserDefinedFunction>();
        private List<CLRUserDefinedFunction> _clrUserDefinedFunctions = new List<CLRUserDefinedFunction>();
        private List<UserDefinedDataType> _userDefinedDataTypes = new List<UserDefinedDataType>();
        private List<UserDefinedType> _userDefinedTypes = new List<UserDefinedType>();
        private List<UserDefinedTableType> _userDefinedTableTypes = new List<UserDefinedTableType>();

        public List<DBObjectType.Assembly> Assemblies
        {
            get
            {
                return _assemblies;
            }
        }
        public List<Aggregate> Aggregates 
        {
            get
            {
                return _aggregates;
            }
        }
        public List<Principal> Users
        {
            get
            {
                return _users;
            }
        }
        public List<Principal> ApplicationRoles
        {
            get
            {
                return _appRoles;
            }
        }
        public List<Principal> DatabaseRoles
        {
            get
            {
                return _databaseRoles;
            }
        }
        public List<Table> Tables
        {
            get
            {
                return _tables;
            }
        }
        public List<Index> Indexes
        {
            get
            {
                return _indexes;
            }
        }
        public List<Trigger> DDLTriggers
        {
            get
            {
                return _ddlTriggers;
            }
        }
        public List<Trigger> DMLTriggers
        {
            get
            {
                return _dmlTriggers;
            }
        }
        public List<CLRTrigger> CLRTriggers
        {
            get
            {
                return _clrTriggers;
            }
        }
        public List<StoredProcedure> StoredProcedures 
        {
            get 
            {
                return _storedProcedures;
            }
        }
        public List<View> Views
        {
            get
            {
                return _views;
            }
        }
        public List<Synonym> Synonyms
        {
            get
            {
                return _synonyms;
            }
        }
        public List<Default> Defaults
        {
            get
            {
                return _defaults;
            }
        }
        public List<XMLSchemaCollection> XMLSchemaCollections {
            get
            {
                return _xmlSchemaCollections;
            }
        }
        public List<MessageType> MessageTypes
        {
            get
            {
                return _messageTypes;
            }
        }
        public List<Contract> Contracts
        {
            get
            {
                return _contracts;
            }
        }
        public List<PartitionFunction> PartitionFunctions
        {
            get {
                return _partitionFunctions;
            }
        }
        public List<ServiceQueue> ServiceQueues
        {
            get {
                return _serviceQueues;
            }
        }
        public List<FullTextCatalog> FullTextCatalogs
        {
            get { 
                return _fullTextCatalogs; 
            }
        }
        public List<FullTextStopList> FullTextStopLists
        {
            get
            {
                return _fullTextStopLists;
            }
        }
        public List<Service> Services {
            get
            {
                return _services;
            }
        }
        public List<BrokerPriority> BrokerPriorities {
            get {
                return _brokerPriorities;
            }
        }
        public List<PartitionScheme> PartitionSchemes
        {
            get { 
                return _partitionSchemes;
            }
        }
        public List<RemoteServiceBinding> RemoteServiceBindings
        {
            get
            {
                return _remoteServiceBindings;
            }
        }
        public List<DBObjectType.Rule> Rules
        {
            get
            {
                return _rules;
            }
        }
        public List<Route> Routes
        {
            get
            {
                return _routes;
            }
        }
        public List<Schema> Schemas
        {
            get
            {
                return _schemas;
            }
        }
        public List<SQLUserDefinedFunction> SQLUserDefinedFunctions
        {
            get
            {
                return _sqlUserDefinedFunctions;
            }
        }
        public List<CLRUserDefinedFunction> CLRUserDefinedFunctions
        {
            get
            {
                return _clrUserDefinedFunctions;
            }
        }
        public List<UserDefinedDataType> UserDefinedDataTypes
        {
            get
            {
                return _userDefinedDataTypes;
            }
        }
        public List<UserDefinedType> UserDefinedTypes
        {
            get
            {
                return _userDefinedTypes;
            }
        }
        public List<UserDefinedTableType> UserDefinedTableTypes
        {
            get
            {
                return _userDefinedTableTypes;
            }
        }
        public void FetchObjects(ScriptingOptions so)
        {
            ScriptGenerator generator = new ScriptGenerator();
            string sql = generator.GenerateScript(so);
            hsResultSets = generator.ResultSets;

            DataSet ds = null;
            sqlDatabase = new SqlDatabase(_connString);
            SqlCommand sqlCommand = sqlDatabase.GetSqlStringCommand(sql) as SqlCommand;
            ds = sqlDatabase.ExecuteDataSet(sqlCommand);
            if (so.Tables == true)
            {
                DataTable dtTables = ds.Tables[int.Parse(hsResultSets["TableCollection"].ToString())];
                foreach (DataRow drTable in dtTables.Rows)
                {
                    Table table = new Table();
                    table.AnsiNullsStatus = bool.Parse(drTable["AnsiNullsStatus"].ToString());
                    table.ChangeTrackingEnabled = bool.Parse(drTable["ChangeTrackingEnabled"].ToString());
                    table.Description = drTable["Description"].ToString();
                    table.Filegroup = drTable["FileGroup"].ToString();
                    table.FileStreamGroup = drTable["FileStreamGroup"].ToString();
                    table.FileStreamPartitionScheme = drTable["FileStreamPartitionScheme"].ToString();
                    table.Name = drTable["Name"].ToString();
                    table.ObjectId = int.Parse(drTable["Object_Id"].ToString());
                    table.PartitionedColumn = drTable["PartitionedColumn"].ToString();
                    table.PartitionScheme = drTable["PartitionScheme"].ToString();
                    table.QuotedIdentifierStatus = bool.Parse(drTable["QuotedIdentifierStatus"].ToString());
                    table.Schema = drTable["Schema"].ToString();
                    table.TextFileGroup = drTable["TextFileGroup"].ToString();
                    table.TrackColumnsUpdatedEnabled = bool.Parse(drTable["TrackColumnsUpdatedEnabled"].ToString());
                    
                    DataTable dtColumns = ds.Tables[int.Parse(hsResultSets["ColumnCollection"].ToString())];
                    table.Columns = GetColumns(dtColumns, table.ObjectId);

                    _tables.Add(table);
                    if (so.DataCompression)
                    {
                        if (so.ServerMajorVersion >= 10)
                        {
                            DataTable dtTableDataCompression = ds.Tables[int.Parse(hsResultSets["TableDataCompressionCollection"].ToString())];
                            table.Partitions = GetTableDataCompression(dtTableDataCompression, table.ObjectId);
                        }
                    }
                    if (so.DefaultConstraints)
                    {
                        DataTable dtDefaultConstraints = ds.Tables[int.Parse(hsResultSets["DefaultConstraintCollection"].ToString())];
                        table.DefaultConstraints = GetDefaultConstraints(dtDefaultConstraints, table.ObjectId);
                    }
                    if (so.CheckConstraints)
                    {
                        DataTable dtCheckConstraints = ds.Tables[int.Parse(hsResultSets["CheckConstraintCollection"].ToString())];
                        table.CheckConstraints = GetCheckConstraints(dtCheckConstraints, table.ObjectId);
                    }
                    DataTable dtIndexColumns=null;
                    if (so.PrimaryKeys || so.UniqueConstraints || so.ClusteredIndexes || so.NonClusteredIndexes)
                    {
                        dtIndexColumns = ds.Tables[int.Parse(hsResultSets["IndexColumnCollection"].ToString())];
                    }
                    if (so.PrimaryKeys)
                    {
                        DataTable dtPrimaryKey = ds.Tables[int.Parse(hsResultSets["IndexCollection"].ToString())];

                        table.PrimaryKeyConstraint = GetPrimaryKeyConstraint(dtPrimaryKey, dtIndexColumns, table.ObjectId);
                    }
                    if (so.UniqueConstraints)
                    {
                        DataTable dtUniqueConstraints = ds.Tables[int.Parse(hsResultSets["IndexCollection"].ToString())];
                        table.UniqueConstraints = GetUniqueConstraints(dtUniqueConstraints, dtIndexColumns, table.ObjectId);
                    }
                    if (so.ForeignKeys)
                    {
                        DataTable dtForeignKeyConstraints = ds.Tables[int.Parse(hsResultSets["ForeignKeyCollection"].ToString())];
                        DataTable dtForeignKeyColumns = ds.Tables[int.Parse(hsResultSets["ForeignKeyColumnCollection"].ToString())];
                        table.ForeignKeys = GetForeignKeys(dtForeignKeyConstraints,dtForeignKeyColumns, table.ObjectId);
                    }
                    if (so.FullTextIndexes)
                    {
                        DataTable dtFulltextIndexes = ds.Tables[int.Parse(hsResultSets["FullTextIndexCollection"].ToString())];
                        DataTable dtFulltextIndexColumns = ds.Tables[int.Parse(hsResultSets["FullTextIndexColumnCollection"].ToString())];
                        table.FullTextIndexes = GetFullTextIndexes(dtFulltextIndexes, dtFulltextIndexColumns,table.ObjectId);
                    }
                    OnObjectFetched( new FetchEventArgs(table));
                }
            }
            if (so.MessageTypes)
            {
                DataTable dtMessageTypes = ds.Tables[int.Parse(hsResultSets["MessageTypeCollection"].ToString())];
                _messageTypes = GetMessageTypes(dtMessageTypes);
            }
            if (so.Contracts)
            {
                DataTable dtContracts = ds.Tables[int.Parse(hsResultSets["ContractCollection"].ToString())];
                DataTable dtMsgTypes = ds.Tables[int.Parse(hsResultSets["ContractMessageTypeCollection"].ToString())];
                _contracts = GetContracts(dtContracts,dtMsgTypes);
            }
            if (so.XMLSchemaCollections)
            {
                DataTable dtXMLSchemaCollections = ds.Tables[int.Parse(hsResultSets["XMLSchemaCollection"].ToString())];
                _xmlSchemaCollections = GetXMLSchemaCollections(dtXMLSchemaCollections);
            }
            if (so.ClusteredIndexes || so.NonClusteredIndexes)
            {

                DataTable dtIndexColumns = ds.Tables[int.Parse(hsResultSets["IndexColumnCollection"].ToString())];
                DataTable dtIndexes = ds.Tables[int.Parse(hsResultSets["IndexCollection"].ToString())];
                _indexes = new List<Index>();
                if(so.ClusteredIndexes)
                {
                    List<Index> idxs = GetIndexes(dtIndexes, dtIndexColumns, "CLUSTERED");
                    foreach(Index idx in idxs)
                    {
                        _indexes.Add(idx);
                    }
                }
                if (so.NonClusteredIndexes)
                {
                    List<Index> idxs = GetIndexes(dtIndexes, dtIndexColumns, "NONCLUSTERED");
                    foreach (Index idx in idxs)
                    {
                        _indexes.Add(idx);
                    }
                }    
            }
            if (so.DDLTriggers)
            {
                DataTable dtTriggers = ds.Tables[int.Parse(hsResultSets["TriggerCollection"].ToString())];
                _ddlTriggers = GetTriggers(dtTriggers, true);
            }
            if (so.DMLTriggers)
            {
                DataTable dtTriggers = ds.Tables[int.Parse(hsResultSets["TriggerCollection"].ToString())];
                _dmlTriggers = GetTriggers(dtTriggers, false);
            }
            DataTable dtParameters = null;
            if (so.Aggregates || so.StoredProcedures || so.SQLUserDefinedFunctions )
            {
                dtParameters = ds.Tables[int.Parse(hsResultSets["ParameterCollection"].ToString())];
            }
            if (so.StoredProcedures)
            {
                DataTable dtSPs = ds.Tables[int.Parse(hsResultSets["SPCollection"].ToString())];    
                _storedProcedures = GetStoredProcedures(dtSPs, dtParameters);
            }
            
            if (so.Views)
            {
                DataTable dtViews = ds.Tables[int.Parse(hsResultSets["ViewCollection"].ToString())];
                _views = GetViews(dtViews);
            }
            if (so.CLRTriggers)
            {
                DataTable dtCLRTriggers = ds.Tables[int.Parse(hsResultSets["CLRTriggerCollection"].ToString())];
                DataTable dtCLRTriggerEvents = ds.Tables[int.Parse(hsResultSets["CLRTriggerEventCollection"].ToString())];
                _clrTriggers = GetCLRTriggers(dtCLRTriggers,dtCLRTriggerEvents);
            }
            if (so.ApplicationRoles)
            {
                DataTable dtPrincipals = ds.Tables[int.Parse(hsResultSets["PrincipalCollection"].ToString())];
                _appRoles = GetPrincipals(dtPrincipals,"A");
            }
            if (so.DatabaseRoles)
            {
                DataTable dtPrincipals = ds.Tables[int.Parse(hsResultSets["PrincipalCollection"].ToString())];
                _databaseRoles = GetPrincipals(dtPrincipals, "R");
            }
            if (so.Users)
            {
                DataTable dtPrincipals = ds.Tables[int.Parse(hsResultSets["PrincipalCollection"].ToString())];
                _users = GetPrincipals(dtPrincipals, "S");
            }
            if (so.Assemblies)
            {
                DataTable dtAssemblies = ds.Tables[int.Parse(hsResultSets["AssemblyCollection"].ToString())];
                _assemblies = GetAssemblies(dtAssemblies);
            }
            if (so.Aggregates)
            {
                DataTable dtAggregates = ds.Tables[int.Parse(hsResultSets["AggregateCollection"].ToString())];
                _aggregates = GetAggregates(dtAggregates, dtParameters);
            }
            if (so.Defaults)
            {
                DataTable dtDefaults = ds.Tables[int.Parse(hsResultSets["DefaultCollection"].ToString())];
                _defaults = GetDefaults(dtDefaults);
            }
            if (so.Synonyms)
            {
                DataTable dtSynonyms = ds.Tables[int.Parse(hsResultSets["SynonymCollection"].ToString())];
                _synonyms = GetSynonyms(dtSynonyms);
            }
            if (so.PartitionFunctions)
            {
                DataTable dtPartitionFunctions = ds.Tables[int.Parse(hsResultSets["PartitionFunctionCollection"].ToString())];
                DataTable dtPartitionFunctionsRangeValues = ds.Tables[int.Parse(hsResultSets["PartitionFunctionRangeValuesCollection"].ToString())];
                _partitionFunctions = GetPartitionFunctions(dtPartitionFunctions,dtPartitionFunctionsRangeValues);
            }
            if (so.ServiceQueues)
            {
                DataTable dtQueues = ds.Tables[int.Parse(hsResultSets["QueueCollection"].ToString())];
                _serviceQueues = GetServiceQueues(dtQueues);
            }
            if (so.FullTextCatalogs)
            {
                DataTable dtFtCatalogs = ds.Tables[int.Parse(hsResultSets["FullTextCatalogCollection"].ToString())];
                _fullTextCatalogs = GetFulltextCatalogs(dtFtCatalogs);
            }
            if (so.FullTextStopLists)
            {
                if (so.ServerMajorVersion >= 10)
                {
                    DataTable dtStopLists = ds.Tables[int.Parse(hsResultSets["FullTextStopListCollection"].ToString())];
                    DataTable dtStopWords = ds.Tables[int.Parse(hsResultSets["FullTextStopWordCollection"].ToString())];
                    _fullTextStopLists = GetFullTextStopLists(dtStopLists, dtStopWords);
                }
            }
            if (so.Services)
            {
                DataTable dtServices = ds.Tables[int.Parse(hsResultSets["ServiceCollection"].ToString())];
                DataTable dtServiceContracts = ds.Tables[int.Parse(hsResultSets["ServiceContractCollection"].ToString())];
                _services = GetServices(dtServices,dtServiceContracts);
            }
            if (so.BrokerPriorities)
            {
                if (so.ServerMajorVersion > 9)
                {
                    DataTable dtBrokerPriorities = ds.Tables[int.Parse(hsResultSets["BrokerPriorityCollection"].ToString())];
                    _brokerPriorities = GetBrokerPriorities(dtBrokerPriorities);
                }
            }
            if (so.PartitionSchemes)
            {
                DataTable dtPartitionSchemes = ds.Tables[int.Parse(hsResultSets["PartitionSchemeCollection"].ToString())];
                DataTable dtPartitionSchemeFileGroups = ds.Tables[int.Parse(hsResultSets["PartitionSchemeFileGroupCollection"].ToString())];
                _partitionSchemes = GetPartitionSchemes(dtPartitionSchemes, dtPartitionSchemeFileGroups);
            }
            if (so.RemoteServiceBindings)
            {
                DataTable dtBindings = ds.Tables[int.Parse(hsResultSets["RemoteServiceBindingCollection"].ToString())];
                _remoteServiceBindings = GetRemoteServiceBindings(dtBindings);
            }
            if (so.Rules)
            {
                DataTable dtRules = ds.Tables[int.Parse(hsResultSets["RuleCollection"].ToString())];
                _rules = GetRules(dtRules);
            }
            if (so.Routes)
            {
                DataTable dtRoutes = ds.Tables[int.Parse(hsResultSets["RouteCollection"].ToString())];
                _routes = GetRoutes(dtRoutes);
            }
            if (so.Schemas)
            {
                DataTable dtSchemas = ds.Tables[int.Parse(hsResultSets["SchemaCollection"].ToString())];
                _schemas = GetSchemas(dtSchemas);
            }
            if (so.SQLUserDefinedFunctions)
            {
                DataTable dtScalarValuedFunctions = ds.Tables[int.Parse(hsResultSets["UserDefinedFunctionCollection"].ToString())];
                _sqlUserDefinedFunctions = GetSQLUserDefinedFunctions(dtScalarValuedFunctions, dtParameters);
            }
            if(so.CLRUserDefinedFunctions)
            {
                DataTable dtCLRFunctions = ds.Tables[int.Parse(hsResultSets["CLRUserDefinedFunctionCollection"].ToString())];
                DataTable dtCLRFunctionColumns = ds.Tables[int.Parse(hsResultSets["CLRUserDefinedFunctionColumnCollection"].ToString())];
                _clrUserDefinedFunctions = GetCLRUserDefinedFunctions(dtCLRFunctions, dtParameters, dtCLRFunctionColumns);
            }
            if (so.UserDefinedDataTypes)
            {
                DataTable dtUDDTS = ds.Tables[int.Parse(hsResultSets["UserDefinedDataTypeCollection"].ToString())];
                _userDefinedDataTypes = GetUserDefinedDataTypes(dtUDDTS);
            }
            if (so.UserDefinedTypes)
            {
                DataTable dtUDTS = ds.Tables[int.Parse(hsResultSets["UserDefinedTypeCollection"].ToString())];
                _userDefinedTypes = GetUserDefinedTypes(dtUDTS);
            }
            if (so.UserDefinedTableTypes)
            {
                DataTable dtUDTTS = ds.Tables[int.Parse(hsResultSets["UserDefinedTableTypeCollection"].ToString())];
                DataTable dtUDTTSCols = ds.Tables[int.Parse(hsResultSets["UserDefinedTableTypeColumnCollection"].ToString())];
                DataTable dtUDTTSIndexes = ds.Tables[int.Parse(hsResultSets["UserDefinedTableTypeIndexCollection"].ToString())];
                DataTable dtUDTTSIndexColumns = ds.Tables[int.Parse(hsResultSets["UserDefinedTableTypeIndexColumnCollection"].ToString())];
                DataTable dtUDTTSIndexCheckConstraints = ds.Tables[int.Parse(hsResultSets["UserDefinedTableTypeCheckConstraintCollection"].ToString())];
                _userDefinedTableTypes = GetUserDefinedTableTypes(dtUDTTS, dtUDTTSCols, dtUDTTSIndexes, dtUDTTSIndexColumns, dtUDTTSIndexCheckConstraints);
            }
        }

        private List<UserDefinedType> GetUserDefinedTypes(DataTable dtTypes)
        {
            List<UserDefinedType> udts = new List<UserDefinedType>();
            DataView dwUDTS = new DataView(dtTypes, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwUDTS.Count; i++)
            {
                UserDefinedType udt = new UserDefinedType();
                udt.AssemblyClass = dwUDTS[i].Row["ClassName"].ToString();
                udt.AssemblyName = dwUDTS[i].Row["AssemblyName"].ToString();
                udt.Name = dwUDTS[i].Row["Name"].ToString();
                udt.ObjectId = int.Parse(dwUDTS[i].Row["ID"].ToString());
                udt.Schema = dwUDTS[i].Row["Schema"].ToString();
                udts.Add(udt);
                OnObjectFetched(new FetchEventArgs(udt));
            }
            return udts;
        }

        private List<UserDefinedTableType> GetUserDefinedTableTypes(DataTable dtTypes, DataTable dtColumns, 
            DataTable dtIndexes, DataTable dtIndexColumns, DataTable dtCheckConstraints)
        {
            List<UserDefinedTableType> udtts = new List<UserDefinedTableType>();
            DataView dwUDTTS = new DataView(dtTypes, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwUDTTS.Count; i++)
            {
                UserDefinedTableType udtt = new UserDefinedTableType();
                udtt.Name = dwUDTTS[i].Row["Name"].ToString();
                udtt.ObjectId = int.Parse(dwUDTTS[i].Row["ID"].ToString());
                udtt.Schema = dwUDTTS[i].Row["Schema"].ToString();
                udtt.Description = dwUDTTS[i].Row["Description"].ToString();

                if (udtt.Name == "MyType1")
                {
                    string a = "a";
                }

                DataView dwColumns = new DataView(dtColumns, "object_id='" + udtt.ObjectId + "'", "ID", System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwColumns.Count; j++)
                {
                    UserDefinedTableTypeColumn column = new UserDefinedTableTypeColumn();
                    column.Collation = dwColumns[j].Row["Collation"].ToString();
                    column.DataType = dwColumns[j].Row["DataType"].ToString();
                    column.Default = dwColumns[j].Row["DefaultValue"].ToString();
                    column.Definition = dwColumns[j].Row["Definition"].ToString();
                    column.Identity = bool.Parse(dwColumns[j].Row["Identity"].ToString());
                    column.IdentityIncrement = int.Parse(dwColumns[j].Row["IdentityIncrement"].ToString());
                    column.IdentitySeed = int.Parse(dwColumns[j].Row["IdentitySeed"].ToString());
                    column.IsComputed = bool.Parse(dwColumns[j].Row["Computed"].ToString());
                    column.IsNullable = bool.Parse(dwColumns[j].Row["Nullable"].ToString());
                    column.IsPersisted = bool.Parse(dwColumns[j].Row["IsPersisted"].ToString());
                    column.IsRowGuidCol = bool.Parse(dwColumns[j].Row["RowGuidCol"].ToString());
                    column.IsColumnSet = bool.Parse(dwColumns[j].Row["IsColumnSet"].ToString());
                    column.Length = int.Parse(dwColumns[j].Row["Length"].ToString());
                    column.Name = dwColumns[j].Row["Name"].ToString();
                    column.Precision = int.Parse(dwColumns[j].Row["NumericPrecision"].ToString());
                    column.Scale = int.Parse( dwColumns[j].Row["NumericScale"].ToString());
                    udtt.Columns.Add(column);
                }

                DataView dwIndexes = new DataView(dtIndexes, "object_id='" + udtt.ObjectId + "'", "index_id", System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwIndexes.Count; j++)
                {
                    UserDefinedTableTypeIndex index = new UserDefinedTableTypeIndex();
                    index.FilterDefinition = dwIndexes[j].Row["filter_definition"].ToString();
                    index.IgnoreDupKey = bool.Parse(dwIndexes[j].Row["ignore_dup_key"].ToString());
                    index.IndexId = int.Parse(dwIndexes[j].Row["index_id"].ToString());
                    index.IsPrimaryKey = bool.Parse(dwIndexes[j].Row["is_primary_key"].ToString());
                    index.IsUnique = bool.Parse(dwIndexes[j].Row["is_unique"].ToString());
                    index.Name = dwIndexes[j].Row["name"].ToString();
                    index.ObjectId = int.Parse(dwIndexes[j].Row["object_id"].ToString());
                    index.TypeDesc = dwIndexes[j].Row["type_desc"].ToString();

                    DataView dwIndexColumns = new DataView(dtIndexColumns, "object_id='" + udtt.ObjectId + "' AND index_id=" + index.IndexId, "", System.Data.DataViewRowState.CurrentRows);
                    for (int k = 0; k < dwIndexColumns.Count; k++)
                    {
                        IndexColumn idxColumn = new IndexColumn();
                        idxColumn.Name = dwIndexColumns[k].Row["name"].ToString();
                        idxColumn.IsDescendingKey = bool.Parse(dwIndexColumns[k].Row["is_descending_key"].ToString());
                        index.Columns.Add(idxColumn);
                    }
                    udtt.Indexes.Add(index);
                }

                DataView dwCheckConstraints = new DataView(dtCheckConstraints, "parent_object_id='" + udtt.ObjectId + "'","", System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwCheckConstraints.Count; j++)
                {
                    UserDefinedTableTypeCheckConstraint checkConstraint = new UserDefinedTableTypeCheckConstraint();
                    checkConstraint.Name = dwCheckConstraints[j].Row["Name"].ToString();
                    checkConstraint.Definition = dwCheckConstraints[j].Row["Definition"].ToString();
                    checkConstraint.ObjectId = int.Parse(dwCheckConstraints[j].Row["object_id"].ToString());
                    checkConstraint.ParentObjectId = int.Parse(dwCheckConstraints[j].Row["parent_object_id"].ToString());
                    udtt.CheckConstraints.Add(checkConstraint);
                }

                udtts.Add(udtt);
                OnObjectFetched(new FetchEventArgs(udtt));
            }
            return udtts;


        }

        private List<UserDefinedDataType> GetUserDefinedDataTypes(DataTable dtTypes)
        {
            List<UserDefinedDataType> uddts = new List<UserDefinedDataType>();
            DataView dwUDDTS = new DataView(dtTypes, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwUDDTS.Count; i++)
            {
                UserDefinedDataType uddt = new UserDefinedDataType();
                uddt.IsNullable = bool.Parse(dwUDDTS[i].Row["Nullable"].ToString());
                uddt.Length = int.Parse(dwUDDTS[i].Row["Length"].ToString());
                uddt.MaxLength = int.Parse(dwUDDTS[i].Row["MaxLength"].ToString());
                uddt.Name = dwUDDTS[i].Row["Name"].ToString();
                uddt.ObjectId = int.Parse(dwUDDTS[i].Row["ID"].ToString());
                uddt.Precision = int.Parse(dwUDDTS[i].Row["NumericPrecision"].ToString());
                uddt.Scale = int.Parse(dwUDDTS[i].Row["NumericScale"].ToString());
                uddt.Schema = dwUDDTS[i].Row["Schema"].ToString();
                uddt.SystemType = dwUDDTS[i].Row["SystemType"].ToString();
                uddt.Description = dwUDDTS[i].Row["Description"].ToString();
                uddts.Add(uddt);
                OnObjectFetched(new FetchEventArgs(uddt));
            }
            return uddts;
        }

        private List<Schema> GetSchemas(DataTable dtSchemas)
        {
            List<Schema> schemas = new List<Schema>();
            DataView dwSchemas = new DataView(dtSchemas, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwSchemas.Count; i++)
            {
                Schema schema = new Schema();
                schema.Name = dwSchemas[i].Row["Name"].ToString();
                schema.ObjectId = int.Parse(dwSchemas[i].Row["schema_id"].ToString());
                schema.Principal = dwSchemas[i].Row["principal"].ToString();
                schema.Description = dwSchemas[i].Row["Description"].ToString();
                schemas.Add(schema);
                OnObjectFetched(new FetchEventArgs(schema));
            }
            return schemas;
        }

        private List<Route> GetRoutes(DataTable dtRoutes)
        {
            List<Route> routes = new List<Route>();
            DataView dwRoutes = new DataView(dtRoutes, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwRoutes.Count; i++)
            {
                Route route = new Route();
                route.Address = dwRoutes[i].Row["Address"].ToString();
                route.BrokerInstance = dwRoutes[i].Row["broker_instance"].ToString();
                string lifetime = dwRoutes[i].Row["lifetime"].ToString();
                if (lifetime == "")
                {
                    route.LifeTime = 0;
                }
                else
                {
                    DateTime dtLifeTime = DateTime.Parse(lifetime);
                    System.TimeSpan diffResult = dtLifeTime - DateTime.Now;
                    route.LifeTime = (int)diffResult.TotalSeconds;
                }
                
                route.MirrorAddress = dwRoutes[i].Row["mirror_address"].ToString();
                route.Name = dwRoutes[i].Row["name"].ToString();
                route.ObjectId = int.Parse(dwRoutes[i].Row["route_id"].ToString());
                route.Principal = dwRoutes[i].Row["principal"].ToString();
                route.RemoteService = dwRoutes[i].Row["remote_service_name"].ToString();
                routes.Add(route);
                OnObjectFetched(new FetchEventArgs(route));
            }

            return routes;
        }

        private List<DBObjectType.Rule> GetRules(DataTable dtRules)
        { 
            List<DBObjectType.Rule> rules = new List<DBObjectType.Rule>();
            DataView dwRules = new DataView(dtRules, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwRules.Count; i++)
            {
                DBObjectType.Rule rule = new DBObjectType.Rule();
                rule.Definition = dwRules[i].Row["definition"].ToString();
                rule.ObjectId = int.Parse(dwRules[i].Row["object_id"].ToString());
                rule.Name = dwRules[i].Row["name"].ToString();
                rule.Schema = dwRules[i].Row["schema"].ToString();
                rules.Add(rule);
                OnObjectFetched(new FetchEventArgs(rule));
            }
            return rules;
        
        }

        private List<RemoteServiceBinding> GetRemoteServiceBindings(DataTable dtBindings)
        {
            List<RemoteServiceBinding> bindings = new List<RemoteServiceBinding>();
            DataView dwBindings = new DataView(dtBindings, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwBindings.Count; i++)
            {
                RemoteServiceBinding binding = new RemoteServiceBinding();
                binding.Name = dwBindings[i].Row["name"].ToString();
                binding.ObjectId = int.Parse(dwBindings[i].Row["remote_service_binding_id"].ToString());
                binding.IsAnonymousOn = bool.Parse(dwBindings[i].Row["is_anonymous_on"].ToString());
                binding.Principal = dwBindings[i].Row["Principal"].ToString();
                binding.RemoteService = dwBindings[i].Row["remote_service_name"].ToString();
                bindings.Add(binding);
                OnObjectFetched(new FetchEventArgs(binding));
            }
            return bindings;
        }

        private List<PartitionScheme> GetPartitionSchemes(DataTable dtSchemes, DataTable dtFileGroups)
        {
            List<PartitionScheme> schemes = new List<PartitionScheme>();
            DataView dwSchemes = new DataView(dtSchemes, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwSchemes.Count; i++)
            {
                PartitionScheme scheme = new PartitionScheme();
                scheme.Name = dwSchemes[i].Row["Name"].ToString();
                scheme.PartitionFunction = dwSchemes[i].Row["PartitionFunction"].ToString();
                DataView dwFileGRoups = new DataView(dtFileGroups, "name='" + scheme.Name+"'", "ID", System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwFileGRoups.Count; j++)
                {
                    scheme.FileGroups.Add(dwFileGRoups[j].Row["FileGroup"].ToString());
                }
                schemes.Add(scheme);
                OnObjectFetched(new FetchEventArgs(scheme));
            }

            return schemes;
        }

        private List<BrokerPriority> GetBrokerPriorities(DataTable dtPriorities)
        {
            List<BrokerPriority> priorities = new List<BrokerPriority>();
            DataView dwPriorities = new DataView(dtPriorities, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwPriorities.Count; i++)
            {
                BrokerPriority priority = new BrokerPriority();
                priority.Name = dwPriorities[i].Row["name"].ToString();
                priority.ObjectId = int.Parse(dwPriorities[i].Row["priority_id"].ToString());
                priority.Priority = int.Parse(dwPriorities[i].Row["priority"].ToString());
                priority.RemoteService = dwPriorities[i].Row["RemoteService"].ToString();
                priority.LocalService = dwPriorities[i].Row["LocalService"].ToString();
                priority.Contract = dwPriorities[i].Row["Contract"].ToString();
                priorities.Add(priority);
                OnObjectFetched(new FetchEventArgs(priority));
            }
            return priorities;
        }

        private List<FullTextStopList> GetFullTextStopLists(DataTable dtStopLists, DataTable dtStopWords)
        {
            List<FullTextStopList> fullTextStopLists = new List<FullTextStopList>();
            DataView dwStopLists = new DataView(dtStopLists, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwStopLists.Count; i++)
            {
                FullTextStopList fullTextStopList = new FullTextStopList();
                fullTextStopList.Name = dwStopLists[i].Row["name"].ToString();
                fullTextStopList.ObjectId = int.Parse(dwStopLists[i].Row["stoplist_id"].ToString());
                fullTextStopList.Principal = dwStopLists[i].Row["Principal"].ToString();

                DataView dwStopWords = new DataView(dtStopWords, "stoplist_id=" + fullTextStopList.ObjectId, "", System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwStopWords.Count; j++)
                {
                    FullTextStopWord word = new FullTextStopWord();
                    word.Language = dwStopWords[j].Row["Language"].ToString();
                    word.StopListId = int.Parse(dwStopWords[j].Row["stoplist_id"].ToString());
                    word.StopWord = dwStopWords[j].Row["stopword"].ToString();
                    fullTextStopList.StopWords.Add(word);
                }
                fullTextStopLists.Add(fullTextStopList);
                OnObjectFetched(new FetchEventArgs(fullTextStopList));
            }
            return fullTextStopLists;
        }

        private List<Service> GetServices(DataTable dtServices, DataTable dtServiceContracts)
        {
            List<Service> services = new List<Service>();
            DataView dwServices = new DataView(dtServices, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwServices.Count; i++)
            {
                Service service = new Service();
                service.Name = dwServices[i].Row["name"].ToString();
                service.ObjectId = int.Parse(dwServices[i].Row["service_id"].ToString());
                service.Principal = dwServices[i].Row["principal"].ToString();
                service.ServiceQueue = dwServices[i].Row["ServiceQueue"].ToString();
                service.ServiceQueueSchema = dwServices[i].Row["ServiceQueueSchema"].ToString();
                DataView dwContracts = new DataView(dtServiceContracts, "service_id=" + service.ObjectId , "", System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwContracts.Count; j++)
                {
                    service.Contracts.Add(dwContracts[j].Row["name"].ToString());
                }
                services.Add(service);
                OnObjectFetched(new FetchEventArgs(service));
            }
            return services;
        }

        private List<ServiceQueue> GetServiceQueues(DataTable dtQueues)
        {
            List<ServiceQueue> queues = new List<ServiceQueue>();
            DataView dwQueues = new DataView(dtQueues);
            for (int i = 0; i < dwQueues.Count; i++)
            {
                ServiceQueue sq = new ServiceQueue();

                sq.ActivationProcedure = dwQueues[i].Row["activation_procedure"].ToString();
                sq.IsActivationEnabled = bool.Parse(dwQueues[i].Row["is_activation_enabled"].ToString());
                sq.IsEnqueueEnabled = bool.Parse(dwQueues[i].Row["is_enqueue_enabled"].ToString());
                sq.IsReceiveEnabled = bool.Parse(dwQueues[i].Row["is_receive_enabled"].ToString());
                sq.IsRetentionEnabled = bool.Parse(dwQueues[i].Row["is_retention_enabled"].ToString());
                sq.MaxReaders = int.Parse(dwQueues[i].Row["max_readers"].ToString());
                sq.Name = dwQueues[i].Row["name"].ToString();
                sq.ObjectId = int.Parse(dwQueues[i].Row["object_id"].ToString());
                sq.Principal = dwQueues[i].Row["Principal"].ToString();
                sq.PrincipalId = dwQueues[i].Row["execute_as_Principal_Id"].ToString();
                sq.Schema = dwQueues[i].Row["Schema"].ToString();
                sq.FileGroup = dwQueues[i].Row["FileGroup"].ToString();
                queues.Add(sq);
                OnObjectFetched(new FetchEventArgs(sq));
            }
            return queues;
        }

        private List<FullTextCatalog> GetFulltextCatalogs(DataTable dtFTCatalogs)
        {
            List<FullTextCatalog> ftCatalogs = new List<FullTextCatalog>();
            DataView dwFtCatalogs = new DataView(dtFTCatalogs);
            for (int i = 0; i < dwFtCatalogs.Count; i++)
            {
                FullTextCatalog ftCatalog = new FullTextCatalog();
                ftCatalog.FileGroup = dwFtCatalogs[i].Row["FileGroup"].ToString();
                ftCatalog.IsAccentSensitive = bool.Parse(dwFtCatalogs[i].Row["Is_Accent_Sensitivity_on"].ToString());
                ftCatalog.IsDefault = bool.Parse(dwFtCatalogs[i].Row["Is_Default"].ToString());
                ftCatalog.Name = dwFtCatalogs[i].Row["Name"].ToString();
                ftCatalog.ObjectId = int.Parse(dwFtCatalogs[i].Row["fulltext_catalog_id"].ToString());
                ftCatalog.Path = dwFtCatalogs[i].Row["Path"].ToString();
                ftCatalog.Principal = dwFtCatalogs[i].Row["Principal"].ToString();
                ftCatalogs.Add(ftCatalog);
                OnObjectFetched(new FetchEventArgs(ftCatalog));
            }

            return ftCatalogs;
        }

        private List<PartitionFunction> GetPartitionFunctions(DataTable dtPartitionFunctions, DataTable dtPartitionFunctionsRangeValues)
        {
            List<PartitionFunction> partitionFunctions = new List<PartitionFunction>();
            DataView dwFunctions = new DataView(dtPartitionFunctions, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwFunctions.Count; i++)
            {
                PartitionFunction partitionFunction = new PartitionFunction();
                partitionFunction.Name = dwFunctions[i].Row["name"].ToString();
                partitionFunction.ObjectId = int.Parse(dwFunctions[i].Row["function_id"].ToString());
                partitionFunction.Type = dwFunctions[i].Row["Type"].ToString(); //boundary_value_on_right
                partitionFunction.BoundaryValueOnRight = bool.Parse(dwFunctions[i].Row["boundary_value_on_right"].ToString());
                partitionFunction.MaxLength = int.Parse(dwFunctions[i].Row["max_length"].ToString());
                partitionFunction.Precision = int.Parse(dwFunctions[i].Row["precision"].ToString());
                partitionFunction.Scale = int.Parse(dwFunctions[i].Row["scale"].ToString());


                DataView dwRAngeValues = new DataView(dtPartitionFunctionsRangeValues, "function_id=" + partitionFunction.ObjectId + "", "boundary_id", System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwRAngeValues.Count; j++)
                {
                    partitionFunction.RangeValues.Add(int.Parse(dwRAngeValues[j].Row["boundary_Id"].ToString()),dwRAngeValues[j].Row["value"].ToString());
                }
                partitionFunctions.Add(partitionFunction);
                OnObjectFetched(new FetchEventArgs(partitionFunction));
            }
            return partitionFunctions;
        }

        private List<FullTextIndex> GetFullTextIndexes(DataTable dtFtIndexes, DataTable columns, int tableId)
        {
            List<DBObjectType.FullTextIndex> ftIndexes = new List<DBObjectType.FullTextIndex>();
            DataView dwFtIndexes = new DataView(dtFtIndexes, "object_id=" + tableId ,"", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwFtIndexes.Count; i++)
            {
                FullTextIndex ftIndex = new FullTextIndex();
                ftIndex.ChangeTrackingState = dwFtIndexes[i].Row["change_tracking_state_desc"].ToString();
                ftIndex.Filegroup = dwFtIndexes[i].Row["FileGroup"].ToString();
                ftIndex.FullTextCatalog = dwFtIndexes[i].Row["FullTextCatalog"].ToString();
                ftIndex.KeyIndex = dwFtIndexes[i].Row["IndexName"].ToString();
                ftIndex.ObjectId = int.Parse(dwFtIndexes[i].Row["object_id"].ToString());
                ftIndex.ParentObjectName = dwFtIndexes[i].Row["ParentObjectName"].ToString();
                ftIndex.StopList = dwFtIndexes[i].Row["StopList"].ToString();
                ftIndex.StopListId = int.Parse(dwFtIndexes[i].Row["StoplistId"].ToString());
                ftIndex.Schema = dwFtIndexes[i].Row["Schema"].ToString();
                DataView dwColumns = new DataView(columns, "object_id=" + tableId + "", "", System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwColumns.Count; j++)
                {
                    FulltextIndexColumn column = new FulltextIndexColumn();
                    column.ColumnName = dwColumns[j].Row["ColumnName"].ToString();
                    column.LanguageId = int.Parse(dwColumns[j].Row["language_id"].ToString());
                    column.ObjectId = int.Parse(dwColumns[j].Row["object_id"].ToString());
                    column.TypeColumnName = dwColumns[j].Row["TypeColumnName"].ToString();
                    ftIndex.Columns.Add(column);
                }
                ftIndexes.Add(ftIndex);
            }
            return ftIndexes;
        }

        private List<DBObjectType.ForeignKeyConstraint> GetForeignKeys(DataTable dtFK, DataTable columns, int tableId)
        {
            List<DBObjectType.ForeignKeyConstraint> fks = new List<DBObjectType.ForeignKeyConstraint>();
            DataView dwFKs = new DataView(dtFK, "parent_object_id=" + tableId + "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwFKs.Count; i++)
            {
                DBObjectType.ForeignKeyConstraint fk = new DBObjectType.ForeignKeyConstraint();
                fk.Name = dwFKs[i].Row["name"].ToString();
                fk.ObjectId = int.Parse(dwFKs[i].Row["object_id"].ToString());
                fk.Schema = dwFKs[i].Row["schemaname"].ToString();
                fk.ParentObjectId = int.Parse(dwFKs[i].Row["parent_object_id"].ToString());
                fk.IsDisabled = bool.Parse(dwFKs[i].Row["is_disabled"].ToString());
                fk.IsNotForReplication = bool.Parse(dwFKs[i].Row["is_not_for_replication"].ToString());
                fk.IsNotTrusted = bool.Parse(dwFKs[i].Row["is_not_trusted"].ToString());
                fk.DeleteAction = dwFKs[i].Row["delete_referential_action_desc"].ToString();
                fk.UpdateAction = dwFKs[i].Row["update_referential_action_desc"].ToString();

                DataView dwColumns = new DataView(columns, "constraint_object_id=" + fk.ObjectId + "", "", System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwColumns.Count; j++)
                {
                    ForeingKeyColumns fkc = new ForeingKeyColumns();
                    fkc.ConstraintColumnId = int.Parse(dwColumns[j].Row["constraint_column_id"].ToString());
                    fkc.ConstraintObjectId = int.Parse(dwColumns[j].Row["constraint_object_id"].ToString());
                    fkc.ParentColumnName  = dwColumns[j].Row["ParentColumnName"].ToString();
                    fkc.ReferenceColumnName = dwColumns[j].Row["ReferencedColumnName"].ToString();
                    fkc.ReferencedObjectName = dwColumns[j].Row["ReferencedObjectName"].ToString();
                    fkc.ReferencedObjectId = int.Parse( dwColumns[j].Row["ReferencedObjectId"].ToString());
                    fkc.ReferencedObjectSchema = dwColumns[j].Row["ReferencedObjectSchema"].ToString();
                    fk.Columns.Add(fkc);
                }

                fks.Add(fk);
                //OnObjectFetched(new FetchEventArgs(fk));
            }
            return fks;
        }

        private List<DBObjectType.Contract> GetContracts(DataTable dtContracts, DataTable dtMsgTypes)
        {
            List<DBObjectType.Contract> contracts = new List<DBObjectType.Contract>();
            DataView dwContracts = new DataView(dtContracts, "", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwContracts.Count; i++)
            {
                DBObjectType.Contract contract = new DBObjectType.Contract();
                contract.Name = dwContracts[i].Row["name"].ToString();
                contract.ObjectId = int.Parse(dwContracts[i].Row["service_contract_id"].ToString());
                contract.PrincipalName = dwContracts[i].Row["PrincipalName"].ToString();

                DataView dwContractMessageTypes = new DataView(dtMsgTypes, "service_contract_id=" + contract.ObjectId + "", "", System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwContractMessageTypes.Count; j++)
                {
                    ContractMessageType cmt = new ContractMessageType();
                    cmt.ServiceContractId = int.Parse(dwContractMessageTypes[j].Row["service_contract_id"].ToString());
                    cmt.Name = dwContractMessageTypes[j].Row["Name"].ToString();

                    cmt.IsSentByInitiator = bool.Parse(dwContractMessageTypes[j].Row["is_sent_by_initiator"].ToString());
                    cmt.IsSentByTarget = bool.Parse(dwContractMessageTypes[j].Row["is_sent_by_target"].ToString());

                    contract.MessageTypes.Add(cmt);
                }
                contracts.Add(contract);
                OnObjectFetched(new FetchEventArgs(contract));
            }
            return contracts;
        }

        private List<MessageType> GetMessageTypes(DataTable dtMessageTypes)
        {
            List<MessageType> messageTypes = new List<MessageType>();
            DataView dwMessageTypes = new DataView(dtMessageTypes);
            for (int i = 0; i < dwMessageTypes.Count; i++)
            {
                MessageType messageType = new MessageType();
                messageType.Name = dwMessageTypes[i].Row["Name"].ToString();
                messageType.PrincipalName = dwMessageTypes[i].Row["PrincipalName"].ToString();
                messageType.ObjectId = int.Parse(dwMessageTypes[i].Row["message_type_id"].ToString());
                messageType.Validation = dwMessageTypes[i].Row["validation_desc"].ToString();
                messageType.SchemaCollection = dwMessageTypes[i].Row["SchemaCollection"].ToString();
                
                messageTypes.Add(messageType);
                OnObjectFetched(new FetchEventArgs(messageType));
            }
            return messageTypes;
        }

        private List<XMLSchemaCollection> GetXMLSchemaCollections(DataTable dtXMLSchemaCollections)
        {
            List<XMLSchemaCollection> xmlSchemaCollections = new List<XMLSchemaCollection>();
            DataView dwXMLSchemaCollections = new DataView(dtXMLSchemaCollections);
            for (int i = 0; i < dwXMLSchemaCollections.Count; i++)
            {
                XMLSchemaCollection xmlSchemaCollection = new XMLSchemaCollection();
                xmlSchemaCollection.Name = dwXMLSchemaCollections[i].Row["Name"].ToString();
                xmlSchemaCollection.Definition = dwXMLSchemaCollections[i].Row["text"].ToString();
                xmlSchemaCollection.Schema = dwXMLSchemaCollections[i].Row["Schema"].ToString();
                xmlSchemaCollection.ObjectId = int.Parse(dwXMLSchemaCollections[i].Row["id"].ToString());
                xmlSchemaCollections.Add(xmlSchemaCollection);
                OnObjectFetched(new FetchEventArgs(xmlSchemaCollection));
            }
            return xmlSchemaCollections;
        }

        private List<Synonym> GetSynonyms(DataTable dtSynonyms)
        {
            List<Synonym> synonyms = new List<Synonym>();
            DataView dwSynonyms = new DataView(dtSynonyms);
            for (int i = 0; i < dwSynonyms.Count; i++)
            {
                Synonym synonym = new Synonym();
                synonym.Name = dwSynonyms[i].Row["Name"].ToString();
                synonym.Definition = dwSynonyms[i].Row["base_object_name"].ToString();
                synonym.Schema = dwSynonyms[i].Row["Schema"].ToString();
                synonym.ObjectId = int.Parse(dwSynonyms[i].Row["object_id"].ToString());
                synonyms.Add(synonym);
                OnObjectFetched(new FetchEventArgs(synonym));
            }
            return synonyms;
        }

        private List<Default> GetDefaults(DataTable dtDefaults)
        {
            List<Default> defaults = new List<Default>();
            DataView dwDefaults = new DataView(dtDefaults);
            for (int i = 0; i < dwDefaults.Count; i++)
            {
                Default def = new Default();
                def.Definition = dwDefaults[i].Row["Definition"].ToString();
                def.Name = dwDefaults[i].Row["Name"].ToString();
                def.ObjectId = int.Parse( dwDefaults[i].Row["object_id"].ToString());
                defaults.Add(def);
                OnObjectFetched(new FetchEventArgs(def));
            }
            return defaults;
        }

        private List<Aggregate> GetAggregates(DataTable dtAggregates, DataTable dtParameters)
        {
            List<Aggregate> aggregates = new List<Aggregate>();
            DataView dwAggregates = new DataView(dtAggregates);
            for (int i = 0; i < dwAggregates.Count; i++)
            {
                Aggregate aggregate = new Aggregate();
                aggregate.AssemblyClass = dwAggregates[i].Row["Assembly_Class"].ToString();
                aggregate.AssemblyName = dwAggregates[i].Row["Assembly_Name"].ToString();
                aggregate.Name = dwAggregates[i].Row["Name"].ToString();
                aggregate.ObjectId = int.Parse( dwAggregates[i].Row["Object_id"].ToString());
                aggregate.Schema = dwAggregates[i].Row["Schema"].ToString();
                
                //List<ObjectHelper.DBObjectType.UniqueConstraint> constraints = new List<ObjectHelper.DBObjectType.UniqueConstraint>();
                string rowFilter = "Object_Id=" + aggregate.ObjectId + " and is_output=0";
                DataView dwParameters = new DataView(dtParameters, rowFilter, "Parameter_Id", System.Data.DataViewRowState.CurrentRows);

                for (int j = 0; j < dwParameters.Count; j++)
                {
                    Parameter parameter = new Parameter();
                    parameter.DefaultValue = dwParameters[j].Row["Default_Value"].ToString();
                    parameter.IsOutput = bool.Parse(dwParameters[j].Row["is_output"].ToString());
                    parameter.IsReadOnly = bool.Parse(dwParameters[j].Row["is_readonly"].ToString());
                    parameter.IsXmlDocument = bool.Parse(dwParameters[j].Row["is_xml_document"].ToString());
                    parameter.MaxLength = int.Parse(dwParameters[j].Row["max_length"].ToString());
                    parameter.Name = dwParameters[j].Row["Name"].ToString();
                    parameter.ObjectId = int.Parse(dwParameters[j].Row["object_id"].ToString());
                    parameter.ParameterId = int.Parse(dwParameters[j].Row["parameter_id"].ToString());
                    parameter.Precision = int.Parse(dwParameters[j].Row["precision"].ToString());
                    parameter.Scale = int.Parse(dwParameters[j].Row["scale"].ToString());
                    parameter.Type = dwParameters[j].Row["Type"].ToString();
                    parameter.XmlCollectionId = int.Parse(dwParameters[j].Row["xml_collection_id"].ToString());
                    //parameter.Description = dwParameters[j].Row["Description"].ToString();
                    aggregate.InputParameters.Add(parameter);
                }

                rowFilter = "Object_Id=" + aggregate.ObjectId + " and is_output=1";
                dwParameters = new DataView(dtParameters, rowFilter, "Parameter_Id", System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwParameters.Count; j++)
                {
                    Parameter parameter = new Parameter();
                    parameter.DefaultValue = dwParameters[j].Row["Default_Value"].ToString();
                    parameter.IsOutput = bool.Parse(dwParameters[j].Row["is_output"].ToString());
                    parameter.IsReadOnly = bool.Parse(dwParameters[j].Row["is_readonly"].ToString());
                    parameter.IsXmlDocument = bool.Parse(dwParameters[j].Row["is_xml_document"].ToString());
                    parameter.MaxLength = int.Parse(dwParameters[j].Row["max_length"].ToString());
                    parameter.Name = dwParameters[j].Row["Name"].ToString();
                    parameter.ObjectId = int.Parse(dwParameters[j].Row["object_id"].ToString());
                    parameter.ParameterId = int.Parse(dwParameters[j].Row["parameter_id"].ToString());
                    parameter.Precision = int.Parse(dwParameters[j].Row["precision"].ToString());
                    parameter.Scale = int.Parse(dwParameters[j].Row["scale"].ToString());
                    parameter.Type = dwParameters[j].Row["Type"].ToString();
                    parameter.XmlCollectionId = int.Parse(dwParameters[j].Row["xml_collection_id"].ToString());
                    //parameter.Description = dwParameters[j].Row["Description"].ToString();
                    aggregate.OutputParameter = parameter;
                }
                
                //DataTable dtParameters = ds.Tables[int.Parse(hsResultSets["SPCollection"].ToString())];

                aggregates.Add(aggregate);
                OnObjectFetched(new FetchEventArgs(aggregate));
            }
            return aggregates;
        }

        private List<DBObjectType.Assembly> GetAssemblies(DataTable dtAssemblies)
        {
            List<DBObjectType.Assembly> assemblies = new List<DBObjectType.Assembly>();
            DataView dwAssemblies = new DataView(dtAssemblies,"", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwAssemblies.Count; i++)
            {
                DBObjectType.Assembly assembly = new DBObjectType.Assembly();
                assembly.Name = dwAssemblies[i].Row["name"].ToString();
                assembly.Filename = dwAssemblies[i].Row["Filename"].ToString();
                assembly.Content = dwAssemblies[i].Row["Content"].ToString().ToUpper();
                assembly.PermissionSet = int.Parse(dwAssemblies[i].Row["permission_set"].ToString());
                assembly.Principal = dwAssemblies[i].Row["principalname"].ToString();
                assembly.ObjectId = int.Parse(dwAssemblies[i].Row["assembly_id"].ToString());
                assembly.Description = dwAssemblies[i].Row["Description"].ToString();
                assemblies.Add(assembly);
                OnObjectFetched(new FetchEventArgs(assembly));
            }
            return assemblies;
        }

        private List<Principal> GetPrincipals(DataTable dtPrincipals, string type)
        {
            List<Principal> principals = new List<Principal>();
            DataView dwPrincipals = new DataView(dtPrincipals, "Type='"+type+"'", "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwPrincipals.Count; i++)
            {
                Principal principal = new Principal();
                principal.Name = dwPrincipals[i].Row["name"].ToString();
                principal.OwningPrincipalName = dwPrincipals[i].Row["OwningPrincipalName"].ToString();
                principal.ObjectId = int.Parse(dwPrincipals[i].Row["principal_id"].ToString());
                principal.Schema = dwPrincipals[i].Row["default_schema_name"].ToString();
                principal.Type = dwPrincipals[i].Row["type"].ToString();
                principal.Login = dwPrincipals[i].Row["login"].ToString();
                principal.AsymmetricKey = dwPrincipals[i].Row["AsymmetricKey"].ToString();
                principal.Certificate = dwPrincipals[i].Row["Certificate"].ToString();
                principal.Description = dwPrincipals[i].Row["Description"].ToString();
                principals.Add(principal);
                OnObjectFetched(new FetchEventArgs(principal));
            }
            return principals;
        }

        private List<CLRTrigger> GetCLRTriggers(DataTable dtTriggers, DataTable dtEvents)
        {

            List<CLRTrigger> triggers = new List<CLRTrigger>();
            DataView dwTriggers = new DataView(dtTriggers, "", "Name", System.Data.DataViewRowState.CurrentRows);
            DataView dwEvents = null;
            for (int i = 0; i < dwTriggers.Count; i++)
            {
                CLRTrigger trigger = new CLRTrigger();
                trigger.AssemblyClass = dwTriggers[i].Row["assembly_class"].ToString();
                trigger.AssemblyMethod = dwTriggers[i].Row["assembly_method"].ToString();
                trigger.AssemblyName = dwTriggers[i].Row["assemblyname"].ToString();
                trigger.ExecuteAs = dwTriggers[i].Row["ExecuteAs"].ToString();
                trigger.IsAfter = bool.Parse(dwTriggers[i].Row["IsAfter"].ToString());
                trigger.IsDisabled = bool.Parse(dwTriggers[i].Row["Is_Disabled"].ToString());
                trigger.IsInsteadOf = bool.Parse(dwTriggers[i].Row["is_instead_of_trigger"].ToString());
                trigger.IsNotForReplication = bool.Parse(dwTriggers[i].Row["is_not_for_replication"].ToString());
                trigger.Name = dwTriggers[i].Row["name"].ToString();
                trigger.ObjectId =int.Parse( dwTriggers[i].Row["Object_Id"].ToString());
                trigger.ParentClass =int.Parse( dwTriggers[i].Row["parent_class"].ToString());
                trigger.ParentObjectName=dwTriggers[i].Row["ParentObjectName"].ToString();
                trigger.ParentObjectSchema = dwTriggers[i].Row["ParentObjectSchema"].ToString();
                trigger.Schema = dwTriggers[i].Row["Schema"].ToString();
                trigger.IsDatabaseTrigger = bool.Parse(dwTriggers[i].Row["IsDatabaseTrigger"].ToString()); 
                dwEvents = new DataView(dtEvents,"object_id=" + trigger.ObjectId,"type_desc",System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwEvents.Count; j++)
                {
                    trigger.Events.Add(dwEvents[j].Row["type_desc"].ToString());
                }
                triggers.Add(trigger);
                OnObjectFetched(new FetchEventArgs(trigger));
            }
            return triggers;
        }

        private List<Trigger> GetTriggers(DataTable dtTriggers, bool ddlTrigger)
        {
            List<Trigger> triggers = new List<Trigger>();

            string rowFilter = string.Empty;
            if (ddlTrigger)
            {
                rowFilter = "parent_class=0";
            }
            else
            {
                rowFilter = "parent_class<>0";
            }
            DataView dwTriggers = new DataView(dtTriggers, rowFilter, "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwTriggers.Count; i++)
            {
                Trigger trigger = new Trigger();
                trigger.ObjectId = int.Parse(dwTriggers[i].Row["Object_Id"].ToString());
                trigger.Definition = dwTriggers[i].Row["Definition"].ToString();
                trigger.IsDisabled = bool.Parse(dwTriggers[i].Row["Is_Disabled"].ToString());
                trigger.IsInsteadOf = bool.Parse(dwTriggers[i].Row["is_instead_of_trigger"].ToString());
                trigger.IsNotForReplication = bool.Parse(dwTriggers[i].Row["is_not_for_replication"].ToString());
                trigger.Name = dwTriggers[i].Row["Name"].ToString();
                trigger.ParentClass = int.Parse(dwTriggers[i].Row["Parent_Class"].ToString());
                trigger.IsAfter = bool.Parse(dwTriggers[i].Row["IsAfter"].ToString());
                trigger.ParentObjectName = dwTriggers[i].Row["ParentObjectName"].ToString();
                trigger.ParentObjectSchema = dwTriggers[i].Row["ParentObjectSchema"].ToString();
                trigger.Schema = dwTriggers[i].Row["Schema"].ToString();
                trigger.IsDatabaseTrigger = bool.Parse(dwTriggers[i].Row["IsDatabaseTrigger"].ToString()); 
                triggers.Add(trigger);
                OnObjectFetched(new FetchEventArgs(trigger));
            }
            return triggers;
        }

        private List<Column> GetColumns(DataTable dtColumns, int tableId)
        {
            List<Column> columns = new List<Column>();
            string rowFilter = "Object_Id=" + tableId;
            DataView dwColumns = new DataView(dtColumns, rowFilter, "Column_Id", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwColumns.Count; i++)
            {
                Column column = new Column();
                column.ColumnId = int.Parse(dwColumns[i].Row["Column_Id"].ToString());
                column.Description = dwColumns[i].Row["Description"].ToString();
                column.Name = dwColumns[i].Row["Name"].ToString();
                column.IsComputed = bool.Parse(dwColumns[i].Row["Is_Computed"].ToString());
                column.IsFileStream = bool.Parse(dwColumns[i].Row["Is_Filestream"].ToString());
                column.IsIdentity = bool.Parse(dwColumns[i].Row["Is_Identity"].ToString());
                column.IsNullable = bool.Parse(dwColumns[i].Row["Is_Nullable"].ToString());
                column.IsReplicated = bool.Parse(dwColumns[i].Row["Is_Replicated"].ToString());
                column.IsRowGuidCol = bool.Parse(dwColumns[i].Row["Is_rowguidcol"].ToString());
                column.IsSparse = bool.Parse(dwColumns[i].Row["Is_Sparse"].ToString());
                column.ObjectId = int.Parse(dwColumns[i].Row["Object_Id"].ToString());
                column.Precision = int.Parse(dwColumns[i].Row["Precision"].ToString());
                column.Scale = int.Parse(dwColumns[i].Row["Scale"].ToString());
                column.Type = dwColumns[i].Row["Type"].ToString();
                column.IsComputed = bool.Parse(dwColumns[i].Row["Is_Computed"].ToString());
                column.Definition = dwColumns[i].Row["Definition"].ToString();
                column.Collation = dwColumns[i].Row["Collation"].ToString();
                column.Scale =int.Parse(dwColumns[i].Row["Scale"].ToString());
                column.Description = dwColumns[i].Row["Description"].ToString();
                column.IdentityIncrement = int.Parse(dwColumns[i].Row["IdentityIncrement"].ToString());
                column.IdentitySeed = int.Parse(dwColumns[i].Row["IdentitySeed"].ToString());
                column.IsPersisted = bool.Parse(dwColumns[i].Row["IsPersisted"].ToString());
                column.IsUserDefinedDataType = bool.Parse(dwColumns[i].Row["IsUserDefinedDataType"].ToString());
                int isUnique = int.Parse(dwColumns[i].Row["IsUnique"].ToString());
                if (isUnique > 0)
                {
                    column.IsUnique = true;
                }
                else
                {
                    column.IsUnique = false;
                }
                column.IsColumnSet = bool.Parse(dwColumns[i].Row["is_column_set"].ToString());
                columns.Add(column);
            }
            return columns;
        }

        private List<DefaultConstraint> GetDefaultConstraints(DataTable dtConstraints, int tableId)
        {
            List<DefaultConstraint> constraints = new List<DefaultConstraint>();
            string rowFilter = "Parent_Object_Id=" + tableId;
            DataView dwConstraints = new DataView(dtConstraints, rowFilter, "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwConstraints.Count; i++)
            {
                DefaultConstraint constraint = new DefaultConstraint();
                constraint.Name = dwConstraints[i].Row["Name"].ToString();
                constraint.ObjectId = int.Parse(dwConstraints[i].Row["Object_id"].ToString());
                constraint.ParentObjectId = int.Parse(dwConstraints[i].Row["Parent_Object_id"].ToString());
                constraint.Column = dwConstraints[i].Row["ColumnName"].ToString();
                constraint.Definition = dwConstraints[i].Row["Definition"].ToString();
                constraint.Table = dwConstraints[i].Row["TableName"].ToString();
                constraint.Schema = dwConstraints[i].Row["Schema"].ToString();
                constraints.Add(constraint);
                OnObjectFetched(new FetchEventArgs(constraint));
            }

            return constraints;
        }

        private List<CheckConstraint> GetCheckConstraints(DataTable dtConstraints, int tableId)
        {
            List<CheckConstraint> constraints = new List<CheckConstraint>();
            string rowFilter = "Parent_Object_Id=" + tableId;
            DataView dwConstraints = new DataView(dtConstraints, rowFilter, "Name", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwConstraints.Count; i++)
            {
                CheckConstraint constraint = new CheckConstraint();
                constraint.Name = dwConstraints[i].Row["Name"].ToString();
                constraint.ObjectId = int.Parse(dwConstraints[i].Row["Object_id"].ToString());
                constraint.ParentObjectId = int.Parse(dwConstraints[i].Row["Parent_Object_id"].ToString());
                constraint.Column = dwConstraints[i].Row["ColumnName"].ToString();
                constraint.Definition = dwConstraints[i].Row["Definition"].ToString();
                constraint.Table = dwConstraints[i].Row["TableName"].ToString();
                constraint.Schema = dwConstraints[i].Row["Schema"].ToString();
                constraints.Add(constraint);
            }

            return constraints;
        }

        private List<PrimaryKeyConstraint> GetPrimaryKeyConstraint(DataTable dtConstraints, DataTable dtIndexColumns, int tableId)
        {
            List<PrimaryKeyConstraint> constraints = new List<PrimaryKeyConstraint>();
            string rowFilter = "Object_Id=" + tableId + " AND is_primary_key=1";
            DataView dwConstraints = new DataView(dtConstraints, rowFilter, "Name", System.Data.DataViewRowState.CurrentRows);
            
            for (int i = 0; i < dwConstraints.Count; i++)
            {
                PrimaryKeyConstraint constraint = new PrimaryKeyConstraint();
                constraint.ObjectId = int.Parse(dwConstraints[i].Row["Object_id"].ToString());
                constraint.Name = dwConstraints[i].Row["Name"].ToString();
                constraint.IndexId = int.Parse(dwConstraints[i].Row["Index_id"].ToString());
                constraint.Type = dwConstraints[i].Row["Type_Desc"].ToString();
                constraint.IsUnique = bool.Parse(dwConstraints[i].Row["is_unique"].ToString());
                constraint.IgnoreDupKey = bool.Parse(dwConstraints[i].Row["ignore_dup_key"].ToString());
                constraint.IsPrimary = bool.Parse(dwConstraints[i].Row["is_primary_key"].ToString());
                constraint.IsUniqueConstraint = bool.Parse(dwConstraints[i].Row["is_unique_constraint"].ToString());
                constraint.FillFactor = int.Parse(dwConstraints[i].Row["fill_factor"].ToString());
                constraint.IsPadded = bool.Parse(dwConstraints[i].Row["is_padded"].ToString());
                constraint.IsDisabled = bool.Parse(dwConstraints[i].Row["is_disabled"].ToString());
                constraint.IsHypothetical = bool.Parse(dwConstraints[i].Row["is_hypothetical"].ToString());
                constraint.AllowRowLocks = bool.Parse(dwConstraints[i].Row["allow_row_locks"].ToString());
                constraint.AllowPageLocks = bool.Parse(dwConstraints[i].Row["allow_page_locks"].ToString());
                //constraint.HasFilter = bool.Parse(dwConstraints[i].Row["has_filter"].ToString());
                //constraint.FilterDefinition = dwConstraints[i].Row["filter_definition"].ToString();
                constraint.DataSpaceType = dwConstraints[i].Row["DataSpaceType"].ToString();
                constraint.DataSpace = dwConstraints[i].Row["DataSpace"].ToString();
                constraint.PartitionedColumn = dwConstraints[i].Row["PartitionedColumn"].ToString();
                constraint.StatisticsNoRecompute = bool.Parse(dwConstraints[i].Row["no_recompute"].ToString());
                constraint.Columns = GetIndexColumns(tableId, constraint.IndexId, dtIndexColumns);
                constraint.Description = dwConstraints[i].Row["ConstraintDescription"].ToString();
                constraints.Add(constraint);
            }
            return constraints;
        }

        private List<Index> GetIndexes(DataTable dtIndexes, DataTable dtIndexColumns, string Type)
        {
            List<Index> constraints = new List<Index>();
            string rowFilter = "is_primary_key=0 and is_unique_constraint=0 and [type_desc]='"+Type+"'";
            DataView dwIndexes = new DataView(dtIndexes, rowFilter, "Name", System.Data.DataViewRowState.CurrentRows);

            for (int i = 0; i < dwIndexes.Count; i++)
            {
                Index constraint = new Index();
                constraint.ObjectId = int.Parse(dwIndexes[i].Row["Object_id"].ToString());
                constraint.Name = dwIndexes[i].Row["Name"].ToString();
                constraint.IndexId = int.Parse(dwIndexes[i].Row["Index_id"].ToString());
                constraint.Type = dwIndexes[i].Row["Type_Desc"].ToString();
                constraint.IsUnique = bool.Parse(dwIndexes[i].Row["is_unique"].ToString());
                constraint.IgnoreDupKey = bool.Parse(dwIndexes[i].Row["ignore_dup_key"].ToString());
                constraint.IsPrimary = bool.Parse(dwIndexes[i].Row["is_primary_key"].ToString());
                constraint.IsUniqueConstraint = bool.Parse(dwIndexes[i].Row["is_unique_constraint"].ToString());
                constraint.FillFactor = int.Parse(dwIndexes[i].Row["fill_factor"].ToString());
                constraint.IsPadded = bool.Parse(dwIndexes[i].Row["is_padded"].ToString());
                constraint.IsDisabled = bool.Parse(dwIndexes[i].Row["is_disabled"].ToString());
                constraint.IsHypothetical = bool.Parse(dwIndexes[i].Row["is_hypothetical"].ToString());
                constraint.AllowRowLocks = bool.Parse(dwIndexes[i].Row["allow_row_locks"].ToString());
                constraint.AllowPageLocks = bool.Parse(dwIndexes[i].Row["allow_page_locks"].ToString());
                constraint.HasFilter = bool.Parse(dwIndexes[i].Row["has_filter"].ToString());
                constraint.FilterDefinition = dwIndexes[i].Row["filter_definition"].ToString();
                constraint.DataSpaceType = dwIndexes[i].Row["DataSpaceType"].ToString();
                constraint.DataSpace = dwIndexes[i].Row["DataSpace"].ToString();
                constraint.PartitionedColumn = dwIndexes[i].Row["PartitionedColumn"].ToString();
                constraint.StatisticsNoRecompute = bool.Parse(dwIndexes[i].Row["no_recompute"].ToString());
                constraint.Columns = GetIndexColumns(constraint.ObjectId, constraint.IndexId, dtIndexColumns);
                constraint.FileStreamFileGroup = dwIndexes[i].Row["FileStreamFileGroup"].ToString();
                constraint.ObjectName = dwIndexes[i].Row["ObjectName"].ToString();
                constraint.ObjectSchema = dwIndexes[i].Row["ObjectSchema"].ToString();
                constraint.Description = dwIndexes[i].Row["Description"].ToString();
                constraints.Add(constraint);
                OnObjectFetched(new FetchEventArgs(constraint));
            }
            return constraints;
        }

        private List<ObjectHelper.DBObjectType.UniqueConstraint> GetUniqueConstraints(DataTable dtConstraints, DataTable dtIndexColumns, int tableId)
        {
            List<ObjectHelper.DBObjectType.UniqueConstraint> constraints = new List<ObjectHelper.DBObjectType.UniqueConstraint>();
            string rowFilter = "Object_Id=" + tableId + " AND is_unique_constraint=1";
            DataView dwConstraints = new DataView(dtConstraints, rowFilter, "Name", System.Data.DataViewRowState.CurrentRows);

            for (int i = 0; i < dwConstraints.Count; i++)
            {
                ObjectHelper.DBObjectType.UniqueConstraint constraint = new ObjectHelper.DBObjectType.UniqueConstraint();
                constraint.ObjectId = int.Parse(dwConstraints[i].Row["Object_id"].ToString());
                constraint.Name = dwConstraints[i].Row["Name"].ToString();
                constraint.IndexId = int.Parse(dwConstraints[i].Row["Index_id"].ToString());
                constraint.Type = dwConstraints[i].Row["Type_Desc"].ToString();
                constraint.IsUnique = bool.Parse(dwConstraints[i].Row["is_unique"].ToString());
                constraint.IgnoreDupKey = bool.Parse(dwConstraints[i].Row["ignore_dup_key"].ToString());
                constraint.IsPrimary = bool.Parse(dwConstraints[i].Row["is_primary_key"].ToString());
                constraint.IsUniqueConstraint = bool.Parse(dwConstraints[i].Row["is_unique_constraint"].ToString());
                constraint.FillFactor = int.Parse(dwConstraints[i].Row["fill_factor"].ToString());
                constraint.IsPadded = bool.Parse(dwConstraints[i].Row["is_padded"].ToString());
                constraint.IsDisabled = bool.Parse(dwConstraints[i].Row["is_disabled"].ToString());
                constraint.IsHypothetical = bool.Parse(dwConstraints[i].Row["is_hypothetical"].ToString());
                constraint.AllowRowLocks = bool.Parse(dwConstraints[i].Row["allow_row_locks"].ToString());
                constraint.AllowPageLocks = bool.Parse(dwConstraints[i].Row["allow_page_locks"].ToString());
                constraint.HasFilter = bool.Parse(dwConstraints[i].Row["has_filter"].ToString());
                constraint.FilterDefinition = dwConstraints[i].Row["filter_definition"].ToString();
                constraint.DataSpaceType = dwConstraints[i].Row["DataSpaceType"].ToString();
                constraint.DataSpace = dwConstraints[i].Row["DataSpace"].ToString();
                constraint.PartitionedColumn = dwConstraints[i].Row["PartitionedColumn"].ToString();
                constraint.StatisticsNoRecompute = bool.Parse(dwConstraints[i].Row["no_recompute"].ToString());
                constraint.Columns = GetIndexColumns(tableId, constraint.IndexId, dtIndexColumns);
                constraints.Add(constraint);
                OnObjectFetched(new FetchEventArgs(constraint));
            }
            return constraints;
        }

        private List<IndexColumn> GetIndexColumns(int tableId, int indexId, DataTable dtIndexColumns)
        {
            List<IndexColumn> columns = new List<IndexColumn>();
            string rowFilter = "Object_Id=" + tableId + " AND index_Id=" + indexId;
            DataView dwColumns = new DataView(dtIndexColumns, rowFilter, "Index_Column_Id", System.Data.DataViewRowState.CurrentRows);

            for (int i = 0; i < dwColumns.Count; i++)
            {
                IndexColumn column = new IndexColumn();
                column.ObjectId = int.Parse(dwColumns[i].Row["Object_id"].ToString());
                column.Name = dwColumns[i].Row["Name"].ToString();
                column.IndexId = int.Parse(dwColumns[i].Row["Index_id"].ToString());
                column.IsDescendingKey = bool.Parse(dwColumns[i].Row["is_descending_key"].ToString());
                column.IsIncluded = bool.Parse(dwColumns[i].Row["is_descending_key"].ToString());
                column.IndexColumnId = int.Parse(dwColumns[i].Row["Index_Column_Id"].ToString());
                column.ColumnId = int.Parse(dwColumns[i].Row["Column_Id"].ToString());
                columns.Add(column);
            }
            return columns;
        }

        private List<CLRUserDefinedFunction> GetCLRUserDefinedFunctions(DataTable dtFunctions, DataTable dtParameters, DataTable dtColumns)
        {
            List<CLRUserDefinedFunction> functions = new List<CLRUserDefinedFunction>();
            DataView dwFunctions = new DataView(dtFunctions);
            for (int i = 0; i < dwFunctions.Count; i++)
            {
                CLRUserDefinedFunction function = new CLRUserDefinedFunction();
                function.AssemblyClass = dwFunctions[i].Row["Assembly_class"].ToString();
                function.AssemblyMethod = dwFunctions[i].Row["Assembly_method"].ToString();
                function.AssemblyName = dwFunctions[i].Row["Assembly_name"].ToString();
                function.ExecuteAsPrincipal = dwFunctions[i].Row["execute_as_principal_id_name"].ToString();
                function.ExecuteAsPrincipalId = int.Parse(dwFunctions[i].Row["execute_as_principal_id"].ToString());
                function.IsTableValued = bool.Parse(dwFunctions[i].Row["Is_Table_Valued"].ToString());
                function.Name = dwFunctions[i].Row["Name"].ToString();
                function.ObjectId = int.Parse(dwFunctions[i].Row["object_id"].ToString());
                function.Schema = dwFunctions[i].Row["Schema"].ToString();

                DataView dwParameters = new DataView(dtParameters, "object_id=" + function.ObjectId, "Parameter_id", System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwParameters.Count; j++)
                {
                    Parameter parameter = new Parameter();
                    parameter.DefaultValue = dwParameters[j].Row["Default_Value"].ToString();
                    parameter.IsOutput = bool.Parse(dwParameters[j].Row["is_output"].ToString());
                    parameter.IsReadOnly = bool.Parse(dwParameters[j].Row["is_readonly"].ToString());
                    parameter.IsXmlDocument = bool.Parse(dwParameters[j].Row["is_xml_document"].ToString());
                    parameter.MaxLength = int.Parse(dwParameters[j].Row["max_length"].ToString());
                    parameter.Name = dwParameters[j].Row["Name"].ToString();
                    parameter.ObjectId = int.Parse(dwParameters[j].Row["object_id"].ToString());
                    parameter.ParameterId = int.Parse(dwParameters[j].Row["parameter_id"].ToString());
                    parameter.Precision = int.Parse(dwParameters[j].Row["precision"].ToString());
                    parameter.Scale = int.Parse(dwParameters[j].Row["scale"].ToString());
                    parameter.Type = dwParameters[j].Row["Type"].ToString();
                    parameter.XmlCollectionId = int.Parse(dwParameters[j].Row["xml_collection_id"].ToString());
                    parameter.XmlCollection = dwParameters[j].Row["xmlcollection"].ToString();
                    parameter.Description = dwParameters[j].Row["Description"].ToString();
                    if (parameter.IsOutput)
                    {
                        function.Output = parameter;
                    }
                    else
                    {
                        function.Parameters.Add(parameter);
                    }
                }

                DataView dwColumns = new DataView(dtColumns,"object_id="+function.ObjectId,"column_id",System.Data.DataViewRowState.CurrentRows);
                for (int j = 0; j < dwColumns.Count; j++)
                {
                    Column column = new Column();
                    column.ObjectId = int.Parse(dwColumns[j].Row["object_id"].ToString());
                    column.Name = dwColumns[j].Row["name"].ToString();
                    column.ColumnId = int.Parse(dwColumns[j].Row["column_id"].ToString());
                    column.Type = dwColumns[j].Row["DataType"].ToString();
                    column.Scale = int.Parse(dwColumns[j].Row["Scale"].ToString());
                    column.Precision = int.Parse(dwColumns[j].Row["Precision"].ToString());
                    column.IsSparse = bool.Parse(dwColumns[j].Row["is_sparse"].ToString());
                    function.Columns.Add(column);
                }
                functions.Add(function);
                OnObjectFetched(new FetchEventArgs(function));
            }
            return functions;
        }

        private List<SQLUserDefinedFunction> GetSQLUserDefinedFunctions(DataTable dtFs, DataTable dtParameters)
        {
            List<SQLUserDefinedFunction> functions = new List<SQLUserDefinedFunction>();
            DataView dwFunctions = new DataView(dtFs);
            for (int i = 0; i < dwFunctions.Count; i++)
            {
                SQLUserDefinedFunction function = new SQLUserDefinedFunction();
                function.IsDeterministic = bool.Parse(dwFunctions[i].Row["IsDeterministic"].ToString());
                function.Definition = dwFunctions[i].Row["Definition"].ToString();
                function.Name = dwFunctions[i].Row["Name"].ToString();
                function.ObjectId = int.Parse(dwFunctions[i].Row["Object_Id"].ToString());
                function.QuotedIdentifiers = bool.Parse(dwFunctions[i].Row["QuotedIdentifierStatus"].ToString());
                function.Schema = dwFunctions[i].Row["Schema"].ToString();
                function.IsTableValued = bool.Parse(dwFunctions[i].Row["Is_Table_Valued"].ToString());
                string rowFilter = "Object_Id=" + function.ObjectId;
                DataView dwParameters = new DataView(dtParameters, rowFilter, "Parameter_Id", System.Data.DataViewRowState.CurrentRows);

                for (int j = 0; j < dwParameters.Count; j++)
                {
                    Parameter parameter = new Parameter();
                    parameter.DefaultValue = dwParameters[j].Row["Default_Value"].ToString();
                    parameter.IsOutput = bool.Parse(dwParameters[j].Row["is_output"].ToString());
                    parameter.IsReadOnly = bool.Parse(dwParameters[j].Row["is_readonly"].ToString());
                    parameter.IsXmlDocument = bool.Parse(dwParameters[j].Row["is_xml_document"].ToString());
                    parameter.MaxLength = int.Parse(dwParameters[j].Row["max_length"].ToString());
                    parameter.Name = dwParameters[j].Row["Name"].ToString();
                    parameter.ObjectId = int.Parse(dwParameters[j].Row["object_id"].ToString());
                    parameter.ParameterId = int.Parse(dwParameters[j].Row["parameter_id"].ToString());
                    parameter.Precision = int.Parse(dwParameters[j].Row["precision"].ToString());
                    parameter.Scale = int.Parse(dwParameters[j].Row["scale"].ToString());
                    parameter.Type = dwParameters[j].Row["Type"].ToString();
                    parameter.XmlCollectionId = int.Parse(dwParameters[j].Row["xml_collection_id"].ToString());
                    parameter.XmlCollection = dwParameters[j].Row["xmlcollection"].ToString();
                    parameter.Description = dwParameters[j].Row["Description"].ToString();
                    if (parameter.IsOutput)
                    {
                        function.Output = parameter;
                    }
                    else
                    {
                        function.Parameters.Add(parameter);
                    }
                }
                functions.Add(function);
                OnObjectFetched(new FetchEventArgs(function));
            }
            return functions;
        }

        private List<StoredProcedure> GetStoredProcedures(DataTable dtSPs, DataTable dtParameters)
        {
            List<StoredProcedure> procedures = new List<StoredProcedure>();
            DataView dwProcedures = new DataView(dtSPs);
            for (int i = 0; i < dwProcedures.Count; i++)
            {
                StoredProcedure sp = new StoredProcedure();
                sp.Definition = dwProcedures[i].Row["Definition"].ToString();
                sp.IsAutoExecuted = bool.Parse(dwProcedures[i].Row["is_auto_executed"].ToString());
                sp.IsExecutionReplicated = bool.Parse(dwProcedures[i].Row["is_execution_replicated"].ToString());
                sp.IsReplicationSerializableOnly = bool.Parse(dwProcedures[i].Row["is_repl_serializable_only"].ToString());
                sp.ObjectId = int.Parse(dwProcedures[i].Row["object_id"].ToString());
                sp.Name = dwProcedures[i].Row["Name"].ToString();
                sp.Schema = dwProcedures[i].Row["SchemaName"].ToString();
                sp.UsesAnsiNull = bool.Parse(dwProcedures[i].Row["uses_ansi_nulls"].ToString());
                sp.UsesQuotedIdentifier = bool.Parse(dwProcedures[i].Row["uses_quoted_identifier"].ToString());

                //List<ObjectHelper.DBObjectType.UniqueConstraint> constraints = new List<ObjectHelper.DBObjectType.UniqueConstraint>();
                string rowFilter = "Object_Id=" + sp.ObjectId;
                DataView dwParameters = new DataView(dtParameters, rowFilter, "Parameter_Id", System.Data.DataViewRowState.CurrentRows);

                for (int j = 0; j < dwParameters.Count; j++)
                {
                    Parameter parameter = new Parameter();
                    parameter.DefaultValue = dwParameters[j].Row["Default_Value"].ToString();
                    parameter.IsOutput = bool.Parse(dwParameters[j].Row["is_output"].ToString());
                    parameter.IsReadOnly=bool.Parse(dwParameters[j].Row["is_readonly"].ToString());
                    parameter.IsXmlDocument = bool.Parse(dwParameters[j].Row["is_xml_document"].ToString());
                    parameter.MaxLength = int.Parse(dwParameters[j].Row["max_length"].ToString());
                    parameter.Name = dwParameters[j].Row["Name"].ToString();
                    parameter.ObjectId = int.Parse(dwParameters[j].Row["object_id"].ToString());
                    parameter.ParameterId = int.Parse(dwParameters[j].Row["parameter_id"].ToString());
                    parameter.Precision = int.Parse(dwParameters[j].Row["precision"].ToString());
                    parameter.Scale = int.Parse(dwParameters[j].Row["scale"].ToString());
                    parameter.Type = dwParameters[j].Row["Type"].ToString();
                    parameter.XmlCollectionId = int.Parse(dwParameters[j].Row["xml_collection_id"].ToString());
                    parameter.XmlCollection = dwParameters[j].Row["xmlcollection"].ToString();
                    parameter.Description = dwParameters[j].Row["Description"].ToString();
                    sp.Parameters.Add(parameter);
                }
                //DataTable dtParameters = ds.Tables[int.Parse(hsResultSets["SPCollection"].ToString())];

                procedures.Add(sp);
                OnObjectFetched(new FetchEventArgs(sp));
            }
            return procedures;
        }

        private List<View> GetViews(DataTable dtViews)
        {
            List<View> views = new List<View>();
            DataView dwViews = new DataView(dtViews);
            for (int i = 0; i < dwViews.Count; i++)
            {
                View view = new View();
                view.Definition = dwViews[i].Row["Definition"].ToString();
                view.WithCheckOption = bool.Parse(dwViews[i].Row["with_check_option"].ToString());
                view.IsRecompiled = bool.Parse(dwViews[i].Row["is_recompiled"].ToString());
                view.IsSchemaBound = bool.Parse(dwViews[i].Row["is_schema_bound"].ToString());
                view.ObjectId = int.Parse(dwViews[i].Row["object_id"].ToString());
                view.Name = dwViews[i].Row["Name"].ToString();
                view.Schema = dwViews[i].Row["SchemaName"].ToString();
                view.UsesAnsiNull = bool.Parse(dwViews[i].Row["uses_ansi_nulls"].ToString());
                view.UsesQuotedIdentifier = bool.Parse(dwViews[i].Row["uses_quoted_identifier"].ToString());
                views.Add(view);
                OnObjectFetched(new FetchEventArgs(view));
            }
            return views;
        }

        private SortedList<int, string> GetTableDataCompression(DataTable dtTableDataCompression, int tableId)
        {
            SortedList<int, string> dataCompression = new SortedList<int, string>();

            string rowFilter = "Object_Id=" + tableId;
            DataView dwTableDataCompression = new DataView(dtTableDataCompression, rowFilter, "Partition_Number", System.Data.DataViewRowState.CurrentRows);
            for (int i = 0; i < dwTableDataCompression.Count; i++)
            {
                dataCompression.Add(int.Parse(dwTableDataCompression[i].Row["partition_number"].ToString()), dwTableDataCompression[i].Row["data_compression_desc"].ToString());
            }
            return dataCompression;
        }

        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }
}
