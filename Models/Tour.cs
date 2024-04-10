using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class Tour
{
    public int? IdTours { get; set; }

    public string DescriptionTours { get; set; } = null!;

    public string TypeTours { get; set; } = null!;

    public decimal? PriceTours { get; set; }

    public DateTime? StartDateTours { get; set; }

    public DateTime? EndDateTours { get; set; }

    public string ReservationNumberTours { get; set; } = null!;

    public string BookingDateTours { get; set; } = null!;

    public string BookingStatusTours { get; set; } = null!;

    public int? ReviewsId { get; set; }

    public int? PaymentsId { get; set; }

    public int? UsersId { get; set; }

    public int? PhotoId { get; set; }

    public int? CountryId { get; set; }

    //public virtual Country? Country { get; set; }

    //public virtual Payment? Payments { get; set; }

    //public virtual Photo? Photo { get; set; }

    //public virtual Review? Reviews { get; set; }

    //public virtual User? Users { get; set; }
}
