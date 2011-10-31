using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Wmi;
using Microsoft.SqlServer.Management.Smo.Broker;
using Microsoft.SqlServer.Management.Common;

using Microsoft.SqlServer.Management.Sdk.Sfc;

using System.Text.RegularExpressions;

using ObjectHelper;
using ObjectHelper.DBObjectType;

namespace DBCompare
{
    public partial class ObjectFetch : Form
    {
        Server server1 = null;
        Server server2 = null;
        string database1 = null;
        string database2 = null;
        string password1 = null;
        string password2 = null;
        string userId1 = null;
        string userId2 = null;

        /*
        List<SqlSmoObject> list1 = new List<SqlSmoObject>();
        List<SqlSmoObject> list2 = new List<SqlSmoObject>();
        */
        static List<string> lstDBObjecTypes = new List<string>();
        Hashtable hsObject1 = new Hashtable();
        Hashtable hsObject2 = new Hashtable();

        DataTable dtObjects = null;
        ObjectHelper.ScriptingOptions scriptOpt = null;

        public ObjectFetch(Server srv1, string db1, string uId1, string pwd1, Server srv2, string db2, string uId2, string pwd2, ObjectHelper.ScriptingOptions so)
        {
            server1 = srv1;
            server2 = srv2;
            database1 = db1;
            database2 = db2;
            userId1 = uId1;
            userId2 = uId2;
            password1 = pwd1;
            password2 = pwd2;
            scriptOpt = so;




            InitializeComponent();
        }

        private delegate void ScriptDelegate(object[] objParams);
        private delegate void CompareDelegate();

        private void ObjectFetch_Load(object sender, EventArgs e)
        {
            object[] scriptingParams1 = new object[6];

            try
            {
                scriptingParams1[0] = server1;
                scriptingParams1[1] = database1;
                scriptingParams1[2] = scriptOpt;
                scriptingParams1[3] = hsObject1;
            }
            catch (Exception err)
            {
                string errrr = err.Message;
            }

            object[] scriptingParams2 = new object[6];

            scriptingParams2[0] = server2;
            scriptingParams2[1] = database2;
            scriptingParams2[2] = scriptOpt;
            scriptingParams2[3] = hsObject2;

            ScriptDelegate scriptDelelegate1 = Script;
            ScriptDelegate scriptDelelegate2 = Script;
            CompareDelegate compareDelegate1 = CompareObjects;

            //Task scriptTask1 = new Task(obj => Script((object[])obj), scriptingParams1);
            try
            {
                Task scriptTask1 = Task.Factory.StartNew(delegate { scriptDelelegate1(scriptingParams1); });
                Task scriptTask2 = scriptTask1.ContinueWith(delegate { scriptDelelegate2(scriptingParams2); });
                Task scriptTask3 = scriptTask2.ContinueWith(delegate { compareDelegate1(); });
                //scriptTask1.Start();
            }
            catch (Exception err)
            {
                string a = err.Message;
            }
        }

