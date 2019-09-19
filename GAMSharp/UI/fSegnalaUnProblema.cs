/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.GB;
using System;
using System.Windows.Forms;

namespace GAMSharp.UI
{
    sealed partial class fSegnalaUnProblema : Base.fBase
    {
        private Exception errore;

        internal fSegnalaUnProblema()
        {
            InitializeComponent();
            PossoEssereFullScreen = true;
        }

        internal fSegnalaUnProblema(Exception ex) : this()
        {
            errore = ex;
        }

        private void bInvia_Click(object sender, EventArgs z)
        {
            if (cGB.MsgBox("Invio?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                using (var e = new maionemikyWS.EmailSendingSoapClient())
                    cGB.MsgBox(
                        e.MandaMail(
                            "GAM#: Segnalazione errore - " + DB.cMemDB.UtenteConnesso.Email,
                            eProblema.Text + (errore?.Message ?? ""),
                            "mikymaione@hotmail.it"
                        ),
                        MessageBoxIcon.Exclamation
                    );
        }

    }
}