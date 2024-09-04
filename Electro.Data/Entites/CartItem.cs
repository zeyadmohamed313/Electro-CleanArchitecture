using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class CartItem
    {
        public int Id { get; set; }  
        public int CartId { get; set; }  
        public int ProductId { get; set; }  
        public string ProductName { get; set; }  
        public int Quantity { get; set; }  
        public decimal UnitPrice { get; set; }  
        public decimal TotalPrice => Quantity * UnitPrice;  

        // Navigation properties
        public virtual Cart Cart { get; set; }  
        public virtual Product Product { get; set; }  
    }
}
