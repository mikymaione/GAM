select
	*
from InfoAggiuntive
where
	Entita_Tipo = @Entita_Tipo and
	Entita_Key = @Entita_Key
order by
	DataModifica desc