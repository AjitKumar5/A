select 
	r.name,
	r.route_id,
	r.remote_service_name,
	r.broker_instance,
	isnull(cast(r.lifetime as varchar(30) ),'') as [LifeTime],
	r.address,
	r.mirror_address,
	p.name as [Principal] 
from sys.routes r
left join sys.database_principals p on r.principal_id = p.principal_id;