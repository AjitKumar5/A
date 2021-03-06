﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class DefaultConstraint:BaseDBObject
    {
        public string Column { get; set; }
        public string Definition { get; set; }
        public int ParentObjectId { get; set; }
        public string Table { get; set; }
        public string Schema { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("ALTER TABLE [" + Schema + "].[" + Table + "] ADD CONSTRAINT [" + Name + "] DEFAULT " + Definition + " FOR [" + Column + "]");
            return sbScript.ToString();
        }
    }
}
