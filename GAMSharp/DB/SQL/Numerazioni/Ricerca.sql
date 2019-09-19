select
	c.Descrizione,
	n.*
from Numerazioni n
inner join Centro c on c.Codice = n.CodiceCentro
order by
	c.Descrizione