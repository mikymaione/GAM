select
	p.Cognome || ' ' || p.Nome as RagioneSociale,	
	l.*
from ListaDiAttesa l
left outer join Persona p on p.CF = l.Minore_CF

where
	l.Minore_CF = @Minore_CF