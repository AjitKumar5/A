using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjectHelper;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Threading.Tasks;

namespace DBDocumentation
{

    

    public partial class Main : Form
    {
        ObjectHelper.ScriptingOptions so = new ObjectHelper.ScriptingOptions();
        
        private delegate void ScriptDelegate(object[] objParams);

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

            propertyGrid1.SelectedObject = so;
        }

        private void cmdCompare_Click(object sender, EventArgs e)
        {
            string aa = so.Tables.ToString();
            Server server1 = null;

            if (rbSQLServerAuthentication1.Checked == true)
            {
                ServerConnection conn = new ServerConnection();
                conn.ServerInstance = cboServer1.Text;
                conn.LoginSecure = false;
                conn.Login = txtUser1.Text;
                conn.Password = txtPassword1.Text;
                server1 = new Server(conn);
            }
            else
            {
                ServerConnection conn = new ServerConnection();
                conn.ServerInstance = cboServer1.Text;
                server1 = new Server(conn);

                
            }
            try
            {
                ScriptDelegate scriptDelelegate1 = Script;

                object[] scriptingParams = new object[2];
                scriptingParams[0] = server1;
                scriptingParams[1] = cboDatabase1.Text;

                Task scriptTask1 = Task.Factory.StartNew(delegate { scriptDelelegate1(scriptingParams); });
               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Script(object[] scriptParams)
        {
            Server server = (Server)scriptParams[0];
            string dbName = scriptParams[1].ToString();
            so.ServerMajorVersion = server.VersionMajor;
            string connectionString = server.ConnectionContext.ConnectionString + "; Initial Catalog='" + dbName + "'";
            ObjectDB objectDB = new ObjectDB(connectionString);
            objectDB.ObjectFetched += new ObjectFetchedEventHandler(ObjectFetched);
            objectDB.FetchObjects(so);


            string text = System.IO.File.ReadAllText(@"Template\toc.html");
            StringBuilder sbToc = new StringBuilder();
            sbToc.AppendLine("<ol class=\"tree\">");
            if (so.Tables)
            {
                List<BaseDBObject> lst = objectDB.Tables.ConvertAll(obj=>(BaseDBObject)obj);
                sbToc.AppendLine(GenerateTocList(lst, "Tables"));
            }


            if (so.Views)
            {
                List<BaseDBObject> lst = objectDB.Views.ConvertAll(obj => (BaseDBObject)obj);
                sbToc.AppendLine(GenerateTocList(lst, "Views"));
            }

            if (so.CLRTriggers || so.DDLTriggers)
            {
                List<BaseDBObject> lst = objectDB.CLRTriggers.ConvertAll(obj => (BaseDBObject)obj);
                foreach (ObjectHelper.DBObjectType.Trigger trigger in objectDB.DDLTriggers.ConvertAll(obj => (BaseDBObject)obj))
                {
                    lst.Add(trigger);
                }

                sbToc.AppendLine(GenerateTocList(lst, "Triggers"));
            }

            if (so.StoredProcedures)
            {
                List<BaseDBObject> lst = objectDB.StoredProcedures.ConvertAll(obj => (BaseDBObject)obj);
                sbToc.AppendLine(GenerateTocList(lst, "Stored Procedures"));
            }

            if (so.CLRUserDefinedFunctions || so.SQLUserDefinedFunctions)
            {
                List<BaseDBObject> lst = objectDB.CLRUserDefinedFunctions.ConvertAll(obj => (BaseDBObject)obj);
                foreach (ObjectHelper.DBObjectType.SQLUserDefinedFunction function in objectDB.SQLUserDefinedFunctions.ConvertAll(obj => (BaseDBObject)obj))
                {
                    lst.Add(function);
                }
                
                sbToc.AppendLine(GenerateTocList(lst, "Functions"));
            }

            if (so.DMLTriggers)
            {
                List<BaseDBObject> lst = objectDB.DMLTriggers.ConvertAll(obj => (BaseDBObject)obj);
                sbToc.AppendLine(GenerateTocList(lst, "DML Triggers"));
            }

            string bodyPos = text.Substring(0,text.IndexOf("<body"));
            int startBodyPos = text.IndexOf(">", text.IndexOf("<body"));
            int endBodyPos = text.IndexOf("</body>");
            StringBuilder sbToc2 = new StringBuilder();
            sbToc2.AppendLine(text.Substring(0,startBodyPos+1));
            sbToc.AppendLine("</ol>");
            sbToc2.AppendLine(sbToc.ToString());
            sbToc2.AppendLine(text.Substring(endBodyPos));

            
            System.IO.TextWriter tw = new System.IO.StreamWriter(System.IO.Path.Combine(txtOutputForder.Text,"Documentation.html"));
            System.IO.File.Copy(@"Template\_styles.css", System.IO.Path.Combine(txtOutputForder.Text, "_styles.css"), true);
            System.IO.File.Copy(@"Template\document.png", System.IO.Path.Combine(txtOutputForder.Text, "document.png"),true);
            System.IO.File.Copy(@"Template\folder-horizontal.png", System.IO.Path.Combine(txtOutputForder.Text, "folder-horizontal.png"), true);
            System.IO.File.Copy(@"Template\toggle-small-expand.png", System.IO.Path.Combine(txtOutputForder.Text, "toggle-small-expand.png"), true);
            System.IO.File.Copy(@"Template\toggle-small.png", System.IO.Path.Combine(txtOutputForder.Text, "toggle-small.png"), true);

            // write a line of text to the file
            tw.WriteLine(sbToc2.ToString());

            // close the stream
            tw.Close();



        }

        private string GenerateTocList(List<BaseDBObject>  lst, string type)
        {
            StringBuilder sbToc = new StringBuilder();

            if (lst.Count > 0)
            {
                sbToc.AppendLine("\t<li>");
                sbToc.AppendLine("\t\t<label for=\"item" + type + "\">"+type+"</label><input type=\"checkbox\"  id=\"item" + type + "\" />");
                sbToc.AppendLine("\t\t\t<ol>");
                foreach (BaseDBObject obj in lst)
                {
                    sbToc.AppendLine("\t\t\t\t<li class=\"file\"><a href=\"" + obj.ObjectId + ".html\">" + obj.Name + "</a></li>");
                    GenerateObjectDocumentationFile(obj);
                }

                sbToc.AppendLine("\t\t\t</ol>");
                sbToc.AppendLine("\t</li>");
            }
            return sbToc.ToString();

        }

        private void GenerateObjectDocumentationFile(BaseDBObject obj)
        {
            
            string aaa = obj.GetType().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtOutputForder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void ObjectFetched(object sender, FetchEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                lblStatus.Text = "Fetching objects: " + e.DBObject.Name;
            }));
        }

