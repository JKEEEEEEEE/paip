using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class Country
{
    public int? IdCountry { get; set; }

    public string NameCountry { get; set; } = null!;

    public int? TouristRoutesId { get; set; }

    public int? CityId { get; set; }

    //public virtual Room? Room { get; set; }

    //public virtual TouristRoute? TouristRoutes { get; set; }

    //public virtual ICollection<Tour> Tours { get; } = new List<Tour>();
}
