select 
	s.name,
	s.object_id,
	s.base_object_name,
	sch.name as [Schema]
from sys.synonyms s left join sys.schemas sch on s.schema_id=sch.schema_id;