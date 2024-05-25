using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismGoDomain.Core.Entities;

namespace TourismGoDomain.Core.DTO
{
    public class ActivityDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        public decimal? Price { get; set; }

        public string? Duration { get; set; }

    }

    public class ActivityDTOList
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }

}
