/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Base;
using System.Collections.Generic;
using System.Windows.Forms;
using GAMSharp.DB.DataWrapper.Tabelle;

namespace GAMSharp.UI.Utente
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.Utente>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif    
    {
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ePsw;
        private System.Windows.Forms.TextBox eEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox eTipo;
        private Controlli.ucLookUp ePersona_CF;
        private CheckBox eFullScreen_Ricerca;
        private CheckBox eFullScreen_Dettaglio;
        private System.Windows.Forms.Label label1;

#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.Utente> getEntita()
        {
            return new DB.DataWrapper.cUtente();
        }

        protected override DB.DataWrapper.Tabelle.Utente getForm()
        {
            return new DB.DataWrapper.Tabelle.Utente()
            {
                Persona_CF = (string)ePersona_CF.Value,
                Email = eEmail.Text,
                Psw = ePsw.Text,
                Tipo = (char)GB.cGB.GetSelectedComboItem_ID(eTipo),
                FullScreen_Dettaglio = GB.cGB.BoolToEnglishChar(eFullScreen_Dettaglio.Checked),
                FullScreen_Ricerca = GB.cGB.BoolToEnglishChar(eFullScreen_Ricerca.Checked)
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Utente e)
        {
            ePersona_CF.Value = e.Persona_CF;
            ePersona_CF.Text = e.ExRicerca.RagioneSociale;
            eEmail.Text = e.Email;
            ePsw.Text = e.Psw;
            eFullScreen_Dettaglio.Checked = GB.cGB.EnglishVarCharToBool(e.FullScreen_Dettaglio);
            eFullScreen_Ricerca.Checked = GB.cGB.EnglishVarCharToBool(e.FullScreen_Ricerca);
            GB.cGB.SetSelectedComboItem_ID(ref eTipo, e.Tipo);
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Utente entita)
        {
            return new Control[] {
                ePersona_CF
            };
        }

        protected override void setFormNew()
        {
            eTipo.SelectedIndex = 0;
        }

        protected override void PostSalva(DB.DataWrapper.Tabelle.Utente entita)
        {
            base.PostSalva(entita);

            if (DB.cMemDB.UtenteConnesso.Persona_CF.Equals(entita.Persona_CF))
                DB.cMemDB.UtenteConnesso = entita;
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (ePersona_CF.Value == null)
                z.Add("Selezionare una persona");
            if (eEmail.Text.Length < 5)
                z.Add("L'email deve essere di almeno 5 caratteri");
            if (ePsw.Text.Length < 2)
                z.Add("La password deve essere di almeno 2 caratteri");

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
            using (var r = new Persona.Dettaglio())
                if (r.ShowDialog(Key) == DialogResult.OK)
                    ePersona_CF.Text = RiCaricaEntita().ExRicerca.RagioneSociale;
#endif
        }

        internal Dettaglio()
        {
            InitializeComponent();

            ePersona_CF.RicercaRichiesta += ePersona_CF_RicercaRichiesta;
            ePersona_CF.DettaglioRichiesto += ePersona_CF_DettaglioRichiesto;

            eTipo.Items.Add(new GB.cComboItem('U', "Utente"));
            eTipo.Items.Add(new GB.cComboItem('A', "Amministratore"));
            eTipo.Enabled = DB.cMemDB.UtenteConnesso.Tipo.Equals('A');
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ePsw = new System.Windows.Forms.TextBox();
            this.eEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.eTipo = new System.Windows.Forms.ComboBox();
            this.ePersona_CF = new GAMSharp.UI.Controlli.ucLookUp();
            this.eFullScreen_Ricerca = new System.Windows.Forms.CheckBox();
            this.eFullScreen_Dettaglio = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Email";
            // 
            // ePsw
            // 
            this.ePsw.Location = new System.Drawing.Point(126, 87);
            this.ePsw.MaxLength = 40;
            this.ePsw.Name = "ePsw";
            this.ePsw.Size = new System.Drawing.Size(215, 20);
            this.ePsw.TabIndex = 2;
            // 
            // eEmail
            // 
            this.eEmail.Location = new System.Drawing.Point(126, 61);
            this.eEmail.MaxLength = 200;
            this.eEmail.Name = "eEmail";
            this.eEmail.Size = new System.Drawing.Size(215, 20);
            this.eEmail.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Persona";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tipo";
            // 
            // eTipo
            // 
            this.eTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eTipo.FormattingEnabled = true;
            this.eTipo.Location = new System.Drawing.Point(126, 113);
            this.eTipo.Name = "eTipo";
            this.eTipo.Size = new System.Drawing.Size(215, 21);
            this.eTipo.TabIndex = 3;
            // 
            // ePersona_CF
            // 
            this.ePersona_CF.Elemento = ((System.Tuple<object, string>)(resources.GetObject("ePersona_CF.Elemento")));
            this.ePersona_CF.Location = new System.Drawing.Point(126, 33);
            this.ePersona_CF.Name = "ePersona_CF";
            this.ePersona_CF.ReadOnly = false;
            this.ePersona_CF.Size = new System.Drawing.Size(215, 25);
            this.ePersona_CF.TabIndex = 0;
            this.ePersona_CF.Tipo = null;
            this.ePersona_CF.Value = null;
            // 
            // eFullScreen_Ricerca
            // 
            this.eFullScreen_Ricerca.AutoSize = true;
            this.eFullScreen_Ricerca.Location = new System.Drawing.Point(23, 143);
            this.eFullScreen_Ricerca.Name = "eFullScreen_Ricerca";
            this.eFullScreen_Ricerca.Size = new System.Drawing.Size(227, 17);
            this.eFullScreen_Ricerca.TabIndex = 4;
            this.eFullScreen_Ricerca.Text = "Finestre di ricerca sempre a schermo intero";
            this.eFullScreen_Ricerca.UseVisualStyleBackColor = true;
            // 
            // eFullScreen_Dettaglio
            // 
            this.eFullScreen_Dettaglio.AutoSize = true;
            this.eFullScreen_Dettaglio.Location = new System.Drawing.Point(23, 169);
            this.eFullScreen_Dettaglio.Name = "eFullScreen_Dettaglio";
            this.eFullScreen_Dettaglio.Size = new System.Drawing.Size(307, 17);
            this.eFullScreen_Dettaglio.TabIndex = 5;
            this.eFullScreen_Dettaglio.Text = "Finestre di dettaglio sempre a schermo intero (se disponibile)";
            this.eFullScreen_Dettaglio.UseVisualStyleBackColor = true;
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(367, 205);
            this.Controls.Add(this.eFullScreen_Dettaglio);
            this.Controls.Add(this.eFullScreen_Ricerca);
            this.Controls.Add(this.ePersona_CF);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.eTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ePsw);
            this.Controls.Add(this.eEmail);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio utente";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.eEmail, 0);
            this.Controls.SetChildIndex(this.ePsw, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.eTipo, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.ePersona_CF, 0);
            this.Controls.SetChildIndex(this.eFullScreen_Ricerca, 0);
            this.Controls.SetChildIndex(this.eFullScreen_Dettaglio, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}