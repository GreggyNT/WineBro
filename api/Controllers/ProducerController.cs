using api.dtos;
using api.Entities;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("api/v1.0/[controller]")]
public class ProducerController:Controller<Producer,ProducerDto>
{
    public ProducerController(IService<ProducerDto, Producer> service) : base(service)
    {
    }
}