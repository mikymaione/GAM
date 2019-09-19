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

namespace GAMSharp.UI.Persona
{
#if DEBUG
    sealed class Ricerca : fBaseRicerca<DB.DataWrapper.Tabelle.Persona, DB.DataWrapper.Tabelle.Persona>
#else
    sealed class Ricerca : UI.Base.fFakeRicerca
#endif    
    {
        internal enum eQuery
        {
            Ricerca,
            GSG_Partecipanti
        };

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private UI.Controlli.ucCaseTypeTextBox eNome;
        private UI.Controlli.ddlComune eLuogoDiNascita;
        private TextBox eCF;
        private UI.Controlli.ucCaseTypeTextBox eCognome;
        private System.Windows.Forms.Label label1;

        private eQuery Query = eQuery.Ricerca;

        internal System.Tuple<object, string> LookUp(eQuery Query_ = eQuery.Ricerca)
        {
            Query = Query_;

            if (ShowLookUp() == System.Windows.Forms.DialogResult.OK)
            {
#if DEBUG
                var e = getSelectedEntity();

                if (e != null)
                    return new System.Tuple<object, string>(e.CF, e.Cognome + " " + e.Nome);
#endif
            }

            return null;
        }

#if DEBUG
        protected override fBaseDettaglio<DB.DataWrapper.Tabelle.Persona> getFormDettaglio()
        {
            return new Dettaglio();
        }

        protected override void SelectFirstControl()
        {
            eCF.Select();
        }

        protected override void ChiamaCarica()
        {
            DB.cRisultatoSQL<System.Data.DataTable> r = null;
            var maxr = cGB.ObjectToInt(Griglia.eFirstXRows.Text, -1);
            var p = new DB.DataWrapper.cPersona();
            var parametri = new DB.DataWrapper.Tabelle.Persona()
            {
                CF = cGB.Like(eCF.Text, 16),
                Cognome = cGB.Like(eCognome.Text),
                Nome = cGB.Like(eNome.Text),
                LuogoDiNascita = cGB.Like(eLuogoDiNascita.Text)
            };

            if (Query == eQuery.Ricerca)
                r = p.Ricerca(maxr, parametri);
            else if (Query == eQuery.GSG_Partecipanti)
                r = p.GSG_Partecipanti(maxr, parametri);

            if (r.Errore)
                cGB.MsgBox(r.Eccezione);
            else
                Griglia.Carica(r.Risultato);
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.Persona> Carica_getEntita()
        {
            return new DB.DataWrapper.cPersona();
        }

        protected override DataGridViewColumn[] getColonneGriglia()
        {
            DataGridViewColumn[] c = {
                Griglia.NewCol("CF","Codice fiscale", 140),
                Griglia.NewCol("RagioneSociale", "Persona"),
                Griglia.NewCol("DataDiNascita","Data di nascita", 80),
                Griglia.NewCol("LuogoDiNascita","Luogo di nascita", 120),
                Griglia.NewCol("Tutore", 130),
                Griglia.NewCol("Padre", 130),
                Griglia.NewCol("Madre", 130)
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
            this.eCF = new TextBox();
            this.eCognome = new UI.Controlli.ucCaseTypeTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pRicerca
            //             
            this.Griglia.gbRicerca.Controls.Add(this.label4);
            this.Griglia.gbRicerca.Controls.Add(this.label3);
            this.Griglia.gbRicerca.Controls.Add(this.label2);
            this.Griglia.gbRicerca.Controls.Add(this.eNome);
            this.Griglia.gbRicerca.Controls.Add(this.eLuogoDiNascita);
            this.Griglia.gbRicerca.Controls.Add(this.eCF);
            this.Griglia.gbRicerca.Controls.Add(this.eCognome);
            this.Griglia.gbRicerca.Controls.Add(this.label1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 51);
            this.label4.Name = "label4";
            this.label4.Text = "Luogo di nascita";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(641, 26);
            this.label3.Name = "label3";
            this.label3.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 26);
            this.label2.Name = "label2";
            this.label2.Text = "Cognome";
            // 
            // eNome
            // 
            this.eNome.Location = new System.Drawing.Point(682, 19);
            this.eNome.Name = "eNome";
            this.eNome.Size = new System.Drawing.Size(215, 20);
            this.eNome.TabIndex = 2;
            // 
            // eLuogoDiNascita
            // 
            this.eLuogoDiNascita.Location = new System.Drawing.Point(107, 45);
            this.eLuogoDiNascita.Name = "eLuogoDiNascita";
            this.eLuogoDiNascita.Size = new System.Drawing.Size(215, 20);
            this.eLuogoDiNascita.TabIndex = 3;
            // 
            // eCF
            // 
            this.eCF.Location = new System.Drawing.Point(107, 19);
            this.eCF.MaxLength = 16;
            this.eCF.CharacterCasing = CharacterCasing.Upper;
            this.eCF.Name = "eCF";
            this.eCF.Size = new System.Drawing.Size(215, 20);
            this.eCF.TabIndex = 0;
            // 
            // eCognome
            // 
            this.eCognome.Location = new System.Drawing.Point(416, 19);
            this.eCognome.Name = "eCognome";
            this.eCognome.Size = new System.Drawing.Size(215, 20);
            this.eCognome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Text = "CF";
            // 
            // Ricerca
            //             
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Ricerca";
            this.Text = "Persone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}