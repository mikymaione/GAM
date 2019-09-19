select	
	l.*
from PEI l
where
	l.Minore_CF = @Minore_CF
order by
	l.Data_Creazione desc