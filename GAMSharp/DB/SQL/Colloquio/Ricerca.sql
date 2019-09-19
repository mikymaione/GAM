select	
	l.*
from Colloquio l
where
	l.Minore_CF = @Minore_CF
order by
	l.Inizio desc