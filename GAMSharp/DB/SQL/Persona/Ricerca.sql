select
	p.*,
	p.Cognome || ' ' || p.Nome as RagioneSociale,	
	case p.Sesso
		when  'F' then 'Donna'
		else 'Uomo'
	end as Sex,
	m.Cognome || ' ' || m.Nome as Madre,
	d.Cognome || ' ' || d.Nome as Padre,
	t.Cognome || ' ' || t.Nome as Tutore	
from Persona p
left outer join Persona m on m.CF = p.Madre_CF
left outer join Persona d on d.CF = p.Padre_CF
left outer join Persona t on t.CF = p.Tutore_CF
where
	p.Cognome like @Cognome and
	p.Nome like @Nome and
	p.LuogoDiNascita like @LuogoDiNascita and
	p.CF like @CF
order by
	RagioneSociale