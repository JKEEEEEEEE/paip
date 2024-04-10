using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class Role
{
    public int? IdRole { get; set; }

    public string NameRole { get; set; } = null!;

    //public virtual ICollection<User> Users { get; } = new List<User>();
}
