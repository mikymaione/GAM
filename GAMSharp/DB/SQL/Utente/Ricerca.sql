select
	p.Cognome || ' ' || p.Nome as RagioneSociale,
	l.*
from Utente l
inner join Persona p on p.CF = l.Persona_CF
order by
	l.Email