/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Tabelle;
using System.Data.Common;
using GAMSharp.GB;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cEducatrice : Base.cBaseEntity<Educatrice>
    {

        protected override Educatrice Carica_Record(ref DbDataReader dr)
        {
            return new Educatrice()
            {
                Persona_CF = cGB.ObjectToString(dr["Persona_CF"]),
                IDScaglioniDiEta = cGB.ObjectToInt(dr["IDScaglioniDiEta"], -1),
                Note = cGB.ObjectToString(dr["Note"]),
                ExRicerca = new Educatrice.sExRicerca()
                {
                    RagioneSociale = cGB.ObjectToString(dr["RagioneSociale"]),
                    Scaglione = cGB.ObjectToString(dr["Scaglione"])
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Educatrice entita)
        {
            return Modifica_Parametri(entita);
        }

        protected override DbParameter[] Modifica_Parametri(Educatrice entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("Persona_CF", entita.Persona_CF),
                cDB.NewPar("IDScaglioniDiEta", entita.IDScaglioniDiEta),
                cDB.NewPar("Note", entita.Note)
            };
        }

        protected override DbParameter[] Ricerca_Parametri(Educatrice entita)
        {
            return null;
        }


    }
}