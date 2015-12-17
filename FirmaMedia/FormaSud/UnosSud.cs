using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace FormaSud
{
    public partial class UnosSud : Form
    {
        bool IspravanostAdrese, IspravanostNaziva, IspravanostKategorije, IspravanostNadredenog, IspravnostMjesta, IspravanostPbr;
        Font defaultFont;
        Color defaultColor;
        public int IDsuda = 0;
        bool izmjena = false;
        bazaF.RPPP10 context;

        #region inicijalizacija
        public UnosSud()
        {
            InitializeComponent();
            defaultFont = this.Font;
            defaultColor = this.BackColor;
            
            bazaF.RPPP10 baza = new bazaF.RPPP10();

            var upit = baza.KategorijaSuda.Select(x => new { x.NazivKatSuda });
            var kategorija = upit.ToList();
            cbKategorija.Items.Add(" - Odaberite - ");

            foreach (var elem in kategorija)
            {
                cbKategorija.Items.Add(elem.NazivKatSuda);
            }
            cbKategorija.SelectedIndex = 0;

            cbNadredeni.Items.Add(" - Odaberite - ");
            cbNadredeni.SelectedIndex = 0;

            cbPbr.Items.Add(" - Odaberite - ");
            cbPbr.SelectedIndex = 0;

            baza.Dispose();

        }

        public UnosSud(int id)
        {
            InitializeComponent();
            
            IDsuda = id;

            bazaF.RPPP10 baza = new bazaF.RPPP10();

            //************popunjavanje kategorije********
            var upit3 = baza.KategorijaSuda.Select(x => new { x.NazivKatSuda });
            var kategorija3 = upit3.ToList();

            foreach (var elem in kategorija3)
            {
                cbKategorija.Items.Add(elem.NazivKatSuda);
            }

            //************popunjavanje podacima ******

            var upit2 =
                from item in baza.Sud
                where item.IDSuda == IDsuda
                select new { item };

            foreach (var element in upit2)
            {
                tbNaziv.Text = element.item.Naziv;
                IspravanostNaziva = true;

                tbAdresa.Text = element.item.UlicaIKucniBr;
                IspravanostAdrese = true;

                tbMjesto.Text = element.item.Mjesto.Naziv;
                IspravnostMjesta = true;

                cbKategorija.Text = element.item.KategorijaSuda.NazivKatSuda.ToString();
                IspravanostKategorije = true;
            }

            ///*********popunjavanje pbr***********
            var upit = baza.Mjesto.Where(x => x.Naziv.Contains(tbMjesto.Text)).Select(x => new { x.PBr, x.Naziv });
            var pbr = upit.ToList();

            cbPbr.Items.Clear();
            foreach (var elem in pbr)
            {
                cbPbr.Items.Add(elem.PBr + " " + elem.Naziv);
            }
            
            
            //***********popunjavanje nadređenog**********
            IspravanostKategorije = true;
            NapuniNadredenog();

            //Convert.ToInt32(kat1[0].IDSuda); 

            foreach (var element in upit2)
            {
                string s = element.item.PBr.ToString()+" " + element.item.Mjesto.Naziv.ToString();
                cbPbr.Text = (s);
                IspravanostPbr = true;
                
                //ID nadređenog
                //int br = Convert.ToInt32(element.item.Nadredeni);


                //var upit4 =
                //       from item in baza.Sud
                //       where item.IDSuda == br
                //       select new { item };

                //var kategorija4 = upit4.ToList();
                // if (kategorija4.Count() != 0)
                //{
                //    cbNadredeni.Text = kategorija4[0].item.Naziv.ToString();
                //    IspravanostNadredenog = true;
                //    cbNadredeni.Items.Remove(" - Odaberite - ");
                //}
                //else
                //{
                //    cbNadredeni.Text = "";
                //    IspravanostNadredenog = true;
                //}
            }


            baza.Dispose();

        }
        #endregion
        
        private void Form1_Load(object sender, EventArgs e)
        {
            DisableControls(this);
            LoadData();

            LoadDataSort();
            FillCombos();
            Func<bazaF.Sud, string, bool> filterNazivSuda =
                (sud, naziv) => sud.Naziv == naziv;
        }
        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            context.Dispose();
        }

        private void LoadData()
        {
            if (context != null)
            {
                context.Dispose();
            }
            context = new bazaF.RPPP10();
            var upit = context.Sud.OrderBy(d => d.Naziv);
            upit.Load();
            bindingSourceSud.DataSource = context.Sud.Local.ToBindingList();
            dataGridSud.Columns[1].Width = 200;
            dataGridSud.Columns[2].Width = 200;
        }
        
        private void DisableControls(Control con)
        {
            panelUnos.Enabled = false;
        }
        
        private void refresh()
        {
            int index = dataGridSud.CurrentRow.Index;
            dataGridSud.Rows[index].Selected = true;

            int ID = Convert.ToInt32(dataGridSud[0, index].Value);
            UnosSuda(ID);
        }

        private void dataGridSud_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            refresh(); 
        }

        #region validacija
        //*****************************  VALIDACIJA  ***************************** //
        // Adresa
        private void tbAdresa_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravanostAdrese = IspravnaAdresa((TextBox)sender);
        }
        private bool IspravnaAdresa(TextBox tb)
        {
            bool Ispravno = true;
            for (int i = 0; i < tb.Text.Length; i++)
            {
                if (!(Char.IsLetter(tb.Text[i])) && !(Char.IsNumber(tb.Text[i])) && !(Char.IsWhiteSpace(tb.Text[i])))
                {
                    epAdresa.SetError(tb, "Uneseni su neodgovarajući znakovi.");
                    Ispravno = false;
                    break;
                }
            }
            if (tbAdresa.Text.Length == 0)
            {
                epAdresa.SetError(tb, "Unos mjesta je obavezan.");
                Ispravno = false;
            }
            if (Ispravno) epAdresa.SetError(tb, "");
            return Ispravno;
        }

        // Naziv
        public void tbNaziv_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravanostNaziva = IspravanNaziv((TextBox)sender);
        }

        private bool IspravanNaziv(TextBox tb)
        {

            bool Ispravno = true;
            bool okej = true;
            for (int i = 0; i < tb.Text.Length; i++)
            {
                if (!(Char.IsLetter(tb.Text[i])) && !(Char.IsWhiteSpace(tb.Text[i])))
                {
                    if (tb.Text[i] != '(' && tb.Text[i] != ')')
                    {
                        epPbrMjesto.SetError(tb, "Uneseni su neodgovarajući znakovi.");
                        Ispravno = false;
                        break;
                    }
                    else
                    {
                        okej = true;
                    }
                }
                if (okej) Ispravno = true;
            }
            if (tbNaziv.Text.Length == 0)
            {
                epNaziv.SetError(tb, "Unos naziva je obavezan.");
                Ispravno = false;
            }
            if (Ispravno) epNaziv.SetError(tb, "");
            return Ispravno;

            //bool Ispravno = true;
            //for (int i = 0; i < tb.Text.Length; i++)
            //{
            //    if ((Char.IsLetter(tb.Text[i])) && !(Char.IsWhiteSpace(tb.Text[i])))
            //    {
            //        epNaziv.SetError(tb, "Uneseni su neodgovarajući znakovi.");
            //        Ispravno = false;
            //        break;
            //    }
            //}
            //if (tbNaziv.Text.Length == 0)
            //{
            //    epNaziv.SetError(tb, "Unos mjesta je obavezan.");
            //    Ispravno = false;
            //}
            //if (Ispravno) epNaziv.SetError(tb, "");
            //return Ispravno;

        }

        // Nadređeni
        public void tbNadredeni_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravanostNadredenog = IspravanNadredeni((ComboBox)sender);
        }

        private bool IspravanNadredeni(ComboBox cb)
        {
            if (cb.SelectedItem == " - Odaberite - ")
            {
                epNadredeni.SetError(cb, "Odabir nadređenog je obavezan.");
                return false;
            }
            else
            {
                epNadredeni.SetError(cb, "");
                return true;
            }
        }

        // Kategorija
        private void cbKategorija_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravanostKategorije = IspravnaKategorija((ComboBox)sender);
            if (IspravanostKategorije)
            {
                NapuniNadredenog();
            }
            else
            {
                //const string poruka = "Obavezno je prvo ispuniti sve potrebne podatke (mjesto, pbr i kategoriju.";
                //const string caption = "Ups!";
                //var odluka = MessageBox.Show(poruka, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool IspravnaKategorija(ComboBox cb)
        {
            if (cb.SelectedItem == " - Odaberite - ")
            {
                epKategorija.SetError(cbKategorija, "Unesite ispravnu kategoriju.");
                return false;
            }
            else
            {
                epKategorija.SetError(cb, "");
                return true;
            }
        }

        // Mjesto
        public void tbMjesto_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostMjesta = IspravnoMjesto((TextBox)sender);
            if (IspravnostMjesta)
            {
                bazaF.RPPP10 baza = new bazaF.RPPP10();
                var upit = baza.Mjesto.Where(x => x.Naziv.Contains(tbMjesto.Text)).Select(x => new { x.PBr, x.Naziv });
                var pbr = upit.ToList();

                cbPbr.Items.Clear();
                foreach (var elem in pbr)
                {
                    cbPbr.Items.Add(elem.PBr + " " + elem.Naziv);
                }

                baza.Dispose();
            }
        }

        private bool IspravnoMjesto(TextBox tb)
        {
            bool Ispravno = true;
            bool okej = true;
            for (int i = 0; i < tb.Text.Length; i++)
            {
                if (!(Char.IsLetter(tb.Text[i])) && !(Char.IsWhiteSpace(tb.Text[i])))
                {
                    if (tb.Text[i] != '-')
                    {
                        epPbrMjesto.SetError(tb, "Uneseni su neodgovarajući znakovi.");
                        Ispravno = false;
                        break;
                    }
                    else
                    {
                        okej = true;
                    }  
                }
                if (okej) Ispravno = true;
            }
            if (tbMjesto.Text.Length == 0)
            {
                epPbrMjesto.SetError(tb, "Unos mjesta je obavezan.");
                Ispravno = false;
            }
            if (Ispravno) epPbrMjesto.SetError(tb, "");
            return Ispravno;
        }

        // PBr
        private void cbPbr_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravanostPbr = IspravnostPbr((ComboBox)sender);

            if (IspravanostPbr)
            {
                //string[] pbr = new string[2];
                //pbr = cbPbr.Text.Split(' ');
                //string mjesto = Convert.ToString(pbr[1]);
                //cbPbr.Text = mjesto;
            }

            //if (mjesto == tbMjesto.Text) IspravanostPbr = true;
            //else IspravanostPbr = false;
           
        }

        private bool IspravnostPbr(ComboBox cb)
        {
            if (cb.Text == " - Odaberite - ") 
            {
                epPbrMjesto.SetError(tbMjesto, "Unesite ispravan pbr.");
                return false;
            }
            else if(cb.Text=="")
            {
                epPbrMjesto.SetError(tbMjesto, "Unesite ispravan pbr.");
                return false;
            }
            else
            {
                epPbrMjesto.SetError(cb, "");
                return true;
            }
        }

        // *********************************************************************//

        #endregion

        private void cbPbr_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string pbr_mjesto = cbPbr.Text;
            int index = pbr_mjesto.IndexOf(' ');
            string pbr = pbr_mjesto.Substring(0, index);
            int len=pbr_mjesto.Length;
            string mjesto = pbr_mjesto.Substring(index+1, len-6);
            tbMjesto.Text = mjesto;
        }

        private bool IspravnostSvega()
        {

            if (!IspravanostNaziva)
                IspravanostNaziva=IspravanNaziv(tbNaziv);
            if (!IspravanostAdrese)
                IspravanostAdrese=IspravnaAdresa(tbAdresa);
            if (!IspravanostKategorije)
                IspravanostKategorije=IspravnaKategorija(cbKategorija);
            if (!IspravanostNadredenog)
                IspravanostNadredenog=IspravanNadredeni(cbNadredeni);
            if (!IspravnostMjesta)
                IspravnostMjesta=IspravnoMjesto(tbMjesto);
            if (!IspravanostPbr)
                IspravanostPbr=IspravnostPbr(cbPbr);

            if (IspravanostAdrese && IspravanostNaziva && IspravanostKategorije && IspravanostNadredenog && IspravnostMjesta && IspravanostPbr)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #region Nadređeni
        private void NapuniNadredenog()
        {
            if (IspravanostKategorije)
            {
                IspravanostNadredenog = false;
                cbNadredeni.Items.Clear();
                cbNadredeni.Items.Add(" - Odaberite - ");
                cbNadredeni.SelectedIndex = 0;

                if (cbKategorija.Text == "Vrhovni sud Republike Hrvatske")
                {
                    cbNadredeni.Items.Clear();
                    cbNadredeni.Items.Add(" ");
                    cbNadredeni.SelectedIndex = 0;
                }
                else if (cbKategorija.Text == "Općinski sud")
                {
                    DodajUNadredene(2);
                }
                else if (cbKategorija.Text == "Županijski sud")
                {
                    DodajUNadredene(1);
                }
                else if (cbKategorija.Text == "Upravni sud")
                {
                    //cbNadredeni.Items.Add("Visoki upravni sud Republike Hrvatske");
                    DodajUNadredene(9);

                }
                else if (cbKategorija.Text == "Prekršajni sud")
                {
                    //cbNadredeni.Items.Add("Visoki prekršajni sud Republike Hrvatske");
                    DodajUNadredene(7);
                }
                else if (cbKategorija.Text == "Trgovački sud")
                {
                    //cbNadredeni.Items.Add("Visoki trgovački sud Republike Hrvatske");
                    DodajUNadredene(8);

                }
                else if (cbKategorija.Text == "Visoki prekršajni sud Republike Hrvatske")
                {
                    DodajUNadredene(1);
                }
                else if (cbKategorija.Text == "Visoki trgovački sud Republike Hrvatske")
                {
                    //cbNadredeni.Items.Add("Visoki trgovački sud Republike Hrvatske");
                     DodajUNadredene(1);

                }
                else if (cbKategorija.Text == "Visoki upravni sud Republike Hrvatske")
                {
                    //cbNadredeni.Items.Add("Visoki trgovački sud Republike Hrvatske");
                    DodajUNadredene(1);

                }
            }
        }

        private void DodajUNadredene(int i){
                    bazaF.RPPP10 baza = new bazaF.RPPP10();

                    var upit =
                       from item in baza.Sud
                       where item.KategorijaSuda.SifraKatSuda==i
                       select new { item.Naziv };

                    var kategorija = upit.ToList();
                    
                    if (!(cbNadredeni.Items.Contains(" - Odaberite - ")))
                        cbNadredeni.Items.Add(" - Odaberite - ");

                    foreach (var elem in kategorija)
                    {
                        cbNadredeni.Items.Add(elem.Naziv);
                    }
                    cbNadredeni.SelectedIndex = 0;

    }

        #endregion

        #region Slucajno dodane reference
        private void defaultToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void promjeniPozadinuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void promjeniFontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region fontovi i pozadina
        // fontovi i pozadina
        private void defaultToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Font = defaultFont;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            menuStripSud.Font = defaultFont;
            menuStripSud.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void promijeniFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialogSud.ShowColor = true;

            if (fontDialogSud.ShowDialog() != DialogResult.Cancel)
            {
                this.Font = fontDialogSud.Font;
                this.ForeColor = fontDialogSud.Color;
                menuStripSud.Font = fontDialogSud.Font;
                menuStripSud.ForeColor = fontDialogSud.Color;
            }
        }


        private void defaultToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.BackColor = defaultColor;
            menuStripSud.BackColor = defaultColor;
        }

        private void promijeniPozadinuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialogSud.ShowDialog() != DialogResult.Cancel)
            {
                this.BackColor = colorDialogSud.Color;
                menuStripSud.BackColor = colorDialogSud.Color;
            }
        }

        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region Binding Navigator buttoni

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            //int currentRow = dataGridSud.CurrentRow.Index;
            //if (currentRow == dataGridSud.RowCount)
            //{
            //    dataGridSud.Rows[0].Cells[0].Selected = true;
            //}
            //else
            //{
            //    dataGridSud.Rows[currentRow+1].Cells[0].Selected = true;
            //}

            //if (bindingSourceSud.Position != bindingSourceSud.Count - 1)
            //{
            //    ++bindingSourceSud.Position;
            //}
            refresh();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (bindingNavigatorAddNewItem.Enabled == false)
            {
                //UnosSuda();
                Cancel();
                refresh();
                bindingNavigatorElementiOn();
                panelUnos.Enabled = false;
                dataGridSud.Enabled = true;
            }
            else
            {
                    int red = dataGridSud.CurrentRow.Index;
                    int ID = Convert.ToInt32(dataGridSud[0, red].Value);
                    string naziv = dataGridSud[1, red].Value.ToString();
                    if (MessageBox.Show("Želite li trajno obrisati " + naziv + " ?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        //var elem = from x in context.Sud where x.Nadredeni == ID select x;

                        //foreach (var item in elem)
                        //{
                        //    var nadr = (from y in context.Sud where y.Kategorija == item.Kategorija select  y).First();
                        //    item.Nadredeni = nadr.Nadredeni;
                        //}

                        var upit = from x in context.Sud where x.IDSuda == ID select x;
                        context.Sud.RemoveRange(upit);

                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Sud uspiješno obrisan!");
                        }
                        catch (Exception iznimka)
                        {
                            MessageBox.Show(iznimka.Message, "Žao nam je, no došlo je do pogreške.");
                        }

                        var query = context.Sud.Include(o => o.Proces).AsNoTracking();
                        bindingSourceSud.DataSource = query.ToList();
                        //refresh();
            }
		  }           
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            izmjena = false;
            panelUnos.Enabled = true;
            bindingNavigatorElementiOff();
            dataGridSud.Enabled = false;
            UnosSuda();
            tbNaziv.Text = "";
            tbAdresa.Text = "";
            tbMjesto.Text = "";

        }

        private void bindingNavigatorElementiOff()
        {
            bindingNavigatorMoveFirstItem.Enabled = false;
            bindingNavigatorMovePreviousItem.Enabled = false;
            bindingNavigatorPositionItem.Enabled = false;
            bindingNavigatorMoveNextItem.Enabled = false;
            bindingNavigatorMoveLastItem.Enabled = false;
            openToolStripButton.Enabled = false;
            bindingNavigatorAddNewItem.Enabled = false;
            saveToolStripButton.Enabled = true;
            btnSort.Enabled = false;
            gbFilter.Enabled = false;
            gbSort.Enabled = false;
        }

        private void bindingNavigatorElementiOn()
        {
            bindingNavigatorMoveFirstItem.Enabled = true;
            bindingNavigatorMovePreviousItem.Enabled = true;
            bindingNavigatorPositionItem.Enabled = true;
            bindingNavigatorMoveNextItem.Enabled = true;
            bindingNavigatorMoveLastItem.Enabled = true;
            openToolStripButton.Enabled = true;
            bindingNavigatorAddNewItem.Enabled = true;
            saveToolStripButton.Enabled = false;
            btnSort.Enabled = true;
            gbFilter.Enabled = true;
            gbSort.Enabled = true;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (IspravnostSvega())
            {

                bazaF.RPPP10 baza = new bazaF.RPPP10();
                bazaF.Sud sud = new bazaF.Sud();

                if (!izmjena)
                {

                    try
                    {
                        int max = (from x in baza.Sud select x.IDSuda).Max();
                        sud.IDSuda = max + 1;
                    }
                    catch
                    {
                        sud.IDSuda = 1;
                    }
                }
                else
                {
                    sud = baza.Sud.First((i => i.IDSuda == IDsuda));
                }

                sud.Naziv = tbNaziv.Text;
                sud.UlicaIKucniBr = tbAdresa.Text;
                //sud.Mjesto = tbMjesto.Text;

                //ne odvaja ispravno ime mjesta i pbr ali ovdje ionako nije bitno kad se samo pbr vadi
                string[] pbr = new string[2];
                pbr = cbPbr.Text.Split(' ');
                sud.PBr = Convert.ToInt32(pbr[0]);

                var upit = baza.KategorijaSuda.Where(x => x.NazivKatSuda.Contains(cbKategorija.Text)).Select(x => new
                {
                    x.SifraKatSuda,
                    x.NazivKatSuda
                });
                var kat = upit.ToList();

                sud.Kategorija = Convert.ToInt32(kat[0].SifraKatSuda);

                //var upit1 =
                //       from item in baza.Sud
                //       where item.Naziv == cbNadredeni.Text
                //       select new { item.IDSuda };

                //var kat1 = upit1.ToList();

                //if (kat1.Count() != 0)
                //{
                //    sud.Nadredeni = Convert.ToInt32(kat1[0].IDSuda);
                //}
                //else
                //{
                //    sud.Nadredeni = null;
                //}


                bool DodanNovi = false;
                if (!izmjena)
                {
                    try
                    {
                        baza.Sud.Add(sud);
                        DodanNovi = true;
                        izmjena = false;
                    }
                    catch
                    {
                        MessageBox.Show("Dogodila se greška prilikom unosa!!!");
                    }
                }

                try
                {
                    baza.SaveChanges();
                    if (DodanNovi)
                        MessageBox.Show("Sud uspješno pohranjen!");
                    else
                        MessageBox.Show("Sud uspješno izmijenjen!");
                    baza.Dispose();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Dogodila se greška prilikom unosa!!!");
                    MessageBox.Show(error.ToString());
                }
                baza.Dispose();
            }
            else
            {
                const string poruka = "Podaci su neispravno uneseni. Molimo Vas da ih ispravite prije pohrane.";
                const string caption = "Ups!";
                var odluka = MessageBox.Show(poruka, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            LoadData();
            bindingNavigatorElementiOn();
            dataGridSud.Enabled = true;
            panelUnos.Enabled = false;
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            izmjena = true;

            panelUnos.Enabled = true;
            dataGridSud.Enabled = false;

            bindingNavigatorElementiOff();
            int red = dataGridSud.CurrentRow.Index;
            int ID = Convert.ToInt32(dataGridSud[0, red].Value);
            UnosSuda(ID);
        }

        #endregion

        public void UnosSuda(int id)
        {
            IDsuda = id;

            bazaF.RPPP10 baza = new bazaF.RPPP10();

            cbPbr.Items.Clear();
            cbKategorija.Items.Clear();
            cbNadredeni.Items.Clear();

            //************popunjavanje kategorije********
            var upit3 = baza.KategorijaSuda.Select(x => new { x.NazivKatSuda });
            var kategorija3 = upit3.ToList();

            foreach (var elem in kategorija3)
            {
                if (!(cbNadredeni.Items.Contains(elem.NazivKatSuda)))
                    cbKategorija.Items.Add(elem.NazivKatSuda);
            }

            //************popunjavanje podacima ******

            var upit2 =
                from item in baza.Sud
                where item.IDSuda == IDsuda
                select new { item };

            foreach (var element in upit2)
            {
                tbNaziv.Text = element.item.Naziv;
                IspravanostNaziva = true;

                tbAdresa.Text = element.item.UlicaIKucniBr;
                IspravanostAdrese = true;

                tbMjesto.Text = element.item.Mjesto.Naziv;
                IspravnostMjesta = true;

                cbKategorija.Text = element.item.KategorijaSuda.NazivKatSuda.ToString();
                IspravanostKategorije = true;
            }

            ///*********popunjavanje pbr***********
            var upit = baza.Mjesto.Where(x => x.Naziv.Contains(tbMjesto.Text)).Select(x => new { x.PBr, x.Naziv });
            var pbr = upit.ToList();

            cbPbr.Items.Clear();
            foreach (var elem in pbr)
            {
                cbPbr.Items.Add(elem.PBr + " " + elem.Naziv);
            }


            //***********popunjavanje nadređenog**********
            IspravanostKategorije = true;
            NapuniNadredenog();

            //Convert.ToInt32(kat1[0].IDSuda); 

            foreach (var element in upit2)
            {
                string s = element.item.PBr.ToString() + " " + element.item.Mjesto.Naziv.ToString();
                cbPbr.Text = (s);
                IspravanostPbr = true;

                //ID nadređenog
                //int br = Convert.ToInt32(element.item.Nadredeni);


                //var upit4 =
                //       from item in baza.Sud
                //       where item.IDSuda == br
                //       select new { item };

                //var kategorija4 = upit4.ToList();
                //if (kategorija4.Count() != 0)
                //{
                //    cbNadredeni.Text = kategorija4[0].item.Naziv.ToString();
                //    IspravanostNadredenog = true;
                //    cbNadredeni.Items.Remove(" - Odaberite - ");
                //}
                //else
                //{
                //    cbNadredeni.Text = "";
                //    IspravanostNadredenog = true;
                //}
            }


            baza.Dispose();

        }

        public void UnosSuda()
        {
            defaultFont = this.Font;
            defaultColor = this.BackColor;

            bazaF.RPPP10 baza = new bazaF.RPPP10();

            var upit = baza.KategorijaSuda.Select(x => new { x.NazivKatSuda });
            var kategorija = upit.ToList();

            cbPbr.Items.Clear();
            cbKategorija.Items.Clear();
            cbNadredeni.Items.Clear();

            cbKategorija.Items.Add(" - Odaberite - ");

            foreach (var elem in kategorija)
            {
                if (!(cbNadredeni.Items.Contains(elem.NazivKatSuda)))
                    cbKategorija.Items.Add(elem.NazivKatSuda);
            }
            cbKategorija.SelectedIndex = 0;

            cbNadredeni.Items.Add(" - Odaberite - ");
            cbNadredeni.SelectedIndex = 0;

            cbPbr.Items.Add(" - Odaberite - ");
            cbPbr.SelectedIndex = 0;

            baza.Dispose();

        }


        private void Cancel()
        {
            sudBindingSource.CancelEdit();

            CancelAllChanges();

            //ResetCurrentItem potreban jer entiteti ne implementiraju INotifyPropertyChanged
            sudBindingSource.ResetCurrentItem();

            //UpdateDisplay(false);
        }

        private void CancelAllChanges()
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.State = EntityState.Detached;
                }
                else if (entry.State == EntityState.Deleted || entry.State == EntityState.Modified)
                {
                    entry.State = EntityState.Unchanged;
                }
            }
        }
        
         #region Sortiranje i filtriranje

        private class FilterElement
        {
            public string Opis { get; set; }
            public Stupac Naziv { get; set; }
            public string Vrijednost { get; set; }
            public override string ToString()
            {
                return Opis + " : " + Vrijednost;
            }
        }

        private enum Stupac
        {
            //Naziv, UlicaIKucniBr, Pbr, Kategorija, Nadredeni
            Naziv, UlicaIKucniBr, Pbr

        }


        private void FillCombos()
        {
            List<KeyValuePair<string, Stupac>> list = new List<KeyValuePair<string, Stupac>>{
				new KeyValuePair<string, Stupac>("Naziv suda", Stupac.Naziv),
				new KeyValuePair<string, Stupac>("Adresa", Stupac.UlicaIKucniBr),
				new KeyValuePair<string, Stupac>("Poštanski broj", Stupac.Pbr),
			    };
                cbFilter.DisplayMember = "Key";
                cbFilter.ValueMember = "Value";
                cbFilter.DataSource = list;

                for (int i = 1; i <= 3; i++)
                {
                    //za ostale comboboxove koristit ćemo nove liste s početnim praznim elementom
                    var listaSPraznim = new List<KeyValuePair<string, Stupac>>(list);
                    listaSPraznim.Insert(0, new KeyValuePair<string, Stupac>("", Stupac.Naziv));
                    ComboBox combo = gbSort.Controls["cbSort" + i] as ComboBox;
                    if (combo != null)
                    {
                        combo.DisplayMember = "Key";
                        combo.ValueMember = "Value";
                        combo.DataSource = listaSPraznim;
                    }
                    ComboBox comboPoredak = gbSort.Controls["cbSort" + i + i] as ComboBox;
                    if (comboPoredak != null)
                    {
                        comboPoredak.SelectedIndex = 0;
                    }
                }
        }

        private void LoadDataSort()
        {
            context = new bazaF.RPPP10();
            var query = context.Sud.AsNoTracking();
            bindingSourceSud.DataSource = query.ToList();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            var query = context.Sud.Include(o => o.Proces).AsNoTracking();
            query = ApplyFilter(query);
            IOrderedQueryable<bazaF.Sud> sortedQuery = ApplySort(query);
            if (sortedQuery != null)
            {
                bindingSourceSud.DataSource = sortedQuery.ToList();
            }
            else
            {
                bindingSourceSud.DataSource = query.ToList();
            }
		  }

        private IQueryable<bazaF.Sud> ApplyFilter(IQueryable<bazaF.Sud> query)
        {
            string vrijednost = tbTrazi.Text;
            switch (cbFilter.Text)
            {
                case "Poštanski broj":
                    int pbr = int.Parse(vrijednost);
                    query = query.Where(m => m.PBr == pbr);
                    break;
                case "Naziv suda":
                    query = query.Where(m => m.Naziv.Contains(vrijednost));
                    break;
                case "Adresa":
                    query = query.Where(m => m.UlicaIKucniBr.Contains(vrijednost)); //case insensitive ako se radi o sql upitu
                    break;
            }
            return query;
        }

        private IOrderedQueryable<bazaF.Sud> ApplySort(IQueryable<bazaF.Sud> query)
        {
            IOrderedQueryable<bazaF.Sud> sortedQuery = null;
            for (int i = 1; i <= 3; i++)
            {
                ComboBox combo = gbSort.Controls["cbSort" + i] as ComboBox;
                ComboBox comboPoredak = gbSort.Controls["cbSort" + i + i] as ComboBox;
                if (combo.SelectedIndex > 0)
                {
                    Stupac stupac = (Stupac)combo.SelectedValue;
                    bool descending = comboPoredak.SelectedIndex == 1;

                    switch (stupac)
                    {
                        case Stupac.Naziv:
                            if (sortedQuery == null)
                            {
                                if (descending)
                                    sortedQuery = query.OrderByDescending(m => m.Naziv);
                                else
                                    sortedQuery = query.OrderBy(m => m.Naziv);
                            }
                            else
                            {
                                if (descending)
                                    sortedQuery = sortedQuery.ThenByDescending(m => m.Naziv);
                                else
                                    sortedQuery = sortedQuery.ThenBy(m => m.Naziv);
                            }
                            break;
                        case Stupac.Pbr:
                            if (sortedQuery == null)
                            {
                                if (descending)
                                    sortedQuery = query.OrderByDescending(m => m.PBr);
                                else
                                    sortedQuery = query.OrderBy(m => m.PBr);
                            }
                            else
                            {
                                if (descending)
                                    sortedQuery = sortedQuery.ThenByDescending(m => m.PBr);
                                else
                                    sortedQuery = sortedQuery.ThenBy(m => m.PBr);
                            }
                            break;
                        case Stupac.UlicaIKucniBr:
                            if (sortedQuery == null)
                            {
                                if (descending)
                                    sortedQuery = query.OrderByDescending(m => m.UlicaIKucniBr);
                                else
                                    sortedQuery = query.OrderBy(m => m.UlicaIKucniBr);
                            }
                            else
                            {
                                if (descending)
                                    sortedQuery = sortedQuery.ThenByDescending(m => m.UlicaIKucniBr);
                                else
                                    sortedQuery = sortedQuery.ThenBy(m => m.UlicaIKucniBr);
                            }
                            break;
                    }
                }
            }
            return sortedQuery;
        }

        #endregion
        
    }


}
