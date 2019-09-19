﻿/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace GAMSharp.DB.DataWrapper.Tabelle
{
    sealed class Centro : TabellaBase
    {
        [PrimaryKey]
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public string Municipalita { get; set; }
        public int Csst { get; set; }
        public sExRicerca ExRicerca;

        public struct sExRicerca
        {
            public string DescEnte;
        }


    }
}