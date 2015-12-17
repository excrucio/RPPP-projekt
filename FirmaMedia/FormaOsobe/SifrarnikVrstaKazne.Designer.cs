namespace FormaOsobe
{
    partial class SifrarnikVrstaKazne
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
            this.UnosPanel = new System.Windows.Forms.Panel();
            this.VrstaTextBox = new System.Windows.Forms.TextBox();
            this.OdustaniButton = new System.Windows.Forms.Button();
            this.DodajButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Podaci = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.unesiNovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obrišiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnosPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Podaci)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UnosPanel
            // 
            this.UnosPanel.Controls.Add(this.VrstaTextBox);
            this.UnosPanel.Controls.Add(this.OdustaniButton);
            this.UnosPanel.Controls.Add(this.DodajButton);
            this.UnosPanel.Controls.Add(this.label1);
            this.UnosPanel.Location = new System.Drawing.Point(163, 37);
            this.UnosPanel.Name = "UnosPanel";
            this.UnosPanel.Size = new System.Drawing.Size(197, 84);
            this.UnosPanel.TabIndex = 11;
            // 
            // VrstaTextBox
            // 
            this.VrstaTextBox.Location = new System.Drawing.Point(92, 6);
            this.VrstaTextBox.MaxLength = 200;
            this.VrstaTextBox.Name = "VrstaTextBox";
            this.VrstaTextBox.Size = new System.Drawing.Size(100, 20);
            this.VrstaTextBox.TabIndex = 2;
            // 
            // OdustaniButton
            // 
            this.OdustaniButton.Location = new System.Drawing.Point(114, 41);
            this.OdustaniButton.Name = "OdustaniButton";
            this.OdustaniButton.Size = new System.Drawing.Size(75, 23);
            this.OdustaniButton.TabIndex = 7;
            this.OdustaniButton.Text = "Odustani";
            this.OdustaniButton.UseVisualStyleBackColor = true;
            this.OdustaniButton.Click += new System.EventHandler(this.OdustaniButton_Click);
            // 
            // DodajButton
            // 
            this.DodajButton.Location = new System.Drawing.Point(3, 41);
            this.DodajButton.Name = "DodajButton";
            this.DodajButton.Size = new System.Drawing.Size(75, 23);
            this.DodajButton.TabIndex = 6;
            this.DodajButton.Text = "Dodaj";
            this.DodajButton.UseVisualStyleBackColor = true;
            this.DodajButton.Click += new System.EventHandler(this.DodajButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vrsta kazne";
            // 
            // Podaci
            // 
            this.Podaci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Podaci.Location = new System.Drawing.Point(12, 37);
            this.Podaci.Name = "Podaci";
            this.Podaci.Size = new System.Drawing.Size(145, 150);
            this.Podaci.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unesiNovoToolStripMenuItem,
            this.obrišiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(367, 24);
            this.menuStrip1.TabIndex = 10;
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
            // SifrarnikVrstaKazne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 201);
            this.Controls.Add(this.UnosPanel);
            this.Controls.Add(this.Podaci);
            this.Controls.Add(this.menuStrip1);
            this.Name = "SifrarnikVrstaKazne";
            this.Text = "Vrste kazne";
            this.Load += new System.EventHandler(this.VrstaKazneLoad);
            this.UnosPanel.ResumeLayout(false);
            this.UnosPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Podaci)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel UnosPanel;
        private System.Windows.Forms.TextBox VrstaTextBox;
        private System.Windows.Forms.Button OdustaniButton;
        private System.Windows.Forms.Button DodajButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Podaci;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem unesiNovoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obrišiToolStripMenuItem;

    }
}