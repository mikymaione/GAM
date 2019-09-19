/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;
using GAMSharp.GB;

namespace GAMSharp.DB
{
    sealed class cDB
    {

        internal enum eTipoEvento
        {
            Modifica, Elimina, Inserisci, Carica, Ricerca, RicercaEx
        }

        internal enum DataBase
        {
            Access,
            SQLite,
            FireBird
        }

        private static Dictionary<string, string> QueriesGiaLette = new Dictionary<string, string>();

        private static string ActualConnectionString_ = "";
        private static bool ConnessioneEffettuata_ = false;
        private static DbConnection Connessione;
        private static DataBase DataBaseAttuale = DataBase.Access;
        internal static DateTime UltimaModifica = DateTime.MinValue;

        public static object Application { get; private set; }

        public static string ActualConnectionString
        {
            get
            {
                return ActualConnectionString_;
            }
        }

        public static bool ConnessioneEffettuata
        {
            get
            {
                return ConnessioneEffettuata_;
            }
        }

        private static string DammiStringaConnessione(string path_db = "", string server = "", string username = "", string psw = "")
        {
            var s = "";

            switch (DataBaseAttuale)
            {
                case DataBase.Access:
                    s = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path_db + ";";
                    break;
                case DataBase.SQLite:
                    s = "Version=3;Data Source=" + path_db + ";";
                    break;
                case DataBase.FireBird:
                    s = $"User={username};Password={psw};Database={path_db};DataSource={server};Port=3050;Dialect=3;Charset=UTF8;";
                    break;
                default:
                    throw new NotImplementedException();
            }

            return s;
        }

        internal static cRisultatoSQL<int> EseguiSQLNoQuery(string sql, List<DbParameter> param)
        {
            return EseguiSQLNoQuery(sql, param.ToArray());
        }

        internal static cRisultatoSQL<int> EseguiSQLNoQuery(ref DbTransaction Trans, string sql, List<DbParameter> param)
        {
            return EseguiSQLNoQuery(ref Trans, sql, param.ToArray());
        }

        internal static cRisultatoSQL<int> EseguiSQLNoQuery(ref DbTransaction Trans, string sql, DbParameter[] param)
        {
            var i = -1;
            var cm = CreaCommandNoConnection(sql, param);

            if ((Trans != null))
                cm.Transaction = Trans;

            try
            {
                i = cm.ExecuteNonQuery();

                if (i > 0)
                    UltimaModifica = DateTime.Now;

                return new cRisultatoSQL<int>(i);
            }
            catch (Exception ex)
            {
                return new cRisultatoSQL<int>(ex);
            }
        }

        internal static cRisultatoSQL<int> EseguiSQLNoQuery(string sql)
        {
            return EseguiSQLNoQuery(sql, new List<DbParameter>());
        }

        internal static cRisultatoSQL<int> EseguiSQLNoQuery(string sql, DbParameter[] param)
        {
            DbTransaction tr = null;

            return EseguiSQLNoQuery(ref tr, sql, param);
        }

        internal static DataTable EseguiSQLDataTable(string sql)
        {
            return EseguiSQLDataTable(sql, null);
        }

        internal static DataTable EseguiSQLDataTable(string sql, DbParameter[] param, int MaxRows = -1)
        {
            var t = new DataTable();

            if (MaxRows > -1)
                sql = Regex.Replace(sql, "select", "select first " + MaxRows, RegexOptions.IgnoreCase);

            using (var cm = CreaCommandNoConnection(sql, param))
                switch (DataBaseAttuale)
                {
                    case DataBase.Access:
                        using (var a = new System.Data.OleDb.OleDbDataAdapter((System.Data.OleDb.OleDbCommand)cm))
                            a.Fill(t);
                        break;
                    case DataBase.SQLite:
                        //using (DbDataAdapter a = new System.Data.SQLite.SQLiteDataAdapter((System.Data.SQLite.SQLiteCommand)cm))
                        //a.Fill(t);
                        break;
                    case DataBase.FireBird:
                        using (var a = new FirebirdSql.Data.FirebirdClient.FbDataAdapter((FirebirdSql.Data.FirebirdClient.FbCommand)cm))
                            a.Fill(t);
                        break;
                    default:
                        throw new NotImplementedException();
                }

            return t;
        }

