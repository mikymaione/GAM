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

namespace GAMSharp.UI.Educatrice_Laboratorio
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.Educatrice_Laboratorio>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {
        private Controlli.ucLookUp ePersona_CF;
        private Label label2;
        private int IDLaboratorio_ = -1;

#if DEBUG
        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Educatrice_Laboratorio entita)
        {
            return null;
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.Educatrice_Laboratorio> getEntita()
        {
            return new DB.DataWrapper.cEducatrice_Laboratorio();
        }

        protected override DB.DataWrapper.Tabelle.Educatrice_Laboratorio getForm()
        {
            return new DB.DataWrapper.Tabelle.Educatrice_Laboratorio()
            {
                ID = cGB.ObjectToInt(PrimaryKey, -1),
                IDLaboratorio = IDLaboratorio_,
                CFEducatrice = cGB.ObjectToString(ePersona_CF.Value)
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Educatrice_Laboratorio e)
        {
            IDLaboratorio_ = e.IDLaboratorio;
            ePersona_CF.Value = e.CFEducatrice;
            ePersona_CF.Text = e.ExRicerca.RagioneSociale;
        }

        protected override void setFormNew()
        {
            //
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
            using (var r = new Educatrice.Ricerca())
                ePersona_CF.Elemento = r.LookUp();
        }

        private void ePersona_CF_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var r = new Educatrice.Dettaglio())
                if (r.ShowDialog(Key) == DialogResult.OK)
                    ePersona_CF.Text = RiCaricaEntita().ExRicerca.RagioneSociale;
#endif 
        }

        internal Dettaglio(int IDLaboratorio__) : this()
        {
            IDLaboratorio_ = IDLaboratorio__;
        }

        internal Dettaglio()
        {
            InitializeComponent();

            ePersona_CF.RicercaRichiesta += ePersona_CF_RicercaRichiesta;
            ePersona_CF.DettaglioRichiesto += ePersona_CF_DettaglioRichiesto;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.ePersona_CF = new GAMSharp.UI.Controlli.ucLookUp();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ePersona_CF
            // 
            this.ePersona_CF.Elemento = ((System.Tuple<object, string>)(resources.GetObject("ePersona_CF.Elemento")));
            this.ePersona_CF.Location = new System.Drawing.Point(119, 36);
            this.ePersona_CF.Name = "ePersona_CF";
            this.ePersona_CF.ReadOnly = false;
            this.ePersona_CF.Size = new System.Drawing.Size(332, 25);
            this.ePersona_CF.TabIndex = 0;
            this.ePersona_CF.Tipo = null;
            this.ePersona_CF.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Educatrice";
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(463, 75);
            this.Controls.Add(this.ePersona_CF);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio educatrice del laboratorio";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.ePersona_CF, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}