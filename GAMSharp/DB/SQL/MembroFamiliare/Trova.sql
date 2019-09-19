select
	l.IDNucleoFamiliare
from MembroFamiliare l
left outer join Persona p on p.CF = l.Persona_CF
left outer join Persona m on m.CF = l.Minore_CF
left outer join Lead z on z.ID = l.Lead_ID
where	
	l.Persona_CF = @Persona_CF or
	l.Minore_CF = @Minore_CF or
	l.Lead_ID = @Lead_ID