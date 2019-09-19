select
	e.Descrizione as Scaglione,
	p.Cognome || ' ' || p.Nome as Responsabile,
	l.*
from Laboratorio l
left outer join Persona p on p.CF = l.CFResponsabile
left outer join ScaglioniDiEta e on e.ID = l.IDScaglioniDiEta
where
	l.ID = @ID