namespace TMS.Models.Dto
{
    public class OrderPatchDto
    {
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal NumberOfTickets { get; set; }
        public DateTime OrderedAt { get; set; }
    }
}
