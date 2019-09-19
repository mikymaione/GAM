/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using GAMSharp.DatiComuni;

namespace GAMSharpOptions
{
    public partial class Form1 : Form
    {

        private Database OpzioniProgramma = new Database();

        public Form1()
        {
            InitializeComponent();

            OpzioniProgramma = OpzioniProgramma.Carica();

            if (!System.IO.Directory.Exists(GAMSharp.GB.cGB.NullStringToEmpty(OpzioniProgramma.DBFolder)))
                OpzioniProgramma.DBFolder = GAMSharp.GB.cGB.CartellaDefaultInstallazione;

            eDBFolder.Text = OpzioniProgramma.DBFolder;
            eDocumentaleFolder.Text = OpzioniProgramma.DocumentaleFolder;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            OpzioniProgramma.Salva(OpzioniProgramma);
        }

        private void CreaRegistraTask(TaskService task_service, string Titolo, string Descrizione, string ProgrammaExe, GAMSharp.GB.cGB.Time orario, short DaysInterval_)
        {
            string a = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            TaskDefinition t = task_service.NewTask();

            t.Principal.UserId = "SYSTEM";
            t.Principal.LogonType = TaskLogonType.ServiceAccount;
            t.Principal.RunLevel = TaskRunLevel.Highest;
            t.Settings.WakeToRun = true;
            t.Settings.RunOnlyIfNetworkAvailable = true;
            t.Settings.MultipleInstances = TaskInstancesPolicy.IgnoreNew;
            t.RegistrationInfo.Description = Descrizione;
            t.Actions.Add(new ExecAction(System.IO.Path.Combine(a, ProgrammaExe)));
            t.Triggers.Add(new DailyTrigger()
            {
                StartBoundary = DateTime.Today + new TimeSpan(orario.Ora, orario.Minuto, 0),
                DaysInterval = DaysInterval_
            });

            task_service.RootFolder.RegisterTaskDefinition(Titolo, t);
        }

        private bool Valida()
        {
            int i = 0;
            string s = "";
            var e = new System.Collections.Generic.List<string>();

            if (!GAMSharp.GB.cGB.String_For_Time_IsValid(eDBBKOrario.Text))
                e.Add("L'orario di Database Backup non è valido");
            if (!GAMSharp.GB.cGB.String_For_Time_IsValid(eUPDOrario.Text))
                e.Add("L'orario di Software update non è valido");

            foreach (var z in e)
                s += "#" + (i += 1) + ": " + z + Environment.NewLine;

            if (e.Count > 0)
                GAMSharp.GB.cGB.MsgBox(s, MessageBoxIcon.Error);

            return (e.Count < 1);
        }

        private void bScegliCartellaDB_Click(object sender, EventArgs e)
        {
            bool ok = false;

            using (var d = new FolderBrowserDialog())
            {
                d.Description = "Seleziona la cartella del database di GAM#";

                if (d.ShowDialog() == DialogResult.OK)
                    if (System.IO.Directory.Exists(d.SelectedPath))
                    {
                        var f = System.IO.Directory.GetFiles(d.SelectedPath, "*.fdb");

                        if (f.Length > 0)
                        {
                            eDBFolder.Text = d.SelectedPath;
                            OpzioniProgramma.DBFolder = d.SelectedPath;
                            ok = true;
                        }
                    }
            }

            if (!ok)
                GAMSharp.GB.cGB.MsgBox("La cartella selezionata non contiene nessun database!", MessageBoxIcon.Exclamation);
        }

        private void bCreaCartellaCondivisa_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(eDBFolder.Text))
            {
                var c = new GAMSharp.GB.cShareFolder();

                GAMSharp.GB.cGB.MsgBox(c.ShareFolder_ToMsg(eDBFolder.Text, "GAM# Server", "GAM# Server"), MessageBoxIcon.Exclamation);
            }
            else
            {
                GAMSharp.GB.cGB.MsgBox("Scegliere una cartella del Data Base");
            }
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            if (Valida())
                try
                {
                    using (TaskService task_service = new TaskService())
                    {
                        CreaRegistraTask(
                        task_service,
                        "GAM# - Database Backup",
                        "GAM# - Gestione accoglienza minori: esegue una copia di backup del database.",
                        "GAMSharpDBBK.exe",
                        GAMSharp.GB.cGB.StringToTime(eDBBKOrario.Text),
                        Convert.ToInt16(eDBBKGiorni.Value)
                        );

                        CreaRegistraTask(
                        task_service,
                        "GAM# - Software update",
                        "GAM# - Gestione accoglienza minori: esegue l'aggiornamento automatico del programma.",
                        "GAMSharpUpdate.exe",
                        GAMSharp.GB.cGB.StringToTime(eUPDOrario.Text),
                        Convert.ToInt16(eUPDGiorni.Value)
                        );
                    }

                    GAMSharp.GB.cGB.MsgBox("Creati 2 tasks!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    GAMSharp.GB.cGB.MsgBox(ex.Message);
                }
        }

        private void bEventViewer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("eventvwr.exe");
        }

        private void bWindowsTaskScheduler_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("taskschd.msc");
        }

        private void bScegliCartellaDocumentale_Click(object sender, EventArgs e)
        {
            using (var d = new FolderBrowserDialog())
            {
                d.Description = "Seleziona la cartella dell'archivio documentale di GAM#";

                if (d.ShowDialog() == DialogResult.OK)
                    if (System.IO.Directory.Exists(d.SelectedPath))
                    {
                        eDocumentaleFolder.Text = d.SelectedPath;
                        OpzioniProgramma.DocumentaleFolder = d.SelectedPath;
                    }
            }
        }


    }
}