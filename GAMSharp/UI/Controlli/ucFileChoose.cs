/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Windows.Forms;

namespace GAMSharp.UI.Controlli
{
    public partial class ucFileChoose : UserControl
    {

        private string FilePath_Real_ = "";

        public string PathEntità { get; set; }
        public string PathKey { get; set; }

        public string FileName
        {
            get
            {
                return System.IO.Path.GetFileName(FilePath_Real);
            }
        }

        public string FilePath_Real
        {
            get
            {
                return FilePath_Real_;
            }
            set
            {
                FilePath_Real_ = value;
                eFile.Text = System.IO.Path.GetFileName(value);
            }
        }

        public ucFileChoose()
        {
            InitializeComponent();
        }

        private void bChoose_Click(object sender, EventArgs e)
        {
            bool continua = true;

            if (FilePath_Real_ != null && !FilePath_Real_.Equals(""))
                continua = GB.cGB.MsgBoxQuestion("Vuoi sostituire il file " + FilePath_Real_ + " con un file nuovo?");

            if (continua)
                using (var opd = new OpenFileDialog())
                    if (opd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(opd.FileName))
                            try
                            {
                                string a = GB.MyGB.OpzioniDB.DocumentaleFolder;
                                string b = GB.cGB.NullStringToEmpty(PathEntità);
                                string c = GB.cGB.NullStringToEmpty(PathKey);
                                string d = System.IO.Path.Combine(System.IO.Path.Combine(a, b), c);
                                string r = System.IO.Path.Combine(d, System.IO.Path.GetFileName(opd.FileName));

                                if (a.Equals(""))
                                    throw new Exception("Percorso_Archivio_Documentale not setted");
                                if (b.Equals(""))
                                    throw new Exception("PathEntità not setted");
                                if (c.Equals(""))
                                    throw new Exception("PathKey not setted");

                                GB.cGB.CreaCartellaSeNonEsiste_ThrowException(d);

                                if (System.IO.File.Exists(r))
                                    continua = GB.cGB.MsgBoxQuestion("Il file " + r + " esiste già, vuoi sostituirlo?");

                                if (continua)
                                {
                                    System.IO.File.Copy(opd.FileName, r, true);
                                    FilePath_Real = r;
                                }
                            }
                            catch (Exception ex)
                            {
                                GB.cGB.MsgBox(ex);
                            }
        }

        private void bVedi_Click(object sender, EventArgs e)
        {
            if (FilePath_Real_ != null && !FilePath_Real_.Equals(""))
            {
                if (System.IO.File.Exists(FilePath_Real_))
                    System.Diagnostics.Process.Start(FilePath_Real_);
                else
                    GB.cGB.MsgBox("Il file " + FilePath_Real_ + " non esiste!", MessageBoxIcon.Error);
            }
            else
                GB.cGB.MsgBox("Clicca sul pulsante 'Scegli un file' per allegare un file.");
        }


    }
}