        private void Script(object[] scriptParams)
        {
            Server srv = (Server)scriptParams[0];

            string[] lv = new String[2];

            int srvVersion = srv.Version.Major;

            this.Invoke(new MethodInvoker(delegate
            {
                lv[0] = "Connecting to Database: " + scriptParams[1].ToString();
                lv[1] = "";
                lwProgress.Items.Add(new ListViewItem(lv, 0));

            }));
           

            Database db = srv.Databases[scriptParams[1].ToString()];

            Hashtable hsObject = (Hashtable)scriptParams[3];

            this.Invoke(new MethodInvoker(delegate
            {
                ListViewItem lvi = lwProgress.Items[lwProgress.Items.Count - 1];
                lvi.SubItems[1].Text = "OK";
            }));

            string connectionString = srv.ConnectionContext.ConnectionString + "; Initial Catalog='" + scriptParams[1].ToString()+"'";

            ObjectDB objectDB = new ObjectDB(connectionString);


            this.Invoke(new MethodInvoker(delegate
            {
                lv[0] = "Fetching Objects: " ;
                lv[1] = "";
                lwProgress.Items.Add(new ListViewItem(lv, 0));

            }));

            ObjectHelper.ScriptingOptions so = (ObjectHelper.ScriptingOptions)scriptParams[2];
            
            so.ServerMajorVersion = srv.VersionMajor;
            objectDB.ObjectFetched += new ObjectFetchedEventHandler(ObjectFetched);
            objectDB.FetchObjects(so);
            
            this.Invoke(new MethodInvoker(delegate
            {
                ListViewItem lvi = lwProgress.Items[lwProgress.Items.Count - 1];
                lvi.SubItems[1].Text = "OK";
            }));

            ScriptedObject scriptedObj;

            int objectCount = 0;
            objectCount = objectCount + objectDB.Aggregates.Count;
            objectCount = objectCount + objectDB.Assemblies.Count;
            objectCount = objectCount + objectDB.ApplicationRoles.Count;
            objectCount = objectCount + objectDB.BrokerPriorities.Count;
            objectCount = objectCount + objectDB.CLRTriggers.Count;
            objectCount = objectCount + objectDB.CLRUserDefinedFunctions.Count;
            objectCount = objectCount + objectDB.Contracts.Count;
            objectCount = objectCount + objectDB.DatabaseRoles.Count;
            objectCount = objectCount + objectDB.DDLTriggers.Count;
            objectCount = objectCount + objectDB.Defaults.Count;
            objectCount = objectCount + objectDB.DMLTriggers.Count;
            objectCount = objectCount + objectDB.FullTextCatalogs.Count;
            objectCount = objectCount + objectDB.FullTextStopLists.Count;
            objectCount = objectCount + objectDB.Indexes.Count;
            objectCount = objectCount + objectDB.MessageTypes.Count;
            objectCount = objectCount + objectDB.PartitionFunctions.Count;
            objectCount = objectCount + objectDB.PartitionSchemes.Count;
            objectCount = objectCount + objectDB.RemoteServiceBindings.Count;
            objectCount = objectCount + objectDB.Routes.Count;
            objectCount = objectCount + objectDB.Rules.Count;
            objectCount = objectCount + objectDB.Schemas.Count;
            objectCount = objectCount + objectDB.ServiceQueues.Count; 
            objectCount = objectCount + objectDB.Services.Count;
            objectCount = objectCount + objectDB.SQLUserDefinedFunctions.Count;
            objectCount = objectCount + objectDB.StoredProcedures.Count;
            objectCount = objectCount + objectDB.Synonyms.Count;
            objectCount = objectCount + objectDB.Tables.Count;
            objectCount = objectCount + objectDB.UserDefinedDataTypes.Count;
            objectCount = objectCount + objectDB.UserDefinedTableTypes.Count;
            objectCount = objectCount + objectDB.UserDefinedTypes.Count;
            objectCount = objectCount + objectDB.Users.Count;
            objectCount = objectCount + objectDB.Views.Count;
            objectCount = objectCount + objectDB.XMLSchemaCollections.Count;



            foreach (Aggregate obj in objectDB.Aggregates)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "Aggregate";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }
            

            foreach (Assembly obj in objectDB.Assemblies)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Type = "Assembly";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            

            foreach  ( ObjectHelper.DBObjectType.BrokerPriority obj in objectDB.BrokerPriorities)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Type = "BrokerPriority";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (Principal obj in objectDB.ApplicationRoles)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "ApplicationRole";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }
            
