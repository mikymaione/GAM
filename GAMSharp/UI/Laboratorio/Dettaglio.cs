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

namespace GAMSharp.UI.Laboratorio
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.Laboratorio>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif    
    {
        private List<GB.cComboItem> Scaglioni;

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
        private Controlli.ucLookUp eCFResponsabile;
        private Label label1;
        private ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private UI.OrariLaboratori.cRicerca Griglia_Orari;
        private TabPage tpEducatrici;
        private UI.Educatrice_Laboratorio.cRicerca Griglia_Educatrici;
        private TabPage tpSvolgimentoLaboratorio;
        private SvolgimentoLaboratorio.cRicerca Griglia_SvolgimentoLaboratorio;
        private Label label6;
        private ComboBox eIDScaglioniDiEta;
        private TabPage tpOrari;

        internal Dettaglio()
        {
            //Griglia_Orari = new UI.OrariLaboratori.cRicerca();
            //Griglia_Educatrici = new UI.Educatrice_Laboratorio.cRicerca();            
            InitializeComponent();
            PossoEssereFullScreen = true;

            eCFResponsabile.RicercaRichiesta += eCFResponsabile_RicercaRichiesta;
            eCFResponsabile.DettaglioRichiesto += eCFResponsabile_DettaglioRichiesto;

            Griglia_Educatrici.RicercaVisibile = false;
            Griglia_SvolgimentoLaboratorio.RicercaVisibile = false;
            Griglia_Orari.RicercaVisibile = false;

            var ScaglioniDiEta_ = new DB.DataWrapper.cScaglioniDiEta();
            Scaglioni = ScaglioniDiEta_.GetAll();
            eIDScaglioniDiEta.DataSource = Scaglioni;
        }

        public override DialogResult ShowDialog(object PrimaryKey_)
        {
            Griglia_Orari.IDLaboratorio = cGB.ObjectToInt(PrimaryKey_, -1);
            Griglia_Educatrici.IDLaboratorio = cGB.ObjectToInt(PrimaryKey_, -1);
            Griglia_SvolgimentoLaboratorio.IDLaboratorio = cGB.ObjectToInt(PrimaryKey_, -1);

            return base.ShowDialog(PrimaryKey_);
        }

        private void eCFResponsabile_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var r = new Persona.Dettaglio())
                if (r.ShowDialog(Key) == DialogResult.OK)
                    eCFResponsabile.Text = RiCaricaEntita().ExRicerca.Responsabile;
#endif
        }

        private void eCFResponsabile_RicercaRichiesta()
        {
            using (var r = new Persona.Ricerca())
                eCFResponsabile.Elemento = r.LookUp();
        }

