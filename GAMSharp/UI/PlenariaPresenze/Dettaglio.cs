/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GAMSharp.DB.DataWrapper.Base;
using GAMSharp.GB;

namespace GAMSharp.UI.PlenariaPresenze
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.PlenariaPresenze>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {
        private Controlli.ucLookUp eEntity;
        private Label label1;
        private Label label2;
        private ComboBox eTipo;
        private int IDPlenaria_ = -1;


        private void eEntity_DettaglioRichiesto(object Key)
        {
#if DEBUG
            dynamic d = null;
            var e = cGB.GetSelectedComboItem_Valore(eTipo);

            if (e.Equals("Ente"))
                d = new Ente.Dettaglio();
            else if (e.Equals("Lead"))
                d = new Lead.Dettaglio();
            else if (e.Equals("Persona"))
                d = new Persona.Dettaglio();
            else if (e.Equals("Minore"))
                d = new Minore.Dettaglio();

            if (d != null)
            {
                if (d.ShowDialog(Key) == DialogResult.OK)
                    eEntity.Text = RiCaricaEntita().ExRicerca.Descrizione;

                d.Dispose();
            }
#endif
        }

        private void eEntity_RicercaRichiesta()
        {
            dynamic f = null;            
            eEntity.ClearAll();

            if (cGB.GetSelectedComboItem_ID(eTipo).Equals("Ente"))
                f = new Ente.Ricerca();
            else if (cGB.GetSelectedComboItem_ID(eTipo).Equals("Lead"))
                f = new Lead.Ricerca();
            else if (cGB.GetSelectedComboItem_ID(eTipo).Equals("Persona"))
                f = new Persona.Ricerca();
            else if (cGB.GetSelectedComboItem_ID(eTipo).Equals("Minore"))
                f = new Minore.Ricerca();

            if (f != null)
            {
                var r = f.LookUp();

                if (r != null)
                {
                    eEntity.Elemento = r;
                    eEntity.Tipo = cGB.GetSelectedComboItem_Valore(eTipo);
                }

                f.Dispose();
            }
        }

#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.PlenariaPresenze> getEntita()
        {
            return new DB.DataWrapper.cPlenariaPresenze();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.PlenariaPresenze e)
        {
            cGB.SetSelectedComboItem_ID(ref eTipo, e.getValorizedType());
            eEntity.Tipo = e.getValorizedType();
            eEntity.Value = e.getValorizedKey();
            eEntity.Text = e.ExRicerca.Descrizione;
        }

        protected override void setFormNew()
        {

        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eTipo.SelectedIndex < 0)
                z.Add("Devi selezionare un tipo");
            if (eEntity.Value == null)
                z.Add("Devi selezionare un entità");
            if (!eEntity.Tipo.Equals(cGB.GetSelectedComboItem_ID(eTipo)))
                z.Add("L'entità selezionata non è del tipo selezionato");

            return z;
        }

        protected override DB.DataWrapper.Tabelle.PlenariaPresenze getForm()
        {
            var v = eEntity.Value;
            var e = cGB.GetSelectedComboItem_Valore(eTipo);

            var r = new DB.DataWrapper.Tabelle.PlenariaPresenze()
            {
                ID = cGB.ObjectToInt(PrimaryKey, -1),
                IDPlenaria = IDPlenaria_
            };

            if (e.Equals("Lead"))
                r.Lead_ID = (int?)v;
            else if (e.Equals("Ente"))
                r.Ente_ID = (int?)v;
            else if (e.Equals("Minore"))
                r.Minore_CF = (string)v;
            else if (e.Equals("Persona"))
                r.Persona_CF = (string)v;

            return r;
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.PlenariaPresenze entita)
        {
            return null;
        }
#endif

        internal Dettaglio(int IDPlenaria__) : this()
        {
            IDPlenaria_ = IDPlenaria__;
        }

        internal Dettaglio()
        {
            InitializeComponent();

            eTipo.Items.Add(new cComboItem("Ente"));
            eTipo.Items.Add(new cComboItem("Lead"));
            eTipo.Items.Add(new cComboItem("Minore"));
            eTipo.Items.Add(new cComboItem("Persona"));

            eEntity.RicercaRichiesta += eEntity_RicercaRichiesta;
            eEntity.DettaglioRichiesto += eEntity_DettaglioRichiesto;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.eEntity = new GAMSharp.UI.Controlli.ucLookUp();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eTipo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // eEntity
            // 
            this.eEntity.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eEntity.Elemento")));
            this.eEntity.Location = new System.Drawing.Point(94, 62);
            this.eEntity.Name = "eEntity";
            this.eEntity.ReadOnly = false;
            this.eEntity.Size = new System.Drawing.Size(318, 25);
            this.eEntity.TabIndex = 1;
            this.eEntity.Tipo = null;
            this.eEntity.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Entità";
            // 
            // eTipo
            // 
            this.eTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eTipo.FormattingEnabled = true;
            this.eTipo.Location = new System.Drawing.Point(94, 38);
            this.eTipo.Name = "eTipo";
            this.eTipo.Size = new System.Drawing.Size(318, 21);
            this.eTipo.TabIndex = 0;
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(428, 99);
            this.Controls.Add(this.eTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eEntity);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio presenza";
            this.Controls.SetChildIndex(this.eEntity, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.eTipo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}