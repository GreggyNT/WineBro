using api.dtos;
using api.Entities;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("api/v1.0/[controller]")]
public class CategoryController:Controller<Category,CategoryDto>
{
    public CategoryController(IService<CategoryDto, Category> service) : base(service)
    {
    }
}