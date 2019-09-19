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
    sealed class cCentro : Base.cBaseEntity<Centro>
    {

        protected override Centro Carica_Record(ref DbDataReader dr)
        {
            return new Centro()
            {
                Codice = cGB.ObjectToString(dr["Codice"]),
                Descrizione = cGB.ObjectToString(dr["Descrizione"]),
                Municipalita = cGB.ObjectToString(dr["Municipalita"]),
                Csst = cGB.ObjectToInt(dr["Csst"], -1),
                ExRicerca = new Centro.sExRicerca()
                {
                    DescEnte = cGB.ObjectToString(dr["DescEnte"])
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Centro entita)
        {
            return Modifica_Parametri(entita);
        }

        protected override DbParameter[] Modifica_Parametri(Centro entita)
        {
            return new DbParameter[]  {
                cDB.NewPar(entita.Campo("Codice")),
                cDB.NewPar(entita.Campo("Descrizione")),
                cDB.NewPar(entita.Campo("Municipalita")),
                cDB.NewPar(entita.Campo("Csst"))
            };
        }

        protected override DbParameter[] Ricerca_Parametri(Centro entita)
        {
            return null;
        }


    }
}