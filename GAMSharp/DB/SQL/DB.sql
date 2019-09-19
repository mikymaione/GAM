--GAM# - Gestione Accoglienza Minori
--Copyright (C) 2015 [MAIONE MIKY]
--This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
--This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
--You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 

--port 3050
--SYSDBA
--masterkey
create table Persona
(	
	CF varchar(16) not null primary key,
	
	Cognome varchar(100) not null,	
	Nome varchar(100) not null,
	DataDiNascita date not null,
	LuogoDiNascita varchar(100) not null,
	NazioneDiNascita varchar(100),
	Nazionalita varchar(100),
	Sesso varchar(1) not null,	
	
	Professione varchar(250),
	AdesioneGSG char(1),
	
	Padre_CF varchar(16),
	Madre_CF varchar(16),
	Tutore_CF varchar(16),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF),
	
	foreign key (Padre_CF) references Persona(CF),
	foreign key (Madre_CF) references Persona(CF),
	foreign key (Tutore_CF) references Persona(CF)
);

create table ScaglioniDiEta 
(
	ID int not null primary key,
	Descrizione VARCHAR(250) not null, 
	Da int not null,
	A int not null,
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator ScaglioniDiEta_ID_Gen;

CREATE TRIGGER ScaglioniDiEta_ID_Gen FOR ScaglioniDiEta ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN
		NEW.ID = GEN_ID(ScaglioniDiEta_ID_Gen, 1);
END;


create table Ente
(
	ID int not null primary key,
	Descrizione varchar(400) not null,	
	Tipo varchar(2) not null,	
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator Ente_ID_Gen;

CREATE TRIGGER Ente_ID_Gen FOR Ente	ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN
		NEW.ID = GEN_ID(Ente_ID_Gen, 1);
END;

create table Lead
(
	ID int not null primary key,
	
	Cognome varchar(100) not null,	
	Nome varchar(100),
	DataDiNascita date,
	LuogoDiNascita varchar(100),
	Sesso varchar(1),
	
	NazioneDiNascita varchar(100),
	Professione varchar(250),	
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator Lead_ID_Gen;

CREATE TRIGGER Lead_ID_Gen FOR Lead	ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN
		NEW.ID = GEN_ID(Lead_ID_Gen, 1);
END;


create table AssistenteSociale
(
	IDLead int not null primary key,
	
	Municipalita varchar(250),
	Csst int,	
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF),

	foreign key (Csst) references Ente(ID),	
	foreign key (IDLead) references Lead(ID)	
);

create table InfoAggiuntive 
(
	ID int not null primary key,
	
	Entita_Tipo varchar(150) not null,
	Entita_Key BLOB not null,
	
	Hide char(1) not null,
	Tipo varchar(50) not null,
	Note varchar(5000),
	Allegato varchar(260),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
		
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator InfoAggiuntive_ID_Gen;

CREATE TRIGGER InfoAggiuntive_ID_Gen FOR InfoAggiuntive	ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN
		NEW.ID = GEN_ID(InfoAggiuntive_ID_Gen, 1);
END;

create table Recapiti 
(
	ID int not null primary key,
	
	Entita_Tipo varchar(150) not null,
	Entita_Key BLOB not null,
	
	Tipo varchar(50) not null,
	Recapito varchar(100) not null,
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator Recapiti_ID_Gen;

CREATE TRIGGER Recapiti_ID_Gen FOR Recapiti	ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN
		NEW.ID = GEN_ID(Recapiti_ID_Gen, 1);
END;

create table Indirizzi 
(
	ID int not null primary key,
	
	Entita_Tipo varchar(150) not null,
	Entita_Key BLOB not null,
	
	Tipo varchar(50) not null,
	Indirizzo varchar(300) not null,
	CAP varchar(5) not null,
	Provincia varchar(2) not null,
	Comune varchar(100) not null,
	Stato varchar(100) not null,
	Note varchar(5000),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator Indirizzi_ID_Gen;

CREATE TRIGGER Indirizzi_ID_Gen FOR Indirizzi ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN
		NEW.ID = GEN_ID(Indirizzi_ID_Gen, 1);
END;

create table Minore
(	
	Persona_CF varchar(16) not null primary key,
	
	ConoscenzaDirettaServizio char(1),	
	SoggettoInviante int,
	MotivoIscrizione varchar(5000),

	IDScaglioniDiEta int,	
	
	Scuola int,
	Scuola_Classe varchar(50),
	Scuola_Note varchar(300),
	
	SegnalatoDa varchar(300),
	
	InformazioniSullaSalute varchar(5000),
	DisabilitaFisica varchar(500),
	DisabilitaPsichica varchar(500),
	DisagioNonDiagn varchar(500),
	DisturboApprendimento varchar(500),
	
	ParentiStessoProgetto char(1),	
	
	DataPrimoContatto timestamp,
	DataIscrizione timestamp,
	DataDimissione timestamp,
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (IDScaglioniDiEta) references ScaglioniDiEta(ID),
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF),
	
	foreign key (Persona_CF) references Persona(CF),
	foreign key (Scuola) references Ente(ID),
	foreign key (SoggettoInviante) references Ente(ID)
);

create table Utente
(
	Persona_CF varchar(16) not null primary key,
	Email varchar(200) not null,
	Psw varchar(40) not null,		
	Tipo char(1) default 'U',
	FullScreen_Ricerca char(1),
	FullScreen_Dettaglio char(1),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF),
	
	foreign key (Persona_CF) references Persona(CF)
);

create table ProblemiFamiliari
(
	ID int not null primary key,
	Minore_CF varchar(16) not null,
	Descrizione varchar(300) not null,
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF),
	
	foreign key (Minore_CF) references Minore(Persona_CF)
);

create generator ProblemiFamiliari_ID_Gen;

CREATE TRIGGER ProblemiFamiliari_ID_Gen FOR ProblemiFamiliari ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN
		NEW.ID = GEN_ID(ProblemiFamiliari_ID_Gen, 1);
END;


create table TipoInterventiRealizzati
(
	ID int not null primary key,
	Anno int not null,
	Minore_CF varchar(16) not null,
	Descrizione varchar(300) not null,
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF),
	
	foreign key (Minore_CF) references Minore(Persona_CF)
);

create generator TipoInterventiRealizzati_ID_Gen;

CREATE TRIGGER TipoInterventiRealizzati_ID_Gen FOR TipoInterventiRealizzati ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN
		NEW.ID = GEN_ID(TipoInterventiRealizzati_ID_Gen, 1);
END;


create table RisultatiAnnuali
(		
	Minore_CF varchar(16) not null,
	Anno int not null,
	
	EsitoScolastico varchar(50),
	AssiduitaLezioni varchar(50),
	AssiduitaLaboratori varchar(50),
	AssiduitaGenitori varchar(50),
	
	ValutazionePercorsoFormativo varchar(3000),
	ObbEduRaggiunti varchar(3000),
	ObbDidaRaggiunti varchar(3000),
	EventualiRilievi varchar(3000),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	primary key (Minore_CF, Anno),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF),
	
	foreign key (Minore_CF) references Minore(Persona_CF)
);