            foreach (CLRTrigger obj in objectDB.CLRTriggers)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script(so);
                scriptedObj.Schema = obj.Schema;
                if (obj.IsDatabaseTrigger)
                {
                    scriptedObj.Type = "CLRDDLTrigger";
                }
                else
                {
                    scriptedObj.Type = "CLRDMLTrigger";
                }
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (CLRUserDefinedFunction obj in objectDB.CLRUserDefinedFunctions)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script(so);
                scriptedObj.Schema = obj.Schema;
                if (obj.IsTableValued)
                {
                    scriptedObj.Type = "CLRUserDefinedTableFunction";
                }
                else
                {
                    scriptedObj.Type = "CLRUserDefinedFunction";
                }
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (Contract obj in objectDB.Contracts)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Type = "SERVICECONTRACT";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (Principal obj in objectDB.DatabaseRoles)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "DatabaseRole";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.Trigger obj in objectDB.DDLTriggers)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script(so);
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "SQLDDLTrigger";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.Default obj in objectDB.Defaults)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Type = "Default";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.Trigger obj in objectDB.DMLTriggers)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script(so);
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "SQLDMLTrigger";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.FullTextCatalog obj in objectDB.FullTextCatalogs)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script(so);
                scriptedObj.Type = "FullTextCatalog";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.FullTextStopList obj in objectDB.FullTextStopLists)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Type = "FullTextStopList";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.Index obj in objectDB.Indexes)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script(so);
                scriptedObj.Type = "Index";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.MessageType obj in objectDB.MessageTypes)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Type = "MessageType";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.PartitionFunction obj in objectDB.PartitionFunctions)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Type = "PartitionFunction";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.PartitionScheme obj in objectDB.PartitionSchemes)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Type = "PartitionScheme";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.RemoteServiceBinding obj in objectDB.RemoteServiceBindings)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Type = "REMOTESERVICEBINDING";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.Route obj in objectDB.Routes)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Type = "SERVICEROUTE";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.Rule obj in objectDB.Rules)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "Rule";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.Schema obj in objectDB.Schemas)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Type = "Schema";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.ServiceQueue obj in objectDB.ServiceQueues)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "SERVICEQUEUE";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.Service obj in objectDB.Services)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Type = "Service";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.SQLUserDefinedFunction obj in objectDB.SQLUserDefinedFunctions)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script(so);
                scriptedObj.Schema = obj.Schema;
                if (obj.IsTableValued)
                {
                    scriptedObj.Type = "SQLUserDefinedTableFunction";
                }
                else
                {
                    scriptedObj.Type = "SQLUserDefinedFunction";
                }
                //scriptedObj.Type = "SQLUserDefinedFunction";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.StoredProcedure obj in objectDB.StoredProcedures)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script(so);
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "StoredProcedure";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.Synonym obj in objectDB.Synonyms)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "Synonym";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.Table obj in objectDB.Tables)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script(so);
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "Table";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.UserDefinedDataType obj in objectDB.UserDefinedDataTypes)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "UserDefinedDataType";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.UserDefinedTableType obj in objectDB.UserDefinedTableTypes)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script(so);
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "UserDefinedTableType";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.UserDefinedType obj in objectDB.UserDefinedTypes)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "UserDefinedType";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.Principal obj in objectDB.Users)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "User";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.View obj in objectDB.Views)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script(so);
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "View";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }

            foreach (ObjectHelper.DBObjectType.XMLSchemaCollection obj in objectDB.XMLSchemaCollections)
            {
                scriptedObj = new ScriptedObject();
                scriptedObj.Name = obj.Name;
                scriptedObj.ObjectDefinition = obj.Script();
                scriptedObj.Schema = obj.Schema;
                scriptedObj.Type = "XMLSCHEMACOLLECTION";
                hsObject.Add(Guid.NewGuid().ToString(), scriptedObj);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CompareObjects()
        {
            try
            {
                string[] lv = new String[2];

                List<ScriptedObject> list1 = new List<ScriptedObject>();
                List<ScriptedObject> list2 = new List<ScriptedObject>();

                foreach (object obj in hsObject1.Values)
                {
                    list1.Add((ScriptedObject)obj);
                }

                foreach (object obj in hsObject2.Values)
                {
                    list2.Add((ScriptedObject)obj);
                }

                var query1 = from l1 in list1
                             where !(from l2 in list2
                                     select ((ScriptedObject)l2).Name.ToLower()).Contains(((ScriptedObject)l1).Name.ToLower())
                             select new
                             {
                                 Name = l1.Name,
                                 ObjectDefinition1 = l1.ObjectDefinition,
                                 ObjectDefinition2 = "",
                                 Schema = l1.Schema,
                                 Type = l1.Type
                             };

                this.Invoke(new MethodInvoker(delegate
                {
                    lv[0] = "Objects that exist only in " + database1 + ": " + +query1.Count();
                    lv[1] = "";
                    lwProgress.Items.Add(new ListViewItem(lv, 0));

                }));

                var query2 = from l2 in list2
                             where !(from l1 in list1
                                     select ((ScriptedObject)l1).Name).Contains(((ScriptedObject)l2).Name)
                             select new
                             {
                                 Name = l2.Name,
                                 ObjectDefinition1 = l2.ObjectDefinition,
                                 ObjectDefinition2 = "",
                                 Schema = l2.Schema,
                                 Type = l2.Type
                             };

                this.Invoke(new MethodInvoker(delegate
                {
                    lv[0] = "Objects that exist only in " + database2 + ": " + +query2.Count();
                    lv[1] = "";
                    lwProgress.Items.Add(new ListViewItem(lv, 0));

                }));



                var query3 = from l2 in list1.AsEnumerable()
                             from l1 in list2.AsEnumerable()
                             where ((ScriptedObject)l1).Type + "." + ((ScriptedObject)l1).Name == ((ScriptedObject)l2).Type + "." + ((ScriptedObject)l2).Name
                             &&
                             RemoveWhiteSpaces(((ScriptedObject)l1).ObjectDefinition) == RemoveWhiteSpaces(((ScriptedObject)l2).ObjectDefinition)

                             select new
                             {
                                 Name = l1.Name,
                                 ObjectDefinition1 = l1.ObjectDefinition,
                                 ObjectDefinition2 = l2.ObjectDefinition,
                                 Schema = l1.Schema,
                                 Type = l1.Type
                             };



                this.Invoke(new MethodInvoker(delegate
                {
                    lv[0] = "Objects that exist in both databases and are identical: " + query3.Count();
                    lv[1] = "";
                    lwProgress.Items.Add(new ListViewItem(lv, 0));

                }));


                var query4 = from l1 in list1
                             from l2 in list2
                             where ((ScriptedObject)l1).Type + "." + ((ScriptedObject)l1).Name == ((ScriptedObject)l2).Type + "." + ((ScriptedObject)l2).Name
                             &&
                             RemoveWhiteSpaces(((ScriptedObject)l1).ObjectDefinition) != RemoveWhiteSpaces(((ScriptedObject)l2).ObjectDefinition)
                             select new
                             {
                                 Name = l1.Name,
                                 ObjectDefinition1 = l1.ObjectDefinition,
                                 ObjectDefinition2 = l2.ObjectDefinition,
                                 Schema = l1.Schema,
                                 Type = l1.Type
                             };


                this.Invoke(new MethodInvoker(delegate
                {
                    lv[0] = "Objects that exist in both databases and are different: " + query4.Count();
                    lv[1] = "";
                    lwProgress.Items.Add(new ListViewItem(lv, 0));


                    //"Objects that exist in both databases and are identical (" + query3.Count() + ")"

                }));

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("ResultSet");
                dt1.Columns.Add("Name");
                dt1.Columns.Add("Type");
                dt1.Columns.Add("Schema");
                dt1.Columns.Add("ObjectDefinition1");
                dt1.Columns.Add("ObjectDefinition2");
                try
                {
                    string[] lvObjects = new String[3];
                    this.Invoke(new MethodInvoker(delegate
                    {
                        foreach (var obj in query1)
                        {


                            DataRow dr = dt1.NewRow();
                            dr["ResultSet"] = "1";
                            dr["Name"] = obj.Name;
                            dr["Type"] = obj.Type;
                            if (obj.Schema != null)
                                dr["Schema"] = obj.Schema;
                            else
                                dr["Schema"] = "";
                            dr["ObjectDefinition1"] = obj.ObjectDefinition1;
                            dr["ObjectDefinition2"] = obj.ObjectDefinition2;
                            dt1.Rows.Add(dr);

                            /*
                            if (obj.Schema != null)
                                lvObjects[0] = obj.Schema;
                            else
                                lvObjects[0] = "";
                            lvObjects[1] = obj.Type;
                            lvObjects[2] = obj.Name;
                            //this.Invoke(new MethodInvoker(delegate
                            //{
                                listView1.Items.Add(new ListViewItem(lvObjects, 0, listView1.Groups[0]));
                            //}));*/
                        }

                        foreach (var obj in query2)
                        {
                            DataRow dr = dt1.NewRow();
                            dr["ResultSet"] = "2";
                            dr["Name"] = obj.Name;
                            dr["Type"] = obj.Type;
                            if (obj.Schema != null)
                                dr["Schema"] = obj.Schema;
                            else
                                dr["Schema"] = "";
                            dr["ObjectDefinition1"] = obj.ObjectDefinition1;
                            dr["ObjectDefinition2"] = obj.ObjectDefinition2;
                            dt1.Rows.Add(dr);
                            /*
                            dt1.Rows.Add(dr);
                            if (obj.Schema != null)
                                lvObjects[0] = obj.Schema;
                            else
                                lvObjects[0] = "";
                            lvObjects[1] = obj.Type;
                            lvObjects[2] = obj.Name;
                            */
                            //this.Invoke(new MethodInvoker(delegate
                            //{
                            //listView1.Items.Add(new ListViewItem(lvObjects, 0, listView1.Groups[1]));
                            //}));
                        }

                        foreach (var obj in query3)
                        {
                            DataRow dr = dt1.NewRow();
                            dr["ResultSet"] = "3";
                            dr["Name"] = obj.Name;
                            dr["Type"] = obj.Type;
                            if (obj.Schema != null)
                                dr["Schema"] = obj.Schema;
                            else
                                dr["Schema"] = "";
                            dr["ObjectDefinition1"] = obj.ObjectDefinition1;
                            dr["ObjectDefinition2"] = obj.ObjectDefinition2;
                            dt1.Rows.Add(dr);
                            /*
                            if (obj.Schema != null)
                                lvObjects[0] = obj.Schema;
                            else
                                lvObjects[0] = "";
                            lvObjects[1] = obj.Type;
                            lvObjects[2] = obj.Name;
                            //this.Invoke(new MethodInvoker(delegate
                            //{
                                listView1.Items.Add(new ListViewItem(lvObjects, 0, listView1.Groups[2]));
                            //}));*/
                        }

                        foreach (var obj in query4)
                        {
                            DataRow dr = dt1.NewRow();
                            dr["ResultSet"] = "4";
                            dr["Name"] = obj.Name;
                            dr["Type"] = obj.Type;
                            if (obj.Schema != null)
                                dr["Schema"] = obj.Schema;
                            else
                                dr["Schema"] = "";
                            dr["ObjectDefinition1"] = obj.ObjectDefinition1;
                            dr["ObjectDefinition2"] = obj.ObjectDefinition2;
                            dt1.Rows.Add(dr);
                            /*
                            if (obj.Schema != null)
                                lvObjects[0] = obj.Schema;
                            else
                                lvObjects[0] = "";
                            lvObjects[1] = obj.Type;
                            lvObjects[2] = obj.Name;

                            listView1.Items.Add(new ListViewItem(lvObjects, 0, listView1.Groups[3]));*/

                        }
                        dt1.TableName = "Objects";

                        dtObjects = dt1;
                        this.DialogResult = DialogResult.OK;

                    }));

                }
                catch (Exception err)
                {
                    string aa = err.Message;
                }

                int ColumnIndex = 0;

                DataSet ds = new DataSet();
                ds.Tables.Add(dt1);

                this.Invoke(new MethodInvoker(delegate
                {
                    /*
                    outlookGrid1.AutoGenerateColumns = false;
                    outlookGrid1.Columns.Add("ResultSet", "ResultSet");
                    outlookGrid1.Columns.Add("Name", "Name");
                    outlookGrid1.Columns.Add("Type", "Type");
                    */
                    //outlookGrid1.BindData(ds, "Objects");

                    /*
                    this.outlookGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

                    DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
                    dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
                    dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
                    dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                    dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                    this.outlookGrid1.DefaultCellStyle = dataGridViewCellStyle2;
                    this.outlookGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

                    DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
                    dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                    dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
                    dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
                    dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                    dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                    this.outlookGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

                    this.outlookGrid1.GridColor = System.Drawing.SystemColors.Control;
                    this.outlookGrid1.RowTemplate.Height = 19;
                    this.outlookGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
                    this.outlookGrid1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    this.outlookGrid1.RowHeadersVisible = false;
                    this.outlookGrid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    this.outlookGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.outlookGrid1.AllowUserToAddRows = false;
                    this.outlookGrid1.AllowUserToDeleteRows = false;
                    this.outlookGrid1.AllowUserToResizeRows = false;
                    this.outlookGrid1.EditMode = DataGridViewEditMode.EditProgrammatically;
                    this.outlookGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    //this.outlookGrid1.ClearGroups(); // reset

                    ListSortDirection direction = ListSortDirection.Ascending;
                    outlookGrid1.GroupTemplate.Column = outlookGrid1.Columns[0];
                    outlookGrid1.Sort(new DataRowComparer(0, direction));
                    outlookGrid1.Columns[0].Visible = false;*/

                }));



                /*
                // set the group template to use, e.g. to sort alphabetically:

                outlookGrid1.GroupTemplate = new OutlookGridAlphabeticGroup();

                // specify the column the Group will be associated with:

                outlookGrid1.GroupTemplate.Column = outlookGrid1.Columns[ColumnIndex];

                // all groups in the list will be collapsed,

                // so only the groups are displayed, not the items

                outlookGrid1.GroupTemplate.Column.Collapsed = true;

                // sort the grid using the DataRowComparer object

                // the DataRowComparer constructor takes two parameters,

                // the column that will be sorted on, and the direction

                // in which to sort (ascending or descending)

                outlookGrid1.Sort(new DataRowComparer(ColumnIndex, direction));*/

            }
            catch (Exception err)
            {
                string aa = err.Message;
            }
        }

        public DataTable GetDatabaseObjectsTable()
        {
            return dtObjects;
        }

        private string RemoveWhiteSpaces(string s)
        {
            Regex r = new Regex(@"\s+");

            // C.
            // Strip multiple spaces.
            string s3 = r.Replace(s, @" ");
            //Console.WriteLine(s3);

            // D.
            // Strip multiple spaces.
            return s3;
        }

        private void ObjectFetched(object sender, FetchEventArgs e)
        {
            Console.WriteLine(e.DBObject.Name);

            this.Invoke(new MethodInvoker(delegate
            {
                ListViewItem lvi = lwProgress.Items[lwProgress.Items.Count - 1];
                lvi.SubItems[0].Text = "Fetching objects: " + e.DBObject.Name;
            }));
        }
    }

    public class DataRowComparer : IComparer
    {
        ListSortDirection direction;
        int columnIndex;

        public DataRowComparer(int columnIndex, ListSortDirection direction)
        {
            this.columnIndex = columnIndex;
            this.direction = direction;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {

            DataRow obj1 = (DataRow)x;
            DataRow obj2 = (DataRow)y;
            return string.Compare(obj1[columnIndex].ToString(), obj2[columnIndex].ToString()) * (direction == ListSortDirection.Ascending ? 1 : -1);
        }
        #endregion
    }
}

