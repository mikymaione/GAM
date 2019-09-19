/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Base;
using GAMSharp.UI.Base;
using System.Windows.Forms;

namespace GAMSharp.UI.AssistenteSociale
{
#if DEBUG
    sealed class Ricerca : fBaseRicerca<DB.DataWrapper.Tabelle.AssistenteSociale, DB.DataWrapper.Tabelle.AssistenteSociale>
#else
    sealed class Ricerca : UI.Base.fFakeRicerca
#endif
    {

#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.AssistenteSociale> Carica_getEntita()
        {
            return new DB.DataWrapper.cAssistenteSociale();
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                Griglia.NewCol("IDLead", "ID", 80),
                Griglia.NewCol("RagioneSociale", "Ragione sociale"),
                Griglia.NewCol("Municipalita", "Municipalità", 200),
                Griglia.NewCol("DescEnte", "CSST", 200)
            };
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.AssistenteSociale> getFormDettaglio()
        {
            return new Dettaglio();
        }

        protected override void ChiamaCarica()
        {
            Carica();
        }

        protected override void SelectFirstControl()
        {

        }
#endif

        internal Ricerca()
        {
            InitializeComponent();

#if DEBUG
            this.RicercaVisibile = false;
#endif
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ricerca));
            this.SuspendLayout();
            // 
            // Ricerca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(804, 441);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "Ricerca";
            this.Text = "Assistenti sociali";
            this.ResumeLayout(false);

        }


    }
}