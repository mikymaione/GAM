select
	e.Descrizione as DescEnte,
	p.Cognome || ' ' || p.Nome as RagioneSociale,
	l.*
from AssistenteSociale l
left outer join Lead p on p.ID = l.IDLead
left outer join Ente e on e.ID = l.Csst
where
	l.IDLead = @IDLead