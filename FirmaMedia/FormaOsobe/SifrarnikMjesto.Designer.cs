namespace FormaOsobe
{
    partial class Mjesta
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
            this.PBrTextBox = new System.Windows.Forms.TextBox();
            this.NazivTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.unesiNovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obrišiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DodajButton = new System.Windows.Forms.Button();
            this.OdustaniButton = new System.Windows.Forms.Button();
            this.UnosPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Podaci)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.UnosPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Podaci
            // 
            this.Podaci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Podaci.Location = new System.Drawing.Point(12, 38);
            this.Podaci.Name = "Podaci";
            this.Podaci.Size = new System.Drawing.Size(260, 150);
            this.Podaci.TabIndex = 0;
            // 
            // PBrTextBox
            // 
            this.PBrTextBox.Location = new System.Drawing.Point(92, 36);
            this.PBrTextBox.MaxLength = 5;
            this.PBrTextBox.Name = "PBrTextBox";
            this.PBrTextBox.Size = new System.Drawing.Size(100, 20);
            this.PBrTextBox.TabIndex = 1;
            // 
            // NazivTextBox
            // 
            this.NazivTextBox.Location = new System.Drawing.Point(92, 6);
            this.NazivTextBox.MaxLength = 200;
            this.NazivTextBox.Name = "NazivTextBox";
            this.NazivTextBox.Size = new System.Drawing.Size(100, 20);
            this.NazivTextBox.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unesiNovoToolStripMenuItem,
            this.obrišiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(492, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // unesiNovoToolStripMenuItem
            // 
            this.unesiNovoToolStripMenuItem.Name = "unesiNovoToolStripMenuItem";
            this.unesiNovoToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.unesiNovoToolStripMenuItem.Text = "Unesi novo";
            this.unesiNovoToolStripMenuItem.Click += new System.EventHandler(this.unesiNovoToolStripMenuItem_Click);
            // 
            // obrišiToolStripMenuItem
            // 
            this.obrišiToolStripMenuItem.Name = "obrišiToolStripMenuItem";
            this.obrišiToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.obrišiToolStripMenuItem.Text = "Obriši";
            this.obrišiToolStripMenuItem.Click += new System.EventHandler(this.obrišiToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Poštanski broj";
            // 
            // DodajButton
            // 
            this.DodajButton.Location = new System.Drawing.Point(6, 81);
            this.DodajButton.Name = "DodajButton";
            this.DodajButton.Size = new System.Drawing.Size(75, 23);
            this.DodajButton.TabIndex = 6;
            this.DodajButton.Text = "Dodaj";
            this.DodajButton.UseVisualStyleBackColor = true;
            this.DodajButton.Click += new System.EventHandler(this.DodajButton_Click);
            // 
            // OdustaniButton
            // 
            this.OdustaniButton.Location = new System.Drawing.Point(117, 81);
            this.OdustaniButton.Name = "OdustaniButton";
            this.OdustaniButton.Size = new System.Drawing.Size(75, 23);
            this.OdustaniButton.TabIndex = 7;
            this.OdustaniButton.Text = "Odustani";
            this.OdustaniButton.UseVisualStyleBackColor = true;
            this.OdustaniButton.Click += new System.EventHandler(this.OdustaniButton_Click);
            // 
            // UnosPanel
            // 
            this.UnosPanel.Controls.Add(this.NazivTextBox);
            this.UnosPanel.Controls.Add(this.OdustaniButton);
            this.UnosPanel.Controls.Add(this.PBrTextBox);
            this.UnosPanel.Controls.Add(this.DodajButton);
            this.UnosPanel.Controls.Add(this.label1);
            this.UnosPanel.Controls.Add(this.label2);
            this.UnosPanel.Location = new System.Drawing.Point(280, 38);
            this.UnosPanel.Name = "UnosPanel";
            this.UnosPanel.Size = new System.Drawing.Size(200, 113);
            this.UnosPanel.TabIndex = 8;
            // 
            // Mjesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 213);
            this.Controls.Add(this.UnosPanel);
            this.Controls.Add(this.Podaci);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mjesta";
            this.Text = "Mjesta";
            this.Load += new System.EventHandler(this.MjestoLoad);
            ((System.ComponentModel.ISupportInitialize)(this.Podaci)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.UnosPanel.ResumeLayout(false);
            this.UnosPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Podaci;
        private System.Windows.Forms.TextBox PBrTextBox;
        private System.Windows.Forms.TextBox NazivTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem unesiNovoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obrišiToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DodajButton;
        private System.Windows.Forms.Button OdustaniButton;
        private System.Windows.Forms.Panel UnosPanel;
    }
}