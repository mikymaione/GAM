/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Data.Common;
using GAMSharp.GB;
using GAMSharp.DB.DataWrapper.Tabelle;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cEnte : Base.cBaseEntity<Ente>
    {

        protected override Ente Carica_Record(ref DbDataReader dr)
        {
            return new Ente()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                Descrizione = cGB.ObjectToString(dr["Descrizione"]),
                Tipo = cGB.ObjectToString(dr["Tipo"]),
                ExRicerca = new Ente.sExRicerca()
                {
                    TipoDesc = cGB.ObjectToString(ColumnExists(dr, "TipoDesc") ? dr["TipoDesc"] : "")
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Ente entita)
        {
            return new DbParameter[] {
                cDB.NewPar("Tipo", entita.Tipo),
                cDB.NewPar("Descrizione", entita.Descrizione)
            };
        }

        protected override DbParameter[] Modifica_Parametri(Ente entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(Ente entita)
        {
            return new DbParameter[] {
                cDB.NewPar("Tipo", entita.Tipo),
                cDB.NewPar("Descrizione", entita.Descrizione)
            };
        }


    }
}