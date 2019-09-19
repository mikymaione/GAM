/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using GAMSharp.GB;

namespace GAMSharp.UI
{
    partial class fScegliServer : Base.fBase
    {

        internal fScegliServer()
        {
            InitializeComponent();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            var t = this.Text;
            this.Text = "Connessione in corso ...";
            this.Enabled = false;
            var Server_ = eServers.Text;

            if (DB.cDB.ApriConnessione(DB.cDB.DataBase.FireBird, "GAM", false, Server_, "SYSDBA", "masterkey"))
            {
                MyGB.Opzioni.ConnectionString = DB.cDB.ActualConnectionString;
                this.Close();
            }

            this.Text = t;
            this.Enabled = true;
        }

        void CercaServers()
        {
            System.Windows.Forms.Application.DoEvents();
            var t = this.Text;
            this.Text = "Ricerca server in corso ...";
            this.Enabled = false;

            var l = new GB.cLan();
            var computers = l.GetComputersOnLan();

            if (computers != null && computers.Count > 0)
                eServers.Items.AddRange(computers.ToArray());

            this.Text = t;
            this.Enabled = true;
        }

        private void bCerca_Click(object sender, EventArgs e)
        {
            CercaServers();
        }


    }
}