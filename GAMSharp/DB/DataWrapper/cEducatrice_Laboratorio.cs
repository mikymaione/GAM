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
    sealed class cEducatrice_Laboratorio : Base.cBaseEntity<Educatrice_Laboratorio>
    {

        protected override Educatrice_Laboratorio Carica_Record(ref DbDataReader dr)
        {
            return new Educatrice_Laboratorio()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                IDLaboratorio = cGB.ObjectToInt(dr["IDLaboratorio"], -1),
                CFEducatrice = cGB.ObjectToString(dr["CFEducatrice"]),
                ExRicerca = new Educatrice_Laboratorio.sExRicerca()
                {
                    Laboratorio = cGB.ObjectToString(dr["Laboratorio"]),
                    RagioneSociale = cGB.ObjectToString(dr["RagioneSociale"])
                }
            };
        }

        protected override DbParameter[] Inserisci_Parametri(Educatrice_Laboratorio entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("CFEducatrice", entita.CFEducatrice),
                cDB.NewPar("IDLaboratorio", entita.IDLaboratorio)
            };
        }

        protected override DbParameter[] Modifica_Parametri(Educatrice_Laboratorio entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(Educatrice_Laboratorio entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("IDLaboratorio", entita.IDLaboratorio),
                cDB.NewPar("CFEducatrice", entita.CFEducatrice)
            };
        }


    }
}