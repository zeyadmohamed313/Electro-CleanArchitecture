using Electro.Data.Helper;
using Electro_CleanArchitecture.Bases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace Electro_CleanArchitecture.Controllers
{
    
    public class PaymentController : AppBaseController
    {
        [HttpPost("create-checkout-session")]
        public IActionResult CreateCheckoutSession([FromBody] CheckoutRequest request)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(request.ProductName) || request.UnitAmount <= 0 || request.Quantity <= 0)
                {
                    return BadRequest(new { error = "Invalid input parameters" });
                }

                // Create a checkout session
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = request.UnitAmount, // Amount in cents
                            Currency = request.Currency.ToLower(), // Currency (e.g., "usd")
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = request.ProductName,
                            },
                        },
                        Quantity = request.Quantity,
                    },
                },
                    Mode = "payment",
                    SuccessUrl = request.SuccessUrl, // URL on payment success
                    CancelUrl = request.CancelUrl,   // URL on payment cancel
                };

                var service = new SessionService();
                var session = service.Create(options);

                return Ok(new { sessionId = session.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
