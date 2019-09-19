/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Windows.Forms;

namespace GAMSharpUpdate.GB
{
    sealed class MyUpdater
    {
        private struct VersioneInfo
        {
            internal string Programma;
            internal DateTime Versione;
            internal string NomeZip;
        }

        private VersioneInfo MioV;
        private string Mio;
        private string PathFileVersioni = System.IO.Path.Combine(Application.UserAppDataPath, "versioni.txt");
        private DateTime _Versione;
        private GAMSharp.GB.cLog Log = new GAMSharp.GB.cLog();

        private bool DeZippaEdEsegui(string s)
        {
            var resu = false;
            var k = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(s), Application.ProductName);
            var z = new ICSharpCode.SharpZipLib.Zip.FastZip();

            try
            {
                if (System.IO.Directory.Exists(k))
                    System.IO.Directory.Delete(k, true);
            }
            finally
            {
                try
                {
                    z.ExtractZip(s, k, "");
                    var msi = System.IO.Directory.GetFiles(k, "*.msi");

                    foreach (var m in msi)
                        EseguiMSI(m);

                    resu = true;
                }
                catch (Exception ex)
                {
                    Log.Scrivi("Estrazione file zip " + s, ex);
                }
            }

            return resu;
        }

        private string Q(string s)
        {
            return '"' + s + '"';
        }

        private void EseguiMSI(string s)
        {
            //msiexec /i C:\abc\xyz\Example.msi            
            string w = GAMSharp.GB.cGB.CartellaDefaultInstallazione;
            w = "/quiet /package " + Q(s) + " TARGETDIR=" + Q(w);

            System.Diagnostics.Process.Start("msiexec.exe", w);
        }

        private bool DownloadFileFromInternet(string http_, string path_salvataggio)
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
            catch (Exception ex)
            {
                Log.Scrivi("Download update da " + http_ + " in " + path_salvataggio, ex);
            }

            return ok;
        }

        internal bool AggiornaQuestoProgramma(bool VerificaSolo, System.Version v)
        {
            //Major.Minor.Build.Revision
            //20.15.11.22
            //2015/11/22

            return AggiornaQuestoProgramma(VerificaSolo, new DateTime((v.Major * 100) + v.Minor, v.Build, v.Revision));
        }

        internal bool AggiornaQuestoProgramma(bool VerificaSolo, System.DateTime Versione_)
        {
            Mio = Application.ProductName + ".exe";
            _Versione = Versione_;

            try
            {
                DownloadFileFromInternet("http://www.maionemiky.it/public/programmi/versioni.txt", PathFileVersioni);

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
                            string ext = System.IO.Path.GetExtension(MioV_NomeZip);

                            DownloadFileFromInternet("http://www.maionemiky.it/public/programmi/" + MioV.NomeZip, MioV_NomeZip);

                            if (ext.Equals(".zip", StringComparison.OrdinalIgnoreCase))
                            {
                                if (System.IO.File.Exists(MioV_NomeZip))
                                    bbo = DeZippaEdEsegui(MioV_NomeZip);
                            }
                            else if (ext.Equals(".msi", StringComparison.OrdinalIgnoreCase))
                            {
                                EseguiMSI(MioV_NomeZip);
                                bbo = true;
                            }

                            return bbo;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Scrivi("Aggiornamento programma", ex);
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

        private VersioneInfo LeggiRigaVersione(string s)
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

        private bool ControllaVersione(string p)
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

                            if (v.Programma.Equals(Mio, StringComparison.OrdinalIgnoreCase))
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