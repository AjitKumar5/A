SELECT
	obj.object_id,
	obj.name AS [Name],
	SCHEMA_NAME(obj.schema_id) AS [Schema],
	am.assembly_class,
	a.name as Assembly_Name

FROM
	sys.objects AS obj
	join sys.assembly_modules am on obj.object_id=am.object_id
	join sys.assemblies a on am.assembly_id=a.assembly_id
WHERE
(obj.type='AF');