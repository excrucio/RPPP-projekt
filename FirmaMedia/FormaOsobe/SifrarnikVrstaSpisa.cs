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
    public partial class SifrarnikVrstaSpisa : Form
    {
        bazaF.RPPP10 baza = new bazaF.RPPP10();
        public SifrarnikVrstaSpisa()
        {
            InitializeComponent();
        }

        private void VrstaSpisaLoad(object sender, EventArgs e)
        {
            var upit = baza.VrstaSpisa.Select(x => new { x.NazivVrste });
            var Lista = upit.ToList();
            Podaci.DataSource = null;
            Podaci.DataSource = Lista;
            UnosPanel.Enabled = false;

            Podaci.Columns[0].HeaderText = "Vrsta spisa";
        }

        private void unesiNovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosPanel.Enabled = true;
        }

        private void obrišiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int red = Podaci.CurrentRow.Index;
            string Vrsta = Podaci[0, red].Value.ToString();

            var ZaBrisanjeSpis = from x in baza.VrstaSpisa where x.NazivVrste == Vrsta select x;

            baza.VrstaSpisa.RemoveRange(ZaBrisanjeSpis);

            try
            {
                baza.SaveChanges();
                MessageBox.Show("Obrisano!");
            }
            catch (Exception iznimka)
            {
                MessageBox.Show(iznimka.Message, "Greška prilikom brisanja!!!");
            }

            VrstaSpisaLoad(this, e);
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
                MessageBox.Show("Vrsta spisa ne smije biti prazna!");
                dalje = 0;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(VrstaTextBox.Text, "[0-9]"))
            {
                MessageBox.Show("Vrsta spisa ne smije u sebi imati brojeve!");
                dalje = 0;
            }

            if (dalje == 1)
            {
                bazaF.VrstaSpisa spis = new bazaF.VrstaSpisa();

                try
                {
                    int Max = (from x in baza.VrstaSpisa select x.SifraVrste).Max();
                    spis.SifraVrste = Max + 1;
                }
                catch
                {
                    spis.SifraVrste = 1;
                }

                spis.NazivVrste = VrstaTextBox.Text;

                baza.VrstaSpisa.Add(spis);

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
            VrstaSpisaLoad(this, e);
        }


    }
}
