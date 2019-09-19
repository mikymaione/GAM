/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;

namespace GAMSharp.DB.DataWrapper.Tabelle
{
    sealed class Lead : TabellaBase
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public char Sesso { get; set; }
        public DateTime DataDiNascita { get; set; }        
        public string LuogoDiNascita { get; set; }

        public string NazioneDiNascita { get; set; }
        public string Professione { get; set; }        

    }
}