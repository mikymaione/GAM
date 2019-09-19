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
    sealed class cAssistenteSociale : Base.cBaseEntity<AssistenteSociale>
    {

        protected override AssistenteSociale Carica_Record(ref DbDataReader dr)
        {
            return new AssistenteSociale()
            {
                IDLead = cGB.ObjectToInt(dr["IDLead"], -1),
                Csst = cGB.ObjectToInt(dr["Csst"], -1),
                Municipalita = cGB.ObjectToString(dr["Municipalita"]),
                ExRicerca = new AssistenteSociale.sExRicerca()
                {
                    RagioneSociale = cGB.ObjectToString(dr["RagioneSociale"]),
                    DescEnte = cGB.ObjectToString(dr["DescEnte"])
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(AssistenteSociale entita)
        {
            return Modifica_Parametri(entita);
        }

        protected override DbParameter[] Modifica_Parametri(AssistenteSociale entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("IDLead", entita.IDLead),
                cDB.NewPar("Csst", entita.Csst),
                cDB.NewPar("Municipalita", entita.Municipalita)
            };
        }

        protected override DbParameter[] Ricerca_Parametri(AssistenteSociale entita)
        {
            return null;
        }


    }
}