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
    public partial class SifrarnikVrstaPresude : Form
    {
        bazaF.RPPP10 baza = new bazaF.RPPP10();

        public SifrarnikVrstaPresude()
        {
            InitializeComponent();
        }

        private void VrstaPresudeLoad(object sender, EventArgs e)
        {
            var upit = baza.TipPresude.Select(x => new { x.NazivTipa });
            var Lista = upit.ToList();
            Podaci.DataSource = null;
            Podaci.DataSource = Lista;
            UnosPanel.Enabled = false;

            Podaci.Columns[0].HeaderText = "Vrsta presude";
        }

        private void unesiNovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosPanel.Enabled = true;
        }

        private void obrišiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int red = Podaci.CurrentRow.Index;
            string Vrsta = Podaci[0, red].Value.ToString();

            var ZaBrisanjeVrsta = from x in baza.TipPresude where x.NazivTipa == Vrsta select x;

            baza.TipPresude.RemoveRange(ZaBrisanjeVrsta);

            try
            {
                baza.SaveChanges();
                MessageBox.Show("Obrisano!");
            }
            catch (Exception iznimka)
            {
                MessageBox.Show(iznimka.Message, "Greška prilikom brisanja!!!");
            }

            VrstaPresudeLoad(this, e);
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
                MessageBox.Show("Vrsta presude ne smije biti prazna!");
                dalje = 0;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(VrstaTextBox.Text, "[0-9]"))
            {
                MessageBox.Show("Vrsta presude ne smije u sebi imati brojeve!");
                dalje = 0;
            }

            if (dalje == 1)
            {
                bazaF.TipPresude vrsta = new bazaF.TipPresude();

                try
                {
                    int Max = (from x in baza.TipPresude select x.SifraTipa).Max();
                    vrsta.SifraTipa = Max + 1;
                }
                catch
                {
                    vrsta.SifraTipa = 1;
                }

                vrsta.NazivTipa = VrstaTextBox.Text;

                baza.TipPresude.Add(vrsta);

                try
                {
                    baza.SaveChanges();
                    MessageBox.Show("Vrsta presude je uspješno unesena!");
                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message, "Greška!");
                }
            }

            VrstaTextBox.Clear();
            VrstaPresudeLoad(this, e);
        }
    }
}
