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
using System;

namespace GAMSharp.UI.Minore
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.Minore>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif   
    {
        private ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private TabControl TheTabControl;
        private TabPage tpDati;
        private Controlli.ucLookUp ePersona_CF;
        private Label label2;
        private TabPage tpColloqui;
        private Colloquio.cRicerca Griglia_Colloquio;
        private TabPage tpAttivitaExtra;
        private AttivitaExtra.cRicerca Griglia_AttivitaExtra;
        private TabPage tpNucleoFamiliare;
        private MembroFamiliare.cRicerca Griglia_MembroFamiliare;
        private TabPage tpPEI;
        private PEI.cRicerca Griglia_PEI;
        private CheckBox eConoscenzaDirettaServizio;
        private Label label1;
        private Label label3;
        private TextBox eMotivoIscrizione;
        private Label label5;
        private TextBox eScuola_Note;
        private Label label4;
        private TextBox eScuola_Classe;
        private Label label6;
        private TextBox eSegnalatoDa;
        private TabPage tSalute;
        private Label label7;
        private TextBox eInformazioniSullaSalute;
        private Label label8;
        private TextBox eDisabilitaFisica;
        private Label label9;
        private TextBox eDisabilitaPsichica;
        private Label label10;
        private TextBox eDisagioNonDiagn;
        private Label label99;
        private TextBox eDisturboApprendimento;
        private CheckBox eParentiStessoProgetto;
        private Label label899;
        private DateTimePicker eDataIscrizione;
        private Label label11;
        private DateTimePicker eDataPrimoContatto;
        private Controlli.ucLookUp eScuola;
        private Label label12;
        private Controlli.ucLookUp eSoggettoInviante;
        private ToolStripMenuItem bStampe;
        private Label label13;
        private ComboBox eIDScaglioniDiEta;

        private List<cComboItem> Scaglioni;
        

        private void eEnteDiProvenienza_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var r = new Ente.Dettaglio())
                if (r.ShowDialog(Key) == DialogResult.OK)
                    eSoggettoInviante.Text = RiCaricaEntita().ExRicerca.SoggettoInvianteDesc;
#endif
        }

        private void eEnteDiProvenienza_RicercaRichiesta()
        {
            using (var r = new Ente.Ricerca())
                eSoggettoInviante.Elemento = r.LookUp();
        }

