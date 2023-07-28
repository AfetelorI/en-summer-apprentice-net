using System;
using System.Collections.Generic;

namespace TMS.Models;

public partial class Venue
{
    public int VenueId { get; set; }

    public string Location { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<TicketManagerSystem.Api.Models.Event> Events { get; set; } = new List<TicketManagerSystem.Api.Models.Event>();
}
