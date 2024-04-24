using api.dtos;

namespace api.Services;

public interface IBetterService
{
    public WineDto? Read(long? id);
    public IEnumerable<WineDto> GetAll(long left, long right);
    public IEnumerable<WineCellDto> GetAllSpecs();
}