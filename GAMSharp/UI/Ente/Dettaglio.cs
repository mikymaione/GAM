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

namespace GAMSharp.UI.Ente
{
#if DEBUG
    class Dettaglio : Base.Ex.fTabbedDettaglio<DB.DataWrapper.Tabelle.Ente>
#else
    class Dettaglio : UI.Base.Ex.fFakeTabbedDettaglio
#endif
    {
        public Label label2;
        public Label label1;
        public ComboBox eTipo;
        internal Controlli.ucCaseTypeTextBox eDescrizione;

#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.Ente> getEntita()
        {
            return new DB.DataWrapper.cEnte();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Ente e)
        {
            eDescrizione.Text = e.Descrizione;
            GB.cGB.SetSelectedComboItem_ID(ref eTipo, e.Tipo);
        }

        protected override DB.DataWrapper.Tabelle.Ente getForm()
        {
            return new DB.DataWrapper.Tabelle.Ente()
            {
                ID = GB.cGB.ObjectToInt(PrimaryKey, -1),
                Descrizione = eDescrizione.Text,
                Tipo = GB.cGB.GetSelectedComboItem_ID(eTipo) as string
            };
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Ente entita)
        {
            return null;
        }

        protected override void setFormNew()
        {
            eDescrizione.Select();
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eDescrizione.Text.Length < 4)
                z.Add("La descrizione deve essere almeno di 3 caratteri");
            if (eTipo.SelectedIndex < 0)
                z.Add("Selezionare un tipo");

            return z;
        }
#endif

        internal Dettaglio() : base("Ente")
        {            
            InitializeComponent();

            var c = new ComboFiller();
            c.Fill_eTipo(ref eTipo, false);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.eTipo = new System.Windows.Forms.ComboBox();
            this.eDescrizione = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.tabControl1.SuspendLayout();
            this.tpIndirizzi.SuspendLayout();
            this.tpInfoAggiuntive.SuspendLayout();
            this.tpRecapiti.SuspendLayout();
            this.tpDati.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpIndirizzi
            // 
            this.tpIndirizzi.Location = new System.Drawing.Point(4, 22);
            this.tpIndirizzi.Size = new System.Drawing.Size(700, 209);
            // 
            // tpInfoAggiuntive
            // 
            this.tpInfoAggiuntive.Location = new System.Drawing.Point(4, 22);
            this.tpInfoAggiuntive.Size = new System.Drawing.Size(700, 209);
            // 
            // tpRecapiti
            // 
            this.tpRecapiti.Location = new System.Drawing.Point(4, 22);
            this.tpRecapiti.Size = new System.Drawing.Size(700, 209);
            // 
            // tpDati
            // 
            this.tpDati.Controls.Add(this.label2);
            this.tpDati.Controls.Add(this.label1);
            this.tpDati.Controls.Add(this.eTipo);
            this.tpDati.Controls.Add(this.eDescrizione);
            this.tpDati.Location = new System.Drawing.Point(4, 22);
            this.tpDati.Size = new System.Drawing.Size(700, 209);
            // 
            // Griglia_Indirizzi
            // 
            this.Griglia_Indirizzi.Size = new System.Drawing.Size(694, 203);
            // 
            // Griglia_Recapiti
            // 
            this.Griglia_Recapiti.Size = new System.Drawing.Size(694, 203);
            // 
            // Griglia_InfoAggiuntive
            // 
            this.Griglia_InfoAggiuntive.Size = new System.Drawing.Size(694, 203);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Descrizione";
            // 
            // eTipo
            // 
            this.eTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eTipo.FormattingEnabled = true;
            this.eTipo.Location = new System.Drawing.Point(76, 44);
            this.eTipo.Name = "eTipo";
            this.eTipo.Size = new System.Drawing.Size(336, 21);
            this.eTipo.Sorted = true;
            this.eTipo.TabIndex = 1;
            // 
            // eDescrizione
            // 
            this.eDescrizione.Location = new System.Drawing.Point(76, 18);
            this.eDescrizione.MaxLength = 400;
            this.eDescrizione.Name = "eDescrizione";
            this.eDescrizione.Size = new System.Drawing.Size(336, 20);
            this.eDescrizione.TabIndex = 0;
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(708, 257);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio ente";
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