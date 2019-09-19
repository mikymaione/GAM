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

namespace GAMSharp.UI.Lead
{
#if DEBUG
    class Dettaglio : Base.Ex.fTabbedDettaglio<DB.DataWrapper.Tabelle.Lead>
#else
    class Dettaglio : UI.Base.Ex.fFakeTabbedDettaglio
#endif
    {
        private Label label6;
        private ComboBox eSesso;
        private Label label5;
        private DateTimePicker eDataDiNascita;
        private Label label4;
        private Label label3;
        private Label label2;
        private Controlli.ucCaseTypeTextBox eNome;
        private Controlli.ddlNazione eNazioneDiNascita;
        private Label label1;
        private Label label7;
        private Controlli.ucCaseTypeTextBox eProfessione;
        private Controlli.ddlComune eLuogoDiNascita;
        private Controlli.ucCaseTypeTextBox eCognome;


#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.Lead> getEntita()
        {
            return new DB.DataWrapper.cLead();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Lead e)
        {
            cGB.SetSelectedComboItem_ID(ref eSesso, e.Sesso);
            eCognome.Text = e.Cognome;
            eNome.Text = e.Nome;
            eLuogoDiNascita.Text = e.LuogoDiNascita;
            eDataDiNascita.Value = e.DataDiNascita;
            eNazioneDiNascita.Text = e.NazioneDiNascita;
            eProfessione.Text = e.Professione;
        }

        protected override DB.DataWrapper.Tabelle.Lead getForm()
        {
            return new DB.DataWrapper.Tabelle.Lead()
            {
                ID = cGB.ObjectToInt(PrimaryKey, -1),
                Cognome = eCognome.Text,
                Nome = eNome.Text,
                LuogoDiNascita = eLuogoDiNascita.Text,
                DataDiNascita = eDataDiNascita.Value,
                Sesso = (char)cGB.GetSelectedComboItem_ID(eSesso),
                NazioneDiNascita = eNazioneDiNascita.Text,
                Professione = eProfessione.Text
            };
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Lead entita)
        {
            return null;
        }

        protected override void setFormNew()
        {
            eSesso.SelectedIndex = 0;
            eCognome.Select();            
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

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

        internal Dettaglio() : base("Lead")
        {            
            InitializeComponent();

#if DEBUG
            eSesso.Items.Add(new cComboItem('M', "Maschio"));
            eSesso.Items.Add(new cComboItem('F', "Femmina"));
#endif
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.label6 = new System.Windows.Forms.Label();
            this.eSesso = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.eDataDiNascita = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eNome = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.eNazioneDiNascita = new GAMSharp.UI.Controlli.ddlNazione();
            this.eCognome = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.eProfessione = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.eLuogoDiNascita = new GAMSharp.UI.Controlli.ddlComune();
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
            this.tpDati.Controls.Add(this.eLuogoDiNascita);
            this.tpDati.Controls.Add(this.label7);
            this.tpDati.Controls.Add(this.eProfessione);
            this.tpDati.Controls.Add(this.label1);
            this.tpDati.Controls.Add(this.label6);
            this.tpDati.Controls.Add(this.eSesso);
            this.tpDati.Controls.Add(this.label5);
            this.tpDati.Controls.Add(this.eDataDiNascita);
            this.tpDati.Controls.Add(this.label4);
            this.tpDati.Controls.Add(this.label3);
            this.tpDati.Controls.Add(this.label2);
            this.tpDati.Controls.Add(this.eNome);
            this.tpDati.Controls.Add(this.eNazioneDiNascita);
            this.tpDati.Controls.Add(this.eCognome);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Sesso";
            // 
            // eSesso
            // 
            this.eSesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eSesso.FormattingEnabled = true;
            this.eSesso.Location = new System.Drawing.Point(123, 117);
            this.eSesso.Name = "eSesso";
            this.eSesso.Size = new System.Drawing.Size(215, 21);
            this.eSesso.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Data di nascita";
            // 
            // eDataDiNascita
            // 
            this.eDataDiNascita.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.eDataDiNascita.Location = new System.Drawing.Point(123, 91);
            this.eDataDiNascita.MaxDate = new System.DateTime(9000, 12, 31, 0, 0, 0, 0);
            this.eDataDiNascita.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.eDataDiNascita.Name = "eDataDiNascita";
            this.eDataDiNascita.Size = new System.Drawing.Size(110, 20);
            this.eDataDiNascita.TabIndex = 4;
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
            this.label3.Location = new System.Drawing.Point(17, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Cognome";
            // 
            // eNome
            // 
            this.eNome.Location = new System.Drawing.Point(123, 38);
            this.eNome.MaxLength = 100;
            this.eNome.Name = "eNome";
            this.eNome.Size = new System.Drawing.Size(215, 20);
            this.eNome.TabIndex = 1;
            // 
            // eNazioneDiNascita
            // 
            this.eNazioneDiNascita.Location = new System.Drawing.Point(123, 65);
            this.eNazioneDiNascita.MaxLength = 100;
            this.eNazioneDiNascita.Name = "eNazioneDiNascita";
            this.eNazioneDiNascita.Size = new System.Drawing.Size(215, 20);
            this.eNazioneDiNascita.TabIndex = 2;
            // 
            // eCognome
            // 
            this.eCognome.Location = new System.Drawing.Point(123, 12);
            this.eCognome.MaxLength = 100;
            this.eCognome.Name = "eCognome";
            this.eCognome.Size = new System.Drawing.Size(215, 20);
            this.eCognome.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(371, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Luogo di nascita";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Professione";
            // 
            // eProfessione
            // 
            this.eProfessione.Location = new System.Drawing.Point(123, 144);
            this.eProfessione.MaxLength = 100;
            this.eProfessione.Name = "eProfessione";
            this.eProfessione.Size = new System.Drawing.Size(215, 20);
            this.eProfessione.TabIndex = 6;
            // 
            // eLuogoDiNascita
            // 
            this.eLuogoDiNascita.Location = new System.Drawing.Point(477, 65);
            this.eLuogoDiNascita.MaxLength = 100;
            this.eLuogoDiNascita.Name = "eLuogoDiNascita";
            this.eLuogoDiNascita.Size = new System.Drawing.Size(215, 20);
            this.eLuogoDiNascita.TabIndex = 3;
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(708, 257);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio lead";
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