/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2016 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.GB;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GAMSharp.UI
{
    sealed class Rubrica : Base.fBase
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bRicerca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Controlli.ucCaseTypeTextBox sNome;
        private Controlli.ddlComune sLuogoDiNascita;
        private System.Windows.Forms.TextBox sCF;
        private Controlli.ucCaseTypeTextBox sCognome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView ePersone;

        private GroupBox groupBox2;
        private Panel panel2;
        private Indirizzi.cRicerca Griglia_Indirizzi;
        private Splitter splitter2;
        private Splitter splitter1;
        private Panel panel4;
        private Recapiti.cRicerca Griglia_Recapiti;
        private Panel panel3;
        private TextBox eCF;
        private TextBox eLuogoDiNascita;
        private TextBox eNome;
        private TextBox eCognome;
        private Label label4;
        private Label label1;
        private Label label5;
        private DateTimePicker eDataDiNascita;
        private Label label3;
        private Label label2;

        DB.DataWrapper.cRubrica cRubrica = new DB.DataWrapper.cRubrica();
        private Button bDettaglio;
        private Button bAzzera;
        DB.cRisultatoSQL<List<DB.DataWrapper.Viste.Rubrica>> ElementiRubrica;


        private void bAzzera_Click(object sender, System.EventArgs e)
        {
            sCF.Text = "";
            sCognome.Text = "";
            sNome.Text = "";
            sLuogoDiNascita.Text = "";

            Ricerca();
        }

        private void bDettaglio_Click(object sender, System.EventArgs e)
        {
            if (ePersone.SelectedItems.Count > 0)
            {
                var key = ePersone.SelectedItems[0].Tag;

                if (key is int)
                    using (var d = new Lead.Dettaglio())
                        d.ShowDialog(key);
                else if (key is string)
                    using (var d = new Persona.Dettaglio())
                        d.ShowDialog(key);
            }
        }

        private void bRicerca_Click(object sender, System.EventArgs e)
        {
            Ricerca();
        }

        private void ePersone_SelectedIndexChanged(object sender, System.EventArgs x)
        {
            if (ePersone.SelectedItems.Count > 0)
            {
                var entita = "";
                var key = ePersone.SelectedItems[0].Tag;

                if (ElementiRubrica.Errore)
                    cGB.MsgBox(ElementiRubrica.Eccezione);
                else if (ElementiRubrica.Risultato.Count > 0)
                    if (key is int)
                    {
                        entita = "Lead";

                        foreach (var per in ElementiRubrica.Risultato)
                            if (per.Lead != null && per.Lead.ID.Equals(key))
                            {
                                var e = per.Lead;

                                eCF.Text = "";
                                eCognome.Text = e.Cognome;
                                eNome.Text = e.Nome;
                                eLuogoDiNascita.Text = e.LuogoDiNascita;
                                eDataDiNascita.Value = e.DataDiNascita;

                                break;
                            }
                    }
                    else if (key is string)
                    {
                        entita = "Persona";

                        foreach (var per in ElementiRubrica.Risultato)
                            if (per.Persona != null && per.Persona.CF.Equals(key))
                            {
                                var e = per.Persona;

                                eCF.Text = e.CF;
                                eCognome.Text = e.Cognome;
                                eNome.Text = e.Nome;
                                eLuogoDiNascita.Text = e.LuogoDiNascita;
                                eDataDiNascita.Value = e.DataDiNascita;

                                break;
                            }
                    }

                LoadDataForElement(entita, key);
            }
        }

        private void Ricerca()
        {
            ePersone.Items.Clear();

            eCF.Text = "";
            eCognome.Text = "";
            eNome.Text = "";
            eLuogoDiNascita.Text = "";
            eDataDiNascita.Value = System.DateTime.Now;

            LoadDataForElement("", -1);

            ElementiRubrica = cRubrica.Ricerca(new DB.DataWrapper.Viste.Rubrica()
            {
                Persona = new DB.DataWrapper.Tabelle.Persona()
                {
                    CF = cGB.Like(sCF.Text, 16),
                    Cognome = cGB.Like(sCognome.Text),
                    Nome = cGB.Like(sNome.Text),
                    LuogoDiNascita = cGB.Like(sLuogoDiNascita.Text)
                },
                Lead = new DB.DataWrapper.Tabelle.Lead()
                {
                    Cognome = cGB.Like(sCognome.Text),
                    Nome = cGB.Like(sNome.Text),
                    LuogoDiNascita = cGB.Like(sLuogoDiNascita.Text)
                }
            });

            if (ElementiRubrica.Errore)
                cGB.MsgBox(ElementiRubrica.Eccezione);
            else if (ElementiRubrica.Risultato.Count > 0)
            {
                var n = -1;
                var testo = "";
                object key = null;
                var persone = new ListViewItem[ElementiRubrica.Risultato.Count];

                foreach (var rub in ElementiRubrica.Risultato)
                {
                    testo = "";

                    if (rub.Persona != null)
                    {
                        key = rub.Persona.CF;
                        testo = rub.Persona.Cognome + " " + rub.Persona.Nome;
                    }
                    else if (rub.Lead != null)
                    {
                        key = rub.Lead.ID;
                        testo = rub.Lead.Cognome + " " + rub.Lead.Nome;
                    }

                    persone[n += 1] = new ListViewItem()
                    {
                        Text = testo,
                        Tag = key
                    };
                }

                ePersone.Items.AddRange(persone);
            }
        }

        private void LoadDataForElement(string NomeEntità, object PrimaryKey_)
        {
            Griglia_Indirizzi.Entita_Tipo = NomeEntità;
            Griglia_Recapiti.Entita_Tipo = NomeEntità;

            Griglia_Indirizzi.Entita_Key = PrimaryKey_;
            Griglia_Recapiti.Entita_Key = PrimaryKey_;

            Griglia_Indirizzi.RiChiamaCarica();
            Griglia_Recapiti.RiChiamaCarica();
        }

        internal Rubrica()
        {
            InitializeComponent();
            PossoEssereFullScreen = true;

            Griglia_Indirizzi.AvviaAutomaticamenteLaRicerca = false;
            Griglia_Recapiti.AvviaAutomaticamenteLaRicerca = false;

            Griglia_Indirizzi.RicercaVisibile = false;
            Griglia_Recapiti.RicercaVisibile = false;

            Ricerca();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rubrica));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ePersone = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sNome = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.sLuogoDiNascita = new GAMSharp.UI.Controlli.ddlComune();
            this.sCF = new System.Windows.Forms.TextBox();
            this.sCognome = new GAMSharp.UI.Controlli.ucCaseTypeTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bRicerca = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Griglia_Indirizzi = new GAMSharp.UI.Indirizzi.cRicerca();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Griglia_Recapiti = new GAMSharp.UI.Recapiti.cRicerca();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bDettaglio = new System.Windows.Forms.Button();
            this.eCF = new System.Windows.Forms.TextBox();
            this.eLuogoDiNascita = new System.Windows.Forms.TextBox();
            this.eNome = new System.Windows.Forms.TextBox();
            this.eCognome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.eDataDiNascita = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bAzzera = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "user.ico");
            this.imageList1.Images.SetKeyName(1, "house_one.ico");
            this.imageList1.Images.SetKeyName(2, "telephone.ico");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ePersone);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 661);
            this.panel1.TabIndex = 2;
            // 
            // ePersone
            // 
            this.ePersone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ePersone.Location = new System.Drawing.Point(0, 158);
            this.ePersone.MultiSelect = false;
            this.ePersone.Name = "ePersone";
            this.ePersone.Size = new System.Drawing.Size(344, 503);
            this.ePersone.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ePersone.TabIndex = 1;
            this.ePersone.UseCompatibleStateImageBehavior = false;
            this.ePersone.View = System.Windows.Forms.View.List;
            this.ePersone.SelectedIndexChanged += new System.EventHandler(this.ePersone_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bAzzera);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.sNome);
            this.groupBox1.Controls.Add(this.sLuogoDiNascita);
            this.groupBox1.Controls.Add(this.sCF);
            this.groupBox1.Controls.Add(this.sCognome);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.bRicerca);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ricerca";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Luogo di nascita";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nome";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Cognome";
            // 
            // sNome
            // 
            this.sNome.Location = new System.Drawing.Point(117, 72);
            this.sNome.Name = "sNome";
            this.sNome.Size = new System.Drawing.Size(215, 20);
            this.sNome.TabIndex = 2;
            // 
            // sLuogoDiNascita
            // 
            this.sLuogoDiNascita.Location = new System.Drawing.Point(117, 98);
            this.sLuogoDiNascita.Name = "sLuogoDiNascita";
            this.sLuogoDiNascita.Size = new System.Drawing.Size(215, 20);
            this.sLuogoDiNascita.TabIndex = 3;
            // 
            // sCF
            // 
            this.sCF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sCF.Location = new System.Drawing.Point(117, 20);
            this.sCF.MaxLength = 16;
            this.sCF.Name = "sCF";
            this.sCF.Size = new System.Drawing.Size(215, 20);
            this.sCF.TabIndex = 0;
            // 
            // sCognome
            // 
            this.sCognome.Location = new System.Drawing.Point(117, 46);
            this.sCognome.Name = "sCognome";
            this.sCognome.Size = new System.Drawing.Size(215, 20);
            this.sCognome.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "CF";
            // 
            // bRicerca
            // 
            this.bRicerca.Image = global::GAMSharp.Properties.Resources.zoom;
            this.bRicerca.Location = new System.Drawing.Point(260, 124);
            this.bRicerca.Name = "bRicerca";
            this.bRicerca.Size = new System.Drawing.Size(72, 25);
            this.bRicerca.TabIndex = 4;
            this.bRicerca.Text = "Cerca";
            this.bRicerca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bRicerca.UseVisualStyleBackColor = true;
            this.bRicerca.Click += new System.EventHandler(this.bRicerca_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.splitter2);
            this.groupBox2.Controls.Add(this.splitter1);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(344, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(640, 661);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contatto";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Griglia_Indirizzi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 297);
            this.panel2.TabIndex = 0;
            // 
            // Griglia_Indirizzi
            // 
            this.Griglia_Indirizzi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_Indirizzi.Entita_Key = null;
            this.Griglia_Indirizzi.Entita_Tipo = null;
            this.Griglia_Indirizzi.Location = new System.Drawing.Point(0, 0);
            this.Griglia_Indirizzi.Name = "Griglia_Indirizzi";
            this.Griglia_Indirizzi.Size = new System.Drawing.Size(634, 297);
            this.Griglia_Indirizzi.TabIndex = 1;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(3, 158);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(634, 3);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(3, 458);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(634, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Griglia_Recapiti);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 461);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(634, 197);
            this.panel4.TabIndex = 2;
            // 
            // Griglia_Recapiti
            // 
            this.Griglia_Recapiti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Griglia_Recapiti.Entita_Key = null;
            this.Griglia_Recapiti.Entita_Tipo = null;
            this.Griglia_Recapiti.Location = new System.Drawing.Point(0, 0);
            this.Griglia_Recapiti.Name = "Griglia_Recapiti";
            this.Griglia_Recapiti.Size = new System.Drawing.Size(634, 197);
            this.Griglia_Recapiti.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bDettaglio);
            this.panel3.Controls.Add(this.eCF);
            this.panel3.Controls.Add(this.eLuogoDiNascita);
            this.panel3.Controls.Add(this.eNome);
            this.panel3.Controls.Add(this.eCognome);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.eDataDiNascita);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(634, 142);
            this.panel3.TabIndex = 1;
            // 
            // bDettaglio
            // 
            this.bDettaglio.Image = global::GAMSharp.Properties.Resources.application_edit;
            this.bDettaglio.Location = new System.Drawing.Point(516, 107);
            this.bDettaglio.Name = "bDettaglio";
            this.bDettaglio.Size = new System.Drawing.Size(109, 25);
            this.bDettaglio.TabIndex = 73;
            this.bDettaglio.Text = "Vai al dettaglio";
            this.bDettaglio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bDettaglio.UseVisualStyleBackColor = true;
            this.bDettaglio.Click += new System.EventHandler(this.bDettaglio_Click);
            // 
            // eCF
            // 
            this.eCF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.eCF.Location = new System.Drawing.Point(121, 7);
            this.eCF.Name = "eCF";
            this.eCF.ReadOnly = true;
            this.eCF.Size = new System.Drawing.Size(293, 20);
            this.eCF.TabIndex = 63;
            // 
            // eLuogoDiNascita
            // 
            this.eLuogoDiNascita.Location = new System.Drawing.Point(121, 85);
            this.eLuogoDiNascita.Name = "eLuogoDiNascita";
            this.eLuogoDiNascita.ReadOnly = true;
            this.eLuogoDiNascita.Size = new System.Drawing.Size(293, 20);
            this.eLuogoDiNascita.TabIndex = 66;
            // 
            // eNome
            // 
            this.eNome.Location = new System.Drawing.Point(121, 59);
            this.eNome.Name = "eNome";
            this.eNome.ReadOnly = true;
            this.eNome.Size = new System.Drawing.Size(293, 20);
            this.eNome.TabIndex = 65;
            // 
            // eCognome
            // 
            this.eCognome.Location = new System.Drawing.Point(121, 33);
            this.eCognome.Name = "eCognome";
            this.eCognome.ReadOnly = true;
            this.eCognome.Size = new System.Drawing.Size(293, 20);
            this.eCognome.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "CF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Luogo di nascita";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "Data di nascita";
            // 
            // eDataDiNascita
            // 
            this.eDataDiNascita.Enabled = false;
            this.eDataDiNascita.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.eDataDiNascita.Location = new System.Drawing.Point(121, 112);
            this.eDataDiNascita.Name = "eDataDiNascita";
            this.eDataDiNascita.Size = new System.Drawing.Size(110, 20);
            this.eDataDiNascita.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Cognome";
            // 
            // bAzzera
            // 
            this.bAzzera.Image = global::GAMSharp.Properties.Resources.broom;
            this.bAzzera.Location = new System.Drawing.Point(179, 124);
            this.bAzzera.Name = "bAzzera";
            this.bAzzera.Size = new System.Drawing.Size(75, 25);
            this.bAzzera.TabIndex = 5;
            this.bAzzera.Text = "Azzera";
            this.bAzzera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bAzzera.UseVisualStyleBackColor = true;
            this.bAzzera.Click += new System.EventHandler(this.bAzzera_Click);
            // 
            // Rubrica
            // 
            this.AcceptButton = this.bRicerca;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "Rubrica";
            this.Text = "Rubrica";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }


    }
}