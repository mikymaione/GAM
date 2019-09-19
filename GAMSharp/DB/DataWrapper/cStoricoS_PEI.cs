﻿/*
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
    sealed class cStoricoS_PEI : Base.cBaseEntity<StoricoS_PEI>
    {

        protected override StoricoS_PEI Carica_Record(ref DbDataReader dr)
        {
            return new StoricoS_PEI()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                IDPEI = cGB.ObjectToInt(dr["IDPEI"], -1),
                Inizio = cGB.ObjectToDateTime(dr["Inizio"]),
                Fine = cGB.ObjectToDateTime(dr["Fine"]),
                Note = cGB.ObjectToString(dr["Note"], null)
            };
        }

        protected override DbParameter[] Inserisci_Parametri(StoricoS_PEI entita)
        {
            return new DbParameter[] {
                cDB.NewPar(entita.Campo("IDPEI")),
                cDB.NewPar(entita.Campo("Inizio")),
                cDB.NewPar(entita.Campo("Fine")),
                cDB.NewPar(entita.Campo("Note"))
            };
        }

        protected override DbParameter[] Modifica_Parametri(StoricoS_PEI entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(StoricoS_PEI entita)
        {
            return new DbParameter[] {
                cDB.NewPar(entita.Campo("IDPEI"))
            };
        }


    }
}