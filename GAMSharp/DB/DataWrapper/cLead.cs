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
    sealed class cLead : Base.cBaseEntity<Lead>
    {

        protected override Lead Carica_Record(ref DbDataReader dr)
        {
            return new Lead()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                Cognome = cGB.ObjectToString(dr["Cognome"]),
                Nome = cGB.ObjectToString(dr["Nome"]),
                Sesso = cGB.ObjectToChar(dr["Sesso"], 'M'),
                DataDiNascita = cGB.ObjectToDateTime(dr["DataDiNascita"]),
                LuogoDiNascita = cGB.ObjectToString(dr["LuogoDiNascita"]),

                NazioneDiNascita = cGB.ObjectToString(dr["NazioneDiNascita"]),
                Professione = cGB.ObjectToString(dr["Professione"])
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Lead entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("Cognome", entita.Cognome),
                cDB.NewPar("Nome", entita.Nome),
                cDB.NewPar("Sesso", entita.Sesso),
                cDB.NewPar("DataDiNascita", entita.DataDiNascita),
                cDB.NewPar("LuogoDiNascita", entita.LuogoDiNascita),

                cDB.NewPar("NazioneDiNascita", entita.NazioneDiNascita),
                cDB.NewPar("Professione", entita.Professione)
            };
        }

        protected override DbParameter[] Modifica_Parametri(Lead entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(Lead entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("Cognome", entita.Cognome),
                cDB.NewPar("Nome", entita.Nome),
                cDB.NewPar("LuogoDiNascita", entita.LuogoDiNascita)
            };
        }


    }
}