using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UgovoriKlase;
using ManuelaKajkara;
using ManuelaKajkara.BLLProviders;

namespace ImplementacijaUgovora
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IFirmaServis
    {
        #region sudovi
        public List<UgovoriKlase.Sud> PopisSudova()
        {
            SudBLL bll = new SudBLL();

            return bll.FetchAll().Select(m =>
                new UgovoriKlase.Sud
                {
                    ID = m.ID,
                    Naziv = m.naziv,
                    Adresa = m.adresa,
                    kategorija = (int)m.kategorija,
                    PBr = (int)m.pbr
                }
                ).ToList();
        }

        public UgovoriKlase.Sud DohvatiJedan(int id)
        {
            SudBLL bll = new SudBLL();
            var sud = bll.Fetch(id);
            return new UgovoriKlase.Sud
            {
                ID = sud.ID,
                Naziv = sud.naziv,
                Adresa = sud.adresa,
                PBr = (int)sud.pbr,
                kategorija = (int)sud.kategorija
            };
        }


        public ManuelaKajkara.Mjesto DohvatiJednoMjesto(int id)
        {
            MjestoBLL bll = new MjestoBLL();
            ManuelaKajkara.Mjesto mjesto = bll.Fetch(id);
            return mjesto;
        }


        public List<UgovoriKlase.Kategorija> PopisKategorija()
        {
            KategorijaBLL bll = new KategorijaBLL();

            return bll.FetchAll().Select(m =>
                new UgovoriKlase.Kategorija
                {
                    id = m.id,
                    naziv = m.naziv
                }
                ).ToList();
        }

        public List<UgovoriKlase.Mjesto> PopisMjesta()
        {
            MjestoBLL bll = new MjestoBLL();

            return bll.FetchAll().Select(m =>
                new UgovoriKlase.Mjesto
                {
                    pbr = m.pbr,
                    naziv = m.naziv
                }
                ).ToList();
        }

        public void ObrisiSud(int id)
        {
            try
            {
                ManuelaKajkara.SudBLL bll = new ManuelaKajkara.SudBLL();
                ManuelaKajkara.Sud sud = bll.Fetch(id);
                bll.Delete(sud);
                SudacBLL bllS = new SudacBLL();
                bllS.DeleteSud(id); //svim sucima koji sude na sudu koji se briše, stavi null za idSuda
            }
            catch
            {
                throw new Exception("Brisanje nije izvedivo");
            }

        }

        public void DodajNoviSud(int id, string naziv, string adresa, int pbr, int kategorija)
        {
            try
            {
                ManuelaKajkara.Sud sud = new ManuelaKajkara.Sud()
                {
                    ID = id,
                    naziv = naziv,
                    adresa = adresa,
                    pbr = pbr,
                    kategorija = kategorija,
                };
                var bll = new ManuelaKajkara.SudBLL();
                bll.Insert(sud);
            }
            catch
            {

            }

        }

        public void UrediSud(int id, string naziv, string adresa, int pbr, int kategorija)
        {
            try
            {
                ManuelaKajkara.Sud sud = new ManuelaKajkara.Sud()
                {
                    ID = id,
                    naziv = naziv,
                    adresa = adresa,
                    pbr = pbr,
                    kategorija = kategorija,
                };
                var bll = new ManuelaKajkara.SudBLL();
                bll.Update(sud);
            }
            catch
            {

            }

        } 
        #endregion

        //original.ID = new_id;
        //        original.naziv = sud.Naziv ;
        //        original.adresa = sud.Adresa;
        //        original.pbr = (int)sud.PBr;
        //        original.kategorija = sud.kategorija;
        //bll.Insert(original);

        #region Fizička Osoba

        public List<ManuelaKajkara.FizOsoba> DajSveFizickeOsobe()
        {
            ManuelaKajkara.FizOsobaBLL bll = new ManuelaKajkara.FizOsobaBLL();
            var lista = bll.DajSveOsobe().ToList();
            return lista;
        }

        public ManuelaKajkara.FizOsoba DajFizickuOsobu(int ID)
        {
            ManuelaKajkara.FizOsobaBLL bll = new ManuelaKajkara.FizOsobaBLL();
            return bll.DajJednuID(ID);
        }

        public void UnesiFizickuOsobu(ManuelaKajkara.FizOsoba osoba)
        {
            ManuelaKajkara.FizOsobaBLL bll = new ManuelaKajkara.FizOsobaBLL();
            bll.Unesi(osoba);
        }

        public void PromijeniFizickuOsobu(ManuelaKajkara.FizOsoba osoba)
        {
            ManuelaKajkara.FizOsobaBLL bll = new ManuelaKajkara.FizOsobaBLL();
            bll.Promijeni(osoba);
        }

        public void ObrisiFizickuOsobu(int ID)
        {
            ManuelaKajkara.FizOsobaBLL bll = new ManuelaKajkara.FizOsobaBLL();
            bll.Brisi(ID);
        }
        #endregion

        #region Kazne_WCF

        public List<ManuelaKajkara.Kazna> DajSveKazne()
        {
            ManuelaKajkara.KaznaBLL bll = new ManuelaKajkara.KaznaBLL();
            var lista = bll.FetchAll().ToList();
            return lista;
        }

        public ManuelaKajkara.Kazna DajKaznu(int ID)
        {
            ManuelaKajkara.KaznaBLL bll = new ManuelaKajkara.KaznaBLL();
            return bll.FetchK(ID);
        }

        public void UnesiKaznu(ManuelaKajkara.Kazna kazna)
        {
            ManuelaKajkara.KaznaBLL bll = new ManuelaKajkara.KaznaBLL();
            bll.Insert(kazna);
        }

        public void PromijeniKaznu(ManuelaKajkara.Kazna kazna)
        {
            ManuelaKajkara.KaznaBLL bll = new ManuelaKajkara.KaznaBLL();
            bll.Update(kazna);
        }

        public void ObrisiKaznu(int ID)
        {
            ManuelaKajkara.KaznaBLL bll = new ManuelaKajkara.KaznaBLL();
            bll.Delete(ID);
        }

        #endregion
    }
}
