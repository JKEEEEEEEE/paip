using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class Hotel
{
    public int? IdHotel { get; set; }

    public string NameHotel { get; set; } = null!;

    public string CategoryHotel { get; set; } = null!;

    public int? PhotoId { get; set; }

    public int? ServicesId { get; set; }

    public int? FoodId { get; set; }

    public int? RoomId { get; set; }

    //public virtual ICollection<City> Cities { get; } = new List<City>();

    //public virtual Food? Food { get; set; }

    //public virtual Photo? Photo { get; set; }

    //public virtual Room? Room { get; set; }

    //public virtual Service? Services { get; set; }
}
