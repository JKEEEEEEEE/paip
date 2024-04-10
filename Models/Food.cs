using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class Food
{
    public int? IdFood { get; set; }

    public decimal PriceFood { get; set; }

    public string DishFood { get; set; } = null!;

    public string DescriptionFood { get; set; } = null!;

    //public virtual ICollection<Hotel> Hotels { get; } = new List<Hotel>();
}
