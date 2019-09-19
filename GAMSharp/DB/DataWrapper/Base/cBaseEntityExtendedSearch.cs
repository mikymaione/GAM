/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace GAMSharp.DB.DataWrapper.Base
{
    abstract class cBaseEntityExtendedSearch<TableEntity, TableEntitySearch> : cBaseEntity<TableEntity> where TableEntity : Tabelle.TabellaBase, new() where TableEntitySearch : Tabelle.TabellaBase, new()
    {

        protected abstract System.Data.Common.DbParameter[] Ricerca_ParametriEx(TableEntitySearch entita);

        internal cRisultatoSQL<System.Data.DataTable> Ricerca(int MaxRows, TableEntitySearch entita)
        {
            try
            {
                return new cRisultatoSQL<System.Data.DataTable>(cDB.EseguiSQLDataTable(getQuery(cDB.eTipoEvento.RicercaEx), Ricerca_ParametriEx(entita), MaxRows));
            }
            catch (System.Exception ex)
            {
                return new cRisultatoSQL<System.Data.DataTable>(ex);
            }
        }


    }
}