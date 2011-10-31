using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class MessageType:BaseDBObject
    {
        public string Validation { get; set; }
        public string SchemaCollection { get; set; }
        public string PrincipalName { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE MESSAGE TYPE [" + Name+"]" + System.Environment.NewLine);
            sbScript.Append("\tAUTHORIZATION [" + PrincipalName + "]" + System.Environment.NewLine);
            sbScript.Append("\tVALIDATION = ");
            switch (Validation)
            { 
                case "XML":
                    if(SchemaCollection=="")
                        sbScript.Append("WELL_FORMED_XML");
                    else
                        sbScript.Append("VALID_XML WITH SCHEMA COLLECTION [" + SchemaCollection+"]");
                    break;
                case "EMPTY":
                    sbScript.Append(Validation);
                    break;
                case "BINARY":
                    sbScript.Append("NONE");
                    break;
            
            }

            return sbScript.ToString();
        }
    }
}
