using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Linq;

namespace FormaProces
{
    public partial class ProcesUnos : Form
    {
        private bool mjenjano = false;
        private int IDtraz;
        private int IdProcesa = 0;
        private bazaF.RPPP10 baza = new bazaF.RPPP10();

        

        List<string> optuzenici = new List<string>();

        private FontDialog fontDialog = new FontDialog();
        private ColorDialog colorDialog = new ColorDialog();

        Font defaultFont; // sami pamtimo početno pismo i font postavljene u dizajnu
        Color defaultColor;

        //
        // ukloniti X gumb jer se ne smije zatvarati putem njega
        // 
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public ProcesUnos()
        {
            InitializeComponent();

            defaultFont = this.Font;
            defaultColor = this.BackColor;

            //učitati sve moguće izbore u sud i oznaku

            var sudovi = baza.Sud.Select(x => new { x.Naziv, x.IDSuda });
            this.cbSud.DataSource = sudovi.ToList();
            this.cbSud.DisplayMember = "Naziv";
            this.cbSud.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbSud.SelectedIndex = 0;

            //oznake procesa...
            var oznake = baza.VrstaOznake.Select(x => new { x.OpisOznake, x.SifraOznake });
            this.cbOznaka.DataSource = oznake.ToList();
            this.cbOznaka.DisplayMember = "SifraOznake";
            this.cbOznaka.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbOznaka.SelectedIndex = 0;
        }

        public ProcesUnos(int ProcesID)
        {
            InitializeComponent();
            this.IdProcesa = ProcesID;

            defaultFont = this.Font;
            defaultColor = this.BackColor;

            //učitati sve moguće izbore u sud i oznaku

            var sudovi = baza.Sud.Select(x => new { x.Naziv, x.IDSuda });
            this.cbSud.DataSource = sudovi.ToList();
            this.cbSud.DisplayMember = "Naziv";
            this.cbSud.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbSud.SelectedIndex = 0;

            //oznake procesa...
            var oznake = baza.VrstaOznake.Select(x => new { x.OpisOznake, x.SifraOznake });
            this.cbOznaka.DataSource = oznake.ToList();
            this.cbOznaka.DisplayMember = "SifraOznake";
            this.cbOznaka.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbOznaka.SelectedIndex = 0;

            //popuniti sve ljude*********************************************************************
            //tuzitelji
            var upit1 = from x in baza.Tuzitelj
                        join y in baza.PravnaOsoba on x.IDOsobe equals y.IDOsobe
                        where x.IDProcesa == this.IdProcesa
                        select new { y.Naziv, y.MB, y.IDOsobe };

            var upit2 = from x in baza.Tuzitelj
                        join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
                        where x.IDProcesa == this.IdProcesa
                        select new { y.Ime, y.Prezime, y.IDOsobe };

            var Lista1 = upit1.ToList();
            var Lista2 = upit2.ToList();

            this.dgTuziteljPrav.DataSource = null;
            this.dgTuziteljPrav.DataSource = Lista1;
            this.dgTuziteljFiz.DataSource = null;
            this.dgTuziteljFiz.DataSource = Lista2;

            //branitelji
              var  upitb1 = from x in baza.Branitelj
                        join y in baza.PravnaOsoba on x.IDOsobe equals y.IDOsobe
                        join z in baza.Optuzenik on x.IDOptuzenika equals z.IDOptuzenika
                        where z.IDProces == this.IdProcesa
                        select new { y.Naziv, y.MB, x.IDOsobe, z.IDOptuzenika };

                var upitb2 = from x in baza.Branitelj
                        join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
                        join z in baza.Optuzenik on x.IDOptuzenika equals z.IDOptuzenika
                        where z.IDProces == this.IdProcesa
                        select new { y.Ime, y.Prezime, x.IDOsobe, z.IDOptuzenika };

            var Listab1 = upitb1.ToList();
            var Listab2 = upitb2.ToList();

            this.dgBraniteljPrav.DataSource = null;
            this.dgBraniteljPrav.DataSource = Listab1;
            this.dgBraniteljFiz.DataSource = null;
            this.dgBraniteljFiz.DataSource = Listab2;

            //optuženici
            var upitz1 = from x in baza.Optuzenik
                        join y in baza.PravnaOsoba on x.IDOsobe equals y.IDOsobe
                         where x.IDProces == this.IdProcesa
                        select new { y.Naziv, y.MB };

            var upitz2 = from x in baza.Optuzenik
                        join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
                         where x.IDProces == this.IdProcesa
                        select new { y.Ime, y.Prezime };

            var Listaz1 = upitz1.ToList();
            var Listaz2 = upitz2.ToList();

            this.dgOptuzeniciPrav.DataSource = null;
            this.dgOptuzeniciPrav.DataSource = Listaz1;
            this.dgOptuzeniciFiz.DataSource = null;
            this.dgOptuzeniciFiz.DataSource = Listaz2;

            //ostecenici
            var ost1 = from x in baza.Ostecenik
                       join y in baza.PravnaOsoba on x.IDOsobe equals y.IDOsobe
                       where x.IDProces == this.IdProcesa
                       select new { y.Naziv, y.MB };

            var ost2 = from x in baza.Ostecenik
                       join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
                       where x.IDProces == this.IdProcesa
                       select new { y.Ime, y.Prezime };

            var Listao1 = ost1.ToList();
            var Listao2 = ost2.ToList();

            this.dgOsteceniciPrav.DataSource = null;
            this.dgOsteceniciPrav.DataSource = Listao1;
            this.dgOsteceniciFiz.DataSource = null;
            this.dgOsteceniciFiz.DataSource = Listao2;

            //svjedoci
            var upitv2 = from x in baza.Svjedok
                        join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
                         where x.IDProces == this.IdProcesa
                        select new { y.Ime, y.Prezime };

            var Listav2 = upitv2.ToList();

            this.dgSvjedoci.DataSource = null;
            this.dgSvjedoci.DataSource = Listav2;

            //***************************************************************

        //popuniti naziv i ur broj i klasu
            var proc = from x in baza.Proces
                       where x.IDProcesa==this.IdProcesa
                       select new { x.Naziv, x.Klasa, x.Broj };

            tbKlasa.Text = proc.ToArray()[0].Klasa.ToString();
            tbUrBroj.Text = proc.ToArray()[0].Broj.ToString();
            tbNaziv.Text = proc.ToArray()[0].Naziv.ToString();

            //omogućiti kontrole izmjene
            optDel.Enabled = true;
            ostDel.Enabled = true;
            SvjDel.Enabled = true;
            tuzDel.Enabled = true;
            branDel.Enabled = true;

            button2.Visible = true;

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.Font = fontDialog.Font;
            }

        }

