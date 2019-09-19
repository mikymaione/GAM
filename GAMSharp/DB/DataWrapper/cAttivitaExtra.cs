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
    sealed class cAttivitaExtra : Base.cBaseEntity<AttivitaExtra>
    {

        protected override AttivitaExtra Carica_Record(ref DbDataReader dr)
        {
            return new AttivitaExtra()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                Descrizione = cGB.ObjectToString(dr["Descrizione"]),
                Note = cGB.ObjectToString(dr["Note"]),
                Minore_CF = cGB.ObjectToString(dr["Minore_CF"]),
                IDEnte = cGB.ObjectToIntNullable(dr["IDEnte"], 0),
                AttivitaDelTerritorio = cGB.ObjectToChar(dr["AttivitaDelTerritorio"], 'F'),
                ExRicerca = new AttivitaExtra.sExRicerca()
                {
                    Minore = cGB.ObjectToString(dr["Minore"]),
                    DescEnte = cGB.ObjectToString(dr["DescEnte"])
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(AttivitaExtra entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("Descrizione", entita.Descrizione),
                cDB.NewPar("AttivitaDelTerritorio", entita.AttivitaDelTerritorio),
                cDB.NewPar("Note", entita.Note),
                cDB.NewPar("Minore_CF", entita.Minore_CF),
                cDB.NewPar("IDEnte", entita.IDEnte)
            };
        }

        protected override DbParameter[] Modifica_Parametri(AttivitaExtra entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(AttivitaExtra entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("Minore_CF", entita.Minore_CF)
            };
        }


    }
}