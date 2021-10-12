using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Data.ViewModels
{

    //Need of this class?
    // To assign only inputed value except (primary key,)
    public class BookVM
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Isread { get; set; }

        //By typing ? it becomes Optional
        public DateTime? DateRead { get; set; }

        public int? Rate { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }

        public string CoverUrl { get; set; }

    }
}
