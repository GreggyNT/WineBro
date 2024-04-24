using System;
using System.Collections.Generic;

namespace api.Entities;

public partial class Category:BaseEnt
{
    public string? Color { get; set; }
    
    public string? Sweetness { get;set; }

    public virtual ICollection<Wine> Wines { get; set; } = new List<Wine>();
}
