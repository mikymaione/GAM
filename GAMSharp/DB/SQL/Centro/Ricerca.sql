select	
	e.Descrizione as DescEnte,
	l.*
from Centro l
left outer join Ente e on e.ID = l.Csst