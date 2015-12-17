using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaProces
{
    public partial class OdabirOsobe : Form
    {

        public int povratakID = 0;
        private bool prav = false;
        bazaF.RPPP10 baza = new bazaF.RPPP10();

        public OdabirOsobe(string tko, bool prav)
        {
            InitializeComponent();

            this.prav = prav;

            if (!prav)
            {
                //if (tko == "tuz")
                //{
                //    var podaci = from x in baza.Tuzitelj
                //                 join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                //                 join z in baza.FizickaOsoba on x.IDOsobe equals z.IDOsobe
                //                 select new { z.Ime, z.Prezime, z.IDOsobe };
                //    dataGridView1.DataSource = podaci.ToList();
                //}
                //else if (tko == "ost")
                //{
                //    var podaci = from x in baza.Ostecenik
                //                 join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                //                 join z in baza.FizickaOsoba on x.IDOsobe equals z.IDOsobe
                //                 select new { z.Ime, z.Prezime, z.IDOsobe };
                //    dataGridView1.DataSource = podaci.ToList();
                //}
                //else if (tko == "bran")
                //{
                //    var podaci = from x in baza.Branitelj
                //                 join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                //                 join z in baza.FizickaOsoba on x.IDOsobe equals z.IDOsobe
                //                 select new { z.Ime, z.Prezime, z.IDOsobe };
                //    dataGridView1.DataSource = podaci.ToList();
                //}
                //else if (tko == "opt")
                //{
                //    var podaci = from x in baza.Optuzenik
                //                 join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                //                 join z in baza.FizickaOsoba on x.IDOsobe equals z.IDOsobe
                //                 select new { z.Ime, z.Prezime, z.IDOsobe };
                //    dataGridView1.DataSource = podaci.ToList();
                //}
                //else if (tko == "svj")
                //{
                //    var podaci = from x in baza.Svjedok
                //                 join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                //                 join z in baza.FizickaOsoba on x.IDOsobe equals z.IDOsobe
                //                 select new { z.Ime, z.Prezime, z.IDOsobe };
                //    dataGridView1.DataSource = podaci.ToList();

                //}
                //else
                //{
                //    this.Close();
                //}

            //*************************************************
            //SAMO FIZIČKE OSOBE OVDJE:
                var podaci = from y in baza.Osoba
                             join x in baza.FizickaOsoba on y.IDOsobe equals x.IDOsobe
                             select new { x.Ime, x.Prezime, x.IDOsobe };
                dataGridView1.DataSource = podaci.ToList();

            }
            else {
                //if (tko == "tuz")
                //{
                //    var podaci = from x in baza.Tuzitelj
                //                 join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                //                 join z in baza.PravnaOsoba on x.IDOsobe equals z.IDOsobe
                //                 select new { z.Naziv, z.IDOsobe };
                //    dataGridView1.DataSource = podaci.ToList();
                //}
                //else if (tko == "ost")
                //{
                //    var podaci = from x in baza.Ostecenik
                //                 join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                //                 join z in baza.PravnaOsoba on x.IDOsobe equals z.IDOsobe
                //                 select new { z.Naziv, z.IDOsobe };
                //    dataGridView1.DataSource = podaci.ToList();
                //}
                //else if (tko == "bran")
                //{
                //    var podaci = from x in baza.Branitelj
                //                 join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                //                 join z in baza.PravnaOsoba on x.IDOsobe equals z.IDOsobe
                //                 select new { z.Naziv, z.IDOsobe };
                //    dataGridView1.DataSource = podaci.ToList();
                //}
                //else if (tko == "opt")
                //{
                //    var podaci = from x in baza.Optuzenik
                //                 join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                //                 join z in baza.PravnaOsoba on x.IDOsobe equals z.IDOsobe
                //                 select new { z.Naziv, z.IDOsobe };
                //    dataGridView1.DataSource = podaci.ToList();
                //}
                //else if (tko == "svj")
                //{
                //    var podaci = from x in baza.Svjedok
                //                 join y in baza.Osoba on x.IDOsobe equals y.IDOsobe
                //                 join z in baza.PravnaOsoba on x.IDOsobe equals z.IDOsobe
                //                 select new { z.Naziv, z.IDOsobe };
                //    dataGridView1.DataSource = podaci.ToList();
                //}
                //else
                //{
                //    this.Close();
                //}

            //*************************************************
            //SAMO PRAVNE OSOBE OVDJE:
                var podaci = from y in baza.Osoba
                             join x in baza.PravnaOsoba on y.IDOsobe equals x.IDOsobe
                             select new { x.Naziv, x.IDOsobe };
                dataGridView1.DataSource = podaci.ToList();


            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (!this.prav){
                    this.povratakID=Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                }
                else{
                    this.povratakID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                }
                MessageBox.Show("Odabrano!");
                this.button1.Enabled = false;
            }
            else {
                MessageBox.Show("odaberi nekoga");
            }
        }

    }
}
