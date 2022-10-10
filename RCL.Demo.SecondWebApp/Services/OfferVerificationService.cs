using Microsoft.Extensions.Options;
using RCL.Core.Api.RequestService;
using RCL.Core.Authorization;

namespace RCL.Demo.SecondWebApp
{
    public class OfferVerificationService : ApiRequestBase, IOfferVerificationService
    {
        private readonly IOptions<ApiOptions> _options;

        public OfferVerificationService(IAuthTokenService authTokenService, IOptions<ApiOptions> options) : base(authTokenService)
        {
            _options = options;
        }

        public async Task<List<EcoResortBooking>> GetUserBookings(string userId)
        {
            string uri = $"{_options.Value.BaseUri}/v1/demo/booking/userid/{userId}/getall";

            List<EcoResortBooking> bookings = await GetListResultAsync<EcoResortBooking>(uri, _options.Value.Resource);

            return bookings;
        }
    }
}
