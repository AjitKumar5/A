using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Default:BaseDBObject
    {
        public Default()
        {
            Definition = String.Empty;
        }

        public string Definition { get; set; }

        public string Script()
        {
            return Definition;
        }
    }
}
