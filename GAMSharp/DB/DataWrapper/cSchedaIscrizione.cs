/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2016 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Data.Common;
using GAMSharp.DB.DataWrapper.Viste;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cSchedaIscrizione : Base.cBaseDBObject<SchedaIscrizione>
    {

        protected override SchedaIscrizione Carica_RecordSenzaAudit(ref DbDataReader dr)
        {
            return new SchedaIscrizione()
            {
                DataIscrizione = GB.cGB.ObjectToDateTime(dr["DataIscrizione"]),
                ParentiStessoProgetto = GB.cGB.ObjectToBoolean(dr["ParentiStessoProgetto"]),
                Persona_CF = GB.cGB.ObjectToString(dr["Persona_CF"]),
                Cognome = GB.cGB.ObjectToString(dr["Cognome"]),
                Nome = GB.cGB.ObjectToString(dr["Nome"])
            };
        }

        protected override DbParameter[] Ricerca_Parametri(SchedaIscrizione entita)
        {
            return new DbParameter[] {
                cDB.NewPar("Persona_CF", entita.Persona_CF),
            };
        }


    }
}