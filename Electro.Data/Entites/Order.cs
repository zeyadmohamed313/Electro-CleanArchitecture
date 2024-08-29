using Electro.Data.Entites.Identity;
using Electro.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class Order
    {
       
            public int Id { get; set; }  // Unique identifier for the order
            public int UserId { get; set; }  // Identifier of the user who placed the order
            public DateTime OrderDate { get; set; }  // Date when the order was placed
            public decimal TotalAmount { get; set; }  // Total amount for the order
            public OrderStatus Status { get; set; }  // Status of the order (e.g., Pending, Shipped, Delivered, Cancelled)
            public string? ShippingAddress { get; set; }  // Shipping address for the order
            public string? BillingAddress { get; set; }  // Billing address for the order
            public DateTime? ShippedDate { get; set; }  // Date when the order was shipped
            public DateTime? DeliveredDate { get; set; }  // Date when the order was delivered
            public string? TrackingNumber { get; set; }  // Tracking number for the shipment

            // Navigation properties
            public virtual User User { get; set; }  // The user who placed the order
            public virtual ICollection<OrderItem> OrderItems { get; set; }  // List of items in the order
        

    }
}
