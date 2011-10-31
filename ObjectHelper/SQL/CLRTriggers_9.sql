﻿select
	t.object_id,
	o.object_id,
	t.name,
	s.name as [Schema],
	[ParentObjectName] = isnull(o.name,'' ),
	[ParentObjectSchema] = ss.name, --isnull(OBJECT_SCHEMA_NAME(o.object_id),''),
	t.parent_class,
	t.object_id,
	t.is_disabled,
	t.is_not_for_replication,
	t.is_instead_of_trigger,
	am.assembly_class,
	am.assembly_method,
	a.name as [AssemblyName],
	dp.name as [ExecuteAs],
	IsAfter = cast(IsNull(ObjectProperty(t.object_id,'ExecIsAfterTrigger'),'0')as bit),
	IsDatabaseTrigger = CAST(case when t.parent_class = 0 then 1 else 0 end AS bit) 
from sys.triggers t join sys.assembly_modules am on t.object_id=am.object_id
	join sys.assemblies a on a.assembly_id = am.assembly_id
	left join sys.objects o on o.object_id = t.object_id--parent_id
	left join sys.database_principals dp on am.execute_as_principal_id=dp.principal_id 
	join sys.schemas s on s.schema_id = o.schema_id
	join sys.objects oo on oo.object_id = t.parent_id
	join sys.schemas ss on ss.schema_id = oo.schema_id
where t.type='TA'
select object_id,type_desc from sys.trigger_events;