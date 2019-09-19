/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Windows.Forms;
using GAMSharp.GB;

namespace GAMSharp.UI
{
    sealed partial class fMain : Base.fBase
    {

        private bool ChiusuraRichiesta = false;

        internal fMain()
        {
            InitializeComponent();

            utenteToolStripMenuItem.Text = DB.cMemDB.UtenteConnesso.ExRicerca.RagioneSociale;
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ChiusuraRichiesta)
                if (cGB.MsgBox("Vuoi uscire dal programma?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
        }

        private void ShowChildForm(Form n)
        {
            n.ShowDialog();
        }

        private void disconnettiToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ChiusuraRichiesta = true;
            this.DialogResult = DialogResult.Retry;
        }

        private void dettaglioToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            using (var u = new Utente.Dettaglio())
                u.ShowDialog(DB.cMemDB.UtenteConnesso.Persona_CF);
        }

        private void ilCentroToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            using (var u = new Centro.Dettaglio())
                u.ShowDialog("TEN");
        }

        private void novitàToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new fNovità());
        }

        private void informazioniToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new fAbout());
        }

        private void personeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new Persona.Ricerca());
        }

        private void utentiToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new Utente.Ricerca());
        }

        private void scaglioniToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new ScaglioniDiEta.Ricerca());
        }

        private void listeDiAttesaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new ListaDiAttesa.Ricerca());
        }

        private void segnalaUnProblemaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new fSegnalaUnProblema());
        }

        private void laboratoriToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new Laboratorio.Ricerca());
        }

        private void educatriciToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new Educatrice.Ricerca());
        }

        private void entiToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new Ente.Ricerca());
        }

        private void contattiToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new Lead.Ricerca());
        }

        private void minoriToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new Minore.Ricerca());
        }

        private void plenarieToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new Plenaria.Ricerca());
        }

        private void assistentiSocialiToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new AssistenteSociale.Ricerca());
        }

        private void nucleiFamiliariToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new NucleoFamiliare.Ricerca());
        }

        private void gruppiSostegniGenitorialitàToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new GruppoSostegnoG.Ricerca());
        }

        private void numerazioniToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new Numerazioni.Ricerca());
        }

        private void rubricaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowChildForm(new Rubrica());
        }


    }
}