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
    public partial class Sud : Form
    {
        bazaF.RPPP10 baza;
        bool izmjena = false;
        int IDSuda = 0;
        bool IspravnostNaziva, IspravnostAdrese, IspravnostKategorije;
        public Sud()
        {
            InitializeComponent();
            panelUnos.Enabled = false;
        }

        #region Učitavanje podataka i postavljanje povezivanja

        private void Sud_Load(object sender, EventArgs e)
        {
            LoadDataSources(false);
            UpdateDisplay(false);
            
        }

        private void LoadDataSources(bool display)
        {
            baza = new bazaF.RPPP10();

            

            bindingSourceSud.DataSource = baza.Sud.Include(s=>s.Sudac).AsNoTracking().ToList();

            bindingSourceKategorija.DataSource = baza.KategorijaSuda.AsNoTracking().ToList();
            bindingSourceMjesto.DataSource = baza.Mjesto.AsNoTracking().ToList();
            //bindingSourceSud.DataSource = baza.Sud.AsNoTracking().ToList();
            bindingSourceSudac.DataSource = bindingSourceSud;
           
            bindingSourceSudskoVijece.DataSource = baza.SudskoVijece.AsNoTracking().ToList();

            baza.Sud.Load();
            //bindingSourceSud.DataSource = baza.Sud.Local.ToBindingList();
            dataGridSuci.DataSource = bindingSourceSudac;
            var suci = baza.FizickaOsoba.Where(u=>u.Sudac==true).ToList();

            //var suciList = suci.ToList();
            fizickaOsobaBindingSource.DataSource = suci;

            //var sudac = baza.FizickaOsoba.Where(o => o.Sudac == true).Where(o => o.).ToList();
            var sudac = baza.FizickaOsoba.Where(o => o.Sudac == true).ToList();
            if (!display)
            {
                //fizickaOsobaBindingSource.DataSource = sudac;
                UpdateDisplay(display);
            }


        }
        #endregion

        private void UpdateDisplay(bool editMode)
        {
            bindingNavigatorSud.MoveFirstItem.Enabled = bindingNavigatorSud.MovePreviousItem.Enabled
                                                                                            = bindingNavigatorMoveFirstItem.Enabled
                                                                                            = bindingNavigatorSud.MoveNextItem.Enabled
                                                                                            = bindingNavigatorSud.MoveLastItem.Enabled
                                                                                            = bindingNavigatorSud.PositionItem.Enabled
                                                                                            = bindingNavigatorAddNewItem.Enabled
                                                                                            = bindingNavigatorDeleteItem.Enabled
                                                                                           // = toolStripButtonEdit.Enabled
                                                                                            = !editMode;

            //dataGridSuci.ReadOnly = !editMode;
            //imePrezimeDataGridViewTextBoxColumn.ReadOnly = !editMode;
            saveToolStripButton.Enabled = /*toolStripButtonCancel.Enabled = */panelUnos.Enabled = editMode;

            dataGridSuci.AllowUserToDeleteRows = editMode;
            dataGridSuci.AllowUserToAddRows = editMode;
            dataGridSuci.ReadOnly = !editMode;

        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (bindingNavigatorAddNewItem.Enabled == false)
            {
                Cancel();
                epNaziv.SetError(tbNaziv, "");
                epPbr.SetError(cbPbr, "");
                epAdresa.SetError(tbAdresa, "");
                epKategorija.SetError(cbKategorija, "");
            }
            else
            {
                Delete();
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            izmjena = true;
            tbMjesto.Enabled = false;
            dataGridSuci.Enabled = true;
            dataGridSuci.ReadOnly= false;
            UpdateDisplay(true);
            Open();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (IspravnostSvega())
            {
                Save();
            }
            else
            {
                const string poruka = "Podaci su neispravno uneseni. Molimo Vas da ih ispravite prije pohrane.";
                const string caption = "Ups!";
                var odluka = MessageBox.Show(poruka, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void Open()
        {
            //bindingNavigatorElementiOff();
            UpdateDisplay(true);
            panelUnos.Enabled = true;
            tbID.Enabled = false;
            bindingNavigatorDeleteItem.Enabled = true;
            //var nadredeni = from x in baza.KategorijaSuda
            //                select new { x.NazivKatSuda };
            //foreach (var item in nadredeni){
            //    if (!(cbNadredeni.Items.Contains(item.NazivKatSuda)))
            //        cbKategorija.Items.Add(item.NazivKatSuda);
            //}
            

        }

        private void Save(){

            bazaF.RPPP10 baza = new bazaF.RPPP10();
            bazaF.Sud sud = new bazaF.Sud();

            if (this.ValidateChildren())
            {
                bindingSourceKategorija.EndEdit();
                bindingSourceMjesto.EndEdit();
                bindingSourceSud.EndEdit();
                bindingSourceSudac.EndEdit();
                bindingSourceSudskoVijece.EndEdit();
                

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
                    IDSuda = Convert.ToInt32(tbID.Text);
                    sud = baza.Sud.First((i => i.IDSuda == IDSuda));
                }
                sud.Naziv = tbNaziv.Text;
                sud.UlicaIKucniBr = tbAdresa.Text;
                //sud.Mjesto = tbMjesto.Text;

                ////ne odvaja ispravno ime mjesta i pbr ali ovdje ionako nije bitno kad se samo pbr vadi
                //string[] pbr = new string[2];
                //pbr = cbPbr.Text.Split(' ');
                //sud.PBr = Convert.ToInt32(pbr[0]);

                sud.PBr = Convert.ToInt32(cbPbr.Text);

                var upit = baza.KategorijaSuda.Where(x => x.NazivKatSuda.Contains(cbKategorija.Text)).Select(x => new
                {
                    x.SifraKatSuda,
                    x.NazivKatSuda
                });
                var kat = upit.ToList();

                sud.Kategorija = Convert.ToInt32(kat[0].SifraKatSuda);

                

                bool DodanNovi = false;
                if (!izmjena)
                {
                    try
                    {
                        baza.Sud.Add(sud);
                        DodanNovi = true;
                        izmjena = false;
                        SaveGrid();
                    }
                    catch
                    {
                        MessageBox.Show("Dogodila se greška prilikom unosa!!!");
                    }
                }


                try
                {
                    baza.SaveChanges();
                    SaveGrid();
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

                UpdateDisplay(false);
            }
            else
            {
                MessageBox.Show("Polja nisu popunjena na odgovarajući način!"
                , "Greška"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Information);
            }
        }

        private void SaveGrid()
        {
            //sud pa osoba

            List<bazaF.FizickaOsoba> suci = new List<bazaF.FizickaOsoba>();
            for (int i = 0; i < dataGridSuci.Rows.Count - 1; i++)
            {
                int IDosobe = (int)dataGridSuci[1, i].Value;
                //bazaF.Sudac s = baza.Sudac.Find(IDosobe);
                bazaF.FizickaOsoba s = baza.FizickaOsoba.Find(IDosobe);
                suci.Add(s);
            }


            //foreach(DataGridViewRow row in dataGridSuci.Rows)
            foreach (var s in suci)
            { 
                
                ////int IDsuda = Convert.ToInt32(row.Cells[0].Value);
                //int IDosobe = Convert.ToInt32(row.Cells[1].Value);
                int IDsuda = Convert.ToInt32(tbID.Text);

                bazaF.RPPP10 baza = new bazaF.RPPP10();
                bazaF.Sudac sudac = new bazaF.Sudac();

                //var upit =
                //    (from item in baza.Sudac
                //    where item.IDOsobe==s.IDOsobe
                //    select item);
                bazaF.Sudac upit = null;
                upit = baza.Sudac.Where(u => u.IDOsobe == s.IDOsobe).FirstOrDefault();
           
                
                //var list = upit.ToList();

                int id = s.IDOsobe;
                sudac.IDOsobe = id;
                sudac.IDSuda = IDsuda;

                if (upit == null)
                {
                    try
                    {
                        baza.Sudac.Add(sudac);

                        //foreach (bazaF.FizickaOsoba osoba1 in suciNovi)
                        //{ 
                        //    bazaF.Sudac.
                        //}

                        //SaveGrid();
                    }
                    catch
                    {
                        MessageBox.Show("Dogodila se greška prilikom unosa!!!");
                    }
                }
                

                try
                {
                    bazaF.Sudac sudaccc = baza.Sudac.Where(u => u.IDOsobe == s.IDOsobe).FirstOrDefault();
                    sudaccc.IDSuda = IDsuda;
                    baza.SaveChanges();
                    //SaveGrid();
                    //MessageBox.Show("Pohrana uspješna!");
                    //baza.Dispose();

                    List<bazaF.FizickaOsoba> suciNovi = new List<bazaF.FizickaOsoba>();
                    List<bazaF.FizickaOsoba> suciPresjek = new List<bazaF.FizickaOsoba>();

                    for (int i = 0; i < dataGridSuci.Rows.Count - 1; i++)
                    {
                        int IDosobe = (int)dataGridSuci[1, i].Value;
                        bazaF.FizickaOsoba s1 = baza.FizickaOsoba.Find(IDosobe);
                        suciNovi.Add(s1);
                    }

                    foreach (bazaF.FizickaOsoba osoba1 in suciNovi)
                    {
                        foreach (bazaF.FizickaOsoba osoba in suci)
                        {
                            if (osoba1.Equals(osoba) && osoba1.IDOsobe != id)
                            {
                                suciPresjek.Add(osoba);
                            }
                        }
                    }



                }
                catch (Exception error)
                {
                    MessageBox.Show("Žao nam je, no došlo je do pogreške!");
                    MessageBox.Show(error.ToString());
                }
                //baza.Dispose();
            }

            

            LoadDataSources(false);
            UpdateDisplay(false);
        }

        private async Task Delete()
        {
            DialogResult result = MessageBox.Show("Želite li obrisati zapis", "Brisanje zapisa", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                bindingSourceSud.RemoveCurrent();
                await baza.SaveChangesAsync();
                //    bazaF.Sud sud = bindingSourceSud.Current as bazaF.Sud;
                //    try
                //                            {
                //                                    baza.Sud.Remove(sud);
                //                                    baza.SaveChanges();
                //                                    MessageBox.Show("Zapis je uspješno obrisan!",
                //                                    "Zapis uspješno obrisan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                            }
                //                            catch (Exception exc)
                //                            {
                //                                    string tekst = exc.Message + Environment.NewLine + exc.StackTrace;
                //                                    if (exc.InnerException != null)
                //                                    {
                //                                            tekst += Environment.NewLine + exc.InnerException.Message;
                //                                    }
                //                                    MessageBox.Show(tekst, "Pogreška prilikom pohrane u bazu");
                //                            }

                //                    }
            }
        }
       

        private void Add()
        {
            bindingNavigatorDeleteItem.Enabled = true;
            bazaF.Sud sud = (bazaF.Sud)bindingSourceSud.Current;
            int max = (from x in baza.Sud select x.IDSuda).Max();
            sud.IDSuda = max + 1;

            bindingSourceSud.ResetCurrentItem();

            UpdateDisplay(true);
            tbID.Enabled = false;
            //int max = (from x in baza.Sud select x.IDSuda).Max();
            //tbID.Text = Convert.ToString(max + 1);
            tbMjesto.Enabled = false;
            bindingNavigatorDeleteItem.Enabled = true;
        }


        private void Cancel()
        {

            bindingSourceKategorija.CancelEdit();
            bindingSourceMjesto.CancelEdit();
            bindingSourceSud.CancelEdit();
            bindingSourceSudac.CancelEdit();
            bindingSourceSudskoVijece.CancelEdit();

            CancelAllChanges();

            //ResetCurrentItem potreban jer entiteti ne implementiraju INotifyPropertyChanged
            bindingSourceSud.ResetCurrentItem();

            UpdateDisplay(false);
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
            bindingNavigatorDeleteItem.Enabled = true;
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

        public void cbPbr_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void dataGridSuci_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void cbPbr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bazaF.Sud sud = (bazaF.Sud)bindingSourceSud.Current;
                int pbr = Convert.ToInt32(cbPbr.Text);
                var upit =
                    from item in baza.Mjesto
                    where item.PBr == pbr
                    select new { item };

                foreach (var elem in upit)
                {
                    sud.Mjesto.Naziv = elem.item.Naziv;
                    //tbMjesto.Text = elem.item.Naziv;
                }
            }
            catch(Exception exception)
            {

            }

        }

        private void openToolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridSuci_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            List<bazaF.Sudac> sudacZaBrisanje = new List<bazaF.Sudac>();
            int count = dataGridSuci.SelectedRows.Count;
            for (int i = 0; i < count; i++)
            {
                DialogResult result = MessageBox.Show("Jeste li sigurni da želite obrisati suca?", "Brisanje zapisa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    sudacZaBrisanje.Add(dataGridSuci.SelectedRows[i].DataBoundItem as bazaF.Sudac);
                }

            }
            baza.Sudac.Load();
            foreach (bazaF.Sudac s in sudacZaBrisanje)
            {
                //try
                //{
                    //baza = new bazaF.RPPP10();
                    bazaF.Sudac x = baza.Sudac.Where(u => u.IDOsobe == s.IDOsobe).Where(u => u.IDSuda == s.IDSuda).FirstOrDefault();
                    //if (x != null)
                    //{
                        baza.Sudac.Remove(s);
                   // }
                    
                    //LoadDataSources(false);
               // }
                //catch (Exception exc)
                //{
                //    MessageBox.Show("Dogodila se greška prilikom brisanja!!!");
                //}
            }

            e.Cancel = true;
        }

        private void dataGridSuci_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bazaF.Sudac x = (bazaF.Sudac)bindingSourceSudac[0];
            bazaF.Osoba f = baza.Osoba.Find(x.IDOsobe);
            x.Osoba = f;
            bindingSourceSudac[0] = x;
            bindingSourceSudac.ResetBindings(true);
            dataGridSuci.Refresh();
        }

        private void tbNaziv_Validating(object sender, CancelEventArgs e)
        {
            IspravnostNaziva = IspravanNaziv((TextBox)sender);
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
                        epNaziv.SetError(tb, "Uneseni su neodgovarajući znakovi.");
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

        }

        private void tbAdresa_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostAdrese = IspravnaAdresa((TextBox)sender);
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

        // Kategorija
        private void cbKategorija_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostKategorije = IspravnaKategorija((ComboBox)sender);

        }
        private bool IspravnaKategorija(ComboBox cb)
        {
            if (cb.SelectedItem == null)
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
        private bool IspravnostSvega()
        {

            if (IspravnostNaziva==false)
                IspravnostNaziva = IspravanNaziv(tbNaziv);
            if (IspravnostAdrese==false)
                IspravnostAdrese = IspravnaAdresa(tbAdresa);
            if (IspravnostKategorije==false)
                IspravnostKategorije = IspravnaKategorija(cbKategorija);

            if (IspravnostNaziva && IspravnostAdrese && IspravnostKategorije)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            new Mjesta().Show();
            LoadDataSources(true);
        }
    }

}
