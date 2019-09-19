/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.GB;
using GAMSharp.DB.DataWrapper.Base;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GAMSharp.UI.Persona
{
#if DEBUG
    class Dettaglio : Base.Ex.fTabbedDettaglio<DB.DataWrapper.Tabelle.Persona>
#else
    class Dettaglio : UI.Base.Ex.fFakeTabbedDettaglio
#endif
    {
        private Controlli.ucLookUp eTutore_CF;
        private Controlli.ucLookUp eMadre_CF;
        private Controlli.ucLookUp ePadre_CF;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private ComboBox eSesso;
        private Label label5;
        private DateTimePicker eDataDiNascita;
        private Label label4;
        private Label label3;
        private Label label2;
        private Controlli.ucCaseTypeTextBox eNome;
        private Controlli.ddlNazione eNazioneDiNascita;
        private Controlli.ucCFTextBox eCF;
        private Controlli.ucCaseTypeTextBox eCognome;
        private Label label10;
        private Controlli.ddlComune eLuogoDiNascita;
        private Label label11;
        private Controlli.ucCaseTypeTextBox eProfessione;
        private CheckBox eAdesioneGSG;
        private Label label1;


        private void eTutore_CF_RicercaRichiesta()
        {
            using (var r = new Persona.Ricerca())
                eTutore_CF.Elemento = r.LookUp();
        }

        private void ePadre_CF_RicercaRichiesta()
        {
            using (var r = new Persona.Ricerca())
                ePadre_CF.Elemento = r.LookUp();
        }

        private void eMadre_CF_RicercaRichiesta()
        {
            using (var r = new Persona.Ricerca())
                eMadre_CF.Elemento = r.LookUp();
        }

        private void ePadre_CF_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var r = new Persona.Dettaglio())
                if (r.ShowDialog(Key) == DialogResult.OK)
                    ePadre_CF.Text = RiCaricaEntita().ExRicerca.Padre;
#endif
        }

        private void eMadre_CF_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var r = new Persona.Dettaglio())
                if (r.ShowDialog(Key) == DialogResult.OK)
                    eMadre_CF.Text = RiCaricaEntita().ExRicerca.Madre;
#endif
        }

        private void eTutore_CF_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var r = new Persona.Dettaglio())
                if (r.ShowDialog(Key) == DialogResult.OK)
                    eTutore_CF.Text = RiCaricaEntita().ExRicerca.Tutore;
#endif
        }


#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.Persona> getEntita()
        {
            return new DB.DataWrapper.cPersona();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Persona e)
        {
            cGB.SetSelectedComboItem_ID(ref eSesso, e.Sesso);
            eCF.Text = e.CF;
            eCognome.Text = e.Cognome;
            eNome.Text = e.Nome;
            eLuogoDiNascita.Text = e.LuogoDiNascita;
            eDataDiNascita.Value = e.DataDiNascita;

            eAdesioneGSG.Checked = cGB.EnglishVarCharToBool(e.AdesioneGSG);
            eNazioneDiNascita.Text = e.NazioneDiNascita;
            eProfessione.Text = e.Professione;

            eTutore_CF.Value = e.Tutore_CF;
            ePadre_CF.Value = e.Padre_CF;
            eMadre_CF.Value = e.Madre_CF;

            eTutore_CF.Text = e.ExRicerca.Tutore;
            ePadre_CF.Text = e.ExRicerca.Padre;
            eMadre_CF.Text = e.ExRicerca.Madre;
        }

        protected override DB.DataWrapper.Tabelle.Persona getForm()
        {
            return new DB.DataWrapper.Tabelle.Persona()
            {
                CF = eCF.Text,
                Cognome = eCognome.Text,
                Nome = eNome.Text,
                LuogoDiNascita = eLuogoDiNascita.Text,
                DataDiNascita = eDataDiNascita.Value,
                Sesso = (char)cGB.GetSelectedComboItem_ID(eSesso),
                Madre_CF = cGB.EmptyStringToNull(eMadre_CF.Value),
                Padre_CF = cGB.EmptyStringToNull(ePadre_CF.Value),
                Tutore_CF = cGB.EmptyStringToNull(eTutore_CF.Value),
                NazioneDiNascita = eNazioneDiNascita.Text,
                Professione = eProfessione.Text,
                AdesioneGSG = cGB.BoolToEnglishChar(eAdesioneGSG.Checked)
            };
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Persona entita)
        {
            return new Control[] {
                eCF
            };
        }

        protected override void setFormNew()
        {
            eSesso.SelectedIndex = 0;
            eCF.Select();
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eCF.Text.Length < eCF.MaxLength)
                z.Add("Il codice fiscale deve essere di " + eCF.MaxLength + " caratteri");
            if (eCognome.Text.Length < 2)
                z.Add("Il cognome deve essere almeno di 2 caratteri");
            if (eNome.Text.Length < 2)
                z.Add("Il nome deve essere almeno di 2 caratteri");
            if (eLuogoDiNascita.Text.Length < 3)
                z.Add("Il luogo di nascita deve essere almeno di 3 caratteri");
            if (eDataDiNascita.Value < eDataDiNascita.MinDate || eDataDiNascita.Value > eDataDiNascita.MaxDate)
                z.Add("Inserire una data di nascita valida");
            if (eSesso.SelectedIndex < 0)
                z.Add("Selezionare un sesso");

            return z;
        }
