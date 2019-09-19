/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Windows.Forms;

namespace GAMSharp.UI.Ente
{
    sealed class ComboFiller
    {

        public void Fill_eTipo(ref ComboBox c, bool Tutti)
        {
            if (Tutti)
                c.Items.Add(new GB.cComboItem("%%", "Tutti"));

            c.Items.Add(new GB.cComboItem("AC", "Associazione di categoria"));
            c.Items.Add(new GB.cComboItem("AL", "ASL"));
            c.Items.Add(new GB.cComboItem("AS", "Associazione"));

            c.Items.Add(new GB.cComboItem("CF", "Ente confessionale"));
            c.Items.Add(new GB.cComboItem("CP", "Cooperativa"));
            c.Items.Add(new GB.cComboItem("CO", "Comune"));
            c.Items.Add(new GB.cComboItem("CR", "Congregazione religiosa"));

            c.Items.Add(new GB.cComboItem("EP", "Ente pubblico"));
            c.Items.Add(new GB.cComboItem("ER", "Ente religioso"));

            c.Items.Add(new GB.cComboItem("FO", "Fondazione"));

            c.Items.Add(new GB.cComboItem("IS", "Comunità isolana"));

            c.Items.Add(new GB.cComboItem("ME", "Città metropolitana"));
            c.Items.Add(new GB.cComboItem("MI", "Ministero"));
            c.Items.Add(new GB.cComboItem("MO", "Comunità montanta"));

            c.Items.Add(new GB.cComboItem("PF", "Persona fisica"));
            c.Items.Add(new GB.cComboItem("PR", "Provincia"));
            c.Items.Add(new GB.cComboItem("PV", "Ente privato"));

            c.Items.Add(new GB.cComboItem("OS", "Ospedale"));

            c.Items.Add(new GB.cComboItem("SC", "Scuola elementare"));
            c.Items.Add(new GB.cComboItem("SI", "Sindacato"));
            c.Items.Add(new GB.cComboItem("SM", "Scuola media inferiore"));
            c.Items.Add(new GB.cComboItem("SO", "Società"));
            c.Items.Add(new GB.cComboItem("SS", "Scuola media superiore"));

            c.Items.Add(new GB.cComboItem("UC", "Unione di comuni"));
            c.Items.Add(new GB.cComboItem("UN", "Università"));
        }


    }
}