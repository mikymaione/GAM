/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Windows.Forms;

namespace GAMSharp.UI.Base.Ex
{
    abstract class fTabbedDettaglio<TableEntity> : fBaseDettaglio<TableEntity> where TableEntity : DB.DataWrapper.Tabelle.TabellaBase, new()
    {
        public ImageList imgLstTabs;
        public TabControl tabControl1;
        public TabPage tpIndirizzi, tpInfoAggiuntive, tpRecapiti, tpDati;
        public System.ComponentModel.IContainer components;
        public Indirizzi.cRicerca Griglia_Indirizzi;
        public Recapiti.cRicerca Griglia_Recapiti;
        public InfoAggiuntive.cRicerca Griglia_InfoAggiuntive;

        public string NomeEntità { get; set; }

        public override DialogResult ShowDialog(object PrimaryKey_)
        {
            Griglia_Indirizzi.Entita_Tipo = NomeEntità;
            Griglia_Recapiti.Entita_Tipo = NomeEntità;
            Griglia_InfoAggiuntive.Entita_Tipo = NomeEntità;

            Griglia_Indirizzi.Entita_Key = PrimaryKey_;
            Griglia_Recapiti.Entita_Key = PrimaryKey_;
            Griglia_InfoAggiuntive.Entita_Key = PrimaryKey_;

            tpRecapiti.Enabled = true;
            tpIndirizzi.Enabled = true;
            tpInfoAggiuntive.Enabled = true;

            return base.ShowDialog(PrimaryKey_);
        }

        internal fTabbedDettaglio() : this("") { }

        internal fTabbedDettaglio(string NomeEntità_)
        {
            NomeEntità = NomeEntità_;

            components = new System.ComponentModel.Container();
            imgLstTabs = new ImageList(components);
            imgLstTabs.Images.Add(Properties.Resources.to_do_list_checked_all);
            imgLstTabs.Images.Add(Properties.Resources.house_one);
            imgLstTabs.Images.Add(Properties.Resources.telephone);
            imgLstTabs.Images.Add(Properties.Resources.award_star_gold_blue);

            InitializeComponent();

            PossoEssereFullScreen = true;

            Griglia_Indirizzi.RicercaVisibile = false;
            Griglia_Recapiti.RicercaVisibile = false;
            Griglia_InfoAggiuntive.RicercaVisibile = false;
        }

