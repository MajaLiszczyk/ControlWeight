using ControlWeightAPI;
using ControlWeightAPI.Entities;
using ControlWeightAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


// Add services to the container.
//builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ControlWeightDbContext>(/*options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))*/);

builder.Services.AddControllers();
builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IMeasureService, MeasureService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
