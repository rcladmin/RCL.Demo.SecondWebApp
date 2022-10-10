using Microsoft.AspNetCore.Mvc.RazorPages;
using RCL.Core.Identity.Tools;

namespace RCL.Demo.SecondWebApp.Pages.Offer
{
    public class IndexModel : PageModel
    {
        private readonly IOfferVerificationService _offerVerificationService;

        public List<EcoResortBooking> Bookings = new List<EcoResortBooking>();
        public UserClaimsData UserClaimsData { get; set; } = new UserClaimsData();

        public IndexModel(IOfferVerificationService offerVerificationService)
        {
            _offerVerificationService = offerVerificationService;
        }

        public async Task OnGetAsync()
        {
            UserClaimsData = UserClaimsHelper.GetUserDataFromClaims(User);
            Bookings = await _offerVerificationService.GetUserBookings(UserClaimsData.ObjectId);
        }
    }
}
