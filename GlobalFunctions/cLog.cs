/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Diagnostics;

namespace GAMSharp.GB
{
    public class cLog
    {
        private bool OK = false;
        private EventLog Log = new EventLog("Application");

        public cLog()
        {
            string cs = "GAM#";

            try
            {
                if (!EventLog.SourceExists(cs))
                    EventLog.CreateEventSource(cs, "Application");

                Log.Source = cs;
                Log.EnableRaisingEvents = true;
                OK = true;
            }
            catch
            {
                //cannot create
            }
        }

        public void Scrivi(string nome_funzione, System.Exception ex)
        {
            string s = "";

            if (nome_funzione.Length > 0)
                s = nome_funzione + ": ";

            Scrivi(s + ex.Message, EventLogEntryType.Error);
        }

        public void Scrivi(System.Exception ex)
        {
            Scrivi("", ex);
        }

        public void Scrivi(string s, EventLogEntryType t)
        {
            if (OK)
                try
                {
                    Log.WriteEntry(s, t);
                }
                catch
                {
                    //cannot write
                }
        }


    }
}