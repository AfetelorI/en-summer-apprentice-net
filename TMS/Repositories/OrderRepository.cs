using Microsoft.EntityFrameworkCore;
using TicketManagerSystem.Api.Models;
using TMS.Api.Exceptions;
using TMS.Models;

namespace TicketManagerSystem.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EndavaTemaContext _dbContext;



        public OrderRepository()
        {
            _dbContext = new EndavaTemaContext();
        }
        public int Add(Order @order)
        {
            throw new NotImplementedException();
        }


        public void Delete(Order @order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;
            return orders;
        }
        public async Task<Order> GetById(int id)
        {
            var @order = await _dbContext.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
            if (order == null)
                throw new EntityNotFoundException(id, nameof(Order));
            return @order;
        }

        public void Update(Order @order)
        {
            _dbContext.Entry(@order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

     
    }
}