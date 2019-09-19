/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Windows.Forms;

namespace GAMSharp.DB
{
    sealed class cMemDB
    {
        private static AutoCompleteStringCollection Comuni_ = null;
        private static AutoCompleteStringCollection Province_ = null;
        private static AutoCompleteStringCollection Nazioni_ = null;

        internal static DataWrapper.Tabelle.Utente UtenteConnesso;

        internal static AutoCompleteStringCollection Nazioni
        {
            get
            {
                if (Nazioni_ == null)
                {
                    var c = new DataWrapper.cNazioni();
                    Nazioni_ = c.getNazioni();
                }

                return Nazioni_;
            }
        }

        internal static AutoCompleteStringCollection Comuni
        {
            get
            {
                if (Comuni_ == null)
                {
                    var c = new DataWrapper.cComuni();
                    Comuni_ = c.getComuni();
                }

                return Comuni_;
            }
        }

        internal static AutoCompleteStringCollection Province
        {
            get
            {
                if (Province_ == null)
                {
                    var c = new DataWrapper.cComuni();
                    Province_ = c.getProvince();
                }

                return Province_;
            }
        }


    }
}