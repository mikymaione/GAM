select	
	p.Cognome || ' ' || p.Nome as RagioneSociale,
	l.*
from NucleoFamiliare l
left outer join Persona p on p.CF = l.Capofamiglia
where
	l.ID = @ID