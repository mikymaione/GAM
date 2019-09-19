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

namespace GAMSharp.UI.Indirizzi
{
    sealed class cRicerca : cBaseRicerca<DB.DataWrapper.Tabelle.Indirizzi>
    {

        public object Entita_Key { get; set; }
        public string Entita_Tipo { get; set; }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.Indirizzi> Carica_getEntita()
        {
            return new DB.DataWrapper.cIndirizzi();
        }

        internal void RiChiamaCarica()
        {
            ChiamaCarica();
        }

        protected override void ChiamaCarica()
        {
            CaricaDati(new DB.DataWrapper.cIndirizzi(), new DB.DataWrapper.Tabelle.Indirizzi()
            {
                Entita_Key = Entita_Key,
                Entita_Tipo = Entita_Tipo
            });
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                NewCol("ID", 80),
                NewCol("Tipo", 100),
                NewCol("Provincia", "Prov.", 40),
                NewCol("Comune", 100),
                NewCol("CAP", 60),
                NewCol("Indirizzo")
            };
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.Indirizzi> getFormDettaglio()
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