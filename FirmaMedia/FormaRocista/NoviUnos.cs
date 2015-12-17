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

namespace FormaRocista
{
    public partial class NoviUnos : Form
    {
        bazaF.RPPP10 context;
        int maxSudionik;
        public NoviUnos()
        {
            InitializeComponent();
        }

        private void NoviUnos_Load(object sender, EventArgs e)
        {
            LoadDataSources();
            Osvjezi(false);
        }

        private void LoadDataSources()
        {
            bindingNavigator1.Visible = false;
            context = new bazaF.RPPP10();
            maxSudionik = context.Sudionik.Max(d => d.IDSudionika);

            rocisteBindingSource.DataSource = context.Rociste.AsNoTracking().ToList();
            
            List<bazaF.Proces> procesi = context.Proces.AsNoTracking().ToList();
            procesi.Insert(0, new bazaF.Proces
            {
                IDProcesa = 0,
                Naziv = "-------------Odaberite naziv procesa--------------"
            });
            procesBindingSource.DataSource = procesi;

            List<bazaF.UlogaSudionika> uloge = context.UlogaSudionika.AsNoTracking().ToList();
            uloge.Insert(0, new bazaF.UlogaSudionika
            {
                SifraUloge = 0,
                NazivUloge = "--------Odaberite ulogu---------"
            });
            ulogaSudionikaBindingSource.DataSource = uloge;

            List<bazaF.FizickaOsoba> osobe = context.FizickaOsoba.AsNoTracking().ToList();
            osobe.Insert(0, new bazaF.FizickaOsoba
            {
                IDOsobe = 0,
                Ime = "--------Odaberite",
                Prezime = "osobu---------"
            });
            fizickaOsobaBindingSource.DataSource = osobe;

            context.Rociste.Load();
            rocisteBindingSource.DataSource = context.Rociste.Local.ToBindingList();

            bindingNavigator1.Visible = true;
        }

        private void btnIzmjena_Click(object sender, EventArgs e)
        {
            Izmijeni();
        }

        private async void btnSpremanje_Click(object sender, EventArgs e)
        {
            await Spremi();
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            await Brisi();
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            Novi(true);
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Odustani();
        }

