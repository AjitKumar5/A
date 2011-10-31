select
	ftc.fulltext_catalog_id,
	ftc.name,
	ftc.is_default,
	ftc.is_accent_sensitivity_on,
	ftc.path,
	ds.name as FileGroup,
	p.name as Principal
from sys.fulltext_catalogs ftc
left join sys.data_spaces ds on ftc.data_space_id=ds.data_space_id
left join sys.database_principals p on ftc.principal_id=p.principal_id;