select 
	c.name,
	idxc.column_id,
	idxc.index_id,
	idxc.is_included_column,
	idxc.object_id,
	idxc.index_column_id,
	idxc.is_descending_key
from sys.index_columns idxc
	join sys.indexes idx on idx.object_id = idxc.object_id and idx.index_id = idxc.index_id
	join sys.columns c on c.object_id=idxc.object_id and c.column_id = idxc.column_id
	join sys.tables t on t.object_id = idx.object_id
where idx.[type]!=0;