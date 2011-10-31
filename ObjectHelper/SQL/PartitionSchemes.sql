select
ps.name,
pf.name as [PartitionFunction]
from sys.partition_schemes ps
join sys.partition_functions pf on ps.function_id = pf.function_id;

SELECT
sps.name,
sf.name AS [FileGroup],
sdd.destination_id AS [ID]

FROM
sys.partition_schemes AS sps
INNER JOIN sys.partition_functions AS spf ON sps.function_id = spf.function_id	
INNER JOIN sys.destination_data_spaces AS sdd ON sdd.partition_scheme_id = sps.data_space_id and sdd.destination_id <= spf.fanout
INNER JOIN sys.filegroups AS sf ON sf.data_space_id = sdd.data_space_id

ORDER BY name,
[ID] ASC;