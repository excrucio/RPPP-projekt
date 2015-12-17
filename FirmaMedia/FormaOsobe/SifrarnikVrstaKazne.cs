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
    public partial class SifrarnikVrstaKazne : Form
    {
        bazaF.RPPP10 baza = new bazaF.RPPP10();
        public SifrarnikVrstaKazne()
        {
            InitializeComponent();
        }

        private void VrstaKazneLoad(object sender, EventArgs e)
        {
            var upit = baza.VrstaKazne.Select(x => new { x.NazivVrste });
            var Lista = upit.ToList();
            Podaci.DataSource = null;
            Podaci.DataSource = Lista;
            UnosPanel.Enabled = false;

            Podaci.Columns[0].HeaderText = "Vrsta kazne";
        }

        private void unesiNovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosPanel.Enabled = true;
        }

        private void obrišiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int red = Podaci.CurrentRow.Index;
            string Vrsta = Podaci[0, red].Value.ToString();

            var ZaBrisanjeKazna = from x in baza.VrstaKazne where x.NazivVrste == Vrsta select x;

            baza.VrstaKazne.RemoveRange(ZaBrisanjeKazna);

            try
            {
                baza.SaveChanges();
                MessageBox.Show("Obrisano!");
            }
            catch (Exception iznimka)
            {
                MessageBox.Show(iznimka.Message, "Greška prilikom brisanja!!!");
            }

            VrstaKazneLoad(this, e);
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            VrstaTextBox.Clear();
            UnosPanel.Enabled = false;
        }

        private void DodajButton_Click(object sender, EventArgs e)
        {
            int dalje = 1;

            if (string.IsNullOrWhiteSpace(VrstaTextBox.Text))
            {
                MessageBox.Show("Vrsta kazne ne smije biti prazna!");
                dalje = 0;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(VrstaTextBox.Text, "[0-9]"))
            {
                MessageBox.Show("Vrsta kazne ne smije u sebi imati brojeve!");
                dalje = 0;
            }

            if (dalje == 1)
            {
                bazaF.VrstaKazne kazna = new bazaF.VrstaKazne();

                try
                {
                    int Max = (from x in baza.VrstaKazne select x.SifraVrste).Max();
                    kazna.SifraVrste = Max + 1;
                }
                catch
                {
                    kazna.SifraVrste = 1;
                }

                kazna.NazivVrste = VrstaTextBox.Text;

                baza.VrstaKazne.Add(kazna);

                try
                {
                    baza.SaveChanges();
                    MessageBox.Show("Vrsta kazne je uspješno unesena!");
                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message, "Greška!");
                }
            }

            VrstaTextBox.Clear();
            VrstaKazneLoad(this, e);
        }
    }
}
