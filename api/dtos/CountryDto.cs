using api.Entities;

namespace api.dtos;

public partial class CountryDto : Entities.BaseEnt
{
    public long? Id { get; set; }
    public string? Name { get; set; }
}
