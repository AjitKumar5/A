select 
	sc.name,
	sc.service_contract_id,
	dp.name as PrincipalName
from sys.service_contracts sc join sys.database_principals dp on dp.principal_id=sc.principal_id;

select 
	smt.name,
	scmu.is_sent_by_initiator,
	scmu.is_sent_by_target,
	scmu.service_contract_id
from sys.service_contract_message_usages scmu join sys.service_message_types smt on smt.message_type_id= scmu.message_type_id;