using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class RemoteServiceBinding : BaseDBObject
    {
        public string Principal { get; set; }
        public string RemoteService { get; set; }
        public bool IsAnonymousOn { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE REMOTE SERVICE BINDING ["+ Name +"]"+System.Environment.NewLine);
            sbScript.Append("TO SERVICE [" + RemoteService + "]" + System.Environment.NewLine);
            sbScript.Append("WITH USER [" + Principal+ "]");
            if (IsAnonymousOn)
            {
                sbScript.Append(", ANONYMOUS=ON");
            }
            return sbScript.ToString();
        }
    }
}
