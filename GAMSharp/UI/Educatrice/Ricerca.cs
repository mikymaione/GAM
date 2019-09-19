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

namespace GAMSharp.UI.Educatrice
{
#if DEBUG
    sealed class Ricerca : fBaseRicerca<DB.DataWrapper.Tabelle.Educatrice, DB.DataWrapper.Tabelle.Educatrice>
#else
    sealed class Ricerca : UI.Base.fFakeRicerca
#endif    
    {

        internal System.Tuple<object, string> LookUp()
        {
            if (ShowLookUp() == System.Windows.Forms.DialogResult.OK)
            {
#if DEBUG
                var e = getSelectedEntity();

                if (e != null)
                    return new System.Tuple<object, string>(e.Persona_CF, e.ExRicerca.RagioneSociale);
#endif
            }

            return null;
        }

#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.Educatrice> Carica_getEntita()
        {
            return new DB.DataWrapper.cEducatrice();
        }

        protected override void ChiamaCarica()
        {
            Carica();
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                Griglia.NewCol("Persona_CF","Codice fiscale", 140),
                Griglia.NewCol("RagioneSociale", "Persona"),
                Griglia.NewCol("Scaglione", 300)
            };
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.Educatrice> getFormDettaglio()
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
            this.Text = "Educatrici";
            this.ResumeLayout(false);

        }


    }
}