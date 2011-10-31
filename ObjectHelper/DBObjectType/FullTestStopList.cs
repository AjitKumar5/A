using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    /* STOPLISTS are supperted only under compatibility lever 100*/
    public class FullTextStopList:BaseDBObject
    {
        public FullTextStopList()
        {
            StopWords = new List<FullTextStopWord>();
        }
        public string Principal { get; set; }
        public List<FullTextStopWord> StopWords { get; set; }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE FULLTEXT STOPLIST ["+Name+"]" + System.Environment.NewLine);
            sbScript.Append("AUTHORIZATION [" + Principal + "];"+System.Environment.NewLine);
            foreach (FullTextStopWord stopWord in StopWords)
            {
                if (stopWord.StopWord.IndexOf("'") > -4)
                {
                    stopWord.StopWord = stopWord.StopWord.Replace("'", "''");
                }
                
                sbScript.Append("ALTER FULLTEXT STOPLIST ["+Name+"] ADD '"+stopWord.StopWord+"' LANGUAGE '"+stopWord.Language+"';"+System.Environment.NewLine);
            }
            return sbScript.ToString().Trim(); ;
        }
    }

    public class FullTextStopWord
    {
        public int StopListId { get; set; }
        public string StopWord { get; set; }
        public string Language { get; set; }
    }
}
