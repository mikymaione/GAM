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

namespace GAMSharp.UI.Recapiti
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.Recapiti>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {
        private ComboBox eTipo;
        private TextBox eRecapito;
        private Label label1;
        private Label label2;
        private object Entita_Key = null;
        private string Entita_Tipo = "";

#if DEBUG
        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.Recapiti entita)
        {
            return null;
        }

        protected override cBaseEntity<DB.DataWrapper.Tabelle.Recapiti> getEntita()
        {
            return new DB.DataWrapper.cRecapiti();
        }

        protected override DB.DataWrapper.Tabelle.Recapiti getForm()
        {
            return new DB.DataWrapper.Tabelle.Recapiti()
            {
                ID = GB.cGB.ObjectToInt(PrimaryKey, -1),
                Entita_Key = Entita_Key,
                Entita_Tipo = Entita_Tipo,
                Tipo = eTipo.Text,
                Recapito = eRecapito.Text
            };
        }

        protected override void setForm(DB.DataWrapper.Tabelle.Recapiti e)
        {
            eTipo.Text = e.Tipo;
            eRecapito.Text = e.Recapito;
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
            if (eRecapito.Text.Length < 3)
                z.Add("Valorizzare il campo recapito");

            return z;
        }
#endif

        internal Dettaglio(string Entita_Tipo_, object Entita_Key_) : this()
        {
            Entita_Key = Entita_Key_;
            Entita_Tipo = Entita_Tipo_;
        }

        internal Dettaglio()
        {
            InitializeComponent();

            eTipo.Items.Add(new GB.cComboItem("Cellulare"));
            eTipo.Items.Add(new GB.cComboItem("Cellulare secondario"));
            eTipo.Items.Add(new GB.cComboItem("Cellulare terziario"));
            eTipo.Items.Add(new GB.cComboItem("Casa"));
            eTipo.Items.Add(new GB.cComboItem("Casa secondario"));                
            eTipo.Items.Add(new GB.cComboItem("Ufficio"));
            eTipo.Items.Add(new GB.cComboItem("Ufficio secondario"));
            eTipo.Items.Add(new GB.cComboItem("Fax"));
            eTipo.Items.Add(new GB.cComboItem("Fax secondario"));
            eTipo.Items.Add(new GB.cComboItem("Email"));
            eTipo.Items.Add(new GB.cComboItem("Email secondaria"));
            eTipo.Items.Add(new GB.cComboItem("Email lavoro"));            
            eTipo.Items.Add(new GB.cComboItem("Sito web"));
            eTipo.Items.Add(new GB.cComboItem("Sito web secondario"));
            eTipo.Items.Add(new GB.cComboItem("Facebook"));
            eTipo.Items.Add(new GB.cComboItem("WhatsApp"));
            eTipo.Items.Add(new GB.cComboItem("Linkedin"));
            eTipo.Items.Add(new GB.cComboItem("Google +"));
            eTipo.Items.Add(new GB.cComboItem("Twitter"));
            eTipo.Items.Add(new GB.cComboItem("Instagram"));
            eTipo.Items.Add(new GB.cComboItem("Telegram"));            
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.eTipo = new System.Windows.Forms.ComboBox();
            this.eRecapito = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eTipo
            // 
            this.eTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eTipo.Location = new System.Drawing.Point(87, 35);
            this.eTipo.Name = "eTipo";
            this.eTipo.Size = new System.Drawing.Size(242, 21);
            this.eTipo.TabIndex = 0;
            // 
            // eRecapito
            // 
            this.eRecapito.Location = new System.Drawing.Point(87, 61);
            this.eRecapito.MaxLength = 100;
            this.eRecapito.Name = "eRecapito";
            this.eRecapito.Size = new System.Drawing.Size(242, 20);
            this.eRecapito.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Recapito";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tipo";
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(344, 95);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eRecapito);
            this.Controls.Add(this.eTipo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Dettaglio recapito";
            this.Controls.SetChildIndex(this.eTipo, 0);
            this.Controls.SetChildIndex(this.eRecapito, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}