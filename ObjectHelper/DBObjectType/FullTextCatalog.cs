using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class FullTextCatalog:BaseDBObject
    {
        public string FileGroup{get;set;}
        public string Path{get;set;}
        public string Principal{get;set;}
        public bool IsDefault {get;set;}
        public bool IsAccentSensitive{get;set;}

        public string Script(ScriptingOptions so)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE FULLTEXT CATALOG ["+ Name +"]"+System.Environment.NewLine);
            if (so.ServerMajorVersion < 10)
            {
                if (FileGroup != "")
                {
                    sbScript.Append("\tON FILEGROUP [" + FileGroup + "]," + System.Environment.NewLine);
                }
                if (so.FullTextCatalogPath)
                {
                    if (Path != "")
                    {
                        sbScript.Append("\tIN PATH '" + Path + "'," + System.Environment.NewLine);
                    }
                }
            }
            sbScript.Append("\tWITH ACCENT_SENSITIVITY = ");
            if (IsAccentSensitive)
            {
                sbScript.Append("ON," + System.Environment.NewLine);
            }
            else
            {
                sbScript.Append("OFF,"+System.Environment.NewLine);
            }
            if (IsDefault)
            {
                sbScript.Append("\tAS DEFAULT, " + System.Environment.NewLine);
            }
            sbScript.Append("\tAUTHORIZATION [" + Principal + "]");
            return sbScript.ToString();
        }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE FULLTEXT CATALOG [" + Name + "]" + System.Environment.NewLine);
           
            sbScript.Append("\tWITH ACCENT_SENSITIVITY = ");
            if (IsAccentSensitive)
            {
                sbScript.Append("ON," + System.Environment.NewLine);
            }
            else
            {
                sbScript.Append("OFF," + System.Environment.NewLine);
            }
            if (IsDefault)
            {
                sbScript.Append("\tAS DEFAULT, " + System.Environment.NewLine);
            }
            sbScript.Append("\tAUTHORIZATION [" + Principal + "]");
            return sbScript.ToString();
        }
    }

    
}
