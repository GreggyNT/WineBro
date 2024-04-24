namespace api.dtos;

public partial class RegionDto : Entities.BaseEnt
{

    public string? Name { get; set; }

    public CountryDto? Country { get; set; }
    
}