        private static DbCommand CreaCommandNoConnection(string sql, DbParameter[] param)
        {
            DbCommand cm = null;

            switch (DataBaseAttuale)
            {
                case DataBase.Access:
                    cm = new System.Data.OleDb.OleDbCommand(sql, (System.Data.OleDb.OleDbConnection)Connessione);
                    break;
                case DataBase.SQLite:
                    cm = null;//new System.Data.SQLite.SQLiteCommand(sql, (System.Data.SQLite.SQLiteConnection)Connessione);
                    break;
                case DataBase.FireBird:
                    cm = new FirebirdSql.Data.FirebirdClient.FbCommand(sql, (FirebirdSql.Data.FirebirdClient.FbConnection)Connessione);
                    break;
                default:
                    throw new NotImplementedException();
            }

            if ((param != null))
                for (int x = 0; x <= param.Length - 1; x++)
                {
                    if (param[x].DbType == DbType.Decimal)
                        param[x].DbType = DbType.Currency;

                    cm.Parameters.Add(param[x]);
                }

            return cm;
        }

        internal static DbDataReader EseguiSQLDataReader(string sql)
        {
            DbTransaction tr = null;

            return EseguiSQLDataReader(ref tr, sql, null);
        }

        internal static DbDataReader EseguiSQLDataReader(string sql, List<DbParameter> param)
        {
            return EseguiSQLDataReader(sql, param.ToArray());
        }

        internal static DbDataReader EseguiSQLDataReader(string sql, DbParameter[] param)
        {
            DbTransaction tr = null;

            return EseguiSQLDataReader(ref tr, sql, param);
        }

        internal static DbDataReader EseguiSQLDataReader(ref DbTransaction Trans, string sql, DbParameter[] param)
        {
            var cm = CreaCommandNoConnection(sql, param);

            if ((Trans != null))
                cm.Transaction = Trans;

            return cm.ExecuteReader();
        }

        internal static string ComponiQuery(string percorso, eTipoEvento evento, string tabella, string primaryKeyName, bool primaryKeyIsAutoInc, DbParameter[] campiAggiornamento)
        {
            var z = "";

            if (QueriesGiaLette.ContainsKey(percorso))
                z = QueriesGiaLette[percorso];

            if (z == null || z.Equals(""))
            {
                if (evento == eTipoEvento.Elimina)
                    z = "delete from " + tabella + " where " + primaryKeyName + " = @" + primaryKeyName;
                else if (evento == eTipoEvento.Carica)
                    z = "select * from " + tabella + " where " + primaryKeyName + " = @" + primaryKeyName;
                else if (evento == eTipoEvento.Ricerca)
                    z = "select * from " + tabella;
                else if (evento == eTipoEvento.Modifica)
                {
                    z = "update " + tabella + " set ";

                    for (var i = 0; i < campiAggiornamento.Length; i++)
                        if (!campiAggiornamento[i].ParameterName.Equals(primaryKeyName))
                            z += campiAggiornamento[i].ParameterName + " = @" + campiAggiornamento[i].ParameterName + (campiAggiornamento.Length > i + 1 ? ", " : " ");

                    z += "where " + primaryKeyName + " = @" + primaryKeyName;
                }
                else if (evento == eTipoEvento.Inserisci)
                {
                    var m = 0;

                    if (primaryKeyIsAutoInc)
                        m = -1;

                    z = "insert into " + tabella + " ( ";

                    for (var i = 0; i < campiAggiornamento.Length; i++)
                        if (campiAggiornamento[i].Direction == ParameterDirection.Input)
                            if (!primaryKeyIsAutoInc || !campiAggiornamento[i].ParameterName.Equals(primaryKeyName))
                                z += campiAggiornamento[i].ParameterName + (campiAggiornamento.Length + m > i + 1 ? ", " : " ");

                    z += " ) values ( ";

                    for (var i = 0; i < campiAggiornamento.Length; i++)
                        if (campiAggiornamento[i].Direction == ParameterDirection.Input)
                            if (!primaryKeyIsAutoInc || !campiAggiornamento[i].ParameterName.Equals(primaryKeyName))
                                z += "@" + campiAggiornamento[i].ParameterName + (campiAggiornamento.Length + m > i + 1 ? ", " : " ");

                    z += " ) ";

                    if (primaryKeyIsAutoInc)
                        z += "returning " + primaryKeyName;
                }

                QueriesGiaLette.Add(percorso, z);
            }

            return z;
        }

