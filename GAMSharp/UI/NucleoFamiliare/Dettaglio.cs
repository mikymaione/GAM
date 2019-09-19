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
using GAMSharp.DB.DataWrapper.Tabelle;
using GAMSharp.GB;

namespace GAMSharp.UI.NucleoFamiliare
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.NucleoFamiliare>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {
        private TabControl tabControl1;
        private TabPage tpDati;
        private Label label1;
        private ComboBox eRelazioneGenitori;
        private Controlli.ucLookUp eCapofamiglia;
        private Label label2;
        private TabPage tpMembroFamiliare;
        private ImageList imageList1;
        private MembroFamiliare.cRicerca Griglia_MembroFamiliare;
        private System.ComponentModel.IContainer components;


#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.NucleoFamiliare> getEntita()
        {
            return new DB.DataWrapper.cNucleoFamiliare();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.NucleoFamiliare e)
        {
            cGB.SetSelectedComboItem_ID(ref eRelazioneGenitori, e.RelazioneGenitori);
            eCapofamiglia.Value = e.Capofamiglia;
            eCapofamiglia.Text = e.ExRicerca.RagioneSociale;

            Griglia_MembroFamiliare.IDNucleoFamiliare = e.ID;
        }

        protected override void PostSalva(DB.DataWrapper.Tabelle.NucleoFamiliare entita)
        {
            base.PostSalva(entita);
            var i = cGB.ObjectToInt(PrimaryKey, -1);

            if (i > -1)
            {
                var m = new DB.DataWrapper.cMembroFamiliare();

                m.Inserisci(
                    new DB.DataWrapper.Tabelle.MembroFamiliare()
                    {
                        IDNucleoFamiliare = i,
                        Persona_CF = entita.Capofamiglia,
                        Figura = "Genitore"
                    },
                    "ID",
                    true
                );
            }
        }

        protected override void setFormNew()
        {
            tpMembroFamiliare.Enabled = false;
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eCapofamiglia.Value == null)
                z.Add("Selezionare una capofamiglia");

            return z;
        }

        protected override DB.DataWrapper.Tabelle.NucleoFamiliare getForm()
        {
            return new DB.DataWrapper.Tabelle.NucleoFamiliare()
            {
                ID = cGB.ObjectToInt(PrimaryKey, -1),
                Capofamiglia = cGB.ObjectToString(eCapofamiglia.Value),
                RelazioneGenitori = cGB.GetSelectedComboItem_Valore(eRelazioneGenitori)
            };
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.NucleoFamiliare entita)
        {
            return null;
        }
#endif

        private void eCapofamiglia_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var d = new Persona.Dettaglio())
                if (d.ShowDialog(Key) == DialogResult.OK)
                    eCapofamiglia.Text = RiCaricaEntita().ExRicerca.RagioneSociale;
#endif
        }

        private void eCapofamiglia_RicercaRichiesta()
        {
            using (var r = new Persona.Ricerca())
                eCapofamiglia.Elemento = r.LookUp();
        }

        internal Dettaglio()
        {            
            InitializeComponent();
            PossoEssereFullScreen = true;

            eRelazioneGenitori.Items.Add(new cComboItem("Coniugati"));
            eRelazioneGenitori.Items.Add(new cComboItem("Divorziati"));
            eRelazioneGenitori.Items.Add(new cComboItem("Separati"));
            eRelazioneGenitori.Items.Add(new cComboItem("Famiglia di fatto"));
            eRelazioneGenitori.Items.Add(new cComboItem("Vedovo"));

            eCapofamiglia.RicercaRichiesta += eCapofamiglia_RicercaRichiesta;
            eCapofamiglia.DettaglioRichiesto += eCapofamiglia_DettaglioRichiesto;

            Griglia_MembroFamiliare.RicercaVisibile = false;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDati = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.eRelazioneGenitori = new System.Windows.Forms.ComboBox();
            this.eCapofamiglia = new GAMSharp.UI.Controlli.ucLookUp();
            this.label2 = new System.Windows.Forms.Label();
            this.tpMembroFamiliare = new System.Windows.Forms.TabPage();
            this.Griglia_MembroFamiliare = new GAMSharp.UI.MembroFamiliare.cRicerca();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tpDati.SuspendLayout();
            this.tpMembroFamiliare.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpDati);
            this.tabControl1.Controls.Add(this.tpMembroFamiliare);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(835, 242);
            this.tabControl1.TabIndex = 14;
            // 
            // tpDati
            // 
            this.tpDati.Controls.Add(this.label1);
            this.tpDati.Controls.Add(this.eRelazioneGenitori);
            this.tpDati.Controls.Add(this.eCapofamiglia);
            this.tpDati.Controls.Add(this.label2);
            this.tpDati.ImageIndex = 0;
            this.tpDati.Location = new System.Drawing.Point(4, 23);
            this.tpDati.Name = "tpDati";
            this.tpDati.Size = new System.Drawing.Size(644, 215);
            this.tpDati.TabIndex = 0;
            this.tpDati.Text = "Dati";
            this.tpDati.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Relazione genitori";
            // 
            // eRelazioneGenitori
            // 
            this.eRelazioneGenitori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eRelazioneGenitori.Location = new System.Drawing.Point(116, 39);
            this.eRelazioneGenitori.Name = "eRelazioneGenitori";
            this.eRelazioneGenitori.Size = new System.Drawing.Size(268, 21);
            this.eRelazioneGenitori.TabIndex = 15;
            // 
            // eCapofamiglia
            // 
            this.eCapofamiglia.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eCapofamiglia.Elemento")));
            this.eCapofamiglia.Location = new System.Drawing.Point(116, 11);
            this.eCapofamiglia.Name = "eCapofamiglia";
            this.eCapofamiglia.ReadOnly = false;
            this.eCapofamiglia.Size = new System.Drawing.Size(268, 25);
            this.eCapofamiglia.TabIndex = 14;
            this.eCapofamiglia.Tipo = null;
            this.eCapofamiglia.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Capofamiglia";
            // 
            // tpMembroFamiliare
            // 
            this.tpMembroFamiliare.Controls.Add(this.Griglia_MembroFamiliare);
            this.tpMembroFamiliare.ImageIndex = 1;
            this.tpMembroFamiliare.Location = new System.Drawing.Point(4, 23);
            this.tpMembroFamiliare.Name = "tpMembroFamiliare";
            this.tpMembroFamiliare.Size = new System.Drawing.Size(827, 215);
            this.tpMembroFamiliare.TabIndex = 1;
            this.tpMembroFamiliare.Text = "Membri familiari";
            this.tpMembroFamiliare.UseVisualStyleBackColor = true;
            // 
            // Griglia_MembroFamiliare
            // 
            this.Griglia_MembroFamiliare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_MembroFamiliare.IDNucleoFamiliare = 0;
            this.Griglia_MembroFamiliare.Location = new System.Drawing.Point(0, 0);
            this.Griglia_MembroFamiliare.Name = "Griglia_MembroFamiliare";
            this.Griglia_MembroFamiliare.Size = new System.Drawing.Size(827, 215);
            this.Griglia_MembroFamiliare.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "document_prepare.png");
            this.imageList1.Images.SetKeyName(1, "personals.png");
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(835, 264);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio nucleo familiare";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tpDati.ResumeLayout(false);
            this.tpDati.PerformLayout();
            this.tpMembroFamiliare.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}