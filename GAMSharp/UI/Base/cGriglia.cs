/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Windows.Forms;

namespace GAMSharp.UI.Base
{
    public partial class cGriglia : Base.cbGriglia
    {

        public void AddButton(ToolStripButton b)
        {
            this.bindingNavigator1.Items.Add(b);
        }

        public void AddButton(ToolStripButton b, int position)
        {
            this.bindingNavigator1.Items.Insert(position, b);
        }

        public void Add(Control c)
        {
            gbRicerca.Controls.Add(c);
        }

        internal bool AbilitaPulsanteOK
        {
            get
            {
                return bOk.Enabled;
            }
            set
            {
                bOk.Enabled = value;
            }
        }

        internal bool AbilitaPulsantiNewModifica
        {
            set
            {
                bNuovo.Enabled = value;
                bModifica.Enabled = value;
            }
        }

        internal bool RicercaVisibile
        {
            get
            {
                return gbRicerca.Visible;
            }
            set
            {
                gbRicerca.Visible = value;
            }
        }

        public cGriglia()
        {
            InitializeComponent();

            eFirstXRows.SelectedIndex = 0;
            dataGridView1.AutoGenerateColumns = false;

            bCerca.Left = gbRicerca.Width - bCerca.Width - 10;
            bCerca.Top = gbRicerca.Height - bCerca.Height - 10;
            bAzzera.Top = bCerca.Top;
            bAzzera.Left = bCerca.Left - 81;

            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellDoubleClick);
            this.bNuovo.Click += new System.EventHandler(this.bNuovo_Click);
            this.bModifica.Click += new System.EventHandler(this.bModifica_Click);
            this.bElimina.Click += new System.EventHandler(this.bElimina_Click);
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            this.eFirstXRows.SelectedIndexChanged += new System.EventHandler(this.eFirstXRows_SelectedIndexChanged);
            this.bAzzera.Click += new System.EventHandler(this.bAzzera_Click);
            this.bCerca.Click += new System.EventHandler(this.bCerca_Click);

            BloccaRicerca = false;
        }

        internal void Carica(System.Data.DataTable dt)
        {
            bindingSource1.DataSource = dt;
        }

        internal object SelectedRecord
        {
            get
            {
                if (dataGridView1.SelectedRows.Count > 0)
                    return dataGridView1.SelectedRows[0].Cells[0].Value;

                return null;
            }
        }

        internal void AddColonne(DataGridViewColumn[] ccc)
        {
            if (ccc != null && ccc.Length > 0)
                dataGridView1.Columns.AddRange(ccc);
        }

        private void bAzzera_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gbRicerca.Controls.Count; i++)
                if (gbRicerca.Controls[i] is Button)
                    continue;
                else if (gbRicerca.Controls[i] is Label)
                    continue;
                else
                    gbRicerca.Controls[i].Text = "";

            DoCerca();
        }

        private void bRefreshGrid_Click(object sender, EventArgs e)
        {
            DoCerca();
        }


    }
}