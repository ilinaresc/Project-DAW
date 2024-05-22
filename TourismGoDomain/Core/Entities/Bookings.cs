using System;
using System.Collections.Generic;

namespace TourismGoDomain.Core.Entities;

public partial class Bookings
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ActivityId { get; set; }

    public DateOnly? Date { get; set; }

    public int? NumberOfPeople { get; set; }

    public virtual Activities? Activity { get; set; }

    public virtual Users? User { get; set; }
}
