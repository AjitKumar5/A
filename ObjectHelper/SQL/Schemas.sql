select 
	s.name,
	s.schema_id,
	p.name as Principal,
	[Description] = ISNULL((select value from fn_listextendedproperty ('MS_Description', 'SCHEMA', s.name, null, null, null, null)),N'')
from sys.schemas s
join sys.database_principals p
on p.principal_id = s.principal_id;