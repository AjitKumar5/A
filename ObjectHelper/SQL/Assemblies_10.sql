select 
	a.assembly_id,
	a.name,
	a.permission_set,
	sys.fn_varbintohexstr(af.content) as content,
	af.name as [FileName],
	p.name AS [PrincipalName],
	[Description] = ISNULL((select value from fn_listextendedproperty ('MS_Description', 'assembly', a.name, null, null, NULL, NULL)),N'')
from sys.assemblies a join sys.assembly_files af on a.assembly_id = af.assembly_id
left join sys.database_principals p on p.principal_id = a.principal_id
where a.is_user_defined=1;