using Electro.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class Cart
    {
        public int Id { get; set; }  // Unique identifier for the cart
        public int UserId { get; set; }  // Identifier of the user who owns the cart
        public DateTime CreatedDate { get; set; }  // Date when the cart was created
        public DateTime? LastUpdated { get; set; }  // Date when the cart was last updated
        public decimal TotalAmount
        {
            get
            {
                return CartItems?.Sum(item => item.TotalPrice) ?? 0;
            }
        }  // Total amount for the cart, calculated from cart items

        // Navigation properties
        public virtual User User { get; set; }  // The user who owns the cart
        public virtual List<CartItem> CartItems { get; set; }  // List of items in the cart

        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }
}
