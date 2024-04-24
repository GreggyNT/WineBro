using api.Context;
using api.dtos;
using api.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class WineSpec:IBetterService
{
    private AppbContext _context;
    
    public WineSpec()
    {
    }
    public WineSpec(AppbContext context)
    {
        _context = context;
    }
    
    public WineDto? Read(long? id)
    {
        Wine? entity;
        using (_context)
        {
            entity = _context.Find<Wine>(id);
            entity.Category = _context.Categories.Find(entity.CategoryId);
            entity.Prod = _context.Producers.Find(entity.ProdId);
            entity.Score = _context.Scores.Find(entity.ScoreId);
            entity.Prod.Region = _context.Regions.Find(entity.ProdId);
            entity.Prod.Region.Country = _context.Countries.Find(entity.Prod.RegionId);
        }
        return dtos.Converter<Wine, WineDto>.ToDto(entity);
    }

    public IEnumerable<WineDto> GetAll(long left, long right)
    {
        using (_context)
        {
            Wine? entity;
            for (long i = left; i < right; i++)
            {
                entity = _context.Find<Wine>(i);
                entity.Category = _context.Categories.Find(entity.CategoryId);
                entity.Prod = _context.Producers.Find(entity.ProdId);
                entity.Score = _context.Scores.Find(entity.ScoreId);
                entity.Prod.Region = _context.Regions.Find(entity.ProdId);
                entity.Prod.Region.Country = _context.Countries.Find(entity.Prod.RegionId);
                for (int j = 0; j < entity.GrapesId.Length; j++)
                {
                    entity.Grapes[j] = _context.Grapes.Find(entity.GrapesId[j]);
                }
                yield return dtos.Converter<Wine, WineDto>.ToDto(entity);
            }
        }
    }

    public IEnumerable<WineCellDto> GetAllSpecs()
    {
        var res = _context.Wines.Select(x => x).Where(x => x.IsSpecOffer == true).ToList();
        foreach (var entity in res)
        {
            entity.Category =  _context.Categories.Find(entity.CategoryId);
            entity.Prod = _context.Producers.Find(entity.ProdId);
            entity.Score = _context.Scores.Find(entity.ScoreId);
            yield return entity.Adapt<WineCellDto>();
        }
    }
}