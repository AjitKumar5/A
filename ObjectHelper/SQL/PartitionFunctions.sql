select
	pf.name,
	pf.function_id,
	pf.boundary_value_on_right,
	[Type]= t.name ,
	pp.max_length,
	pp.precision,
	pp.scale
from sys.partition_functions pf join sys.partition_parameters pp on pp.function_id=pf.function_id
join sys.types t on pp.system_type_id = t.system_type_id;

select 
	function_id,
	boundary_id,
	parameter_id,
	value
from sys.partition_range_values;