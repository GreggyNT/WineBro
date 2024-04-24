using api.dtos;
using api.Entities;
using api.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("api/v1.0/Wines")]
public class WineController:Controller<Wine,WineDto>
{
    private readonly IBetterService _betterService;
    public WineController(IService<WineDto, Wine> service,IBetterService betterService) : base(service)
    {
        _betterService = betterService;
    }

    [HttpGet("Imgs/{id}")]
    public IActionResult GetImage(long id)
    {
        Byte[] image = System.IO.File.ReadAllBytes($"/home/gregster/.var/app/org.telegram.desktop/data/TelegramDesktop/tdata/temp_data/pics_wino/{id}.png"); 
        return File(image, "image/png");
    }
    
    public override ActionResult<WineDto> Get(long id)
    {
        var wine = _betterService.Read(id);
        return Ok(wine.Adapt<WineDto>());
    }

    public override ActionResult<List<WineDto>> GetAll(long left, long right)
    {
        return Ok(_betterService.GetAll(left, right));
    }

    [HttpGet("Specs")]
    public ActionResult<IEnumerable<WineCellDto>>GetAllSpecs() => Ok( _betterService.GetAllSpecs());
}