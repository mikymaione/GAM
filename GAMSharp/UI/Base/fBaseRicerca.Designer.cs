namespace GAMSharp.UI.Base
{
    partial class fBaseRicerca<TableEntity, TableEntitySearch> where TableEntity : DB.DataWrapper.Tabelle.TabellaBase, new() where TableEntitySearch : DB.DataWrapper.Tabelle.TabellaBase, new()
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Griglia = new GAMSharp.UI.Base.cGriglia();
            this.SuspendLayout();
            // 
            // Griglia
            // 
            this.Griglia.Dock = System.Windows.Forms.DockStyle.Fill;            
            this.Griglia.Name = "Griglia";            
            this.Griglia.TabIndex = 0;
            this.Griglia.OkClick += new GAMSharp.UI.Base.Base.cbGriglia.OkClickEventHandler(this.Griglia_OkClick);
            this.Griglia.CercaClick += new GAMSharp.UI.Base.Base.cbGriglia.CercaClickEventHandler(this.Griglia_CercaClick);
            this.Griglia.ModificaClick += new GAMSharp.UI.Base.Base.cbGriglia.ModificaClickEventHandler(this.Griglia_ModificaClick);
            this.Griglia.NuovoClick += new GAMSharp.UI.Base.Base.cbGriglia.NuovoClickEventHandler(this.Griglia_NuovoClick);
            this.Griglia.EliminaClick += new GAMSharp.UI.Base.Base.cbGriglia.EliminaClickEventHandler(this.Griglia_EliminaClick);
            this.Griglia.GrigliaDoppioClick += new GAMSharp.UI.Base.Base.cbGriglia.GrigliaDoppioClickEventHandler(this.Griglia_GrigliaDoppioClick);
            // 
            // fBaseRicerca
            //             
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.Griglia);
            this.Name = "fBaseRicerca";
            this.Text = "Ricerca";
            this.Load += new System.EventHandler(this.fBaseRicerca_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal cGriglia Griglia;
    }
}