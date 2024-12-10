using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class Blog
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string AuthorImageUrl { get; set; }
        public DateTime Date { get; set; }
        public string ContentUrl { get; set; }

    }
}
