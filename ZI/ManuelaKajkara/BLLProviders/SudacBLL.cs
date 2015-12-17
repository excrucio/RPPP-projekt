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
    public class SudacBLL
    {

        private _DAL.SudacDAL dal = new _DAL.SudacDAL();
        private _DAL.OsobaPODAL dal1 = new _DAL.OsobaPODAL();

        //public BindingList<Sudac> FetchAll()
        //{
        //    BindingList<Sudac> list = new BindingList<Sudac>();
        //    var dalCollection = dal.FetchAll();

        //    foreach (var dalObject in (IEnumerable<DAL.EF.Sudac>)dalCollection)
        //    {
        //        Sudac sudac = new Sudac();
        //        sudac.LoadFromDB(dalObject);
        //        list.Add(sudac);
        //    }

        //    return list;
        //}

        //public Sudac Fetch(int? id)
        //{
        //    Sudac sudac = null;
        //    var dalObject = dal.Fetch(id);
        //    var dalObject1 = dal.FetchIDsuda(id);
        //    if (dalObject != null)
        //    {
        //        sudac = new Sudac();
        //        sudac.LoadFromDB(dalObject);
        //    }
        //    return sudac;
        //}

        public Sudac FetchJednog(int? id)
        {
            Sudac sudac = null;
            var dalObject = dal.Fetch(id);  // imam id osobe i id suda
            var dalObject1 = dal1.FetchFO((int)id); // dohvat osobe s id-jem osobe
            if (dalObject != null)
            {
                sudac = new Sudac();
                sudac.LoadFromDB(dalObject, dalObject1);
            }
            return sudac;
        }


        public BindingList<Sudac> FetchAll()
        {
            BindingList<Sudac> suci = new BindingList<Sudac>();
            Sudac sudac = null;
            var dalO = dal.FetchAll();
            foreach (var item in dalO)
            {
                var dalObject1 = dal1.FetchFO((int)item.IDOsobe); // dohvat osobe s id-jem osobe
                if (item != null)
                {
                    sudac = new Sudac();
                    sudac.LoadFromDB(item, dalObject1);
                    suci.Add(sudac);
                }
            }
            return suci;
        }

        // lista sudaca na jednom sudu
        //public BindingList<Sudac> Fetch(int idSuda)
        //{
        //    List<Sudac> suci = new List<Sudac>();
        //    Sudac newSudac = null;
        //    var dalObject = dal.Fetch(idSuda);  //dalObject je lista sudaca
        //    if (dalObject != null)
        //    {
        //        foreach (var item in dalObject)
        //        {
        //            newSudac = new Sudac();
        //            newSudac.LoadFromDB(item);
        //            suci.Add(newSudac);
        //        }
        //    }
        //    return suci;
        //}

        public BindingList<Sudac> FetchFromSud(int idSuda)
        {
            BindingList<Sudac> lista = new BindingList<Sudac>();
            var dalCollection = dal.FetchForIDsuda(idSuda);
            if (dalCollection == null)
            {
                return null;
            }

            else
            {
                foreach (var item in (IEnumerable<DAL.EF.Sudac>)dalCollection)
                {
                    Sudac sudac = new Sudac();
                    var osoba = dal1.FetchFO(item.IDOsobe);
                    sudac.LoadFromDB(item,osoba);
                    lista.Add(sudac);
                }
                return lista;
            }


        }

    //    public void Insert(Sudac a)
    //    {
    //        if ( /* validacija uspješna */  true /*string.IsNullOrEmpty(a.Error)*/)
    //        {
    //            dal.Insert(a.IDOsobe, a.IDSuda);
    //        }
    //        else
    //        {
    //            throw new Exception("Validacija neuspješna: " /*+ a.Error*/);
    //        }
    //    }

        public void Delete(int id)
        {
            dal.Update(id, null);
        }

        public void DeleteSud(int idSuda)
        {
            var lista = dal.FetchForIDsuda(idSuda);
            foreach (DAL.EF.Sudac item in lista)
            {
                dal.Update(item.IDOsobe, null);
            }
        }

        public void Insert(int idOsobe, int idSuda)
        {
                dal.Insert(idOsobe, idSuda);
        }

        public void Update(int idOsobe, int idSuda)
        {
            dal.Update(idOsobe, idSuda);
        }
    }
}
