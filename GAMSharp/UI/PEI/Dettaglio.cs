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

namespace GAMSharp.UI.PEI
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.PEI>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {
        private TabControl tabControl1;
        private TabPage tpDati;
        private Label label4;
        private TextBox eDimissione_Motivo;
        private TextBox eNote;
        private Label label1;
        private DateTimePicker eData_Compilazione;
        private DateTimePicker eData_Creazione;
        private Label label3;
        private Label label2;
        private TabPage tpPartecipanti;
        private ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private StoricoS_PEI.cRicerca Griglia_StoricoS_PEI;
        private DateTimePicker eData_Dimissione;
        private Label label5;
        private Label label6;
        private ComboBox eStato;
        private string Minore_CF = "";


#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.PEI> getEntita()
        {
            return new DB.DataWrapper.cPEI();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.PEI e)
        {
            eNote.Text = e.Note;
            eDimissione_Motivo.Text = e.Dimissione_Motivo;

            cGB.SetSelectedComboItem_ID(ref eStato, e.Stato);

            eData_Compilazione.Value = e.Data_Compilazione;
            eData_Creazione.Value = e.Data_Creazione;

            if (e.Data_Dimissione > eData_Dimissione.MinDate)
            {
                eData_Dimissione.Checked = true;
                eData_Dimissione.Value = e.Data_Dimissione;
            }
            else
            {
                eData_Dimissione.Checked = false;
            }
        }

        protected override void setFormNew()
        {
            var n = System.DateTime.Now;

            eData_Creazione.Value = n;
            eData_Compilazione.Value = n.AddMinutes(+30);
            eData_Dimissione.Checked = false;

            eStato.SelectedIndex = 0;

            tpPartecipanti.Enabled = false;
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eData_Creazione.Value > eData_Compilazione.Value)
                z.Add("La data di compilazione deve essere maggiore della data di creazione");
            if (eData_Dimissione.Checked && eData_Compilazione.Value > eData_Dimissione.Value)
                z.Add("La data di dimissione deve essere maggiore della data di compilazione");
            if (eStato.SelectedIndex < 0)
                z.Add("Il campo stato non è valorizzato");

            return z;
        }

        protected override DB.DataWrapper.Tabelle.PEI getForm()
        {
            return new DB.DataWrapper.Tabelle.PEI()
            {
                ID = cGB.ObjectToInt(PrimaryKey, -1),
                Minore_CF = Minore_CF,

                Data_Compilazione = eData_Compilazione.Value,
                Data_Creazione = eData_Creazione.Value,
                Data_Dimissione = (eData_Dimissione.Checked ? eData_Dimissione.Value : System.DateTime.MinValue),

                Stato = cGB.GetSelectedComboItem_Valore(eStato),
                Note = eNote.Text
            };
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.PEI entita)
        {
            return null;
        }
