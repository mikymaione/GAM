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
using GAMSharp.GB;

namespace GAMSharp.UI.Controlli
{
    public sealed class ucCFTextBox : TextBox
    {

        public ucCFTextBox()
        {
            CharacterCasing = CharacterCasing.Upper;
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Controlla();
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Controlla();
        }

        private void Controlla()
        {
            BackColor = (cGB.CheckCodiceFiscale(Text) ? Color.FromKnownColor(KnownColor.Window) : Color.Red);
        }


    }
}