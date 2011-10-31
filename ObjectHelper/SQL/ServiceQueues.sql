select 
	q.name,
	q.object_id,
	p.name as Principal, --if 0 than SELF
	q.execute_as_principal_id,
	s.name as [Schema],
	q.max_readers,
	q.activation_procedure,
	q.is_activation_enabled,
	q.is_receive_enabled,
	q.is_enqueue_enabled,
	q.is_retention_enabled,
	fg.name AS [FileGroup]
from sys.service_queues q
left join sys.database_principals p on q.execute_as_principal_id=p.principal_id
join sys.schemas s on s.schema_id = q.schema_id
INNER JOIN sys.internal_tables AS it ON q.object_id = it.parent_object_id
INNER JOIN sys.indexes AS ind ON ind.object_id = it.object_id and ind.index_id < 2
INNER JOIN sys.filegroups AS fg ON fg.data_space_id = ind.data_space_id;