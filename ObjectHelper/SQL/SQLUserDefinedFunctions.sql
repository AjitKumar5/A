select 
	udf.object_id,
	udf.name,
	s.name as [Schema],
	CAST(OBJECTPROPERTYEX(udf.object_id, 'IsQuotedIdentOn') AS bit) AS [QuotedIdentifierStatus],
	CAST(OBJECTPROPERTYEX(udf.object_id, 'IsDeterministic') AS bit) AS [IsDeterministic],
	ISNULL(smudf.definition, ssmudf.definition) AS [Definition],
	cast((case when udf.type='IF' then 1  else 0  end) as bit)as Is_Table_Valued,
	udf.type
from sys.all_objects udf 
join sys.schemas s on s.schema_id=udf.schema_id
LEFT OUTER JOIN sys.sql_modules AS smudf ON smudf.object_id = udf.object_id
LEFT OUTER JOIN sys.system_sql_modules AS ssmudf ON ssmudf.object_id = udf.object_id
where udf.type in ('FN','IF','TF')  and udf.is_ms_shipped=0;