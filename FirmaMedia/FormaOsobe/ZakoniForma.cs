using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FormaOsobe
{
    public partial class ZakoniForma : Form
    {
        bazaF.RPPP10 baza = new bazaF.RPPP10();  //Bitne varijable za cijeli program (Baza, IDZakona i BindingSource)
        int IDZakona = 0;
        BindingSource Zakoni = new BindingSource();
        int izmjena = 0;
        public ZakoniForma()
        {
            InitializeComponent();
            InfoLabel.Text = "Dvoklik na ćeliju za" + Environment.NewLine + "više informacija o članku";
            InfoLabel.Visible = false;
        }

        private void ZakoniLoad(object sender, EventArgs e)
        {

            bindingNavigator1.Visible = false;
            Omoguci();
            PodaciPanel.Visible = false;

            try
            {
                var upit = baza.Zakon.Where(x => x.Razina == 1).Select(x => new { x.IDZakona, x.Naziv });
                var Lista = upit.ToList();
                Zakoni.DataSource = Lista;
                bindingSourceZakoni.DataSource = Zakoni;
                bindingNavigator1.BindingSource = Zakoni;
            }
            catch
            {
                MessageBox.Show("Ne mogu dohvatiti podatke iz baze!");
                this.Close();
            }

            label3.DataBindings.Clear();
            label3.DataBindings.Add("Text", Zakoni, "Naziv", false, DataSourceUpdateMode.OnPropertyChanged);

            PodaciPanel.Enabled = false;
            PretraživanjeLabel.Visible = false;
            bindingNavigator1.Visible = true;
        }

        private void SpremiButton_Click(object sender, EventArgs e) //Kod za spremanje zakona
        {
            int dalje = 1;

            if (NazivTextBox.Text == "")
            {
                MessageBox.Show("Niste upisali ime zakona/članka!");
                dalje = 0;
            }

            if (dalje == 1)
            {
                bazaF.Zakon Zakon = new bazaF.Zakon();

                if (izmjena != 0) {
                    Zakon = baza.Zakon.First(i=>i.IDZakona == IDZakona);
                }

                else 
                {
                   try
                        {
                            int Max = (from x in baza.Zakon select x.IDZakona).Max();
                            Zakon.IDZakona = Max + 1;
                        }
                   catch
                        {
                            Zakon.IDZakona = 1;
                        }
                }

                Zakon.Naziv = NazivTextBox.Text;

                if (izmjena == 0) {
                    baza.Zakon.Add(Zakon);
                }

                try
                {
                    baza.SaveChanges();
                    MessageBox.Show("Zakon je uspješno unesen!");
                }
                catch
                {
                    MessageBox.Show("Dogodila se greška prilikom unosa zakona!");
                }

                izmjena = 0;
                Ocisti();
                Omoguci();
            }
        }

        private void ObrisiButton_Click(object sender, EventArgs e) //Kod za brisanje trenutnog zakona
        {
            int ID = DajIDTrenutnogZakona();
            if (MessageBox.Show("Želite li trajno obrisati odabrani zakon?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var ZaBrisanje = from x in baza.Zakon where x.IDZakona == ID || x.IDNadredenog == ID select x;

                baza.Zakon.RemoveRange(ZaBrisanje);

                try
                {
                    baza.SaveChanges();
                    MessageBox.Show("Obrisano!");
                }
                catch
                {
                    MessageBox.Show("Prvo obrišite sve članke zakona!");
                }
            }

            ZakoniLoad(this, e);
        }

        private void DodajButton_Click(object sender, EventArgs e) //Par kratkih EventHandlera
        {
            PodaciPanel.Visible = true;
            ImeLabel.Text = "Naziv novog zakona";
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            Onemoguci();
        }

        private void UrediButton_Click(object sender, EventArgs e)
        {
            PodaciPanel.Visible = true;
            ImeLabel.Text = "Novi naziv zakona";
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            Onemoguci();

            izmjena = 1;
            NazivTextBox.Text = label3.Text;
        }

        private void Trazi(object sender, KeyEventArgs e) //Kod za pretragu
        {
            var upit = baza.Zakon.Where(x => x.Naziv.StartsWith(PretragaTextBox.Text) && x.Razina == 1).Select(x => new { x.IDZakona, x.Naziv, x.RazinaZakona.NazivRazine, Nadredjeni = x.Zakon2.Naziv });
            var Lista = upit.ToList();
            Zakoni.DataSource = Lista;
            bindingSourceZakoni.DataSource = Zakoni;
            bindingNavigator1.BindingSource = Zakoni;

            label3.DataBindings.Clear();
            label3.DataBindings.Add("Text", Zakoni, "Naziv", false, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void SortirajButton_Click(object sender, EventArgs e) //Kod za sortiranje
        {
            if (UzlaznoCheck.Checked == true)
            {
                int ID = DajIDTrenutnogZakona();
                var upit = baza.Zakon.Where(x => x.Razina == 2 && x.IDNadredenog == ID).Select(x => new {x.Naziv }).OrderBy(x => x.Naziv);
                var Lista = upit.ToList();

                Podaci.DataSource = null;
                Podaci.DataSource = Lista;
            }
            else
            {
                int ID = DajIDTrenutnogZakona();
                var upit = baza.Zakon.Where(x => x.Razina == 2 && x.IDNadredenog == ID).Select(x => new { x.Naziv }).OrderByDescending(x => x.Naziv);
                var Lista = upit.ToList();

                Podaci.DataSource = null;
                Podaci.DataSource = Lista;
            }
        }

        private void Promijeni(object sender, EventArgs e) // Kod za promjenu naziva trenutnog zakona
        {
            ObrisiClanakButton.Enabled = false;

            int Broj = DajIDTrenutnogZakona();

            var upit = baza.Zakon.Where(x => x.IDNadredenog == Broj).Select(x => new { x.IDZakona, x.Naziv });
            var Lista = upit.ToList();
            Podaci.DataSource = null;
            Podaci.DataSource = Lista;
            Podaci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Podaci.Columns[0].Visible = false;
        }

        int DajIDTrenutnogZakona()  //Daje ID Trenutnog zakona - JAKO BITNO!
        {
            string red = Zakoni.Current.ToString();
            string[] broj = red.Split('=');
            broj = broj[1].Split(',');

            return int.Parse(broj[0]);
        }

        private void Klik(object sender, DataGridViewCellMouseEventArgs e) // Dvoklik koji poziva formu Stavci
        {
            try
            {
                int red = Podaci.CurrentRow.Index;
                int ID = Convert.ToInt32(Podaci[0, red].Value);

                StavciForma poziv = new StavciForma(ID);
                poziv.ShowDialog();
            }
            catch { }
        }

        private void DodajClanakButton_Click(object sender, EventArgs e) //Omogućuje dodavanje novog članka
        {
            PodaciPanel.Visible = true;
            ImeLabel.Text = "Naziv novog članka";
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            Onemoguci();
        }

        private void OdustaniButton_Click_1(object sender, EventArgs e) //Odustajanje od izmjena
        {
            izmjena = 0;
            Omoguci();
            NazivTextBox.Clear();
            PodaciPanel.Visible = false;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
        }

        private void OmoguciBrisanje(object sender, DataGridViewCellEventArgs e) //Sedam kratkih EventHandlera
        {
            ObrisiClanakButton.Enabled = true;
        }

        private void PokaziUputu(object sender, DataGridViewCellEventArgs e)
        {
            InfoLabel.Visible = true;
        }

        private void MakniUputu(object sender, DataGridViewCellEventArgs e)
        {
            InfoLabel.Visible = false;
        }

        private void Omoguci()
        {
            UrediButton.Enabled = true;
            DodajButton.Enabled = true;
            ObrisiButton.Enabled = true;
            Podaci.Enabled = true;
        }

        private void Onemoguci()
        {
            PodaciPanel.Enabled = true;
            DodajButton.Enabled = false;
            ObrisiButton.Enabled = false;
            UrediButton.Enabled = false;
        }

        private void Ocisti()
        {
            NazivTextBox.Clear();
        }

        private void DolazakMisa(object sender, EventArgs e)
        {
            PretraživanjeLabel.Visible = true;
        }

        private void OdlazakMisa(object sender, EventArgs e)
        {
            PretraživanjeLabel.Visible = false;
        }

        private void SpremiButton_Click_1(object sender, EventArgs e) //Kod za spremanje podataka
        {

            int dalje = 1;

            if (string.IsNullOrWhiteSpace(NazivTextBox.Text))
            {
                if (ImeLabel.Text == "Naziv novog članka")
                {
                    MessageBox.Show("Niste unijeli naziv članka!");
                    dalje = 0;
                }
                else
                {
                    MessageBox.Show("Niste unijeli naziv zakona!");
                    dalje = 0;
                }
            }

            if (dalje == 1)
            {
                bazaF.Zakon unos = new bazaF.Zakon();

                if (izmjena == 1)
                {
                    int ID = DajIDTrenutnogZakona();
                    unos = baza.Zakon.First(x => x.IDZakona == ID);
                }
                else 
                {
                    try
                    {
                        int Max = (from x in baza.Zakon select x.IDZakona).Max();
                        unos.IDZakona = Max + 1;
                    }
                    catch
                    {
                        unos.IDZakona = 1;
                    }
                }

                if (ImeLabel.Text == "Naziv novog članka")
                {
                    unos.Razina = 2;
                    unos.IDNadredenog = DajIDTrenutnogZakona();
                }
                else
                {
                    unos.Razina = 1;
                }

                unos.Naziv = NazivTextBox.Text;

                if (izmjena == 0)
                {
                    baza.Zakon.Add(unos);
                }

                try
                {
                    baza.SaveChanges();

                    if (ImeLabel.Text == "Naziv novog članka")
                    {
                        MessageBox.Show("Članak uspješno unesen!");
                    }
                    else
                    {
                        MessageBox.Show("Zakon uspješno unesen!");
                    }
                }
                catch
                {
                    MessageBox.Show("Dogodila se greška prilikom unosa zakona/članka!");
                }

                Omoguci();

                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                PodaciPanel.Visible = false;

                izmjena = 0;

                ZakoniLoad(this, e);
            }
        }

        private void ObrisiClanakButton_Click(object sender, EventArgs e) //Kod za brisanje članaka
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
                if (MessageBox.Show("Želite li trajno obrisati članak \"" + Naziv + "\" ?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var ZaBrisanje = from x in baza.Zakon where x.IDZakona == ID || x.IDNadredenog == ID select x;

                    baza.Zakon.RemoveRange(ZaBrisanje);

                    try
                    {
                        baza.SaveChanges();
                        MessageBox.Show("Obrisano!");
                    }
                    catch
                    {
                        MessageBox.Show("Dogodila se greška prilikom brisanja!!!");
                    }
                }

                ZakoniLoad(this, e);
            }
        }
    }
}
