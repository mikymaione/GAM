/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2016 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Data.Common;
using GAMSharp.DB.DataWrapper.Viste;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cSchedaPrimoContatto : Base.cBaseDBObject<SchedaPrimoContatto>
    {

        protected override SchedaPrimoContatto Carica_RecordSenzaAudit(ref DbDataReader dr)
        {
            return new SchedaPrimoContatto()
            {
                NSchedaPrimoContatto = GB.cGB.ObjectToInt(dr["NSchedaPrimoContatto"], 0),
                CF = GB.cGB.ObjectToString(dr["CF"]),
                Cognome = GB.cGB.ObjectToString(dr["Cognome"]),
                Nome = GB.cGB.ObjectToString(dr["Nome"]),
                LuogoDiNascita = GB.cGB.ObjectToString(dr["LuogoDiNascita"]),
                DataDiNascita = GB.cGB.ObjectToDateTime(dr["DataDiNascita"]),
                NazioneDiNascita = GB.cGB.ObjectToString(dr["NazioneDiNascita"]),
                Nazionalita = GB.cGB.ObjectToString(dr["Nazionalita"]),
                ComuneCap = GB.cGB.ObjectToString(dr["ComuneCap"]),
                Indirizzo = GB.cGB.ObjectToString(dr["Indirizzo"]),
                TelCasa = GB.cGB.ObjectToString(dr["TelCasa"]),
                TelMobile = GB.cGB.ObjectToString(dr["TelMobile"]),                
                DataIscrizione = GB.cGB.ObjectToDateTime(dr["DataIscrizione"]),
                ConoscenzaDirettaServizio = GB.cGB.EnglishVarCharToBool(dr["ConoscenzaDirettaServizio"]),
                SoggettoInviante = GB.cGB.ObjectToString(dr["SoggettoInviante"]),
                MotivoIscrizione = GB.cGB.ObjectToString(dr["MotivoIscrizione"]),
                Scuola_Classe = GB.cGB.ObjectToString(dr["Scuola_Classe"]),
                Scuola_Note = GB.cGB.ObjectToString(dr["Scuola_Note"]),
                ParentiStessoProgetto = GB.cGB.EnglishVarCharToBool(dr["ParentiStessoProgetto"]),
                InformazioniSullaSalute = GB.cGB.ObjectToString(dr["InformazioniSullaSalute"]),
                DescScuola = GB.cGB.ObjectToString(dr["DescScuola"]),
                Mamma_Cognome = GB.cGB.ObjectToString(dr["Mamma_Cognome"]),
                Mamma_Nome = GB.cGB.ObjectToString(dr["Mamma_Nome"]),
                Mamma_LuogoDiNascita = GB.cGB.ObjectToString(dr["Mamma_LuogoDiNascita"]),
                Mamma_DataDiNascita = GB.cGB.ObjectToDateTime(dr["Mamma_DataDiNascita"]),
                Mamma_Professione = GB.cGB.ObjectToString(dr["Mamma_Professione"]),
                Babbo_Cognome = GB.cGB.ObjectToString(dr["Babbo_Cognome"]),
                Babbo_Nome = GB.cGB.ObjectToString(dr["Babbo_Nome"]),
                Babbo_LuogoDiNascita = GB.cGB.ObjectToString(dr["Babbo_LuogoDiNascita"]),
                Babbo_DataDiNascita = GB.cGB.ObjectToDateTime(dr["Babbo_DataDiNascita"]),
                Babbo_Professione = GB.cGB.ObjectToString(dr["Babbo_Professione"])
            };
        }

        protected override DbParameter[] Ricerca_Parametri(SchedaPrimoContatto entita)
        {
            return new DbParameter[] {
                cDB.NewPar("Persona_CF", entita.CF),
            };
        }


    }
}