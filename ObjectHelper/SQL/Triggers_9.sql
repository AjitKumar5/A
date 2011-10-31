select 
	t.name,
	s.name as [SCHEMA],
	t.object_id,
	t.parent_class,
	t.is_disabled,
	t.is_not_for_replication,
	t.is_instead_of_trigger,
	isnull(s2.name,'')as [ParentObjectSchema],
	OBJECT_DEFINITION(t.object_id) AS [Definition],
	[ParentObjectName] = isnull(o.name,'' ),
	IsAfter = cast(IsNull(ObjectProperty(t.object_id,'ExecIsAfterTrigger'),'0')as bit),
	IsDatabaseTrigger = CAST(case when t.parent_class = 0 then 1 else 0 end AS bit)
from sys.triggers t left join sys.objects o on o.object_id = t .parent_id
left join sys.objects o2 on o2.object_id=t.object_id
left join sys.schemas s on s.schema_id = o2.schema_id
left join sys.schemas s2 on s2.schema_id = o.schema_id
 where t.type='TR';