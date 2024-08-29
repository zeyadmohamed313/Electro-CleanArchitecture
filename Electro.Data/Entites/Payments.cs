using Electro.Data.Entites.Identity;
using Electro.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class Payments
    {
        public int Id { get; set; }  // Unique identifier for the payment
        public int OrderId { get; set; }  // Identifier of the order associated with the payment
        public int UserId { get; set; }  // Identifier of the user who made the payment
        public decimal Amount { get; set; }  // Amount paid
        public PaymentMethod Method { get; set; }  // Payment method used (e.g., CreditCard, PayPal)
        public PaymentStatus Status { get; set; }  // Status of the payment (e.g., Pending, Completed, Failed)
        public DateTime PaymentDate { get; set; }  // Date and time when the payment was made
        public DateTime? ConfirmationDate { get; set; }  // Date and time when the payment was confirmed

        // Optional attributes for storing transaction details
        public string? TransactionId { get; set; }  // Unique transaction identifier from the payment gateway

        // Navigation properties
        public virtual Order Order { get; set; }  // The order associated with the payment
        public virtual User User { get; set; }  // The user who made the payment

    }
}
