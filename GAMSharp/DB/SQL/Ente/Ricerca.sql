select
	case e.Tipo
		when 'UN' then 'Università'
		when 'SS' then 'Scuola media superiore'
		when 'SM' then 'Scuola media inferiore'
		when 'SC' then 'Scuola elementare'
		when 'OS' then 'Ospedale'
		when 'AL' then 'ASL'
		when 'CO' then 'Comune'
		when 'PR' then 'Provincia'
		when 'ME' then 'Città metropolitana'
		when 'MO' then 'Comunità montanta'
		when 'IS' then 'Comunità isolana'
		when 'UC' then 'Unione di comuni'
		when 'FO' then 'Fondazione'
		when 'SO' then 'Società'
		when 'AS' then 'Associazione'
		when 'CP' then 'Cooperativa'
		when 'SI' then 'Sindacato'
		when 'AC' then 'Associazione di categoria'
		when 'CR' then 'Congregazione religiosa'
		when 'EP' then 'Ente pubblico'
		when 'PV' then 'Ente privato'
		when 'MI' then 'Ministero'
		when 'CF' then 'Ente confessionale'
		when 'ER' then 'Ente religioso'
		when 'PG' then 'Persona giuridica'
		else 'Sconosciuto'
	end as TipoDesc,
	e.*
from Ente e
where
	e.Descrizione like @Descrizione and
	e.Tipo like @Tipo
order by
	e.Descrizione