using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class Room
{
    public int? IdRoom { get; set; }

    public int? NumberAdultsRoom { get; set; }

    public int? NumberChildrenRoom { get; set; }

    public int? PhotoId { get; set; }

    public int? RoomTypeId { get; set; }

    //public virtual ICollection<Country> Countries { get; } = new List<Country>();

    //public virtual ICollection<Hotel> Hotels { get; } = new List<Hotel>();

    //public virtual Photo? Photo { get; set; }

    //public virtual RoomType? RoomType { get; set; }
}
