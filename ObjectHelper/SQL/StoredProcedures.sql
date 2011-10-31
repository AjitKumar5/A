select 
	p.object_id,
	p.name,
	s.name as SchemaName,
	p.is_auto_executed,
	p.is_execution_replicated,
	p.is_repl_serializable_only,
	OBJECT_DEFINITION(p.object_id) as [Definition],
	m.uses_ansi_nulls,
	m.uses_quoted_identifier
from sys.procedures p left join sys.schemas s on p.schema_id = s.schema_id
join sys.sql_modules m on m.object_id=p.object_id;