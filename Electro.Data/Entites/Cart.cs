using Electro.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class Cart
    {
        public int Id { get; set; }  
        public int UserId { get; set; }  
        public DateTime CreatedDate { get; set; } 

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastUpdated { get; set; }
        public decimal TotalAmount
        {
            get
            {
                return CartItems?.Sum(item => item.TotalPrice) ?? 0;
            }
        }  // Total amount for the cart, calculated from cart items

        // Navigation properties
        public virtual User User { get; set; }  
        public virtual List<CartItem> CartItems { get; set; }
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }
}
