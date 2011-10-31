using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace DBCompare
{
    public partial class MDIMain : Form
    {
        private int childFormNumber = 0;

        public MDIMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            ObjectCompare objCompare = new ObjectCompare();
            objCompare.MdiParent = this;
            objCompare.WindowState = FormWindowState.Maximized;
            objCompare.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            LoadProject();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            /*
            Login login = new Login();
            login.MdiParent = this;
            login.Show();*/
            ObjectCompare objCompare = new ObjectCompare();
            objCompare.MdiParent = this;
            objCompare.WindowState = FormWindowState.Maximized;
            objCompare.Show();

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ObjectCompare objCompare = (ObjectCompare)this.ActiveMdiChild;
                objCompare.Save();
                //MessageBox.Show(objCompare.Text);
            }
        }

        private void helpMenu_Click(object sender, EventArgs e)
        {

        }

        private void LoadProject()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.xml)|*.xml|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("ResultSet");
                dt1.Columns.Add("Name");
                dt1.Columns.Add("Type");
                dt1.Columns.Add("Schema");
                dt1.Columns.Add("ObjectDefinition1");
                dt1.Columns.Add("ObjectDefinition2");

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(FileName);
                
                string db1 = "";
                string db2 = "";

                

                foreach(XmlNode xmlNode in xmlDocument.ChildNodes)
                {
                    string aa = xmlNode.Name + " " + xmlNode.Value;
                }

                string srv1 = "";
                string login1 = "";
                string pwd1 = "";

                foreach (XmlNode xmlNode in xmlDocument.GetElementsByTagName("Server1"))
                {
                    foreach (XmlNode xmlServerNode in xmlNode.ChildNodes)
                    {
                        switch (xmlServerNode.Name)
                        { 
                            case "Server":
                                srv1 = xmlServerNode.InnerText;
                                break;
                            case "Database":
                                db1 = xmlServerNode.InnerText;
                                break;
                            case "Login":
                                login1 = xmlServerNode.InnerText;
                                break;
                            case "Password":
                                pwd1 = xmlServerNode.InnerText;
                                break;
                        }
                    }
                }

                ServerConnection conn = new ServerConnection();
                conn.ServerInstance = srv1;
                if (login1 != "")
                {
                    conn.LoginSecure = false;
                    conn.Login = login1;
                    conn.Password = pwd1;
                }
                Server server1 = new Server(conn);

                string srv2 = "";
                string login2 = "";
                string pwd2 = "";

                foreach (XmlNode xmlNode in xmlDocument.GetElementsByTagName("Server2"))
                {
                    foreach (XmlNode xmlServerNode in xmlNode.ChildNodes)
                    {
                        switch (xmlServerNode.Name)
                        {
                            case "Server":
                                srv2 = xmlServerNode.InnerText;
                                break;
                            case "Database":
                                db2 = xmlServerNode.InnerText;
                                break;
                            case "Login":
                                login2 = xmlServerNode.InnerText;
                                break;
                            case "Password":
                                pwd2 = xmlServerNode.InnerText;
                                break;
                        }
                    }
                }

                conn = new ServerConnection();
                conn.ServerInstance = srv2;
                if (login1 != "")
                {
                    conn.LoginSecure = false;
                    conn.Login = login2;
                    conn.Password = pwd2;
                }
                Server server2 = new Server(conn);

                foreach (XmlNode xmlNode in xmlDocument.GetElementsByTagName("Object"))
                {
                    DataRow dr = dt1.NewRow();
                    dr["ResultSet"] = xmlNode.Attributes["ResultSet"].Value;
                    dr["Name"] = xmlNode.Attributes["Name"].Value;
                    dr["Type"] = xmlNode.Attributes["Type"].Value;
                    dr["Schema"] = xmlNode.Attributes["Schema"].Value;
                    dr["ObjectDefinition1"] = xmlNode.Attributes["ObjectDefinition1"].Value;
                    dr["ObjectDefinition2"] = xmlNode.Attributes["ObjectDefinition2"].Value;
                    dt1.Rows.Add(dr);
                }

                ObjectCompare objCompare = new ObjectCompare(false);
                objCompare.SetDatabase1(db1);
                objCompare.SetDatabase2(db2);

                objCompare.SetServer1(server1);
                objCompare.SetServer2(server2);

                objCompare.LoadObjects(dt1);
                objCompare.MdiParent = this;
                objCompare.Show();
                
            }
        }
    }
}
