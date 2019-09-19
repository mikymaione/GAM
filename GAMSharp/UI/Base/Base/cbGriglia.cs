/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Windows.Forms;

namespace GAMSharp.UI.Base.Base
{
    public class cbGriglia : UserControl
    {

        public event OkClickEventHandler OkClick;
        public delegate void OkClickEventHandler();
        public event CercaClickEventHandler CercaClick;
        public delegate void CercaClickEventHandler();
        public event ModificaClickEventHandler ModificaClick;
        public delegate void ModificaClickEventHandler();
        public event NuovoClickEventHandler NuovoClick;
        public delegate void NuovoClickEventHandler();
        public event SalvaClickEventHandler SalvaClick;
        public delegate void SalvaClickEventHandler();
        public event EliminaClickEventHandler EliminaClick;
        public delegate void EliminaClickEventHandler();
        public event GrigliaDoppioClickEventHandler GrigliaDoppioClick;
        public delegate void GrigliaDoppioClickEventHandler();
        public event DeSelezionaTuttiClickEventHandler DeSelezionaTuttiClick;
        public delegate void DeSelezionaTuttiClickEventHandler();
        public event SelezionaTuttiClickEventHandler SelezionaTuttiClick;
        public delegate void SelezionaTuttiClickEventHandler();

        protected bool BloccaRicerca = true;
        public bool DoubleClickAbilitato = true;


        protected void DoCerca()
        {
            if (CercaClick != null)
                CercaClick();
        }

        protected void bCerca_Click(object sender, EventArgs e)
        {
            DoCerca();
        }

        protected void bSelezionaTutti_Click(object sender, EventArgs e)
        {
            if (SelezionaTuttiClick != null)
                SelezionaTuttiClick();
        }

        protected void bDeselezionaTutti_Click(object sender, EventArgs e)
        {
            if (DeSelezionaTuttiClick != null)
                DeSelezionaTuttiClick();
        }

        protected void CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DoubleClickAbilitato)
                if (GrigliaDoppioClick != null)
                    GrigliaDoppioClick();
        }

        protected void bSalva_Click(object sender, EventArgs e)
        {
            if (SalvaClick != null)
                SalvaClick();
        }

        protected void bNuovo_Click(object sender, EventArgs e)
        {
            if (NuovoClick != null)
                NuovoClick();
        }

        protected void bModifica_Click(object sender, EventArgs e)
        {
            if (ModificaClick != null)
                ModificaClick();
        }

        protected void bElimina_Click(object sender, EventArgs e)
        {
            if (EliminaClick != null)
                EliminaClick();
        }

        protected void bOk_Click(object sender, EventArgs e)
        {
            if (OkClick != null)
                OkClick();
        }

        protected void eFirstXRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!BloccaRicerca)
                CercaClick();
        }

        internal DataGridViewColumn NewCol(string ColName)
        {
            return new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true,
                Name = ColName,
                DataPropertyName = ColName,
                HeaderText = ColName
            };
        }

        internal DataGridViewColumn NewCol(string ColName, int lunghezza)
        {
            return new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                ReadOnly = true,
                Name = ColName,
                DataPropertyName = ColName,
                HeaderText = ColName,
                Width = lunghezza
            };
        }

        internal DataGridViewColumn NewCol(string ColName, string Titolo, int lunghezza, bool ReadOnly = true)
        {
            return new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                ReadOnly = ReadOnly,
                Name = ColName,
                DataPropertyName = ColName,
                HeaderText = Titolo,
                Width = lunghezza
            };
        }

        internal DataGridViewColumn NewCol(string ColName, string Titolo, bool ReadOnly = true)
        {
            return new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = ReadOnly,
                Name = ColName,
                DataPropertyName = ColName,
                HeaderText = Titolo
            };
        }

        internal DataGridViewCheckBoxColumn NewCol_CheckBox(string ColName, int lunghezza, bool ReadOnly = true)
        {
            return new DataGridViewCheckBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                ReadOnly = ReadOnly,
                Name = ColName,
                DataPropertyName = ColName,
                HeaderText = ColName,
                Width = lunghezza
            };
        }

        internal DataGridViewCheckBoxColumn NewCol_CheckBox(string ColName, string Titolo, int lunghezza)
        {
            return new DataGridViewCheckBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                ReadOnly = true,
                Name = ColName,
                DataPropertyName = ColName,
                HeaderText = Titolo,
                Width = lunghezza
            };
        }


    }
}