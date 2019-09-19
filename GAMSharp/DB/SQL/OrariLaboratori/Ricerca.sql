select	
	l.Da_Ore || '.' || l.Da_Minuti || iif(l.Da_Minuti > 9, '', '0') as Inizio,
	l.A_Ore || '.' || l.A_Minuti || iif(l.A_Minuti > 9, '', '0') as Fine,
	decode(l.GiornoSettimana,
		0, 'Domenica',
		1, 'Lunedì',
		2, 'Martedì',
		3, 'Mercoledì',
		4, 'Giovedì',
		5, 'Venerdì',
		6, 'Sabato',
		'Sconosciuto'
	) as Giorno,
	l.*
from OrariLaboratori l
where
	l.IDLaboratorio = @IDLaboratorio
order by
	l.GiornoSettimana,
	l.Da_Ore,
	l.Da_Minuti,
	l.A_Ore,
	l.A_Minuti