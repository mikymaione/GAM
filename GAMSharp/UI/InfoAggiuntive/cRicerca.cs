/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.UI.Base;
using GAMSharp.DB.DataWrapper.Base;
using System.Windows.Forms;

namespace GAMSharp.UI.InfoAggiuntive
{
    sealed class cRicerca : cBaseRicerca<DB.DataWrapper.Tabelle.InfoAggiuntive>
    {

        public object Entita_Key { get; set; }
        public string Entita_Tipo { get; set; }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.InfoAggiuntive> Carica_getEntita()
        {
            return new DB.DataWrapper.cInfoAggiuntive();
        }

        protected override void ChiamaCarica()
        {
            CaricaDati(new DB.DataWrapper.cInfoAggiuntive(), new DB.DataWrapper.Tabelle.InfoAggiuntive()
            {
                Entita_Key = Entita_Key,
                Entita_Tipo = Entita_Tipo
            });
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                NewCol("ID", 80),
                NewCol("Tipo")
            };
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.InfoAggiuntive> getFormDettaglio()
        {
#if DEBUG
            return new Dettaglio(Entita_Tipo, Entita_Key);
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