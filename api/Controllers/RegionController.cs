using api.dtos;
using api.Entities;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("api/v1.0/[controller]")]
public class RegionController:Controller<Region,RegionDto>
{
    public RegionController(IService<RegionDto, Region> service) : base(service)
    {
    }
}