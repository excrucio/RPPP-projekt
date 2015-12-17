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
    public partial class SifrarnikVrstaOznake : Form
    {
        bazaF.RPPP10 baza = new bazaF.RPPP10();
        public SifrarnikVrstaOznake()
        {
            InitializeComponent();
        }

        private void VrstaOznakeLoad(object sender, EventArgs e)
        {
            var upit = baza.VrstaOznake.Select(x => new { x.SifraOznake, x.OpisOznake });
            var Lista = upit.ToList();
            Podaci.DataSource = null;
            Podaci.DataSource = Lista;
            UnosPanel.Enabled = false;

            Podaci.Columns[0].HeaderText = "Šifra spisa";
            Podaci.Columns[1].HeaderText = "Opis oznake";
        }

        private void unesiNovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosPanel.Enabled = true;
        }

        private void obrišiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int red = Podaci.CurrentRow.Index;
            string Vrsta = Podaci[0, red].Value.ToString();

            var ZaBrisanjeOznaka = from x in baza.VrstaOznake where x.SifraOznake == Vrsta select x;

            baza.VrstaOznake.RemoveRange(ZaBrisanjeOznaka);

            try
            {
                baza.SaveChanges();
                MessageBox.Show("Obrisano!");
            }
            catch (Exception iznimka)
            {
                MessageBox.Show(iznimka.Message, "Greška prilikom brisanja!!!");
            }

            VrstaOznakeLoad(this, e);
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            VrstaTextBox.Clear();
            SifraTextBox.Clear();
            UnosPanel.Enabled = false;
        }

        private void DodajButton_Click(object sender, EventArgs e)
        {
            int dalje = 1;

            if (string.IsNullOrWhiteSpace(VrstaTextBox.Text))
            {
                MessageBox.Show("Vrsta spisa ne smije biti prazna!");
                dalje = 0;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(VrstaTextBox.Text, "[0-9]"))
            {
                MessageBox.Show("Vrsta spisa ne smije u sebi imati brojeve!");
                dalje = 0;
            }
            else if (string.IsNullOrWhiteSpace(SifraTextBox.Text))
            {
                MessageBox.Show("Šifra spisa ne smije biti prazna!");
                dalje = 0;
            }

            var a = from x in baza.VrstaOznake where x.SifraOznake == SifraTextBox.Text select x;
            int broj = a.Count();

            if (broj != 0)
            {
                MessageBox.Show("Ta šifra već postoji!");
                dalje = 0;
            }

            if (dalje == 1)
            {
                bazaF.VrstaOznake oznaka = new bazaF.VrstaOznake();

                oznaka.SifraOznake = SifraTextBox.Text;
                oznaka.OpisOznake = VrstaTextBox.Text;

                baza.VrstaOznake.Add(oznaka);

                try
                {
                    baza.SaveChanges();
                    MessageBox.Show("Vrsta spisa je uspješno unesena!");
                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message, "Greška!");
                }
            }

            VrstaTextBox.Clear();
            SifraTextBox.Clear();
            VrstaOznakeLoad(this, e);
        }

    }
}
