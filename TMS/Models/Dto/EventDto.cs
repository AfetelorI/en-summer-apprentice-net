namespace TMS.Api.Models.Dto
{
    public class OrderDto
    {
        internal int orderID;
        internal int numberOfTickets;
        internal int totalPrice;
        internal DateTime orderedAt;

        public long EventId { get; set; }

        public string EventName { get; set; } = string.Empty;

        public string EventDescription { get; set; }

        public string EventType { get; set; }

        public string Venue { get; set; }

    }
}