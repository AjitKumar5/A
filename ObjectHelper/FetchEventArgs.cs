using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class FetchEventArgs : EventArgs
    {
        public BaseDBObject DBObject;

        public FetchEventArgs(BaseDBObject obj)
        {
            DBObject = obj;
        }
    }
}
