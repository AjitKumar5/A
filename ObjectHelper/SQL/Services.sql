select 
	s.name,
	s.service_id,
	p.name as [Principal],
	sq.name as ServiceQueue,
	sch.name as ServiceQueueSchema
from sys.services s
join sys.database_principals p on p.principal_id=s.principal_id
join sys.service_queues sq on sq.object_id = s.service_queue_id
join sys.schemas sch on sq.schema_id = sch.schema_id;

select 
	sc.name,
	scu.service_id
from sys.service_contracts sc
join sys.service_contract_usages scu on sc.service_contract_id=scu.service_contract_id;
