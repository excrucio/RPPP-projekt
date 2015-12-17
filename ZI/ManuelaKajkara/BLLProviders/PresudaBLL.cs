using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;

namespace ManuelaKajkara.BLLProviders
{
    public class PresudaBLL
    {
        private DAL.EF.PresudaDAL dal = new DAL.EF.PresudaDAL();

        public BindingList<Presuda> FetchAll()
        {
            BindingList<Presuda> list = new BindingList<Presuda>();
            var dalCollection = dal.FetchAll();

            foreach (var dalObject in (IEnumerable<DAL.EF.Presuda>)dalCollection)
            {
                Presuda pre = new Presuda();
                pre.LoadFromDB(dalObject);
                list.Add(pre);
            }

            return list;
        }

        public Presuda Fetch(int id)
        {
            Presuda presuda = null;
            var Objekt = dal.Fetch(id);
            presuda = new Presuda();
            presuda.LoadFromDB(Objekt);
            return presuda;
        }


    }
}