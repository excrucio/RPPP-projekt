namespace FormaSud
{
    partial class PretrazivanjeSud
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPbr = new System.Windows.Forms.ComboBox();
            this.cbKategorija = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMjesto = new System.Windows.Forms.TextBox();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.lblPretrazivanjeSuda = new System.Windows.Forms.Label();
            this.tbAdresa = new System.Windows.Forms.TextBox();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridSud = new System.Windows.Forms.DataGridView();
            this.btnIzmijeni = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.epAdresa = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPbrMjesto = new System.Windows.Forms.ErrorProvider(this.components);
            this.epNaziv = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStripSud = new System.Windows.Forms.MenuStrip();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.promijeniFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pozadinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promijeniPozadinuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialogSud = new System.Windows.Forms.FontDialog();
            this.colorDialogSud = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAdresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPbrMjesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNaziv)).BeginInit();
            this.menuStripSud.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbPbr);
            this.panel1.Controls.Add(this.cbKategorija);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbMjesto);
            this.panel1.Controls.Add(this.btnPretrazi);
            this.panel1.Controls.Add(this.lblPretrazivanjeSuda);
            this.panel1.Controls.Add(this.tbAdresa);
            this.panel1.Controls.Add(this.tbNaziv);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 238);
            this.panel1.TabIndex = 2;
            // 
            // cbPbr
            // 
            this.cbPbr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPbr.FormattingEnabled = true;
            this.cbPbr.Location = new System.Drawing.Point(170, 130);
            this.cbPbr.Name = "cbPbr";
            this.cbPbr.Size = new System.Drawing.Size(261, 21);
            this.cbPbr.TabIndex = 3;
            this.cbPbr.SelectionChangeCommitted += new System.EventHandler(this.cbPbr_SelectionChangeCommitted);
            // 
            // cbKategorija
            // 
            this.cbKategorija.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKategorija.FormattingEnabled = true;
            this.cbKategorija.Location = new System.Drawing.Point(173, 163);
            this.cbKategorija.Name = "cbKategorija";
            this.cbKategorija.Size = new System.Drawing.Size(548, 21);
            this.cbKategorija.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Kategorija";
            // 
            // tbMjesto
            // 
            this.tbMjesto.Location = new System.Drawing.Point(437, 131);
            this.tbMjesto.Name = "tbMjesto";
            this.tbMjesto.Size = new System.Drawing.Size(281, 20);
            this.tbMjesto.TabIndex = 4;
            this.tbMjesto.Validating += new System.ComponentModel.CancelEventHandler(this.tbMjesto_validating);
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(643, 202);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(75, 23);
            this.btnPretrazi.TabIndex = 6;
            this.btnPretrazi.Text = "Pretraži";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // lblPretrazivanjeSuda
            // 
            this.lblPretrazivanjeSuda.AutoSize = true;
            this.lblPretrazivanjeSuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPretrazivanjeSuda.Location = new System.Drawing.Point(10, 20);
            this.lblPretrazivanjeSuda.Name = "lblPretrazivanjeSuda";
            this.lblPretrazivanjeSuda.Size = new System.Drawing.Size(155, 20);
            this.lblPretrazivanjeSuda.TabIndex = 23;
            this.lblPretrazivanjeSuda.Text = "Pretraživanje sudova";
            // 
            // tbAdresa
            // 
            this.tbAdresa.Location = new System.Drawing.Point(170, 101);
            this.tbAdresa.Name = "tbAdresa";
            this.tbAdresa.Size = new System.Drawing.Size(548, 20);
            this.tbAdresa.TabIndex = 2;
            this.tbAdresa.Validating += new System.ComponentModel.CancelEventHandler(this.tbAdresa_Validating);
            // 
            // tbNaziv
            // 
            this.tbNaziv.Location = new System.Drawing.Point(170, 65);
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(548, 20);
            this.tbNaziv.TabIndex = 1;
            this.tbNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.tbNaziv_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Poštanski broj i mjesto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Adresa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv:";
            // 
            // dataGridSud
            // 
            this.dataGridSud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSud.Location = new System.Drawing.Point(26, 300);
            this.dataGridSud.Name = "dataGridSud";
            this.dataGridSud.Size = new System.Drawing.Size(707, 201);
            this.dataGridSud.TabIndex = 3;
            this.dataGridSud.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnIzmijeni
            // 
            this.btnIzmijeni.Location = new System.Drawing.Point(539, 533);
            this.btnIzmijeni.Name = "btnIzmijeni";
            this.btnIzmijeni.Size = new System.Drawing.Size(75, 23);
            this.btnIzmijeni.TabIndex = 7;
            this.btnIzmijeni.Text = "Izmijeni";
            this.btnIzmijeni.UseVisualStyleBackColor = true;
            this.btnIzmijeni.Visible = false;
            this.btnIzmijeni.Click += new System.EventHandler(this.btnIzmijeni_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(658, 533);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 8;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // epAdresa
            // 
            this.epAdresa.ContainerControl = this;
            // 
            // epPbrMjesto
            // 
            this.epPbrMjesto.ContainerControl = this;
            // 
            // epNaziv
            // 
            this.epNaziv.ContainerControl = this;
            // 
            // menuStripSud
            // 
            this.menuStripSud.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.pozadinaToolStripMenuItem});
            this.menuStripSud.Location = new System.Drawing.Point(0, 0);
            this.menuStripSud.Name = "menuStripSud";
            this.menuStripSud.Size = new System.Drawing.Size(791, 24);
            this.menuStripSud.TabIndex = 6;
            this.menuStripSud.Text = "menuStrip1";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem1,
            this.promijeniFontToolStripMenuItem});
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fontToolStripMenuItem.Text = "Font";
            // 
            // defaultToolStripMenuItem1
            // 
            this.defaultToolStripMenuItem1.Name = "defaultToolStripMenuItem1";
            this.defaultToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.defaultToolStripMenuItem1.Text = "Default";
            this.defaultToolStripMenuItem1.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click_1);
            // 
            // promijeniFontToolStripMenuItem
            // 
            this.promijeniFontToolStripMenuItem.Name = "promijeniFontToolStripMenuItem";
            this.promijeniFontToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.promijeniFontToolStripMenuItem.Text = "Promijeni font";
            this.promijeniFontToolStripMenuItem.Click += new System.EventHandler(this.promijeniFontToolStripMenuItem_Click);
            // 
            // pozadinaToolStripMenuItem
            // 
            this.pozadinaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.promijeniPozadinuToolStripMenuItem});
            this.pozadinaToolStripMenuItem.Name = "pozadinaToolStripMenuItem";
            this.pozadinaToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.pozadinaToolStripMenuItem.Text = "Pozadina";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem1_Click_1);
            // 
            // promijeniPozadinuToolStripMenuItem
            // 
            this.promijeniPozadinuToolStripMenuItem.Name = "promijeniPozadinuToolStripMenuItem";
            this.promijeniPozadinuToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.promijeniPozadinuToolStripMenuItem.Text = "Promijeni pozadinu";
            this.promijeniPozadinuToolStripMenuItem.Click += new System.EventHandler(this.promijeniPozadinuToolStripMenuItem_Click);
            // 
            // PretrazivanjeSud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 578);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnIzmijeni);
            this.Controls.Add(this.dataGridSud);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripSud);
            this.MainMenuStrip = this.menuStripSud;
            this.Name = "PretrazivanjeSud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PretrazivanjeSud";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAdresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPbrMjesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNaziv)).EndInit();
            this.menuStripSud.ResumeLayout(false);
            this.menuStripSud.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbKategorija;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMjesto;
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.Label lblPretrazivanjeSuda;
        private System.Windows.Forms.TextBox tbAdresa;
        private System.Windows.Forms.TextBox tbNaziv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridSud;
        private System.Windows.Forms.ComboBox cbPbr;
        private System.Windows.Forms.Button btnIzmijeni;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.ErrorProvider epAdresa;
        private System.Windows.Forms.ErrorProvider epPbrMjesto;
        private System.Windows.Forms.ErrorProvider epNaziv;
        private System.Windows.Forms.MenuStrip menuStripSud;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem promijeniFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pozadinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promijeniPozadinuToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialogSud;
        private System.Windows.Forms.ColorDialog colorDialogSud;

    }
}