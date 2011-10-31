select 
	rsb.name,
	rsb.remote_service_binding_id,
	rsb.remote_service_name,
	p.name as [Principal],
	rsb.is_anonymous_on
from sys.remote_service_bindings rsb 
join sys.database_principals p on rsb.principal_id = p.principal_id;