﻿namespace FirmaMedia
{
    partial class UnosZakona
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ImeZakonaTextBox = new System.Windows.Forms.Label();
            this.RazinaTextBox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ImeDat = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(103, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(205, 20);
            this.textBox2.TabIndex = 1;
            // 
            // ImeZakonaTextBox
            // 
            this.ImeZakonaTextBox.AutoSize = true;
            this.ImeZakonaTextBox.Location = new System.Drawing.Point(8, 12);
            this.ImeZakonaTextBox.Name = "ImeZakonaTextBox";
            this.ImeZakonaTextBox.Size = new System.Drawing.Size(62, 13);
            this.ImeZakonaTextBox.TabIndex = 2;
            this.ImeZakonaTextBox.Text = "Ime zakona";
            // 
            // RazinaTextBox
            // 
            this.RazinaTextBox.AutoSize = true;
            this.RazinaTextBox.Location = new System.Drawing.Point(8, 38);
            this.RazinaTextBox.Name = "RazinaTextBox";
            this.RazinaTextBox.Size = new System.Drawing.Size(40, 13);
            this.RazinaTextBox.TabIndex = 3;
            this.RazinaTextBox.Text = "Razina";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nadređeni zakon";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Odaberi datoteku";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ImeDat
            // 
            this.ImeDat.AutoSize = true;
            this.ImeDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ImeDat.Location = new System.Drawing.Point(147, 92);
            this.ImeDat.Name = "ImeDat";
            this.ImeDat.Size = new System.Drawing.Size(72, 16);
            this.ImeDat.TabIndex = 9;
            this.ImeDat.Text = "Datoteka...";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 34);
            this.button2.TabIndex = 10;
            this.button2.Text = "Dodaj zakon";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(281, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 34);
            this.button3.TabIndex = 11;
            this.button3.Text = "Odustani";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // UnosZakona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 175);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ImeDat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RazinaTextBox);
            this.Controls.Add(this.ImeZakonaTextBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "UnosZakona";
            this.Text = "UnosZakona";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label ImeZakonaTextBox;
        private System.Windows.Forms.Label RazinaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ImeDat;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}