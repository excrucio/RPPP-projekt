using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara.Models
{
    public class Sudovi_listWCF
    {
        public IEnumerable<ServiceReference1.Sud> SudList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}