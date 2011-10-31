select 
	t.name,
	[SCHEMA] = isnull(OBJECT_SCHEMA_NAME(t.object_id),''),
	t.object_id,
	t.parent_class,
	t.is_disabled,
	t.is_not_for_replication,
	t.is_instead_of_trigger,
	[ParentObjectSchema] = isnull(OBJECT_SCHEMA_NAME(o.object_id),''),
	OBJECT_DEFINITION(t.object_id) AS [Definition],
	[ParentObjectName] = isnull(o.name,'' ),
	IsAfter = cast(IsNull(ObjectProperty(t.object_id,'ExecIsAfterTrigger'),'0')as bit),
	IsDatabaseTrigger = CAST(case when t.parent_class = 0 then 1 else 0 end AS bit)
from sys.triggers t left join sys.objects o on o.object_id = t .parent_id

 where t.type='TR';