using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace GloballyPaid.Tests
{
    [Collection("Globally Paid SDK tests")]
    public class BaseTest
    {
        protected HttpServiceClient Client { get; }

        protected MockHttpClientFixture MockHttpClientFixture { get; }

        public BaseTest(MockHttpClientFixture mockHttpClientFixture)
        {
            MockHttpClientFixture = mockHttpClientFixture;

            var httpClient = new HttpServiceClient(
                new HttpClient(MockHttpClientFixture.MockHandler.Object)
                {
                    BaseAddress = new Uri("https://sandbox.transactions.globallypaid.com")
                });
            Client = new HttpServiceClient(httpClient);

            MockHttpClientFixture.Reset();
        }

        protected void AssertRequest(HttpMethod method, string path)
        {
            MockHttpClientFixture.AssertRequest(method, path);
        }

        protected void StubRequest(HttpMethod method, string path, HttpStatusCode status, string response)
        {
            MockHttpClientFixture.StubRequest(method, path, status, response);
        }

        protected RequestOptions GetTestRequestOptions()
        {
            return new RequestOptions("Test Publishable API Key", "Test Shared Secret", "Test APP ID");
        }

        protected string GetInvalidJson()
        {
            return "{\"errors: \"invalid JSON\"}";
        }

        protected string GetInvalidStatusError()
        {
            return "{\"error\": \"invalid status\"}";
        }

        protected PaymentInstrumentRequest GetPaymentInstrumentRequest()
        {
            return new PaymentInstrumentRequest
            {
                Id = "id",
                Type = PaymentType.CreditCard,
                CustomerId = "customer_id",
                ClientCustomerId = "000000",
                CreditCard = new CreditCard
                {
                    Number = "4111111111111111",
                    Cvv = "123",
                    Brand = "Visa",
                    Expiration = "0725",
                    LastFour = "1111"
                },
                BillingContact = new Contact
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = new Address
                    {
                        Line1 = "Address Line 1",
                        City = "CIty",
                        State = "State",
                        PostalCode = "00000",
                        Country = "Country"
                    },
                    Email = "jane.doe@example.com",
                    Phone = "0000000000"
                }
            };
        }

        protected PaymentInstrument GetPaymentInstrument()
        {
            return new PaymentInstrument
            {
                Id = "id",
                Type = PaymentType.CreditCard,
                CustomerId = "customer_id",
                ClientCustomerId = "000000",
                Brand = "Visa",
                Expiration = "0725",
                LastFour = "1111",
                BillingContact = new Contact
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = new Address
                    {
                        Line1 = "Address Line 1",
                        City = "CIty",
                        State = "State",
                        PostalCode = "00000",
                        Country = "Country"
                    },
                    Email = "jane.doe@example.com",
                    Phone = "0000000000"
                }
            };
        }
    }
}
