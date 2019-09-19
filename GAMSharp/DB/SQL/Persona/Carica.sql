select
	p.*,
	m.Cognome || ' ' || m.Nome as Madre,
	d.Cognome || ' ' || d.Nome as Padre,
	t.Cognome || ' ' || t.Nome as Tutore	
from Persona p
left outer join Persona m on m.CF = p.Madre_CF
left outer join Persona d on d.CF = p.Padre_CF
left outer join Persona t on t.CF = p.Tutore_CF
where
	p.CF = @CF