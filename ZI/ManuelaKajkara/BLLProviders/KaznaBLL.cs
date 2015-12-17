using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.EF;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace ManuelaKajkara
{
    /// <summary>
    /// Razred koji pruža objekte BLL sloja.
    /// </summary>
    public class KaznaBLL
    {
        /// <summary>
        /// Pružatelj funkcionalnosti DAL sloja
        /// </summary>
        private DAL.EF.KaznaDAL dal = new DAL.EF.KaznaDAL();

        /// <summary>
        /// Postupak za dohvat kazni neke osobe
        /// </summary>
        /// <param name="sifOsoba">ID osobe čije kazne se dohvaćaju</param>
        /// <returns>Rezultat je lista kazni</returns>
        public BindingList<Kazna> Fetch(int sifOsoba)
        {
            BindingList<Kazna> list = new BindingList<Kazna>();
            var dalCollection = dal.FetchAll(sifOsoba);
            foreach (var dalObject in (IEnumerable<DAL.EF.Kazna>)dalCollection)
            {
                Kazna Kazna = new Kazna();
                Kazna.LoadFromDB(dalObject);
                list.Add(Kazna);
            }
            return list;
        }

        /// <summary>
        /// Postupak za dohvat svih kazni 
        /// </summary>
        /// <returns>Rezultat je lista svih dohvaćenih kazni</returns>
        public BindingList<Kazna> FetchAll()
        {
            BindingList<Kazna> list = new BindingList<Kazna>();
            var dalCollection = dal.FetchSve();
            foreach (var dalObject in (IEnumerable<DAL.EF.Kazna>)dalCollection)
            {
                Kazna Kazna = new Kazna();
                Kazna.LoadFromDB(dalObject);
                list.Add(Kazna);
            }
            return list;
        }

        /// <summary>
        /// Postupak za dohvat vrste kazne
        /// </summary>
        /// <param name="id">ID kazne čija se vrsta dohvaća</param>
        /// <returns>Rezultat je vrsta kazne</returns>
        public string vrstaKazne(int id) {
            string qv = dal.vrstaKazne(id).ToString();
            return qv;
        }

        /// <summary>
        /// Postupak za dohvat vrste presude
        /// </summary>
        /// <param name="id">ID presude čija se vrsta dohvaća</param>
        /// <returns>Rezultat je vrsta presude</returns>
        public string vrstaPresude(int idPre)
        {
            string qv = dal.vrstaPresude(idPre).ToString();
            return qv;
        }

        /// <summary>
        /// Postupak za dodavanje kazne u bazu
        /// </summary>
        /// <param name="a">Kazna koja se dodaje u bazu</param>
        public void Insert(Kazna a)
        {
            if (string.IsNullOrEmpty(a.Error))
            {
                dal.Insert(a.IDOsobe, (int)a.IDPresude, a.Vrsta, a.Iznos, a.Opis);
            }
            else
            {
                throw new Exception("Validacija neuspješna: " + a.Error);
            }
        }

        /// <summary>
        /// Postupak za brisanje kazne iz baze
        /// </summary>
        /// <param name="id">ID kazne koja se briše</param>
        public void Delete(int id)
        {
            dal.Delete(id);
        }

        /// <summary>
        /// Postupak za spremanje izmjenjene kazne u bazu
        /// </summary>
        /// <param name="a">izmjenejna kazna koja se sprema u bazu</param>
        public void Update(Kazna a)
        {
            if (string.IsNullOrEmpty(a.Error))
            {
                dal.Update(a.IDKazne,(int)a.IDPresude, a.Vrsta, a.Iznos, a.Opis);
            }
            else
            {
                throw new Exception(a.Error);
            }
        }

        /// <summary>
        /// Postupak za dohvat jedne kazne
        /// </summary>
        /// <param name="id">ID kazne koja se dohvaća</param>
        /// <returns>Rezultat je dohvaćena kazna</returns>
        public Kazna DajKaznu(int id)
        {
            var kaz = dal.Vidi(id);
            Kazna vrati = new Kazna
            {
                IDKazne = (int)kaz.IDKazne,
                IDOsobe = (int)kaz.IDOsobe,
                IDPresude = (int)kaz.IDPresude,
                Vrsta = (int)kaz.Vrsta,
                Naziv = new KaznaBLL().vrstaKazne((int)kaz.Vrsta).ToString(),
                Opis = kaz.Opis,
                Iznos = (decimal)kaz.Iznos,
                Osoba = new FizickaOsobaBLL().Fetch((int)kaz.IDOsobe)
            };
            return vrati;
        }

        /// <summary>
        /// Postupak za dohvat jedne kazne
        /// </summary>
        /// <param name="id">ID kazne koja se dohvaća</param>
        /// <returns>Rezultat je dohvaćena kazna</returns>
        public Kazna FetchK(int id)
        {
            var dalCollection = dal.Vidi(id);

                Kazna kazna = new Kazna();
                kazna.LoadFromDB(dalCollection);
            return kazna;
        }

    }
}
