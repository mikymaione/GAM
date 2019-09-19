/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Management;

namespace GAMSharp.GB
{
    public class cShareFolder
    {

        public enum eRisultato : uint
        {
            Success = 0,
            Access_denied = 2,
            Unknown_failure = 8,
            Invalid_name = 9,
            Invalid_level = 10,
            Invalid_parameter = 21,
            Duplicate_share = 22,
            Redirected_path = 23,
            Unknown_device_or_directory = 24,
            Net_name_not_found = 25,
            Other
        }

        public string ShareFolder_ToMsg(string FolderPath, string ShareName, string Description)
        {
            uint r = 26;
            string s = "Errore sconosciuto";

            try
            {
                r = ShareFolder(FolderPath, ShareName, Description);
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }

            if (r == 0)
                s = "Cartella condivisa creata con successo";
            else if (r == 2)
                s = "Accesso negato";
            else if (r == 8)
                s = "Fallimento sconosciuto";
            else if (r == 9)
                s = "Nome non valido";
            else if (r == 10)
                s = "Livello non valido";
            else if (r == 21)
                s = "Parametro non valido";
            else if (r == 22)
                s = "Condivisione già esistente";
            else if (r == 23)
                s = "Percorso reindirizzato";
            else if (r == 24)
                s = "Percorso sconosciuto";
            else if (r == 25)
                s = "Nome network non trovato";

            return s;
        }

        public eRisultato ShareFolder_To_eRisultato(string FolderPath, string ShareName, string Description)
        {
            uint r = 26;

            try
            {
                r = ShareFolder(FolderPath, ShareName, Description);
            }
            catch
            {
                //errore
            }

            return (eRisultato)r;
        }

        public uint ShareFolder(string FolderPath, string ShareName, string Description)
        {
            var managementClass = new ManagementClass("Win32_Share");
            var inParams = managementClass.GetMethodParameters("Create");

            inParams["Description"] = Description;
            inParams["Name"] = ShareName;
            inParams["Path"] = FolderPath;
            inParams["Type"] = 0x0; //Disk Drive

            var outParams = managementClass.InvokeMethod("Create", inParams, null);

            return Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
        }


    }
}