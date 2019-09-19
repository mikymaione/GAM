/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Collections.Generic;
using System.Windows.Forms;
using GAMSharp.DB.DataWrapper.Base;
using GAMSharp.DB.DataWrapper.Tabelle;

namespace GAMSharp.UI.AttivitaExtra
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.AttivitaExtra>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {
        private Label label2;
        private Label label1;
        private TextBox eNote;
        private Controlli.ucCaseTypeTextBox eDescrizione;
        private Label label3;
        private Controlli.ucLookUp eIDEnte;
        private string Minore_CF = "";

#if DEBUG

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.AttivitaExtra entita)
        {
            return null;
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.AttivitaExtra> getEntita()
        {
            return new DB.DataWrapper.cAttivitaExtra();
        }

        protected override DB.DataWrapper.Tabelle.AttivitaExtra getForm()
        {
            return new DB.DataWrapper.Tabelle.AttivitaExtra()
            {
                ID = GB.cGB.ObjectToInt(PrimaryKey, -1),
                Minore_CF = Minore_CF,                
                IDEnte = GB.cGB.ObjectToIntNullable(eIDEnte.Value, 0),                
                Descrizione = eDescrizione.Text,
                Note = eNote.Text
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.AttivitaExtra e)
        {
            eNote.Text = e.Note;
            eDescrizione.Text = e.Descrizione;
            eIDEnte.Value = e.IDEnte;
            eIDEnte.Text = e.ExRicerca.DescEnte;
        }

        protected override void setFormNew()
        {
            //
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eDescrizione.Text.Length < 3)
                z.Add("Valorizzare la descrizione");

            return z;
        }
#endif              

        private void eIDEnte_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var d = new Ente.Dettaglio())
                if (d.ShowDialog(Key) == DialogResult.OK)
                    eIDEnte.Text = RiCaricaEntita().ExRicerca.DescEnte;
#endif
        }

        private void eIDEnte_RicercaRichiesta()
        {
            using (var r = new Ente.Ricerca())
                eIDEnte.Elemento = r.LookUp();
        }

        internal Dettaglio(string Minore_CF_) : this()
        {
            Minore_CF = Minore_CF_;
        }

        internal Dettaglio()
        {
            InitializeComponent();

            eIDEnte.RicercaRichiesta += eIDEnte_RicercaRichiesta;
            eIDEnte.DettaglioRichiesto += eIDEnte_DettaglioRichiesto;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.eNote = new System.Windows.Forms.TextBox();
            this.eDescrizione = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.eIDEnte = new GAMSharp.UI.Controlli.ucLookUp();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Note";
            // 
            // eNote
            // 
            this.eNote.Location = new System.Drawing.Point(86, 85);
            this.eNote.MaxLength = 5000;
            this.eNote.Multiline = true;
            this.eNote.Name = "eNote";
            this.eNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eNote.Size = new System.Drawing.Size(617, 294);
            this.eNote.TabIndex = 2;
            // 
            // eDescrizione
            // 
            this.eDescrizione.Location = new System.Drawing.Point(86, 33);
            this.eDescrizione.MaxLength = 250;
            this.eDescrizione.Name = "eDescrizione";
            this.eDescrizione.Size = new System.Drawing.Size(617, 20);
            this.eDescrizione.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Descrizione";
            // 
            // eIDEnte
            // 
            this.eIDEnte.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eIDEnte.Elemento")));
            this.eIDEnte.Location = new System.Drawing.Point(86, 57);
            this.eIDEnte.Name = "eIDEnte";
            this.eIDEnte.ReadOnly = false;
            this.eIDEnte.Size = new System.Drawing.Size(617, 25);
            this.eIDEnte.TabIndex = 1;
            this.eIDEnte.Tipo = null;
            this.eIDEnte.Value = null;
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(719, 391);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eNote);
            this.Controls.Add(this.eDescrizione);
            this.Controls.Add(this.eIDEnte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio attività extra";
            this.Controls.SetChildIndex(this.eIDEnte, 0);
            this.Controls.SetChildIndex(this.eDescrizione, 0);
            this.Controls.SetChildIndex(this.eNote, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}