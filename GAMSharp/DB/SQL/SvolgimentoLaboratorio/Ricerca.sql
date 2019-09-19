select		
	l.*
from SvolgimentoLaboratorio l
where
	l.IDLaboratorio = @IDLaboratorio
order by
	l.Dalle desc,
	l.Alle desc