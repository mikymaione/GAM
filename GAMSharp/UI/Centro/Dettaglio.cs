/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.GB;
using GAMSharp.DB.DataWrapper.Base;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GAMSharp.UI.Centro
{
#if DEBUG
    class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.Centro>
#else
    class Dettaglio : UI.Base.fFakeDettaglio
#endif
    {
        private TextBox eDescrizione;
        private Label label1;
        private Label label2;
        private Controlli.ucLookUp eCsst;
        private Label label3;
        private Controlli.ddlComune eMunicipalita;


        private void eCsst_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var d = new Ente.Dettaglio())
                if (d.ShowDialog(Key) == DialogResult.OK)
                    eCsst.Text = RiCaricaEntita().ExRicerca.DescEnte;
#endif
        }

        private void eCsst_RicercaRichiesta()
        {
            using (var r = new Ente.Ricerca())
                eCsst.Elemento = r.LookUp();
        }

#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.Centro> getEntita()
        {
            return new DB.DataWrapper.cCentro();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Centro e)
        {
            eDescrizione.Text = e.Descrizione;
            eMunicipalita.Text = e.Municipalita;
            eCsst.Value = e.Csst;
            eCsst.Text = e.ExRicerca.DescEnte;
        }

        protected override DB.DataWrapper.Tabelle.Centro getForm()
        {
            return new DB.DataWrapper.Tabelle.Centro()
            {
                Codice = "TEN",
                Descrizione = eDescrizione.Text,
                Municipalita = eMunicipalita.Text,
                Csst = cGB.ObjectToInt(eCsst.Value, -1)
            };
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Centro entita)
        {
            return null;
        }

        protected override void setFormNew()
        {

        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eDescrizione.Text.Length < 3)
                z.Add("La descrizione deve essere di almeno 3 caratteri");

            return z;
        }
#endif

        internal Dettaglio()
        {
            InitializeComponent();

            eCsst.RicercaRichiesta += eCsst_RicercaRichiesta;
            eCsst.DettaglioRichiesto += eCsst_DettaglioRichiesto;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.eDescrizione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eMunicipalita = new GAMSharp.UI.Controlli.ddlComune();
            this.eCsst = new GAMSharp.UI.Controlli.ucLookUp();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eDescrizione
            // 
            this.eDescrizione.Location = new System.Drawing.Point(118, 35);
            this.eDescrizione.MaxLength = 250;
            this.eDescrizione.Name = "eDescrizione";
            this.eDescrizione.Size = new System.Drawing.Size(403, 20);
            this.eDescrizione.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Descrizione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Municipalità";
            // 
            // eMunicipalita
            // 
            this.eMunicipalita.Location = new System.Drawing.Point(118, 61);
            this.eMunicipalita.MaxLength = 250;
            this.eMunicipalita.Name = "eMunicipalita";
            this.eMunicipalita.Size = new System.Drawing.Size(403, 20);
            this.eMunicipalita.TabIndex = 1;
            // 
            // eCsst
            // 
            this.eCsst.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eCsst.Elemento")));
            this.eCsst.Location = new System.Drawing.Point(118, 85);
            this.eCsst.Name = "eCsst";
            this.eCsst.ReadOnly = false;
            this.eCsst.Size = new System.Drawing.Size(403, 25);
            this.eCsst.TabIndex = 2;
            this.eCsst.Tipo = null;
            this.eCsst.Value = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "CSST";
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(533, 122);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eCsst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eMunicipalita);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eDescrizione);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio Centro";
            this.Controls.SetChildIndex(this.eDescrizione, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.eMunicipalita, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.eCsst, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}