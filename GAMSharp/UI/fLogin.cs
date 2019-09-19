/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Windows.Forms;
using GAMSharp.GB;
using System.DirectoryServices.AccountManagement;
using System.IO;

namespace GAMSharp.UI
{
    sealed partial class fLogin : Base.fBase
    {

        internal fLogin()
        {
            InitializeComponent();

            try
            {
                var ad = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var cartella = Path.Combine(ad, "InformaticiSenzaFrontiere", "GAM Sharp");
                var file_ = Path.Combine(cartella, "AccountManagement.db");

                if (!File.Exists(file_))
                {
                    var email = UserPrincipal.Current.EmailAddress;

                    if (email == null || email.Equals(""))
                    {
                        if (!Directory.Exists(cartella))
                            Directory.CreateDirectory(cartella);

                        File.WriteAllBytes(file_, new byte[] { 0 });
                    }
                    else
                    {
                        this.eEmail.Text = email;
                    }
                }
            }
            catch
            {
                //non settata
            }
        }

        private void bRecuperaPsw_Click(object sender, EventArgs e)
        {
            var c = new DB.DataWrapper.cUtente();
            var psw = c.RecuperaPsw(eEmail.Text);

            if (psw != null && psw.Length > 0)
            {
                using (var m = new maionemikyWS.EmailSendingSoapClient())
                    m.MandaMail("GAM# - Recupero password", "Hai richiesto di recuperare la password del programma GAM#, la tua password è: " + psw, eEmail.Text);

                cGB.MsgBox("Password inviata all'indirizzo " + eEmail.Text);
            }
            else
                cGB.MsgBox("Credenziali di accesso non corrette!", MessageBoxIcon.Exclamation);
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            var c = new DB.DataWrapper.cUtente();

            if (c.Login(eEmail.Text, ePsw.Text))
            {
                DB.cMemDB.UtenteConnesso = c.Carica(eEmail.Text, ePsw.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
                cGB.MsgBox("Credenziali di accesso non corrette!", MessageBoxIcon.Exclamation);
        }


    }
}