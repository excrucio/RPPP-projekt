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
using System.IO;

namespace FormaPresuda
{
    public partial class UnosPresude : Form
    {

        bool isprOsoba, presudaDodana, fileDodao,izmjena;
        byte[] BLOB;

        bazaF.RPPP10 baza = new bazaF.RPPP10();
        int IDProcesa=0;
        private int idPres;
        private int proc;

        public UnosPresude(int IDProc = 1)
        {
            InitializeComponent();
            tbNaziv.Enabled = false;
            this.IDProcesa = IDProc;


          /*
            from itemA in TableA 
                 join itemB in TableB on itemA.ID equals itemB.ID
                 where neš== neš
                 select new { itemA, itemB };
            */

            try
            {
                var proc = from x in baza.Proces
                           where x.IDProcesa == IDProc
                           select new { x.Naziv };

                this.tbNaziv.Text = proc.ToList()[0].Naziv;

                var optFiz = from x in baza.Optuzenik
                             join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                             join z in baza.FizickaOsoba on x.IDOsobe equals z.IDOsobe
                             where x.IDProces == IDProc
                             select new { z.Ime, z.Prezime, z.IDOsobe };

                var optPrav = from x in baza.Optuzenik
                              join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                              join z in baza.PravnaOsoba on x.IDOsobe equals z.IDOsobe
                              where x.IDProces == IDProc
                              select new { z.Naziv, z.IDOsobe };

                this.dgOptFiz.DataSource = optFiz.ToList();
                this.dgOptPrav.DataSource = optPrav.ToList();

                dgOptFiz.Columns[2].Visible = false;
                dgOptPrav.Columns[1].Visible = false;

                this.dgOptFiz.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dgOptPrav.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                var tip = from x in baza.TipPresude
                          select new { x.NazivTipa, x.SifraTipa };

                this.cbPresudaTip.DataSource = tip.ToList();
                this.cbPresudaTip.DisplayMember = "NazivTipa";
                this.cbPresudaTip.ValueMember = "SifraTipa";
                this.cbPresudaTip.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbPresudaTip.SelectedIndex = 0;
            }
            catch (Exception greska)
            {

                MessageBox.Show("Greška!!:\n\n"+greska.ToString());
            }

        }

        public UnosPresude(int idPres, int IDProc)
        {
            InitializeComponent();

            tbNaziv.Enabled = false;
            this.IDProcesa = IDProc;
            this.idPres = idPres;

            btnSpremi.Text = "Izmjeni";
            this.izmjena=true;


            try
            {
                var proc = from x in baza.Proces
                           where x.IDProcesa == IDProc
                           select new { x.Naziv };

                this.tbNaziv.Text = proc.ToList()[0].Naziv;

                var optFiz = from x in baza.Optuzenik
                             join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                             join z in baza.FizickaOsoba on x.IDOsobe equals z.IDOsobe
                             join k in baza.Kazna on z.IDOsobe equals k.IDOsobe
                             join h in baza.Presuda on k.IDPresude equals h.IDStavke
                             where x.IDProces == IDProc
                             where h.IDStavke==idPres
                             select new { z.Ime, z.Prezime, z.IDOsobe };

                var optPrav = from x in baza.Optuzenik
                              join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                              join z in baza.PravnaOsoba on x.IDOsobe equals z.IDOsobe
                              join k in baza.Kazna on z.IDOsobe equals k.IDOsobe
                              join h in baza.Presuda on k.IDPresude equals h.IDStavke
                              where x.IDProces == IDProc
                              where h.IDStavke == idPres
                              select new { z.Naziv, z.IDOsobe };

                this.dgOptFiz.DataSource = optFiz.ToList();
                this.dgOptPrav.DataSource = optPrav.ToList();

                dgOptFiz.Columns[2].Visible = false;
                dgOptPrav.Columns[1].Visible = false;

                this.dgOptFiz.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dgOptPrav.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                var tip = from x in baza.TipPresude
                          select new { x.NazivTipa, x.SifraTipa };

                this.cbPresudaTip.DataSource = tip.ToList();
                this.cbPresudaTip.DisplayMember = "NazivTipa";
                this.cbPresudaTip.ValueMember = "SifraTipa";
                this.cbPresudaTip.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbPresudaTip.SelectedIndex = 0;
            }
            catch (Exception greska)
            {

                MessageBox.Show("Greška!!:\n\n" + greska.ToString());
            }
        }
        
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ovo je za fizičke
            dgOptPrav.ClearSelection();
        }

