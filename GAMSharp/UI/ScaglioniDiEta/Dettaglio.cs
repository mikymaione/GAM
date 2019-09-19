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

namespace GAMSharp.UI.ScaglioniDiEta
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.ScaglioniDiEta>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif    
    {        
        private UI.Controlli.ucCaseTypeTextBox eDescrizione;        
        private System.Windows.Forms.NumericUpDown eA;
        private System.Windows.Forms.NumericUpDown eDa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Minore.cRicerca Griglia_Minori;
        private System.Windows.Forms.Label label3;


#if DEBUG
        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.ScaglioniDiEta entita)
        {
            return null;
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.ScaglioniDiEta> getEntita()
        {
            return new DB.DataWrapper.cScaglioniDiEta();
        }

        protected override DB.DataWrapper.Tabelle.ScaglioniDiEta getForm()
        {
            return new DB.DataWrapper.Tabelle.ScaglioniDiEta()
            {
                ID = cGB.ObjectToInt(PrimaryKey, -1),
                Descrizione = eDescrizione.Text,
                Da = Convert.ToInt32(eDa.Value),
                A = Convert.ToInt32(eA.Value)
            };
        }       

        protected override void setForm(DB.DataWrapper.Tabelle.ScaglioniDiEta e)
        {
            eDescrizione.Text = e.Descrizione;
            eDa.Value = e.Da;
            eA.Value = e.A;
        }

        protected override void setFormNew()
        {

        }

        protected override List<string> ValidateForm()
        {
            List<string> z = new List<string>();

            if (eDescrizione.Text.Length < 3)
                z.Add("La descrizione deve essere almeno di 3 caratteri");

            return z;
        }
#endif

        public override DialogResult ShowDialog(object PrimaryKey_)
        {
            Griglia_Minori.IDScaglioniDiEta = cGB.ObjectToInt(PrimaryKey_, -1);            

            return base.ShowDialog(PrimaryKey_);
        }

        internal Dettaglio()
        {
            InitializeComponent();

            Griglia_Minori.RicercaVisibile = false;            
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.eDa = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.eDescrizione = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eA = new System.Windows.Forms.NumericUpDown();
            this.Griglia_Minori = new GAMSharp.UI.Minore.cRicerca();
            ((System.ComponentModel.ISupportInitialize)(this.eDa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eA)).BeginInit();
            this.SuspendLayout();
            // 
            // eDa
            // 
            this.eDa.Location = new System.Drawing.Point(121, 62);
            this.eDa.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.eDa.Name = "eDa";
            this.eDa.Size = new System.Drawing.Size(120, 20);
            this.eDa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Descrizione";
            // 
            // eDescrizione
            // 
            this.eDescrizione.Location = new System.Drawing.Point(121, 36);
            this.eDescrizione.MaxLength = 250;
            this.eDescrizione.Name = "eDescrizione";
            this.eDescrizione.Size = new System.Drawing.Size(215, 20);
            this.eDescrizione.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Da";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "A";
            // 
            // eA
            // 
            this.eA.Location = new System.Drawing.Point(121, 88);
            this.eA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.eA.Name = "eA";
            this.eA.Size = new System.Drawing.Size(120, 20);
            this.eA.TabIndex = 2;
            this.eA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cRicerca1
            // 
            this.Griglia_Minori.Location = new System.Drawing.Point(12, 126);            
            this.Griglia_Minori.Name = "Griglia_Minori";
            this.Griglia_Minori.Size = new System.Drawing.Size(720, 523);
            this.Griglia_Minori.TabIndex = 11;
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(744, 661);
            this.Controls.Add(this.Griglia_Minori);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eDescrizione);
            this.Controls.Add(this.eDa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(760, 700);
            this.Name = "Dettaglio";
            this.Text = "Dettaglio scaglione";
            this.Controls.SetChildIndex(this.eDa, 0);
            this.Controls.SetChildIndex(this.eDescrizione, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.eA, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.Griglia_Minori, 0);
            ((System.ComponentModel.ISupportInitialize)(this.eDa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}