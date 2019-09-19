/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Reflection;

namespace GAMSharp.GB
{
    public static class cGB
    {

        public static bool AggiornamentiDisponibili = false;
        public static bool RestartMe = false;
        public static Random random = new Random(DateTime.Now.Second * DateTime.Now.Millisecond + DateTime.Now.Hour + DateTime.Now.Minute);

        public struct Time
        {
            public int Ora, Minuto;
        }

        public static bool DesignTime
        {
            get
            {
                return (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime);
            }
        }

        public static string CartellaDefaultInstallazione
        {
            get
            {
                //return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Informatici Senza Frontiere\GAM Sharp\");
                return System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            }
        }

        public static string CartellaApplicationData
        {
            get
            {
                string p = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                p = System.IO.Path.Combine(p, @"Informatici Senza Frontiere ONLUS\GAM#\");

                return p;
            }
        }

        public static DateTime MyProductVersion
        {
            get
            {
                int g, m, a;
                var s = System.Windows.Forms.Application.ProductVersion;

                a = Convert.ToInt32(s.Substring(2, 2)) + 2000;
                m = Convert.ToInt32(s.Substring(5, 2));
                g = Convert.ToInt32(s.Substring(8, 2));

                return new DateTime(a, m, g);
            }
        }

        public static string CopyrightHolder
        {
            get
            {
                var attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static bool StringInArray(string s, string[] a)
        {
            if (a != null)
                if (a.Length > 0)
                    for (var i = 0; i < a.Length; i++)
                        if (s.Equals(a[i], StringComparison.OrdinalIgnoreCase))
                            return true;

            return false;
        }

        public static bool String_For_Time_IsValid(string s)
        {
            var b = false;

            try
            {
                var t = new Time();

                t.Ora = Convert.ToInt32(s.Substring(0, 2));
                t.Minuto = Convert.ToInt32(s.Substring(3, 2));

                if (t.Ora >= 0 && t.Ora <= 23)
                    if (t.Minuto >= 0 && t.Minuto <= 59)
                        b = true;
            }
            catch
            {
                //error
            }

            return b;
        }

        public static Time StringToTime(string s)
        {
            var t = new Time();

            try
            {
                t.Ora = Convert.ToInt32(s.Substring(0, 2));
                t.Minuto = Convert.ToInt32(s.Substring(3, 2));
            }
            catch
            {
                //error
            }

            return t;
        }

        public static string TimeToString(DateTime t)
        {
            return TimeToString(new Time()
            {
                Ora = t.Hour,
                Minuto = t.Minute
            });
        }

        public static string TimeToString(int h, int m)
        {
            var t = new Time()
            {
                Ora = h,
                Minuto = m
            };

            return TimeToString(t);
        }

        public static string TimeToString(Time t)
        {
            var h = "";
            var m = "";

            if (t.Ora < 10)
                h = "0";

            h += t.Ora;

            if (t.Minuto < 10)
                m = "0";

            m += t.Minuto;

            return (h + "." + m);
        }

        public static System.Windows.Forms.DialogResult MsgBox(System.Exception ex)
        {
            return MsgBox("Errore: " + ex.Message, System.Windows.Forms.MessageBoxIcon.Error);
        }

        public static System.Windows.Forms.DialogResult MsgBox(string s)
        {
            return MsgBox(s, System.Windows.Forms.MessageBoxIcon.Information);
        }

        public static System.Windows.Forms.DialogResult MsgBox(string s, System.Windows.Forms.MessageBoxIcon ico)
        {
            return MsgBox(s, System.Windows.Forms.MessageBoxButtons.OK, ico);
        }

        public static System.Windows.Forms.DialogResult MsgBox(string s, System.Windows.Forms.MessageBoxButtons but, System.Windows.Forms.MessageBoxIcon ico, bool TopMost = false)
        {
            return System.Windows.Forms.MessageBox.Show(new System.Windows.Forms.Form() { TopMost = true }, s, "GAM#", but, ico);
        }

        public static bool MsgBoxQuestion(string s)
        {
            return MsgBox(s, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
        }

        public static string DateTimeToDate_String(object o)
        {
            return ObjectToDateTime(o, new DateTime(1600, 1, 1)).ToShortDateString();
        }

        public static DateTime ObjectToDateTime(object o, DateTime defa)
        {
            var d = defa;

            try
            {
                if (o is DateTime)
                    d = (DateTime)o;
                else if (o is string)
                    d = DateTime.ParseExact(o.ToString().Substring(0, 19), "yyyy-MM-dd hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                //empty                
            }

            return d;
        }

        public static DateTime ObjectToDateTime(object o)
        {
            return ObjectToDateTime(o, DateTime.MinValue);
        }

        public static char ObjectToChar(object o, char Default_)
        {
            var c = Default_;

            try
            {
                if (o is string)
                    c = ((string)o)[0];
                else
                    c = (char)o;
            }
            catch
            {
                //errore
            }

            return c;
        }

        public static string ObjectToString(object o, string default_ = "")
        {
            var r = default_;

            try
            {
                r = o.ToString();
            }
            catch
            {
                //errore
            }

            if (r == null)
                r = default_;

            if (r.Equals(""))
                r = default_;

            return r;
        }

        public static byte[] ObjectToBytesMemConvert(object obj)
        {
            if (obj == null)
                return null;

            if (obj is short)
                return BitConverter.GetBytes((short)obj);
            else if (obj is int)
                return BitConverter.GetBytes((int)obj);
            else if (obj is long)
                return BitConverter.GetBytes((long)obj);
            else if (obj is float)
                return BitConverter.GetBytes((float)obj);
            else if (obj is double)
                return BitConverter.GetBytes((double)obj);
            else if (obj is bool)
                return BitConverter.GetBytes((bool)obj);
            else if (obj is char)
                return BitConverter.GetBytes((char)obj);

            byte[] r = null;
            var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            using (var ms = new System.IO.MemoryStream())
                try
                {
                    bf.Serialize(ms, obj);
                    r = ms.ToArray();
                }
                catch
                {
                    //error
                }

            return r;
        }

        public static object BytesToObjectMemConvert(byte[] arrBytes)
        {
            object obj = null;
            var binForm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            using (var memStream = new System.IO.MemoryStream())
                try
                {
                    memStream.Write(arrBytes, 0, arrBytes.Length);
                    memStream.Seek(0, System.IO.SeekOrigin.Begin);

                    obj = binForm.Deserialize(memStream);
                }
                catch
                {
                    //errore
                }

            return obj;
        }

        public static string BoolToSiNo(object o)
        {
            return (o.Equals(true) ? "sì" : "no");
        }

        public static string BoolToItalianString(bool o)
        {
            return (o ? "vero" : "falso");
        }

        public static string BoolToEnglishString(bool o)
        {
            return (o ? "true" : "false");
        }

        public static char BoolToEnglishChar(bool o)
        {
            return (o ? 'T' : 'F');
        }

        public static bool EnglishVarCharToBool(char o)
        {
            if (o.Equals('T') || o.Equals('t'))
                return true;

            return false;
        }

        public static bool EnglishVarCharToBool(string o)
        {
            return EnglishVarCharToBool(o[0]);
        }

        public static bool EnglishVarCharToBool(object o)
        {
            return EnglishVarCharToBool(ObjectToChar(o, 'F'));
        }

        public static byte[] ObjectToBytes(object o)
        {
            if (o != null)
                if (o is byte[])
                    return o as byte[];

            return null;
        }

        public static bool ObjectToBoolean(object o, bool Default_ = false)
        {
            var d = Default_;

            try
            {
                d = (bool)o;
            }
            catch
            {
                //erorr
            }

            return d;
        }

        public static decimal ObjectToDouble(object o, decimal Default_ = 0)
        {
            var d = Default_;

            try
            {
                d = (decimal)o;
            }
            catch
            {
                //erorr
            }

            return d;
        }

        public static int? ObjectToIntNullable(object o, int min_value_accepted)
        {
            int? i = null;

            try
            {
                i = (int)o;

                if (i < min_value_accepted)
                    return null;
            }
            catch
            {
                //error
            }

            return i;
        }

        public static int ObjectToInt(object o, int default_)
        {
            var i = default_;

            try
            {
                i = Convert.ToInt32(o);
            }
            catch
            {
                //error
            }

            return i;
        }

        public static string QQ(string s, bool active)
        {
            if (active)
                return "%" + s + "%";
            else
                return "%%";
        }

        public static string QQ(string s)
        {
            return QQ(s, true);
        }

        public static string HolidayName(DateTime data)
        {
            var z = "";
            var y = data.Year;
            var m = data.Month;
            var d = data.Day;

            if (m == 1 & d == 1)
                z = "Capodanno";
            if (m == 1 & d == 6)
                z = "Befana";
            if (m == 4 & d == 25)
                z = "Festa della liberazione";
            if (m == 5 & d == 1)
                z = "Festa del lavoro";
            if (m == 6 & d == 2)
                z = "Nascita della Repubblica Italiana";
            if (m == 8 & d == 15)
                z = "Ferragosto";
            if (m == 11 & d == 1)
                z = "Ognissanti";
            if (m == 12 & d == 8)
                z = "Immacolata";
            if (m == 12 & d == 25)
                z = "Natale";
            if (m == 12 & d == 26)
                z = "Santo Stefano";
            if (data.Equals(EasterDate(y).AddDays(1)))
                z = "Pasqua";

            return z;
        }

        public static bool IsHoliday(DateTime data)
        {
            var y = data.Year;
            var m = data.Month;
            var d = data.Day;

            if (
                m == 1 & d == 1 |
                m == 1 & d == 6 |
                m == 4 & d == 25 |
                m == 5 & d == 1 |
                m == 6 & d == 2 |
                m == 8 & d == 15 |
                m == 11 & d == 1 |
                m == 12 & d == 8 |
                m == 12 & d == 25 |
                m == 12 & d == 26 |
                data.Equals(EasterDate(y).AddDays(1)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static DateTime EasterDate(int year = 0)
        {
            var dt = DateTime.Now;
            var G = 0;
            var C = 0;
            var H = 0;
            var i = 0;
            var j = 0;
            var L = 0;
            var m = 0;
            var d = 0;

            if (year == 0)
                year = DateTime.Today.Year;

            if (dt.Year != year)
            {
                G = year % 19;
                C = year / 100;
                H = ((C - (C / 4) - ((8 * C + 13) / 25) + (19 * G) + 15) % 30);
                i = H - ((H / 28) * (1 - (H / 28) * (29 / (H + 1)) * ((21 - G) / 11)));
                j = ((year + (year / 4) + i + 2 - C + (C / 4)) % 7);
                L = i - j;

                m = 3 + ((L + 40) / 44);
                d = L + 28 - (31 * (m / 4));
                dt = new DateTime(year, m, d);
            }

            return dt;
        }

        public static void StartProgram(string programma, string parametri = "")
        {
            try
            {
                System.Diagnostics.Process.Start(programma, parametri);
            }
            catch
            {
                //cannot open
            }
        }

        public static void StartExplorer(string percorso)
        {
            StartProgram("explorer.exe", percorso);
        }

        public static string DateToSQLite(DateTime d)
        {
            //yyyy-MM-dd HH:mm:ss.fff
            var h = "";

            h += d.Year + "-" + (d.Month < 10 ? "0" : "") + d.Month + "-" + (d.Day < 10 ? "0" : "") + d.Day + " ";
            h += (d.Hour < 10 ? "0" : "") + d.Hour + ":" + (d.Minute < 10 ? "0" : "") + d.Minute + ":" + (d.Second < 10 ? "0" : "") + d.Second + ".000";

            return h;
        }

        public static Object DateToDBDateNullable(DateTime d)
        {
            if (d.Date > DateTime.MinValue)
                return d;
            else
                return DBNull.Value;
        }

        public static System.Decimal DoubleToMoney(double a)
        {
            return DoubleToMoney(Convert.ToString(a));
        }

        public static System.Decimal DoubleToMoney(System.Decimal a)
        {
            return DoubleToMoney(Convert.ToString(a));
        }

        public static string DoubleToMoneyString(System.Decimal a)
        {
            return DoubleToMoney(a).ToString();
        }

        public static string DoubleToMoneyStringValuta(System.Decimal a)
        {
            return DoubleToMoney(a).ToString("C");
        }

        public static string DoubleToMoneyStringValuta(double a)
        {
            return DoubleToMoney(a).ToString("C");
        }

        public static System.Decimal DoubleToMoney(string sa)
        {
            var punta = sa.IndexOf(".");
            var virga = sa.IndexOf(",");
            var max_v = sa.Length - virga;
            var max_p = sa.Length - punta;

            if (max_v > 3)
                max_v = 3;

            if (max_p > 3)
                max_p = 3;

            if (punta > -1)
                sa = sa.Substring(0, punta + max_p);
            if (virga > -1)
                sa = sa.Substring(0, virga + max_v);

            return ObjectToDouble(sa);
        }

        public static DateTime DateToOnlyDate(DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day);
        }

        public static string Default(object s, string default_)
        {
            var z = default_;

            try
            {
                z = Default(Convert.ToString(s), default_);
            }
            catch
            {
                //error
            }

            return z;
        }

        public static string Default(string s, string default_)
        {
            var z = default_;

            if (s != null)
                if (s != "")
                    z = s;

            return z;
        }

        public static string EmptyStringToNull(object s)
        {
            if (s == null)
                return null;
            else if (s != null && s.Equals(""))
                return null;
            else
                return NullStringToEmpty(s);
        }

        public static string NullStringToEmpty(string s)
        {
            if (s == null)
                s = "";

            return s;
        }

        public static string NullStringToEmpty(object s)
        {
            return NullStringToEmpty(s.ToString());
        }

        public static void SetSelectedComboItem_ID(ref System.Windows.Forms.ComboBox c, object ID_ToSelect)
        {
            try
            {
                for (var i = 0; i < c.Items.Count; i++)
                    if (((cComboItem)c.Items[i]).Value.Equals(ID_ToSelect))
                    {
                        c.SelectedIndex = i;
                        break;
                    }
            }
            catch
            {
                //null
            }
        }

        public static object GetSelectedComboItem_ID(System.Windows.Forms.ComboBox c)
        {
            try
            {
                return ((cComboItem)c.SelectedItem).Value;
            }
            catch
            {
                //null
            }

            return null;
        }

        public static string GetSelectedComboItem_Valore(System.Windows.Forms.ComboBox c)
        {
            var z = "";

            try
            {
                z = ((cComboItem)c.SelectedItem).Text;
            }
            catch
            {
                //null
            }

            return z;
        }

        public static string Like(string z, int LimitToNChar)
        {
            if (z == null)
                z = "";

            if (z.Length == LimitToNChar)
                return z;
            else if (z.Length == LimitToNChar - 1)
                return LikeR(z);
            else
                return Like(z);
        }

        public static string Like(string z)
        {
            return "%" + z + "%";
        }

        public static string LikeL(string z)
        {
            return "%" + z;
        }

        public static string LikeR(string z)
        {
            return z + "%";
        }

        public static bool DateSonoUgualiPer_YYYYMMDD(DateTime a, DateTime b)
        {
            var r = false;

            if (a.Year == b.Year)
                if (a.Month == b.Month)
                    if (a.Day == b.Day)
                        r = true;

            return r;
        }

        private static void EliminaChiaveRegistro(string s)
        {
            try
            {
                Microsoft.Win32.Registry.LocalMachine.DeleteSubKey(s);
            }
            catch
            {
                //errore cancellazione
            }
        }

        public static object ValueToDBNULL(bool PutNull, object ElseValue)
        {
            if (PutNull)
                return DBNull.Value;
            else
                return ElseValue;
        }

        public static bool CheckCodiceFiscale(string CodiceFiscale)
        {
            try
            {
                return CheckCodiceFiscale_(CodiceFiscale);
            }
            catch
            {
                return false;
            }
        }

        private static bool CheckCodiceFiscale_(string CodiceFiscale)
        {
            var result = false;
            const int caratteri = 16;

            if (CodiceFiscale == null)
                return result;

            if (CodiceFiscale.Length != caratteri)
                return result;

            // stringa per controllo e calcolo omocodia
            const string omocodici = "LMNPQRSTUV";
            // per il calcolo del check digit e la conversione in numero
            const string listaControllo = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int[] listaPari = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
            int[] listaDispari = { 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23 };

            CodiceFiscale = CodiceFiscale.ToUpper();
            var cCodice = CodiceFiscale.ToCharArray();

            // check della correttezza formale del codice fiscale
            // elimino dalla stringa gli eventuali caratteri utilizzati negli
            // spazi riservati ai 7 che sono diventati carattere in caso di omocodia
            for (var k = 6; k < 15; k++)
            {
                if ((k == 8) || (k == 11))
                    continue;

                var x = (omocodici.IndexOf(cCodice[k]));

                if (x != -1)
                    cCodice[k] = x.ToString().ToCharArray()[0];
            }

            var somma = 0;
            cCodice = CodiceFiscale.ToCharArray();

            for (var i = 0; i < 15; i++)
            {
                var c = cCodice[i];
                var x = "0123456789".IndexOf(c);

                if (x != -1)
                    c = listaControllo.Substring(x, 1).ToCharArray()[0];

                x = listaControllo.IndexOf(c);

                // i modulo 2 = 0 è dispari perchè iniziamo da 0
                if ((i % 2) == 0)
                    x = listaDispari[x];
                else
                    x = listaPari[x];
                somma += x;
            }

            result = (listaControllo.Substring(somma % 26, 1) == CodiceFiscale.Substring(15, 1));

            return result;
        }

        public static void CreaCartellaSeNonEsiste_ThrowException(string path)
        {
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
        }

        public static Exception CreaCartellaSeNonEsiste(string path)
        {
            try
            {
                CreaCartellaSeNonEsiste_ThrowException(path);
            }
            catch (Exception ex)
            {
                //error       
                return ex;
            }

            return null;
        }


    }
}