#endif

        public override DialogResult ShowDialog(object PrimaryKey_)
        {
            Griglia_StoricoS_PEI.IDPEI = cGB.ObjectToInt(PrimaryKey_, -1);

            return base.ShowDialog(PrimaryKey_);
        }

        internal Dettaglio(string Minore_CF_) : this()
        {
            Minore_CF = Minore_CF_;
        }

        internal Dettaglio()
        {
            InitializeComponent();

            Griglia_StoricoS_PEI.RicercaVisibile = false;

            eStato.Items.Add(new cComboItem("In compilazione"));
            eStato.Items.Add(new cComboItem("Compilato"));
            eStato.Items.Add(new cComboItem("Sottoscritto"));
            eStato.Items.Add(new cComboItem("Dimesso"));
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDati = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.eDimissione_Motivo = new System.Windows.Forms.TextBox();
            this.eNote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eData_Compilazione = new System.Windows.Forms.DateTimePicker();
            this.eData_Creazione = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpPartecipanti = new System.Windows.Forms.TabPage();
            this.Griglia_StoricoS_PEI = new GAMSharp.UI.StoricoS_PEI.cRicerca();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.eData_Dimissione = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.eStato = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.tabControl1.Size = new System.Drawing.Size(774, 511);
            this.tabControl1.TabIndex = 2;
            // 
            // tpDati
            // 
            this.tpDati.Controls.Add(this.label6);
            this.tpDati.Controls.Add(this.eStato);
            this.tpDati.Controls.Add(this.eData_Dimissione);
            this.tpDati.Controls.Add(this.label5);
            this.tpDati.Controls.Add(this.label4);
            this.tpDati.Controls.Add(this.eDimissione_Motivo);
            this.tpDati.Controls.Add(this.eNote);
            this.tpDati.Controls.Add(this.label1);
            this.tpDati.Controls.Add(this.eData_Compilazione);
            this.tpDati.Controls.Add(this.eData_Creazione);
            this.tpDati.Controls.Add(this.label3);
            this.tpDati.Controls.Add(this.label2);
            this.tpDati.ImageIndex = 0;
            this.tpDati.Location = new System.Drawing.Point(4, 23);
            this.tpDati.Name = "tpDati";
            this.tpDati.Padding = new System.Windows.Forms.Padding(3);
            this.tpDati.Size = new System.Drawing.Size(766, 484);
            this.tpDati.TabIndex = 0;
            this.tpDati.Text = "Dati";
            this.tpDati.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Motivo dimissione";
            // 
            // eDimissione_Motivo
            // 
            this.eDimissione_Motivo.Location = new System.Drawing.Point(112, 64);
            this.eDimissione_Motivo.MaxLength = 3000;
            this.eDimissione_Motivo.Multiline = true;
            this.eDimissione_Motivo.Name = "eDimissione_Motivo";
            this.eDimissione_Motivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eDimissione_Motivo.Size = new System.Drawing.Size(640, 73);
            this.eDimissione_Motivo.TabIndex = 4;
            // 
            // eNote
            // 
            this.eNote.Location = new System.Drawing.Point(112, 143);
            this.eNote.MaxLength = 5000;
            this.eNote.Multiline = true;
            this.eNote.Name = "eNote";
            this.eNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eNote.Size = new System.Drawing.Size(640, 333);
            this.eNote.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Note";
            // 
            // eData_Compilazione
            // 
            this.eData_Compilazione.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eData_Compilazione.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eData_Compilazione.Location = new System.Drawing.Point(364, 10);
            this.eData_Compilazione.Name = "eData_Compilazione";
            this.eData_Compilazione.Size = new System.Drawing.Size(138, 20);
            this.eData_Compilazione.TabIndex = 1;
            // 
            // eData_Creazione
            // 
            this.eData_Creazione.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eData_Creazione.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eData_Creazione.Location = new System.Drawing.Point(112, 11);
            this.eData_Creazione.Name = "eData_Creazione";
            this.eData_Creazione.Size = new System.Drawing.Size(138, 20);
            this.eData_Creazione.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Compilazione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Creazione";
            // 
            // tpPartecipanti
            // 
            this.tpPartecipanti.Controls.Add(this.Griglia_StoricoS_PEI);
            this.tpPartecipanti.ImageIndex = 1;
            this.tpPartecipanti.Location = new System.Drawing.Point(4, 23);
            this.tpPartecipanti.Name = "tpPartecipanti";
            this.tpPartecipanti.Padding = new System.Windows.Forms.Padding(3);
            this.tpPartecipanti.Size = new System.Drawing.Size(646, 484);
            this.tpPartecipanti.TabIndex = 1;
            this.tpPartecipanti.Text = "Storico sottoscrizione PEI";
            this.tpPartecipanti.UseVisualStyleBackColor = true;
            // 
            // Griglia_StoricoS_PEI
            // 
            this.Griglia_StoricoS_PEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_StoricoS_PEI.Name = "Griglia_StoricoS_PEI";
            this.Griglia_StoricoS_PEI.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "document_prepare.png");
            this.imageList1.Images.SetKeyName(1, "clock_history_frame.ico");
            // 
            // eData_Dimissione
            // 
            this.eData_Dimissione.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eData_Dimissione.ShowCheckBox = true;
            this.eData_Dimissione.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eData_Dimissione.Location = new System.Drawing.Point(604, 10);
            this.eData_Dimissione.Name = "eData_Dimissione";
            this.eData_Dimissione.Size = new System.Drawing.Size(148, 20);
            this.eData_Dimissione.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(514, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Dimissione";
            // 
            // eStato
            // 
            this.eStato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eStato.FormattingEnabled = true;
            this.eStato.Location = new System.Drawing.Point(112, 37);
            this.eStato.Name = "eStato";
            this.eStato.Size = new System.Drawing.Size(252, 21);
            this.eStato.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Stato";
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(774, 533);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio PEI";
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