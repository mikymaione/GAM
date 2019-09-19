/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2016 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Windows.Forms;
using GAMSharp.DB.DataWrapper.Base;
using GAMSharp.UI.Base;

namespace GAMSharp.UI.Minore
{
    sealed class cRicerca : cBaseRicerca<DB.DataWrapper.Tabelle.Minore>
    {

        public int IDScaglioniDiEta = -1;

        protected override cBaseEntity<DB.DataWrapper.Tabelle.Minore> Carica_getEntita()
        {
            return new DB.DataWrapper.cMinore();
        }

        protected override void ChiamaCarica()
        {            
            CaricaDati(new DB.DataWrapper.cMinore(), new DB.DataWrapper.Tabelle.Minore()
            {                
                IDScaglioniDiEta = IDScaglioniDiEta
            });
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                NewCol("Persona_CF","Codice fiscale", 140),
                NewCol("RagioneSociale", "Minore"),
                NewCol("DataDiNascita","Data di nascita", 80),
                NewCol("LuogoDiNascita","Luogo di nascita", 120)
            };
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.Minore> getFormDettaglio()
        {
#if DEBUG
            return new Dettaglio();
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