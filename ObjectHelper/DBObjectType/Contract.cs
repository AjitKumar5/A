using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper.DBObjectType
{
    public class Contract:BaseDBObject
    {
        public string PrincipalName { get; set; }
        public List<ContractMessageType> MessageTypes { get; set; }

        public Contract()
        {
            MessageTypes = new List<ContractMessageType>();
        }

        public string Script()
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("CREATE CONTRACT ["+ Name + "]"+System.Environment.NewLine);
            if (PrincipalName != "dbo")
            {
                sbScript.Append("AUTHORIZATION [" + PrincipalName + "]" + System.Environment.NewLine);
            }
            sbScript.Append("(" + System.Environment.NewLine);

            for (int i = 0; i < MessageTypes.Count; i++)
            {
                if (MessageTypes[i].IsSentByInitiator && MessageTypes[i].IsSentByTarget)
                {
                    sbScript.Append("\t[" + MessageTypes[i].Name + "]" + System.Environment.NewLine);
                    sbScript.Append("\t\t SENT BY INITIATOR," + System.Environment.NewLine);
                    sbScript.Append("\t[" + MessageTypes[i].Name + "]" + System.Environment.NewLine);
                    sbScript.Append("\t\t SENT BY TARGET");
                }
                else
                {
                    if (MessageTypes[i].IsSentByInitiator)
                    {
                        sbScript.Append("\t[" + MessageTypes[i].Name + "]" + System.Environment.NewLine);
                        sbScript.Append("\t\t SENT BY INITIATOR");
                    }
                    else if (MessageTypes[i].IsSentByTarget)
                    {
                        sbScript.Append("\t[" + MessageTypes[i].Name + "]" + System.Environment.NewLine);
                        sbScript.Append("\t\t SENT BY TARGET");
                    }
                }
                if (i != MessageTypes.Count - 1)
                {
                    sbScript.Append(",");
                }
                sbScript.AppendLine();
            }

            sbScript.Append(")");
            return sbScript.ToString();
        }
        
    }

    public class ContractMessageType
    {
        public string Name{get;set;}
        public bool IsSentByInitiator{get;set;}
        public bool IsSentByTarget{get;set;}
        public int ServiceContractId { get; set; }
    }
}
