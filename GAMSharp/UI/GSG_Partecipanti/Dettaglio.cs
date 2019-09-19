/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Collections.Generic;
using System.Windows.Forms;
using GAMSharp.DB.DataWrapper.Base;
using GAMSharp.GB;

namespace GAMSharp.UI.GSG_Partecipanti
{
#if DEBUG
    sealed class Dettaglio : Base.fBaseDettaglio<DB.DataWrapper.Tabelle.GSG_Partecipanti>
#else
    sealed class Dettaglio : UI.Base.fFakeDettaglio
#endif  
    {
        private ImageList ilIcone;
        private System.ComponentModel.IContainer components;
        private Controlli.ucLookUp eCF;
        private Label label2;
        private int IDGruppoSostegnoG = -1;


#if DEBUG
        protected override cBaseEntity<DB.DataWrapper.Tabelle.GSG_Partecipanti> getEntita()
        {
            return new DB.DataWrapper.cGSG_Partecipanti();
        }

        protected override void setForm(DB.DataWrapper.Tabelle.GSG_Partecipanti e)
        {
            eCF.Value = e.CF;
            eCF.Text = e.ExRicerca.RagioneSociale;
        }

        protected override void setFormNew()
        {

        }

        protected override List<string> ValidateForm()
        {
            var z = new List<string>();

            if (eCF.Value == null)
                z.Add("Selezionare una persona");

            return z;
        }

        protected override DB.DataWrapper.Tabelle.GSG_Partecipanti getForm()
        {
            return new DB.DataWrapper.Tabelle.GSG_Partecipanti()
            {
                ID = cGB.ObjectToInt(PrimaryKey, -1),
                IDGruppoSostegnoG = IDGruppoSostegnoG,
                CF = cGB.ObjectToString(eCF.Value)
            };
        }

        protected override Control[] getControlliSoloInserimento(DB.DataWrapper.Tabelle.GSG_Partecipanti entita)
        {
            return null;
        }
#endif

        private void eCF_RicercaRichiesta()
        {
            using (var r = new Persona.Ricerca())
                eCF.Elemento = r.LookUp(Persona.Ricerca.eQuery.GSG_Partecipanti);
        }

        private void eCF_DettaglioRichiesto(object Key)
        {
#if DEBUG
            using (var d = new Persona.Dettaglio())
                if (d.ShowDialog(Key) == DialogResult.OK)
                    eCF.Text = RiCaricaEntita().ExRicerca.RagioneSociale;
#endif
        }

        internal Dettaglio(int IDGruppoSostegnoG_) : this()
        {
            IDGruppoSostegnoG = IDGruppoSostegnoG_;
        }

        internal Dettaglio()
        {
            InitializeComponent();

            eCF.RicercaRichiesta += eCF_RicercaRichiesta;
            eCF.DettaglioRichiesto += eCF_DettaglioRichiesto;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dettaglio));
            this.ilIcone = new System.Windows.Forms.ImageList(this.components);
            this.eCF = new GAMSharp.UI.Controlli.ucLookUp();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ilIcone
            // 
            this.ilIcone.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcone.ImageStream")));
            this.ilIcone.TransparentColor = System.Drawing.Color.Transparent;
            this.ilIcone.Images.SetKeyName(0, "to_do_list_checked_all.png");
            this.ilIcone.Images.SetKeyName(1, "users_5.png");
            // 
            // eCF
            // 
            this.eCF.Elemento = ((System.Tuple<object, string>)(resources.GetObject("eCF.Elemento")));
            this.eCF.Location = new System.Drawing.Point(79, 33);
            this.eCF.Name = "eCF";
            this.eCF.ReadOnly = false;
            this.eCF.Size = new System.Drawing.Size(328, 25);
            this.eCF.TabIndex = 0;
            this.eCF.Tipo = null;
            this.eCF.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Persona";
            // 
            // Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(424, 67);
            this.Controls.Add(this.eCF);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dettaglio";
            this.Text = "Partecipante gruppo sostegno genitorialità";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.eCF, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}