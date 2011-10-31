select 
	t.Object_Id,
	t.Name,
	s.name as [Schema],
	t.is_replicated AS [Replicated],
	t.uses_ansi_nulls AS [AnsiNullsStatus],
	CAST(OBJECTPROPERTY(t.object_id,N'IsQuotedIdentOn') AS bit) AS [QuotedIdentifierStatus],
	CAST(0 as bit) AS [ChangeTrackingEnabled],
	CAST(0 AS bit) AS [TrackColumnsUpdatedEnabled],
	[FileGroup]=ISNULL((
		SELECT 
			f.[name] 
		FROM 
			sys.indexes i INNER JOIN sys.filegroups f ON i.data_space_id = f.data_space_id 
			INNER JOIN sys.all_objects o ON i.[object_id] = o.[object_id] 
			inner join sys.tables tt on i.object_id=tt.object_id 
			where i.[type]=0 and i.object_id=t.object_id
		),N'' ),	
	[PartitionScheme] = ISNULL((
		select ps.name
		from
			sys.tables tt
		LEFT JOIN sys.indexes idx on idx.object_id=tt.object_id
		LEFT JOIN sys.data_spaces ds on idx.data_space_id=ds.data_space_id
		LEFT JOIN sys.partition_schemes ps on ps.data_space_id = ds.data_space_id
		where ds.type='PS' and tt.object_id=t.object_id
		),N''),
	[FileStreamGroup] = ISNULL((select ds.name from sys.data_spaces ds where ds.data_space_id=t.filestream_data_space_id and ds.type='FD' ),N''),
	[FileStreamPartitionScheme]= ISNULL((select ds.name from sys.data_spaces ds where ds.data_space_id=t.filestream_data_space_id and ds.type='PS' ),N''),
	[TextFileGroup]=ISNULL(dstext.name,N''),
	[Description] = ISNULL((select value from fn_listextendedproperty ('MS_Description', 'schema', s.name, 'table', t.name, NULL, NULL)),N''),
	[PartitionedColumn] = ISNULL(
	
		(select c.name
	from
		sys.columns c
		LEFT JOIN sys.indexes i on i.object_id = c.object_id
		LEFT JOIN sys.index_columns ic on ic.object_id=c.object_id
		LEFT JOIN sys.data_spaces ds on i.data_space_id=ds.data_space_id
		LEFT JOIN sys.partition_schemes ps on ps.data_space_id=ds.data_space_id
		where i.index_id=ic.index_id
		and c.object_id=t.object_id
		and ds.type='PS'
		and ic.column_id=c.column_id),N''
	)
from
	sys.tables t
	LEFT OUTER JOIN sys.schemas s on s.schema_id=t.schema_id
	LEFT OUTER JOIN sys.data_spaces AS dsText  ON t.lob_data_space_id = dstext.data_space_id
	--LEFT OUTER JOIN sys.change_tracking_tables AS ctt ON ctt.object_id = t.object_id ;