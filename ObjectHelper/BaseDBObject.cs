using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class BaseDBObject
    {
        public BaseDBObject()
        { 
        }

        public string Name
        {
            get;
            set;
        }
        public int ObjectId
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}
