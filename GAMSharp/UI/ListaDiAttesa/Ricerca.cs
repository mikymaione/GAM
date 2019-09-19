/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Base;
using GAMSharp.UI.Base;
using GAMSharp.GB;
using System.Windows.Forms;

namespace GAMSharp.UI.ListaDiAttesa
{
#if DEBUG
    class Ricerca : fBaseRicerca<DB.DataWrapper.Tabelle.ListaDiAttesa, DB.DataWrapper.Tabelle.ListaDiAttesaRicerca>
#else
    class Ricerca : UI.Base.fFakeRicerca
#endif    
    {
                
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private UI.Controlli.ucCaseTypeTextBox eNome;
        private UI.Controlli.ucCaseTypeTextBox eCognome;
        private System.Windows.Forms.TextBox eCF;                        

#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.ListaDiAttesa> Carica_getEntita()
        {
            return new DB.DataWrapper.cListaDiAttesa();
        }

        protected override void ChiamaCarica()
        {
            Carica(new DB.DataWrapper.cListaDiAttesa(), new DB.DataWrapper.Tabelle.ListaDiAttesaRicerca()
            {
                Minore_CF = cGB.Like(eCF.Text),
                Cognome = cGB.Like(eCognome.Text),
                Nome = cGB.Like(eNome.Text)
            });
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            DataGridViewColumn[] c = {
                Griglia.NewCol("Minore_CF", "Codice fiscale", 140),
                Griglia.NewCol("RagioneSociale", "Persona"),
                Griglia.NewCol("EntrataInLista", "Entrata in lista", 120),
                Griglia.NewCol("UscitaDallaLista", "Uscita dalla lista", 120)
            };

            return c;
        }

        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.ListaDiAttesa> getFormDettaglio()
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eNome = new UI.Controlli.ucCaseTypeTextBox();
            this.eCF = new System.Windows.Forms.TextBox();
            this.eCognome = new UI.Controlli.ucCaseTypeTextBox();
            this.label1 = new System.Windows.Forms.Label();            
            this.SuspendLayout();
            // 
            // pRicerca
            //             
            this.Griglia.gbRicerca.Controls.Add(this.label3);
            this.Griglia.gbRicerca.Controls.Add(this.label2);
            this.Griglia.gbRicerca.Controls.Add(this.eNome);
            this.Griglia.gbRicerca.Controls.Add(this.eCF);
            this.Griglia.gbRicerca.Controls.Add(this.eCognome);
            this.Griglia.gbRicerca.Controls.Add(this.label1);                                    
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Cognome";
            // 
            // eNome
            // 
            this.eNome.Location = new System.Drawing.Point(583, 23);
            this.eNome.Name = "eNome";
            this.eNome.Size = new System.Drawing.Size(215, 20);
            this.eNome.TabIndex = 2;
            // 
            // eCF
            // 
            this.eCF.Location = new System.Drawing.Point(42, 23);
            this.eCF.MaxLength = 16;
            this.eCF.Name = "eCF";
            this.eCF.CharacterCasing = CharacterCasing.Upper;
            this.eCF.Size = new System.Drawing.Size(215, 20);
            this.eCF.TabIndex = 0;
            // 
            // eCognome
            // 
            this.eCognome.Location = new System.Drawing.Point(321, 23);
            this.eCognome.Name = "eCognome";
            this.eCognome.Size = new System.Drawing.Size(215, 20);
            this.eCognome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "CF";
            // 
            // Ricerca
            //             
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(904, 561);            
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(920, 600);
            this.Name = "Ricerca";
            this.Text = "Liste di attesa";            
            this.ResumeLayout(false);
        }


    }
}