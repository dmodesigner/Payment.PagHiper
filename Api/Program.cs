using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AppSettings

builder.Services.Configure<UrlModel>(builder.Configuration.GetSection("Url"));

#endregion

#region IOC

//Injeção de dependência de serviços
builder.Services.AddScoped<IBankSlipService, BankSlipService>();

#endregion


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
