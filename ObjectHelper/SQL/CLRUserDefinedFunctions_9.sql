select 
	obj.object_id,
	obj.name,
	SCHEMA_NAME(obj.schema_id) as [Schema],
	a.name as Assembly_Name,
	am.assembly_class,
	am.assembly_method,
	ret_param.name as TableVariableName,
	isnull(am.execute_as_principal_id,0) as execute_as_principal_id,
	p.name as execute_as_principal_id_name,
	am.null_on_null_input,
	cast((case when obj.type='FT' then 1  else 0  end) as bit)as Is_Table_Valued
from sys.all_objects obj
join sys.assembly_modules am on am.object_id=obj.object_id
join sys.assemblies a on am.assembly_id = a.assembly_id
LEFT OUTER JOIN sys.all_parameters AS ret_param ON ret_param.object_id = obj.object_id and ret_param.is_output = 1
left join sys.database_principals p on p.principal_id = am.execute_as_principal_id
where obj.type in ('FT','FS');

select 
c.object_id,
c.name,
c.column_id,
t.name as [DataType],
c.scale,
[Precision] = columnproperty(c.object_id,c.name,'Precision'),
CAST(CASE WHEN t.name IN (N'nchar', N'nvarchar') AND c.max_length <> -1 THEN c.max_length/2 ELSE c.max_length END AS int) AS [Length],
cast(0 as bit) is_sparse
from sys.columns c 
join sys.all_objects o on o.object_id = c.object_id
join sys.types t on t.user_type_id = c.user_type_id
where o.type in ('FT','FS');
