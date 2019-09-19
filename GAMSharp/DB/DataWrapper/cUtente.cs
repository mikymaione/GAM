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
    sealed class cUtente : Base.cBaseEntity<Utente>
    {

        internal bool Login(string email, string psw)
        {
            var ok = false;

            try
            {
                DbParameter[] p =  {
                    cDB.NewPar("Email", email),
                    cDB.NewPar("Psw", psw)
                };

                var dr = cDB.EseguiSQLDataReader(getQuery("GetByParam"), p);

                if (dr.HasRows)
                    while (dr.Read())
                        ok = true;

                dr.Close();
            }
            catch (System.Exception ex)
            {
                cGB.MsgBox(ex);
            }

            return ok;
        }

        internal string RecuperaPsw(string email)
        {
            var psw = "";

            try
            {
                DbParameter[] p =  {
                    cDB.NewPar("Email", email)
                };

                var dr = cDB.EseguiSQLDataReader(getQuery("RecuperaPsw"), p);

                if (dr.HasRows)
                    while (dr.Read())
                        psw = cGB.ObjectToString(dr["Psw"]);

                dr.Close();
            }
            catch (System.Exception ex)
            {
                cGB.MsgBox(ex);
            }

            return psw;
        }

        internal Utente Carica(string email, string psw)
        {
            try
            {
                Utente u = null;

                DbParameter[] p =  {
                    cDB.NewPar("Email", email),
                    cDB.NewPar("Psw", psw)
                };

                var dr = cDB.EseguiSQLDataReader(getQuery("GetByParam"), p);

                if (dr.HasRows)
                    while (dr.Read())
                        u = Carica_Record(ref dr);

                dr.Close();

                return u;
            }
            catch (System.Exception ex)
            {
                cGB.MsgBox(ex);
            }

            return null;
        }

        protected override Utente Carica_Record(ref DbDataReader dr)
        {
            return new Utente()
            {
                Persona_CF = cGB.ObjectToString(dr["Persona_CF"]),
                Email = cGB.ObjectToString(dr["Email"]),
                Psw = cGB.ObjectToString(dr["Psw"]),
                Tipo = cGB.ObjectToChar(dr["Tipo"], 'U'),
                FullScreen_Ricerca = cGB.ObjectToChar(dr["FullScreen_Ricerca"], 'F'),
                FullScreen_Dettaglio = cGB.ObjectToChar(dr["FullScreen_Dettaglio"], 'F'),
                ExRicerca = new Utente.sExRicerca()
                {
                    RagioneSociale = cGB.ObjectToString(cDB.FieldIfExists(dr, "RagioneSociale"))
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Utente entita)
        {
            return Modifica_Parametri(entita);
        }

        protected override DbParameter[] Modifica_Parametri(Utente entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("Persona_CF", entita.Persona_CF),
                cDB.NewPar("Email", entita.Email),
                cDB.NewPar("Psw", entita.Psw),
                cDB.NewPar("Tipo", entita.Tipo),
                cDB.NewPar("FullScreen_Ricerca", entita.FullScreen_Ricerca),
                cDB.NewPar("FullScreen_Dettaglio", entita.FullScreen_Dettaglio)
            };
        }

        protected override DbParameter[] Ricerca_Parametri(Utente entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("Email", entita.Email),
                cDB.NewPar("Psw", entita.Psw)
            };
        }


    }
}