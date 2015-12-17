namespace FormaSud
{
    partial class SortSud
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
            this.components = new System.ComponentModel.Container();
            this.dataGridSud = new System.Windows.Forms.DataGridView();
            this.nazivDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ulicaIKucniBrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kategorijaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nadredeniDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kategorijaSudaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mjestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sud2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sudBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cbSort1 = new System.Windows.Forms.ComboBox();
            this.cbSort11 = new System.Windows.Forms.ComboBox();
            this.cbSort2 = new System.Windows.Forms.ComboBox();
            this.cbSort22 = new System.Windows.Forms.ComboBox();
            this.cbSort3 = new System.Windows.Forms.ComboBox();
            this.cbSort33 = new System.Windows.Forms.ComboBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.tbTrazi = new System.Windows.Forms.TextBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.sudBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxFilter = new System.Windows.Forms.ListBox();
            this.gbSort = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sudBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sudBindingSource)).BeginInit();
            this.gbSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridSud
            // 
            this.dataGridSud.AutoGenerateColumns = false;
            this.dataGridSud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSud.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nazivDataGridViewTextBoxColumn,
            this.ulicaIKucniBrDataGridViewTextBoxColumn,
            this.pBrDataGridViewTextBoxColumn,
            this.kategorijaDataGridViewTextBoxColumn,
            this.nadredeniDataGridViewTextBoxColumn,
            this.kategorijaSudaDataGridViewTextBoxColumn,
            this.mjestoDataGridViewTextBoxColumn,
            this.sud2DataGridViewTextBoxColumn});
            this.dataGridSud.DataSource = this.sudBindingSource1;
            this.dataGridSud.Location = new System.Drawing.Point(24, 183);
            this.dataGridSud.Name = "dataGridSud";
            this.dataGridSud.Size = new System.Drawing.Size(843, 309);
            this.dataGridSud.TabIndex = 0;
            // 
            // nazivDataGridViewTextBoxColumn
            // 
            this.nazivDataGridViewTextBoxColumn.DataPropertyName = "Naziv";
            this.nazivDataGridViewTextBoxColumn.HeaderText = "Naziv";
            this.nazivDataGridViewTextBoxColumn.Name = "nazivDataGridViewTextBoxColumn";
            // 
            // ulicaIKucniBrDataGridViewTextBoxColumn
            // 
            this.ulicaIKucniBrDataGridViewTextBoxColumn.DataPropertyName = "UlicaIKucniBr";
            this.ulicaIKucniBrDataGridViewTextBoxColumn.HeaderText = "UlicaIKucniBr";
            this.ulicaIKucniBrDataGridViewTextBoxColumn.Name = "ulicaIKucniBrDataGridViewTextBoxColumn";
            // 
            // pBrDataGridViewTextBoxColumn
            // 
            this.pBrDataGridViewTextBoxColumn.DataPropertyName = "PBr";
            this.pBrDataGridViewTextBoxColumn.HeaderText = "PBr";
            this.pBrDataGridViewTextBoxColumn.Name = "pBrDataGridViewTextBoxColumn";
            // 
            // kategorijaDataGridViewTextBoxColumn
            // 
            this.kategorijaDataGridViewTextBoxColumn.DataPropertyName = "Kategorija";
            this.kategorijaDataGridViewTextBoxColumn.HeaderText = "Kategorija";
            this.kategorijaDataGridViewTextBoxColumn.Name = "kategorijaDataGridViewTextBoxColumn";
            // 
            // nadredeniDataGridViewTextBoxColumn
            // 
            this.nadredeniDataGridViewTextBoxColumn.DataPropertyName = "Nadredeni";
            this.nadredeniDataGridViewTextBoxColumn.HeaderText = "Nadredeni";
            this.nadredeniDataGridViewTextBoxColumn.Name = "nadredeniDataGridViewTextBoxColumn";
            // 
            // kategorijaSudaDataGridViewTextBoxColumn
            // 
            this.kategorijaSudaDataGridViewTextBoxColumn.DataPropertyName = "KategorijaSuda";
            this.kategorijaSudaDataGridViewTextBoxColumn.HeaderText = "KategorijaSuda";
            this.kategorijaSudaDataGridViewTextBoxColumn.Name = "kategorijaSudaDataGridViewTextBoxColumn";
            // 
            // mjestoDataGridViewTextBoxColumn
            // 
            this.mjestoDataGridViewTextBoxColumn.DataPropertyName = "Mjesto";
            this.mjestoDataGridViewTextBoxColumn.HeaderText = "Mjesto";
            this.mjestoDataGridViewTextBoxColumn.Name = "mjestoDataGridViewTextBoxColumn";
            // 
            // sud2DataGridViewTextBoxColumn
            // 
            this.sud2DataGridViewTextBoxColumn.DataPropertyName = "Sud2";
            this.sud2DataGridViewTextBoxColumn.HeaderText = "Sud2";
            this.sud2DataGridViewTextBoxColumn.Name = "sud2DataGridViewTextBoxColumn";
            // 
            // sudBindingSource1
            // 
            this.sudBindingSource1.DataSource = typeof(bazaF.Sud);
            // 
            // cbSort1
            // 
            this.cbSort1.FormattingEnabled = true;
            this.cbSort1.Location = new System.Drawing.Point(11, 23);
            this.cbSort1.Name = "cbSort1";
            this.cbSort1.Size = new System.Drawing.Size(121, 21);
            this.cbSort1.TabIndex = 1;
            // 
            // cbSort11
            // 
            this.cbSort11.FormattingEnabled = true;
            this.cbSort11.Items.AddRange(new object[] {
            "Uzlazno",
            "Silazno"});
            this.cbSort11.Location = new System.Drawing.Point(186, 24);
            this.cbSort11.Name = "cbSort11";
            this.cbSort11.Size = new System.Drawing.Size(121, 21);
            this.cbSort11.TabIndex = 2;
            // 
            // cbSort2
            // 
            this.cbSort2.FormattingEnabled = true;
            this.cbSort2.Location = new System.Drawing.Point(11, 66);
            this.cbSort2.Name = "cbSort2";
            this.cbSort2.Size = new System.Drawing.Size(121, 21);
            this.cbSort2.TabIndex = 3;
            // 
            // cbSort22
            // 
            this.cbSort22.FormattingEnabled = true;
            this.cbSort22.Items.AddRange(new object[] {
            "Uzlazno",
            "Silazno"});
            this.cbSort22.Location = new System.Drawing.Point(186, 66);
            this.cbSort22.Name = "cbSort22";
            this.cbSort22.Size = new System.Drawing.Size(121, 21);
            this.cbSort22.TabIndex = 4;
            // 
            // cbSort3
            // 
            this.cbSort3.FormattingEnabled = true;
            this.cbSort3.Location = new System.Drawing.Point(11, 111);
            this.cbSort3.Name = "cbSort3";
            this.cbSort3.Size = new System.Drawing.Size(121, 21);
            this.cbSort3.TabIndex = 5;
            // 
            // cbSort33
            // 
            this.cbSort33.FormattingEnabled = true;
            this.cbSort33.Items.AddRange(new object[] {
            "Uzlazno",
            "Silazno"});
            this.cbSort33.Location = new System.Drawing.Point(186, 111);
            this.cbSort33.Name = "cbSort33";
            this.cbSort33.Size = new System.Drawing.Size(121, 21);
            this.cbSort33.TabIndex = 6;
            // 
            // cbFilter
            // 
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(453, 53);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 7;
            // 
            // tbTrazi
            // 
            this.tbTrazi.Location = new System.Drawing.Point(593, 53);
            this.tbTrazi.Name = "tbTrazi";
            this.tbTrazi.Size = new System.Drawing.Size(147, 20);
            this.tbTrazi.TabIndex = 8;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(509, 93);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(145, 23);
            this.btnSort.TabIndex = 9;
            this.btnSort.Text = "Sortiraj i filtriraj";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // sudBindingSource
            // 
            this.sudBindingSource.DataSource = typeof(bazaF.Sud);
            // 
            // listBoxFilter
            // 
            this.listBoxFilter.FormattingEnabled = true;
            this.listBoxFilter.Location = new System.Drawing.Point(453, 131);
            this.listBoxFilter.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxFilter.Name = "listBoxFilter";
            this.listBoxFilter.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFilter.Size = new System.Drawing.Size(266, 30);
            this.listBoxFilter.TabIndex = 10;
            // 
            // gbSort
            // 
            this.gbSort.Controls.Add(this.cbSort1);
            this.gbSort.Controls.Add(this.cbSort22);
            this.gbSort.Controls.Add(this.cbSort11);
            this.gbSort.Controls.Add(this.cbSort2);
            this.gbSort.Controls.Add(this.cbSort3);
            this.gbSort.Controls.Add(this.cbSort33);
            this.gbSort.Location = new System.Drawing.Point(24, 12);
            this.gbSort.Name = "gbSort";
            this.gbSort.Size = new System.Drawing.Size(332, 158);
            this.gbSort.TabIndex = 11;
            this.gbSort.TabStop = false;
            this.gbSort.Text = "Sort";
            // 
            // SortSud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 514);
            this.Controls.Add(this.gbSort);
            this.Controls.Add(this.listBoxFilter);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.tbTrazi);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.dataGridSud);
            this.Name = "SortSud";
            this.Text = "SortSud";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormaSud_FormClosing);
            this.Load += new System.EventHandler(this.SortSud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sudBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sudBindingSource)).EndInit();
            this.gbSort.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridSud;
        private System.Windows.Forms.ComboBox cbSort1;
        private System.Windows.Forms.ComboBox cbSort11;
        private System.Windows.Forms.ComboBox cbSort2;
        private System.Windows.Forms.ComboBox cbSort22;
        private System.Windows.Forms.ComboBox cbSort3;
        private System.Windows.Forms.ComboBox cbSort33;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox tbTrazi;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazivDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ulicaIKucniBrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pBrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kategorijaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nadredeniDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kategorijaSudaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mjestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sud2DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sudBindingSource1;
        private System.Windows.Forms.BindingSource sudBindingSource;
        private System.Windows.Forms.ListBox listBoxFilter;
        private System.Windows.Forms.GroupBox gbSort;
    }
}