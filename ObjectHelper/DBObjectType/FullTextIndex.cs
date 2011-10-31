using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class FullTextIndex
    {

        public FullTextIndex()
        {
            Columns = new List<FulltextIndexColumn>();
        }
        public int ObjectId { get; set; }
        public string ParentObjectName { get; set; }
        public string Schema { get; set; }
        public string KeyIndex { get; set; }
        public string FullTextCatalog { get; set; }
        public string ChangeTrackingState { get; set; }
        public string StopList { get; set; }
        public int StopListId { get; set; }
        public string Filegroup { get; set; }
        public List<FulltextIndexColumn> Columns { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE FULLTEXT INDEX ON ["+Schema+"].["+ ParentObjectName+ "]" + System.Environment.NewLine);
            sbScript.Append("\t(" + Environment.NewLine);
            sbScript.Append("\t)" + Environment.NewLine);
            sbScript.Append("\tKEY INDEX ["+ KeyIndex +"]" + Environment.NewLine);
            if (FullTextCatalog != "")
            {
                if (Filegroup != "")
                {
                    sbScript.Append("\tON (" + FullTextCatalog + ", FILEGROUP " + Filegroup + ")" + System.Environment.NewLine);
                }
                else
                {
                    sbScript.Append("\tON "+FullTextCatalog);
                }
            }
            else
            {
                if (Filegroup != "")
                {
                    sbScript.Append("\t ON FILEGROUP " + Filegroup +  System.Environment.NewLine);
                }
            }

            sbScript.Append("\tWITH CHANGE TRACKING = "+ChangeTrackingState + Environment.NewLine);
            sbScript.Append("\tSTOPLIST = ");
            if (StopListId == 0)
            {
                sbScript.Append("SYSTEM");
            }
            else if (StopListId == -1)
            {
                sbScript.Append("OFF");
            }
            else
            {
                sbScript.Append(StopList);
            }
            return sbScript.ToString().Trim();
        }
    }

    public class FulltextIndexColumn
    {
        public int ObjectId { get; set; }
        public string  ColumnName { get; set; }
        public string  TypeColumnName { get; set; }
        public int LanguageId { get; set; }
    }
}
