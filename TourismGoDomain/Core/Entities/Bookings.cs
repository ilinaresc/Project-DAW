using System;
using System.Collections.Generic;

namespace TourismGoDomain.Core.Entities;

public partial class Bookings
{
    private User? user;

    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ActivityId { get; set; }

    public DateOnly? Date { get; set; }

    public int? NumberOfPeople { get; set; }

    public virtual Activities? Activity { get; set; }

    public virtual User? User { get => user; set => user = value; }
}
