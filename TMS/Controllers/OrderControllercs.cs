using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using TicketManagerSystem.Api.Models.DTO;
using TicketManagerSystem.Api.Repositories;



namespace TicketManagerSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;



        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }



        [HttpGet]
        public ActionResult<List<OrderDTO>> GetAll()
        {
            var orders = _orderRepository.GetAll();



            var dtoOrders = orders.Select(o => new OrderDTO()
            {
                orderID = o.OrderId,
                customerID = o.CustomerId,
                ticketCategoryID = o.TicketCategoryId,
                orderedAt= o.OrderedAt,
                numberOfTickets = o.NumberOfTickets ,
                totalPrice = o.TotalPrice,
               
            });





            return Ok(dtoOrders);
        }




        [HttpGet]
        public ActionResult<OrderDTO> GetById(int id)
        {
            var @order = _orderRepository.GetById(id);



            if (@order == null)
            {
                return NotFound();
            }



            var dtoOrder = new OrderDTO()
            {
                orderID = @order.OrderId,
                customerID = @order.CustomerId,
                ticketCategoryID = @order.TicketCategoryId,
                orderedAt = @order.OrderedAt,
                numberOfTickets = @order.NumberOfTickets,
                totalPrice = @order.TotalPrice,
            };



            return Ok(dtoOrder);
        }



    }
}