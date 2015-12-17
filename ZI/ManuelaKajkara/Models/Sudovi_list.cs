using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara.Models
{
    public class Sudovi_list
    {
        public IEnumerable<Sud> SudList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}