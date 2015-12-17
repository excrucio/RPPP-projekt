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
    public partial class SortSud : Form
    {
        #region Sortiranje i filtriranje

        bazaF.RPPP10 context;

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
            Naziv, UlicaIKucniBr, Pbr, Kategorija, Nadredeni
        }

        public SortSud()
        {
            InitializeComponent();
        }

        private void SortSud_Load(object sender, EventArgs e)
        {
            LoadData();
            FillCombos();
            Func<bazaF.Sud, string, bool> filterNazivSuda = 
                (sud, naziv) => sud.Naziv == naziv;
        }

        private void FillCombos()
        {
            List<KeyValuePair<string, Stupac>> list = new List<KeyValuePair<string, Stupac>>{
				new KeyValuePair<string, Stupac>("Naziv suda", Stupac.Naziv),
				new KeyValuePair<string, Stupac>("Adresa", Stupac.UlicaIKucniBr),
				new KeyValuePair<string, Stupac>("Poštanski broj", Stupac.Pbr),
                //new KeyValuePair<string, Stupac>("Kategorija suda", Stupac.Kategorija),
                //new KeyValuePair<string, Stupac>("Nadređeni sud", Stupac.Nadredeni),
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

        private void LoadData()
        {
            context = new bazaF.RPPP10();
            var query = context.Sud.AsNoTracking();
            //var query = context.Sud.Include(n => n.PBr)
            //                         .Include(m => m.Kategorija)
            //                         .Include(o => o.Nadredeni).AsNoTracking();
            sudBindingSource1.DataSource = query.ToList();
        }

        private void FormaSud_FormClosing(object sender, FormClosingEventArgs e)
        {
            context.Dispose();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            var query = context.Sud.Include(o => o.Proces).AsNoTracking();
                                    
            //var query = context.Sud.AsNoTracking();
            query = ApplyFilter(query);
            IOrderedQueryable<bazaF.Sud> sortedQuery = ApplySort(query);
            if (sortedQuery != null)
            {
                sudBindingSource1.DataSource = sortedQuery.ToList();
            }
            else
            {
               sudBindingSource1.DataSource = query.ToList();
            }      
		  }

        private IQueryable<bazaF.Sud> ApplyFilter(IQueryable<bazaF.Sud> query)
        {
            //foreach (FilterElement item in listBoxFilter.Items)
            //{
                //string vrijednost = item.Vrijednost;
                //moramo definirati lokalnu varijablu, jer bi inače parametar bila referenca na item.Vrijednost što bi se povezalo tek naknadno
                //pa bi svi parametri bili isti -> vidi PPIJ :)
                //switch (item.Naziv)
            string vrijednost = tbTrazi.Text;
            switch(cbFilter.Text)
                {
                    //case Stupac.Pbr:
                    case "Poštanski broj":
                        int pbr = int.Parse(vrijednost);
                        query = query.Where(m => m.PBr == pbr);
                        break;
                    //case Stupac.Naziv:
                    case "Naziv suda":
                        query = query.Where(m => m.Naziv.Contains(vrijednost));
                        break;
                    //case Stupac.UlicaIKucniBr:
                    case "Adresa":
                        query = query.Where(m => m.UlicaIKucniBr.Contains(vrijednost)); //case insensitive ako se radi o sql upitu
                        break;
                    //case Stupac.Nadredeni:
                    //    int nadredeni = int.Parse(vrijednost);
                    //    query = query.Where(m => m.Nadredeni==nadredeni);
                    //    break;
                    //case Stupac.Kategorija:
                    //    int kategorija = int.Parse(vrijednost);
                    //    query = query.Where(m => m.Kategorija==kategorija);
                    //    break;
                //}
            }
            return query;
        }

        private void textBoxUvjet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string vrijednost = tbTrazi.Text;
                if (!string.IsNullOrWhiteSpace(vrijednost))
                {
                    KeyValuePair<string, Stupac> pair = (KeyValuePair<string, Stupac>)cbFilter.SelectedItem;
                    FilterElement filterElement = new FilterElement()
                    {
                        Naziv = pair.Value,
                        Vrijednost = vrijednost,
                        Opis = pair.Key
                    };
                    listBoxFilter.Items.Add(filterElement);
                }
            }
        }

        private IOrderedQueryable<bazaF.Sud> ApplySort(IQueryable<bazaF.Sud> query)
        {
            IOrderedQueryable<bazaF.Sud> sortedQuery = null;
            for (int i = 1; i <= 3; i++)
            {
                ComboBox combo = gbSort.Controls["cbSort" + i] as ComboBox;
                ComboBox comboPoredak = gbSort.Controls["cbSort" + i + i] as ComboBox;
                if (combo.SelectedIndex > 0)
                {
                    Stupac stupac = (Stupac)combo.SelectedValue;
                    bool descending = comboPoredak.SelectedIndex == 1;

                    switch (stupac)
                    {
                        case Stupac.Kategorija:
                            if (sortedQuery == null)
                            {
                                if (descending)
                                    sortedQuery = query.OrderByDescending(m => m.Kategorija);
                                else
                                    sortedQuery = query.OrderBy(m => m.Kategorija);
                            }
                            else
                            {
                                if (descending)
                                    sortedQuery = sortedQuery.ThenByDescending(m => m.Kategorija);
                                else
                                    sortedQuery = sortedQuery.ThenBy(m => m.Kategorija);
                            }
                            break;
                        case Stupac.Nadredeni:
                            if (sortedQuery == null)
                            {
                                if (descending)
                                    sortedQuery = query.OrderByDescending(m => m.Nadredeni);
                                else
                                    sortedQuery = query.OrderBy(m => m.Nadredeni);
                            }
                            else
                            {
                                if (descending)
                                    sortedQuery = sortedQuery.ThenByDescending(m => m.Nadredeni);
                                else
                                    sortedQuery = sortedQuery.ThenBy(m => m.Nadredeni);
                            }
                            break;
                        case Stupac.Naziv:
                            if (sortedQuery == null)
                            {
                                if (descending)
                                    sortedQuery = query.OrderByDescending(m => m.Naziv);
                                else
                                    sortedQuery = query.OrderBy(m => m.Naziv);
                            }
                            else
                            {
                                if (descending)
                                    sortedQuery = sortedQuery.ThenByDescending(m => m.Naziv);
                                else
                                    sortedQuery = sortedQuery.ThenBy(m => m.Naziv);
                            }
                            break;
                        case Stupac.Pbr:
                            if (sortedQuery == null)
                            {
                                if (descending)
                                    sortedQuery = query.OrderByDescending(m => m.PBr);
                                else
                                    sortedQuery = query.OrderBy(m => m.PBr);
                            }
                            else
                            {
                                if (descending)
                                    sortedQuery = sortedQuery.ThenByDescending(m => m.PBr);
                                else
                                    sortedQuery = sortedQuery.ThenBy(m => m.PBr);
                            }
                            break;
                        case Stupac.UlicaIKucniBr:
                            if (sortedQuery == null)
                            {
                                if (descending)
                                    sortedQuery = query.OrderByDescending(m => m.UlicaIKucniBr);
                                else
                                    sortedQuery = query.OrderBy(m => m.UlicaIKucniBr);
                            }
                            else
                            {
                                if (descending)
                                    sortedQuery = sortedQuery.ThenByDescending(m => m.UlicaIKucniBr);
                                else
                                    sortedQuery = sortedQuery.ThenBy(m => m.UlicaIKucniBr);
                            }
                            break;
                    }
                }
            }
            return sortedQuery;
        }

        #endregion
    }

}
