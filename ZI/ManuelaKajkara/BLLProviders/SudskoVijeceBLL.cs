using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

using _DAL = DAL.EF;

//namespace ManuelaKajkara.BLLProviders
namespace ManuelaKajkara
{
    public class SudskoVijeceBLL
    {
        private _DAL.SudskoVijeceDAL dal = new _DAL.SudskoVijeceDAL();

        public BindingList<SudskoVijece> FetchAll()
        {
            BindingList<SudskoVijece> list = new BindingList<SudskoVijece>();
            var dalCollection = dal.FetchAll();

            foreach (var dalObject in (IEnumerable<DAL.EF.SudskoVijece>)dalCollection)
            {
                SudskoVijece sudskovijece = new SudskoVijece();
                sudskovijece.LoadFromDB(dalObject);
                list.Add(sudskovijece);
            }

            return list;
        }

        public SudskoVijece Fetch(int id)
        {
            SudskoVijece vijece = null;
            var dalObject = dal.Fetch(id);
            if (dalObject != null)
            {
                vijece = new SudskoVijece();
                vijece.LoadFromDB(dalObject);
            }
            return vijece;
        }

        public string Vijece_nazivProcesa(int id)
        {
            _DAL.ProcesDAL dal = new _DAL.ProcesDAL();
            var proces = dal.Fetch(id);
            string nazivProcesa = proces.Naziv;
            return nazivProcesa;
        }

    
    }
}
