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

namespace FormaSpis
{
    public partial class UnosUSpis : Form
    {
        bazaF.RPPP10 baza;
        int IDSpisa = 0;
        int IDProcesa = 1;
        bool izmjena=true;
        byte[] PodaciDatoteke = null;

        public UnosUSpis()
        {
            InitializeComponent();
            tbDatum.Text = Convert.ToString(DateTime.Now);
            cbVrstaStavke.SelectedIndex =0;
            SpisLoad();
            bindingNavigatorAddNewItem.Enabled = true;

        }

        public UnosUSpis(int idProcesa)
        {
            IDProcesa = idProcesa;
            InitializeComponent();
            tbDatum.Text = Convert.ToString(DateTime.Now);
            cbVrstaStavke.SelectedIndex = 0;
            SpisLoad();
            bindingNavigatorAddNewItem.Enabled = true;
        }
        
        public void SpisLoad(){
            LoadDataSort();
            FillCombos();

            using (baza = new bazaF.RPPP10())
            {
                tbNaziv.Text = "";
                tbDatum.Text = Convert.ToString(DateTime.Now);

                var upit2 =
                    from item in baza.Proces
                    where item.IDProcesa == IDProcesa
                    select new { item.Naziv };

                var upit1 = baza.Proces.Select(x => new { x.Naziv, x.IDProcesa});
                var proces = upit1.ToList();

                cbProces.Items.Clear();
                // combobox sa nazivom procesa:
                foreach (var elem in proces)
                {
                    cbProces.Items.Add(elem.IDProcesa + " " + elem.Naziv);
                }

                foreach (var elem in upit2)
                {
                    cbProces.Text = IDProcesa+" "+ elem.Naziv;
                }

                cbVrstaStavke.Items.Clear();
                cbVrstaStavke.Items.Add(" - Odaberite - ");
                cbVrstaStavke.Text = " - Odaberite - ";

                // combobox sa vrstom spisa:
                var upit3 =
                    from item in baza.VrstaSpisa
                    select new { item.NazivVrste };

                foreach (var elem in upit3)
                {
                    cbVrstaStavke.Items.Add(elem.NazivVrste);
                }

                var upit = baza.StavkaSpisa.Select(x => new { x.IDStavke, x.NazivStavke, x.VrstaSpisa1.NazivVrste, x.Proces.Naziv });
                var Lista = upit.ToList();
                BindingSource Spisi = new BindingSource();
                Spisi.DataSource = Lista;
                bindingSourceSpis.DataSource = Spisi;
                bindingNavigatorSpis.BindingSource = Spisi;

                dataGridSpis.DataSource = null;
                dataGridSpis.DataSource = Spisi;

                dataGridSpis.Columns[0].Visible = false;
                dataGridSpis.Columns[1].HeaderText = "Naziv";
                dataGridSpis.Columns[2].HeaderText = "Vrsta spisa";
                dataGridSpis.Columns[3].HeaderText = "Proces";

                panelSpis.Enabled = false;

            }

        }

        private void dataGridSpis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            openToolStripButton.Enabled = true;
            refresh();
        }

        private void refresh()
        {
            int index = dataGridSpis.CurrentRow.Index;
            dataGridSpis.Rows[index].Selected = true;

            int ID = Convert.ToInt32(dataGridSpis[0, index].Value);
            Spis(ID);
        }

