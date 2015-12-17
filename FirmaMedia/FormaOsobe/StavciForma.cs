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
    public partial class StavciForma : Form
    {
        bazaF.RPPP10 baza = new bazaF.RPPP10(); //varijable koje su bitne za cijeli program 
        int IDClanak;
        public StavciForma(int IDClanka)
        {
            IDClanak = IDClanka;
            InitializeComponent();
        }

        private void StavciLoad(object sender, EventArgs e) //Učitavanje forme
        {
            var upit = baza.Zakon.Where(x => x.IDNadredenog == IDClanak).Select(x => new { x.IDZakona, x.Naziv });
            var Lista = upit.ToList();
            Podaci.DataSource = null;
            Podaci.DataSource = Lista;
            Podaci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Podaci.Columns[0].Visible = false;
            SpremiButton.Visible = false;
            OdustaniButton.Visible = false;
        }

        private void Klik(object sender, DataGridViewCellEventArgs e) //Ispis teksta stavka zakona u TextBox
        {
            bazaF.Zakon stavak = new bazaF.Zakon();

            try
            {
                int red = Podaci.CurrentRow.Index;
                int ID = Convert.ToInt32(Podaci[0, red].Value);

                stavak = baza.Zakon.First(x => x.IDZakona == ID);
                char[] tekst = new char[stavak.Dokument.Length / sizeof(char)];
                System.Buffer.BlockCopy(stavak.Dokument, 0, tekst, 0, stavak.Dokument.Length);
                StavakTextBox.Text = new string(tekst);
            }
            catch { }
        }

        private void dodajNoviStavakToolStripMenuItem_Click(object sender, EventArgs e) //Omogućavanje dodavanja novog stavka
        {
            ImeStavkaTextBox.Clear();
            StavakTextBox.Clear();
            ImeStavkaLabel.Visible = true;
            ImeStavkaTextBox.Visible = true;
            SpremiButton.Visible = true;
            OdustaniButton.Visible = true;
        }

        private void OdustaniButton_Click(object sender, EventArgs e) //Odustajanje od trenutne radnje
        {
            ImeStavkaTextBox.Clear();
            StavakTextBox.Clear();
            ImeStavkaLabel.Visible = false;
            ImeStavkaTextBox.Visible = false;
            SpremiButton.Visible = false;
            OdustaniButton.Visible = false;
        }

        private void SpremiButton_Click(object sender, EventArgs e) //Provjera i spremanje stavka pod trenutni članak
        {
            bazaF.Zakon stavak = new bazaF.Zakon();

            int dalje = 1;

            if (string.IsNullOrWhiteSpace(ImeStavkaTextBox.Text))
            {
                MessageBox.Show("Niste unijeli naziv stavka!");
                dalje = 0;
            }
            else if (string.IsNullOrWhiteSpace(StavakTextBox.Text))
            {
                MessageBox.Show("Niste unijeli tekst stavka!");
                dalje = 0;
            }

            if (dalje == 1)
            {
                try
                {
                    int Max = (from x in baza.Zakon select x.IDZakona).Max();
                    stavak.IDZakona = Max + 1;
                }
                catch
                {
                    stavak.IDZakona = 1;
                }

                stavak.IDNadredenog = IDClanak;
                stavak.Naziv = ImeStavkaTextBox.Text;
                stavak.Razina = 3;
                byte[] dokument = new byte[StavakTextBox.Text.Length * sizeof(char)];
                System.Buffer.BlockCopy(StavakTextBox.Text.ToCharArray(), 0, dokument, 0, dokument.Length);
                stavak.Dokument = dokument;

                baza.Zakon.Add(stavak);

                try
                {
                    baza.SaveChanges();
                    MessageBox.Show("Stavak je uspješno unesen!");
                }
                catch
                {
                    MessageBox.Show("Greška se dogodila prilikom spremanja stavka!");
                }

                ImeStavkaTextBox.Clear();
                StavakTextBox.Clear();
                ImeStavkaLabel.Visible = false;
                ImeStavkaTextBox.Visible = false;
                SpremiButton.Visible = false;
                OdustaniButton.Visible = false;

                StavciLoad(this, e);
            }
        }

        private void izbrišiOdabraniStavakToolStripMenuItem_Click(object sender, EventArgs e) //Brisanje odabranog stavka
        {
            int dalje = 1;
            int red = 0;
            try
            {
                red = Podaci.CurrentRow.Index;
            }
            catch
            {
                dalje = 0;
            }
            if (dalje == 1)
            {
                int ID = Convert.ToInt32(Podaci[0, red].Value);
                string Naziv = Podaci[1, red].Value.ToString();
                if (MessageBox.Show("Želite li trajno obrisati stavak \"" + Naziv + "\" ?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var ZaBrisanje = from x in baza.Zakon where x.IDZakona == ID select x;

                    baza.Zakon.RemoveRange(ZaBrisanje);

                    try
                    {
                        baza.SaveChanges();
                        MessageBox.Show("Obrisano!");
                    }
                    catch (Exception iznimka)
                    {
                        MessageBox.Show(iznimka.Message, "Greška prilikom brisanja!!!");
                    }
                }

                StavciLoad(this, e);
            } 
        }
    }
}
