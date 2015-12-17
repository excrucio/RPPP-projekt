using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;

namespace ManuelaKajkara.BLLProviders
{
    public class VrKaBLL
    {
        private DAL.EF.VrKaDAL dal = new DAL.EF.VrKaDAL();
        public BindingList<VrKa> FetchAll()
        {
            BindingList<VrKa> list = new BindingList<VrKa>();
            var dalCollection = dal.FetchAll();

            foreach (var dalObject in (IEnumerable<DAL.EF.VrstaKazne>)dalCollection)
            {
                VrKa vrk = new VrKa();
                vrk.LoadFromDB(dalObject);
                list.Add(vrk);
            }

            return list;
        }
    }
}