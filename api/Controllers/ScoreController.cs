using api.dtos;
using api.Entities;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("api/v1.0/[controller]")]
public class ScoreController:Controller<Score,ScoreDto>
{
    public ScoreController(IService<ScoreDto, Score> service) : base(service)
    {
    }
}