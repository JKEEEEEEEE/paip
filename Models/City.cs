using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class City
{
    public int? IdCity { get; set; }

    public string NameCity { get; set; } = null!;

    public int? HotelId { get; set; }

    //public virtual Hotel? Hotel { get; set; }
}
