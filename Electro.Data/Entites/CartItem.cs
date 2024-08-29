using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class CartItem
    {
        public int Id { get; set; }  // Unique identifier for the cart item
        public int CartId { get; set; }  // Identifier of the cart
        public int ProductId { get; set; }  // Identifier of the product
        public string ProductName { get; set; }  // Name of the product
        public int Quantity { get; set; }  // Quantity of the product in the cart
        public decimal UnitPrice { get; set; }  // Unit price of the product
        public decimal TotalPrice => Quantity * UnitPrice;  // Total price for the cart item

        // Navigation properties
        public virtual Cart Cart { get; set; }  // The cart to which this item belongs
        public virtual Product Product { get; set; }  // The product that was added to the cart
    }
}