create table ListaDiAttesa
(
	Minore_CF varchar(16) not null primary key,
	EntrataInLista timestamp default CURRENT_timestamp,
	UscitaDallaLista timestamp,	
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF),
	
	foreign key (Minore_CF) references Minore(Persona_CF)	
);

create table Educatrice
(
	Persona_CF varchar(16) not null primary key,
	IDScaglioniDiEta int,
	Note varchar(5000),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF),
	
	foreign key (Persona_CF) references Persona(CF),
	foreign key (IDScaglioniDiEta) references ScaglioniDiEta(ID)
);

create table Laboratorio
(
	ID int not null primary key,

	Inizio timestamp not null,
	Fine timestamp not null,

	CFResponsabile varchar(16) not null,
	IDScaglioniDiEta int,	
	
	Descrizione varchar(250) not null,
	Note varchar(5000),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (IDScaglioniDiEta) references ScaglioniDiEta(ID),
	foreign key (CFResponsabile) references Persona(CF),
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator Laboratorio_ID_Gen;

CREATE TRIGGER Laboratorio_ID_Gen FOR Laboratorio ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(Laboratorio_ID_Gen, 1);
END;


create table Educatrice_Laboratorio
(
	ID int not null primary key,
	CFEducatrice varchar(16) not null,
	IDLaboratorio int not null,	
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF),
	
	foreign key (CFEducatrice) references Educatrice(Persona_CF),
	foreign key (IDLaboratorio) references Laboratorio(ID)	
);

create generator Educatrice_Laboratorio_ID_Gen;

CREATE TRIGGER Educatrice_Laboratorio_ID_Gen FOR Educatrice_Laboratorio ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(Educatrice_Laboratorio_ID_Gen, 1);
END;