        private async void DokumentStavkaForm_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.KeyCode)
            {
                case Keys.Home: Prvi(); break;
                case Keys.PageUp: Prethodni(); break;
                case Keys.PageDown: Sljedeci(); break;
                case Keys.End: Zadnji(); break;
                case Keys.F2: Novi(); break;
                case Keys.F3: Izmijeni(); break;
                case Keys.F7: await Brisi(); break;
                case Keys.F9: Odustani(); break;
                case Keys.F10: await Spremi(); break;
                default: e.Handled = false; break;
            }
        }

        private void Odustani()
        {
            sudionikBindingSource.CancelEdit();
            rocisteBindingSource.CancelEdit();

            PonistiSve();

            rocisteBindingSource.ResetCurrentItem();

            Osvjezi(false);
        }

        private void PonistiSve()
        {
            foreach (var elem in context.ChangeTracker.Entries())
            {
                if (elem.State == EntityState.Added)
                {
                    elem.State = EntityState.Detached;
                }
                else if (elem.State == EntityState.Deleted || elem.State == EntityState.Modified)
                {
                    elem.State = EntityState.Unchanged;
                }
            }
        }

        private bool Validiraj()
        {
            bool Tocno = true;
            if (!(cmbNazivProcesa.SelectedIndex > -1))
            {
                epNazivProcesa.SetError(cmbNazivProcesa, "Proces mora biti odabran!");
                Tocno = false;
            }
            if (!((Convert.ToDecimal(tbTrajanje.Text) > 0) && (Convert.ToDecimal(tbTrajanje.Text) < 20)))
            {
                epTrajanje.SetError(tbTrajanje, "Proces mora imati trajanje! (Gornja granica trajanja je 20 h.)");
                Tocno = false;
            }
            /*foreach (DataGridViewCell cell in dgvSudionici)
            {
                if (!((Convert.ToInt32(cell.Value) > 0) && (cell.Value != null)))
                {
                    epSudionici.SetError(dgvSudionici, "Uloge i osobe moraju biti odabrane!");
                    Tocno = false;
                }
            }*/
            return Tocno;
        }
        private async Task Spremi()
        {
            if (Validiraj()) 
            {
                rocisteBindingSource.EndEdit();
                sudionikBindingSource.EndEdit();
                tbIDRocista.Focus();
            
                //bazaF.Rociste rociste = (bazaF.Rociste)rocisteBindingSource.Current;
          
                //provjera validacijskih pogrešaka na razini modela
                var modelErrors = context.GetValidationErrors();

                StringBuilder Tekst = new StringBuilder();
                foreach (var modelError in modelErrors)
                {
                    if (!modelError.IsValid)
                    {
                        var list = modelError.ValidationErrors
                                    .Select(ve => ve.PropertyName + " : " + ve.ErrorMessage)
                                    .ToList();
                        Tekst.AppendLine(string.Join("\n", list));
                    }
                }
                if (Tekst.Length > 0)
                {
                    MessageBox.Show(Tekst.ToString(), "Nije moguće spremiti neispravan dokument");
                }
                else
                {
                    try
                    {
                        await context.SaveChangesAsync();
                        Osvjezi(false);
                    }
                    catch (Exception exc)
                    {
                        string Nesto = exc.Message + Environment.NewLine + exc.StackTrace;
                        if (exc.InnerException != null)
                        {
                            Nesto += Environment.NewLine + exc.InnerException.Message;
                        }
                        MessageBox.Show(Nesto, "Pogreška prilikom pohrane u bazu");
                    }
                }
            }
        }

        private void Izmijeni()
        {
            Osvjezi(true);
        }

        private void Novi(bool SNavigatora = false)
        {
            cmbNazivProcesa.SelectedValue = 0;
            dtpDatum.Value = DateTime.Now;
            tbTrajanje.Text = "0.0";
            
            if (!SNavigatora) //u slučaju da poziv nije došao s binding navigatora, već npr. s tipkovnice
            {
                rocisteBindingSource.AddNew();
            }
            
            bazaF.Rociste rociste = (bazaF.Rociste) rocisteBindingSource.Current;
            rociste.IDRocista = context.Rociste.Max(d => d.IDRocista) + 1;
            rociste.IDProcesa = int.Parse(cmbNazivProcesa.SelectedValue.ToString());
            rociste.Datum = dtpDatum.Value;
            rociste.Trajanje = Convert.ToDecimal(tbTrajanje.Text);
            rocisteBindingSource.ResetCurrentItem();
            Osvjezi(true);
        }

        private async Task Brisi()
        {
            DialogResult result = MessageBox.Show("Želite li obrisati zapis?", "Brisanje zapisa", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                rocisteBindingSource.RemoveCurrent();
                await context.SaveChangesAsync();
            }
        }

        private void Zadnji()
        {
            rocisteBindingSource.Position = rocisteBindingSource.Count - 1;
        }

        private void Sljedeci()
        {
            if (rocisteBindingSource.Position != rocisteBindingSource.Count - 1)
            {
                ++rocisteBindingSource.Position;
            }
        }

        private void Prethodni()
        {
            if (rocisteBindingSource.Position != 0)
            {
                --rocisteBindingSource.Position;
            }
        }

        private void Prvi()
        {
            rocisteBindingSource.Position = 0;
        }

        private void Osvjezi(bool editMode)
        {
            bindingNavigator1.MoveFirstItem.Enabled = bindingNavigator1.MovePreviousItem.Enabled
                                                    = bindingNavigatorMoveFirstItem.Enabled
                                                    = bindingNavigator1.MoveNextItem.Enabled
                                                    = bindingNavigator1.MoveLastItem.Enabled
                                                    = bindingNavigator1.PositionItem.Enabled
                                                    = btnNovi.Enabled
                                                    = btnObrisi.Enabled
                                                    = btnIzmjena.Enabled
                                                    = !editMode;


            btnSpremanje.Enabled    = btnOdustani.Enabled 
                                    = pnlRociste.Enabled 
                                    = editMode;

            dgvSudionici.AllowUserToDeleteRows = editMode;
            dgvSudionici.AllowUserToAddRows = editMode;
            dgvSudionici.ReadOnly = !editMode;
            dgvSudionici.Columns[0].ReadOnly = dgvSudionici.Columns[1].ReadOnly = true;

        }

        private void dgvSudionici_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = btnIzmjena.Enabled;
        }

        private void NoviUnos_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.Dispose();
        }

        private void dgvSudionici_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvSudionici.Rows[dgvSudionici.Rows.Count - 2].Cells[0].Value = Int32.Parse(tbIDRocista.Text);
            dgvSudionici.Rows[dgvSudionici.Rows.Count - 2].Cells[1].Value = maxSudionik + 1;
            maxSudionik++;
        }

        private void šifrarnikUlogeSudionikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaOsobe.SifrarnikUlogaSudionika FormaUloga = new FormaOsobe.SifrarnikUlogaSudionika();
            FormaUloga.Show();
        }

        private void procesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaProces.ProcesPretrazivanje FormaProces = new FormaProces.ProcesPretrazivanje();
            FormaProces.Show();
        }

        private void osobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaOsobe.OsobeForma FormaOsoba = new FormaOsobe.OsobeForma();
            FormaOsoba.Show();
        }

    }
}
