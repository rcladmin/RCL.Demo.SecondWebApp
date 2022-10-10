#nullable disable

namespace RCL.Demo.SecondWebApp
{
    public class EcoResortBooking
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomNumber { get; set; }
        public string UserId { get; set; }
        public string PaymentId { get; set; }
    }
}
