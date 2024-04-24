using api.dtos;
using api.Entities;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public abstract class Controller<T,TV> : ControllerBase where TV:BaseEnt
{
    protected readonly IService<TV,T> _service;

    private int _count;
    public Controller(IService<TV,T> service)
    {
        _count = 20;
        _service = service;
    }
    
    [HttpGet("{left}/{right}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public virtual ActionResult<List<TV>> GetAll(long left, long right) => Ok(_service.GetAll(_count));
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<TV> Create([FromBody] TV dto)
    { 
        dto.Id = _count++;
        return CreatedAtAction("",_service.Create(dto));
    }
    
    [HttpDelete("{id}")]

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult DeleteAuthor(long id)
    {
            
        return _service.Delete(id)?NoContent():NotFound(); 
    }
    
    [HttpPut]
    public ActionResult<TV> UpdateAuthor([FromBody] TV dto)
    {

        return _service.Update(dto) == null ? NotFound(dto) : Ok(dto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public virtual ActionResult<TV> Get(long id) => Ok(_service.Read(id));
}


