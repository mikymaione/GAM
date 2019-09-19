namespace GAMSharp.UI
{
    partial class fLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ePsw = new System.Windows.Forms.TextBox();
            this.eEmail = new System.Windows.Forms.TextBox();
            this.bLogin = new System.Windows.Forms.Button();
            this.bRecuperaPsw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // ePsw
            // 
            this.ePsw.Location = new System.Drawing.Point(71, 38);
            this.ePsw.MaxLength = 40;
            this.ePsw.Name = "ePsw";
            this.ePsw.Size = new System.Drawing.Size(167, 20);
            this.ePsw.TabIndex = 1;            
            this.ePsw.UseSystemPasswordChar = true;
            // 
            // eEmail
            // 
            this.eEmail.Location = new System.Drawing.Point(71, 12);
            this.eEmail.MaxLength = 200;
            this.eEmail.Name = "eEmail";
            this.eEmail.Size = new System.Drawing.Size(167, 20);
            this.eEmail.TabIndex = 0;            
            // 
            // bLogin
            // 
            this.bLogin.Image = global::GAMSharp.Properties.Resources.key;
            this.bLogin.Location = new System.Drawing.Point(164, 73);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(74, 25);
            this.bLogin.TabIndex = 2;
            this.bLogin.Text = "&Login";
            this.bLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // bRecuperaPsw
            // 
            this.bRecuperaPsw.Image = global::GAMSharp.Properties.Resources.email;
            this.bRecuperaPsw.Location = new System.Drawing.Point(15, 73);
            this.bRecuperaPsw.Name = "bRecuperaPsw";
            this.bRecuperaPsw.Size = new System.Drawing.Size(143, 25);
            this.bRecuperaPsw.TabIndex = 3;
            this.bRecuperaPsw.Text = "&Recupera password";
            this.bRecuperaPsw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bRecuperaPsw.UseVisualStyleBackColor = true;
            this.bRecuperaPsw.Click += new System.EventHandler(this.bRecuperaPsw_Click);
            // 
            // fLogin
            // 
            this.AcceptButton = this.bLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 114);
            this.Controls.Add(this.bRecuperaPsw);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.eEmail);
            this.Controls.Add(this.ePsw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ePsw;
        private System.Windows.Forms.TextBox eEmail;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.Button bRecuperaPsw;
    }
}