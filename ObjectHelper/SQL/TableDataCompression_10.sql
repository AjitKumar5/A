select 
	p.object_id,
	p.data_compression_desc,
	p.partition_number
from sys.partitions p join sys.tables t on t.object_id=p.object_id and p.index_id=0;