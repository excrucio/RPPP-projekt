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
    public partial class Pretrazivanje : Form
    {
        public Pretrazivanje()
        {
            InitializeComponent();
        }

        private void bPretrazi_Click(object sender, EventArgs e)
        {
            if (tbIme.Text=="" || tbPrezime.Text=="" || tbOdvjUred.Text=="" ||
                (cbDan.SelectedIndex < -1 && cbMjesec.SelectedIndex < -1 && cbGodina.SelectedIndex < -1))
            {
                const string poruka = "Potrebno je unijeti minimalno jedan podatak.";
                const string caption = "Ups!";
                var odluka = MessageBox.Show(poruka, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
