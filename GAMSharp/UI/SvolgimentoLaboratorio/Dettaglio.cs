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
using GAMSharp.GB;

namespace GAMSharp.UI.SvolgimentoLaboratorio
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.SvolgimentoLaboratorio>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {
        private TabControl tabControl1;
        private TabPage tpDati;
        private TextBox eNote;
        private Label label1;
        private DateTimePicker eAlle;
        private DateTimePicker eDalle;
        private Label label3;
        private Label label2;
        private TabPage tpPartecipanti;
        private ImageList ilIcone;
        private System.ComponentModel.IContainer components;
        private PresenzeSvolgimentoLaboratorio.MultiSelectGrid GrigliaMultiSelect_Minore;
        private int IDLaboratorio_ = -1;


#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.SvolgimentoLaboratorio> getEntita()
        {
            return new DB.DataWrapper.cSvolgimentoLaboratorio();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.SvolgimentoLaboratorio e)
        {
            eNote.Text = e.Note;
            eDalle.Value = e.Dalle;
            eAlle.Value = e.Alle;

            GrigliaMultiSelect_Minore.IDSvolgimentoLaboratorio = e.ID;
        }

        protected override void PostSalva(DB.DataWrapper.Tabelle.SvolgimentoLaboratorio e)
        {
            base.PostSalva(e);

            GrigliaMultiSelect_Minore.IDSvolgimentoLaboratorio = cGB.ObjectToInt(PrimaryKey, -1);
            GrigliaMultiSelect_Minore.ChiamaCarica();
        }

        protected override void setFormNew()
        {
            var n = System.DateTime.Now;
            eDalle.Value = new System.DateTime(n.Year, n.Month, n.Day, 08, 00, 00);
            eAlle.Value = new System.DateTime(n.Year, n.Month, n.Day, 19, 00, 00);        
            
            tpPartecipanti.Enabled = false;
        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eDalle.Value > eAlle.Value)
                z.Add("La data di inizio non può essere maggiore della data di fine");

            return z;
        }

        protected override DB.DataWrapper.Tabelle.SvolgimentoLaboratorio getForm()
        {
            return new DB.DataWrapper.Tabelle.SvolgimentoLaboratorio()
            {
                ID = cGB.ObjectToInt(PrimaryKey, -1),
                IDLaboratorio = IDLaboratorio_,
                Note = eNote.Text,
                Dalle = eDalle.Value,
                Alle = eAlle.Value
            };
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.SvolgimentoLaboratorio entita)
        {
            return null;
        }
#endif

        internal Dettaglio(int IDLaboratorio__) : this()
        {
            IDLaboratorio_ = IDLaboratorio__;            
        }

        internal Dettaglio()
        {            
            InitializeComponent();
            PossoEssereFullScreen = true;

            GrigliaMultiSelect_Minore.RicercaVisibile = false;
            //GrigliaMultiSelect_Minore = new Minore.MultiSelectGrid();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.GrigliaMultiSelect_Minore = new PresenzeSvolgimentoLaboratorio.MultiSelectGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDati = new System.Windows.Forms.TabPage();
            this.eNote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eAlle = new System.Windows.Forms.DateTimePicker();
            this.eDalle = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpPartecipanti = new System.Windows.Forms.TabPage();
            this.ilIcone = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tpDati.SuspendLayout();
            this.tpPartecipanti.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpDati);
            this.tabControl1.Controls.Add(this.tpPartecipanti);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.ilIcone;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 437);
            this.tabControl1.TabIndex = 2;
            // 
            // tpDati
            // 
            this.tpDati.Controls.Add(this.eNote);
            this.tpDati.Controls.Add(this.label1);
            this.tpDati.Controls.Add(this.eAlle);
            this.tpDati.Controls.Add(this.eDalle);
            this.tpDati.Controls.Add(this.label3);
            this.tpDati.Controls.Add(this.label2);
            this.tpDati.ImageIndex = 0;
            this.tpDati.Location = new System.Drawing.Point(4, 23);
            this.tpDati.Name = "tpDati";
            this.tpDati.Padding = new System.Windows.Forms.Padding(3);
            this.tpDati.Size = new System.Drawing.Size(776, 410);
            this.tpDati.TabIndex = 0;
            this.tpDati.Text = "Dati";
            this.tpDati.UseVisualStyleBackColor = true;
            // 
            // eNote
            // 
            this.eNote.Location = new System.Drawing.Point(67, 60);
            this.eNote.MaxLength = 5000;
            this.eNote.Multiline = true;
            this.eNote.Name = "eNote";
            this.eNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eNote.Size = new System.Drawing.Size(701, 342);
            this.eNote.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Note";
            // 
            // eAlle
            // 
            this.eAlle.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eAlle.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eAlle.Location = new System.Drawing.Point(67, 34);
            this.eAlle.Name = "eAlle";
            this.eAlle.Size = new System.Drawing.Size(138, 20);
            this.eAlle.TabIndex = 1;
            // 
            // eDalle
            // 
            this.eDalle.CustomFormat = "dd/MM/yyyy HH:mm";
            this.eDalle.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eDalle.Location = new System.Drawing.Point(67, 8);
            this.eDalle.Name = "eDalle";
            this.eDalle.Size = new System.Drawing.Size(138, 20);
            this.eDalle.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Fine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Inizio";
            // 
            // tpPartecipanti
            // 
            this.tpPartecipanti.Controls.Add(this.GrigliaMultiSelect_Minore);
            this.tpPartecipanti.ImageIndex = 1;
            this.tpPartecipanti.Location = new System.Drawing.Point(4, 23);
            this.tpPartecipanti.Name = "tpPartecipanti";
            this.tpPartecipanti.Padding = new System.Windows.Forms.Padding(3);
            this.tpPartecipanti.Size = new System.Drawing.Size(616, 392);
            this.tpPartecipanti.TabIndex = 1;
            this.tpPartecipanti.Text = "Partecipanti";
            this.tpPartecipanti.UseVisualStyleBackColor = true;
            // 
            // GrigliaMultiSelect_Minore
            // 
            this.GrigliaMultiSelect_Minore.Dock = System.Windows.Forms.DockStyle.Fill;            
            this.GrigliaMultiSelect_Minore.Name = "GrigliaMultiSelect_Minore";            
            this.GrigliaMultiSelect_Minore.TabIndex = 0;
            // 
            // ilIcone
            // 
            this.ilIcone.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcone.ImageStream")));
            this.ilIcone.TransparentColor = System.Drawing.Color.Transparent;
            this.ilIcone.Images.SetKeyName(0, "to_do_list_checked_all.png");
            this.ilIcone.Images.SetKeyName(1, "users_5.png");
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Dettaglio";
            this.Text = "Dettaglio laboratorio svolto";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tpDati.ResumeLayout(false);
            this.tpDati.PerformLayout();
            this.tpPartecipanti.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}