/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2016 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using GAMSharp.DB.DataWrapper.Viste;
using System.Collections.Generic;

namespace GAMSharp.DB.DataWrapper
{
    sealed class cRubrica
    {
       
        internal cRisultatoSQL<List<Rubrica>> Ricerca(Rubrica entita)
        {
            try
            {
                var rubrica = new List<Rubrica>();
                var p = new cPersona();
                var l = new cLead();

                var R_persone = p.Ricerca(entita.Persona);
                var R_leads = l.Ricerca(entita.Lead);

                if (!R_persone.Errore)
                    foreach (var persona in R_persone.Risultato)
                        rubrica.Add(new Rubrica()
                        {
                            Persona = persona
                        });

                if (!R_leads.Errore)
                    foreach (var lead in R_leads.Risultato)
                        rubrica.Add(new Rubrica()
                        {
                            Lead = lead
                        });

                return new cRisultatoSQL<List<Rubrica>>(rubrica);
            }
            catch (System.Exception ex)
            {
                return new cRisultatoSQL<List<Rubrica>>(ex);
            }
        }


    }
}