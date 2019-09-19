/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DatiComuni;
using GAMSharp.GB;
using System;

namespace GAMSharpDBBK
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            var log = new cLog();

            try
            {
                var D = new Database();
                D = D.Carica();

                if (System.IO.Directory.Exists(D.DBFolder))
                {
                    var dir_backup = System.IO.Path.Combine(D.DBFolder, "BK");

                    cGB.CreaCartellaSeNonEsiste(dir_backup);
                    if (System.IO.Directory.Exists(dir_backup))
                    {
                        var cur_dir_backup = System.IO.Path.Combine(dir_backup, DateTime.Now.ToString("yyyyMMdd"));

                        cGB.CreaCartellaSeNonEsiste(cur_dir_backup);
                        if (System.IO.Directory.Exists(cur_dir_backup))
                        {
                            string t = "";
                            var files = System.IO.Directory.GetFiles(D.DBFolder, "*.FDB");

                            foreach (var f in files)
                                try
                                {
                                    t = System.IO.Path.GetFileName(f);
                                    t = System.IO.Path.Combine(cur_dir_backup, t);

                                    System.IO.File.Copy(f, t, true);

                                    log.Scrivi("Copia del file " + f + " in " + t + " effettuata", System.Diagnostics.EventLogEntryType.Information);
                                }
                                catch (Exception ex)
                                {
                                    log.Scrivi("Copia del file " + f + " in " + t + " non effettuata", ex);
                                }
                        }
                        else
                            log.Scrivi("La cartella " + cur_dir_backup + " non è accessibile", System.Diagnostics.EventLogEntryType.Error);
                    }
                }
                else
                    log.Scrivi("La cartella " + D.DBFolder + " non è accessibile", System.Diagnostics.EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                log.Scrivi("Backup del Database", ex);
            }
        }


    }
}