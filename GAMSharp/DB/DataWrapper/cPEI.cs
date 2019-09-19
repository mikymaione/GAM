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
    sealed class cPEI : Base.cBaseEntity<PEI>
    {

        protected override PEI Carica_Record(ref DbDataReader dr)
        {
            return new PEI()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                Minore_CF = cGB.ObjectToString(dr["Minore_CF"]),

                Stato = cGB.ObjectToString(dr["Stato"]),
                Dimissione_Motivo = cGB.ObjectToString(dr["Dimissione_Motivo"]),
                Note = cGB.ObjectToString(dr["Note"]),

                Data_Compilazione = cGB.ObjectToDateTime(dr["Data_Compilazione"]),
                Data_Creazione = cGB.ObjectToDateTime(dr["Data_Creazione"]),
                Data_Dimissione = cGB.ObjectToDateTime(dr["Data_Dimissione"])
            };
        }

        protected override DbParameter[] Inserisci_Parametri(PEI e)
        {
            return new DbParameter[]  {
                cDB.NewPar(e.Campo("Minore_CF")),

                cDB.NewPar(e.Campo("Stato")),
                cDB.NewPar(e.Campo("Dimissione_Motivo")),
                cDB.NewPar(e.Campo("Note")),

                cDB.NewPar(e.Campo("Data_Compilazione")),
                cDB.NewPar(e.Campo("Data_Creazione")),
                cDB.NewPar(e.Campo("Data_Dimissione"))
            };
        }

        protected override DbParameter[] Modifica_Parametri(PEI entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(PEI entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("Minore_CF", entita.Minore_CF)
            };
        }


    }
}