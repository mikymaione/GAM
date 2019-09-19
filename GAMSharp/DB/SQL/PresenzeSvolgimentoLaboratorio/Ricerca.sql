select
	z.Cognome || ' ' || z.Nome as RagioneSociale,
	z.DataDiNascita,
	z.LuogoDiNascita,
	p.*
from PresenzeSvolgimentoLaboratorio p
left outer join Persona z on z.CF = p.Minore_CF
where
	p.IDSvolgimentoLaboratorio = @IDSvolgimentoLaboratorio