using api.dtos;
using api.Entities;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("api/v1.0/[controller]")]
public class CountryController:Controller<Country,CountryDto>
{
    public CountryController(IService<CountryDto, Country> service) : base(service)
    {
    }
}