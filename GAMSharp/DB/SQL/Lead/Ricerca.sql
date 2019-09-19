select
	p.*,
	p.Cognome || ' ' || p.Nome as RagioneSociale	
from Lead p
where
	p.Cognome like @Cognome and
	p.Nome like @Nome and
	p.LuogoDiNascita like @LuogoDiNascita	
order by
	RagioneSociale