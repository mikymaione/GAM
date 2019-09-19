select	
	z.Descrizione as Laboratorio,
	p.Cognome || ' ' || p.Nome as RagioneSociale,
	l.*
from Educatrice_Laboratorio l
inner join Persona p on p.CF = l.CFEducatrice
inner join Laboratorio z on z.ID = l.IDLaboratorio
where
	l.ID = @ID