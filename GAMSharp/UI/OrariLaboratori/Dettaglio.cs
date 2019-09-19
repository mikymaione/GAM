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

namespace GAMSharp.UI.OrariLaboratori
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.OrariLaboratori>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {

        private int IDLaboratorio_ = -1;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox eDa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox eA;
        private System.Windows.Forms.ComboBox eGiornoSettimana;


#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.OrariLaboratori> getEntita()
        {
            return new DB.DataWrapper.cOrariLaboratori();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.OrariLaboratori e)
        {
            eGiornoSettimana.SelectedIndex = e.GiornoSettimana;
            eDa.Text = cGB.TimeToString(e.Da_Ore, e.Da_Minuti);
            eA.Text = cGB.TimeToString(e.A_Ore, e.A_Minuti);
        }

        protected override void setFormNew()
        {

        }

        protected override List<string> ValidateForm()
        {
            List<string> z = new List<string>();

            if (eDa.Text.Length != 5)
                z.Add("Il campo Dalle non è valorizzato correttamente");
            if (eA.Text.Length != 5)
                z.Add("Il campo Dalle non è valorizzato correttamente");
            if (eGiornoSettimana.SelectedIndex < 0)
                z.Add("Scegliere un giorno della settimana");

            return z;
        }

        protected override DB.DataWrapper.Tabelle.OrariLaboratori getForm()
        {
            cGB.Time da = cGB.StringToTime(eDa.Text);
            cGB.Time a = cGB.StringToTime(eA.Text);

            return new DB.DataWrapper.Tabelle.OrariLaboratori()
            {
                ID = cGB.ObjectToInt(PrimaryKey, -1),
                IDLaboratorio = IDLaboratorio_,
                GiornoSettimana = eGiornoSettimana.SelectedIndex,
                Da_Ore = da.Ora,
                Da_Minuti = da.Minuto,
                A_Ore = a.Ora,
                A_Minuti = a.Minuto
            };
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.OrariLaboratori entita)
        {
            return null;
        }
#endif

        internal Dettaglio(int IDLaboratorio__) : this()
        {
            IDLaboratorio_ = IDLaboratorio__;
        }

        internal Dettaglio()
        {
            InitializeComponent();

            this.eGiornoSettimana.Items.Add(new cComboItem(0, "Domenica"));
            this.eGiornoSettimana.Items.Add(new cComboItem(1, "Lunedi"));
            this.eGiornoSettimana.Items.Add(new cComboItem(2, "Martedì"));
            this.eGiornoSettimana.Items.Add(new cComboItem(3, "Mercoledì"));
            this.eGiornoSettimana.Items.Add(new cComboItem(4, "Giovedì"));
            this.eGiornoSettimana.Items.Add(new cComboItem(5, "Venerdì"));
            this.eGiornoSettimana.Items.Add(new cComboItem(6, "Sabato"));
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.label1 = new System.Windows.Forms.Label();
            this.eGiornoSettimana = new System.Windows.Forms.ComboBox();
            this.eDa = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eA = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Giorno della settimana";
            // 
            // eGiornoSettimana
            // 
            this.eGiornoSettimana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eGiornoSettimana.FormattingEnabled = true;
            this.eGiornoSettimana.Location = new System.Drawing.Point(144, 36);
            this.eGiornoSettimana.Name = "eGiornoSettimana";
            this.eGiornoSettimana.Size = new System.Drawing.Size(121, 21);
            this.eGiornoSettimana.TabIndex = 0;
            // 
            // eDa
            // 
            this.eDa.Location = new System.Drawing.Point(144, 63);
            this.eDa.Mask = "00:00";
            this.eDa.Name = "eDa";
            this.eDa.Size = new System.Drawing.Size(53, 20);
            this.eDa.TabIndex = 1;
            this.eDa.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dalle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Alle";
            // 
            // eA
            // 
            this.eA.Location = new System.Drawing.Point(144, 89);
            this.eA.Mask = "00:00";
            this.eA.Name = "eA";
            this.eA.Size = new System.Drawing.Size(53, 20);
            this.eA.TabIndex = 2;
            this.eA.ValidatingType = typeof(System.DateTime);
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(287, 121);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eDa);
            this.Controls.Add(this.eGiornoSettimana);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio orario";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.eGiornoSettimana, 0);
            this.Controls.SetChildIndex(this.eDa, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.eA, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}