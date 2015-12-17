using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using System.ComponentModel;
using System.Data;

namespace ManuelaKajkara
{
    public class OsobaBLL
    {

    private DAL.EF.FizickaOsobaDAL dal = new DAL.EF.FizickaOsobaDAL();

		public BindingList<FizickaOsoba> FetchAll()
		{
			BindingList<FizickaOsoba> list = new BindingList<FizickaOsoba>();
            var dalCollection = dal.FetchAll();
				foreach (var dalObject in (IEnumerable<DAL.EF.FizickaOsoba>) dalCollection)
				{
					FizickaOsoba Osoba = new FizickaOsoba();
					Osoba.LoadFromDB(dalObject);
					list.Add(Osoba);					
				}
			
			return list;
		}
        public List<FizickaOsoba> TraziIP(string ime, string prezime) {

            FizickaOsoba Osoba = null;
            var dalObject = dal.TraziIP(ime,prezime);
            List<FizickaOsoba> osobe = new List<FizickaOsoba>();
            if (dalObject != null)
            {
                foreach (var os in dalObject){
                    Osoba = new FizickaOsoba();
                    Osoba.LoadFromDB(os);
                    osobe.Add(Osoba);
                }
            }
            return osobe;
        }
        public string DajAdresu(int id) {
            return dal.DajAdresu(id);
        }
		public FizickaOsoba Fetch(int sifOsoba)
		{
			FizickaOsoba Osoba = null;
			var dalObject = dal.Fetch(sifOsoba);
			if (dalObject != null)
			{
				
					Osoba = new FizickaOsoba();
					Osoba.LoadFromDB(dalObject);
			}
			return Osoba;
			
		}

        public List<FizickaOsoba> FetchLookup()
        {
            Dictionary<int, string> lookupData = dal.FetchLookup();
            var list = lookupData.Select(d => new FizickaOsoba { IDOsobe = d.Key, Ime = d.Value }).ToList();
            return list;
        }

        public FizickaOsoba DajOsobu(int Indeks)
        {
            FizickaOsoba fo = null;
            var Objekt = dal.DajFO(Indeks);
            fo = new FizickaOsoba();
            fo.LoadFromDB(Objekt);
            return fo;
        }

        public void Update(FizickaOsoba oso) {

            DAL.EF.FizickaOsoba osoba = new DAL.EF.FizickaOsoba
            {
                IDOsobe=oso.IDOsobe,
                Ime = oso.Ime,
                Prezime = oso.Prezime,
                ImeOca = oso.ImeOca,
                DatumRod = oso.DatumRod,
                JMBG = oso.JMBG
            };
            
            dal.Update(osoba);

            OsobaDAL dalOS = new OsobaDAL();
            DAL.EF.Osoba coek = new Osoba
            {
                IDOsobe=oso.IDOsobe,
                UlicaIKucniBr = oso.Adresa,
                PBr = oso.pbr
            };
            
            dalOS.Update(coek);
        }

	}
}
