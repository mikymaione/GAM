select
	coalesce (
		p.Cognome || ' ' || p.Nome,
		m.Cognome || ' ' || m.Nome,
		z.Cognome || ' ' || z.Nome
	) as Descrizione,
	c.Cognome || ' ' || c.Nome as IlCapoFamiglia,
	l.*
from MembroFamiliare l
left outer join NucleoFamiliare n on n.ID = l.IDNucleoFamiliare
left outer join Persona c on c.CF = n.Capofamiglia
left outer join Persona p on p.CF = l.Persona_CF
left outer join Persona m on m.CF = l.Minore_CF
left outer join Lead z on z.ID = l.Lead_ID
where
	l.IDNucleoFamiliare = @IDNucleoFamiliare	
order by
	IlCapoFamiglia,
	l.Figura,
	Descrizione