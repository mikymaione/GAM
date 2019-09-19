/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Base;
using GAMSharp.GB;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GAMSharp.UI.Numerazioni
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.Numerazioni>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif    
    {
        private System.Windows.Forms.NumericUpDown eSchedaIscrizione;
        private System.Windows.Forms.NumericUpDown eSchedaPrimoContatto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controlli.ucLookUp eCodiceCentro;
        private System.Windows.Forms.Label label3;


#if DEBUG
        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Numerazioni entita)
        {
            return new Control[] {
                eCodiceCentro
            };
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.Numerazioni> getEntita()
        {
            return new DB.DataWrapper.cNumerazioni();
        }

        protected override DB.DataWrapper.Tabelle.Numerazioni getForm()
        {
            return new DB.DataWrapper.Tabelle.Numerazioni()
            {
                CodiceCentro = cGB.ObjectToString(eCodiceCentro.Value),
                SchedaIscrizione = cGB.ObjectToInt(eSchedaIscrizione.Value, 0),
                SchedaPrimoContatto = cGB.ObjectToInt(eSchedaPrimoContatto.Value, 0)
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Numerazioni e)
        {
            eSchedaIscrizione.Value = e.SchedaIscrizione;
            eSchedaPrimoContatto.Value = e.SchedaPrimoContatto;
            eCodiceCentro.Value = e.CodiceCentro;
            eCodiceCentro.Text = e.ExRicerca.Descrizione;
        }

        protected override void setFormNew()
        {
            //
        }

        protected override List<string> ValidateForm()
        {
            List<string> z = new List<string>();

            if (eCodiceCentro.Value == null)
                z.Add("Selezionare un centro");

            return z;
        }
#endif

        private void eCodiceCentro_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var d = new Centro.Dettaglio())
                if (d.ShowDialog(Key) == DialogResult.OK)
                    eCodiceCentro.Text = RiCaricaEntita().ExRicerca.Descrizione;
#endif
        }

        private void eCodiceCentro_RicercaRichiesta()
        {
            eCodiceCentro.Elemento = new Tuple<object, string>("TEN", "La Tenda");
        }

        internal Dettaglio()
        {
            InitializeComponent();
            this.Eliminabile = false;
            eCodiceCentro.RicercaRichiesta += eCodiceCentro_RicercaRichiesta;
            eCodiceCentro.DettaglioRichiesto += eCodiceCentro_DettaglioRichiesto;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.eSchedaPrimoContatto = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eSchedaIscrizione = new System.Windows.Forms.NumericUpDown();
            this.eCodiceCentro = new GAMSharp.UI.Controlli.ucLookUp();
            ((System.ComponentModel.ISupportInitialize)(this.eSchedaPrimoContatto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSchedaIscrizione)).BeginInit();
            this.SuspendLayout();
            // 
            // eSchedaPrimoContatto
            // 
            this.eSchedaPrimoContatto.Location = new System.Drawing.Point(140, 64);
            this.eSchedaPrimoContatto.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.eSchedaPrimoContatto.Name = "eSchedaPrimoContatto";
            this.eSchedaPrimoContatto.Size = new System.Drawing.Size(120, 20);
            this.eSchedaPrimoContatto.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Centro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Scheda primo contatto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Scheda iscrizione";
            // 
            // eSchedaIscrizione
            // 
            this.eSchedaIscrizione.Location = new System.Drawing.Point(140, 90);
            this.eSchedaIscrizione.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.eSchedaIscrizione.Name = "eSchedaIscrizione";
            this.eSchedaIscrizione.Size = new System.Drawing.Size(120, 20);
            this.eSchedaIscrizione.TabIndex = 2;
            // 
            // eCodiceCentro
            // 
            this.eCodiceCentro.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eCodiceCentro.Elemento")));
            this.eCodiceCentro.Location = new System.Drawing.Point(140, 36);
            this.eCodiceCentro.Name = "eCodiceCentro";
            this.eCodiceCentro.ReadOnly = false;
            this.eCodiceCentro.Size = new System.Drawing.Size(309, 25);
            this.eCodiceCentro.TabIndex = 0;
            this.eCodiceCentro.Tipo = null;
            this.eCodiceCentro.Value = null;
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(461, 123);
            this.Controls.Add(this.eCodiceCentro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eSchedaIscrizione);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eSchedaPrimoContatto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio numerazione";
            this.Controls.SetChildIndex(this.eSchedaPrimoContatto, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.eSchedaIscrizione, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.eCodiceCentro, 0);
            ((System.ComponentModel.ISupportInitialize)(this.eSchedaPrimoContatto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSchedaIscrizione)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}