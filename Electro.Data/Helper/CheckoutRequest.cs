using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Helper
{
    public class CheckoutRequest
    {

        public string ProductName { get; set; } // Name of the product
        public int UnitAmount { get; set; }    // Price in cents
        public int Quantity { get; set; }      // Number of items
        public string Currency { get; set; }   // e.g., "usd"
        public string SuccessUrl { get; set; } // Redirect on success
        public string CancelUrl { get; set; }  // Redirect on cancel
    }
}
