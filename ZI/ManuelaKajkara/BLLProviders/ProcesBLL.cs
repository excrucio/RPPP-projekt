using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace ManuelaKajkara
{
    public class ProcesBLL
    {
        private ProcesDAL dal = new ProcesDAL();

        public BindingList<ProcesPD> FetchAll()
        {
            BindingList<ProcesPD> lista = new BindingList<ProcesPD>();
            var dalCollection = dal.FetchAll();
            foreach (var dalObject in (IEnumerable<DAL.EF.Proces>)dalCollection)
            {
                ProcesPD proces = new ProcesPD();
                proces.LoadFromDB(dalObject);
                lista.Add(proces);
            }
            return lista;
        }

        public ProcesPD Fetch(int IDProcesa)
        {
            ProcesPD proces = null;
            var dalObject = dal.Fetch(IDProcesa);
            if (dalObject != null)
            {
                proces = new ProcesPD();
                proces.LoadFromDB(dalObject);
            }
            return proces;

        }
        public List<ProcesPD> TraziNazSudVrs(string naziv="",int sud=-777, string vrsta="-777")
        {
            List<ProcesPD> lista = new List<ProcesPD>();
            var dalCollection = dal.TraziNazSudVrs(naziv);
            if (vrsta == "-777")
            {
                if (sud == -777)
                { 
                }
                else
                {
                    dalCollection = dal.TraziNazSudVrs(naziv, sud);
                }
            }
            else {
                    dalCollection = dal.TraziNazSudVrs(naziv, sud, vrsta);
            }
            
            foreach (var dalObject in (IEnumerable<DAL.EF.Proces>)dalCollection)
            {
                ProcesPD proces = new ProcesPD();
                proces.LoadFromDB(dalObject);
                lista.Add(proces);
            }
            return lista;
        }

        public List<String> FetchAllNaziv()
        {
            return new ProcesDAL().FetchAllNaziv();

        }
    }
}