        private void Spis(int id)
        {
            IDSpisa = id;
            using (bazaF.RPPP10 baza = new bazaF.RPPP10())
            {
                var upit =
                    from item in baza.StavkaSpisa
                    where item.IDStavke == IDSpisa
                    select new { item };

                foreach (var elem in upit)
                {
                    tbNaziv.Text = elem.item.NazivStavke;
                    cbProces.Text = elem.item.IDProcesa + " " +elem.item.Proces.Naziv;
                    tbDatum.Text = Convert.ToString(elem.item.DatumUnosa);

                    var upit1 =
                       from item in baza.VrstaSpisa
                       where item.SifraVrste==elem.item.VrstaSpisa
                       select new { item.NazivVrste };
                    foreach (var item in upit1)
                    {
                        cbVrstaStavke.Text = item.NazivVrste;
                    }
                }
            }
        }




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void defaultTSMIPretrazivanjePresude_Click(object sender, EventArgs e)
        {

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
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            izmjena = false;
            panelSpis.Enabled = true;
            bindingNavigatorElementiOff();
            tbDatum.Enabled = false;
            cbProces.Enabled = false;

            dataGridSpis.Enabled = false;
            //Spis();
            tbNaziv.Text = "";
            tbDatum.Text = Convert.ToString(DateTime.Now);

            using (baza = new bazaF.RPPP10())
            {
                var upit= from item in baza.Proces
                    where item.IDProcesa == IDProcesa
                    select new { item };

                foreach (var elem in upit)
                {
                    cbProces.Text = elem.item.Naziv;
                }
            }
           
            
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            gbFilter.Enabled = false;
            gbSort.Enabled = false;
            btnSort.Enabled = false;
            izmjena = true;
            bindingNavigatorElementiOff();
            panelSpis.Enabled = true;
            dataGridSpis.Enabled = false;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
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

        private bool IspravnostSvega()
        {
            return true;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
             if (IspravnostSvega())
            {

                bazaF.RPPP10 baza = new bazaF.RPPP10();
                bazaF.StavkaSpisa stavka = new bazaF.StavkaSpisa();

                if (!izmjena)
                {

                    try
                    {
                        int max = (from x in baza.StavkaSpisa select x.IDStavke).Max();
                        stavka.IDStavke = max + 1;
                    }
                    catch (Exception ee)
                    {
                        stavka.IDStavke= 1;
                    }
                }
                else
                {
                    stavka = baza.StavkaSpisa.First((i => i.IDStavke == IDSpisa));
                }

                stavka.NazivStavke= tbNaziv.Text;
                
                var upit= from item in baza.VrstaSpisa
                    where item.NazivVrste==cbVrstaStavke.Text
                    select new { item.SifraVrste };

                foreach (var elem in upit)
                {
                    stavka.VrstaSpisa=elem.SifraVrste;
                }
                
                bool DodanNovi = false;
                if (!izmjena)
                {
                    try
                    {
                        baza.StavkaSpisa.Add(stavka);
                        DodanNovi = true;
                        izmjena = false;
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Dogodila se greška prilikom unosa!!!");
                    }
                }

                try
                {
                    baza.SaveChanges();
                    if (DodanNovi)
                        MessageBox.Show("Spis uspješno pohranjen!");
                    else
                        MessageBox.Show("Spis uspješno izmijenjen!");
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

            SpisLoad();
            bindingNavigatorElementiOn();
            dataGridSpis.Enabled = true;
            panelSpis.Enabled = false;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            using (baza = new bazaF.RPPP10())
            {

                if (bindingNavigatorAddNewItem.Enabled == false)
                {
                    Cancel();
                    refresh();
                    bindingNavigatorElementiOn();
                    panelSpis.Enabled = false;
                    dataGridSpis.Enabled = true;
                    gbFilter.Enabled = true;
                    gbSort.Enabled = true;
                    btnSort.Enabled = true;
                }
                else
                {
                    int red = dataGridSpis.CurrentRow.Index;
                    int ID = Convert.ToInt32(dataGridSpis[0, red].Value);
                    string naziv = dataGridSpis[1, red].Value.ToString();
                    if (MessageBox.Show("Želite li trajno obrisati " + naziv + " ?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        //var elem = from x in baza.Proces where x.StavkaSpisa == ID select x;

                        //foreach (var item in elem)
                        //{
                        //    var nadr = (from y in context.Sud where y.Kategorija == item.Kategorija select y).First();
                        //    item.Nadredeni = nadr.Nadredeni;
                        //}

                        var upit = from x in baza.StavkaSpisa where x.IDStavke == ID select x;
                        baza.StavkaSpisa.RemoveRange(upit);

                        try
                        {
                            baza.SaveChanges();
                            MessageBox.Show("Stavka je uspiješno obrisana!");
                        }
                        catch (Exception iznimka)
                        {
                            MessageBox.Show(iznimka.Message, "Žao nam je, no došlo je do pogreške.");
                        }

                        var query = baza.StavkaSpisa.Include(o => o.Proces).AsNoTracking();
                        bindingSourceSpis.DataSource = query.ToList();
                        SpisLoad();
                    }
                }
            }
        }

        private void Cancel()
        {
            bindingSourceSpis.CancelEdit();

            CancelAllChanges();

            //ResetCurrentItem potreban jer entiteti ne implementiraju INotifyPropertyChanged
            bindingSourceSpis.ResetCurrentItem();

            //UpdateDisplay(false);
        }

        private void CancelAllChanges()
        {
            foreach (var entry in baza.ChangeTracker.Entries())
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
            Naziv, Datum, Proces, Vrsta

        }


        private void FillCombos()
        {
            List<KeyValuePair<string, Stupac>> list = new List<KeyValuePair<string, Stupac>>{
				new KeyValuePair<string, Stupac>("Naziv", Stupac.Naziv),
				//new KeyValuePair<string, Stupac>("Datum", Stupac.Datum),
				new KeyValuePair<string, Stupac>("Proces", Stupac.Proces),
				new KeyValuePair<string, Stupac>("Vrsta", Stupac.Vrsta),
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
            using (baza = new bazaF.RPPP10())
            {
                var query = baza.StavkaSpisa.AsNoTracking();
                bindingSourceSpis.DataSource = query.ToList();
            }
        }

        private void Razvrstaj( BindingSource Spisi)
        {
            bindingSourceSpis.DataSource = Spisi;
            bindingNavigatorSpis.BindingSource = Spisi;

            dataGridSpis.DataSource = null;
            dataGridSpis.DataSource = Spisi;

            dataGridSpis.Columns[0].Visible = false;
            dataGridSpis.Columns[1].HeaderText = "Naziv";
            dataGridSpis.Columns[2].HeaderText = "Vrsta spisa";
            dataGridSpis.Columns[3].HeaderText = "Proces";
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            using (baza = new bazaF.RPPP10())
            {
                if (cbSort1.Text == "Naziv")
                {
                    if (cbSort11.Text == "Uzlazno")
                    {
                        var upit = baza.StavkaSpisa.Select(x => new { x.IDStavke, x.NazivStavke, x.VrstaSpisa1.NazivVrste, x.Proces.Naziv }).OrderBy(x => x.NazivStavke);
                        var Lista = upit.ToList();
                        BindingSource Spisi = new BindingSource();
                        Spisi.DataSource = Lista;
                        Razvrstaj(Spisi);
                    }
                    else
                    {
                        var upit = baza.StavkaSpisa.Select(x => new { x.IDStavke, x.NazivStavke, x.VrstaSpisa1.NazivVrste, x.Proces.Naziv }).OrderByDescending(x => x.NazivStavke);
                        var Lista = upit.ToList();
                        BindingSource Spisi = new BindingSource();
                        Spisi.DataSource = Lista;
                        Razvrstaj(Spisi);
                    }

                }
                else if (cbSort1.Text == "Vrsta")
                {
                    if (cbSort11.Text == "Uzlazno")
                    {
                        var upit = baza.StavkaSpisa.Select(x => new { x.IDStavke, x.NazivStavke, x.VrstaSpisa1.NazivVrste, x.Proces.Naziv }).OrderBy(x => x.NazivVrste);
                        var Lista = upit.ToList();
                        BindingSource Spisi = new BindingSource();
                        Spisi.DataSource = Lista;
                        Razvrstaj(Spisi);
                    }
                    else
                    {
                        var upit = baza.StavkaSpisa.Select(x => new { x.IDStavke, x.NazivStavke, x.VrstaSpisa1.NazivVrste, x.Proces.Naziv }).OrderByDescending(x => x.NazivVrste);
                        var Lista = upit.ToList();
                        BindingSource Spisi = new BindingSource();
                        Spisi.DataSource = Lista;
                        Razvrstaj(Spisi);
                    }

                }
                else if (cbSort1.Text == "Proces")
                {
                    if (cbSort11.Text == "Uzlazno")
                    {
                        var upit = baza.StavkaSpisa.Select(x => new { x.IDStavke, x.NazivStavke, x.VrstaSpisa1.NazivVrste, x.Proces.Naziv }).OrderBy(x => x.Naziv);
                        var Lista = upit.ToList();
                        BindingSource Spisi = new BindingSource();
                        Spisi.DataSource = Lista;
                        Razvrstaj(Spisi);
                    }
                    else
                    {
                        var upit = baza.StavkaSpisa.Select(x => new { x.IDStavke, x.NazivStavke, x.VrstaSpisa1.NazivVrste, x.Proces.Naziv }).OrderByDescending(x => x.Naziv);
                        var Lista = upit.ToList();
                        BindingSource Spisi = new BindingSource();
                        Spisi.DataSource = Lista;
                        Razvrstaj(Spisi);
                    }

                }
            }
        }



        private void Trazi(object sender, KeyEventArgs e)
        {
            using (baza = new bazaF.RPPP10())
            {
                if (cbFilter.Text == "Naziv")
                {
                    var upit = baza.StavkaSpisa.Where(x => x.NazivStavke.StartsWith(tbTrazi.Text)).Select(x => new { x.IDStavke, x.NazivStavke, x.VrstaSpisa1.NazivVrste, x.Proces.Naziv });
                    var Lista = upit.ToList();
                    BindingSource Spisi = new BindingSource();
                    Spisi.DataSource = Lista;
                    Razvrstaj(Spisi);
                }
                else if (cbFilter.Text == "Vrsta")
                {
                    var upit = baza.StavkaSpisa.Where(x => x.VrstaSpisa1.NazivVrste.StartsWith(tbTrazi.Text)).Select(x => new { x.IDStavke, x.NazivStavke, x.VrstaSpisa1.NazivVrste, x.Proces.Naziv });
                    var Lista = upit.ToList();
                    BindingSource Spisi = new BindingSource();
                    Spisi.DataSource = Lista;
                    Razvrstaj(Spisi);
                }
                else if (cbFilter.Text == "Proces")
                {
                    var upit = baza.StavkaSpisa.Where(x => x.Proces.Naziv.StartsWith(tbTrazi.Text)).Select(x => new { x.IDStavke, x.NazivStavke, x.VrstaSpisa1.NazivVrste, x.Proces.Naziv });
                    var Lista = upit.ToList();
                    BindingSource Spisi = new BindingSource();
                    Spisi.DataSource = Lista;
                    Razvrstaj(Spisi);
                }
            }
        }

        #endregion
       
    }
}

