/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Data.Common;
using GAMSharp.DB.DataWrapper.Tabelle;
using GAMSharp.GB;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cNumerazioni : Base.cBaseEntity<Numerazioni>
    {

        protected override Numerazioni Carica_Record(ref DbDataReader dr)
        {
            return new Numerazioni()
            {
                SchedaIscrizione = cGB.ObjectToInt(dr["SchedaIscrizione"], 0),
                SchedaPrimoContatto = cGB.ObjectToInt(dr["SchedaPrimoContatto"], 0),
                CodiceCentro = cGB.ObjectToString(dr["CodiceCentro"]),
                ExRicerca = new Numerazioni.sExRicerca()
                {
                    Descrizione = cGB.ObjectToString(dr["Descrizione"])
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Numerazioni entita)
        {
            return new DbParameter[] {
                cDB.NewPar("SchedaIscrizione", entita.SchedaIscrizione),
                cDB.NewPar("SchedaPrimoContatto", entita.SchedaPrimoContatto),
                cDB.NewPar("CodiceCentro", entita.CodiceCentro)
            };
        }

        protected override DbParameter[] Modifica_Parametri(Numerazioni entita)
        {
            return Inserisci_Parametri(entita);
        }

        protected override DbParameter[] Ricerca_Parametri(Numerazioni entita)
        {
            return null;
        }


    }
}