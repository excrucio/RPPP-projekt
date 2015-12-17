using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManuelaKajkara.Models
{
    public class Rocista_lista
    {
        public Rociste rociste { get; set; }
        public IEnumerable<Sudionik> sudionici { get; set; }
        public PagingInfo pagingInfoRocista { get; set; }
        public ProcesPD proces { get; set; }
    }
}