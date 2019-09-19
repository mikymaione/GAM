insert into PresenzeSvolgimentoLaboratorio (
	IDSvolgimentoLaboratorio,
	Minore_CF,
	Presente,	
	CFCreazione,
	CFModifica
)
select
	s.ID,
	Persona_CF,
	'false',
	@CFCreazione,
	@CFModifica
from SvolgimentoLaboratorio	s
inner join Laboratorio l on l.ID = s.IDLaboratorio
inner join Minore m on m.IDScaglioniDiEta = l.IDScaglioniDiEta
where
	s.ID = @IDSvolgimentoLaboratorio