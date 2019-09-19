/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.IO;
using System.Windows.Forms;

namespace GAMSharp.Stampe
{
    internal static class ConstStampe
    {

        internal enum eStampa
        {
            SchedaValutazionePercorsoFormativo,
            SchedaIscrizione,
            SchedaPrimoContatto,
            PEI
        }

        internal static string PercorsoStampa(eStampa stampa)
        {
            return Path.GetDirectoryName(Application.ExecutablePath) + @"\Stampe\" + stampa + ".docx";
        }

        internal static string ToString(eStampa s)
        {
            if (s == eStampa.PEI)
                return "PEI";
            else if (s == eStampa.SchedaIscrizione)
                return "Scheda iscrizione";
            else if (s == eStampa.SchedaPrimoContatto)
                return "Scheda primo contatto";
            else if (s == eStampa.SchedaValutazionePercorsoFormativo)
                return "Scheda percorso formativo";

            return "";
        }


    }
}