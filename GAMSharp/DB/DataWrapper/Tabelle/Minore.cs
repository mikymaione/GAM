/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace GAMSharp.DB.DataWrapper.Tabelle
{
    public class Minore : TabellaBase
    {
        [PrimaryKey]
        public string Persona_CF { get; set; }
        public int Scuola { get; set; }
        public char ConoscenzaDirettaServizio { get; set; }
        public int? SoggettoInviante { get; set; }
        public int IDScaglioniDiEta { get; set; }
        public string MotivoIscrizione { get; set; }
        public string Scuola_Classe { get; set; }
        public string Scuola_Note { get; set; }
        public string SegnalatoDa { get; set; }
        public string InformazioniSullaSalute { get; set; }
        public string DisabilitaFisica { get; set; }
        public string DisabilitaPsichica { get; set; }
        public string DisagioNonDiagn { get; set; }
        public string DisturboApprendimento { get; set; }
        public char ParentiStessoProgetto { get; set; }
        public System.DateTime DataPrimoContatto { get; set; }
        public System.DateTime DataIscrizione { get; set; }
        public sExRicerca ExRicerca;

        public struct sExRicerca
        {
            public string RagioneSociale, ScuolaDesc, SoggettoInvianteDesc, Scaglione;
        }


    }
}