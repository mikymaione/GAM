namespace GAMSharp.UI.Base
{
    partial class cGriglia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.eFirstXRows = new System.Windows.Forms.ToolStripComboBox();
            this.gbRicerca = new System.Windows.Forms.GroupBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bNuovo = new System.Windows.Forms.ToolStripButton();
            this.bModifica = new System.Windows.Forms.ToolStripButton();
            this.bElimina = new System.Windows.Forms.ToolStripButton();
            this.bOk = new System.Windows.Forms.ToolStripButton();
            this.bRefreshGrid = new System.Windows.Forms.ToolStripButton();
            this.bAzzera = new System.Windows.Forms.Button();
            this.bCerca = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.gbRicerca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.bindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 100);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1063, 384);
            this.dataGridView1.TabIndex = 5002;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bNuovo,
            this.bModifica,
            this.bElimina,
            this.toolStripSeparator1,
            this.bOk,
            this.toolStripSeparator2,
            this.bRefreshGrid,
            this.eFirstXRows});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 484);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1063, 25);
            this.bindingNavigator1.TabIndex = 5001;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(34, 22);
            this.bindingNavigatorCountItem.Text = "di {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Numero totale di elementi";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(100, 25);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posizione attuale";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // eFirstXRows
            // 
            this.eFirstXRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eFirstXRows.Items.AddRange(new object[] {
            "50",
            "100",
            "150",
            "300",
            "500",
            "1000",
            "1500",
            "3000",
            "5000",
            "Tutti"});
            this.eFirstXRows.Name = "eFirstXRows";
            this.eFirstXRows.Size = new System.Drawing.Size(121, 25);
            this.eFirstXRows.ToolTipText = "Elementi da visualizzare";
            // 
            // gbRicerca
            // 
            this.gbRicerca.Controls.Add(this.bAzzera);
            this.gbRicerca.Controls.Add(this.bCerca);
            this.gbRicerca.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRicerca.Location = new System.Drawing.Point(0, 0);
            this.gbRicerca.Name = "gbRicerca";
            this.gbRicerca.Size = new System.Drawing.Size(1063, 100);
            this.gbRicerca.TabIndex = 5003;
            this.gbRicerca.TabStop = false;
            this.gbRicerca.Text = "Ricerca";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = global::GAMSharp.Properties.Resources.resultset_first;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = global::GAMSharp.Properties.Resources.resultset_previous;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Precedente";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = global::GAMSharp.Properties.Resources.resultset_next;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Successivo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = global::GAMSharp.Properties.Resources.resultset_last;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo";
            // 
            // bNuovo
            // 
            this.bNuovo.Image = global::GAMSharp.Properties.Resources.add;
            this.bNuovo.Name = "bNuovo";
            this.bNuovo.Size = new System.Drawing.Size(63, 22);
            this.bNuovo.Text = "&Nuovo";
            // 
            // bModifica
            // 
            this.bModifica.Image = global::GAMSharp.Properties.Resources.application_edit;
            this.bModifica.Name = "bModifica";
            this.bModifica.Size = new System.Drawing.Size(74, 22);
            this.bModifica.Text = "&Modifica";
            // 
            // bElimina
            // 
            this.bElimina.Image = global::GAMSharp.Properties.Resources.delete;
            this.bElimina.Name = "bElimina";
            this.bElimina.Size = new System.Drawing.Size(66, 22);
            this.bElimina.Text = "&Elimina";
            // 
            // bOk
            // 
            this.bOk.Enabled = false;
            this.bOk.Image = global::GAMSharp.Properties.Resources.accept_button;
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(42, 22);
            this.bOk.Text = "&Ok";
            // 
            // bRefreshGrid
            // 
            this.bRefreshGrid.Image = global::GAMSharp.Properties.Resources.update;
            this.bRefreshGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRefreshGrid.Name = "bRefreshGrid";
            this.bRefreshGrid.Size = new System.Drawing.Size(76, 22);
            this.bRefreshGrid.Text = "Aggiorna";
            this.bRefreshGrid.Click += new System.EventHandler(this.bRefreshGrid_Click);
            // 
            // bAzzera
            // 
            this.bAzzera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAzzera.Image = global::GAMSharp.Properties.Resources.broom;
            this.bAzzera.Location = new System.Drawing.Point(901, 69);
            this.bAzzera.Name = "bAzzera";
            this.bAzzera.Size = new System.Drawing.Size(75, 25);
            this.bAzzera.TabIndex = 6;
            this.bAzzera.Text = "&Azzera";
            this.bAzzera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // bCerca
            // 
            this.bCerca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCerca.Image = global::GAMSharp.Properties.Resources.zoom;
            this.bCerca.Location = new System.Drawing.Point(982, 69);
            this.bCerca.Name = "bCerca";
            this.bCerca.Size = new System.Drawing.Size(75, 25);
            this.bCerca.TabIndex = 5;
            this.bCerca.Text = "&Cerca";
            this.bCerca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // cGriglia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.gbRicerca);
            this.Name = "cGriglia";
            this.Size = new System.Drawing.Size(1063, 509);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.gbRicerca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        public System.Windows.Forms.ToolStripButton bNuovo;
        public System.Windows.Forms.ToolStripButton bModifica;
        public System.Windows.Forms.ToolStripButton bElimina;
        private System.Windows.Forms.ToolStripButton bOk;
        public System.Windows.Forms.Button bCerca;
        public System.Windows.Forms.GroupBox gbRicerca;
        public System.Windows.Forms.ToolStripComboBox eFirstXRows;
        private System.Windows.Forms.Button bAzzera;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bRefreshGrid;
    }
}