        private void temaSvjetla_Click(object sender, EventArgs e)
        {
            this.Font = defaultFont;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BackColor = Color.White;
        }

        private void izborPozadina_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.BackColor = colorDialog.Color;
            }
        }

        private void temaTamna_Click(object sender, EventArgs e)
        {
            this.ForeColor=Color.WhiteSmoke;
            this.BackColor=Color.FromArgb(80,80,80);

        }

        private void btnOptuzenici_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Za pravnu osobu odaberite YES, a za fizičku NO!", "odabir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OdabirOsobe osoba = new OdabirOsobe("opt", true);
                while(osoba.ShowDialog()!=DialogResult.Cancel ){
                }
                this.IDtraz = osoba.povratakID;
            }
            else
            {
                OdabirOsobe osoba = new OdabirOsobe("opt", false);
                while (osoba.ShowDialog() != DialogResult.Cancel)
                {
                }
                this.IDtraz = osoba.povratakID;
            }
            //var upit1 = from x in baza.Optuzenik
            //            join y in baza.PravnaOsoba on x.IDOsobe equals y.IDOsobe
            //            where x.IDOsobe == this.IDtraz
            //            select new { y.Naziv, y.MB };

            //var upit2 = from x in baza.Optuzenik
            //            join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
            //            where x.IDOsobe == this.IDtraz
            //            select new { y.Ime, y.Prezime };

            var upit1 = from x in baza.Osoba
                        join y in baza.PravnaOsoba on x.IDOsobe equals y.IDOsobe
                        where x.IDOsobe == this.IDtraz
                        select new { y.Naziv, y.MB };

            var upit2 = from x in baza.Osoba
                        join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
                        where x.IDOsobe == this.IDtraz
                        select new { y.Ime, y.Prezime };


            var Lista1 = upit1.ToList();
            var Lista2 = upit2.ToList();

            if (Lista1.Count > 0)
                this.dgOptuzeniciPrav.DataSource = Lista1;
            if (Lista2.Count > 0)
                this.dgOptuzeniciFiz.DataSource = Lista2;

            }

        private void btnOstecenici_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Za pravnu osobu odaberite YES, a za fizičku NO!", "odabir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OdabirOsobe osoba = new OdabirOsobe("ost",true);
                while (osoba.ShowDialog() != DialogResult.Cancel)
                {
                }
                this.IDtraz=osoba.povratakID;

            }
            else {
                OdabirOsobe osoba = new OdabirOsobe("ost", false);
                while (osoba.ShowDialog() != DialogResult.Cancel)
                {
                }
                this.IDtraz = osoba.povratakID;

            }

            //var ost1 = from x in baza.Ostecenik
            //           join y in baza.PravnaOsoba on x.IDOsobe equals y.IDOsobe
            //           where x.IDOsobe == this.IDtraz
            //           select new { y.Naziv, y.MB };

            //var ost2 = from x in baza.Ostecenik
            //           join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
            //           where x.IDOsobe == this.IDtraz
            //           select new { y.Ime, y.Prezime };

            var upit1 = from x in baza.Osoba
                        join y in baza.PravnaOsoba on x.IDOsobe equals y.IDOsobe
                        where x.IDOsobe == this.IDtraz
                        select new { y.Naziv, y.MB };

            var upit2 = from x in baza.Osoba
                        join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
                        where x.IDOsobe == this.IDtraz
                        select new { y.Ime, y.Prezime };


            var Lista1 = upit1.ToList();
            var Lista2 = upit2.ToList();

            if (Lista1.Count>0)
                this.dgOsteceniciPrav.DataSource = Lista1;
            if (Lista2.Count>0)
                this.dgOsteceniciFiz.DataSource = Lista2;
            
        }

        private void btnSvjedoci_Click(object sender, EventArgs e)
        {
            
                OdabirOsobe osoba = new OdabirOsobe("svj", false);
                while (osoba.ShowDialog() != DialogResult.Cancel)
                {
                }
                this.IDtraz = osoba.povratakID;


            var upit2 = from x in baza.Osoba
                        join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
                        where x.IDOsobe == this.IDtraz
                        select new { y.Ime, y.Prezime };

            var Lista2 = upit2.ToList();


            if (Lista2.Count > 0)
                this.dgSvjedoci.DataSource = Lista2;

        }

        private void btnTuzitelj_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Za pravnu osobu odaberite YES, a za fizičku NO!", "odabir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OdabirOsobe osoba = new OdabirOsobe("tuz", true);
                while (osoba.ShowDialog() != DialogResult.Cancel && osoba.ShowDialog() != DialogResult.Abort)
                {
                }
                this.IDtraz = osoba.povratakID;

                
            }
            else
            {
                OdabirOsobe osoba = new OdabirOsobe("tuz", false);
                while (osoba.ShowDialog() != DialogResult.Cancel)
                {
                }
                this.IDtraz = osoba.povratakID;

            }

            //var upit1 = from x in baza.Tuzitelj
            //            join y in baza.PravnaOsoba on x.IDOsobe equals y.IDOsobe
            //            where x.IDOsobe == this.IDtraz
            //            select new { y.Naziv, y.MB, y.IDOsobe };

            //var upit2 = from x in baza.Tuzitelj
            //            join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
            //            where x.IDOsobe == this.IDtraz
            //            select new { y.Ime, y.Prezime, y.IDOsobe };

            var upit1 = from x in baza.Osoba
                        join y in baza.PravnaOsoba on x.IDOsobe equals y.IDOsobe
                        where x.IDOsobe == this.IDtraz
                        select new { y.Naziv, y.MB };

            var upit2 = from x in baza.Osoba
                        join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
                        where x.IDOsobe == this.IDtraz
                        select new { y.Ime, y.Prezime };


            var Lista1 = upit1.ToList();
            var Lista2 = upit2.ToList();
            var to2=Lista2.GetType();

            if (Lista1.Count > 0)
                this.dgTuziteljPrav.DataSource = Lista1;
            if (Lista2.Count > 0)
                this.dgTuziteljFiz.DataSource = Lista2;

        }

        private void btnBranitelj_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Za pravnu osobu odaberite YES, a za fizičku NO!", "odabir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OdabirOsobe osoba = new OdabirOsobe("bran", true);
                while (osoba.ShowDialog() != DialogResult.Cancel)
                {
                }
                this.IDtraz = osoba.povratakID;

            }
            else
            {
                OdabirOsobe osoba = new OdabirOsobe("bran", false);
                while (osoba.ShowDialog() != DialogResult.Cancel)
                {
                }
                this.IDtraz = osoba.povratakID;

            }

            //var upit1 = from x in baza.Branitelj
            //            join y in baza.PravnaOsoba on x.IDOsobe equals y.IDOsobe
            //            join z in baza.Optuzenik on x.IDOptuzenika equals z.IDOptuzenika
            //            where x.IDOsobe == this.IDtraz
            //            select new { y.Naziv, y.MB, x.IDOsobe, z.IDOptuzenika };

            //var upit2 = from x in baza.Branitelj
            //            join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
            //            join z in baza.Optuzenik on x.IDOptuzenika equals z.IDOptuzenika
            //            where x.IDOsobe == this.IDtraz
            //            select new { y.Ime, y.Prezime, x.IDOsobe, z.IDOptuzenika };

            var upit1 = from x in baza.Osoba
                        join y in baza.PravnaOsoba on x.IDOsobe equals y.IDOsobe
                        where x.IDOsobe == this.IDtraz
                        select new { y.Naziv, y.MB };

            var upit2 = from x in baza.Osoba
                        join y in baza.FizickaOsoba on x.IDOsobe equals y.IDOsobe
                        where x.IDOsobe == this.IDtraz
                        select new { y.Ime, y.Prezime };


            var Lista1 = upit1.ToList();
            var Lista2 = upit2.ToList();

            if (Lista1.Count > 0)
                this.dgBraniteljPrav.DataSource = Lista1;
            if (Lista2.Count > 0)
                this.dgBraniteljFiz.DataSource = Lista2;


        }

        private int dajMiId() { 
            //spremi proces i daj id
            if(this.IdProcesa!=0){
                return this.IdProcesa;
            }else if (tbKlasa.Text=="" || tbNaziv.Text=="" || tbUrBroj.Text=="" || cbOznaka.Text=="" || cbSud.Text=="")
                {
                    MessageBox.Show("Prvo unesite sve ostalo vezano uz proces.");
                    return 0;
                }
            int max=this.spremanje();
            return (max + 1);
        }

        private void odustani_Click(object sender, EventArgs e)
        {
            //ako je baza mjenjana, tada ukloniti taj proces jer korisnik odustaje
            if (this.mjenjano)
            {
                var remProces = from x in baza.Proces where x.IDProcesa == this.IdProcesa select x;
                baza.Proces.RemoveRange(remProces);
                baza.SaveChanges();
            }
            this.Close();
        }

        private bool validacija() {

            if (tbKlasa.Text == "" || tbNaziv.Text == "" || tbUrBroj.Text == "" || cbSud.Text == "" || cbOznaka.Text=="")
            {
                return false;
            }

            return true;
        }


        /*
         * metoda koja spremi proces bez optuženika i inih ljudi
         * 
         */
        private int spremanje() 
        {
            bazaF.Proces proces = new bazaF.Proces();
            var ima=(from x in baza.Proces select x.IDProcesa);
            int max = 0;
            if (ima.Count()>0)
            {
                max = ima.Max();
            }
            this.IdProcesa = max + 1;
            proces.IDProcesa = this.IdProcesa;

            proces.Broj = Convert.ToInt32(this.tbUrBroj.Text);
            proces.Klasa = this.tbKlasa.Text;
            proces.Naziv = this.tbNaziv.Text;
            proces.Oznaka = this.cbOznaka.Text;

            var sudovi = baza.Sud.Select(x => new { x.Naziv, x.IDSuda });
            var idoviSud = sudovi.Where(x => x.Naziv.Equals(cbSud.Text)).Select(x => new { x.IDSuda }).ToArray();
            int idSud = Convert.ToInt32(idoviSud[0].IDSuda.ToString());
            proces.Sud = idSud;

            baza.Proces.Add(proces);
            baza.SaveChanges();
            return max;
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            //validacija unosa...
            if (!this.validacija())
            {
                MessageBox.Show("Neće moći, ove noći!\nUnesite sve nužne stavke!");
            }
            else if (bra && tuz && ost && naziv && broj && klasa && opt){

                try
                {
                    //spremanje u bazu ako nije već spremljen (pola procesa) proces kroz dajMiId
                    if (!this.mjenjano){
                        int max=spremanje();
                        this.IdProcesa = max + 1;
                    }
                    

                    //tuzitelji
                    foreach (DataGridViewRow row in this.dgTuziteljFiz.Rows)
                    {
                        bazaF.Tuzitelj tuzitelj = new bazaF.Tuzitelj();

                        var ima = (from x in baza.Tuzitelj select x.IDTuzitelja);
                        int maxN = 0;
                        if (ima.Count() > 0)
                        {
                            maxN = ima.Max();
                        }

                        tuzitelj.IDTuzitelja = maxN + 1;
                        tuzitelj.IDOsobe=Convert.ToInt32(row.Cells[2].Value.ToString());
                        tuzitelj.IDProcesa = this.IdProcesa;
                        baza.Tuzitelj.Add(tuzitelj);
                        baza.SaveChanges();
                    }

                    foreach (DataGridViewRow row in this.dgTuziteljPrav.Rows)
                    {
                        bazaF.Tuzitelj tuzitelj = new bazaF.Tuzitelj();

                        var ima = (from x in baza.Tuzitelj select x.IDTuzitelja);
                        int maxN = 0;
                        if (ima.Count() > 0)
                        {
                            maxN = ima.Max();
                        }

                        tuzitelj.IDTuzitelja = maxN + 1;
                        tuzitelj.IDOsobe = Convert.ToInt32(row.Cells[2].Value.ToString());
                        tuzitelj.IDProcesa = this.IdProcesa;
                        baza.Tuzitelj.Add(tuzitelj);
                        baza.SaveChanges();
                    }


                    //branitelji
                    foreach (DataGridViewRow row in this.dgBraniteljFiz.Rows)
                    {
                        bazaF.Branitelj branitelj = new bazaF.Branitelj();

                        var ima = (from x in baza.Branitelj select x.IDBranitelja);
                        int maxN = 0;
                        if (ima.Count() > 0)
                        {
                            maxN = ima.Max();
                        }

                        

                        branitelj.IDBranitelja = maxN + 1;
                        branitelj.IDOsobe = Convert.ToInt32(row.Cells[2].Value.ToString());
                        branitelj.IDOptuzenika = Convert.ToInt32(row.Cells[3].Value.ToString());
                        baza.Branitelj.Add(branitelj);
                        baza.SaveChanges();
                    }

                    foreach (DataGridViewRow row in this.dgBraniteljPrav.Rows)
                    {
                        bazaF.Branitelj branitelj = new bazaF.Branitelj();

                        var ima = (from x in baza.Branitelj select x.IDBranitelja);
                        int maxN = 0;
                        if (ima.Count() > 0)
                        {
                            maxN = ima.Max();
                        }

                        branitelj.IDBranitelja = maxN + 1;
                        branitelj.IDOsobe = Convert.ToInt32(row.Cells[2].Value.ToString());
                        branitelj.IDOptuzenika = Convert.ToInt32(row.Cells[3].Value.ToString());
                        baza.Branitelj.Add(branitelj);
                        baza.SaveChanges();
                    }

                    //oštećenici
                    foreach (DataGridViewRow row in this.dgOsteceniciFiz.Rows)
                    {
                        bazaF.Ostecenik ostecenik = new bazaF.Ostecenik();

                        var ima = (from x in baza.Ostecenik select x.IDOstecenika);
                        int maxN = 0;
                        if (ima.Count() > 0)
                        {
                            maxN = ima.Max();
                        }

                        ostecenik.IDOstecenika = maxN + 1;
                        ostecenik.IDOsobe = Convert.ToInt32(row.Cells[2].Value.ToString());
                        ostecenik.IDProces = this.IdProcesa;
                        baza.Ostecenik.Add(ostecenik);
                        baza.SaveChanges();
                    }
                    foreach (DataGridViewRow row in this.dgOsteceniciPrav.Rows)
                    {
                        bazaF.Ostecenik ostecenik = new bazaF.Ostecenik();

                        var ima = (from x in baza.Ostecenik select x.IDOstecenika);
                        int maxN = 0;
                        if (ima.Count() > 0)
                        {
                            maxN = ima.Max();
                        }

                        ostecenik.IDOstecenika = maxN + 1;
                        ostecenik.IDOsobe = Convert.ToInt32(row.Cells[2].Value.ToString());
                        ostecenik.IDProces = this.IdProcesa;
                        baza.Ostecenik.Add(ostecenik);
                        baza.SaveChanges();
                    }

                    
                    //optuženici

                    foreach (DataGridViewRow row in this.dgOptuzeniciFiz.Rows)
                    {
                        bazaF.Optuzenik optuzenik = new bazaF.Optuzenik();

                        var ima = (from x in baza.Optuzenik select x.IDOptuzenika);
                        int maxN = 0;
                        if (ima.Count() > 0)
                        {
                            maxN = ima.Max();
                        }

                        optuzenik.IDOptuzenika = maxN + 1;
                        optuzenik.IDOsobe = Convert.ToInt32(row.Cells[2].Value.ToString());
                        optuzenik.IDProces = this.IdProcesa;
                        baza.Optuzenik.Add(optuzenik);
                        baza.SaveChanges();
                    }

                    foreach (DataGridViewRow row in this.dgOptuzeniciPrav.Rows)
                    {
                        bazaF.Optuzenik optuzenik = new bazaF.Optuzenik();

                        var ima = (from x in baza.Optuzenik select x.IDOptuzenika);
                        int maxN = 0;
                        if (ima.Count() > 0)
                        {
                            maxN = ima.Max();
                        }

                        optuzenik.IDOptuzenika = maxN + 1;
                        optuzenik.IDOsobe = Convert.ToInt32(row.Cells[2].Value.ToString());
                        optuzenik.IDProces = this.IdProcesa;
                        baza.Optuzenik.Add(optuzenik);
                        baza.SaveChanges();
                    }




                    //svjedoci

                    foreach (DataGridViewRow row in this.dgSvjedoci.Rows)
                    {
                        bazaF.Svjedok svjedok = new bazaF.Svjedok();

                        var ima = (from x in baza.Svjedok select x.IDSvjedoka);
                        int maxN = 0;
                        if (ima.Count() > 0)
                        {
                            maxN = ima.Max();
                        }

                        svjedok.IDSvjedoka = maxN + 1;
                        svjedok.IDOsobe = Convert.ToInt32(row.Cells[2].Value.ToString());
                        svjedok.IDProces = this.IdProcesa;
                        baza.Svjedok.Add(svjedok);
                        baza.SaveChanges();
                    }



                    MessageBox.Show("Uspješno spremljeno!");

                    this.Close();

                }catch(Exception greska){
                    MessageBox.Show("Greška:\n\n" + greska.ToString());                    
                }
            }
        }

        /**
         * Ovdje se zove forma optuznica ako validacija prođe 
         * 
         */
        private void btnOptuznica_Click(object sender, EventArgs e)
        {
            
            for (int i = 1; 1 < dgOptuzeniciFiz.RowCount; i++) {
                optuzenici.Add(dgOptuzeniciFiz[0,i].Value.ToString()+dgOptuzeniciFiz[1,i].Value.ToString());
            }

            if (this.validacija())
            {
                this.mjenjano = true;
                this.IdProcesa = this.dajMiId();
                
                //zove konstruktor od forme optuznica
              //  FormaOptuzba.Optuzba form = new FormaOptuzba.Optuzba(this.IdProcesa, optuzenici);
              //  form.Show();
            }
            else {
                MessageBox.Show("Unesite sve ostalo vezano za proces!");
            }
        }

        //prikaz svih optuznbi spojenih zajedno
        private void lnkOptuznica_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string tuzbeSve = "";

            //ucitaj sve tuzbe za ovaj proces
            var tuzbe = baza.TekstOptuzbe.Select(x => new { x.Tekst, x.IDProcesa });
            var tuzTekst = tuzbe.Where(x => x.IDProcesa.Equals(this.IdProcesa)).Select(x => new { x.Tekst }).ToArray();
            
            //is svake izvadi teks i spoji ih
            for (int i=0;i<tuzTekst.Length;i++)
            {
                tuzbeSve+=tuzTekst[i].Tekst.ToString();
                tuzbeSve += "\n\n************************************************\n\n";
            }

            //prikaži sada to sve
            PrikazOptuznice opt = new PrikazOptuznice(tuzbeSve);
            opt.Show();

        }

        /*
         * 
         * Ovdje se zove forma spis ako prođe validacija
         * 
         */
        private void btnSpis_Click(object sender, EventArgs e)
        {

            if (this.validacija())
            {
                this.mjenjano = true;
                this.IdProcesa = this.dajMiId();

                //zove konstruktor od forme spis
                FormaSpis.UnosUSpis spis = new FormaSpis.UnosUSpis(this.IdProcesa);
                spis.Show();
            }
            else
            {
                MessageBox.Show("Unesite sve vezano za proces!");
            }
        }

        //validacija da je ur. broj zaista broj
        private void provjeriBroj(object sender, EventArgs e)
        {
            int broj;
            if (int.TryParse(this.tbUrBroj.Text, out broj) == false)
            {
                MessageBox.Show("Ur. broj je broj!");
                errorBroj.SetError(tbUrBroj,"ur. broj treba biti broj");
                this.broj = false;
            }
            else {
                errorBroj.Clear();
                this.broj = true;
            }
            if (tbUrBroj.Text == "") {
                errorBroj.SetError(tbUrBroj, "ur. broj nije unešen");
                this.broj = false;
            }

        }

        //briše oštećenike
        private void bthOsvjTO_Click(object sender, EventArgs e)
        {
            
            if (dgOsteceniciFiz.SelectedRows.Count > 0)
            {
                int ostID = Convert.ToInt32(dgOsteceniciFiz.CurrentRow.Cells[2].Value.ToString());
                var ZaBrisanje = baza.Ostecenik.First(x => x.IDOstecenika == ostID);
                if (MessageBox.Show("Jeste li sigurno a želite bespovratno izbrisati oštećenika??", "upozorenje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    baza.Ostecenik.Remove(ZaBrisanje);
                    baza.SaveChanges();
                    MessageBox.Show("Uklonjeno!");
                }
            }
            else if (dgOsteceniciPrav.SelectedRows.Count > 0)
            {
                int ostID = Convert.ToInt32(dgOsteceniciPrav.CurrentRow.Cells[2].Value.ToString());
                var ZaBrisanje = baza.Ostecenik.First(x => x.IDOstecenika == ostID);

                if (MessageBox.Show("Jeste li sigurno a želite bespovratno izbrisati oštećenika??", "upozorenje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    baza.Ostecenik.Remove(ZaBrisanje);
                    baza.SaveChanges();
                    MessageBox.Show("Uklonjeno!");
                }
            }
        }

        //osvježava branitelje i optuženike
        private void btnOsvjBO_Click(object sender, EventArgs e)
        {
            if (dgOptuzeniciFiz.SelectedRows.Count > 0)
            {
                int optID = Convert.ToInt32(dgOptuzeniciFiz.CurrentRow.Cells[2].Value.ToString());
                var ZaBrisanje = baza.Optuzenik.First(x => x.IDOptuzenika == optID);
                if (MessageBox.Show("Jeste li sigurno a želite bespovratno izbrisati optuženika??", "upozorenje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    baza.Optuzenik.Remove(ZaBrisanje);
                    baza.SaveChanges();
                    MessageBox.Show("Uklonjeno!");
                }
            }
            else if (dgOsteceniciPrav.SelectedRows.Count > 0)
            {
                int optID = Convert.ToInt32(dgOptuzeniciPrav.CurrentRow.Cells[2].Value.ToString());
                var ZaBrisanje = baza.Optuzenik.First(x => x.IDOptuzenika == optID);

                if (MessageBox.Show("Jeste li sigurno a želite bespovratno izbrisati optuženika??", "upozorenje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    baza.Optuzenik.Remove(ZaBrisanje);
                    baza.SaveChanges();
                    MessageBox.Show("Uklonjeno!");
                }
            }
           
        }

        //osvježava svjedoke
        private void btnOsvjS_Click(object sender, EventArgs e)
        {
            if (dgSvjedoci.SelectedRows.Count > 0)
            {
                int svjID = Convert.ToInt32(dgSvjedoci.CurrentRow.Cells[2].Value.ToString());
                var ZaBrisanje = baza.Svjedok.First(x => x.IDSvjedoka == svjID);
                if (MessageBox.Show("Jeste li sigurno a želite bespovratno izbrisati svjedoka??", "upozorenje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    baza.Svjedok.Remove(ZaBrisanje);
                    baza.SaveChanges();
                    MessageBox.Show("Uklonjeno!");
                }
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.validacija())
            {
                this.mjenjano = true;
                this.IdProcesa = this.dajMiId();

                //zove konstruktor od forme
                FormaPresuda.UnosPresude presuda = new FormaPresuda.UnosPresude(IdProcesa);
                presuda.Show();
            }
            else
            {
                MessageBox.Show("Unesite sve vezano za proces!");
            }
            
        }

        private void tuz_val(object sender, CancelEventArgs e)
        {
            if (dgTuziteljFiz.RowCount > 0 || dgTuziteljPrav.RowCount > 0)
            {
                tuz = true;
                errorTuz.Clear();
            }
            else {
                tuz = false;
                errorTuz.SetError(dgTuziteljFiz,"nema tuzitelja");
            }

            if (dgTuziteljFiz.SelectedRows.Count > 0) {
                dgTuziteljPrav.ClearSelection();
            }
            if (dgTuziteljPrav.SelectedRows.Count > 0)
            {
                dgTuziteljFiz.ClearSelection();
            }

        }

        private void bra_val(object sender, CancelEventArgs e)
        {
            if (dgBraniteljFiz.RowCount > 0 || dgBraniteljPrav.RowCount > 0)
            {
                bra = true;
                errorBranitelj.Clear();
            }
            else
            {
                bra = false;
                errorBranitelj.SetError(dgBraniteljFiz, "nema branitelja");
            }

            if (dgBraniteljFiz.SelectedRows.Count > 0)
            {
                dgBraniteljPrav.ClearSelection();
            }
            if (dgBraniteljPrav.SelectedRows.Count > 0)
            {
                dgBraniteljFiz.ClearSelection();
            }

        }

        private void ost_val(object sender, CancelEventArgs e)
        {
            if (this.dgOsteceniciFiz.RowCount > 0 || dgOsteceniciPrav.RowCount > 0)
            {
                ost = true;
                errorOstecenik.Clear();
            }
            else
            {
                ost= false;
                errorOstecenik.SetError(dgOsteceniciFiz, "nema ostecenika");
            }

            if (dgOsteceniciFiz.SelectedRows.Count > 0)
            {
                dgOsteceniciPrav.ClearSelection();
            }
            if (dgOsteceniciPrav.SelectedRows.Count > 0)
            {
                dgOsteceniciFiz.ClearSelection();
            }

        }

        private void opt_val(object sender, CancelEventArgs e)
        {
            if (this.dgOptuzeniciFiz.RowCount > 0 || dgOptuzeniciPrav.RowCount > 0)
            {
                opt = true;
                this.errorOptuzenik.Clear();
            }
            else
            {
                opt = false;
                errorOptuzenik.SetError(dgOptuzeniciFiz, "nema optuzenika");
            }

            if (dgOptuzeniciFiz.SelectedRows.Count > 0)
            {
                dgOptuzeniciPrav.ClearSelection();
            }
            if (dgOptuzeniciPrav.SelectedRows.Count > 0)
            {
                dgOptuzeniciFiz.ClearSelection();
            }

        }

        private void naziv_val(object sender, CancelEventArgs e)
        {
            if (tbNaziv.Text!="")
            {
                naziv = true;
                this.errorNaziv.Clear();
            }
            else
            {
                naziv = false;
                this.errorNaziv.SetError(tbNaziv, "nema naziva procesa");
            }
        }

        private void klasa_val(object sender, CancelEventArgs e)
        {
            if (tbKlasa.Text != "")
            {
                klasa = true;
                this.errorKlasa.Clear();
            }
            else
            {
                klasa = false;
                this.errorKlasa.SetError(tbKlasa, "nema klase procesa");
            }
        }

        bool tuz, bra, ost, opt, naziv, broj, klasa;

        private void tuzDel_Click(object sender, EventArgs e)
        {
            bazaF.Tuzitelj remTuz = new bazaF.Tuzitelj();

            if (dgTuziteljFiz.SelectedRows.Count > 0) {
               int tuzID=Convert.ToInt32(dgTuziteljFiz.CurrentRow.Cells[2].Value.ToString());
               var ZaBrisanje = baza.Tuzitelj.First(x => x.IDTuzitelja == tuzID);
               if (MessageBox.Show("Jeste li sigurno a želite bespovratno izbrisati tuzitelja??", "upozorenje", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                   baza.Tuzitelj.Remove(ZaBrisanje);
                   baza.SaveChanges();
                   MessageBox.Show("Uklonjeno!");
               }
            }
            else if (dgTuziteljPrav.SelectedRows.Count > 0) {
                int tuzID = Convert.ToInt32(dgTuziteljPrav.CurrentRow.Cells[2].Value.ToString());
                var ZaBrisanje = baza.Tuzitelj.First(x => x.IDTuzitelja == tuzID);

                if (MessageBox.Show("Jeste li sigurno a želite bespovratno izbrisati tuzitelja??", "upozorenje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    baza.Tuzitelj.Remove(ZaBrisanje);
                    baza.SaveChanges();
                    MessageBox.Show("Uklonjeno!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var ZaBrisanje = baza.Proces.First(x => x.IDProcesa == this.IdProcesa);
                if (MessageBox.Show("Jeste li sigurno a želite bespovratno izbrisati cijeli proces??","upozorenje",MessageBoxButtons.YesNo)==DialogResult.Yes){
                    baza.Proces.Remove(ZaBrisanje);
                    baza.SaveChanges();
                    MessageBox.Show("Uklonjeno!");
                    this.Close();
                }
            }
            catch (Exception greska) {
                MessageBox.Show("Greška;\n\n"+greska.ToString());
            }
        }

        private void pretraživanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcesPretrazivanje pretraga = new ProcesPretrazivanje();
            pretraga.Show();
        }

        private void branDel_Click(object sender, EventArgs e)
        {
            if (dgBraniteljFiz.SelectedRows.Count > 0)
            {
                int branID = Convert.ToInt32(dgBraniteljFiz.CurrentRow.Cells[2].Value.ToString());
                var ZaBrisanje = baza.Branitelj.First(x => x.IDBranitelja == branID);
                if (MessageBox.Show("Jeste li sigurno a želite bespovratno izbrisati branitelja??", "upozorenje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    baza.Branitelj.Remove(ZaBrisanje);
                    baza.SaveChanges();
                    MessageBox.Show("Uklonjeno!");
                }
            }
            else if (dgBraniteljPrav.SelectedRows.Count > 0)
            {
                int branID = Convert.ToInt32(dgBraniteljPrav.CurrentRow.Cells[2].Value.ToString());
                var ZaBrisanje = baza.Branitelj.First(x => x.IDBranitelja == branID);

                if (MessageBox.Show("Jeste li sigurno a želite bespovratno izbrisati branitelja??", "upozorenje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    baza.Branitelj.Remove(ZaBrisanje);
                    baza.SaveChanges();
                    MessageBox.Show("Uklonjeno!");
                }
            }
        }

    }
}
