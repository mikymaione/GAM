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
using GAMSharp.DB.DataWrapper.Tabelle;

namespace GAMSharp.UI.InfoAggiuntive
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.InfoAggiuntive>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {
        private Label label2;
        private Label label1;
        private TextBox eNote;
        private Label label3;
        private Controlli.ucFileChoose eAllegato;
        private Controlli.ucCaseTypeTextBox eTipo;
        private object Entita_Key = null;
        private string Entita_Tipo = "";

#if DEBUG

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.InfoAggiuntive entita)
        {
            return null;
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.InfoAggiuntive> getEntita()
        {
            return new DB.DataWrapper.cInfoAggiuntive();
        }

        protected override DB.DataWrapper.Tabelle.InfoAggiuntive getForm()
        {
            return new DB.DataWrapper.Tabelle.InfoAggiuntive()
            {
                ID = GB.cGB.ObjectToInt(PrimaryKey, -1),
                Entita_Key = Entita_Key,
                Entita_Tipo = Entita_Tipo,
                Tipo = eTipo.Text,
                Note = eNote.Text,
                Allegato = eAllegato.FilePath_Real,
                Hide = GB.cGB.BoolToEnglishChar(!eAllegato.FilePath_Real.Equals(""))
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.InfoAggiuntive e)
        {
            eTipo.Text = e.Tipo;
            eNote.Text = e.Note;
            eAllegato.FilePath_Real = e.Allegato;
        }

        protected override void setFormNew()
        {
            //
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eTipo.Text.Length < 3)
                z.Add("Valorizzare il campo Tipo");

            return z;
        }
#endif        

        internal Dettaglio(string Entita_Tipo_, object Entita_Key_) : this()
        {
            Entita_Key = Entita_Key_;
            Entita_Tipo = Entita_Tipo_;

            eAllegato.PathEntità = Entita_Tipo;
            eAllegato.PathKey = GB.cGB.ObjectToString(Entita_Key_);
        }

        internal Dettaglio()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.eNote = new System.Windows.Forms.TextBox();
            this.eTipo = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.eAllegato = new GAMSharp.UI.Controlli.ucFileChoose();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Note";
            // 
            // eNote
            // 
            this.eNote.Location = new System.Drawing.Point(86, 90);
            this.eNote.MaxLength = 5000;
            this.eNote.Multiline = true;
            this.eNote.Name = "eNote";
            this.eNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eNote.Size = new System.Drawing.Size(242, 292);
            this.eNote.TabIndex = 2;
            // 
            // eTipo
            // 
            this.eTipo.Location = new System.Drawing.Point(86, 34);
            this.eTipo.MaxLength = 50;
            this.eTipo.Name = "eTipo";
            this.eTipo.Size = new System.Drawing.Size(242, 20);
            this.eTipo.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Allegato";
            // 
            // eAllegato
            // 
            this.eAllegato.FilePath_Real = "";
            this.eAllegato.Location = new System.Drawing.Point(86, 60);
            this.eAllegato.Name = "eAllegato";
            this.eAllegato.PathEntità = null;
            this.eAllegato.PathKey = null;
            this.eAllegato.Size = new System.Drawing.Size(242, 24);
            this.eAllegato.TabIndex = 1;
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(345, 394);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eAllegato);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eNote);
            this.Controls.Add(this.eTipo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio informazioni aggiuntive";
            this.Controls.SetChildIndex(this.eTipo, 0);
            this.Controls.SetChildIndex(this.eNote, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.eAllegato, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}