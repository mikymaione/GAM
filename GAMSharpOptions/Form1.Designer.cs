namespace GAMSharpOptions
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.eDBFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.eDBBKOrario = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.eDBBKGiorni = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.eUPDOrario = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.eUPDGiorni = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label7 = new System.Windows.Forms.Label();
            this.eDocumentaleFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bScegliCartellaDocumentale = new System.Windows.Forms.Button();
            this.bCreaCartellaCondivisa = new System.Windows.Forms.ToolStripButton();
            this.bCreate = new System.Windows.Forms.ToolStripButton();
            this.bEventViewer = new System.Windows.Forms.ToolStripButton();
            this.bWindowsTaskScheduler = new System.Windows.Forms.ToolStripButton();
            this.bScegliCartellaDB = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eDBBKGiorni)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eUPDGiorni)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // eDBFolder
            // 
            this.eDBFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eDBFolder.Location = new System.Drawing.Point(182, 82);
            this.eDBFolder.Name = "eDBFolder";
            this.eDBFolder.ReadOnly = true;
            this.eDBFolder.Size = new System.Drawing.Size(483, 20);
            this.eDBFolder.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cartella del Database";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.eDBBKOrario);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.eDBBKGiorni);
            this.groupBox1.Location = new System.Drawing.Point(15, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 84);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Backup";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Orario";
            // 
            // eDBBKOrario
            // 
            this.eDBBKOrario.Location = new System.Drawing.Point(111, 52);
            this.eDBBKOrario.Mask = "00:00";
            this.eDBBKOrario.Name = "eDBBKOrario";
            this.eDBBKOrario.Size = new System.Drawing.Size(71, 20);
            this.eDBBKOrario.TabIndex = 1;
            this.eDBBKOrario.Text = "0100";
            this.eDBBKOrario.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Intervallo in giorni";
            // 
            // eDBBKGiorni
            // 
            this.eDBBKGiorni.Location = new System.Drawing.Point(111, 26);
            this.eDBBKGiorni.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.eDBBKGiorni.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.eDBBKGiorni.Name = "eDBBKGiorni";
            this.eDBBKGiorni.Size = new System.Drawing.Size(71, 20);
            this.eDBBKGiorni.TabIndex = 0;
            this.eDBBKGiorni.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.eUPDOrario);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.eUPDGiorni);
            this.groupBox2.Location = new System.Drawing.Point(218, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 84);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Software update";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Orario";
            // 
            // eUPDOrario
            // 
            this.eUPDOrario.Location = new System.Drawing.Point(111, 52);
            this.eUPDOrario.Mask = "00:00";
            this.eUPDOrario.Name = "eUPDOrario";
            this.eUPDOrario.Size = new System.Drawing.Size(71, 20);
            this.eUPDOrario.TabIndex = 1;
            this.eUPDOrario.Text = "0200";
            this.eUPDOrario.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Intervallo in giorni";
            // 
            // eUPDGiorni
            // 
            this.eUPDGiorni.Location = new System.Drawing.Point(111, 26);
            this.eUPDGiorni.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.eUPDGiorni.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.eUPDGiorni.Name = "eUPDGiorni";
            this.eUPDGiorni.Size = new System.Drawing.Size(71, 20);
            this.eUPDGiorni.TabIndex = 0;
            this.eUPDGiorni.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bCreaCartellaCondivisa,
            this.bCreate,
            this.bEventViewer,
            this.bWindowsTaskScheduler});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(708, 38);
            this.toolStrip1.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Cartella dell\'archivio documentale";
            // 
            // eDocumentaleFolder
            // 
            this.eDocumentaleFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eDocumentaleFolder.Location = new System.Drawing.Point(182, 108);
            this.eDocumentaleFolder.Name = "eDocumentaleFolder";
            this.eDocumentaleFolder.ReadOnly = true;
            this.eDocumentaleFolder.Size = new System.Drawing.Size(483, 20);
            this.eDocumentaleFolder.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(659, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Le funzioni di aggiornamento automatico del programma e di backup del Database vengono pianificate tramite il Windows Task Scheduler.";            
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GAMSharpOptions.Properties.Resources.information;
            this.pictureBox1.Location = new System.Drawing.Point(15, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // bScegliCartellaDocumentale
            // 
            this.bScegliCartellaDocumentale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bScegliCartellaDocumentale.Image = global::GAMSharpOptions.Properties.Resources.folder_page;
            this.bScegliCartellaDocumentale.Location = new System.Drawing.Point(671, 106);
            this.bScegliCartellaDocumentale.Name = "bScegliCartellaDocumentale";
            this.bScegliCartellaDocumentale.Size = new System.Drawing.Size(25, 25);
            this.bScegliCartellaDocumentale.TabIndex = 3;
            this.bScegliCartellaDocumentale.UseVisualStyleBackColor = true;
            this.bScegliCartellaDocumentale.Click += new System.EventHandler(this.bScegliCartellaDocumentale_Click);
            // 
            // bCreaCartellaCondivisa
            // 
            this.bCreaCartellaCondivisa.Image = global::GAMSharpOptions.Properties.Resources.network_folder;
            this.bCreaCartellaCondivisa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bCreaCartellaCondivisa.Name = "bCreaCartellaCondivisa";
            this.bCreaCartellaCondivisa.Size = new System.Drawing.Size(103, 35);
            this.bCreaCartellaCondivisa.Text = "Condividi cartella";
            this.bCreaCartellaCondivisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bCreaCartellaCondivisa.ToolTipText = "Crea la cartella condivisa";
            this.bCreaCartellaCondivisa.Click += new System.EventHandler(this.bCreaCartellaCondivisa_Click);
            // 
            // bCreate
            // 
            this.bCreate.Image = global::GAMSharpOptions.Properties.Resources.add;
            this.bCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(64, 35);
            this.bCreate.Text = "Crea tasks";
            this.bCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // bEventViewer
            // 
            this.bEventViewer.Image = global::GAMSharpOptions.Properties.Resources.error_log;
            this.bEventViewer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bEventViewer.Name = "bEventViewer";
            this.bEventViewer.Size = new System.Drawing.Size(78, 35);
            this.bEventViewer.Text = "Event Viewer";
            this.bEventViewer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bEventViewer.ToolTipText = "Mostra l\'Event Viewer";
            this.bEventViewer.Click += new System.EventHandler(this.bEventViewer_Click);
            // 
            // bWindowsTaskScheduler
            // 
            this.bWindowsTaskScheduler.Image = global::GAMSharpOptions.Properties.Resources.clock_151;
            this.bWindowsTaskScheduler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bWindowsTaskScheduler.Name = "bWindowsTaskScheduler";
            this.bWindowsTaskScheduler.Size = new System.Drawing.Size(89, 35);
            this.bWindowsTaskScheduler.Text = "Task Scheduler";
            this.bWindowsTaskScheduler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bWindowsTaskScheduler.ToolTipText = "Mostra il Windows Task Scheduler";
            this.bWindowsTaskScheduler.Click += new System.EventHandler(this.bWindowsTaskScheduler_Click);
            // 
            // bScegliCartellaDB
            // 
            this.bScegliCartellaDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bScegliCartellaDB.Image = global::GAMSharpOptions.Properties.Resources.folder_database;
            this.bScegliCartellaDB.Location = new System.Drawing.Point(671, 80);
            this.bScegliCartellaDB.Name = "bScegliCartellaDB";
            this.bScegliCartellaDB.Size = new System.Drawing.Size(25, 25);
            this.bScegliCartellaDB.TabIndex = 1;
            this.bScegliCartellaDB.UseVisualStyleBackColor = true;
            this.bScegliCartellaDB.Click += new System.EventHandler(this.bScegliCartellaDB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 248);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bScegliCartellaDocumentale);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.eDocumentaleFolder);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bScegliCartellaDB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eDBFolder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GAM# - Opzioni";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eDBBKGiorni)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eUPDGiorni)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox eDBFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bScegliCartellaDB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown eDBBKGiorni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox eDBBKOrario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox eUPDOrario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown eUPDGiorni;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bCreate;
        private System.Windows.Forms.ToolStripButton bEventViewer;
        private System.Windows.Forms.ToolStripButton bWindowsTaskScheduler;
        private System.Windows.Forms.ToolStripButton bCreaCartellaCondivisa;
        private System.Windows.Forms.Button bScegliCartellaDocumentale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox eDocumentaleFolder;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

