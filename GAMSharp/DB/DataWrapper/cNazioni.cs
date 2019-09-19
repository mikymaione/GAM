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
using System.Windows.Forms;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cNazioni : Base.cBaseEntity<Nazioni>
    {

        public AutoCompleteStringCollection getNazioni()
        {
            var r = new AutoCompleteStringCollection();
            var dr = cDB.EseguiSQLDataReader(getQuery(cDB.eTipoEvento.Ricerca));

            if (dr.HasRows)
                while (dr.Read())
                {
                    var e = Carica_Record(ref dr);
                    r.Add(e.Descrizione);
                }

            dr.Close();

            return r;
        }

        protected override Nazioni Carica_Record(ref DbDataReader dr)
        {
            return new Nazioni()
            {
                Codice = cGB.ObjectToString(dr["Codice"]),
                Continente = cGB.ObjectToInt(dr["Continente"], -1),
                Descrizione = cGB.ObjectToString(dr["Descrizione"]),
                Sigla = cGB.ObjectToString(dr["Sigla"])
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Nazioni entita)
        {
            return new DbParameter[] {
                cDB.NewPar("Codice", entita.Codice),
                cDB.NewPar("Continente", entita.Continente),
                cDB.NewPar("Descrizione", entita.Descrizione),
                cDB.NewPar("Sigla", entita.Sigla)
            };
        }

        protected override DbParameter[] Modifica_Parametri(Nazioni entita)
        {
            return Inserisci_Parametri(entita);
        }

        protected override DbParameter[] Ricerca_Parametri(Nazioni entita)
        {
            return null;
        }


    }
}