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
    sealed class cPersona : Base.cBaseEntity<Persona>
    {

        internal cRisultatoSQL<System.Data.DataTable> GSG_Partecipanti(int MaxRows, Persona entita)
        {
            try
            {
                return new cRisultatoSQL<System.Data.DataTable>(cDB.EseguiSQLDataTable(getQuery("GSG_Partecipanti"), Ricerca_Parametri(entita), MaxRows));
            }
            catch (System.Exception ex)
            {
                return new cRisultatoSQL<System.Data.DataTable>(ex);
            }
        }

        protected override Persona Carica_Record(ref System.Data.Common.DbDataReader dr)
        {
            return new Persona()
            {
                CF = cGB.ObjectToString(dr["CF"]),
                Cognome = cGB.ObjectToString(dr["Cognome"]),
                Nome = cGB.ObjectToString(dr["Nome"]),
                Sesso = cGB.ObjectToChar(dr["Sesso"], 'M'),
                DataDiNascita = cGB.ObjectToDateTime(dr["DataDiNascita"]),
                LuogoDiNascita = cGB.ObjectToString(dr["LuogoDiNascita"]),

                Madre_CF = cGB.ObjectToString(dr["Madre_CF"]),
                Padre_CF = cGB.ObjectToString(dr["Padre_CF"]),
                Tutore_CF = cGB.ObjectToString(dr["Tutore_CF"]),

                NazioneDiNascita = cGB.ObjectToString(dr["NazioneDiNascita"]),
                Professione = cGB.ObjectToString(dr["Professione"]),
                AdesioneGSG = cGB.ObjectToChar(dr["AdesioneGSG"], 'F'),

                ExRicerca = new Persona.sExRicerca()
                {
                    Madre = cGB.ObjectToString(dr["Madre"]),
                    Padre = cGB.ObjectToString(dr["Padre"]),
                    Tutore = cGB.ObjectToString(dr["Tutore"])
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Persona entita)
        {
            return Modifica_Parametri(entita);
        }

        protected override DbParameter[] Modifica_Parametri(Persona entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("CF", entita.CF),
                cDB.NewPar("Cognome", entita.Cognome),
                cDB.NewPar("Nome", entita.Nome),
                cDB.NewPar("Sesso", entita.Sesso),
                cDB.NewPar("DataDiNascita", entita.DataDiNascita),
                cDB.NewPar("LuogoDiNascita", entita.LuogoDiNascita),

                cDB.NewPar("NazioneDiNascita", entita.NazioneDiNascita),
                cDB.NewPar("Professione", entita.Professione),
                cDB.NewPar("AdesioneGSG", entita.AdesioneGSG),

                cDB.NewPar("Madre_CF", entita.Madre_CF),
                cDB.NewPar("Padre_CF", entita.Padre_CF),
                cDB.NewPar("Tutore_CF", entita.Tutore_CF)
            };
        }

        protected override DbParameter[] Ricerca_Parametri(Persona entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("CF", entita.CF),
                cDB.NewPar("Cognome", entita.Cognome),
                cDB.NewPar("Nome", entita.Nome),
                cDB.NewPar("LuogoDiNascita", entita.LuogoDiNascita)
            };
        }


    }
}