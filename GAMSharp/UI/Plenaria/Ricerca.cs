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

namespace GAMSharp.UI.Plenaria
{
#if DEBUG
    sealed class Ricerca : fBaseRicerca<DB.DataWrapper.Tabelle.Plenaria, DB.DataWrapper.Tabelle.Plenaria>
#else
    sealed class Ricerca : UI.Base.fFakeRicerca
#endif    
    {

#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.Plenaria> Carica_getEntita()
        {
            return new DB.DataWrapper.cPlenaria();
        }

        protected override void ChiamaCarica()
        {
            Carica();
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                Griglia.NewCol("ID", 80),
                Griglia.NewCol("Descrizione"),
                Griglia.NewCol("Inizio", 100),
                Griglia.NewCol("Fine", 100)
            };
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.Plenaria> getFormDettaglio()
        {
            return new Dettaglio();
        }

        protected override void SelectFirstControl()
        {
            //
        }
#endif

        internal Ricerca()
        {
            InitializeComponent();
            Griglia.RicercaVisibile = false;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ricerca));
            this.SuspendLayout();
            // 
            // Ricerca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "Ricerca";
            this.Text = "Plenarie";
            this.ResumeLayout(false);

        }


    }
}