select 
	cp.priority_id,
	cp.name,
	cp.priority,
	isnull(s.name,'ANY') as LocalService,
	isnull(cp.remote_service_name,'ANY') as RemoteService,
	isnull(sc.name,'ANY') as [Contract]
from sys.conversation_priorities cp 
left join sys.service_contracts sc on sc.service_contract_id=cp.service_contract_id
left join sys.services s on s.service_id=cp.local_service_id;