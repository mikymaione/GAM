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
using GAMSharp.DB.DataWrapper.Base;

namespace GAMSharp.UI.Indirizzi
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.Indirizzi>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {
        private ComboBox eTipo;
        private Controlli.ddlNazione eStato;
        private Label label1;
        private Label label2;
        private Label label3;
        private Controlli.ddlProvincia eProvincia;
        private Label label4;
        private Label label5;
        private Controlli.ddlComune eComune;
        private MaskedTextBox eCAP;
        private Label label6;
        private TextBox eNote;
        private Label label7;
        private Controlli.ucCaseTypeTextBox eIndirizzo;
        private object Entita_Key = null;
        private string Entita_Tipo = "";

#if DEBUG
        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Indirizzi entita)
        {
            return null;
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.Indirizzi> getEntita()
        {
            return new DB.DataWrapper.cIndirizzi();
        }

        protected override DB.DataWrapper.Tabelle.Indirizzi getForm()
        {
            return new DB.DataWrapper.Tabelle.Indirizzi()
            {
                ID = GB.cGB.ObjectToInt(PrimaryKey, -1),
                Entita_Key = Entita_Key,
                Entita_Tipo = Entita_Tipo,
                CAP = eCAP.Text,
                Comune = eComune.Text,
                Provincia = eProvincia.Text,
                Note = eNote.Text,
                Stato = eStato.Text,
                Indirizzo = eIndirizzo.Text,
                Tipo = eTipo.Text
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Indirizzi e)
        {
            eCAP.Text = e.CAP;
            eComune.Text = e.Comune;
            eProvincia.Text = e.Provincia;
            eNote.Text = e.Note;
            eStato.Text = e.Stato;
            eIndirizzo.Text = e.Indirizzo;
            eTipo.Text = e.Tipo;
        }

        protected override void setFormNew()
        {
            //
        }

        protected override List<string> ValidateForm()
        {
            List<string> z = new List<string>();

            if (eCAP.Text.Length != 5)
                z.Add("Valorizzare il campo CAP");
            if (eComune.Text.Length < 3)
                z.Add("Valorizzare il campo Comune");
            if (eProvincia.Text.Length != 2)
                z.Add("Valorizzare il campo Provincia");
            if (eStato.Text.Length < 3)
                z.Add("Valorizzare il campo Stato");
            if (eIndirizzo.Text.Length < 3)
                z.Add("Valorizzare il campo Indirizzo");
            if (eTipo.Text.Length < 3)
                z.Add("Valorizzare il campo Tipo");

            return z;
        }
#endif

        internal Dettaglio(string Entita_Tipo_, object Entita_Key_) : this()
        {
            Entita_Key = Entita_Key_;
            Entita_Tipo = Entita_Tipo_;
        }

        internal Dettaglio()
        {
            InitializeComponent();

            eTipo.Items.Add(new GB.cComboItem("Residenza"));
            eTipo.Items.Add(new GB.cComboItem("Domicilio"));
            eTipo.Items.Add(new GB.cComboItem("Sede"));
            eTipo.Items.Add(new GB.cComboItem("Sede operativa"));
            eTipo.Items.Add(new GB.cComboItem("Sede legale"));
            eTipo.Items.Add(new GB.cComboItem("Sede amministrativa"));
            eTipo.Items.Add(new GB.cComboItem("Succursale"));
            eTipo.Items.Add(new GB.cComboItem("Centro"));
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.eTipo = new System.Windows.Forms.ComboBox();
            this.eStato = new GAMSharp.UI.Controlli.ddlNazione();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eProvincia = new GAMSharp.UI.Controlli.ddlProvincia();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.eComune = new GAMSharp.UI.Controlli.ddlComune();
            this.eCAP = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.eNote = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.eIndirizzo = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.SuspendLayout();
            // 
            // eTipo
            // 
            this.eTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eTipo.Location = new System.Drawing.Point(118, 34);
            this.eTipo.Name = "eTipo";
            this.eTipo.Size = new System.Drawing.Size(261, 21);
            this.eTipo.TabIndex = 0;
            // 
            // eStato
            // 
            this.eStato.Location = new System.Drawing.Point(118, 60);
            this.eStato.MaxLength = 100;
            this.eStato.Name = "eStato";
            this.eStato.Size = new System.Drawing.Size(261, 20);
            this.eStato.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Stato";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Provincia";
            // 
            // eProvincia
            // 
            this.eProvincia.Location = new System.Drawing.Point(118, 86);
            this.eProvincia.MaxLength = 2;
            this.eProvincia.Name = "eProvincia";
            this.eProvincia.Size = new System.Drawing.Size(44, 20);
            this.eProvincia.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "CAP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Comune";
            // 
            // eComune
            // 
            this.eComune.Location = new System.Drawing.Point(118, 138);
            this.eComune.MaxLength = 100;
            this.eComune.Name = "eComune";
            this.eComune.Size = new System.Drawing.Size(261, 20);
            this.eComune.TabIndex = 4;
            // 
            // eCAP
            // 
            this.eCAP.Location = new System.Drawing.Point(118, 112);
            this.eCAP.Mask = "00000";
            this.eCAP.Name = "eCAP";
            this.eCAP.Size = new System.Drawing.Size(53, 20);
            this.eCAP.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Note";
            // 
            // eNote
            // 
            this.eNote.Location = new System.Drawing.Point(118, 190);
            this.eNote.MaxLength = 5000;
            this.eNote.Multiline = true;
            this.eNote.Name = "eNote";
            this.eNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eNote.Size = new System.Drawing.Size(261, 210);
            this.eNote.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Indirizzo";
            // 
            // eIndirizzo
            // 
            this.eIndirizzo.Location = new System.Drawing.Point(118, 164);
            this.eIndirizzo.MaxLength = 300;
            this.eIndirizzo.Name = "eIndirizzo";
            this.eIndirizzo.Size = new System.Drawing.Size(261, 20);
            this.eIndirizzo.TabIndex = 5;
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(397, 412);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.eIndirizzo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.eNote);
            this.Controls.Add(this.eCAP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.eComune);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eProvincia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eStato);
            this.Controls.Add(this.eTipo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio indirizzo";
            this.Controls.SetChildIndex(this.eTipo, 0);
            this.Controls.SetChildIndex(this.eStato, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.eProvincia, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.eComune, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.eCAP, 0);
            this.Controls.SetChildIndex(this.eNote, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.eIndirizzo, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}