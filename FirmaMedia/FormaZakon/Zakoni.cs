using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FirmaMedia
{
    public partial class Zakoni : Form
    {
        public Zakoni()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Upit.Text == "")
            {

                var upit = baza.PravnaOsoba.Select(x => new { x.Naziv, x.MB, x.Osoba.OIB, x.Osoba.UlicaIKucniBr, x.Osoba.PBr, NazivMjesto = x.Osoba.Mjesto.Naziv });
                var Lista = upit.ToList();
                DataGrid.DataSource = null;
                DataGrid.DataSource = Lista;
            }

            if (PoImenu.Checked == true)
            {

            }
            else if (PoRazini.Checked == true)
            {

            }
            else
            {

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            UnosZakona Unos = new UnosZakona();
            Unos.Show();
        }

    }

}
