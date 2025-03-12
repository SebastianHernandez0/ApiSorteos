namespace TechLottery.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MercadoPago.Client.Payment;
    using MercadoPago.Client.PaymentMethod;
    using MercadoPago.Config;
    using MercadoPago.Resource.Payment;
    using MercadoPago.Resource.PaymentMethod;

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
            public async Task<Payment> GetPaymentAsync(long paymentId)
            {
                var client = new PaymentClient();
                Payment payment = await client.GetAsync(paymentId);
                return payment;
            }

            public async Task<List<MercadoPago.Resource.PaymentMethod.PaymentMethod>> GetPaymentMethodsAsync()
            {
                var client = new PaymentMethodClient();
                var paymentMethods = await client.ListAsync();
                return paymentMethods;
            }
        }
    }

}
