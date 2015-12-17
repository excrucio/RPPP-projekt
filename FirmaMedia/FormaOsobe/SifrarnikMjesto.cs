using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaOsobe
{
    public partial class Mjesta : Form
    {
        bazaF.RPPP10 baza = new bazaF.RPPP10();
        public Mjesta()
        {
            InitializeComponent();
        }

        private void MjestoLoad(object sender, EventArgs e)
        {
            var upit = baza.Mjesto.Select(x => new { x.Naziv, x.PBr });
            var Lista = upit.ToList();
            Podaci.DataSource = null;
            Podaci.DataSource = Lista;
            UnosPanel.Enabled = false;
            Podaci.Columns[1].HeaderText = "Poštanski broj";
        }

        private void unesiNovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosPanel.Enabled = true;
        }

        private void obrišiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int red = Podaci.CurrentRow.Index;
            int Pbr = Convert.ToInt32(Podaci[1, red].Value);

            var ZaBrisanjeMjesto = from x in baza.Mjesto where x.PBr == Pbr select x;

            baza.Mjesto.RemoveRange(ZaBrisanjeMjesto);

            try
            {
                baza.SaveChanges();
                MessageBox.Show("Obrisano!");
            }
            catch (Exception iznimka)
            {
                MessageBox.Show(iznimka.Message, "Greška prilikom brisanja!!!");
            }

            MjestoLoad(this, e);
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            NazivTextBox.Clear();
            PBrTextBox.Clear();
            UnosPanel.Enabled = false;
        }

        private void DodajButton_Click(object sender, EventArgs e)
        {
            int dalje = 1;

            if (string.IsNullOrWhiteSpace(NazivTextBox.Text))
            {
                MessageBox.Show("Naziv ne smije biti prazan!");
                dalje = 0;
            }
            else if (string.IsNullOrWhiteSpace(PBrTextBox.Text))
            {
                MessageBox.Show("Poštanski broj ne smije biti prazan!");
                dalje = 0;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(NazivTextBox.Text, "[0-9]"))
            {
                MessageBox.Show("Naziv ne smije u sebi imati brojeve!");
                dalje = 0;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(PBrTextBox.Text, "[0-9]{5}"))
            {
                MessageBox.Show("Poštanski broj se sastoji od 5 znamenaka!");
                dalje = 0;
            }

            if (dalje == 1)
            {
                bazaF.Mjesto mjesto = new bazaF.Mjesto();

                mjesto.Naziv = NazivTextBox.Text;
                mjesto.PBr = Convert.ToInt32(PBrTextBox.Text);

                baza.Mjesto.Add(mjesto);

                try
                {
                    baza.SaveChanges();
                    MessageBox.Show("Mjesto uspješno uneseno!");
                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message, "Greška!");
                }
            }

            NazivTextBox.Clear();
            PBrTextBox.Clear();

            MjestoLoad(this, e);
        }
    }
}
