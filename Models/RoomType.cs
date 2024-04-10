using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class RoomType
{
    public int? IdRoomType { get; set; }

    public string NameRoomType { get; set; } = null!;

    public decimal? PriceRoomType { get; set; }

    //public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
