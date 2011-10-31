using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Principal : BaseDBObject
    {
        
        public string Type { get; set; }
        
        public string Schema { get; set; }
        public string OwningPrincipalName { get; set; }
        public string Login { get; set; }
        public string Certificate { get; set; }
        public string AsymmetricKey { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();

            switch (Type)
            { 
                case "A":
                    return ScriptApplicationRole();
                case "R":
                    return ScriptDatabaseRole();
                case "S":
                    return ScriptUser();
            
            }

            return sbScript.ToString();
        }

        private string ScriptApplicationRole()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE APPLICATION ROLE [" + Name + "]" + System.Environment.NewLine);
            sbScript.Append("WITH PASSWORD='fsdjfhkfasjhfkhjhklsaf465'");
            if (Schema != "")
            {
                sbScript.Append(", DEFAULT_SCHEMA=[" + Schema + "]");
            }
            sbScript.Append(System.Environment.NewLine+"GO");
            return sbScript.ToString();
        }

        private string ScriptDatabaseRole()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE ROLE [" + Name + "]" + System.Environment.NewLine);
            
            if (OwningPrincipalName != "")
            {
                sbScript.Append("AUTHORIZATION [" + OwningPrincipalName+"]" );
            }
            sbScript.Append(System.Environment.NewLine + "GO");
            return sbScript.ToString();
        }

        private string ScriptUser()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE USER [" + Name + "]" + System.Environment.NewLine);

            if (AsymmetricKey != "" || Certificate != "" || Login != "")
            {
                sbScript.Append("FOR ");
                if (AsymmetricKey != "")
                {
                    sbScript.Append("ASYMMETRIC KEY " + AsymmetricKey);
                }
                else if (Certificate != "")
                {
                    sbScript.Append("CERTIFICATE " + Certificate);
                }
                else
                {
                    sbScript.Append("LOGIN " + Login);
                }
            }
            else
            {
                sbScript.Append("\tWITHOUT LOGIN");
            }
            if (Schema != "")
            {
                sbScript.Append(System.Environment.NewLine +  "\tWITH DEFAULT_SCHEMA=[" + Schema+"]");
            }
            sbScript.Append(System.Environment.NewLine + "GO");
            return sbScript.ToString();
        }
    }
}
