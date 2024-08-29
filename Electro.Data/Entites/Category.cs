using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class Category
    {
        public int Id { get; set; } 
        public string Name { get; set; } // The Name Of The Category
        public List<Product> Products { get; set; }
    }
}
