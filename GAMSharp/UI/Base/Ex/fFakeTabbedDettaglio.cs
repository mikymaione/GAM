/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Collections.Generic;
using System.Windows.Forms;
using GAMSharp.DB.DataWrapper.Base;

namespace GAMSharp.UI.Base.Ex
{
    class fFakeTabbedDettaglio : fTabbedDettaglio<DB.DataWrapper.Tabelle.ScaglioniDiEta>
    {

        internal fFakeTabbedDettaglio() { }

        internal fFakeTabbedDettaglio(string n) { }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.ScaglioniDiEta entita)
        {
            return null;
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.ScaglioniDiEta> getEntita()
        {
            return new DB.DataWrapper.cScaglioniDiEta();
        }

        protected override DB.DataWrapper.Tabelle.ScaglioniDiEta getForm()
        {
            return new DB.DataWrapper.Tabelle.ScaglioniDiEta();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.ScaglioniDiEta entita)
        {
            //
        }

        protected override void setFormNew()
        {
            //
        }

        protected override List<string> ValidateForm()
        {
            return new List<string>();
        }


    }
}