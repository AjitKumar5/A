select 
v.object_id,
v.name,
s.name as SchemaName,
m.uses_ansi_nulls,
m.uses_quoted_identifier,
v.with_check_option,
m.is_recompiled,
m.is_schema_bound,
m.[definition]
 from sys.views v join sys.sql_modules m on v.object_id=m.object_id 
 join sys.schemas s on s.schema_id=v.schema_id;