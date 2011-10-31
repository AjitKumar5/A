SELECT
	atypes.name AS [Name],
	satypes.name AS [Schema],
	atypes.user_type_id AS [ID],
	asmbl.name AS [AssemblyName],
ISNULL(atypes.assembly_class,N'') AS [ClassName]
FROM
sys.assembly_types AS atypes
INNER JOIN sys.assemblies AS asmbl ON (asmbl.assembly_id = atypes.assembly_id) and (atypes.is_user_defined = 1)
INNER JOIN sys.schemas AS satypes ON satypes.schema_id = atypes.schema_id
LEFT OUTER JOIN sys.database_principals AS s1atypes ON s1atypes.principal_id = ISNULL(atypes.principal_id, (TYPEPROPERTY(QUOTENAME(SCHEMA_NAME(atypes.schema_id)) + '.' + QUOTENAME(atypes.name), 'OwnerId')));