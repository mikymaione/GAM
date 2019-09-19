/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Windows.Forms;
using GAMSharp.GB;

namespace GAMSharp.UI.Base
{
    abstract class cBaseRicerca<TableEntity> : cGriglia where TableEntity : DB.DataWrapper.Tabelle.TabellaBase, new()
    {
        protected abstract DB.DataWrapper.Base.cBaseEntity<TableEntity> Carica_getEntita();
        protected abstract DataGridViewColumn[] getColonneGriglia();
        protected abstract fBaseDettaglio<TableEntity> getFormDettaglio();        
        protected abstract void ChiamaCarica();
        protected abstract void SelectFirstControl();

        internal bool AvviaAutomaticamenteLaRicerca = true;        

        internal cBaseRicerca()
        {
            this.NuovoClick += CBaseRicerca_NuovoClick;
            this.ModificaClick += CBaseRicerca_ModificaClick;
            this.EliminaClick += CBaseRicerca_EliminaClick;
            this.GrigliaDoppioClick += CBaseRicerca_GrigliaDoppioClick;
            this.Load += CBaseRicerca_Load;

#if DEBUG
            AddColonne(getColonneGriglia());
#endif
        }

        private void CBaseRicerca_Load(object sender, System.EventArgs e)
        {
#if DEBUG
            if (AvviaAutomaticamenteLaRicerca)
                ChiamaCarica();

            SelectFirstControl();
#endif
        }
    
        protected void CaricaDati(DB.DataWrapper.Base.cBaseEntity<TableEntity> c_entita, TableEntity parametri)
        {
            var r = c_entita.Ricerca(cGB.ObjectToInt(eFirstXRows.Text, -1), parametri);

            if (r.Errore)
                cGB.MsgBox(r.Eccezione);
            else
                Carica(r.Risultato);
        }

        private void MostraDettaglio(bool nuovo)
        {
            using (fBaseDettaglio<TableEntity> d = getFormDettaglio())
                if ((nuovo ? d.ShowDialog() : d.ShowDialog(SelectedRecord)) == DialogResult.OK)
                    ChiamaCarica();
        }

        protected bool Elimina(DB.DataWrapper.Base.cBaseEntity<TableEntity> entita, object primary_key)
        {
            var eliminato = false;

            if (cGB.MsgBox("Sicuro di voler eliminare il record selezionato?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (primary_key == null)
                    cGB.MsgBox("Nessun record selezionato!", MessageBoxIcon.Exclamation);
                else
                {
                    var z = entita.Elimina(primary_key);

                    if (z.Errore)
                        cGB.MsgBox(z.Eccezione);
                    else
                    {
                        eliminato = true;
                        cGB.MsgBox("Eliminati " + z.Risultato + " record", MessageBoxIcon.Exclamation);
                    }
                }
            }

            return eliminato;
        }

        private void CBaseRicerca_EliminaClick()
        {
            if (Elimina(Carica_getEntita(), SelectedRecord))
                ChiamaCarica();
        }

        private void CBaseRicerca_GrigliaDoppioClick()
        {
            MostraDettaglio(false);
        }

        private void CBaseRicerca_ModificaClick()
        {
            MostraDettaglio(false);
        }

        private void CBaseRicerca_NuovoClick()
        {
            MostraDettaglio(true);
        }


    }
}