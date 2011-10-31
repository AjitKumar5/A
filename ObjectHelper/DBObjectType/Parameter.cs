using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Parameter:BaseDBObject
    {
        public string Type { get; set; }
        public int ParameterId { get; set; }
        public int MaxLength { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }
        public bool IsOutput { get; set; }
        public string DefaultValue { get; set; }
        public bool IsXmlDocument { get; set; }
        public int XmlCollectionId { get; set; }
        public bool IsReadOnly { get; set; }
        public string XmlCollection { get; set; }

        public string Script(ScriptingOptions so)
        {
            StringBuilder sbScript = new StringBuilder();
            return sbScript.ToString();
        }
    }
}
