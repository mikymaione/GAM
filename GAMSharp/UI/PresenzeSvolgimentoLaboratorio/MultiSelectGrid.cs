/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.GB;
using GAMSharp.UI.Base;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GAMSharp.UI.PresenzeSvolgimentoLaboratorio
{
    sealed class MultiSelectGrid : cMultiSelectGriglia
    {

        public int IDSvolgimentoLaboratorio { get; set; }

        private DB.DataWrapper.cPresenzeSvolgimentoLaboratorio PresenzeSvolgimentoLaboratorio = new DB.DataWrapper.cPresenzeSvolgimentoLaboratorio();

        internal MultiSelectGrid()
        {
            AddColonne(getColonneGriglia());

            this.Load += MultiSelectGrid_Load;
            this.SelezionaTuttiClick += MultiSelectGrid_SelezionaTuttiClick;
            this.DeSelezionaTuttiClick += MultiSelectGrid_DeSelezionaTuttiClick;
            this.NuovoClick += MultiSelectGrid_NuovoClick;
            this.SalvaClick += MultiSelectGrid_SalvaClick;
        }        

        private void MultiSelectGrid_SalvaClick()
        {
            if (Rows.Count > 0)
            {
                this.EndEdit();

                var righe = new List<Tuple<Tuple<int, string>, bool>>(Rows.Count);

                for (int i = 0; i < Rows.Count; i++)
                {
                    var b = cGB.ObjectToBoolean(Rows[i].Cells[0].Value);
                    var cf = cGB.ObjectToString(Rows[i].Cells[1].Value);

                    righe.Add(new Tuple<Tuple<int, string>, bool>(new Tuple<int, string>(IDSvolgimentoLaboratorio, cf), b));
                }

                var r = PresenzeSvolgimentoLaboratorio.AggiornaMultiplo(righe);

                MsgAggiornati(r);
                ChiamaCarica();
            }
        }

        private void MsgAggiornati(dynamic i)
        {
            cGB.MsgBox("Aggiornati " + i + "/" + Rows.Count + " presenze al laboratorio!", MessageBoxIcon.Information);
        }

        private void MultiSelectGrid_NuovoClick()
        {
            using (var f = new Minore.Ricerca())
            {                
                var r = f.LookUp();

                PresenzeSvolgimentoLaboratorio.Nuovo(new DB.DataWrapper.Tabelle.PresenzeSvolgimentoLaboratorio()
                {
                    IDSvolgimentoLaboratorio = IDSvolgimentoLaboratorio,
                    Minore_CF = cGB.ObjectToString(r.Item1)
                });
            }

            ChiamaCarica();
        }

        private void SelezionaTutti(bool presente)
        {
            var r = PresenzeSvolgimentoLaboratorio.SelezionaTutti(presente, IDSvolgimentoLaboratorio);
            MsgAggiornati(r.Risultato);
            ChiamaCarica();
        }

        private void MultiSelectGrid_DeSelezionaTuttiClick()
        {
            SelezionaTutti(false);
        }

        private void MultiSelectGrid_SelezionaTuttiClick()
        {
            SelezionaTutti(true);
        }

        private void MultiSelectGrid_Load(object sender, EventArgs e)
        {
#if DEBUG
            ChiamaCarica();
#endif
        }

        private DB.DataWrapper.cPresenzeSvolgimentoLaboratorio Carica_getEntita()
        {
            return new DB.DataWrapper.cPresenzeSvolgimentoLaboratorio();
        }

        private void CaricaDati(DB.DataWrapper.cPresenzeSvolgimentoLaboratorio c_entita, DB.DataWrapper.Tabelle.PresenzeSvolgimentoLaboratorio parametri)
        {
            var r = c_entita.Ricerca(cGB.ObjectToInt(eFirstXRows.Text, -1), parametri);

            if (r.Errore)
                cGB.MsgBox(r.Eccezione);
            else
                Carica(r.Risultato);
        }

        internal void ChiamaCarica()
        {
            CaricaDati(new DB.DataWrapper.cPresenzeSvolgimentoLaboratorio(), new DB.DataWrapper.Tabelle.PresenzeSvolgimentoLaboratorio()
            {
                IDSvolgimentoLaboratorio = IDSvolgimentoLaboratorio
            });
        }

        private DataGridViewColumn[] getColonneGriglia()
        {
            return new DataGridViewColumn[] {
                NewCol_CheckBox("Presente", 60, false),
                NewCol("Minore_CF", "Codice fiscale", 140),
                NewCol("RagioneSociale", "Minore"),
                NewCol("DataDiNascita", "Data di nascita", 80),
                NewCol("LuogoDiNascita", "Luogo di nascita", 120)
            };
        }


    }
}