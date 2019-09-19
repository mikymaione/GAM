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
    sealed class cMembroFamiliare : Base.cBaseEntity<MembroFamiliare>
    {

        internal int TrovaNucleoFamiliare(string Tabella_, dynamic ID_)
        {
            var i = -1;

            try
            {
                DbParameter[] p =  {
                    cDB.NewPar("Lead_ID", Tabella_.Equals("Lead") ? cGB.ObjectToIntNullable(ID_, 0) : null),
                    cDB.NewPar("Persona_CF", Tabella_.Equals("Persona") ? cGB.ObjectToString(ID_, null) : null),
                    cDB.NewPar("Minore_CF", Tabella_.Equals("Minore") ? cGB.ObjectToString(ID_, null) : null)
                };

                var dr = cDB.EseguiSQLDataReader(getQuery("Trova"), p);

                if (dr.HasRows)
                    while (dr.Read())
                        i = cGB.ObjectToInt(dr["IDNucleoFamiliare"], -1);

                dr.Close();
            }
            catch
            {
                //errore                
            }

            return i;
        }

        protected override MembroFamiliare Carica_Record(ref DbDataReader dr)
        {
            return new MembroFamiliare()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                IDNucleoFamiliare = cGB.ObjectToInt(dr["IDNucleoFamiliare"], -1),
                Figura = cGB.ObjectToString(dr["Figura"]),

                Lead_ID = cGB.ObjectToIntNullable(dr["Lead_ID"], 0),
                Persona_CF = cGB.ObjectToString(dr["Persona_CF"], null),
                Minore_CF = cGB.ObjectToString(dr["Minore_CF"], null),
                ExRicerca = new MembroFamiliare.sExRicerca()
                {
                    Descrizione = cGB.ObjectToString(dr["Descrizione"])
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(MembroFamiliare entita)
        {
            return new DbParameter[] {
                cDB.NewPar(entita.Campo("IDNucleoFamiliare")),
                cDB.NewPar(entita.Campo("Figura")),
                cDB.NewPar(entita.Campo("Lead_ID")),
                cDB.NewPar(entita.Campo("Persona_CF")),
                cDB.NewPar(entita.Campo("Minore_CF"))
            };
        }

        protected override DbParameter[] Modifica_Parametri(MembroFamiliare entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(MembroFamiliare entita)
        {
            return new DbParameter[] {
                cDB.NewPar(entita.Campo("IDNucleoFamiliare"))
            };
        }


    }
}