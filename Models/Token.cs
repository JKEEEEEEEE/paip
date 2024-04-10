using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class Token
{
    public int? IdToken { get; set; }

    public string NameToken { get; set; } = null!;

    public DateTime? DateTimeToken { get; set; }

    //public virtual ICollection<User> Users { get; } = new List<User>();
}
