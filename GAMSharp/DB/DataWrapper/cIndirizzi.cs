/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Tabelle;
using System.Data.Common;
using GAMSharp.GB;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cIndirizzi : Base.cBaseEntity<Indirizzi>
    {

        protected override Indirizzi Carica_Record(ref DbDataReader dr)
        {
            return new Indirizzi()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                CAP = cGB.ObjectToString(dr["CAP"]),
                Comune = cGB.ObjectToString(dr["Comune"]),
                Indirizzo = cGB.ObjectToString(dr["Indirizzo"]),
                Provincia = cGB.ObjectToString(dr["Provincia"]),
                Stato = cGB.ObjectToString(dr["Stato"]),
                Entita_Tipo = cGB.ObjectToString(dr["Entita_Tipo"]),
                Entita_Key = cGB.BytesToObjectMemConvert(dr["Entita_Key"] as byte[]),
                Tipo = cGB.ObjectToString(dr["Tipo"]),
                Note = cGB.ObjectToString(dr["Note"])
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Indirizzi entita)
        {
            return new DbParameter[] {
                cDB.NewPar("CAP", entita.CAP),
                cDB.NewPar("Comune", entita.Comune),
                cDB.NewPar("Indirizzo", entita.Indirizzo),
                cDB.NewPar("Provincia", entita.Provincia),
                cDB.NewPar("Stato", entita.Stato),
                cDB.NewPar("Entita_Key", cGB.ObjectToBytesMemConvert(entita.Entita_Key)),
                cDB.NewPar("Entita_Tipo", entita.Entita_Tipo),
                cDB.NewPar("Tipo", entita.Tipo),
                cDB.NewPar("Note", entita.Note)
            };
        }

        protected override DbParameter[] Modifica_Parametri(Indirizzi entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(Indirizzi entita)
        {
            return new DbParameter[] {
                cDB.NewPar("Entita_Key", cGB.ObjectToBytesMemConvert(entita.Entita_Key)),
                cDB.NewPar("Entita_Tipo", entita.Entita_Tipo)
            };
        }


    }
}