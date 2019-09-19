/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Tabelle;
using GAMSharp.GB;
using System;
using System.Data.Common;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cLaboratorio : Base.cBaseEntity<Laboratorio>
    {

        protected override Laboratorio Carica_Record(ref DbDataReader dr)
        {
            return new Laboratorio()
            {
                CFResponsabile = cGB.ObjectToString(dr["CFResponsabile"]),
                Descrizione = cGB.ObjectToString(dr["Descrizione"]),
                Note = cGB.ObjectToString(dr["Note"]),
                Inizio = cGB.ObjectToDateTime(dr["Inizio"]),
                Fine = cGB.ObjectToDateTime(dr["Fine"]),
                ID = cGB.ObjectToInt(dr["ID"], -1),
                IDScaglioniDiEta = cGB.ObjectToInt(dr["IDScaglioniDiEta"], -1),
                ExRicerca = new Laboratorio.sExRicerca()
                {
                    Scaglione = cGB.ObjectToString(dr["Scaglione"]),
                    Responsabile = cGB.ObjectToString(dr["Responsabile"])
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Laboratorio entita)
        {
            return new DbParameter[] {
                cDB.NewPar("Inizio", entita.Inizio),
                cDB.NewPar("Fine", entita.Fine),
                cDB.NewPar("CFResponsabile", entita.CFResponsabile),
                cDB.NewPar("Descrizione", entita.Descrizione),
                cDB.NewPar("IDScaglioniDiEta", entita.IDScaglioniDiEta),
                cDB.NewPar("Note", entita.Note)
            };
        }

        protected override DbParameter[] Modifica_Parametri(Laboratorio entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(Laboratorio entita)
        {
            return null;
        }


    }
}