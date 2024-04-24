using api.Entities;

namespace api.dtos;

public partial class WineDto  : Entities.BaseEnt
{
    public string? Name { get; set; }
    
    public bool? IsNewArr { get; set; }
    
    public bool? IsSpecOffer { get; set; }

    public bool? IsBestSeller { get; set; }

    public int? YearProduced { get; set; }
    
    public decimal? Price { get; set; }

    public decimal? AlcoholPercentage { get; set; }

    public CategoryDto? Category { get; set; }

    public ProducerDto? Prod { get; set; }

    public ScoreDto? Score { get; set; }
    
    public GrapesDto?[] Grapes { get; set; }
    
    public long?[] GrapesId { get; set; }
    
}
