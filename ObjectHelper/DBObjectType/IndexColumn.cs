using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class IndexColumn:BaseDBObject
    {
        public int IndexId { get; set; }
        public int ColumnId { get; set; }
        public int IndexColumnId { get; set; }
        public bool IsIncluded { get; set; }
        public bool IsDescendingKey { get; set; }
    }
}
