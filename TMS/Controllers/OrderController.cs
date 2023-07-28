using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TicketManagerSystem.Api.Models.DTO;
using TicketManagerSystem.Api.Repositories;
using TMS.Api.Models;
using TMS.Api.Models.Dto;
using TMS.Api.Repositories;
using TMS.Models;
using TMS.Models.Dto;

namespace TMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public OrderController(IOrderRepository orderRepository, IMapper mapper, ILogger<OrderController> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<OrderDTO>> GetAll()
        {
            var orders = _orderRepository.GetAll();

            var dtoOrders = orders.Select(o => new OrderDto()
            {
                orderID = o.OrderId,
                numberOfTickets = o.NumberOfTickets,
                totalPrice = o.TotalPrice,
                orderedAt = o.OrderedAt
            }) ;

            return Ok(dtoOrders);
        }


        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var @order = await _orderRepository.GetById(id);

            var orderDto = _mapper.Map<OrderDto>(@order);

            return Ok(orderDto);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            if (orderPatch == null) throw new ArgumentNullException(nameof(orderPatch));
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderId);
            if (orderEntity == null)
            {
                return NotFound();
            }
            //if (!_orderRepository.IsNullOrEmpty(orderEntity)) orderEntity.numberOfTickets = orderPatch.NumberOfTickets;
            //if (!_orderRepository.IsNullOrEmpty(orderEntity)) orderEntity.orderedAt = orderPatch.orderedAt;
            _orderRepository.Update(orderEntity);
            _mapper.Map(orderPatch, orderEntity);
     
            return Ok(orderEntity);
        }

    

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(orderEntity);
            return NoContent();
        }
    }
}