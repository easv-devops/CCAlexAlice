﻿using CurrencyConverter;
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

app.UseCors(options =>
{
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();







app.MapControllers();



app.Run();   