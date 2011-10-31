select  
	[Type]=(select name from sys.types where sys.types.user_type_id=p.user_type_id),
	p.object_id,
	p.name,
	p.parameter_id,
	p.max_length,
	[precision] = columnproperty(p.object_id,p.name,'Precision'), 
	p.scale,
	p.is_output,
	[Default_Value] = ISNULL( p.default_value,N''),
	p.is_xml_document,
	p.xml_collection_id,
	p.is_readonly,
	isnull(xmlsc.name,'') as [xmlcollection],
	[Description] = 
	
	case
		when ISNULL((select value from fn_listextendedproperty ('MS_Description', 'SCHEMA', s.name, 'PROCEDURE', o.name, 'PARAMETER', p.name)),N'')!=''
			then ISNULL((select value from fn_listextendedproperty ('MS_Description', 'SCHEMA', s.name, 'PROCEDURE', o.name, 'PARAMETER', p.name)),N'')
		else
			ISNULL((select value from fn_listextendedproperty ('MS_Description', 'SCHEMA', s.name, 'FUNCTION', o.name, 'PARAMETER', p.name)),N'')
	end
from sys.parameters p
left join sys.xml_schema_collections xmlsc on p.xml_collection_id = xmlsc.xml_collection_id
left join sys.objects o on p.object_id = o.object_id
left join sys.schemas s on o.schema_id = s.schema_id;