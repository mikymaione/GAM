/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Windows.Forms;
using GAMSharp.DB.DataWrapper.Base;
using GAMSharp.UI.Base;

namespace GAMSharp.UI.OrariLaboratori
{
    sealed class cRicerca : cBaseRicerca<DB.DataWrapper.Tabelle.OrariLaboratori>
    {

        public int IDLaboratorio { get; set; }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.OrariLaboratori> Carica_getEntita()
        {
            return new DB.DataWrapper.cOrariLaboratori();
        }

        protected override void ChiamaCarica()
        {
            CaricaDati(new DB.DataWrapper.cOrariLaboratori(), new DB.DataWrapper.Tabelle.OrariLaboratori()
            {
                IDLaboratorio = IDLaboratorio
            });
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                NewCol("ID", 80),
                NewCol("Giorno"),
                NewCol("Inizio", 80),
                NewCol("Fine", 80)
            };
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.OrariLaboratori> getFormDettaglio()
        {
#if DEBUG
            return new Dettaglio(IDLaboratorio);
#else
            return null;
#endif
        }

        protected override void SelectFirstControl()
        {
            //
        }


    }
}