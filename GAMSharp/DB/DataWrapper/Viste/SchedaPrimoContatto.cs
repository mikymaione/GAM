/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2016 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Tabelle;
using System;
using System.Collections.Generic;

namespace GAMSharp.DB.DataWrapper.Viste
{
    sealed class SchedaPrimoContatto : Tabelle.Base.BaseDBObject
    {

        [PrimaryKey]
        public string CF { get; set; }
        public int NSchedaPrimoContatto { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string LuogoDiNascita { get; set; }
        public DateTime DataDiNascita { get; set; }
        public string NazioneDiNascita { get; set; }
        public string Nazionalita { get; set; }
        public string ComuneCap { get; set; }
        public string Indirizzo { get; set; }
        public string TelCasa { get; set; }
        public string TelMobile { get; set; }
        public DateTime DataIscrizione { get; set; }
        public bool ConoscenzaDirettaServizio { get; set; }
        public string SoggettoInviante { get; set; }
        public string MotivoIscrizione { get; set; }
        public string Scuola_Classe { get; set; }
        public string Scuola_Note { get; set; }
        public bool ParentiStessoProgetto { get; set; }
        public string InformazioniSullaSalute { get; set; }
        public string DescScuola { get; set; }
        public string Mamma_Cognome { get; set; }
        public string Mamma_Nome { get; set; }
        public string Mamma_LuogoDiNascita { get; set; }
        public DateTime Mamma_DataDiNascita { get; set; }
        public string Mamma_Professione { get; set; }
        public string Babbo_Cognome { get; set; }
        public string Babbo_Nome { get; set; }
        public string Babbo_LuogoDiNascita { get; set; }
        public DateTime Babbo_DataDiNascita { get; set; }
        public string Babbo_Professione { get; set; }

        public string AttivitaTerritorio
        {
            get
            {
                var d = "";
                var a = new cAttivitaExtra();
                var r = a.Ricerca(new AttivitaExtra()
                {
                    Minore_CF = CF
                });

                if (!r.Errore && r.Risultato.Count > 0)
                {
                    var descrizioni = new List<string>();

                    foreach (var x in r.Risultato)
                        if (x.AttivitaDelTerritorio.Equals('T'))
                            descrizioni.Add(x.Descrizione);

                    d = string.Join(", ", descrizioni.ToArray()) + ".";
                }

                return d;
            }
        }

        public DateTime TODAY
        {
            get
            {
                return DateTime.Now;
            }
        }


    }
}