using System;
using System.Collections.Generic;

namespace api.Entities;

public partial class Country:BaseEnt
{


    public string? Name { get; set; }

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
