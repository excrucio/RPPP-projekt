using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaKazna
{
    public partial class KaznaMaster : Form
    {
        BindingSource Osobe = new BindingSource();
        bazaF.RPPP10 baza = new bazaF.RPPP10();
        int BrojRetka = 0;
        int UnosNovog = 0;
        public KaznaMaster()
        {
            InitializeComponent();
        }

        private void KaznaMaster_Load(object sender, EventArgs e)
        {
            bindNavigator.Visible = false;

            try
            {
                List<string> vrstaKazne = baza.VrstaKazne.Select(x => x.NazivVrste).ToList();
                VrstaKazneCombo.DataSource = vrstaKazne;

                var upit = baza.Optuzenik.Select(x => new { x.IDOsobe });
                var Lista = upit.ToList();

                Osobe.DataSource = Lista;
                bindingSourceOsobe.DataSource = Osobe;
                bindNavigator.BindingSource = Osobe;
                toolStripLabel2.Enabled = false;
                OdustaniButton.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Ne mogu dohvatiti podatke iz baze!");
            }
            dgKazne.Columns[5].Visible = false;
            bindNavigator.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int dalje = 1;

            try
            {
                BrojRetka = dgKazne.CurrentRow.Index;
            }
            catch 
            {
                dalje = 0;
            }

            int broj = dgKazne.Rows.Count;
            if (dalje == 1 && dgKazne.Rows.Count != 1)
            {
                label14.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                VrstaKazneCombo.Visible = true;
                UrediButton.Visible = true;
                IznosText.Visible = true;
                OpisText.Visible = true;
                ObrisiButton.Enabled = false;
                DodajButton.Enabled = false;
                toolStripLabel2.Enabled = true;
                OdustaniButton.Enabled = true;
                dgKazne.Enabled = true;

                try
                {
                    VrstaKazneCombo.Text = dgKazne[0, BrojRetka].Value.ToString();
                }
                catch
                {
                    VrstaKazneCombo.SelectedIndex = -1;
                }

                try
                {
                    IznosText.Text = dgKazne[1, BrojRetka].Value.ToString();
                }
                catch
                {
                    IznosText.Text = "0";
                }

                try
                {
                    OpisText.Text = dgKazne[2, BrojRetka].Value.ToString();
                }
                catch
                {
                    OpisText.Text = "";
                }
            }

        }

        private void Promjena(object sender, EventArgs e)
        {
            ObrisiButton.Enabled = false;
            dgKazne.Rows.Clear();

            int Broj = DajIDTrenutneOsobe();

            int nadjeno = 0;

            try
            {
                var upit = baza.FizickaOsoba.First(x => x.IDOsobe == Broj);
                panelFizicke.Visible = true;
                panelPravne.Visible = false;
                tbIme.Text = upit.Ime;
                tbPrezime.Text = upit.Prezime;
                tbImeOca.Text = upit.ImeOca;
                datePickFIz.Value = upit.DatumRod.Value;
                tbJmbgFiz.Text = upit.JMBG;
                tbOibFiz.Text = upit.Osoba.OIB;
                tbUlicaFiz.Text = upit.Osoba.UlicaIKucniBr;
                cbMjestoFiz.Text = upit.Osoba.Mjesto.Naziv;

                nadjeno = 1;
            }
            catch { }

            if (nadjeno == 0)
            {
                var upit2 = baza.PravnaOsoba.First(x => x.IDOsobe == Broj);
                panelFizicke.Visible = false;
                panelPravne.Visible = true;
                tbNaziv.Text = upit2.Naziv;
                tbOibPrav.Text = upit2.Osoba.OIB;
                tbUlicaPrav.Text = upit2.Osoba.UlicaIKucniBr;
                cbMjestoPrav.Text = upit2.Osoba.Mjesto.Naziv;
            }

            try
            {
                var upit = baza.Kazna.Where(x => x.IDOsobe == Broj).Select(x => new { x.IDKazne, x.VrstaKazne.NazivVrste, x.Opis, x.Iznos, x.TipPresude.NazivTipa, x.IDPresude });

                foreach (var i in upit)
                {
                    int IDPresude = Convert.ToInt32(i.IDPresude);
                    if (i.IDPresude != null)
                    {
                        var upit2 = baza.StavkaSpisa.First(x => x.IDStavke == IDPresude);
                        int IDProcesa = Convert.ToInt32(upit2.IDProcesa);
                        var proces = baza.Proces.First(x => x.IDProcesa == IDProcesa);
                        dgKazne.Rows.Add(i.NazivVrste, i.Iznos.ToString(), i.Opis, i.NazivTipa, proces.Naziv, i.IDKazne);
                    }
                    else
                    {
                        dgKazne.Rows.Add(i.NazivVrste, i.Iznos.ToString(), i.Opis, i.NazivTipa, null, i.IDKazne);
                    }
                }
            }
            catch { }
        }

        int DajIDTrenutneOsobe()
        {
            string red = Osobe.Current.ToString();
            string[] broj = red.Split('=');
            broj = broj[1].Split(',');
            broj[0] = broj[0].Remove(broj[0].Length - 1);
            return int.Parse(broj[0]);
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            VrstaKazneCombo.Visible = false;
            UrediButton.Visible = false;
            IznosText.Visible = false;
            OpisText.Visible = false;
            ObrisiButton.Enabled = true;
            DodajButton.Enabled = true;
            toolStripLabel2.Enabled = false;
            OdustaniButton.Enabled = false;
            dgKazne.Enabled = true;
        }

        private void toolStripLabel2_Click(object sender, EventArgs e) // Spremanje
        {
            int ID = Convert.ToInt32(dgKazne[5, BrojRetka].Value);

            bazaF.Kazna kazna = new bazaF.Kazna();
            bazaF.VrstaKazne vrsta = new bazaF.VrstaKazne();

            if (UnosNovog == 1)
            {
                try
                {
                    bazaF.Kazna nova = new bazaF.Kazna();

                    nova = baza.Kazna.First(x => x.IDKazne == ID);

                    kazna.IDPresude = nova.IDPresude;
                }
                catch
                {
                    kazna.IDPresude = null;
                }

                try
                {
                    int Max = (from x in baza.Kazna select x.IDKazne).Max();
                    kazna.IDKazne = Max + 1;
                    kazna.IDOsobe = DajIDTrenutneOsobe();
                }
                catch
                {
                    kazna.IDKazne = 1;
                    kazna.IDOsobe = DajIDTrenutneOsobe();
                }

                int dalje = 1;
                decimal broj;

                if (Decimal.TryParse(IznosText.Text, out broj))
                {
                    kazna.Iznos = broj;
                }
                else
                {
                    MessageBox.Show("Iznos nije dobro napisan (format: ****,***)");
                    dalje = 0;
                }


                if (dalje == 1)
                {
                    string naziv = VrstaKazneCombo.Text;
                    kazna.Opis = OpisText.Text;
                    vrsta = baza.VrstaKazne.First(x => x.NazivVrste == naziv);
                    kazna.Vrsta = vrsta.SifraVrste;

                    if (UnosNovog == 1)
                    {
                        baza.Kazna.Add(kazna);
                        UnosNovog = 0;
                    }

                    try
                    {
                        baza.SaveChanges();
                        MessageBox.Show("Spremljeno!");
                    }
                    catch
                    {
                        MessageBox.Show("Greška prilikom spremanja!");
                    }
                }
            }
            else
            {
                kazna = baza.Kazna.First(x => x.IDKazne == ID);

                int dalje = 1;
                decimal broj;

                if (Decimal.TryParse(IznosText.Text, out broj))
                {
                    kazna.Iznos = broj;
                }
                else
                {
                    MessageBox.Show("Iznos nije dobro napisan (format: ****,***)");
                    dalje = 0;
                }


                if (dalje == 1)
                {
                    string naziv = VrstaKazneCombo.Text;
                    kazna.Opis = OpisText.Text;
                    vrsta = baza.VrstaKazne.First(x => x.NazivVrste == naziv);
                    kazna.Vrsta = vrsta.SifraVrste;

                    if (UnosNovog == 1)
                    {
                        baza.Kazna.Add(kazna);
                        UnosNovog = 0;
                    }

                    try
                    {
                        baza.SaveChanges();
                        MessageBox.Show("Spremljeno!");
                    }
                    catch
                    {
                        MessageBox.Show("Greška prilikom spremanja!");
                    }
                }
            }
            

            int Broj = DajIDTrenutneOsobe();
            var upit = baza.Kazna.Where(x => x.IDOsobe == Broj).Select(x => new { x.IDKazne, x.VrstaKazne.NazivVrste, x.Opis, x.Iznos, x.TipPresude.NazivTipa, x.IDPresude });

            dgKazne.Rows.Clear();

            foreach (var i in upit)
            {
                int IDPresude = Convert.ToInt32(i.IDPresude);
                if (i.IDPresude != null)
                {
                    var upit2 = baza.StavkaSpisa.First(x => x.IDStavke == IDPresude);
                    int IDProcesa = Convert.ToInt32(upit2.IDProcesa);
                    var proces = baza.Proces.First(x => x.IDProcesa == IDProcesa);
                    dgKazne.Rows.Add(i.NazivVrste, i.Iznos.ToString(), i.Opis, i.NazivTipa, proces.Naziv, i.IDKazne);
                }
                else
                {
                    dgKazne.Rows.Add(i.NazivVrste, i.Iznos.ToString(), i.Opis, i.NazivTipa, null, i.IDKazne);
                }
            }
        }

        private void UrediButton_Click(object sender, EventArgs e)
        {
            FormaOsobe.SifrarnikVrstaKazne prozor = new FormaOsobe.SifrarnikVrstaKazne();
            prozor.ShowDialog();
            List<string> vrstaKazne = baza.VrstaKazne.Select(x => x.NazivVrste).ToList();
            VrstaKazneCombo.DataSource = vrstaKazne;
        }

        private void Klik(object sender, DataGridViewCellMouseEventArgs e)
        {
            ObrisiButton.Enabled = true;
        }

        private void ObrisiButton_Click(object sender, EventArgs e)
        {
            if (dgKazne.Rows.Count == 1)
            {
                MessageBox.Show("Lista je prazna! Ne može se brisati!");
            }

            else
            {
                int IDKazne = Convert.ToInt32(dgKazne[5, BrojRetka].Value);

                var ZaBrisanje = baza.Kazna.First(x => x.IDKazne == IDKazne);

                baza.Kazna.Remove(ZaBrisanje);

                if (MessageBox.Show("Želite li trajno obrisati odabranu kaznu?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        baza.SaveChanges();
                        MessageBox.Show("Obrisano!");

                        dgKazne.Rows.Clear();

                        int Broj = DajIDTrenutneOsobe();
                        var upit = baza.Kazna.Where(x => x.IDOsobe == Broj).Select(x => new { x.IDKazne, x.VrstaKazne.NazivVrste, x.Opis, x.Iznos, x.TipPresude.NazivTipa, x.IDPresude });

                        foreach (var i in upit)
                        {
                            int IDPresude = Convert.ToInt32(i.IDPresude);
                            if (i.IDPresude != null)
                            {
                                var upit2 = baza.StavkaSpisa.First(x => x.IDStavke == IDPresude);
                                int IDProcesa = Convert.ToInt32(upit2.IDProcesa);
                                var proces = baza.Proces.First(x => x.IDProcesa == IDProcesa);
                                dgKazne.Rows.Add(i.NazivVrste, i.Iznos.ToString(), i.Opis, i.NazivTipa, proces.Naziv, i.IDKazne);
                            }
                            else
                            {
                                dgKazne.Rows.Add(i.NazivVrste, i.Iznos.ToString(), i.Opis, i.NazivTipa, null, i.IDKazne);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Greška prilikom brisanja!!!");
                    }
                }
            }
        }

        private void DodajButton_Click(object sender, EventArgs e)
        {
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            VrstaKazneCombo.Visible = true;
            UrediButton.Visible = true;
            IznosText.Visible = true;
            OpisText.Visible = true;
            ObrisiButton.Enabled = false;
            DodajButton.Enabled = false;
            toolStripLabel2.Enabled = true;
            OdustaniButton.Enabled = true;
            dgKazne.Enabled = true;

            UnosNovog = 1;


        }
    }
}
