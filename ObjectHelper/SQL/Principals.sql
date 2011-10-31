select 
	dbp.name,
	dbp.type,
	dbp.type_desc,
	dbp.principal_id,
	dbp.default_schema_name,
	[OwningPrincipalName] = dbp2.name,
	ISNULL(suser_sname(dbp.sid),N'') AS [Login],
	ISNULL(cert.name,N'') AS [Certificate],
	ISNULL(ak.name,N'') AS [AsymmetricKey],
	[Description] = ISNULL((select value from fn_listextendedproperty ('MS_Description', 'DATABASE_PRINCIPAL', dbp.name, null, null, null, null)),N'')
from sys.database_principals dbp left join sys.database_principals dbp2 on dbp.owning_principal_id=dbp2.principal_id
LEFT OUTER JOIN sys.certificates AS cert ON cert.sid = dbp.sid
LEFT OUTER JOIN sys.asymmetric_keys AS ak ON ak.sid = dbp.sid;