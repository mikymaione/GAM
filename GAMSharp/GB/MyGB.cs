/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace GAMSharp.GB
{
    static class MyGB
    {
        private static DatiComuni.OpzioniProgramma Opzioni_ = new DatiComuni.OpzioniProgramma();
        private static DatiComuni.Database OpzioniDB_ = new DatiComuni.Database();

        internal static DatiComuni.OpzioniProgramma Opzioni
        {
            get
            {
                return Opzioni_;
            }
            set
            {
                Opzioni_ = value;
            }
        }

        internal static DatiComuni.Database OpzioniDB
        {
            get
            {
                return OpzioniDB_;
            }
        }

        internal static void Carica()
        {
            Opzioni_ = Opzioni.Carica() as DatiComuni.OpzioniProgramma;
            OpzioniDB_ = OpzioniDB.Carica() as DatiComuni.Database;
        }

        internal static void Salva()
        {
            Opzioni_.Salva(Opzioni_);
        }


    }
}