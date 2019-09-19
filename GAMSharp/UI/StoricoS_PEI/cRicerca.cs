﻿/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Windows.Forms;
using GAMSharp.DB.DataWrapper.Base;
using GAMSharp.UI.Base;

namespace GAMSharp.UI.StoricoS_PEI
{
    sealed class cRicerca : cBaseRicerca<DB.DataWrapper.Tabelle.StoricoS_PEI>
    {

        public int IDPEI { get; set; }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.StoricoS_PEI> Carica_getEntita()
        {
            return new DB.DataWrapper.cStoricoS_PEI();
        }

        protected override void ChiamaCarica()
        {
            CaricaDati(new DB.DataWrapper.cStoricoS_PEI(), new DB.DataWrapper.Tabelle.StoricoS_PEI()
            {
                IDPEI = IDPEI
            });
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                NewCol("ID", 80),
                NewCol("Inizio", 100),
                NewCol("Fine", 100),
                NewCol("Note")
            };
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.StoricoS_PEI> getFormDettaglio()
        {
#if DEBUG
            return new Dettaglio(IDPEI);
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