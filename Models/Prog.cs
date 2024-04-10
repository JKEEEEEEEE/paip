using System;
using System.Collections.Generic;

namespace kursach_diplom_api.Models;

public partial class Prog
{
    public int? IdProg { get; set; }

    public string Tema { get; set; } = null!;
}
