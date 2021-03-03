using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace GloballyPaid.Tests
{
    public class PaymentInstrumentServiceTest : BaseTest
    {
        private const string BasePath = "/api/v1/paymentinstrument";

        private readonly PaymentInstrumentService service;

        public PaymentInstrumentServiceTest(
            MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            service = new PaymentInstrumentService(Client);
        }

        [Fact]
        public void List_Empty()
        {
            var expectedResult = new List<PaymentInstrument>();

            StubRequest(HttpMethod.Get, $"{BasePath}/list/customer_id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.List("customer_id");

            AssertRequest(HttpMethod.Get, $"{BasePath}/list/customer_id");
            Assert.Empty(result);
        }

        [Fact]
        public void List()
        {
            var expectedResult = new List<PaymentInstrument>
            {
                GetPaymentInstrument()
            };

            StubRequest(HttpMethod.Get, $"{BasePath}/list/customer_id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.List("customer_id");

            AssertRequest(HttpMethod.Get, $"{BasePath}/list/customer_id");
            Assert.Collection(result, item =>
                Assert.Equal(expectedResult[0].ToJson(), item.ToJson()));
        }

        [Fact]
        public async Task List_Async()
        {
            var expectedResult = new List<PaymentInstrument>
            {
                GetPaymentInstrument()
            };

            StubRequest(HttpMethod.Get, $"{BasePath}/list/customer_id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.ListAsync("customer_id");

            AssertRequest(HttpMethod.Get, $"{BasePath}/list/customer_id");
            Assert.Collection(result, item =>
                Assert.Equal(expectedResult[0].ToJson(), item.ToJson()));
        }

        [Fact]
        public void List_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Get, $"{BasePath}/list/customer_id", HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<GloballyPaidException>(() =>
               service.List("customer_id"));

            Assert.Equal(HttpStatusCode.OK, exception.GloballyPaidResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.GloballyPaidException' was thrown.", exception.Message);
            Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.GloballyPaidResponse.Content);
        }

        [Fact]
        public void List_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Get, $"{BasePath}/list/customer_id", HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<GloballyPaidException>(() =>
               service.List("customer_id"));

            Assert.Equal(HttpStatusCode.BadRequest, exception.GloballyPaidResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.GloballyPaidException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.GloballyPaidResponse.Content);
        }

        [Fact]
        public void Get_Empty()
        {
            var expectedResult = new PaymentInstrument();

            StubRequest(HttpMethod.Get, $"{BasePath}/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Get("id");

            AssertRequest(HttpMethod.Get, $"{BasePath}/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Get()
        {
            var expectedResult = GetPaymentInstrument();

            StubRequest(HttpMethod.Get, $"{BasePath}/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Get("id");

            AssertRequest(HttpMethod.Get, $"{BasePath}/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Get_Async()
        {
            var expectedResult = GetPaymentInstrument();

            StubRequest(HttpMethod.Get, $"{BasePath}/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.GetAsync("id");

            AssertRequest(HttpMethod.Get, $"{BasePath}/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Get_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Get, $"{BasePath}/id", HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<GloballyPaidException>(() =>
               service.Get("id"));

            Assert.Equal(HttpStatusCode.OK, exception.GloballyPaidResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.GloballyPaidException' was thrown.", exception.Message);
            Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.GloballyPaidResponse.Content);
        }

        [Fact]
        public void Get_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Get, $"{BasePath}/id", HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<GloballyPaidException>(() =>
               service.Get("id"));

            Assert.Equal(HttpStatusCode.BadRequest, exception.GloballyPaidResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.GloballyPaidException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.GloballyPaidResponse.Content);
        }

        [Fact]
        public void Create()
        {
            var expectedResult = GetPaymentInstrument();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Create("41111111111111", "123", GetPaymentInstrument(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Create_Async()
        {
            var expectedResult = GetPaymentInstrument();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.CreateAsync("41111111111111", "123", GetPaymentInstrument(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Create_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<GloballyPaidException>(() =>
               service.Create("41111111111111", "123", GetPaymentInstrument(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.OK, exception.GloballyPaidResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.GloballyPaidException' was thrown.", exception.Message);
            Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.GloballyPaidResponse.Content);
        }

        [Fact]
        public void Create_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<GloballyPaidException>(() =>
              service.Create("41111111111111", "123", GetPaymentInstrument(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.BadRequest, exception.GloballyPaidResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.GloballyPaidException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.GloballyPaidResponse.Content);
        }

        [Fact]
        public void Update()
        {
            var expectedResult = GetPaymentInstrument();

            StubRequest(HttpMethod.Put, $"{BasePath}/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Update(GetPaymentInstrument(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Put, $"{BasePath}/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Update_Async()
        {
            var expectedResult = GetPaymentInstrument();

            StubRequest(HttpMethod.Put, $"{BasePath}/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.UpdateAsync(GetPaymentInstrument(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Put, $"{BasePath}/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Update_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Put, $"{BasePath}/id", HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<GloballyPaidException>(() =>
               service.Update(GetPaymentInstrument(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.OK, exception.GloballyPaidResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.GloballyPaidException' was thrown.", exception.Message);
            Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.GloballyPaidResponse.Content);
        }

        [Fact]
        public void Update_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Put, $"{BasePath}/id", HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<GloballyPaidException>(() =>
              service.Update(GetPaymentInstrument(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.BadRequest, exception.GloballyPaidResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.GloballyPaidException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.GloballyPaidResponse.Content);
        }

        [Fact]
        public void Delete()
        {
            StubRequest(HttpMethod.Delete, $"{BasePath}/id", HttpStatusCode.OK, string.Empty);

            service.Delete("id", GetTestRequestOptions());

            AssertRequest(HttpMethod.Delete, $"{BasePath}/id");
        }

        [Fact]
        public async Task Delete_Async()
        {
            StubRequest(HttpMethod.Delete, $"{BasePath}/id", HttpStatusCode.OK, string.Empty);

            await service.DeleteAsync("id", GetTestRequestOptions());

            AssertRequest(HttpMethod.Delete, $"{BasePath}/id");
        }
    }
}
