/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.GB;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace GAMSharp.DB.DataWrapper.Base
{
    abstract class cBaseEntity<TableEntity> : cBaseDBObject<TableEntity> where TableEntity : Tabelle.TabellaBase, new()
    {
        protected abstract DbParameter[] Inserisci_Parametri(TableEntity entita);
        protected abstract DbParameter[] Modifica_Parametri(TableEntity entita);
        protected abstract TableEntity Carica_Record(ref DbDataReader dr);

        internal cRisultatoSQL<int> Modifica(TableEntity entita, string PrimaryKeyName)
        {
            var modP = Modifica_Parametri(entita);
            DbParameter[] auditP = {
                cDB.NewPar("DataModifica", DateTime.Now),
                cDB.NewPar("CFModifica", cMemDB.UtenteConnesso.Persona_CF)
            };

            var p = new List<DbParameter>();
            p.AddRange(modP);
            p.AddRange(auditP);

            return cDB.EseguiSQLNoQuery(getQuery(cDB.eTipoEvento.Modifica, PrimaryKeyName, false, p.ToArray()), p);
        }

        internal virtual cRisultatoSQL<Tuple<int, int>> Inserisci(TableEntity entita, string PrimaryKeyName, bool PrimaryKeyIsAutoInc)
        {
            DbParameter outp = null;
            var insP = Inserisci_Parametri(entita);

            DbParameter[] auditP = {
                cDB.NewPar("CFCreazione", cMemDB.UtenteConnesso.Persona_CF),
                cDB.NewPar("CFModifica", cMemDB.UtenteConnesso.Persona_CF)
            };

            var p = new List<DbParameter>();
            p.AddRange(insP);
            p.AddRange(auditP);

            if (PrimaryKeyIsAutoInc)
            {
                outp = cDB.NewPar(PrimaryKeyName, null, System.Data.ParameterDirection.Output);
                p.Add(outp);
            }

            var r = cDB.EseguiSQLNoQuery(getQuery(cDB.eTipoEvento.Inserisci, PrimaryKeyName, PrimaryKeyIsAutoInc, p.ToArray()), p);

            if (r.Errore)
                return new cRisultatoSQL<Tuple<int, int>>(r.Eccezione);
            else
            {
                if (PrimaryKeyIsAutoInc)
                    return new cRisultatoSQL<Tuple<int, int>>(new Tuple<int, int>(r.Risultato, Convert.ToInt32(outp.Value)));
                else
                    return new cRisultatoSQL<Tuple<int, int>>(new Tuple<int, int>(r.Risultato, -1));
            }
        }

        internal cRisultatoSQL<int> Elimina(object key)
        {
            var e = Carica(key);

            if (e.Errore)
            {
                return new cRisultatoSQL<int>(e.Eccezione);
            }
            else
            {
                var entita = e.Risultato;

                if (entita.CFCreazione.Equals(cMemDB.UtenteConnesso.Persona_CF))
                {
                    DbParameter[] p =  {
                        cDB.NewPar(entita.PrimaryKeyName, key)
                    };

                    return cDB.EseguiSQLNoQuery(getQuery(cDB.eTipoEvento.Elimina, entita.PrimaryKeyName), p);
                }
                else
                {
                    return new cRisultatoSQL<int>(new Exception("Non puoi eliminare un elemento che non hai creato tu!"));
                }
            }
        }

        protected override TableEntity Carica_RecordSenzaAudit(ref DbDataReader dr)
        {
            var e = Carica_Record(ref dr);
            Carica_Audit(ref e, dr);

            return e;
        }

        private void Carica_Audit(ref TableEntity entita, DbDataReader dr)
        {
            entita.DataCreazione = cGB.ObjectToDateTime(dr["DataCreazione"]);
            entita.DataModifica = cGB.ObjectToDateTime(dr["DataModifica"]);
            entita.CFCreazione = cGB.ObjectToString(dr["CFCreazione"]);
            entita.CFModifica = cGB.ObjectToString(dr["CFModifica"]);
        }


    }
}