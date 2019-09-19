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
    sealed class cRecapiti : Base.cBaseEntity<Recapiti>
    {

        protected override Recapiti Carica_Record(ref DbDataReader dr)
        {
            return new Recapiti()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                Entita_Tipo = cGB.ObjectToString(dr["Entita_Tipo"]),
                Entita_Key = cGB.BytesToObjectMemConvert(dr["Entita_Key"] as byte[]),
                Tipo = cGB.ObjectToString(dr["Tipo"]),
                Recapito = cGB.ObjectToString(dr["Recapito"])
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Recapiti entita)
        {
            return new DbParameter[] {
                cDB.NewPar("Tipo", entita.Tipo),
                cDB.NewPar("Recapito", entita.Recapito),
                cDB.NewPar("Entita_Key", cGB.ObjectToBytesMemConvert(entita.Entita_Key)),
                cDB.NewPar("Entita_Tipo", entita.Entita_Tipo)
            };
        }

        protected override DbParameter[] Modifica_Parametri(Recapiti entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(Recapiti entita)
        {
            return new DbParameter[] {
                cDB.NewPar("Entita_Key", cGB.ObjectToBytesMemConvert(entita.Entita_Key)),
                cDB.NewPar("Entita_Tipo", entita.Entita_Tipo)
            };
        }


    }
}