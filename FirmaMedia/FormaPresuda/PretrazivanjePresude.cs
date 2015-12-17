using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaPresuda
{
    public partial class PretrazivanjePresude : Form
    {

        bool oznaceno = false;

        bazaF.RPPP10 baza = new bazaF.RPPP10();

        public PretrazivanjePresude()
        {
            InitializeComponent();
        }

        private void PretrazivanjePresude_Load(object sender, EventArgs e)
        {

        }

        private void rbFiz_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFiz.Checked == true) {
                rbPrav.Checked = false;
                tbPrezime.Enabled = true;
            }
        }

        private void rbPrav_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrav.Checked == true)
            {
                rbFiz.Checked = false;
                tbPrezime.Enabled = false;
            }
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbFiz.Checked == true)
                {
                    var presude = from x in baza.Optuzenik
                                  join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                                  join z in baza.Proces on x.IDProces equals z.IDProcesa
                                  join k in baza.Kazna on x.IDOsobe equals k.IDOsobe
                                  join j in baza.Presuda on k.IDPresude equals j.IDStavke
                                  join i in baza.FizickaOsoba on x.IDOsobe equals i.IDOsobe
                                  join h in baza.TipPresude on j.TipPresude equals h.SifraTipa
                                  join g in baza.VrstaKazne on k.Vrsta equals g.SifraVrste
                                  where i.Ime.Contains(tbIme.Text)
                                  where i.Prezime.Contains(tbPrezime.Text)
                                  select new { i.Ime, i.Prezime, z.Naziv, h.NazivTipa, x.IDOptuzenika, z.IDProcesa, k.IDOsobe, g.NazivVrste, k.IDPresude };

                    dgRezultati.DataSource = null;
                    dgRezultati.DataSource = presude.ToList();
                    dgRezultati.Columns[2].HeaderText = "Proces";
                    dgRezultati.Columns[3].HeaderText = "Presuda";
                    dgRezultati.Columns[4].Visible = false;
                    dgRezultati.Columns[5].Visible = false;
                    dgRezultati.Columns[6].Visible = false;
                    dgRezultati.Columns[7].HeaderText = "Kazna";
                    dgRezultati.Columns[8].Visible = false;

                }
                else
                {
                    var presude = from x in baza.Optuzenik
                                  join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                                  join z in baza.Proces on x.IDProces equals z.IDProcesa
                                  join k in baza.Kazna on x.IDOsobe equals k.IDOsobe
                                  join j in baza.Presuda on k.IDPresude equals j.IDStavke
                                  join i in baza.PravnaOsoba on x.IDOsobe equals i.IDOsobe
                                  join h in baza.TipPresude on j.TipPresude equals h.SifraTipa
                                  join g in baza.VrstaKazne on k.Vrsta equals g.SifraVrste
                                  where i.Naziv.Contains(tbIme.Text)
                                  select new { i.Naziv, h.NazivTipa, x.IDOptuzenika, z.IDProcesa, k.IDOsobe, g.NazivVrste, k.IDPresude };

                    dgRezultati.DataSource = null;
                    dgRezultati.DataSource = presude.ToList();
                    dgRezultati.Columns[1].HeaderText = "Presuda";
                    dgRezultati.Columns[2].Visible = false;
                    dgRezultati.Columns[3].Visible = false;
                    dgRezultati.Columns[4].Visible = false;
                    dgRezultati.Columns[5].HeaderText = "Kazna";
                    dgRezultati.Columns[6].Visible = false;
                }
            }
            catch (Exception greska)
            {

                MessageBox.Show("Greška:\n\n"+greska.ToString());
            }

        }

        private void btnUzmi_Click(object sender, EventArgs e)
        {
            if (oznaceno) {
                int idPres;
                if (rbFiz.Checked==true){
                    idPres=Convert.ToInt32(dgRezultati.CurrentRow.Cells[8].Value.ToString());
                }
                else{
                    idPres = Convert.ToInt32(dgRezultati.CurrentRow.Cells[6].Value.ToString());
                }
                var document = from x in baza.Presuda
                               where x.IDStavke == idPres
                               select new { x.Dokument };

                byte[] dok = document.ToArray()[0].Dokument;

                SaveFileDialog mydialogbox = new SaveFileDialog();
                mydialogbox.DefaultExt = ".pdf";
       
                if (mydialogbox.ShowDialog() == DialogResult.OK && dok != null)
                {
                    string filename = mydialogbox.FileName;
                    System.IO.File.WriteAllBytes(filename,dok);
                    if (MessageBox.Show("Presuda preuzeta!\n\nŽelite li ju odmah pregledati?", "Spremljeno!", MessageBoxButtons.YesNo)==DialogResult.Yes) {
                        System.Diagnostics.Process.Start(filename);
                    }
                }
                if (dok == null) {
                    MessageBox.Show("Nema presude u bazi!");
                }
            }

        }

        private void pregled_validate(object sender, CancelEventArgs e)
        {
            oznaceno = odabran((DataGridView) sender);
        }

        private bool odabran(DataGridView dg) {
            if (dg.SelectedRows.Count == 1) {
                errorPregled.Clear();
                return true;
            }

            errorPregled.SetError(dg,"Morate odabrati nešto da bi ste mogli pregledati!");
            return false;
        }

        private void btnPregledaj_Click(object sender, EventArgs e)
        {
            if (oznaceno) {
                int idPres, proc;
                if (rbFiz.Checked == true)
                {
                    idPres = Convert.ToInt32(dgRezultati.CurrentRow.Cells[8].Value.ToString());
                    proc = Convert.ToInt32(dgRezultati.CurrentRow.Cells[5].Value.ToString());
                }
                else
                {
                    idPres = Convert.ToInt32(dgRezultati.CurrentRow.Cells[6].Value.ToString());
                    proc = Convert.ToInt32(dgRezultati.CurrentRow.Cells[3].Value.ToString());
                }

                UnosPresude izmjena = new UnosPresude(idPres, proc);
                izmjena.Show();

            }

        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                if (oznaceno)
                {

                    int idPres, proc;
                    if (rbFiz.Checked == true)
                    {
                        idPres = Convert.ToInt32(dgRezultati.CurrentRow.Cells[8].Value.ToString());
                    }
                    else
                    {
                        idPres = Convert.ToInt32(dgRezultati.CurrentRow.Cells[6].Value.ToString());
                    }

                    var ZaBrisanje = baza.Presuda.First(x => x.IDStavke == idPres);
                    if (MessageBox.Show("jeste sigurni da želite bespovratno obrisati ovu stavku?", "Upozorenje!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        baza.Presuda.Remove(ZaBrisanje);
                        baza.SaveChanges();
                        MessageBox.Show("Uspješno uklonjeno!");
                    }
                }
            }
            catch (Exception greska)
            {

                MessageBox.Show("Greška:\n\n" + greska.ToString());
            }

        }
    }
}
