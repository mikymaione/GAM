/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace GAMSharp.DB.DataWrapper
{
    sealed class cAggiornamenti
    {

        internal int EseguiUpdate()
        {
            int i = 0;
            string z = DB.cDB.LeggiQuery("Aggiornamenti");
            string[] q = z.Split(new char[] { ';' });

            if (q != null)
                if (q.Length > 0)
                    for (int b = 0; b < q.Length; b++)
                    {
                        var r = DB.cDB.EseguiSQLNoQuery(q[b]);

                        if (!r.Errore)
                            i += r.Risultato;
                    }

            return i;
        }


    }
}