        private void UnosPresude_Load(object sender, EventArgs e)
        {

        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgOptPrav_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgOptFiz.ClearSelection();
        }

        private void klik(object sender, EventArgs e)
        {

        }


        //validacija fizičke osobe i pravne
        private void izabranaOsoba_validate(object sender, CancelEventArgs e)
        {
            isprOsoba=valja_osoba((DataGridView) sender);
        }

        private bool valja_osoba(DataGridView dg)
        {

            if (this.dgOptFiz.SelectedRows.Count > 0 || this.dgOptPrav.SelectedRows.Count > 0)
            {
                errorProv.Clear();
               return true;
            }

            errorProv.SetError(this.panel, "Morate odabrati optuženika.");
            return false;
        }

        private void dodanDokument_validate(object sender, CancelEventArgs e)
        {
            this.presudaDodana=ima_dok((Button)sender);
        }

        private bool ima_dok(Button bt) {

            if (fileDodao==true){
                errorDok.Clear();
                return true;
            }
            errorDok.SetError(bt, "Morate dodati presudu.");
            return false;

        }

        private void btnDodajPresudu_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OpenFileDialog = new OpenFileDialog();
                OpenFileDialog.Title = "Dodaj presudu...";

                if (dodavanjePresudeOFD.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(dodavanjePresudeOFD.FileName, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);

                    this.BLOB = br.ReadBytes((int)fs.Length);

                    fs.Close();
                    br.Close();
                    this.fileDodao = true;
                }
            }
            catch (Exception greska)
            {

                MessageBox.Show("Greška:\n\n"+greska.ToString());
            }
            

        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            if (isprOsoba && presudaDodana && !izmjena)
            {
                bazaF.Presuda presuda = new bazaF.Presuda();


                int max = 0;
                var ima = (from x in baza.Presuda select x.IDStavke);

                if (ima.Count() > 0)
                {
                    max = ima.Max();
                }

                presuda.Dokument = this.BLOB;
                presuda.IDStavke = max + 1;
                presuda.TipPresude = (Int32)cbPresudaTip.SelectedValue;

                bazaF.Kazna kazna = new bazaF.Kazna();

                if (dgOptFiz.SelectedRows.Count == 1) {
                     kazna.IDOsobe =(Int32) dgOptFiz.CurrentRow.Cells[2].Value;
                }
                else if (dgOptPrav.SelectedRows.Count == 1) 
                {
                    kazna.IDOsobe = (Int32)dgOptPrav.CurrentRow.Cells[1].Value;
                }

                kazna.IDPresude = max + 1;

                max = 0;
                ima = (from x in baza.Kazna select x.IDKazne);

                if (ima.Count() > 0)
                {
                    max = ima.Max();
                }

                kazna.IDKazne = max + 1;

                baza.Presuda.Add(presuda);
                baza.Kazna.Add(kazna);
                baza.SaveChanges();

                MessageBox.Show("Uspješno spremljeno u bazu!");
                reset();
            }

            if (isprOsoba && presudaDodana && izmjena) {
                var izmj = baza.Presuda.First(i => i.IDStavke == this.idPres);

                izmj.Dokument = this.BLOB;
                izmj.TipPresude = (Int32)cbPresudaTip.SelectedValue;

                baza.SaveChanges();

                MessageBox.Show("Uspješno izmjenjeno!");
                
                this.Close();
            }

        }

        private void reset() { 
            isprOsoba=presudaDodana=fileDodao=false;
            dgOptFiz.ClearSelection();
            dgOptPrav.ClearSelection();
            cbPresudaTip.SelectedIndex = 0;
            errorProv.SetError(this.panel, "Morate odabrati optuženika.");
            errorDok.SetError(this.btnDodajPresudu, "Morate dodati presudu.");

        }

        private void glavnaFormaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PretrazivanjePresude pretraga = new PretrazivanjePresude();
            pretraga.Show();
        }
        


    }
}
