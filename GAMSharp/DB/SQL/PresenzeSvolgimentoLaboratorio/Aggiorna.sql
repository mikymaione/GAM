update PresenzeSvolgimentoLaboratorio set
	Presente = @Presente
where
	IDSvolgimentoLaboratorio = @IDSvolgimentoLaboratorio and
	Minore_CF = @Minore_CF