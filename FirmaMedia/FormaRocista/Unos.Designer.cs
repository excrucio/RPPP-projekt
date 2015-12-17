namespace FormaRocista
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
            this.lblNaslov = new System.Windows.Forms.Label();
            this.lblNazivProcesa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDanRocista = new System.Windows.Forms.ComboBox();
            this.lblDatumDanTocka = new System.Windows.Forms.Label();
            this.cmbMjesecRocista = new System.Windows.Forms.ComboBox();
            this.lblDatumMjesecTocka = new System.Windows.Forms.Label();
            this.cmbGodinaRocista = new System.Windows.Forms.ComboBox();
            this.lblVrijemePocetka = new System.Windows.Forms.Label();
            this.cmbSatPocetka = new System.Windows.Forms.ComboBox();
            this.lblVrijemePocetkaDvotocka = new System.Windows.Forms.Label();
            this.cmbMinPocetka = new System.Windows.Forms.ComboBox();
            this.cmbMinZavrsetka = new System.Windows.Forms.ComboBox();
            this.lblVrijemeZavrsetkaDvotocka = new System.Windows.Forms.Label();
            this.cmbSatZavrsetka = new System.Windows.Forms.ComboBox();
            this.lblVrijemeZavrsetka = new System.Windows.Forms.Label();
            this.dgvSudionici = new System.Windows.Forms.DataGridView();
            this.lblSudionici = new System.Windows.Forms.Label();
            this.btnSpremiRoc = new System.Windows.Forms.Button();
            this.btnOdustaniRoc = new System.Windows.Forms.Button();
            this.lblTrajanjeDvotocka = new System.Windows.Forms.Label();
            this.lblTrajanje = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promijeniFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pozadinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.promijeniPozadinuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSatTrajanja = new System.Windows.Forms.TextBox();
            this.tbMinTrajanja = new System.Windows.Forms.TextBox();
            this.cmbNazivProcesa = new System.Windows.Forms.ComboBox();
            this.epNazivProcesa = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDatum = new System.Windows.Forms.ErrorProvider(this.components);
            this.epVrijemePocetka = new System.Windows.Forms.ErrorProvider(this.components);
            this.epVrijemeZavrsetka = new System.Windows.Forms.ErrorProvider(this.components);
            this.fontDialogRociste = new System.Windows.Forms.FontDialog();
            this.colorDialogRociste = new System.Windows.Forms.ColorDialog();
            this.lblDatumGodinaTocka = new System.Windows.Forms.Label();
            this.btnObrisiRed = new System.Windows.Forms.Button();
            this.btnUcitaj = new System.Windows.Forms.Button();
            this.btnUnosZapisnika = new System.Windows.Forms.Button();
            this.btnIzmijeni = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSudionici)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epNazivProcesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epVrijemePocetka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epVrijemeZavrsetka)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNaslov.Location = new System.Drawing.Point(12, 33);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(133, 26);
            this.lblNaslov.TabIndex = 0;
            this.lblNaslov.Text = "Unos ročišta";
            // 
            // lblNazivProcesa
            // 
            this.lblNazivProcesa.AutoSize = true;
            this.lblNazivProcesa.Location = new System.Drawing.Point(17, 80);
            this.lblNazivProcesa.Name = "lblNazivProcesa";
            this.lblNazivProcesa.Size = new System.Drawing.Size(78, 13);
            this.lblNazivProcesa.TabIndex = 1;
            this.lblNazivProcesa.Text = "Naziv procesa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Datum:";
            // 
            // cmbDanRocista
            // 
            this.cmbDanRocista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDanRocista.FormattingEnabled = true;
            this.cmbDanRocista.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbDanRocista.Location = new System.Drawing.Point(114, 181);
            this.cmbDanRocista.Name = "cmbDanRocista";
            this.cmbDanRocista.Size = new System.Drawing.Size(38, 21);
            this.cmbDanRocista.TabIndex = 6;
            this.cmbDanRocista.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDanRocista_Validating);
            // 
            // lblDatumDanTocka
            // 
            this.lblDatumDanTocka.AutoSize = true;
            this.lblDatumDanTocka.Location = new System.Drawing.Point(152, 189);
            this.lblDatumDanTocka.Name = "lblDatumDanTocka";
            this.lblDatumDanTocka.Size = new System.Drawing.Size(10, 13);
            this.lblDatumDanTocka.TabIndex = 6;
            this.lblDatumDanTocka.Text = ".";
            // 
            // cmbMjesecRocista
            // 
            this.cmbMjesecRocista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMjesecRocista.FormattingEnabled = true;
            this.cmbMjesecRocista.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbMjesecRocista.Location = new System.Drawing.Point(164, 181);
            this.cmbMjesecRocista.Name = "cmbMjesecRocista";
            this.cmbMjesecRocista.Size = new System.Drawing.Size(38, 21);
            this.cmbMjesecRocista.TabIndex = 7;
            this.cmbMjesecRocista.Validating += new System.ComponentModel.CancelEventHandler(this.cmbMjesecRocista_Validating);
            // 
            // lblDatumMjesecTocka
            // 
            this.lblDatumMjesecTocka.AutoSize = true;
            this.lblDatumMjesecTocka.Location = new System.Drawing.Point(202, 189);
            this.lblDatumMjesecTocka.Name = "lblDatumMjesecTocka";
            this.lblDatumMjesecTocka.Size = new System.Drawing.Size(10, 13);
            this.lblDatumMjesecTocka.TabIndex = 8;
            this.lblDatumMjesecTocka.Text = ".";
            // 
            // cmbGodinaRocista
            // 
            this.cmbGodinaRocista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGodinaRocista.FormattingEnabled = true;
            this.cmbGodinaRocista.Items.AddRange(new object[] {
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014"});
            this.cmbGodinaRocista.Location = new System.Drawing.Point(215, 181);
            this.cmbGodinaRocista.Name = "cmbGodinaRocista";
            this.cmbGodinaRocista.Size = new System.Drawing.Size(68, 21);
            this.cmbGodinaRocista.TabIndex = 8;
            this.cmbGodinaRocista.Validating += new System.ComponentModel.CancelEventHandler(this.cmbGodinaRocista_Validating);
            // 
            // lblVrijemePocetka
            // 
            this.lblVrijemePocetka.AutoSize = true;
            this.lblVrijemePocetka.Location = new System.Drawing.Point(17, 130);
            this.lblVrijemePocetka.Name = "lblVrijemePocetka";
            this.lblVrijemePocetka.Size = new System.Drawing.Size(86, 13);
            this.lblVrijemePocetka.TabIndex = 12;
            this.lblVrijemePocetka.Text = "Vrijeme početka:";
            // 
            // cmbSatPocetka
            // 
            this.cmbSatPocetka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSatPocetka.FormattingEnabled = true;
            this.cmbSatPocetka.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbSatPocetka.Location = new System.Drawing.Point(114, 127);
            this.cmbSatPocetka.Name = "cmbSatPocetka";
            this.cmbSatPocetka.Size = new System.Drawing.Size(38, 21);
            this.cmbSatPocetka.TabIndex = 2;
            this.cmbSatPocetka.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSatPocetka_Validating);
            // 
            // lblVrijemePocetkaDvotocka
            // 
            this.lblVrijemePocetkaDvotocka.AutoSize = true;
            this.lblVrijemePocetkaDvotocka.Location = new System.Drawing.Point(152, 130);
            this.lblVrijemePocetkaDvotocka.Name = "lblVrijemePocetkaDvotocka";
            this.lblVrijemePocetkaDvotocka.Size = new System.Drawing.Size(10, 13);
            this.lblVrijemePocetkaDvotocka.TabIndex = 14;
            this.lblVrijemePocetkaDvotocka.Text = ":";
            // 
            // cmbMinPocetka
            // 
            this.cmbMinPocetka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMinPocetka.FormattingEnabled = true;
            this.cmbMinPocetka.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cmbMinPocetka.Location = new System.Drawing.Point(168, 127);
            this.cmbMinPocetka.Name = "cmbMinPocetka";
            this.cmbMinPocetka.Size = new System.Drawing.Size(38, 21);
            this.cmbMinPocetka.TabIndex = 3;
            this.cmbMinPocetka.Validating += new System.ComponentModel.CancelEventHandler(this.cmbMinPocetka_Validating);
            // 
            // cmbMinZavrsetka
            // 
            this.cmbMinZavrsetka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMinZavrsetka.FormattingEnabled = true;
            this.cmbMinZavrsetka.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cmbMinZavrsetka.Location = new System.Drawing.Point(425, 127);
            this.cmbMinZavrsetka.Name = "cmbMinZavrsetka";
            this.cmbMinZavrsetka.Size = new System.Drawing.Size(38, 21);
            this.cmbMinZavrsetka.TabIndex = 5;
            this.cmbMinZavrsetka.Validating += new System.ComponentModel.CancelEventHandler(this.cmbMinZavrsetka_Validating);
            // 
            // lblVrijemeZavrsetkaDvotocka
            // 
            this.lblVrijemeZavrsetkaDvotocka.AutoSize = true;
            this.lblVrijemeZavrsetkaDvotocka.Location = new System.Drawing.Point(409, 130);
            this.lblVrijemeZavrsetkaDvotocka.Name = "lblVrijemeZavrsetkaDvotocka";
            this.lblVrijemeZavrsetkaDvotocka.Size = new System.Drawing.Size(10, 13);
            this.lblVrijemeZavrsetkaDvotocka.TabIndex = 18;
            this.lblVrijemeZavrsetkaDvotocka.Text = ":";
            // 
            // cmbSatZavrsetka
            // 
            this.cmbSatZavrsetka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSatZavrsetka.FormattingEnabled = true;
            this.cmbSatZavrsetka.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbSatZavrsetka.Location = new System.Drawing.Point(371, 127);
            this.cmbSatZavrsetka.Name = "cmbSatZavrsetka";
            this.cmbSatZavrsetka.Size = new System.Drawing.Size(38, 21);
            this.cmbSatZavrsetka.TabIndex = 4;
            this.cmbSatZavrsetka.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSatZavrsetka_Validating);
            // 
            // lblVrijemeZavrsetka
            // 
            this.lblVrijemeZavrsetka.AutoSize = true;
            this.lblVrijemeZavrsetka.Location = new System.Drawing.Point(272, 130);
            this.lblVrijemeZavrsetka.Name = "lblVrijemeZavrsetka";
            this.lblVrijemeZavrsetka.Size = new System.Drawing.Size(93, 13);
            this.lblVrijemeZavrsetka.TabIndex = 16;
            this.lblVrijemeZavrsetka.Text = "Vrijeme završetka:";
            // 
            // dgvSudionici
            // 
            this.dgvSudionici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSudionici.Location = new System.Drawing.Point(114, 243);
            this.dgvSudionici.Name = "dgvSudionici";
            this.dgvSudionici.Size = new System.Drawing.Size(349, 181);
            this.dgvSudionici.TabIndex = 20;
            // 
            // lblSudionici
            // 
            this.lblSudionici.AutoSize = true;
            this.lblSudionici.Location = new System.Drawing.Point(17, 243);
            this.lblSudionici.Name = "lblSudionici";
            this.lblSudionici.Size = new System.Drawing.Size(53, 13);
            this.lblSudionici.TabIndex = 21;
            this.lblSudionici.Text = "Sudionici:";
            // 
            // btnSpremiRoc
            // 
            this.btnSpremiRoc.Location = new System.Drawing.Point(531, 272);
            this.btnSpremiRoc.Name = "btnSpremiRoc";
            this.btnSpremiRoc.Size = new System.Drawing.Size(135, 23);
            this.btnSpremiRoc.TabIndex = 12;
            this.btnSpremiRoc.Text = "Spremi";
            this.btnSpremiRoc.UseVisualStyleBackColor = true;
            this.btnSpremiRoc.Click += new System.EventHandler(this.btnSpremiRoc_Click);
            // 
            // btnOdustaniRoc
            // 
            this.btnOdustaniRoc.Location = new System.Drawing.Point(531, 243);
            this.btnOdustaniRoc.Name = "btnOdustaniRoc";
            this.btnOdustaniRoc.Size = new System.Drawing.Size(135, 23);
            this.btnOdustaniRoc.TabIndex = 11;
            this.btnOdustaniRoc.Text = "Odustani";
            this.btnOdustaniRoc.UseVisualStyleBackColor = true;
            this.btnOdustaniRoc.Click += new System.EventHandler(this.btnOdustaniRoc_Click);
            // 
            // lblTrajanjeDvotocka
            // 
            this.lblTrajanjeDvotocka.AutoSize = true;
            this.lblTrajanjeDvotocka.Location = new System.Drawing.Point(409, 184);
            this.lblTrajanjeDvotocka.Name = "lblTrajanjeDvotocka";
            this.lblTrajanjeDvotocka.Size = new System.Drawing.Size(10, 13);
            this.lblTrajanjeDvotocka.TabIndex = 26;
            this.lblTrajanjeDvotocka.Text = ":";
            // 
            // lblTrajanje
            // 
            this.lblTrajanje.AutoSize = true;
            this.lblTrajanje.Location = new System.Drawing.Point(308, 184);
            this.lblTrajanje.Name = "lblTrajanje";
            this.lblTrajanje.Size = new System.Drawing.Size(45, 13);
            this.lblTrajanje.TabIndex = 24;
            this.lblTrajanje.Text = "Trajanje";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.pozadinaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(696, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.promijeniFontToolStripMenuItem});
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fontToolStripMenuItem.Text = "Font";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // promijeniFontToolStripMenuItem
            // 
            this.promijeniFontToolStripMenuItem.Name = "promijeniFontToolStripMenuItem";
            this.promijeniFontToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.promijeniFontToolStripMenuItem.Text = "Promijeni font...";
            this.promijeniFontToolStripMenuItem.Click += new System.EventHandler(this.promijeniFontToolStripMenuItem_Click);
            // 
            // pozadinaToolStripMenuItem
            // 
            this.pozadinaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem1,
            this.promijeniPozadinuToolStripMenuItem});
            this.pozadinaToolStripMenuItem.Name = "pozadinaToolStripMenuItem";
            this.pozadinaToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.pozadinaToolStripMenuItem.Text = "Pozadina";
            // 
            // defaultToolStripMenuItem1
            // 
            this.defaultToolStripMenuItem1.Name = "defaultToolStripMenuItem1";
            this.defaultToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.defaultToolStripMenuItem1.Text = "Default";
            this.defaultToolStripMenuItem1.Click += new System.EventHandler(this.defaultToolStripMenuItem1_Click);
            // 
            // promijeniPozadinuToolStripMenuItem
            // 
            this.promijeniPozadinuToolStripMenuItem.Name = "promijeniPozadinuToolStripMenuItem";
            this.promijeniPozadinuToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.promijeniPozadinuToolStripMenuItem.Text = "Promijeni pozadinu...";
            this.promijeniPozadinuToolStripMenuItem.Click += new System.EventHandler(this.promijeniPozadinuToolStripMenuItem_Click);
            // 
            // tbSatTrajanja
            // 
            this.tbSatTrajanja.Location = new System.Drawing.Point(369, 181);
            this.tbSatTrajanja.Name = "tbSatTrajanja";
            this.tbSatTrajanja.ReadOnly = true;
            this.tbSatTrajanja.Size = new System.Drawing.Size(38, 20);
            this.tbSatTrajanja.TabIndex = 29;
            // 
            // tbMinTrajanja
            // 
            this.tbMinTrajanja.Location = new System.Drawing.Point(425, 181);
            this.tbMinTrajanja.Name = "tbMinTrajanja";
            this.tbMinTrajanja.ReadOnly = true;
            this.tbMinTrajanja.Size = new System.Drawing.Size(38, 20);
            this.tbMinTrajanja.TabIndex = 30;
            // 
            // cmbNazivProcesa
            // 
            this.cmbNazivProcesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNazivProcesa.FormattingEnabled = true;
            this.cmbNazivProcesa.Location = new System.Drawing.Point(114, 77);
            this.cmbNazivProcesa.Name = "cmbNazivProcesa";
            this.cmbNazivProcesa.Size = new System.Drawing.Size(349, 21);
            this.cmbNazivProcesa.TabIndex = 1;
            this.cmbNazivProcesa.Validating += new System.ComponentModel.CancelEventHandler(this.cmbNazivProcesa_Validating);
            // 
            // epNazivProcesa
            // 
            this.epNazivProcesa.ContainerControl = this;
            // 
            // epDatum
            // 
            this.epDatum.ContainerControl = this;
            // 
            // epVrijemePocetka
            // 
            this.epVrijemePocetka.ContainerControl = this;
            // 
            // epVrijemeZavrsetka
            // 
            this.epVrijemeZavrsetka.ContainerControl = this;
            // 
            // lblDatumGodinaTocka
            // 
            this.lblDatumGodinaTocka.AutoSize = true;
            this.lblDatumGodinaTocka.Location = new System.Drawing.Point(283, 189);
            this.lblDatumGodinaTocka.Name = "lblDatumGodinaTocka";
            this.lblDatumGodinaTocka.Size = new System.Drawing.Size(10, 13);
            this.lblDatumGodinaTocka.TabIndex = 32;
            this.lblDatumGodinaTocka.Text = ".";
            // 
            // btnObrisiRed
            // 
            this.btnObrisiRed.Location = new System.Drawing.Point(531, 401);
            this.btnObrisiRed.Name = "btnObrisiRed";
            this.btnObrisiRed.Size = new System.Drawing.Size(135, 23);
            this.btnObrisiRed.TabIndex = 14;
            this.btnObrisiRed.Text = "Obriši redak tablice";
            this.btnObrisiRed.UseVisualStyleBackColor = true;
            this.btnObrisiRed.Click += new System.EventHandler(this.btnObrisiRed_Click);
            // 
            // btnUcitaj
            // 
            this.btnUcitaj.Location = new System.Drawing.Point(531, 77);
            this.btnUcitaj.Name = "btnUcitaj";
            this.btnUcitaj.Size = new System.Drawing.Size(135, 23);
            this.btnUcitaj.TabIndex = 9;
            this.btnUcitaj.Text = "Učitaj prethodni unos";
            this.btnUcitaj.UseVisualStyleBackColor = true;
            this.btnUcitaj.Click += new System.EventHandler(this.btnUcitaj_Click);
            // 
            // btnUnosZapisnika
            // 
            this.btnUnosZapisnika.Location = new System.Drawing.Point(531, 106);
            this.btnUnosZapisnika.Name = "btnUnosZapisnika";
            this.btnUnosZapisnika.Size = new System.Drawing.Size(135, 23);
            this.btnUnosZapisnika.TabIndex = 10;
            this.btnUnosZapisnika.Text = "Unesi zapisnik ročišta...";
            this.btnUnosZapisnika.UseVisualStyleBackColor = true;
            this.btnUnosZapisnika.Click += new System.EventHandler(this.btnUnosZapisnika_Click);
            // 
            // btnIzmijeni
            // 
            this.btnIzmijeni.Enabled = false;
            this.btnIzmijeni.Location = new System.Drawing.Point(531, 301);
            this.btnIzmijeni.Name = "btnIzmijeni";
            this.btnIzmijeni.Size = new System.Drawing.Size(135, 23);
            this.btnIzmijeni.TabIndex = 13;
            this.btnIzmijeni.Text = "Izmijeni";
            this.btnIzmijeni.UseVisualStyleBackColor = true;
            this.btnIzmijeni.Click += new System.EventHandler(this.btnIzmijeni_Click);
            // 
            // Unos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 469);
            this.Controls.Add(this.btnIzmijeni);
            this.Controls.Add(this.btnUnosZapisnika);
            this.Controls.Add(this.btnUcitaj);
            this.Controls.Add(this.btnObrisiRed);
            this.Controls.Add(this.lblDatumGodinaTocka);
            this.Controls.Add(this.cmbNazivProcesa);
            this.Controls.Add(this.tbMinTrajanja);
            this.Controls.Add(this.tbSatTrajanja);
            this.Controls.Add(this.lblTrajanjeDvotocka);
            this.Controls.Add(this.lblTrajanje);
            this.Controls.Add(this.btnOdustaniRoc);
            this.Controls.Add(this.btnSpremiRoc);
            this.Controls.Add(this.lblSudionici);
            this.Controls.Add(this.dgvSudionici);
            this.Controls.Add(this.cmbMinZavrsetka);
            this.Controls.Add(this.lblVrijemeZavrsetkaDvotocka);
            this.Controls.Add(this.cmbSatZavrsetka);
            this.Controls.Add(this.lblVrijemeZavrsetka);
            this.Controls.Add(this.cmbMinPocetka);
            this.Controls.Add(this.lblVrijemePocetkaDvotocka);
            this.Controls.Add(this.cmbSatPocetka);
            this.Controls.Add(this.lblVrijemePocetka);
            this.Controls.Add(this.cmbGodinaRocista);
            this.Controls.Add(this.lblDatumMjesecTocka);
            this.Controls.Add(this.cmbMjesecRocista);
            this.Controls.Add(this.lblDatumDanTocka);
            this.Controls.Add(this.cmbDanRocista);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNazivProcesa);
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Unos";
            this.Text = "Unos Ročišta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSudionici)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epNazivProcesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epVrijemePocetka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epVrijemeZavrsetka)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Label lblNazivProcesa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDanRocista;
        private System.Windows.Forms.Label lblDatumDanTocka;
        private System.Windows.Forms.ComboBox cmbMjesecRocista;
        private System.Windows.Forms.Label lblDatumMjesecTocka;
        private System.Windows.Forms.ComboBox cmbGodinaRocista;
        private System.Windows.Forms.Label lblVrijemePocetka;
        private System.Windows.Forms.ComboBox cmbSatPocetka;
        private System.Windows.Forms.Label lblVrijemePocetkaDvotocka;
        private System.Windows.Forms.ComboBox cmbMinPocetka;
        private System.Windows.Forms.ComboBox cmbMinZavrsetka;
        private System.Windows.Forms.Label lblVrijemeZavrsetkaDvotocka;
        private System.Windows.Forms.ComboBox cmbSatZavrsetka;
        private System.Windows.Forms.Label lblVrijemeZavrsetka;
        private System.Windows.Forms.DataGridView dgvSudionici;
        private System.Windows.Forms.Label lblSudionici;
        private System.Windows.Forms.Button btnSpremiRoc;
        private System.Windows.Forms.Button btnOdustaniRoc;
        private System.Windows.Forms.Label lblTrajanjeDvotocka;
        private System.Windows.Forms.Label lblTrajanje;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pozadinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promijeniFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem promijeniPozadinuToolStripMenuItem;
        private System.Windows.Forms.TextBox tbSatTrajanja;
        private System.Windows.Forms.TextBox tbMinTrajanja;
        private System.Windows.Forms.ComboBox cmbNazivProcesa;
        private System.Windows.Forms.ErrorProvider epNazivProcesa;
        private System.Windows.Forms.ErrorProvider epDatum;
        private System.Windows.Forms.ErrorProvider epVrijemePocetka;
        private System.Windows.Forms.ErrorProvider epVrijemeZavrsetka;
        private System.Windows.Forms.FontDialog fontDialogRociste;
        private System.Windows.Forms.ColorDialog colorDialogRociste;
        private System.Windows.Forms.Label lblDatumGodinaTocka;
        private System.Windows.Forms.Button btnObrisiRed;
        private System.Windows.Forms.Button btnUcitaj;
        private System.Windows.Forms.Button btnUnosZapisnika;
        private System.Windows.Forms.Button btnIzmijeni;
    }
}

