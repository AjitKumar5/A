using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

using ObjectHelper;

namespace DBCompare
{
    public partial class Login : Form
    {

        Server server1 = null;
        Server server2 = null;

        public Login()
        {
            InitializeComponent();
        }

        private void lblDatabase1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Resize(object sender, EventArgs e)
        {
            pnlSettings.Location = new Point(
                this.ClientSize.Width / 2 - pnlSettings.Size.Width / 2,
                this.ClientSize.Height / 2 - pnlSettings.Size.Height / 2);
            pnlSettings.Anchor = AnchorStyles.None;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            DataTable dt = SmoApplication.EnumAvailableSqlServers(false);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    cboServer1.Items.Add(dr["Name"].ToString());
                    cboServer2.Items.Add(dr["Name"].ToString());

                }
            }
        }


        private void cmdRefreshServer1_Click(object sender, EventArgs e)
        {
            RefreshServerList(cboServer1);
        }

        private void cmdRefreshServer2_Click(object sender, EventArgs e)
        {
            RefreshServerList(cboServer1);
        }

        private void rbWindowsAuthentication1_Click(object sender, EventArgs e)
        {
            txtUser1.Enabled = false;
            lblUserName1.Enabled = false;
            txtPassword1.Enabled = false;
            lblPassword1.Enabled = false;
        }

        private void rbSQLServerAuthentication1_CheckedChanged(object sender, EventArgs e)
        {
            txtUser1.Enabled = true;
            lblUserName1.Enabled = true;
            txtPassword1.Enabled = true;
            lblPassword1.Enabled = true;
        }

        private void rbWindowsAuthentication2_CheckedChanged(object sender, EventArgs e)
        {
            txtUser2.Enabled = false;
            lblUserName2.Enabled = false;
            txtPassword2.Enabled = false;
            lblPassword2.Enabled = false;
        }

        private void rbSQLServerAuthentication2_CheckedChanged(object sender, EventArgs e)
        {
            txtUser2.Enabled = true;
            lblUserName2.Enabled = true;
            txtPassword2.Enabled = true;
            lblPassword2.Enabled = true;
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

        private void cboDatabase2_Click(object sender, EventArgs e)
        {
            if (cboDatabase2.Items.Count == 0)
            {
                if (rbWindowsAuthentication2.Checked)
                {
                    RefreshDatabaseList(cboDatabase2, cboServer2.Text);
                }
                else
                {
                    RefreshDatabaseList(cboDatabase2, cboServer2.Text, txtUser2.Text, txtPassword2.Text);
                }
            }
        }

        private void cboServer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDatabase1.Items.Clear();
        }

        private void cboServer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDatabase2.Items.Clear();
        }

        private void cmdCompare_Click(object sender, EventArgs e)
        {


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


            if (rbSQLServerAuthentication2.Checked == true)
            {
                ServerConnection conn = new ServerConnection();
                conn.ServerInstance = cboServer2.Text;
                conn.LoginSecure = false;
                conn.Login = txtUser2.Text;
                conn.Password = txtPassword2.Text;
                server2 = new Server(conn);
            }
            else
            {
                ServerConnection conn = new ServerConnection();
                conn.ServerInstance = cboServer2.Text;
                server2 = new Server(conn);
            }
            try
            {
                string srv1 = server1.Information.Version.ToString();
                string srv2 = server2.Information.Version.ToString();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*
            ObjectFetch objFetch = new ObjectFetch(server1.Name, cboDatabase1.Text, txtUser1.Text, txtPassword1.Text,server2.Name, cboDatabase2.Text,txtUser2.Text,txtPassword2.Text);
            //objFetch.Parent = this.Parent;
            objFetch.Show();
            this.Hide();
             */
        }

        public ObjectHelper.ScriptingOptions GetScriptiongOptions()
        {
            ObjectHelper.ScriptingOptions so = new ObjectHelper.ScriptingOptions();
            so.Aggregates = chkAggregates.Checked;
            so.ApplicationRoles = chkApplicationRoles.Checked;
            so.Assemblies = chkAssemblies.Checked;
            so.BrokerPriorities = chkBrokerPriorities.Checked;
            so.ClusteredIndexes = chkClusteredIndexes.Checked;
            so.CLRTriggers = chkCLRTriggers.Checked;
            so.CLRUserDefinedFunctions = chkCLRUserDefinedFunctions.Checked;
            so.CheckConstraints = chkCheckConstraints.Checked;
            so.Collation = chkCollation.Checked;
            so.Contracts = chkContracts.Checked;
            so.DatabaseRoles = chkDatabaseRoles.Checked;
            so.DataCompression = chkDataCompression.Checked;
            so.Defaults = chkDefaults.Checked;
            so.DDLTriggers = chkDDLTriggers.Checked;
            so.DefaultConstraints = chkDefaultConstraints.Checked;
            so.DMLTriggers = chkDMLTriggers.Checked;
            so.ForeignKeys = chkForeignKeys.Checked;
            so.FullTextCatalogPath = chkFullTextCatalogPath.Checked;
            so.FullTextCatalogs = chkFullTextCatalogs.Checked;
            so.FullTextIndexes = chkFullTextIndexes.Checked;
            so.FullTextStopLists = chkFullTextStopLists.Checked;
            so.MessageTypes = chkMessageTypes.Checked;
            so.NoFileStream = chkNoFileStream.Checked;
            so.NoIdentities = chkNoIdentities.Checked;
            so.NonClusteredIndexes = chkNonClusteredIndexes.Checked;
            so.PartitionFunctions = chkPartitionFunctions.Checked;
            so.PartitionSchemes = chkPartitionSchemes.Checked;
            so.PrimaryKeys = chkPrimaryKeys.Checked;
            so.RemoteServiceBindings = chkRemoteServiceBindings.Checked;
            so.Routes = chkRoutes.Checked;
            so.Rules = chkRules.Checked;
            so.Schemas = chkSchemas.Checked;
            so.ServiceQueues = chkServiceQueues.Checked;
            so.Services = chkServices.Checked;
            so.SQLUserDefinedFunctions = chkSQLUserDefinedFunctions.Checked;
            so.StoredProcedures = chkStoredProcedures.Checked;
            so.Synonyms = chkSynonyms.Checked;
            so.Tables = chkTables.Checked;            
            so.UniqueConstraints = chkUniqueConstraints.Checked;
            so.UserDefinedDataTypes = chkUserDefinedDataTypes.Checked;
            so.UserDefinedTableTypes = chkUserDefinedTableTypes.Checked;
            so.UserDefinedTypes = chkUserDefinedTypes.Checked;
            so.Users = chkUsers.Checked;
            so.Views = chkViews.Checked;
            so.XMLSchemaCollections = chkXMLSchemaCollections.Checked;

            return so;
        }


        public Server GetServer1()
        {
            return server1;
        }

        public Server GetServer2()
        {
            return server2;
        }

        public string GetDatabase1()
        {
            return cboDatabase1.Text;
        }

        public string GetDatabase2()
        {
            return cboDatabase2.Text;
        }

        private void cboDatabase1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
