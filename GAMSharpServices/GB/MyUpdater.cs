/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Windows.Forms;

namespace GAMSharpServices.GB
{
    static class MyUpdater
    {
        private struct VersioneInfo
        {
            internal string Programma;
            internal System.DateTime Versione;
            internal string NomeZip;
        }

        private static VersioneInfo MioV;
        private static string Mio;
        private static string PathFileVersioni = System.IO.Path.Combine(Application.UserAppDataPath, "versioni.txt");

        internal static System.DateTime _Versione;

        private static bool DeZippaEdEsegui(string s)
        {
            bool resu = false;
            string k = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(s), Application.ProductName);
            ICSharpCode.SharpZipLib.Zip.FastZip z = new ICSharpCode.SharpZipLib.Zip.FastZip();

            try
            {
                if (System.IO.Directory.Exists(k))
                    System.IO.Directory.Delete(k, true);
            }
            finally
            {
                try
                {
                    int j = 0;
                    int trov = -1;
                    string nj = null;
                    string[] exex = null;

                    z.ExtractZip(s, k, "");
                    exex = System.IO.Directory.GetFiles(k, "*.exe", System.IO.SearchOption.AllDirectories);

                    for (j = 0; j <= exex.Length - 1; j++)
                    {
                        s = exex[j];
                        nj = s.ToLower();

                        nj = System.IO.Path.GetFileName(nj);

                        if (nj == "setup.exe")
                        {
                            trov = j;
                            break;
                        }
                    }

                    if (trov > -1)
                    {
                        s = exex[trov];

                        System.Diagnostics.Process.Start(s);
                    }
                }
                catch
                {
                    //some error
                }
            }

            return resu;
        }

        private static bool DownloadFileFromInternet(string http_, string path_salvataggio)
        {
            bool ok = false;

            if (System.IO.File.Exists(path_salvataggio))
                try
                {
                    System.IO.File.Delete(path_salvataggio);
                }
                catch
                {
                    //cannot delete
                }

            try
            {
                using (System.Net.WebClient c = new System.Net.WebClient())
                {
                    c.DownloadFile(http_, path_salvataggio);
                    ok = true;
                }
            }
            catch
            {
                //error                
            }

            return ok;
        }

        private static bool AggiornaQuestoProgramma_(bool VerificaSolo, System.DateTime Versione_)
        {
            Mio = Application.ProductName + ".exe";
            _Versione = Versione_;

            try
            {
                DownloadFileFromInternet("http://www.maionemiky.it/internal/programmi/versioni.txt", PathFileVersioni);

                if (ControllaVersione(PathFileVersioni))
                {
                    string MioV_NomeZip = System.IO.Path.Combine(Application.UserAppDataPath, MioV.NomeZip);

                    if (System.IO.File.Exists(PathFileVersioni))
                        try
                        {
                            System.IO.File.Delete(PathFileVersioni);
                        }
                        catch
                        {
                            //cannot delete
                        }

                    try
                    {
                        if (System.IO.File.Exists(MioV_NomeZip))
                            try
                            {
                                System.IO.File.Delete(MioV_NomeZip);
                            }
                            catch
                            {
                                return false;
                            }

                        if (VerificaSolo)
                        {
                            return false;
                        }
                        else
                        {
                            bool bbo = false;
                            DownloadFileFromInternet("http://www.maionemiky.it/internal/programmi/" + MioV.NomeZip, MioV_NomeZip);

                            if (System.IO.File.Exists(MioV_NomeZip))
                                bbo = DeZippaEdEsegui(MioV_NomeZip);

                            return bbo;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private static VersioneInfo LeggiRigaVersione(string s)
        {
            //22=23
            //31=32
            //XXXXXXXXXXXXXXXXXXXXXX0123456789
            //RationesCurare_Six.exe=21/11/07;RCV_Small.zip
            string d = "";
            int i = 0;
            int m = 0;
            VersioneInfo c = default(VersioneInfo);

            i = s.IndexOf("=");
            c.Programma = s.Substring(0, i);

            m = s.IndexOf(";");
            c.NomeZip = s.Substring(m, s.Length - m);
            c.NomeZip = c.NomeZip.Replace(";", "");

            d = s.Substring(i, 9);
            d = d.Replace("=", "");
            d = d.Replace(";", "");

            try
            {
                c.Versione = DateTime.ParseExact(d, "dd/MM/yy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                //cannot convert to date
            }

            return c;
        }

        private static bool ControllaVersione(string p)
        {
            bool ok = false;

            try
            {
                if (System.IO.File.Exists(p))
                {
                    string g = "";
                    VersioneInfo v = default(VersioneInfo);

                    using (System.IO.StreamReader f = new System.IO.StreamReader(p))
                    {
                        while (!(f.Peek() == -1))
                        {
                            g = f.ReadLine();
                            v = LeggiRigaVersione(g);

                            if (v.Programma == Mio)
                                if (v.Versione > _Versione)
                                {
                                    MioV = v;
                                    ok = true;

                                    break;
                                }
                        }

                        f.Close();
                    }
                }
            }
            catch
            {
                //error
            }

            return ok;
        }


    }
}