namespace GAMSharp.UI.Base
{
    partial class fBaseDettaglio<TableEntity> where TableEntity : DB.DataWrapper.Tabelle.TabellaBase, new()
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
            this.tbComandi = new System.Windows.Forms.MenuStrip();
            this.bFile = new System.Windows.Forms.ToolStripMenuItem();
            this.bSalva = new System.Windows.Forms.ToolStripMenuItem();
            this.bSalva2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bElimina2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bChiudiFinestra = new System.Windows.Forms.ToolStripMenuItem();
            this.bInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.lDataCreazione = new System.Windows.Forms.ToolStripMenuItem();
            this.lDataModifica = new System.Windows.Forms.ToolStripMenuItem();
            this.lCFCreazione = new System.Windows.Forms.ToolStripMenuItem();
            this.lCFModifica = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbComandi.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbComandi
            // 
            this.tbComandi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bFile,
            this.bInfo});
            this.tbComandi.Location = new System.Drawing.Point(0, 0);
            this.tbComandi.Name = "tbComandi";
            this.tbComandi.ShowItemToolTips = true;
            this.tbComandi.Size = new System.Drawing.Size(304, 24);
            this.tbComandi.TabIndex = 1;
            // 
            // bFile
            // 
            this.bFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSalva,
            this.bSalva2,
            this.toolStripSeparator2,
            this.bElimina2,
            this.toolStripSeparator1,
            this.bChiudiFinestra});
            this.bFile.Image = global::GAMSharp.Properties.Resources.page_edit;
            this.bFile.Name = "bFile";
            this.bFile.Size = new System.Drawing.Size(53, 20);
            this.bFile.Text = "&File";
            // 
            // bSalva
            // 
            this.bSalva.Image = global::GAMSharp.Properties.Resources.save_close;
            this.bSalva.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSalva.Name = "bSalva";
            this.bSalva.Size = new System.Drawing.Size(182, 22);
            this.bSalva.Text = "&Salva e chiudi";
            this.bSalva.ToolTipText = "Salva e chiudi la finestra";
            this.bSalva.Click += new System.EventHandler(this.bSalva_Click);
            // 
            // bSalva2
            // 
            this.bSalva2.Image = global::GAMSharp.Properties.Resources.diskette;
            this.bSalva2.Name = "bSalva2";
            this.bSalva2.Size = new System.Drawing.Size(182, 22);
            this.bSalva2.Text = "S&alva senza chiudere";
            this.bSalva2.ToolTipText = "Salva senza chiudere la finestra";
            this.bSalva2.Click += new System.EventHandler(this.bSalva2_Click);
            // 
            // bElimina2
            // 
            this.bElimina2.Enabled = false;
            this.bElimina2.Image = global::GAMSharp.Properties.Resources.delete;
            this.bElimina2.Name = "bElimina2";
            this.bElimina2.Size = new System.Drawing.Size(182, 22);
            this.bElimina2.Text = "&Elimina";
            this.bElimina2.ToolTipText = "Elimina";
            this.bElimina2.Click += new System.EventHandler(this.bElimina2_Click);
            // 
            // bChiudiFinestra
            // 
            this.bChiudiFinestra.Image = global::GAMSharp.Properties.Resources.cancel;
            this.bChiudiFinestra.Name = "bChiudiFinestra";
            this.bChiudiFinestra.Size = new System.Drawing.Size(182, 22);
            this.bChiudiFinestra.Text = "Chiudi finestra";
            this.bChiudiFinestra.Click += new System.EventHandler(this.bChiudiFinestra_Click);
            // 
            // bInfo
            // 
            this.bInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lDataCreazione,
            this.lDataModifica,
            this.lCFCreazione,
            this.lCFModifica});
            this.bInfo.Enabled = false;
            this.bInfo.Image = global::GAMSharp.Properties.Resources.information;
            this.bInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bInfo.Name = "bInfo";
            this.bInfo.Size = new System.Drawing.Size(102, 20);
            this.bInfo.Text = "&Informazioni";
            // 
            // lDataCreazione
            // 
            this.lDataCreazione.Image = global::GAMSharp.Properties.Resources.calendar_add;
            this.lDataCreazione.Name = "lDataCreazione";
            this.lDataCreazione.Size = new System.Drawing.Size(180, 22);
            this.lDataCreazione.Text = "toolStripMenuItem1";
            // 
            // lDataModifica
            // 
            this.lDataModifica.Image = global::GAMSharp.Properties.Resources.calendar_edit;
            this.lDataModifica.Name = "lDataModifica";
            this.lDataModifica.Size = new System.Drawing.Size(180, 22);
            this.lDataModifica.Text = "toolStripMenuItem2";
            // 
            // lCFCreazione
            // 
            this.lCFCreazione.Image = global::GAMSharp.Properties.Resources.user_add;
            this.lCFCreazione.Name = "lCFCreazione";
            this.lCFCreazione.Size = new System.Drawing.Size(180, 22);
            this.lCFCreazione.Text = "toolStripMenuItem3";
            // 
            // lCFModifica
            // 
            this.lCFModifica.Image = global::GAMSharp.Properties.Resources.user_edit;
            this.lCFModifica.Name = "lCFModifica";
            this.lCFModifica.Size = new System.Drawing.Size(180, 22);
            this.lCFModifica.Text = "toolStripMenuItem4";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // fBaseDettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 185);
            this.Controls.Add(this.tbComandi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "fBaseDettaglio";
            this.Text = "Dettaglio ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fBaseDettaglio_FormClosing);
            this.tbComandi.ResumeLayout(false);
            this.tbComandi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ToolStripMenuItem bFile;
        public System.Windows.Forms.ToolStripMenuItem bSalva;
        public System.Windows.Forms.ToolStripMenuItem bSalva2;
        public System.Windows.Forms.ToolStripMenuItem bElimina2;
        public System.Windows.Forms.ToolStripMenuItem bInfo;
        public System.Windows.Forms.ToolStripMenuItem lDataCreazione;
        public System.Windows.Forms.ToolStripMenuItem lDataModifica;
        public System.Windows.Forms.ToolStripMenuItem lCFCreazione;
        public System.Windows.Forms.ToolStripMenuItem lCFModifica;
        public System.Windows.Forms.MenuStrip tbComandi;
        public System.Windows.Forms.ToolStripMenuItem bChiudiFinestra;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}