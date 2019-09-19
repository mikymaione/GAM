/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Tabelle;
using GAMSharp.GB;
using System.Data.Common;
using System;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cSvolgimentoLaboratorio : Base.cBaseEntity<SvolgimentoLaboratorio>
    {

        internal override cRisultatoSQL<Tuple<int, int>> Inserisci(SvolgimentoLaboratorio entita, string PrimaryKeyName, bool PrimaryKeyIsAutoInc)
        {
            var i = base.Inserisci(entita, PrimaryKeyName, PrimaryKeyIsAutoInc);

            if (i.Errore)
                return new cRisultatoSQL<Tuple<int, int>>(i.Eccezione);

            if (i.Risultato.Item1 > 0)
            {
                var cp = new cPresenzeSvolgimentoLaboratorio();
                var r = cp.CreaMinori(i.Risultato.Item2);

                if (r.Errore)
                    return new cRisultatoSQL<Tuple<int, int>>(r.Eccezione);
                else
                    return new cRisultatoSQL<Tuple<int, int>>(new Tuple<int, int>(r.Risultato, -1));
            }

            return new cRisultatoSQL<Tuple<int, int>>(new Tuple<int, int>(0, -1));
        }
    
        protected override SvolgimentoLaboratorio Carica_Record(ref DbDataReader dr)
        {
            return new SvolgimentoLaboratorio()
            {
                ID = cGB.ObjectToInt(dr["ID"], -1),
                IDLaboratorio = cGB.ObjectToInt(dr["IDLaboratorio"], -1),
                Dalle = cGB.ObjectToDateTime(dr["Dalle"]),
                Alle = cGB.ObjectToDateTime(dr["Alle"]),
                Note = cGB.ObjectToString(dr["Note"])
            };
        }

        protected override DbParameter[] Inserisci_Parametri(SvolgimentoLaboratorio entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("IDLaboratorio", entita.IDLaboratorio),
                cDB.NewPar("Dalle", entita.Dalle),
                cDB.NewPar("Alle", entita.Alle),
                cDB.NewPar("Note", entita.Note)
            };
        }

        protected override DbParameter[] Modifica_Parametri(SvolgimentoLaboratorio entita)
        {
            var p = Inserisci_Parametri(entita);
            cDB.AddPar(ref p, "ID", entita.ID);

            return p;
        }

        protected override DbParameter[] Ricerca_Parametri(SvolgimentoLaboratorio entita)
        {
            return new DbParameter[]  {
                cDB.NewPar("IDLaboratorio", entita.IDLaboratorio)
            };
        }


    }
}