select 
	fk.name,
	fk.object_id,
	SchemaName=s.name,
	fk.parent_object_id,
	fk.is_disabled,
	fk.is_not_for_replication,
	fk.is_not_trusted,
	fk.delete_referential_action_desc,
	fk.update_referential_action_desc
from sys.foreign_keys fk join sys.schemas s on fk.schema_id=s.schema_id;

select 
	fkc.constraint_object_id,
	fkc.constraint_column_id,
	ParentColumnName =  c1.name,
	ReferencedObjectName = o2.name,
	ReferencedObjectId = o2.object_id,
	ReferencedColumnName =c2.name,
	ReferencedObjectSchema = s.name
from sys.foreign_key_columns fkc 
	join sys.objects o on o.object_id = fkc.parent_object_id
	join sys.columns c1 on c1.object_id = o.object_id and c1.column_id = fkc.parent_column_id
	join sys.objects o2 on o2.object_id = fkc.referenced_object_id
	join sys.columns c2 on c2.object_id = o2.object_id and c2.column_id = fkc.referenced_column_id
	join sys.schemas s on s.schema_id = o2.schema_id
order by fkc.constraint_object_id,fkc.constraint_column_id;