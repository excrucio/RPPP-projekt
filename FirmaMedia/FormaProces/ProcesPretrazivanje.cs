using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaProces
{
    public partial class ProcesPretrazivanje : Form
    {
        FontDialog fontDialog = new FontDialog();
        ColorDialog colorDialog = new ColorDialog();

        // početi font i boja
        Font defaultFont; 
        Color defaultColor;

        bazaF.RPPP10 baza = new bazaF.RPPP10();

        public ProcesPretrazivanje()
        {
            InitializeComponent();

            defaultFont = this.Font;
            defaultColor = this.BackColor;
        }

        private void izborFonta_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.Font = fontDialog.Font;
            }
        }

        private void temaSvjetla_Click(object sender, EventArgs e)
        {
            this.Font = defaultFont;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BackColor = Color.White;
        }

        private void izborPozadina_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.BackColor = colorDialog.Color;
            }
        }

        private void temaTamna_Click(object sender, EventArgs e)
        {
            this.ForeColor = Color.WhiteSmoke;
            this.BackColor = Color.FromArgb(80, 80, 80);
        }

        private void odustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trazi_Click(object sender, EventArgs e)
        {
            var proces = from x in baza.Proces
                         join y in baza.VrstaOznake on x.Oznaka equals y.SifraOznake
                         select new { x.Naziv, x.Klasa, x.Broj, y.OpisOznake};
            dataGridView1.DataSource = proces.ToList();
        }

        private void izmjena_Click(object sender, EventArgs e)
        {
            ProcesUnos proces = new ProcesUnos(1);
            proces.Show();
        }
    }
}
