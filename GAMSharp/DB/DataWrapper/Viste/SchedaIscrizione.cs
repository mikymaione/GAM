/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2016 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Tabelle;

namespace GAMSharp.DB.DataWrapper.Viste
{
    sealed class SchedaIscrizione : Tabelle.Base.BaseDBObject
    {

        [PrimaryKey]
        public string Persona_CF { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public System.DateTime DataIscrizione { get; set; }
        public bool ParentiStessoProgetto { get; set; }


    }
}