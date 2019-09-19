/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace GAMSharp.DB.DataWrapper.Tabelle
{
    sealed class InfoAggiuntive : Base.tMultiLink
    {
        [PrimaryAutoIncKey]
        public int ID { get; set; }
        public char Hide { get; set; }
        public string Tipo { get; set; }
        public string Note { get; set; }
        public string Allegato { get; set; }


    }
}