select
	p.Cognome || ' ' || p.Nome as RagioneSociale,
	e.Descrizione as Scaglione,
	l.*
from Educatrice l
inner join Persona p on p.CF = l.Persona_CF
inner join ScaglioniDiEta e on e.ID = l.IDScaglioniDiEta
where
	l.Persona_CF = @Persona_CF