select 

	idx.object_id,
	idx.name ,
	idx.index_id,
	idx.type,
	idx.type_desc,
	idx.is_unique,
	idx.data_space_id,
	idx.ignore_dup_key,
	idx.is_primary_key,
	idx.is_unique_constraint,
	idx.fill_factor,
	idx.is_padded,
	idx.is_disabled,
	idx.is_hypothetical,
	idx.allow_row_locks,
	idx.allow_page_locks,
	cast(0 as bit) as has_filter,
	'' as filter_definition,
	[ObjectName] = o.name,
	[ObjectSchema] = sc.name,
	ds.type as DataSpaceType,
	ds.name as DataSpace,
	
	[PartitionedColumn] = ISNULL(
	
		(select c.name
	from
		sys.columns c
		LEFT JOIN sys.indexes i on i.object_id = c.object_id
		LEFT JOIN sys.index_columns ic on ic.object_id=c.object_id
		LEFT JOIN sys.data_spaces ds on i.data_space_id=ds.data_space_id
		LEFT JOIN sys.partition_schemes ps on ps.data_space_id=ds.data_space_id
		where i.index_id=ic.index_id
		and c.object_id=idx.object_id
		and ds.type='PS'
		and ic.column_id=c.column_id),N''
	),--,ps.name as [PartitionScheme],
	no_recompute=isnull(s.no_recompute,0),
	[FileStreamFileGroup]=
	(
		select fsds.name from sys.tables t join sys.data_spaces fsds on t.filestream_data_space_id=fsds.data_space_id
		where t.object_id=idx.object_id
	),
	[Description] = 
	
	case
		when ISNULL((select value from fn_listextendedproperty ('MS_Description', 'SCHEMA', sc.name, 'TABLE', o.name, 'INDEX', idx.name)),N'')!=''
			then ISNULL((select value from fn_listextendedproperty ('MS_Description', 'SCHEMA', sc.name, 'TABLE', o.name, 'INDEX', idx.name)),N'')
		else
			ISNULL((select value from fn_listextendedproperty ('MS_Description', 'SCHEMA', sc.name, 'VIEW', o.name, 'INDEX', idx.name)),N'')
	end,
	[ConstraintDescription] = 
	case
		when ISNULL((select value from fn_listextendedproperty ('MS_Description', 'SCHEMA', sc.name, 'TABLE', o.name, 'CONSTRAINT', idx.name)),N'')!=''
			then ISNULL((select value from fn_listextendedproperty ('MS_Description', 'SCHEMA', sc.name, 'TABLE', o.name, 'CONSTRAINT', idx.name)),N'')
		else
			ISNULL((select value from fn_listextendedproperty ('MS_Description', 'SCHEMA', sc.name, 'VIEW', o.name, 'CONSTRAINT', idx.name)),N'')
	end
from sys.indexes idx 
left join sys.data_spaces ds on ds.data_space_id=idx.data_space_id
--left join sys.partition_schemes ps on ps.data_space_id = ds.data_space_id
join sys.objects o on idx.object_id=o.object_id
left join sys.stats s on s.object_id = idx.object_id and s.stats_id = idx.index_id
left join sys.schemas sc on o.schema_id = sc.schema_id
--join sys.objects o on idx.object_id=o.object_id
where idx.[type]!=0 and o.type in ('V','U');