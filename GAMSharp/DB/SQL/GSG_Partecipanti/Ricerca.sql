select
	p.Cognome || ' ' || p.Nome as RagioneSociale,
	l.*
from GSG_Partecipanti l
inner join Persona p on p.CF = l.CF
where
	l.IDGruppoSostegnoG = @IDGruppoSostegnoG
order by
	RagioneSociale