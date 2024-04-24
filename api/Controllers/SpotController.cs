using api.dtos;
using api.Entities;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("api/v1.0/[controller]")]
public class SpotController:Controller<Spot,SpotDto>
{
    public SpotController(IService<SpotDto, Spot> service) : base(service)
    {
    }
}