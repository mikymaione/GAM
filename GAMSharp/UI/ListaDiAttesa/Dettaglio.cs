/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Base;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GAMSharp.DB.DataWrapper.Tabelle;

namespace GAMSharp.UI.ListaDiAttesa
{
#if DEBUG
    class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.ListaDiAttesa>
#else
    class Dettaglio : UI.Base.fFakeDettaglio
#endif    
    {
        private Controlli.ucLookUp eMinore_CF;
        private DateTimePicker eEntrataInLista, eUscitaDallaLista;
        private Label label1, label2, label3;
        private ToolStripMenuItem bEsci, bStampe;

        internal Dettaglio()
        {
            InitializeComponent();

            bStampe = NewButton("&Stampe", Properties.Resources.printer);
            bEsci = NewButton(bEsci_Click, "&Esci dalla lista", Properties.Resources.door_in);

            AddButtonToMenu(bStampe);
            AddButtonToMenu(bStampe, NewButton(bStampa_SchedaPrimoContatto_Click, "Stampa scheda &primo contatto", Properties.Resources.printer));
            AddButtonToMenu(bStampe, NewButton(bStampa_SchedaIscrizione_Click, "Stampa scheda &iscrizione", Properties.Resources.printer));
            AddButtonToMenu(bEsci);

            eMinore_CF.RicercaRichiesta += ePersona_CF_RicercaRichiesta;
            eMinore_CF.DettaglioRichiesto += ePersona_CF_DettaglioRichiesto;
        }

        private void ePersona_CF_RicercaRichiesta()
        {
            using (var r = new Minore.Ricerca())
                eMinore_CF.Elemento = r.LookUp();
        }

        private void ePersona_CF_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var r = new Minore.Dettaglio())
                if (r.ShowDialog(Key) == DialogResult.OK)
                    eMinore_CF.Text = RiCaricaEntita().ExRicerca.RagioneSociale;
#endif
        }

        private void Stampa(Stampe.ConstStampe.eStampa doc)
        {
            if (GB.cGB.MsgBoxQuestion("Vuoi stampare la " + Stampe.ConstStampe.ToString(doc) + "?"))
            {
                var w = new Stampe.cWordReplacer();
                w.StampaRimpiazzaDocx("Persona", eMinore_CF.Value, doc);
            }
        }

        private void bStampa_SchedaPrimoContatto_Click(object sender, EventArgs e)
        {
            Stampa(Stampe.ConstStampe.eStampa.SchedaPrimoContatto);

            var cm = new DB.DataWrapper.cMinore();
            var r = cm.Carica(eMinore_CF.Value);
            var m = r.Risultato;
            m.DataPrimoContatto = DateTime.Now;

            cm.Modifica(m, m.PrimaryKeyName);
        }

        private void bStampa_SchedaIscrizione_Click(object sender, EventArgs e)
        {
            Stampa(Stampe.ConstStampe.eStampa.SchedaIscrizione);

            var cm = new DB.DataWrapper.cMinore();
            var r = cm.Carica(eMinore_CF.Value);
            var m = r.Risultato;
            m.DataIscrizione = DateTime.Now;

            cm.Modifica(m, m.PrimaryKeyName);
        }

        private void bEsci_Click(object sender, EventArgs e)
        {
            if (GB.cGB.MsgBoxQuestion("Vuoi far uscire questo minore dalla lista?"))
            {
                GB.cGB.MsgBox("Inizio interazione uscita minore dalla lista ... NON ANCORA IMPLEMENTATO");
                eUscitaDallaLista.Checked = true;
                eUscitaDallaLista.Value = DateTime.Now;
                Salva(true, true);
            }
        }

#if DEBUG
        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.ListaDiAttesa entita)
        {
            return new Control[] { eMinore_CF };
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.ListaDiAttesa> getEntita()
        {
            return new DB.DataWrapper.cListaDiAttesa();
        }

        protected override DB.DataWrapper.Tabelle.ListaDiAttesa getForm()
        {
            return new DB.DataWrapper.Tabelle.ListaDiAttesa()
            {
                Minore_CF = GB.cGB.ObjectToString(eMinore_CF.Value),
                EntrataInLista = eEntrataInLista.Value,
                UscitaDallaLista = (eUscitaDallaLista.Checked ? eUscitaDallaLista.Value : DateTime.MinValue)
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.ListaDiAttesa e)
        {
            eMinore_CF.Text = e.ExRicerca.RagioneSociale;
            eMinore_CF.Value = e.Minore_CF;
            eEntrataInLista.Value = e.EntrataInLista;

            if (e.UscitaDallaLista > eUscitaDallaLista.MinDate)
            {
                eUscitaDallaLista.Checked = true;
                eUscitaDallaLista.Value = e.UscitaDallaLista;
                bEsci.Enabled = false;
                bStampe.Enabled = false;
            }
            else
            {
                eUscitaDallaLista.Checked = false;
            }
        }

        protected override void setFormNew()
        {
            eEntrataInLista.Value = DateTime.Now;
            bEsci.Enabled = false;
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eMinore_CF.Value == null)
                z.Add("Selezionare una persona");
            if (eUscitaDallaLista.Checked && eEntrataInLista.Value > eUscitaDallaLista.Value)
                z.Add("L'entrata deve essere precedente all'uscita");

            return z;
        }
#endif

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.eMinore_CF = new GAMSharp.UI.Controlli.ucLookUp();
            this.label1 = new System.Windows.Forms.Label();
            this.eEntrataInLista = new System.Windows.Forms.DateTimePicker();
            this.eUscitaDallaLista = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eMinore_CF
            // 
            this.eMinore_CF.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eMinore_CF.Elemento")));
            this.eMinore_CF.Location = new System.Drawing.Point(125, 32);
            this.eMinore_CF.Name = "eMinore_CF";
            this.eMinore_CF.ReadOnly = false;
            this.eMinore_CF.Size = new System.Drawing.Size(282, 25);
            this.eMinore_CF.TabIndex = 0;
            this.eMinore_CF.Tipo = null;
            this.eMinore_CF.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Minore";
            // 
            // eEntrataInLista
            // 
            this.eEntrataInLista.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eEntrataInLista.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eEntrataInLista.Location = new System.Drawing.Point(125, 61);
            this.eEntrataInLista.Name = "eEntrataInLista";
            this.eEntrataInLista.Size = new System.Drawing.Size(157, 20);
            this.eEntrataInLista.TabIndex = 2;
            // 
            // eUscitaDallaLista
            // 
            this.eUscitaDallaLista.Checked = false;
            this.eUscitaDallaLista.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eUscitaDallaLista.Enabled = false;
            this.eUscitaDallaLista.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eUscitaDallaLista.Location = new System.Drawing.Point(125, 87);
            this.eUscitaDallaLista.Name = "eUscitaDallaLista";
            this.eUscitaDallaLista.ShowCheckBox = true;
            this.eUscitaDallaLista.Size = new System.Drawing.Size(157, 20);
            this.eUscitaDallaLista.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Entrata nella lista";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Uscita dalla lista";
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(421, 120);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eUscitaDallaLista);
            this.Controls.Add(this.eEntrataInLista);
            this.Controls.Add(this.eMinore_CF);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio minore in attesa";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.eMinore_CF, 0);
            this.Controls.SetChildIndex(this.eEntrataInLista, 0);
            this.Controls.SetChildIndex(this.eUscitaDallaLista, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}