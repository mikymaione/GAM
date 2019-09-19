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

namespace GAMSharp.UI.Utente
{
#if DEBUG
    sealed class Ricerca : fBaseRicerca<DB.DataWrapper.Tabelle.Utente, DB.DataWrapper.Tabelle.Utente>
#else
    sealed class Ricerca : UI.Base.fFakeRicerca
#endif    
    {

#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.Utente> Carica_getEntita()
        {
            return new DB.DataWrapper.cUtente();
        }

        protected override void ChiamaCarica()
        {
            Carica();
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                Griglia.NewCol("Persona_CF", "Codice fiscale", 140),                
                Griglia.NewCol("RagioneSociale", "Persona"),
                Griglia.NewCol("Email", 200)
            };
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.Utente> getFormDettaglio()
        {            
            return new Dettaglio();
        }

        protected override void SelectFirstControl()
        {

        }        
#endif

        internal Ricerca()
        {
            InitializeComponent();

            if (DB.cMemDB.UtenteConnesso.Tipo.Equals('U'))
            {
                Griglia.DoubleClickAbilitato = false;
                Griglia.bModifica.Enabled = false;
                Griglia.bElimina.Enabled = false;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ricerca));
            this.SuspendLayout();
            // 
            // Ricerca
            // 
            this.RicercaVisibile = false;            
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));            
            this.Name = "Ricerca";
            this.Text = "Utenti";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}