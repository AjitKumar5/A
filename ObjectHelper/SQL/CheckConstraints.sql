select 
	dc.object_id, 
	dc.parent_object_id,
	dc.name,
	dc.definition,
	c.name as ColumnName,
	t.name as TableName,
	s.name as [Schema]
from 
	sys.check_constraints dc join sys.columns c on dc.parent_object_id=c.object_id and dc.parent_column_id=c.column_id
	left join sys.tables t on t.object_id=dc.parent_object_id
	left join sys.schemas s on s.schema_id = t.schema_id;