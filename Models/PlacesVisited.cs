using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class PlacesVisited
{
    public int? IdPlacesVisited { get; set; }

    public string NamePlacesVisited { get; set; } = null!;

    public string DescriptionPlacesVisited { get; set; } = null!;

    //public virtual ICollection<TouristRoute> TouristRoutes { get; } = new List<TouristRoute>();
}
