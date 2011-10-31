select 
	 smt.message_type_id,
	 smt.name,
	 smt.validation_desc,
	 isnull(sc.name,'') as SchemaCollection,
	 smt.principal_id,
	 p.name as PrincipalName
from sys.service_message_types smt left join sys.xml_schema_collections sc on smt.xml_collection_id=sc.xml_collection_id
join sys.database_principals p on p.principal_id=smt.principal_id;