#endif

        internal Dettaglio() : base("Persona")
        {         
            InitializeComponent();            

            eTutore_CF.RicercaRichiesta += eTutore_CF_RicercaRichiesta;
            eMadre_CF.RicercaRichiesta += eMadre_CF_RicercaRichiesta;
            ePadre_CF.RicercaRichiesta += ePadre_CF_RicercaRichiesta;
            eTutore_CF.DettaglioRichiesto += eTutore_CF_DettaglioRichiesto;
            eMadre_CF.DettaglioRichiesto += eMadre_CF_DettaglioRichiesto;
            ePadre_CF.DettaglioRichiesto += ePadre_CF_DettaglioRichiesto;

            eSesso.Items.Add(new cComboItem('M', "Maschio"));
            eSesso.Items.Add(new cComboItem('F', "Femmina"));
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.eTutore_CF = new GAMSharp.UI.Controlli.ucLookUp();
            this.eMadre_CF = new GAMSharp.UI.Controlli.ucLookUp();
            this.ePadre_CF = new GAMSharp.UI.Controlli.ucLookUp();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.eSesso = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.eDataDiNascita = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eNome = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.eNazioneDiNascita = new GAMSharp.UI.Controlli.ddlNazione();
            this.eCF = new GAMSharp.UI.Controlli.ucCFTextBox();
            this.eCognome = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.eLuogoDiNascita = new GAMSharp.UI.Controlli.ddlComune();
            this.label11 = new System.Windows.Forms.Label();
            this.eProfessione = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.eAdesioneGSG = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tpIndirizzi.SuspendLayout();
            this.tpInfoAggiuntive.SuspendLayout();
            this.tpRecapiti.SuspendLayout();
            this.tpDati.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgLstTabs
            // 
            this.imgLstTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstTabs.ImageStream")));
            this.imgLstTabs.Images.SetKeyName(0, "");
            this.imgLstTabs.Images.SetKeyName(1, "");
            this.imgLstTabs.Images.SetKeyName(2, "");
            this.imgLstTabs.Images.SetKeyName(3, "");
            // 
            // tpDati
            // 
            this.tpDati.Controls.Add(this.eAdesioneGSG);
            this.tpDati.Controls.Add(this.label11);
            this.tpDati.Controls.Add(this.eProfessione);
            this.tpDati.Controls.Add(this.label10);
            this.tpDati.Controls.Add(this.eLuogoDiNascita);
            this.tpDati.Controls.Add(this.eTutore_CF);
            this.tpDati.Controls.Add(this.eMadre_CF);
            this.tpDati.Controls.Add(this.ePadre_CF);
            this.tpDati.Controls.Add(this.label9);
            this.tpDati.Controls.Add(this.label8);
            this.tpDati.Controls.Add(this.label7);
            this.tpDati.Controls.Add(this.label6);
            this.tpDati.Controls.Add(this.eSesso);
            this.tpDati.Controls.Add(this.label5);
            this.tpDati.Controls.Add(this.eDataDiNascita);
            this.tpDati.Controls.Add(this.label4);
            this.tpDati.Controls.Add(this.label3);
            this.tpDati.Controls.Add(this.label2);
            this.tpDati.Controls.Add(this.eNome);
            this.tpDati.Controls.Add(this.eNazioneDiNascita);
            this.tpDati.Controls.Add(this.eCF);
            this.tpDati.Controls.Add(this.eCognome);
            this.tpDati.Controls.Add(this.label1);
            // 
            // eTutore_CF
            // 
            this.eTutore_CF.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eTutore_CF.Elemento")));
            this.eTutore_CF.Location = new System.Drawing.Point(469, 167);
            this.eTutore_CF.Name = "eTutore_CF";
            this.eTutore_CF.ReadOnly = false;
            this.eTutore_CF.Size = new System.Drawing.Size(215, 25);
            this.eTutore_CF.TabIndex = 11;
            this.eTutore_CF.Tipo = null;
            this.eTutore_CF.Value = null;
            // 
            // eMadre_CF
            // 
            this.eMadre_CF.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eMadre_CF.Elemento")));
            this.eMadre_CF.Location = new System.Drawing.Point(469, 141);
            this.eMadre_CF.Name = "eMadre_CF";
            this.eMadre_CF.ReadOnly = false;
            this.eMadre_CF.Size = new System.Drawing.Size(215, 25);
            this.eMadre_CF.TabIndex = 10;
            this.eMadre_CF.Tipo = null;
            this.eMadre_CF.Value = null;
            // 
            // ePadre_CF
            // 
            this.ePadre_CF.Elemento = ((System.Tuple<object, string>)(resources.GetObject("ePadre_CF.Elemento")));
            this.ePadre_CF.Location = new System.Drawing.Point(469, 115);
            this.ePadre_CF.Name = "ePadre_CF";
            this.ePadre_CF.ReadOnly = false;
            this.ePadre_CF.Size = new System.Drawing.Size(215, 25);
            this.ePadre_CF.TabIndex = 9;
            this.ePadre_CF.Tipo = null;
            this.ePadre_CF.Value = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(363, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Tutore";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Madre";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(363, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Padre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Sesso";
            // 
            // eSesso
            // 
            this.eSesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eSesso.FormattingEnabled = true;
            this.eSesso.Location = new System.Drawing.Point(123, 91);
            this.eSesso.Name = "eSesso";
            this.eSesso.Size = new System.Drawing.Size(215, 21);
            this.eSesso.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Data di nascita";
            // 
            // eDataDiNascita
            // 
            this.eDataDiNascita.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.eDataDiNascita.Location = new System.Drawing.Point(469, 39);
            this.eDataDiNascita.MaxDate = new System.DateTime(9000, 12, 31, 0, 0, 0, 0);
            this.eDataDiNascita.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.eDataDiNascita.Name = "eDataDiNascita";
            this.eDataDiNascita.Size = new System.Drawing.Size(110, 20);
            this.eDataDiNascita.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Nazione di nascita";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Cognome";
            // 
            // eNome
            // 
            this.eNome.Location = new System.Drawing.Point(123, 39);
            this.eNome.MaxLength = 100;
            this.eNome.Name = "eNome";
            this.eNome.Size = new System.Drawing.Size(215, 20);
            this.eNome.TabIndex = 2;
            // 
            // eNazioneDiNascita
            // 
            this.eNazioneDiNascita.Location = new System.Drawing.Point(123, 65);
            this.eNazioneDiNascita.MaxLength = 100;
            this.eNazioneDiNascita.Name = "eNazioneDiNascita";
            this.eNazioneDiNascita.Size = new System.Drawing.Size(215, 20);
            this.eNazioneDiNascita.TabIndex = 4;
            // 
            // eCF
            // 
            this.eCF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.eCF.Location = new System.Drawing.Point(123, 13);
            this.eCF.MaxLength = 16;
            this.eCF.Name = "eCF";
            this.eCF.Size = new System.Drawing.Size(215, 20);
            this.eCF.TabIndex = 0;
            // 
            // eCognome
            // 
            this.eCognome.Location = new System.Drawing.Point(469, 13);
            this.eCognome.MaxLength = 100;
            this.eCognome.Name = "eCognome";
            this.eCognome.Size = new System.Drawing.Size(215, 20);
            this.eCognome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "CF";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(363, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Luogo di nascita";
            // 
            // eLuogoDiNascita
            // 
            this.eLuogoDiNascita.Location = new System.Drawing.Point(469, 65);
            this.eLuogoDiNascita.MaxLength = 100;
            this.eLuogoDiNascita.Name = "eLuogoDiNascita";
            this.eLuogoDiNascita.Size = new System.Drawing.Size(215, 20);
            this.eLuogoDiNascita.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(363, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 57;
            this.label11.Text = "Professione";
            // 
            // eProfessione
            // 
            this.eProfessione.Location = new System.Drawing.Point(469, 91);
            this.eProfessione.MaxLength = 100;
            this.eProfessione.Name = "eProfessione";
            this.eProfessione.Size = new System.Drawing.Size(215, 20);
            this.eProfessione.TabIndex = 7;
            // 
            // eAdesioneGSG
            // 
            this.eAdesioneGSG.AutoSize = true;
            this.eAdesioneGSG.Location = new System.Drawing.Point(123, 120);
            this.eAdesioneGSG.Name = "eAdesioneGSG";
            this.eAdesioneGSG.Size = new System.Drawing.Size(216, 17);
            this.eAdesioneGSG.TabIndex = 8;
            this.eAdesioneGSG.Text = "Aderisce al gruppo sostegno genitorialità";
            this.eAdesioneGSG.UseVisualStyleBackColor = true;
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(708, 257);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio persona";
            this.tabControl1.ResumeLayout(false);
            this.tpIndirizzi.ResumeLayout(false);
            this.tpInfoAggiuntive.ResumeLayout(false);
            this.tpRecapiti.ResumeLayout(false);
            this.tpDati.ResumeLayout(false);
            this.tpDati.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}