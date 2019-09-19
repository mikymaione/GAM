/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Data.Common;
using GAMSharp.DB.DataWrapper.Tabelle;
using GAMSharp.GB;

namespace GAMSharp.DB.DataWrapper
{
    class cListaDiAttesa : Base.cBaseEntityExtendedSearch<ListaDiAttesa, ListaDiAttesaRicerca>
    {

        protected override ListaDiAttesa Carica_Record(ref DbDataReader dr)
        {
            return new ListaDiAttesa()
            {
                ExRicerca = new ListaDiAttesa.sExRicerca()
                {
                    RagioneSociale = cGB.ObjectToString(dr["RagioneSociale"])                    
                },
                Minore_CF = cGB.ObjectToString(dr["Minore_CF"]),
                EntrataInLista = cGB.ObjectToDateTime(dr["EntrataInLista"]),
                UscitaDallaLista = cGB.ObjectToDateTime(dr["UscitaDallaLista"])                
            };
        }

        protected override DbParameter[] Inserisci_Parametri(ListaDiAttesa e)
        {
            return Modifica_Parametri(e);
        }

        protected override DbParameter[] Modifica_Parametri(ListaDiAttesa e)
        {
            return new DbParameter[] {
                cDB.NewPar("Minore_CF", e.Minore_CF),
                cDB.NewPar("EntrataInLista", e.EntrataInLista),
                cDB.NewPar("UscitaDallaLista", cGB.DateToDBDateNullable(e.UscitaDallaLista))                
            };
        }

        protected override DbParameter[] Ricerca_Parametri(ListaDiAttesa entita)
        {
            return null;
        }

        protected override DbParameter[] Ricerca_ParametriEx(ListaDiAttesaRicerca e)
        {
            return new DbParameter[] {
                cDB.NewPar("Minore_CF", e.Minore_CF),
                cDB.NewPar("Cognome", e.Cognome),
                cDB.NewPar("Nome", e.Nome)
            };
        }


    }
}