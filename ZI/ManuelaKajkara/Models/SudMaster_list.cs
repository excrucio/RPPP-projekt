using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara.Models
{
    public class SudMaster_list
    {
        public Sud sud{ get; set; }
        public List<Sudac> suci { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}