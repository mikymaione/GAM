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
    sealed class cPlenaria : Base.cBaseEntity<Plenaria>
    {

        protected override Plenaria Carica_Record(ref DbDataReader dr)
        {
            return new Plenaria()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                Descrizione = cGB.ObjectToString(dr["Descrizione"]),
                Note = cGB.ObjectToString(dr["Note"]),
                Inizio = cGB.ObjectToDateTime(dr["Inizio"]),
                Fine = cGB.ObjectToDateTime(dr["Fine"])
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Plenaria entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("Descrizione", entita.Descrizione),
                cDB.NewPar("Note", entita.Note),
                cDB.NewPar("Inizio", entita.Inizio),
                cDB.NewPar("Fine", entita.Fine)
            };
        }

        protected override DbParameter[] Modifica_Parametri(Plenaria entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(Plenaria entita)
        {
            return null;
        }


    }
}