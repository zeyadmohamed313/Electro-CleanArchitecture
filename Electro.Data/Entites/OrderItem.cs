using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class OrderItem
    {
        public int Id { get; set; }  // Unique identifier for the order item
        public int OrderId { get; set; }  // Identifier of the order
        public int ProductId { get; set; }  // Identifier of the product
        public string ProductName { get; set; }  // Name of the product
        public int Quantity { get; set; }  // Quantity of the product ordered
        public decimal UnitPrice { get; set; }  // Unit price of the product
        public decimal TotalPrice => Quantity * UnitPrice;  // Total price for the order item

        // Navigation properties
        public virtual Order Order { get; set; }  // The order to which this item belongs
        public virtual Product Product { get; set; }  // The product that was ordered
    }
}
