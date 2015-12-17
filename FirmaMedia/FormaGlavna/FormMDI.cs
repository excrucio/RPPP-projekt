using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaGlavna
{
    public partial class FormMDI : Form
    {
        public FormMDI()
        {
            InitializeComponent();
        }


        #region Osnovne forme
        private void sudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using(new StatusBusy())
            //{
            //    FormaSud.UnosSud sud = new FormaSud.UnosSud();
            //    sud.MdiParent = this;
            //    sud.Show();
            //}
            
        }

        private void pregledSudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaSud.UnosSud sud = new FormaSud.UnosSud();
                sud.MdiParent = this;
                sud.Show();
            }
        }

        private void procesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaProces.ProcesPretrazivanje proces = new FormaProces.ProcesPretrazivanje();
                proces.MdiParent = this;
                proces.Show();
            }
        }

        private void optužbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaOptuzba.Optuzba optuzba = new FormaOptuzba.Optuzba();
                optuzba.MdiParent = this;
                optuzba.Show();
            }
        }

        private void ročišteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaRocista.NoviUnos rociste = new FormaRocista.NoviUnos();
                rociste.MdiParent = this;
                rociste.Show();
            }
        }

        private void spisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaSpis.UnosUSpis spis = new FormaSpis.UnosUSpis();
                spis.MdiParent = this;
                spis.Show();
            }
        }

        private void zakonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaOsobe.ZakoniForma zakon = new FormaOsobe.ZakoniForma();
                zakon.MdiParent = this;
                zakon.Show();
            }
        }

        private void osobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaOsobe.OsobeForma osobe = new FormaOsobe.OsobeForma();
                osobe.MdiParent = this;
                osobe.Show();
            }
        }

        private void pretraživanjeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaPresuda.PretrazivanjePresude presuda = new FormaPresuda.PretrazivanjePresude();
                presuda.MdiParent = this;
                presuda.Show();
            }
        }

        private void kaznaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaKazna.KaznaMaster kazna = new FormaKazna.KaznaMaster();
                kazna.MdiParent = this;
                kazna.Show();
            }
        }

        private void unosToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaPresuda.UnosPresude Unos = new FormaPresuda.UnosPresude();
                Unos.MdiParent = this;
                Unos.Show();
            }
        }

        private void pretraživanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaProces.ProcesPretrazivanje Proces = new FormaProces.ProcesPretrazivanje();
                Proces.MdiParent = this;
                Proces.Show();
            }
        }

        private void prikazOptužniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaProces.PrikazOptuznice Proces = new FormaProces.PrikazOptuznice();
                Proces.MdiParent = this;
                Proces.Show();
            }
        }

        private void unosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaProces.ProcesUnos Proces = new FormaProces.ProcesUnos();
                Proces.MdiParent = this;
                Proces.Show();
            }
        }

        private void unosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaSpis.UnosUSpis Spis = new FormaSpis.UnosUSpis();
                Spis.MdiParent = this;
                Spis.Show();
            }
        }

        private void pretraživanjeToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaSuci.Pretrazivanje Suci = new FormaSuci.Pretrazivanje();
                Suci.MdiParent = this;
                Suci.Show();
            }
        }

        private void unosToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaSuci.Unos Suci = new FormaSuci.Unos();
                Suci.MdiParent = this;
                Suci.Show();
            }
        }

        #endregion

        #region Unos

        #endregion Unos

        #region Prozori
        private void kaskadnoPoravnanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalnoPoravnanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void vertikalnoPoravnanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        #endregion

        #region Sifrarnici
        private void kategorijaSudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaOsobe.SifrarnikKategorijaSuda sifrarnik = new FormaOsobe.SifrarnikKategorijaSuda();
                sifrarnik.MdiParent = this;
                sifrarnik.Show();
            }
        }

        private void mjestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaOsobe.Mjesta sifrarnik = new FormaOsobe.Mjesta();
                sifrarnik.MdiParent = this;
                sifrarnik.Show();
            }
        }

        private void ulogaSudionikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaOsobe.SifrarnikUlogaSudionika sifrarnik = new FormaOsobe.SifrarnikUlogaSudionika();
                sifrarnik.MdiParent = this;
                sifrarnik.Show();
            }
        }

        private void vrstaKazneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaOsobe.SifrarnikVrstaKazne sifrarnik = new FormaOsobe.SifrarnikVrstaKazne();
                sifrarnik.MdiParent = this;
                sifrarnik.Show();
            }
        }

        private void vrstaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaOsobe.SifrarnikVrstaOznake sifrarnik = new FormaOsobe.SifrarnikVrstaOznake();
                sifrarnik.MdiParent = this;
                sifrarnik.Show();
            }
        }

        private void vrstaPresudeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaOsobe.SifrarnikVrstaPresude sifrarnik = new FormaOsobe.SifrarnikVrstaPresude();
                sifrarnik.MdiParent = this;
                sifrarnik.Show();
            }
        }

        private void vrstaSpisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaOsobe.SifrarnikVrstaSpisa sifrarnik = new FormaOsobe.SifrarnikVrstaSpisa();
                sifrarnik.MdiParent = this;
                sifrarnik.Show();
            }
        }

        #endregion

        private void pregledSudaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaSud.Sud sud = new FormaSud.Sud();
                sud.MdiParent = this;
                sud.Show();
            }
        }

        private void sudoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (new StatusBusy())
            {
                FormaSud.Sud sud = new FormaSud.Sud();
                sud.MdiParent = this;
                sud.Show();
            }
        }

    }
}
