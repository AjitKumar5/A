select 
	o.name as [ParentObjectName],
	s.name as [Schema], 
	fti.has_crawl_completed,
	idx.name as [IndexName],
	fti.object_id,
	ftc.name as FullTextCatalog,
	fti.is_enabled,
	fti.change_tracking_state_desc,
	fts.name as [StopList],
	isnull(fti.stoplist_id,-1) as StopListId,
	ds.name as [FileGroup]
from sys.fulltext_indexes fti
left join sys.fulltext_catalogs ftc on fti.fulltext_catalog_id=ftc.fulltext_catalog_id
left join sys.fulltext_stoplists fts on fti.stoplist_id=fts.stoplist_id
left join sys.data_spaces ds on fti.data_space_id = ds.data_space_id
left join sys.objects o on o.object_id = fti.object_id
left join sys.schemas s on o.schema_id=s.schema_id
left join sys.indexes idx on idx.object_id = o.object_id and idx.index_id=fti.unique_index_id;

select 
	ftc.object_id ,
	c.name as ColumnName,
	c2.name as TypeColumnName,
	ftc.language_id
from sys.fulltext_index_columns ftc
join sys.columns c on c.object_id= ftc.object_id and c.column_id=ftc.column_id
left join sys.columns c2 on c2.object_id= ftc.object_id and c2.column_id=ftc.type_column_id;