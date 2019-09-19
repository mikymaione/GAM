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

namespace GAMSharp.UI.Colloquio
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.Colloquio>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {
        private TabControl tabControl1;
        private TabPage tpDati;
        private CheckBox eMostraInPEI;
        private Label label4;
        private TextBox eDescrizione;
        private TextBox eNote;
        private Label label1;
        private DateTimePicker eFine;
        private DateTimePicker eInizio;
        private Label label3;
        private Label label2;
        private TabPage tpPartecipanti;
        private ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private ColloquioPresenze.cRicerca Griglia_ColloquioPresenze;
        private string Minore_CF = "";


#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.Colloquio> getEntita()
        {
            return new DB.DataWrapper.cColloquio();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Colloquio e)
        {
            eDescrizione.Text = e.Descrizione;
            eNote.Text = e.Note;
            eInizio.Value = e.Inizio;
            eFine.Value = e.Fine;
            eMostraInPEI.Checked = cGB.EnglishVarCharToBool(e.MostraInPEI);
        }

        protected override void setFormNew()
        {
            var n = System.DateTime.Now;

            eFine.Value = n;
            eInizio.Value = n.AddMinutes(-50);

            tpPartecipanti.Enabled = false;
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eDescrizione.Text.Length < 2)
                z.Add("Il campo descrizione è troppo breve");
            if (eFine.Value < eInizio.Value)
                z.Add("Il campo fine deve essere maggiore del campo inizio");

            return z;
        }

        protected override DB.DataWrapper.Tabelle.Colloquio getForm()
        {
            return new DB.DataWrapper.Tabelle.Colloquio()
            {
                ID = cGB.ObjectToInt(PrimaryKey, -1),
                Minore_CF = Minore_CF,
                Descrizione = eDescrizione.Text,
                Note = eNote.Text,
                MostraInPEI = cGB.BoolToEnglishChar(eMostraInPEI.Checked),
                Inizio = eInizio.Value,
                Fine = eFine.Value
            };
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Colloquio entita)
        {
            return null;
        }
#endif

        public override DialogResult ShowDialog(object PrimaryKey_)
        {            
            Griglia_ColloquioPresenze.IDColloquio = cGB.ObjectToInt(PrimaryKey_, -1);

            return base.ShowDialog(PrimaryKey_);
        }

        internal Dettaglio(string Minore_CF_) : this()
        {
            Minore_CF = Minore_CF_;
        }

        internal Dettaglio()
        {
            InitializeComponent();
            PossoEssereFullScreen = true;

            Griglia_ColloquioPresenze.RicercaVisibile = false;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDati = new System.Windows.Forms.TabPage();
            this.eMostraInPEI = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.eDescrizione = new System.Windows.Forms.TextBox();
            this.eNote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eFine = new System.Windows.Forms.DateTimePicker();
            this.eInizio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpPartecipanti = new System.Windows.Forms.TabPage();
            this.Griglia_ColloquioPresenze = new GAMSharp.UI.ColloquioPresenze.cRicerca();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tpDati.SuspendLayout();
            this.tpPartecipanti.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpDati);
            this.tabControl1.Controls.Add(this.tpPartecipanti);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(654, 511);
            this.tabControl1.TabIndex = 2;
            // 
            // tpDati
            // 
            this.tpDati.Controls.Add(this.eMostraInPEI);
            this.tpDati.Controls.Add(this.label4);
            this.tpDati.Controls.Add(this.eDescrizione);
            this.tpDati.Controls.Add(this.eNote);
            this.tpDati.Controls.Add(this.label1);
            this.tpDati.Controls.Add(this.eFine);
            this.tpDati.Controls.Add(this.eInizio);
            this.tpDati.Controls.Add(this.label3);
            this.tpDati.Controls.Add(this.label2);
            this.tpDati.ImageIndex = 0;
            this.tpDati.Location = new System.Drawing.Point(4, 23);
            this.tpDati.Name = "tpDati";
            this.tpDati.Padding = new System.Windows.Forms.Padding(3);
            this.tpDati.Size = new System.Drawing.Size(646, 484);
            this.tpDati.TabIndex = 0;
            this.tpDati.Text = "Dati";
            this.tpDati.UseVisualStyleBackColor = true;
            // 
            // eMostraInPEI
            // 
            this.eMostraInPEI.AutoSize = true;
            this.eMostraInPEI.Checked = true;
            this.eMostraInPEI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.eMostraInPEI.Location = new System.Drawing.Point(81, 38);
            this.eMostraInPEI.Name = "eMostraInPEI";
            this.eMostraInPEI.Size = new System.Drawing.Size(95, 17);
            this.eMostraInPEI.TabIndex = 2;
            this.eMostraInPEI.Text = "Mostra nel PEI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Descrizione";
            // 
            // eDescrizione
            // 
            this.eDescrizione.Location = new System.Drawing.Point(81, 63);
            this.eDescrizione.MaxLength = 250;
            this.eDescrizione.Multiline = true;
            this.eDescrizione.Name = "eDescrizione";
            this.eDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eDescrizione.Size = new System.Drawing.Size(557, 73);
            this.eDescrizione.TabIndex = 3;
            // 
            // eNote
            // 
            this.eNote.Location = new System.Drawing.Point(81, 142);
            this.eNote.MaxLength = 5000;
            this.eNote.Multiline = true;
            this.eNote.Name = "eNote";
            this.eNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eNote.Size = new System.Drawing.Size(557, 333);
            this.eNote.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Note";
            // 
            // eFine
            // 
            this.eFine.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eFine.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eFine.Location = new System.Drawing.Point(333, 10);
            this.eFine.Name = "eFine";
            this.eFine.Size = new System.Drawing.Size(138, 20);
            this.eFine.TabIndex = 1;
            // 
            // eInizio
            // 
            this.eInizio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eInizio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eInizio.Location = new System.Drawing.Point(81, 11);
            this.eInizio.Name = "eInizio";
            this.eInizio.Size = new System.Drawing.Size(138, 20);
            this.eInizio.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Fine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Inizio";
            // 
            // tpPartecipanti
            // 
            this.tpPartecipanti.Controls.Add(this.Griglia_ColloquioPresenze);
            this.tpPartecipanti.ImageIndex = 1;
            this.tpPartecipanti.Location = new System.Drawing.Point(4, 23);
            this.tpPartecipanti.Name = "tpPartecipanti";
            this.tpPartecipanti.Padding = new System.Windows.Forms.Padding(3);
            this.tpPartecipanti.Size = new System.Drawing.Size(646, 484);
            this.tpPartecipanti.TabIndex = 1;
            this.tpPartecipanti.Text = "Partecipanti";
            this.tpPartecipanti.UseVisualStyleBackColor = true;
            // 
            // Griglia_ColloquioPresenze
            // 
            this.Griglia_ColloquioPresenze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_ColloquioPresenze.Name = "Griglia_ColloquioPresenze";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "document_prepare.png");
            this.imageList1.Images.SetKeyName(1, "report_user.png");
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(654, 533);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio colloquio";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tpDati.ResumeLayout(false);
            this.tpDati.PerformLayout();
            this.tpPartecipanti.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}