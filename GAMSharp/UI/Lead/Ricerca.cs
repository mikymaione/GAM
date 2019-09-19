/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.GB;
using GAMSharp.UI.Base;
using GAMSharp.DB.DataWrapper.Base;
using System.Windows.Forms;

namespace GAMSharp.UI.Lead
{
#if DEBUG
    sealed class Ricerca : fBaseRicerca<DB.DataWrapper.Tabelle.Lead, DB.DataWrapper.Tabelle.Lead>
#else
    sealed class Ricerca : UI.Base.fFakeRicerca
#endif    
    {
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private UI.Controlli.ucCaseTypeTextBox eNome;
        private UI.Controlli.ddlComune eLuogoDiNascita;
        private UI.Controlli.ucCaseTypeTextBox eCognome;

        internal System.Tuple<object, string> LookUp()
        {
            if (ShowLookUp() == System.Windows.Forms.DialogResult.OK)
            {
#if DEBUG
                var e = getSelectedEntity();

                if (e != null)
                    return new System.Tuple<object, string>(e.ID, e.Cognome + " " + e.Nome);
#endif
            }

            return null;
        }

#if DEBUG
        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.Lead> getFormDettaglio()
        {
            return new Dettaglio();
        }

        protected override void SelectFirstControl()
        {
            eCognome.Select();
        }

        protected override void ChiamaCarica()
        {
            Carica(new DB.DataWrapper.Tabelle.Lead()
            {
                Cognome = cGB.Like(eCognome.Text),
                Nome = cGB.Like(eNome.Text),
                LuogoDiNascita = cGB.Like(eLuogoDiNascita.Text)
            });
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.Lead> Carica_getEntita()
        {
            return new DB.DataWrapper.cLead();
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            DataGridViewColumn[] c = {
                Griglia.NewCol("ID", 80),
                Griglia.NewCol("RagioneSociale", "Lead"),
                Griglia.NewCol("DataDiNascita","Data di nascita", 115),
                Griglia.NewCol("LuogoDiNascita","Luogo di nascita", 120)
            };

            return c;
        }
#endif

        internal Ricerca()
        {
            AvviaAutomaticamenteLaRicerca = false;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ricerca));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eNome = new UI.Controlli.ucCaseTypeTextBox();
            this.eLuogoDiNascita = new UI.Controlli.ddlComune();
            this.eCognome = new UI.Controlli.ucCaseTypeTextBox();
            this.SuspendLayout();
            // 
            // pRicerca
            //             
            this.Griglia.gbRicerca.Controls.Add(this.label4);
            this.Griglia.gbRicerca.Controls.Add(this.label3);
            this.Griglia.gbRicerca.Controls.Add(this.label2);
            this.Griglia.gbRicerca.Controls.Add(this.eNome);
            this.Griglia.gbRicerca.Controls.Add(this.eLuogoDiNascita);
            this.Griglia.gbRicerca.Controls.Add(this.eCognome);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(641, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Luogo di nascita";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Cognome";
            // 
            // eNome
            // 
            this.eNome.Location = new System.Drawing.Point(373, 19);
            this.eNome.Name = "eNome";
            this.eNome.Size = new System.Drawing.Size(215, 20);
            this.eNome.TabIndex = 2;
            // 
            // eLuogoDiNascita
            // 
            this.eLuogoDiNascita.Location = new System.Drawing.Point(732, 19);
            this.eLuogoDiNascita.Name = "eLuogoDiNascita";
            this.eLuogoDiNascita.Size = new System.Drawing.Size(215, 20);
            this.eLuogoDiNascita.TabIndex = 3;
            // 
            // eCognome
            // 
            this.eCognome.Location = new System.Drawing.Point(74, 19);
            this.eCognome.Name = "eCognome";
            this.eCognome.Size = new System.Drawing.Size(215, 20);
            this.eCognome.TabIndex = 1;
            // 
            // Ricerca
            //             
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Ricerca";
            this.Text = "Contatti";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}