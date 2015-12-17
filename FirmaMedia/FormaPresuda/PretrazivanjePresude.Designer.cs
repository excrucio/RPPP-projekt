namespace FormaPresuda
{
    partial class PretrazivanjePresude
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
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.dgRezultati = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIme = new System.Windows.Forms.TextBox();
            this.btnPregledaj = new System.Windows.Forms.Button();
            this.colorDialogPretrazivanjePresuda = new System.Windows.Forms.ColorDialog();
            this.fontDialogPretrazivanjePresuda = new System.Windows.Forms.FontDialog();
            this.rbFiz = new System.Windows.Forms.RadioButton();
            this.rbPrav = new System.Windows.Forms.RadioButton();
            this.tbPrezime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUzmi = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.errorPregled = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorUzmi = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnObrisi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgRezultati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPregled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorUzmi)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(651, 67);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(93, 23);
            this.btnPretrazi.TabIndex = 5;
            this.btnPretrazi.Text = "Pretraži";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // dgRezultati
            // 
            this.dgRezultati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRezultati.Location = new System.Drawing.Point(34, 133);
            this.dgRezultati.MultiSelect = false;
            this.dgRezultati.Name = "dgRezultati";
            this.dgRezultati.Size = new System.Drawing.Size(687, 258);
            this.dgRezultati.TabIndex = 6;
            this.dgRezultati.Validating += new System.ComponentModel.CancelEventHandler(this.pregled_validate);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Osoba:";
            // 
            // tbIme
            // 
            this.tbIme.Location = new System.Drawing.Point(139, 69);
            this.tbIme.Name = "tbIme";
            this.tbIme.Size = new System.Drawing.Size(282, 20);
            this.tbIme.TabIndex = 3;
            // 
            // btnPregledaj
            // 
            this.btnPregledaj.Location = new System.Drawing.Point(118, 397);
            this.btnPregledaj.Name = "btnPregledaj";
            this.btnPregledaj.Size = new System.Drawing.Size(112, 23);
            this.btnPregledaj.TabIndex = 7;
            this.btnPregledaj.Text = "Pregledaj/Izmjeni";
            this.btnPregledaj.UseVisualStyleBackColor = true;
            this.btnPregledaj.Click += new System.EventHandler(this.btnPregledaj_Click);
            // 
            // rbFiz
            // 
            this.rbFiz.AutoSize = true;
            this.rbFiz.Checked = true;
            this.rbFiz.Location = new System.Drawing.Point(34, 37);
            this.rbFiz.Name = "rbFiz";
            this.rbFiz.Size = new System.Drawing.Size(90, 17);
            this.rbFiz.TabIndex = 103;
            this.rbFiz.TabStop = true;
            this.rbFiz.Text = "Fizička osoba";
            this.rbFiz.UseVisualStyleBackColor = true;
            this.rbFiz.CheckedChanged += new System.EventHandler(this.rbFiz_CheckedChanged);
            // 
            // rbPrav
            // 
            this.rbPrav.AutoSize = true;
            this.rbPrav.Location = new System.Drawing.Point(139, 37);
            this.rbPrav.Name = "rbPrav";
            this.rbPrav.Size = new System.Drawing.Size(91, 17);
            this.rbPrav.TabIndex = 104;
            this.rbPrav.Text = "Pravna osoba";
            this.rbPrav.UseVisualStyleBackColor = true;
            this.rbPrav.CheckedChanged += new System.EventHandler(this.rbPrav_CheckedChanged);
            // 
            // tbPrezime
            // 
            this.tbPrezime.Location = new System.Drawing.Point(446, 69);
            this.tbPrezime.Name = "tbPrezime";
            this.tbPrezime.Size = new System.Drawing.Size(170, 20);
            this.tbPrezime.TabIndex = 105;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Rezultati:";
            // 
            // btnUzmi
            // 
            this.btnUzmi.Location = new System.Drawing.Point(469, 397);
            this.btnUzmi.Name = "btnUzmi";
            this.btnUzmi.Size = new System.Drawing.Size(106, 23);
            this.btnUzmi.TabIndex = 107;
            this.btnUzmi.Text = "Preuzmi presudu";
            this.btnUzmi.UseVisualStyleBackColor = true;
            this.btnUzmi.Click += new System.EventHandler(this.btnUzmi_Click);
            // 
            // errorPregled
            // 
            this.errorPregled.ContainerControl = this;
            // 
            // errorUzmi
            // 
            this.errorUzmi.ContainerControl = this;
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(315, 397);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(75, 23);
            this.btnObrisi.TabIndex = 108;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // PretrazivanjePresude
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 472);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnUzmi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPrezime);
            this.Controls.Add(this.rbPrav);
            this.Controls.Add(this.rbFiz);
            this.Controls.Add(this.btnPregledaj);
            this.Controls.Add(this.tbIme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgRezultati);
            this.Controls.Add(this.btnPretrazi);
            this.Name = "PretrazivanjePresude";
            this.Text = "Pretraživanje presuda";
            this.Load += new System.EventHandler(this.PretrazivanjePresude_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRezultati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPregled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorUzmi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.DataGridView dgRezultati;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIme;
        private System.Windows.Forms.Button btnPregledaj;
        private System.Windows.Forms.ColorDialog colorDialogPretrazivanjePresuda;
        private System.Windows.Forms.FontDialog fontDialogPretrazivanjePresuda;
        private System.Windows.Forms.RadioButton rbFiz;
        private System.Windows.Forms.RadioButton rbPrav;
        private System.Windows.Forms.TextBox tbPrezime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUzmi;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ErrorProvider errorPregled;
        private System.Windows.Forms.ErrorProvider errorUzmi;
        private System.Windows.Forms.Button btnObrisi;
    }
}