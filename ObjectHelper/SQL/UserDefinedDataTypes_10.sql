SELECT
st.name AS [Name],
sst.name AS [Schema],
st.user_type_id AS [ID],
CAST(CASE WHEN baset.name IN (N'nchar', N'nvarchar') AND st.max_length <> -1 THEN st.max_length/2 ELSE st.max_length END AS int) AS [Length],
CAST(st.precision AS int) AS [NumericPrecision],
CAST(st.scale AS int) AS [NumericScale],
st.max_length AS [MaxLength],
st.is_nullable AS [Nullable],
(case when st.default_object_id = 0 then N'' else schema_name(def.schema_id) end) AS [DefaultSchema],
baset.name AS [SystemType],
[Description] = ISNULL((select value from fn_listextendedproperty ('MS_Description', 'SCHEMA', sst.name, 'TYPE', st.name, null, null)),N'')
FROM
sys.types AS st
INNER JOIN sys.schemas AS sst ON sst.schema_id = st.schema_id
LEFT OUTER JOIN sys.database_principals AS s1st ON s1st.principal_id = ISNULL(st.principal_id, (TYPEPROPERTY(QUOTENAME(SCHEMA_NAME(st.schema_id)) + '.' + QUOTENAME(st.name), 'OwnerId')))
LEFT OUTER JOIN sys.types AS baset ON (baset.user_type_id = st.system_type_id and baset.user_type_id = baset.system_type_id) or ((baset.system_type_id = st.system_type_id) and (baset.user_type_id = st.user_type_id) and (baset.is_user_defined = 0) and (baset.is_assembly_type = 1)) 
LEFT OUTER JOIN sys.objects AS def ON def.object_id = st.default_object_id
LEFT OUTER JOIN sys.objects AS rul ON rul.object_id = st.rule_object_id
WHERE
(st.schema_id!=4 and st.system_type_id!=240 and st.user_type_id != st.system_type_id and st.is_table_type != 1)