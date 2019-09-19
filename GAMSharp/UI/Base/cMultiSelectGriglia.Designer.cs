using System.Windows.Forms;

namespace GAMSharp.UI.Base
{
    partial class cMultiSelectGriglia
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bSelezionaTutti = new System.Windows.Forms.ToolStripButton();
            this.bDeselezionaTutti = new System.Windows.Forms.ToolStripButton();
            this.bNuovo = new System.Windows.Forms.ToolStripButton();
            this.eFirstXRows = new System.Windows.Forms.ToolStripComboBox();
            this.gbRicerca = new System.Windows.Forms.GroupBox();
            this.bAzzera = new System.Windows.Forms.Button();
            this.bCerca = new System.Windows.Forms.Button();
            this.bSalva = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.gbRicerca.SuspendLayout();
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
            this.dataGridView1.Size = new System.Drawing.Size(731, 348);
            this.dataGridView1.TabIndex = 5005;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "di {0}";
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
            this.bSelezionaTutti,
            this.bDeselezionaTutti,
            this.bNuovo,
            this.bSalva,
            this.eFirstXRows});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 448);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(731, 25);
            this.bindingNavigator1.TabIndex = 5004;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(34, 22);
            this.bindingNavigatorCountItem.Text = "di {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Numero totale di elementi";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = global::GAMSharp.Properties.Resources.resultset_first;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = global::GAMSharp.Properties.Resources.resultset_previous;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Precedente";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posizione attuale";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = global::GAMSharp.Properties.Resources.resultset_next;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Successivo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = global::GAMSharp.Properties.Resources.resultset_last;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bSelezionaTutti
            // 
            this.bSelezionaTutti.Image = global::GAMSharp.Properties.Resources.check_box;
            this.bSelezionaTutti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSelezionaTutti.Name = "bSelezionaTutti";
            this.bSelezionaTutti.Size = new System.Drawing.Size(101, 22);
            this.bSelezionaTutti.Text = "Seleziona &tutti";
            // 
            // bDeselezionaTutti
            // 
            this.bDeselezionaTutti.Image = global::GAMSharp.Properties.Resources.check_box_uncheck;
            this.bDeselezionaTutti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDeselezionaTutti.Name = "bDeselezionaTutti";
            this.bDeselezionaTutti.Size = new System.Drawing.Size(114, 22);
            this.bDeselezionaTutti.Text = "&Deseleziona tutti";
            // 
            // bNuovo
            // 
            this.bNuovo.Image = global::GAMSharp.Properties.Resources.add;
            this.bNuovo.Name = "bNuovo";
            this.bNuovo.RightToLeftAutoMirrorImage = true;
            this.bNuovo.Size = new System.Drawing.Size(63, 22);
            this.bNuovo.Text = "&Nuovo";
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
            this.eFirstXRows.Size = new System.Drawing.Size(75, 25);
            this.eFirstXRows.ToolTipText = "Elementi da visualizzare";
            // 
            // gbRicerca
            // 
            this.gbRicerca.Controls.Add(this.bAzzera);
            this.gbRicerca.Controls.Add(this.bCerca);
            this.gbRicerca.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRicerca.Location = new System.Drawing.Point(0, 0);
            this.gbRicerca.Name = "gbRicerca";
            this.gbRicerca.Size = new System.Drawing.Size(731, 100);
            this.gbRicerca.TabIndex = 5006;
            this.gbRicerca.TabStop = false;
            this.gbRicerca.Text = "Ricerca";
            // 
            // bAzzera
            // 
            this.bAzzera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAzzera.Image = global::GAMSharp.Properties.Resources.broom;
            this.bAzzera.Location = new System.Drawing.Point(569, 69);
            this.bAzzera.Name = "bAzzera";
            this.bAzzera.Size = new System.Drawing.Size(75, 25);
            this.bAzzera.TabIndex = 6;
            this.bAzzera.Text = "&Azzera";
            this.bAzzera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bAzzera.UseVisualStyleBackColor = true;
            // 
            // bCerca
            // 
            this.bCerca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCerca.Image = global::GAMSharp.Properties.Resources.zoom;
            this.bCerca.Location = new System.Drawing.Point(650, 69);
            this.bCerca.Name = "bCerca";
            this.bCerca.Size = new System.Drawing.Size(75, 25);
            this.bCerca.TabIndex = 5;
            this.bCerca.Text = "&Cerca";
            this.bCerca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bCerca.UseVisualStyleBackColor = true;
            // 
            // bSalva
            // 
            this.bSalva.Image = global::GAMSharp.Properties.Resources.diskette;
            this.bSalva.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSalva.Name = "bSalva";
            this.bSalva.Size = new System.Drawing.Size(54, 22);
            this.bSalva.Text = "&Salva";
            // 
            // cMultiSelectGriglia
            // 
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.gbRicerca);
            this.Name = "cMultiSelectGriglia";
            this.Size = new System.Drawing.Size(731, 473);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.gbRicerca.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BindingSource bindingSource1;
        private DataGridView dataGridView1;
        private BindingNavigator bindingNavigator1;
        private ToolStripLabel bindingNavigatorCountItem;
        private ToolStripButton bindingNavigatorMoveFirstItem;
        private ToolStripButton bindingNavigatorMovePreviousItem;
        private ToolStripSeparator bindingNavigatorSeparator;
        private ToolStripTextBox bindingNavigatorPositionItem;
        private ToolStripSeparator bindingNavigatorSeparator1;
        private ToolStripButton bindingNavigatorMoveNextItem;
        private ToolStripButton bindingNavigatorMoveLastItem;
        private ToolStripSeparator bindingNavigatorSeparator2;
        private ToolStripButton bNuovo;
        public ToolStripComboBox eFirstXRows;
        public GroupBox gbRicerca;
        private Button bAzzera;
        public Button bCerca;
        private ToolStripButton bSelezionaTutti;
        private ToolStripButton bDeselezionaTutti;
        private ToolStripButton bSalva;
    }
}