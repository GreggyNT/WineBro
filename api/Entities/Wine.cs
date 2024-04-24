using System;
using System.Collections.Generic;
using api.dtos;

namespace api.Entities;

public partial class Wine:BaseEnt
{

    public string? Name { get; set; }

    public int? YearProduced { get; set; }
    
    public bool? IsNewArr { get; set; }
    
    public bool? IsSpecOffer { get; set; }
    
    public bool? IsBestSeller { get; set;}
    public decimal? AlcoholPercentage { get; set; }

    public long? CategoryId { get; set; }

    public long? ProdId { get; set; }

    public long? ScoreId { get; set; }

    public Grapes?[] Grapes { get; set; }
    
    public long?[] GrapesId { get; set; }

    public string? Description { get; set; }

    public string? Recs { get; set; }

    public decimal? Price { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Producer? Prod { get; set; }

    public virtual Score? Score { get; set; }
}