create table OrariLaboratori
(
	ID int not null primary key,
	IDLaboratorio int not null,
	Da_Ore int not null,
	Da_Minuti int not null,
	A_Ore int not null,
	A_Minuti int not null,	
	GiornoSettimana int not null,
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (IDLaboratorio) references Laboratorio(ID),	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator OrariLaboratori_ID_Gen;

CREATE TRIGGER OrariLaboratori_ID_Gen FOR OrariLaboratori ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(OrariLaboratori_ID_Gen, 1);
END;


create table SvolgimentoLaboratorio
(
	ID int not null primary key,
	IDLaboratorio int not null,
	Dalle timestamp not null,
	Alle timestamp not null,
	Note varchar(5000),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (IDLaboratorio) references Laboratorio(ID),	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator SvolgimentoLaboratorio_ID_Gen;

CREATE TRIGGER SvolgimentoLaboratorio_ID_Gen FOR SvolgimentoLaboratorio ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(SvolgimentoLaboratorio_ID_Gen, 1);
END;

create table PresenzeSvolgimentoLaboratorio
(	
	IDSvolgimentoLaboratorio int not null,
	Minore_CF varchar(16) not null,	
	
	Presente char(5) not null,
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	primary key (IDSvolgimentoLaboratorio, Minore_CF),
	
	foreign key (IDSvolgimentoLaboratorio) references SvolgimentoLaboratorio(ID),	
	foreign key (Minore_CF) references Minore(Persona_CF),	
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);


create table PEI
(
	ID int not null primary key,
	Minore_CF varchar(16) not null,
	
	Stato varchar(40),
	
	Data_Creazione timestamp,
	Data_Compilazione timestamp,
	Data_Dimissione timestamp,
	
	Dimissione_Motivo varchar(3000),	
	Note varchar(5000),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (Minore_CF) references Minore(Persona_CF),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator PEI_ID_Gen;

CREATE TRIGGER PEI_ID_Gen FOR PEI ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(PEI_ID_Gen, 1);
END;


create table StoricoS_PEI
(
	ID int not null primary key,
	IDPEI int not null,
	
	Inizio timestamp not null,
	Fine timestamp,	
	Note varchar(5000),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (IDPEI) references PEI(ID),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator StoricoS_PEI_ID_Gen;

CREATE TRIGGER StoricoS_PEI_ID_Gen FOR StoricoS_PEI ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(StoricoS_PEI_ID_Gen, 1);
END;


create table Colloquio
(
	ID int not null primary key,
	Minore_CF varchar(16) not null,
	
	Inizio timestamp not null,
	Fine timestamp not null,
	Descrizione varchar(250),
	MostraInPEI char(1) default 'F',
	Note varchar(5000),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (Minore_CF) references Minore(Persona_CF),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator Colloquio_ID_Gen;

CREATE TRIGGER Colloquio_ID_Gen FOR Colloquio ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(Colloquio_ID_Gen, 1);
END;


create table ColloquioPresenze
(	
	ID int not null primary key,
	
	IDColloquio int not null,
	Persona_CF varchar(16),
	Minore_CF varchar(16),
	Lead_ID int,
	Ente_ID int,
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (IDColloquio) references Colloquio(ID),
	foreign key (Persona_CF) references Persona(CF),
	foreign key (Minore_CF) references Minore(Persona_CF),
	foreign key (Lead_ID) references Lead(ID),
	foreign key (Ente_ID) references Ente(ID),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator ColloquioPresenze_ID_Gen;

CREATE TRIGGER ColloquioPresenze_ID_Gen FOR ColloquioPresenze ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(ColloquioPresenze_ID_Gen, 1);
END;


create table Plenaria
(
	ID int not null primary key,	
	
	Inizio timestamp not null,
	Fine timestamp not null,
	Descrizione varchar(250),	
	Note varchar(5000),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator Plenaria_ID_Gen;

CREATE TRIGGER Plenaria_ID_Gen FOR Plenaria ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(Plenaria_ID_Gen, 1);
END;


create table PlenariaPresenze
(	
	ID int not null primary key,
	
	IDPlenaria int not null,
	Persona_CF varchar(16),
	Minore_CF varchar(16),
	Lead_ID int,
	Ente_ID int,
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (IDPlenaria) references Plenaria(ID),
	foreign key (Persona_CF) references Persona(CF),
	foreign key (Minore_CF) references Minore(Persona_CF),
	foreign key (Lead_ID) references Lead(ID),
	foreign key (Ente_ID) references Ente(ID),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create generator PlenariaPresenze_ID_Gen;

CREATE TRIGGER PlenariaPresenze_ID_Gen FOR PlenariaPresenze ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(PlenariaPresenze_ID_Gen, 1);
END;


create table Centro
(	
	Codice varchar(3) not null primary key,
	Descrizione varchar(250) not null,
	Lotto varchar(250),
	Municipalita varchar(250),
	Csst int,
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (Csst) references Ente(ID),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create table Numerazioni
(
	CodiceCentro varchar(3) not null primary key,
	SchedaPrimoContatto int,
	SchedaIscrizione int,
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CodiceCentro) references Centro(Codice),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create table Nazioni
(
	Continente int,
	Sigla varchar(5),
	Descrizione varchar(250) not null,
	Codice varchar(4) not null,	
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create table Comuni
(	
	Codice varchar(4) not null primary key,
	Provincia varchar(2) not null,
	DescrizioneItalia varchar(250) not null,
	DescrizioneEstera varchar(250),
	CodCat varchar(4),
	UffCatTerr varchar(2),
	UffCatFabb varchar(2),
	COD_Conservat varchar(4),
	CONSERVAT varchar(250),
	CodIstat int,
	InAttesaVCTTerr varchar(1),
	InAttesaVCTFabb varchar(1),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)
);

create table AttivitaExtra
(
	ID int not null primary key,
	
	IDEnte int,
	Minore_CF varchar(16) not null,
	Descrizione varchar(250) not null,
	AttivitaDelTerritorio char(1),
	Note varchar(5000),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (IDEnte) references Ente(ID),
	foreign key (Minore_CF) references Minore(Persona_CF),	
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)	
);

create generator AttivitaExtra_ID_Gen;

CREATE TRIGGER AttivitaExtra_ID_Gen FOR AttivitaExtra ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(AttivitaExtra_ID_Gen, 1);
END;


create table NucleoFamiliare
(
	ID int not null primary key,
	Capofamiglia varchar(16) not null,
	RelazioneGenitori varchar(250),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (Capofamiglia) references Persona(CF),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)	
);

create generator NucleoFamiliare_ID_Gen;

CREATE TRIGGER NucleoFamiliare_ID_Gen FOR NucleoFamiliare ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(NucleoFamiliare_ID_Gen, 1);
END;


create table MembroFamiliare
(
	ID int not null primary key,	
	IDNucleoFamiliare int not null,
	Figura varchar(150),
	
	--Membro
	Persona_CF varchar(16),
	Minore_CF varchar(16),
	Lead_ID int,	
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),
	
	foreign key (IDNucleoFamiliare) references NucleoFamiliare(ID),	
	
	foreign key (Persona_CF) references Persona(CF),
	foreign key (Minore_CF) references Minore(Persona_CF),
	foreign key (Lead_ID) references Lead(ID),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)	
);

create generator MembroFamiliare_ID_Gen;

CREATE TRIGGER MembroFamiliare_ID_Gen FOR MembroFamiliare ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(MembroFamiliare_ID_Gen, 1);
END;


create table GruppoSostegnoG
(
	ID int not null primary key,
	Inizio timestamp not null,
	Fine timestamp,	
	Descrizione varchar(250) not null,
	Note varchar(5000),
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),	
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)	
);

create generator GruppoSostegnoG_ID_Gen;

CREATE TRIGGER GruppoSostegnoG_ID_Gen FOR GruppoSostegnoG ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(GruppoSostegnoG_ID_Gen, 1);
END;


create table GSG_Partecipanti
(
	ID int not null primary key,
	IDGruppoSostegnoG int not null,
	CF varchar(16) not null,
	
	DataCreazione timestamp default CURRENT_timestamp,
	DataModifica timestamp default CURRENT_timestamp,
	CFCreazione varchar(16),
	CFModifica varchar(16),	
	
	foreign key (IDGruppoSostegnoG) references GruppoSostegnoG(ID),
	foreign key (CF) references Persona(CF),
	
	foreign key (CFCreazione) references Persona(CF),
	foreign key (CFModifica) references Persona(CF)	
);

create generator GSG_Partecipanti_ID_Gen;

CREATE TRIGGER GSG_Partecipanti_ID_Gen FOR GSG_Partecipanti ACTIVE BEFORE INSERT POSITION 0
AS BEGIN 
	IF (NEW.ID IS NULL OR NEW.ID = 0) THEN 
		NEW.ID = GEN_ID(GSG_Partecipanti_ID_Gen, 1);
END;


--viste
RECREATE VIEW SchedaIscrizione as
	select
		mi.Persona_CF,
		pe.Cognome,
		pe.Nome,
		mi.DataIscrizione,
		mi.ParentiStessoProgetto
	from Minore mi
	inner join Persona pe on pe.CF = mi.Persona_CF
	order by
		pe.Cognome,
		pe.Nome;


RECREATE VIEW SchedaPrimoContatto as
	select
		nume.SchedaPrimoContatto as NSchedaPrimoContatto,	
		
		pe.CF,
		pe.Cognome,
		pe.Nome,
		pe.LuogoDiNascita,
		pe.DataDiNascita,
		pe.NazioneDiNascita,
		pe.Nazionalita,
		
		res.Comune || ' - ' || CAP as ComuneCap,
		res.Indirizzo,
		
		r_casa.Recapito as TelCasa,
		r_mobile.Recapito as TelMobile,
		
		mi.DataIscrizione,
		mi.ConoscenzaDirettaServizio,		
		eSoggettoInviante.Descrizione as SoggettoInviante,
		mi.MotivoIscrizione,
		mi.Scuola_Classe,
		mi.Scuola_Note,
		mi.ParentiStessoProgetto,
		mi.InformazioniSullaSalute,
		
		scuola.Descrizione as DescScuola,
		
		mamma.Cognome as Mamma_Cognome,
		mamma.Nome as Mamma_Nome,
		mamma.LuogoDiNascita as Mamma_LuogoDiNascita,
		mamma.DataDiNascita as Mamma_DataDiNascita,
		mamma.Professione as Mamma_Professione,
		
		babbo.Cognome as Babbo_Cognome,
		babbo.Nome as Babbo_Nome,
		babbo.LuogoDiNascita as Babbo_LuogoDiNascita,
		babbo.DataDiNascita as Babbo_DataDiNascita,
		babbo.Professione as Babbo_Professione
		
	from Minore mi
	inner join Persona pe on pe.CF = mi.Persona_CF
	left outer join Persona mamma on mamma.CF = pe.Madre_CF
	left outer join Persona babbo on babbo.CF = pe.Padre_CF
	left outer join Ente scuola on scuola.ID = mi.Scuola	
	left outer join Ente eSoggettoInviante on eSoggettoInviante.ID = mi.SoggettoInviante
	left outer join Recapiti r_casa on r_casa.Entita_Tipo = 'Persona' and substring(cast(substring(r_casa.Entita_Key from 24 for 31) as varchar(17)) from 1 for 16) = pe.CF and r_casa.Tipo = 'Casa'
	left outer join Recapiti r_mobile on r_mobile.Entita_Tipo = 'Persona' and substring(cast(substring(r_mobile.Entita_Key from 24 for 31) as varchar(17)) from 1 for 16) = pe.CF and r_mobile.Tipo = 'Cellulare'
	left outer join Indirizzi res on res.Entita_Tipo = 'Persona' and substring(cast(substring(res.Entita_Key from 24 for 31) as varchar(17)) from 1 for 16) = pe.CF and res.Tipo = 'Residenza'
	left outer join Numerazioni nume on nume.CodiceCentro = 'TEN'
	order by
		pe.Cognome,
		pe.Nome;
	
	
--Dati
insert into Persona
(	
	CF,
	Cognome,
	Nome,
	DataDiNascita,
	LuogoDiNascita,
	Sesso
) values (
	'MNAMHL86B25F839E',
	'Maione',
	'Michele',
	'1986-02-25',
	'Napoli',
	'M'
);

insert into Utente
(
	Persona_CF,
	Email,
	Psw,
	Tipo
) values (
	'MNAMHL86B25F839E',
	'mikymaione@hotmail.it',
	'az',
	'A'
);

insert into ScaglioniDiEta (	
	Descrizione,
	Da,
	A
) values (
	'Viaggiatore',
	6,
	9
);

insert into ScaglioniDiEta (	
	Descrizione,
	Da,
	A
) values (
	'Preadolescente',
	10,
	12
);

insert into ScaglioniDiEta (	
	Descrizione,
	Da,
	A
) values (
	'Adolescente',
	13,
	16
);

insert into Centro
(
	Codice,
	Descrizione,
	CFCreazione,
	CFModifica
) values (
	'TEN',
	'La Tenda',
	'MNAMHL86B25F839E',
	'MNAMHL86B25F839E'
);

insert into Numerazioni (
	CodiceCentro,
	SchedaPrimoContatto,
	SchedaIscrizione
) values (
	'TEN',
	0,
	0
);