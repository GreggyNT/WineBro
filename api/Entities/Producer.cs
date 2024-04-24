using System;
using System.Collections.Generic;

namespace api.Entities;

public partial class Producer:BaseEnt
{


    public string? Name { get; set; }

    public string? Details { get; set; }

    public long? RegionId { get; set; }

    public virtual Region? Region { get; set; }

    public virtual ICollection<Wine> Wines { get; set; } = new List<Wine>();
}
