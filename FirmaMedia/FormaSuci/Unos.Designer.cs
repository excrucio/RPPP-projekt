namespace FormaSuci
{
    partial class Unos
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
            this.cbDanRod = new System.Windows.Forms.ComboBox();
            this.tbMjesto = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.lblUnosSuca = new System.Windows.Forms.Label();
            this.cbGodinaRod = new System.Windows.Forms.ComboBox();
            this.lblGodinaTocka = new System.Windows.Forms.Label();
            this.cbMjesecRod = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPbr = new System.Windows.Forms.TextBox();
            this.tbAdresa = new System.Windows.Forms.TextBox();
            this.tbJMBG = new System.Windows.Forms.TextBox();
            this.tbOIB = new System.Windows.Forms.TextBox();
            this.tbImeOca = new System.Windows.Forms.TextBox();
            this.tbPrezime = new System.Windows.Forms.TextBox();
            this.tbIme = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.epIme = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPrezime = new System.Windows.Forms.ErrorProvider(this.components);
            this.epImeOca = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDatum = new System.Windows.Forms.ErrorProvider(this.components);
            this.epOIB = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAdresa = new System.Windows.Forms.ErrorProvider(this.components);
            this.epMjesto = new System.Windows.Forms.ErrorProvider(this.components);
            this.fontDialogSudac = new System.Windows.Forms.FontDialog();
            this.colorDialogSudac = new System.Windows.Forms.ColorDialog();
            this.menuStripSudac = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPozadina = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promjeniPozadinuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.promjeniFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epIme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrezime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epImeOca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOIB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAdresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMjesto)).BeginInit();
            this.menuStripSudac.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbDanRod);
            this.panel1.Controls.Add(this.tbMjesto);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.btnOdustani);
            this.panel1.Controls.Add(this.btnSpremi);
            this.panel1.Controls.Add(this.lblUnosSuca);
            this.panel1.Controls.Add(this.cbGodinaRod);
            this.panel1.Controls.Add(this.lblGodinaTocka);
            this.panel1.Controls.Add(this.cbMjesecRod);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tbPbr);
            this.panel1.Controls.Add(this.tbAdresa);
            this.panel1.Controls.Add(this.tbJMBG);
            this.panel1.Controls.Add(this.tbOIB);
            this.panel1.Controls.Add(this.tbImeOca);
            this.panel1.Controls.Add(this.tbPrezime);
            this.panel1.Controls.Add(this.tbIme);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 347);
            this.panel1.TabIndex = 1;
            // 
            // cbDanRod
            // 
            this.cbDanRod.FormattingEnabled = true;
            this.cbDanRod.Location = new System.Drawing.Point(170, 149);
            this.cbDanRod.Name = "cbDanRod";
            this.cbDanRod.Size = new System.Drawing.Size(51, 21);
            this.cbDanRod.TabIndex = 28;
            this.cbDanRod.Validating += new System.ComponentModel.CancelEventHandler(this.cbDatRod_Validating);
            // 
            // tbMjesto
            // 
            this.tbMjesto.Location = new System.Drawing.Point(261, 265);
            this.tbMjesto.Name = "tbMjesto";
            this.tbMjesto.Size = new System.Drawing.Size(137, 20);
            this.tbMjesto.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(298, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = ".";
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(323, 300);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 25;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(227, 300);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 24;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // lblUnosSuca
            // 
            this.lblUnosSuca.AutoSize = true;
            this.lblUnosSuca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUnosSuca.Location = new System.Drawing.Point(10, 20);
            this.lblUnosSuca.Name = "lblUnosSuca";
            this.lblUnosSuca.Size = new System.Drawing.Size(85, 20);
            this.lblUnosSuca.TabIndex = 23;
            this.lblUnosSuca.Text = "Unos suca";
            // 
            // cbGodinaRod
            // 
            this.cbGodinaRod.FormattingEnabled = true;
            this.cbGodinaRod.Location = new System.Drawing.Point(313, 150);
            this.cbGodinaRod.Name = "cbGodinaRod";
            this.cbGodinaRod.Size = new System.Drawing.Size(73, 21);
            this.cbGodinaRod.TabIndex = 22;
            this.cbGodinaRod.Validating += new System.ComponentModel.CancelEventHandler(this.cbDatRod_Validating);
            // 
            // lblGodinaTocka
            // 
            this.lblGodinaTocka.AutoSize = true;
            this.lblGodinaTocka.Location = new System.Drawing.Point(388, 156);
            this.lblGodinaTocka.Name = "lblGodinaTocka";
            this.lblGodinaTocka.Size = new System.Drawing.Size(10, 13);
            this.lblGodinaTocka.TabIndex = 21;
            this.lblGodinaTocka.Text = ".";
            // 
            // cbMjesecRod
            // 
            this.cbMjesecRod.FormattingEnabled = true;
            this.cbMjesecRod.Location = new System.Drawing.Point(246, 149);
            this.cbMjesecRod.Name = "cbMjesecRod";
            this.cbMjesecRod.Size = new System.Drawing.Size(51, 21);
            this.cbMjesecRod.TabIndex = 20;
            this.cbMjesecRod.Validating += new System.ComponentModel.CancelEventHandler(this.cbDatRod_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(227, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = ".";
            // 
            // tbPbr
            // 
            this.tbPbr.Location = new System.Drawing.Point(170, 265);
            this.tbPbr.Name = "tbPbr";
            this.tbPbr.ReadOnly = true;
            this.tbPbr.Size = new System.Drawing.Size(85, 20);
            this.tbPbr.TabIndex = 15;
            // 
            // tbAdresa
            // 
            this.tbAdresa.Location = new System.Drawing.Point(170, 235);
            this.tbAdresa.Name = "tbAdresa";
            this.tbAdresa.Size = new System.Drawing.Size(228, 20);
            this.tbAdresa.TabIndex = 14;
            this.tbAdresa.Validating += new System.ComponentModel.CancelEventHandler(this.tbAdresa_Validating);
            // 
            // tbJMBG
            // 
            this.tbJMBG.Location = new System.Drawing.Point(170, 207);
            this.tbJMBG.Name = "tbJMBG";
            this.tbJMBG.Size = new System.Drawing.Size(228, 20);
            this.tbJMBG.TabIndex = 13;
            this.tbJMBG.MouseHover += new System.EventHandler(this.JMBG_MouseHover);
            // 
            // tbOIB
            // 
            this.tbOIB.Location = new System.Drawing.Point(170, 180);
            this.tbOIB.Name = "tbOIB";
            this.tbOIB.Size = new System.Drawing.Size(228, 20);
            this.tbOIB.TabIndex = 12;
            this.tbOIB.Validating += new System.ComponentModel.CancelEventHandler(this.tbOIB_Validating);
            // 
            // tbImeOca
            // 
            this.tbImeOca.Location = new System.Drawing.Point(170, 122);
            this.tbImeOca.Name = "tbImeOca";
            this.tbImeOca.Size = new System.Drawing.Size(228, 20);
            this.tbImeOca.TabIndex = 11;
            this.tbImeOca.Validating += new System.ComponentModel.CancelEventHandler(this.tbImeOca_Validating);
            // 
            // tbPrezime
            // 
            this.tbPrezime.Location = new System.Drawing.Point(170, 95);
            this.tbPrezime.Name = "tbPrezime";
            this.tbPrezime.Size = new System.Drawing.Size(228, 20);
            this.tbPrezime.TabIndex = 10;
            this.tbPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.tbPrezime_Validating);
            // 
            // tbIme
            // 
            this.tbIme.Location = new System.Drawing.Point(170, 65);
            this.tbIme.Name = "tbIme";
            this.tbIme.Size = new System.Drawing.Size(228, 20);
            this.tbIme.TabIndex = 9;
            this.tbIme.Validating += new System.ComponentModel.CancelEventHandler(this.tbIme_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Poštanski broj i mjesto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Adresa:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "JMBG:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "OIB:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Datum rođenja:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ime oca:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prezime:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime:";
            // 
            // epIme
            // 
            this.epIme.ContainerControl = this;
            // 
            // epPrezime
            // 
            this.epPrezime.ContainerControl = this;
            // 
            // epImeOca
            // 
            this.epImeOca.ContainerControl = this;
            // 
            // epDatum
            // 
            this.epDatum.ContainerControl = this;
            // 
            // epOIB
            // 
            this.epOIB.ContainerControl = this;
            // 
            // epAdresa
            // 
            this.epAdresa.ContainerControl = this;
            // 
            // epMjesto
            // 
            this.epMjesto.ContainerControl = this;
            // 
            // menuStripSudac
            // 
            this.menuStripSudac.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFont,
            this.toolStripMenuItemPozadina});
            this.menuStripSudac.Location = new System.Drawing.Point(0, 0);
            this.menuStripSudac.Name = "menuStripSudac";
            this.menuStripSudac.Size = new System.Drawing.Size(460, 24);
            this.menuStripSudac.TabIndex = 2;
            this.menuStripSudac.Text = "menuStrip1";
            // 
            // toolStripMenuItemFont
            // 
            this.toolStripMenuItemFont.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem1,
            this.promjeniFontToolStripMenuItem});
            this.toolStripMenuItemFont.Name = "toolStripMenuItemFont";
            this.toolStripMenuItemFont.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItemFont.Text = "Font";
            this.toolStripMenuItemFont.Click += new System.EventHandler(this.toolStripMenuItemFont_Click);
            // 
            // toolStripMenuItemPozadina
            // 
            this.toolStripMenuItemPozadina.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.promjeniPozadinuToolStripMenuItem});
            this.toolStripMenuItemPozadina.Name = "toolStripMenuItemPozadina";
            this.toolStripMenuItemPozadina.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItemPozadina.Text = "Pozadina";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // promjeniPozadinuToolStripMenuItem
            // 
            this.promjeniPozadinuToolStripMenuItem.Name = "promjeniPozadinuToolStripMenuItem";
            this.promjeniPozadinuToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.promjeniPozadinuToolStripMenuItem.Text = "Promijeni pozadinu";
            this.promjeniPozadinuToolStripMenuItem.Click += new System.EventHandler(this.promjeniPozadinuToolStripMenuItem_Click);
            // 
            // defaultToolStripMenuItem1
            // 
            this.defaultToolStripMenuItem1.Name = "defaultToolStripMenuItem1";
            this.defaultToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.defaultToolStripMenuItem1.Text = "Default";
            this.defaultToolStripMenuItem1.Click += new System.EventHandler(this.defaultToolStripMenuItem1_Click);
            // 
            // promjeniFontToolStripMenuItem
            // 
            this.promjeniFontToolStripMenuItem.Name = "promjeniFontToolStripMenuItem";
            this.promjeniFontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.promjeniFontToolStripMenuItem.Text = "Promijeni font";
            this.promjeniFontToolStripMenuItem.Click += new System.EventHandler(this.promjeniFontToolStripMenuItem_Click);
            // 
            // Unos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 391);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripSudac);
            this.MainMenuStrip = this.menuStripSudac;
            this.Name = "Unos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unos suca";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epIme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrezime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epImeOca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOIB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAdresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMjesto)).EndInit();
            this.menuStripSudac.ResumeLayout(false);
            this.menuStripSudac.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbDanRod;
        private System.Windows.Forms.TextBox tbMjesto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.Label lblUnosSuca;
        private System.Windows.Forms.ComboBox cbGodinaRod;
        private System.Windows.Forms.Label lblGodinaTocka;
        private System.Windows.Forms.ComboBox cbMjesecRod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPbr;
        private System.Windows.Forms.TextBox tbAdresa;
        private System.Windows.Forms.TextBox tbJMBG;
        private System.Windows.Forms.TextBox tbOIB;
        private System.Windows.Forms.TextBox tbImeOca;
        private System.Windows.Forms.TextBox tbPrezime;
        private System.Windows.Forms.TextBox tbIme;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider epIme;
        private System.Windows.Forms.ErrorProvider epPrezime;
        private System.Windows.Forms.ErrorProvider epImeOca;
        private System.Windows.Forms.ErrorProvider epDatum;
        private System.Windows.Forms.ErrorProvider epOIB;
        private System.Windows.Forms.ErrorProvider epAdresa;
        private System.Windows.Forms.ErrorProvider epMjesto;
        private System.Windows.Forms.MenuStrip menuStripSudac;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFont;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem promjeniFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPozadina;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promjeniPozadinuToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialogSudac;
        private System.Windows.Forms.ColorDialog colorDialogSudac;
    }
}