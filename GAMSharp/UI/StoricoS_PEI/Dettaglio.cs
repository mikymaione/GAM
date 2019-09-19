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

namespace GAMSharp.UI.StoricoS_PEI
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.StoricoS_PEI>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {
        private TextBox eNote;
        private Label label1;
        private DateTimePicker eFine;
        private DateTimePicker eInizio;
        private Label label3;
        private Label label2;
        private int IDPEI = -1;

#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.StoricoS_PEI> getEntita()
        {
            return new DB.DataWrapper.cStoricoS_PEI();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.StoricoS_PEI e)
        {
            eNote.Text = e.Note;
            eInizio.Value = e.Inizio;

            if (e.Fine > eFine.MinDate)
            {
                eFine.Checked = true;
                eFine.Value = e.Fine;
            }
            else
            {
                eFine.Checked = false;
            }
        }

        protected override void setFormNew()
        {
            eInizio.Value = System.DateTime.Now;
            eFine.Checked = false;
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eFine.Checked && eInizio.Value > eFine.Value)
                z.Add("La data di fine deve essere posteriore alla data di inizio");

            return z;
        }

        protected override DB.DataWrapper.Tabelle.StoricoS_PEI getForm()
        {
            return new DB.DataWrapper.Tabelle.StoricoS_PEI()
            {
                IDPEI = IDPEI,
                Note = eNote.Text,
                Inizio = eInizio.Value,
                Fine = (eFine.Checked ? eFine.Value : System.DateTime.MinValue),
            };
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.StoricoS_PEI entita)
        {
            return null;
        }
#endif

        internal Dettaglio(int IDPEI_) : this()
        {
            IDPEI = IDPEI_;
        }

        internal Dettaglio()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.eNote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eFine = new System.Windows.Forms.DateTimePicker();
            this.eInizio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eNote
            // 
            this.eNote.Location = new System.Drawing.Point(76, 60);
            this.eNote.MaxLength = 5000;
            this.eNote.Multiline = true;
            this.eNote.Name = "eNote";
            this.eNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eNote.Size = new System.Drawing.Size(390, 455);
            this.eNote.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Note";
            // 
            // eFine
            // 
            this.eFine.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eFine.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eFine.Location = new System.Drawing.Point(316, 34);
            this.eFine.Name = "eFine";
            this.eFine.ShowCheckBox = true;
            this.eFine.Size = new System.Drawing.Size(150, 20);
            this.eFine.TabIndex = 1;
            // 
            // eInizio
            // 
            this.eInizio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eInizio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eInizio.Location = new System.Drawing.Point(76, 35);
            this.eInizio.Name = "eInizio";
            this.eInizio.Size = new System.Drawing.Size(138, 20);
            this.eInizio.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Fine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Inizio";
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(479, 527);
            this.Controls.Add(this.eNote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eFine);
            this.Controls.Add(this.eInizio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio storico sottoscrizione PEI";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.eInizio, 0);
            this.Controls.SetChildIndex(this.eFine, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.eNote, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}