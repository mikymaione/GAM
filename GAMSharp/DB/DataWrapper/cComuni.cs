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
    sealed class cComuni : Base.cBaseEntity<Comuni>
    {

        public AutoCompleteStringCollection getComuni()
        {
            var r = new AutoCompleteStringCollection();
            var dr = cDB.EseguiSQLDataReader(getQuery(cDB.eTipoEvento.Ricerca));

            if (dr.HasRows)
                while (dr.Read())
                {
                    var e = Carica_Record(ref dr);
                    r.Add(e.DescrizioneItalia);
                }

            dr.Close();

            return r;
        }

        public AutoCompleteStringCollection getProvince()
        {
            var r = new AutoCompleteStringCollection();
            var dr = cDB.EseguiSQLDataReader(getQuery(cDB.eTipoEvento.Ricerca));

            if (dr.HasRows)
                while (dr.Read())
                {
                    var e = Carica_Record(ref dr);
                    r.Add(e.Provincia.ToUpper());
                }

            dr.Close();

            return r;
        }

        protected override Comuni Carica_Record(ref DbDataReader dr)
        {
            return new Comuni()
            {
                Codice = cGB.ObjectToString(dr["Codice"]),
                DescrizioneItalia = cGB.ObjectToString(dr["DescrizioneItalia"]),
                Provincia = cGB.ObjectToString(dr["Provincia"]),
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Comuni entita)
        {
            return new DbParameter[] {
                cDB.NewPar("Codice", entita.Codice),
                cDB.NewPar("Provincia", entita.Provincia),
                cDB.NewPar("DescrizioneItalia", entita.DescrizioneItalia)
            };
        }

        protected override DbParameter[] Modifica_Parametri(Comuni entita)
        {
            return Inserisci_Parametri(entita);
        }

        protected override DbParameter[] Ricerca_Parametri(Comuni entita)
        {
            return null;
        }


    }
}