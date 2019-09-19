/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Tabelle;
using GAMSharp.GB;
using System.Data.Common;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cColloquioPresenze : Base.cBaseEntity<ColloquioPresenze>
    {

        protected override ColloquioPresenze Carica_Record(ref DbDataReader dr)
        {
            return new ColloquioPresenze()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                IDColloquio = cGB.ObjectToInt(dr["IDColloquio"], -1),
                Ente_ID = cGB.ObjectToIntNullable(dr["Ente_ID"], 0),
                Lead_ID = cGB.ObjectToIntNullable(dr["Lead_ID"], 0),
                Persona_CF = cGB.ObjectToString(dr["Persona_CF"], null),
                Minore_CF = cGB.ObjectToString(dr["Minore_CF"], null),
                ExRicerca = new ColloquioPresenze.sExRicerca()
                {
                    Descrizione = cGB.ObjectToString(dr["Descrizione"])
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(ColloquioPresenze entita)
        {
            return new DbParameter[] {
                cDB.NewPar(entita.Campo("IDColloquio")),
                cDB.NewPar(entita.Campo("Ente_ID")),
                cDB.NewPar(entita.Campo("Lead_ID")),
                cDB.NewPar(entita.Campo("Persona_CF")),
                cDB.NewPar(entita.Campo("Minore_CF"))
            };
        }

        protected override DbParameter[] Modifica_Parametri(ColloquioPresenze entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(ColloquioPresenze entita)
        {
            return new DbParameter[] {
                cDB.NewPar(entita.Campo("IDColloquio"))
            };
        }


    }
}