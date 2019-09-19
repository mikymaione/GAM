select
	coalesce (
		p.Cognome || ' ' || p.Nome,
		m.Cognome || ' ' || m.Nome,
		z.Cognome || ' ' || z.Nome,
		e.Descrizione
	) as Descrizione,
	l.*
from PlenariaPresenze l
left outer join Persona p on p.CF = l.Persona_CF
left outer join Persona m on m.CF = l.Minore_CF
left outer join Lead z on z.ID = l.Lead_ID
left outer join Ente e on e.ID = l.Ente_ID
where
	l.IDPlenaria = @IDPlenaria
order by
	Descrizione