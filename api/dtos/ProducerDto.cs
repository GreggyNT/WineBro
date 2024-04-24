using api.Entities;

namespace api.dtos;

public partial class ProducerDto : Entities.BaseEnt
{

    public string? Name { get; set; }

    public string? Details { get; set; }
    
    public virtual RegionDto? Region { get; set; }
}