#if DEBUG
        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Minore entita)
        {
            return new Control[] {
                ePersona_CF
            };
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.Minore> getEntita()
        {
            return new DB.DataWrapper.cMinore();
        }

        protected override DB.DataWrapper.Tabelle.Minore getForm()
        {
            return new DB.DataWrapper.Tabelle.Minore()
            {
                Persona_CF = cGB.ObjectToString(ePersona_CF.Value),
                Scuola = cGB.ObjectToInt(eScuola.Value, -1),

                ConoscenzaDirettaServizio = cGB.BoolToEnglishChar(eConoscenzaDirettaServizio.Checked),
                ParentiStessoProgetto = cGB.BoolToEnglishChar(eParentiStessoProgetto.Checked),

                DataPrimoContatto = GetDateTimePicker(eDataPrimoContatto),
                DataIscrizione = GetDateTimePicker(eDataIscrizione),
                IDScaglioniDiEta = cGB.ObjectToInt(cGB.GetSelectedComboItem_ID(eIDScaglioniDiEta), -1),

                SoggettoInviante = cGB.ObjectToIntNullable(eSoggettoInviante.Value, 0),
                MotivoIscrizione = eMotivoIscrizione.Text,
                Scuola_Classe = eScuola_Classe.Text,
                Scuola_Note = eScuola_Note.Text,
                SegnalatoDa = eSegnalatoDa.Text,
                InformazioniSullaSalute = eInformazioniSullaSalute.Text,
                DisabilitaFisica = eDisabilitaFisica.Text,
                DisabilitaPsichica = eDisabilitaPsichica.Text,
                DisagioNonDiagn = eDisagioNonDiagn.Text,
                DisturboApprendimento = eDisturboApprendimento.Text
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Minore e)
        {
            var n = new DB.DataWrapper.cMembroFamiliare();

            Griglia_MembroFamiliare.IDNucleoFamiliare = n.TrovaNucleoFamiliare("Minore", e.Persona_CF);
            Griglia_Colloquio.Minore_CF = e.Persona_CF;
            Griglia_AttivitaExtra.Minore_CF = e.Persona_CF;
            Griglia_PEI.Minore_CF = e.Persona_CF;

            ePersona_CF.Value = e.Persona_CF;
            ePersona_CF.Text = e.ExRicerca.RagioneSociale;

            eScuola.Value = e.Scuola;
            eScuola.Text = e.ExRicerca.ScuolaDesc;

            eSoggettoInviante.Value = e.SoggettoInviante;
            eSoggettoInviante.Text = e.ExRicerca.SoggettoInvianteDesc;

            SetDateTimePicker(eDataPrimoContatto, e.DataPrimoContatto);
            SetDateTimePicker(eDataIscrizione, e.DataIscrizione);

            eMotivoIscrizione.Text = e.MotivoIscrizione;
            eScuola_Classe.Text = e.Scuola_Classe;
            eScuola_Note.Text = e.Scuola_Note;
            eSegnalatoDa.Text = e.SegnalatoDa;
            eInformazioniSullaSalute.Text = e.InformazioniSullaSalute;
            eDisabilitaFisica.Text = e.DisabilitaFisica;
            eDisabilitaPsichica.Text = e.DisabilitaPsichica;
            eDisagioNonDiagn.Text = e.DisagioNonDiagn;
            eDisturboApprendimento.Text = e.DisturboApprendimento;
            eConoscenzaDirettaServizio.Checked = cGB.EnglishVarCharToBool(e.ConoscenzaDirettaServizio);
            eParentiStessoProgetto.Checked = cGB.EnglishVarCharToBool(e.ParentiStessoProgetto);

            cGB.SetSelectedComboItem_ID(ref eIDScaglioniDiEta, e.IDScaglioniDiEta);
        }

        protected override void setFormNew()
        {
            tpColloqui.Enabled = false;
            tpAttivitaExtra.Enabled = false;
            tpNucleoFamiliare.Enabled = false;
            tpPEI.Enabled = false;
            eDataIscrizione.Checked = false;
            eDataPrimoContatto.Checked = false;
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (ePersona_CF.Value == null)
                z.Add("Selezionare una persona");

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
            using (var d = new Persona.Dettaglio())
                if (d.ShowDialog(Key) == DialogResult.OK)
                    ePersona_CF.Text = RiCaricaEntita().ExRicerca.RagioneSociale;
#endif
        }

        private void eScuola_RicercaRichiesta()
        {
            using (var r = new Ente.Ricerca())
                eScuola.Elemento = r.LookUp();
        }

        private void eScuola_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var d = new Ente.Dettaglio())
                if (d.ShowDialog(Key) == DialogResult.OK)
                    eScuola.Text = RiCaricaEntita().ExRicerca.ScuolaDesc;
#endif
        }

        private void Stampa(Stampe.ConstStampe.eStampa doc)
        {
            if (GB.cGB.MsgBoxQuestion("Vuoi stampare la " + Stampe.ConstStampe.ToString(doc) + "?"))
            {
                var w = new Stampe.cWordReplacer();
                w.StampaRimpiazzaDocx("Persona", ePersona_CF.Value, doc);
            }
        }

        private void bStampa_SchedaPrimoContatto_Click(object sender, EventArgs e)
        {
            Stampa(Stampe.ConstStampe.eStampa.SchedaPrimoContatto);

            var cm = new DB.DataWrapper.cMinore();
            var r = cm.Carica(ePersona_CF.Value);
            var m = r.Risultato;
            m.DataPrimoContatto = DateTime.Now;

            cm.Modifica(m, m.PrimaryKeyName);
        }

        private void bStampa_SchedaIscrizione_Click(object sender, EventArgs e)
        {
            Stampa(Stampe.ConstStampe.eStampa.SchedaIscrizione);

            var cm = new DB.DataWrapper.cMinore();
            var r = cm.Carica(ePersona_CF.Value);
            var m = r.Risultato;
            m.DataIscrizione = DateTime.Now;

            cm.Modifica(m, m.PrimaryKeyName);
        }
     
        internal Dettaglio()
        {
            InitializeComponent();
            PossoEssereFullScreen = true;

            Griglia_MembroFamiliare.RicercaVisibile = false;
            Griglia_Colloquio.RicercaVisibile = false;
            Griglia_AttivitaExtra.RicercaVisibile = false;
            Griglia_PEI.RicercaVisibile = false;

            bStampe = NewButton("&Stampe", Properties.Resources.printer);

            AddButtonToMenu(bStampe);
            AddButtonToMenu(bStampe, NewButton(bStampa_SchedaPrimoContatto_Click, "Stampa scheda &primo contatto", Properties.Resources.printer));
            AddButtonToMenu(bStampe, NewButton(bStampa_SchedaIscrizione_Click, "Stampa scheda &iscrizione", Properties.Resources.printer));

            ePersona_CF.RicercaRichiesta += ePersona_CF_RicercaRichiesta;
            ePersona_CF.DettaglioRichiesto += ePersona_CF_DettaglioRichiesto;
            eScuola.RicercaRichiesta += eScuola_RicercaRichiesta;
            eScuola.DettaglioRichiesto += eScuola_DettaglioRichiesto;
            eSoggettoInviante.RicercaRichiesta += eEnteDiProvenienza_RicercaRichiesta;
            eSoggettoInviante.DettaglioRichiesto += eEnteDiProvenienza_DettaglioRichiesto;

            var ScaglioniDiEta_ = new DB.DataWrapper.cScaglioniDiEta();
            Scaglioni = ScaglioniDiEta_.GetAll();
            eIDScaglioniDiEta.DataSource = Scaglioni;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TheTabControl = new System.Windows.Forms.TabControl();
            this.tpDati = new System.Windows.Forms.TabPage();
            this.eSoggettoInviante = new GAMSharp.UI.Controlli.ucLookUp();
            this.eScuola = new GAMSharp.UI.Controlli.ucLookUp();
            this.label12 = new System.Windows.Forms.Label();
            this.label899 = new System.Windows.Forms.Label();
            this.eDataIscrizione = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.eDataPrimoContatto = new System.Windows.Forms.DateTimePicker();
            this.eParentiStessoProgetto = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.eSegnalatoDa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.eScuola_Note = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.eScuola_Classe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.eMotivoIscrizione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eConoscenzaDirettaServizio = new System.Windows.Forms.CheckBox();
            this.ePersona_CF = new GAMSharp.UI.Controlli.ucLookUp();
            this.label2 = new System.Windows.Forms.Label();
            this.tSalute = new System.Windows.Forms.TabPage();
            this.label99 = new System.Windows.Forms.Label();
            this.eDisturboApprendimento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.eDisagioNonDiagn = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.eDisabilitaPsichica = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.eDisabilitaFisica = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.eInformazioniSullaSalute = new System.Windows.Forms.TextBox();
            this.tpColloqui = new System.Windows.Forms.TabPage();
            this.Griglia_Colloquio = new GAMSharp.UI.Colloquio.cRicerca();
            this.tpAttivitaExtra = new System.Windows.Forms.TabPage();
            this.Griglia_AttivitaExtra = new GAMSharp.UI.AttivitaExtra.cRicerca();
            this.tpNucleoFamiliare = new System.Windows.Forms.TabPage();
            this.Griglia_MembroFamiliare = new GAMSharp.UI.MembroFamiliare.cRicerca();
            this.tpPEI = new System.Windows.Forms.TabPage();
            this.Griglia_PEI = new GAMSharp.UI.PEI.cRicerca();
            this.label13 = new System.Windows.Forms.Label();
            this.eIDScaglioniDiEta = new System.Windows.Forms.ComboBox();
            this.TheTabControl.SuspendLayout();
            this.tpDati.SuspendLayout();
            this.tSalute.SuspendLayout();
            this.tpColloqui.SuspendLayout();
            this.tpAttivitaExtra.SuspendLayout();
            this.tpNucleoFamiliare.SuspendLayout();
            this.tpPEI.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "to_do_list_checked_all.ico");
            this.imageList1.Images.SetKeyName(1, "user_comment.ico");
            this.imageList1.Images.SetKeyName(2, "tree.ico");
            this.imageList1.Images.SetKeyName(3, "heart.ico");
            this.imageList1.Images.SetKeyName(4, "document_protect.ico");
            this.imageList1.Images.SetKeyName(5, "health.png");
            // 
            // TheTabControl
            // 
            this.TheTabControl.Controls.Add(this.tpDati);
            this.TheTabControl.Controls.Add(this.tSalute);
            this.TheTabControl.Controls.Add(this.tpColloqui);
            this.TheTabControl.Controls.Add(this.tpAttivitaExtra);
            this.TheTabControl.Controls.Add(this.tpNucleoFamiliare);
            this.TheTabControl.Controls.Add(this.tpPEI);
            this.TheTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TheTabControl.ImageList = this.imageList1;
            this.TheTabControl.Location = new System.Drawing.Point(0, 24);
            this.TheTabControl.Name = "TheTabControl";
            this.TheTabControl.SelectedIndex = 0;
            this.TheTabControl.Size = new System.Drawing.Size(984, 637);
            this.TheTabControl.TabIndex = 2;
            // 
            // tpDati
            // 
            this.tpDati.Controls.Add(this.label13);
            this.tpDati.Controls.Add(this.eIDScaglioniDiEta);
            this.tpDati.Controls.Add(this.eSoggettoInviante);
            this.tpDati.Controls.Add(this.eScuola);
            this.tpDati.Controls.Add(this.label12);
            this.tpDati.Controls.Add(this.label899);
            this.tpDati.Controls.Add(this.eDataIscrizione);
            this.tpDati.Controls.Add(this.label11);
            this.tpDati.Controls.Add(this.eDataPrimoContatto);
            this.tpDati.Controls.Add(this.eParentiStessoProgetto);
            this.tpDati.Controls.Add(this.label6);
            this.tpDati.Controls.Add(this.eSegnalatoDa);
            this.tpDati.Controls.Add(this.label5);
            this.tpDati.Controls.Add(this.eScuola_Note);
            this.tpDati.Controls.Add(this.label4);
            this.tpDati.Controls.Add(this.eScuola_Classe);
            this.tpDati.Controls.Add(this.label3);
            this.tpDati.Controls.Add(this.eMotivoIscrizione);
            this.tpDati.Controls.Add(this.label1);
            this.tpDati.Controls.Add(this.eConoscenzaDirettaServizio);
            this.tpDati.Controls.Add(this.ePersona_CF);
            this.tpDati.Controls.Add(this.label2);
            this.tpDati.ImageIndex = 0;
            this.tpDati.Location = new System.Drawing.Point(4, 23);
            this.tpDati.Name = "tpDati";
            this.tpDati.Padding = new System.Windows.Forms.Padding(3);
            this.tpDati.Size = new System.Drawing.Size(976, 610);
            this.tpDati.TabIndex = 0;
            this.tpDati.Text = "Dati";
            this.tpDati.UseVisualStyleBackColor = true;
            // 
            // eSoggettoInviante
            // 
            this.eSoggettoInviante.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eSoggettoInviante.Elemento")));
            this.eSoggettoInviante.Location = new System.Drawing.Point(119, 42);
            this.eSoggettoInviante.Name = "eSoggettoInviante";
            this.eSoggettoInviante.ReadOnly = false;
            this.eSoggettoInviante.Size = new System.Drawing.Size(849, 25);
            this.eSoggettoInviante.TabIndex = 1;
            this.eSoggettoInviante.Tipo = null;
            this.eSoggettoInviante.Value = null;
            // 
            // eScuola
            // 
            this.eScuola.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eScuola.Elemento")));
            this.eScuola.Location = new System.Drawing.Point(119, 120);
            this.eScuola.Name = "eScuola";
            this.eScuola.ReadOnly = false;
            this.eScuola.Size = new System.Drawing.Size(849, 25);
            this.eScuola.TabIndex = 7;
            this.eScuola.Tipo = null;
            this.eScuola.Value = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Scuola";
            // 
            // label899
            // 
            this.label899.AutoSize = true;
            this.label899.Location = new System.Drawing.Point(343, 101);
            this.label899.Name = "label899";
            this.label899.Size = new System.Drawing.Size(51, 13);
            this.label899.TabIndex = 28;
            this.label899.Text = "Iscrizione";
            // 
            // eDataIscrizione
            // 
            this.eDataIscrizione.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eDataIscrizione.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eDataIscrizione.Location = new System.Drawing.Point(400, 96);
            this.eDataIscrizione.Name = "eDataIscrizione";
            this.eDataIscrizione.ShowCheckBox = true;
            this.eDataIscrizione.Size = new System.Drawing.Size(157, 20);
            this.eDataIscrizione.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Primo contatto";
            // 
            // eDataPrimoContatto
            // 
            this.eDataPrimoContatto.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eDataPrimoContatto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eDataPrimoContatto.Location = new System.Drawing.Point(119, 96);
            this.eDataPrimoContatto.Name = "eDataPrimoContatto";
            this.eDataPrimoContatto.ShowCheckBox = true;
            this.eDataPrimoContatto.Size = new System.Drawing.Size(157, 20);
            this.eDataPrimoContatto.TabIndex = 3;
            // 
            // eParentiStessoProgetto
            // 
            this.eParentiStessoProgetto.AutoSize = true;
            this.eParentiStessoProgetto.Location = new System.Drawing.Point(753, 99);
            this.eParentiStessoProgetto.Name = "eParentiStessoProgetto";
            this.eParentiStessoProgetto.Size = new System.Drawing.Size(159, 17);
            this.eParentiStessoProgetto.TabIndex = 6;
            this.eParentiStessoProgetto.Text = "Parenti nello stesso progetto";
            this.eParentiStessoProgetto.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Segnalato da";
            // 
            // eSegnalatoDa
            // 
            this.eSegnalatoDa.Location = new System.Drawing.Point(119, 70);
            this.eSegnalatoDa.MaxLength = 300;
            this.eSegnalatoDa.Name = "eSegnalatoDa";
            this.eSegnalatoDa.Size = new System.Drawing.Size(849, 20);
            this.eSegnalatoDa.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Scuola: note";
            // 
            // eScuola_Note
            // 
            this.eScuola_Note.Location = new System.Drawing.Point(119, 174);
            this.eScuola_Note.MaxLength = 300;
            this.eScuola_Note.Name = "eScuola_Note";
            this.eScuola_Note.Size = new System.Drawing.Size(849, 20);
            this.eScuola_Note.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Scuola: classe";
            // 
            // eScuola_Classe
            // 
            this.eScuola_Classe.Location = new System.Drawing.Point(119, 148);
            this.eScuola_Classe.MaxLength = 50;
            this.eScuola_Classe.Name = "eScuola_Classe";
            this.eScuola_Classe.Size = new System.Drawing.Size(849, 20);
            this.eScuola_Classe.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Motivo iscrizione";
            // 
            // eMotivoIscrizione
            // 
            this.eMotivoIscrizione.Location = new System.Drawing.Point(16, 252);
            this.eMotivoIscrizione.MaxLength = 5000;
            this.eMotivoIscrizione.Multiline = true;
            this.eMotivoIscrizione.Name = "eMotivoIscrizione";
            this.eMotivoIscrizione.Size = new System.Drawing.Size(952, 350);
            this.eMotivoIscrizione.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Soggetto inviante";
            // 
            // eConoscenzaDirettaServizio
            // 
            this.eConoscenzaDirettaServizio.AutoSize = true;
            this.eConoscenzaDirettaServizio.Location = new System.Drawing.Point(575, 99);
            this.eConoscenzaDirettaServizio.Name = "eConoscenzaDirettaServizio";
            this.eConoscenzaDirettaServizio.Size = new System.Drawing.Size(172, 17);
            this.eConoscenzaDirettaServizio.TabIndex = 5;
            this.eConoscenzaDirettaServizio.Text = "Conoscenza diretta del servizio";
            this.eConoscenzaDirettaServizio.UseVisualStyleBackColor = true;
            // 
            // ePersona_CF
            // 
            this.ePersona_CF.Elemento = ((System.Tuple<object, string>)(resources.GetObject("ePersona_CF.Elemento")));
            this.ePersona_CF.Location = new System.Drawing.Point(119, 16);
            this.ePersona_CF.Name = "ePersona_CF";
            this.ePersona_CF.ReadOnly = false;
            this.ePersona_CF.Size = new System.Drawing.Size(849, 25);
            this.ePersona_CF.TabIndex = 0;
            this.ePersona_CF.Tipo = null;
            this.ePersona_CF.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Persona";
            // 
            // tSalute
            // 
            this.tSalute.Controls.Add(this.label99);
            this.tSalute.Controls.Add(this.eDisturboApprendimento);
            this.tSalute.Controls.Add(this.label10);
            this.tSalute.Controls.Add(this.eDisagioNonDiagn);
            this.tSalute.Controls.Add(this.label9);
            this.tSalute.Controls.Add(this.eDisabilitaPsichica);
            this.tSalute.Controls.Add(this.label8);
            this.tSalute.Controls.Add(this.eDisabilitaFisica);
            this.tSalute.Controls.Add(this.label7);
            this.tSalute.Controls.Add(this.eInformazioniSullaSalute);
            this.tSalute.ImageIndex = 5;
            this.tSalute.Location = new System.Drawing.Point(4, 23);
            this.tSalute.Name = "tSalute";
            this.tSalute.Padding = new System.Windows.Forms.Padding(3);
            this.tSalute.Size = new System.Drawing.Size(976, 610);
            this.tSalute.TabIndex = 5;
            this.tSalute.Text = "Salute";
            this.tSalute.UseVisualStyleBackColor = true;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(13, 168);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(137, 13);
            this.label99.TabIndex = 35;
            this.label99.Text = "Disturbo dell\'apprendimento";
            // 
            // eDisturboApprendimento
            // 
            this.eDisturboApprendimento.Location = new System.Drawing.Point(16, 184);
            this.eDisturboApprendimento.MaxLength = 500;
            this.eDisturboApprendimento.Multiline = true;
            this.eDisturboApprendimento.Name = "eDisturboApprendimento";
            this.eDisturboApprendimento.Size = new System.Drawing.Size(301, 118);
            this.eDisturboApprendimento.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(627, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Disagio non diagnosticato";
            // 
            // eDisagioNonDiagn
            // 
            this.eDisagioNonDiagn.Location = new System.Drawing.Point(630, 37);
            this.eDisagioNonDiagn.MaxLength = 500;
            this.eDisagioNonDiagn.Multiline = true;
            this.eDisagioNonDiagn.Name = "eDisagioNonDiagn";
            this.eDisagioNonDiagn.Size = new System.Drawing.Size(301, 118);
            this.eDisagioNonDiagn.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Disabilità psichica";
            // 
            // eDisabilitaPsichica
            // 
            this.eDisabilitaPsichica.Location = new System.Drawing.Point(323, 37);
            this.eDisabilitaPsichica.MaxLength = 500;
            this.eDisabilitaPsichica.Multiline = true;
            this.eDisabilitaPsichica.Name = "eDisabilitaPsichica";
            this.eDisabilitaPsichica.Size = new System.Drawing.Size(301, 118);
            this.eDisabilitaPsichica.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Disabilità fisica";
            // 
            // eDisabilitaFisica
            // 
            this.eDisabilitaFisica.Location = new System.Drawing.Point(16, 37);
            this.eDisabilitaFisica.MaxLength = 500;
            this.eDisabilitaFisica.Multiline = true;
            this.eDisabilitaFisica.Name = "eDisabilitaFisica";
            this.eDisabilitaFisica.Size = new System.Drawing.Size(301, 118);
            this.eDisabilitaFisica.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Informazioni sulla salute";
            // 
            // eInformazioniSullaSalute
            // 
            this.eInformazioniSullaSalute.Location = new System.Drawing.Point(323, 184);
            this.eInformazioniSullaSalute.MaxLength = 5000;
            this.eInformazioniSullaSalute.Multiline = true;
            this.eInformazioniSullaSalute.Name = "eInformazioniSullaSalute";
            this.eInformazioniSullaSalute.Size = new System.Drawing.Size(608, 418);
            this.eInformazioniSullaSalute.TabIndex = 5;
            // 
            // tpColloqui
            // 
            this.tpColloqui.Controls.Add(this.Griglia_Colloquio);
            this.tpColloqui.ImageIndex = 1;
            this.tpColloqui.Location = new System.Drawing.Point(4, 23);
            this.tpColloqui.Name = "tpColloqui";
            this.tpColloqui.Padding = new System.Windows.Forms.Padding(3);
            this.tpColloqui.Size = new System.Drawing.Size(976, 610);
            this.tpColloqui.TabIndex = 1;
            this.tpColloqui.Text = "Colloqui";
            this.tpColloqui.UseVisualStyleBackColor = true;
            // 
            // Griglia_Colloquio
            // 
            this.Griglia_Colloquio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_Colloquio.Location = new System.Drawing.Point(3, 3);
            this.Griglia_Colloquio.Minore_CF = null;
            this.Griglia_Colloquio.Name = "Griglia_Colloquio";
            this.Griglia_Colloquio.Size = new System.Drawing.Size(970, 604);
            this.Griglia_Colloquio.TabIndex = 0;
            // 
            // tpAttivitaExtra
            // 
            this.tpAttivitaExtra.Controls.Add(this.Griglia_AttivitaExtra);
            this.tpAttivitaExtra.ImageIndex = 2;
            this.tpAttivitaExtra.Location = new System.Drawing.Point(4, 23);
            this.tpAttivitaExtra.Name = "tpAttivitaExtra";
            this.tpAttivitaExtra.Padding = new System.Windows.Forms.Padding(3);
            this.tpAttivitaExtra.Size = new System.Drawing.Size(976, 610);
            this.tpAttivitaExtra.TabIndex = 2;
            this.tpAttivitaExtra.Text = "Attività extra";
            this.tpAttivitaExtra.UseVisualStyleBackColor = true;
            // 
            // Griglia_AttivitaExtra
            // 
            this.Griglia_AttivitaExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_AttivitaExtra.Location = new System.Drawing.Point(3, 3);
            this.Griglia_AttivitaExtra.Minore_CF = null;
            this.Griglia_AttivitaExtra.Name = "Griglia_AttivitaExtra";
            this.Griglia_AttivitaExtra.Size = new System.Drawing.Size(970, 604);
            this.Griglia_AttivitaExtra.TabIndex = 0;
            // 
            // tpNucleoFamiliare
            // 
            this.tpNucleoFamiliare.Controls.Add(this.Griglia_MembroFamiliare);
            this.tpNucleoFamiliare.ImageIndex = 3;
            this.tpNucleoFamiliare.Location = new System.Drawing.Point(4, 23);
            this.tpNucleoFamiliare.Name = "tpNucleoFamiliare";
            this.tpNucleoFamiliare.Padding = new System.Windows.Forms.Padding(3);
            this.tpNucleoFamiliare.Size = new System.Drawing.Size(976, 610);
            this.tpNucleoFamiliare.TabIndex = 3;
            this.tpNucleoFamiliare.Text = "Nucleo familiare";
            this.tpNucleoFamiliare.UseVisualStyleBackColor = true;
            // 
            // Griglia_MembroFamiliare
            // 
            this.Griglia_MembroFamiliare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_MembroFamiliare.IDNucleoFamiliare = -1;
            this.Griglia_MembroFamiliare.Location = new System.Drawing.Point(3, 3);
            this.Griglia_MembroFamiliare.Name = "Griglia_MembroFamiliare";
            this.Griglia_MembroFamiliare.Size = new System.Drawing.Size(970, 604);
            this.Griglia_MembroFamiliare.TabIndex = 0;
            // 
            // tpPEI
            // 
            this.tpPEI.Controls.Add(this.Griglia_PEI);
            this.tpPEI.ImageIndex = 4;
            this.tpPEI.Location = new System.Drawing.Point(4, 23);
            this.tpPEI.Name = "tpPEI";
            this.tpPEI.Padding = new System.Windows.Forms.Padding(3);
            this.tpPEI.Size = new System.Drawing.Size(976, 610);
            this.tpPEI.TabIndex = 4;
            this.tpPEI.Text = "PEI";
            this.tpPEI.UseVisualStyleBackColor = true;
            // 
            // Griglia_PEI
            // 
            this.Griglia_PEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_PEI.Location = new System.Drawing.Point(3, 3);
            this.Griglia_PEI.Minore_CF = null;
            this.Griglia_PEI.Name = "Griglia_PEI";
            this.Griglia_PEI.Size = new System.Drawing.Size(970, 604);
            this.Griglia_PEI.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Scaglione";
            // 
            // eIDScaglioniDiEta
            // 
            this.eIDScaglioniDiEta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eIDScaglioniDiEta.FormattingEnabled = true;
            this.eIDScaglioniDiEta.Location = new System.Drawing.Point(119, 200);
            this.eIDScaglioniDiEta.Name = "eIDScaglioniDiEta";
            this.eIDScaglioniDiEta.Size = new System.Drawing.Size(267, 21);
            this.eIDScaglioniDiEta.TabIndex = 10;
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.TheTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Dettaglio";
            this.Text = "Dettaglio minore";
            this.Controls.SetChildIndex(this.TheTabControl, 0);
            this.TheTabControl.ResumeLayout(false);
            this.tpDati.ResumeLayout(false);
            this.tpDati.PerformLayout();
            this.tSalute.ResumeLayout(false);
            this.tSalute.PerformLayout();
            this.tpColloqui.ResumeLayout(false);
            this.tpAttivitaExtra.ResumeLayout(false);
            this.tpNucleoFamiliare.ResumeLayout(false);
            this.tpPEI.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}