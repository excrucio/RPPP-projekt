namespace FormaPresuda
{
    partial class UnosPresude
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
            this.lblNazivProcesa = new System.Windows.Forms.Label();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.lblTipPresude = new System.Windows.Forms.Label();
            this.cbPresudaTip = new System.Windows.Forms.ComboBox();
            this.btnDodajPresudu = new System.Windows.Forms.Button();
            this.dodavanjePresudeOFD = new System.Windows.Forms.OpenFileDialog();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.fontDialogUnosPresude = new System.Windows.Forms.FontDialog();
            this.colorDialogUnosPresude = new System.Windows.Forms.ColorDialog();
            this.lblOptuzenici = new System.Windows.Forms.Label();
            this.dgOptFiz = new System.Windows.Forms.DataGridView();
            this.dgOptPrav = new System.Windows.Forms.DataGridView();
            this.panel = new System.Windows.Forms.Panel();
            this.errorProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorDok = new System.Windows.Forms.ErrorProvider(this.components);
            this.glavnaFormaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dgOptFiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOptPrav)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDok)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNazivProcesa
            // 
            this.lblNazivProcesa.AutoSize = true;
            this.lblNazivProcesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNazivProcesa.Location = new System.Drawing.Point(37, 60);
            this.lblNazivProcesa.Name = "lblNazivProcesa";
            this.lblNazivProcesa.Size = new System.Drawing.Size(78, 13);
            this.lblNazivProcesa.TabIndex = 2;
            this.lblNazivProcesa.Text = "Naziv procesa:";
            // 
            // tbNaziv
            // 
            this.tbNaziv.Enabled = false;
            this.tbNaziv.Location = new System.Drawing.Point(130, 57);
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(288, 20);
            this.tbNaziv.TabIndex = 3;
            // 
            // lblTipPresude
            // 
            this.lblTipPresude.AutoSize = true;
            this.lblTipPresude.Location = new System.Drawing.Point(43, 339);
            this.lblTipPresude.Name = "lblTipPresude";
            this.lblTipPresude.Size = new System.Drawing.Size(66, 13);
            this.lblTipPresude.TabIndex = 6;
            this.lblTipPresude.Text = "Tip presude:";
            // 
            // cbPresudaTip
            // 
            this.cbPresudaTip.FormattingEnabled = true;
            this.cbPresudaTip.Location = new System.Drawing.Point(130, 336);
            this.cbPresudaTip.Name = "cbPresudaTip";
            this.cbPresudaTip.Size = new System.Drawing.Size(172, 21);
            this.cbPresudaTip.TabIndex = 7;
            // 
            // btnDodajPresudu
            // 
            this.btnDodajPresudu.Location = new System.Drawing.Point(344, 336);
            this.btnDodajPresudu.Name = "btnDodajPresudu";
            this.btnDodajPresudu.Size = new System.Drawing.Size(102, 23);
            this.btnDodajPresudu.TabIndex = 8;
            this.btnDodajPresudu.Text = "Dodaj presudu";
            this.btnDodajPresudu.UseVisualStyleBackColor = true;
            this.btnDodajPresudu.Click += new System.EventHandler(this.btnDodajPresudu_Click);
            this.btnDodajPresudu.Validating += new System.ComponentModel.CancelEventHandler(this.dodanDokument_validate);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(46, 371);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 9;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(344, 371);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 10;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // lblOptuzenici
            // 
            this.lblOptuzenici.AutoSize = true;
            this.lblOptuzenici.Location = new System.Drawing.Point(22, 5);
            this.lblOptuzenici.Name = "lblOptuzenici";
            this.lblOptuzenici.Size = new System.Drawing.Size(60, 13);
            this.lblOptuzenici.TabIndex = 4;
            this.lblOptuzenici.Text = "Optuženici:";
            // 
            // dgOptFiz
            // 
            this.dgOptFiz.Location = new System.Drawing.Point(25, 21);
            this.dgOptFiz.MultiSelect = false;
            this.dgOptFiz.Name = "dgOptFiz";
            this.dgOptFiz.Size = new System.Drawing.Size(406, 109);
            this.dgOptFiz.TabIndex = 5;
            this.dgOptFiz.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgOptFiz.Validating += new System.ComponentModel.CancelEventHandler(this.izabranaOsoba_validate);
            // 
            // dgOptPrav
            // 
            this.dgOptPrav.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOptPrav.Location = new System.Drawing.Point(25, 126);
            this.dgOptPrav.MultiSelect = false;
            this.dgOptPrav.Name = "dgOptPrav";
            this.dgOptPrav.Size = new System.Drawing.Size(406, 107);
            this.dgOptPrav.TabIndex = 11;
            this.dgOptPrav.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOptPrav_CellContentClick);
            this.dgOptPrav.Click += new System.EventHandler(this.klik);
            this.dgOptPrav.Validating += new System.ComponentModel.CancelEventHandler(this.izabranaOsoba_validate);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.dgOptPrav);
            this.panel.Controls.Add(this.lblOptuzenici);
            this.panel.Controls.Add(this.dgOptFiz);
            this.panel.Location = new System.Drawing.Point(11, 86);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(434, 250);
            this.panel.TabIndex = 12;
            // 
            // errorProv
            // 
            this.errorProv.ContainerControl = this;
            // 
            // errorDok
            // 
            this.errorDok.ContainerControl = this;
            // 
            // glavnaFormaToolStripMenuItem
            // 
            this.glavnaFormaToolStripMenuItem.Name = "glavnaFormaToolStripMenuItem";
            this.glavnaFormaToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.glavnaFormaToolStripMenuItem.Text = "Pretraživanje";
            this.glavnaFormaToolStripMenuItem.Click += new System.EventHandler(this.glavnaFormaToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.glavnaFormaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(477, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // UnosPresude
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 396);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.btnDodajPresudu);
            this.Controls.Add(this.cbPresudaTip);
            this.Controls.Add(this.lblTipPresude);
            this.Controls.Add(this.tbNaziv);
            this.Controls.Add(this.lblNazivProcesa);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UnosPresude";
            this.Text = "Unos presude";
            this.Load += new System.EventHandler(this.UnosPresude_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOptFiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOptPrav)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDok)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNazivProcesa;
        private System.Windows.Forms.TextBox tbNaziv;
        private System.Windows.Forms.Label lblTipPresude;
        private System.Windows.Forms.ComboBox cbPresudaTip;
        private System.Windows.Forms.Button btnDodajPresudu;
        private System.Windows.Forms.OpenFileDialog dodavanjePresudeOFD;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.FontDialog fontDialogUnosPresude;
        private System.Windows.Forms.ColorDialog colorDialogUnosPresude;
        private System.Windows.Forms.Label lblOptuzenici;
        private System.Windows.Forms.DataGridView dgOptFiz;
        private System.Windows.Forms.DataGridView dgOptPrav;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ErrorProvider errorProv;
        private System.Windows.Forms.ErrorProvider errorDok;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem glavnaFormaToolStripMenuItem;
    }
}

