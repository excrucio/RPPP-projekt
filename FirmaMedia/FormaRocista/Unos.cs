using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaRocista
{
    public partial class Unos : Form
    {
        bool IspravnostNazivaProcesa, IspravnostDana, IspravnostMjeseca, IspravnostGodine,
            IspravnostSataPocetka, IspravnostMinPocetka, IspravnostSataZavrsetka, IspravnostMinZavrsetka;
        Font defaultFont;
        Color defaultColor;
        
        public Unos()
        {
            InitializeComponent();

            bazaF.RPPP10 baza = new bazaF.RPPP10();
            var Procesi = (from x in baza.Proces select new {x.IDProcesa, x.Naziv}).ToList();
            var Uloge = (from x in baza.UlogaSudionika select new {x.SifraUloge, x.NazivUloge}).ToList();
            var Imena = (from x in baza.FizickaOsoba select  new {x.IDOsobe, PunoIme = x.Ime + " " +  x.Prezime}).ToList();
            baza.Dispose();

            cmbNazivProcesa.DataSource = Procesi;
            cmbNazivProcesa.ValueMember = "IDProcesa";
            cmbNazivProcesa.DisplayMember = "Naziv";
            cmbNazivProcesa.SelectedItem = null;
            
            cmbDanRocista.Items.Clear();
            cmbMjesecRocista.Items.Clear();
            cmbSatPocetka.Items.Clear();
            cmbSatZavrsetka.Items.Clear();
            cmbMinPocetka.Items.Clear();
            cmbMinZavrsetka.Items.Clear();
            cmbGodinaRocista.Items.Clear();


            for (int i = 0; i <= 59; i++)
            {
                if (i < 24) cmbSatPocetka.Items.Add(i);
                if (i < 24) cmbSatZavrsetka.Items.Add(i);
                if ((i > 0) && (i <= 31)) cmbDanRocista.Items.Add(i);
                if ((i > 0) && (i <= 12)) cmbMjesecRocista.Items.Add(i);
            }
            for (int i = 2014; i >= 1950; i--) cmbGodinaRocista.Items.Add(i);
            string[] minute = {"00", "01", "02", "03", "04","05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", 
                                "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31",
                            "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47",
                            "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59"};
            for (int i = 0; i < 60; i++) 
            {
                cmbMinPocetka.Items.Add(minute[i]);
                cmbMinZavrsetka.Items.Add(minute[i]);
            }

            dgvSudionici.AllowUserToAddRows = true;
            dgvSudionici.AllowUserToDeleteRows = true;
            dgvSudionici.AutoGenerateColumns = false;

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Uloga";
            cmb.Name = "cmbUloga";
            cmb.DataSource = Uloge;
            cmb.ValueMember = "SifraUloge";
            cmb.DisplayMember = "NazivUloge";
            dgvSudionici.Columns.Add(cmb);

            cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Ime i prezime";
            cmb.Name = "cmbImePrezime";
            cmb.DataSource = Imena;
            cmb.ValueMember = "IDOsobe";
            cmb.DisplayMember = "PunoIme";
            dgvSudionici.Columns.Add(cmb);

            dgvSudionici.Columns[0].Width = 100;
            dgvSudionici.Columns[1].Width = dgvSudionici.Width - 100 - 40;
            
            defaultFont = this.Font;
            defaultColor = this.BackColor;
           

        }
        // Validacija naziva procesa
        private void cmbNazivProcesa_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostNazivaProcesa = IspravanNazivProcesa((ComboBox)sender);
        }

        private bool IspravanNazivProcesa(ComboBox cmb)
        {
            if (!(cmb.SelectedIndex > -1))
            {
                epDatum.SetError(cmb, "Odaberite naziv procesa.");
                return false;
            }
            else
            {
                epDatum.SetError(cmb, "");
                return true;
            }
        }

        // Validacija datuma
        private void cmbDanRocista_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostDana = IspravanDan((ComboBox)sender);
        }

        private bool IspravanDan(ComboBox cmb)
        {
            if (!(cmb.SelectedIndex > -1))
            {
                epDatum.SetError(cmb, "Unesite ispravan dan datuma.");
                return false;
            }
            else
            {
                epDatum.SetError(cmb, "");
                return true;
            }
        }

        private void cmbMjesecRocista_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostMjeseca = IspravanMjesec((ComboBox)sender);
        }
        private bool IspravanMjesec(ComboBox cmb)
        {
            if (!(cmb.SelectedIndex > -1))
            {
                epDatum.SetError(cmb, "Unesite ispravan mjesec datum.");
                return false;
            }
            else
            {
                epDatum.SetError(cmb, "");
                return true;
            }
        }

        private void cmbGodinaRocista_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostGodine = IspravnaGodina((ComboBox)sender);
        }
        private bool IspravnaGodina(ComboBox cmb)
        {
            if (!(cmb.SelectedIndex > -1))
            {
                epDatum.SetError(cmb, "Unesite ispravnu godinu datuma.");
                return false;
            }
            else
            {
                epDatum.SetError(cmb, "");
                return true;
            }
        }

        // Validacija vremena početka
        private void cmbSatPocetka_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostSataPocetka = IspravanSatPocetka((ComboBox)sender);
        }

        private bool IspravanSatPocetka(ComboBox cmb)
        {
            if (!(cmb.SelectedIndex > -1))
            {
                epDatum.SetError(cmb, "Odaberite sat početka ročišta.");
                return false;
            }
            else
            {
                epDatum.SetError(cmb, "");
                return true;
            }
        }

        private void cmbMinPocetka_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostMinPocetka = IspravanMinPocetka((ComboBox)sender);
        }

        private bool IspravanMinPocetka(ComboBox cmb)
        {
            if (!(cmb.SelectedIndex > -1))
            {
                epDatum.SetError(cmb, "Odaberite minute početka ročišta.");
                return false;
            }
            else
            {
                epDatum.SetError(cmb, "");
                return true;
            }
        }

        // Validacija vremena završetka
        private void cmbSatZavrsetka_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostSataZavrsetka = IspravanSatZavrsetka((ComboBox)sender);
        }

        private bool IspravanSatZavrsetka(ComboBox cmb)
        {
            if (!(cmb.SelectedIndex > -1))
            {
                epDatum.SetError(cmb, "Odaberite sat završetka ročišta.");
                return false;
            }
            else
            {
                epDatum.SetError(cmb, "");
                return true;
            }
        }

        private void cmbMinZavrsetka_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostMinZavrsetka = IspravanMinZavrsetka((ComboBox)sender);
        }

        private bool IspravanMinZavrsetka(ComboBox cmb)
        {
            if (!(cmb.SelectedIndex > -1))
            {
                epDatum.SetError(cmb, "Odaberite minute završetka ročišta.");
                return false;
            }
            else if ((int.Parse(cmbSatPocetka.SelectedItem.ToString()) > int.Parse(cmbSatZavrsetka.SelectedItem.ToString()))
                || (int.Parse(cmbSatPocetka.SelectedItem.ToString()) == int.Parse(cmbSatZavrsetka.SelectedItem.ToString()))
                && (int.Parse(cmbMinPocetka.SelectedItem.ToString()) >= int.Parse(cmbMinZavrsetka.SelectedItem.ToString())))
            {
                epDatum.SetError(cmb, "Ročište ne može završiti prije ili u trenutku kad je počelo. Odaberite pravilne datume!");
                return false;
            }
            else
            {
                if (int.Parse(cmbMinZavrsetka.SelectedItem.ToString()) - int.Parse(cmbMinPocetka.SelectedItem.ToString()) < 0)
                {
                    tbMinTrajanja.Text = (60 + int.Parse(cmbMinZavrsetka.SelectedItem.ToString()) -
                     int.Parse(cmbMinPocetka.SelectedItem.ToString())).ToString();
                    tbSatTrajanja.Text = (int.Parse(cmbSatZavrsetka.SelectedItem.ToString()) -
                    int.Parse(cmbSatPocetka.SelectedItem.ToString()) - 1).ToString();
                }
                else
                {
                    tbMinTrajanja.Text = (int.Parse(cmbMinZavrsetka.SelectedItem.ToString()) -
                    int.Parse(cmbMinPocetka.SelectedItem.ToString())).ToString();
                    tbSatTrajanja.Text = (int.Parse(cmbSatZavrsetka.SelectedItem.ToString()) -
                    int.Parse(cmbSatPocetka.SelectedItem.ToString())).ToString();
                }
                epDatum.SetError(cmb, "");
                return true;
            }
        }

       
        // Ukupna validacija
        private bool IspravnostSvega()
        {
            if (IspravnostNazivaProcesa && IspravnostDana && IspravnostMjeseca && IspravnostGodine &&
            IspravnostSataPocetka && IspravnostMinPocetka && IspravnostSataZavrsetka && IspravnostMinZavrsetka)
            {
                return true;
            }
            else
            {
                if (!IspravnostNazivaProcesa)
                    IspravnostNazivaProcesa = IspravanNazivProcesa(cmbNazivProcesa);
                if (!IspravnostDana)
                    IspravnostDana = IspravanDan(cmbDanRocista);
                if (!IspravnostMjeseca)
                    IspravnostMjeseca = IspravanMjesec(cmbMjesecRocista);
                if (!IspravnostGodine)
                    IspravnostGodine = IspravnaGodina(cmbGodinaRocista);
                if (!IspravnostSataPocetka)
                    IspravnostSataPocetka = IspravanSatPocetka(cmbSatPocetka);
                if (!IspravnostMinPocetka)
                    IspravnostMinPocetka = IspravanMinPocetka(cmbMinPocetka);
                if (!IspravnostSataZavrsetka)
                    IspravnostSataZavrsetka = IspravanSatZavrsetka(cmbSatZavrsetka);
                if (!IspravnostMinZavrsetka)
                    IspravnostMinZavrsetka = IspravanMinZavrsetka(cmbMinZavrsetka);
                if (IspravnostNazivaProcesa && IspravnostDana && IspravnostMjeseca && IspravnostGodine &&
                     IspravnostSataPocetka && IspravnostMinPocetka && IspravnostSataZavrsetka && IspravnostMinZavrsetka)
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
               // MessageBox.Show("Naziv: " + IspravnostNazivaProcesa + "\nDan: " + IspravnostDana + "\nMjesec: " +
                    //IspravnostMjeseca + "\nGodina: " + IspravnostGodine + "\nPocetak: " + IspravnostSataPocetka + 
                   // IspravnostMinPocetka + "\nZavršetak: " + IspravnostSataPocetka + IspravnostMinPocetka);
            }
        }

        private void btnOdustaniRoc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpremiRoc_Click(object sender, EventArgs e)
        {
            if (IspravnostSvega())
            {
                bazaF.RPPP10 baza = new bazaF.RPPP10();

                var Procesi = (from x in baza.Proces select new { x.IDProcesa, x.Naziv }).ToList();
                var Uloge = (from x in baza.UlogaSudionika select new { x.SifraUloge, x.NazivUloge }).ToList();
                var Imena = (from x in baza.FizickaOsoba select new { x.IDOsobe, x.Ime, x.Prezime }).ToList();
                
                bazaF.Rociste Rociste = new bazaF.Rociste();
                bazaF.Sudionik Sudionik = new bazaF.Sudionik();

                int maxRociste = 0;
                try
                {
                    var Rezultat = (from x in baza.Rociste select x.IDRocista);
                    maxRociste = Rezultat.Max();
                }
                catch
                {
                    maxRociste = 0;
                }
                int maxSudionik = 0;
                try
                {
                    var Rezultat = (from x in baza.Sudionik select x.IDSudionika);
                    maxSudionik = Rezultat.Max();
                }
                catch
                {
                    maxSudionik = 0;
                }
                
                Rociste.IDRocista = maxRociste + 1;
                Rociste.IDProcesa = int.Parse(cmbNazivProcesa.SelectedValue.ToString());
                Rociste.Datum = Convert.ToDateTime(cmbDanRocista.SelectedItem.ToString() + '.'+
                    cmbMjesecRocista.SelectedItem.ToString() + '.' + cmbGodinaRocista.SelectedItem.ToString() + ". " + 
                    cmbSatPocetka.SelectedItem.ToString() + ':' + cmbMinPocetka.SelectedItem.ToString() + ":00");
                Rociste.Trajanje = (short) Math.Round((double.Parse(tbSatTrajanja.Text) + (double.Parse(tbMinTrajanja.Text) / 60)));

                try 
                {
                    baza.Rociste.Add(Rociste);
                    baza.SaveChanges();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Upis ročišta u bazu nije uspio! Detalji:\n" + error.Message);
                    baza.Dispose();
                }

                for(var i = 0; i < dgvSudionici.RowCount - 1; i++)
                {
                    Sudionik.IDSudionika = maxSudionik + 1;
                    Sudionik.IDOsobe = Convert.ToInt32(dgvSudionici.Rows[i].Cells[1].Value.ToString());
                    Sudionik.IDRocista = maxRociste + 1;
                    Sudionik.Uloga = Convert.ToInt32(dgvSudionici.Rows[i].Cells[0].Value.ToString());

                    try
                    {
                        baza.Sudionik.Add(Sudionik);
                        baza.SaveChanges();
                        maxSudionik = maxSudionik + 1;
                        Sudionik = new bazaF.Sudionik();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Upis sudionika u bazu nije uspio! Detalji:\n" + error.Message);
                        baza.Dispose();
                    }
                }
                MessageBox.Show("Forma je uspješno popunjena i pohranjena u bazu podataka! :)");
                baza.Dispose();
                this.Close();
            }
            else
            {
                const string poruka = "Podaci su neispravno uneseni. Molimo Vas da ih ispravite prije pohrane.";
                const string caption = "Ups!";
                var odluka = MessageBox.Show(poruka, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Font = defaultFont;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            menuStrip1.Font = defaultFont;
            menuStrip1.ForeColor = System.Drawing.SystemColors.ControlText;
            lblNaslov.Font = defaultFont;
            lblNaslov.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void promijeniFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialogRociste.ShowColor = true;

            if (fontDialogRociste.ShowDialog() != DialogResult.Cancel)
            {
                this.Font = fontDialogRociste.Font;
                this.ForeColor = fontDialogRociste.Color;
                menuStrip1.Font = fontDialogRociste.Font;
                menuStrip1.ForeColor = fontDialogRociste.Color;
                lblNaslov.Font = fontDialogRociste.Font;
                lblNaslov.ForeColor = fontDialogRociste.Color;
            }
        }

        private void defaultToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.BackColor = defaultColor;
            menuStrip1.BackColor = defaultColor;
        }

        private void promijeniPozadinuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialogRociste.ShowDialog() != DialogResult.Cancel)
            {
                this.BackColor = colorDialogRociste.Color;
                menuStrip1.BackColor = colorDialogRociste.Color;
            }
        }

        private void btnObrisiRed_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSudionici.SelectedRows)
            {
                try
                {
                    dgvSudionici.Rows.Remove(row);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Označeni red nije moguće obrisati!");
                }
            }
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            btnIzmijeni.Enabled = true;
            btnSpremiRoc.Enabled = false;
            bazaF.RPPP10 baza = new bazaF.RPPP10();
            int maxRociste = 0;
            try
            {
                var Rezultat = (from x in baza.Rociste select x.IDRocista);
                maxRociste = Rezultat.Max();
                var Rociste = from x in baza.Rociste where (x.IDRocista.Equals(maxRociste)) select new {x.IDProcesa, x.Datum, x.Trajanje };
                foreach (var elem in Rociste)
                {
                    cmbNazivProcesa.SelectedValue = elem.IDProcesa;
                    char[] Delimiteri = {'.', ' ', ':'};
                    var Datum = elem.Datum.ToString().Split(Delimiteri);
                    cmbDanRocista.Text = Datum[0];
                    cmbMjesecRocista.Text = Datum[1];
                    cmbGodinaRocista.Text = Datum[2];
                    cmbSatPocetka.Text = Datum[4];
                    cmbMinPocetka.Text = Datum[5];
                    cmbSatZavrsetka.Text = (short.Parse(cmbSatPocetka.SelectedItem.ToString()) + elem.Trajanje).ToString();
                    cmbMinZavrsetka.Text = cmbMinPocetka.Text;
                    tbSatTrajanja.Text = elem.Trajanje.ToString();
                    tbMinTrajanja.Text = "0";
                }
                var Sudionici = from x in baza.Sudionik where (x.IDRocista == maxRociste) select new {x.IDOsobe, x.Uloga};
                var i = 0;
                foreach (var elem in Sudionici)
                {
                    dgvSudionici.Rows.Add(1);
                    dgvSudionici.Rows[i].Cells[0].Value = elem.Uloga;
                    dgvSudionici.Rows[i].Cells[1].Value = elem.IDOsobe;
                    i = i + 1;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Nema prethodnih upisa!\n" + error.Message);
            }
            
            baza.Dispose();
            
        }

        private void btnUnosZapisnika_Click(object sender, EventArgs e)
        {
            FormaSpis.UnosUSpis zapisnik = new FormaSpis.UnosUSpis();
            zapisnik.Show();
        }

        private void btnIzmijeni_Click(object sender, EventArgs e)
        {
            if (IspravnostSvega())
            {
                bazaF.RPPP10 baza = new bazaF.RPPP10();

                var Procesi = (from x in baza.Proces select new { x.IDProcesa, x.Naziv }).ToList();
                var Uloge = (from x in baza.UlogaSudionika select new { x.SifraUloge, x.NazivUloge }).ToList();
                var Imena = (from x in baza.FizickaOsoba select new { x.IDOsobe, x.Ime, x.Prezime }).ToList();

                bazaF.Rociste Rociste = new bazaF.Rociste();
                bazaF.Sudionik Sudionik = new bazaF.Sudionik();

                int maxRociste = 0;
                try
                {
                    var Rezultat = (from x in baza.Rociste select x.IDRocista);
                    maxRociste = Rezultat.Max();
                }
                catch
                {
                    maxRociste = 0;
                }
                var StariSudionici = (from x in baza.Sudionik where x.IDRocista == maxRociste select x).ToList();
                var StaroRociste = (from x in baza.Rociste where x.IDRocista == maxRociste select x).ToList();
                baza.Sudionik.RemoveRange(StariSudionici);
                baza.Rociste.RemoveRange(StaroRociste);
                baza.SaveChanges();

                Rociste.IDRocista = maxRociste;
                Rociste.IDProcesa = int.Parse(cmbNazivProcesa.SelectedValue.ToString());
                Rociste.Datum = Convert.ToDateTime(cmbDanRocista.SelectedItem.ToString() + '.' +
                    cmbMjesecRocista.SelectedItem.ToString() + '.' + cmbGodinaRocista.SelectedItem.ToString() + ". " +
                    cmbSatPocetka.SelectedItem.ToString() + ':' + cmbMinPocetka.SelectedItem.ToString() + ":00");
                Rociste.Trajanje = (short)Math.Round((double.Parse(tbSatTrajanja.Text) + (double.Parse(tbMinTrajanja.Text) / 60)));

                try
                {
                    baza.Rociste.Add(Rociste);
                    baza.SaveChanges();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Upis ročišta u bazu nije uspio! Detalji:\n" + error.Message);
                    baza.Dispose();
                    return;
                }

                int maxSudionik = 0;
                try
                {
                    var Rezultat = (from x in baza.Sudionik select x.IDSudionika);
                    maxSudionik = Rezultat.Max();
                }
                catch
                {
                    maxSudionik = 0;
                }

                for (var i = 0; i < dgvSudionici.RowCount - 1; i++)
                {
                    Sudionik.IDSudionika = maxSudionik + 1;
                    Sudionik.IDOsobe = Convert.ToInt32(dgvSudionici.Rows[i].Cells[1].Value.ToString());
                    Sudionik.IDRocista = maxRociste;
                    Sudionik.Uloga = Convert.ToInt32(dgvSudionici.Rows[i].Cells[0].Value.ToString());

                    try
                    {
                        baza.Sudionik.Add(Sudionik);
                        maxSudionik = maxSudionik + 1;
                        Sudionik = new bazaF.Sudionik();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Upis sudionika u bazu nije uspio! Detalji:\n" + error.Message);
                        baza.Dispose();
                        return;
                    }
                }
                try
                {
                    baza.SaveChanges();
                    MessageBox.Show("Forma je uspješno popunjena i pohranjena u bazu podataka! :)");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Promjene ne mogu biti pohranjene u bazu podataka.\n" + error.Message +
                        error.InnerException);
                }
                baza.Dispose();
                this.Close();
            }
            else
            {
                const string poruka = "Podaci su neispravno uneseni. Molimo Vas da ih ispravite prije pohrane.";
                const string caption = "Ups!";
                var odluka = MessageBox.Show(poruka, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


    }
}
