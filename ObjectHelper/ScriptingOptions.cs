using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ObjectHelper
{
    
    [DefaultProperty("Tables")]
    public class ScriptingOptions : ICloneable
    {
        public ScriptingOptions()
        { 
        
        }
        [Category("Tables"), DisplayName("Script Tables"), DefaultValue(true)]
        public bool Tables{get;set;}

        [ Browsable(false) ]
        public int ServerMajorVersion{get;set;}
        
        public bool ScriptAnsiNulls { get; set; }
        public bool ScriptQuotedIdentifiers { get; set; }





        [Category("Misc")]
        public bool Aggregates { get; set; }
        [Category("Programmability")]
        public bool Assemblies { get; set; }
        [Category("Security")]
        public bool ApplicationRoles { get; set; }
        [Category("Service Broker")]
        public bool BrokerPriorities { get; set; }
        [Category("Tables")]
        public bool CheckConstraints { get; set; }
        [Category("Triggers")]
        public bool CLRTriggers { get; set; }
        [Category("Programmability"), DisplayName("CLR User Defined Functions")]
        public bool CLRUserDefinedFunctions { get; set; }
        [Category("Indexes")]
        public bool ClusteredIndexes { get; set; }

        [Category("Tables")]
        public bool Collation { get; set; }
        [Category("Service Broker")]
        public bool Contracts { get; set; }
        [Category("Storage")]
        public bool DatabaseRoles { get; set; }
        [Category("Tables")]
        public bool DataCompression { get; set; }
        [Category("Tables")]
        public bool DefaultConstraints { get; set; }
        [Category("Programmability")]
        public bool Defaults { get; set; }
        [Category("Triggers")]
        public bool DDLTriggers { get; set; }
        [Category("Triggers")]
        public bool DMLTriggers { get; set; }
        [Category("Tables")]
        public bool ForeignKeys { get; set; }
        [Category("Storage")]
        public bool FullTextCatalogs { get; set; }
        [Category("Storage")]
        public bool FullTextCatalogPath { get; set; }
        [Category("Indexes")]
        public bool FullTextIndexes { get; set; }
        [Category("Storage")]
        public bool FullTextStopLists { get; set;}
        [Category("Service Broker")]
        public bool MessageTypes { get; set; }
        [Category("Tables")]
        public bool NoFileStream { get; set; }
        [Category("Tables")]
        public bool NoIdentities { get; set; }
        [Category("Indexes")]
        public bool NonClusteredIndexes { get; set; }
        [Category("Storage")]
        public bool PartitionFunctions { get; set; }
        [Category("Storage")]
        public bool PartitionSchemes { get; set; }
        [Category("Tables")]
        public bool PrimaryKeys { get; set; }
        [Category("Service Broker")]
        public bool RemoteServiceBindings { get; set; }
        [Category("Service Broker")]
        public bool Routes { get; set; }
        [Category("Programmability")]
        public bool Rules { get; set; }
        [Category("Security")]
        public bool Schemas { get; set; }
        [Category("Service Broker")]
        public bool ServiceQueues { get; set; }
        [Category("Service Broker")]
        public bool Services { get; set; }
        [Category("Programmability"), DisplayName("SQL User Defined Functions")]
        public bool SQLUserDefinedFunctions { get; set; }
        [Category("Programmability"), DisplayName("Stored Procedures")]
        public bool StoredProcedures { get; set; }
        [Category("Misc")]
        public bool Synonyms { get; set; }
        [Category("Tables")]
        public bool UniqueConstraints { get; set; }
        [Category("Types")]
        public bool UserDefinedDataTypes { get; set; }
        [Category("Types")]
        public bool UserDefinedTableTypes { get; set; }
        [Category("Types")]
        public bool UserDefinedTypes { get; set; }
        [Category("Security")]
        public bool Users { get; set; }
        [Category("Programmability")]
        public bool Views { get; set; }
        [Category("Misc")]
        public bool XMLSchemaCollections { get; set; }
        
        //
        /*
         * 
         * DROBIT DALSIE
         * 
        --FT - CLR - table valued function
        --FS - CLR - scalar valued function
         * 
         * 
         */
        //plan guides, user defined table types, user defined data types, user  defined types
        //functions/

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}
