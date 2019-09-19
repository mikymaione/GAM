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
using GAMSharp.GB;
using System;

namespace GAMSharp.UI.GruppoSostegnoG
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.GruppoSostegnoG>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif    
    {
        private TabControl tabControl1;
        private TabPage tpDati;
        private DateTimePicker eFine;
        private DateTimePicker eInizio;
        private Label label5;
        private Label label4;
        private TextBox eNote;
        private Label label3;
        private Label label2;
        private TextBox eDescrizione;
        private ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private TabPage tpPartecipanti;
        private GSG_Partecipanti.cRicerca Griglia_GSG_Partecipanti;

        internal Dettaglio()
        {            
            InitializeComponent();
            PossoEssereFullScreen = true;

            Griglia_GSG_Partecipanti.RicercaVisibile = false;
        }

        public override DialogResult ShowDialog(object PrimaryKey_)
        {
            Griglia_GSG_Partecipanti.IDGruppoSostegnoG = cGB.ObjectToInt(PrimaryKey_, -1);

            return base.ShowDialog(PrimaryKey_);
        }

#if DEBUG
        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.GruppoSostegnoG entita)
        {
            return null;
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.GruppoSostegnoG> getEntita()
        {
            return new DB.DataWrapper.cGruppoSostegnoG();
        }

        protected override DB.DataWrapper.Tabelle.GruppoSostegnoG getForm()
        {
            return new DB.DataWrapper.Tabelle.GruppoSostegnoG()
            {
                ID = cGB.ObjectToInt(PrimaryKey, -1),
                Descrizione = eDescrizione.Text,
                Note = eNote.Text,
                Inizio = eInizio.Value,
                Fine = (eFine.Checked ? eFine.Value : DateTime.MinValue)
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.GruppoSostegnoG e)
        {
            eDescrizione.Text = e.Descrizione;
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
            tpPartecipanti.Enabled = false;
            eFine.Checked = false;
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eDescrizione.Text.Length < 4)
                z.Add("Scrivere una descrizione");
            if (eInizio.Value > eFine.Value)
                z.Add("La data di inizio deve essere minore della data di fine");

            return z;
        }
#endif        

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDati = new System.Windows.Forms.TabPage();
            this.eFine = new System.Windows.Forms.DateTimePicker();
            this.eInizio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.eNote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eDescrizione = new System.Windows.Forms.TextBox();
            this.tpPartecipanti = new System.Windows.Forms.TabPage();
            this.Griglia_GSG_Partecipanti = new GAMSharp.UI.GSG_Partecipanti.cRicerca();
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
            this.tabControl1.Size = new System.Drawing.Size(584, 439);
            this.tabControl1.TabIndex = 2;
            // 
            // tpDati
            // 
            this.tpDati.Controls.Add(this.eFine);
            this.tpDati.Controls.Add(this.eInizio);
            this.tpDati.Controls.Add(this.label5);
            this.tpDati.Controls.Add(this.label4);
            this.tpDati.Controls.Add(this.eNote);
            this.tpDati.Controls.Add(this.label3);
            this.tpDati.Controls.Add(this.label2);
            this.tpDati.Controls.Add(this.eDescrizione);
            this.tpDati.ImageIndex = 0;
            this.tpDati.Location = new System.Drawing.Point(4, 23);
            this.tpDati.Name = "tpDati";
            this.tpDati.Padding = new System.Windows.Forms.Padding(3);
            this.tpDati.Size = new System.Drawing.Size(576, 412);
            this.tpDati.TabIndex = 0;
            this.tpDati.Text = "Dati";
            this.tpDati.UseVisualStyleBackColor = true;
            // 
            // eFine
            // 
            this.eFine.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eFine.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eFine.Location = new System.Drawing.Point(112, 32);
            this.eFine.Name = "eFine";
            this.eFine.ShowCheckBox = true;
            this.eFine.Size = new System.Drawing.Size(157, 20);
            this.eFine.TabIndex = 1;
            // 
            // eInizio
            // 
            this.eInizio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eInizio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eInizio.Location = new System.Drawing.Point(112, 6);
            this.eInizio.Name = "eInizio";
            this.eInizio.Size = new System.Drawing.Size(157, 20);
            this.eInizio.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Note";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Descrizione";
            // 
            // eNote
            // 
            this.eNote.Location = new System.Drawing.Point(112, 168);
            this.eNote.MaxLength = 5000;
            this.eNote.Multiline = true;
            this.eNote.Name = "eNote";
            this.eNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eNote.Size = new System.Drawing.Size(456, 236);
            this.eNote.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Fine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Inizio";
            // 
            // eDescrizione
            // 
            this.eDescrizione.Location = new System.Drawing.Point(112, 58);
            this.eDescrizione.MaxLength = 250;
            this.eDescrizione.Multiline = true;
            this.eDescrizione.Name = "eDescrizione";
            this.eDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eDescrizione.Size = new System.Drawing.Size(456, 104);
            this.eDescrizione.TabIndex = 2;
            // 
            // tpPartecipanti
            // 
            this.tpPartecipanti.Controls.Add(this.Griglia_GSG_Partecipanti);
            this.tpPartecipanti.ImageIndex = 1;
            this.tpPartecipanti.Location = new System.Drawing.Point(4, 23);
            this.tpPartecipanti.Name = "tpPartecipanti";
            this.tpPartecipanti.Padding = new System.Windows.Forms.Padding(3);
            this.tpPartecipanti.Size = new System.Drawing.Size(576, 412);
            this.tpPartecipanti.TabIndex = 3;
            this.tpPartecipanti.Text = "Partecipanti";
            this.tpPartecipanti.UseVisualStyleBackColor = true;
            // 
            // Griglia_GSG_Partecipanti
            // 
            this.Griglia_GSG_Partecipanti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_GSG_Partecipanti.Name = "Griglia_GSG_Partecipanti";
            this.Griglia_GSG_Partecipanti.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "document_prepare.png");
            this.imageList1.Images.SetKeyName(1, "users_4.ico");
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Dettaglio";
            this.Text = "Dettaglio gruppo sostegno genitorialità";
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