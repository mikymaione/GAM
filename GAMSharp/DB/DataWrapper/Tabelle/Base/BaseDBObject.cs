/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Linq;

namespace GAMSharp.DB.DataWrapper.Tabelle.Base
{
    public abstract class BaseDBObject
    {

        public Tuple<string, dynamic> Campo(string nome, dynamic default_)
        {
            var t = Campo(nome);

            if (t.Item2 != null)
            {
                if (t.Item2 is int)
                    if (t.Item2 < 0)
                        return new Tuple<string, dynamic>(nome, default_);
            }

            return t;
        }

        public Tuple<string, dynamic> Campo(string nome)
        {
            var f = this.GetType().GetProperty(nome);

            if (f == null)
                throw new Exception("Il campo " + nome + " non esiste nell'entità " + this.GetType().Name);

            var v = f.GetValue(this, null);

            return new Tuple<string, dynamic>(nome, v);
        }

        public bool Equals(TabellaBase ot)
        {
            if (ot == null)
                return false;

            var me_fields = this.GetType().GetProperties();
            var ot_fields = ot.GetType().GetProperties();

            var TupleUguali =
                from m in me_fields
                join o in ot_fields on m.Name equals o.Name
                select new { m, o };

            foreach (var e in TupleUguali)
            {
                var mv = e.m.GetValue(this, null);
                var ov = e.o.GetValue(ot, null);

                if (mv == null && ov == null)
                    continue;

                if (mv == null && "".Equals(ov))
                    continue;

                if ("".Equals(mv) && ov == null)
                    continue;

                if (mv == null && ov != null)
                    return false;

                if (mv != null && ov == null)
                    return false;

                if (!mv.Equals(ov))
                    return false;
            }

            return true;
        }

        private System.Reflection.PropertyInfo PrimaryKeyProperties
        {
            get
            {
                var properties = this.GetType().GetProperties();

                foreach (var property in properties)
                {
                    var attributes = property.GetCustomAttributes(false);

                    foreach (var attribute in attributes)
                        if (attribute is PrimaryKeyAttribute)
                            return property;
                }

                throw new Exception("La chiave primaria non è stata settata per la classe " + this.GetType().Name);
            }
        }

        public bool PrimaryKeyIsAutoInc
        {
            get
            {
                var properties = this.GetType().GetProperties();

                foreach (var property in properties)
                {
                    var attributes = property.GetCustomAttributes(false);

                    foreach (var attribute in attributes)
                        if (attribute is PrimaryAutoIncKeyAttribute)
                            return true;
                }

                return false;
            }
        }

        public object PrimaryKey
        {
            get
            {
                return PrimaryKeyProperties.GetValue(this, null);
            }
        }

        public string PrimaryKeyName
        {
            get
            {
                return PrimaryKeyProperties.Name;
            }
        }

        protected bool EqualsOrNull(string a, string b)
        {
            if (a == b)
                return true;

            if (a == null && b == "")
                return true;
            if (b == null && a == "")
                return true;

            return false;
        }


    }
}