        private void InitializeComponent()
        {            
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDati = new System.Windows.Forms.TabPage();
            this.tpIndirizzi = new System.Windows.Forms.TabPage();
            this.Griglia_Indirizzi = new GAMSharp.UI.Indirizzi.cRicerca();
            this.tpRecapiti = new System.Windows.Forms.TabPage();
            this.Griglia_Recapiti = new GAMSharp.UI.Recapiti.cRicerca();
            this.tpInfoAggiuntive = new System.Windows.Forms.TabPage();
            this.Griglia_InfoAggiuntive = new GAMSharp.UI.InfoAggiuntive.cRicerca();
            this.tabControl1.SuspendLayout();
            this.tpIndirizzi.SuspendLayout();
            this.tpRecapiti.SuspendLayout();
            this.tpInfoAggiuntive.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpDati);
            this.tabControl1.Controls.Add(this.tpIndirizzi);
            this.tabControl1.Controls.Add(this.tpRecapiti);
            this.tabControl1.Controls.Add(this.tpInfoAggiuntive);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imgLstTabs;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(708, 235);
            this.tabControl1.TabIndex = 18;
            // 
            // tpDati
            // 
            this.tpDati.ImageIndex = 0;
            this.tpDati.Location = new System.Drawing.Point(4, 23);
            this.tpDati.Name = "tpDati";
            this.tpDati.Padding = new System.Windows.Forms.Padding(3);
            this.tpDati.Size = new System.Drawing.Size(700, 208);
            this.tpDati.TabIndex = 0;
            this.tpDati.Text = "Dati";
            this.tpDati.UseVisualStyleBackColor = true;
            // 
            // tpIndirizzi
            // 
            this.tpIndirizzi.Controls.Add(this.Griglia_Indirizzi);
            this.tpIndirizzi.ImageIndex = 1;
            this.tpIndirizzi.Enabled = false;
            this.tpIndirizzi.Location = new System.Drawing.Point(4, 23);
            this.tpIndirizzi.Name = "tpIndirizzi";
            this.tpIndirizzi.Padding = new System.Windows.Forms.Padding(3);
            this.tpIndirizzi.Size = new System.Drawing.Size(700, 208);
            this.tpIndirizzi.TabIndex = 1;
            this.tpIndirizzi.Text = "Indirizzi";
            this.tpIndirizzi.UseVisualStyleBackColor = true;
            // 
            // Griglia_Indirizzi
            // 
            this.Griglia_Indirizzi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_Indirizzi.Entita_Key = null;
            this.Griglia_Indirizzi.Entita_Tipo = null;
            this.Griglia_Indirizzi.Location = new System.Drawing.Point(3, 3);
            this.Griglia_Indirizzi.Name = "Griglia_Indirizzi";
            this.Griglia_Indirizzi.Size = new System.Drawing.Size(694, 202);
            this.Griglia_Indirizzi.TabIndex = 0;
            // 
            // tpRecapiti
            // 
            this.tpRecapiti.Controls.Add(this.Griglia_Recapiti);
            this.tpRecapiti.ImageIndex = 2;
            this.tpRecapiti.Enabled = false;
            this.tpRecapiti.Location = new System.Drawing.Point(4, 23);
            this.tpRecapiti.Name = "tpRecapiti";
            this.tpRecapiti.Padding = new System.Windows.Forms.Padding(3);
            this.tpRecapiti.Size = new System.Drawing.Size(700, 208);
            this.tpRecapiti.TabIndex = 2;
            this.tpRecapiti.Text = "Recapiti";
            this.tpRecapiti.UseVisualStyleBackColor = true;
            // 
            // Griglia_Recapiti
            // 
            this.Griglia_Recapiti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_Recapiti.Entita_Key = null;
            this.Griglia_Recapiti.Entita_Tipo = null;
            this.Griglia_Recapiti.Location = new System.Drawing.Point(3, 3);
            this.Griglia_Recapiti.Name = "Griglia_Recapiti";
            this.Griglia_Recapiti.Size = new System.Drawing.Size(694, 202);
            this.Griglia_Recapiti.TabIndex = 0;
            // 
            // tbInfoAggiuntive
            // 
            this.tpInfoAggiuntive.Controls.Add(this.Griglia_InfoAggiuntive);
            this.tpInfoAggiuntive.ImageIndex = 3;
            this.tpInfoAggiuntive.Enabled = false;
            this.tpInfoAggiuntive.Location = new System.Drawing.Point(4, 23);
            this.tpInfoAggiuntive.Name = "tbInfoAggiuntive";
            this.tpInfoAggiuntive.Padding = new System.Windows.Forms.Padding(3);
            this.tpInfoAggiuntive.Size = new System.Drawing.Size(700, 208);
            this.tpInfoAggiuntive.TabIndex = 3;
            this.tpInfoAggiuntive.Text = "Informazioni aggiuntive";
            this.tpInfoAggiuntive.UseVisualStyleBackColor = true;
            // 
            // Griglia_InfoAggiuntive
            // 
            this.Griglia_InfoAggiuntive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_InfoAggiuntive.Entita_Key = null;
            this.Griglia_InfoAggiuntive.Entita_Tipo = null;
            this.Griglia_InfoAggiuntive.Location = new System.Drawing.Point(3, 3);
            this.Griglia_InfoAggiuntive.Name = "Griglia_InfoAggiuntive";
            this.Griglia_InfoAggiuntive.Size = new System.Drawing.Size(694, 202);
            this.Griglia_InfoAggiuntive.TabIndex = 0;
            // 
            // fTabbedDettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(708, 257);
            this.Controls.Add(this.tabControl1);
            this.Name = "fTabbedDettaglio";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tpIndirizzi.ResumeLayout(false);
            this.tpRecapiti.ResumeLayout(false);
            this.tpInfoAggiuntive.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}