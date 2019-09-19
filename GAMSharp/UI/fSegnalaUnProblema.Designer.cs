namespace GAMSharp.UI
{
    partial class fSegnalaUnProblema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSegnalaUnProblema));
            this.eProblema = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bInvia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // eProblema
            // 
            this.eProblema.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eProblema.Location = new System.Drawing.Point(15, 31);
            this.eProblema.Multiline = true;
            this.eProblema.Name = "eProblema";
            this.eProblema.Size = new System.Drawing.Size(597, 367);
            this.eProblema.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Problema:";
            // 
            // bInvia
            // 
            this.bInvia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bInvia.Image = global::GAMSharp.Properties.Resources.email;
            this.bInvia.Location = new System.Drawing.Point(15, 404);
            this.bInvia.Name = "bInvia";
            this.bInvia.Size = new System.Drawing.Size(75, 25);
            this.bInvia.TabIndex = 1;
            this.bInvia.Text = "&Invia";
            this.bInvia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bInvia.UseVisualStyleBackColor = true;
            this.bInvia.Click += new System.EventHandler(this.bInvia_Click);
            // 
            // fSegnalaUnProblema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eProblema);
            this.Controls.Add(this.bInvia);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "fSegnalaUnProblema";
            this.Text = "Segnala un problema";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox eProblema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bInvia;
    }
}