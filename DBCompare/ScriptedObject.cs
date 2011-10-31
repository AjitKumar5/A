using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Sdk.Sfc;

namespace DBCompare
{
    public class ScriptedObject
    {
        public string Name="";
        public string Schema="";
        public string Type="";
        public DateTime DateLastModified;
        public string ObjectDefinition="";
        public Urn Urn;
        
    }
}
