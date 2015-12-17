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
    public partial class SifrarnikUlogaSudionika : Form
    {
        bazaF.RPPP10 baza = new bazaF.RPPP10();
        public SifrarnikUlogaSudionika()
        {
            InitializeComponent();
        }

        private void UlogeSudionikaLoad(object sender, EventArgs e)
        {
            var upit = baza.UlogaSudionika.Select(x => new { x.NazivUloge });
            var Lista = upit.ToList();
            Podaci.DataSource = null;
            Podaci.DataSource = Lista;
            UnosPanel.Enabled = false;

            Podaci.Columns[0].HeaderText = "Uloga sudionika";
        }

        private void unesiNovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosPanel.Enabled = true;
        }

        private void obrišiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int red = Podaci.CurrentRow.Index;
            string Vrsta = Podaci[0, red].Value.ToString();

            var ZaBrisanjeUloga = from x in baza.UlogaSudionika where x.NazivUloge == Vrsta select x;

            baza.UlogaSudionika.RemoveRange(ZaBrisanjeUloga);

            try
            {
                baza.SaveChanges();
                MessageBox.Show("Obrisano!");
            }
            catch (Exception iznimka)
            {
                MessageBox.Show(iznimka.Message, "Greška prilikom brisanja!!!");
            }

            UlogeSudionikaLoad(this, e);
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
                MessageBox.Show("Uloga sudionika ne smije biti prazna!");
                dalje = 0;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(VrstaTextBox.Text, "[0-9]"))
            {
                MessageBox.Show("Uloga sudionika ne smije u sebi imati brojeve!");
                dalje = 0;
            }

            if (dalje == 1)
            {
                bazaF.UlogaSudionika vrsta = new bazaF.UlogaSudionika();

                try
                {
                    int Max = (from x in baza.UlogaSudionika select x.SifraUloge).Max();
                    vrsta.SifraUloge = Max + 1;
                }
                catch
                {
                    vrsta.SifraUloge = 1;
                }

                vrsta.NazivUloge = VrstaTextBox.Text;

                baza.UlogaSudionika.Add(vrsta);

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
            UlogeSudionikaLoad(this, e);
        }
    }
}
