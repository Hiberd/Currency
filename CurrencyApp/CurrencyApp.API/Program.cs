using CurrencyApp.BusinessLogic;
using CurrencyApp.DataAccess;
using CurrencyApp.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext<CurrencyAppDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("CurrencyDb"));
});

builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<DataAccessMappingProfile>();
});

builder.Services.AddScoped<ICurrencyServices, CurrencyServices>();
builder.Services.AddScoped<ICurrencyPasrsingService, CurrencyPasrsingService>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
