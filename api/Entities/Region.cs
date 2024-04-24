using System;
using System.Collections.Generic;

namespace api.Entities;

public partial class Region:BaseEnt
{


    public string? Name { get; set; }

    public long? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Producer> Producers { get; set; } = new List<Producer>();
}
