namespace FirmaMedia
{
    partial class Zakoni
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
            this.Upit = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Opisni_tekst = new System.Windows.Forms.Label();
            this.PoImenu = new System.Windows.Forms.RadioButton();
            this.PoRazini = new System.Windows.Forms.RadioButton();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.PoIDu = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Upit
            // 
            this.Upit.Location = new System.Drawing.Point(15, 25);
            this.Upit.Name = "Upit";
            this.Upit.Size = new System.Drawing.Size(280, 20);
            this.Upit.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "Pretraživanje";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Opisni_tekst
            // 
            this.Opisni_tekst.AutoSize = true;
            this.Opisni_tekst.Location = new System.Drawing.Point(12, 9);
            this.Opisni_tekst.Name = "Opisni_tekst";
            this.Opisni_tekst.Size = new System.Drawing.Size(237, 13);
            this.Opisni_tekst.TabIndex = 2;
            this.Opisni_tekst.Text = "Unesite naziv zakona ili pojam koji želite pretražiti";
            // 
            // PoImenu
            // 
            this.PoImenu.AutoSize = true;
            this.PoImenu.Checked = true;
            this.PoImenu.Location = new System.Drawing.Point(15, 51);
            this.PoImenu.Name = "PoImenu";
            this.PoImenu.Size = new System.Drawing.Size(69, 17);
            this.PoImenu.TabIndex = 3;
            this.PoImenu.TabStop = true;
            this.PoImenu.Text = "Po imenu";
            this.PoImenu.UseVisualStyleBackColor = true;
            // 
            // PoRazini
            // 
            this.PoRazini.AutoSize = true;
            this.PoRazini.Location = new System.Drawing.Point(97, 51);
            this.PoRazini.Name = "PoRazini";
            this.PoRazini.Size = new System.Drawing.Size(65, 17);
            this.PoRazini.TabIndex = 4;
            this.PoRazini.Text = "Po razini";
            this.PoRazini.UseVisualStyleBackColor = true;
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToResizeColumns = false;
            this.DataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(15, 74);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(280, 199);
            this.DataGrid.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(301, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Dodaj zakon";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PoIDu
            // 
            this.PoIDu.AutoSize = true;
            this.PoIDu.Location = new System.Drawing.Point(184, 51);
            this.PoIDu.Name = "PoIDu";
            this.PoIDu.Size = new System.Drawing.Size(61, 17);
            this.PoIDu.TabIndex = 7;
            this.PoIDu.Text = "Po ID-u";
            this.PoIDu.UseVisualStyleBackColor = true;
            // 
            // Zakoni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 276);
            this.Controls.Add(this.PoIDu);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.PoRazini);
            this.Controls.Add(this.PoImenu);
            this.Controls.Add(this.Opisni_tekst);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Upit);
            this.Name = "Zakoni";
            this.Text = "Zakoni";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Upit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Opisni_tekst;
        private System.Windows.Forms.RadioButton PoImenu;
        private System.Windows.Forms.RadioButton PoRazini;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton PoIDu;
    }
}

