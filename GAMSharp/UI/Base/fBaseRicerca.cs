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
    abstract partial class fBaseRicerca<TableEntity, TableEntitySearch> : fBase where TableEntity : DB.DataWrapper.Tabelle.TabellaBase, new() where TableEntitySearch : DB.DataWrapper.Tabelle.TabellaBase, new()
    {

        protected abstract DB.DataWrapper.Base.cBaseEntity<TableEntity> Carica_getEntita();
        protected abstract DataGridViewColumn[] getColonneGriglia();
        protected abstract fBaseDettaglio<TableEntity> getFormDettaglio();        
        protected abstract void ChiamaCarica();
        protected abstract void SelectFirstControl();

        internal bool AvviaAutomaticamenteLaRicerca = true;

        private enum eTipo
        {
            Ricerca,
            Lookup
        }

        private eTipo Tipo = eTipo.Ricerca;

        internal bool RicercaVisibile
        {
            get
            {
                return Griglia.RicercaVisibile;
            }
            set
            {
                Griglia.RicercaVisibile = value;
            }
        }

        internal fBaseRicerca()
        {
            //this.Griglia = new cGriglia();                     
            InitializeComponent();
            PossoEssereFullScreen = true;

            this.AcceptButton = Griglia.bCerca;

            Griglia.AddColonne(getColonneGriglia());
        }

        private void fBaseRicerca_Load(object sender, System.EventArgs e)
        {
            Griglia.bCerca.Left = Griglia.gbRicerca.Width - Griglia.bCerca.Width - 10;
            Griglia.bCerca.Top = Griglia.gbRicerca.Height - Griglia.bCerca.Height - 10;

#if DEBUG
            if (AvviaAutomaticamenteLaRicerca)
                ChiamaCarica();

            SelectFirstControl();
#endif
        }

        protected void Carica(DB.DataWrapper.Base.cBaseEntityExtendedSearch<TableEntity, TableEntitySearch> c_entita, TableEntitySearch parametri)
        {
            var r = c_entita.Ricerca(cGB.ObjectToInt(Griglia.eFirstXRows.Text, -1), parametri);

            if (r.Errore)
                cGB.MsgBox(r.Eccezione);
            else
                Griglia.Carica(r.Risultato);
        }

        protected void Carica()
        {
            Carica(new TableEntity());
        }

        protected void Carica(TableEntity parametri)
        {
            var r = Carica_getEntita().Ricerca(cGB.ObjectToInt(Griglia.eFirstXRows.Text, -1), parametri);

            if (r.Errore)
                cGB.MsgBox(r.Eccezione);
            else
                Griglia.Carica(r.Risultato);
        }

        private void Dettaglio(bool nuovo)
        {
            using (fBaseDettaglio<TableEntity> d = getFormDettaglio())
                if ((nuovo ? d.ShowDialog() : d.ShowDialog(SelectedRecord)) == DialogResult.OK)
                    ChiamaCarica();
        }

        internal TableEntity getSelectedEntity()
        {
            TableEntity e = null;
            var r = SelectedRecord;

            if (r != null)
            {
                var z = Carica_getEntita().Carica(r);

                if (!z.Errore)
                    e = z.Risultato;
            }

            return e;
        }

        private object SelectedRecord
        {
            get
            {
                return Griglia.SelectedRecord;
            }
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

        protected DialogResult ShowLookUp()
        {
            Tipo = eTipo.Lookup;
            Griglia.AbilitaPulsanteOK = true;

            return ShowDialog();
        }

        private void Griglia_CercaClick()
        {
            ChiamaCarica();
        }

        private void Griglia_OkClick()
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Griglia_GrigliaDoppioClick()
        {
            Dettaglio(false);
        }

        private void Griglia_NuovoClick()
        {
            Dettaglio(true);
        }

        private void Griglia_ModificaClick()
        {
            Dettaglio(false);
        }

        private void Griglia_EliminaClick()
        {
            if (Elimina(Carica_getEntita(), SelectedRecord))
                ChiamaCarica();
        }


    }
}