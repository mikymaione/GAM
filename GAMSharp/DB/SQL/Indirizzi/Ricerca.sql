select
	*
from Indirizzi
where
	Entita_Tipo = @Entita_Tipo and
	Entita_Key = @Entita_Key
order by
	Tipo