/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Base;
using GAMSharp.GB;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GAMSharp.UI.AssistenteSociale
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.AssistenteSociale>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif    
    {
        private Controlli.ucLookUp eIDLead;
        private Label label3;
        private Controlli.ucLookUp eCsst;
        private Label label1;
        private Controlli.ddlComune eMunicipalita;
        private Label label2;


#if DEBUG
        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.AssistenteSociale entita)
        {
            return null;
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.AssistenteSociale> getEntita()
        {
            return new DB.DataWrapper.cAssistenteSociale();
        }

        protected override DB.DataWrapper.Tabelle.AssistenteSociale getForm()
        {
            return new DB.DataWrapper.Tabelle.AssistenteSociale()
            {
                IDLead = cGB.ObjectToInt(eIDLead.Value, -1),
                Csst = cGB.ObjectToInt(eCsst.Value, -1),
                Municipalita = eMunicipalita.Text                
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.AssistenteSociale e)
        {
            eMunicipalita.Text = e.Municipalita;            
            eCsst.Value = e.Csst;
            eCsst.Text = e.ExRicerca.DescEnte;
            eIDLead.Value = e.IDLead;
            eIDLead.Text = e.ExRicerca.RagioneSociale;
        }

        protected override void setFormNew()
        {

        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eIDLead.Value == null || eIDLead.Value.Equals(-1))
                z.Add("Selezionare una persona");

            return z;
        }
#endif

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

        private void eIDLead_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var d = new Lead.Dettaglio())
                if (d.ShowDialog(Key) == DialogResult.OK)
                    eIDLead.Text = RiCaricaEntita().ExRicerca.RagioneSociale;
#endif
        }

        private void eIDLead_RicercaRichiesta()
        {
            using (var r = new Lead.Ricerca())
                eIDLead.Elemento = r.LookUp();
        }

        internal Dettaglio()
        {
            InitializeComponent();

            eCsst.RicercaRichiesta += eCsst_RicercaRichiesta;
            eCsst.DettaglioRichiesto += eCsst_DettaglioRichiesto;
            eIDLead.RicercaRichiesta += eIDLead_RicercaRichiesta;
            eIDLead.DettaglioRichiesto += eIDLead_DettaglioRichiesto;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.eIDLead = new GAMSharp.UI.Controlli.ucLookUp();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eCsst = new GAMSharp.UI.Controlli.ucLookUp();
            this.label1 = new System.Windows.Forms.Label();
            this.eMunicipalita = new GAMSharp.UI.Controlli.ddlComune();
            this.SuspendLayout();
            // 
            // eIDLead
            // 
            this.eIDLead.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eIDLead.Elemento")));
            this.eIDLead.Location = new System.Drawing.Point(118, 37);
            this.eIDLead.Name = "eIDLead";
            this.eIDLead.ReadOnly = false;
            this.eIDLead.Size = new System.Drawing.Size(403, 25);
            this.eIDLead.TabIndex = 0;
            this.eIDLead.Tipo = null;
            this.eIDLead.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Persona";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "CSST";
            // 
            // eCsst
            // 
            this.eCsst.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eCsst.Elemento")));
            this.eCsst.Location = new System.Drawing.Point(118, 89);
            this.eCsst.Name = "eCsst";
            this.eCsst.ReadOnly = false;
            this.eCsst.Size = new System.Drawing.Size(403, 25);
            this.eCsst.TabIndex = 2;
            this.eCsst.Tipo = null;
            this.eCsst.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Municipalità";
            // 
            // eMunicipalita
            // 
            this.eMunicipalita.Location = new System.Drawing.Point(118, 65);
            this.eMunicipalita.MaxLength = 250;
            this.eMunicipalita.Name = "eMunicipalita";
            this.eMunicipalita.Size = new System.Drawing.Size(403, 20);
            this.eMunicipalita.TabIndex = 1;
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(541, 125);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eCsst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eMunicipalita);
            this.Controls.Add(this.eIDLead);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio assistente sociale";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.eIDLead, 0);
            this.Controls.SetChildIndex(this.eMunicipalita, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.eCsst, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}