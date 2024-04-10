using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class TouristRoute
{
    public int? IdTouristRoutes { get; set; }

    public string NameTouristRoutes { get; set; } = null!;

    public string DescriptionTouristRoutes { get; set; } = null!;

    public string DurationTouristRoutes { get; set; } = null!;

    public DateTime? DateTouristRoutes { get; set; }

    public TimeSpan? TimeTouristRoutes { get; set; }

    public int? MaximumNumberTouristsTouristRoutes { get; set; }

    public int? PhotoId { get; set; }

    public int? PlacesVisitedId { get; set; }

    //public virtual ICollection<Country> Countries { get; } = new List<Country>();

    //public virtual Photo? Photo { get; set; }

    //public virtual PlacesVisited? PlacesVisited { get; set; }
}
