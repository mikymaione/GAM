/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.UI.Base;
using GAMSharp.DB.DataWrapper.Base;
using System.Windows.Forms;
using System;

namespace GAMSharp.UI.Ente
{
#if DEBUG
    sealed class Ricerca : fBaseRicerca<DB.DataWrapper.Tabelle.Ente, DB.DataWrapper.Tabelle.Ente>
#else
    sealed class Ricerca : UI.Base.fFakeRicerca
#endif    
    {
        private Controlli.ucCaseTypeTextBox eDescrizione;
        private Label label1;
        private Label label2;
        private ComboBox eTipo;

#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.Ente> Carica_getEntita()
        {
            return new DB.DataWrapper.cEnte();
        }

        protected override void ChiamaCarica()
        {
            Carica(new DB.DataWrapper.Tabelle.Ente()
            {
                Descrizione = GB.cGB.Like(eDescrizione.Text),
                Tipo = GB.cGB.Like(GB.cGB.GetSelectedComboItem_ID(eTipo) as string, 2),
            });
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                Griglia.NewCol("ID", 80),
                Griglia.NewCol("Descrizione"),
                Griglia.NewCol("TipoDesc", "Tipo", 200)
            };
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.Ente> getFormDettaglio()
        {
            return new Dettaglio();
        }

        protected override void SelectFirstControl()
        {
            eDescrizione.Select();
        }
#endif

        internal Tuple<object, string> LookUp()
        {
            if (ShowLookUp() == System.Windows.Forms.DialogResult.OK)
            {
#if DEBUG
                var e = getSelectedEntity();

                if (e != null)
                    return new Tuple<object, string>(e.ID, e.Descrizione);
#endif
            }

            return null;
        }

        internal Ricerca()
        {
            AvviaAutomaticamenteLaRicerca = false;
            InitializeComponent();

            var c = new ComboFiller();
            c.Fill_eTipo(ref eTipo, true);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ricerca));
            this.eDescrizione = new Controlli.ucCaseTypeTextBox();
            this.eTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eDescrizione
            // 
            this.eDescrizione.Location = new System.Drawing.Point(80, 24);
            this.eDescrizione.MaxLength = 400;
            this.eDescrizione.Name = "eDescrizione";
            this.eDescrizione.Size = new System.Drawing.Size(197, 20);
            this.eDescrizione.TabIndex = 0;
            // 
            // eTipo
            // 
            this.eTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eTipo.FormattingEnabled = true;
            this.eTipo.Location = new System.Drawing.Point(331, 24);
            this.eTipo.Name = "eTipo";
            this.eTipo.Sorted = true;
            this.eTipo.Size = new System.Drawing.Size(217, 21);
            this.eTipo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Descrizione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo";
            // 
            // Ricerca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(713, 475);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eTipo);
            this.Controls.Add(this.eDescrizione);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ricerca";
            this.Text = "Enti";
            this.Controls.SetChildIndex(this.eDescrizione, 0);
            this.Controls.SetChildIndex(this.eTipo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}