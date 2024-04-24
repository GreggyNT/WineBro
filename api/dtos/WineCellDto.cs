using api.Entities;

namespace api.dtos;

public class WineCellDto:BaseEnt
{
    
    public int? YearProduced { get; set; }
    
    public string? Prod { get; set; }
    
    public string? Name { get; set; }
    
    public ScoreDto? Score { get; set; }
    
    public CategoryDto? Category { get; set;}
}