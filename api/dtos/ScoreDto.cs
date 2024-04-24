using api.Entities;

namespace api.dtos;

public partial class ScoreDto  : Entities.BaseEnt
{

    public int? Sweetness { get; set; }

    public int? Bitterness { get; set; }

    public int? Acidity { get; set; }

    public decimal? Overall { get; set; }
    

}
