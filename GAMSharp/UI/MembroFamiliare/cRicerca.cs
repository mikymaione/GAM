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

namespace GAMSharp.UI.MembroFamiliare
{
    sealed class cRicerca : cBaseRicerca<DB.DataWrapper.Tabelle.MembroFamiliare>
    {

        private int IDNucleoFamiliare_ = -1;
        public int IDNucleoFamiliare
        {
            get
            {
                return IDNucleoFamiliare_;
            }
            set
            {
                IDNucleoFamiliare_ = value;
                AbilitaPulsantiNewModifica = (IDNucleoFamiliare_ > -1);
            }
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.MembroFamiliare> Carica_getEntita()
        {
            return new DB.DataWrapper.cMembroFamiliare();
        }

        protected override void ChiamaCarica()
        {
            CaricaDati(new DB.DataWrapper.cMembroFamiliare(), new DB.DataWrapper.Tabelle.MembroFamiliare()
            {
                IDNucleoFamiliare = IDNucleoFamiliare
            });
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                NewCol("ID", 80),
                NewCol("IlCapoFamiglia", "Capofamiglia", 200),
                NewCol("Figura", 150),
                NewCol("Descrizione", "Membro")                
            };
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.MembroFamiliare> getFormDettaglio()
        {
#if DEBUG
            return new Dettaglio(IDNucleoFamiliare);
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