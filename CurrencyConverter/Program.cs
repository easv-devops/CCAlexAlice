using CurrencyConverter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConversionRepository, ConversionRepository>();

builder.Services.AddSingleton<ConversionService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


var app = builder.Build();

app.UseCors("AllowAnyOrigin");

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();



app.Run();   