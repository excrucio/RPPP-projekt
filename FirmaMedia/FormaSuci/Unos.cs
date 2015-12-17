using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaSuci
{
    public partial class Unos : Form
    {
        bool IspravanostOIBa, IspravanostAdrese, IspravanostImena, IspravanostPrezimena, IspravanostImenaOca, IspravanostDatuma;
        Font defaultFont;
        Color defaultColor;

        public Unos()
        {
            InitializeComponent();
            for (int i = 1; i <= 31; i++)
            {
                cbDanRod.Items.Add(i);
                if (i <= 12) cbMjesecRod.Items.Add(i);
            }
            for (int i = 1900; i <= 2014; i++) cbGodinaRod.Items.Add(i);

            defaultFont = this.Font;
            defaultColor = this.BackColor;
        }

        //*****************************  VALIDACIJA  **************************//
        //  OIB
        public void tbOIB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravanostOIBa = IspravanOIB((TextBox)sender);
        }

        public bool IspravanOIB(TextBox tb)
        {
            if (tb.Text.Length == 0)
            {
                epOIB.SetError(tbOIB, "Unos OIB-a je obavezan.");
                return false;
            }

            if (tb.Text.Length != 13)
            {
                epOIB.SetError(tbOIB, "OIB ima 13 znamenki.");
                return false;
            }
            else
            {
                epOIB.SetError(tbOIB, "");
                return true;
            }
        }

        // Adresa
        private void tbAdresa_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravanostAdrese = IspravnaAdresa((TextBox)sender);
        }
        private bool IspravnaAdresa(TextBox tb)
        {
            if (tb.Text.Length == 0)
            {
                epAdresa.SetError(tb, "Unos adrese je obavezan.");
                return false;
            }
            else
            {
                epAdresa.SetError(tb, "");
                return true;
            }
        }

        // Ime
        public void tbIme_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravanostImena = IspravnoIme((TextBox)sender);
        }

        private bool IspravnoIme(TextBox tb)
        {
            if (tb.Text.Length == 0)
            {
                epAdresa.SetError(tb, "Unos imena je obavezan.");
                return false;
            }
            else
            {
                epAdresa.SetError(tb, "");
                return true;
            }
        }

        // Prezime
        public void tbPrezime_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravanostPrezimena = IspravnoPrezime((TextBox)sender);
        }

        private bool IspravnoPrezime(TextBox tb)
        {
            if (tb.Text.Length == 0)
            {
                epAdresa.SetError(tb, "Unos prezimena je obavezan.");
                return false;
            }
            else
            {
                epAdresa.SetError(tb, "");
                return true;
            }
        }

        // Ime oca
        public void tbImeOca_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravanostImenaOca = IspravnoImeOca((TextBox)sender);
        }

        private bool IspravnoImeOca(TextBox tb)
        {
            if (tb.Text.Length == 0)
            {
                epAdresa.SetError(tb, "Unos imena oca je obavezan.");
                return false;
            }
            else
            {
                epAdresa.SetError(tb, "");
                return true;
            }
        }

        // Datum rođenja
        private void cbDatRod_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IspravanostDatuma = IspravanDatRod((ComboBox)sender);
        }

        private bool IspravanDatRod(ComboBox cb)
        {
            if (!(cb.SelectedIndex > -1))
            {
                epDatum.SetError(lblGodinaTocka, "Unesite ispravan datum.");
                return false;
            }
            else
            {
                epDatum.SetError(cb, "");
                return true;
            }
        }

        // Mjesto <----------------------------------

        // *********************************************************************//

        private bool IspravnostSvega()
        {
            if (IspravanostOIBa && IspravanostAdrese && IspravanostImena && 
                IspravanostPrezimena && IspravanostImenaOca && IspravanostDatuma)
            {
                return true;
            }
            else
            {
                if (!IspravanostOIBa)
                    IspravanOIB(tbOIB);
                if (!IspravanostAdrese)
                    IspravnaAdresa(tbAdresa);
                if (!IspravanostImena)
                    IspravnoIme(tbIme);
                if (!IspravanostPrezimena)
                    IspravnoPrezime(tbPrezime);
                if (!IspravanostImenaOca)
                    IspravnoImeOca(tbImeOca);
                if (!IspravanostDatuma)
                {
                    IspravanDatRod(cbDanRod);
                    IspravanDatRod(cbMjesecRod);
                    IspravanDatRod(cbGodinaRod);
                }
                return false;
            }
        }

        // *********************************************************************//

        private void JMBG_MouseHover(object sender, System.EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip((TextBox)sender, "JMBG je tajan broj te ga nije potrebno unositi.");
        }

        // *********************************************************************//


        //*********************************** BUTTONS  **************************************//
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            if (IspravnostSvega())
            {
                this.Close();
            }
            else
            {
                const string poruka = "Podaci su neispravno uneseni. Molimo Vas da ih ispravite prije pohrane.";
                const string caption = "Ups!";
                var odluka = MessageBox.Show(poruka, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripMenuItemFont_Click(object sender, EventArgs e)
        {

        }

        private void defaultToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Font = defaultFont;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            menuStripSudac.Font = defaultFont;
            menuStripSudac.ForeColor = System.Drawing.SystemColors.ControlText;
            lblUnosSuca.Font = defaultFont;
            lblUnosSuca.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void promjeniFontToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fontDialogSudac.ShowColor = true;

            if (fontDialogSudac.ShowDialog() != DialogResult.Cancel)
            {
                this.Font = fontDialogSudac.Font;
                this.ForeColor = fontDialogSudac.Color;
                menuStripSudac.Font = fontDialogSudac.Font;
                menuStripSudac.ForeColor = fontDialogSudac.Color;
                lblUnosSuca.Font = fontDialogSudac.Font;
                lblUnosSuca.ForeColor = fontDialogSudac.Color;
            }
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = defaultColor;
            menuStripSudac.BackColor = defaultColor;
        }

        private void promjeniPozadinuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialogSudac.ShowDialog() != DialogResult.Cancel)
            {
                this.BackColor = colorDialogSudac.Color;
                menuStripSudac.BackColor = colorDialogSudac.Color;
            }
        }
    }
}
