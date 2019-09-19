﻿/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace GAMSharp.DB.DataWrapper.Tabelle.Base
{
    abstract class tMultiLink : TabellaBase
    {        
        public string Entita_Tipo;
        public object Entita_Key;

        protected bool Uguale(tMultiLink p)
        {
            if (Entita_Tipo.Equals(p.Entita_Tipo))
                if (Entita_Key.Equals(p.Entita_Key))
                    return true;

            return false;
        }


    }
}