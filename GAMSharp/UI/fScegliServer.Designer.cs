namespace GAMSharp.UI
{
    partial class fScegliServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fScegliServer));
            this.eServers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.bCerca = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // eServers
            // 
            this.eServers.Location = new System.Drawing.Point(15, 25);
            this.eServers.Name = "eServers";
            this.eServers.Size = new System.Drawing.Size(266, 21);
            this.eServers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server a cui connettersi";
            // 
            // bOK
            // 
            this.bOK.Image = global::GAMSharp.Properties.Resources.accept_button;
            this.bOK.Location = new System.Drawing.Point(15, 52);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 25);
            this.bOK.TabIndex = 2;
            this.bOK.Text = "&Ok";
            this.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCerca
            // 
            this.bCerca.Image = global::GAMSharp.Properties.Resources.server_find;
            this.bCerca.Location = new System.Drawing.Point(287, 22);
            this.bCerca.Name = "bCerca";
            this.bCerca.Size = new System.Drawing.Size(105, 25);
            this.bCerca.TabIndex = 1;
            this.bCerca.Text = "&Cerca servers";
            this.bCerca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bCerca.UseVisualStyleBackColor = true;
            this.bCerca.Click += new System.EventHandler(this.bCerca_Click);
            // 
            // fScegliServer
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 85);
            this.Controls.Add(this.bCerca);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eServers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fScegliServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scegli il server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox eServers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCerca;
    }
}