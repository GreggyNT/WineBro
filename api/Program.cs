using api.Context;
using api.dtos;
using api.Entities;
using api.Services;
using Mapster;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppbContext>();
builder.Services.AddTransient<IService<WineDto, Wine>,BaseService<Wine,WineDto>>();
builder.Services.AddTransient<IService<CountryDto, Country>,BaseService<Country,CountryDto>>();
builder.Services.AddTransient<IService<ProducerDto, Producer>,BaseService<Producer,ProducerDto>>();
builder.Services.AddTransient<IService<CategoryDto, Category>,BaseService<Category,CategoryDto>>();
builder.Services.AddTransient<IService<ScoreDto, Score>,BaseService<Score,ScoreDto>>();
builder.Services.AddTransient<IBetterService, WineSpec>();
TypeAdapterConfig<Wine, WineCellDto>.NewConfig().Map(sedt => sedt.Prod, s => s.Prod.Name);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();

