﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketManagerSystem.Api.Models;

using TMS.Api.Exceptions;
using TMS.Api.Models;
using TMS.Models;

namespace TMS.Api.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EndavaTemaContext _dbContext;

        public EventRepository()
        {
            _dbContext = new EndavaTemaContext();
        }

        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public void Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events;

            return events;
        }

        public async Task<Event> GetById(long id)
        {
            var @event = await _dbContext.Events.Where(e => e.EventId == id).FirstOrDefaultAsync();

            if (@event == null)
                throw new EntityNotFoundException(id, nameof(Event));

            return @event;
        }

        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}