        private void cmdRefreshServer1_Click(object sender, EventArgs e)
        {
            RefreshServerList(cboServer1);
        }

        private void RefreshServerList(ComboBox cbo)
        {
            cbo.Items.Clear();
            DataTable dt = SmoApplication.EnumAvailableSqlServers(false);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cbo.Items.Add(dr["Name"].ToString());
                }
            }
        }

        private void cboServer1_Click(object sender, EventArgs e)
        {
            if (cboServer1.Items.Count == 0)
            { 
                RefreshServerList(cboServer1);
            }
        }

        private void rbWindowsAuthentication1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword1.Enabled = false;
            txtUser1.Enabled = false;
            lblUserName1.Enabled = false;
            lblPassword1.Enabled = false;
        }

        private void rbSQLServerAuthentication1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword1.Enabled = true;
            txtUser1.Enabled = true;
            lblUserName1.Enabled = true;
            lblPassword1.Enabled = true;
        }

        private void cboDatabase1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboDatabase1_Click(object sender, EventArgs e)
        {
            if (cboDatabase1.Items.Count == 0)
            {
                if (rbWindowsAuthentication1.Checked)
                {
                    RefreshDatabaseList(cboDatabase1, cboServer1.Text);
                }
                else
                {
                    RefreshDatabaseList(cboDatabase1, cboServer1.Text, txtUser1.Text, txtPassword1.Text);
                }
            }
        }

        private void RefreshDatabaseList(ComboBox cbo, string server)
        {
            try
            {
                cbo.Items.Clear();
                ServerConnection conn = new ServerConnection();
                conn.ServerInstance = server;
                Server srv = new Server(conn);

                foreach (Database db in srv.Databases)
                {
                    cbo.Items.Add(db.Name);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDatabaseList(ComboBox cbo, string server, string login, string password)
        {
            try
            {
                cbo.Items.Clear();
                ServerConnection conn = new ServerConnection();
                conn.ServerInstance = server;
                conn.LoginSecure = false;
                conn.Login = login;
                conn.Password = password;
                Server srv = new Server(conn);

                foreach (Database db in srv.Databases)
                {
                    cbo.Items.Add(db.Name);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
