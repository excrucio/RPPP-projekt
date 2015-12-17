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
    public partial class SifrarnikKategorijaSuda : Form
    {
        bazaF.RPPP10 baza = new bazaF.RPPP10();
        public SifrarnikKategorijaSuda()
        {
            InitializeComponent();
        }

        private void KategorijaSudaLoad(object sender, EventArgs e)
        {
            var upit = baza.KategorijaSuda.Select(x => new { x.NazivKatSuda });
            var Lista = upit.ToList();
            Podaci.DataSource = null;
            Podaci.DataSource = Lista;
            UnosPanel.Enabled = false;

            Podaci.Columns[0].HeaderText = "Kategorija suda";
        }

        private void unesiNovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosPanel.Enabled = true;
        }

        private void obrišiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int red = Podaci.CurrentRow.Index;
            string Vrsta = Podaci[0, red].Value.ToString();

            var ZaBrisanjeKategorija = from x in baza.KategorijaSuda where x.NazivKatSuda == Vrsta select x;

            baza.KategorijaSuda.RemoveRange(ZaBrisanjeKategorija);

            try
            {
                baza.SaveChanges();
                MessageBox.Show("Obrisano!");
            }
            catch (Exception iznimka)
            {
                MessageBox.Show(iznimka.Message, "Greška prilikom brisanja!!!");
            }

            KategorijaSudaLoad(this, e);
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
                MessageBox.Show("Kategorija suda ne smije biti prazna!");
                dalje = 0;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(VrstaTextBox.Text, "[0-9]"))
            {
                MessageBox.Show("Kategorija suda ne smije u sebi imati brojeve!");
                dalje = 0;
            }

            if (dalje == 1)
            {
                bazaF.KategorijaSuda kategorija = new bazaF.KategorijaSuda();

                try
                {
                    int Max = (from x in baza.KategorijaSuda select x.SifraKatSuda).Max();
                    kategorija.SifraKatSuda = Max + 1;
                }
                catch
                {
                    kategorija.SifraKatSuda = 1;
                }

                kategorija.NazivKatSuda = VrstaTextBox.Text;

                baza.KategorijaSuda.Add(kategorija);

                try
                {
                    baza.SaveChanges();
                    MessageBox.Show("Uloga sudionika je uspješno unesena!");
                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message, "Greška!");
                }
            }

            VrstaTextBox.Clear();
            KategorijaSudaLoad(this, e);
        }
    }
}
