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
using GAMSharp.GB;

namespace GAMSharp.UI.Minore
{
#if DEBUG
    sealed class Ricerca : fBaseRicerca<DB.DataWrapper.Tabelle.Minore, DB.DataWrapper.Tabelle.MinoreRicerca>
#else
    sealed class Ricerca : UI.Base.fFakeRicerca
#endif    
    {
        private Label label4;
        private Label label3;
        private Label label2;
        private Controlli.ucCaseTypeTextBox eNome;
        private Controlli.ddlComune eLuogoDiNascita;
        private TextBox eCF;
        private Controlli.ucCaseTypeTextBox eCognome;
        private Label label1;

        internal System.Tuple<object, string> LookUp()
        {
            if (ShowLookUp() == System.Windows.Forms.DialogResult.OK)
            {
#if DEBUG
                var e = getSelectedEntity();

                if (e != null)
                    return new System.Tuple<object, string>(e.Persona_CF, e.ExRicerca.RagioneSociale);
#endif
            }

            return null;
        }

#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.Minore> Carica_getEntita()
        {
            return new DB.DataWrapper.cMinore();
        }

        protected override void ChiamaCarica()
        {
            Carica(new DB.DataWrapper.cMinore(), new DB.DataWrapper.Tabelle.MinoreRicerca()
            {
                Persona_CF = cGB.Like(eCF.Text, 16),
                Cognome = cGB.Like(eCognome.Text),
                Nome = cGB.Like(eNome.Text),
                LuogoDiNascita = cGB.Like(eLuogoDiNascita.Text)                
            });
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                Griglia.NewCol("Persona_CF","Codice fiscale", 140),
                Griglia.NewCol("RagioneSociale", "Minore"),
                Griglia.NewCol("DataDiNascita","Data di nascita", 80),
                Griglia.NewCol("LuogoDiNascita","Luogo di nascita", 120)
            };
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.Minore> getFormDettaglio()
        {
            return new Dettaglio();
        }

        protected override void SelectFirstControl()
        {
            eCF.Select();
        }
#endif

        internal Ricerca()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ricerca));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eNome = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.eLuogoDiNascita = new GAMSharp.UI.Controlli.ddlComune();
            this.eCF = new System.Windows.Forms.TextBox();
            this.eCognome = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 49);
            this.label4.Name = "label4";
            this.label4.Text = "Luogo di nascita";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(638, 24);
            this.label3.Name = "label3";
            this.label3.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 24);
            this.label2.Name = "label2";
            this.label2.Text = "Cognome";
            // 
            // eNome
            // 
            this.eNome.Location = new System.Drawing.Point(679, 17);
            this.eNome.Name = "eNome";
            this.eNome.Size = new System.Drawing.Size(215, 20);
            this.eNome.TabIndex = 2;
            // 
            // eLuogoDiNascita
            // 
            this.eLuogoDiNascita.Location = new System.Drawing.Point(104, 43);
            this.eLuogoDiNascita.Name = "eLuogoDiNascita";
            this.eLuogoDiNascita.Size = new System.Drawing.Size(215, 20);
            this.eLuogoDiNascita.TabIndex = 3;
            // 
            // eCF
            // 
            this.eCF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.eCF.Location = new System.Drawing.Point(104, 17);
            this.eCF.MaxLength = 16;
            this.eCF.Name = "eCF";
            this.eCF.Size = new System.Drawing.Size(215, 20);
            this.eCF.TabIndex = 0;
            // 
            // eCognome
            // 
            this.eCognome.Location = new System.Drawing.Point(413, 17);
            this.eCognome.Name = "eCognome";
            this.eCognome.Size = new System.Drawing.Size(215, 20);
            this.eCognome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Text = "CF";
            // 
            // Ricerca
            //             
            this.Griglia.gbRicerca.Controls.Add(this.label4);
            this.Griglia.gbRicerca.Controls.Add(this.label3);
            this.Griglia.gbRicerca.Controls.Add(this.label2);
            this.Griglia.gbRicerca.Controls.Add(this.eNome);
            this.Griglia.gbRicerca.Controls.Add(this.eLuogoDiNascita);
            this.Griglia.gbRicerca.Controls.Add(this.eCF);
            this.Griglia.gbRicerca.Controls.Add(this.eCognome);
            this.Griglia.gbRicerca.Controls.Add(this.label1);

            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Ricerca";
            this.Text = "Minori";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}