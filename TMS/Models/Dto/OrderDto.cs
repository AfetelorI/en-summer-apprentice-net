using System.Data;



namespace TicketManagerSystem.Api.Models.DTO
{
    public class OrderDTO
    {
        public int orderID { get; set; }
        public int customerID { get; set; }
        public int ticketCategoryID { get; set; }
        public int numberOfTickets { get; set; }
        public decimal totalPrice { get; set; }
        public DateTime orderedAt { get; set; }
    }
}