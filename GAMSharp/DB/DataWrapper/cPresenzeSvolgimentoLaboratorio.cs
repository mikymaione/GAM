/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Tabelle;
using GAMSharp.GB;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cPresenzeSvolgimentoLaboratorio : Base.cBaseEntity<PresenzeSvolgimentoLaboratorio>
    {

        internal cRisultatoSQL<int> Nuovo(PresenzeSvolgimentoLaboratorio e)
        {
            var p = new DbParameter[]  {
                cDB.NewPar("IDSvolgimentoLaboratorio", e.IDSvolgimentoLaboratorio),
                cDB.NewPar("Minore_CF", e.Minore_CF)
            };

            return cDB.EseguiSQLNoQuery(getQuery("Nuovo"), p);
        }

        internal uint AggiornaMultiplo(List<Tuple<Tuple<int, string>, bool>> righe)
        {
            uint tot = 0;

            foreach (var r in righe)
            {
                var p = new DbParameter[]  {
                    cDB.NewPar("Presente", cGB.BoolToEnglishString(r.Item2)),
                    cDB.NewPar("IDSvolgimentoLaboratorio", r.Item1.Item1),
                    cDB.NewPar("Minore_CF", r.Item1.Item2)
                };

                var z = cDB.EseguiSQLNoQuery(getQuery("Aggiorna"), p);

                if (z.Risultato > 0)
                    tot += Convert.ToUInt32(z.Risultato);
            }

            return tot;
        }

        internal cRisultatoSQL<int> SelezionaTutti(bool Presente, int IDSvolgimentoLaboratorio)
        {
            var p = new DbParameter[]  {
                cDB.NewPar("Presente", cGB.BoolToEnglishString(Presente)),
                cDB.NewPar("IDSvolgimentoLaboratorio", IDSvolgimentoLaboratorio)
            };

            return cDB.EseguiSQLNoQuery(getQuery("SelezionaTutti"), p);
        }

        internal cRisultatoSQL<int> CreaMinori(int IDSvolgimentoLaboratorio)
        {
            var p = new DbParameter[]  {
                cDB.NewPar("IDSvolgimentoLaboratorio", IDSvolgimentoLaboratorio),
                cDB.NewPar("CFCreazione", cMemDB.UtenteConnesso.Persona_CF),
                cDB.NewPar("CFModifica", cMemDB.UtenteConnesso.Persona_CF)
            };

            return cDB.EseguiSQLNoQuery(getQuery("Crea"), p);
        }

        protected override PresenzeSvolgimentoLaboratorio Carica_Record(ref DbDataReader dr)
        {
            return new PresenzeSvolgimentoLaboratorio()
            {
                IDSvolgimentoLaboratorio = cGB.ObjectToInt(dr["IDSvolgimentoLaboratorio"], -1),
                Minore_CF = cGB.ObjectToString(dr["Minore_CF"]),
                Presente = cGB.ObjectToString(dr["Presente"], "false")
            };
        }

        protected override DbParameter[] Inserisci_Parametri(PresenzeSvolgimentoLaboratorio entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("IDSvolgimentoLaboratorio", entita.IDSvolgimentoLaboratorio),
                cDB.NewPar("Minore_CF", entita.Minore_CF),
                cDB.NewPar("Presente", entita.Presente)
            };
        }

        protected override DbParameter[] Modifica_Parametri(PresenzeSvolgimentoLaboratorio entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("Presente", entita.Presente)
            };
        }

        protected override DbParameter[] Ricerca_Parametri(PresenzeSvolgimentoLaboratorio entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("IDSvolgimentoLaboratorio", entita.IDSvolgimentoLaboratorio)
            };
        }


    }
}