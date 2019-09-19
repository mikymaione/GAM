/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;

namespace GAMSharp.GB
{
    [Serializable]
    public class SerializzatoreFS<Classe> where Classe : class, new()
    {

        private string FileOpzioni
        {
            get
            {
                var z = typeof(Classe);

                string p = cGB.CartellaApplicationData;
                p = System.IO.Path.Combine(p, z.Namespace + "." + z.Name + ".db");

                return p;
            }
        }       

        public void Salva(Classe classe)
        {
            cGB.CreaCartellaSeNonEsiste(cGB.CartellaApplicationData);

            if (System.IO.Directory.Exists(cGB.CartellaApplicationData))
                try
                {
                    using (var fs = new System.IO.FileStream(FileOpzioni, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
                    {
                        try
                        {
                            var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                            bf.Serialize(fs, classe);
                        }
                        catch
                        {
                            //errore                            
                        }

                        fs.Close();
                    }
                }
                catch
                {
                    //errore
                }
        }

        public Classe Carica()
        {
            Classe t = null;

            if (System.IO.File.Exists(FileOpzioni))
                try
                {
                    using (var fs = new System.IO.FileStream(FileOpzioni, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        try
                        {
                            var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            t = bf.Deserialize(fs) as Classe;
                        }
                        catch
                        {
                            //error                            
                        }

                        fs.Close();
                    }
                }
                catch
                {
                    //error
                }

            if (t == null)
                t = new Classe();

            return t;
        }



    }
}