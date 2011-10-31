select 
	fts.stoplist_id,
	fts.name,
	dp.name as [Principal]
from sys.fulltext_stoplists fts
join sys.database_principals dp on dp.principal_id=fts.principal_id;

select stoplist_id, stopword,language from sys.fulltext_stopwords;