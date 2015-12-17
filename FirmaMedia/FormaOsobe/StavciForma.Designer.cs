namespace FormaOsobe
{
    partial class StavciForma
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
            this.Podaci = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dodajNoviStavakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izbrišiOdabraniStavakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StavakTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ImeStavkaTextBox = new System.Windows.Forms.TextBox();
            this.ImeStavkaLabel = new System.Windows.Forms.Label();
            this.SpremiButton = new System.Windows.Forms.Button();
            this.OdustaniButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Podaci)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Podaci
            // 
            this.Podaci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Podaci.Location = new System.Drawing.Point(12, 61);
            this.Podaci.Name = "Podaci";
            this.Podaci.ReadOnly = true;
            this.Podaci.Size = new System.Drawing.Size(240, 180);
            this.Podaci.TabIndex = 0;
            this.Podaci.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Klik);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista stavaka";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajNoviStavakToolStripMenuItem,
            this.izbrišiOdabraniStavakToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(717, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dodajNoviStavakToolStripMenuItem
            // 
            this.dodajNoviStavakToolStripMenuItem.Name = "dodajNoviStavakToolStripMenuItem";
            this.dodajNoviStavakToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.dodajNoviStavakToolStripMenuItem.Text = "Dodaj novi stavak";
            this.dodajNoviStavakToolStripMenuItem.Click += new System.EventHandler(this.dodajNoviStavakToolStripMenuItem_Click);
            // 
            // izbrišiOdabraniStavakToolStripMenuItem
            // 
            this.izbrišiOdabraniStavakToolStripMenuItem.Name = "izbrišiOdabraniStavakToolStripMenuItem";
            this.izbrišiOdabraniStavakToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.izbrišiOdabraniStavakToolStripMenuItem.Text = "Izbriši odabrani stavak";
            this.izbrišiOdabraniStavakToolStripMenuItem.Click += new System.EventHandler(this.izbrišiOdabraniStavakToolStripMenuItem_Click);
            // 
            // StavakTextBox
            // 
            this.StavakTextBox.Location = new System.Drawing.Point(313, 110);
            this.StavakTextBox.Multiline = true;
            this.StavakTextBox.Name = "StavakTextBox";
            this.StavakTextBox.Size = new System.Drawing.Size(392, 131);
            this.StavakTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(308, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tekst stavka";
            // 
            // ImeStavkaTextBox
            // 
            this.ImeStavkaTextBox.Location = new System.Drawing.Point(313, 59);
            this.ImeStavkaTextBox.Name = "ImeStavkaTextBox";
            this.ImeStavkaTextBox.Size = new System.Drawing.Size(227, 20);
            this.ImeStavkaTextBox.TabIndex = 5;
            this.ImeStavkaTextBox.Visible = false;
            // 
            // ImeStavkaLabel
            // 
            this.ImeStavkaLabel.AutoSize = true;
            this.ImeStavkaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ImeStavkaLabel.Location = new System.Drawing.Point(308, 31);
            this.ImeStavkaLabel.Name = "ImeStavkaLabel";
            this.ImeStavkaLabel.Size = new System.Drawing.Size(115, 25);
            this.ImeStavkaLabel.TabIndex = 6;
            this.ImeStavkaLabel.Text = "Ime stavka";
            this.ImeStavkaLabel.Visible = false;
            // 
            // SpremiButton
            // 
            this.SpremiButton.Location = new System.Drawing.Point(313, 262);
            this.SpremiButton.Name = "SpremiButton";
            this.SpremiButton.Size = new System.Drawing.Size(75, 23);
            this.SpremiButton.TabIndex = 7;
            this.SpremiButton.Text = "Spremi";
            this.SpremiButton.UseVisualStyleBackColor = true;
            this.SpremiButton.Click += new System.EventHandler(this.SpremiButton_Click);
            // 
            // OdustaniButton
            // 
            this.OdustaniButton.Location = new System.Drawing.Point(422, 262);
            this.OdustaniButton.Name = "OdustaniButton";
            this.OdustaniButton.Size = new System.Drawing.Size(75, 23);
            this.OdustaniButton.TabIndex = 8;
            this.OdustaniButton.Text = "Odustani";
            this.OdustaniButton.UseVisualStyleBackColor = true;
            this.OdustaniButton.Click += new System.EventHandler(this.OdustaniButton_Click);
            // 
            // StavciForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 297);
            this.Controls.Add(this.OdustaniButton);
            this.Controls.Add(this.SpremiButton);
            this.Controls.Add(this.ImeStavkaLabel);
            this.Controls.Add(this.ImeStavkaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StavakTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Podaci);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StavciForma";
            this.Text = "Stavci";
            this.Load += new System.EventHandler(this.StavciLoad);
            ((System.ComponentModel.ISupportInitialize)(this.Podaci)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Podaci;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dodajNoviStavakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izbrišiOdabraniStavakToolStripMenuItem;
        private System.Windows.Forms.TextBox StavakTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ImeStavkaTextBox;
        private System.Windows.Forms.Label ImeStavkaLabel;
        private System.Windows.Forms.Button SpremiButton;
        private System.Windows.Forms.Button OdustaniButton;
    }
}