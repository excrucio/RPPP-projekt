using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaSud
{
    public partial class PretrazivanjeSud : Form
    {
        
        Font defaultFont;
        Color defaultColor;

        bool IspravnostMjesta, IspravnostNaziva, IspravnostAdrese;

        public PretrazivanjeSud()
        {
            InitializeComponent();
            defaultFont = this.Font;
            defaultColor = this.BackColor;
            bazaF.RPPP10 baza = new bazaF.RPPP10();
            var upit = baza.KategorijaSuda.Select(x => new { x.NazivKatSuda });
            var kategorija = upit.ToList();

            cbPbr.Items.Clear();
            cbPbr.Items.Add(" - Odaberite - ");
            cbPbr.SelectedIndex = 0;

            cbKategorija.Items.Clear();
            cbKategorija.Items.Add(" - Odaberite - ");
            cbKategorija.SelectedIndex = 0;
            foreach (var elem in kategorija)
            {
                cbKategorija.Items.Add(elem.NazivKatSuda);
            }
            baza.Dispose();
        }

        //private ~PretrazivanjeSud()
        //{
        //    baza.Dispose();
        //}

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            bazaF.RPPP10 baza = new bazaF.RPPP10();
            var upit1=(dynamic) null;
            var upit2 = (dynamic)null;
            var upit3 = (dynamic)null;
            var upit4 = (dynamic)null;
            var kat1 = (dynamic)null;
            var kat2 = (dynamic)null;
            var kat3 = (dynamic)null;
            var kat4 = (dynamic)null;

            if (tbNaziv.Text == "" && tbAdresa.Text == "" && tbMjesto.Text == "" && cbKategorija.Text == " - Odaberite - ")
            {
                const string poruka = "Potrebno je unijeti minimalno jedan podatak.";
                const string caption = "Ups!";
                var odluka = MessageBox.Show(poruka, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //if (tbNaziv.Text == "" && tbMjesto.Text == "" && tbNaziv.Text == "")
                //{
                var upit = baza.Sud.Select(x => new
                {
                    x.IDSuda,
                    x.Naziv,
                    x.UlicaIKucniBr,
                    x.Mjesto.PBr,
                    NazivMjesta = x.Mjesto.Naziv,
                    x.KategorijaSuda.NazivKatSuda,
                    NazivSuda2 = x.Sud2.Naziv
                });
                var Lista = upit.ToList();
                dataGridSud.DataSource = null;
                dataGridSud.DataSource = Lista;
                //dataGridSud.Columns[0].HeaderText = "ID suda";
                dataGridSud.Columns[0].Visible = false;
                dataGridSud.Columns[5].HeaderText = "Kategorija";
                dataGridSud.Columns[4].HeaderText = "Mjesto";
                dataGridSud.Columns[2].HeaderText = "Adresa";
                dataGridSud.Columns[6].HeaderText = "Nadređeni";
                //}

                //var izraz1 = (dynamic)null;
                //var izraz2 = (dynamic)null;
                //var izraz3 = (dynamic)null;
                //var izraz4 = (dynamic)null;

                ////Naziv izabran
                //if (tbNaziv.Text != "") izraz1=

                ////Pbr izabran
                //if (cbPbr.Text != "")
                //{
                //    upit2 =
                //        from item in baza.Sud
                //        where item.Naziv.Contains(cbPbr.Text)
                //        select new { item };
                //    kat2 = upit2.ToList();
                //}
                ////adresa izabrana
                //if (tbAdresa.Text != "")
                //{
                //    upit3 =
                //        from item in baza.Sud
                //        where item.Naziv.Contains(cbPbr.Text)
                //        select new { item };
                //    kat3 = upit3.ToList();
                //}

                //var intersect1 = kat1.Intersect(kat2);



                //Kategorija izabrana

            }
                //this.Close();
            baza.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridSud.CurrentRow.Index;
            dataGridSud.Rows[index].Selected = true;
            btnIzmijeni.Visible = true;
        }

        //************************ validacija **************************//

        // Mjesto          
        private void tbMjesto_validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostMjesta = IspravnoMjesto((TextBox)sender);

            if (tbMjesto.Text!="")
            {
                bazaF.RPPP10 baza = new bazaF.RPPP10();
                var upit = baza.Mjesto.Where(x => x.Naziv.Contains(tbMjesto.Text)).Select(x => new { x.PBr, x.Naziv });
                var pbr = upit.ToList();

                cbPbr.Items.Clear();
                cbPbr.Items.Add(" - Odaberite - ");
                cbPbr.SelectedIndex = 0;
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
            for (int i = 0; i < tb.Text.Length; i++)
            {
                if (!(Char.IsLetter(tb.Text[i])) && !(Char.IsWhiteSpace(tb.Text[i])))
                {
                    epPbrMjesto.SetError(tb, "Uneseni su neodgovarajući znakovi.");
                    Ispravno = false;
                    break;
                }
            }
            if (Ispravno) epPbrMjesto.SetError(tb, "");
            return Ispravno;
        }

        // Adresa
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
            if (Ispravno) epAdresa.SetError(tb, "");
            return Ispravno;
        }

        // Naziv
        public void tbNaziv_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravnostNaziva = IspravanNaziv((TextBox)sender);
        }

        private bool IspravanNaziv(TextBox tb)
        {
            bool Ispravno = true;
                
            for (int i = 0; i < tb.Text.Length; i++)
            {
                if (!(Char.IsLetter(tb.Text[i])) && !(Char.IsWhiteSpace(tb.Text[i])))
                {
                    epNaziv.SetError(tb, "Uneseni su neodgovarajući znakovi.");
                    Ispravno = false;
                    break;
                }
            }
            if(Ispravno) epNaziv.SetError(tb, "");
            return Ispravno;
        }

        //******************************************************************/

        // fontovi i pozadina
        private void defaultToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Font = defaultFont;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            menuStripSud.Font = defaultFont;
            menuStripSud.ForeColor = System.Drawing.SystemColors.ControlText;
            lblPretrazivanjeSuda.Font = defaultFont;
            lblPretrazivanjeSuda.ForeColor = System.Drawing.SystemColors.ControlText;
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
                lblPretrazivanjeSuda.Font = fontDialogSud.Font;
                lblPretrazivanjeSuda.ForeColor = fontDialogSud.Color;
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



        //******************************************************************/
        private void cbPbr_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string pbr_mjesto = cbPbr.Text;
            int index = pbr_mjesto.IndexOf(' ');
            string pbr = pbr_mjesto.Substring(0, index);
            int len = pbr_mjesto.Length;
            string mjesto = pbr_mjesto.Substring(index + 1, len - 6);
            tbMjesto.Text = mjesto;
        }

        private void btnIzmijeni_Click(object sender, EventArgs e)
        {
            int red = dataGridSud.CurrentRow.Index;
            int ID = Convert.ToInt32(dataGridSud[0, red].Value);
            UnosSud unos = new UnosSud(ID);
            unos.Show();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            UnosSud Unos = new UnosSud();
            Unos.Show();
        }
        }
        
        

    }