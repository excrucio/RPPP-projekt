using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DAL = DAL.EF;

using System.Data;
using System.ComponentModel;

namespace ManuelaKajkara
{

    public class MjestoBLL
    {
        private _DAL.MjestoDAL dal = new _DAL.MjestoDAL();

        public BindingList<Mjesto> FetchAll()
        {
            BindingList<Mjesto> list = new BindingList<Mjesto>();
            var dalCollection = dal.FetchAll();

            foreach (var dalObject in (IEnumerable<DAL.EF.Mjesto>)dalCollection)
            {
                Mjesto mjesto = new Mjesto();
                mjesto.LoadFromDB(dalObject);
                list.Add(mjesto);
            }

            return list;
        }

        public List<Mjesto> FetchLookup()
        {
            Dictionary<int, string> lookupData = dal.FetchLookup();
            var list = lookupData.Select(d => new Mjesto { pbr = d.Key, naziv= d.Value }).ToList();
            return list;
        }

        public int DajPoImenu(string ime)
        {
            int pbr = dal.DajPoImenu(ime);
            return pbr;
        }

        public Mjesto Fetch(int? pbr)
        {
            Mjesto mjesto = new Mjesto();
            var dalObject = dal.Fetch(pbr);
            if (dalObject != null)
            {
                    mjesto = new Mjesto();
                    mjesto.LoadFromDB(dalObject);
            }
            return mjesto;

        }

        public IEnumerable<string> DajSvaImena()
        {
            return dal.DajSvaImena();
        }

        public void Add(Mjesto a)
        {
            if ( /* validacija uspješna */  true /*string.IsNullOrEmpty(a.Error)*/)
            {
                dal.Insert(a.naziv, a.pbr);
                // public void Insert(int id, string naziv, string adresa, int pbr, int kategorija)
            }
            else
            {
                throw new Exception("Validacija neuspješna: " /*+ a.Error*/);
            }
        }

        public void Update(Mjesto a, int id)
        {
            var lista = dal.FetchAll();
            List<int> listaPbr = new List<int>();
            var original = dal.Fetch(id);

            foreach (var m in lista)
            {
                if(m.PBr!=original.PBr)
                    listaPbr.Add(m.PBr);
            }

            if (!listaPbr.Contains(a.pbr))
            {
                dal.Update(a.naziv, a.pbr);
            }
            else
            {
                throw new Exception("Pbr već postoji!");
            }
        }

        public void Delete(Mjesto a)
        {

            _DAL.SudDAL dalSud = new _DAL.SudDAL();
            var lista = dalSud.FetchForPBR(a.pbr);

            _DAL.OsobaDAL dalOsoba = new _DAL.OsobaDAL();
            var lista1 = dalOsoba.FetchForPBR(a.pbr);

            if (lista.Count() != 0) throw new Exception("Brisanje nije izvedivo");
            else if (lista1.Count() != 0) throw new Exception("Brisanje nije izvedivo");
            else dal.Delete(a.pbr);
            
        }
    }
}
