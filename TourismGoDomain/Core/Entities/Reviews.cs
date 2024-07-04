using System;
using System.Collections.Generic;

namespace TourismGoDomain.Core.Entities;

public partial class Reviews
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ActivityId { get; set; }

    public string? Comment { get; set; }

    public int? Rating { get; set; }

    public virtual Activities? Activity { get; set; }

    public virtual User? User { get; set; }
}
