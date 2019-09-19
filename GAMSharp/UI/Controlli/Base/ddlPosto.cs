/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Windows.Forms;

namespace GAMSharp.UI.Controlli.Base
{
    abstract class ddlPosto : ucCaseTypeTextBox
    {

        protected abstract AutoCompleteStringCollection getTipo();

        public ddlPosto()
        {
#if DEBUG
            this.MaxLength = 250;
            this.CaseType = eCaseType.TitleCaseSaint;
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.AutoCompleteCustomSource = getTipo();
#endif
        }


    }
}