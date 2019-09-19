/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;

namespace GAMSharp.DB
{
    sealed class cRisultatoSQL<T>
    {
        private Exception Eccezione_ = null;
        private bool Errore_;
        private T Risultato_;

        internal cRisultatoSQL(T Risultato_p)
        {
            Risultato_ = Risultato_p;
        }

        internal cRisultatoSQL(Exception Eccezione_p)
        {
            Errore_ = true;
            Eccezione_ = Eccezione_p;
        }

        internal bool Errore
        {
            get
            {
                return Errore_;
            }
        }

        internal T Risultato
        {
            get
            {
                return Risultato_;
            }
        }

        internal Exception Eccezione
        {
            get
            {
                if (Errore_)
                    return Eccezione_;
                else
                    return null;
            }
        }


    }
}