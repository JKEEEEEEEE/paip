using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class User
{
    public int? IdUsers { get; set; }

    public string SurnameUser { get; set; } = null!;

    public string NameUser { get; set; } = null!;

    public string? MiddleNameUser { get; set; }

    public string EmailUser { get; set; } = null!;

    public string LoginUser { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public string? SaltUser { get; set; }

    public string CityUser { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public int? RoleId { get; set; }

    public int? TokenId { get; set; }

    //public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    //public virtual Role? Role { get; set; }

    //public virtual Token? Token { get; set; }

    //public virtual ICollection<Tour> Tours { get; } = new List<Tour>();
}
