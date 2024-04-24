using api.Context;
using api.dtos;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class BaseService<T,TV>:IService<TV,T> where T:BaseEnt
{
    private AppbContext _context;
    
    public BaseService()
    {
    }
    public BaseService(AppbContext context)
    {
        _context = context;
    }

    public TV? Create(TV dto)
    {
        var entity = dtos.Converter<T, TV>.FromDto(dto);
        using (_context)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return Read(entity.Id);
        }
        
    }


    public TV? Read(long? id)
    {
        T? entity;
        using (_context)
        {
            entity = _context.Find<T>(id);
        }

        return dtos.Converter<T, TV>.ToDto(entity);
    }

    public TV? Update(TV dto)
    {
        var entity = dtos.Converter<T, TV>.FromDto(dto);
        using (_context)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return Read(entity.Id);
        }
        
    }

    public bool Delete(long? id)
    {
        bool res;
        using (_context)
        {
            res = _context.Remove(_context.Find<T>(id)).State == EntityState.Deleted;
            _context.SaveChanges();
        }

        return res;
    }

    public IEnumerable<TV> GetAll(int count)
    {
        for (int i = 0; i < count; i++)
            yield return Read(i);
    }
}
