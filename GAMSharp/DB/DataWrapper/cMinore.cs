/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Tabelle;
using System.Data.Common;
using GAMSharp.GB;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cMinore : Base.cBaseEntityExtendedSearch<Minore, MinoreRicerca>
    {

        protected override Minore Carica_Record(ref DbDataReader dr)
        {
            return new Minore()
            {
                Persona_CF = cGB.ObjectToString(dr["Persona_CF"]),
                Scuola = cGB.ObjectToInt(dr["Scuola"], -1),

                IDScaglioniDiEta = cGB.ObjectToInt(dr["IDScaglioniDiEta"], -1),
                SoggettoInviante = cGB.ObjectToInt(dr["SoggettoInviante"], -1),
                MotivoIscrizione = cGB.ObjectToString(dr["MotivoIscrizione"]),
                Scuola_Classe = cGB.ObjectToString(dr["Scuola_Classe"]),
                Scuola_Note = cGB.ObjectToString(dr["Scuola_Note"]),
                SegnalatoDa = cGB.ObjectToString(dr["SegnalatoDa"]),
                InformazioniSullaSalute = cGB.ObjectToString(dr["InformazioniSullaSalute"]),
                DisabilitaFisica = cGB.ObjectToString(dr["DisabilitaFisica"]),
                DisabilitaPsichica = cGB.ObjectToString(dr["DisabilitaPsichica"]),
                DisagioNonDiagn = cGB.ObjectToString(dr["DisagioNonDiagn"]),
                DisturboApprendimento = cGB.ObjectToString(dr["DisturboApprendimento"]),

                ParentiStessoProgetto = cGB.ObjectToChar(dr["ParentiStessoProgetto"], 'F'),
                ConoscenzaDirettaServizio = cGB.ObjectToChar(dr["ConoscenzaDirettaServizio"], 'F'),

                DataPrimoContatto = cGB.ObjectToDateTime(dr["DataPrimoContatto"]),
                DataIscrizione = cGB.ObjectToDateTime(dr["DataIscrizione"]),

                ExRicerca = new Minore.sExRicerca()
                {
                    RagioneSociale = cGB.ObjectToString(dr["RagioneSociale"]),
                    Scaglione = cGB.ObjectToString(dr["Scaglione"]),
                    ScuolaDesc = cGB.ObjectToString(dr["ScuolaDesc"]),
                    SoggettoInvianteDesc = cGB.ObjectToString(dr["SoggettoInvianteDesc"]),
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Minore entita)
        {
            return Modifica_Parametri(entita);
        }

        protected override DbParameter[] Modifica_Parametri(Minore e)
        {
            return new DbParameter[]  {
                cDB.NewPar(e.Campo("IDScaglioniDiEta")),
                cDB.NewPar(e.Campo("ConoscenzaDirettaServizio")),
                cDB.NewPar(e.Campo("SoggettoInviante")),
                cDB.NewPar(e.Campo("MotivoIscrizione")),
                cDB.NewPar(e.Campo("Scuola", System.DBNull.Value)),
                cDB.NewPar(e.Campo("Scuola_Classe")),
                cDB.NewPar(e.Campo("Scuola_Note")),
                cDB.NewPar(e.Campo("SegnalatoDa")),
                cDB.NewPar(e.Campo("InformazioniSullaSalute")),
                cDB.NewPar(e.Campo("DisabilitaFisica")),
                cDB.NewPar(e.Campo("DisabilitaPsichica")),
                cDB.NewPar(e.Campo("DisagioNonDiagn")),
                cDB.NewPar(e.Campo("DisturboApprendimento")),
                cDB.NewPar(e.Campo("ParentiStessoProgetto")),
                cDB.NewPar(e.Campo("DataPrimoContatto")),
                cDB.NewPar(e.Campo("DataIscrizione")),
                cDB.NewPar(e.Campo("Persona_CF"))
            };
        }

        protected override DbParameter[] Ricerca_Parametri(Minore entita)
        {
            return new DbParameter[]  {
               cDB.NewPar("IDScaglioniDiEta", entita.IDScaglioniDiEta)
            };
        }

        protected override DbParameter[] Ricerca_ParametriEx(MinoreRicerca entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("Persona_CF", entita.Persona_CF),
                cDB.NewPar("Cognome", entita.Cognome),
                cDB.NewPar("Nome", entita.Nome),
                cDB.NewPar("LuogoDiNascita", entita.LuogoDiNascita)
            };
        }


    }
}