        internal static string LeggiQuery(string percorso)
        {
            var z = "";

            if (QueriesGiaLette.ContainsKey(percorso))
                z = QueriesGiaLette[percorso];

            if (z == null || z.Equals(""))
            {
                var path_to_sql = "";
                path_to_sql = System.Windows.Forms.Application.StartupPath;
                path_to_sql = System.IO.Path.Combine(path_to_sql, "DB");
                path_to_sql = System.IO.Path.Combine(path_to_sql, "SQL");
                path_to_sql = System.IO.Path.Combine(path_to_sql, percorso);
                path_to_sql = System.IO.Path.ChangeExtension(path_to_sql, ".sql");

                if (!System.IO.File.Exists(path_to_sql))
                    throw new System.IO.FileNotFoundException("Il file " + path_to_sql + " non esiste.");

                using (var sr = new System.IO.StreamReader(path_to_sql))
                {
                    while (sr.Peek() != -1)
                        z += sr.ReadLine() + Environment.NewLine;

                    sr.Close();
                }

                if (DataBaseAttuale == DataBase.SQLite)
                {
                    z = z.Replace("Datepart('d',", "strftime('%d',");
                    z = z.Replace("Datepart('yyyy',", "strftime('%Y',");
                    z = z.Replace("Format(m.data, 'yyyy')", "strftime('%Y',m.data)");
                    z = z.Replace("Format(m.data, 'yyyy/mm')", "strftime('%Y/%m',m.data)");
                }

                QueriesGiaLette.Add(percorso, z);
            }

            return z;
        }

        internal static void AddPar(ref DbParameter[] parametri, string Nome, object Valore)
        {
            var o = parametri.Length;

            Array.Resize<DbParameter>(ref parametri, o + 1);

            parametri[o] = NewPar(Nome, Valore);
        }


        internal static DbParameter NewPar(Tuple<string, dynamic> campo, ParameterDirection direction = ParameterDirection.Input)
        {
            return NewPar(campo.Item1, campo.Item2, direction);
        }

