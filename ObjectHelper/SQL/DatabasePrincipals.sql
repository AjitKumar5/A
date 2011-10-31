select 
	dbp.name,
	dbp.type,
	dbp.type_desc,
	dbp.principal_id,
	dbp.default_schema_name,
	[OwningPrincipalName] = dbp2.name
from sys.database_principals dbp left join sys.database_principals dbp2 on dbp.owning_principal_id=dbp2.principal_id;