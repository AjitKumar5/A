using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Assembly : BaseDBObject
    {
        
        
        public int PermissionSet { get; set; }
        public string Content { get; set; }
        public string Filename { get; set; }
        public string Principal { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE ASSEMBLY [" + Name + "]" + System.Environment.NewLine);
            if (Principal != "")
            {
                sbScript.Append("AUTHORIZATION [" + Principal + "]" + System.Environment.NewLine);
            }
            sbScript.Append("FROM " + Content + System.Environment.NewLine);
            sbScript.Append("WITH PERMISSION_SET=");
            switch (PermissionSet)
            { 
                case 1:
                    sbScript.Append("SAFE");
                    break;
                case 2:
                    sbScript.Append("EXTERNAL_ACCESS");
                    break;
                case 3:
                    sbScript.Append("UNSAFE");
                    break;
            }
            sbScript.Append(System.Environment.NewLine + "GO");
            return sbScript.ToString();
        }
    }
}
