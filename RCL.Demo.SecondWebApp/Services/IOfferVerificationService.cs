namespace RCL.Demo.SecondWebApp
{
    public interface IOfferVerificationService
    {
        Task<List<EcoResortBooking>> GetUserBookings(string userId);
    }
}
