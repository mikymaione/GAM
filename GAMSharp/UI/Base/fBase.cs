/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GAMSharp.UI.Base
{
    partial class fBase : Form
    {

        private bool PossoEssereFullScreen_ = false;

        public bool PossoEssereFullScreen
        {
            get
            {
                return PossoEssereFullScreen_;
            }
            set
            {
                PossoEssereFullScreen_ = value;

                if (DB.cMemDB.UtenteConnesso != null)
                    switch (this.Name)
                    {
                        case "fBaseRicerca":
                            if (GB.cGB.EnglishVarCharToBool(DB.cMemDB.UtenteConnesso.FullScreen_Ricerca))
                                this.WindowState = FormWindowState.Maximized;
                            break;

                        case "fBaseDettaglio":
                            if (PossoEssereFullScreen_)
                                if (GB.cGB.EnglishVarCharToBool(DB.cMemDB.UtenteConnesso.FullScreen_Dettaglio))
                                {
                                    this.MaximizeBox = true;
                                    this.FormBorderStyle = FormBorderStyle.Sizable;
                                    this.WindowState = FormWindowState.Maximized;
                                }
                            break;
                    }
            }
        }


        internal fBase()
        {
            InitializeComponent();
        }

        private void fBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        protected ToolStripMenuItem NewButton(string Testo, Image Icona, string ToolTip = "", TextImageRelation TextImageRelation_ = TextImageRelation.ImageBeforeText)
        {
            return new ToolStripMenuItem()
            {
                Text = Testo,
                Image = Icona,
                ToolTipText = ToolTip,
                TextImageRelation = TextImageRelation_
            };
        }

        protected ToolStripMenuItem NewButton(EventHandler click, string Testo, Image Icona, string ToolTip = "", TextImageRelation TextImageRelation_ = TextImageRelation.ImageBeforeText)
        {
            var b = NewButton(Testo, Icona, ToolTip, TextImageRelation_);
            b.Click += click;

            return b;
        }


    }
}