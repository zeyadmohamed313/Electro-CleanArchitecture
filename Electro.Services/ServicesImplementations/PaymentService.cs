using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe;
using Stripe.Checkout;
using Electro.Services.Abstracts;

namespace Electro.Services.ServicesImplementations
{
    public class PaymentService:IPaymentServices
    {
        private readonly string _stripeSecretKey;

        public PaymentService(IConfiguration configuration)
        {
            _stripeSecretKey = configuration["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = _stripeSecretKey;
        }

        public async Task<PaymentIntent> CreatePaymentIntentAsync(long amount, string currency)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = amount, // Amount in cents (e.g., $10.00 = 1000)
                Currency = currency, // e.g., "usd"
                PaymentMethodTypes = new List<string> { "card" }, // Accept card payments
            };

            var service = new PaymentIntentService();
            return await service.CreateAsync(options);
        }

        public async Task<bool> ConfirmPaymentAsync(string paymentIntentId)
        {
            var service = new PaymentIntentService();
            var intent = await service.ConfirmAsync(paymentIntentId);

            return intent.Status == "succeeded";
        }
    }
}
