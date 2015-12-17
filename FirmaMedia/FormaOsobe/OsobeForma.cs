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
    public partial class OsobeForma : Form
    {

        BindingSource Osobe = new BindingSource();
        bazaF.RPPP10 baza = new bazaF.RPPP10();
        int izmjena = 0;
        public OsobeForma()
        {
            InitializeComponent();
        }

        private void FizickaOsobaLoad(object sender, EventArgs e)
        {
            bindingNavigator1.Visible = false;
            Omoguci();

            button1.Visible = false;

            try
            {
                List<bazaF.Mjesto> mjesto = baza.Mjesto.AsNoTracking().OrderBy(x => x.Naziv).ToList();
                MjestoComboBox.DataSource = mjesto;
                MjestoPravnaCombo.DataSource = mjesto;
                List<bazaF.PravnaOsoba> poslodavac = baza.PravnaOsoba.AsNoTracking().OrderBy(x => x.Naziv).ToList();
                PoslodavacComboBox.DataSource = poslodavac;

                var upit = baza.Osoba.Select(x => new { x.IDOsobe, x.OIB, x.UlicaIKucniBr, x.PBr, NazivMjesto = x.Mjesto.Naziv });
                var Lista = upit.ToList();

                Osobe.DataSource = Lista;
                bindingSourceOsoba.DataSource = Osobe;
                bindingNavigator1.BindingSource = Osobe;
            }
            catch
            {
                MessageBox.Show("Ne mogu se povezati sa bazom podataka!");
                this.Close();
            }
            PretragaComboBox.SelectedIndex = 0;
            SpremiButton.Enabled = false;
            OdustaniButton.Enabled = false;
            bindingNavigator1.Visible = true;
        }

        int DajIDTrenutneOsobe()
        {
            string red = Osobe.Current.ToString();
            string[] broj = red.Split('=');
            broj = broj[1].Split(',');

            return int.Parse(broj[0]);
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            UrediButton.Enabled = true;
            DodajButton.Enabled = true;
            ObrisiButton.Enabled = true;
            SpremiButton.Enabled = false;
            OdustaniButton.Enabled = false;
            Onemoguci();
            izmjena = 0;
            FizickaOsobaLoad(this, e);
        }

        private void SpremiButton_Click(object sender, EventArgs e)
        {
            int dalje = 1;

            if (PodaciPanel.Visible == true) 
            { 
                if (string.IsNullOrWhiteSpace(ImeTextBox.Text))
            {
                MessageBox.Show("Niste unijeli ime fizičke osobe!");
                dalje = 0;
            }
            else if (string.IsNullOrWhiteSpace(PrezimeTextBox.Text))
            {
                MessageBox.Show("Niste unijeli prezime fizičke osobe!");
                dalje = 0;
            }
            else if (string.IsNullOrWhiteSpace(ImeOcaTextBox.Text))
            {
                MessageBox.Show("Niste unijeli ime oca!");
                dalje = 0;
            }
            else if (string.IsNullOrWhiteSpace(JMBGTextBox.Text))
            {
                MessageBox.Show("Niste unijeli JMBG!");
                dalje = 0;
            }
            else if (string.IsNullOrWhiteSpace(OIBTextBox.Text))
            {
                MessageBox.Show("Niste unijeli OIB!");
                dalje = 0;
            }
            else if (string.IsNullOrWhiteSpace(AdresaTextBox.Text))
            {
                MessageBox.Show("Niste unijeli ulicu i kućni broj!");
                dalje = 0;
            }

            if (dalje == 1)
                {
                    bazaF.FizickaOsoba FizOsoba = new bazaF.FizickaOsoba();
                    bazaF.Osoba Osoba = new bazaF.Osoba();
                    bazaF.Mjesto Mjesto = new bazaF.Mjesto();

                    if (izmjena != 0)
                    {
                        int ID = DajIDTrenutneOsobe();
                        FizOsoba = baza.FizickaOsoba.First(i => i.IDOsobe == ID);
                        Osoba = baza.Osoba.First(i => i.IDOsobe == ID);
                    }
                    else
                    {
                        try
                        {
                            int Max = (from x in baza.Osoba select x.IDOsobe).Max();
                            FizOsoba.IDOsobe = Max + 1;
                            Osoba.IDOsobe = Max + 1;
                        }
                        catch
                        {
                            FizOsoba.IDOsobe = 1;
                            Osoba.IDOsobe = 1;
                        }
                    }
                    FizOsoba.Ime = ImeTextBox.Text;
                    FizOsoba.Prezime = PrezimeTextBox.Text;
                    FizOsoba.ImeOca = ImeOcaTextBox.Text;
                    FizOsoba.DatumRod = DatumOdabir.Value;
                    FizOsoba.JMBG = JMBGTextBox.Text;
                    if (SudacCombo.Text == "Da")
                    {
                        FizOsoba.Sudac = true;
                    }
                    else FizOsoba.Sudac = false;
                    Osoba.OIB = OIBTextBox.Text;
                    Osoba.UlicaIKucniBr = AdresaTextBox.Text;
                    Mjesto = baza.Mjesto.First(i => i.Naziv == MjestoComboBox.Text);
                    Osoba.PBr = Mjesto.PBr;

                    if (izmjena == 0)
                    {
                        baza.Osoba.Add(Osoba);
                        baza.FizickaOsoba.Add(FizOsoba);
                    }

                    try
                    {
                        baza.SaveChanges();
                        MessageBox.Show("Fizička osoba uspješno unesena!");
                    }
                    catch
                    {
                        MessageBox.Show("Greška prilikom spremanja fizičke osobe!", "Greška!");
                    }

                    Ocisti();
                    Omoguci();

                    FizickaOsobaLoad(this, e);
                }
            }
            else
            {
                
                if (string.IsNullOrWhiteSpace(NazivTextBox.Text))
                {
                    MessageBox.Show("Niste unijeli naziv pravne osobe!");
                    dalje = 0;
                }
                else if (string.IsNullOrWhiteSpace(MBrTextBox.Text))
                {
                    MessageBox.Show("Niste unijeli matični broj pravne osobe!");
                    dalje = 0;
                }
                else if (string.IsNullOrWhiteSpace(OIBPravna.Text))
                {
                    MessageBox.Show("Niste unijeli OIB pravne osobe!");
                    dalje = 0;
                }
                else if (string.IsNullOrWhiteSpace(AdresaPravna.Text))
                {
                    MessageBox.Show("Niste unijeli ulicu i kućni broj!");
                    dalje = 0;
                }

                if (dalje == 1)
                {
                    bazaF.PravnaOsoba PravOsoba = new bazaF.PravnaOsoba();
                    bazaF.Osoba Osoba = new bazaF.Osoba();
                    bazaF.Mjesto Mjesto = new bazaF.Mjesto();

                    if (izmjena != 0)
                    {
                        int ID = DajIDTrenutneOsobe();
                        PravOsoba = baza.PravnaOsoba.First(i => i.IDOsobe == ID);
                        Osoba = baza.Osoba.First(i => i.IDOsobe == ID);
                    }
                    else
                    {
                        try
                        {
                            int Max = (from x in baza.Osoba select x.IDOsobe).Max();
                            PravOsoba.IDOsobe = Max + 1;
                            Osoba.IDOsobe = Max + 1;
                        }
                        catch
                        {
                            PravOsoba.IDOsobe = 1;
                            Osoba.IDOsobe = 1;
                        }
                    }

                    PravOsoba.Naziv = NazivTextBox.Text;
                    PravOsoba.MB = MBrTextBox.Text;
                    Osoba.UlicaIKucniBr = AdresaPravna.Text;
                    Osoba.OIB = OIBPravna.Text;
                    Mjesto = baza.Mjesto.First(i => i.Naziv == MjestoPravnaCombo.Text);
                    Osoba.PBr = Mjesto.PBr;

                    if (izmjena == 0)
                    {
                        baza.Osoba.Add(Osoba);
                        baza.PravnaOsoba.Add(PravOsoba);
                    }

                    try
                    {
                        baza.SaveChanges();
                        MessageBox.Show("Pravna osoba uspješno unesena!");
                    }
                    catch
                    {
                        MessageBox.Show("Greška prilikom spremanja pravne osobe!", "Greška!");
                    }
                }
            }
            izmjena = 0;

            UrediButton.Enabled = true;
            DodajButton.Enabled = true;
            ObrisiButton.Enabled = true;
            SpremiButton.Enabled = false;
            OdustaniButton.Enabled = false;

            FizickaOsobaLoad(this, e);
        }

        private void UrediButton_Click(object sender, EventArgs e)
        {
            UrediButton.Enabled = false;
            DodajButton.Enabled = false;
            ObrisiButton.Enabled = false;
            SpremiButton.Enabled = true;
            OdustaniButton.Enabled = true;
            Omoguci();
            izmjena = 1;
        }

        private void ObrisiButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Želite li trajno obrisati odabranu osobu?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int ID = DajIDTrenutneOsobe();

                var ZaBrisanje = baza.Osoba.First(x => x.IDOsobe == ID);

                baza.Osoba.Remove(ZaBrisanje);

                try
                {
                    baza.SaveChanges();
                    MessageBox.Show("Obrisano!");
                }
                catch
                {
                    MessageBox.Show("Greška prilikom brisanja!!!");
                }

                FizickaOsobaLoad(this, e);
            }
        }

        private void Trazi(object sender, KeyEventArgs e)
        {
            if (PretragaComboBox.Text == "Fizička")
            {
                var upit = baza.FizickaOsoba.Where(x => x.Ime.StartsWith(PretragaTextBox.Text)).Select(x => new { x.IDOsobe, x.Ime, x.Prezime, x.ImeOca, x.DatumRod, x.JMBG, x.Osoba.OIB, x.Osoba.UlicaIKucniBr, x.Osoba.PBr, NazivMjesto = x.Osoba.Mjesto.Naziv, x.PravnaOsoba.Naziv });
                var Lista = upit.ToList();
                Osobe.DataSource = Lista;
                bindingSourceOsoba.DataSource = Osobe;
                bindingNavigator1.BindingSource = Osobe;
            }
            else
            {
                var upit = baza.PravnaOsoba.Where(x => x.Naziv.StartsWith(PretragaTextBox.Text)).Select(x => new { x.IDOsobe, x.Naziv, x.MB, x.Osoba.OIB, x.Osoba.UlicaIKucniBr, MjestoNaziv = x.Osoba.Mjesto.Naziv });
                var Lista = upit.ToList();
                Osobe.DataSource = Lista;
                bindingSourceOsoba.DataSource = Osobe;
                bindingNavigator1.BindingSource = Osobe;
            }
        }

        private void Omoguci()
        {
            ImeTextBox.Enabled = true;
            PrezimeTextBox.Enabled = true;
            ImeOcaTextBox.Enabled = true;
            DatumOdabir.Enabled = true;
            JMBGTextBox.Enabled = true;
            OIBTextBox.Enabled = true;
            AdresaTextBox.Enabled = true;
            MjestoComboBox.Enabled = true;
            PoslodavacComboBox.Enabled = true;
            NazivTextBox.Enabled = true;
            MBrTextBox.Enabled = true;
            OIBPravna.Enabled = true;
            AdresaPravna.Enabled = true;
            MjestoPravnaCombo.Enabled = true;
            SudacCombo.Enabled = true;
        }

        private void Onemoguci()
        {
            ImeTextBox.Enabled = false;
            PrezimeTextBox.Enabled = false;
            ImeOcaTextBox.Enabled = false;
            DatumOdabir.Enabled = false;
            JMBGTextBox.Enabled = false;
            OIBTextBox.Enabled = false;
            AdresaTextBox.Enabled = false;
            MjestoComboBox.Enabled = false;
            PoslodavacComboBox.Enabled = false;
            NazivTextBox.Enabled = false;
            MBrTextBox.Enabled = false;
            OIBPravna.Enabled = false;
            AdresaPravna.Enabled = false;
            MjestoPravnaCombo.Enabled = false;
            SudacCombo.Enabled = false;
        }

        private void Ocisti()
        {
            ImeTextBox.Clear();
            PrezimeTextBox.Clear();
            ImeOcaTextBox.Clear();
            DatumOdabir.Value = DatumOdabir.Value.Date;
            JMBGTextBox.Clear();
            OIBTextBox.Clear();
            AdresaTextBox.Clear();
            MjestoComboBox.SelectedValue = -1;
            PoslodavacComboBox.SelectedValue = -1;
            NazivTextBox.Clear();
            MBrTextBox.Clear();
            OIBPravna.Clear();
            AdresaPravna.Clear();
            MjestoPravnaCombo.SelectedValue = -1;
            SudacCombo.SelectedValue = 1;
        }

        private void ProvjeraImena(object sender, CancelEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ImeTextBox.Text, "[0-9]"))
            {
                errorProviderFizicka.SetError(ImeTextBox, "Ime ne smije u sebi imati brojeve!");
                e.Cancel = true;
            }
            else
            {
                errorProviderFizicka.SetError(ImeTextBox, "");
                e.Cancel = false;
            }
        }

        private void PrezimeProvjera(object sender, CancelEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(PrezimeTextBox.Text, "[0-9]"))
            {
                errorProviderFizicka.SetError(PrezimeTextBox, "Prezime ne smije u sebi imati brojeve!");
                e.Cancel = true;
            }
            else
            {
                errorProviderFizicka.SetError(PrezimeTextBox, "");
                e.Cancel = false;
            }
        }

        private void ImeOcaProvjera(object sender, CancelEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ImeOcaTextBox.Text, "[0-9]"))
            {
                errorProviderFizicka.SetError(ImeOcaTextBox, "Ime oca ne smije u sebi imati brojeve!");
                e.Cancel = true;
            }
            else
            {
                errorProviderFizicka.SetError(ImeOcaTextBox, "");
                e.Cancel = false;
            }
        }

        private void JMBGProvjera(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(JMBGTextBox.Text, "[0-9]{13}"))
            {
                errorProviderFizicka.SetError(JMBGTextBox, "JMBG se sastoji od 13 znamenaka!");
                e.Cancel = true;
            }
            else
            {
                errorProviderFizicka.SetError(JMBGTextBox, "");
                e.Cancel = false;
            }
        }

        private void OIBProvjera(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(OIBTextBox.Text, "[0-9]{11}"))
            {
                errorProviderFizicka.SetError(OIBTextBox, "OIB se sastoji od 11 znamenaka!");
                e.Cancel = true;
            }
            else
            {
                errorProviderFizicka.SetError(OIBTextBox, "");
                e.Cancel = false;
            }
        }

        private void ProvjeraMBr(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(JMBGTextBox.Text, "[0-9]{7}"))
            {
                errorProviderFizicka.SetError(JMBGTextBox, "Matični broj se sastoji od 7 znamenaka!");
                e.Cancel = true;
            }
            else
            {
                errorProviderFizicka.SetError(JMBGTextBox, "");
                e.Cancel = false;
            }
        }

        private void ProvjeraMBrPravna(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(MBrTextBox.Text, "[0-9]{7}"))
            {
                errorProviderFizicka.SetError(OIBTextBox, "Matični broj se sastoji od 7 znamenaka!");
                e.Cancel = true;
            }
            else
            {
                errorProviderFizicka.SetError(OIBTextBox, "");
                e.Cancel = false;
            }
        }

        private void OIBProvjeraPravna(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(OIBPravna.Text, "[0-9]{11}"))
            {
                errorProviderFizicka.SetError(OIBTextBox, "OIB se sastoji od 11 znamenaka!");
                e.Cancel = true;
            }
            else
            {
                errorProviderFizicka.SetError(OIBTextBox, "");
                e.Cancel = false;
            }
        }

        private void Promjeni(object sender, EventArgs e)
        {
            OdvjetnikData.Rows.Clear();
            OdvjetnikTuzbaGrid.Rows.Clear();
            OstecenikData.Rows.Clear();
            SvjedokData.Rows.Clear();
            SudionikData.Rows.Clear();

            int Broj = DajIDTrenutneOsobe();

            int nadjeno = 0;

            try
            {
                var upit = baza.FizickaOsoba.First(x => x.IDOsobe == Broj);
                PodaciPanel.Visible = true;
                PanelPravna.Visible = false;
                ImeTextBox.Text = upit.Ime;
                PrezimeTextBox.Text = upit.Prezime;
                ImeOcaTextBox.Text = upit.ImeOca;
                DatumOdabir.Value = upit.DatumRod.Value;
                JMBGTextBox.Text = upit.JMBG;
                OIBTextBox.Text = upit.Osoba.OIB;
                AdresaTextBox.Text = upit.Osoba.UlicaIKucniBr;
                MjestoComboBox.Text = upit.Osoba.Mjesto.Naziv;
                if (upit.PravnaOsoba != null)
                {
                    PoslodavacComboBox.Text = upit.PravnaOsoba.Naziv;
                }
                else PoslodavacComboBox.SelectedIndex = -1;

                if (upit.Sudac == true)
                {
                    SudacCombo.Text = "Da";
                }
                else SudacCombo.Text = "Ne";

                OdvjetnikLabel.Visible = true;
                OdvjetnikData.Visible = true;
                OdvjetnikTuzbaGrid.Visible = true;

                try
                {
                    var upitBranitelj = baza.Branitelj.Where(x => x.IDOsobe == Broj).Select(x => new { x.Optuzenik.IDProces });

                    OdvjetnikPanel.Visible = true;
                    foreach (var i in upitBranitelj)
                    {
                        int IDProces = Convert.ToInt32(i.IDProces);
                        var proces = baza.Proces.First(x => x.IDProcesa == IDProces);
                        OdvjetnikData.Rows.Add(proces.Naziv);
                    }
                }
                catch {}

                try
                {
                    var upitTuzitelj = baza.Tuzitelj.Where(x => x.IDOsobe == Broj).Select(x => new { x.Proces.IDProcesa });

                    OdvjetnikPanel.Visible = true;
                    foreach (var i in upitTuzitelj)
                    {
                        int IDProces = Convert.ToInt32(i.IDProcesa);
                        var proces = baza.Proces.First(x => x.IDProcesa == IDProces);
                        OdvjetnikTuzbaGrid.Rows.Add(proces.Naziv);
                    }
                }
                catch {}

                nadjeno = 1;
            }
            catch { };

            if (nadjeno == 0)
            {
                OdvjetnikLabel.Visible = false;
                OdvjetnikData.Visible = false;
                OdvjetnikTuzbaGrid.Visible = false;
                var upitPravna = baza.PravnaOsoba.First(x => x.IDOsobe == Broj);
                PodaciPanel.Visible = false;
                PanelPravna.Visible = true;
                NazivTextBox.Text = upitPravna.Naziv;
                MBrTextBox.Text = upitPravna.MB;
                OIBPravna.Text = upitPravna.Osoba.OIB;
                AdresaPravna.Text = upitPravna.Osoba.UlicaIKucniBr;
                MjestoPravnaCombo.Text = upitPravna.Osoba.Mjesto.Naziv;
            }

            try
            {
                var upitSvjedok = baza.Svjedok.Where(x => x.IDOsobe == Broj).Select(x => new { x.IDProces });

                OdvjetnikPanel.Visible = true;
                foreach (var i in upitSvjedok)
                {
                    int IDProces = Convert.ToInt32(i.IDProces);
                    var proces = baza.Proces.First(x => x.IDProcesa == IDProces);
                    SvjedokData.Rows.Add(proces.Naziv);
                }
            }
            catch {}

            try
            {
                var upitOstecenik = baza.Ostecenik.Where(x => x.IDOsobe == Broj).Select(x => new { x.IDProces });

                OdvjetnikPanel.Visible = true;
                foreach (var i in upitOstecenik)
                {
                    int IDProces = Convert.ToInt32(i.IDProces);
                    var proces = baza.Proces.First(x => x.IDProcesa == IDProces);
                    OstecenikData.Rows.Add(proces.Naziv);
                }
            }
            catch {}

            try
            {
                var upitSudionik = baza.Sudionik.Where(x => x.IDOsobe == Broj).Select(x => new { x.Rociste.IDProcesa });

                OdvjetnikPanel.Visible = true;
                foreach (var i in upitSudionik)
                {
                    int IDProces = Convert.ToInt32(i.IDProcesa);
                    var proces = baza.Proces.First(x => x.IDProcesa == IDProces);
                    SvjedokData.Rows.Add(proces.Naziv);
                }
            }
            catch {}

            Onemoguci();
        }

        private void fizičkaOsobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrediButton.Enabled = false;
            DodajButton.Enabled = false;
            ObrisiButton.Enabled = false;
            SpremiButton.Enabled = true;
            OdustaniButton.Enabled = true;
            Ocisti();
            Omoguci();
            PanelPravna.Visible = false;
            PodaciPanel.Visible = true;
        }

        private void pravnaOsobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrediButton.Enabled = false;
            DodajButton.Enabled = false;
            ObrisiButton.Enabled = false;
            SpremiButton.Enabled = true;
            OdustaniButton.Enabled = true;
            Ocisti();
            Omoguci();
            PanelPravna.Visible = true;
            PodaciPanel.Visible = false;
        }

        private void UrediPravna_Click(object sender, EventArgs e)
        {
            Mjesta uredi = new Mjesta();
            uredi.ShowDialog();
            string naziv = MjestoComboBox.Text;
            List<bazaF.Mjesto> mjesto = baza.Mjesto.AsNoTracking().OrderBy(x => x.Naziv).ToList();
            MjestoComboBox.DataSource = mjesto;
            MjestoPravnaCombo.DataSource = mjesto;
            MjestoComboBox.Text = naziv;
        }

        private void UrediFizicka_Click(object sender, EventArgs e)
        {
            Mjesta uredi = new Mjesta();
            uredi.ShowDialog();
            string naziv = MjestoComboBox.Text;
            List<bazaF.Mjesto> mjesto = baza.Mjesto.AsNoTracking().OrderBy(x => x.Naziv).ToList();
            MjestoComboBox.DataSource = mjesto;
            MjestoPravnaCombo.DataSource = mjesto;
            MjestoComboBox.Text = naziv;
        }

        private void OsvjeziButton_Click(object sender, EventArgs e)
        {
            PretragaTextBox.Text = "";
            FizickaOsobaLoad(this, e);
        }

    }
}
