namespace GAMSharp.UI.Controlli
{
    partial class ucFileChoose
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
            this.eFile = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bVedi = new System.Windows.Forms.Button();
            this.bChoose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // eFile
            // 
            this.eFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eFile.Location = new System.Drawing.Point(0, 2);
            this.eFile.Name = "eFile";            
            this.eFile.ReadOnly = true;
            this.eFile.Size = new System.Drawing.Size(100, 20);
            this.eFile.TabIndex = 0;
            // 
            // bVedi
            // 
            this.bVedi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bVedi.Image = global::GAMSharp.Properties.Resources.folder_page;
            this.bVedi.Location = new System.Drawing.Point(137, 0);
            this.bVedi.Name = "bVedi";
            this.bVedi.Size = new System.Drawing.Size(25, 25);
            this.bVedi.TabIndex = 2;
            this.toolTip1.SetToolTip(this.bVedi, "Vedi il file");
            this.bVedi.UseVisualStyleBackColor = true;
            this.bVedi.Click += new System.EventHandler(this.bVedi_Click);
            // 
            // bChoose
            // 
            this.bChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bChoose.Image = global::GAMSharp.Properties.Resources.page_add;
            this.bChoose.Location = new System.Drawing.Point(106, 0);
            this.bChoose.Name = "bChoose";
            this.bChoose.Size = new System.Drawing.Size(25, 25);
            this.bChoose.TabIndex = 1;
            this.toolTip1.SetToolTip(this.bChoose, "Scegli un file");
            this.bChoose.UseVisualStyleBackColor = true;
            this.bChoose.Click += new System.EventHandler(this.bChoose_Click);
            // 
            // ucFileChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bVedi);
            this.Controls.Add(this.bChoose);
            this.Controls.Add(this.eFile);
            this.Name = "ucFileChoose";
            this.Size = new System.Drawing.Size(161, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox eFile;
        private System.Windows.Forms.Button bChoose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bVedi;
    }
}
