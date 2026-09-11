using System.Data;
using HabitsDev.Api.database;
using HabitsDev.Api.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using OpenTelemetry;
using OpenTelemetry.Context.Propagation;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<AppDbContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("default") , 
npgoptions => npgoptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName , Schemas.Application))
);

builder.Services.AddOpenTelemetry()
.ConfigureResource(resours => resours.AddService(builder.Environment.ApplicationName))
.WithTracing(tracing => tracing 
.AddHttpClientInstrumentation()
.AddAspNetCoreInstrumentation())
.WithMetrics(metrics => metrics
.AddAspNetCoreInstrumentation()
.AddHttpClientInstrumentation()
.AddRuntimeInstrumentation())
.UseOtlpExporter();

builder.Logging.AddOpenTelemetry(option =>
{
    option.IncludeFormattedMessage = true;
    option.IncludeScopes = true;
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    await app.ApplyMigrationsAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
