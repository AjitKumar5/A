using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk.Sfc;

using System.Configuration;
using System.Data;

namespace DBCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string serverstr = "POSTA";
            string user = "kanasz";
            string password = "chaaron";
            ServerConnection conn = new ServerConnection(serverstr, user, password);
            try
            {
                Server server = new Server(conn);

                /*
                foreach(Table table in db.Tables)
                {
                    Console.WriteLine(table.Name);
                }*/

                DataTable dt = new System.Data.DataTable();

                dt.Columns.Add("Name");

                List<SqlSmoObject> list = new List<SqlSmoObject>();

                server.SetDefaultInitFields(typeof(StoredProcedure), "IsSystemObject");
                Database db = server.Databases["Dynamic"];
                foreach (StoredProcedure sp in db.StoredProcedures)
                {
                    if (!sp.IsSystemObject)
                    {
                        //Console.WriteLine(sp.Name);
                        list.Add(sp);
                        //Console.WriteLine(sp.TextBody);
                        dt.Rows.Add(sp.Name);

                    }
                }

                dataGridView1.DataSource = dt;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
