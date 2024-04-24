using System;
using System.Collections.Generic;

namespace api.Entities;

public partial class Bottle
{
    public long WineId { get; set; }

    public long SupplyId { get; set; }

    public virtual Spot Supply { get; set; } = null!;

    public virtual Wine Wine { get; set; } = null!;
}
