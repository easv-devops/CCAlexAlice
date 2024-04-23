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


var app = builder.Build();

app.UseRouting();
    app.UseSwagger();
    app.UseSwaggerUI();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://62.171.178.179:5001")
            .AllowAnyMethod()
            .AllowAnyHeader());
});


/*app.UseCors(options =>
{
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});*/

app.UseCors("AllowOrigin");

app.MapControllers();



app.Run();   