        internal static DbParameter NewPar(string Nome, object Valore, ParameterDirection direction = ParameterDirection.Input)
        {
            DbParameter o = null;

            if (direction == ParameterDirection.Output)
            {
                switch (DataBaseAttuale)
                {
                    case DataBase.Access:
                        o = new System.Data.OleDb.OleDbParameter(Nome, DbType.Int32);
                        break;
                    case DataBase.SQLite:
                        o = null;//new System.Data.SQLite.SQLiteParameter(Nome, DbType.Int32);
                        break;
                    case DataBase.FireBird:
                        o = new FirebirdSql.Data.FirebirdClient.FbParameter(Nome, DbType.Int32);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                if (Valore is DateTime)
                {
                    switch (DataBaseAttuale)
                    {
                        case DataBase.Access:
                            o = new System.Data.OleDb.OleDbParameter(Nome, DbType.DateTime);
                            break;
                        case DataBase.SQLite:
                            Valore = cGB.DateToSQLite((DateTime)Valore);
                            //Valore = ((DateTime)Valore).ToString("yyyy-MM-dd HH:mm:ss.fff");
                            o = null;//new System.Data.SQLite.SQLiteParameter(Nome, DbType.String);
                            break;
                        case DataBase.FireBird:
                            o = new FirebirdSql.Data.FirebirdClient.FbParameter(Nome, DbType.DateTime);
                            break;
                        default:
                            throw new NotImplementedException();
                    }

                    o.Value = Valore;
                }
                else
                {
                    switch (DataBaseAttuale)
                    {
                        case DataBase.Access:
                            o = new System.Data.OleDb.OleDbParameter(Nome, Valore);
                            break;
                        case DataBase.SQLite:
                            o = null;//new System.Data.SQLite.SQLiteParameter(Nome, Valore);
                            break;
                        case DataBase.FireBird:
                            o = new FirebirdSql.Data.FirebirdClient.FbParameter(Nome, Valore);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }

            o.Direction = direction;

            return o;
        }

        internal static DbParameter NewPar(string Nome, object Valore, DbType tipo)
        {
            DbParameter o = null;

            switch (DataBaseAttuale)
            {
                case DataBase.Access:
                    o = new System.Data.OleDb.OleDbParameter(Nome, tipo);
                    break;
                case DataBase.SQLite:
                    if (tipo == DbType.Date || tipo == DbType.DateTime)
                    {
                        //"YYYY-MM-DD HH:MM:SS.SSS"
                        Valore = ((DateTime)Valore).ToString("yyyy-MM-dd HH:mm:ss.fff");
                        tipo = DbType.String;
                    }

                    //o = new System.Data.SQLite.SQLiteParameter(Nome, tipo);
                    break;
                case DataBase.FireBird:
                    o = new FirebirdSql.Data.FirebirdClient.FbParameter(Nome, tipo);
                    break;
                default:
                    throw new NotImplementedException();
            }

            o.Value = Valore;

            return o;
        }

        internal static void ChiudiConnessione()
        {
            try
            {
                Connessione.Close();
                Connessione.Dispose();
            }
            catch
            {
                //cannot close               
            }
        }

        internal static void ApriConnessione(bool ForceClose)
        {
            ApriConnessione(DataBase.Access, "", ForceClose);
        }

        internal static void ApriConnessione(DataBase db_, bool ForceClose)
        {
            ApriConnessione(db_, "", ForceClose);
        }

        internal static void ApriConnessione(string path_db = "", bool ForceClose = false)
        {
            ApriConnessione(DataBase.Access, path_db, ForceClose);
        }

        internal static string GetConnectionStringFromProperties(DataBase db, string host_, string Database_, string User_, string Password_)
        {
            DbConnectionStringBuilder b = null;
            DataBaseAttuale = db;

            if (DataBaseAttuale == DataBase.FireBird) //User=SYSDBA;Password=masterkey;Database=GAM;DataSource=localhost;
                b = new FirebirdSql.Data.FirebirdClient.FbConnectionStringBuilder()
                {
                    UserID = User_,
                    Password = Password_,
                    Database = Database_,
                    DataSource = host_
                };

            return b.ConnectionString;
        }

        internal static bool ApriConnessione(string ConnectionFile, DataBase db_)
        {
            var z = "";

            using (var sr = new System.IO.StreamReader(ConnectionFile))
            {
                while (sr.Peek() != -1)
                    z += sr.ReadLine();

                //z = z.Replace("[CURRENTPATH]", System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath)); //???

                sr.Close();
            }

            return ApriConnessione_(db_, z);
        }

        internal static bool ApriConnessione(DataBase db_, string path_db = "", bool ForceClose = false, string server = "", string username = "", string psw = "")
        {
            DataBaseAttuale = db_;
            var s = DammiStringaConnessione(path_db, server, username, psw);

            return ApriConnessione_(db_, s, ForceClose);
        }

        internal static bool ApriConnessione(bool ForceClose, string ConnectionString, DataBase db_)
        {
            return ApriConnessione_(db_, ConnectionString, ForceClose);
        }

        private static bool ApriConnessione_(DataBase db_, string ConnectionString, bool ForceClose = false)
        {
            ConnessioneEffettuata_ = false;

            if (ForceClose)
                ChiudiConnessione();

            try
            {
                switch (db_)
                {
                    case DataBase.Access:
                        Connessione = new System.Data.OleDb.OleDbConnection(ConnectionString);
                        break;
                    case DataBase.FireBird:
                        Connessione = new FirebirdSql.Data.FirebirdClient.FbConnection(ConnectionString);
                        break;
                    case DataBase.SQLite:
                        //new System.Data.SQLite.SQLiteConnection(ConnectionString);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                Connessione.Open();

                DataBaseAttuale = db_;
                ActualConnectionString_ = ConnectionString;
                ConnessioneEffettuata_ = true;
            }
            catch (Exception ex)
            {
                cGB.MsgBox("Non riesco a connettermi al DB (" + ex.Message + ")", System.Windows.Forms.MessageBoxIcon.Error);
            }

            try
            {
                var ca = new DataWrapper.cAggiornamenti();
                ca.EseguiUpdate();
            }
            catch
            {
                //errore
            }

            return ConnessioneEffettuata_;
        }

        internal static DbTransaction CreaTransazione()
        {
            return Connessione.BeginTransaction();
        }

        internal static Int32 GetColumnType(string TName, string CName)
        {
            var sc = Connessione.GetSchema("Columns");

            foreach (DataRow r in sc.Rows)
                if (r["TABLE_NAME"].Equals(TName))
                    if (r["COLUMN_NAME"].Equals(CName))
                        return Convert.ToInt32(r["DATA_TYPE"]);

            return -1;
        }

        internal static object FieldIfExists(DbDataReader dr, string column)
        {
            var i = -1;
            object o = null;

            try
            {
                i = dr.GetOrdinal(column);
            }
            catch
            {
                //not exists
            }

            if (i > -1)
                o = dr.GetValue(i);

            return o;
        }


    }
}