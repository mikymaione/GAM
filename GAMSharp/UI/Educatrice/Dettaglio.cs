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
using GAMSharp.GB;

namespace GAMSharp.UI.Educatrice
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.Educatrice>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif   
    {
        private List<GB.cComboItem> Scaglioni;

        private Controlli.ucLookUp ePersona_CF;
        private Label label5;
        private TextBox eNote;
        private ComboBox eIDScaglioniDiEta;
        private Label label1;
        private Label label2;

#if DEBUG
        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Educatrice entita)
        {
            return new Control[] {
                ePersona_CF
            };
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.Educatrice> getEntita()
        {
            return new DB.DataWrapper.cEducatrice();
        }

        protected override DB.DataWrapper.Tabelle.Educatrice getForm()
        {
            return new DB.DataWrapper.Tabelle.Educatrice()
            {
                Persona_CF = cGB.ObjectToString(ePersona_CF.Value),
                IDScaglioniDiEta = cGB.ObjectToInt(cGB.GetSelectedComboItem_ID(eIDScaglioniDiEta), -1),
                Note = eNote.Text
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Educatrice e)
        {
            eNote.Text = e.Note;
            ePersona_CF.Value = e.Persona_CF;
            ePersona_CF.Text = e.ExRicerca.RagioneSociale;
            cGB.SetSelectedComboItem_ID(ref eIDScaglioniDiEta, e.IDScaglioniDiEta);
        }

        protected override void setFormNew()
        {
            //
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (ePersona_CF.Value == null)
                z.Add("Selezionare una persona");
            if (eIDScaglioniDiEta.SelectedIndex < 0)
                z.Add("Selezionare uno scaglione");

            return z;
        }
#endif

        private void ePersona_CF_RicercaRichiesta()
        {
            using (var r = new Persona.Ricerca())
                ePersona_CF.Elemento = r.LookUp();
        }

        private void ePersona_CF_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var d = new Persona.Dettaglio())
                if (d.ShowDialog(Key) == DialogResult.OK)
                    ePersona_CF.Text = RiCaricaEntita().ExRicerca.RagioneSociale;
#endif
        }

        internal Dettaglio()
        {
            InitializeComponent();

            ePersona_CF.RicercaRichiesta += ePersona_CF_RicercaRichiesta;
            ePersona_CF.DettaglioRichiesto += ePersona_CF_DettaglioRichiesto;

            var ScaglioniDiEta_ = new DB.DataWrapper.cScaglioniDiEta();
            Scaglioni = ScaglioniDiEta_.GetAll();
            eIDScaglioniDiEta.DataSource = Scaglioni;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.ePersona_CF = new GAMSharp.UI.Controlli.ucLookUp();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.eNote = new System.Windows.Forms.TextBox();
            this.eIDScaglioniDiEta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ePersona_CF
            // 
            this.ePersona_CF.Elemento = ((System.Tuple<object, string>)(resources.GetObject("ePersona_CF.Elemento")));
            this.ePersona_CF.Location = new System.Drawing.Point(131, 34);
            this.ePersona_CF.Name = "ePersona_CF";
            this.ePersona_CF.ReadOnly = false;
            this.ePersona_CF.Size = new System.Drawing.Size(267, 25);
            this.ePersona_CF.TabIndex = 0;
            this.ePersona_CF.Tipo = null;
            this.ePersona_CF.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Persona";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Note";
            // 
            // eNote
            // 
            this.eNote.Location = new System.Drawing.Point(131, 89);
            this.eNote.MaxLength = 5000;
            this.eNote.Multiline = true;
            this.eNote.Name = "eNote";
            this.eNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eNote.Size = new System.Drawing.Size(267, 294);
            this.eNote.TabIndex = 2;
            // 
            // eIDScaglioniDiEta
            // 
            this.eIDScaglioniDiEta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eIDScaglioniDiEta.FormattingEnabled = true;
            this.eIDScaglioniDiEta.Location = new System.Drawing.Point(131, 62);
            this.eIDScaglioniDiEta.Name = "eIDScaglioniDiEta";
            this.eIDScaglioniDiEta.Size = new System.Drawing.Size(267, 21);
            this.eIDScaglioniDiEta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Scaglione";
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(410, 394);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eIDScaglioniDiEta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.eNote);
            this.Controls.Add(this.ePersona_CF);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio educatrice";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.ePersona_CF, 0);
            this.Controls.SetChildIndex(this.eNote, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.eIDScaglioniDiEta, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}