using System;
using System.Collections.Generic;

namespace TourismGoDomain.Core.Entities;

public partial class Activities
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public decimal? Price { get; set; }

    public string? Duration { get; set; }

    public int? CompanyId { get; set; }

    public virtual ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();

    public virtual Companies? Company { get; set; }

    public virtual ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
}
