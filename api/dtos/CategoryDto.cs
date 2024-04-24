using api.Entities;

namespace api.dtos;

public partial class CategoryDto : Entities.BaseEnt
{

    public string? Color { get; set; }
    
    public string? Sweetness { get;set; }

    
}
