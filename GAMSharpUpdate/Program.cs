﻿/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharpUpdate.GB;
using System;
using System.Reflection;

namespace GAMSharpUpdate
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            var l = new GAMSharp.GB.cLog();

            try
            {
                string r = "Aggiornamento del " + DateTime.Now;
                var m = new MyUpdater();

                if (m.AggiornaQuestoProgramma(false, Assembly.GetExecutingAssembly().GetName().Version))
                    l.Scrivi(r + " effettuato con successo.", System.Diagnostics.EventLogEntryType.Information);
                else
                    l.Scrivi(r + " non effettuato.", System.Diagnostics.EventLogEntryType.Warning);
            }
            catch (Exception ex)
            {
                l.Scrivi("Aggiornamento di GAM#", ex);
            }
        }


    }
}