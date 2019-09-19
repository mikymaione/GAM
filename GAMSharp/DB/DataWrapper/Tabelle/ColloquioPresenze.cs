/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace GAMSharp.DB.DataWrapper.Tabelle
{
    sealed class ColloquioPresenze : TabellaBase
    {
        [PrimaryAutoIncKey]
        public int ID { get; set; }
        public int IDColloquio { get; set; }
        public int? Lead_ID { get; set; }
        public int? Ente_ID { get; set; }
        public string Persona_CF { get; set; }
        public string Minore_CF { get; set; }
        public sExRicerca ExRicerca;

        public struct sExRicerca
        {
            public string Descrizione;
        }

        public object getValorizedKey()
        {
            if (Lead_ID > -1)
                return Lead_ID;
            else if (Ente_ID > -1)
                return Ente_ID;
            else if (!GB.cGB.NullStringToEmpty(Persona_CF).Equals(""))
                return Persona_CF;
            else if (!GB.cGB.NullStringToEmpty(Minore_CF).Equals(""))
                return Minore_CF;

            return null;
        }

        public string getValorizedType()
        {
            if (Lead_ID > -1)
                return "Lead";
            else if (Ente_ID > -1)
                return "Ente";
            else if (!GB.cGB.NullStringToEmpty(Persona_CF).Equals(""))
                return "Persona";
            else if (!GB.cGB.NullStringToEmpty(Minore_CF).Equals(""))
                return "Minore";

            return null;
        }


    }
}