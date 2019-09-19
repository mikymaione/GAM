select
	p.Cognome || ' ' || p.Nome as RagioneSociale,	
	sc.Descrizione as Scaglione,
	s.Descrizione as ScuolaDesc,
	e.Descrizione as SoggettoInvianteDesc,
	l.*
from Minore l
inner join Persona p on p.CF = l.Persona_CF
left outer join Ente s on s.ID = l.Scuola
left outer join Ente e on e.ID = l.SoggettoInviante
left outer join ScaglioniDiEta sc on sc.ID = l.IDScaglioniDiEta
where
	l.Persona_CF = @Persona_CF