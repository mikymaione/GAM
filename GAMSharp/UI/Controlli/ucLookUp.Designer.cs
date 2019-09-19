namespace GAMSharp.UI.Controlli
{
    partial class ucLookUp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bCerca = new System.Windows.Forms.Button();
            this.eTesto = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bDettaglio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bCerca
            // 
            this.bCerca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCerca.Image = global::GAMSharp.Properties.Resources.zoom;
            this.bCerca.Location = new System.Drawing.Point(86, 0);
            this.bCerca.Name = "bCerca";
            this.bCerca.Size = new System.Drawing.Size(25, 25);
            this.bCerca.TabIndex = 1;
            this.toolTip1.SetToolTip(this.bCerca, "Ricerca");
            this.bCerca.UseVisualStyleBackColor = true;
            this.bCerca.Click += new System.EventHandler(this.bCerca_Click);
            // 
            // eTesto
            // 
            this.eTesto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eTesto.Location = new System.Drawing.Point(0, 2);
            this.eTesto.Name = "eTesto";
            this.eTesto.ReadOnly = true;
            this.eTesto.Size = new System.Drawing.Size(82, 20);
            this.eTesto.TabIndex = 0;
            this.toolTip1.SetToolTip(this.eTesto, "Cliccare sul pulsante di ricerca che si trova a destra");            
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // bDettaglio
            // 
            this.bDettaglio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));            
            this.bDettaglio.Image = global::GAMSharp.Properties.Resources.application_edit;
            this.bDettaglio.Location = new System.Drawing.Point(117, 0);
            this.bDettaglio.Name = "bDettaglio";
            this.bDettaglio.Size = new System.Drawing.Size(25, 25);
            this.bDettaglio.TabIndex = 2;
            this.toolTip1.SetToolTip(this.bDettaglio, "Vai al dettaglio");
            this.bDettaglio.UseVisualStyleBackColor = true;
            this.bDettaglio.Click += new System.EventHandler(this.bDettaglio_Click);
            // 
            // ucLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bDettaglio);
            this.Controls.Add(this.eTesto);
            this.Controls.Add(this.bCerca);
            this.Name = "ucLookUp";
            this.Size = new System.Drawing.Size(141, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCerca;
        private System.Windows.Forms.TextBox eTesto;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bDettaglio;
    }
}
