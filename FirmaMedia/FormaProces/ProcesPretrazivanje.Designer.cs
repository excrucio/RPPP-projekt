namespace FormaProces
{
    partial class ProcesPretrazivanje
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
            this.naziv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sud = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.urBroj = new System.Windows.Forms.TextBox();
            this.klasa = new System.Windows.Forms.TextBox();
            this.urBrojlabel = new System.Windows.Forms.Label();
            this.klasalabel = new System.Windows.Forms.Label();
            this.trazi = new System.Windows.Forms.Button();
            this.labe = new System.Windows.Forms.Label();
            this.optuzenik = new System.Windows.Forms.TextBox();
            this.ostecenik = new System.Windows.Forms.TextBox();
            this.odustani = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.odvjetnik = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.izmjena = new System.Windows.Forms.Button();
            this.obrisi = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.izborFonta = new System.Windows.Forms.ToolStripMenuItem();
            this.izborPozadina = new System.Windows.Forms.ToolStripMenuItem();
            this.izgledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temaTamna = new System.Windows.Forms.ToolStripMenuItem();
            this.temaSvjetla = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // naziv
            // 
            this.naziv.Location = new System.Drawing.Point(102, 81);
            this.naziv.Name = "naziv";
            this.naziv.Size = new System.Drawing.Size(462, 20);
            this.naziv.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Naziv procesa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pretraživanje procesa";
            // 
            // sud
            // 
            this.sud.FormattingEnabled = true;
            this.sud.Location = new System.Drawing.Point(102, 155);
            this.sud.Name = "sud";
            this.sud.Size = new System.Drawing.Size(188, 21);
            this.sud.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nadležan sud:";
            // 
            // urBroj
            // 
            this.urBroj.Location = new System.Drawing.Point(357, 118);
            this.urBroj.Name = "urBroj";
            this.urBroj.Size = new System.Drawing.Size(207, 20);
            this.urBroj.TabIndex = 7;
            // 
            // klasa
            // 
            this.klasa.Location = new System.Drawing.Point(102, 118);
            this.klasa.Name = "klasa";
            this.klasa.Size = new System.Drawing.Size(188, 20);
            this.klasa.TabIndex = 5;
            // 
            // urBrojlabel
            // 
            this.urBrojlabel.AutoSize = true;
            this.urBrojlabel.Location = new System.Drawing.Point(296, 121);
            this.urBrojlabel.Name = "urBrojlabel";
            this.urBrojlabel.Size = new System.Drawing.Size(44, 13);
            this.urBrojlabel.TabIndex = 6;
            this.urBrojlabel.Text = "Ur. broj:";
            // 
            // klasalabel
            // 
            this.klasalabel.AutoSize = true;
            this.klasalabel.Location = new System.Drawing.Point(14, 121);
            this.klasalabel.Name = "klasalabel";
            this.klasalabel.Size = new System.Drawing.Size(36, 13);
            this.klasalabel.TabIndex = 4;
            this.klasalabel.Text = "Klasa:";
            // 
            // trazi
            // 
            this.trazi.Location = new System.Drawing.Point(357, 194);
            this.trazi.Name = "trazi";
            this.trazi.Size = new System.Drawing.Size(93, 57);
            this.trazi.TabIndex = 16;
            this.trazi.Text = "Traži";
            this.trazi.UseVisualStyleBackColor = true;
            this.trazi.Click += new System.EventHandler(this.trazi_Click);
            // 
            // labe
            // 
            this.labe.AutoSize = true;
            this.labe.Location = new System.Drawing.Point(14, 197);
            this.labe.Name = "labe";
            this.labe.Size = new System.Drawing.Size(58, 13);
            this.labe.TabIndex = 12;
            this.labe.Text = "Optuženik:";
            // 
            // optuzenik
            // 
            this.optuzenik.Location = new System.Drawing.Point(102, 194);
            this.optuzenik.Name = "optuzenik";
            this.optuzenik.Size = new System.Drawing.Size(188, 20);
            this.optuzenik.TabIndex = 13;
            // 
            // ostecenik
            // 
            this.ostecenik.Location = new System.Drawing.Point(102, 231);
            this.ostecenik.Name = "ostecenik";
            this.ostecenik.Size = new System.Drawing.Size(188, 20);
            this.ostecenik.TabIndex = 15;
            // 
            // odustani
            // 
            this.odustani.Location = new System.Drawing.Point(471, 194);
            this.odustani.Name = "odustani";
            this.odustani.Size = new System.Drawing.Size(93, 57);
            this.odustani.TabIndex = 17;
            this.odustani.Text = "Odustani";
            this.odustani.UseVisualStyleBackColor = true;
            this.odustani.Click += new System.EventHandler(this.odustani_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Oštećenik:";
            // 
            // odvjetnik
            // 
            this.odvjetnik.Location = new System.Drawing.Point(357, 155);
            this.odvjetnik.Name = "odvjetnik";
            this.odvjetnik.Size = new System.Drawing.Size(207, 20);
            this.odvjetnik.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Odvjetnik:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "Rezultati:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(547, 170);
            this.dataGridView1.TabIndex = 18;
            // 
            // izmjena
            // 
            this.izmjena.Location = new System.Drawing.Point(17, 464);
            this.izmjena.Name = "izmjena";
            this.izmjena.Size = new System.Drawing.Size(136, 33);
            this.izmjena.TabIndex = 19;
            this.izmjena.Text = "Izmjeni";
            this.izmjena.UseVisualStyleBackColor = true;
            this.izmjena.Click += new System.EventHandler(this.izmjena_Click);
            // 
            // obrisi
            // 
            this.obrisi.Location = new System.Drawing.Point(428, 464);
            this.obrisi.Name = "obrisi";
            this.obrisi.Size = new System.Drawing.Size(136, 33);
            this.obrisi.TabIndex = 20;
            this.obrisi.Text = "Obriši";
            this.obrisi.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izborFonta,
            this.izborPozadina,
            this.izgledToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(595, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menu";
            // 
            // izborFonta
            // 
            this.izborFonta.Name = "izborFonta";
            this.izborFonta.Size = new System.Drawing.Size(43, 20);
            this.izborFonta.Text = "Font";
            this.izborFonta.Click += new System.EventHandler(this.izborFonta_Click);
            // 
            // izborPozadina
            // 
            this.izborPozadina.Name = "izborPozadina";
            this.izborPozadina.Size = new System.Drawing.Size(67, 20);
            this.izborPozadina.Text = "Pozadina";
            this.izborPozadina.Click += new System.EventHandler(this.izborPozadina_Click);
            // 
            // izgledToolStripMenuItem
            // 
            this.izgledToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temaTamna,
            this.temaSvjetla});
            this.izgledToolStripMenuItem.Name = "izgledToolStripMenuItem";
            this.izgledToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.izgledToolStripMenuItem.Text = "Tema";
            // 
            // temaTamna
            // 
            this.temaTamna.Name = "temaTamna";
            this.temaTamna.Size = new System.Drawing.Size(111, 22);
            this.temaTamna.Text = "Tamna";
            this.temaTamna.Click += new System.EventHandler(this.temaTamna_Click);
            // 
            // temaSvjetla
            // 
            this.temaSvjetla.Name = "temaSvjetla";
            this.temaSvjetla.Size = new System.Drawing.Size(111, 22);
            this.temaSvjetla.Text = "Svjetla";
            this.temaSvjetla.Click += new System.EventHandler(this.temaSvjetla_Click);
            // 
            // ProcesPretrazivanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 503);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.obrisi);
            this.Controls.Add(this.izmjena);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.odvjetnik);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.odustani);
            this.Controls.Add(this.ostecenik);
            this.Controls.Add(this.optuzenik);
            this.Controls.Add(this.labe);
            this.Controls.Add(this.trazi);
            this.Controls.Add(this.sud);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.urBroj);
            this.Controls.Add(this.klasa);
            this.Controls.Add(this.urBrojlabel);
            this.Controls.Add(this.klasalabel);
            this.Controls.Add(this.naziv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProcesPretrazivanje";
            this.Text = "Pretrazivanje procesa";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox naziv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox urBroj;
        private System.Windows.Forms.TextBox klasa;
        private System.Windows.Forms.Label urBrojlabel;
        private System.Windows.Forms.Label klasalabel;
        private System.Windows.Forms.Button trazi;
        private System.Windows.Forms.Label labe;
        private System.Windows.Forms.TextBox optuzenik;
        private System.Windows.Forms.TextBox ostecenik;
        private System.Windows.Forms.Button odustani;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox odvjetnik;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button izmjena;
        private System.Windows.Forms.Button obrisi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem izborFonta;
        private System.Windows.Forms.ToolStripMenuItem izborPozadina;
        private System.Windows.Forms.ToolStripMenuItem izgledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temaTamna;
        private System.Windows.Forms.ToolStripMenuItem temaSvjetla;
    }
}