/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Windows.Forms;

namespace GAMSharp.UI.Controlli
{
    public partial class ucLookUp : UserControl
    {

        internal delegate void RicercaRichiesta_EventHandler();
        internal event RicercaRichiesta_EventHandler RicercaRichiesta;

        internal delegate void DettaglioRichiesto_EventHandler(object Key);
        internal event DettaglioRichiesto_EventHandler DettaglioRichiesto;

        private bool ReadOnly_ = false;
        private object Value_;

        public string Tipo { get; set; }

        public Tuple<object, string> Elemento
        {
            get
            {
                return new Tuple<object, string>(Value, Text);
            }
            set
            {
                if (value == null)
                {
                    Value = null;
                    Text = "";
                }
                else
                {
                    Value = value.Item1;
                    Text = value.Item2;
                }
            }
        }

        public bool ReadOnly
        {
            get
            {
                return ReadOnly_;
            }
            set
            {
                ReadOnly_ = value;
                bCerca.Enabled = !value;                
            }
        }

        public object Value
        {
            get
            {
                if ((Value_ == null || Value_.Equals("")) && Text != null && Text.Length > 0)
                    return Text;

                return Value_;
            }
            set
            {
                Value_ = value;
            }
        }

        public new string Text
        {
            get
            {
                return this.eTesto.Text;
            }
            set
            {
                this.eTesto.Text = value;
            }
        }

        public ucLookUp()
        {
            InitializeComponent();

            eTesto.ReadOnly = true;
        }

        public void ClearAll()
        {
            Tipo = "";
            Text = "";
            Value = null;
        }

        public virtual void OnRicercaRichiesta()
        {
            RicercaRichiesta_EventHandler handler = RicercaRichiesta;

            if (handler != null)
                handler();
        }

        public virtual void OnDettaglioRichiesto()
        {
            DettaglioRichiesto_EventHandler handler = DettaglioRichiesto;

            if (handler != null)
                handler(Value);
        }

        private void bCerca_Click(object sender, EventArgs e)
        {
            OnRicercaRichiesta();
        }

        private void bDettaglio_Click(object sender, EventArgs e)
        {
            MostraDettaglio();
        }

        private void MostraDettaglio()
        {
            if (Value != null)
                if (!Value.Equals(""))
                    OnDettaglioRichiesto();
        }


    }
}