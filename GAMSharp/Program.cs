/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.IO;
using System.Windows.Forms;

namespace GAMSharp
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new GB.cWindowsTweak().AbilitaAccelleratori();

            GB.MyGB.Carica();
            GB.cSetup.CreateDesktopIcon();
            GB.cSetup.CreateStartMenuEntry();

            if (!"".Equals(GB.MyGB.Opzioni?.ConnectionString ?? ""))
                DB.cDB.ApriConnessione(false, GB.MyGB.Opzioni.ConnectionString, DB.cDB.DataBase.FireBird);

            if (!DB.cDB.ConnessioneEffettuata)
            {
                var file_connessione = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Connessione.txt");

                if (File.Exists(file_connessione))
                    DB.cDB.ApriConnessione(file_connessione, DB.cDB.DataBase.FireBird);
            }

            if (!DB.cDB.ConnessioneEffettuata)
                using (var ScegliServer = new UI.fScegliServer())
                    ScegliServer.ShowDialog();

            var FM_resu = DialogResult.Retry;
            var FL_resu = DialogResult.OK;

            if (DB.cDB.ConnessioneEffettuata)
                while (FM_resu == DialogResult.Retry && FL_resu == DialogResult.OK)
                    using (var login = new UI.fLogin())
                        try
                        {
                            FL_resu = login.ShowDialog();

                            if (FL_resu == DialogResult.OK)
                                using (var main = new UI.fMain())
                                    FM_resu = main.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            FM_resu = DialogResult.Abort;
                            GB.cGB.MsgBox("Un'errore inaspettato è stato incontrato. Vi invitiamo a segnalare il problema nella prossima finestra. Grazie.", MessageBoxIcon.Error);

                            using (var erD = new UI.fSegnalaUnProblema(ex))
                                erD.ShowDialog();
                        }

            DB.cDB.ChiudiConnessione();
            GB.MyGB.Salva();
        }


    }
}