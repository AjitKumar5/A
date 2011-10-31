select 
	c.object_id,	
	c.column_Id,    
	c.name, 
	c.is_nullable,	
	c.is_computed,
	c.is_identity,
	c.is_filestream,
	c.is_replicated,
	c.is_rowguidcol,
	c.is_sparse,
	c.is_column_set,
	--[Definition] =ISNULL((select [definition] from sys.computed_columns cc where cc.object_id=c.object_id and cc.column_id=c.column_id),N'') ,
	[Definition] =ISNULL(cc.[definition],N'') ,
	[Type]=(select name from sys.types where sys.types.user_type_id=c.user_type_id), 
	[tablename]=t.name, 
	[Precision] = columnproperty(t.object_id,c.name,'Precision'), 
	[Collation] = c.collation_name,
	c.Scale, 
	[Description] = ISNULL((select value from fn_listextendedproperty ('MS_Description', 'schema', s.name, 'table', t.name, 'column', c.name)) ,N''),
	[IdentitySeed] = ISNULL(ic.seed_value,0),
	[IdentityIncrement] = ISNULL(ic.increment_value,0),
	[IsPersisted] = CAST(ISNULL(cc.is_persisted,0) as bit),
	[IsUnique] =  ( 
		(select COUNT(*) from sys.index_columns idxc 
		left join sys.indexes idx on idx.object_id=idxc.object_id and idx.index_id=idxc.index_id	
		--where idxc.object_id=c.object_id and c.column_id=idxc.column_id and idx.is_unique=1)
		where idxc.object_id=c.object_id and c.column_id=idxc.column_id and idx.is_unique_constraint=1)
	
	),
	[IsUserDefinedDataType]=st.is_user_defined

from sys.columns c 
join sys.tables t on c.object_id=t.object_id 
join sys.schemas s on t.schema_id=s.schema_id
Left Join sys.identity_columns ic on c.object_id=ic.object_id and c.column_id=ic.column_id
Left Join sys.computed_columns cc on c.object_id=cc.object_id and cc.column_id=c.column_id
Left Join sys.types st on c.system_type_id=st.system_type_id and c.user_type_id=st.user_type_id;