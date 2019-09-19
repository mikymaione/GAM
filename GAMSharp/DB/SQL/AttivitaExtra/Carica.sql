select		
	i.Descrizione as DescEnte,
	m.Cognome || ' ' || m.Nome as Minore,
	p.*
from AttivitaExtra p
left outer join Ente i on i.ID = p.IDEnte
left outer join Persona m on m.CF = p.Minore_CF
where	
	p.ID = @ID