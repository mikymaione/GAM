/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GAMSharp.GB;

namespace GAMSharp.UI.Base
{
    abstract partial class fBaseDettaglio<TableEntity> : fBase where TableEntity : DB.DataWrapper.Tabelle.TabellaBase, new()
    {

        private bool Eliminabile_ = true;
        private bool Salvato = false;
        private bool ModalitaModifica_ = false;
        private object PrimaryKey_;
        private TableEntity EntitaCaricata;

        protected abstract DB.DataWrapper.Base.cBaseEntity<TableEntity> getEntita();
        protected abstract void setForm(TableEntity entita);
        protected abstract void setFormNew();
        protected abstract List<string> ValidateForm();
        protected abstract TableEntity getForm();
        protected abstract Control[] getControlliSoloInserimento(TableEntity entita);

        protected bool Eliminabile
        {
            get
            {
                return Eliminabile_;
            }
            set
            {
                Eliminabile_ = value;
                bElimina2.Visible = value;
            }
        }

        protected bool ModalitaModifica
        {
            get
            {
                return ModalitaModifica_;
            }
        }

        internal object PrimaryKey
        {
            get
            {
                return PrimaryKey_;
            }
        }

        internal fBaseDettaglio()
        {
            InitializeComponent();
        }

        public new DialogResult ShowDialog()
        {
            setFormNew();
            bSalva2.Enabled = false;

            return base.ShowDialog();
        }

        protected TableEntity RiCaricaEntita()
        {
            var r = getEntita().Carica(PrimaryKey_);

            if (r.Errore)
                cGB.MsgBox(r.Eccezione);
            else
                return r.Risultato;

            return null;
        }

        public virtual DialogResult ShowDialog(object PrimaryKey__)
        {
            ModalitaModifica_ = true;
            PrimaryKey_ = PrimaryKey__;
            var r = getEntita().Carica(PrimaryKey__);

            if (r.Errore)
            {
                cGB.MsgBox(r.Eccezione);
                bSalva.Enabled = false;
                bSalva2.Enabled = false;
            }
            else
            {
                bInfo.Enabled = true;
                bElimina2.Enabled = true;

                setForm(r.Risultato);
                setAudit(r.Risultato);
                EntitaCaricata = r.Risultato;

                var ControlliSoloInserimento = getControlliSoloInserimento(r.Risultato);

                if (ControlliSoloInserimento != null)
                    foreach (var c in ControlliSoloInserimento)
                        if (c is Controlli.ucLookUp)
                            ((Controlli.ucLookUp)c).ReadOnly = true;
                        else
                            c.Enabled = false;
            }

            return base.ShowDialog();
        }

        private void setAudit(TableEntity e)
        {
            var c = new DB.DataWrapper.cPersona();

            var r = c.Carica(e.CFCreazione);
            if (r.Errore)
                lCFCreazione.Text = "Creato da " + e.CFCreazione;
            else
                lCFCreazione.Text = "Creato da " + r.Risultato.Cognome + " " + r.Risultato.Nome;

            var z = c.Carica(e.CFModifica);
            if (z.Errore)
                lCFModifica.Text = "Modificato da " + e.CFModifica;
            else
                lCFModifica.Text = "Modificato da " + z.Risultato.Cognome + " " + z.Risultato.Nome;

            lDataCreazione.Text = "Creato il " + e.DataCreazione;
            lDataModifica.Text = "Modificato il " + e.DataModifica;
        }

        private bool DatiCambiati()
        {
            if (PrimaryKey_ == null)
                return true;

            if (EntitaCaricata == null)
                return false;
            else
                return !EntitaCaricata.Equals(getForm());
        }

        protected virtual void PreSalva(TableEntity entita)
        {
            //se serve...
        }

        protected virtual void PostSalva(TableEntity entita)
        {
            //se serve...
        }

        protected bool Salva(bool Chiudi, bool Force = false)
        {
            var ok = false;

            do
            {
                ok = Salva_(Chiudi);
            } while (Force && ok == false);

            return ok;
        }

        private bool Salva_(bool Chiudi)
        {
            Salvato = false;
            var e = ValidateForm();

            if (e != null && e.Count < 1)
            {
                DB.cRisultatoSQL<Tuple<int, int>> r;
                var entita = getForm();

                PreSalva(entita);

                if (PrimaryKey_ == null || PrimaryKey_.Equals(-1))
                {
                    r = getEntita().Inserisci(entita, entita.PrimaryKeyName, entita.PrimaryKeyIsAutoInc);
                }
                else
                {
                    var z = getEntita().Modifica(entita, entita.PrimaryKeyName);

                    if (z.Errore)
                        r = new DB.cRisultatoSQL<Tuple<int, int>>(z.Eccezione);
                    else
                        r = new DB.cRisultatoSQL<Tuple<int, int>>(new Tuple<int, int>(z.Risultato, -1)); //la chiave è la entita.PrimaryKey
                }

                if (r.Errore)
                {
                    cGB.MsgBox(r.Eccezione);
                }
                else
                {
                    if (r.Risultato.Item2 > -1)
                        PrimaryKey_ = r.Risultato.Item2;

                    PostSalva(entita);

                    cGB.MsgBox("Salvati " + r.Risultato.Item1 + " elementi!");

                    Salvato = true;
                    if (Chiudi)
                        this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                var i = 0;
                var y = "";

                foreach (var z in e)
                    y += (i++) + "# " + z + Environment.NewLine;

                cGB.MsgBox(y, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return Salvato;
        }

        private void bSalva2_Click(object sender, EventArgs e)
        {
            Salva(false);
        }

        private void bElimina2_Click(object sender, EventArgs e)
        {
            if (Elimina(getEntita(), PrimaryKey_))
            {
                Salvato = true;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void bSalva_Click(object sender, EventArgs e)
        {
            Salva(true);
        }

        private void fBaseDettaglio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Salvato)
                if (DatiCambiati())
                    if (cGB.MsgBox("Vuoi salvare prima di chiudere la finestra?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        e.Cancel = !Salva(true);
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

        protected void AddButtonToMenu(ToolStripMenuItem locazione, ToolStripMenuItem b)
        {
            locazione.DropDownItems.Add(b);
        }

        protected void AddButtonToMenu(ToolStripMenuItem b)
        {
            tbComandi.Items.Add(b);
        }

        private void bChiudiFinestra_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        protected DateTime GetDateTimePicker(DateTimePicker p)
        {
            if (p.Checked)
                return p.Value;
            else
                return DateTime.MinValue;
        }

        protected void SetDateTimePicker(DateTimePicker p, DateTime d)
        {
            p.ShowCheckBox = true;

            if (d > p.MinDate)
            {
                p.Value = d;
                p.Checked = true;
            }
            else
            {
                p.Checked = false;
            }
        }



    }
}