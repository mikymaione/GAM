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
    sealed class cScaglioniDiEta : Base.cBaseEntity<ScaglioniDiEta>
    {

        protected override ScaglioniDiEta Carica_Record(ref DbDataReader dr)
        {
            return new ScaglioniDiEta()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                Da = cGB.ObjectToInt(dr["Da"], 0),
                A = cGB.ObjectToInt(dr["A"], 1),
                Descrizione = cGB.ObjectToString(dr["Descrizione"])
            };
        }

        protected override DbParameter[] Inserisci_Parametri(ScaglioniDiEta entita)
        {
            return new DbParameter[] {
                cDB.NewPar("Da", entita.Da),
                cDB.NewPar("A", entita.A),
                cDB.NewPar("Descrizione", entita.Descrizione)
            };
        }

        protected override DbParameter[] Modifica_Parametri(ScaglioniDiEta entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(ScaglioniDiEta entita)
        {
            return null;
        }

        internal System.Collections.Generic.List<GB.cComboItem> GetAll()
        {
            var z = new System.Collections.Generic.List<GB.cComboItem>();

            try
            {
                ScaglioniDiEta e;
                var dr = cDB.EseguiSQLDataReader(getQuery(cDB.eTipoEvento.Ricerca));

                if (dr.HasRows)
                    while (dr.Read())
                        try
                        {
                            e = Carica_Record(ref dr);
                            z.Add(new GB.cComboItem(e.ID, e.Descrizione));
                        }
                        catch
                        {
                            //error
                        }

                dr.Close();
            }
            catch
            {
                //error
            }

            return z;
        }


    }
}