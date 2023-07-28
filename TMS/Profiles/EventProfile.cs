using AutoMapper;
using TicketManagerSystem.Api.Models;
using TMS.Api.Models.Dto;

namespace TicketManagerSystem.Api.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, OrderDto>().ReverseMap();
            CreateMap<Event, EventPatchDto>().ReverseMap();
        }
    }
}