using System;
using System.Collections.Generic;

namespace TourismGoDomain.Core.Entities;

public partial class Users
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();

    public virtual ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
}
