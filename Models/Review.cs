using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class Review
{
    public int? IdReviews { get; set; }

    public int EvaluationReviews { get; set; }

    public string DescriptionReviews { get; set; } = null!;

    public DateTime? DateReviews { get; set; }

    public int? UsersId { get; set; }

    //public virtual ICollection<Tour> Tours { get; } = new List<Tour>();

    //public virtual User? Users { get; set; }
}