#if DEBUG
        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Laboratorio entita)
        {
            return null;
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.Laboratorio> getEntita()
        {
            return new DB.DataWrapper.cLaboratorio();
        }

        protected override DB.DataWrapper.Tabelle.Laboratorio getForm()
        {
            return new DB.DataWrapper.Tabelle.Laboratorio()
            {
                ID = cGB.ObjectToInt(PrimaryKey, -1),
                CFResponsabile = (string)eCFResponsabile.Value,
                Descrizione = eDescrizione.Text,
                IDScaglioniDiEta = cGB.ObjectToInt(cGB.GetSelectedComboItem_ID(eIDScaglioniDiEta), -1),
                Note = eNote.Text,
                Inizio = eInizio.Value,
                Fine = eFine.Value
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Laboratorio e)
        {
            eDescrizione.Text = e.Descrizione;
            eNote.Text = e.Note;
            eInizio.Value = e.Inizio;
            eFine.Value = e.Fine;
            eCFResponsabile.Value = e.CFResponsabile;
            eCFResponsabile.Text = e.ExRicerca.Responsabile;
            cGB.SetSelectedComboItem_ID(ref eIDScaglioniDiEta, e.IDScaglioniDiEta);
        }

        protected override void setFormNew()
        {
            tpEducatrici.Enabled = false;
            tpOrari.Enabled = false;
            tpSvolgimentoLaboratorio.Enabled = false;
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eCFResponsabile.Value == null)
                z.Add("Selezionare una persona");
            if (eDescrizione.Text.Length < 4)
                z.Add("Scrivere una descrizione");
            if (eInizio.Value > eFine.Value)
                z.Add("La data di inizio deve essere minore della data di fine");
            if (eIDScaglioniDiEta.SelectedIndex < 0)
                z.Add("Selezionare uno scaglione");

            return z;
        }
#endif        

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDati = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.eIDScaglioniDiEta = new System.Windows.Forms.ComboBox();
            this.eFine = new System.Windows.Forms.DateTimePicker();
            this.eInizio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.eNote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eDescrizione = new System.Windows.Forms.TextBox();
            this.eCFResponsabile = new GAMSharp.UI.Controlli.ucLookUp();
            this.label1 = new System.Windows.Forms.Label();
            this.tpOrari = new System.Windows.Forms.TabPage();
            this.Griglia_Orari = new GAMSharp.UI.OrariLaboratori.cRicerca();
            this.tpEducatrici = new System.Windows.Forms.TabPage();
            this.Griglia_Educatrici = new GAMSharp.UI.Educatrice_Laboratorio.cRicerca();
            this.tpSvolgimentoLaboratorio = new System.Windows.Forms.TabPage();
            this.Griglia_SvolgimentoLaboratorio = new GAMSharp.UI.SvolgimentoLaboratorio.cRicerca();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tpDati.SuspendLayout();
            this.tpOrari.SuspendLayout();
            this.tpEducatrici.SuspendLayout();
            this.tpSvolgimentoLaboratorio.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpDati);
            this.tabControl1.Controls.Add(this.tpOrari);
            this.tabControl1.Controls.Add(this.tpEducatrici);
            this.tabControl1.Controls.Add(this.tpSvolgimentoLaboratorio);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 437);
            this.tabControl1.TabIndex = 2;
            // 
            // tpDati
            // 
            this.tpDati.Controls.Add(this.label6);
            this.tpDati.Controls.Add(this.eIDScaglioniDiEta);
            this.tpDati.Controls.Add(this.eFine);
            this.tpDati.Controls.Add(this.eInizio);
            this.tpDati.Controls.Add(this.label5);
            this.tpDati.Controls.Add(this.label4);
            this.tpDati.Controls.Add(this.eNote);
            this.tpDati.Controls.Add(this.label3);
            this.tpDati.Controls.Add(this.label2);
            this.tpDati.Controls.Add(this.eDescrizione);
            this.tpDati.Controls.Add(this.eCFResponsabile);
            this.tpDati.Controls.Add(this.label1);
            this.tpDati.ImageIndex = 0;
            this.tpDati.Location = new System.Drawing.Point(4, 23);
            this.tpDati.Name = "tpDati";
            this.tpDati.Padding = new System.Windows.Forms.Padding(3);
            this.tpDati.Size = new System.Drawing.Size(776, 410);
            this.tpDati.TabIndex = 0;
            this.tpDati.Text = "Dati";
            this.tpDati.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(534, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Scaglione";
            // 
            // eIDScaglioniDiEta
            // 
            this.eIDScaglioniDiEta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eIDScaglioniDiEta.FormattingEnabled = true;
            this.eIDScaglioniDiEta.Location = new System.Drawing.Point(611, 34);
            this.eIDScaglioniDiEta.Name = "eIDScaglioniDiEta";
            this.eIDScaglioniDiEta.Size = new System.Drawing.Size(157, 21);
            this.eIDScaglioniDiEta.TabIndex = 3;
            // 
            // eFine
            // 
            this.eFine.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eFine.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eFine.Location = new System.Drawing.Point(348, 34);
            this.eFine.Name = "eFine";
            this.eFine.Size = new System.Drawing.Size(157, 20);
            this.eFine.TabIndex = 2;
            // 
            // eInizio
            // 
            this.eInizio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eInizio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eInizio.Location = new System.Drawing.Point(83, 34);
            this.eInizio.Name = "eInizio";
            this.eInizio.Size = new System.Drawing.Size(157, 20);
            this.eInizio.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Note";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Descrizione";
            // 
            // eNote
            // 
            this.eNote.Location = new System.Drawing.Point(83, 171);
            this.eNote.MaxLength = 5000;
            this.eNote.Multiline = true;
            this.eNote.Name = "eNote";
            this.eNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eNote.Size = new System.Drawing.Size(685, 236);
            this.eNote.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Fine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Inizio";
            // 
            // eDescrizione
            // 
            this.eDescrizione.Location = new System.Drawing.Point(83, 61);
            this.eDescrizione.MaxLength = 250;
            this.eDescrizione.Multiline = true;
            this.eDescrizione.Name = "eDescrizione";
            this.eDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eDescrizione.Size = new System.Drawing.Size(685, 104);
            this.eDescrizione.TabIndex = 4;
            // 
            // eCFResponsabile
            // 
            this.eCFResponsabile.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eCFResponsabile.Elemento")));
            this.eCFResponsabile.Location = new System.Drawing.Point(83, 6);
            this.eCFResponsabile.Name = "eCFResponsabile";
            this.eCFResponsabile.ReadOnly = false;
            this.eCFResponsabile.Size = new System.Drawing.Size(685, 25);
            this.eCFResponsabile.TabIndex = 0;
            this.eCFResponsabile.Tipo = null;
            this.eCFResponsabile.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Responsabile";
            // 
            // tpOrari
            // 
            this.tpOrari.Controls.Add(this.Griglia_Orari);
            this.tpOrari.ImageIndex = 1;
            this.tpOrari.Location = new System.Drawing.Point(4, 23);
            this.tpOrari.Name = "tpOrari";
            this.tpOrari.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrari.Size = new System.Drawing.Size(576, 410);
            this.tpOrari.TabIndex = 1;
            this.tpOrari.Text = "Orari";
            this.tpOrari.UseVisualStyleBackColor = true;
            // 
            // Griglia_Orari
            // 
            this.Griglia_Orari.Dock = System.Windows.Forms.DockStyle.Fill;            
            this.Griglia_Orari.Name = "Griglia_Orari";            
            this.Griglia_Orari.TabIndex = 0;
            // 
            // tpEducatrici
            // 
            this.tpEducatrici.Controls.Add(this.Griglia_Educatrici);
            this.tpEducatrici.ImageIndex = 2;
            this.tpEducatrici.Location = new System.Drawing.Point(4, 23);
            this.tpEducatrici.Name = "tpEducatrici";
            this.tpEducatrici.Padding = new System.Windows.Forms.Padding(3);
            this.tpEducatrici.Size = new System.Drawing.Size(576, 410);
            this.tpEducatrici.TabIndex = 2;
            this.tpEducatrici.Text = "Educatrici";
            this.tpEducatrici.UseVisualStyleBackColor = true;
            // 
            // Griglia_Educatrici
            // 
            this.Griglia_Educatrici.Dock = System.Windows.Forms.DockStyle.Fill;                        
            this.Griglia_Educatrici.Name = "Griglia_Educatrici";            
            this.Griglia_Educatrici.TabIndex = 0;
            // 
            // tpSvolgimentoLaboratorio
            // 
            this.tpSvolgimentoLaboratorio.Controls.Add(this.Griglia_SvolgimentoLaboratorio);
            this.tpSvolgimentoLaboratorio.ImageKey = "date_time_functions.ico";
            this.tpSvolgimentoLaboratorio.Location = new System.Drawing.Point(4, 23);
            this.tpSvolgimentoLaboratorio.Name = "tpSvolgimentoLaboratorio";
            this.tpSvolgimentoLaboratorio.Padding = new System.Windows.Forms.Padding(3);
            this.tpSvolgimentoLaboratorio.Size = new System.Drawing.Size(576, 410);
            this.tpSvolgimentoLaboratorio.TabIndex = 3;
            this.tpSvolgimentoLaboratorio.Text = "Svolgimento laboratorio";
            this.tpSvolgimentoLaboratorio.UseVisualStyleBackColor = true;
            // 
            // Griglia_SvolgimentoLaboratorio
            // 
            this.Griglia_SvolgimentoLaboratorio.Dock = System.Windows.Forms.DockStyle.Fill;                        
            this.Griglia_SvolgimentoLaboratorio.Name = "Griglia_SvolgimentoLaboratorio";            
            this.Griglia_SvolgimentoLaboratorio.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "document_prepare.png");
            this.imageList1.Images.SetKeyName(1, "time.png");
            this.imageList1.Images.SetKeyName(2, "user_waiter_female.png");
            this.imageList1.Images.SetKeyName(3, "date_time_functions.ico");
            // 
            // Dettaglio
            //             
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Dettaglio";
            this.Text = "Dettaglio laboratorio";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tpDati.ResumeLayout(false);
            this.tpDati.PerformLayout();
            this.tpOrari.ResumeLayout(false);
            this.tpEducatrici.ResumeLayout(false);
            this.tpSvolgimentoLaboratorio.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}