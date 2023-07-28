using AutoMapper;
using TicketManagerSystem.Api.Models.DTO;
using TMS.Models;
using TMS.Models.Dto;

namespace TMS.Profiles
{ 
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderPatchDto>().ReverseMap();
        }
    }
}
