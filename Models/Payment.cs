using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class Payment
{
    public int? IdPayments { get; set; }

    public decimal? PricePayments { get; set; }

    public DateTime? DatePayments { get; set; }

    public string StatusPayments { get; set; } = null!;

    //public virtual ICollection<Tour> Tours { get; } = new List<Tour>();
}
