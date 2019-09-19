/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Collections.Generic;
using System.Data.Common;

namespace GAMSharp.DB.DataWrapper.Base
{
    abstract class cBaseDBObject<TableEntity> where TableEntity : Tabelle.Base.BaseDBObject, new()
    {
        protected abstract DbParameter[] Ricerca_Parametri(TableEntity entita);
        protected abstract TableEntity Carica_RecordSenzaAudit(ref DbDataReader dr);


        protected bool ColumnExists(DbDataReader dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
                if (dr.GetName(i).Equals(columnName, System.StringComparison.OrdinalIgnoreCase))
                    return true;

            return false;
        }

        protected string getQuery(string NomeEvento)
        {
            return cDB.LeggiQuery(typeof(TableEntity).Name + @"/" + NomeEvento);
        }

        protected string getQuery(cDB.eTipoEvento NomeEvento, string PrimaryKeyName = "", bool PrimaryKeyIsAutoInc = false, DbParameter[] campiDaAggiornare = null)
        {
            var z = "";
            var p = "";

            try
            {
                p = typeof(TableEntity).Name + @"/" + NomeEvento;
                z = cDB.LeggiQuery(p);
            }
            catch (System.IO.FileNotFoundException)
            {
                z = cDB.ComponiQuery(p, NomeEvento, typeof(TableEntity).Name, PrimaryKeyName, PrimaryKeyIsAutoInc, campiDaAggiornare);
            }

            return z;
        }

        internal cRisultatoSQL<List<TableEntity>> Ricerca(TableEntity entita)
        {
            var r = new List<TableEntity>();

            try
            {
                var dr = cDB.EseguiSQLDataReader(getQuery(cDB.eTipoEvento.Ricerca), Ricerca_Parametri(entita));

                try
                {
                    if (dr.HasRows)
                        while (dr.Read())
                            r.Add(Carica_RecordSenzaAudit(ref dr));
                }
                catch (System.Exception ex1)
                {
                    dr.Close();

                    return new cRisultatoSQL<List<TableEntity>>(ex1);
                }

                dr.Close();
            }
            catch (System.Exception ex2)
            {
                return new cRisultatoSQL<List<TableEntity>>(ex2);
            }

            return new cRisultatoSQL<List<TableEntity>>(r);
        }

        internal cRisultatoSQL<System.Data.DataTable> Ricerca(int MaxRows, TableEntity entita)
        {
            try
            {
                return new cRisultatoSQL<System.Data.DataTable>(cDB.EseguiSQLDataTable(getQuery(cDB.eTipoEvento.Ricerca), Ricerca_Parametri(entita), MaxRows));
            }
            catch (System.Exception ex)
            {
                return new cRisultatoSQL<System.Data.DataTable>(ex);
            }
        }

        internal cRisultatoSQL<System.Data.DataTable> Ricerca(object key)
        {
            try
            {
                var e = new TableEntity();

                DbParameter[] p =  {
                    cDB.NewPar(e.PrimaryKeyName, key)
                };

                return new cRisultatoSQL<System.Data.DataTable>(cDB.EseguiSQLDataTable(getQuery(cDB.eTipoEvento.Carica, e.PrimaryKeyName), p, 1));
            }
            catch (System.Exception ex)
            {
                return new cRisultatoSQL<System.Data.DataTable>(ex);
            }
        }

        internal cRisultatoSQL<TableEntity> Carica(object key)
        {
            try
            {
                var ok = false;
                var e = new TableEntity();

                DbParameter[] p =  {
                    cDB.NewPar(e.PrimaryKeyName, key)
                };

                var dr = cDB.EseguiSQLDataReader(getQuery(cDB.eTipoEvento.Carica, e.PrimaryKeyName), p);

                try
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        e = Carica_RecordSenzaAudit(ref dr);

                        ok = true;
                    }
                }
                catch (System.Exception ex1)
                {
                    dr.Close();

                    return new cRisultatoSQL<TableEntity>(ex1);
                }

                dr.Close();

                if (ok)
                    return new cRisultatoSQL<TableEntity>(e);
                else
                    throw new System.Exception("Record non trovato!");
            }
            catch (System.Exception ex2)
            {
                return new cRisultatoSQL<TableEntity>(ex2);
            }
        }


    }
}