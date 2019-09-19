select
	e.Descrizione as Scaglione,
	p.Cognome || ' ' || p.Nome as Responsabile,
	count(s.ID) as Svolgimenti,
	l.ID,
	l.Inizio,
	l.Fine,
	l.Descrizione
from Laboratorio l
left outer join Persona p on p.CF = l.CFResponsabile
left outer join SvolgimentoLaboratorio s on s.IDLaboratorio = l.ID
left outer join ScaglioniDiEta e on e.ID = l.IDScaglioniDiEta
group by
	Scaglione,
	Responsabile,
	l.ID,
	l.Inizio,
	l.Fine,
	l.Descrizione
order by
	l.Inizio desc, l.Fine desc