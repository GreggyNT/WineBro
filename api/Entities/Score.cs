using System;
using System.Collections.Generic;

namespace api.Entities;

public partial class Score:BaseEnt
{
  

    public int? Sweetness { get; set; }

    public int? Bitterness { get; set; }

    public int? Acidity { get; set; }

    public decimal? Overall { get; set; }

    public virtual ICollection<Wine> Wines { get; set; } = new List<Wine>();
}
