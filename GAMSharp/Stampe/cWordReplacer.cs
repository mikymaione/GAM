/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2016 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;

namespace GAMSharp.Stampe
{
    internal class cWordReplacer
    {

        internal void StampaRimpiazzaDocx(string Entita, object chiave, ConstStampe.eStampa documento)
        {
            DB.DataWrapper.Tabelle.Base.BaseDBObject vista = null;

            if (documento == ConstStampe.eStampa.SchedaPrimoContatto || documento == ConstStampe.eStampa.SchedaIscrizione)
            {
                var n = new DB.DataWrapper.cNumerazioni();
                var p = n.Carica("TEN");
                var c = p.Risultato;

                if (documento == ConstStampe.eStampa.SchedaPrimoContatto)
                    c.SchedaPrimoContatto += 1;

                if (documento == ConstStampe.eStampa.SchedaIscrizione)
                    c.SchedaIscrizione += 1;

                n.Modifica(c, "CodiceCentro");
            }

            if (documento == ConstStampe.eStampa.SchedaPrimoContatto)
            {
                var spc = new DB.DataWrapper.cSchedaPrimoContatto();
                var ricerca = spc.Carica(chiave);

                if (ricerca.Errore)
                    GB.cGB.MsgBox(ricerca.Eccezione);
                else
                    vista = ricerca.Risultato;
            }
            else if (documento == ConstStampe.eStampa.SchedaIscrizione)
            {
                var spc = new DB.DataWrapper.cSchedaIscrizione();
                var ricerca = spc.Carica(chiave);

                if (ricerca.Errore)
                    GB.cGB.MsgBox(ricerca.Eccezione);
                else
                    vista = ricerca.Risultato;
            }
            else if (documento == ConstStampe.eStampa.SchedaValutazionePercorsoFormativo)
            {
                var spc = new DB.DataWrapper.cSchedaIscrizione();
                var ricerca = spc.Carica(chiave);

                if (ricerca.Errore)
                    GB.cGB.MsgBox(ricerca.Eccezione);
                else
                    vista = ricerca.Risultato;
            }
            else if (documento == ConstStampe.eStampa.PEI)
            {
                var spc = new DB.DataWrapper.cSchedaIscrizione();
                var ricerca = spc.Carica(chiave);

                if (ricerca.Errore)
                    GB.cGB.MsgBox(ricerca.Eccezione);
                else
                    vista = ricerca.Risultato;
            }

            if (vista != null)
            {
                var file = StampaRimpiazzaDocx_p2(Entita, chiave, documento, vista);

                if (file != null && !file.Equals(""))
                {
                    var i = new DB.DataWrapper.cInfoAggiuntive();

                    var r = i.Inserisci(new DB.DataWrapper.Tabelle.InfoAggiuntive()
                    {                        
                        Hide = 'T',
                        Entita_Tipo = "Persona",
                        Entita_Key = chiave,
                        Tipo = ConstStampe.ToString(documento),
                        Allegato = file
                    }, "ID", true);

                    if (r.Errore)
                        GB.cGB.MsgBox(r.Eccezione);                    
                }
            }
        }

        private string StampaRimpiazzaDocx_p2(string Entita, object chiave, ConstStampe.eStampa documento, DB.DataWrapper.Tabelle.Base.BaseDBObject vista)
        {
            var resu = "";
            var Database = new DatiComuni.Database();
            Database = Database.Carica();

            var enty = @"\" + Entita + @"\" + chiave + @"\";
            var dest = Path.GetTempPath() + enty + @"SCHEDA PRIMO CONTATTO\";
            var zip = ConstStampe.PercorsoStampa(documento);
            var destFO = Database.DocumentaleFolder + enty;
            var docx = destFO + DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_SCHEDA PRIMO CONTATTO.docx";

            if (!Directory.Exists(destFO))
                Directory.CreateDirectory(destFO);

            File.Copy(zip, docx);

            var z = new FastZip();
            z.ExtractZip(zip, dest, "document.xml");

            var f = Directory.GetFiles(dest, "document.xml", SearchOption.AllDirectories);

            if (f != null && f.Length > 0)
                using (var zippo = new ZipFile(docx))
                {
                    zippo.BeginUpdate();

                    foreach (var d in f)
                    {
                        object v = null;
                        string te = "";
                        var text = File.ReadAllText(d);
                        var properties = vista.GetType().GetProperties();

                        foreach (var p in properties)
                        {
                            try
                            {
                                v = p.GetValue(vista, null);
                            }
                            catch
                            {
                                v = null;
                            }

                            if (v == null)
                                v = "";

                            if (v is DateTime)
                                te = GB.cGB.DateTimeToDate_String(v);
                            else if (v is bool)
                                te = GB.cGB.BoolToSiNo(v);
                            else
                                te = v.ToString();

                            text = text.Replace("XXX" + p.Name + "XXX", te);
                        }

                        File.WriteAllText(d, text);

                        zippo.Add(d, @"word\document.xml");
                    }

                    zippo.CommitUpdate();
                    zippo.Close();

                    resu = docx;

                    GB.cGB.StartProgram(docx);
                }

            return resu;
        }


    }
}