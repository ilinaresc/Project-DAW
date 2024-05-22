using System;
using System.Collections.Generic;

namespace TourismGoDomain.Core.Entities;

public partial class Companies
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Activities> Activities { get; set; } = new List<Activities>();
}
