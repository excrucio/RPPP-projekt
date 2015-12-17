using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaOptuzba
{
    public partial class Optuzba : Form
    {
        bazaF.RPPP10 baza = new bazaF.RPPP10();

        public Optuzba()
        {
            InitializeComponent();
        }

        private void Omoguci()
        {
            PodaciPanel.Enabled = false;
            UrediButton.Enabled = true;
            DodajButton.Enabled = true;
            ObrisiButton.Enabled = true;
            SpremiButton.Enabled = false;
            OdustaniButton.Enabled = false;
            Podaci.Enabled = true;
        }

        private void OptuznicaLoad(object sender, EventArgs e)
        {
            bindingNavigator1.Visible = false;
            Omoguci();

            var upit = baza.Optuzba.Select(x=> new{x.Optuzenik.Osoba.OIB, x.Zakon.Naziv, x.Presuda.TipPresude1.NazivTipa});
            var Lista = upit.ToList();
            BindingSource optuzba = new BindingSource();
            optuzba.DataSource = Lista;
            bindingSourceOptuzba.DataSource = optuzba;
            bindingNavigator1.BindingSource = optuzba;

            Podaci.DataSource = null;
            Podaci.DataSource = optuzba;

            PodaciPanel.Enabled = false;
            PretraživanjeLabel.Visible = false;
            bindingNavigator1.Visible = true;
        }
    }
}
