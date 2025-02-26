namespace TechLottery.Services
{
    using System;
    using System.Threading.Tasks;
    using MercadoPago.Client.Payment;
    using MercadoPago.Config;
    using MercadoPago.Resource.Payment;

    namespace TechLottery.Services
    {
        public class MercadoPagoService
        {
            public MercadoPagoService(string accessToken)
            {
                MercadoPagoConfig.AccessToken = accessToken;
            }

            public async Task<Payment> CreatePaymentAsync(decimal amount, string description, string email)
            {
                var paymentRequest = new PaymentCreateRequest
                {
                    TransactionAmount = amount,
                    Description = description,
                    PaymentMethodId = "visa",
                    Payer = new PaymentPayerRequest
                    {
                        Email = email
                    }
                };

                var client = new PaymentClient();
                Payment payment = await client.CreateAsync(paymentRequest);
                return payment;
            }
        }
    }

}
