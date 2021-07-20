using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace GloballyPaid.Tests
{
    public class ChargeServiceTest : BaseTest
    {
        private const string BasePath = "/api/v1/charge";

        private readonly ChargeService service;

        public ChargeServiceTest(
            MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            service = new ChargeService(Client);
        }

        [Fact]
        public void Charge_Authorization_Transaction()
        {
            var expectedResult = GetCharge(captured: false);

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Charge(GetChargeRequest(capture: false), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Charge_Async_Authorization_Transaction()
        {
            var expectedResult = GetCharge(captured: false);

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.ChargeAsync(GetChargeRequest(capture: false), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Charge_Sale_Transaction()
        {
            var expectedResult = GetCharge();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Charge(GetChargeRequest(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Charge_Async_Sale_Transaction()
        {
            var expectedResult = GetCharge();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.ChargeAsync(GetChargeRequest(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Charge_With_Payment_Instrument_Transaction()
        {
            var expectedResult = GetCharge(savePaymentInstrument: true);

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Charge(GetChargeRequest(savePaymentInstrument: true), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Charge_Async_With_Payment_Instrument_Transaction()
        {
            var expectedResult = GetCharge(savePaymentInstrument: true);

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.ChargeAsync(GetChargeRequest(savePaymentInstrument: true), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Charge_Without_Token()
        {
            var expectedTokenizeResult = GetPaymentInstrument();
            StubRequest(HttpMethod.Post, "/api/v1/token", HttpStatusCode.OK, expectedTokenizeResult.ToJson());

            var expectedResult = GetCharge(savePaymentInstrument: true);

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Charge(GetPaymentInstrumentRequest(), 1299, GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Charge_Async_Without_Token()
        {
            var expectedTokenizeResult = GetPaymentInstrument();
            StubRequest(HttpMethod.Post, "/api/v1/token", HttpStatusCode.OK, expectedTokenizeResult.ToJson());

            var expectedResult = GetCharge(savePaymentInstrument: true);

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.ChargeAsync(GetPaymentInstrumentRequest(), 1299, GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Charge_Error_Invalid_ResponseCode()
        {
            var expectedResult = GetChargeWithInvalidResponseCode();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var exception = Assert.Throws<GloballyPaidException>(() =>
                service.Charge(GetChargeRequest(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.BadRequest, exception.HttpStatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.GloballyPaidException' was thrown.", exception.Message);
            Assert.Equal("Not Approved", exception.ErrorMessage);
        }

        [Fact]
        public void Charge_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<GloballyPaidException>(() =>
               service.Charge(GetChargeRequest(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.OK, exception.GloballyPaidResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.GloballyPaidException' was thrown.", exception.Message);
            //Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.GloballyPaidResponse.Content);
        }

        [Fact]
        public void Capture_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<GloballyPaidException>(() =>
               service.Charge(GetChargeRequest(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.BadRequest, exception.GloballyPaidResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.GloballyPaidException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.GloballyPaidResponse.Content);
        }

        private ChargeRequest GetChargeRequest(bool capture = true, bool savePaymentInstrument = false)
        {
            return new ChargeRequest
            {
                Source = "token_id",
                Amount = 1299,
                Capture = capture
            };
        }

        private Charge GetCharge(bool captured = true, bool savePaymentInstrument = false)
        {
            return new Charge
            {
                Id = "id",
                Amount =1299,
                ResponseCode = "00",
                Message = "charged",
                Approved = true,
                Captured = captured,
                NewPaymentInstrument = savePaymentInstrument ? GetPaymentInstrument() : null
            };
        }

        private Charge GetChargeWithInvalidResponseCode()
        {
            return new Charge
            {
                Id = "id",
                Amount = 1299,
                ResponseCode = "02",
                Message = "Not Approved"
            };
        }
    }
}
